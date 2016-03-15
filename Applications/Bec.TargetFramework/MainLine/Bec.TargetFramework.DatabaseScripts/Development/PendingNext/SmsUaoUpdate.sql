ALTER TABLE sms."SmsTransaction" ADD COLUMN "CreatedByUserAccountOrganisationID" UUID;

--attempt exact usernme match, then first 4 chars
update sms."SmsTransaction" tx set "CreatedByUserAccountOrganisationID" = (
select "UserAccountOrganisationID" from "UserAccountOrganisation" uao join "UserAccounts" ua on uao."UserID" = ua."ID"
 where ua."IsDeleted" = false and
  (ua."Username" = tx."CreatedBy" or 
  ("OrganisationID" = tx."OrganisationID" and lower(replace(ua."Username", '.', '')) like concat(lower(substring(tx."CreatedBy", 1, 4)), '%'))) limit 1
)

--tidy up any null values, set to org admin
update sms."SmsTransaction" tx set "CreatedByUserAccountOrganisationID" = (
select "UserAccountOrganisationID" from "UserAccountOrganisation" uao join "UserType" ut on uao."UserTypeID" = ut."UserTypeID"
 where uao."OrganisationID" = tx."OrganisationID" and ut."Name" = 'Organisation Administrator' limit 1
) where "CreatedByUserAccountOrganisationID" is null

ALTER TABLE sms."SmsTransaction" ALTER COLUMN "CreatedByUserAccountOrganisationID" SET NOT NULL;

ALTER TABLE sms."SmsTransaction" DROP COLUMN "CreatedBy";

ALTER TABLE sms."SmsTransaction"
  ADD CONSTRAINT "SmsTransaction_fkUserAccountOrganisation" FOREIGN KEY ("CreatedByUserAccountOrganisationID")
    REFERENCES public."UserAccountOrganisation"("UserAccountOrganisationID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;