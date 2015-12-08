update "NotificationConstruct" set "NotificationSubject" = 'Bank Account Notification' where "Name" in ('BankAccountMarkedAsFraudSuspicious', 'BankAccountMarkedAsSafe');
update "NotificationConstruct" set "NotificationSubject" = 'Safe Buyer No Match Notification' where "Name" in ('BankAccountCheckNoMatch');

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (803002, E'BankAccount', NULL, 2081, NULL, True, False);

CREATE FUNCTION sms."fn_SmsTransactionRank" (
  orgid uuid,
  txid uuid
)
RETURNS integer AS
$body$
declare 
ret integer;
BEGIN
 ret = (
 select "Row" from (
  SELECT tx."SmsTransactionID", row_number() over (order by tx."CreatedOn" desc) as "Row"
  FROM sms."SmsTransaction" tx where tx."OrganisationID" = orgid
    ) t 
  where t."SmsTransactionID" = txid
  limit 1
  );
  return ret;
END;
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER;