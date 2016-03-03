/*
 * Copyright (c) Brock Allen.  All rights reserved.
 * see license.txt
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BrockAllen.MembershipReboot.AccountService;

namespace BrockAllen.MembershipReboot
{
    public class UserAccountService<TAccount> : IEventSource
        where TAccount : UserAccount
    {
        public MembershipRebootConfiguration Config { get; set; }

        public MembershipRebootConfiguration<TAccount> Configuration { get { return Config as MembershipRebootConfiguration<TAccount>; } }
        public IPartialUserLogicController UserLogic { get; set; }

        Lazy<AggregateValidator<TAccount>> usernameValidator;
        Lazy<AggregateValidator<TAccount>> emailValidator;
        Lazy<AggregateValidator<TAccount>> passwordValidator;
        private string m_key = null;

        public ITwoFactorAuthenticationPolicy TwoFactorAuthenticationPolicy { get; set; }

        public UserAccountService()
        {
            this.usernameValidator = new Lazy<AggregateValidator<TAccount>>(() =>
            {
                var val = new AggregateValidator<TAccount>();
                if (!this.Configuration.EmailIsUsername)
                {
                    val.Add(UserAccountValidation<TAccount>.UsernameDoesNotContainAtSign);
                    val.Add(UserAccountValidation<TAccount>.UsernameOnlyContainsLettersAndDigits);
                }
                val.Add(UserAccountValidation<TAccount>.UsernameMustNotAlreadyExist);
                val.Add(Configuration.UsernameValidator);
                return val;
            });

            this.emailValidator = new Lazy<AggregateValidator<TAccount>>(() =>
            {
                var val = new AggregateValidator<TAccount>();
                val.Add(UserAccountValidation<TAccount>.EmailIsRequiredIfRequireAccountVerificationEnabled);
                val.Add(UserAccountValidation<TAccount>.EmailIsValidFormat);
                val.Add(UserAccountValidation<TAccount>.EmailMustNotAlreadyExist);
                val.Add(Configuration.EmailValidator);
                return val;
            });

            this.passwordValidator = new Lazy<AggregateValidator<TAccount>>(() =>
            {
                var val = new AggregateValidator<TAccount>();
                val.Add(UserAccountValidation<TAccount>.PasswordMustBeDifferentThanCurrent);
                val.Add(Configuration.PasswordValidator);
                return val;
            });
        }

        protected async Task ValidateUsernameAsync(TAccount account, string value)
        {
            var result = await this.usernameValidator.Value.ValidateAsync(this, account, value);
            if (result != null && result != ValidationResult.Success)
            {
                Tracing.Error("ValidateUsername failed: " + result.ErrorMessage);
                throw new ValidationException(result.ErrorMessage);
            }
        }
        protected async Task ValidatePasswordAsync(TAccount account, string value)
        {
            var result = await this.passwordValidator.Value.ValidateAsync(this, account, value);
            if (result != null && result != ValidationResult.Success)
            {
                Tracing.Error("ValidatePassword failed: " + result.ErrorMessage);
                throw new ValidationException(result.ErrorMessage);
            }
        }
        protected async Task ValidateEmailAsync(TAccount account, string value)
        {
            var result = await this.emailValidator.Value.ValidateAsync(this, account, value);
            if (result != null && result != ValidationResult.Success)
            {
                Tracing.Error("ValidateEmail failed: " + result.ErrorMessage);
                throw new ValidationException(result.ErrorMessage);
            }
        }

        List<IEvent> events = new List<IEvent>();
        IEnumerable<IEvent> IEventSource.GetEvents()
        {
            return events;
        }
        void IEventSource.Clear()
        {
            events.Clear();
        }
        protected void AddEvent<E>(E evt) where E : IEvent
        {
            //if (evt is IAllowMultiple ||
            //    !events.Any(x => x.GetType() == evt.GetType()))
            //{
            //    events.Add(evt);
            //}
        }

        internal virtual async Task<List<UserAccount>> GetAllAsync()
        {
            return await GetAllAsync(null) as List<UserAccount>;
        }

        public virtual async Task UpdateAsync(UserAccount account)
        {
            if (account == null)
            {
                Tracing.Error("[UserAccountService.Update] called -- failed null account");
                throw new ArgumentNullException("account");
            }

            Tracing.Information("[UserAccountService.Update] called for account: {0}", account.ID);

            account.LastUpdated = DateTime.Now;

            await UserLogic.UpdateUserAccountAsync(account);
        }

        internal virtual async Task<IEnumerable<UserAccount>> GetAllAsync(string tenant)
        {
            if (!Configuration.MultiTenant)
            {
                Tracing.Verbose("[UserAccountService.GetAll] applying default tenant");
                tenant = Configuration.DefaultTenant;
            }

            Tracing.Information("[UserAccountService.GetAll] called for tenant: {0}", tenant);

            if (String.IsNullOrWhiteSpace(tenant)) return Enumerable.Empty<TAccount>().AsQueryable().ToList();

            return (await UserLogic.GetAllUserAccountAsync()).Where(x => x.Tenant == tenant && x.IsAccountClosed == false);
        }

        public virtual async Task<TAccount> GetByUsernameAsync(string username)
        {
            return await GetByUsernameAsync(null, username);
        }

        public virtual async Task<TAccount> GetByUsernameAsync(string tenant, string username)
        {
            if (!Configuration.MultiTenant)
            {
                Tracing.Verbose("[UserAccountService.GetByUsername] applying default tenant");
                tenant = Configuration.DefaultTenant;
            }

            Tracing.Information("[UserAccountService.GetByUsername] called for tenant: {0}, username: {1}", tenant, username);

            if (!Configuration.UsernamesUniqueAcrossTenants && String.IsNullOrWhiteSpace(tenant)) return null;
            if (String.IsNullOrWhiteSpace(username)) return null;

            var query = await UserLogic.GetBAUserAccountByUsernameAsync(username);


            if (query == null)
            {
                Tracing.Warning("[UserAccountService.GetByUsername] failed to locate account: {0}, {1}", tenant, username);
            }
            return query as TAccount;
        }

        public virtual async Task<TAccount> GetByEmailAsync(string email)
        {
            return await GetByEmailAsync(null, email);
        }

        public virtual async Task<TAccount> GetByEmailAsync(string tenant, string email)
        {
            if (!Configuration.MultiTenant)
            {
                Tracing.Verbose("[UserAccountService.GetByEmail] applying default tenant");
                tenant = Configuration.DefaultTenant;
            }

            Tracing.Information("[UserAccountService.GetByEmail] called for tenant: {0}, email: {1}", tenant, email);

            if (String.IsNullOrWhiteSpace(tenant)) return null;
            if (String.IsNullOrWhiteSpace(email)) return null;

            var account = await UserLogic.GetBAUserAccountByEmailAsync(email);
            if (account == null)
            {
                Tracing.Warning("[UserAccountService.GetByEmail] failed to locate account: {0}, {1}", tenant, email);
            }
            return account as TAccount;
        }

        public virtual async Task<TAccount> GetByIDAsync(Guid id)
        {
            Tracing.Information("[UserAccountService.GetByID] called for id: {0}", id);

            var account = await this.UserLogic.GetUserAccountAsync(id);
            if (account == null)
            {
                Tracing.Warning("[UserAccountService.GetByID] failed to locate account: {0}", id);
            }
            return account as TAccount;
        }

        public async Task<bool> HasTooManyRecentForgotUsernameRequestFailuresAsync(TAccount account)
        {
            var result = false;
            if (Configuration.forgottenUsernameLockoutFailedAttempts <= account.FailedForgotUsernameAttempts)
            {
                result = account.LastForgotUsernameFailedAttempt >= DateTime.Now.Subtract(Configuration.forgottenUsernameLockoutDuration);
            }
            if (result)
            {
                account.FailedForgotUsernameAttempts++;
                await UpdateAsync(account);
            }
            
            return result;
        }

        public async Task<bool> HasTooManyRecentForgotPasswordRequestFailuresAsync(TAccount account)
        {
            var result = false;
            if (Configuration.forgottenPasswordLockoutFailedAttempts <= account.FailedForgotPasswordAttempts)
            {
                result = account.LastForgotPasswordFailedAttempt >= DateTime.Now.Subtract(Configuration.forgottenPasswordLockoutDuration);
            }
            if (result)
            {
                account.FailedForgotPasswordAttempts++;
                await UpdateAsync(account);
            }

            return result;
        }
        public async Task<bool> VerifySecretQuestionAndAnswerAsync(Guid accountID, PasswordResetQuestionAnswer answer, string controllerName)
        {
            Tracing.Information("[UserAccountService.VerifySecretQuestionAndAnswer] called: {0}", accountID);

            if (answer == null || String.IsNullOrWhiteSpace(answer.Answer))
            {
                Tracing.Error("[UserAccountService.VerifySecretQuestionAndAnswer] failed -- no answers");
                throw new ValidationException(Resources.ValidationMessages.SecretAnswerRequired);
            }

            var account = await this.GetByIDAsync(accountID);
            var secrets = account.PasswordResetSecrets.ToArray();
            var secret = secrets.SingleOrDefault(x => x.PasswordResetSecretID == answer.QuestionID);
            var failed = false;
            if (answer == null || !this.Configuration.Crypto.SlowEquals(secret.Answer, this.Configuration.Crypto.Hash(answer.Answer)))
            {
                Tracing.Error("[UserAccountService.ResetPasswordFromSecretQuestionAndAnswer] failed on question id: {0}", answer.QuestionID);
                failed = true;
            }

                if (controllerName == "ForgottenUsername")
                {
                    if (failed)
                    {
                        account.LastForgotUsernameFailedAttempt = DateTime.Now;
                        if (account.FailedForgotUsernameAttempts <= 0)
                            account.FailedForgotUsernameAttempts = 1;
                        else
                            account.FailedForgotUsernameAttempts++;

                    }
                    else
                        account.FailedForgotUsernameAttempts = 0;
                    await LockOrUnlockForgotUsernameRequestAsync(account);
                }
                else if (controllerName == "ForgottenPassword")
                {
                    if (failed)
                    {
                        account.LastForgotPasswordFailedAttempt = DateTime.Now;
                        if (account.FailedForgotPasswordAttempts <= 0)
                            account.FailedForgotPasswordAttempts = 1;
                        else
                            account.FailedForgotPasswordAttempts++;
                    }
                    else
                        account.FailedForgotPasswordAttempts = 0;
                    await LockOrUnlockForgotPasswordRequestAsync(account);
                }
                else //Change password
                {
                    //No lockout for change password screen
                }

            await UpdateAsync(account);
            return failed;
        }

        protected virtual async Task LockOrUnlockForgotUsernameRequestAsync(TAccount account)
        {
            var result = false;
            if (Configuration.forgottenUsernameLockoutFailedAttempts <= account.FailedForgotUsernameAttempts)
            {
                result = account.LastForgotUsernameFailedAttempt >= DateTime.Now.Subtract(Configuration.forgottenUsernameLockoutDuration);
            }
            if (result)
            {
                if (account.IsForgotUsernameRequestAllowed)
                    account.IsForgotUsernameRequestAllowed = false;
                else
                {
                    account.IsForgotUsernameRequestAllowed = true;
                    account.FailedForgotUsernameAttempts = 1;
                }
            }
            await UpdateAsync(account);
        }
        protected virtual async Task LockOrUnlockForgotPasswordRequestAsync(TAccount account)
        {
            var result = false;
            if (Configuration.forgottenPasswordLockoutFailedAttempts <= account.FailedForgotPasswordAttempts)
            {
                result = account.LastForgotPasswordFailedAttempt >= DateTime.Now.Subtract(Configuration.forgottenPasswordLockoutDuration);
            }
            if (result)
            {
                if (account.IsForgotPasswordRequestAllowed)
                    account.IsForgotPasswordRequestAllowed = false;
                else
                {
                    account.IsForgotPasswordRequestAllowed = true;
                    account.FailedForgotPasswordAttempts = 1;
                }
            }
            await UpdateAsync(account);
        }
        //public virtual TAccount GetByVerificationKey(string key)
        //{
        //    Tracing.Information("[UserAccountService.GetByVerificationKey] called for key: {0}", key);

        //    if (String.IsNullOrWhiteSpace(key)) return null;

        //    key = this.Configuration.Crypto.Hash(key);

        //    var account = UserLogic.GetByVerificationKey(key);
        //    if (account == null)
        //    {
        //        Tracing.Warning("[UserAccountService.GetByVerificationKey] failed to locate account: {0}", key);
        //    }
        //    return account;
        //}

        public virtual async Task<TAccount> GetByLinkedAccountAsync(string provider, string id)
        {
            return await GetByLinkedAccountAsync(null, provider, id);
        }

        public virtual async Task<TAccount> GetByLinkedAccountAsync(string tenant, string provider, string id)
        {
            if (!Configuration.MultiTenant)
            {
                Tracing.Verbose("[UserAccountService.GetByLinkedAccount] applying default tenant");
                tenant = Configuration.DefaultTenant;
            }

            Tracing.Information("[UserAccountService.GetByLinkedAccount] called for tenant: {0}, provider; {1}, id: {2}", tenant, provider, id);

            if (String.IsNullOrWhiteSpace(tenant)) return null;
            if (String.IsNullOrWhiteSpace(provider)) return null;
            if (String.IsNullOrWhiteSpace(id)) return null;

            var query =
                from u in (await UserLogic.GetAllUserAccountAsync())
                where u.Tenant == tenant
                from l in u.LinkedAccounts
                where l.ProviderName == provider && l.ProviderAccountID == id
                select u;

            var account = query.SingleOrDefault();
            if (account == null)
            {
                Tracing.Warning("[UserAccountService.GetByLinkedAccount] failed to locate by tenant: {0}, provider: {1}, id: {2}", tenant, provider, id);
            }
            return account as TAccount;
        }

        public virtual async Task<TAccount> GetByCertificateAsync(string thumbprint)
        {
            return await GetByCertificateAsync(null, thumbprint);
        }

        public virtual async Task<TAccount> GetByCertificateAsync(string tenant, string thumbprint)
        {
            if (!Configuration.MultiTenant)
            {
                Tracing.Verbose("[UserAccountService.GetByCertificate] applying default tenant");
                tenant = Configuration.DefaultTenant;
            }

            Tracing.Information("[UserAccountService.GetByCertificate] called for tenant: {0}, thumbprint; {1}", tenant, thumbprint);

            if (String.IsNullOrWhiteSpace(tenant)) return null;
            if (String.IsNullOrWhiteSpace(thumbprint)) return null;

            var query =
                from u in (await UserLogic.GetAllUserAccountAsync())
                where u.Tenant == tenant
                from c in u.Certificates
                where c.Thumbprint == thumbprint
                select u;

            var account = query.SingleOrDefault();
            if (account == null)
            {
                Tracing.Warning("[UserAccountService.GetByCertificate] failed to locate by certificate thumbprint: {0}, {1}", tenant, thumbprint);
            }
            return account as TAccount;
        }

        public virtual async Task<bool> UsernameExistsAsync(string username)
        {
            return await UsernameExistsAsync(null, username);
        }

        public virtual async Task<bool> UsernameExistsAsync(string tenant, string username)
        {
            Tracing.Information("[UserAccountService.UsernameExists] called for tenant: {0}, username; {1}", tenant, username);

            if (String.IsNullOrWhiteSpace(username)) return false;

            if (Configuration.UsernamesUniqueAcrossTenants)
            {
                return (await UserLogic.GetBAUserAccountByUsernameAsync(username) != null);
            }
            else
            {
                if (!Configuration.MultiTenant)
                {
                    Tracing.Verbose("[UserAccountService.UsernameExists] applying default tenant");
                    tenant = Configuration.DefaultTenant;
                }

                if (String.IsNullOrWhiteSpace(tenant)) return false;

                return (await UserLogic.GetBAUserAccountByUsernameAsync(username) != null);
            }
        }

        public virtual async Task<bool> EmailExistsAsync(string email)
        {
            return await EmailExistsAsync(null, email);
        }

        public virtual async Task<bool> EmailExistsAsync(string tenant, string email)
        {
            if (!Configuration.MultiTenant)
            {
                Tracing.Verbose("[UserAccountService.EmailExists] applying default tenant");
                tenant = Configuration.DefaultTenant;
            }

            Tracing.Information("[UserAccountService.EmailExists] called for tenant: {0}, email; {1}", tenant, email);

            if (String.IsNullOrWhiteSpace(tenant)) return false;
            if (String.IsNullOrWhiteSpace(email)) return false;

            return (await UserLogic.GetBAUserAccountByEmailAsync(email) != null);
        }

        protected internal async Task<bool> EmailExistsOtherThanAsync(TAccount account, string email)
        {
            if (account == null) throw new ArgumentNullException("account");

            Tracing.Information("[UserAccountService.EmailExistsOtherThan] called for account id: {0}, email; {1}", account.ID, email);

            if (String.IsNullOrWhiteSpace(email)) return false;

            return (await UserLogic.GetBAUserAccountByEmailAndNotIDAsync(email, account.ID) != null);
        }

        public virtual async Task<TAccount> CreateAccountAsync(string username, string password, string email, string phoneNumber, Guid userId)
        {
            return await CreateAccountAsync(null, username, password, email, phoneNumber, userId);
        }
        public virtual async Task<TAccount> CreateAccountAsync(string tenant, string username, string password, string email, string phoneNumber, Guid userId)
        {
            if (Configuration.EmailIsUsername)
            {
                Tracing.Verbose("[UserAccountService.CreateAccount] applying email is username");
                username = email;
            }

            if (!Configuration.MultiTenant)
            {
                Tracing.Verbose("[UserAccountService.CreateAccount] applying default tenant");
                tenant = Configuration.DefaultTenant;
            }

            Tracing.Information("[UserAccountService.CreateAccount] called: {0}, {1}, {2}", tenant, username, email);

            TAccount account = new BrockAllen.MembershipReboot.UserAccount() as TAccount;
            Init(account, tenant, username, password, email, phoneNumber, userId);

            await ValidateEmailAsync(account, email);
            await ValidateUsernameAsync(account, username);
            await ValidatePasswordAsync(account, password);

            Tracing.Verbose("[UserAccountService.CreateAccount] success");

            this.AddEvent(new AccountCreatedEvent<TAccount> { Account = account, InitialPassword = password, VerificationKey = m_key });

            await UserLogic.AddUserAccountAsync(account);

            return account;
        }

        protected void Init(TAccount account, string tenant, string username, string password, string email, string phoneNumber, Guid userId)
        {
            Tracing.Information("[UserAccountService.Init] called");

            if (account == null)
            {
                Tracing.Error("[UserAccountService.Init] failed -- null account");
                throw new ArgumentNullException("account");
            }

            if (account.Claims == null) account.Claims = new List<UserClaim>();
            if (account.LinkedAccounts == null) account.LinkedAccounts = new List<LinkedAccount>();
            if (account.Certificates == null) account.Certificates = new List<UserCertificate>();
            if (account.TwoFactorAuthTokens == null) account.TwoFactorAuthTokens = new List<TwoFactorAuthToken>();
            if (account.PasswordResetSecrets == null) account.PasswordResetSecrets = new List<PasswordResetSecret>();

            if (String.IsNullOrWhiteSpace(tenant))
            {
                Tracing.Error("[UserAccountService.Init] failed -- no tenant");
                throw new ArgumentNullException("tenant");
            }

            if (String.IsNullOrWhiteSpace(username))
            {
                Tracing.Error("[UserAccountService.Init] failed -- no username");
                throw new ValidationException(Resources.ValidationMessages.UsernameRequired);
            }

            if (password != null && String.IsNullOrWhiteSpace(password.Trim()))
            {
                Tracing.Error("[UserAccountService.Init] failed -- no password");
                throw new ValidationException(Resources.ValidationMessages.PasswordRequired);
            }

            if (account.ID != Guid.Empty)
            {
                Tracing.Error("[UserAccountService.Init] failed -- ID already assigned");
                throw new Exception("Can't call Init if UserAccount is already assigned an ID");
            }

            account.ID = userId;
            account.Tenant = tenant;
            account.Username = username;
            account.Email = email;
            account.Created = DateTime.Now;
            account.LastUpdated = account.Created;
            account.HashedPassword = password != null ?
                Configuration.Crypto.HashPassword(password, this.Configuration.PasswordHashingIterationCount) : null;
            account.PasswordChanged = password != null ? account.Created : (DateTime?)null;
            account.AccountTwoFactorAuthMode = (int)TwoFactorAuthMode.None;
            account.CurrentTwoFactorAuthStatus = (int)TwoFactorAuthMode.None;
            account.IsLoginAllowed = false; 
            account.IsTemporaryAccount = true; // when the user is registered then it is changed to false
            account.IsAccountVerified = true; //No verification method exists for accounts once created. Use isApproved for approvals on account
            account.IsActive = true;
            account.IsForgotPasswordRequestAllowed = true;
            account.IsForgotUsernameRequestAllowed = false; // the username is e-mail and you cannot recover it if you forgot
            account.MobilePhoneNumber = phoneNumber;
            Tracing.Verbose("[UserAccountService.CreateAccount] SecuritySettings.AllowLoginAfterAccountCreation is set to: {0}", account.IsLoginAllowed);
            
            if (!String.IsNullOrWhiteSpace(account.Email))
            {
                Tracing.Verbose("[UserAccountService.CreateAccount] Email was provided, so creating email verification request");
                m_key = SetVerificationKey(account, VerificationKeyPurpose.ChangeEmail, state: account.Email);
            }
        }

        public virtual async Task RequestAccountVerificationAsync(Guid accountID)
        {
            Tracing.Information("[UserAccountService.RequestAccountVerification] called for account id: {0}", accountID);

            var account = await this.GetByIDAsync(accountID);
            if (account == null)
            {
                Tracing.Error("[UserAccountService.RequestAccountVerification] invalid account id");
                throw new Exception("Invalid Account ID");
            }

            if (String.IsNullOrWhiteSpace(account.Email))
            {
                Tracing.Error("[UserAccountService.RequestAccountVerification] email empty");
                throw new ValidationException(Resources.ValidationMessages.EmailRequired);
            }

            if (account.IsAccountVerified)
            {
                Tracing.Error("[UserAccountService.RequestAccountVerification] account already verified");
                throw new ValidationException(Resources.ValidationMessages.AccountAlreadyVerified);
            }

            Tracing.Verbose("[UserAccountService.RequestAccountVerification] creating a new verification key");
            var key = SetVerificationKey(account, VerificationKeyPurpose.ChangeEmail, state: account.Email);
            this.AddEvent(new EmailChangeRequestedEvent<TAccount> { Account = account, NewEmail = account.Email, VerificationKey = key });

            await UpdateAsync(account);
        }


        public virtual async Task DeleteAccountAsync(Guid accountID)
        {
            Tracing.Information("[UserAccountService.DeleteAccount] called: {0}", accountID);

            var account = await this.GetByIDAsync(accountID);
            if (account == null) throw new ArgumentException("Invalid AccountID");

            await DeleteAccountAsync(account);
        }

        protected virtual async Task DeleteAccountAsync(TAccount account)
        {
            if (account == null) throw new ArgumentNullException("account");

            Tracing.Verbose("[UserAccountService.DeleteAccount] marking account as closed: {0}", account.ID);

            CloseAccount(account);
            await UpdateAsync(account);

            if (Configuration.AllowAccountDeletion || account.IsNew())
            {
                Tracing.Verbose("[UserAccountService.DeleteAccount] removing account record: {0}", account.ID);
                await UserLogic.RemoveUserAccountAsync(account);
            }
        }
        public virtual async Task CloseAccountAsync(Guid accountID)
        {
            var account = await this.GetByIDAsync(accountID);
            if (account == null) throw new ArgumentException("Invalid AccountID");
            
            Tracing.Verbose("[UserAccountService.DeleteAccount] marking account as closed: {0}", account.ID);

            CloseAccount(account);
            await UpdateAsync(account);
        }

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="userAccount"></param>
        /// <param name="tenant"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public virtual UserLoginValidation Authenticate(UserAccount userAccount,string tenant, string username, string password)
        {
            UserLoginValidation result = new UserLoginValidation();
            if (!Configuration.MultiTenant)
            {
                Tracing.Verbose("[UserAccountService.Authenticate] applying default tenant");
                tenant = Configuration.DefaultTenant;
            }

            Tracing.Information("[UserAccountService.Authenticate] called: {0}, {1}", tenant, username);

            if (!Configuration.UsernamesUniqueAcrossTenants && String.IsNullOrWhiteSpace(tenant))
            {
                result.valid = false;
                return result;
            }
            if (String.IsNullOrWhiteSpace(username))
            {
                result.valid = false;
                return result;
            }
            if (String.IsNullOrWhiteSpace(password))
            {
                Tracing.Error("[UserAccountService.CancelVerification] failed -- empty password");
                result.valid = false;
                result.validationMessage = "Empty password";
                return result;
            }

            if (userAccount == null)
            {
                result.valid = false;
                result.validationMessage = "Invalid Username or Password";
                return result;
            }

            if(!userAccount.IsActive)
            {
                result.valid = false;
                result.validationMessage = "Invalid Username or Password";
                return result;
            }

            return Authenticate(userAccount, password, AuthenticationPurpose.SignIn);
        }

        /// <summary>
        /// AuthenticateWithUsername
        /// </summary>
        /// <param name="userAccount"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public virtual UserLoginValidation AuthenticateWithUsername(UserAccount userAccount,string userName, string password)
        {
            return AuthenticateWithUsername(userAccount,null, userName, password);
        }

        /// <summary>
        /// AuthenticateWithUsername
        /// </summary>
        /// <param name="userAccount"></param>
        /// <param name="tenant"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public virtual UserLoginValidation AuthenticateWithUsername(UserAccount userAccount, string tenant, string userName, string password)
        {
            UserLoginValidation result = new UserLoginValidation();
            if (!Configuration.MultiTenant)
            {
                Tracing.Verbose("[UserAccountService.AuthenticateWithUsernameOrEmail] applying default tenant");
                tenant = Configuration.DefaultTenant;
            }

            Tracing.Information("[UserAccountService.AuthenticateWithUsernameOrEmail] called {0}, {1}", tenant, userName);

            if (String.IsNullOrWhiteSpace(tenant)) { result.valid = false;
            return result;
            }
            if (String.IsNullOrWhiteSpace(userName))
            {
                result.valid = false;
                result.validationMessage = "Invalid Username or Password";
                return result;
            }
            if (String.IsNullOrWhiteSpace(password))
            {
                Tracing.Error("[UserAccountService.AuthenticateWithUsernameOrEmail] failed -- empty password");
                result.valid = false;
                result.validationMessage = "Invalid Username or Password";
                return result;
            }

            if (!Configuration.EmailIsUsername && userName.Contains("@"))
            {
                result.valid = false;
                result.validationMessage = "Invalid Username or Password";
                return result;
            }
            else
            {
                Tracing.Verbose("[UserAccountService.AuthenticateWithUsernameOrEmail] username detected");
                return Authenticate(userAccount, tenant, userName, password);
            }
        }

        /// <summary>
        ///  Authe
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <param name="purpose"></param>
        /// <returns></returns>
        protected virtual UserLoginValidation Authenticate(UserAccount account, string password, AuthenticationPurpose purpose)
        {
            Tracing.Verbose("[UserAccountService.Authenticate] for account: {0}", account.ID);

            var result = Authenticate(account, password);

            if (purpose == AuthenticationPurpose.SignIn &&
                Configuration.RequireAccountVerification &&
                !account.IsAccountVerified)
            {
                Tracing.Error("[UserAccountService.Authenticate] failed -- account not verified");
                this.AddEvent(new AccountNotVerifiedEvent<UserAccount>() { Account = account });
                result.valid = false;
            }

            if (result.valid &&
                purpose == AuthenticationPurpose.SignIn &&
                account.AccountTwoFactorAuthMode != (int)TwoFactorAuthMode.None)
            {
                Tracing.Verbose("[UserAccountService.Authenticate] password authN successful, doing two factor auth checks: {0}, {1}", account.Tenant, account.Username);

                bool shouldRequestTwoFactorAuthCode = true;
                if (this.TwoFactorAuthenticationPolicy != null)
                {
                    Tracing.Verbose("[UserAccountService.Authenticate] TwoFactorAuthenticationPolicy configured");

                    var token = this.TwoFactorAuthenticationPolicy.GetTwoFactorAuthToken(account);
                    if (!String.IsNullOrWhiteSpace(token))
                    {
                        shouldRequestTwoFactorAuthCode = !VerifyTwoFactorAuthToken(account, token);
                        Tracing.Verbose("[UserAccountService.Authenticate] TwoFactorAuthenticationPolicy token found, was verified: {0}", shouldRequestTwoFactorAuthCode);
                    }
                    else
                    {
                        Tracing.Verbose("[UserAccountService.Authenticate] TwoFactorAuthenticationPolicy no token present");
                    }
                }

                if (shouldRequestTwoFactorAuthCode)
                {
                    if (account.AccountTwoFactorAuthMode == (int)TwoFactorAuthMode.Certificate)
                    {
                        Tracing.Verbose("[UserAccountService.Authenticate] requesting 2fa certificate: {0}, {1}", account.Tenant, account.Username);
                        result.valid = RequestTwoFactorAuthCertificate(account);
                    }

                    if (account.AccountTwoFactorAuthMode == (int)TwoFactorAuthMode.Mobile)
                    {
                        Tracing.Verbose("[UserAccountService.Authenticate] requesting 2fa mobile code: {0}, {1}", account.Tenant, account.Username);
                        result.valid = RequestTwoFactorAuthCode(account);
                    }
                }
                else
                {
                    Tracing.Verbose("[UserAccountService.Authenticate] setting two factor auth status to None");
                    account.CurrentTwoFactorAuthStatus = (int)TwoFactorAuthMode.None;
                }
            }

            //deliberately not awaited
            UpdateAsync(account);

            Tracing.Verbose("[UserAccountService.Authenticate] authentication outcome: {0}", result.valid ? "Successful Login" : "Failed Login");

            return result;
        }


        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        protected virtual UserLoginValidation Authenticate(UserAccount account, string password)
        {
            Tracing.Information("[UserAccountService.Authenticate] called for accountID: {0}", account.ID);
            UserLoginValidation userValidation = new UserLoginValidation();
            if (String.IsNullOrWhiteSpace(password))
            {
                Tracing.Error("[UserAccountService.Authenticate] failed -- no password");
                userValidation.valid = false;
                userValidation.validationMessage = "No password";
                return userValidation;
            }

            if (!account.HasPassword())
            {
                Tracing.Error("[UserAccountService.Authenticate] failed -- account does not have a password");
                userValidation.valid = false;
                userValidation.validationMessage = "Account does not have a password";
                return userValidation;
            }

            if (account.IsAccountClosed)
            {
                Tracing.Error("[UserAccountService.Authenticate] failed -- account closed");
                this.AddEvent(new InvalidAccountEvent<UserAccount> { Account = account });
                userValidation.valid = false;
                userValidation.validationMessage = "Account closed";
                return userValidation;
            }

            if (!account.IsLoginAllowed)
            {
                Tracing.Error("[UserAccountService.Authenticate] failed -- account not allowed to login");
                this.AddEvent(new AccountLockedEvent<UserAccount> { Account = account });
                userValidation.valid = false;
                userValidation.validationMessage = "Account not allowed to login";
                return userValidation;
            }

            if (HasTooManyRecentPasswordFailures(account))
            {
                Tracing.Error("[UserAccountService.Authenticate] failed -- Your account has been locked for 30 minutes due to too many failed login attempts");
                this.AddEvent(new TooManyRecentPasswordFailuresEvent<UserAccount> { Account = account });
                userValidation.valid = false;
                userValidation.validationMessage = "Your account has been locked for 30 minutes due to too many failed login attempts";
                return userValidation;
            }



            userValidation.valid = VerifyHashedPassword(account, password);
            if (userValidation.valid)
            {
                Tracing.Verbose("[UserAccountService.Authenticate] authentication success");
                userValidation.validationMessage = "Authentication success";
                RecordSuccessfulLogin(account);
                this.AddEvent(new SuccessfulPasswordLoginEvent<UserAccount> { Account = account });
            }
            else
            {
                Tracing.Error("[UserAccountService.Authenticate] failed -- invalid password");
                userValidation.validationMessage = "Invalid Username or Password";
                RecordInvalidLoginAttempt(account);
                this.AddEvent(new InvalidPasswordEvent<UserAccount> { Account = account });
            }

            return userValidation;
        }

        protected internal bool VerifyHashedPassword(UserAccount account, string password)
        {
            return Configuration.Crypto.VerifyHashedPassword(account.HashedPassword, password);
        }

        protected virtual bool HasTooManyRecentPasswordFailures(UserAccount account)
        {
            var result = false;
            if (Configuration.AccountLockoutFailedLoginAttempts <= account.FailedLoginCount + 1)
            {
                result = account.LastFailedLogin >= DateTime.Now.Subtract(Configuration.AccountLockoutDuration);
                
                // This fixes a bug where after a 30min lock out has expired, we need to ensure we can do another 6 attempts.
                if (!result)
                    account.FailedLoginCount = 0;
            }

            if (result)
            {
                account.FailedLoginCount++;
            }

            return result;
        }

        protected virtual void RecordSuccessfulLogin(UserAccount account)
        {
            account.LastLogin = DateTime.Now;
            account.FailedLoginCount = 0;
        }

        protected virtual void RecordInvalidLoginAttempt(UserAccount account)
        {
            account.LastFailedLogin = DateTime.Now;
            if (account.FailedLoginCount <= 0)
            {
                account.FailedLoginCount = 1;
            }
            else
            {
                account.FailedLoginCount++;
            }
        }

        public virtual async Task<TAccount> AuthenticateWithCodeAsync(Guid accountID, string code)
        {
            Tracing.Information("[UserAccountService.AuthenticateWithCode] called {0}", accountID);

            var account = await this.GetByIDAsync(accountID);
            if (account == null) throw new ArgumentException("Invalid AccountID");

            Tracing.Information("[UserAccountService.AuthenticateWithCode] called for accountID: {0}", account.ID);

            if (code == null)
            {
                Tracing.Error("[UserAccountService.AuthenticateWithCode] failed - null code");
                return null;
            }

            if (account.IsAccountClosed)
            {
                Tracing.Error("[UserAccountService.AuthenticateWithCode] failed -- account closed");
                return null;
            }

            if (!account.IsLoginAllowed)
            {
                Tracing.Error("[UserAccountService.AuthenticateWithCode] failed -- login not allowed");
                return null;
            }

            if (account.AccountTwoFactorAuthMode != (int)TwoFactorAuthMode.Mobile)
            {
                Tracing.Error("[UserAccountService.AuthenticateWithCode] failed -- two factor auth mode not mobile");
                return null;
            }

            if (account.CurrentTwoFactorAuthStatus != (int)TwoFactorAuthMode.Mobile)
            {
                Tracing.Error("[UserAccountService.AuthenticateWithCode] failed -- current auth status not mobile");
                return null;
            }

            if (!VerifyMobileCode(account, code))
            {
                Tracing.Error("[UserAccountService.AuthenticateWithCode] failed -- mobile code failed to verify");
                return null;
            }

            ClearMobileAuthCode(account);

            account.LastLogin = DateTime.Now;
            account.CurrentTwoFactorAuthStatus = (int)TwoFactorAuthMode.None;

            this.AddEvent(new SuccessfulTwoFactorAuthCodeLoginEvent<TAccount> { Account = account });

            Tracing.Verbose("[UserAccountService.AuthenticateWithCode] success ");

            if (this.TwoFactorAuthenticationPolicy != null)
            {
                CreateTwoFactorAuthToken(account);
                Tracing.Verbose("[UserAccountService.AuthenticateWithCode] TwoFactorAuthenticationPolicy issuing a new two factor auth token");
            };

            await UpdateAsync(account);

            return account;
        }

        public virtual async Task<TAccount> AuthenticateWithCertificateAsync(X509Certificate2 certificate)
        {
            Tracing.Information("[UserAccountService.AuthenticateWithCertificate] called");

            if (!certificate.Validate())
            {
                Tracing.Error("[UserAccountService.AuthenticateWithCertificate] failed -- cert failed to validate");
                return null;
            }

            var account = await this.GetByCertificateAsync(certificate.Thumbprint);
            if (account == null) return null;

            var result = Authenticate(account, certificate);
            await UpdateAsync(account);

            Tracing.Verbose("[UserAccountService.AuthenticateWithCertificate] result {0}", result);

            return account;
        }

        public virtual async Task<TAccount> AuthenticateWithCertificateAsync(Guid accountID, X509Certificate2 certificate)
        {
            Tracing.Information("[UserAccountService.AuthenticateWithCertificate] called for userID: {0}", accountID);

            if (!certificate.Validate())
            {
                Tracing.Error("[UserAccountService.AuthenticateWithCertificate] failed -- cert failed to validate");
                return null;
            }

            var account = await this.GetByIDAsync(accountID);
            if (account == null) throw new ArgumentException("Invalid AccountID");

            var result = Authenticate(account, certificate);
            await UpdateAsync(account);

            Tracing.Verbose("[UserAccountService.AuthenticateWithCertificate] result: {0}", result);

            return account;
        }

        protected virtual bool Authenticate(TAccount account, X509Certificate2 certificate)
        {
            Tracing.Information("[UserAccountService.Authenticate] certificate auth called for account ID: {0}", account.ID);

            if (!certificate.Validate())
            {
                Tracing.Error("[UserAccountService.Authenticate] failed -- cert failed to validate");
                return false;
            }

            Tracing.Verbose("[UserAccountService.Authenticate] cert: {0}", certificate.Thumbprint);

            if (!(certificate.NotBefore < DateTime.Now && DateTime.Now < certificate.NotAfter))
            {
                Tracing.Error("[UserAccountService.Authenticate] failed -- invalid certificate dates");
                this.AddEvent(new InvalidCertificateEvent<TAccount> { Account = account, Certificate = certificate });
                return false;
            }

            var match = account.Certificates.FirstOrDefault(x => x.Thumbprint.Equals(certificate.Thumbprint, StringComparison.OrdinalIgnoreCase));
            if (match == null)
            {
                Tracing.Error("[UserAccountService.Authenticate] failed -- no certificate thumbprint match");
                this.AddEvent(new InvalidCertificateEvent<TAccount> { Account = account, Certificate = certificate });
                return false;
            }

            Tracing.Verbose("[UserAccountService.Authenticate] success");

            account.LastLogin = DateTime.Now;
            account.CurrentTwoFactorAuthStatus = (int)TwoFactorAuthMode.None;

            this.AddEvent(new SuccessfulCertificateLoginEvent<TAccount> { Account = account, UserCertificate = match, Certificate = certificate });

            return true;
        }

        public virtual async Task SetIsLoginAllowedAsync(Guid accountID, bool isLoginAllowed)
        {
            Tracing.Information("[UserAccountService.SetIsLoginAllowed] called: {0}", accountID);

            var account = await this.GetByIDAsync(accountID);
            if (account == null) throw new ArgumentException("Invalid AccountID");

            account.IsLoginAllowed = isLoginAllowed;

            Tracing.Verbose("[UserAccountService.SetIsLoginAllowed] success");

            await UpdateAsync(account);
        }

        public virtual async Task SetRequiresPasswordResetAsync(Guid accountID, bool requiresPasswordReset)
        {
            Tracing.Information("[UserAccountService.SetRequiresPasswordReset] called: {0}", accountID);

            var account = await this.GetByIDAsync(accountID);
            if (account == null) throw new ArgumentException("Invalid AccountID");

            account.RequiresPasswordReset = requiresPasswordReset;

            Tracing.Verbose("[UserAccountService.SetRequiresPasswordReset] success");

            await UpdateAsync(account);
        }

        public virtual async Task SetPasswordAsync(Guid accountID, string newPassword)
        {
            Tracing.Information("[UserAccountService.SetPassword] called: {0}", accountID);

            if (String.IsNullOrWhiteSpace(newPassword))
            {
                Tracing.Error("[UserAccountService.SetPassword] failed -- null newPassword");
                throw new ValidationException(Resources.ValidationMessages.InvalidNewPassword);
            }

            var account = await this.GetByIDAsync(accountID);
            if (account == null) throw new ArgumentException("Invalid AccountID");

            //ValidatePassword(account, newPassword); This checks for different check which we don't need so commented it

            SetPassword(account, newPassword);
            await UpdateAsync(account);

            Tracing.Verbose("[UserAccountService.SetPassword] success");
        }

        public virtual async Task SetPasswordAndClearVerificationKeyAsync(Guid accountID, string newPassword)
        {
            Tracing.Information("[UserAccountService.SetPassword] called: {0}", accountID);

            if (String.IsNullOrWhiteSpace(newPassword))
            {
                Tracing.Error("[UserAccountService.SetPassword] failed -- null newPassword");
                throw new ValidationException(Resources.ValidationMessages.InvalidNewPassword);
            }

            var account = await this.GetByIDAsync(accountID);
            if (account == null) throw new ArgumentException("Invalid AccountID");

            ValidatePasswordAsync(account, newPassword);
            SetPassword(account, newPassword);
            ClearVerificationKey(account);
            await UpdateAsync(account);

            Tracing.Verbose("[UserAccountService.SetPassword] success");
        }

        public virtual async Task ChangePasswordAsync(Guid accountID, string oldPassword, string newPassword)
        {
            Tracing.Information("[UserAccountService.ChangePassword] called: {0}", accountID);

            if (String.IsNullOrWhiteSpace(oldPassword))
            {
                Tracing.Error("[UserAccountService.ChangePassword] failed -- null oldPassword");
                throw new ValidationException(Resources.ValidationMessages.InvalidOldPassword);
            }
            if (String.IsNullOrWhiteSpace(newPassword))
            {
                Tracing.Error("[UserAccountService.ChangePassword] failed -- null newPassword");
                throw new ValidationException(Resources.ValidationMessages.InvalidNewPassword);
            }

            var account = await this.GetByIDAsync(accountID);
            if (account == null) throw new ArgumentException("Invalid AccountID");

            ValidatePasswordAsync(account, newPassword);
            var result = Authenticate(account, oldPassword, AuthenticationPurpose.VerifyPassword).valid;
            if (!result)
            {
                Tracing.Error("[UserAccountService.ChangePassword] failed -- failed authN");
                throw new ValidationException(Resources.ValidationMessages.InvalidOldPassword);
            }

            Tracing.Verbose("[UserAccountService.ChangePassword] success");

            SetPassword(account, newPassword);
            await UpdateAsync(account);
        }

        public virtual async Task ResetPasswordAsync(string email)
        {
            await ResetPasswordAsync(null, email);
        }

        public async Task<string> ResetPasswordAndReturnVerificationKeyAsync(Guid userId)
        {
            var account = await this.GetByIDAsync(userId);

            var key = SetVerificationKey(account, VerificationKeyPurpose.ResetPassword);
            
            await UpdateAsync(account);

            return key;
        }

        public virtual async Task ResetPasswordAsync(string tenant, string email)
        {
            if (!Configuration.MultiTenant)
            {
                Tracing.Verbose("[UserAccountService.ResetPassword] applying default tenant");
                tenant = Configuration.DefaultTenant;
            }

            Tracing.Information("[UserAccountService.ResetPassword] called: {0}, {1}", tenant, email);

            if (String.IsNullOrWhiteSpace(tenant))
            {
                Tracing.Error("[UserAccountService.ResetPassword] failed -- null tenant");
                throw new ValidationException(Resources.ValidationMessages.InvalidTenant);
            }
            if (String.IsNullOrWhiteSpace(email))
            {
                Tracing.Error("[UserAccountService.ResetPassword] failed -- null email");
                throw new ValidationException(Resources.ValidationMessages.InvalidEmail);
            }

            var account = await this.GetByEmailAsync(tenant, email);
            if (account == null) throw new ValidationException(Resources.ValidationMessages.InvalidEmail);

            if (account.PasswordResetSecrets.Count > 0)
            {
                Tracing.Error("[UserAccountService.ResetPassword] failed -- account configured for secret question/answer");
                throw new ValidationException(Resources.ValidationMessages.AccountPasswordResetRequiresSecretQuestion);
            }

            Tracing.Verbose("[UserAccountService.ResetPassword] success");

            ResetPassword(account);
            await UpdateAsync(account);
        }

        public virtual async Task AddPasswordResetSecretAsync(Guid accountID, string password, string question, string answer)
        {
            Tracing.Information("[UserAccountService.AddPasswordResetSecret] called: {0}", accountID);

            if (String.IsNullOrWhiteSpace(password))
            {
                Tracing.Error("[UserAccountService.AddPasswordResetSecret] failed -- null oldPassword");
                throw new ValidationException(Resources.ValidationMessages.InvalidPassword);
            }
            if (String.IsNullOrWhiteSpace(question))
            {
                Tracing.Error("[UserAccountService.AddPasswordResetSecret] failed -- null question");
                throw new ValidationException(Resources.ValidationMessages.SecretQuestionRequired);
            }
            if (String.IsNullOrWhiteSpace(answer))
            {
                Tracing.Error("[UserAccountService.AddPasswordResetSecret] failed -- null answer");
                throw new ValidationException(Resources.ValidationMessages.SecretAnswerRequired);
            }

            var account = await this.GetByIDAsync(accountID);
            if (account == null) throw new ArgumentException("Invalid AccountID");

            if (!Authenticate(account, password, AuthenticationPurpose.VerifyPassword).valid)
            {
                Tracing.Error("[UserAccountService.AddPasswordResetSecret] failed -- failed authN");
                throw new ValidationException(Resources.ValidationMessages.InvalidPassword);
            }

            if (account.PasswordResetSecrets.Any(x => x.Question == question))
            {
                Tracing.Error("[UserAccountService.AddPasswordResetSecret] failed -- question already exists");
                throw new ValidationException(Resources.ValidationMessages.SecretQuestionAlreadyInUse);
            }

            Tracing.Verbose("[UserAccountService.AddPasswordResetSecret] success");

            var secret = NewPasswordResetSecret();
            secret.PasswordResetSecretID = Guid.NewGuid();
            secret.Question = question;
            secret.Answer = this.Configuration.Crypto.Hash(answer);
            secret.QuestionID = Convert.ToInt32(question);
            account.PasswordResetSecrets.Add(secret);

            this.AddEvent(new PasswordResetSecretAddedEvent<TAccount> { Account = account, Secret = secret });

            await UpdateAsync(account);
        }

        public virtual async Task RemovePasswordResetSecretAsync(Guid accountID, Guid PasswordResetSecretID)
        {
            Tracing.Information("[UserAccountService.RemovePasswordResetSecret] called: Acct: {0}, Question: {1}", accountID, PasswordResetSecretID);

            var account = await this.GetByIDAsync(accountID);
            if (account == null) throw new ArgumentException("Invalid AccountID");

            var item = account.PasswordResetSecrets.SingleOrDefault(x => x.PasswordResetSecretID == PasswordResetSecretID);
            if (item != null)
            {
                Tracing.Verbose("[UserAccountService.RemovePasswordResetSecret] success -- item removed");

                account.PasswordResetSecrets.Remove(item);
                this.AddEvent(new PasswordResetSecretRemovedEvent<TAccount> { Account = account, Secret = item });
                await UpdateAsync(account);
            }
            else
            {
                Tracing.Verbose("[UserAccountService.RemovePasswordResetSecret] no matching item found");
            }
        }

        public virtual async Task ResetPasswordFromSecretQuestionAndAnswerAsync(Guid accountID, PasswordResetQuestionAnswer[] answers)
        {
            Tracing.Information("[UserAccountService.ResetPasswordFromSecretQuestionAndAnswer] called: {0}", accountID);

            if (answers == null || answers.Length == 0 || answers.Any(x => String.IsNullOrWhiteSpace(x.Answer)))
            {
                Tracing.Error("[UserAccountService.ResetPasswordFromSecretQuestionAndAnswer] failed -- no answers");
                throw new ValidationException(Resources.ValidationMessages.SecretAnswerRequired);
            }

            var account = await this.GetByIDAsync(accountID);
            if (account == null)
            {
                Tracing.Error("[UserAccountService.ResetPasswordFromSecretQuestionAndAnswer] failed -- invalid account id");
                throw new Exception("Invalid Account ID");
            }

            if (String.IsNullOrWhiteSpace(account.Email))
            {
                Tracing.Error("[UserAccountService.ResetPasswordFromSecretQuestionAndAnswer] no email to use for password reset");
                throw new ValidationException(Resources.ValidationMessages.PasswordResetErrorNoEmail);
            }

            if (account.PasswordResetSecrets.Count == 0)
            {
                Tracing.Error("[UserAccountService.ResetPasswordFromSecretQuestionAndAnswer] failed -- account not configured for secret question/answer");
                throw new ValidationException(Resources.ValidationMessages.AccountNotConfiguredWithSecretQuestion);
            }

            if (account.FailedPasswordResetCount >= Configuration.AccountLockoutFailedLoginAttempts &&
                account.LastFailedPasswordReset >= DateTime.Now.Subtract(Configuration.AccountLockoutDuration))
            {
                account.FailedPasswordResetCount++;

                this.AddEvent(new PasswordResetFailedEvent<TAccount> { Account = account });

                await UpdateAsync(account);

                Tracing.Error("[UserAccountService.ResetPasswordFromSecretQuestionAndAnswer] failed -- too many failed password reset attempts");
                throw new ValidationException(Resources.ValidationMessages.InvalidQuestionOrAnswer);
            }

            var secrets = account.PasswordResetSecrets.ToArray();
            var failed = false;
            foreach (var answer in answers)
            {
                var secret = secrets.SingleOrDefault(x => x.PasswordResetSecretID == answer.QuestionID);
                if (secret == null ||
                    !this.Configuration.Crypto.SlowEquals(secret.Answer, this.Configuration.Crypto.Hash(answer.Answer)))
                {
                    Tracing.Error("[UserAccountService.ResetPasswordFromSecretQuestionAndAnswer] failed on question id: {0}", answer.QuestionID);
                    failed = true;
                }
            }

            if (failed)
            {
                account.LastFailedPasswordReset = DateTime.Now;
                if (account.FailedPasswordResetCount <= 0)
                {
                    account.FailedPasswordResetCount = 1;
                }
                else
                {
                    account.FailedPasswordResetCount++;
                }
                this.AddEvent(new PasswordResetFailedEvent<TAccount> { Account = account });
            }
            else
            {
                Tracing.Verbose("[UserAccountService.ResetPasswordFromSecretQuestionAndAnswer] success");

                account.LastFailedPasswordReset = null;
                account.FailedPasswordResetCount = 0;
                ResetPassword(account);
            }

            await UpdateAsync(account);

            if (failed)
            {
                throw new ValidationException(Resources.ValidationMessages.InvalidQuestionOrAnswer);
            }
        }

        public virtual async Task SendUsernameReminderAsync(string email)
        {
            await SendUsernameReminderAsync(null, email);
        }

        public virtual async Task SendUsernameReminderAsync(string tenant, string email)
        {
            if (!Configuration.MultiTenant)
            {
                Tracing.Verbose("[UserAccountService.SendUsernameReminder] applying default tenant");
                tenant = Configuration.DefaultTenant;
            }

            Tracing.Information("[UserAccountService.SendUsernameReminder] called: {0}, {1}", tenant, email);

            if (String.IsNullOrWhiteSpace(tenant))
            {
                Tracing.Error("[UserAccountService.SendUsernameReminder] failed -- null tenant");
                throw new ArgumentNullException("tenant");
            }
            if (String.IsNullOrWhiteSpace(email))
            {
                Tracing.Error("[UserAccountService.SendUsernameReminder] failed -- null email");
                throw new ValidationException(Resources.ValidationMessages.InvalidEmail);
            }

            var account = await this.GetByEmailAsync(tenant, email);
            if (account == null) throw new ValidationException(Resources.ValidationMessages.InvalidEmail);

            if (!account.IsAccountVerified)
            {
                Tracing.Error("[UserAccountService.SendUsernameReminder] failed -- account not verified");
                throw new ValidationException(Resources.ValidationMessages.AccountNotVerified);
            }

            Tracing.Verbose("[UserAccountService.SendUsernameReminder] success");

            this.AddEvent(new UsernameReminderRequestedEvent<TAccount> { Account = account });

            await UpdateAsync(account);
        }

        public virtual async Task ChangeUsernameAndEmailAsync(Guid accountID, string newUsername)
        {
            Tracing.Information("[UserAccountService.ChangeUsername] called account id: {0}, new username: {1}", accountID, newUsername);

            if (String.IsNullOrWhiteSpace(newUsername))
            {
                Tracing.Error("[UserAccountService.ChangeUsername] failed -- null newUsername");
                throw new ValidationException(Resources.ValidationMessages.InvalidUsername);
            }

            var account = await this.GetByIDAsync(accountID);
            if (account == null) throw new ArgumentException("Invalid AccountID");

            ValidateEmailAsync(account, newUsername);
            ValidateUsernameAsync(account, newUsername);

            Tracing.Verbose("[UserAccountService.ChangeUsername] success");

            account.Username = newUsername;
            account.Email = newUsername;

            this.AddEvent(new UsernameChangedEvent<TAccount> { Account = account });

            await UpdateAsync(account);
        }

        public virtual async Task ChangeEmailRequestAsync(Guid accountID, string newEmail)
        {
            Tracing.Information("[UserAccountService.ChangeEmailRequest] called: {0}, {1}", accountID, newEmail);

            var account = await this.GetByIDAsync(accountID);
            if (account == null) throw new ArgumentException("Invalid AccountID");

            ValidateEmailAsync(account, newEmail);

            var oldEmail = account.Email;

            Tracing.Verbose("[UserAccountService.ChangeEmailRequest] creating a new reset key");
            var key = SetVerificationKey(account, VerificationKeyPurpose.ChangeEmail, state: newEmail);

            if (!Configuration.RequireAccountVerification)
            {
                Tracing.Verbose("[UserAccountService.ChangeEmailRequest] RequireAccountVerification false, changing email");
                account.IsAccountVerified = false;
                account.Email = newEmail;

                this.AddEvent(new EmailChangedEvent<TAccount> { Account = account, OldEmail = oldEmail, VerificationKey = key });
            }
            else
            {
                Tracing.Verbose("[UserAccountService.ChangeEmailRequest] RequireAccountVerification true, sending changing email");
                this.AddEvent(new EmailChangeRequestedEvent<TAccount> { Account = account, OldEmail = oldEmail, NewEmail = newEmail, VerificationKey = key });
            }

            Tracing.Verbose("[UserAccountService.ChangeEmailRequest] success");

            await UpdateAsync(account);
        }

        public virtual async Task RemoveMobilePhoneAsync(Guid accountID)
        {
            Tracing.Information("[UserAccountService.RemoveMobilePhone] called: {0}", accountID);

            var account = await this.GetByIDAsync(accountID);
            if (account == null) throw new ArgumentException("Invalid AccountID");

            Tracing.Information("[UserAccountService.ClearMobilePhoneNumber] called for accountID: {0}", account.ID);

            if (account.AccountTwoFactorAuthMode == (int)TwoFactorAuthMode.Mobile)
            {
                Tracing.Verbose("[UserAccountService.ClearMobilePhoneNumber] disabling two factor auth");
                ConfigureTwoFactorAuthentication(account, TwoFactorAuthMode.None);
            }

            if (String.IsNullOrWhiteSpace(account.MobilePhoneNumber))
            {
                Tracing.Warning("[UserAccountService.ClearMobilePhoneNumber] nothing to do -- no mobile associated with account");
                return;
            }

            Tracing.Verbose("[UserAccountService.ClearMobilePhoneNumber] success");

            ClearMobileAuthCode(account);

            account.MobilePhoneNumber = null;
            account.MobilePhoneNumberChanged = DateTime.Now;

            this.AddEvent(new MobilePhoneRemovedEvent<TAccount> { Account = account });

            await UpdateAsync(account);
        }

        public virtual async Task ChangeMobilePhoneRequestAsync(Guid accountID, string newMobilePhoneNumber)
        {
            Tracing.Information("[UserAccountService.ChangeMobilePhoneRequest] called: {0}, {1}", accountID, newMobilePhoneNumber);

            if (String.IsNullOrWhiteSpace(newMobilePhoneNumber))
            {
                Tracing.Error("[UserAccountService.ChangeMobilePhoneRequest] failed -- null newMobilePhoneNumber");
                throw new ValidationException(Resources.ValidationMessages.InvalidPhone);
            }

            var account = await this.GetByIDAsync(accountID);
            if (account == null) throw new ArgumentException("Invalid AccountID");

            if (account.MobilePhoneNumber == newMobilePhoneNumber)
            {
                Tracing.Error("[UserAccountService.RequestChangeMobilePhoneNumber] mobile phone same as current");
                throw new ValidationException(Resources.ValidationMessages.MobilePhoneMustBeDifferent);
            }

            if (!IsVerificationPurposeValid(account, VerificationKeyPurpose.ChangeMobile) ||
                CanResendMobileCode(account) ||
                newMobilePhoneNumber != account.VerificationStorage ||
                account.CurrentTwoFactorAuthStatus == (int)TwoFactorAuthMode.Mobile)
            {
                ClearMobileAuthCode(account);

                SetVerificationKey(account, VerificationKeyPurpose.ChangeMobile, state: newMobilePhoneNumber);
                var code = IssueMobileCode(account);

                Tracing.Verbose("[UserAccountService.RequestChangeMobilePhoneNumber] success");

                this.AddEvent(new MobilePhoneChangeRequestedEvent<TAccount> { Account = account, NewMobilePhoneNumber = newMobilePhoneNumber, Code = code });
            }
            else
            {
                Tracing.Verbose("[UserAccountService.RequestChangeMobilePhoneNumber] complete, but not issuing a new code");
            }

            await UpdateAsync(account);
        }

        public virtual async Task<bool> ChangeMobilePhoneFromCodeAsync(Guid accountID, string code)
        {
            Tracing.Information("[UserAccountService.ChangeMobileFromCode] called: {0}", accountID);

            if (String.IsNullOrWhiteSpace(code))
            {
                Tracing.Error("[UserAccountService.ChangeMobileFromCode] failed -- null code");
                throw new ValidationException(Resources.ValidationMessages.CodeRequired);
            }

            var account = await this.GetByIDAsync(accountID);
            if (account == null) throw new ArgumentException("Invalid AccountID");

            Tracing.Information("[UserAccountService.ConfirmMobilePhoneNumberFromCode] called for accountID: {0}", account.ID);

            if (account.VerificationPurpose != (int)VerificationKeyPurpose.ChangeMobile)
            {
                Tracing.Error("[UserAccountService.ConfirmMobilePhoneNumberFromCode] failed -- invalid verification key purpose");
                return false;
            }

            if (!VerifyMobileCode(account, code))
            {
                Tracing.Error("[UserAccountService.ConfirmMobilePhoneNumberFromCode] failed -- mobile code failed to verify");
                return false;
            }

            Tracing.Verbose("[UserAccountService.ConfirmMobilePhoneNumberFromCode] success");

            account.MobilePhoneNumber = account.VerificationStorage;
            account.MobilePhoneNumberChanged = DateTime.Now;

            ClearVerificationKey(account);
            ClearMobileAuthCode(account);

            this.AddEvent(new MobilePhoneChangedEvent<TAccount> { Account = account });

            await UpdateAsync(account);

            return true;
        }

        public virtual async Task<bool> IsPasswordExpiredAsync(Guid accountID)
        {
            var account = await this.GetByIDAsync(accountID);
            if (account == null) throw new ArgumentException("Invalid AccountID");

            return IsPasswordExpired(account);
        }

        public virtual bool IsPasswordExpired(TAccount account)
        {
            if (account == null) throw new ArgumentNullException("account");

            Tracing.Information("[UserAccountService.IsPasswordExpired] called: {0}", account.ID);

            if (account.RequiresPasswordReset)
            {
                Tracing.Verbose("[UserAccountService.IsPasswordExpired] RequiresPasswordReset set, returning true");
                return true;
            }

            if (Configuration.PasswordResetFrequency <= 0)
            {
                Tracing.Verbose("[UserAccountService.PasswordResetFrequency ] PasswordResetFrequency not set, returning false");
                return false;
            }

            if (String.IsNullOrWhiteSpace(account.HashedPassword))
            {
                Tracing.Verbose("[UserAccountService.PasswordResetFrequency ] HashedPassword is null, returning false");
                return false;
            }

            if (account.PasswordChanged == null)
            {
                Tracing.Warning("[UserAccountService.PasswordResetFrequency ] PasswordChanged is null, returning false");
                return false;
            }

            var now = DateTime.Now;
            var last = account.PasswordChanged.Value;
            var result = last.AddDays(Configuration.PasswordResetFrequency) <= now;

            Tracing.Verbose("[UserAccountService.PasswordResetFrequency ] result: {0}", result);

            return result;
        }

        protected virtual string SetVerificationKey(UserAccount account, VerificationKeyPurpose purpose, string key = null, string state = null)
        {
            if (key == null) key = StripUglyBase64(Configuration.Crypto.GenerateSalt());

            account.VerificationKey = this.Configuration.Crypto.Hash(key);
            account.VerificationPurpose = (int)purpose;
            account.VerificationKeySent = DateTime.Now;
            account.VerificationStorage = state;

            return key;
        }

        protected virtual bool IsVerificationKeyValid(UserAccount account, VerificationKeyPurpose purpose, string key)
        {
            if (!IsVerificationPurposeValid(account, purpose))
            {
                return false;
            }

            var hashedKey = Configuration.Crypto.Hash(key);
            var result = Configuration.Crypto.SlowEquals(account.VerificationKey, hashedKey);
            if (!result)
            {
                Tracing.Error("[UserAccountService.IsVerificationKeyValid] failed -- verification key doesn't match");
                return false;
            }

            Tracing.Verbose("[UserAccountService.IsVerificationKeyValid] success -- verification key valid");
            return true;
        }

        protected virtual bool IsVerificationPurposeValid(UserAccount account, VerificationKeyPurpose purpose)
        {
            if (account.VerificationPurpose != (int)purpose)
            {
                Tracing.Error("[UserAccountService.IsVerificationPurposeValid] failed -- verification purpose invalid");
                return false;
            }

            if (IsVerificationKeyStale(account))
            {
                Tracing.Error("[UserAccountService.IsVerificationPurposeValid] failed -- verification key stale");
                return false;
            }

            Tracing.Verbose("[UserAccountService.IsVerificationPurposeValid] success -- verification purpose valid");
            return true;
        }

        protected virtual bool IsVerificationKeyStale(UserAccount account)
        {
            if (account.VerificationKeySent == null)
            {
                return true;
            }

            if (account.VerificationKeySent < DateTime.Now.AddMinutes(-MembershipRebootConstants.UserAccount.VerificationKeyStaleDurationMinutes))
            {
                return true;
            }

            return false;
        }

        protected virtual void ClearVerificationKey(UserAccount account)
        {
            account.VerificationKey = null;
            account.VerificationPurpose = null;
            account.VerificationKeySent = null;
            account.VerificationStorage = null;
        }

        protected virtual void SetPassword(UserAccount account, string password)
        {
            if (account == null) throw new ArgumentNullException("account");

            Tracing.Information("[UserAccountService.SetPassword] called for accountID: {0}", account.ID);

            if (String.IsNullOrWhiteSpace(password))
            {
                Tracing.Error("[UserAccountService.SetPassword] failed -- no password provided");
                throw new ValidationException(Resources.ValidationMessages.InvalidPassword);
            }

            Tracing.Verbose("[UserAccountService.SetPassword] setting new password hash");

            account.HashedPassword = Configuration.Crypto.HashPassword(password, this.Configuration.PasswordHashingIterationCount);
            account.PasswordChanged = DateTime.Now;
            account.RequiresPasswordReset = false;
            account.FailedLoginCount = 0;

            account.MobileCode = "";
            account.MobileCodeSent = null;

            this.AddEvent(new PasswordChangedEvent<UserAccount> { Account = account, NewPassword = password });
        }

        protected virtual void ResetPassword(UserAccount account)
        {
            if (account == null) throw new ArgumentNullException("account");

            Tracing.Information("[UserAccountService.ResetPassword] called for accountID: {0}", account.ID);

            if (String.IsNullOrWhiteSpace(account.Email))
            {
                Tracing.Error("[UserAccountService.ResetPassword] no email to use for password reset");
                throw new ValidationException(Resources.ValidationMessages.PasswordResetErrorNoEmail);
            }

            if (!account.IsAccountVerified)
            {
                // if they've not yet verified then don't allow password reset
                // instead request an initial account verification
                if (account.IsNew())
                {
                    Tracing.Verbose("[UserAccountService.ResetPassword] account not verified -- raising account created email event to resend initial email");
                    var key = SetVerificationKey(account, VerificationKeyPurpose.ChangeEmail, state: account.Email);
                    this.AddEvent(new AccountCreatedEvent<UserAccount> { Account = account, VerificationKey = key });
                }
                else
                {
                    Tracing.Verbose("[UserAccountService.ResetPassword] account not verified -- raising change email event to resend email verification");
                    var key = SetVerificationKey(account, VerificationKeyPurpose.ChangeEmail, state: account.Email);
                    this.AddEvent(new EmailChangeRequestedEvent<UserAccount> { Account = account, NewEmail = account.Email, VerificationKey = key });
                }
            }
            else
            {
                Tracing.Verbose("[UserAccountService.ResetPassword] creating new verification keys");
                var key = SetVerificationKey(account, VerificationKeyPurpose.ResetPassword);

                Tracing.Verbose("[UserAccountService.ResetPassword] account verified -- raising event to send reset notification");
                this.AddEvent(new PasswordResetRequestedEvent<UserAccount> { Account = account, VerificationKey = key });
            }
        }


        protected virtual string IssueMobileCode(UserAccount account)
        {
            if (account == null) throw new ArgumentNullException("account");

            string code = this.Configuration.Crypto.GenerateNumericCode(MembershipRebootConstants.UserAccount.MobileCodeLength);
            account.MobileCode = this.Configuration.Crypto.HashPassword(code, this.Configuration.PasswordHashingIterationCount);
            account.MobileCodeSent = DateTime.Now;

            return code;
        }

        protected virtual bool VerifyMobileCode(TAccount account, string code)
        {
            if (account == null) throw new ArgumentNullException("account");
            if (String.IsNullOrWhiteSpace(code)) return false;

            if (IsMobileCodeExpired(account))
            {
                Tracing.Error("[UserAccountService.VerifyMobileCode] failed -- mobile code stale");
                return false;
            }

            if (HasTooManyRecentPasswordFailures(account))
            {
                Tracing.Error("[UserAccountService.VerifyMobileCode] failed -- TooManyRecentPasswordFailures");
                return false;
            }

            var result = this.Configuration.Crypto.VerifyHashedPassword(account.MobileCode, code);
            if (!result)
            {
                RecordInvalidLoginAttempt(account);
                Tracing.Error("[UserAccountService.VerifyMobileCode] failed -- mobile code invalid");
                return false;
            }

            RecordSuccessfulLogin(account);

            Tracing.Verbose("[UserAccountService.VerifyMobileCode] success -- mobile code valid");
            return true;
        }

        protected virtual void ClearMobileAuthCode(UserAccount account)
        {
            if (account == null) throw new ArgumentNullException("account");

            Tracing.Verbose("[UserAccountService.ClearMobileAuthCode] called for account id {0}", account.ID);

            account.MobileCode = null;
            account.MobileCodeSent = null;
            if (account.CurrentTwoFactorAuthStatus == (int)TwoFactorAuthMode.Mobile)
            {
                account.CurrentTwoFactorAuthStatus = (int)TwoFactorAuthMode.None;
            }
            if (account.VerificationPurpose == (int)VerificationKeyPurpose.ChangeMobile)
            {
                ClearVerificationKey(account);
            }
        }

        protected virtual bool IsMobileCodeOlderThan(UserAccount account, int duration)
        {
            if (account == null) throw new ArgumentNullException("account");

            if (account.MobileCodeSent == null || String.IsNullOrWhiteSpace(account.MobileCode))
            {
                return true;
            }

            if (account.MobileCodeSent < DateTime.Now.AddMinutes(-duration))
            {
                return true;
            }

            return false;
        }

        protected virtual bool IsMobileCodeExpired(UserAccount account)
        {
            return IsMobileCodeOlderThan(account, MembershipRebootConstants.UserAccount.MobileCodeStaleDurationMinutes);
        }

        protected virtual bool CanResendMobileCode(UserAccount account)
        {
            return IsMobileCodeOlderThan(account, MembershipRebootConstants.UserAccount.MobileCodeResendDelayMinutes);
        }

        public virtual async Task ConfigureTwoFactorAuthenticationAsync(Guid accountID, TwoFactorAuthMode mode)
        {
            Tracing.Information("[UserAccountService.ConfigureTwoFactorAuthentication] called: {0}", accountID);

            var account = await this.GetByIDAsync(accountID);
            if (account == null) throw new ArgumentException("Invalid AccountID");

            ConfigureTwoFactorAuthentication(account, mode);
            await UpdateAsync(account);

            Tracing.Verbose("[UserAccountService.ConfigureTwoFactorAuthentication] success");
        }

        protected virtual void ConfigureTwoFactorAuthentication(UserAccount account, TwoFactorAuthMode mode)
        {
            if (account == null) throw new ArgumentNullException("account");

            Tracing.Information("[UserAccountService.ConfigureTwoFactorAuthentication] called for accountID: {0}, mode: {1}", account.ID, mode);

            if (account.AccountTwoFactorAuthMode == (int)mode)
            {
                Tracing.Warning("[UserAccountService.ConfigureTwoFactorAuthentication] nothing to do -- mode is same as current value");
                return;
            }

            if (mode == TwoFactorAuthMode.Mobile &&
                String.IsNullOrWhiteSpace(account.MobilePhoneNumber))
            {
                Tracing.Error("[UserAccountService.ConfigureTwoFactorAuthentication] failed -- mobile requested but no mobile phone for account");
                throw new ValidationException(Resources.ValidationMessages.RegisterMobileForTwoFactor);
            }

            if (mode == TwoFactorAuthMode.Certificate &&
                !account.Certificates.Any())
            {
                Tracing.Error("[UserAccountService.ConfigureTwoFactorAuthentication] failed -- certificate requested but no certificates for account");
                throw new ValidationException(Resources.ValidationMessages.AddClientCertForTwoFactor);
            }

            ClearMobileAuthCode(account);

            account.AccountTwoFactorAuthMode = (int)mode;
            account.CurrentTwoFactorAuthStatus = (int)TwoFactorAuthMode.None;

            if (mode == TwoFactorAuthMode.None)
            {
                RemoveTwoFactorAuthTokens(account);

                Tracing.Verbose("[UserAccountService.ConfigureTwoFactorAuthentication] success -- two factor auth disabled");
                this.AddEvent(new TwoFactorAuthenticationDisabledEvent<UserAccount> { Account = account });
            }
            else
            {
                Tracing.Verbose("[UserAccountService.ConfigureTwoFactorAuthentication] success -- two factor auth enabled, mode: {0}", mode);
                this.AddEvent(new TwoFactorAuthenticationEnabledEvent<UserAccount> { Account = account, Mode = mode });
            }
        }

        protected virtual bool RequestTwoFactorAuthCertificate(UserAccount account)
        {
            if (account == null) throw new ArgumentNullException("account");

            Tracing.Information("[UserAccountService.RequestTwoFactorAuthCertificate] called for accountID: {0}", account.ID);

            if (account.IsAccountClosed)
            {
                Tracing.Error("[UserAccountService.RequestTwoFactorAuthCertificate] failed -- account closed");
                return false;
            }

            if (!account.IsLoginAllowed)
            {
                Tracing.Error("[UserAccountService.RequestTwoFactorAuthCertificate] failed -- login not allowed");
                return false;
            }

            if (account.AccountTwoFactorAuthMode != (int)TwoFactorAuthMode.Certificate)
            {
                Tracing.Error("[UserAccountService.RequestTwoFactorAuthCertificate] failed -- current auth mode is not certificate");
                return false;
            }

            if (!account.Certificates.Any())
            {
                Tracing.Error("[UserAccountService.RequestTwoFactorAuthCertificate] failed -- no certificates");
                return false;
            }

            Tracing.Verbose("[UserAccountService.RequestTwoFactorAuthCertificate] success");

            account.CurrentTwoFactorAuthStatus = (int)TwoFactorAuthMode.Certificate;

            return true;
        }

        protected virtual bool RequestTwoFactorAuthCode(UserAccount account, bool force = false)
        {
            if (account == null) throw new ArgumentNullException("account");

            Tracing.Information("[UserAccountService.RequestTwoFactorAuthCode] called for accountID: {0}", account.ID);

            if (account.IsAccountClosed)
            {
                Tracing.Error("[UserAccountService.RequestTwoFactorAuthCode] failed -- account closed");
                return false;
            }

            if (!account.IsLoginAllowed)
            {
                Tracing.Error("[UserAccountService.RequestTwoFactorAuthCode] failed -- login not allowed");
                return false;
            }

            if (account.AccountTwoFactorAuthMode != (int)TwoFactorAuthMode.Mobile)
            {
                Tracing.Error("[UserAccountService.RequestTwoFactorAuthCode] failed -- AccountTwoFactorAuthMode not mobile");
                return false;
            }

            if (String.IsNullOrWhiteSpace(account.MobilePhoneNumber))
            {
                Tracing.Error("[UserAccountService.RequestTwoFactorAuthCode] failed -- empty MobilePhoneNumber");
                return false;
            }

            if (CanResendMobileCode(account) ||
                account.CurrentTwoFactorAuthStatus != (int)TwoFactorAuthMode.Mobile)
            {
                ClearMobileAuthCode(account);

                Tracing.Verbose("[UserAccountService.RequestTwoFactorAuthCode] new mobile code issued");
                var code = IssueMobileCode(account);
                account.CurrentTwoFactorAuthStatus = (int)TwoFactorAuthMode.Mobile;

                Tracing.Verbose("[UserAccountService.RequestTwoFactorAuthCode] success");

                this.AddEvent(new TwoFactorAuthenticationCodeNotificationEvent<UserAccount> { Account = account, Code = code });
            }
            else
            {
                Tracing.Verbose("[UserAccountService.RequestTwoFactorAuthCode] success, but not issing a new code");
            }

            return true;
        }

        public virtual async Task SendTwoFactorAuthenticationCodeAsync(Guid accountID)
        {
            Tracing.Information("[UserAccountService.SendTwoFactorAuthenticationCode] called: {0}", accountID);

            var account = await this.GetByIDAsync(accountID);
            if (account == null) throw new ArgumentException("Invalid AccountID");

            RequestTwoFactorAuthCode(account, true);
            await UpdateAsync(account);
        }

        protected virtual void CloseAccount(TAccount account)
        {
            if (account == null) throw new ArgumentNullException("account");

            Tracing.Information("[UserAccountService.CloseAccount] called for accountID: {0}", account.ID);

            ClearVerificationKey(account);
            ClearMobileAuthCode(account);
            ConfigureTwoFactorAuthentication(account, TwoFactorAuthMode.None);

            account.IsLoginAllowed = false;

            if (!account.IsAccountClosed)
            {
                Tracing.Verbose("[UserAccountService.CloseAccount] success");

                account.IsAccountClosed = true;
                account.AccountClosed = DateTime.Now;

                this.AddEvent(new AccountClosedEvent<TAccount> { Account = account });
            }
            else
            {
                Tracing.Warning("[UserAccountService.CloseAccount] account already closed");
            }
        }

        public virtual async Task AddClaimAsync(Guid accountID, string type, string value)
        {
            Tracing.Information("[UserAccountService.AddClaim] called for accountID: {0}", accountID);

            var account = await this.GetByIDAsync(accountID);
            if (account == null) throw new ArgumentException("Invalid AccountID");

            if (String.IsNullOrWhiteSpace(type))
            {
                Tracing.Error("[UserAccountService.AddClaim] failed -- null type");
                throw new ArgumentException("type");
            }

            if (String.IsNullOrWhiteSpace(value))
            {
                Tracing.Error("[UserAccountService.AddClaim] failed -- null value");
                throw new ArgumentException("value");
            }

            if (!account.HasClaim(type, value))
            {
                var claim = new UserClaim();
                claim.Type = type;
                claim.Value = value;
                account.Claims.Add(claim);
                this.AddEvent(new ClaimAddedEvent<TAccount> { Account = account, Claim = claim });

                Tracing.Verbose("[UserAccountService.AddClaim] claim added");
            }

            await UpdateAsync(account);
        }

        public virtual async Task RemoveClaimAsync(Guid accountID, string type)
        {
            Tracing.Information("[UserAccountService.RemoveClaim] called for accountID: {0}", accountID);

            var account = await this.GetByIDAsync(accountID);
            if (account == null) throw new ArgumentException("Invalid AccountID");

            if (String.IsNullOrWhiteSpace(type))
            {
                Tracing.Error("[UserAccountService.RemoveClaim] failed -- null type");
                throw new ArgumentException("type");
            }

            var claimsToRemove =
                from claim in account.Claims
                where claim.Type == type
                select claim;
            foreach (var claim in claimsToRemove.ToArray())
            {
                account.Claims.Remove(claim);
                this.AddEvent(new ClaimRemovedEvent<TAccount> { Account = account, Claim = claim });
                Tracing.Verbose("[UserAccountService.RemoveClaim] claim removed");
            }

            await UpdateAsync(account);
        }

        public virtual async Task RemoveClaimAsync(Guid accountID, string type, string value)
        {
            Tracing.Information("[UserAccountService.RemoveClaim] called for accountID: {0}", accountID);

            var account = await this.GetByIDAsync(accountID);
            if (account == null) throw new ArgumentException("Invalid AccountID");

            if (String.IsNullOrWhiteSpace(type))
            {
                Tracing.Error("[UserAccountService.RemoveClaim] failed -- null type");
                throw new ArgumentException("type");
            }
            if (String.IsNullOrWhiteSpace(value))
            {
                Tracing.Error("[UserAccountService.RemoveClaim] failed -- null value");
                throw new ArgumentException("value");
            }

            var claimsToRemove =
                from claim in account.Claims
                where claim.Type == type && claim.Value == value
                select claim;
            foreach (var claim in claimsToRemove.ToArray())
            {
                account.Claims.Remove(claim);
                this.AddEvent(new ClaimRemovedEvent<TAccount> { Account = account, Claim = claim });
                Tracing.Verbose("[UserAccountService.RemoveClaim] claim removed");
            }

            await UpdateAsync(account);
        }

        protected virtual LinkedAccount GetLinkedAccount(TAccount account, string provider, string id)
        {
            if (account == null) throw new ArgumentNullException("account");

            Tracing.Information("[UserAccountService.GetLinkedAccount] called for account ID: {0}", account.ID);

            return account.LinkedAccounts.Where(x => x.ProviderName == provider && x.ProviderAccountID == id).SingleOrDefault();
        }

        public virtual async Task AddOrUpdateLinkedAccountAsync(TAccount account, string provider, string id, IEnumerable<Claim> claims = null)
        {
            if (account == null) throw new ArgumentNullException("account");

            Tracing.Information("[UserAccountService.AddOrUpdateLinkedAccount] called for accountID: {0}", account.ID);

            if (String.IsNullOrWhiteSpace(provider))
            {
                Tracing.Error("[UserAccountService.AddOrUpdateLinkedAccount] failed -- null provider");
                throw new ArgumentNullException("provider");
            }
            if (String.IsNullOrWhiteSpace(id))
            {
                Tracing.Error("[UserAccountService.AddOrUpdateLinkedAccount] failed -- null id");
                throw new ArgumentNullException("id");
            }

            var linked = GetLinkedAccount(account, provider, id);
            if (linked == null)
            {
                linked = NewLinkedAccount();
                if (linked.Claims == null) linked.Claims = new HashSet<LinkedAccountClaim>();
                linked.ProviderName = provider;
                linked.ProviderAccountID = id;
                account.LinkedAccounts.Add(linked);
                this.AddEvent(new LinkedAccountAddedEvent<TAccount> { Account = account, LinkedAccount = linked });

                Tracing.Verbose("[UserAccountService.AddOrUpdateLinkedAccount] linked account added");
            }

            linked.LastLogin = DateTime.Now;

            claims = claims ?? Enumerable.Empty<Claim>();

            linked.Claims.Clear();

            foreach (var c in claims)
            {
                var claim = NewLinkedAccountClaim();
                claim.Type = c.Type;
                claim.Value = c.Value;
                linked.Claims.Add(claim);
            }

            await UpdateAsync(account);
        }

        public virtual async Task RemoveLinkedAccountAsync(Guid accountID, string provider)
        {
            Tracing.Information("[UserAccountService.RemoveLinkedAccount] called for account ID: {0}", accountID);

            var account = await this.GetByIDAsync(accountID);
            if (account == null) throw new ArgumentException("Invalid AccountID");

            var linked = account.LinkedAccounts.Where(x => x.ProviderName == provider);
            foreach (var item in linked)
            {
                account.LinkedAccounts.Remove(item);
                this.AddEvent(new LinkedAccountRemovedEvent<TAccount> { Account = account, LinkedAccount = item });
                Tracing.Verbose("[UserAccountService.RemoveLinkedAccount] linked account removed");
            }

            await UpdateAsync(account);
        }

        public virtual async Task RemoveLinkedAccountAsync(Guid accountID, string provider, string id)
        {
            Tracing.Information("[UserAccountService.RemoveLinkedAccount] called for account ID: {0}", accountID);

            var account = await this.GetByIDAsync(accountID);
            if (account == null) throw new ArgumentException("Invalid AccountID");

            var linked = GetLinkedAccount(account, provider, id);
            if (linked != null)
            {
                account.LinkedAccounts.Remove(linked);
                this.AddEvent(new LinkedAccountRemovedEvent<TAccount> { Account = account, LinkedAccount = linked });
                Tracing.Verbose("[UserAccountService.RemoveLinkedAccount] linked account removed");
            }

            await UpdateAsync(account);
        }

        public virtual async Task AddCertificateAsync(Guid accountID, X509Certificate2 certificate)
        {
            Tracing.Information("[UserAccountService.AddCertificate] called for account ID: {0}", accountID);

            var account = await this.GetByIDAsync(accountID);
            if (account == null) throw new ArgumentException("Invalid AccountID");

            if (!certificate.Validate())
            {
                Tracing.Error("[UserAccountService.AddCertificate] failed -- cert failed to validate");
                throw new ValidationException(Resources.ValidationMessages.InvalidCertificate);
            }

            await RemoveCertificateAsync(account, certificate);
            await AddCertificateAsync(account, certificate.Thumbprint, certificate.Subject);

            await UpdateAsync(account);
        }

        public virtual async Task AddCertificateAsync(Guid accountID, string thumbprint, string subject)
        {
            Tracing.Information("[UserAccountService.AddCertificate] called for account ID: {0}", accountID);

            var account = await this.GetByIDAsync(accountID);
            if (account == null) throw new ArgumentException("Invalid AccountID");

            await AddCertificateAsync(account, thumbprint, subject);
            await UpdateAsync(account);
        }

        protected virtual async Task AddCertificateAsync(TAccount account, string thumbprint, string subject)
        {
            Tracing.Information("[UserAccountService.AddCertificate] called for accountID: {0}", account.ID);

            if (String.IsNullOrWhiteSpace(thumbprint))
            {
                Tracing.Error("[UserAccountService.AddCertificate] failed -- null thumbprint");
                throw new ArgumentNullException("thumbprint");
            }
            if (String.IsNullOrWhiteSpace(subject))
            {
                Tracing.Error("[UserAccountService.AddCertificate] failed -- null subject");
                throw new ArgumentNullException("subject");
            }

            var cert = NewUserCertificate();
            cert.Thumbprint = thumbprint;
            cert.Subject = subject;
            account.Certificates.Add(cert);

            this.AddEvent(new CertificateAddedEvent<TAccount> { Account = account, Certificate = cert });
        }

        public virtual async Task RemoveCertificateAsync(Guid accountID, X509Certificate2 certificate)
        {
            Tracing.Information("[UserAccountService.RemoveCertificate] called for account ID: {0}", accountID);

            var account = await this.GetByIDAsync(accountID);
            if (account == null) throw new ArgumentException("Invalid AccountID");

            await RemoveCertificateAsync(account, certificate);
            await UpdateAsync(account);
        }
        protected virtual async Task RemoveCertificateAsync(TAccount account, X509Certificate2 certificate)
        {
            if (account == null) throw new ArgumentNullException("account");

            Tracing.Information("[UserAccountService.RemoveCertificate] called for accountID: {0}", account.ID);

            if (certificate == null)
            {
                Tracing.Error("[UserAccountService.RemoveCertificate] failed -- null certificate");
                throw new ArgumentNullException("certificate");
            }
            if (certificate.Handle == IntPtr.Zero)
            {
                Tracing.Error("[UserAccountService.RemoveCertificate] failed -- invalid certificate handle");
                throw new ArgumentException("Invalid certificate");
            }

            await RemoveCertificateAsync(account, certificate.Thumbprint);
        }

        public virtual async Task RemoveCertificateAsync(Guid accountID, string thumbprint)
        {
            Tracing.Information("[UserAccountService.RemoveCertificate] called for account ID: {0}", accountID);

            var account = await this.GetByIDAsync(accountID);
            if (account == null) throw new ArgumentException("Invalid AccountID");

            await RemoveCertificateAsync(account, thumbprint);
            await UpdateAsync(account);
        }
        protected virtual async Task RemoveCertificateAsync(TAccount account, string thumbprint)
        {
            if (account == null) throw new ArgumentNullException("account");

            Tracing.Information("[UserAccountService.RemoveCertificate] called for accountID: {0}", account.ID);

            if (String.IsNullOrWhiteSpace(thumbprint))
            {
                Tracing.Error("[UserAccountService.RemoveCertificate] failed -- no thumbprint");
                throw new ArgumentNullException("thumbprint");
            }

            var certs = account.Certificates.Where(x => x.Thumbprint.Equals(thumbprint, StringComparison.OrdinalIgnoreCase)).ToArray();
            foreach (var cert in certs)
            {
                this.AddEvent(new CertificateRemovedEvent<TAccount> { Account = account, Certificate = cert });
                account.Certificates.Remove(cert);
            }
            Tracing.Error("[UserAccountService.RemoveCertificate] certs removed: {0}", certs.Length);

            if (!account.Certificates.Any() &&
                account.AccountTwoFactorAuthMode == (int)TwoFactorAuthMode.Certificate)
            {
                Tracing.Verbose("[UserAccountService.RemoveCertificate] last cert removed, disabling two factor auth");
                ConfigureTwoFactorAuthentication(account, TwoFactorAuthMode.None);
            }
        }

        protected virtual void CreateTwoFactorAuthToken(TAccount account)
        {
            if (account == null) throw new ArgumentNullException("account");

            Tracing.Information("[UserAccountService.CreateTwoFactorAuthToken] called for accountID: {0}", account.ID);

            if (account.AccountTwoFactorAuthMode != (int)TwoFactorAuthMode.Mobile)
            {
                Tracing.Error("[UserAccountService.CreateTwoFactorAuthToken] AccountTwoFactorAuthMode is not mobile");
                throw new Exception("AccountTwoFactorAuthMode is not Mobile");
            }

            var value = this.Configuration.Crypto.GenerateSalt();

            var item = NewTwoFactorAuthToken();
            item.Token = this.Configuration.Crypto.Hash(value);
            item.Issued = DateTime.Now;
            account.TwoFactorAuthTokens.Add(item);

            this.AddEvent(new TwoFactorAuthenticationTokenCreatedEvent<TAccount> { Account = account, Token = value });
        }

        protected virtual bool VerifyTwoFactorAuthToken(UserAccount account, string token)
        {
            if (account == null) throw new ArgumentNullException("account");

            Tracing.Information("[UserAccountService.VerifyTwoFactorAuthToken] called for accountID: {0}", account.ID);

            if (account.AccountTwoFactorAuthMode != (int)TwoFactorAuthMode.Mobile)
            {
                Tracing.Error("[UserAccountService.VerifyTwoFactorAuthToken] AccountTwoFactorAuthMode is not mobile");
                return false;
            }

            if (String.IsNullOrWhiteSpace(token))
            {
                Tracing.Error("[UserAccountService.VerifyTwoFactorAuthToken] failed -- no token");
                return false;
            }

            token = this.Configuration.Crypto.Hash(token);

            var expiration = DateTime.Now.AddDays(-MembershipRebootConstants.UserAccount.TwoFactorAuthTokenDurationDays);
            var removequery =
                from t in account.TwoFactorAuthTokens
                where
                    t.Issued < account.PasswordChanged ||
                    t.Issued < account.MobilePhoneNumberChanged ||
                    t.Issued < expiration
                select t;
            var itemsToRemove = removequery.ToArray();

            Tracing.Verbose("[UserAccountService.VerifyTwoFactorAuthToken] number of stale tokens being removed: {0}", itemsToRemove.Length);

            foreach (var item in itemsToRemove)
            {
                account.TwoFactorAuthTokens.Remove(item);
            }

            var matchquery =
                from t in account.TwoFactorAuthTokens.ToArray()
                where Configuration.Crypto.SlowEquals(t.Token, token)
                select t;

            var result = matchquery.Any();

            Tracing.Verbose("[UserAccountService.VerifyTwoFactorAuthToken] result was token verified: {0}", result);

            return result;
        }

        protected virtual void RemoveTwoFactorAuthTokens(UserAccount account)
        {
            if (account == null) throw new ArgumentNullException("account");

            Tracing.Information("[UserAccountService.RemoveTwoFactorAuthTokens] called for accountID: {0}", account.ID);

            var tokens = account.TwoFactorAuthTokens.ToArray();
            foreach (var item in tokens)
            {
                account.TwoFactorAuthTokens.Remove(item);
            }

            Tracing.Verbose("[UserAccountService.RemoveTwoFactorAuthTokens] tokens removed: {0}", tokens.Length);
        }

        static readonly string[] UglyBase64 = { "+", "/", "=" };
        protected virtual string StripUglyBase64(string s)
        {
            if (s == null) return s;
            foreach (var ugly in UglyBase64)
            {
                s = s.Replace(ugly, "");
            }
            return s;
        }

        protected virtual LinkedAccount NewLinkedAccount()
        {
            return new LinkedAccount();
        }
        protected virtual LinkedAccountClaim NewLinkedAccountClaim()
        {
            return new LinkedAccountClaim();
        }
        protected virtual PasswordResetSecret NewPasswordResetSecret()
        {
            return new PasswordResetSecret();
        }
        protected virtual TwoFactorAuthToken NewTwoFactorAuthToken()
        {
            return new TwoFactorAuthToken();
        }
        protected virtual UserCertificate NewUserCertificate()
        {
            return new UserCertificate();
        }
    }

    public class UserAccountService : UserAccountService<UserAccount>
    {
        public UserAccountService()
        {
        }
    }
}
