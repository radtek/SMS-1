using System.Linq.Expressions;

namespace Bec.TargetFramework.Data.Infrastructure.Caching.Hash
{
    internal class HashGeneratorHelper
    {
        private readonly Expression _expression;

        public HashGeneratorHelper(Expression expression)
        {
            this._expression = expression;
        }

        // special thanks to Pete Montgomery's post here: http://petemontgomery.wordpress.com/2008/08/07/caching-the-results-of-linq-queries/
        public string GetHash()
        {
            if (this._expression == null)
            {
                return null;
            }

            var expression = this._expression;

            // locally evaluate as much of the query as possible
            expression = Evaluator.PartialEval(expression);

            // support local collections
            expression = LocalCollectionExpander.Rewrite(expression);

            // use the string representation of the expression for the cache key
            return expression.ToString();
        }
    }
}