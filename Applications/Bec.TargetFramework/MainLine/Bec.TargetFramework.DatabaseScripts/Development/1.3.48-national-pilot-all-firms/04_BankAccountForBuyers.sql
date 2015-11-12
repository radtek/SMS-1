-- =======================================================================
-- 1.3.48-national-pilot-all-firms\04_BankAccountForBuyers
-- =======================================================================

ALTER TABLE sms."SmsUserAccountOrganisationTransaction"
  ADD COLUMN "SrcFundsBankAccountSortCode" VARCHAR(10) DEFAULT '' NOT NULL;

ALTER TABLE sms."SmsUserAccountOrganisationTransaction"
  ADD COLUMN "SrcFundsBankAccountNumber" VARCHAR(20) DEFAULT '' NOT NULL;

-- =======================================================================
-- END - 1.3.48-national-pilot-all-firms\04_BankAccountForBuyers
-- =======================================================================
