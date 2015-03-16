namespace Bec.TargetFramework.Business.Rules.Validation.Bank
{
    public interface ISubstitutionSource
    {
        string GetSubstituteSortCode(string original);
    }
}