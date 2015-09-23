using Bec.TargetFramework.Data;
using Mehdime.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using System.Linq;
using EnsureThat;
using System;

namespace Bec.TargetFramework.TestsService.Controllers
{
    public class UserController : ApiController
    {
        public IDbContextScopeFactory DbContextScopeFactory { get; set; }
        public async Task<bool> AddAna()
        {
            //Guid? organisationId = null;
            //using (var scope = DbContextScopeFactory.Create())
            //{
            //    organisationId = scope.DbContexts.Get<TargetFrameworkEntities>()
            //        .FnCreateOrganisationFromDefault(31, Guid.Parse("6cd2a94e-61da-11e5-9721-00155d0a147a"), 1, "Anas Company",
            //        "Anas Company Description", "Test");
            //    Ensure.That(organisationId).IsNotNull();
            //}
            
            var result = false;
            var anaUserId = Guid.NewGuid();
            var anaUserContactId = Guid.NewGuid();
            var addressId = Guid.NewGuid();
            var organisationContactId = Guid.NewGuid();
            var workAddressTypeId = 4974; //Work
            int? professionalOrganisationType = 31; // ProfessionalOrganisation
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
                    Username = "Ana",
                    Email = "ana.qualified.administrator@beconsultancy.co.uk",
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
                    VerificationStorage = "ana.qualified.administrator@beconsultancy.co.uk",
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
                    EmailAddress1 = "ana.qualified.administrator@beconsultancy.co.uk",
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

//DECLARE AnaUserId uuid := (select uuid_generate_v1());
//DECLARE AnaUserContactId uuid := (select uuid_generate_v1());
//DECLARE AnaUserAccountOrganisationId uuid;

//DECLARE AddressId uuid := (select uuid_generate_v1());
//DECLARE OrganisationContactId uuid := (select uuid_generate_v1());
//DECLARE DefaultOrganisationId uuid := (
//    SELECT "DefaultOrganisationID"
//    FROM "DefaultOrganisation"
//    WHERE "Name" LIKE 'Professional Organisation'
//    LIMIT 1
//);

//DECLARE OrganisationId uuid;
//DECLARE WorkAddressTypeId integer := 4974; -- Work
//DECLARE ProfessionalOrganisationType integer := 31; -- ProfessionalOrganisation
//DECLARE OrganisationAdministratorUserTypeId uuid := '62885ba9-36ba-4035-836b-8e0c127098a2'; -- OrganisationAdministrator
//DECLARE OrganisationEmployeeRoleId uuid;
//BEGIN
//    -- ======================== ORGANISATION ========================

//    --  ============ CREATE PROFESSIONAL ORGANISATION  ============
//    OrganisationId := "fn_CreateOrganisationFromDefault"(ProfessionalOrganisationType, DefaultOrganisationId, 1, 'Default Company', 'Default Company Description', 'AutomatedScript');
//    OrganisationEmployeeRoleId := (
//        SELECT "OrganisationRoleID"
//        FROM "OrganisationRole"
//        WHERE "RoleName" LIKE 'Organisation Employee'
//        LIMIT 1
//    );

//    -- ============ CREATE CONTACT FOR ORGANISATION  ============
//    INSERT INTO public."Contact"(
//        "ContactID",
//        "ContactName",
//        "ParentID",
//        "IsPrimaryContact"
//    )
//    VALUES (
//        OrganisationContactId,
//        'Default Organisation Contact',
//        OrganisationId,
//        TRUE
//    );
//    INSERT INTO public."ContactRegulator"
//    (
//        "ContactID",
//        "RegulatorNumber",
//        "RegulatorName",
//        "RegulatorOtherName"
//    )
//    VALUES (
//        OrganisationContactID,
//        '123456',
//        'SRI',
//        'No Name'
//    );
//    INSERT INTO public."Address"
//    (
//        "AddressID",
//        "Name",
//        "Line1",
//        "Line2",
//        "County",
//        "PostalCode",
//        "ParentID",
//        "AddressTypeID",
//        "IsPrimaryAddress",
//        "AdditionalAddressInformation"
//    )
//    VALUES (
//        AddressId,
//        'Default Address',
//        'Default Address Line 1',
//        'Default Address Line 2',
//        'Default Address County',
//        'AA23 D34',
//        OrganisationContactId,
//        WorkAddressTypeId,
//        TRUE,
//        'Default Additional Address Information'
//    );

//    -- ======================== ANA ========================

//    -- ============ CREATE ANA USER ACCOUNT ============
//    INSERT INTO public."UserAccounts"
//    (
//        "ID",
//        "Tenant",
//        "Username",
//        "Email",
//        "Created",
//        "LastUpdated",
//        "RequiresPasswordReset",
//        "IsAccountVerified",
//        "IsLoginAllowed",
//        "IsAccountClosed",
//        "VerificationKey",
//        "VerificationPurpose",
//        "VerificationKeySent",
//        "HashedPassword",
//        "VerificationStorage",
//        "IsActive",
//        "IsDeleted",
//        "IsTemporaryAccount",
//        "CreatedOn",
//        "IsApproved",
//        "IsEmployee",
//        "IsForgotUsernameRequestAllowed",
//        "IsForgotPasswordRequestAllowed",
//        "AccountTwoFactorAuthMode",
//        "CurrentTwoFactorAuthStatus",
//        "FailedLoginCount"
//    )
//    VALUES (
//        AnaUserId,
//        'default',
//        'Ana',
//        'ana.qualified.administrator@beconsultancy.co.uk',
//        now(),
//        now(),
//        FALSE, -- RequiresPasswordReset
//        TRUE, -- IsAccountVerified
//        TRUE, -- IsLoginAllowed
//        FALSE, -- IsAccountClosed
//        '91F3AB4BDD90240A37BC4CE41F8B8AD55928AC19A484D112FBAE5A869684B468',
//        3,
//        now(),
//        '1F400.AF6d8CXT2jJcNPFdqPv7LLFxKZAzklBhi2/XWnd6+nMvLWDTZ6ejcLRVKCWk0eRtbw==',
//        'ana.qualified.administrator@beconsultancy.co.uk',
//        TRUE, -- IsActive
//        FALSE, -- IsDeleted
//        FALSE, -- IsTemporaryAccount,
//        now(),
//        TRUE, -- IsApproved,
//        FALSE, -- IsEmployee,
//        TRUE, -- IsForgotUsernameRequestAllowed,
//        TRUE, -- IsForgotPasswordRequestAllowed,
//        0, -- AccountTwoFactorAuthMode
//        0, -- "CurrentTwoFactorAuthStatus"
//        0 -- "FailedLoginCount"
//    );

//    -- ============ CREATE ANA USER ACCOUNT ============
//    -- Adds Ana to default roles
//    AnaUserAccountOrganisationId := (SELECT "fn_AddUserToOrganisation"(AnaUserId, OrganisationId, OrganisationAdministratorUserTypeId, OrganisationId, TRUE));

//    -- ============ UPDATE ASSIGNEMNT TO THE ORGANISATION
//    INSERT INTO public."Contact"(
//        "ContactID",
//        "ContactName",
//        "ParentID",
//        "IsPrimaryContact",
//        "Telephone1",
//        "FirstName",
//        "LastName",
//        "EmailAddress1",
//        "Salutation"
//    )
//    VALUES (
//        AnaUserContactId,
//        'Default Ana Contact',
//        AnaUserAccountOrganisationId,
//        TRUE,
//        '123455621',
//        'Ana',
//        'Qualified Administrator',
//        'ana.qualified.administrator@beconsultancy.co.uk',
//        'Mrs'
//    );
//    UPDATE "UserAccountOrganisation"
//    SET "PrimaryContactID" = AnaUserContactId
//    WHERE "UserAccountOrganisationID" = AnaUserAccountOrganisationId;



//END $$;
