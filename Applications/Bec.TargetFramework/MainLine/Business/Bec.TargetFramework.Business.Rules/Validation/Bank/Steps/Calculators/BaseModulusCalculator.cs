
namespace Bec.TargetFramework.Business.Rules.Validation.Bank
{
    abstract class BaseModulusCalculator : IStep
    {
        protected int Modulus = 10;
        public abstract bool Process(BankAccountDetails bankAccountDetails);

        protected bool ProcessWeightingRule(BankAccountDetails bankAccountDetails, IModulusWeightMapping modulusWeightMapping)
        {
            var weightingSum = new StandardModulusCheck().GetModulusSum(bankAccountDetails,modulusWeightMapping);
            var remainder = weightingSum%Modulus;
            return modulusWeightMapping.Exception == 4 
                       ? bankAccountDetails.AccountNumber.GetExceptionFourCheckValue == remainder
                       : remainder == 0;
        }
    }
}
