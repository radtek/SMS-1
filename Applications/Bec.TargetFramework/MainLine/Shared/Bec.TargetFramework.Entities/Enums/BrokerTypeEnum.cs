
using Bec.TargetFramework.Infrastructure.Extensions;

namespace Bec.TargetFramework.Entities.Enums
{
    public enum BrokerBusinessTypeEnum
    {
        [StringValue("Financial Services Firm")]
        FinancialServicesFirm,
        [StringValue("Individual")]
        Individual,
        [StringValue("Payment Services Firm")]
        PaymentServicesFirm,
        [StringValue("Consumer Credit Interim")]
        ConsumerCreditInterim,
        [StringValue("EMoney")]
        EMoney,
        [StringValue("Unauthorised Firm")]
        UnauthorisedFirm,
        [StringValue("Collective Investment Scheme")]
        CollectiveInvestmentScheme,
        [StringValue("Exempt Professional Firm")]
        ExemptProfessionalFirm,
        [StringValue("Exchange")]
        Exchange,
        [StringValue("Not for Profit Body")]
        NotforProfitBody
    }
}
