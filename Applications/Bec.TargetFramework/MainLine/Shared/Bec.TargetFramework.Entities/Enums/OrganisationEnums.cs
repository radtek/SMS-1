
using Bec.TargetFramework.Infrastructure.Extensions;
namespace Bec.TargetFramework.Entities.Enums
{
    public enum OrganisationTypeEnum : int
    {
        Administration = 30,
        Branch = 34,
        [StringValue("Personal Organisation")]
        Personal = 29,
        Conveyancing = 28,
        Supplier = 33,
        Temporary = 27,
        [StringValue("Professional Organisation")]
        Professional = 31,
        [StringValue("Mortgage Broker Organisation")]
        MortgageBroker = 37,
        [StringValue("Lender Organisation")]
        Lender = 38
    }
}
