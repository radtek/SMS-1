﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class UserAccountConverter
    {

        public static UserAccountDTO ToDto(this Bec.TargetFramework.Data.UserAccount source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static UserAccountDTO ToDtoWithRelated(this Bec.TargetFramework.Data.UserAccount source, int level)
        {
            if (source == null)
              return null;

            var target = new UserAccountDTO();

            // Properties
            target.ID = source.ID;
            target.Tenant = source.Tenant;
            target.Username = source.Username;
            target.Email = source.Email;
            target.Created = source.Created;
            target.LastUpdated = source.LastUpdated;
            target.PasswordChanged = source.PasswordChanged;
            target.RequiresPasswordReset = source.RequiresPasswordReset;
            target.MobileCode = source.MobileCode;
            target.MobileCodeSent = source.MobileCodeSent;
            target.MobilePhoneNumber = source.MobilePhoneNumber;
            target.AccountTwoFactorAuthMode = source.AccountTwoFactorAuthMode;
            target.CurrentTwoFactorAuthStatus = source.CurrentTwoFactorAuthStatus;
            target.IsAccountVerified = source.IsAccountVerified;
            target.IsLoginAllowed = source.IsLoginAllowed;
            target.IsAccountClosed = source.IsAccountClosed;
            target.AccountClosed = source.AccountClosed;
            target.LastLogin = source.LastLogin;
            target.LastFailedLogin = source.LastFailedLogin;
            target.FailedLoginCount = source.FailedLoginCount;
            target.VerificationKey = source.VerificationKey;
            target.VerificationPurpose = source.VerificationPurpose;
            target.VerificationKeySent = source.VerificationKeySent;
            target.HashedPassword = source.HashedPassword;
            target.LastFailedPasswordReset = source.LastFailedPasswordReset;
            target.FailedPasswordResetCount = source.FailedPasswordResetCount;
            target.MobilePhoneNumberChanged = source.MobilePhoneNumberChanged;
            target.VerificationStorage = source.VerificationStorage;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsTemporaryAccount = source.IsTemporaryAccount;
            target.CreatedOn = source.CreatedOn;
            target.CreatedBy = source.CreatedBy;
            target.ModifiedOn = source.ModifiedOn;
            target.ModifiedBy = source.ModifiedBy;
            target.IsApproved = source.IsApproved;
            target.IsEmployee = source.IsEmployee;
            target.FailedForgotUsernameAttempts = source.FailedForgotUsernameAttempts;
            target.FailedForgotPasswordAttempts = source.FailedForgotPasswordAttempts;
            target.IsForgotUsernameRequestAllowed = source.IsForgotUsernameRequestAllowed;
            target.IsForgotPasswordRequestAllowed = source.IsForgotPasswordRequestAllowed;
            target.LastForgotUsernameFailedAttempt = source.LastForgotUsernameFailedAttempt;
            target.LastForgotPasswordFailedAttempt = source.LastForgotPasswordFailedAttempt;
            target.RowVersion = source.RowVersion;
            target.AccountCreated = source.AccountCreated;

            // Navigation Properties
            if (level > 0) {
              target.UserAccountOrganisations = source.UserAccountOrganisations.ToDtosWithRelated(level - 1);
              target.UserCertificates = source.UserCertificates.ToDtosWithRelated(level - 1);
              target.UserAccountLedgerAccounts = source.UserAccountLedgerAccounts.ToDtosWithRelated(level - 1);
              target.UserAccountDetails = source.UserAccountDetails.ToDtosWithRelated(level - 1);
              target.LinkedAccounts = source.LinkedAccounts.ToDtosWithRelated(level - 1);
              target.PasswordResetSecrets = source.PasswordResetSecrets.ToDtosWithRelated(level - 1);
              target.TwoFactorAuthTokens = source.TwoFactorAuthTokens.ToDtosWithRelated(level - 1);
              target.UserClaims = source.UserClaims.ToDtosWithRelated(level - 1);
              target.UserAccountArchives = source.UserAccountArchives.ToDtosWithRelated(level - 1);
              target.UserAccountLoginSessions = source.UserAccountLoginSessions.ToDtosWithRelated(level - 1);
              target.CalloutUserAccounts = source.CalloutUserAccounts.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.UserAccount ToEntity(this UserAccountDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.UserAccount();

            // Properties
            target.ID = source.ID;
            target.Tenant = source.Tenant;
            target.Username = source.Username;
            target.Email = source.Email;
            target.Created = source.Created;
            target.LastUpdated = source.LastUpdated;
            target.PasswordChanged = source.PasswordChanged;
            target.RequiresPasswordReset = source.RequiresPasswordReset;
            target.MobileCode = source.MobileCode;
            target.MobileCodeSent = source.MobileCodeSent;
            target.MobilePhoneNumber = source.MobilePhoneNumber;
            target.AccountTwoFactorAuthMode = source.AccountTwoFactorAuthMode;
            target.CurrentTwoFactorAuthStatus = source.CurrentTwoFactorAuthStatus;
            target.IsAccountVerified = source.IsAccountVerified;
            target.IsLoginAllowed = source.IsLoginAllowed;
            target.IsAccountClosed = source.IsAccountClosed;
            target.AccountClosed = source.AccountClosed;
            target.LastLogin = source.LastLogin;
            target.LastFailedLogin = source.LastFailedLogin;
            target.FailedLoginCount = source.FailedLoginCount;
            target.VerificationKey = source.VerificationKey;
            target.VerificationPurpose = source.VerificationPurpose;
            target.VerificationKeySent = source.VerificationKeySent;
            target.HashedPassword = source.HashedPassword;
            target.LastFailedPasswordReset = source.LastFailedPasswordReset;
            target.FailedPasswordResetCount = source.FailedPasswordResetCount;
            target.MobilePhoneNumberChanged = source.MobilePhoneNumberChanged;
            target.VerificationStorage = source.VerificationStorage;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsTemporaryAccount = source.IsTemporaryAccount;
            target.CreatedOn = source.CreatedOn;
            target.CreatedBy = source.CreatedBy;
            target.ModifiedOn = source.ModifiedOn;
            target.ModifiedBy = source.ModifiedBy;
            target.IsApproved = source.IsApproved;
            target.IsEmployee = source.IsEmployee;
            target.FailedForgotUsernameAttempts = source.FailedForgotUsernameAttempts;
            target.FailedForgotPasswordAttempts = source.FailedForgotPasswordAttempts;
            target.IsForgotUsernameRequestAllowed = source.IsForgotUsernameRequestAllowed;
            target.IsForgotPasswordRequestAllowed = source.IsForgotPasswordRequestAllowed;
            target.LastForgotUsernameFailedAttempt = source.LastForgotUsernameFailedAttempt;
            target.LastForgotPasswordFailedAttempt = source.LastForgotPasswordFailedAttempt;
            target.RowVersion = source.RowVersion;
            target.AccountCreated = source.AccountCreated;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<UserAccountDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.UserAccount> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<UserAccountDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.UserAccount> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.UserAccount> ToEntities(this IEnumerable<UserAccountDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.UserAccount source, UserAccountDTO target);

        static partial void OnEntityCreating(UserAccountDTO source, Bec.TargetFramework.Data.UserAccount target);

    }

}
