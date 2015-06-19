using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Entities.Injections;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.SB.Client.Interfaces;
using Bec.TargetFramework.SB.Interfaces;
using Bec.TargetFramework.Security;
using BrockAllen.MembershipReboot;
using EnsureThat;
using Omu.ValueInjecter;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Logic
{
    [Trace(TraceExceptionsOnly = true)]
    public class UserLogicController : LogicBase
    {
        public UserAccountService UaService { get; set; }
        public AuthenticationService AuthSvc { get; set; }
        public DataLogicController DataLogic { get; set; }
        public IEventPublishLogicClient EventPublishClient { get; set; }
        public UserLogicController()
        {
        }

        public UserLoginValidation AuthenticateUser(string username, string password)
        {
            BrockAllen.MembershipReboot.UserAccount account = this.GetBAUserAccountByUsername(username);

            var decodedPassword = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(password));

            UserLoginValidation result = UaService.AuthenticateWithUsername(account, username, decodedPassword);

            result.UserAccount = account;

            return result;
        }

        //public List<UserDetailDTO> GetAllUserDetailDTO()
        //{
        //    var dtoList = new List<UserDetailDTO>();

        //    using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
        //    {
        //        //scope.DbContext.VUsers.ToList().ForEach(item =>
        //        //{
        //        //    var dto = new UserDetailDTO();

        //        //    dto.InjectFrom(item);

        //        //    dtoList.Add(dto);
        //        //});
        //    }

        //    return dtoList;
        //}

        //public List<vUserManagementDTO> GetAllUserManagementDTO(SortingPagingDto pagingDto,UserManagementCritieraDTO dto)
        //{
        //    var dtoList = new List<vUserManagementDTO>();

        //    //if (dto != null)
        //    //{
        //    //    using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
        //    //    {
        //    //        if (!string.IsNullOrEmpty(dto.SearchQuery))
        //    //        {
        //    //            if (dto.SearchQueryTargetProperties == null)
        //    //            {
        //    //                dto.SearchQueryTargetProperties = new List<PropertyInfo>();

        //    //                dto.RowObject.GetType().GetProperties().Where(item => item.PropertyType.Equals(typeof(string)))
        //    //                    .ToList().ForEach(pi => dto.SearchQueryTargetProperties.Add(pi));

        //    //            }
        //    //        }
        //    //        var predicate = LinqHelpers.BuildPredicate<VUserManagement,
        //    //           UserManagementCritieraDTO>(dto);

        //    //        scope.DbContext.VUserManagements.AsExpandable().Where(predicate)
        //    //       .OrderBy(item => item.Username).Skip(pagingDto.PageSize * pagingDto.PageNumber).Take(pagingDto.PageSize).ToList().ForEach(item =>
        //    //       {
        //    //           var udto = new vUserManagementDTO();
        //    //           udto.InjectFrom(item);
        //    //           dtoList.Add(udto);
        //    //       });

        //    //    }
        //    //}

        //    return dtoList;
        //}

        //public vUserManagementDTO GerUserManagementDTO(Guid userId)
        //{
        //    Ensure.That(userId).IsNot(Guid.Empty);

        //    var dto = new vUserManagementDTO();

        //    //using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
        //    //{
        //    //    var userDetail = scope.GetGenericRepository<VUserManagement, Guid>().Find(item => item.UserID.Equals(userId));

        //    //    dto.InjectFrom<NullableInjection>(userDetail);
        //    //}

        //    return dto;
        //}

        public async Task<ContactDTO> AddUser(ContactDTO dto)
        {
            Ensure.That(dto).IsNotNull();
            var userContact = new Contact();
            var userDetail = new UserAccountDetail();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var userAccount = UaService.CreateAccount(dto.ContactName, RandomPasswordGenerator.Generate(10), dto.EmailAddress1, true, Guid.NewGuid());

                //user contact
                userContact.InjectFrom<NullableInjection>(dto);
                userContact.ContactID = Guid.NewGuid();
                userContact.ParentID = userAccount.ID;
                //SetAuditFields<Contact>(userContact, true);
                scope.DbContext.Contacts.Add(userContact);


                //create user account detail
                userDetail.InjectFrom<NullableInjection>(dto);
                userDetail.UserID = userAccount.ID;
                userDetail.UserDetailID = Guid.NewGuid();
                userDetail.Salutation = dto.Salutation;
                //SetAuditFields<UserAccountDetail>(userDetail, true);
                scope.DbContext.UserAccountDetails.Add(userDetail);

                await scope.SaveAsync();

                return userContact.ToDto();
            }
        }

        /// <summary>
        /// Reset for Temporary Accounts
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="newPassword"></param>
        public void ResetUserPassword(Guid userID, string newPassword)
        {
            var userAccount = UaService.GetByID(userID);

            if (userAccount.IsTemporaryAccount)
                UaService.SetPasswordAndClearVerificationKey(userID, newPassword);
            else
                UaService.SetPassword(userID, newPassword);
        }

        /// <summary>
        /// Applies only to Temporary Accounts at the moment
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool HasPasswordExpired(Guid userID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                return scope.DbContext.UserAccounts.Any(s =>
                    s.ID == userID &&
                    !string.IsNullOrEmpty(s.VerificationKey) &&
                    (!s.LastLogin.HasValue || (s.LastLogin.HasValue && s.PasswordChanged > s.LastLogin.Value)));
            }
        }

        public async Task LockOrUnlockUser(Guid userId, bool lockUser)
        {
            Ensure.That(userId).IsNot(Guid.Empty);
            var user = new Bec.TargetFramework.Data.UserAccount();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                user = scope.DbContext.UserAccounts.Single(x => x.ID == userId);

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

                await scope.SaveAsync();
            }
        }

        public string ResetPasswordAndSetVerificationKey(Guid userId)
        {
            return UaService.ResetPasswordAndReturnVerificationKey(userId);
        }

        public void ResetPassword(string email)
        {
            var account = UaService.GetByEmail(email);
            UaService.ResetPassword(email);
        }

        [EnsureArgumentAspect]
        public bool IsUserExist(string userName)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger, false))
            {
                return scope.DbContext.UserAccounts.Where(x => x.Username.ToLower() == userName.ToLower()).Count() > 0;
            }
        }

        [EnsureArgumentAspect]
        public bool IsEmailExist(string email)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger, false))
            {
                return scope.DbContext.UserAccounts.Where(u => u.Email.ToLower() == email.ToLower() && !u.IsAccountClosed && u.IsActive).Count() > 0;
            }
        }

        public IEnumerable<AddressDTO> GetUserAddresses(Guid contactID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                return scope.DbContext.Addresses.Where(item => item.ParentID == contactID && item.IsActive && !item.IsDeleted).OrderBy(item => item.Name).ToDtos();
            }
        }

        public List<BrockAllen.MembershipReboot.UserAccount> GetAllUserAccount()
        {
            var dtoList = new List<BrockAllen.MembershipReboot.UserAccount>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                scope.DbContext.UserAccounts.ToList().ForEach(item =>
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
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                ua = new BrockAllen.MembershipReboot.UserAccount();
                var uaDb = scope.DbContext.UserAccounts.Single(s => s.ID == key);
                ua.InjectFrom<NullableInjection>(uaDb);
                ua.PasswordResetSecrets = GetPasswordResetSecrets(key);
            }

            return ua;
        }

        public BrockAllen.MembershipReboot.UserAccount GetBAUserAccountByEmail(string email)
        {
            BrockAllen.MembershipReboot.UserAccount ua = null;
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                var uaDb = scope.DbContext.UserAccounts.Where(s => s.Email == email && s.IsActive && !s.IsDeleted).ToList();

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
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                var uaDb = scope.DbContext.UserAccounts.Where(s => s.Email == email && s.ID != id).ToList();

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
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, false))
            {
                var uaDb = scope.DbContext.UserAccounts.SingleOrDefault(s => s.Username == username);

                if (uaDb != null)
                {
                    ua = new BrockAllen.MembershipReboot.UserAccount();
                    ua.InjectFrom<NullableInjection>(uaDb);
                    ua.PasswordResetSecrets = GetPasswordResetSecrets(uaDb.ID);
                }
            }
            return ua;
        }

        public List<UserAccountDTO> GetUserAccountByEmail(string email, bool permanentAccountonly)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                if (permanentAccountonly)
                    return scope.DbContext.UserAccounts.Where(s => s.Email == email && s.IsActive && !s.IsDeleted && s.IsTemporaryAccount == !permanentAccountonly).ToDtos();
                else
                    return scope.DbContext.UserAccounts.Where(s => s.Email == email && s.IsActive && !s.IsDeleted).ToDtos();
            }
        }
        public UserAccountDTO GetUserAccountByUsername(string userName)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                return scope.DbContext.UserAccounts.SingleOrDefault(s => s.Username == userName).ToDto();
            }
        }

        public List<ContactDTO> GetUserContacts(Guid userId)
        {
            List<ContactDTO> ua = new List<ContactDTO>(); ;
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                ua = ContactConverter.ToDtos(scope.DbContext.Contacts.Where(s => s.ParentID == userId));

            }
            return ua;
        }

        public List<BrockAllen.MembershipReboot.UserAccount> GetUserAccounts(Guid key)
        {
            BrockAllen.MembershipReboot.UserAccount ua = null;
            List<BrockAllen.MembershipReboot.UserAccount> accounts = new List<BrockAllen.MembershipReboot.UserAccount>();
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                var uaDb = scope.DbContext.UserAccounts.Where(s => s.ID == key).ToList();
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
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                return scope.DbContext.UserAccountOrganisations.Where(item => item.UserID == accountID && item.IsActive && !item.IsDeleted).ToDtosWithRelated(1);
            }
        }

        private List<BrockAllen.MembershipReboot.PasswordResetSecret> GetPasswordResetSecrets(Guid userAccountID)
        {
            List<BrockAllen.MembershipReboot.PasswordResetSecret> dtoList = new List<BrockAllen.MembershipReboot.PasswordResetSecret>();
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                scope.DbContext.PasswordResetSecrets.Where(s =>
                    s.UserAccountID == userAccountID &&
                    s.IsActive &&
                    !s.IsDeleted)
                    .ToList().ForEach(item =>
                    {
                        BrockAllen.MembershipReboot.PasswordResetSecret rs = new BrockAllen.MembershipReboot.PasswordResetSecret();

                        rs.InjectFrom<NullableInjection>(item);
                        //Get the question description as we will be only storing classificationtypeid in the passwordresetsecret
                        rs.Question = scope.DbContext.ClassificationTypes.Single(x => x.ClassificationTypeID == item.QuestionID).Name;

                        dtoList.Add(rs);
                    });
            }
            return dtoList;
        }

        public BrockAllen.MembershipReboot.UserAccount CreateUserAccount()
        {
            return new BrockAllen.MembershipReboot.UserAccount();
        }

        public async Task AddUserAccount(BrockAllen.MembershipReboot.UserAccount user)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                Data.UserAccount ua = new Data.UserAccount();

                ua.InjectFrom<NullableInjection>(user);

                scope.DbContext.UserAccounts.Add(ua);

                foreach (var it in user.PasswordResetSecrets)
                {
                    var secret = new Bec.TargetFramework.Data.PasswordResetSecret();

                    secret.InjectFrom(it);
                    secret.UserAccountID = user.ID;
                    scope.DbContext.PasswordResetSecrets.Add(secret);
                }

                await scope.SaveAsync();
            }
        }

        public async Task RemoveUserAccount(BrockAllen.MembershipReboot.UserAccount user)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var uaDb = scope.DbContext.UserAccounts.Single(s => s.ID == user.ID);
                scope.DbContext.UserAccounts.Remove(uaDb);
                await scope.SaveAsync();
            }
        }

        public async Task UpdateUserAccount(BrockAllen.MembershipReboot.UserAccount user)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var uaDb = scope.DbContext.UserAccounts.Single(s => s.ID.Equals(user.ID));

                uaDb.InjectFrom<NullableInjection>(new IgnoreProps("ID"), user);

                var entry = scope.DbContext.Entry(uaDb);

                entry.State = System.Data.Entity.EntityState.Modified;

                foreach (var it in user.PasswordResetSecrets)
                {
                    var secret = scope.DbContext.PasswordResetSecrets.SingleOrDefault(s => s.PasswordResetSecretID.Equals(it.PasswordResetSecretID));
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
                        scope.DbContext.PasswordResetSecrets.Add(secret);
                    }
                }

                await scope.SaveAsync();
            }
        }

        public List<UserClaimDTO> GetUserClaims(Guid userId, Guid organisationID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                var result = scope.DbContext.FnGetUserClaim(userId, organisationID);

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
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                var contact = scope.DbContext.Contacts.Where(item => item.IsPrimaryContact && item.ParentID == uaoID && item.IsActive && !item.IsDeleted).FirstOrDefault();

                Ensure.That(contact).IsNotNull();
                return contact.ToDto();
            }
        }

        public VUserAccountOrganisationUserTypeOrganisationTypeDTO GetUserAccountOrganisationUserTypeOrganisationType(Guid accountID, bool personalOrg)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                var uaoUTypeOType = new VUserAccountOrganisationUserTypeOrganisationType();
                int orgType = (int)OrganisationTypeEnum.Personal;
                if (personalOrg)
                    uaoUTypeOType = scope.DbContext.VUserAccountOrganisationUserTypeOrganisationTypes.SingleOrDefault(item => item.UserID == accountID && item.OrganisationTypeID == orgType);
                else
                    uaoUTypeOType = scope.DbContext.VUserAccountOrganisationUserTypeOrganisationTypes.SingleOrDefault(item => item.UserID == accountID && item.OrganisationTypeID != orgType);
                return uaoUTypeOType.ToDto();
            }
        }

        public List<VUserAccountOrganisationUserTypeOrganisationTypeDTO> GetUserAccountOrganisationWithUserTypeAndOrgType(Guid accountID)
        {
            VUserAccountOrganisationUserTypeOrganisationTypeDTO uaoUserTypeOrganisationType = new VUserAccountOrganisationUserTypeOrganisationTypeDTO();
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                return scope.DbContext.VUserAccountOrganisationUserTypeOrganisationTypes.Where(s => s.UserID == accountID).ToDtos();
            }
        }

        public List<string> UserLoginSessions(Guid userId)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                return scope.DbContext.UserAccountLoginSessions.Where(item => !(item.UserHasLoggedOut ?? false) && item.UserAccountID == userId)
                   .Select(item => item.UserSessionID)
                   .ToList();
            }
        }

        public async Task LogEveryoneElseOut(Guid userId, string sessionId)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                foreach (var item in scope.DbContext.UserAccountLoginSessions.Where(item =>
                    item.UserHasLoggedOut.Value != true &&
                    item.UserAccountID == userId &&
                    item.UserSessionID != sessionId))
                {
                    item.UserHasLoggedOut = true;
                }

                await scope.SaveAsync();
            }
        }

        public async Task SaveUserAccountLoginSession(Guid userId, string sessionId, string userHostAddress, string userIdAddress, string userLocation)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
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

                scope.DbContext.UserAccountLoginSessions.Add(session);

                await scope.SaveAsync();
            }
        }

        public async Task SaveUserAccountLoginSessionData(Guid userId, string sessionId, Dictionary<string, string> requestData)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                // add session data
                var sessionData = new UserAccountLoginSessionDatum
                {
                    UserAccountLoginSessionDataID = Guid.NewGuid(),
                    RequestData = requestData.ToJson(),
                    UserAccountID = userId,
                    UserSessionID = sessionId
                };

                scope.DbContext.UserAccountLoginSessionData.Add(sessionData);

                await scope.SaveAsync();
            }
        }

        public void LockUserTemporaryAccount(Guid tempUserId)
        {
            var tempAccount = UaService.GetByID(tempUserId);

            tempAccount.IsActive = false;
            tempAccount.IsDeleted = true;
            tempAccount.IsAccountClosed = true;
            tempAccount.IsLoginAllowed = false;

            UaService.Update(tempAccount);
        }

        public bool DoesUserExist(Guid userID, bool isTemporary)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                return scope.DbContext.UserAccounts.Any(s => s.ID == userID && s.IsTemporaryAccount == isTemporary);
            }
        }

        public UserAccountOrganisationDTO GetPermanentUAO(Guid userID)
        {
            int personalOrgTypeID = OrganisationTypeEnum.Personal.GetIntValue();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                var uaoEntry = scope.DbContext.VUserAccountOrganisationUserTypeOrganisationTypes.Single(s => s.OrganisationTypeID.Value == personalOrgTypeID && s.UserID.Value == userID);
                return scope.DbContext.UserAccountOrganisations.Single(s => s.UserAccountOrganisationID == uaoEntry.UserAccountOrganisationID).ToDto();
            }
        }

        public Guid GetPersonalUserAccountOrganisation(Guid userId)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                Guid userTypeGuid = UserTypeEnum.User.GetGuidValue();

                return scope.DbContext.VUserAccountOrganisationUserTypeOrganisationTypes.Single(s =>
                    s.UserID == userId && s.UserTypeID == userTypeGuid && s.OrganisationType == "Personal").UserAccountOrganisationID;
            }
        }

        public BrockAllen.MembershipReboot.UserAccount CreateTemporaryAccount(string email, string password, bool temporaryAccount, Guid userId)
        {
            return UaService.CreateAccount(DataLogic.GenerateRandomName(), password, email, temporaryAccount, userId);
        }

        public BrockAllen.MembershipReboot.UserAccount CreateAccount(string userName, string password, string email, bool temporaryAccount, Guid userId)
        {
            return UaService.CreateAccount(userName, password, email, temporaryAccount, userId);
        }

        public async Task CreateContact(ContactDTO contactDTO)
        {
            Ensure.That(contactDTO).IsNotNull();
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                Contact contact = contactDTO.ToEntity();
                //SetAuditFields(contact, true);
                scope.DbContext.Contacts.Add(contact);
                await scope.SaveAsync();
            }
        }

        public bool ContactExists(Guid parentID)
        {
            Ensure.That(parentID).IsNot(Guid.Empty);
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger, true))
            {
                return scope.DbContext.Contacts.Where(item => item.ParentID == parentID).Count() > 0;
            }
        }

        public void DeleteAccount(Guid userID)
        {
            UaService.DeleteAccount(userID);
        }
        public void CloseAccount(Guid userID)
        {
            UaService.CloseAccount(userID);
        }

        public List<VUserAccountNotLoggedInDTO> GetUserAccountsNotLoggedIn()
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger, true))
            {
                return scope.DbContext.VUserAccountNotLoggedIns.ToDtos();
            }
        }

        public async Task SendUsernameReminder(string email)
        {
            //check user exists
            var user = this.GetUserAccountByEmail(email, true).FirstOrDefault();
            if (user != null)
            {
                var uao = GetUserAccountOrganisation(user.ID).First();
                var primaryContact = GetUserAccountOrganisationPrimaryContact(uao.UserAccountOrganisationID);

                var tempDto = new UsernameReminderDTO
                {
                    UserID = user.ID,
                    Username = user.Username,
                    Salutation = primaryContact.Salutation,
                    FirstName = primaryContact.FirstName,
                    LastName = primaryContact.LastName,
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

        public async Task SendPasswordResetNotification(string username, string siteUrl)
        {
            //check user exists
            Data.UserAccount user = null;
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                user = scope.DbContext.UserAccounts.FirstOrDefault(s => s.Username == username && !s.IsTemporaryAccount);
            }
            if (user != null)
            {
                var resetGuid = Guid.NewGuid();
                using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
                {
                    var pr = new PasswordResetRequest();
                    pr.RequestID = resetGuid;
                    pr.UserID = user.ID;
                    pr.CreatedDateTime = DateTime.Now;
                    pr.Expired = false;
                    scope.DbContext.PasswordResetRequests.Add(pr);
                    await scope.SaveAsync();
                }
                var uao = GetUserAccountOrganisation(user.ID).First();
                var primaryContact = GetUserAccountOrganisationPrimaryContact(uao.UserAccountOrganisationID);

                var tempDto = new ForgotPasswordDTO
                {
                    UserID = user.ID,
                    Salutation = primaryContact.Salutation,
                    FirstName = primaryContact.FirstName,
                    LastName = primaryContact.LastName,
                    UserAccountOrganisationID = uao.UserAccountOrganisationID,
                    Url = string.Format(siteUrl, resetGuid, false),
                    ExpireUrl = string.Format(siteUrl, resetGuid, true)
                };
                string payLoad = JsonHelper.SerializeData(new object[] { tempDto });

                var dto = new Bec.TargetFramework.SB.Entities.EventPayloadDTO
                {
                    EventName = "ForgotPasswordEvent",
                    EventSource = AppDomain.CurrentDomain.FriendlyName,
                    EventReference = "0002",
                    PayloadAsJson = payLoad
                };

                await EventPublishClient.PublishEventAsync(dto);
            }
        }

        public async Task<Guid> ExpirePasswordResetRequest(Guid requestID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var rr = GetResetRequest(scope, requestID);
                if (rr != null) rr.Expired = true;
                await scope.SaveAsync();

                if (rr == null)
                    return Guid.Empty;
                else
                    return rr.UserID;
            }
        }

        public bool IsPasswordResetRequestValid(Guid requestID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                return GetResetRequest(scope, requestID) != null;
            }
        }

        private PasswordResetRequest GetResetRequest(UnitOfWorkScope<TargetFrameworkEntities> scope, Guid requestID)
        {
            var rr = scope.DbContext.PasswordResetRequests.SingleOrDefault(r => r.RequestID == requestID && !r.Expired);
            if (rr != null && (DateTime.Now - rr.CreatedDateTime).TotalMinutes < 10)
                return rr;
            else
                return null;
        }
    }
}
