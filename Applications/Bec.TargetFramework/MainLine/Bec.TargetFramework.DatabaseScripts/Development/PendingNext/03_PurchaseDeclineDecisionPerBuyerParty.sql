ALTER TABLE sms."SmsUserAccountOrganisationTransaction"
  ADD COLUMN "ProductAcceptedOn" TIMESTAMP(0) WITH TIME ZONE;
ALTER TABLE sms."SmsUserAccountOrganisationTransaction"
  ADD COLUMN "ProductDeclinedOn" TIMESTAMP(0) WITH TIME ZONE;

-- Migrate product accepted/declined on
UPDATE sms."SmsUserAccountOrganisationTransaction" uaot
SET "ProductAcceptedOn" = (
	SELECT "ProductAcceptedOn" 
    FROM sms."SmsTransaction" t
	WHERE t."SmsTransactionID" = uaot."SmsTransactionID"
    LIMIT 1);
    
UPDATE sms."SmsUserAccountOrganisationTransaction" uaot
SET "ProductDeclinedOn" = (
	SELECT "ProductDeclinedOn" 
    FROM sms."SmsTransaction" t
	WHERE t."SmsTransactionID" = uaot."SmsTransactionID"
    LIMIT 1);

ALTER TABLE sms."SmsTransaction"
  DROP COLUMN "ProductAcceptedOn";
ALTER TABLE sms."SmsTransaction"
  DROP COLUMN "ProductDeclinedOn";