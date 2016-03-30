
DROP VIEW vSafeSendRecipient;

--
-- vSafeSendRecipient
-- 

CREATE OR REPLACE VIEW vSafeSendRecipient AS
 SELECT uaot."SmsTransactionID" AS "ActivityID",
    803001 AS "ActivityTypeID",
    uao."UserAccountOrganisationID" AS "RelatedID",
    uao."OrganisationID",
    c."FirstName",
    c."LastName",
    NULL::character varying AS "OrganisationName",
    'Personal'::character varying AS "OrganisationTypeName",
    false AS "IsSafeSendGroup"
   FROM (((sms."SmsUserAccountOrganisationTransaction" uaot
     JOIN "UserAccountOrganisation" uao ON ((uaot."UserAccountOrganisationID" = uao."UserAccountOrganisationID")))
     JOIN "Contact" c ON ((uao."PrimaryContactID" = c."ContactID")))
     JOIN "UserAccounts" ua ON ((uao."UserID" = ua."ID")))
  WHERE ((((uao."IsActive" = true) AND (ua."IsActive" = true)) AND (ua."IsLoginAllowed" = true)) AND (ua."IsTemporaryAccount" = false))
UNION
 SELECT t."SmsTransactionID" AS "ActivityID",
    803001 AS "ActivityTypeID",
    uao."UserAccountOrganisationID" AS "RelatedID",
    o."OrganisationID",
    c."FirstName",
    c."LastName",
    od."Name" AS "OrganisationName",
    ot."Name" AS "OrganisationTypeName",
    false AS "IsSafeSendGroup"
   FROM ((((((sms."SmsTransaction" t
     JOIN "Organisation" o ON ((t."OrganisationID" = o."OrganisationID")))
     JOIN "OrganisationDetail" od ON ((o."OrganisationID" = od."OrganisationID")))
     JOIN "OrganisationType" ot ON ((o."OrganisationTypeID" = ot."OrganisationTypeID")))
     JOIN "UserAccountOrganisation" uao ON ((o."OrganisationID" = uao."OrganisationID")))
     JOIN "Contact" c ON ((uao."PrimaryContactID" = c."ContactID")))
     JOIN "UserAccounts" ua ON ((uao."UserID" = ua."ID")))
  WHERE ((((uao."IsActive" = true) AND (ua."IsActive" = true)) AND (ua."IsLoginAllowed" = true)) AND (ua."IsTemporaryAccount" = false))
UNION
 SELECT t."SmsTransactionID" AS "ActivityID",
    803001 AS "ActivityTypeID",
    f."SafeSendGroupID" AS "RelatedID",
    o."OrganisationID",
    f."Name" AS "FirstName",
    NULL::character varying(100) AS "LastName",
    od."Name" AS "OrganisationName",
    ot."Name" AS "OrganisationTypeName",
    true AS "IsSafeSendGroup"
   FROM (((((sms."SmsTransaction" t
     JOIN "Lender" l ON (((l."Name")::text = (t."LenderName")::text)))
     JOIN "Organisation" o ON ((l."OrganisationID" = o."OrganisationID")))
     JOIN "OrganisationDetail" od ON ((o."OrganisationID" = od."OrganisationID")))
     JOIN "OrganisationType" ot ON ((o."OrganisationTypeID" = ot."OrganisationTypeID")))
     JOIN "SafeSendGroup" f ON ((ot."OrganisationTypeID" = f."OrganisationTypeID")))
  WHERE (EXISTS ( SELECT uao."UserID",
            uao."OrganisationUnitID",
            uao."OrganisationID",
            uao."JobTitle",
            uao."NickName",
            uao."IsActive",
            uao."IsDeleted",
            uao."UserSubTypeID",
            uao."UserCategoryID",
            uao."UserAccountOrganisationID",
            uao."UserJobTypeID",
            uao."UserTypeID",
            uao."ParentID",
            uao."PrimaryContactID",
            uao."PinCode",
            uao."PinCreated",
            uao."PinAttempts",
            uao."RowVersion",
            ua."ID",
            ua."Tenant",
            ua."Username",
            ua."Email",
            ua."Created",
            ua."LastUpdated",
            ua."PasswordChanged",
            ua."RequiresPasswordReset",
            ua."MobileCode",
            ua."MobileCodeSent",
            ua."MobilePhoneNumber",
            ua."AccountTwoFactorAuthMode",
            ua."CurrentTwoFactorAuthStatus",
            ua."IsAccountVerified",
            ua."IsLoginAllowed",
            ua."IsAccountClosed",
            ua."AccountClosed",
            ua."LastLogin",
            ua."LastFailedLogin",
            ua."FailedLoginCount",
            ua."VerificationKey",
            ua."VerificationPurpose",
            ua."VerificationKeySent",
            ua."HashedPassword",
            ua."LastFailedPasswordReset",
            ua."FailedPasswordResetCount",
            ua."MobilePhoneNumberChanged",
            ua."VerificationStorage",
            ua."IsActive",
            ua."IsDeleted",
            ua."IsTemporaryAccount",
            ua."CreatedOn",
            ua."CreatedBy",
            ua."ModifiedOn",
            ua."ModifiedBy",
            ua."IsApproved",
            ua."IsEmployee",
            ua."FailedForgotUsernameAttempts",
            ua."FailedForgotPasswordAttempts",
            ua."IsForgotUsernameRequestAllowed",
            ua."IsForgotPasswordRequestAllowed",
            ua."LastForgotUsernameFailedAttempt",
            ua."LastForgotPasswordFailedAttempt",
            ua."RowVersion",
            ua."AccountCreated",
            uaossg."UserAccountOrganisationID",
            uaossg."SafeSendGroupID",
            uaossg."IsActive",
            uaossg."IsDeleted"
           FROM (("UserAccountOrganisation" uao
             JOIN "UserAccounts" ua ON ((uao."UserID" = ua."ID")))
             JOIN "UserAccountOrganisationSafeSendGroup" uaossg ON ((uao."UserAccountOrganisationID" = uaossg."UserAccountOrganisationID")))
          WHERE (((((((uao."OrganisationID" = o."OrganisationID") AND (uaossg."SafeSendGroupID" = f."SafeSendGroupID")) AND (uao."IsActive" = true)) AND (uao."IsDeleted" = false)) AND (ua."IsLoginAllowed" = true)) AND (ua."IsActive" = true)) AND (ua."IsTemporaryAccount" = false))))
UNION
 SELECT si."SupportItemID" AS "ActivityID",
    803003 AS "ActivityTypeID",
    uao."UserAccountOrganisationID" AS "RelatedID",
    uao."OrganisationID",
    c."FirstName",
    c."LastName",
    NULL::character varying AS "OrganisationName",
    'Personal'::character varying AS "OrganisationTypeName",
    false AS "IsSafeSendGroup"
   FROM ((("SupportItem" si
     JOIN "UserAccountOrganisation" uao ON ((si."UserAccountOrganisationID" = uao."UserAccountOrganisationID")))
     JOIN "Contact" c ON ((uao."PrimaryContactID" = c."ContactID")))
     JOIN "UserAccounts" ua ON ((uao."UserID" = ua."ID")))
  WHERE ((((uao."IsActive" = true) AND (ua."IsActive" = true)) AND (ua."IsLoginAllowed" = true)) AND (ua."IsTemporaryAccount" = false))
UNION
 SELECT si."SupportItemID" AS "ActivityID",
    803003 AS "ActivityTypeID",
    f."SafeSendGroupID" AS "RelatedID",
    uao."OrganisationID",
    f."Name" AS "FirstName",
    NULL::character varying(100) AS "LastName",
    od."Name" AS "OrganisationName",
    ot."Name" AS "OrganisationTypeName",
    true AS "IsSafeSendGroup"
   FROM ((((("SupportItem" si
     JOIN "UserAccountOrganisation" uao ON ((uao."OrganisationID" = si."OrganisationID")))
     JOIN "Organisation" o ON ((si."OrganisationID" = o."OrganisationID")))
     JOIN "OrganisationDetail" od ON ((o."OrganisationID" = od."OrganisationID")))
     JOIN "OrganisationType" ot ON ((o."OrganisationTypeID" = ot."OrganisationTypeID")))
     JOIN "SafeSendGroup" f ON ((ot."OrganisationTypeID" = f."OrganisationTypeID")))
  WHERE (EXISTS ( SELECT uao_1."UserID",
            uao_1."OrganisationUnitID",
            uao_1."OrganisationID",
            uao_1."JobTitle",
            uao_1."NickName",
            uao_1."IsActive",
            uao_1."IsDeleted",
            uao_1."UserSubTypeID",
            uao_1."UserCategoryID",
            uao_1."UserAccountOrganisationID",
            uao_1."UserJobTypeID",
            uao_1."UserTypeID",
            uao_1."ParentID",
            uao_1."PrimaryContactID",
            uao_1."PinCode",
            uao_1."PinCreated",
            uao_1."PinAttempts",
            uao_1."RowVersion",
            ua."ID",
            ua."Tenant",
            ua."Username",
            ua."Email",
            ua."Created",
            ua."LastUpdated",
            ua."PasswordChanged",
            ua."RequiresPasswordReset",
            ua."MobileCode",
            ua."MobileCodeSent",
            ua."MobilePhoneNumber",
            ua."AccountTwoFactorAuthMode",
            ua."CurrentTwoFactorAuthStatus",
            ua."IsAccountVerified",
            ua."IsLoginAllowed",
            ua."IsAccountClosed",
            ua."AccountClosed",
            ua."LastLogin",
            ua."LastFailedLogin",
            ua."FailedLoginCount",
            ua."VerificationKey",
            ua."VerificationPurpose",
            ua."VerificationKeySent",
            ua."HashedPassword",
            ua."LastFailedPasswordReset",
            ua."FailedPasswordResetCount",
            ua."MobilePhoneNumberChanged",
            ua."VerificationStorage",
            ua."IsActive",
            ua."IsDeleted",
            ua."IsTemporaryAccount",
            ua."CreatedOn",
            ua."CreatedBy",
            ua."ModifiedOn",
            ua."ModifiedBy",
            ua."IsApproved",
            ua."IsEmployee",
            ua."FailedForgotUsernameAttempts",
            ua."FailedForgotPasswordAttempts",
            ua."IsForgotUsernameRequestAllowed",
            ua."IsForgotPasswordRequestAllowed",
            ua."LastForgotUsernameFailedAttempt",
            ua."LastForgotPasswordFailedAttempt",
            ua."RowVersion",
            ua."AccountCreated",
            uaossg."UserAccountOrganisationID",
            uaossg."SafeSendGroupID",
            uaossg."IsActive",
            uaossg."IsDeleted"
           FROM (("UserAccountOrganisation" uao_1
             JOIN "UserAccounts" ua ON ((uao_1."UserID" = ua."ID")))
             JOIN "UserAccountOrganisationSafeSendGroup" uaossg ON ((uao_1."UserAccountOrganisationID" = uaossg."UserAccountOrganisationID")))
          WHERE (((((((uao_1."OrganisationID" = o."OrganisationID") AND (uaossg."SafeSendGroupID" = f."SafeSendGroupID")) AND (uao_1."IsActive" = true)) AND (uao_1."IsDeleted" = false)) AND (ua."IsLoginAllowed" = true)) AND (ua."IsActive" = true)) AND (ua."IsTemporaryAccount" = false))));

GRANT INSERT, SELECT, UPDATE, DELETE, TRUNCATE, REFERENCES, TRIGGER ON vSafeSendRecipient TO postgres;
GRANT INSERT, SELECT, UPDATE, DELETE, TRUNCATE, REFERENCES, TRIGGER ON vSafeSendRecipient TO sg_postgres_developer;
GRANT INSERT, SELECT, UPDATE, DELETE, REFERENCES ON vSafeSendRecipient TO sg_postgres_application;

GRANT DELETE, INSERT, REFERENCES, SELECT, TRIGGER, TRUNCATE, UPDATE ON vSafeSendRecipient TO bef; -- Add