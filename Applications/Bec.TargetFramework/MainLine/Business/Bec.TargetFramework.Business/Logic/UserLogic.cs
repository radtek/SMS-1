using System;
using System.Collections.Generic;
using System.Linq;
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
    using Bec.TargetFramework.Business.Infrastructure.Interfaces;
    using Bec.TargetFramework.Entities;
    using System.ServiceModel;
    using EnsureThat;
    using Bec.TargetFramework.Entities.Enums;

    [Trace(TraceExceptionsOnly = true)]
    public class UserLogic : LogicBase, IUserLogic
    {
        private UserAccountService m_UaService;
        private AuthenticationService m_AuthSvc;
        private IDataLogic m_DataLogic;
        public UserLogic(UserAccountService uaService, AuthenticationService authSvc, IDataLogic dataLogic,  ILogger logger, ICacheProvider cacheProvider)
            : base(logger, cacheProvider)
        {
            m_UaService = uaService;
            m_AuthSvc = authSvc;
            m_DataLogic = dataLogic;
        }

       

        public Task<UserLoginValidation> AuthenticateUser(string username, string password)
        {
            BrockAllen.MembershipReboot.UserAccount account = this.GetBAUserAccountByUsername(username);

            UserLoginValidation result = m_UaService.AuthenticateWithUsername(account, username, password);


            result.UserAccount = account;

            return Task.FromResult(result);
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

        public int GetAllUserManagementDTOCount(SortingPagingDto pagingDto, UserManagementCritieraDTO dto)
        {
            int count = 0;

            //if (dto != null)
            //{
            //    using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            //    {
            //        var predicate = LinqHelpers.BuildPredicate<VUserManagement,
            //            UserManagementCritieraDTO>(dto);

            //        count = scope.DbContext.VUserManagements.AsExpandable().Where(predicate).Count();
            //    }
            //}

            return count;
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

        /// <summary>
        /// Get user's roles
        /// </summary>
        /// <param name="userId">userid</param>
        /// <param name="orgId">organisationid</param>
        /// <returns>OrganisationRoleDTO</returns>
        public List<OrganisationRoleDTO> GetUserRoles(Guid userId, Guid orgId)
        {
            var list = new List<OrganisationRoleDTO>();

            //using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            //{
            //    var userRoles = scope.DbContext.UserAccountOrganisationRoles
            //                    .Include("OrganisationRole").Where(item => item.OrganisationRole.OrganisationID.Equals(orgId) && item.UserID.Equals(userId)).ToList();

            //    userRoles.ForEach(item =>
            //        {
            //            OrganisationRoleDTO li = new OrganisationRoleDTO();
            //            li.InjectFrom<NullableInjection>(item.OrganisationRole);
            //            list.Add(li);
            //        });
            //}
            return list;
        }

        /// <summary>
        /// get organisation's roles by organisationid      
        /// </summary>
        /// <param name="userId">userid</param>
        /// <param name="orgId">organisationid</param>
        /// <returns>OrganisationRoleDTO</returns>
        public List<OrganisationRoleDTO> GetOrganisationRoles(Guid userId, Guid orgId)
        {
            var list = new List<OrganisationRoleDTO>();

            //using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            //{
            //    var orgRoles = scope.DbContext.OrganisationRoles.Where(item => item.OrganisationID.Equals(orgId)).ToList();
            //    orgRoles.ToList().ForEach(item =>
            //    {
            //        var existingRoles = scope.DbContext.UserAccountOrganisationRoles.Where(role=>role.OrganisationRoleID.Equals(item.OrganisationRoleID) && role.UserID.Equals(userId)).ToList();
            //        if(existingRoles.Count == 0)
            //        {
            //            OrganisationRoleDTO li = new OrganisationRoleDTO();
            //            li.InjectFrom<NullableInjection>(item);
            //            list.Add(li);
            //        }
                  
            //    });
            //}
            return list;
        }

        /// <summary>
        /// Get user's groups
        /// </summary>
        /// <param name="userId">userid</param>
        /// <param name="orgId">organisationid</param>
        /// <returns>OrganisationGroupDTO</returns>
        public List<OrganisationGroupDTO> GetUserGroups(Guid userId, Guid orgId)
        {
            var list = new List<OrganisationGroupDTO>();

            //using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            //{
            //    var userGroups = scope.DbContext.UserAccountOrganisationGroups
            //                    .Include("OrganisationGroup").Where(item => item.OrganisationGroup.OrganisationID.Equals(orgId) && item.UserID.Equals(userId)).ToList();

            //    userGroups.ForEach(item =>
            //    {
            //        OrganisationGroupDTO li = new OrganisationGroupDTO();
            //        li.InjectFrom<NullableInjection>(item.OrganisationGroup);
            //        list.Add(li);
            //    });
            //}
            return list;
        }

        /// <summary>
        /// Get organisation groups by organisationId
        /// </summary>
        /// <param name="userId">userid</param>
        /// <param name="orgId">organisationid</param>
        /// <returns>OrganisationGroupDTO</returns>
        public List<OrganisationGroupDTO> GetOrganisationGroups(Guid userId, Guid orgId)
        {
            var list = new List<OrganisationGroupDTO>();
            //using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            //{
            //    var orgGroups = scope.DbContext.OrganisationGroups.Where(item => item.OrganisationID.Equals(orgId)).ToList();
            //    orgGroups.ToList().ForEach(item =>
            //    {
            //        var existingGroups = scope.DbContext.UserAccountOrganisationGroups.Where(grp => grp.OrganisationGroupID.Equals(item.OrganisationGroupID) && grp.UserID.Equals(userId)).ToList();
            //        if (existingGroups.Count == 0)
            //        {
            //            OrganisationGroupDTO li = new OrganisationGroupDTO();
            //            li.InjectFrom<NullableInjection>(item);
            //            list.Add(li);
            //        }

            //    });
            //}
            return list;
        }

        public void UpdateUserStatus(Guid userId, bool delete=false)
        {
            Ensure.That(userId).IsNot(Guid.Empty);
            var user = new Bec.TargetFramework.Data.UserAccount();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var userRepos = scope.GetGenericRepository<Bec.TargetFramework.Data.UserAccount, Guid>();
                user = userRepos.Get(userId);

                if (delete)
                {
                    user.IsDeleted = true;
                }
                else
                {
                    if (user.IsActive)
                    {
                        user.IsActive = false;
                    }
                    else
                    {
                        user.IsActive = true;
                    }
                }

                userRepos.Update(user);
                scope.Save(); 
            }
        }

        /// <summary>
        /// create a new user
        /// </summary>
        /// <param name="dto">contact dto</param>
        /// <returns>contact dto</returns>
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

                scope.Save();

                var contactDTO = new ContactDTO();
                contactDTO.InjectFrom<NullableInjection>(userContact);

                return contactDTO;
            }
        }

        public void AddUserDetails(ContactDTO dto, string userType, string userCategory)
        {
            //Ensure.That(dto);
            //var userDetail = new UserAccountDetail();
            //var userUnit = new UserAccountOrganisationUnit();
            //Guid orgId = string.IsNullOrEmpty(dto.OrganisationID) ? Guid.Empty : Guid.Parse(dto.OrganisationID);

            //using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            //{
            //    var addressRepos = scope.GetGenericRepository<Address, Guid>();
            //    userDetail = scope.DbContext.UserAccountDetails.Single(x => x.UserID.Equals(dto.ParentID));
            //    // useraccount organisationunit
            //    var dtoOrgUserStage = scope.DbContext.OrganisationUserStages.Single(x => x.OrganisationID.Equals(orgId) && x.Name.Equals("New") && x.IsActive);

            //    var userOrganisationUnitRepos = scope.GetGenericRepository<UserAccountOrganisationUnit, Guid, int>();
            //    userUnit.InjectFrom<NullableInjection>(dto);
            //    userUnit.UserAccountOrganisationUnitID = Guid.NewGuid();
            //    userUnit.UserID = dto.ParentID;
            //    userUnit.UserDetailID = userDetail.UserDetailID;
            //    userUnit.OrganisationUserStageID = dtoOrgUserStage.OrganisationUserStageID;
            //    userUnit.OrganisationID = Guid.Parse(dto.OrganisationID);

            //    if (dto.OrganisationUnitID.IsNotNullOrEmpty())
            //        userUnit.OrganisationUnitID = int.Parse(dto.OrganisationUnitID);
            //    userUnit.JobTitle = dto.JobTitle;
            //    userUnit.NickName = dto.NickName;
            //    if (userType.IsNotNullOrEmpty())
            //        userUnit.UserTypeID = int.Parse(userType);
            //    if (userCategory.IsNotNullOrEmpty())
            //        userUnit.UserCategoryID = int.Parse(userCategory);

            //    if (dto.OrganisationBranchID.IsNotNullOrEmpty())
            //        userUnit.OrganisationID = Guid.Parse(dto.OrganisationBranchID);

            //    userUnit.IsActive = true;
            //    SetAuditFields<UserAccountOrganisationUnit>(userUnit, true);
            //    userOrganisationUnitRepos.Add(userUnit);

            //    //user address
            //    if (dto.Addresses != null)
            //        dto.Addresses.ForEach(ad =>
            //      {
            //          var address = new Address();
            //          address.InjectFrom<NullableInjection>(ad);
            //          address.ParentID = dto.ContactID;
            //          address.AddressID = Guid.NewGuid();
            //          address.IsActive = true;
            //          SetAuditFields<Address>(address, true);
            //          addressRepos.Add(address);
            //      });


            //    scope.Save();
            //}

        }

        public void UpdateUser(ContactDTO dto)
        {
            //Ensure.That(dto);
            //var userDetail = new UserAccountDetail();
            //var userUnit = new UserAccountOrganisationUnit();
            //var userContact = new Contact();
            //var contact = new Contact();
            //var userManagement = new VUserManagement();


            //using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            //{
            //    var userManagementRepos = scope.GetGenericRepository<VUserManagement, Guid>();
            //    var userAccountDetailRepos = scope.GetGenericRepository<UserAccountDetail, Guid>();
            //    var userOrganisationUnitRepos = scope.GetGenericRepository<UserAccountOrganisationUnit, Guid, int>();
            //    var contactRepos = scope.GetGenericRepository<Contact, Guid>();

               
            //    if (dto.ParentID != Guid.Empty)
            //    {
            //        var userItems = userManagementRepos.Get(dto.ParentID);
            //        contact = contactRepos.Get(dto.ContactID);
            //        if (contact != null && !contact.EmailAddress1.Equals(dto.EmailAddress1))
            //        {
            //            m_UaService.ChangeEmailRequest(dto.ParentID, dto.EmailAddress1);
            //        }

            //        if (contact != null && !contact.ContactName.Equals(dto.ContactName))
            //        {
            //            m_UaService.ChangeUsername(dto.ParentID, dto.ContactName);
            //        }

            //        //create user account detail
            //        userDetail.InjectFrom<NullableInjection>(userItems);
            //        userAccountDetailRepos.Update(userDetail);

            //        // useraccount organisationunit
            //        //userUnit.InjectFrom<NullableInjection>(userItems);
            //        //userUnit.JobTitle = dto.JobTitle;
            //        //userUnit.NickName = dto.NickName;
            //        //if (dto.OrganisationBranchID.IsNullOrEmpty())
            //        //    userUnit.OrganisationID = Guid.Parse(dto.OrganisationBranchID);

            //        //userOrganisationUnitRepos.Update(userUnit);

            //        //user contact
            //        userContact.InjectFrom<NullableInjection>(dto);
            //        contactRepos.Update(userContact);

            //        //user address
            //        if (dto.Addresses != null)
            //        {
            //            var addressRepos = scope.GetGenericRepository<Address, Guid>();
            //            dto.Addresses.ForEach(ad =>
            //                {
            //                    var address = new Address();
            //                    address.InjectFrom<NullableInjection>(ad);
            //                    addressRepos.Add(address);
            //                    if (ad.AddressID.Equals(Guid.Empty))
            //            {
            //                        address.ParentID = dto.ContactID;
            //                address.AddressID = Guid.NewGuid();
            //                        address.IsActive = true;
            //                SetAuditFields<Address>(address, true);
            //                addressRepos.Add(address);
            //            }
            //            else
            //            {
            //                addressRepos.Update(address);
            //            }
            //                });
            //        }

            //    }

            //    scope.Save();
            //}
        }

        public ContactDTO EditUser(Guid userId)
        {
            var contact = new ContactDTO();
            var user = new vUserManagementDTO();
            //using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            //{
            //    var userRepository = scope.GetGenericRepository<VUserManagement, Guid>();
            //    var userItems = userRepository.Get(userId);
            //    user.InjectFrom<NullableInjection>(userItems);

            //    var contactItems = scope.GetGenericRepository<Contact, Guid>().Find(it => it.ParentID.Equals(userId));
            //    if (contactItems != null)
            //    {
            //        user.UserContact.InjectFrom<NullableInjection>(contactItems);
            //        contact.InjectFrom<NullableInjection>(contactItems);
            //        contact.OrganisationID = user.OrganisationID.ToString();
            //        contact.OrganisationBranchID = user.BranchID.ToString();
            //        contact.OrganisationUnitID = user.OrganisationUnitID.ToString();
            //    }
            //    var addresses = scope.DbContext.Addresses.Where(item => item.ParentID == contact.ContactID).ToList();
            //    addresses.ForEach(item => {
            //        contact.AddressListItems.Add(item.Name);
            //    });
            //    var addressItems = scope.GetGenericRepository<Address, Guid>().Find(it => it.ParentID.Equals(contact.ContactID));
            //    if (addressItems != null)
            //    {
            //        contact.CurrentAddress.InjectFrom<NullableInjection>(addressItems);
            //    }

            //}
            return contact;
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
                scope.Save();
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

        public void DeleteAddressToContact(Guid id)
        {
            var address = new Address();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var addressRepos = scope.GetGenericRepository<Address, Guid>();
                address = addressRepos.Get(id);
                address.IsDeleted = true;
                
                addressRepos.Update(address);
                scope.Save();
            }
        }

        public void SaveUserRoles(Guid userId, List<OrganisationRoleDTO> selectedRoles)
        {
            //Ensure.NotEqual(userId, Guid.Empty, "UserID cannot be empty guid");
            
            //using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            //{
            //    var userRoleRepos = scope.GetGenericRepository<UserAccountOrganisationRole, Guid>();
            //    var existingUserRoles = scope.DbContext.UserAccountOrganisationRoles.Where(role => role.UserID.Equals(userId)).ToList();

            //    //Delete unselected roles
            //    existingUserRoles.ForEach(role =>
            //    {
            //        var roleFound = selectedRoles.Find(r => r.OrganisationRoleID.Equals(role.OrganisationRoleID));
            //        if (roleFound == null)
            //        {
            //            userRoleRepos.Delete(role);
            //        }
            //        else
            //        {
            //            selectedRoles.Remove(roleFound);
            //        }

            //    });

            //    //Add selected roles
            //    //selectedRoles.ForEach(item =>
            //    //{
            //    //    var userRole = new UserAccountOrganisationRole();
            //    //    userRole.UserAccountOrganisationRoleID = Guid.NewGuid();
            //    //    userRole.UserID = userId;
            //    //    userRole.OrganisationRoleID = item.OrganisationRoleID;

            //    //    userRoleRepos.Add(userRole);
            //    //});

            //    scope.Save();
            //}
        }
        
        public void SaveUserGroups(Guid userId, List<OrganisationGroupDTO> selectedGroups)
        {
            //Ensure.NotEqual(userId, Guid.Empty, "UserID cannot be empty guid");

            //using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            //{
            //    var userGroupRepos = scope.GetGenericRepository<UserAccountOrganisationGroup, Guid>();
            //    var existingUserGroups = scope.DbContext.UserAccountOrganisationGroups.Where(role => role.UserID.Equals(userId)).ToList();

            //    //Delete unselected groups
            //    existingUserGroups.ForEach(grp =>
            //        {
            //            var grpFound = selectedGroups.Find(g => g.OrganisationGroupID.Equals(grp.OrganisationGroupID));
            //            if (grpFound==null)
            //            {
            //                userGroupRepos.Delete(grp);
            //            }
            //            else
            //            {
            //                selectedGroups.Remove(grpFound);
            //            }
                       
            //        });

            //    //Add selected groups
            //    //selectedGroups.ForEach(item =>
            //    //{
            //    //    var userGroup = new UserAccountOrganisationGroup();
            //    //    userGroup.UserAccountOrganisationGroupID = Guid.NewGuid();
            //    //    userGroup.UserID = userId;
            //    //    userGroup.OrganisationGroupID = item.OrganisationGroupID;

            //    //    userGroupRepos.Add(userGroup);
            //    //});

            //    scope.Save();
            //}
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

        public BrockAllen.MembershipReboot.UserAccount GetBAUserAccountByVerificationKey(string key)
        {
            BrockAllen.MembershipReboot.UserAccount ua = null;
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {


                var uaDb = scope.DbContext.UserAccounts.Where(s => s.VerificationKey.Equals(key)).ToList();

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

                userAccountOrganisations = UserAccountOrganisationConverter.ToDtos(organisations);

                return userAccountOrganisations;
            }

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
                 int orgType = (int) OrganisationTypeEnum.Personal;
                if(personalOrg)
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

                scope.Save();
            }
        }

        public void RemoveUserAccount(BrockAllen.MembershipReboot.UserAccount user)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                var uaDb = scope.DbContext.UserAccounts.Single(s => s.ID.Equals(user.ID));

                scope.DbContext.UserAccounts.Remove(uaDb);

                scope.Save();
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

                scope.Save();
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

        public List<string> UserLoginSessions(Guid userId)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                return scope.DbContext.UserAccountLoginSessions.Where(item => !(item.UserHasLoggedOut ?? false) && item.UserAccountID.Equals(userId))
                    .Select(item => item.UserSessionID)
                    .ToList();
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

                scope.Save();
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

                scope.Save();
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
                
                scope.Save();
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

        public bool DoesPermanentUserHavePersonalOrganisation(Guid userID)
        {
            bool result = false;
            int personalOrgTypeID = OrganisationTypeEnum.Personal.GetIntValue();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger, true))
            {
                result = scope.DbContext.VUserAccountOrganisationUserTypeOrganisationTypes.Any(
                    s => s.OrganisationTypeID.HasValue && s.OrganisationTypeID.Value.Equals(personalOrgTypeID)
                         && s.UserID.HasValue && s.UserID.Value.Equals(userID));
            }

            return result;
        }

        //[EnsureArgumentAspect]
        //public Guid? CreateAndAddUserToPersonalOrganisation(Guid userID)
        //{
        //    Guid? uaoID = null;

        //    Guid orgID = Guid.Empty;

        //    int personalOrgTypeID = OrganisationTypeEnum.Personal.GetIntValue();

        //    var doPersonalOrganisationTemplate = new VDefaultOrganisationUserTypeOrganisationType();

        //    //Get default organisation id for personal organisation
        //    using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
        //    {
        //        doPersonalOrganisationTemplate = scope.DbContext.VDefaultOrganisationUserTypeOrganisationTypes.Single(item => item.OrganisationTypeID.Equals(personalOrgTypeID));

        //        orgID = scope.DbContext.FnCreateOrganisationFromDefault(doPersonalOrganisationTemplate.OrganisationTypeID, doPersonalOrganisationTemplate.DefaultOrganisationID, doPersonalOrganisationTemplate.DefaultOrganisationVersionNumber, "Personal Organisation", "PersonalOrganisation").GetValueOrDefault();

        //        scope.Save();
        //    }

        //    // add user to personal organisation
        //    using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
        //    {
        //        var branches = m_OrganisationLogic.GetOrgansationBranchDTOs(orgID);

        //        Ensure.That(branches.Count > 0).IsTrue();

        //        //Add user to newly created personal organisation
        //        scope.DbContext.FnAddUserToOrganisation(userID, orgID, doPersonalOrganisationTemplate.UserTypeID, branches.First().OrganisationID);
        //        scope.Save();

        //        var organisationID = branches.First().OrganisationID;

        //        // get uao
        //        uaoID =
        //            scope.DbContext.UserAccountOrganisations.Single(
        //                s => s.UserID.Equals(userID) && s.OrganisationID.Equals(organisationID)).UserAccountOrganisationID;
        //    }

        //    return uaoID;

        //}

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
        public Guid? AddUserToTemporaryOrganisation(Guid userID)
        {
            Ensure.That(userID).IsNot(Guid.Empty);

            Guid? uaoForTemp = null;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                scope.DbContext.FnAddUserToTemporaryOrganisation(userID);
                scope.Save();

                // get temp branch
                var tempOrganisationGuid =
                    scope.DbContext.Organisations.Single(
                        s => 
                            s.OrganisationTypeID.Equals((int) OrganisationTypeEnum.Temporary)).OrganisationID;

                // get branch
                tempOrganisationGuid =
                    scope.DbContext.Organisations.Single(
                        s => s.ParentOrganisationID.HasValue &&
                            s.ParentOrganisationID.Value.Equals(tempOrganisationGuid)).OrganisationID;

                var tempGuid = UserTypeEnum.Temporary.GetGuidValue();

                // get uao entry for user
                uaoForTemp = scope.DbContext.UserAccountOrganisations.Single(
                    s =>
                        s.UserID.Equals(userID) && s.OrganisationID.Equals(tempOrganisationGuid) &&
                        s.UserTypeID.Equals(tempGuid)).UserAccountOrganisationID;
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
                scope.Save();
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

        public VUserAccountOrganisationDTO GetVUserAccountOrganisation(Guid userID)
        {
            VUserAccountOrganisationDTO userAccountOrganisations = new VUserAccountOrganisationDTO();
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, Logger))
            {
                var organisation = scope.DbContext.VUserAccountOrganisations.SingleOrDefault(item => item.ID.Equals(userID));

                userAccountOrganisations = VUserAccountOrganisationConverter.ToDto(organisation);

                return userAccountOrganisations;
            }

        }
        public void RemovePasswordResetSecret(Guid accountID, Guid PasswordResetSecretID)
        {
            m_UaService.RemovePasswordResetSecret(accountID, PasswordResetSecretID);
        }
        public void AddPasswordResetSecret(Guid accountID, string password, string question, string answer)
        {
            m_UaService.AddPasswordResetSecret(accountID, password, question, answer);
        }

    }
}
