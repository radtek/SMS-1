namespace Bec.TargetFramework.Business.Rules.Validation.Bank
{
    class StandardModulusExceptionFourteenCalculator : FirstStandardModulusElevenCalculator
    {
        public override bool Process(BankAccountDetails bankAccountDetails)
        {
            if (!bankAccountDetails.AccountNumber.IsValidCouttsNumber)
            {
                return false;
            }
            bankAccountDetails.AccountNumber.SetElementAt(7, '0');
            return base.Process(bankAccountDetails);
        }
    }
}