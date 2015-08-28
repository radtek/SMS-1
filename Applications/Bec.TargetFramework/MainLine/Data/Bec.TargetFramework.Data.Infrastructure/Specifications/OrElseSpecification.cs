namespace Bec.TargetFramework.Data.Infrastructure.Specifications
{
    public class OrElseSpecification<T> : CompositeSpecification<T>
    {
        public OrElseSpecification(ISpecification<T> leftSide, ISpecification<T> rightSide)
            : base(leftSide.Predicate.OrElse(rightSide.Predicate))
        {
        }
    }
}