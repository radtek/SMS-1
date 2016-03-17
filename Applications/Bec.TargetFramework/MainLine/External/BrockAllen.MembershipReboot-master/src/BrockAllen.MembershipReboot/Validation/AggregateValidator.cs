/*
 * Copyright (c) Brock Allen.  All rights reserved.
 * see license.txt
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace BrockAllen.MembershipReboot
{
    public class AggregateValidator<TAccount> : List<IValidator<TAccount>>, IValidator<TAccount>
        where TAccount : UserAccount
    {
        public async Task<ValidationResult> ValidateAsync(UserAccountService<TAccount> service, TAccount account, string value)
        {
            if (service == null) throw new ArgumentNullException("service");
            if (account == null) throw new ArgumentNullException("account");
            
            var list = new List<ValidationResult>();
            foreach (var item in this)
            {
                var result = await item.ValidateAsync(service, account, value);
                if (result != null && result != ValidationResult.Success)
                {
                    return result;
                }
            }
            return null;
        }
    }
}
