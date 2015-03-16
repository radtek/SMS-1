/*
 * Copyright (c) Brock Allen.  All rights reserved.
 * see license.txt
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace BrockAllen.MembershipReboot
{
    [DataContract]
    [Serializable]
    public class UserAccount
    {
        public UserAccount()
        {
            Claims = new List<UserClaim>();
            LinkedAccounts = new List<LinkedAccount>();
            Certificates = new List<UserCertificate>();
            TwoFactorAuthTokens = new List<TwoFactorAuthToken>();
            PasswordResetSecrets = new List<PasswordResetSecret>();
        }

        #region Properties
         [DataMember]
       
        /// <summary>
        /// There are no comments for ID in the schema.
        /// </summary>
        public virtual global::System.Guid ID
        {
            get;
            set;
        }

         [DataMember]
       
        /// <summary>
        /// There are no comments for Tenant in the schema.
        /// </summary>
        public virtual string Tenant
        {
            get;
            set;
        }

         [DataMember]
       
        /// <summary>
        /// There are no comments for Username in the schema.
        /// </summary>
        public virtual string Username
        {
            get;
            set;
        }

         [DataMember]
       
        /// <summary>
        /// There are no comments for Email in the schema.
        /// </summary>
        public virtual string Email
        {
            get;
            set;
        }

         [DataMember]
       
        /// <summary>
        /// There are no comments for Created in the schema.
        /// </summary>
        public virtual global::System.DateTime Created
        {
            get;
            set;
        }

         [DataMember]
       
        /// <summary>
        /// There are no comments for LastUpdated in the schema.
        /// </summary>
        public virtual global::System.DateTime LastUpdated
        {
            get;
            set;
        }

         [DataMember]
       
        /// <summary>
        /// There are no comments for PasswordChanged in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> PasswordChanged
        {
            get;
            set;
        }

         [DataMember]
       
        /// <summary>
        /// There are no comments for RequiresPasswordReset in the schema.
        /// </summary>
        public virtual bool RequiresPasswordReset
        {
            get;
            set;
        }

         [DataMember]
       
        /// <summary>
        /// There are no comments for MobileCode in the schema.
        /// </summary>
        public virtual string MobileCode
        {
            get;
            set;
        }

         [DataMember]
       
        /// <summary>
        /// There are no comments for MobileCodeSent in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> MobileCodeSent
        {
            get;
            set;
        }
         [DataMember]
       

        /// <summary>
        /// There are no comments for MobilePhoneNumber in the schema.
        /// </summary>
        public virtual string MobilePhoneNumber
        {
            get;
            set;
        }

         [DataMember]
       
        /// <summary>
        /// There are no comments for AccountTwoFactorAuthMode in the schema.
        /// </summary>
        public virtual int AccountTwoFactorAuthMode
        {
            get;
            set;
        }

         [DataMember]
       
        /// <summary>
        /// There are no comments for CurrentTwoFactorAuthStatus in the schema.
        /// </summary>
        public virtual int CurrentTwoFactorAuthStatus
        {
            get;
            set;
        }

         [DataMember]
       
        /// <summary>
        /// There are no comments for IsAccountVerified in the schema.
        /// </summary>
        public virtual bool IsAccountVerified
        {
            get;
            set;
        }

         [DataMember]
       
        /// <summary>
        /// There are no comments for IsLoginAllowed in the schema.
        /// </summary>
        public virtual bool IsLoginAllowed
        {
            get;
            set;
        }

         [DataMember]
       
        /// <summary>
        /// There are no comments for IsAccountClosed in the schema.
        /// </summary>
        public virtual bool IsAccountClosed
        {
            get;
            set;
        }

         [DataMember]
       
        /// <summary>
        /// There are no comments for AccountClosed in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> AccountClosed
        {
            get;
            set;
        }

         [DataMember]
       
        /// <summary>
        /// There are no comments for LastLogin in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> LastLogin
        {
            get;
            set;
        }

         [DataMember]
       
        /// <summary>
        /// There are no comments for LastFailedLogin in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> LastFailedLogin
        {
            get;
            set;
        }
         [DataMember]
       

        /// <summary>
        /// There are no comments for FailedLoginCount in the schema.
        /// </summary>
        public virtual int FailedLoginCount
        {
            get;
            set;
        }
         [DataMember]
       

        /// <summary>
        /// There are no comments for VerificationKey in the schema.
        /// </summary>
        public virtual string VerificationKey
        {
            get;
            set;
        }
         [DataMember]
       

        /// <summary>
        /// There are no comments for VerificationPurpose in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> VerificationPurpose
        {
            get;
            set;
        }

         [DataMember]
       
        /// <summary>
        /// There are no comments for VerificationKeySent in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> VerificationKeySent
        {
            get;
            set;
        }

         [DataMember]
       
        /// <summary>
        /// There are no comments for HashedPassword in the schema.
        /// </summary>
        public virtual string HashedPassword
        {
            get;
            set;
        }

         [DataMember]
       
        /// <summary>
        /// There are no comments for LastFailedPasswordReset in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> LastFailedPasswordReset
        {
            get;
            set;
        }

         [DataMember]
       
        /// <summary>
        /// There are no comments for FailedPasswordResetCount in the schema.
        /// </summary>
        public virtual int FailedPasswordResetCount
        {
            get;
            set;
        }

         [DataMember]
       
        /// <summary>
        /// There are no comments for MobilePhoneNumberChanged in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> MobilePhoneNumberChanged
        {
            get;
            set;
        }

         [DataMember]
       
        /// <summary>
        /// There are no comments for VerificationStorage in the schema.
        /// </summary>
        public virtual string VerificationStorage
        {
            get;
            set;
        }

 [DataMember]
       
        /// <summary>
        /// There are no comments for IsActive in the schema.
        /// </summary>
        public virtual bool IsActive
        {
            get;
            set;
        }

        [DataMember]
        /// <summary>
        /// There are no comments for IsDeleted in the schema.
        /// </summary>
        public virtual bool IsDeleted
        {
            get;
            set;
        }

        [DataMember]
        public virtual bool IsTemporaryAccount
        { 
            get; 
            set; 
        }
        [DataMember]
        public virtual bool IsEmployee
        {
            get;
            set;
        }
        [DataMember]
        public virtual int FailedForgotUsernameAttempts
        {
            get;
            set;
        }

        [DataMember]
        public virtual int FailedForgotPasswordAttempts
        {
            get;
            set;
        }

        [DataMember]
        public virtual bool IsForgotUsernameRequestAllowed
        {
            get;
            set;
        }


        [DataMember]
        public virtual bool IsForgotPasswordRequestAllowed
        {
            get;
            set;
        }


        [DataMember]
        public virtual global::System.Nullable<System.DateTime> LastForgotUsernameFailedAttempt
        {
            get;
            set;
        }


        [DataMember]
        public virtual global::System.Nullable<System.DateTime> LastForgotPasswordFailedAttempt
        {
            get;
            set;
        }
        #endregion

        [DataMember]
        public virtual List<UserClaim> Claims { get; set; }
        [DataMember]
        public virtual List<LinkedAccount> LinkedAccounts { get; set; }
        [DataMember]
        public virtual List<UserCertificate> Certificates { get; set; }
        [DataMember]
        public virtual List<TwoFactorAuthToken> TwoFactorAuthTokens { get; set; }
        [DataMember]
        public virtual List<PasswordResetSecret> PasswordResetSecrets { get; set; }
         [DataMember]
        public UserLoginValidation LoginValidation { get; set; }

        public PasswordResetSecret RandomSecurityQuestion()
        {
            var rand = new Random();
            return PasswordResetSecrets[rand.Next(PasswordResetSecrets.Count)];
        }

    }
}
