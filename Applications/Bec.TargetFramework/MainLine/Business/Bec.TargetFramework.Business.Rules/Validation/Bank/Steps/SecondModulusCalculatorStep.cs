using System;
using System.Linq;
namespace Bec.TargetFramework.Business.Rules.Validation.Bank
{
    class SecondModulusCalculatorStep : IStep
    {
        private readonly SecondStepRouter _secondStepRouter;

        public SecondModulusCalculatorStep()
        {
            _secondStepRouter = new SecondStepRouter();
        }

        public SecondModulusCalculatorStep(SecondStandardModulusTenCalculator secondStandardModulusTenCalculator,
                                           SecondStandardModulusElevenCalculator secondStandardModulusElevenCalculator,
                                           SecondDoubleAlternateCalculator secondDoubleAlternateCalculator,
                                           DoubleAlternateCalculatorExceptionFive daf)
        {
            _secondStepRouter = new SecondStepRouter(secondStandardModulusTenCalculator,
                                                     secondStandardModulusElevenCalculator,
                                                     secondDoubleAlternateCalculator);
        }

        public virtual bool Process(BankAccountDetails bankAccountDetails)
        {
            bankAccountDetails.SecondResult = _secondStepRouter.GetModulusCalculation(bankAccountDetails);
            return new PostProcessModulusCheckResult().Process(bankAccountDetails);
        }
    }
}