DO $$
DECLARE FredUserId uuid := (select uuid_generate_v1());
DECLARE FredUserContactId uuid := (select uuid_generate_v1());
DECLARE FredUserAccountOrganisationId uuid;

DECLARE AdministrationOrganisationTypeId integer := 30; -- Administration
DECLARE UserUserTypeId uuid := '9e8ca436-2139-11e4-a37d-8771a20de3d2'; -- User
DECLARE OrganisationId uuid;
DECLARE FinanceAdministratorRoleId uuid;
BEGIN
	-- ======================== FRED ========================

	OrganisationId := (
        SELECT "OrganisationID"
        FROM "Organisation"
        WHERE "OrganisationTypeID" = AdministrationOrganisationTypeId
        LIMIT 1
    );

	FinanceAdministratorRoleId := (
        SELECT "OrganisationRoleID"
        FROM "OrganisationRole"
        WHERE "RoleName" LIKE 'Finance Administrator'
        LIMIT 1
    );

  	-- ============ CREATE USER ACCOUNT ============
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
        FredUserId,
        'default',
        'fred@bec.com',
        'fred@bec.com',
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
        'fred@bec.com',
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

    FredUserAccountOrganisationId := (SELECT "fn_AddUserToOrganisation"(FredUserId, OrganisationId, UserUserTypeId, OrganisationId, FALSE));

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
		FredUserContactId,
  		'Default Fred Contact',
  		FredUserAccountOrganisationId,
  		TRUE,
        '123455621',
        'Fred',
        'BEC Finance',
        'fred@bec.com',
        'Mrs'
	);
    UPDATE "UserAccountOrganisation"
    SET "PrimaryContactID" = FredUserContactId
    WHERE "UserAccountOrganisationID" = FredUserAccountOrganisationId;

	-- ============ Add to roles ============
	INSERT INTO public."UserAccountOrganisationRole"(
        "OrganisationRoleID",
        "IsActive",
        "IsDeleted",
        "UserAccountOrganisationID"
	)
	VALUES (
  		FinanceAdministratorRoleId,
  		TRUE, -- :IsActive,
  		FALSE, -- :IsDeleted,
  		FredUserAccountOrganisationId
	);

END $$;