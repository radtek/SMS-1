using System.Collections.Generic;

namespace Bec.TargetFramework.Business.Rules.Validation.Bank
{
    interface IModulusCheck
    {
        int GetModulusSum(BankAccountDetails bankAccountDetails, IModulusWeightMapping weightMapping);
    }
}