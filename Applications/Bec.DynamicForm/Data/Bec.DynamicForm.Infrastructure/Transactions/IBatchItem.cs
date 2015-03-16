namespace Bec.TargetFramework.Data.Infrastructure.Transactions
{
    public interface IBatchItem<T>
    {
        BatchAction Action { get; set; }
        T Item { get; set; }
    }
}
