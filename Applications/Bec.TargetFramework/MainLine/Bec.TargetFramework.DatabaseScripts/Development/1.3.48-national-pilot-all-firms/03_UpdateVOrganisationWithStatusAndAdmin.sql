-- =======================================================================
-- 1.3.48-national-pilot-all-firms\03_UpdateVOrganisationWithStatusAndAdmin
-- =======================================================================
-- object recreation
DROP VIEW public."vOrganisationWithStatusAndAdmin";

CREATE VIEW public."vOrganisationWithStatusAndAdmin"(
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
    "FilesPerMonth")
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
         org."FilesPerMonth"
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
                min(os."StatusChangedOn") AS "StatusChangedOn"
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
         verifiedjoin."StatusTypeVersionNumber"
  WHERE orgt."Name"::text ~~ 'Professional'::text AND
        orgc."ContactID" IS NOT NULL AND
        (ua."IsDeleted" IS NULL OR
        ua."IsDeleted" = false);

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."vOrganisationWithStatusAndAdmin" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."vOrganisationWithStatusAndAdmin" TO bef;

-- =======================================================================
-- END - 1.3.48-national-pilot-all-firms\03_UpdateVOrganisationWithStatusAndAdmin
-- =======================================================================
