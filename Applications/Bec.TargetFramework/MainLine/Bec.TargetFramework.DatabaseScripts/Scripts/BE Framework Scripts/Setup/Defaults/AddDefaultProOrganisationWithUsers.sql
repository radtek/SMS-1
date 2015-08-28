DO $$
DECLARE AnaUserId uuid := (select uuid_generate_v1());
DECLARE AnaUserContactId uuid := (select uuid_generate_v1());
DECLARE AnaUserAccountOrganisationId uuid;

DECLARE Elvis1UserId uuid := (select uuid_generate_v1());
DECLARE Elvis1UserContactId uuid := (select uuid_generate_v1());
DECLARE Elvis1UserAccountOrganisationId uuid;

DECLARE Elvis2UserId uuid := (select uuid_generate_v1());
DECLARE Elvis2UserContactId uuid := (select uuid_generate_v1());
DECLARE Elvis2UserAccountOrganisationId uuid;

DECLARE AddressId uuid := (select uuid_generate_v1());
DECLARE OrganisationContactId uuid := (select uuid_generate_v1());
DECLARE DefaultOrganisationId uuid := (
	SELECT "DefaultOrganisationID"
    FROM "DefaultOrganisation"
    WHERE "Name" LIKE 'Professional Organisation'
    LIMIT 1
);

DECLARE OrganisationId uuid;
DECLARE WorkAddressTypeId integer := 4974; -- Work
DECLARE ProfessionalOrganisationType integer := 31; -- ProfessionalOrganisation
DECLARE OrganisationAdministratorUserTypeId uuid := '62885ba9-36ba-4035-836b-8e0c127098a2'; -- OrganisationAdministrator
DECLARE UserUserTypeId uuid := '9e8ca436-2139-11e4-a37d-8771a20de3d2'; -- User
DECLARE OrganisationEmployeeRoleId uuid;
BEGIN
	-- ======================== ORGANISATION ========================

	--  ============ CREATE PROFESSIONAL ORGANISATION  ============
	OrganisationId := "fn_CreateOrganisationFromDefault"(ProfessionalOrganisationType, DefaultOrganisationId, 1, 'Default Company', 'Default Company Description', 'AutomatedScript');
    OrganisationEmployeeRoleId := (
        SELECT "OrganisationRoleID"
        FROM "OrganisationRole"
        WHERE "RoleName" LIKE 'Organisation Employee'
        LIMIT 1
    );

	-- ============ CREATE CONTACT FOR ORGANISATION  ============
    INSERT INTO public."Contact"(
  		"ContactID",
  		"ContactName",
  		"ParentID",
  		"IsPrimaryContact"
	)
	VALUES (
  		OrganisationContactId,
  		'Default Organisation Contact',
  		OrganisationId,
  		TRUE
	);
    INSERT INTO public."ContactRegulator"
    (
		"ContactID",
      	"RegulatorNumber",
      	"RegulatorName",
      	"RegulatorOtherName"
    )
    VALUES (
      	OrganisationContactID,
      	'123456',
      	'SRI',
		'No Name'
    );
    INSERT INTO public."Address"
    (
        "AddressID",
        "Name",
        "Line1",
        "Line2",
        "County",
        "PostalCode",
        "ParentID",
        "AddressTypeID",
        "IsPrimaryAddress",
        "AdditionalAddressInformation"
    )
    VALUES (
    	AddressId,
        'Default Address',
        'Default Address Line 1',
        'Default Address Line 2',
        'Default Address County',
        'AA23 D34',
        OrganisationContactId,
        WorkAddressTypeId,
        TRUE,
        'Default Additional Address Information'
    );

	-- ======================== ANA ========================

  	-- ============ CREATE ANA USER ACCOUNT ============
    INSERT INTO public."UserAccounts"
	(
        "ID",
        "Tenant",
        "Username",
        "Email",
        "Created",
        "LastUpdated",
        "RequiresPasswordReset",
        "IsAccountVerified",
        "IsLoginAllowed",
        "IsAccountClosed",
        "VerificationKey",
        "VerificationPurpose",
        "VerificationKeySent",
        "HashedPassword",
        "VerificationStorage",
        "IsActive",
        "IsDeleted",
        "IsTemporaryAccount",
        "CreatedOn",
        "IsApproved",
        "IsEmployee",
        "IsForgotUsernameRequestAllowed",
        "IsForgotPasswordRequestAllowed",
        "AccountTwoFactorAuthMode",
        "CurrentTwoFactorAuthStatus",
        "FailedLoginCount"
    )
    VALUES (
        AnaUserId,
        'default',
        'Ana',
        'ana.qualified.administrator@beconsultancy.co.uk',
        now(),
        now(),
        FALSE, -- RequiresPasswordReset
        TRUE, -- IsAccountVerified
        TRUE, -- IsLoginAllowed
        FALSE, -- IsAccountClosed
        '91F3AB4BDD90240A37BC4CE41F8B8AD55928AC19A484D112FBAE5A869684B468',
        3,
        now(),
        '1F400.AF6d8CXT2jJcNPFdqPv7LLFxKZAzklBhi2/XWnd6+nMvLWDTZ6ejcLRVKCWk0eRtbw==',
        'ana.qualified.administrator@beconsultancy.co.uk',
        TRUE, -- IsActive
        FALSE, -- IsDeleted
        FALSE, -- IsTemporaryAccount,
        now(),
        TRUE, -- IsApproved,
        FALSE, -- IsEmployee,
        TRUE, -- IsForgotUsernameRequestAllowed,
        TRUE, -- IsForgotPasswordRequestAllowed,
        0, -- AccountTwoFactorAuthMode
        0, -- "CurrentTwoFactorAuthStatus"
		0 -- "FailedLoginCount"
    );

    -- ============ CREATE ANA USER ACCOUNT ============
  	-- Adds Ana to default roles
  	AnaUserAccountOrganisationId := (SELECT "fn_AddUserToOrganisation"(AnaUserId, OrganisationId, OrganisationAdministratorUserTypeId, OrganisationId, TRUE));

    -- ============ UPDATE ASSIGNEMNT TO THE ORGANISATION
    INSERT INTO public."Contact"(
  		"ContactID",
  		"ContactName",
  		"ParentID",
  		"IsPrimaryContact",
        "Telephone1",
        "FirstName",
        "LastName",
        "EmailAddress1",
        "Salutation"
	)
	VALUES (
		AnaUserContactId,
  		'Default Ana Contact',
  		AnaUserAccountOrganisationId,
  		TRUE,
        '123455621',
        'Ana',
        'Qualified Administrator',
        'ana.qualified.administrator@beconsultancy.co.uk',
        'Mrs'
	);
    UPDATE "UserAccountOrganisation"
    SET "PrimaryContactID" = AnaUserContactId
    WHERE "UserAccountOrganisationID" = AnaUserAccountOrganisationId;

	-- ======================== ELVIS1 ========================

	-- ============ CREATE ELVIS1 USER ACCOUNT ============
    INSERT INTO public."UserAccounts"
	(
        "ID",
        "Tenant",
        "Username",
        "Email",
        "Created",
        "LastUpdated",
        "RequiresPasswordReset",
        "IsAccountVerified",
        "IsLoginAllowed",
        "IsAccountClosed",
        "VerificationKey",
        "VerificationPurpose",
        "VerificationKeySent",
        "HashedPassword",
        "VerificationStorage",
        "IsActive",
        "IsDeleted",
        "IsTemporaryAccount",
        "CreatedOn",
        "IsApproved",
        "IsEmployee",
        "IsForgotUsernameRequestAllowed",
        "IsForgotPasswordRequestAllowed",
        "AccountTwoFactorAuthMode",
        "CurrentTwoFactorAuthStatus",
        "FailedLoginCount"
    )
    VALUES (
        Elvis1UserId,
        'default',
        'Elvis1',
        'elvis1.qualified.employee@beconsultancy.co.uk',
        now(),
        now(),
        FALSE, -- RequiresPasswordReset
        TRUE, -- IsAccountVerified
        TRUE, -- IsLoginAllowed
        FALSE, -- IsAccountClosed
        '91F3AB4BDD90240A37BC4CE41F8B8AD55928AC19A484D112FBAE5A869684B468',
        3,
        now(),
        '1F400.AF6d8CXT2jJcNPFdqPv7LLFxKZAzklBhi2/XWnd6+nMvLWDTZ6ejcLRVKCWk0eRtbw==',
        'elvis1.qualified.employee@beconsultancy.co.uk',
        TRUE, -- IsActive
        FALSE, -- IsDeleted
        FALSE, -- IsTemporaryAccount,
        now(),
        TRUE, -- IsApproved,
        FALSE, -- IsEmployee,
        TRUE, -- IsForgotUsernameRequestAllowed,
        TRUE, -- IsForgotPasswordRequestAllowed,
        0, -- AccountTwoFactorAuthMode
        0, -- "CurrentTwoFactorAuthStatus"
		0 -- "FailedLoginCount"
    );

  	-- ============ CREATE USER ACCOUNT ============
  	Elvis1UserAccountOrganisationId := (SELECT "fn_AddUserToOrganisation"(Elvis1UserId, OrganisationId, UserUserTypeId, OrganisationId, FALSE));

	-- ============ Add to roles ============
	INSERT INTO public."UserAccountOrganisationRole"(
        "OrganisationRoleID",
        "IsActive",
        "IsDeleted",
        "UserAccountOrganisationID"
	)
	VALUES (
  		OrganisationEmployeeRoleId,
  		TRUE, -- :IsActive,
  		FALSE, -- :IsDeleted,
  		Elvis1UserAccountOrganisationId
	);

    -- ============ UPDATE ASSIGNEMNT TO THE ORGANISATION
    INSERT INTO public."Contact"(
  		"ContactID",
  		"ContactName",
  		"ParentID",
  		"IsPrimaryContact",
        "Telephone1",
        "FirstName",
        "LastName",
        "EmailAddress1",
        "Salutation"
	)
	VALUES (
		Elvis1UserContactId,
  		'Default Elvis1 Contact',
  		Elvis1UserAccountOrganisationId,
  		TRUE,
        '123455621',
        'Elvis1',
        'Qualified Employee',
        'elvis1.qualified.employee@beconsultancy.co.uk',
        'Mr'
	);
    UPDATE "UserAccountOrganisation"
    SET "PrimaryContactID" = Elvis1UserContactId
    WHERE "UserAccountOrganisationID" = Elvis1UserAccountOrganisationId;

	-- ============ CREATE ELVIS2 USER ACCOUNT ============
    INSERT INTO public."UserAccounts"
	(
        "ID",
        "Tenant",
        "Username",
        "Email",
        "Created",
        "LastUpdated",
        "RequiresPasswordReset",
        "IsAccountVerified",
        "IsLoginAllowed",
        "IsAccountClosed",
        "VerificationKey",
        "VerificationPurpose",
        "VerificationKeySent",
        "HashedPassword",
        "VerificationStorage",
        "IsActive",
        "IsDeleted",
        "IsTemporaryAccount",
        "CreatedOn",
        "IsApproved",
        "IsEmployee",
        "IsForgotUsernameRequestAllowed",
        "IsForgotPasswordRequestAllowed",
        "AccountTwoFactorAuthMode",
        "CurrentTwoFactorAuthStatus",
        "FailedLoginCount"
    )
    VALUES (
        Elvis2UserId,
        'default',
        'Elvis2',
        'elvis2.qualified.employee@beconsultancy.co.uk',
        now(),
        now(),
        FALSE, -- RequiresPasswordReset
        TRUE, -- IsAccountVerified
        TRUE, -- IsLoginAllowed
        FALSE, -- IsAccountClosed
        '91F3AB4BDD90240A37BC4CE41F8B8AD55928AC19A484D112FBAE5A869684B468',
        3,
        now(),
        '1F400.AF6d8CXT2jJcNPFdqPv7LLFxKZAzklBhi2/XWnd6+nMvLWDTZ6ejcLRVKCWk0eRtbw==',
        'elvis2.qualified.employee@beconsultancy.co.uk',
        TRUE, -- IsActive
        FALSE, -- IsDeleted
        FALSE, -- IsTemporaryAccount,
        now(),
        TRUE, -- IsApproved,
        FALSE, -- IsEmployee,
        TRUE, -- IsForgotUsernameRequestAllowed,
        TRUE, -- IsForgotPasswordRequestAllowed,
        0, -- AccountTwoFactorAuthMode
        0, -- "CurrentTwoFactorAuthStatus"
		0 -- "FailedLoginCount"
    );

  	-- ============ CREATE USER ACCOUNT ============
  	Elvis2UserAccountOrganisationId := (SELECT "fn_AddUserToOrganisation"(Elvis2UserId, OrganisationId, UserUserTypeId, OrganisationId, FALSE));

	-- ============ Add to roles ============
	INSERT INTO public."UserAccountOrganisationRole"(
        "OrganisationRoleID",
        "IsActive",
        "IsDeleted",
        "UserAccountOrganisationID"
	)
	VALUES (
  		OrganisationEmployeeRoleId,
  		TRUE, -- :IsActive,
  		FALSE, -- :IsDeleted,
  		Elvis2UserAccountOrganisationId
	);

    -- ============ UPDATE ASSIGNEMNT TO THE ORGANISATION
    INSERT INTO public."Contact"(
  		"ContactID",
  		"ContactName",
  		"ParentID",
  		"IsPrimaryContact",
        "Telephone1",
        "FirstName",
        "LastName",
        "EmailAddress1",
        "Salutation"
	)
	VALUES (
		Elvis2UserContactId,
  		'Default Elvis2 Contact',
  		Elvis2UserAccountOrganisationId,
  		TRUE,
        '123455621',
        'Elvis2',
        'Qualified Employee',
        'elvis2.qualified.employee@beconsultancy.co.uk',
        'Mr'
	);
    UPDATE "UserAccountOrganisation"
    SET "PrimaryContactID" = Elvis2UserContactId
    WHERE "UserAccountOrganisationID" = Elvis2UserAccountOrganisationId;

END $$;