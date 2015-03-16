using System.Linq;
namespace Bec.TargetFramework.Business.Rules.Validation.Bank
{
    class FirstStandardModulusElevenCalculator : FirstStandardModulusTenCalculator
    {
        private readonly FirstStandardModulusElevenCalculatorExceptionFive _firstStandardModulusElevenCalculatorExceptionFive;

        public FirstStandardModulusElevenCalculator()
        {
            _firstStandardModulusElevenCalculatorExceptionFive = new FirstStandardModulusElevenCalculatorExceptionFive();
            Modulus = 11;
        }

        public FirstStandardModulusElevenCalculator(FirstStandardModulusElevenCalculatorExceptionFive firstStandardModulusElevenCalculatorExceptionFive)
        {
            _firstStandardModulusElevenCalculatorExceptionFive = firstStandardModulusElevenCalculatorExceptionFive;
            Modulus = 11;
        }

        public override bool Process(BankAccountDetails bankAccountDetails)
        {
            return bankAccountDetails.WeightMappings.First().Exception == 5
                       ? _firstStandardModulusElevenCalculatorExceptionFive.Process(bankAccountDetails)
                       : ProcessWeightingRule(bankAccountDetails, bankAccountDetails.WeightMappings.First());
        }
    }
}