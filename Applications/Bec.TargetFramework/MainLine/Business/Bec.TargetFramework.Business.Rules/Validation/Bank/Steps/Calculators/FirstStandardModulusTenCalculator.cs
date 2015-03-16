using System.Diagnostics;
using System.Linq;
namespace Bec.TargetFramework.Business.Rules.Validation.Bank
{
    class FirstStandardModulusTenCalculator : BaseModulusCalculator
    {
         public override bool Process(BankAccountDetails bankAccountDetails)
        {
            return ProcessWeightingRule(bankAccountDetails, bankAccountDetails.WeightMappings.First());
        }
    }
}