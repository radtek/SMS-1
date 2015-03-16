using System;
using System.Linq;
namespace Bec.TargetFramework.Business.Rules.Validation.Bank
{
    class SecondStandardModulusTenCalculator : FirstStandardModulusTenCalculator
    {
        public override bool Process(BankAccountDetails bankAccountDetails)
        {
            if (bankAccountDetails.WeightMappings.Count() != 2)
            {
                throw new ArgumentException(
                    "Second Step Check must be passed bank details with two weight mapping rules");
            } 
            return ProcessWeightingRule(bankAccountDetails,
                                        bankAccountDetails.WeightMappings.Second());
        }
    }
}