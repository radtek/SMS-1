/*
 * Copyright (c) Brock Allen.  All rights reserved.
 * see license.txt
 */

using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace BrockAllen.MembershipReboot
{
    public interface IValidator<TAccount>
        where TAccount : UserAccount
    {
        Task<ValidationResult> ValidateAsync(UserAccountService<TAccount> service, TAccount account, string value);
    }
}
    