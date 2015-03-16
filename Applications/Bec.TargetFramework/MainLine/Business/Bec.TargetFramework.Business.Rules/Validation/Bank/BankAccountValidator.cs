namespace Bec.TargetFramework.Business.Rules.Validation.Bank
{
    public class BankAccountValidator
    {
        private readonly IModulusWeightTable _weightTable;

        public BankAccountValidator()
        {
            _weightTable = ModulusWeightTable.GetInstance;
        }

        public BankAccountValidator(IModulusWeightTable modulusWeightTable)
        {
            _weightTable = modulusWeightTable;
        }

        public bool CheckBankAccount(string sortCode, string accountNumber)
        {
            var bankAccountDetails = new BankAccountDetails(sortCode, accountNumber);
            bankAccountDetails.WeightMappings = _weightTable.GetRuleMappings(bankAccountDetails.SortCode);
            return new ConfirmDetailsAreValidForModulusCheck().Process(bankAccountDetails);
        }
    }
}
