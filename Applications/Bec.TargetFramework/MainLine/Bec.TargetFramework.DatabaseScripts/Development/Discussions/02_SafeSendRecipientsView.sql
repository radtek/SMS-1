
CREATE OR REPLACE VIEW public."vSafeSendRecipient"(
	"SmsTransactionID",
    "UserAccountOrganisationID",
    "OrganisationID",
    "FirstName",
    "LastName",
    "OrganisationName")
AS
  SELECT uaot."SmsTransactionID",
         uao."UserAccountOrganisationID",
         uao."OrganisationID",
         c."FirstName",
         c."LastName",
         NULL::character varying AS "OrganisationName"
  FROM sms."SmsUserAccountOrganisationTransaction" uaot
       JOIN "UserAccountOrganisation" uao ON uaot."UserAccountOrganisationID" =
         uao."UserAccountOrganisationID"
       JOIN "Contact" c ON uao."PrimaryContactID" = c."ContactID"
  WHERE uao."IsActive" = true
  UNION
  SELECT t."SmsTransactionID",
         uao."UserAccountOrganisationID",
         o."OrganisationID",
         c."FirstName",
         c."LastName",
         od."Name" AS "OrganisationName"
  FROM sms."SmsTransaction" t
       JOIN "Organisation" o ON t."OrganisationID" = o."OrganisationID"
       JOIN "OrganisationDetail" od ON o."OrganisationID" = od."OrganisationID"
       JOIN "UserAccountOrganisation" uao ON o."OrganisationID" =
         uao."OrganisationID"
       JOIN "Contact" c ON uao."PrimaryContactID" = c."ContactID"
  WHERE uao."IsActive" = TRUE;

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."vSafeSendRecipient" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."vSafeSendRecipient" TO bef;