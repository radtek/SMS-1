﻿using Bec.TargetFramework.Aop.Aspects;
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

        public async Task<ContactDTO> AddUserAsync(ContactDTO dto)
        {
            Ensure.That(dto).IsNotNull();
            var userContact = new Contact();
            var userDetail = new UserAccountDetail();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var userAccount = await UaService.CreateAccountAsync(dto.ContactName, RandomPasswordGenerator.Generate(10), dto.EmailAddress1, true, Guid.NewGuid());

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
        public async Task ResetUserPassword(Guid userID, string newPassword)
        {
            var userAccount = UaService.GetByID(userID);

            if (userAccount.IsTemporaryAccount)
                await UaService.SetPasswordAndClearVerificationKeyAsync(userID, newPassword);
            else
                await UaService.SetPasswordAsync(userID, newPassword);
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

        public async Task LockOrUnlockUserAsync(Guid userId, bool lockUser)
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

        //public string ResetPasswordAndSetVerificationKey(Guid userId)
        //{
        //    return UaService.ResetPasswordAndReturnVerificationKey(userId);
        //}

        //public async Task ResetPassword(string email)
        //{
        //    var account = UaService.GetByEmail(email);
        //    await UaService.ResetPasswordAsync(email);
        //}

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
                    ua.FullName = ua.Username;

                    var uao = uaDb.UserAccountOrganisations.FirstOrDefault();
                    if (uao != null)
                    {
                        var c = scope.DbContext.Contacts.FirstOrDefault(x => x.ParentID == uao.UserAccountOrganisationID);
                        if (c != null) ua.FullName = c.FirstName + " " + c.LastName;
                    }
                        
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

        public async Task AddUserAccountAsync(BrockAllen.MembershipReboot.UserAccount user)
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

        public async Task RemoveUserAccountAsync(BrockAllen.MembershipReboot.UserAccount user)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var uaDb = scope.DbContext.UserAccounts.Single(s => s.ID == user.ID);
                scope.DbContext.UserAccounts.Remove(uaDb);
                await scope.SaveAsync();
            }
        }

        public async Task UpdateUserAccountAsync(BrockAllen.MembershipReboot.UserAccount user)
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

        public async Task LogEveryoneElseOutAsync(Guid userId, string sessionId)
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

        public async Task SaveUserAccountLoginSessionAsync(Guid userId, string sessionId, string userHostAddress, string userIdAddress, string userLocation)
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

        public async Task SaveUserAccountLoginSessionDataAsync(Guid userId, string sessionId, Dictionary<string, string> requestData)
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

        public async Task LockUserTemporaryAccountAsync(Guid tempUserId)
        {
            var tempAccount = UaService.GetByID(tempUserId);

            tempAccount.IsActive = false;
            tempAccount.IsDeleted = true;
            tempAccount.IsAccountClosed = true;
            tempAccount.IsLoginAllowed = false;

            await UaService.UpdateAsync(tempAccount);
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

        public async Task<BrockAllen.MembershipReboot.UserAccount> CreateTemporaryAccountAsync(string email, string password, bool temporaryAccount, Guid userId)
        {
            return await UaService.CreateAccountAsync(RandomPasswordGenerator.GenerateRandomName(), password, email, temporaryAccount, userId);
        }

        public async Task<BrockAllen.MembershipReboot.UserAccount> CreateAccountAsync(string userName, string password, string email, bool temporaryAccount, Guid userId)
        {
            return await UaService.CreateAccountAsync(userName, password, email, temporaryAccount, userId);
        }

        public async Task CreateContactAsync(ContactDTO contactDTO)
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
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger, true))
            {
                return scope.DbContext.VUserAccountNotLoggedIns.ToDtos();
            }
        }

        public async Task SendUsernameReminderAsync(string email)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger, true))
            {
                foreach (var uao in scope.DbContext.UserAccountOrganisations.Where(x => x.UserAccount.Email == email && x.IsActive && !x.IsDeleted && !x.UserAccount.IsTemporaryAccount))
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

        public async Task SendPasswordResetNotificationAsync(string username, string siteUrl)
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

        public async Task<Guid> ExpirePasswordResetRequestAsync(Guid requestID)
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


        public async Task GeneratePinAsync(Guid uaoID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var uao = scope.DbContext.UserAccountOrganisations.Single(x => x.UserAccountOrganisationID == uaoID);

                if (!string.IsNullOrEmpty(uao.PinCode)) throw new Exception("Cannot generate pin; pin already exists. Please go back and try again.");

                uao.PinCode = CreatePin(4);
                uao.PinCreated = DateTime.Now;
                uao.UserAccount.IsLoginAllowed = true;

                await scope.SaveAsync();
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
            //using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            //{
            //    return scope.DbContext.Organisations.Any(o => o.CompanyPinCode == pin);
            //}
        }

        public async Task<bool> IncrementInvalidPINAsync(Guid uaoID)
        {
            bool ret = false;
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var uao = scope.DbContext.UserAccountOrganisations.Single(x => x.UserAccountOrganisationID == uaoID);
                uao.PinAttempts++;
                if (uao.PinAttempts >= 3)
                {
                    await OrganisationLogic.ExpireUserAccountOrganisationAsync(uaoID);
                    ret = true;
                }
                await scope.SaveAsync();
            }
            return ret;
        }

        public async Task RegisterUserAsync(Guid orgID, Guid tempUaoId, string username, string password)
        {
            Guid[] roles;
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                //copy roles from temp user
                roles = scope.DbContext.UserAccountOrganisationRoles.Where(x => x.UserAccountOrganisationID == tempUaoId).Select(r => r.OrganisationRoleID).ToArray();

            }
            var contactDTO = GetUserAccountOrganisationPrimaryContact(tempUaoId);

            //has to be called outside of transaction.
            var newUaoDto = await OrganisationLogic.AddNewUserToOrganisationAsync(orgID, contactDTO, username, password, false, false, roles);

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger))
            {
                var vStatus = LogicHelper.GetStatusType(scope, StatusTypeEnum.ProfessionalOrganisation.GetStringValue(), ProfessionalOrganisationStatusEnum.Verified.GetStringValue());
                var uao = scope.DbContext.UserAccountOrganisations.Single(x => x.UserAccountOrganisationID == tempUaoId);
                var currentStatus = uao.Organisation.OrganisationStatus.OrderByDescending(s => s.StatusChangedOn).First();

                //progress status to 'active' if it's only 'verified'
                if (currentStatus.StatusTypeID == vStatus.StatusTypeID && currentStatus.StatusTypeValueID == vStatus.StatusTypeValueID)
                    await OrganisationLogic.ActivateOrganisationAsync(uao.OrganisationID);

                //delete original temp user account
                await LockUserTemporaryAccountAsync(uao.UserID);

                await scope.SaveAsync();
            }
        }

        public async Task<UserAccountOrganisationDTO> ResendLoginsAsync(Guid uaoId)
        {
            VUserAccountOrganisationDTO oldUaInfo;
            Guid[] roles = null;
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                roles = scope.DbContext.UserAccountOrganisationRoles.Where(x => x.UserAccountOrganisationID == uaoId).Select(x => x.OrganisationRoleID).ToArray();
                oldUaInfo = scope.DbContext.VUserAccountOrganisations.Single(x => x.UserAccountOrganisationID == uaoId).ToDto();
                var orgInfo = scope.DbContext.VOrganisationWithStatusAndAdmins.SingleOrDefault(x => x.OrganisationID == oldUaInfo.OrganisationID); //will be null if org type != professional
                if (orgInfo != null)
                {                 //check status
                    var verifiedStatus = LogicHelper.GetStatusType(scope, StatusTypeEnum.ProfessionalOrganisation.GetStringValue(), ProfessionalOrganisationStatusEnum.Verified.GetStringValue());
                    var activeStatus = LogicHelper.GetStatusType(scope, StatusTypeEnum.ProfessionalOrganisation.GetStringValue(), ProfessionalOrganisationStatusEnum.Active.GetStringValue());
                    if (orgInfo.StatusTypeValueID != verifiedStatus.StatusTypeValueID && orgInfo.StatusTypeValueID != activeStatus.StatusTypeValueID)
                        throw new Exception(string.Format("Cannot resend logins for a company of status '{0}'. Please go back and try again.", orgInfo.StatusValueName));
                }
            }

            //generate new username & password
            var randomUsername = RandomPasswordGenerator.GenerateRandomName();
            var randomPassword = RandomPasswordGenerator.Generate(10);
            var userContactDto = new ContactDTO
            {
                Telephone1 = oldUaInfo.Telephone,
                FirstName = oldUaInfo.FirstName,
                LastName = oldUaInfo.LastName,
                EmailAddress1 = oldUaInfo.Email,
                Salutation = oldUaInfo.Salutation
            };

            //add new user & email them
            var newUao = await OrganisationLogic.AddNewUserToOrganisationAsync(oldUaInfo.OrganisationID, userContactDto, randomUsername, randomPassword, true, true, roles);

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                //disable the old user
                var user = scope.DbContext.UserAccounts.Single(x => x.ID == newUao.UserID);
                user.IsLoginAllowed = true;
                await scope.SaveAsync();
            }

            //disable old temps
            await LockUserTemporaryAccountAsync(oldUaInfo.ID);

            await GeneratePinAsync(newUao.UserAccountOrganisationID);

            return newUao;
        }

        public async Task<List<UserAccountOrganisationRoleDTO>> GetRoles(Guid uaoID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                return scope.DbContext.UserAccountOrganisationRoles.Where(x => x.UserAccountOrganisationID == uaoID).ToDtos();
            }
        }

        public async Task SetRolesAsync(Guid uaoID, params Guid[] orgRoleIDs)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var remove = scope.DbContext.UserAccountOrganisationRoles.Where(x => x.UserAccountOrganisationID == uaoID);
                scope.DbContext.UserAccountOrganisationRoles.RemoveRange(remove);

                foreach (var roleID in orgRoleIDs)
                {
                    scope.DbContext.UserAccountOrganisationRoles.Add(new UserAccountOrganisationRole
                    {
                        UserAccountOrganisationID = uaoID,
                        OrganisationRoleID = roleID
                    });
                }
                await scope.SaveAsync();
            }
        }
    }
}
