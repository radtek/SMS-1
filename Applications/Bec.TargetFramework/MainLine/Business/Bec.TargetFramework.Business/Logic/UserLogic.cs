using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
//Bec.TargetFramework.Entities
using Bec.TargetFramework.Entities.Injections;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Security;
using BrockAllen.MembershipReboot;
//using Fabrik.Common;
using LinqKit;
using Omu.ValueInjecter;
using ServiceStack.Text;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Data.Infrastructure.Specifications;
using Bec.TargetFramework.Data.Infrastructure.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Bec.TargetFramework.Infrastructure.Extensions;
namespace Bec.TargetFramework.Business.Logic
{
    using Bec.TargetFramework.Aop.Aspects;
    using Bec.TargetFramework.Entities;
    using System.ServiceModel;
    using EnsureThat;
    using Bec.TargetFramework.Entities.Enums;
    using Bec.TargetFramework.SB.Interfaces;
    using Bec.TargetFramework.Infrastructure.Helpers;

    [Trace(TraceExceptionsOnly = true)]
    public class UserLogic : LogicBase
    {
        private UserAccountService m_UaService;
        private AuthenticationService m_AuthSvc;
        private DataLogic m_DataLogic;
        IEventPublishClient m_EventPublishClient;
        public UserLogic(UserAccountService uaService, AuthenticationService authSvc, DataLogic dataLogic, ILogger logger, ICacheProvider cacheProvider, IEventPublishClient eventPublishClient)
            : base(logger, cacheProvider)
        {
            m_UaService = uaService;
            m_AuthSvc = authSvc;
            m_DataLogic = dataLogic;
            m_EventPublishClient = eventPublishClient;
        }

        public UserLoginValidation AuthenticateUser(string username, string password)
        {
            BrockAllen.MembershipReboot.UserAccount account = this.GetBAUserAccountByUsername(username);

            var decodedPassword = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(password));

            UserLoginValidation result = m_UaService.AuthenticateWithUsername(account, username, decodedPassword);


            result.UserAccount = account;

            return result;
        }

        public List<UserDetailDTO> GetAllUserDetailDTO()
        {
            var dtoList = new List<UserDetailDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                //scope.DbContext.VUsers.ToList().ForEach(item =>
                //{
                //    var dto = new UserDetailDTO();

                //    dto.InjectFrom(item);

                //    dtoList.Add(dto);
                //});
            }

            return dtoList;
        }

        public List<vUserManagementDTO> GetAllUserManagementDTO(SortingPagingDto pagingDto,UserManagementCritieraDTO dto)
        {
            var dtoList = new List<vUserManagementDTO>();

            //if (dto != null)
            //{
            //    using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            //    {
            //        if (!string.IsNullOrEmpty(dto.SearchQuery))
            //        {
            //            if (dto.SearchQueryTargetProperties == null)
            //            {
            //                dto.SearchQueryTargetProperties = new List<PropertyInfo>();

            //                dto.RowObject.GetType().GetProperties().Where(item => item.PropertyType.Equals(typeof(string)))
            //                    .ToList().ForEach(pi => dto.SearchQueryTargetProperties.Add(pi));

            //            }
            //        }
            //        var predicate = LinqHelpers.BuildPredicate<VUserManagement,
            //           UserManagementCritieraDTO>(dto);

            //        scope.DbContext.VUserManagements.AsExpandable().Where(predicate)
            //       .OrderBy(item => item.Username).Skip(pagingDto.PageSize * pagingDto.PageNumber).Take(pagingDto.PageSize).ToList().ForEach(item =>
            //       {
            //           var udto = new vUserManagementDTO();
            //           udto.InjectFrom(item);
            //           dtoList.Add(udto);
            //       });

            //    }
            //}

            return dtoList;
        }

        public vUserManagementDTO GerUserManagementDTO(Guid userId)
        {
            Ensure.That(userId).IsNot(Guid.Empty);

            var dto = new vUserManagementDTO();

            //using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            //{
            //    var userDetail = scope.GetGenericRepository<VUserManagement, Guid>().Find(item => item.UserID.Equals(userId));

            //    dto.InjectFrom<NullableInjection>(userDetail);
            //}

            return dto;
        }

        public ContactDTO AddUser(ContactDTO dto)
        {
            Ensure.That(dto).IsNotNull();
            var userContact = new Contact();
            var userDetail = new UserAccountDetail();
           

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var userAccount = m_UaService.CreateAccount(dto.ContactName, RandomPasswordGenerator.Generate(10), dto.EmailAddress1, true, Guid.NewGuid());
                
                //user contact
                var contactRepos = scope.GetGenericRepository<Contact, Guid>();
                userContact.InjectFrom<NullableInjection>(dto);
                userContact.ContactID = Guid.NewGuid();
                userContact.ParentID = userAccount.ID;
                SetAuditFields<Contact>(userContact, true);
                contactRepos.Add(userContact);
                

                //create user account detail
                var userAccountDetailRepos = scope.GetGenericRepository<UserAccountDetail, Guid>();
                userDetail.InjectFrom<NullableInjection>(dto);
                userDetail.UserID = userAccount.ID;
                userDetail.UserDetailID = Guid.NewGuid();
                userDetail.Salutation = dto.Salutation;
                SetAuditFields<UserAccountDetail>(userDetail, true);
                userAccountDetailRepos.Add(userDetail);

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;

                var contactDTO = new ContactDTO();
                contactDTO.InjectFrom<NullableInjection>(userContact);

                return contactDTO;
            }
        }

        /// <summary>
        /// Reset for Temporary Accounts
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="newPassword"></param>
        public void ResetUserPassword(Guid userID, string newPassword)
        {
            var userAccount = m_UaService.GetByID(userID);

            if (userAccount.IsTemporaryAccount)
                m_UaService.SetPasswordAndClearVerificationKey(userID, newPassword);
            else
                m_UaService.SetPassword(userID, newPassword);
        }

        /// <summary>
        /// Applies only to Temporary Accounts at the moment
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool HasPasswordExpired(Guid userID)
        {
            bool expired = false;

            using (
                var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                expired =
                    scope.DbContext.UserAccounts.Any(
                        s => s.ID.Equals(userID) && !string.IsNullOrEmpty(s.VerificationKey) && (!s.LastLogin.HasValue || (s.LastLogin.HasValue && s.PasswordChanged > s.LastLogin.Value)));
            }

            return expired;
        }

        public void LockOrUnlockUser(Guid userId, bool lockUser)
        {
            Ensure.That(userId).IsNot(Guid.Empty);
            var user = new Bec.TargetFramework.Data.UserAccount();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var userRepos = scope.GetGenericRepository<Bec.TargetFramework.Data.UserAccount, Guid>();
                user = userRepos.Get(userId);

                if (lockUser)
                {
                    user.IsLoginAllowed = false;
                    user.FailedLoginCount = m_UaService.Configuration.AccountLockoutFailedLoginAttempts;
                }
                else
                {
                    user.IsLoginAllowed = true;
                    user.FailedLoginCount = 0;
                }

                userRepos.Update(user);
                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }

        public string ResetPasswordAndSetVerificationKey(Guid userId)
        {
            return m_UaService.ResetPasswordAndReturnVerificationKey(userId);
        }

        public void ResetPassword(string email)
        {
            var account = m_UaService.GetByEmail(email);
             m_UaService.ResetPassword(email);
        }
        [EnsureArgumentAspect]
        public bool IsUserExist(string userName)
        {
           
            bool exists = false;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger, false))
            {
                var repos = scope.GetGenericRepository<Bec.TargetFramework.Data.UserAccount, Guid>();
                exists = repos.Exists(x => x.Username.ToLower() == userName.ToLower());
            }

            return exists;
        }
        [EnsureArgumentAspect]
        public bool IsEmailExist(string email)
        {
           
            bool exists = false;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger, false))
            {
                var repos = scope.GetGenericRepository<Bec.TargetFramework.Data.UserAccount, Guid>();
                exists = repos.Exists(u => u.Email.ToLower() == email.ToLower() && u.IsAccountClosed == false && u.IsActive == true);
            }

            return exists;
        }

        public List<AddressDTO> GetUserAddresses(Guid contactID)
        {
            List<AddressDTO> addressList = new List<AddressDTO>();
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                var addresses = scope.DbContext.Addresses.Where(item => item.ParentID.Equals(contactID) && item.IsActive == true && item.IsDeleted == false).OrderBy(item=>item.Name).ToList();
                if (addresses.Count > 0)
                {
                    addresses.ForEach(item =>
                    {
                        AddressDTO dto = new AddressDTO();
                        dto.InjectFrom<NullableInjection>(item);
                        addressList.Add(dto);
                    });
                }
                return addressList;
            }
        }

        public List<BrockAllen.MembershipReboot.UserAccount> GetAllUserAccount()
        {
            List<BrockAllen.MembershipReboot.UserAccount> dtoList = new List<BrockAllen.MembershipReboot.UserAccount>();

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

                var uaDb = scope.DbContext.UserAccounts.Single(s => s.ID.Equals(key));

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


                var uaDb = scope.DbContext.UserAccounts.Where(s => s.Email.Equals(email) && s.IsActive == true && s.IsDeleted == false).ToList();

                if (uaDb.Count > 0)
                {
                    ua = new BrockAllen.MembershipReboot.UserAccount();

                    ua.InjectFrom<NullableInjection>(uaDb.First());

                    ua.PasswordResetSecrets = GetPasswordResetSecrets(uaDb.First().ID);
                }


                
            }

            return ua;

        }

        public BrockAllen.MembershipReboot.UserAccount GetBAUserAccountByEmailAndNotID(string email,Guid id)
        {
            BrockAllen.MembershipReboot.UserAccount ua = null;
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {


                var uaDb = scope.DbContext.UserAccounts.Where(s => s.Email.Equals(email) && !s.ID.Equals(id)).ToList();

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
                var uaDb = scope.DbContext.UserAccounts.SingleOrDefault(s => s.Username.Equals(username));

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
            List<UserAccountDTO> ua = new List<UserAccountDTO>();;
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                if(permanentAccountonly)
                    ua = UserAccountConverter.ToDtos(scope.DbContext.UserAccounts.Where(s =>s.Email.Equals(email) && s.IsActive == true && s.IsDeleted == false && s.IsTemporaryAccount == !permanentAccountonly));
                else
                    ua = UserAccountConverter.ToDtos(scope.DbContext.UserAccounts.Where(s => s.Email.Equals(email) && s.IsActive == true && s.IsDeleted == false));
            }
            return ua;
        }
        public UserAccountDTO GetUserAccountByUsername(string userName)
        {
            UserAccountDTO ua = new UserAccountDTO(); ;
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                ua = UserAccountConverter.ToDto(scope.DbContext.UserAccounts.SingleOrDefault(s => s.Username.Equals(userName)));
               
            }
            return ua;
        }

        public List<ContactDTO> GetUserContacts(Guid userId)
        {
            List<ContactDTO> ua = new List<ContactDTO>(); ;
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                ua = ContactConverter.ToDtos(scope.DbContext.Contacts.Where(s => s.ParentID.Equals(userId)));

            }
            return ua;
        }

        public List<BrockAllen.MembershipReboot.UserAccount> GetUserAccounts(Guid key)
        {
            BrockAllen.MembershipReboot.UserAccount ua = null;
            List<BrockAllen.MembershipReboot.UserAccount> accounts = new List<BrockAllen.MembershipReboot.UserAccount>();
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                var uaDb = scope.DbContext.UserAccounts.Where(s => s.ID.Equals(key)).ToList();
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
            List<UserAccountOrganisationDTO> userAccountOrganisations = new List<UserAccountOrganisationDTO>();
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                var organisations = scope.DbContext.UserAccountOrganisations.Where(item => item.UserID.Equals(accountID) && item.IsActive == true && item.IsDeleted == false).ToList();

                userAccountOrganisations = UserAccountOrganisationConverter.ToDtosWithRelated(organisations, 1);

                return userAccountOrganisations;
            }

        }

        private List<BrockAllen.MembershipReboot.PasswordResetSecret> GetPasswordResetSecrets(Guid userAccountID)
        {
            List<BrockAllen.MembershipReboot.PasswordResetSecret> dtoList = new List<BrockAllen.MembershipReboot.PasswordResetSecret>();
            using(var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                scope.DbContext.PasswordResetSecrets.Where(s =>
                    s.UserAccountID == userAccountID 
                    && s.IsActive == true 
                    && s.IsDeleted == false
                    ).ToList().ForEach(item =>
                    {
                        BrockAllen.MembershipReboot.PasswordResetSecret rs = new BrockAllen.MembershipReboot.PasswordResetSecret();

                        rs.InjectFrom<NullableInjection>(item);
                        //Get the question description as we will be only storing classificationtypeid in the passwordresetsecret
                        rs.Question = scope.GetGenericRepository<ClassificationType, int>().Get(item.QuestionID).Name;

                        dtoList.Add(rs);
                    });
            }
            return dtoList;
        }

        public BrockAllen.MembershipReboot.UserAccount CreateUserAccount()
        {
            return new BrockAllen.MembershipReboot.UserAccount();
        }

        public void AddUserAccount(BrockAllen.MembershipReboot.UserAccount user)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                Data.UserAccount ua = new Data.UserAccount();

                ua.InjectFrom<NullableInjection>(user);

                scope.DbContext.UserAccounts.Add(ua);

               var passwordResetSecretRepos = scope.GetGenericRepository<Bec.TargetFramework.Data.PasswordResetSecret, Guid>();
                if (user.PasswordResetSecrets.Count > 0)
                    user.PasswordResetSecrets.ForEach(it =>
                  {
                      var secret = new Bec.TargetFramework.Data.PasswordResetSecret();

                      secret.InjectFrom(it);
                      secret.UserAccountID = user.ID;
                      passwordResetSecretRepos.Add(secret);
                  });

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }

        public void RemoveUserAccount(BrockAllen.MembershipReboot.UserAccount user)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var uaDb = scope.DbContext.UserAccounts.Single(s => s.ID.Equals(user.ID));

                scope.DbContext.UserAccounts.Remove(uaDb);

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }

        public void UpdateUserAccount(BrockAllen.MembershipReboot.UserAccount user)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var uaDb = scope.DbContext.UserAccounts.Single(s => s.ID.Equals(user.ID));

                uaDb.InjectFrom<NullableInjection>(new IgnoreProps("ID"), user);

                var entry = scope.DbContext.Entry(uaDb);

                entry.State = System.Data.Entity.EntityState.Modified;

                var passwordResetSecretRepos = scope.GetGenericRepository<Bec.TargetFramework.Data.PasswordResetSecret, Guid>();

                if (user.PasswordResetSecrets.Count > 0)
                    user.PasswordResetSecrets.ForEach(it =>
                    {
                        var secret = scope.DbContext.PasswordResetSecrets.SingleOrDefault(s => s.PasswordResetSecretID.Equals(it.PasswordResetSecretID));
                        if (secret != null)
                        {
                            secret.InjectFrom(it);
                            secret.UserAccountID = user.ID;
                            passwordResetSecretRepos.Update(secret);
                        }
                        else
                        {
                            secret = new Bec.TargetFramework.Data.PasswordResetSecret();
                            secret.InjectFrom(it);
                            secret.UserAccountID = user.ID;
                            passwordResetSecretRepos.Add(secret);
                        }
                    });

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }

        public List<UserClaimDTO> GetUserClaims(Guid userId,Guid organisationID)
        {
            List<UserClaimDTO> list = new List<UserClaimDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var result = scope.DbContext.FnGetUserClaim(userId, organisationID);

                if (result != null)
                {
                    result.ToList().ForEach(item =>
                        {
                            UserClaimDTO dto = new UserClaimDTO();

                            dto.UserAccountID = userId;
                            dto.Type = item.ClaimType;
                            dto.Value = item.ClaimName;

                            list.Add(dto);

                        });
                }
            }

            return list;
        }

        public ContactDTO GetUserAccountOrganisationPrimaryContact(Guid uaoID)
        {
            ContactDTO userContact = null;
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                var contacts = scope.DbContext.Contacts.Where(item => item.IsPrimaryContact == true && item.ParentID == uaoID && item.IsActive == true && item.IsDeleted == false).ToList();

                Ensure.That(contacts.Count > 0).IsTrue();

                userContact = ContactConverter.ToDto(contacts.First());
            }

            return userContact;
        }

        public VUserAccountOrganisationUserTypeOrganisationTypeDTO GetUserAccountOrganisationUserTypeOrganisationType(Guid accountID, bool personalOrg)
        {
            VUserAccountOrganisationUserTypeOrganisationTypeDTO uaoUserTypeOrganisationType = new VUserAccountOrganisationUserTypeOrganisationTypeDTO();
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                var uaoUTypeOType = new VUserAccountOrganisationUserTypeOrganisationType();
                int orgType = (int)OrganisationTypeEnum.Personal;
                if (personalOrg)
                    uaoUTypeOType = scope.DbContext.VUserAccountOrganisationUserTypeOrganisationTypes.SingleOrDefault(item => item.UserID.HasValue && item.UserID.Value.Equals(accountID) && item.OrganisationTypeID.HasValue && item.OrganisationTypeID.Value.Equals(orgType));
                else
                    uaoUTypeOType = scope.DbContext.VUserAccountOrganisationUserTypeOrganisationTypes.SingleOrDefault(item => item.UserID.HasValue && item.UserID.Value.Equals(accountID) && item.OrganisationTypeID.HasValue && !(item.OrganisationTypeID.Value.Equals(orgType)));
                return VUserAccountOrganisationUserTypeOrganisationTypeConverter.ToDto(uaoUTypeOType);
            }

        }

        public List<VUserAccountOrganisationUserTypeOrganisationTypeDTO> GetUserAccountOrganisationWithUserTypeAndOrgType(Guid accountID)
        {
            List<VUserAccountOrganisationUserTypeOrganisationTypeDTO> list =
                new List<VUserAccountOrganisationUserTypeOrganisationTypeDTO>();

            VUserAccountOrganisationUserTypeOrganisationTypeDTO uaoUserTypeOrganisationType = new VUserAccountOrganisationUserTypeOrganisationTypeDTO();
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                list = VUserAccountOrganisationUserTypeOrganisationTypeConverter.ToDtos(
                    scope.DbContext.VUserAccountOrganisationUserTypeOrganisationTypes.Where(
                        s => s.UserID.HasValue && s.UserID.Value.Equals(accountID)));
            }

            return list;
        }

        public List<string> UserLoginSessions(Guid userId)
        {
            using (var entities = new TargetFrameworkEntities())
            {
                var results = entities.UserAccountLoginSessions.Where(item => !(item.UserHasLoggedOut ?? false) && item.UserAccountID.Equals(userId))
                   .Select(item => item.UserSessionID)
                   .ToList();

                return results;
            }
        }

        public void LogEveryoneElseOut(Guid userId, string sessionId)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var repos = scope.GetGenericRepository<UserAccountLoginSession, Guid, string>();

                repos.IsInScope = true;
                repos.FindAll(item => item.UserHasLoggedOut.Value == false && item.UserAccountID.Equals(userId) && !item.UserSessionID.Equals(sessionId)).ToList()
                .ForEach(item =>
                {
                    item.UserHasLoggedOut = true;
                });

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }

        public void SaveUserAccountLoginSession(Guid userId, string sessionId, string userHostAddress, string userIdAddress, string userLocation)
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

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
             }
        }

        public void SaveUserAccountLoginSessionData(Guid userId, string sessionId, Dictionary<string, string> requestData)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                // add session data
                var sessionData = new UserAccountLoginSessionDatum
                                      {
                                          UserAccountLoginSessionDataID = Guid.NewGuid(),
                                          RequestData = requestData.ToJson(),
                                          UserAccountID =  userId,
                                          UserSessionID =  sessionId
                                      };

                scope.DbContext.UserAccountLoginSessionData.Add(sessionData);
                
                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }

        public void LockUserTemporaryAccount(Guid tempUserId)
        {
            var tempAccount = m_UaService.GetByID(tempUserId);

            tempAccount.IsActive = false;
            tempAccount.IsDeleted = true;
            tempAccount.IsAccountClosed = true;
            tempAccount.IsLoginAllowed = false;

            m_UaService.Update(tempAccount);

            //using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            //{
            //    foreach(var uao in scope.DbContext.UserAccountOrganisations.Where(item => item.UserID.Equals(tempUserId) && item.IsActive == true && item.IsDeleted == false))
            //    {
            //        uao.IsActive = false;
            //        uao.IsDeleted = true;
            //    }
            //    if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());
            //}
        }

        public bool DoesUserExist(Guid userID,bool isTemporary)
        {
            bool result = false;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                result =
                    scope.DbContext.UserAccounts.Any(
                        s => s.ID.Equals(userID) && s.IsTemporaryAccount.Equals(isTemporary));
            }

            return result;
        }

        public UserAccountOrganisationDTO GetPermanentUAO(Guid userID)
        {
            UserAccountOrganisationDTO dto = null;
            int personalOrgTypeID = OrganisationTypeEnum.Personal.GetIntValue();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                var uaoEntry = scope.DbContext.VUserAccountOrganisationUserTypeOrganisationTypes.Single(
                    s => s.OrganisationTypeID.HasValue && s.OrganisationTypeID.Value.Equals(personalOrgTypeID)
                         && s.UserID.HasValue && s.UserID.Value.Equals(userID));

                dto =
                    UserAccountOrganisationConverter.ToDto(
                        scope.DbContext.UserAccountOrganisations.Single(
                            s => s.UserAccountOrganisationID.Equals(uaoEntry.UserAccountOrganisationID)));
            }

            return dto;
        }

        public Guid GetPersonalUserAccountOrganisation(Guid userId)

        {
             Guid uaoForTemp;

            using (
                var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                Guid userTypeGuid = UserTypeEnum.User.GetGuidValue();


                uaoForTemp =
                    scope.DbContext.VUserAccountOrganisationUserTypeOrganisationTypes.Single(
                        s => s.UserTypeID.HasValue && s.UserID.HasValue && s.UserID.Value.Equals(userId) &&
                            s.UserTypeID.Value.Equals(userTypeGuid) && s.OrganisationType.Equals("Personal")).UserAccountOrganisationID;
            }

            return uaoForTemp;
        }

        public BrockAllen.MembershipReboot.UserAccount CreateTemporaryAccount(string email, string password, bool temporaryAccount, Guid userId)
        {
            BrockAllen.MembershipReboot.UserAccount user = m_UaService.CreateAccount(m_DataLogic.GenerateRandomName(), password, email, temporaryAccount, userId); //RandomPasswordGenerator.Generate(10),
            
            return user;
        }
        public BrockAllen.MembershipReboot.UserAccount CreateAccount(string userName, string password, string email, bool temporaryAccount, Guid userId)
        {
            BrockAllen.MembershipReboot.UserAccount user = m_UaService.CreateAccount(userName, password, email, temporaryAccount, userId); 

            return user;
        }
        public void CreateContact(ContactDTO contactDTO)
        {
            Ensure.That(contactDTO).IsNotNull();
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing,this.Logger, true))
            {
                var contactRepos = scope.GetGenericRepository<Contact, Guid>();

                Contact contact = ContactConverter.ToEntity(contactDTO);
                SetAuditFields<Contact>(contact, true);
                contactRepos.Add(contact);
                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }
        public bool ContactExists(Guid parentID)
        {
            Ensure.That(parentID).IsNot(Guid.Empty);
            bool exists = false;
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger, true))
            {
                var contact = scope.DbContext.Contacts.SingleOrDefault(item => item.ParentID.Equals(parentID));
                if (contact != null)
                    exists = true;
            }
            return exists;
        }
        public void DeleteAccount(Guid userID)
        {
            m_UaService.DeleteAccount(userID);
        }
        public void CloseAccount(Guid userID)
        {
            m_UaService.CloseAccount(userID);
        }

        public  List<VUserAccountNotLoggedInDTO> GetUserAccountsNotLoggedIn()
        {
            List<VUserAccountNotLoggedInDTO> uaDtos = new List<VUserAccountNotLoggedInDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger, true))
            {
                scope.DbContext.VUserAccountNotLoggedIns.ToList()
                    .ForEach(s =>
                    {
                        uaDtos.Add(VUserAccountNotLoggedInConverter.ToDto(s));
                    });

            }

            return uaDtos;
        }

        public void SendUsernameReminder(string email)
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

                m_EventPublishClient.PublishEvent(dto);
            }
        }

        public void SendPasswordResetNotification(string username, string siteUrl)
        {
            //check user exists
            Data.UserAccount user = null;
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                user = scope.DbContext.UserAccounts.FirstOrDefault(s => s.Username.Equals(username) && !s.IsTemporaryAccount);
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
                    if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());
                }
                var uao = GetUserAccountOrganisation(user.ID).First();
                var primaryContact = GetUserAccountOrganisationPrimaryContact(uao.UserAccountOrganisationID);

                var tempDto = new ForgotPasswordDTO { 
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

                m_EventPublishClient.PublishEvent(dto);
            }
        }

        public Guid ExpirePasswordResetRequest(Guid requestID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var rr = GetResetRequest(scope, requestID);
                if (rr != null) rr.Expired = true;
                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());
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
