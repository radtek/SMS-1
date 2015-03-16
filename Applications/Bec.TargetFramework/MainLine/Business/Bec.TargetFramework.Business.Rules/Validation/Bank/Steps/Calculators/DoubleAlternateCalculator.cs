using System.Collections.Generic;
using System.Linq;


namespace Bec.TargetFramework.Business.Rules.Validation.Bank
{
    class FirstDoubleAlternateCalculator : DoubleAlternateCalculator
    {
        public FirstDoubleAlternateCalculator()
        {
            DoubleAlternateCalculatorExceptionFive = new FirstDoubleAlternateCalculatorExceptionFive();
        }

        public FirstDoubleAlternateCalculator(FirstDoubleAlternateCalculatorExceptionFive exceptionFive)
        {
            DoubleAlternateCalculatorExceptionFive = exceptionFive;
        }

        protected override int GetMappingException(IEnumerable<IModulusWeightMapping> weightMappings)
        {
            return weightMappings.First().Exception;
        }

        protected override int GetWeightSumForStep(BankAccountDetails bankAccountDetails)
        {
            return new DoubleAlternateModulusCheck().GetModulusSum(bankAccountDetails,
                                                            bankAccountDetails.WeightMappings
                                                                              .First());
        }
    }

    class SecondDoubleAlternateCalculator : DoubleAlternateCalculator
    {
        public SecondDoubleAlternateCalculator()
        {
            DoubleAlternateCalculatorExceptionFive = new SecondDoubleAlternateCalculatorExceptionFive();
        }

        public SecondDoubleAlternateCalculator(SecondDoubleAlternateCalculatorExceptionFive exceptionFive)
        {
            DoubleAlternateCalculatorExceptionFive = exceptionFive;
        }

        protected override int GetMappingException(IEnumerable<IModulusWeightMapping> weightMappings)
        {
            return weightMappings.Second().Exception;
        }

        protected override int GetWeightSumForStep(BankAccountDetails bankAccountDetails)
        {
            return new DoubleAlternateModulusCheck().GetModulusSum(bankAccountDetails,
                                                            bankAccountDetails.WeightMappings
                                                                              .Second());
        }
    }

    abstract class DoubleAlternateCalculator : BaseModulusCalculator
    {
        protected DoubleAlternateCalculatorExceptionFive DoubleAlternateCalculatorExceptionFive;

        protected abstract int GetMappingException(IEnumerable<IModulusWeightMapping> weightMappings);
        protected abstract int GetWeightSumForStep(BankAccountDetails bankAccountDetails);

        public override bool Process(BankAccountDetails bankAccountDetails)
        {
            return GetMappingException(bankAccountDetails.WeightMappings) == 5
                       ? DoubleAlternateCalculatorExceptionFive.Process(bankAccountDetails)
                       : (GetWeightSumForStep(bankAccountDetails)%Modulus) == 0;
        }
    }
}