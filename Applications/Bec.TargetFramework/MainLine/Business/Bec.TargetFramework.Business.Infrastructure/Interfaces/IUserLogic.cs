using BrockAllen.MembershipReboot;

namespace Bec.TargetFramework.Business.Infrastructure.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    using Bec.TargetFramework.Data.Infrastructure.Linq;
    //Bec.TargetFramework.Entities
    using Bec.TargetFramework.Infrastructure.Caching;
    using Bec.TargetFramework.Infrastructure.Log;
    using Bec.TargetFramework.Entities;
    using System.ServiceModel.Web;
    using System.Threading.Tasks;
    using Bec.TargetFramework.Entities.Enums;

    [ServiceContract(Namespace = Bec.TargetFramework.Business.Infrastructure.BecTargetFrameworkBusinessServiceNamespaces.BusinessNamespace + "/UserLogic")]
    public interface IUserLogic : IBusinessLogicService
    {
       
        [OperationContract]
        BrockAllen.MembershipReboot.UserAccount GetBAUserAccountByEmailAndNotID(string email, Guid id);

         [OperationContract]
        BrockAllen.MembershipReboot.UserAccount GetBAUserAccountByVerificationKey(string key);

        [OperationContract]
        BrockAllen.MembershipReboot.UserAccount GetBAUserAccountByEmail(string email);

        [OperationContract]
        BrockAllen.MembershipReboot.UserAccount GetBAUserAccountByUsername(string username);

        [OperationContract]
        UserLoginValidation AuthenticateUser(string username, string password);
        
        [OperationContract]
        List<VUserAccountOrganisationUserTypeOrganisationTypeDTO> GetUserAccountOrganisationWithUserTypeAndOrgType(
            Guid accountID);

        [OperationContract]
        ContactDTO GetUserAccountOrganisationPrimaryContact(Guid uaoID);


        //[OperationContract]

        //UserAccountOrganisationDTO GetTemporaryUAO(Guid userID);

        [OperationContract]

        UserAccountOrganisationDTO GetPermanentUAO(Guid userID);

        [OperationContract]
        bool DoesUserExist(Guid userID, bool isTemporary);

        [OperationContract]
        void LockUserTemporaryAccount(Guid tempUserId);

        //[OperationContract]
        //bool DoesTemporaryUserBelongToTempOrganisation(Guid userID);
        [OperationContract]
        bool DoesPermanentUserHavePersonalOrganisation(Guid userID);

        [OperationContract]
        Guid GetPersonalUserAccountOrganisation(Guid userId);

        [OperationContract]
        string ResetPasswordAndSetVerificationKey(Guid userId);

        [OperationContract]
        List<UserDetailDTO> GetAllUserDetailDTO();

        [OperationContract]
        UserAccountDTO GetUserAccountByUsername(string userName);
         [OperationContract]
        List<ContactDTO> GetUserContacts(Guid userId);

        [OperationContract]
        List<vUserManagementDTO> GetAllUserManagementDTO(SortingPagingDto pagingDto, UserManagementCritieraDTO dto);

        [OperationContract]
        int GetAllUserManagementDTOCount(SortingPagingDto pagingDto, UserManagementCritieraDTO dto);

        [OperationContract]
        vUserManagementDTO GerUserManagementDTO(Guid userId);

        [OperationContract]
        List<OrganisationRoleDTO> GetUserRoles(Guid userId, Guid orgId);

        [OperationContract]
        List<OrganisationRoleDTO> GetOrganisationRoles(Guid userId, Guid orgId);

        [OperationContract]
        List<OrganisationGroupDTO> GetUserGroups(Guid userId, Guid orgId);

        [OperationContract]
        List<OrganisationGroupDTO> GetOrganisationGroups(Guid userId, Guid orgId);

        [OperationContract]
        ContactDTO AddUser(ContactDTO dto);

        [OperationContract]
        void AddUserDetails(ContactDTO dto, string userType, string userCategory);

        [OperationContract]
        void UpdateUserStatus(Guid userId, bool delete = false);

        [OperationContract]
        void UpdateUser(ContactDTO dto);

        [OperationContract]
        ContactDTO EditUser(Guid userId);

        [OperationContract]
        void LockOrUnlockUser(Guid userId, bool lockUser);

        [OperationContract]
        void ResetPassword(string email);

        [OperationContract]
        bool IsUserExist(string userName);

        [OperationContract]
        bool IsEmailExist(string email);

        [OperationContract]
        List<AddressDTO> GetUserAddresses(Guid contactID);

        [OperationContract]
        void DeleteAddressToContact(Guid id);

        [OperationContract]
        void SaveUserRoles(Guid userId, List<OrganisationRoleDTO> selectedRoles);

        [OperationContract]
        void SaveUserGroups(Guid userId, List<OrganisationGroupDTO> selectedGroups);

         [OperationContract]

        List<BrockAllen.MembershipReboot.UserAccount> GetAllUserAccount();

         [OperationContract]
         BrockAllen.MembershipReboot.UserAccount GetUserAccount(Guid key);
         [OperationContract]
         List<BrockAllen.MembershipReboot.UserAccount> GetUserAccounts(Guid key);

         [OperationContract]
         BrockAllen.MembershipReboot.UserAccount CreateUserAccount();

         [OperationContract]
         void AddUserAccount(BrockAllen.MembershipReboot.UserAccount user);
         [OperationContract]
         void RemoveUserAccount(BrockAllen.MembershipReboot.UserAccount user);
         [OperationContract]
         void UpdateUserAccount(BrockAllen.MembershipReboot.UserAccount user);

        [OperationContract]
         List<UserClaimDTO> GetUserClaims(Guid userId, Guid organisationID);

        [OperationContract]
        List<string> UserLoginSessions(Guid userId);

        [OperationContract]
        void LogEveryoneElseOut(Guid userId, string sessionId);

        [OperationContract]
        void SaveUserAccountLoginSession(Guid userId, string sessionId, string userHostAddress, string userIdAddress, string userLocation);

         [OperationContract]
        void SaveUserAccountLoginSessionData(Guid userId, string sessionId, Dictionary<string, string> requestData);

        [OperationContract]
        BrockAllen.MembershipReboot.UserAccount CreateTemporaryAccount(string email,string password, bool temporaryAccount, Guid userId);

        [OperationContract]
        void DeleteAccount(Guid userID);

        [OperationContract]
        void CloseAccount(Guid userID);

        [OperationContract]
        List<UserAccountOrganisationDTO> GetUserAccountOrganisation(Guid accountID);

        //[OperationContract]
        //Guid? CreateAndAddUserToPersonalOrganisation(Guid userID);

        [OperationContract]
        VUserAccountOrganisationUserTypeOrganisationTypeDTO GetUserAccountOrganisationUserTypeOrganisationType(Guid accountID, bool personalOrg);

        [OperationContract]
        void CreateContact(ContactDTO contact);

        [OperationContract]
        bool ContactExists(Guid parentID);

        [OperationContract]
        Guid? AddUserToTemporaryOrganisation(Guid userID);

        [OperationContract]
        BrockAllen.MembershipReboot.UserAccount CreateAccount(string userName, string password, string email, bool temporaryAccount, Guid userId);

        [OperationContract]
        List<UserAccountDTO> GetUserAccountByEmail(string email, bool permanentAccountonly);

        [OperationContract]
        void ResetUserPassword(Guid userID, string newPassword);
        [OperationContract]
        List<VUserAccountNotLoggedInDTO> GetUserAccountsNotLoggedIn();

        [OperationContract]
        VUserAccountOrganisationDTO GetVUserAccountOrganisation(Guid userID);
        [OperationContract]
        void RemovePasswordResetSecret(Guid accountID, Guid PasswordResetSecretID);
        [OperationContract]
        void AddPasswordResetSecret(Guid accountID, string password, string question, string answer);
        

    }

}