namespace Bec.TargetFramework.Data.Infrastructure.Specifications
{
    public class AndAlsoSpecification<T> : CompositeSpecification<T>
    {
        public AndAlsoSpecification(ISpecification<T> leftSide, ISpecification<T> rightSide)
            : base(leftSide.Predicate.AndAlso(rightSide.Predicate))
        {
        }
    }
}