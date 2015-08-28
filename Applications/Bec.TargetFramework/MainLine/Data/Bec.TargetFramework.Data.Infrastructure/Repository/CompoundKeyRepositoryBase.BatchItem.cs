using Bec.TargetFramework.Data.Infrastructure.Transactions;

namespace Bec.TargetFramework.Data.Infrastructure
{
    public abstract partial class CompoundKeyRepositoryBase<T>
    {
        private sealed class BatchItem : IBatchItem<T>
        {
            public BatchAction Action { get; set; }
            public T Item { get; set; }
        }
    }

    public abstract partial class CompoundKeyRepositoryBase<T, TKey, TKey2>
    {
        private sealed class BatchItem : IBatchItem<T>
        {
            public BatchAction Action { get; set; }
            public T Item { get; set; }
        }
    }

    public abstract partial class CompoundKeyRepositoryBase<T, TKey, TKey2, TKey3>
    {
        private sealed class BatchItem : IBatchItem<T>
        {
            public BatchAction Action { get; set; }
            public T Item { get; set; }
        }
    }
}
