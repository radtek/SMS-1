namespace Bec.TargetFramework.Business.Rules.Validation.Bank
{
    interface IStep
    {
        bool Process(BankAccountDetails bankAccountDetails);
    }
}