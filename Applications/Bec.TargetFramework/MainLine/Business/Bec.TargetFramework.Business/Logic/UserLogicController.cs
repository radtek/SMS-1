﻿using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Entities.Injections;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.SB.Client.Interfaces;
using Bec.TargetFramework.Security;
using BrockAllen.MembershipReboot;
using EnsureThat;
using Mehdime.Entity;
using Omu.ValueInjecter;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Logic
{
    [Trace(TraceExceptionsOnly = true)]
    public class UserLogicController : LogicBase, BrockAllen.MembershipReboot.AccountService.IPartialUserLogicController
    {
        public UserAccountService UaService { get; set; }
        public AuthenticationService AuthSvc { get; set; }
        public IEventPublishLogicClient EventPublishClient { get; set; }
        public OrganisationLogicController OrganisationLogic { get; set; }

        public UserLoginValidation AuthenticateUser(string username, string password)
        {
            BrockAllen.MembershipReboot.UserAccount account = this.GetBAUserAccountByUsername(username);

            var decodedPassword = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(password));

            UserLoginValidation result = UaService.AuthenticateWithUsername(account, username, decodedPassword);

            result.UserAccount = account;

            return result;
        }

        public async Task<ContactDTO> AddUserAsync(ContactDTO dto)
        {
            Ensure.That(dto).IsNotNull();
            var userContact = new Contact();
            var userDetail = new UserAccountDetail();

            using (var scope = DbContextScopeFactory.Create())
            {
                var userAccount = await UaService.CreateAccountAsync(dto.ContactName, RandomPasswordGenerator.Generate(10), dto.EmailAddress1, Guid.NewGuid());

                //user contact
                userContact.InjectFrom<NullableInjection>(dto);
                userContact.ContactID = Guid.NewGuid();
                userContact.ParentID = userAccount.ID;
                //SetAuditFields<Contact>(userContact, true);
                scope.DbContexts.Get<TargetFrameworkEntities>().Contacts.Add(userContact);


                //create user account detail
                userDetail.InjectFrom<NullableInjection>(dto);
                userDetail.UserID = userAccount.ID;
                userDetail.UserDetailID = Guid.NewGuid();
                userDetail.Salutation = dto.Salutation;
                //SetAuditFields<UserAccountDetail>(userDetail, true);
                scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountDetails.Add(userDetail);

                await scope.SaveChangesAsync();

                return userContact.ToDto();
            }
        }

        /// <summary>
        /// Reset for Temporary Accounts
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="newPassword"></param>
        public async Task ResetUserPassword(Guid userID, string newPassword, bool registering, string pin)
        {
            var userAccount = UaService.GetByID(userID);

            if (userAccount != null && (registering || (!string.IsNullOrEmpty(userAccount.MobileCode) && userAccount.MobileCode == pin && ValidPINExists(userAccount.MobileCodeSent))))
            {
                if (userAccount.IsTemporaryAccount)
                    await UaService.SetPasswordAndClearVerificationKeyAsync(userID, newPassword);
                else
                    await UaService.SetPasswordAsync(userID, newPassword);
            }
            else
                throw new Exception("An error has occured");
        }

        /// <summary>
        /// Applies only to Temporary Accounts at the moment
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool HasPasswordExpired(Guid userID)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().UserAccounts.Any(s =>
                    s.ID == userID &&
                    !string.IsNullOrEmpty(s.VerificationKey) &&
                    (!s.LastLogin.HasValue || (s.LastLogin.HasValue && s.PasswordChanged > s.LastLogin.Value)));
            }
        }

        public async Task LockOrUnlockUserAsync(Guid userId, bool lockUser)
        {
            Ensure.That(userId).IsNot(Guid.Empty);
            var user = new Bec.TargetFramework.Data.UserAccount();

            using (var scope = DbContextScopeFactory.Create())
            {
                user = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccounts.Single(x => x.ID == userId);

                if (lockUser)
                {
                    user.IsLoginAllowed = false;
                    user.FailedLoginCount = UaService.Configuration.AccountLockoutFailedLoginAttempts;
                }
                else
                {
                    user.IsLoginAllowed = true;
                    user.FailedLoginCount = 0;
                }

                await scope.SaveChangesAsync();
            }
        }

        [EnsureArgumentAspect]
        public bool IsUserExist(string userName)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().UserAccounts.Where(x => x.Username.ToLower() == userName.ToLower()).Count() > 0;
            }
        }

        [EnsureArgumentAspect]
        public bool IsEmailExist(string email)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().UserAccounts.Where(u => u.Email.ToLower() == email.ToLower() && !u.IsAccountClosed && u.IsActive).Count() > 0;
            }
        }

        public bool IsUserAccountRegistered(Guid uaoId)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations.Where(u => u.UserAccountOrganisationID == uaoId && !u.UserAccount.IsTemporaryAccount).Count() > 0;
            }
        }

        public IEnumerable<AddressDTO> GetUserAddresses(Guid contactID)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().Addresses.Where(item => item.ParentID == contactID && item.IsActive && !item.IsDeleted).OrderBy(item => item.Name).ToDtos();
            }
        }

        public List<BrockAllen.MembershipReboot.UserAccount> GetAllUserAccount()
        {
            var dtoList = new List<BrockAllen.MembershipReboot.UserAccount>();

            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                scope.DbContexts.Get<TargetFrameworkEntities>().UserAccounts.ToList().ForEach(item =>
                    {
                        BrockAllen.MembershipReboot.UserAccount ua = new BrockAllen.MembershipReboot.UserAccount();
                        ua.InjectFrom<NullableInjection>(item);
                        ua.PasswordResetSecrets = GetPasswordResetSecrets(item.ID);
                        dtoList.Add(ua);
                    });
            }
            return dtoList;
        }

        public BrockAllen.MembershipReboot.UserAccount GetUserAccount(Guid key)
        {
            BrockAllen.MembershipReboot.UserAccount ua = null;
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                ua = new BrockAllen.MembershipReboot.UserAccount();
                var uaDb = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccounts.Single(s => s.ID == key);
                ua.InjectFrom<NullableInjection>(uaDb);
                ua.PasswordResetSecrets = GetPasswordResetSecrets(key);
            }

            return ua;
        }

        public BrockAllen.MembershipReboot.UserAccount GetBAUserAccountByEmail(string email)
        {
            BrockAllen.MembershipReboot.UserAccount ua = null;
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var uaDb = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccounts.Where(s => s.Email == email && s.IsActive && !s.IsDeleted).ToList();

                if (uaDb.Count > 0)
                {
                    ua = new BrockAllen.MembershipReboot.UserAccount();
                    ua.InjectFrom<NullableInjection>(uaDb.First());
                    ua.PasswordResetSecrets = GetPasswordResetSecrets(uaDb.First().ID);
                }
            }

            return ua;
        }

        public BrockAllen.MembershipReboot.UserAccount GetBAUserAccountByEmailAndNotID(string email, Guid id)
        {
            BrockAllen.MembershipReboot.UserAccount ua = null;
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var uaDb = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccounts.Where(s => s.Email == email && s.ID != id).ToList();

                if (uaDb.Count > 0)
                {
                    ua = new BrockAllen.MembershipReboot.UserAccount();
                    ua.InjectFrom<NullableInjection>(uaDb.First());
                    ua.PasswordResetSecrets = GetPasswordResetSecrets(uaDb.First().ID);
                }
            }
            return ua;
        }

        public BrockAllen.MembershipReboot.UserAccount GetBAUserAccountByUsername(string username)
        {
            BrockAllen.MembershipReboot.UserAccount ua = null;
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var uaDb = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccounts.SingleOrDefault(s => s.Username == username);

                if (uaDb != null)
                {
                    ua = new BrockAllen.MembershipReboot.UserAccount();
                    ua.InjectFrom<NullableInjection>(uaDb);
                    ua.PasswordResetSecrets = GetPasswordResetSecrets(uaDb.ID);
                    ua.FullName = ua.Username;

                    var uao = uaDb.UserAccountOrganisations.FirstOrDefault();
                    if (uao != null)
                    {
                        var c = scope.DbContexts.Get<TargetFrameworkEntities>().Contacts.FirstOrDefault(x => x.ParentID == uao.UserAccountOrganisationID);
                        if (c != null) ua.FullName = c.FirstName + " " + c.LastName;
                    }

                }
            }
            return ua;
        }

        public List<UserAccountDTO> GetUserAccountByEmail(string email, bool permanentAccountonly)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                if (permanentAccountonly)
                    return scope.DbContexts.Get<TargetFrameworkEntities>().UserAccounts.Where(s => s.Email == email && s.IsActive && !s.IsDeleted && s.IsTemporaryAccount == !permanentAccountonly).ToDtos();
                else
                    return scope.DbContexts.Get<TargetFrameworkEntities>().UserAccounts.Where(s => s.Email == email && s.IsActive && !s.IsDeleted).ToDtos();
            }
        }
        public UserAccountDTO GetUserAccountByUsername(string userName)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().UserAccounts.SingleOrDefault(s => s.Username == userName).ToDto();
            }
        }

        public List<ContactDTO> GetUserContacts(Guid userId)
        {
            List<ContactDTO> ua = new List<ContactDTO>(); ;
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                ua = ContactConverter.ToDtos(scope.DbContexts.Get<TargetFrameworkEntities>().Contacts.Where(s => s.ParentID == userId));

            }
            return ua;
        }

        public List<BrockAllen.MembershipReboot.UserAccount> GetUserAccounts(Guid key)
        {
            BrockAllen.MembershipReboot.UserAccount ua = null;
            List<BrockAllen.MembershipReboot.UserAccount> accounts = new List<BrockAllen.MembershipReboot.UserAccount>();
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var uaDb = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccounts.Where(s => s.ID == key).ToList();
                uaDb.ForEach(item =>
                {
                    ua = new BrockAllen.MembershipReboot.UserAccount();
                    ua.InjectFrom<NullableInjection>(item);
                    accounts.Add(ua);
                });
            }

            return accounts;

        }

        public List<UserAccountOrganisationDTO> GetUserAccountOrganisation(Guid accountID)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations.Where(item => item.UserID == accountID && item.IsActive && !item.IsDeleted).ToDtosWithRelated(1);
            }
        }

        private List<BrockAllen.MembershipReboot.PasswordResetSecret> GetPasswordResetSecrets(Guid userAccountID)
        {
            List<BrockAllen.MembershipReboot.PasswordResetSecret> dtoList = new List<BrockAllen.MembershipReboot.PasswordResetSecret>();
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                scope.DbContexts.Get<TargetFrameworkEntities>().PasswordResetSecrets.Where(s =>
                    s.UserAccountID == userAccountID &&
                    s.IsActive &&
                    !s.IsDeleted)
                    .ToList().ForEach(item =>
                    {
                        BrockAllen.MembershipReboot.PasswordResetSecret rs = new BrockAllen.MembershipReboot.PasswordResetSecret();

                        rs.InjectFrom<NullableInjection>(item);
                        //Get the question description as we will be only storing classificationtypeid in the passwordresetsecret
                        rs.Question = scope.DbContexts.Get<TargetFrameworkEntities>().ClassificationTypes.Single(x => x.ClassificationTypeID == item.QuestionID).Name;

                        dtoList.Add(rs);
                    });
            }
            return dtoList;
        }

        public BrockAllen.MembershipReboot.UserAccount CreateUserAccount()
        {
            return new BrockAllen.MembershipReboot.UserAccount();
        }

        public async Task AddUserAccountAsync(BrockAllen.MembershipReboot.UserAccount user)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                Data.UserAccount ua = new Data.UserAccount();

                ua.InjectFrom<NullableInjection>(user);

                scope.DbContexts.Get<TargetFrameworkEntities>().UserAccounts.Add(ua);

                foreach (var it in user.PasswordResetSecrets)
                {
                    var secret = new Bec.TargetFramework.Data.PasswordResetSecret();

                    secret.InjectFrom(it);
                    secret.UserAccountID = user.ID;
                    scope.DbContexts.Get<TargetFrameworkEntities>().PasswordResetSecrets.Add(secret);
                }

                await scope.SaveChangesAsync();
            }
        }

        public async Task RemoveUserAccountAsync(BrockAllen.MembershipReboot.UserAccount user)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var uaDb = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccounts.Single(s => s.ID == user.ID);
                scope.DbContexts.Get<TargetFrameworkEntities>().UserAccounts.Remove(uaDb);
                await scope.SaveChangesAsync();
            }
        }

        public async Task UpdateUserAccountAsync(BrockAllen.MembershipReboot.UserAccount user)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var uaDb = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccounts.Single(s => s.ID.Equals(user.ID));

                uaDb.InjectFrom<NullableInjection>(new IgnoreProps("ID"), user);

                var entry = scope.DbContexts.Get<TargetFrameworkEntities>().Entry(uaDb);

                entry.State = System.Data.Entity.EntityState.Modified;

                foreach (var it in user.PasswordResetSecrets)
                {
                    var secret = scope.DbContexts.Get<TargetFrameworkEntities>().PasswordResetSecrets.SingleOrDefault(s => s.PasswordResetSecretID.Equals(it.PasswordResetSecretID));
                    if (secret != null)
                    {
                        secret.InjectFrom(it);
                        secret.UserAccountID = user.ID;
                    }
                    else
                    {
                        secret = new Bec.TargetFramework.Data.PasswordResetSecret();
                        secret.InjectFrom(it);
                        secret.UserAccountID = user.ID;
                        scope.DbContexts.Get<TargetFrameworkEntities>().PasswordResetSecrets.Add(secret);
                    }
                }

                await scope.SaveChangesAsync();
            }
        }

        public List<UserClaimDTO> GetUserClaims(Guid userId, Guid organisationID)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var result = scope.DbContexts.Get<TargetFrameworkEntities>().FnGetUserClaim(userId, organisationID);

                if (result != null)
                {
                    return result.Select(x => new UserClaimDTO
                    {
                        UserAccountID = userId,
                        Type = x.ClaimType,
                        Value = x.ClaimName
                    }).ToList();
                }
            }

            return new List<UserClaimDTO>();
        }

        public ContactDTO GetUserAccountOrganisationPrimaryContact(Guid uaoID)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var contact = scope.DbContexts.Get<TargetFrameworkEntities>().Contacts.Where(item => item.IsPrimaryContact && item.ParentID == uaoID && item.IsActive && !item.IsDeleted).FirstOrDefault();

                Ensure.That(contact).IsNotNull();
                return contact.ToDto();
            }
        }

        public VUserAccountOrganisationUserTypeOrganisationTypeDTO GetUserAccountOrganisationUserTypeOrganisationType(Guid accountID, bool personalOrg)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var uaoUTypeOType = new VUserAccountOrganisationUserTypeOrganisationType();
                int orgType = (int)OrganisationTypeEnum.Personal;
                if (personalOrg)
                    uaoUTypeOType = scope.DbContexts.Get<TargetFrameworkEntities>().VUserAccountOrganisationUserTypeOrganisationTypes.SingleOrDefault(item => item.UserID == accountID && item.OrganisationTypeID == orgType);
                else
                    uaoUTypeOType = scope.DbContexts.Get<TargetFrameworkEntities>().VUserAccountOrganisationUserTypeOrganisationTypes.SingleOrDefault(item => item.UserID == accountID && item.OrganisationTypeID != orgType);
                return uaoUTypeOType.ToDto();
            }
        }

        public List<VUserAccountOrganisationUserTypeOrganisationTypeDTO> GetUserAccountOrganisationWithUserTypeAndOrgType(Guid accountID)
        {
            VUserAccountOrganisationUserTypeOrganisationTypeDTO uaoUserTypeOrganisationType = new VUserAccountOrganisationUserTypeOrganisationTypeDTO();
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().VUserAccountOrganisationUserTypeOrganisationTypes.Where(s => s.UserID == accountID).ToDtos();
            }
        }

        public List<string> UserLoginSessions(Guid userId)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountLoginSessions.Where(item => !(item.UserHasLoggedOut ?? false) && item.UserAccountID == userId)
                   .Select(item => item.UserSessionID)
                   .ToList();
            }
        }

        public async Task LogEveryoneElseOutAsync(Guid userId, string sessionId)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                foreach (var item in scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountLoginSessions.Where(item =>
                    item.UserHasLoggedOut.Value != true &&
                    item.UserAccountID == userId &&
                    item.UserSessionID != sessionId))
                {
                    item.UserHasLoggedOut = true;
                }

                await scope.SaveChangesAsync();
            }
        }

        public async Task SaveUserAccountLoginSessionAsync(Guid userId, string sessionId, string userHostAddress, string userIdAddress, string userLocation)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var session = new UserAccountLoginSession
                 {
                     UserSessionID = sessionId,
                     UserIPAddress = userIdAddress,
                     UserLocation = userLocation,
                     UserLoginDate = DateTime.Now,
                     UserAccountID = userId,
                     UserHasLoggedOut = false,
                     UserHostAddress = userHostAddress
                 };

                scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountLoginSessions.Add(session);

                await scope.SaveChangesAsync();
            }
        }

        public async Task SaveUserAccountLoginSessionDataAsync(Guid userId, string sessionId, Dictionary<string, string> requestData)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                // add session data
                var sessionData = new UserAccountLoginSessionDatum
                {
                    UserAccountLoginSessionDataID = Guid.NewGuid(),
                    RequestData = requestData.ToJson(),
                    UserAccountID = userId,
                    UserSessionID = sessionId
                };

                scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountLoginSessionData.Add(sessionData);

                await scope.SaveChangesAsync();
            }
        }


        public bool DoesUserExist(Guid userID)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().UserAccounts.Any(s => s.ID == userID);
            }
        }

        public UserAccountOrganisationDTO GetPermanentUAO(Guid userID)
        {
            int personalOrgTypeID = OrganisationTypeEnum.Personal.GetIntValue();

            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var uaoEntry = scope.DbContexts.Get<TargetFrameworkEntities>().VUserAccountOrganisationUserTypeOrganisationTypes.Single(s => s.OrganisationTypeID == personalOrgTypeID && s.UserID == userID);
                return scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations.Single(s => s.UserAccountOrganisationID == uaoEntry.UserAccountOrganisationID).ToDto();
            }
        }

        public Guid GetPersonalUserAccountOrganisation(Guid userId)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                Guid userTypeGuid = UserTypeEnum.User.GetGuidValue();

                return scope.DbContexts.Get<TargetFrameworkEntities>().VUserAccountOrganisationUserTypeOrganisationTypes.Single(s =>
                    s.UserID == userId && s.UserTypeID == userTypeGuid && s.OrganisationType == "Personal").UserAccountOrganisationID;
            }
        }

        public async Task<BrockAllen.MembershipReboot.UserAccount> CreateAccountAsync(string userName, string password, string email, Guid userId)
        {
            return await UaService.CreateAccountAsync(userName, password, email, userId);
        }

        public async Task CreateContactAsync(ContactDTO contactDTO)
        {
            Ensure.That(contactDTO).IsNotNull();
            using (var scope = DbContextScopeFactory.Create())
            {
                Contact contact = contactDTO.ToEntity();
                //SetAuditFields(contact, true);
                scope.DbContexts.Get<TargetFrameworkEntities>().Contacts.Add(contact);
                await scope.SaveChangesAsync();
            }
        }

        public bool ContactExists(Guid parentID)
        {
            Ensure.That(parentID).IsNot(Guid.Empty);
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().Contacts.Where(item => item.ParentID == parentID).Count() > 0;
            }
        }

        public async Task DeleteAccountAsync(Guid userID)
        {
            await UaService.DeleteAccountAsync(userID);
        }
        public async Task CloseAccountAsync(Guid userID)
        {
            await UaService.CloseAccountAsync(userID);
        }

        public List<VUserAccountNotLoggedInDTO> GetUserAccountsNotLoggedIn()
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().VUserAccountNotLoggedIns.ToDtos();
            }
        }

        public async Task SendUsernameReminderAsync(string email)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                foreach (var uao in scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations.Where(x => x.UserAccount.Email == email && x.IsActive && !x.IsDeleted && !x.UserAccount.IsTemporaryAccount))
                {
                    var tempDto = new UsernameReminderDTO
                    {
                        UserID = uao.UserAccount.ID,
                        Username = uao.UserAccount.Username,
                        Salutation = uao.Contact.Salutation,
                        FirstName = uao.Contact.FirstName,
                        LastName = uao.Contact.LastName,
                        UserAccountOrganisationID = uao.UserAccountOrganisationID
                    };

                    string payLoad = JsonHelper.SerializeData(new object[] { tempDto });

                    var dto = new Bec.TargetFramework.SB.Entities.EventPayloadDTO
                    {
                        EventName = "UsernameReminderEvent",
                        EventSource = AppDomain.CurrentDomain.FriendlyName,
                        EventReference = "0001",
                        PayloadAsJson = payLoad
                    };

                    await EventPublishClient.PublishEventAsync(dto);
                }
            }
        }

        public async Task CreatePasswordResetRequestAsync(string username)
        {
            //check user exists
            using (var scope = DbContextScopeFactory.Create())
            {
                var user = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccounts.FirstOrDefault(s => s.Username == username && !s.IsTemporaryAccount);
                
                if(user == null) throw new Exception("An error has occured");
                if (ValidPINExists(user.MobileCodeSent)) throw new Exception("A verification code was generated recently. Please wait a few minutes and try again.");

                user.MobileCode = CreatePin(4);
                user.MobileCodeSent = DateTime.Now;
                await SendTextMessage(user.MobilePhoneNumber, user.MobileCode);

                await scope.SaveChangesAsync();
            }
        }

        private bool ValidPINExists(DateTime? dt)
        {
            return dt.HasValue && (DateTime.Now - dt.Value).TotalMinutes < 10;
        }

        private async Task SendTextMessage(string phoneNumber, string pin)
        {
            var message = string.Format("You, or someone else, has requested to reset your password. PIN: {0}", pin);

            //implementation specific
            var account = "EX0194398";
            string m = "<?xml version='1.0' encoding='UTF-8'?>" +
                "<messages>  " +
                "<accountreference>" +
                account +
                "</accountreference>" +
                 "<message>" +
                  "<to>" +
                  phoneNumber +
                  "</to>" +
                  "<body>" +
                  message +
                  "</body>" +
                 "</message>" +
                "</messages>";

            System.Net.Http.HttpClient c = new System.Net.Http.HttpClient();
            c.BaseAddress = new Uri("https://api.esendex.com/v1.0/");

            var byteArray = Encoding.ASCII.GetBytes("k.howie@beconsultancy.co.uk:YDueg0xvqjzw");
            c.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            var response = await c.PostAsync("messagedispatcher", new System.Net.Http.StringContent(m));
            response.EnsureSuccessStatusCode();
        }

        public async Task GeneratePinAsync(Guid uaoID, bool blank, bool overwriteExisting = false)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var uao = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations.Single(x => x.UserAccountOrganisationID == uaoID);

                if (!overwriteExisting && !string.IsNullOrEmpty(uao.PinCode)) throw new Exception("Cannot generate pin; pin already exists. Please go back and try again.");

                uao.PinCode = blank ? null : CreatePin(4);
                uao.PinCreated = DateTime.Now;
                uao.UserAccount.IsLoginAllowed = true;

                await scope.SaveChangesAsync();
            }
        }

        private string CreatePin(int length)
        {
            Random r = new Random();
            StringBuilder pin = new StringBuilder(length);
            int thisNum;
            int? prevNum = null;
            do
            {
                for (int i = 0; i < length; i++)
                {
                    do
                    {
                        thisNum = r.Next(0, 36);
                    } while (prevNum.HasValue && (thisNum == prevNum || thisNum == prevNum - 1 || thisNum == prevNum + 1)); //avoid repeated or consecutive characters
                    prevNum = thisNum;
                    pin.Append((char)(thisNum > 9 ? thisNum + 55 : thisNum + 48)); //convert to 0-9 A-Z
                }
            } while (PinExists(pin.ToString()));
            return pin.ToString();
        }

        private bool PinExists(string pin)
        {
            return false;
            //using (var scope = DbContextScopeFactory.CreateReadOnly())
            //{
            //    return scope.DbContexts.Get<TargetFrameworkEntities>().Organisations.Any(o => o.CompanyPinCode == pin);
            //}
        }

        public async Task<bool> IncrementInvalidPINAsync(Guid uaoID)
        {
            bool ret = false;
            using (var scope = DbContextScopeFactory.Create())
            {
                var uao = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations.Single(x => x.UserAccountOrganisationID == uaoID);
                uao.PinAttempts++;
                if (uao.PinAttempts >= 3)
                {
                    await OrganisationLogic.ExpireUserAccountOrganisationAsync(uaoID);
                    ret = true;
                }
                await scope.SaveChangesAsync();
            }
            return ret;
        }

        public async Task RegisterUserAsync(Guid uaoId, string phoneNumber, string password)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var vStatus = LogicHelper.GetStatusType(scope, StatusTypeEnum.ProfessionalOrganisation.GetStringValue(), ProfessionalOrganisationStatusEnum.Verified.GetStringValue());
                var uao = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations.Single(x => x.UserAccountOrganisationID == uaoId);

                var currentStatus = uao.Organisation.OrganisationStatus.OrderByDescending(s => s.StatusChangedOn).First();
                //progress status to 'active' if it's only 'verified'
                if (currentStatus.StatusTypeID == vStatus.StatusTypeID && currentStatus.StatusTypeValueID == vStatus.StatusTypeValueID)
                    await OrganisationLogic.ActivateOrganisationAsync(uao.OrganisationID);

                await LockOrUnlockUserAsync(uao.UserID, false);
                await ResetUserPassword(uao.UserID, password, true, null);

                uao.UserAccount.IsTemporaryAccount = false;
                uao.UserAccount.MobilePhoneNumber = phoneNumber;

                await scope.SaveChangesAsync();
            }
        }

        public async Task<List<UserAccountOrganisationRoleDTO>> GetRoles(Guid uaoID, int withRelatedLevel)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisationRoles.Where(x => x.UserAccountOrganisationID == uaoID).ToDtosWithRelated(withRelatedLevel);
            }
        }

        public async Task ChangeUsernameAndEmail(Guid uaoId, string newUsername)
        {
            UserAccountDTO userAccountDto;
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var uao = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations.Single(x => x.UserAccountOrganisationID == uaoId);
                userAccountDto = uao.UserAccount.ToDto();
            }

            if (!userAccountDto.Username.Trim().Equals(newUsername.Trim(), StringComparison.InvariantCultureIgnoreCase))
            {
                await UaService.ChangeUsernameAndEmailAsync(userAccountDto.ID, newUsername);
            }
        }
    }
}
