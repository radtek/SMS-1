-- =======================================================================
-- 1.3.48-national-pilot-all-firms\02_AddAccountCreatedColumn
-- =======================================================================

--reports
ALTER TABLE public."UserAccounts" ADD COLUMN "AccountCreated" TIMESTAMP(0) WITH TIME ZONE;
update "UserAccounts" set "AccountCreated" = "PasswordChanged" where "IsTemporaryAccount" = false;
update "UserAccounts" a set "Created" = (select "Created" from "UserAccounts" b where b."IsTemporaryAccount" = true and b."Email" = a."Email") where a."IsTemporaryAccount" = false and EXISTS (select "Created" from "UserAccounts" b where b."IsTemporaryAccount" = true and b."Email" = a."Email");

-- =======================================================================
-- END - 1.3.48-national-pilot-all-firms\02_AddAccountCreatedColumn
-- =======================================================================
