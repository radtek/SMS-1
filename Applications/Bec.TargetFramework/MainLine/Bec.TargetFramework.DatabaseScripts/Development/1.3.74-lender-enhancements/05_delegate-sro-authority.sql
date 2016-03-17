-- =======================================================================
-- 05_delegate-sro-authority
-- =======================================================================

ALTER TABLE public."Organisation"
  ADD COLUMN "AuthorityDelegatedByContactID" UUID;

ALTER TABLE public."Organisation"
  ADD CONSTRAINT "Organisation_Contact_fk" FOREIGN KEY ("AuthorityDelegatedByContactID")
    REFERENCES public."Contact"("ContactID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;

	
DROP VIEW public."vOrganisationWithStatusAndAdmin";

CREATE VIEW public."vOrganisationWithStatusAndAdmin" (
    "OrganisationID",
    "Name",
    "CreatedOn",
    "CreatedBy",
    "OrganisationVerified",
    "PinCreated",
    "PinCode",
    "OrganisationAdminSalutation",
    "OrganisationAdminFirstName",
    "OrganisationAdminLastName",
    "OrganisationAdminTelephone",
    "OrganisationAdminEmail",
    "Regulator",
    "RegulatorOther",
    "RegulatorNumber",
    "Line1",
    "Line2",
    "Town",
    "County",
    "PostalCode",
    "AdditionalAddressInformation",
    "StatusTypeID",
    "StatusTypeValueID",
    "StatusTypeVersionNumber",
    "OrganisationAdminUserID",
    "StatusValueName",
    "StatusChangedOn",
    "StatusChangedBy",
    "Reason",
    "Notes",
    "OrganisationAdminCreated",
    "VerifiedOn",
    "VerifiedBy",
    "VerifiedNotes",
    "UserAccountOrganisationID",
    "RegisteredAsName",
    "OrganisationRecommendationSourceID",
    "SchemeID",
    "FilesPerMonth",
    "ActiveSafeAccounts",
	"PendingValidationAccounts",
    "OrganisationTypeDescription",
    "BrokerType",
    "BrokerBusinessType",
	"AuthorityDelegatedBySalutation",
	"AuthorityDelegatedByFirstName",
	"AuthorityDelegatedByLastName",
	"AuthorityDelegatedByEmail")
AS
SELECT org."OrganisationID",
    orgd."Name",
    org."CreatedOn",
    org."CreatedBy",
        CASE
            WHEN vst."Name"::text = 'Verified'::text THEN true
            ELSE false
        END AS "OrganisationVerified",
    uao."PinCreated",
    uao."PinCode",
    uaoc."Salutation" AS "OrganisationAdminSalutation",
    uaoc."FirstName" AS "OrganisationAdminFirstName",
    uaoc."LastName" AS "OrganisationAdminLastName",
    uaoc."Telephone1" AS "OrganisationAdminTelephone",
    ua."Email" AS "OrganisationAdminEmail",
    conreg."RegulatorName" AS "Regulator",
    conreg."RegulatorOtherName" AS "RegulatorOther",
    conreg."RegulatorNumber",
    addr."Line1",
    addr."Line2",
    addr."Town",
    addr."County",
    addr."PostalCode",
    addr."AdditionalAddressInformation",
    vorgs."StatusTypeID",
    vorgs."StatusTypeValueID",
    vorgs."StatusTypeVersionNumber",
    ua."ID" AS "OrganisationAdminUserID",
    vorgs."StatusValueName",
    vorgs."StatusChangedOn",
    vorgs."StatusChangedBy",
    vorgs."Reason",
    vorgs."Notes",
    ua."Created" AS "OrganisationAdminCreated",
    verifiedstatus."StatusChangedOn" AS "VerifiedOn",
    verifiedstatus."StatusChangedBy" AS "VerifiedBy",
    verifiedstatus."Notes" AS "VerifiedNotes",
    uao."UserAccountOrganisationID",
    orgd."RegisteredAsName",
    org."OrganisationRecommendationSourceID",
    org."SchemeID",
    org."FilesPerMonth",
    COALESCE(sb."ActiveSafeAccounts", 0::bigint) AS "ActiveSafeAccounts",
	COALESCE(pvb."PendingValidationAccounts", 0::bigint) AS "PendingValidationAccounts",
    orgt."Description" AS "OrganisationTypeDescription",
    org."BrokerType",
    org."BrokerBusinessType",
	adc."Salutation",
	adc."FirstName",
	adc."LastName",
	adc."EmailAddress1"
FROM "Organisation" org
       LEFT JOIN "OrganisationDetail" orgd ON orgd."OrganisationID" =
         org."OrganisationID"
       LEFT JOIN "OrganisationType" orgt ON orgt."OrganisationTypeID" =
         org."OrganisationTypeID"
       LEFT JOIN "vOrganisationStatus" vorgs ON vorgs."OrganisationID" =
         org."OrganisationID"
       LEFT JOIN "vStatusType" vst ON vst."StatusTypeID" = vorgs."StatusTypeID"
         AND vst."StatusTypeValueID" = vorgs."StatusTypeValueID" AND
         vst."StatusTypeVersionNumber" = vorgs."StatusTypeVersionNumber"
       LEFT JOIN "UserAccountOrganisation" uao ON uao."OrganisationID" =
         org."OrganisationID" AND uao."UserTypeID" =((
                                                       SELECT ut."UserTypeID"
                                                       FROM "UserType" ut
                                                       WHERE ut."Name"::text =
                                                         'Organisation Administrator'
                                                         ::text
                                                       LIMIT 1
       ))
       LEFT JOIN "Contact" orgc ON orgc."ParentID" = org."OrganisationID" AND
         orgc."IsPrimaryContact" = true
       LEFT JOIN "Contact" uaoc ON uaoc."ParentID" =
         uao."UserAccountOrganisationID" AND uaoc."IsPrimaryContact" = true
       LEFT JOIN "UserAccounts" ua ON ua."ID" = uao."UserID"
       LEFT JOIN "Address" addr ON addr."ParentID" = orgc."ContactID" AND
         addr."IsPrimaryAddress" = true
       LEFT JOIN "ContactRegulator" conreg ON conreg."ContactID" =
         orgc."ContactID"
       LEFT JOIN 
       (
         SELECT os."OrganisationID",
                os."StatusTypeID",
                os."StatusTypeValueID",
                os."StatusTypeVersionNumber",
                max(os."StatusChangedOn") AS "StatusChangedOn"
         FROM "OrganisationStatus" os
              JOIN "StatusType" st ON st."StatusTypeID" = os."StatusTypeID" AND
                st."Name"::text = 'Professional Organisation Status'::text
              JOIN "StatusTypeValue" sv ON sv."StatusTypeID" = os."StatusTypeID"
                AND sv."StatusTypeValueID" = os."StatusTypeValueID" AND
                sv."Name"::text = 'Verified'::text
         WHERE os."StatusTypeVersionNumber" = 1
         GROUP BY os."OrganisationID",
                  os."StatusTypeID",
                  os."StatusTypeValueID",
                  os."StatusTypeVersionNumber"
       ) verifiedjoin ON verifiedjoin."OrganisationID" = org."OrganisationID"
       LEFT JOIN "OrganisationStatus" verifiedstatus ON
         verifiedstatus."OrganisationID" = verifiedjoin."OrganisationID" AND
         verifiedstatus."StatusTypeID" = verifiedjoin."StatusTypeID" AND
         verifiedstatus."StatusTypeValueID" = verifiedjoin."StatusTypeValueID"
         AND verifiedstatus."StatusTypeVersionNumber" =
         verifiedjoin."StatusTypeVersionNumber" AND
         verifiedstatus."StatusChangedOn" = verifiedjoin."StatusChangedOn"
       LEFT JOIN 
       (
         SELECT ba."OrganisationID",
                count(ba."OrganisationBankAccountID") AS "ActiveSafeAccounts"
         FROM "OrganisationBankAccount" ba
         WHERE ba."IsActive" = true AND
               (((
                   SELECT st."Name"
                   FROM "OrganisationBankAccountStatus" s
                        LEFT JOIN "StatusTypeValue" st ON st."StatusTypeID" =
                          s."StatusTypeID" AND st."StatusTypeValueID" =
                          s."StatusTypeValueID"
                   WHERE s."OrganisationBankAccountID" =
                     ba."OrganisationBankAccountID"
                   ORDER BY s."StatusChangedOn" DESC
                   LIMIT 1
               ))::text) = 'Safe'::text
         GROUP BY ba."OrganisationID"
       ) sb ON sb."OrganisationID" = org."OrganisationID"
       LEFT JOIN 
       (
         SELECT ba."OrganisationID",
                count(ba."OrganisationBankAccountID") AS "PendingValidationAccounts"
         FROM "OrganisationBankAccount" ba
         WHERE (((
                   SELECT st."Name"
                   FROM "OrganisationBankAccountStatus" s
                        LEFT JOIN "StatusTypeValue" st ON st."StatusTypeID" =
                          s."StatusTypeID" AND st."StatusTypeValueID" =
                          s."StatusTypeValueID"
                   WHERE s."OrganisationBankAccountID" =
                     ba."OrganisationBankAccountID"
                   ORDER BY s."StatusChangedOn" DESC
                   LIMIT 1
               ))::text) = 'Pending Validation'::text
         GROUP BY ba."OrganisationID"
       ) pvb ON pvb."OrganisationID" = org."OrganisationID"
	   LEFT JOIN "Contact" adc ON org."AuthorityDelegatedByContactID" = adc."ContactID"
  WHERE (orgt."Name"::text <> ALL (ARRAY [ 'Temporary'::character varying::text,
    'Personal'::character varying::text, 'Administration'::character varying::
    text, 'Supplier'::character varying::text ])) AND
        orgc."ContactID" IS NOT NULL AND
        (ua."IsDeleted" IS NULL OR
        ua."IsDeleted" = false);

grant select, insert, update, delete on public."vOrganisationWithStatusAndAdmin" to bef;
grant select, insert, update, delete on public."vOrganisationWithStatusAndAdmin" to postgres;

-- =======================================================================
-- End - 05_delegate-sro-authority
-- =======================================================================
