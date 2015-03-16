namespace Bec.TargetFramework.Data.Infrastructure.Specifications
{
    public class AndNotSpecification<T> : CompositeSpecification<T>
    {
        public AndNotSpecification(ISpecification<T> leftSide, ISpecification<T> rightSide)
            : base(leftSide.Predicate.AndNot(rightSide.Predicate))
        {
        }
    }
}