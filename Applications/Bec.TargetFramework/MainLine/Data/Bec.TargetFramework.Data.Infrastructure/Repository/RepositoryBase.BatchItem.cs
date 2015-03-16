using Bec.TargetFramework.Data.Infrastructure.Transactions;

namespace Bec.TargetFramework.Data.Infrastructure
{
    public abstract partial class RepositoryBase<T, TKey>
    {
        private sealed class BatchItem : IBatchItem<T>
        {
            public BatchAction Action { get; set; }
            public T Item { get; set; }
        }
    }
}
