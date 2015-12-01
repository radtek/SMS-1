
CREATE OR REPLACE VIEW public."vSafeSendRecipient"(
	"SmsTransactionID",
    "UserAccountOrganisationID",
    "OrganisationID",
    "FirstName",
    "LastName",
    "OrganisationName")
AS
  SELECT 
      uaot."SmsTransactionID",
      uao."UserAccountOrganisationID",
      uao."OrganisationID",
      c."FirstName",
      c."LastName",
      NULL AS OrganisationName
  FROM sms."SmsUserAccountOrganisationTransaction" uaot
  JOIN "UserAccountOrganisation" uao on uaot."UserAccountOrganisationID" = uao."UserAccountOrganisationID"
  JOIN "Contact" c on uao."UserAccountOrganisationID" = c."ParentID"
  WHERE uao."IsActive" = TRUE
  UNION
  SELECT
      t."SmsTransactionID",
      uao."UserAccountOrganisationID",
      o."OrganisationID",
      c."FirstName",
      c."LastName",
      od."Name" AS OrganisationName
  FROM sms."SmsTransaction" t
  JOIN "Organisation" o on t."OrganisationID" = o."OrganisationID"
  JOIN "OrganisationDetail" od on o."OrganisationID" = od."OrganisationID"
  JOIN "UserAccountOrganisation" uao on o."OrganisationID" = uao."OrganisationID"
  JOIN "Contact" c on uao."UserAccountOrganisationID" = c."ParentID"
  WHERE uao."IsActive" = TRUE;

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."vSafeSendRecipient" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."vSafeSendRecipient" TO bef;