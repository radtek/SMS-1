-- =======================================================================
-- 1.3.48-national-pilot-all-firms\04_BankAccountForBuyers
-- =======================================================================

CREATE TABLE sms."SmsSrcFundsBankAccount" (
  "SmsSrcFundsBankAccountID" UUID NOT NULL,
  "SmsUserAccountOrganisationTransactionID" UUID NOT NULL,
  "AccountNumber" VARCHAR(20) NOT NULL,
  "SortCode" VARCHAR(10) NOT NULL,
  PRIMARY KEY("SmsSrcFundsBankAccountID")
) ;

ALTER TABLE sms."SmsSrcFundsBankAccount"
  ADD CONSTRAINT "SmsSrcFundsBankAccount_SmsUaot_fk" FOREIGN KEY ("SmsUserAccountOrganisationTransactionID")
    REFERENCES sms."SmsUserAccountOrganisationTransaction"("SmsUserAccountOrganisationTransactionID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON sms."SmsBankAccountCheck" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON sms."SmsBankAccountCheck" TO bef;

-- =======================================================================
-- END - 1.3.48-national-pilot-all-firms\04_BankAccountForBuyers
-- =======================================================================
