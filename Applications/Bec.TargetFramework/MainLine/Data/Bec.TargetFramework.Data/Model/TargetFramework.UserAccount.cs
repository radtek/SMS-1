﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Bec.TargetFramework.Data
{

    /// <summary>
    /// There are no comments for Bec.TargetFramework.Data.UserAccount in the schema.
    /// </summary>
    [System.Serializable]
    public partial class UserAccount    {

        public UserAccount()
        {
          this.FailedPasswordResetCount = 0;
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsTemporaryAccount = false;
          this.IsApproved = false;
          this.IsEmployee = false;
          this.FailedForgotUsernameAttempts = 0;
          this.FailedForgotPasswordAttempts = 0;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ID in the schema.
        /// </summary>
        public virtual global::System.Guid ID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Tenant in the schema.
        /// </summary>
        public virtual string Tenant
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Username in the schema.
        /// </summary>
        public virtual string Username
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Email in the schema.
        /// </summary>
        public virtual string Email
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Created in the schema.
        /// </summary>
        public virtual global::System.DateTime Created
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LastUpdated in the schema.
        /// </summary>
        public virtual global::System.DateTime LastUpdated
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PasswordChanged in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> PasswordChanged
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RequiresPasswordReset in the schema.
        /// </summary>
        public virtual bool RequiresPasswordReset
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MobileCode in the schema.
        /// </summary>
        public virtual string MobileCode
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MobileCodeSent in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> MobileCodeSent
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MobilePhoneNumber in the schema.
        /// </summary>
        public virtual string MobilePhoneNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AccountTwoFactorAuthMode in the schema.
        /// </summary>
        public virtual int AccountTwoFactorAuthMode
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CurrentTwoFactorAuthStatus in the schema.
        /// </summary>
        public virtual int CurrentTwoFactorAuthStatus
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsAccountVerified in the schema.
        /// </summary>
        public virtual bool IsAccountVerified
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsLoginAllowed in the schema.
        /// </summary>
        public virtual bool IsLoginAllowed
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsAccountClosed in the schema.
        /// </summary>
        public virtual bool IsAccountClosed
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AccountClosed in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> AccountClosed
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LastLogin in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> LastLogin
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LastFailedLogin in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> LastFailedLogin
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FailedLoginCount in the schema.
        /// </summary>
        public virtual int FailedLoginCount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for VerificationKey in the schema.
        /// </summary>
        public virtual string VerificationKey
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for VerificationPurpose in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> VerificationPurpose
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for VerificationKeySent in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> VerificationKeySent
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for HashedPassword in the schema.
        /// </summary>
        public virtual string HashedPassword
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LastFailedPasswordReset in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> LastFailedPasswordReset
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FailedPasswordResetCount in the schema.
        /// </summary>
        public virtual int FailedPasswordResetCount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MobilePhoneNumberChanged in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> MobilePhoneNumberChanged
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for VerificationStorage in the schema.
        /// </summary>
        public virtual string VerificationStorage
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsActive in the schema.
        /// </summary>
        public virtual bool IsActive
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsDeleted in the schema.
        /// </summary>
        public virtual bool IsDeleted
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsTemporaryAccount in the schema.
        /// </summary>
        public virtual bool IsTemporaryAccount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CreatedOn in the schema.
        /// </summary>
        public virtual global::System.DateTime CreatedOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CreatedBy in the schema.
        /// </summary>
        public virtual string CreatedBy
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ModifiedOn in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> ModifiedOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ModifiedBy in the schema.
        /// </summary>
        public virtual string ModifiedBy
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsApproved in the schema.
        /// </summary>
        public virtual bool IsApproved
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsEmployee in the schema.
        /// </summary>
        public virtual bool IsEmployee
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FailedForgotUsernameAttempts in the schema.
        /// </summary>
        public virtual int FailedForgotUsernameAttempts
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FailedForgotPasswordAttempts in the schema.
        /// </summary>
        public virtual int FailedForgotPasswordAttempts
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsForgotUsernameRequestAllowed in the schema.
        /// </summary>
        public virtual bool IsForgotUsernameRequestAllowed
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsForgotPasswordRequestAllowed in the schema.
        /// </summary>
        public virtual bool IsForgotPasswordRequestAllowed
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LastForgotUsernameFailedAttempt in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> LastForgotUsernameFailedAttempt
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LastForgotPasswordFailedAttempt in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> LastForgotPasswordFailedAttempt
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RowVersion in the schema.
        /// </summary>
        public virtual global::System.Nullable<long> RowVersion
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for UserAccountOrganisations in the schema.
        /// </summary>
        public virtual ICollection<UserAccountOrganisation> UserAccountOrganisations
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for UserCertificates in the schema.
        /// </summary>
        public virtual ICollection<UserCertificate> UserCertificates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for UserAccountLedgerAccounts in the schema.
        /// </summary>
        public virtual ICollection<UserAccountLedgerAccount> UserAccountLedgerAccounts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for UserAccountDetails in the schema.
        /// </summary>
        public virtual ICollection<UserAccountDetail> UserAccountDetails
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for LinkedAccounts in the schema.
        /// </summary>
        public virtual ICollection<LinkedAccount> LinkedAccounts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PasswordResetSecrets in the schema.
        /// </summary>
        public virtual ICollection<PasswordResetSecret> PasswordResetSecrets
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for TwoFactorAuthTokens in the schema.
        /// </summary>
        public virtual ICollection<TwoFactorAuthToken> TwoFactorAuthTokens
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for UserClaims in the schema.
        /// </summary>
        public virtual ICollection<UserClaim> UserClaims
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for UserAccountArchives in the schema.
        /// </summary>
        public virtual ICollection<UserAccountArchive> UserAccountArchives
        {
            get;
            set;
        }

        #endregion
    }

}
