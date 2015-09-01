﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bec.TargetFramework.Presentation.Web.Helpers
{
    public class Edit<T>
    {
        public T Model { get; set; }
        
    }

    public static class Edit
    {
        public static string MakeModel(JObject res)
        {
            JObject m = new JObject();
            m["Model"] = res;
            return m.ToString(Formatting.None);
        }

        public static Edit<T> MakeModel<T>(T res)
        {
            Edit<T> m = new Edit<T> { Model = res };
            return m;
        }

        public static Dictionary<T, T2> ReadFormValues<T, T2>(HttpRequestBase request, string prefix, Func<string, T> mapKey, Func<string, T2> mapVal)
        {
            Dictionary<T, T2> ret = new Dictionary<T, T2>();
            foreach (string k in request.Form.AllKeys.Where(k => k.StartsWith(prefix))) ret.Add(mapKey(k.Substring(prefix.Length)), mapVal(request.Form[k]));
            return ret;
        }

        public static Newtonsoft.Json.Linq.JObject fromD(System.Collections.Specialized.NameValueCollection vals)
        {
            Newtonsoft.Json.Linq.JObject o = new Newtonsoft.Json.Linq.JObject();
            foreach (var key in vals.AllKeys.Where(k => k.StartsWith("Model."))) addD(key.Split('.').Skip(1).ToList(), o, vals[key]);
            return o;
        }

        public static Newtonsoft.Json.Linq.JObject addD(List<string> keys, Newtonsoft.Json.Linq.JObject o, string val)
        {
            var name = keys[0];
            var index = -1;
            JArray array = null;

            //arrays
            int b = keys[0].IndexOf('[');
            if (b > 0)
            {
                index = int.Parse(keys[0].Substring(b + 1, (keys[0].Length - b) - 2));
                name = keys[0].Substring(0, b);
                array = o[name] as JArray;
                if (array == null)
                {
                    array = new JArray();
                    o[name] = array;
                }
            }

            if (keys.Count == 1)
            {
                if (array == null)
                    o[name] = val;
                else
                    array.Add(val);
            }
            else
            {
                JObject sub;
                if (array == null)
                {
                    sub = new Newtonsoft.Json.Linq.JObject();
                    var prop = o.Property(name);
                    if (prop != null) sub = prop.Value as Newtonsoft.Json.Linq.JObject;
                }
                else
                {
                    if (array.Count > index)
                        sub = array[index] as JObject;
                    else
                    {
                        sub = new JObject();
                        array.Add(sub);
                    }
                }

                var obj = addD(keys.Skip(1).ToList(), sub, val);
                if (array == null) o[name] = obj;
                
            }
            return o;
        }

    }
}