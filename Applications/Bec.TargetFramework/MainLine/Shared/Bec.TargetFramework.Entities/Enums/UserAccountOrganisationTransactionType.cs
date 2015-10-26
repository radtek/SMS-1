
using Bec.TargetFramework.Infrastructure.Extensions;

namespace Bec.TargetFramework.Entities.Enums
{
    public enum UserAccountOrganisationTransactionType
    {
        [StringValue("Primary Buyer")]
        Buyer = 1,
        [StringValue("Additional Buyer")]
        AdditionalBuyer = 2,
        [StringValue("Giftor")]
        Giftor = 3,
        [StringValue("Seller")]
        Seller = 4
    }
}
