using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bec.TargetFramework.Data.Infrastructure.Specifications
{
    /// <summary>
    /// ParameterRebinder manually rebinds  parameters since LINQ to Entities does not support InvocationExpressions.  
    /// Based on LINQ to Entities: Combining Predicates article by Colin Meek 
    /// <see cref="http://blogs.msdn.com/b/meek/archive/2008/05/02/linq-to-entities-combining-predicates.aspx"/> and
    /// Matt Warren’s series of articles on Buildin an IQueryable provider: 
    /// <see cref="http://blogs.msdn.com/b/mattwar/archive/2007/07/30/linq-building-an-iqueryable-provider-part-i.aspx"/>
    /// <see cref="http://blogs.msdn.com/b/mattwar/archive/2007/07/31/linq-building-an-iqueryable-provider-part-ii.aspx"/>
    /// </summary>
    public class ParameterRebinder : ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> _map;

        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this._map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map,
            Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }

        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression replacement;
            if (this._map.TryGetValue(p, out replacement))
            {
                p = replacement;
            }
            return base.VisitParameter(p);
        }
    }
}