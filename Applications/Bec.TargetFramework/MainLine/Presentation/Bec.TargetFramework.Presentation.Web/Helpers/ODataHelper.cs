using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web;

namespace Bec.TargetFramework.Presentation.Web.Helpers
{
    public class Result
    {
        public List<string> Select { get; set; }
        public Dictionary<string, Result> Expand { get; set; }

        public Result()
        {
            Select = new List<string>();
            Expand = new Dictionary<string, Result>();
        }

        public string ToODataString(string key, bool includeRowVersions)
        {
            return ts(key, true, includeRowVersions);
        }

        //build the select query
        private string ts(string key, bool root, bool includeRowVersions)
        {
            var sb = new StringBuilder();
            if (root) sb.Append("&");
            sb.Append("$" + key + "=");
            IEnumerable<string> list = Select;
            if (includeRowVersions) list = list.Concat(new List<string> { "RowVersion" });
            sb.Append(string.Join(",", list));

            if (Expand.Any())
            {
                if (key == "orderby") throw new Exception("orderby doesn't support navigation properties yet.");
                sb.Append(root ? "&" : ";");
                sb.Append("$expand=");

                bool first = true;
                foreach (var x in Expand)
                {
                    if (!first) sb.Append(",");
                    first = false;
                    sb.Append(x.Key);
                    sb.Append("(");
                    sb.Append(x.Value.ts(key, false, includeRowVersions));
                    sb.Append(")");
                }
            }
            return sb.ToString();
        }
    }

    public static class ODataHelper
    {
        //return a select query for OData
        public static string Select<T>(Expression<Func<T, object>> expression, bool includeRowVersions = false)
        {
            Result r = new Result();
            makeNewExpression(expression.Body as NewExpression, r);
            return r.ToODataString("select", includeRowVersions);
        }

        public static string OrderBy<T>(Expression<Func<T, object>> expression)
        {
            Result r = new Result();
            makeNewExpression(expression.Body as NewExpression, r);
            return r.ToODataString("orderby", false);
        }

        private static void makeNewExpression(NewExpression nx, Result r)
        {
            foreach (var x in nx.Arguments)
            {
                MethodCallExpression sel = x as MethodCallExpression;
                if (sel != null)
                    subSelect(sel, r);
                else
                {
                    MemberExpression mx = x as MemberExpression;
                    MemberExpression m = mx.Expression as MemberExpression;

                    Stack<string> s = new Stack<string>();
                    while (m != null)
                    {
                        s.Push(m.Member.Name);
                        m = m.Expression as MemberExpression;
                    }

                    Result level = r;
                    while (s.Count > 0)
                    {
                        string ex = s.Pop();
                        if (!level.Expand.ContainsKey(ex)) level.Expand.Add(ex, new Result());
                        level = level.Expand[ex];
                    }
                    level.Select.Add(mx.Member.Name);
                }
            }
        }

        private static void subSelect(MethodCallExpression sel, Result r)
        {
            MemberExpression prop = sel.Arguments[0] as MemberExpression;
            LambdaExpression temp = sel.Arguments[1] as LambdaExpression;

            if (!r.Expand.ContainsKey(prop.Member.Name)) r.Expand.Add(prop.Member.Name, new Result());
            r = r.Expand[prop.Member.Name];

            makeNewExpression(temp.Body as NewExpression, r);
        }

        //create an expression to use with Expression.And etc
        public static Expression Expression<T>(Expression<Func<T, bool>> expression)
        {
            return expression.Body;
        }

        //return a string representation of the lambda func
        public static string Filter<T>(Expression<Func<T, bool>> expression)
        {
            return "&$filter=" + pre(expression.Body);
        }

        //return a string representation of the expression
        public static string Filter(Expression expression)
        {
            return "&$filter=" + pre(expression);
        }

        //pre-order tree walk the expression. This currently supports standard odata boolean operators,
        //some string and math functions, arbitrary depth in the object graph and evaluating runtime values in the expression.
        static string pre(Expression ex, MemberExpression parentExpr = null)
        {
            if (ex is BinaryExpression)
            {
                var bx = ex as BinaryExpression;
                string l = pre(bx.Left);
                string o = getOp(bx.NodeType);
                string r = pre(bx.Right);
                return string.Format("({0} {1} {2})", l, o, r);
            }
            else if (ex is MemberExpression)
            {
                var mx = ex as MemberExpression;
                if (mx.Expression is ConstantExpression)
                {
                    return pre(mx.Expression, mx);
                }
                else
                {
                    var s = new Stack<string>();
                    while (mx != null)
                    {
                        s.Push(mx.Member.Name);
                        mx = mx.Expression as MemberExpression;
                    }
                    return string.Join("/", s);
                }
            }
            else if (ex is ConstantExpression)
            {
                var cx = ex as ConstantExpression;
                if (parentExpr == null)
                    return constantVal(cx.Value, cx.Type);
                else
                {
                    var f = parentExpr.Member as FieldInfo;
                    var p = parentExpr.Member as PropertyInfo;
                    if (f != null) return constantVal(f.GetValue(cx.Value), f.FieldType);
                    if (p != null) return constantVal(p.GetValue(cx.Value), p.PropertyType);
                    throw new NotSupportedException("Type of constant not supported");
                }
            }
            else if (ex is MethodCallExpression)
            {
                var mex = ex as MethodCallExpression;
                string method = getMethod(mex.Method);
                if (method != null)
                {
                    string body = pre(mex.Object);
                    string args = string.Join(",", mex.Arguments.Select(a => pre(a)));
                    var b = new List<string>();
                    if (!string.IsNullOrEmpty(body)) b.Add(body);
                    if (!string.IsNullOrEmpty(args)) b.Add(args);
                    var bs = string.Join(",", b);
                    return string.Format("{0}({1})", method, bs);
                }
                else
                {
                    //try calling method here
                    var val = mex.Method.Invoke(null, null);
                    return val.ToString();
                }
            }
            else if (ex is UnaryExpression)
            {
                var ux = ex as UnaryExpression;
                var ret = pre(ux.Operand);
                if (ux.NodeType == ExpressionType.Not) ret += " eq false";
                return ret;
            }
            return "";
        }

        private static string constantVal(object obj, Type t)
        {
            if (obj == null) return "null";
            if (t.Name == "String")
                return string.Format("'{0}'", escape(obj.ToString()));
            else if (t.Name == "Boolean")
                return obj.ToString().ToLower();
            else if (t.Name == "DateTime")
                return ((DateTime)obj).ToUniversalTime().ToString("O");
            else
                return obj.ToString();
        }

        private static string escape(string s)
        {
            return s
                .Replace("%", "%25")
                .Replace("'", "''")
                .Replace("+", "%2B")
                .Replace("/", "%2F")
                .Replace("?", "%3F")
                .Replace("#", "%22")
                .Replace("&", "%26");
        }

        //return valid OData operators
        private static string getOp(ExpressionType expressionType)
        {
            switch (expressionType)
            {
                case ExpressionType.Add: return "add";
                case ExpressionType.And: return "and";
                case ExpressionType.AndAlso: return "and";
                case ExpressionType.Decrement: return "sub";
                case ExpressionType.Divide: return "div";
                case ExpressionType.Equal: return "eq";
                case ExpressionType.GreaterThan: return "gt";
                case ExpressionType.GreaterThanOrEqual: return "ge";
                case ExpressionType.Increment: return "add";
                case ExpressionType.IsFalse: return "eq false";
                case ExpressionType.IsTrue: return "eq true";
                case ExpressionType.LessThan: return "lt";
                case ExpressionType.LessThanOrEqual: return "le";
                case ExpressionType.Modulo: return "mod";
                case ExpressionType.Multiply: return "mul";
                case ExpressionType.Negate: return "-";
                case ExpressionType.Not: return "not";
                case ExpressionType.NotEqual: return "ne";
                case ExpressionType.Or: return "or";
                case ExpressionType.OrElse: return "or";
                case ExpressionType.Subtract: return "sub";
                default: throw new NotSupportedException("Don't know about " + expressionType.ToString());
            }
        }

        //return valid OData methods
        private static string getMethod(MethodInfo m)
        {
            if (m.DeclaringType.Name == "String")
            {
                if (m.Name == "Contains") return "contains";
                if (m.Name == "EndsWith") return "endswith";
                if (m.Name == "StartsWith") return "startswith";
                if (m.Name == "Length") return "length";
                if (m.Name == "IndexOf") return "indexof";
                if (m.Name == "Substring") return "substring";
                if (m.Name == "ToLower") return "tolower";
                if (m.Name == "ToUpper") return "toupper";
                if (m.Name == "Trim") return "trim";
            }
            else if (m.DeclaringType.Name == "Math")
            {
                if (m.Name == "Round") return "round";
                if (m.Name == "Floor") return "floor";
                if (m.Name == "Ceiling") return "ceiling";
            }
            return null;
        }

        internal static JArray SortArray(JArray jArray, string property, bool desc)
        {
            JArray ret = new JArray();
            var ordered = desc ?
                jArray.OrderByDescending(x => x[property]) :
                jArray.OrderBy(x => x[property]);

            foreach (var item in ordered) ret.Add(item);
            return ret;
        }

        internal static string RemoveParameters(HttpRequestBase Request)
        {
            Dictionary<string, string> take = new Dictionary<string, string>();
            foreach (var k in Request.QueryString.AllKeys.Where(x => x != null && x.StartsWith("$")))
                take.Add(k, Request.QueryString[k]);
            if (take.Count > 0) 
                return "?" + string.Join("&", take.Select(d => HttpUtility.UrlEncode(d.Key) + "=" + HttpUtility.UrlEncode(d.Value)));
            else
                return string.Empty;
        }
    }
}