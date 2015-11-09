-- =======================================================================
-- 1.3.48-national-pilot-all-firms\01_AddSmsBankAccountCheck
-- =======================================================================

-- SmsBankAccountCheck
CREATE TABLE sms."SmsBankAccountCheck" (
  "SmsBankAccountCheckID" UUID NOT NULL,
  "SmsUserAccountOrganisationTransactionID" UUID NOT NULL,
  "CheckedOn" TIMESTAMP WITH TIME ZONE NOT NULL,
  "IsMatch" BOOLEAN NOT NULL,
  PRIMARY KEY("SmsBankAccountCheckID")
);
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON sms."SmsBankAccountCheck" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON sms."SmsBankAccountCheck" TO bef;

ALTER TABLE sms."SmsBankAccountCheck"
  ADD CONSTRAINT "SmsBankAccountCheck_SmsUserAccountOrganisationTransaction_fk" FOREIGN KEY ("SmsUserAccountOrganisationTransactionID")
    REFERENCES sms."SmsUserAccountOrganisationTransaction"("SmsUserAccountOrganisationTransactionID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;

-- SmsUserAccountOrganisationTransaction "LatestBankAccountCheckID"
ALTER TABLE sms."SmsUserAccountOrganisationTransaction"
  ADD COLUMN "LatestBankAccountCheckID" UUID;

ALTER TABLE sms."SmsUserAccountOrganisationTransaction"
  ADD CONSTRAINT "SmsUserAccountOrganisationTransaction_SmsBankAccountCheck_fk" FOREIGN KEY ("LatestBankAccountCheckID")
    REFERENCES sms."SmsBankAccountCheck"("SmsBankAccountCheckID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;


ALTER TABLE sms."SmsUserAccountOrganisationTransaction"
  ALTER COLUMN "SmsUserAccountOrganisationTransactionTypeID" DROP DEFAULT;

-- =======================================================================
-- END - 1.3.48-national-pilot-all-firms\01_AddSmsBankAccountCheck
-- =======================================================================
