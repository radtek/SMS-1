using Bec.TargetFramework.Data;
using Mehdime.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using System.Linq;
using EnsureThat;
using System;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Extensions;

namespace Bec.TargetFramework.TestsService.Controllers
{
    public class UserController : ApiController
    {
        public IDbContextScopeFactory DbContextScopeFactory { get; set; }
        public async Task<bool> AddAna(string username, string email)
        {
            var result = false;

            var anaUserId = Guid.NewGuid();
            var anaUserContactId = Guid.NewGuid();
            var addressId = Guid.NewGuid();
            var organisationContactId = Guid.NewGuid();
            var workAddressTypeId = AddressTypeIDEnum.Work.GetIntValue();
            var professionalOrganisationType = OrganisationTypeEnum.Professional.GetIntValue();
            var organisationAdministratorUserTypeId = Guid.Parse("62885ba9-36ba-4035-836b-8e0c127098a2"); // OrganisationAdministrator
            Guid? defaultOrganisationId;
            Guid? organisationId = null;
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var defaultOrganisation = scope.DbContexts.Get<TargetFrameworkEntities>().DefaultOrganisations.FirstOrDefault(o => o.Name == "Professional Organisation");
                Ensure.That(defaultOrganisation).IsNotNull();
                defaultOrganisationId = defaultOrganisation.DefaultOrganisationID;
            }
            using (var scope = DbContextScopeFactory.Create())
            {
                var organisationName = "Anas Company";
                var organisationDescription = "Anas Company Description";

                organisationId = scope.DbContexts.Get<TargetFrameworkEntities>()
                    .FnCreateOrganisationFromDefault(professionalOrganisationType, defaultOrganisationId, 1, organisationName, organisationDescription, typeof(UserController).Name);
                Ensure.That(organisationId).IsNotNull();

                // ============ CREATE PROFESSIONAL ORGANISATION  ============
                var organisationEmployeeRoleId = scope.DbContexts.Get<TargetFrameworkEntities>().OrganisationRoles.FirstOrDefault(o => o.RoleName == "Organisation Employee");

                // ============ CREATE CONTACT FOR ORGANISATION  ============
                var contact = new Contact
                {
                    ContactID = organisationContactId,
                    ContactName = "Default Organisation Contact",
                    ParentID = organisationId.Value,
                    IsPrimaryContact = true
                };
                scope.DbContexts.Get<TargetFrameworkEntities>().Contacts.Add(contact);

                var contactRegulator = new ContactRegulator
                {
                    ContactID = organisationContactId,
                    RegulatorNumber = "123456",
                    RegulatorName = "SRI",
                    RegulatorOtherName = "No Name"
                };
                scope.DbContexts.Get<TargetFrameworkEntities>().ContactRegulators.Add(contactRegulator);

                var address = new Address
                {
                    AddressID = addressId,
                    Name = "Default Address",
                    Line1 = "Default Address Line 1",
                    Line2 = "Default Address Line 2",
                    County = "Default County",
                    PostalCode = "AA23 D34",
                    ParentID = organisationContactId,
                    AddressTypeID = workAddressTypeId,
                    IsPrimaryAddress = true,
                    AdditionalAddressInformation = "Default Additional Address Information"
                };
                scope.DbContexts.Get<TargetFrameworkEntities>().Addresses.Add(address);

                var now = DateTime.Now;
                var userAccount = new UserAccount
                {
                    ID = anaUserId,
                    Tenant = "default",
                    Username = username,
                    Email = email,
                    Created = now,
                    LastUpdated = now,
                    RequiresPasswordReset = false, 
                    IsAccountVerified = true, 
                    IsLoginAllowed = true, 
                    IsAccountClosed = false, 
                    VerificationKey = "91F3AB4BDD90240A37BC4CE41F8B8AD55928AC19A484D112FBAE5A869684B468",
                    VerificationPurpose = 3,
                    VerificationKeySent = now,
                    HashedPassword = "1F400.AF6d8CXT2jJcNPFdqPv7LLFxKZAzklBhi2/XWnd6+nMvLWDTZ6ejcLRVKCWk0eRtbw==",
                    VerificationStorage = email,
                    IsActive = true,
                    IsDeleted = false, 
                    IsTemporaryAccount = false, 
                    CreatedOn = now,
                    IsApproved = true,
                    IsEmployee = false,
                    IsForgotUsernameRequestAllowed = true,
                    IsForgotPasswordRequestAllowed = true,
                    AccountTwoFactorAuthMode = 0,
                    CurrentTwoFactorAuthStatus = 0,
                    FailedLoginCount = 0 
                };
                scope.DbContexts.Get<TargetFrameworkEntities>().UserAccounts.Add(userAccount);

                await scope.SaveChangesAsync();
            }
            Guid? anaUserAccountOrganisationId = null;
            using (var scope = DbContextScopeFactory.Create())
            {
                // ============ CREATE ANA USER ACCOUNT ============
                anaUserAccountOrganisationId = scope.DbContexts.Get<TargetFrameworkEntities>()
                    .FnAddUserToOrganisation(anaUserId, organisationId, organisationAdministratorUserTypeId, organisationId, true);
                Ensure.That(anaUserAccountOrganisationId).IsNotNull();

                var anaContact = new Contact
                {
                    ContactID = anaUserContactId,
                    ContactName = "Default Ana Contact",
                    ParentID = anaUserAccountOrganisationId.Value,
                    IsPrimaryContact = true,
                    Telephone1 = "123455621",
                    FirstName = "Ana",
                    LastName = "Qualified Administrator",
                    EmailAddress1 = email,
                    Salutation = "Mrs"
                };
                scope.DbContexts.Get<TargetFrameworkEntities>().Contacts.Add(anaContact);

                var anaUserAccountOrganisation = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations.FirstOrDefault(u => u.UserAccountOrganisationID == anaUserAccountOrganisationId);
                Ensure.That(anaUserAccountOrganisation).IsNotNull();
                anaUserAccountOrganisation.PrimaryContactID = anaUserContactId;

                await scope.SaveChangesAsync();

                result = true;
            }

            return result;
        }
    }
}