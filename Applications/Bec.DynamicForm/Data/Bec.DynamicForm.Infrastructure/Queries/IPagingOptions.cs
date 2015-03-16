namespace Bec.TargetFramework.Data.Infrastructure.Queries
{
    public interface IPagingOptions
    {
        int PageSize { get; set; }
        int PageNumber { get; set; }
        int Skip { get; }
        int Take { get; }
        int TotalItems { get; set; }
    }
}
