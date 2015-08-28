namespace Bec.TargetFramework.Data.Infrastructure.Caching
{
    public interface ICachePrefixManager
    {
        int Counter { get; }
        void IncrementCounter();
    }
}
