﻿/*
 * Copyright (c) Brock Allen.  All rights reserved.
 * see license.txt
 */

using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace BrockAllen.MembershipReboot
{
    internal class UserAccountValidation<TAccount>
        where TAccount : UserAccount
    {
        public static readonly IValidator<TAccount> UsernameDoesNotContainAtSign =
            new DelegateValidator<TAccount>(async (service, account, value) =>
            {
                if (value.Contains("@"))
                {
                    Tracing.Verbose("[UserAccountValidation.UsernameDoesNotContainAtSign] validation failed: {0}, {1}, {2}", account.Tenant, account.Username, value);

                    return new ValidationResult(Resources.ValidationMessages.UsernameCannotContainAtSign);
                }
                return null;
            });

        public static readonly IValidator<TAccount> UsernameOnlyContainsLettersAndDigits =
            new DelegateValidator<TAccount>(async (service, account, value) =>
            {
                if (!value.All(x => Char.IsLetterOrDigit(x)) /*|| value.All(x => Char.IsDigit(x))*/)
                {
                    Tracing.Verbose("[UserAccountValidation.UsernameOnlyContainsLettersAndDigits] validation failed: {0}, {1}, {2}", account.Tenant, account.Username, value);

                    return new ValidationResult(Resources.ValidationMessages.UsernameOnlyContainLettersAndDigits);
                }
                return null;
            });

        public static readonly IValidator<TAccount> UsernameMustNotAlreadyExist =
            new DelegateValidator<TAccount>(async (service, account, value) =>
            {
                if (await service.UsernameExistsAsync(account.Tenant, value))
                {
                    Tracing.Verbose("[UserAccountValidation.EmailMustNotAlreadyExist] validation failed: {0}, {1}, {2}", account.Tenant, account.Username, value);

                    return new ValidationResult(Resources.ValidationMessages.UsernameAlreadyInUse);
                }
                return null;
            });

        public static readonly IValidator<TAccount> EmailRequired =
            new DelegateValidator<TAccount>(async (service, account, value) =>
            {
                if (service.Configuration.RequireAccountVerification &&
                    String.IsNullOrWhiteSpace(value))
                {
                    Tracing.Verbose("[UserAccountValidation.EmailRequired] validation failed: {0}, {1}", account.Tenant, account.Username);

                    return new ValidationResult(Resources.ValidationMessages.EmailRequired);
                }
                return null;
            });

        public static readonly IValidator<TAccount> EmailIsValidFormat =
            new DelegateValidator<TAccount>(async (service, account, value) =>
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    EmailAddressAttribute validator = new EmailAddressAttribute();
                    if (!validator.IsValid(value))
                    {
                        Tracing.Verbose("[UserAccountValidation.EmailIsValidFormat] validation failed: {0}, {1}, {2}", account.Tenant, account.Username, value);

                        return new ValidationResult(Resources.ValidationMessages.InvalidEmail);
                    }
                }
                return null;
            });

        public static readonly IValidator<TAccount> EmailIsRequiredIfRequireAccountVerificationEnabled =
            new DelegateValidator<TAccount>(async (service, account, value) =>
            {
                if (service.Configuration.RequireAccountVerification && String.IsNullOrWhiteSpace(value))
                {
                    return new ValidationResult(Resources.ValidationMessages.EmailRequired);
                }
                return null;
            });

        public static readonly IValidator<TAccount> EmailMustNotAlreadyExist =
            new DelegateValidator<TAccount>(async (service, account, value) =>
            {
                if (!String.IsNullOrWhiteSpace(value) && await service.EmailExistsOtherThanAsync(account, value))
                {
                    Tracing.Verbose("[UserAccountValidation.EmailMustNotAlreadyExist] validation failed: {0}, {1}, {2}", account.Tenant, account.Username, value);

                    return new ValidationResult(Resources.ValidationMessages.EmailAlreadyInUse);
                }
                return null;
            });

        public static readonly IValidator<TAccount> PasswordMustBeDifferentThanCurrent =
            new DelegateValidator<TAccount>(async (service, account, value) =>
        {
            // Use LastLogin null-check to see if it's a new account
            // we don't want to run this logic if it's a new account
            if (!account.IsNew() && service.VerifyHashedPassword(account, value))
            {
                Tracing.Verbose("[UserAccountValidation.PasswordMustBeDifferentThanCurrent] validation failed: {0}, {1}", account.Tenant, account.Username);

                return new ValidationResult(Resources.ValidationMessages.NewPasswordMustBeDifferent);
            }
            return null;
        });
    }
}
