ALTER TABLE sms."SmsTransaction" drop COLUMN "Confirmed";
ALTER TABLE sms."SmsUserAccountOrganisationTransaction" ADD COLUMN "Confirmed" BOOLEAN DEFAULT FALSE NOT NULL;

-- FOR OTHER ENVIRONMENTS
UPDATE "UserAccounts" ua
SET "Username" = "Email"
WHERE
	ua."IsTemporaryAccount" = FALSE OR
	NOT EXISTS (
		SELECT "Email"
		FROM "UserAccounts" ua1
		WHERE ua1."IsTemporaryAccount" = FALSE AND ua."Email" = ua1."Email"
	);


drop TABLE public."PasswordResetRequest";

ALTER TABLE public."OrganisationDetail" RENAME COLUMN "TradingName" TO "RegisteredAsName";
update "OrganisationDetail" set "RegisteredAsName" = "Name";

ALTER TABLE public."OrganisationBankAccount" ADD COLUMN "Name" VARCHAR;
ALTER TABLE public."OrganisationBankAccount" ADD COLUMN "Address" VARCHAR;

 -- object recreation
DROP VIEW public."vOrganisationBankAccountsWithStatus";

CREATE VIEW public."vOrganisationBankAccountsWithStatus"(
    "OrganisationID",
    "Name",
    "OrganisationBankAccountID",
    "BankAccountNumber",
    "SortCode",
    "Created",
    "Status",
    "Description",
    "IsActive",
    "StatusChangedOn",
    "StatusChangedBy",
    "Notes",
    "AccountName",
    "Address")
AS
  SELECT o."OrganisationID",
         ord."Name",
         ob."OrganisationBankAccountID",
         ob."BankAccountNumber",
         ob."SortCode",
         ob."Created",
         st."Name" AS "Status",
         st."Description",
         ob."IsActive",
         obs."StatusChangedOn",
         obs."StatusChangedBy",
         obs."Notes",
         ob."Name",
         ob."Address"
  FROM (
         SELECT "OrganisationBankAccountStatus"."OrganisationBankAccountID",
                max("OrganisationBankAccountStatus"."StatusChangedOn") AS
                  "StatusChangedOn"
         FROM "OrganisationBankAccountStatus"
         GROUP BY "OrganisationBankAccountStatus"."OrganisationBankAccountID"
       ) obslatest
       JOIN "OrganisationBankAccountStatus" obs ON
         obs."OrganisationBankAccountID" = obslatest."OrganisationBankAccountID"
         AND obs."StatusChangedOn" = obslatest."StatusChangedOn"
       JOIN "StatusTypeValue" st ON st."StatusTypeID" = obs."StatusTypeID" AND
         st."StatusTypeVersionNumber" = obs."StatusTypeVersionNumber" AND
         st."StatusTypeValueID" = obs."StatusTypeValueID"
       JOIN "OrganisationBankAccount" ob ON ob."OrganisationBankAccountID" =
         obslatest."OrganisationBankAccountID"
       JOIN "Organisation" o ON o."OrganisationID" = ob."OrganisationID"
       JOIN "OrganisationDetail" ord ON ord."OrganisationID" =
         o."OrganisationID";

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."vOrganisationBankAccountsWithStatus" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."vOrganisationBankAccountsWithStatus" TO bef;


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
    "RegisteredAsName")
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
         orgd."RegisteredAsName"
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

CREATE OR REPLACE FUNCTION public."fn_CreateOrganisationFromDefault" (
  organisationtypeid integer,
  defaultorganisationid uuid,
  organisationversionnumber integer,
  organisationname varchar,
  tradingname varchar,
  organisationdescription varchar,
  createdby varchar,
  organisationrecommendationsourceid integer
)
RETURNS uuid AS
$body$
Declare
  OrganisationID uuid;
  SchemeID integer;
  LoopRow RECORD;
begin
  OrganisationID := uuid_generate_v1();
  
  SchemeID := NULL;
  if(organisationtypeid <> 29) then
    begin  
      SchemeID := trunc(random() * 89999) + 10000;
      while exists (select "OrganisationID" from "Organisation" where "SchemeID" = SchemeID)
      loop
        SchemeID := trunc(random() * 89999) + 10000;
      end loop;
    end;
  end if;
  
  -- If no defaultorgid then determine from orgtypeid
  if(defaultorganisationid is null) then
    Begin
      defaultorganisationid := (
      select
        DOrg."DefaultOrganisationID"
      from
        "DefaultOrganisation" DOrg
        inner join "DefaultOrganisationTarget" DOT on DOrg."DefaultOrganisationVersionNumber" = DOT."DefaultOrganisationVersionNumber" and DOrg."DefaultOrganisationID" = DOT."DefaultOrganisationID"
          and DOT."OrganisationTypeID" = organisationtypeid
      limit
        1);
    End;
  End if;

  -- create new organisation

  INSERT INTO
    "Organisation"("OrganisationID", "IsBranch", "IsHeadOffice", "IsActive", "IsDeleted", "IsUserOrganisation", "DefaultOrganisationID", "DefaultOrganisationVersionNumber", "OrganisationTypeID", "CreatedBy", "OrganisationRecommendationSourceID", "SchemeID")
  SELECT
    OrganisationID,
    False,
    False,
    True,
    False,
    False,
    defaultorganisationid,
    organisationversionnumber,
    wt."OrganisationTypeID",
    createdby,
    organisationrecommendationsourceid,
    SchemeID
  FROM
    public."DefaultOrganisation" wt
  where
    wt."DefaultOrganisationID" = defaultorganisationid and
    wt."DefaultOrganisationVersionNumber" = organisationversionnumber;

  -- add org default

  INSERT INTO
    public."OrganisationDetail"("OrganisationID", "Name", "Description", "RegisteredAsName")
  VALUES
    (OrganisationID, organisationname, organisationdescription, tradingname);
 
  -- add payment methods
  INSERT INTO
  public."OrganisationPaymentMethod"
(
  "OrganisationID",
  "GlobalPaymentMethodID",
  "OrganisationBankAccountID",
  "IsActive",
  "IsDeleted",
  "IsDirectDebit",
  "IsBACS",
  "OrganisationDirectDebitMandateID",
  "IsPrimary",
  "StatusTypeID",
  "StatusTypeVersionNumber",
  "StatusTypeValueID",
  "DirectDebitMonthCollectionPeriodNumber",
  "BACSMonthPaymentDay",
  "DirectDebitNumberOfNotificationDaysBeforeCollection",
  "BACSNumberOfNotificationDaysBeforeExpectationOfPayment"
)
SELECT
  OrganisationID,
  wt."GlobalPaymentMethodID",
  null,
  true,
  false,
  pm."IsDirectDebit",
  (case when pm."IsDirectDebit" = false and pm."Name" <> 'BACS' then false else true end),
  null,
  (case when pm."Name" = 'BACS' then true else false end),
  st."StatusTypeID",
  st."StatusTypeVersionNumber",
  st."StatusTypeValueID",
  pm."DirectDebitDefaultMonthlyPeriodNumber",
  pm."BACSDefaultMonthlyPaymentDay",
  pm."DirectDebitDefaultNumberOfNotificationDaysBeforeCollection",
  pm."BACSDefaultNumberOfNotificationDaysBeforeExpectationOfPayment"
FROM
  public."DefaultOrganisationPaymentMethod" wt
 
  left outer join "GlobalPaymentMethod" pm on pm."GlobalPaymentMethodID" = wt."GlobalPaymentMethodID"
  left outer join "vStatusType" st on st."StatusTypeName" = 'OrganisationPaymentMethod Status' and st."IsStart" = true
                                              
 
  where wt."DefaultOrganisationID" = defaultorganisationid and wt."DefaultOrganisationVersionNumber" = organisationversionnumber
  and not exists (select * from "OrganisationPaymentMethod" dd where dd."OrganisationID" = OrganisationID and dd."GlobalPaymentMethodID" = wt."GlobalPaymentMethodID" limit 1)
  ;
 
-- add base financials
INSERT INTO
  public."OrganisationFinancialDetail"
(
  "OrganisationID",
  "FinancialStatusTypeID",
  "FinancialStatusTypeVersionNumber",
  "FinancialStatusTypeValueID",
  "HasACreditLimit",
  "CreditLimit",
  "NumberOfLatePayments",
  "HasLatePayments"
)
VALUES (
  OrganisationID,
  (select "StatusTypeID" from "vStatusType" st where st."StatusTypeName" = 'OrganisationFinancial Status' and st."IsStart" = true limit 1),
  (select "StatusTypeVersionNumber" from "vStatusType" st where st."StatusTypeName" = 'OrganisationFinancial Status' and st."IsStart" = true limit 1),
  (select "StatusTypeValueID" from "vStatusType" st where st."StatusTypeName" = 'OrganisationFinancial Status' and st."IsStart" = true limit 1),
  false,
  0,
  0,
  false
);


-- add accounting periods
INSERT INTO
  public."OrganisationAccountingPeriod"
(
  "OrganisationID",
  "GlobalAccountingPeriodID"
)
SELECT
  OrganisationID,
  wt."GlobalAccountingPeriodID"
FROM
  public."GlobalAccountingPeriod" wt
 
  where not exists (select * from "OrganisationAccountingPeriod" gp where gp."OrganisationID" = OrganisatioNID and gp."GlobalAccountingPeriodID" = wt."GlobalAccountingPeriodID" limit 1)
  ;
 
INSERT INTO
  public."OrganisationLedgerAccount"
(
  "LedgerAccountTypeID",
  "LedgerAccountCategoryID",
  "Name",
  "Description",
  "ParentID",
  "CreatedOn",
  "CreatedBy",
  "Balance",
  "HandlesCredit",
  "HandlesDebit",
  "OpenedOn",
  "IsActive",
  "IsDeleted",
  "OrganisationID",
  "AccountingTypeID"
)
SELECT
  wt."LedgerAccountTypeID",
  null,
  wt."LedgerAccountName",
  '',
  null,
  CURRENT_DATE,
  'System',
  0,
  wt."HandlesCredit",
  wt."HandlesDebit",
  CURRENT_DATE,
  true,
  false,
  OrganisationID,
  0
FROM
  public."DefaultOrganisationLedger" wt
  where
    wt."DefaultOrganisationID" = defaultorganisationid and
    wt."DefaultOrganisationVersionNumber" = organisationversionnumber
   
    and not exists(select * from "OrganisationLedgerAccount" le where le."LedgerAccountTypeID" = wt."LedgerAccountTypeID" and le."OrganisationID" = OrganisationID limit 1);



  -- create organisationroles which are not default organisation specific nad global, could be duplicates

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  select
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  from
    "Role" r
  where
    r."RoleID" in (
                    select
                      dor."RoleID"
                    from
                      "DefaultOrganisationRole" dor
                    where
                      dor."DefaultOrganisationID" = defaultorganisationid and
                      dor."IsActive" = true and
                      dor."IsDeleted" = false and
                      COALESCE(dor."IsDefaultOrganisationSpecific", false) = false
    ) and
    r."RoleID" not in (
                        select
                          org."ParentID"
                        from
                          "OrganisationRole" org
                        where
                          org."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false and
    r."IsGlobal" = true;

  -- add roleclaims which are not default organisation specific, parentID is RoleID, and are global roles

  insert into
    "OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  select
    org."OrganisationRoleID",
    rc."ResourceID",
    rc."OperationID",
    rc."StateID",
    rc."StateItemID",
    true,
    false,
    OrganisationID
  from
    "RoleClaim" rc
    inner join "OrganisationRole" org on org."OrganisationID" = OrganisationID and org."IsActive" = true and org."IsDeleted" = false and org."ParentID" = rc."RoleID"
  where
    rc."RoleID" =
    (
      select
        orgr."ParentID"
      from
        "OrganisationRole" orgr
      where
        orgr."OrganisationRoleID" = org."OrganisationRoleID"
    ) and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = org."OrganisationRoleID" and
                   orc."OperationID" = rc."OperationID" and
                   orc."ResourceID" = rc."ResourceID" and
                   orc."StateID" = rc."StateID" and
                   orc."StateItemID" = rc."StateItemID"
    );

  -- add do specific roles

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  select
    OrganisationID,
    dor."RoleName",
    true,
    dor."RoleTypeID",
    true,
    false,
    dor."DefaultOrganisationRoleID"
  from
    "DefaultOrganisationRole" dor
  where
    dor."IsActive" = true and
    dor."IsDeleted" = false and
    dor."IsDefaultOrganisationSpecific" = true and
    dor."DefaultOrganisationID" = defaultorganisationid and
    dor."DefaultOrganisationRoleID" not in (
                                             select
                                               dor1."ParentID"
                                             from
                                               "OrganisationRole" dor1
                                             where
                                               dor1."OrganisationID" = OrganisationID
    );

  -- add do specific claims

  insert into
    "OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  select
    org."OrganisationRoleID",
    rc."ResourceID",
    rc."OperationID",
    rc."StateID",
    rc."StateItemID",
    true,
    false,
    OrganisationID
  from
    "DefaultOrganisationRoleClaim" rc
    inner join "OrganisationRole" org on org."OrganisationID" = OrganisationID and org."ParentID" = rc."DefaultOrganisationRoleID" and org."IsActive" = true and org."IsDeleted" = FALSE
  where
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = org."OrganisationRoleID" and
                   orc."OperationID" = rc."OperationID" and
                   orc."ResourceID" = rc."ResourceID" and
                   orc."StateID" = rc."StateID" and
                   orc."StateItemID" = rc."StateItemID"
    );

  -- add global groups
  -- create organisationroles which are not default organisation specific and global

  insert into
    public."OrganisationGroup"("OrganisationID", "GroupName", "IsManaged", "GroupTypeID", "IsActive", "IsDeleted", "ParentID")
  select
    OrganisationID,
    r."GroupName",
    true,
    r."GroupTypeID",
    true,
    false,
    r."GroupID"
  from
    "Group" r
  where
    r."GroupID" in (
                     select
                       dor."GroupID"
                     from
                       "DefaultOrganisationGroup" dor
                     where
                       dor."DefaultOrganisationID" = defaultorganisationid and
                       dor."IsActive" = true and
                       dor."IsDeleted" = false and
                       COALESCE(dor."IsDefaultOrganisationSpecific", false) = false
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false and
    r."IsGlobal" = true and
    r."GroupID" not in (
                         select
                           rg."ParentID"
                         from
                           "OrganisationGroup" rg
                         where
                           rg."OrganisationID" = OrganisationID
    );

  -- add global group roles

  insert into
    "OrganisationGroupRole"("OrganisationGroupID", "OrganisationRoleID", "IsActive", "IsDeleted")
  select
    org."OrganisationGroupID",
    orgr."OrganisationRoleID",
    true,
    false
  from
    "GroupRole" rc
    inner join "OrganisationGroup" org on org."OrganisationID" = OrganisationID and org."ParentID" = rc."GroupID" and org."IsActive" = true and org."IsDeleted" = false
    inner join "OrganisationRole" orgr on orgr."OrganisationID" = OrganisationID and orgr."ParentID" = rc."RoleID" and orgr."IsActive" = true and orgr."IsDeleted" = false
  where
    rc."GroupID" =
    (
      select
        orgr."ParentID"
      from
        "OrganisationGroup" orgr
      where
        orgr."OrganisationGroupID" = org."OrganisationGroupID"
    );

  -- add do specific groups

  insert into
    public."OrganisationGroup"("OrganisationID", "GroupName", "IsManaged", "GroupTypeID", "IsActive", "IsDeleted", "ParentID")
  select
    OrganisationID,
    dor."GroupName",
    true,
    dor."GroupTypeID",
    true,
    false,
    dor."DefaultOrganisationGroupID"
  from
    "DefaultOrganisationGroup" dor
  where
    dor."IsActive" = true and
    dor."IsDeleted" = false and
    dor."IsDefaultOrganisationSpecific" = true and
    dor."DefaultOrganisationID" = defaultorganisationid and
    dor."DefaultOrganisationGroupID" not in (
                                              select
                                                dor1."ParentID"
                                              from
                                                "OrganisationGroup" dor1
                                              where
                                                dor1."OrganisationID" = OrganisationID
    );

  -- add do specific group roles

  insert into
    "OrganisationGroupRole"("OrganisationGroupID", "OrganisationRoleID", "IsActive", "IsDeleted")
  select
    org."OrganisationGroupID",
    orr."OrganisationRoleID",
    true,
    false
  from
    "DefaultOrganisationGroupRole" rc
    inner join "OrganisationGroup" org on org."OrganisationID" = OrganisationID and org."ParentID" = rc."DefaultOrganisationGroupID" and org."IsActive" = true and org."IsDeleted" = false
    left join "OrganisationRole" orr on orr."ParentID" = rc."DefaultOrganisationRoleID" and orr."IsActive" = true and orr."IsDeleted" = false and orr."OrganisationID" = OrganisationID
  where
    rc."DefaultOrganisationGroupID" =
    (
      select
        orgr."ParentID"
      from
        "OrganisationGroup" orgr
      where
        orgr."OrganisationGroupID" = org."OrganisationGroupID"
    );

  -- Organisation NC /  ROLE / CLAIM

/*  INSERT INTO
    public."OrganisationNotificationConstruct"("NotificationConstructID", "NotificationConstructVersionNumber", "IsActive", "IsDeleted", "OrganisationID", "ParentID")
  SELECT
    "NotificationConstructID",
    "NotificationConstructVersionNumber",
    true,
    false,
    OrganisationID,
    "DefaultOrganisationNotificationConstructID"
  FROM
    public."DefaultOrganisationNotificationConstruct"
  where
    "DefaultOrganisationID" = defaultorganisationid;*/

  -- NC Roles

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    ncr."RoleName",
    true,
    ncr."RoleSubTypeID",
    true,
    false,
    ncr."NotificationRoleConstructID"
  FROM
    public."NotificationConstructRole" ncr
    inner join "DefaultOrganisationNotificationConstruct" donc on donc."NotificationConstructID" = ncr."NotificationConstructID" and donc."NotificationConstructVersionNumber" =
      ncr."NotificationConstructVersionNumber" and donc."IsActive" = true and donc."IsDeleted" = false and donc."DefaultOrganisationID" = defaultorganisationid
  where
    ncr."IsActive" = true and
    ncr."IsDeleted" = false and
    ncr."NotificationRoleConstructID" not in (
                                               select
                                                 orn."ParentID"
                                               from
                                                 "OrganisationRole" orn
                                               where
                                                 orn."OrganisationID" = OrganisationID
    );

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA NC CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "NotificationConstructClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID"
    inner join "DefaultOrganisationNotificationConstruct" donc on donc."NotificationConstructID" = ncc."NotificationConstructID" and donc."NotificationConstructVersionNumber" =
      ncc."NotificationConstructVersionNumber" and donc."IsActive" = true and donc."IsDeleted" = false and donc."DefaultOrganisationID" = defaultorganisationid
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false and
    ncc."NotificationRoleConstructID" is null;

  -- NC CLAIMS THAT ARE DIRECT FROM NC ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."NotificationConstructClaim" ncc
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."NotificationRoleConstructID" and nc."IsActive" = true and nc."IsDeleted" = false and
      ncc."IsActive" = true and ncc."IsDeleted" = false and ncc."RoleID" is null and not exists (
                                                                                                  select
                                                                                                    orc."OrganisationRoleClaimID"
                                                                                                  from
                                                                                                    "OrganisationRoleClaim" orc
                                                                                                  where
                                                                                                    orc."OrganisationID" = OrganisationID and
                                                                                                    orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                                                                                                    orc."OperationID" = ncc."OperationID" and
                                                                                                    orc."ResourceID" = ncc."ResourceID" and
                                                                                                    orc."StateID" = ncc."StateID" and
                                                                                                    orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA NC CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."NotificationConstructClaim" ncc
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."NotificationRoleConstructID" is null;

  ----------------------- Artefact
  -- Org Artefact

  INSERT INTO
    public."OrganisationArtefact"("OrganisationID", "ArtefactID", "ArtefactVersionNumber", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    "ArtefactID",
    "ArtefactVersionNumber",
    "IsActive",
    "IsDeleted",
    "ArtefactID"
  FROM
    public."DefaultOrganisationArtefact"
  where
    "DefaultOrganisationID" = defaultorganisationid and
    "IsActive" = true and
    "IsDeleted" = false;

  -- Artefact Specific Roles

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    ncr."RoleName",
    true,
    ncr."RoleTypeID",
    true,
    false,
    ncr."ArtefactRoleID"
  FROM
    public."ArtefactRole" ncr
    inner join "DefaultOrganisationArtefact" donc on donc."ArtefactID" = ncr."ArtefactID" and donc."ArtefactVersionNumber" = ncr."ArtefactVersionNumber" and donc."IsActive" = true and donc."IsDeleted"
      = false and donc."DefaultOrganisationID" = defaultorganisationid
  where
    ncr."IsActive" = true and
    ncr."IsDeleted" = false and
    ncr."ArtefactRoleID" not in (
                                  select
                                    orn."ParentID"
                                  from
                                    "OrganisationRole" orn
                                  where
                                    orn."OrganisationID" = OrganisationID
    );

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA NC CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "ArtefactClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID"
    inner join "DefaultOrganisationArtefact" donc on donc."ArtefactID" = ncc."ArtefactID" and donc."ArtefactVersionNumber" = ncc."ArtefactVersionNumber" and donc."IsActive" = true and donc."IsDeleted"
      = false and donc."DefaultOrganisationID" = defaultorganisationid
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false and
    ncc."ArtefactRoleID" is null;

  -- ARTEFACT CLAIMS THAT ARE DIRECT FROM ARTEFACT ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."ArtefactClaim" ncc
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."ArtefactRoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA NC CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."ArtefactClaim" ncc
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."ArtefactRoleID" is null;

  -------------------------- MODULE

  -- Module Specific Roles

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    ncr."RoleName",
    true,
    ncr."RoleTypeID",
    true,
    false,
    ncr."RoleID"
  FROM
    public."ModuleRole" ncr
    inner join "DefaultOrganisationModule" donc on donc."ModuleID" = ncr."ModuleID" and donc."ModuleVersionNumber" = ncr."ModuleVersionNumber" and donc."IsActive" = true and donc."IsDeleted" = false
      and donc."DefaultOrganisationID" = defaultorganisationid
  where
    ncr."IsActive" = true and
    ncr."IsDeleted" = false and
    ncr."RoleID" not in (
                          select
                            orn."ParentID"
                          from
                            "OrganisationRole" orn
                          where
                            orn."OrganisationID" = OrganisationID
    );

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA MODULE CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "ModuleClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID"
    inner join "DefaultOrganisationModule" donc on donc."ModuleID" = ncc."ModuleID" and donc."ModuleVersionNumber" = ncc."ModuleVersionNumber" and donc."IsActive" = true and donc."IsDeleted" = false
      and donc."DefaultOrganisationID" = defaultorganisationid
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false and
    ncc."ModuleRoleID" is null;

  -- Module CLAIMS THAT ARE DIRECT FROM Module ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."ModuleClaim" ncc
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."ModuleRoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA MODULE CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."ModuleClaim" ncc
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."ModuleRoleID" is null;

  ----------------------------------- WORKFLOW
/*
  INSERT INTO
    public."OrganisationWorkflow"("OrganisationID", "WorkflowID", "VersionNumber", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    "WorkflowID",
    "WorkflowVersionNumber",
    "IsActive",
    "IsDeleted",
    dow . "DefaultOrganisationID"
  FROM
    public."DefaultOrganisationWorkflow" dow
  where
    dow . "DefaultOrganisationID" = defaultorganisationid and
    dow . "IsActive" = true and
    dow . "IsDeleted" = FALSE and
    not exists (
                 select
                   dow1."OrganisationWorkflowID"
                 from
                   "OrganisationWorkflow" dow1
                 where
                   dow1."OrganisationID" = OrganisationID and
                   dow1."IsActive" = true and
                   dow1."IsDeleted" = false and
                   dow1."WorkflowID" = dow . "WorkflowID" and
                   dow1."VersionNumber" = dow . "WorkflowVersionNumber" and
                   dow1."ParentID" = dow . "DefaultOrganisationID"
    );

  -- Workflow Specific Roles

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    ncr."RoleName",
    true,
    ncr."RoleTypeID",
    true,
    false,
    ncr."WorkflowRoleID"
  FROM
    public."WorkflowRole" ncr
    inner join "DefaultOrganisationWorkflow" donc on donc."WorkflowID" = ncr."WorkflowID" and donc."WorkflowVersionNumber" = ncr."WorkflowVersionNumber" and donc."IsActive" = true and donc."IsDeleted"
      = false and donc."DefaultOrganisationID" = defaultorganisationid
  where
    ncr."IsActive" = true and
    ncr."IsDeleted" = false and
    ncr."WorkflowRoleID" not in (
                                  select
                                    orn."ParentID"
                                  from
                                    "OrganisationRole" orn
                                  where
                                    orn."OrganisationID" = OrganisationID
    );

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA WF CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "WorkflowClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID" and ncc."WorkflowRoleID" is null
    inner join "DefaultOrganisationWorkflow" donc on donc."WorkflowID" = ncc."WorkflowID" and donc."WorkflowVersionNumber" = ncc."WorkflowVersionNumber" and donc."IsActive" = true and donc."IsDeleted"
      = false and donc."DefaultOrganisationID" = defaultorganisationid
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false;

  -- Workflow CLAIMS THAT ARE DIRECT FROM Workflow ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."WorkflowClaim" ncc
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."WorkflowRoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA WF CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."WorkflowClaim" ncc
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."WorkflowRoleID" is null;

  ------------------------ MODULE WORKFLOW ROLECLAIMS

  -- Workflow Specific Roles
/*
  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    wr."RoleName",
    true,
    wr."RoleTypeID",
    true,
    false,
    wr."WorkflowRoleID"
  FROM
    public."ModuleWorkflow" mw
    inner join "OrganisationModuleSubscription" donc on donc."ModuleID" = mw."ModuleID" and donc."ModuleVersionNumber" = mw."ModuleVersionNumber" and donc."IsActive" = true and donc."IsDeleted" =
      false and donc."OrganisationID" = OrganisationID
    inner join "WorkflowRole" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
  where
    mw."IsActive" = true and
    mw."IsDeleted" = false and
    wr."WorkflowRoleID" not in (
                                 select
                                   orn."ParentID"
                                 from
                                   "OrganisationRole" orn
                                 where
                                   orn."OrganisationID" = OrganisationID
    );*/

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA WF CLAIMS

/*  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "WorkflowClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID" and ncc."WorkflowRoleID" is null
    inner join "ModuleWorkflow" mw on mw."WorkflowID" = ncc."WorkflowID" and mw."WorkflowVersionNumber" = ncc."WorkflowVersionNumber" and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."ModuleID" = mw."ModuleID" and ow."ModuleVersionNumber" = mw."ModuleVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false;*/

  -- Workflow CLAIMS THAT ARE DIRECT FROM Workflow ROLES NOT GLOBAL

  /*INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."WorkflowClaim" ncc
    inner join "ModuleWorkflow" mw on mw."WorkflowID" = ncc."WorkflowID" and mw."WorkflowVersionNumber" = ncc."WorkflowVersionNumber" and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."ModuleID" = mw."ModuleID" and ow."ModuleVersionNumber" = mw."ModuleVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."WorkflowRoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );*/

  -- INSERT CLAIMS LINKED VIA WF CLAIMS GLOBAL
/*
  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."WorkflowClaim" ncc
    inner join "ModuleWorkflow" mw on mw."WorkflowID" = ncc."WorkflowID" and mw."WorkflowVersionNumber" = ncc."WorkflowVersionNumber" and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."ModuleID" = mw."ModuleID" and ow."ModuleVersionNumber" = mw."ModuleVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."WorkflowRoleID" is null;*/
*/
  --------------------------------    MODULE NC ROLE/CLAIMS ----------------------               

  -- Workflow Specific Roles
/*
  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    wr."RoleName",
    true,
    wr."RoleTypeID",
    true,
    false,
    wr."NotificationRoleConstructID"
  FROM
    public."ModuleNotificationConstruct" mw
    inner join "OrganisationModuleSubscription" donc on donc."ModuleID" = mw."ModuleID" and donc."ModuleVersionNumber" = mw."ModuleVersionNumber" and donc."IsActive" = true and donc."IsDeleted" =
      false and donc."OrganisationID" = OrganisationID
    inner join "NotificationConstructRole" wr on wr."NotificationConstructID" = mw."ModuleNotificationConstructID" and wr."NotificationConstructVersionNumber" = mw."NotificationConstructVersionNumber"
      and wr."IsActive" = true and wr."IsDeleted" = false
  where
    mw."IsActive" = true and
    mw."IsDeleted" = false and
    wr."NotificationRoleConstructID" not in (
                                              select
                                                orn."ParentID"
                                              from
                                                "OrganisationRole" orn
                                              where
                                                orn."OrganisationID" = OrganisationID
    );*/

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA WF CLAIMS

/*  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "NotificationConstructClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID" and ncc."NotificationRoleConstructID" is null
    inner join "ModuleNotificationConstruct" mw on mw."NotificationConstructID" = ncc."NotificationConstructID" and mw."NotificationConstructVersionNumber" = ncc."NotificationConstructVersionNumber"
      and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."ModuleID" = mw."ModuleID" and ow."ModuleVersionNumber" = mw."ModuleVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false;*/

  -- Workflow CLAIMS THAT ARE DIRECT FROM Workflow ROLES NOT GLOBAL

  /*INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."NotificationConstructClaim" ncc
    inner join "ModuleNotificationConstruct" mw on mw."NotificationConstructID" = ncc."NotificationConstructID" and mw."NotificationConstructVersionNumber" = ncc."NotificationConstructVersionNumber"
      and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."ModuleID" = mw."ModuleID" and ow."ModuleVersionNumber" = mw."ModuleVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."NotificationRoleConstructID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );
*/
  -- INSERT CLAIMS LINKED VIA WF CLAIMS GLOBAL

  /*INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."NotificationConstructClaim" ncc
    inner join "ModuleNotificationConstruct" mw on mw."NotificationConstructID" = ncc."NotificationConstructID" and mw."NotificationConstructVersionNumber" = ncc."NotificationConstructVersionNumber"
      and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."ModuleID" = mw."ModuleID" and ow."ModuleVersionNumber" = mw."ModuleVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."NotificationRoleConstructID" is null;*/

  ---------------------------------------------- ARTEFACT WORKFLOW AND NC ---------------
  -- Workflow Specific Roles
/*
  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    wr."RoleName",
    true,
    wr."RoleTypeID",
    true,
    false,
    wr."WorkflowRoleID"
  FROM
    public."ArtefactWorkflow" mw
    inner join "OrganisationArtefact" donc on donc."ArtefactID" = mw."ArtefactID" and donc."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and donc."IsActive" = true and donc."IsDeleted" = false
      and donc."OrganisationID" = OrganisationID
    inner join "WorkflowRole" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
  where
    mw."IsActive" = true and
    mw."IsDeleted" = false and
    wr."WorkflowRoleID" not in (
                                 select
                                   orn."ParentID"
                                 from
                                   "OrganisationRole" orn
                                 where
                                   orn."OrganisationID" = OrganisationID
    );

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA WF CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "WorkflowClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID" and ncc."WorkflowRoleID" is null
    inner join "ArtefactWorkflow" mw on mw."WorkflowID" = ncc."WorkflowID" and mw."WorkflowVersionNumber" = ncc."WorkflowVersionNumber" and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."ArtefactID" = mw."ArtefactID" and ow."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false;

  -- Workflow CLAIMS THAT ARE DIRECT FROM Workflow ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."WorkflowClaim" ncc
    inner join "ArtefactWorkflow" mw on mw."WorkflowID" = ncc."WorkflowID" and mw."WorkflowVersionNumber" = ncc."WorkflowVersionNumber" and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."ArtefactID" = mw."ArtefactID" and ow."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."WorkflowRoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA WF CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."WorkflowClaim" ncc
    inner join "ArtefactWorkflow" mw on mw."WorkflowID" = ncc."WorkflowID" and mw."WorkflowVersionNumber" = ncc."WorkflowVersionNumber" and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."ArtefactID" = mw."ArtefactID" and ow."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."WorkflowRoleID" is null;
*/
  --------------------------------    Artefact NC ROLE/CLAIMS ----------------------               

  -- Workflow Specific Roles

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    wr."RoleName",
    true,
    wr."RoleTypeID",
    true,
    false,
    wr."NotificationRoleConstructID"
  FROM
    public."ArtefactNotificationConstruct" mw
    inner join "OrganisationArtefact" donc on donc."ArtefactID" = mw."ArtefactID" and donc."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and donc."IsActive" = true and donc."IsDeleted" = false
      and donc."OrganisationID" = OrganisationID
    inner join "NotificationConstructRole" wr on wr."NotificationConstructID" = mw."ArtefactNotificationConstructID" and wr."NotificationConstructVersionNumber" =
      mw."NotificationConstructVersionNumber" and wr."IsActive" = true and wr."IsDeleted" = false
  where
    mw."IsActive" = true and
    mw."IsDeleted" = false and
    wr."NotificationRoleConstructID" not in (
                                              select
                                                orn."ParentID"
                                              from
                                                "OrganisationRole" orn
                                              where
                                                orn."OrganisationID" = OrganisationID
    );

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA WF CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "NotificationConstructClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID" and ncc."NotificationRoleConstructID" is null
    inner join "ArtefactNotificationConstruct" mw on mw."NotificationConstructID" = ncc."NotificationConstructID" and mw."NotificationConstructVersionNumber" = ncc."NotificationConstructVersionNumber"
      and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."ArtefactID" = mw."ArtefactID" and ow."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false;

  -- Workflow CLAIMS THAT ARE DIRECT FROM Workflow ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."NotificationConstructClaim" ncc
    inner join "ArtefactNotificationConstruct" mw on mw."NotificationConstructID" = ncc."NotificationConstructID" and mw."NotificationConstructVersionNumber" = ncc."NotificationConstructVersionNumber"
      and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."NotificationRoleConstructID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA WF CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."NotificationConstructClaim" ncc
    inner join "ArtefactNotificationConstruct" mw on mw."NotificationConstructID" = ncc."NotificationConstructID" and mw."NotificationConstructVersionNumber" = ncc."NotificationConstructVersionNumber"
      and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."ArtefactID" = mw."ArtefactID" and ow."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."NotificationRoleConstructID" is null;

  ------------------------------------ ORGANISATION WORKFLOW NC ROLE / CLAIMS ---------------------------

  -- Workflow Specific Roles
/*
  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    ncr."RoleName",
    true,
    ncr."RoleTypeID",
    true,
    false,
    ncr."NotificationRoleConstructID"
  FROM
    public."ModuleWorkflow" mw
    inner join "OrganisationModuleSubscription" donc on donc."ModuleID" = mw."ModuleID" and donc."ModuleVersionNumber" = mw."ModuleVersionNumber" and donc."IsActive" = true and donc."IsDeleted" =
      false and donc."OrganisationID" = OrganisationID
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "NotificationConstructRole" ncr on ncr."NotificationConstructID" = wr."NotificationConstructID" and ncr."NotificationConstructVersionNumber" = wr."NotificationConstructVersionNumber"
      and ncr."IsActive" = true and ncr."IsDeleted" = false
  where
    mw."IsActive" = true and
    mw."IsDeleted" = false and
    ncr."NotificationRoleConstructID" not in (
                                               select
                                                 orn."ParentID"
                                               from
                                                 "OrganisationRole" orn
                                               where
                                                 orn."OrganisationID" = OrganisationID
    );
*/
  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA WF CLAIMS
/*
  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false
    inner join "ModuleWorkflow" mw on mw."ModuleID" = ow."ModuleID" and mw."ModuleVersionNumber" = ow."ModuleVersionNumber" and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "NotificationConstructClaim" ncr on ncr."RoleID" = r."RoleID" and ncr."NotificationRoleConstructID" is null and ncr."NotificationConstructID" = wr."NotificationConstructID" and
      ncr."NotificationConstructVersionNumber" = wr."NotificationConstructVersionNumber" and ncr."IsActive" = true and ncr."IsDeleted" = false
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false;
*/
  -- Workflow CLAIMS THAT ARE DIRECT FROM Workflow ROLES NOT GLOBAL

  /*INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."NotificationConstructClaim" ncc
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false
    inner join "ModuleWorkflow" mw on mw."ModuleID" = ow."ModuleID" and mw."ModuleVersionNumber" = ow."ModuleVersionNumber" and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."NotificationRoleConstructID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );*/

  -- INSERT CLAIMS LINKED VIA WF CLAIMS GLOBAL
/*
  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."NotificationConstructClaim" ncc
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false
    inner join "ModuleWorkflow" mw on mw."ModuleID" = ow."ModuleID" and mw."ModuleVersionNumber" = ow."ModuleVersionNumber" and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."NotificationRoleConstructID" is null;*/
  -------------------------------------------------------
  ------------------------------------------------------- ARTEFACEWORKFLOW NC
  -- Workflow Specific Roles
/*
  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    ncr."RoleName",
    true,
    ncr."RoleTypeID",
    true,
    false,
    ncr."NotificationRoleConstructID"
  FROM
    public."ArtefactWorkflow" mw
    inner join "OrganisationArtefact" donc on donc."ArtefactID" = mw."ArtefactID" and donc."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and donc."IsActive" = true and donc."IsDeleted" = false
      and donc."OrganisationID" = OrganisationID
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "NotificationConstructRole" ncr on ncr."NotificationConstructID" = wr."NotificationConstructID" and ncr."NotificationConstructVersionNumber" = wr."NotificationConstructVersionNumber"
      and ncr."IsActive" = true and ncr."IsDeleted" = false
  where
    mw."IsActive" = true and
    mw."IsDeleted" = false and
    ncr."NotificationRoleConstructID" not in (
                                               select
                                                 orn."ParentID"
                                               from
                                                 "OrganisationRole" orn
                                               where
                                                 orn."OrganisationID" = OrganisationID
    );

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA WF CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false
    inner join "ArtefactWorkflow" mw on mw."ArtefactID" = ow."ArtefactID" and mw."ArtefactVersionNumber" = ow."ArtefactVersionNumber" and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "NotificationConstructClaim" ncr on ncr."RoleID" = r."RoleID" and ncr."NotificationRoleConstructID" is null and ncr."NotificationConstructID" = wr."NotificationConstructID" and
      ncr."NotificationConstructVersionNumber" = wr."NotificationConstructVersionNumber" and ncr."IsActive" = true and ncr."IsDeleted" = false
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false;

  -- Workflow CLAIMS THAT ARE DIRECT FROM Workflow ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."NotificationConstructClaim" ncc
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false
    inner join "ArtefactWorkflow" mw on mw."ArtefactID" = ow."ArtefactID" and mw."ArtefactVersionNumber" = ow."ArtefactVersionNumber" and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."NotificationRoleConstructID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA WF CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."NotificationConstructClaim" ncc
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false
    inner join "ArtefactWorkflow" mw on mw."ArtefactID" = ow."ArtefactID" and mw."ArtefactVersionNumber" = ow."ArtefactVersionNumber" and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."NotificationRoleConstructID" is null;
  -------------------------------------------------------
  ------------------------------------------------------- ORGANISATION WORKFLOW NC ROLE / CLAIMS
  -- Workflow Specific Roles

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    ncr."RoleName",
    true,
    ncr."RoleTypeID",
    true,
    false,
    ncr."NotificationRoleConstructID"
  FROM
    public."OrganisationWorkflow" mw
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."VersionNumber"
    inner join "NotificationConstructRole" ncr on ncr."NotificationConstructID" = wr."NotificationConstructID" and ncr."NotificationConstructVersionNumber" = wr."NotificationConstructVersionNumber"
      and ncr."IsActive" = true and ncr."IsDeleted" = false
  where
    mw."IsActive" = true and
    mw."IsDeleted" = false and
    ncr."NotificationRoleConstructID" not in (
                                               select
                                                 orn."ParentID"
                                               from
                                                 "OrganisationRole" orn
                                               where
                                                 orn."OrganisationID" = OrganisationID
    ) and
    mw."OrganisationID" = OrganisationID;

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA WF CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "OrganisationWorkflow" mw on mw."OrganisationID" = OrganisationID and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."VersionNumber"
    inner join "NotificationConstructClaim" ncr on ncr."RoleID" = r."RoleID" and ncr."NotificationRoleConstructID" is null and ncr."NotificationConstructID" = wr."NotificationConstructID" and
      ncr."NotificationConstructVersionNumber" = wr."NotificationConstructVersionNumber" and ncr."IsActive" = true and ncr."IsDeleted" = false
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false;

  -- Workflow CLAIMS THAT ARE DIRECT FROM Workflow ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."NotificationConstructClaim" ncc
    inner join "OrganisationWorkflow" mw on mw."OrganisationID" = OrganisationID and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."VersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."NotificationRoleConstructID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA WF CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."NotificationConstructClaim" ncc
    inner join "OrganisationWorkflow" mw on mw."OrganisationID" = OrganisationID and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."VersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."NotificationRoleConstructID" is null;
  -------------------------------------------------------
  */
  ------------------------------------------------------- MODULE ARTEFACT
/*
  INSERT INTO
    public."OrganisationArtefact"("OrganisationID", "ArtefactID", "ArtefactVersionNumber", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    "ArtefactID",
    "ArtefactVersionNumber",
    ma."IsActive",
    ma."IsDeleted",
    "ArtefactID"
  FROM
    public."ModuleArtefact" ma
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
  where
    ma."IsActive" = true and
    ma."IsDeleted" = FALSE and
    not exists (
                 select
                   ma1."ArtefactID"
                 from
                   "OrganisationArtefact" ma1
                 where
                   ma1."OrganisationID" = OrganisationID and
                   ma1."ArtefactID" = ma."ArtefactID" and
                   ma1."ArtefactVersionNumber" = ma."ArtefactVersionNumber"
    );

  -- Artefact Specific Roles

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    ncr."RoleName",
    true,
    ncr."RoleTypeID",
    true,
    false,
    ncr."ArtefactRoleID"
  FROM
    public."ArtefactRole" ncr
    inner join "ModuleArtefact" ma on ma."ArtefactID" = ncr."ArtefactID" and ma."ArtefactVersionNumber" = ncr."ArtefactVersionNumber" and ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
  where
    ncr."IsActive" = true and
    ncr."IsDeleted" = false and
    ncr."ArtefactRoleID" not in (
                                  select
                                    orn."ParentID"
                                  from
                                    "OrganisationRole" orn
                                  where
                                    orn."OrganisationID" = OrganisationID
    );

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA NC CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "ArtefactClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID"
    inner join "ModuleArtefact" ma on ma."ArtefactID" = ncc."ArtefactID" and ma."ArtefactVersionNumber" = ncc."ArtefactVersionNumber" and ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false and
    ncc."ArtefactRoleID" is null;

  -- ARTEFACT CLAIMS THAT ARE DIRECT FROM ARTEFACT ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."ArtefactClaim" ncc
    inner join "ModuleArtefact" ma on ma."ArtefactID" = ncc."ArtefactID" and ma."ArtefactVersionNumber" = ncc."ArtefactVersionNumber" and ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."ArtefactRoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA NC CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."ArtefactClaim" ncc
    inner join "ModuleArtefact" ma on ma."ArtefactID" = ncc."ArtefactID" and ma."ArtefactVersionNumber" = ncc."ArtefactVersionNumber" and ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."ArtefactRoleID" is null;

  -- Workflow Specific Roles

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    wr."RoleName",
    true,
    wr."RoleTypeID",
    true,
    false,
    wr."WorkflowRoleID"
  FROM
    public."ArtefactWorkflow" mw
    inner join "ModuleArtefact" ma on ma."ArtefactID" = mw."ArtefactID" and ma."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
    inner join "OrganisationArtefact" donc on donc."ArtefactID" = mw."ArtefactID" and donc."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and donc."IsActive" = true and donc."IsDeleted" = false
      and donc."OrganisationID" = OrganisationID
    inner join "WorkflowRole" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
  where
    mw."IsActive" = true and
    mw."IsDeleted" = false and
    wr."WorkflowRoleID" not in (
                                 select
                                   orn."ParentID"
                                 from
                                   "OrganisationRole" orn
                                 where
                                   orn."OrganisationID" = OrganisationID
    );*/

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA WF CLAIMS
/*
  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "WorkflowClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID" and ncc."WorkflowRoleID" is null
    inner join "ArtefactWorkflow" mw on mw."WorkflowID" = ncc."WorkflowID" and mw."WorkflowVersionNumber" = ncc."WorkflowVersionNumber" and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "ModuleArtefact" ma on ma."ArtefactID" = mw."ArtefactID" and ma."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
    inner join "OrganisationArtefact" oa on oa."OrganisationID" = OrganisationID and oa."ArtefactID" = mw."ArtefactID" and oa."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and oa."IsActive" =
      true and oa."IsDeleted" = false
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false;
*/
  -- Workflow CLAIMS THAT ARE DIRECT FROM Workflow ROLES NOT GLOBAL
/*
  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."WorkflowClaim" ncc
    inner join "ArtefactWorkflow" mw on mw."WorkflowID" = ncc."WorkflowID" and mw."WorkflowVersionNumber" = ncc."WorkflowVersionNumber" and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "ModuleArtefact" ma on ma."ArtefactID" = mw."ArtefactID" and ma."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
    inner join "OrganisationArtefact" oa on oa."OrganisationID" = OrganisationID and oa."ArtefactID" = mw."ArtefactID" and oa."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and oa."IsActive" =
      true and oa."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."WorkflowRoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA WF CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."WorkflowClaim" ncc
    inner join "ArtefactWorkflow" mw on mw."WorkflowID" = ncc."WorkflowID" and mw."WorkflowVersionNumber" = ncc."WorkflowVersionNumber" and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "ModuleArtefact" ma on ma."ArtefactID" = mw."ArtefactID" and ma."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
    inner join "OrganisationArtefact" oa on oa."OrganisationID" = OrganisationID and oa."ArtefactID" = mw."ArtefactID" and oa."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and oa."IsActive" =
      true and oa."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."WorkflowRoleID" is null;

  --------------------------------    Artefact NC ROLE/CLAIMS ----------------------               

  -- Workflow Specific Roles

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    wr."RoleName",
    true,
    wr."RoleTypeID",
    true,
    false,
    wr."NotificationRoleConstructID"
  FROM
    public."ArtefactNotificationConstruct" mw
    inner join "ModuleArtefact" ma on ma."ArtefactID" = mw."ArtefactID" and ma."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
    inner join "OrganisationArtefact" donc on donc."ArtefactID" = mw."ArtefactID" and donc."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and donc."IsActive" = true and donc."IsDeleted" = false
      and donc."OrganisationID" = OrganisationID
    inner join "NotificationConstructRole" wr on wr."NotificationConstructID" = mw."ArtefactNotificationConstructID" and wr."NotificationConstructVersionNumber" =
      mw."NotificationConstructVersionNumber" and wr."IsActive" = true and wr."IsDeleted" = false
  where
    mw."IsActive" = true and
    mw."IsDeleted" = false and
    wr."NotificationRoleConstructID" not in (
                                              select
                                                orn."ParentID"
                                              from
                                                "OrganisationRole" orn
                                              where
                                                orn."OrganisationID" = OrganisationID
    );

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA WF CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "NotificationConstructClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID" and ncc."NotificationRoleConstructID" is null
    inner join "ArtefactNotificationConstruct" mw on mw."NotificationConstructID" = ncc."NotificationConstructID" and mw."NotificationConstructVersionNumber" = ncc."NotificationConstructVersionNumber"
      and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "ModuleArtefact" ma on ma."ArtefactID" = mw."ArtefactID" and ma."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
    inner join "OrganisationArtefact" oa on oa."OrganisationID" = OrganisationID and oa."ArtefactID" = mw."ArtefactID" and oa."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and oa."IsActive" =
      true and oa."IsDeleted" = false
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false;

  -- Workflow CLAIMS THAT ARE DIRECT FROM Workflow ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."NotificationConstructClaim" ncc
    inner join "ArtefactNotificationConstruct" mw on mw."NotificationConstructID" = ncc."NotificationConstructID" and mw."NotificationConstructVersionNumber" = ncc."NotificationConstructVersionNumber"
      and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "ModuleArtefact" ma on ma."ArtefactID" = mw."ArtefactID" and ma."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."NotificationRoleConstructID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA WF CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."NotificationConstructClaim" ncc
    inner join "ArtefactNotificationConstruct" mw on mw."NotificationConstructID" = ncc."NotificationConstructID" and mw."NotificationConstructVersionNumber" = ncc."NotificationConstructVersionNumber"
      and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "ModuleArtefact" ma on ma."ArtefactID" = mw."ArtefactID" and ma."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
    inner join "OrganisationArtefact" oa on oa."OrganisationID" = OrganisationID and oa."ArtefactID" = mw."ArtefactID" and oa."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and oa."IsActive" =
      true and oa."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."NotificationRoleConstructID" is null;*/

  ----------------------------------------------------------------------------
  -------------------------------------- ORG STATUS TYPE
  -- Org StatusType

  INSERT INTO
    public."OrganisationStatusType"("OrganisationID", "StatusTypeID", "StatusTypeVersionNumber", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    "StatusTypeID",
    "StatusTypeVersionNumber",
    "IsActive",
    "IsDeleted",
    "DefaultOrganisationID"
  FROM
    public."DefaultOrganisationStatusType"
  where
    "DefaultOrganisationID" = defaultorganisationid and
    "IsActive" = true and
    "IsDeleted" = false;

  -- StatusType Specific Roles

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    ncr."RoleName",
    true,
    ncr."RoleTypeID",
    true,
    false,
    ncr."StatusTypeRoleID"
  FROM
    public."StatusTypeRole" ncr
    inner join "DefaultOrganisationStatusType" donc on donc."StatusTypeID" = ncr."StatusTypeID" and donc."StatusTypeVersionNumber" = ncr."StatusTypeVersionNumber" and donc."IsActive" = true and
      donc."IsDeleted" = false and donc."DefaultOrganisationID" = defaultorganisationid
  where
    ncr."IsActive" = true and
    ncr."IsDeleted" = false and
    ncr."StatusTypeRoleID" not in (
                                    select
                                      orn."ParentID"
                                    from
                                      "OrganisationRole" orn
                                    where
                                      orn."OrganisationID" = OrganisationID
    );

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA NC CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "StatusTypeClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID"
    inner join "DefaultOrganisationStatusType" donc on donc."StatusTypeID" = ncc."StatusTypeID" and donc."StatusTypeVersionNumber" = ncc."StatusTypeVersionNumber" and donc."IsActive" = true and
      donc."IsDeleted" = false and donc."DefaultOrganisationID" = defaultorganisationid
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false and
    ncc."StatusTypeRoleID" is null;

  -- StatusType CLAIMS THAT ARE DIRECT FROM StatusType ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."StatusTypeClaim" ncc
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."StatusTypeRoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA NC CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."StatusTypeClaim" ncc
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."StatusTypeRoleID" is null;

  -----------------------------------------------------------------
  ---------------- DO-WF
/*
  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    mw."RoleName",
    true,
    mw."RoleTypeID",
    true,
    false,
    mw."StatusTypeRoleID"
  FROM
    public."StatusTypeRole" mw
    inner join "ModuleStatusType" mst on mst."StatusTypeID" = mw."StatusTypeID" and mst."StatusTypeVersionNumber" = mw."StatusTypeVersionNumber" and mst."IsActive" = true and mst."IsDeleted" = false
    inner join "OrganisationModuleSubscription" donc on donc."ModuleID" = mst."ModuleID" and donc."ModuleVersionNumber" = mst."ModuleVersionNumber" and donc."IsActive" = true and donc."IsDeleted" =
      false and donc."OrganisationID" = OrganisationID
  where
    mw."IsActive" = true and
    mw."IsDeleted" = false and
    mw."StatusTypeRoleID" not in (
                                   select
                                     orn."ParentID"
                                   from
                                     "OrganisationRole" orn
                                   where
                                     orn."OrganisationID" = OrganisationID
    );

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA WF CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "StatusTypeClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID" and ncc."StatusTypeRoleID" is null
    inner join "ModuleStatusType" mw on mw."StatusTypeID" = ncc."StatusTypeID" and mw."StatusTypeVersionNumber" = ncc."StatusTypeVersionNumber" and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."ModuleID" = mw."ModuleID" and ow."ModuleVersionNumber" = mw."ModuleVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false;

  -- StatusType CLAIMS THAT ARE DIRECT FROM StatusType ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."StatusTypeClaim" ncc
    inner join "ModuleStatusType" mw on mw."StatusTypeID" = ncc."StatusTypeID" and mw."StatusTypeVersionNumber" = ncc."StatusTypeVersionNumber" and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."ModuleID" = mw."ModuleID" and ow."ModuleVersionNumber" = mw."ModuleVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."StatusTypeRoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA WF CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."StatusTypeClaim" ncc
    inner join "ModuleStatusType" mw on mw."StatusTypeID" = ncc."StatusTypeID" and mw."StatusTypeVersionNumber" = ncc."StatusTypeVersionNumber" and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."ModuleID" = mw."ModuleID" and ow."ModuleVersionNumber" = mw."ModuleVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."StatusTypeRoleID" is null;*/
  ----------------------------------------------------
  -------------------- DO - AR - STR
  -- Workflow Specific Roles

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    wr."RoleName",
    true,
    wr."RoleTypeID",
    true,
    false,
    wr."StatusTypeRoleID"
  FROM
    public."ArtefactStatusType" mw
    inner join "OrganisationArtefact" donc on donc."ArtefactID" = mw."ArtefactID" and donc."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and donc."IsActive" = true and donc."IsDeleted" = false
      and donc."OrganisationID" = OrganisationID
    inner join "StatusTypeRole" wr on wr."StatusTypeID" = mw."StatusTypeID" and wr."StatusTypeVersionNumber" = mw."StatusTypeVersionNumber"
  where
    wr."StatusTypeRoleID" not in (
                                   select
                                     orn."ParentID"
                                   from
                                     "OrganisationRole" orn
                                   where
                                     orn."OrganisationID" = OrganisationID
    );

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA WF CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "StatusTypeClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID" and ncc."StatusTypeRoleID" is null
    inner join "ArtefactStatusType" mw on mw."StatusTypeID" = ncc."StatusTypeID" and mw."StatusTypeVersionNumber" = ncc."StatusTypeVersionNumber"
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."ArtefactID" = mw."ArtefactID" and ow."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false;

  -- StatusType CLAIMS THAT ARE DIRECT FROM StatusType ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."StatusTypeClaim" ncc
    inner join "ArtefactStatusType" mw on mw."StatusTypeID" = ncc."StatusTypeID" and mw."StatusTypeVersionNumber" = ncc."StatusTypeVersionNumber"
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."ArtefactID" = mw."ArtefactID" and ow."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."StatusTypeRoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA WF CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."StatusTypeClaim" ncc
    inner join "ArtefactStatusType" mw on mw."StatusTypeID" = ncc."StatusTypeID" and mw."StatusTypeVersionNumber" = ncc."StatusTypeVersionNumber"
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."ArtefactID" = mw."ArtefactID" and ow."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."StatusTypeRoleID" is null;
  -----------------------------------------------------
  --------------------- DO - M - WF - STR
  -- Workflow Specific Roles

/* insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    ncr."RoleName",
    true,
    ncr."RoleTypeID",
    true,
    false,
    ncr."StatusTypeRoleID"
  FROM
    public."ModuleWorkflow" mw
    inner join "OrganisationModuleSubscription" donc on donc."ModuleID" = mw."ModuleID" and donc."ModuleVersionNumber" = mw."ModuleVersionNumber" and donc."IsActive" = true and donc."IsDeleted" =
      false and donc."OrganisationID" = OrganisationID
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "StatusTypeRole" ncr on ncr."StatusTypeID" = wr."StatusTypeID" and ncr."StatusTypeVersionNumber" = wr."StatusTypeVersionNumber" and ncr."IsActive" = true and ncr."IsDeleted" = false
  where
    mw."IsActive" = true and
    mw."IsDeleted" = false and
    ncr."StatusTypeRoleID" not in (
                                    select
                                      orn."ParentID"
                                    from
                                      "OrganisationRole" orn
                                    where
                                      orn."OrganisationID" = OrganisationID
    );

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA WF CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false
    inner join "ModuleWorkflow" mw on mw."ModuleID" = ow."ModuleID" and mw."ModuleVersionNumber" = ow."ModuleVersionNumber" and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "StatusTypeClaim" ncr on ncr."RoleID" = r."RoleID" and ncr."StatusTypeRoleID" is null and ncr."StatusTypeID" = wr."StatusTypeID" and ncr."StatusTypeVersionNumber" =
      wr."StatusTypeVersionNumber" and ncr."IsActive" = true and ncr."IsDeleted" = false
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false;

  -- Workflow CLAIMS THAT ARE DIRECT FROM Workflow ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."StatusTypeClaim" ncc
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false
    inner join "ModuleWorkflow" mw on mw."ModuleID" = ow."ModuleID" and mw."ModuleVersionNumber" = ow."ModuleVersionNumber" and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."StatusTypeRoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA WF CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."StatusTypeClaim" ncc
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false
    inner join "ModuleWorkflow" mw on mw."ModuleID" = ow."ModuleID" and mw."ModuleVersionNumber" = ow."ModuleVersionNumber" and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."StatusTypeRoleID" is null;*/
  -----------------------------------------------------
  ---------------------------------- DO - AR -WF - STR
/*
  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    ncr."RoleName",
    true,
    ncr."RoleTypeID",
    true,
    false,
    ncr."StatusTypeRoleID"
  FROM
    public."ArtefactWorkflow" mw
    inner join "OrganisationArtefact" donc on donc."ArtefactID" = mw."ArtefactID" and donc."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and donc."IsActive" = true and donc."IsDeleted" = false
      and donc."OrganisationID" = OrganisationID
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "StatusTypeRole" ncr on ncr."StatusTypeID" = wr."StatusTypeID" and ncr."StatusTypeVersionNumber" = wr."StatusTypeVersionNumber" and ncr."IsActive" = true and ncr."IsDeleted" = false
  where
    mw."IsActive" = true and
    mw."IsDeleted" = false and
    ncr."StatusTypeRoleID" not in (
                                    select
                                      orn."ParentID"
                                    from
                                      "OrganisationRole" orn
                                    where
                                      orn."OrganisationID" = OrganisationID
    );

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA WF CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false
    inner join "ArtefactWorkflow" mw on mw."ArtefactID" = ow."ArtefactID" and mw."ArtefactVersionNumber" = ow."ArtefactVersionNumber" and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "StatusTypeClaim" ncr on ncr."RoleID" = r."RoleID" and ncr."StatusTypeRoleID" is null and ncr."StatusTypeID" = wr."StatusTypeID" and ncr."StatusTypeVersionNumber" =
      wr."StatusTypeVersionNumber" and ncr."IsActive" = true and ncr."IsDeleted" = false
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false;

  -- Workflow CLAIMS THAT ARE DIRECT FROM Workflow ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."StatusTypeClaim" ncc
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false
    inner join "ArtefactWorkflow" mw on mw."ArtefactID" = ow."ArtefactID" and mw."ArtefactVersionNumber" = ow."ArtefactVersionNumber" and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."StatusTypeRoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA WF CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."StatusTypeClaim" ncc
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false
    inner join "ArtefactWorkflow" mw on mw."ArtefactID" = ow."ArtefactID" and mw."ArtefactVersionNumber" = ow."ArtefactVersionNumber" and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."StatusTypeRoleID" is null;

  ----------------------------------------
  -------------------------- DO - WF - STR
  -- Workflow Specific Roles

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    ncr."RoleName",
    true,
    ncr."RoleTypeID",
    true,
    false,
    ncr."StatusTypeRoleID"
  FROM
    public."OrganisationWorkflow" mw
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."VersionNumber"
    inner join "StatusTypeRole" ncr on ncr."StatusTypeID" = wr."StatusTypeID" and ncr."StatusTypeVersionNumber" = wr."StatusTypeVersionNumber" and ncr."IsActive" = true and ncr."IsDeleted" = false
  where
    mw."IsActive" = true and
    mw."IsDeleted" = false and
    ncr."StatusTypeRoleID" not in (
                                    select
                                      orn."ParentID"
                                    from
                                      "OrganisationRole" orn
                                    where
                                      orn."OrganisationID" = OrganisationID
    ) and
    mw."OrganisationID" = OrganisationID;

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA WF CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "OrganisationWorkflow" mw on mw."OrganisationID" = OrganisationID and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."VersionNumber"
    inner join "StatusTypeClaim" ncr on ncr."RoleID" = r."RoleID" and ncr."StatusTypeRoleID" is null and ncr."StatusTypeID" = wr."StatusTypeID" and ncr."StatusTypeVersionNumber" =
      wr."StatusTypeVersionNumber" and ncr."IsActive" = true and ncr."IsDeleted" = false
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false;

  -- Workflow CLAIMS THAT ARE DIRECT FROM Workflow ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."StatusTypeClaim" ncc
    inner join "OrganisationWorkflow" mw on mw."OrganisationID" = OrganisationID and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."VersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."StatusTypeRoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA WF CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."StatusTypeClaim" ncc
    inner join "OrganisationWorkflow" mw on mw."OrganisationID" = OrganisationID and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."VersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."StatusTypeRoleID" is null;
    */
   
  ------------------------ Branch

  -- create branches as needed

  INSERT INTO
    public."Organisation"("OrganisationID", "OrganisationTypeID", "IsBranch", "IsHeadOffice", "CreatedOn", "CreatedBy", "DefaultOrganisationID", "DefaultOrganisationVersionNumber",
      "ParentOrganisationID", "ParentID")
  SELECT
    uuid_generate_v1(),
    (
      select
        "OrganisationTypeID"
      from
        "OrganisationType"
      where
        "Name" = 'Branch'
      limit
        1
    ),
    true,
    false,
    CURRENT_DATE,
    'System',
    defaultorganisationid,
    organisationversionnumber,
    OrganisationID,
    wt."DefaultOrganisationBranchID"
  FROM
    public."DefaultOrganisationBranch" wt
  where
    wt."DefaultOrganisationID" = defaultorganisationid and
    wt."DefaultOrganisationVersionNumber" = organisationversionnumber;
  INSERT INTO
    public."OrganisationDetail"("OrganisationID", "Name", "Description")
  SELECT
    org."OrganisationID",
    dob."BranchName",
    'Branch'
  FROM
    public."Organisation" org
    left outer join "DefaultOrganisationBranch" dob on dob."DefaultOrganisationBranchID" = org."ParentID"
  where
    org."ParentOrganisationID" = OrganisationID;

  -- User Type

  INSERT INTO
    public."OrganisationUserType"("OrganisationID", "UserTypeID", "IsActive", "IsDeleted", "IsForDefaultUser")
  SELECT
    OrganisationID,
    wt."UserTypeID",
    wt."IsActive",
    wt."IsDeleted",
    wt."IsForDefaultUser"
  FROM
    public."DefaultOrganisationUserType" wt
  where
    wt."DefaultOrganisationID" = defaultorganisationid and
    wt."DefaultOrganisationVersionNumber" = organisationversionnumber;

  -- Organisation Default Status 

  INSERT INTO
    public."OrganisationStatus"("OrganisationID", "StatusTypeID", "StatusTypeVersionNumber", "StatusTypeValueID", "StatusChangedOn", "StatusChangedBy", "ParentID")
  SELECT
    OrganisationID,
    wt."StatusTypeID",
    wt."StatusTypeVersionNumber",
    st."StatusTypeValueID",
    CURRENT_DATE,
    'System',
    null
  FROM
    public."DefaultOrganisationTarget" wt
    left outer join "vStatusType" st on st."StatusTypeID" = wt."StatusTypeID" and st."StatusTypeVersionNumber" = wt."StatusTypeVersionNumber" and
      st."IsStart" = true
  where
    wt."DefaultOrganisationID" = defaultorganisationid and
    wt."DefaultOrganisationVersionNumber" = organisationversionnumber and
    st."StatusTypeValueID" is not null;

  -- Organisation Branch Default Status, same as parent
  FOR LoopRow IN
  SELECT
    *
  FROM
    "Organisation"
  where
    "ParentOrganisationID" = OrganisationID
  LOOP
    INSERT INTO
      public."OrganisationStatus"("OrganisationID", "StatusTypeID", "StatusTypeVersionNumber", "StatusTypeValueID", "StatusChangedOn", "StatusChangedBy", "ParentID")
    SELECT
      loopRow."OrganisationID",
      wt."StatusTypeID",
      wt."StatusTypeVersionNumber",
      st."StatusTypeValueID",
      CURRENT_DATE,
      'System',
      null
    FROM
      public."DefaultOrganisationTarget" wt
      left outer join "vStatusType" st on st."StatusTypeID" = wt."StatusTypeID" and st."StatusTypeVersionNumber" = wt."StatusTypeVersionNumber" and st."StatusTypeName" = 'Branch Status' and
        st."IsStart" = true
    where
      wt."DefaultOrganisationID" = defaultorganisationid and
      wt."DefaultOrganisationVersionNumber" = organisationversionnumber and
      st."StatusTypeValueID" is not null;

  END LOOP;

  RETURN OrganisationId;
end;
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER
COST 100;



-- BankAccountCertificate
INSERT INTO
  public."NotificationConstructTemplate"
(
  "NotificationConstructTemplateID",
  "NotificationConstructTemplateVersionNumber",
  "Name",
  "Description",
  "DefaultNotificationExportFormatID",
  "DefaultNotificationDeliveryMethodID",
  "NotificationConstructMutatorObjectType"
)
VALUES (
  '4fb339f0-489f-11e4-a2d3-ef22e599ffaa',
  1,
  'BankAccountCertificate',
  'Bank Account Certificate',
  4990,
  4993,
  ''
);

-- Data
INSERT INTO
  public."NotificationConstructDataTemplate"
(
  "NotificationConstructTemplateID",
  "NotificationConstructTemplateVersionNumber",
  "NotificationData",
  "IsActive",
  "IsDeleted",
  "CreatedOn",
  "UsesBusinessObjects",
  "UsesDataSources"
)
VALUES (
  '4fb339f0-489f-11e4-a2d3-ef22e599ffaa',
  1,
  E'\\357\\273\\277<?xml version="1.0" encoding="utf-8" standalone="yes"?>\\015\\012<StiSerializer version="1.02" type="Net" application="StiReport">\\015\\012  <Dictionary Ref="1" type="Dictionary" isKey="true">\\015\\012    <BusinessObjects isList="true" count="1">\\015\\012      <CertificateDetailsDTO Ref="2" type="Stimulsoft.Report.Dictionary.StiBusinessObject" isKey="true">\\015\\012        <Alias>CertificateDetailsDTO</Alias>\\015\\012        <BusinessObjects isList="true" count="0" />\\015\\012        <Category />\\015\\012        <Columns isList="true" count="7">\\015\\012          <value>OrganisationName,System.String</value>\\015\\012          <value>SchemeID,System.String</value>\\015\\012          <value>StartDate,System.String</value>\\015\\012          <value>BankAccountName,System.String</value>\\015\\012          <value>BankAddress,System.String</value>\\015\\012          <value>AccountNumber,System.String</value>\\015\\012          <value>SortCode,System.String</value>\\015\\012        </Columns>\\015\\012        <Dictionary isRef="1" />\\015\\012        <Guid>cd7569401fbb4dc8ba3350e35063abc4</Guid>\\015\\012        <Name>CertificateDetailsDTO</Name>\\015\\012      </CertificateDetailsDTO>\\015\\012    </BusinessObjects>\\015\\012    <Databases isList="true" count="0" />\\015\\012    <DataSources isList="true" count="0" />\\015\\012    <Relations isList="true" count="0" />\\015\\012    <Report isRef="0" />\\015\\012    <Variables isList="true" count="0" />\\015\\012  </Dictionary>\\015\\012  <EngineVersion>EngineV2</EngineVersion>\\015\\012  <GlobalizationStrings isList="true" count="0" />\\015\\012  <MetaTags isList="true" count="0" />\\015\\012  <Pages isList="true" count="1">\\015\\012    <Page1 Ref="3" type="Page" isKey="true">\\015\\012      <Border>None;Black;2;Solid;False;4;Black</Border>\\015\\012      <Brush>Transparent</Brush>\\015\\012      <Components isList="true" count="26">\\015\\012        <Image1 Ref="4" type="Image" isKey="true">\\015\\012          <AspectRatio>True</AspectRatio>\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>1.4,1,6,2.4</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Image>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</Image>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <MultipleFactor>2</MultipleFactor>\\015\\012          <Name>Image1</Name>\\015\\012          <Page isRef="3" />\\015\\012          <Parent isRef="3" />\\015\\012          <Smoothing>False</Smoothing>\\015\\012          <Stretch>True</Stretch>\\015\\012        </Image1>\\015\\012        <Text1 Ref="5" type="Text" isKey="true">\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>6.8,1.2,11,1.6</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Verdana,9.75,Regular,Point,False,0</Font>\\015\\012          <HorAlignment>Right</HorAlignment>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text1</Name>\\015\\012          <Page isRef="3" />\\015\\012          <Parent isRef="3" />\\015\\012          <Text>BE Consultancy Ltd T/A the Safe Move Scheme\\015\\012Marlesfield House, 114-116 Main Road, Sidcup, Kent, DA14 6NG\\015\\012Company Number: 05742032</Text>\\015\\012          <TextBrush>Black</TextBrush>\\015\\012          <Type>Expression</Type>\\015\\012        </Text1>\\015\\012        <Text2 Ref="6" type="Text" isKey="true">\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>1.2,3.2,16.6,1.2</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Verdana,21.75,Bold,Point,False,0</Font>\\015\\012          <HorAlignment>Center</HorAlignment>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text2</Name>\\015\\012          <Page isRef="3" />\\015\\012          <Parent isRef="3" />\\015\\012          <Text>Registration Certificate</Text>\\015\\012          <TextBrush>Black</TextBrush>\\015\\012          <Type>Expression</Type>\\015\\012        </Text2>\\015\\012        <Text3 Ref="7" type="Text" isKey="true">\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>1.2,4.6,16.6,1.2</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Verdana,9.75,Regular,Point,False,0</Font>\\015\\012          <Guid>3b3e8ad7c7084c8ebe5f28dde2a49e26</Guid>\\015\\012          <HorAlignment>Center</HorAlignment>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text3</Name>\\015\\012          <Page isRef="3" />\\015\\012          <Parent isRef="3" />\\015\\012          <Text>This is to certify that the bank account details below have been registered on the\\015\\012Safe Move Scheme to help prevent fraud.</Text>\\015\\012          <TextBrush>Black</TextBrush>\\015\\012          <Type>Expression</Type>\\015\\012        </Text3>\\015\\012        <Text4 Ref="8" type="Text" isKey="true">\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>1.2,6.4,16.6,0.4</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Verdana,9.75,Regular,Point,False,0</Font>\\015\\012          <Guid>a1852203fcb94d5ba7f2fe066e49cbbf</Guid>\\015\\012          <HorAlignment>Center</HorAlignment>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text4</Name>\\015\\012          <Page isRef="3" />\\015\\012          <Parent isRef="3" />\\015\\012          <Text>Conveyancing Firm</Text>\\015\\012          <TextBrush>Black</TextBrush>\\015\\012          <Type>Expression</Type>\\015\\012        </Text4>\\015\\012        <Text5 Ref="9" type="Text" isKey="true">\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>1.2,6.8,16.6,0.4</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Verdana,9.75,Bold,Point,False,0</Font>\\015\\012          <Guid>b044daee299847ca84a286dfe68a4750</Guid>\\015\\012          <HorAlignment>Center</HorAlignment>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text5</Name>\\015\\012          <Page isRef="3" />\\015\\012          <Parent isRef="3" />\\015\\012          <Text>{CertificateDetailsDTO.OrganisationName}</Text>\\015\\012          <TextBrush>Black</TextBrush>\\015\\012          <Type>DataColumn</Type>\\015\\012        </Text5>\\015\\012        <Text6 Ref="10" type="Text" isKey="true">\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>1.2,7.6,16.6,0.4</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Verdana,9.75,Regular,Point,False,0</Font>\\015\\012          <Guid>c504e9bf5c0242828a84bc01744427d9</Guid>\\015\\012          <HorAlignment>Center</HorAlignment>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text6</Name>\\015\\012          <Page isRef="3" />\\015\\012          <Parent isRef="3" />\\015\\012          <Text>Scheme Number</Text>\\015\\012          <TextBrush>Black</TextBrush>\\015\\012          <Type>Expression</Type>\\015\\012        </Text6>\\015\\012        <Text7 Ref="11" type="Text" isKey="true">\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>1.2,8,16.6,0.4</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Verdana,9.75,Bold,Point,False,0</Font>\\015\\012          <Guid>e90b8d877336421381ee57679f6ca5b9</Guid>\\015\\012          <HorAlignment>Center</HorAlignment>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text7</Name>\\015\\012          <Page isRef="3" />\\015\\012          <Parent isRef="3" />\\015\\012          <Text>{CertificateDetailsDTO.SchemeID}</Text>\\015\\012          <TextBrush>Black</TextBrush>\\015\\012          <Type>Expression</Type>\\015\\012        </Text7>\\015\\012        <Text8 Ref="12" type="Text" isKey="true">\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>1.2,8.8,16.6,0.4</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Verdana,9.75,Regular,Point,False,0</Font>\\015\\012          <Guid>f98bbb3d104b425b83e2994713e6199a</Guid>\\015\\012          <HorAlignment>Center</HorAlignment>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text8</Name>\\015\\012          <Page isRef="3" />\\015\\012          <Parent isRef="3" />\\015\\012          <Text>Registration Start Date</Text>\\015\\012          <TextBrush>Black</TextBrush>\\015\\012          <Type>Expression</Type>\\015\\012        </Text8>\\015\\012        <Text9 Ref="13" type="Text" isKey="true">\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>1.2,9.2,16.6,0.4</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Verdana,9.75,Bold,Point,False,0</Font>\\015\\012          <Guid>bba678dde53743e2b9f43eb20f62ef21</Guid>\\015\\012          <HorAlignment>Center</HorAlignment>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text9</Name>\\015\\012          <Page isRef="3" />\\015\\012          <Parent isRef="3" />\\015\\012          <Text>{CertificateDetailsDTO.StartDate}</Text>\\015\\012          <TextBrush>Black</TextBrush>\\015\\012          <Type>Expression</Type>\\015\\012        </Text9>\\015\\012        <Text10 Ref="14" type="Text" isKey="true">\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>1.2,10,16.6,0.4</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Verdana,9.75,Regular,Point,False,0</Font>\\015\\012          <Guid>e7b97f1f13b5472788efb148de004a58</Guid>\\015\\012          <HorAlignment>Center</HorAlignment>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text10</Name>\\015\\012          <Page isRef="3" />\\015\\012          <Parent isRef="3" />\\015\\012          <Text>Bank Account Name</Text>\\015\\012          <TextBrush>Black</TextBrush>\\015\\012          <Type>Expression</Type>\\015\\012        </Text10>\\015\\012        <Text11 Ref="15" type="Text" isKey="true">\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>1.2,10.4,16.6,0.4</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Verdana,9.75,Bold,Point,False,0</Font>\\015\\012          <Guid>3b28181304bb4b0ebd49c4b00b1bc6eb</Guid>\\015\\012          <HorAlignment>Center</HorAlignment>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text11</Name>\\015\\012          <Page isRef="3" />\\015\\012          <Parent isRef="3" />\\015\\012          <Text>{CertificateDetailsDTO.BankAccountName}</Text>\\015\\012          <TextBrush>Black</TextBrush>\\015\\012          <Type>Expression</Type>\\015\\012        </Text11>\\015\\012        <Text12 Ref="16" type="Text" isKey="true">\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>1.2,11.2,16.6,0.4</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Verdana,9.75,Regular,Point,False,0</Font>\\015\\012          <Guid>16172fd643594f9a878926ebb97e6a94</Guid>\\015\\012          <HorAlignment>Center</HorAlignment>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text12</Name>\\015\\012          <Page isRef="3" />\\015\\012          <Parent isRef="3" />\\015\\012          <Text>Bank</Text>\\015\\012          <TextBrush>Black</TextBrush>\\015\\012          <Type>Expression</Type>\\015\\012        </Text12>\\015\\012        <Text13 Ref="17" type="Text" isKey="true">\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>5,11.6,9,1.4</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Verdana,9.75,Bold,Point,False,0</Font>\\015\\012          <Guid>8c3e8d19c4554fafaa96625d54eb0eb4</Guid>\\015\\012          <HorAlignment>Center</HorAlignment>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text13</Name>\\015\\012          <Page isRef="3" />\\015\\012          <Parent isRef="3" />\\015\\012          <Text>{CertificateDetailsDTO.BankAddress}</Text>\\015\\012          <TextBrush>Black</TextBrush>\\015\\012          <Type>Expression</Type>\\015\\012        </Text13>\\015\\012        <Text14 Ref="18" type="Text" isKey="true">\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>1.2,13,16.6,0.4</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Verdana,9.75,Regular,Point,False,0</Font>\\015\\012          <Guid>b65df1afe31e42a8924550b596510d9e</Guid>\\015\\012          <HorAlignment>Center</HorAlignment>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text14</Name>\\015\\012          <Page isRef="3" />\\015\\012          <Parent isRef="3" />\\015\\012          <Text>Bank Account Number</Text>\\015\\012          <TextBrush>Black</TextBrush>\\015\\012          <Type>Expression</Type>\\015\\012        </Text14>\\015\\012        <Text15 Ref="19" type="Text" isKey="true">\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>1.2,13.4,16.6,0.4</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Verdana,9.75,Bold,Point,False,0</Font>\\015\\012          <Guid>5c8e2f9d054e4c03b3a791dbf551594b</Guid>\\015\\012          <HorAlignment>Center</HorAlignment>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text15</Name>\\015\\012          <Page isRef="3" />\\015\\012          <Parent isRef="3" />\\015\\012          <Text>{CertificateDetailsDTO.AccountNumber}</Text>\\015\\012          <TextBrush>Black</TextBrush>\\015\\012          <Type>Expression</Type>\\015\\012        </Text15>\\015\\012        <Text16 Ref="20" type="Text" isKey="true">\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>1.2,14.2,16.6,0.4</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Verdana,9.75,Regular,Point,False,0</Font>\\015\\012          <Guid>00bdabdedbf14b8fac3a48ea7a241282</Guid>\\015\\012          <HorAlignment>Center</HorAlignment>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text16</Name>\\015\\012          <Page isRef="3" />\\015\\012          <Parent isRef="3" />\\015\\012          <Text>Sort Code</Text>\\015\\012          <TextBrush>Black</TextBrush>\\015\\012          <Type>Expression</Type>\\015\\012        </Text16>\\015\\012        <Text17 Ref="21" type="Text" isKey="true">\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>1.2,14.6,16.6,0.4</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Verdana,9.75,Bold,Point,False,0</Font>\\015\\012          <Guid>7c0470d7295446b2b9808de92fa82f2c</Guid>\\015\\012          <HorAlignment>Center</HorAlignment>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text17</Name>\\015\\012          <Page isRef="3" />\\015\\012          <Parent isRef="3" />\\015\\012          <Text>{CertificateDetailsDTO.SortCode}</Text>\\015\\012          <TextBrush>Black</TextBrush>\\015\\012          <Type>Expression</Type>\\015\\012        </Text17>\\015\\012        <Text18 Ref="22" type="Text" isKey="true">\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>1.2,15.4,16.6,1</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Verdana,9.75,Bold,Point,False,0</Font>\\015\\012          <Guid>898a46ff2c534e238262fe4fec90bb5d</Guid>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text18</Name>\\015\\012          <Page isRef="3" />\\015\\012          <Parent isRef="3" />\\015\\012          <Text>The Safe Move Scheme only provides protection for conveyancing clients who\\015\\012adhere to the following process:</Text>\\015\\012          <TextBrush>Black</TextBrush>\\015\\012          <Type>Expression</Type>\\015\\012        </Text18>\\015\\012        <Text19 Ref="23" type="Text" isKey="true">\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>2,16.6,15,2.6</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Verdana,9.75,Regular,Point,False,0</Font>\\015\\012          <Guid>d9d65625f9474548921e5845eb7a6310</Guid>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text19</Name>\\015\\012          <Page isRef="3" />\\015\\012          <Parent isRef="3" />\\015\\012          <Text>1. Login to the Safe Move Scheme and, if you don\\342\\200\\231t have one, register a new account\\015\\012(your conveyancer can help you set up a Safe Move Scheme account)\\015\\0122. Follow the on-screen instructions to check the bank details below match those\\015\\012registered on the Safe Move Scheme before you transfer money to your\\015\\012conveyancer\\015\\012</Text>\\015\\012          <TextBrush>Black</TextBrush>\\015\\012          <Type>Expression</Type>\\015\\012        </Text19>\\015\\012        <Text20 Ref="24" type="Text" isKey="true">\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>1.2,19.6,16.6,1</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Verdana,9.75,Bold,Point,False,0</Font>\\015\\012          <Guid>8dc9790814ba4d1f9d4cc4f4a8e7d79d</Guid>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text20</Name>\\015\\012          <Page isRef="3" />\\015\\012          <Parent isRef="3" />\\015\\012          <Text>Your payment will not be protected by the Safe Move Scheme without following\\015\\012the above process.</Text>\\015\\012          <TextBrush>Black</TextBrush>\\015\\012          <Type>Expression</Type>\\015\\012        </Text20>\\015\\012        <Text21 Ref="25" type="Text" isKey="true">\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>1.2,20.8,16.6,0.4</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Verdana,9.75,Bold| Underline,Point,False,0</Font>\\015\\012          <Guid>773a223620bb460b860eac2e1cae4b9a</Guid>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text21</Name>\\015\\012          <Page isRef="3" />\\015\\012          <Parent isRef="3" />\\015\\012          <Text>IMPORTANT NOTES</Text>\\015\\012          <TextBrush>Black</TextBrush>\\015\\012          <Type>Expression</Type>\\015\\012        </Text21>\\015\\012        <Text22 Ref="26" type="Text" isKey="true">\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>1.2,21.4,16.6,3.8</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Verdana,9.75,Regular,Point,False,0</Font>\\015\\012          <Guid>68d569bd902b4e7d87f82aa57a9031ae</Guid>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text22</Name>\\015\\012          <Page isRef="3" />\\015\\012          <Parent isRef="3" />\\015\\012          <Text>Please refer to your conveyancer to obtain the required reference for making your\\015\\012payment.\\015\\012Please contact your conveyancer to advise when monies have been sent to them,\\015\\012confirming the amount, the time sent and the bank sent from.\\015\\012Due to anti money laundering regulations, conveyancers cannot accept cash payments\\015\\012into their bank accounts.\\015\\012Please also note that conveyancers cannot receive payments into their account from\\015\\012anyone who is not their client unless they are authorised to provide a gift to a client via\\015\\012the Safe Move Scheme.</Text>\\015\\012          <TextBrush>Black</TextBrush>\\015\\012          <Type>Expression</Type>\\015\\012        </Text22>\\015\\012        <RectanglePrimitive1 Ref="27" type="RectanglePrimitive" isKey="true">\\015\\012          <ClientRectangle>0.8,0.8,17.4,26.4</ClientRectangle>\\015\\012          <Color>Black</Color>\\015\\012          <Guid>f3955e5b352144689dff0961fc5cf2ea</Guid>\\015\\012          <Name>RectanglePrimitive1</Name>\\015\\012          <Page isRef="3" />\\015\\012          <Parent isRef="3" />\\015\\012        </RectanglePrimitive1>\\015\\012        <StartPointPrimitive1 Ref="28" type="Stimulsoft.Report.Components.StiStartPointPrimitive" isKey="true">\\015\\012          <ClientRectangle>0.8,0.8,0,0</ClientRectangle>\\015\\012          <Name>StartPointPrimitive1</Name>\\015\\012          <Page isRef="3" />\\015\\012          <Parent isRef="3" />\\015\\012          <ReferenceToGuid>f3955e5b352144689dff0961fc5cf2ea</ReferenceToGuid>\\015\\012        </StartPointPrimitive1>\\015\\012        <EndPointPrimitive1 Ref="29" type="Stimulsoft.Report.Components.StiEndPointPrimitive" isKey="true">\\015\\012          <ClientRectangle>18.2,27.2,0,0</ClientRectangle>\\015\\012          <Name>EndPointPrimitive1</Name>\\015\\012          <Page isRef="3" />\\015\\012          <Parent isRef="3" />\\015\\012          <ReferenceToGuid>f3955e5b352144689dff0961fc5cf2ea</ReferenceToGuid>\\015\\012        </EndPointPrimitive1>\\015\\012      </Components>\\015\\012      <Conditions isList="true" count="0" />\\015\\012      <Guid>6723661a77b54f37bf980c736252bb2f</Guid>\\015\\012      <Margins>1,1,1,1</Margins>\\015\\012      <Name>Page1</Name>\\015\\012      <PageHeight>29.7</PageHeight>\\015\\012      <PageWidth>21</PageWidth>\\015\\012      <Report isRef="0" />\\015\\012      <Watermark Ref="30" type="Stimulsoft.Report.Components.StiWatermark" isKey="true">\\015\\012        <Font>Arial,100</Font>\\015\\012        <TextBrush>[50:0:0:0]</TextBrush>\\015\\012      </Watermark>\\015\\012    </Page1>\\015\\012  </Pages>\\015\\012  <PrinterSettings Ref="31" type="Stimulsoft.Report.Print.StiPrinterSettings" isKey="true" />\\015\\012  <ReferencedAssemblies isList="true" count="8">\\015\\012    <value>System.Dll</value>\\015\\012    <value>System.Drawing.Dll</value>\\015\\012    <value>System.Windows.Forms.Dll</value>\\015\\012    <value>System.Data.Dll</value>\\015\\012    <value>System.Xml.Dll</value>\\015\\012    <value>Stimulsoft.Controls.Dll</value>\\015\\012    <value>Stimulsoft.Base.Dll</value>\\015\\012    <value>Stimulsoft.Report.Dll</value>\\015\\012  </ReferencedAssemblies>\\015\\012  <ReportAlias>Report</ReportAlias>\\015\\012  <ReportChanged>11/5/2015 1:33:28 PM</ReportChanged>\\015\\012  <ReportCreated>10/29/2015 3:39:53 PM</ReportCreated>\\015\\012  <ReportFile>C:\\134Reports\\134bacert.mrt</ReportFile>\\015\\012  <ReportGuid>bc3a1f7241844c82acb03caf3ce77c20</ReportGuid>\\015\\012  <ReportName>Report</ReportName>\\015\\012  <ReportUnit>Centimeters</ReportUnit>\\015\\012  <ReportVersion>2015.1.8</ReportVersion>\\015\\012  <Script>using System;\\015\\012using System.Drawing;\\015\\012using System.Windows.Forms;\\015\\012using System.Data;\\015\\012using Stimulsoft.Controls;\\015\\012using Stimulsoft.Base.Drawing;\\015\\012using Stimulsoft.Report;\\015\\012using Stimulsoft.Report.Dialogs;\\015\\012using Stimulsoft.Report.Components;\\015\\012\\015\\012namespace Reports\\015\\012{\\015\\012    public class Report : Stimulsoft.Report.StiReport\\015\\012    {\\015\\012        public Report()        {\\015\\012            this.InitializeComponent();\\015\\012        }\\015\\012\\015\\012        #region StiReport Designer generated code - do not modify\\015\\012\\011\\011#endregion StiReport Designer generated code - do not modify\\015\\012    }\\015\\012}\\015\\012</Script>\\015\\012  <ScriptLanguage>CSharp</ScriptLanguage>\\015\\012  <Styles isList="true" count="0" />\\015\\012</StiSerializer>',
  true,
  false,
  CURRENT_DATE,
  true,
  false
);

-- Parameters
INSERT INTO
  public."NotificationConstructParameterTemplate"
(
  "NotificationConstructTemplateID",
  "NotificationConstructTemplateVersionNumber",
  "ParameterOrBusinessObjectName",
  "ObjectType",
  "ObjectName",
  "ObjectNameSpace",
  "ObjectAssembly",
  "IsMandatory",
  "IsActive",
  "IsDeleted",
  "IsBusinessObject",
  "BusinessObjectCategoryName"
)
VALUES (
  '4fb339f0-489f-11e4-a2d3-ef22e599ffaa',
  1,
  'NotificationSettingDTO',
  'Bec.TargetFramework.Entities.NotificationSettingDTO, Bec.TargetFramework.Entities',
  'NotificationSettingDTO',
  'Bec.TargetFramework.Entities',
  'Bec.TargetFramework.Entities',
  true,
  true,
  false,
  true,
  'General'
);

INSERT INTO
  public."NotificationConstructParameterTemplate"
(
  "NotificationConstructTemplateID",
  "NotificationConstructTemplateVersionNumber",
  "ParameterOrBusinessObjectName",
  "ObjectType",
  "ObjectName",
  "ObjectNameSpace",
  "ObjectAssembly",
  "IsMandatory",
  "IsActive",
  "IsDeleted",
  "IsBusinessObject",
  "BusinessObjectCategoryName"
)
VALUES (
  '4fb339f0-489f-11e4-a2d3-ef22e599ffaa',
  1,
  'CertificateDetailsDTO',
  'Bec.TargetFramework.Entities.CertificateDetailsDTO, Bec.TargetFramework.Entities',
  'CertificateDetailsDTO',
  'Bec.TargetFramework.Entities',
  'Bec.TargetFramework.Entities',
  true,
  true,
  false,
  true,
  'General'
);

-- claims - add resource for notification
INSERT INTO
  public."Resource"
(
  "ResourceID",
  "ResourceName",
  "ResourceDescription",
  "IsActive",
  "IsDeleted",
  "ParentID"
)
VALUES (
  '4af24f2c-489f-11e4-be44-93993f0045a6',
  'TcPublic',
  'Public Terms and Conditions Resource',
  true,
  false,
  null
);

INSERT INTO
  public."NotificationConstructClaimTemplate"
(
  "NotificationConstructTemplateID",
  "NotificationConstructTemplateVersionNumber",
  "NotificationConstructRoleID",
  "ResourceID",
  "OperationID",
  "StateID",
  "StateItemID",
  "IsActive",
  "IsDeleted",
  "RoleID"
)
VALUES (
  '4fb339f0-489f-11e4-a2d3-ef22e599ffaa',
  1,
  null,
  '4af24f2c-489f-11e4-be44-93993f0045a6',
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1),
  null,
  null,
  true,
  false,
  null
);

SELECT * FROM public."fn_PromoteNotificationConstructTemplate"('4fb339f0-489f-11e4-a2d3-ef22e599ffaa', 1);


-- ===================================

-- ================= MAIN DB =================
-- New internal messages notification

 --Run Operation script first
-- Run ExternalNotification and ExternalBatchNotification first

--0001 Notification
DO $$
Declare NcTID uuid;
Declare NcTVN integer;
Declare NcResID uuid;
Declare OrgEmployeeRoleID uuid;
Declare UserUserTypeID uuid;
Begin

NcTVN := 1;
NcTID := 'DA37A2E3-AA35-4CC5-A768-3DDC0C262110';
NcResID := (select uuid_generate_v1());
OrgEmployeeRoleID := (select "RoleID" from "Role" where "RoleName" = 'Organisation Administrator' limit 1);
UserUserTypeID := (select "UserTypeID" from "UserType" where "Name" = 'Organisation Administrator' limit 1);

INSERT INTO
  public."NotificationConstructTemplate"
(
  "NotificationConstructTemplateID",
  "NotificationConstructTemplateVersionNumber",
  "Name",
  "Description",
  "DefaultNotificationExportFormatID",
  "DefaultNotificationDeliveryMethodID",
  "NotificationSubject",
  "NotificationTitle",
  "NotificationReference",
  "NotificationConstructMutatorObjectType",
  "CanBeIncludedInBatchNotification"
)
VALUES (
  NcTID,
  NcTVN,
  'NewInternalMessages',
  'New Internal Messages Notification',
  4989,
  4992,
  'New Notifications',
  'Test',
  '0001',
  'Bec.TargetFramework.SB.Notifications.Mutators.NewInternalMessagesMutator, Bec.TargetFramework.SB.Notifications',
  false
);

INSERT INTO
  public."NotificationConstructTargetTemplate"
(
  "NotificationConstructTemplateID",
  "NotificationConstructTemplateVersionNumber",
  "OrganisationTypeID",
  "UserTypeID",
  "IsSingleUser",
  "IsOrganisationBranchOnly",
  "IsDefaultTarget",
  "IsActive",
  "IsDeleted"
)
VALUES (
  NcTID,
  NcTVN,
  null,
  UserUserTypeID,
  true,
  false,
  true,
  true,
  false
);

-- Data
INSERT INTO
  public."NotificationConstructDataTemplate"
(
  "NotificationConstructTemplateID",
  "NotificationConstructTemplateVersionNumber",
  "NotificationData",
  "IsActive",
  "IsDeleted",
  "CreatedOn",
  "UsesBusinessObjects",
  "UsesDataSources"
)
VALUES (
  NcTID,
  NcTVN,
  E'<?xml version="1.0" encoding="utf-8" standalone="yes"?>
<StiSerializer version="1.02" type="Net" application="StiReport">
  <Dictionary Ref="1" type="Dictionary" isKey="true">
    <BusinessObjects isList="true" count="2">
      <NotificationSettingDTO Ref="2" type="Stimulsoft.Report.Dictionary.StiBusinessObject" isKey="true">
        <Alias>NotificationSettingDTO</Alias>
        <BusinessObjects isList="true" count="0" />
        <Category>General</Category>
        <Columns isList="true" count="11">
          <value>ExportFormat,System.Nullable`1[System.Int32]</value>
          <value>LoginRoute,System.String</value>
          <value>NotificationConstructID,System.Guid</value>
          <value>NotificationConstructVersionNumber,System.Int32</value>
          <value>NotificationFromEmailAddress,System.String</value>
          <value>NotificiationSentFromParentID,System.Guid</value>
          <value>ServerLogoImageFileNameWithExtension,System.String</value>
          <value>ServerNotificationImageContentURLFolder,System.String</value>
          <value>ServerURL,System.String</value>
          <value>Subject,System.String</value>
          <value>Title,System.String</value>
        </Columns>
        <Dictionary isRef="1" />
        <Guid>1926f055d4144572b36e7a96e6843d70</Guid>
        <Name>NotificationSettingDTO</Name>
      </NotificationSettingDTO>
      <NewInternalMessagesNotificationDTO Ref="3" type="Stimulsoft.Report.Dictionary.StiBusinessObject" isKey="true">
        <Alias>NewInternalMessagesNotificationDTO</Alias>
        <BusinessObjects isList="true" count="0" />
        <Category>General</Category>
        <Columns isList="true" count="2">
          <value>Count,System.Int32</value>
          <value>ProductName,System.String</value>
        </Columns>
        <Dictionary isRef="1" />
        <Guid>9c462515737f4adeb65f3562c03c20d5</Guid>
        <Name>NewInternalMessagesNotificationDTO</Name>
      </NewInternalMessagesNotificationDTO>
    </BusinessObjects>
    <Databases isList="true" count="0" />
    <DataSources isList="true" count="0" />
    <Relations isList="true" count="0" />
    <Report isRef="0" />
    <Variables isList="true" count="0" />
  </Dictionary>
  <EngineVersion>EngineV2</EngineVersion>
  <GlobalizationStrings isList="true" count="0" />
  <MetaTags isList="true" count="0" />
  <Pages isList="true" count="1">
    <Page1 Ref="4" type="Page" isKey="true">
      <Border>None;Black;2;Solid;False;4;Black</Border>
      <Brush>Transparent</Brush>
      <Components isList="true" count="1">
        <Text Ref="5" type="Text" isKey="true">
          <AllowHtmlTags>True</AllowHtmlTags>
          <AutoWidth>True</AutoWidth>
          <Brush>Transparent</Brush>
          <CanGrow>True</CanGrow>
          <CanShrink>True</CanShrink>
          <ClientRectangle>0,0,38,9.4</ClientRectangle>
          <Conditions isList="true" count="0" />
          <Font>Calibri,11.25,Regular,Point,False,0</Font>
          <GrowToHeight>True</GrowToHeight>
          <Guid>aec152f25a8e4fdbb05d29af446e8573</Guid>
          <Margins>0,0,0,0</Margins>
          <Name>Text</Name>
          <Page isRef="4" />
          <Parent isRef="4" />
          <Text>&lt;p&gt;You have {NewInternalMessagesNotificationDTO.Count} new notification(s) in the {NewInternalMessagesNotificationDTO.ProductName}.&lt;/p&gt;
&lt;p&gt;&lt;b&gt;Please log into the Safe Move Scheme secure website portal as described in the Safe Move Scheme Login Security Policy.&lt;/b&gt;&lt;/p&gt;
&lt;p&gt;Kind regards,&lt;/p&gt;
&lt;p&gt;The {NewInternalMessagesNotificationDTO.ProductName} team&lt;/p&gt;</Text>
          <TextBrush>Black</TextBrush>
          <TextQuality>Wysiwyg</TextQuality>
          <Type>Expression</Type>
        </Text>
      </Components>
      <Conditions isList="true" count="0" />
      <Guid>3f4c07272ec54ccaae2496d9fb03c747</Guid>
      <Margins>1,1,1,1</Margins>
      <Name>Page1</Name>
      <Orientation>Landscape</Orientation>
      <PageHeight>29.7</PageHeight>
      <PageWidth>40</PageWidth>
      <Report isRef="0" />
      <StretchToPrintArea>True</StretchToPrintArea>
      <Watermark Ref="6" type="Stimulsoft.Report.Components.StiWatermark" isKey="true">
        <Font>Arial,100</Font>
        <TextBrush>[50:0:0:0]</TextBrush>
      </Watermark>
    </Page1>
  </Pages>
  <PrinterSettings Ref="7" type="Stimulsoft.Report.Print.StiPrinterSettings" isKey="true" />
  <ReferencedAssemblies isList="true" count="8">
    <value>System.Dll</value>
    <value>System.Drawing.Dll</value>
    <value>System.Windows.Forms.Dll</value>
    <value>System.Data.Dll</value>
    <value>System.Xml.Dll</value>
    <value>Stimulsoft.Controls.Dll</value>
    <value>Stimulsoft.Base.Dll</value>
    <value>Stimulsoft.Report.Dll</value>
  </ReferencedAssemblies>
  <ReportAlias>Report</ReportAlias>
  <ReportChanged>10/30/2015 12:06:23 PM</ReportChanged>
  <ReportCreated>9/28/2015 10:50:12 AM</ReportCreated>
  <ReportFile>AddNewInternalMessagesNotification.mrt</ReportFile>
  <ReportGuid>300413c090cc4841b190b03878091ce5</ReportGuid>
  <ReportName>Report</ReportName>
  <ReportUnit>Centimeters</ReportUnit>
  <ReportVersion>2014.3.0</ReportVersion>
  <Script>using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using Stimulsoft.Controls;
using Stimulsoft.Base.Drawing;
using Stimulsoft.Report;
using Stimulsoft.Report.Dialogs;
using Stimulsoft.Report.Components;

namespace Reports
{
    public class Report : Stimulsoft.Report.StiReport
    {
        public Report()        {
            this.InitializeComponent();
        }

        #region StiReport Designer generated code - do not modify
          #endregion StiReport Designer generated code - do not modify
    }
}
</Script>
  <ScriptLanguage>CSharp</ScriptLanguage>
  <Styles isList="true" count="0" />
</StiSerializer>',
  true,
  false,
  CURRENT_DATE,
  true,
  false
);

-- Parameters
INSERT INTO
  public."NotificationConstructParameterTemplate"
(
  "NotificationConstructTemplateID",
  "NotificationConstructTemplateVersionNumber",
  "ParameterOrBusinessObjectName",
  "ObjectType",
  "ObjectName",
  "ObjectNameSpace",
  "ObjectAssembly",
  "IsMandatory",
  "IsActive",
  "IsDeleted",
  "IsBusinessObject",
  "BusinessObjectCategoryName"
)
VALUES (
  NcTID,
  NcTVN,
  'NotificationSettingDTO',
  'Bec.TargetFramework.Entities.NotificationSettingDTO, Bec.TargetFramework.Entities',
  'NotificationSettingDTO',
  'Bec.TargetFramework.Entities',
  'Bec.TargetFramework.Entities',
  true,
  true,
  false,
  true,
  'General'
);

INSERT INTO
  public."NotificationConstructParameterTemplate"
(
  "NotificationConstructTemplateID",
  "NotificationConstructTemplateVersionNumber",
  "ParameterOrBusinessObjectName",
  "ObjectType",
  "ObjectName",
  "ObjectNameSpace",
  "ObjectAssembly",
  "IsMandatory",
  "IsActive",
  "IsDeleted",
  "IsBusinessObject",
  "BusinessObjectCategoryName"
)
VALUES (
  NcTID,
  NcTVN,
  'NewInternalMessagesNotificationDTO',
  'Bec.TargetFramework.Entities.NewInternalMessagesNotificationDTO, Bec.TargetFramework.Entities',
  'NewInternalMessagesNotificationDTO',
  'Bec.TargetFramework.Entities',
  'Bec.TargetFramework.Entities',
  true,
  true,
  false,
  true,
  'General'
);

INSERT INTO
  public."Resource"
(
  "ResourceID",
  "ResourceName",
  "ResourceDescription",
  "IsActive",
  "IsDeleted",
  "ParentID"
)
VALUES (
  NcResID,
  'NewInternalMessages Notification',
  'NewInternalMessages Resource',
  true,
  false,
  null
);

-- Operations for Notification View/Edit/Send/Configure/MarkAsRead/MarkAsUnRead/Edit MUST EXIST FIRST

-- For
INSERT INTO
  public."NotificationConstructClaimTemplate"
(
  "NotificationConstructTemplateID",
  "NotificationConstructTemplateVersionNumber",
  "NotificationConstructRoleID",
  "ResourceID",
  "OperationID",
  "StateID",
  "StateItemID",
  "IsActive",
  "IsDeleted",
  "RoleID"
)
VALUES (
  NcTID,
  NcTVN,
  null,
  NcResID,
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1),
  null,
  null,
  true,
  false,
  OrgEmployeeRoleID
);

INSERT INTO
  public."ResourceOperationTarget"("ResourceID", "OperationID", "OrganisationTypeID", "UserTypeID")
VALUES
  (NcResID,(select "OperationID" from "Operation" where "OperationName" = 'View' limit 1),31,UserUserTypeID);

INSERT INTO
  public."NotificationConstructClaimTemplate"
(
  "NotificationConstructTemplateID",
  "NotificationConstructTemplateVersionNumber",
  "NotificationConstructRoleID",
  "ResourceID",
  "OperationID",
  "StateID",
  "StateItemID",
  "IsActive",
  "IsDeleted",
  "RoleID"
)
VALUES (
  NcTID,
  NcTVN,
  null,
  NcResID,
  (select "OperationID" from "Operation" where "OperationName" = 'MarkAsRead' limit 1),
  null,
  null,
  true,
  false,
  OrgEmployeeRoleID
);

INSERT INTO
  public."ResourceOperationTarget"("ResourceID", "OperationID", "OrganisationTypeID", "UserTypeID")
VALUES
  (NcResID,(select "OperationID" from "Operation" where "OperationName" = 'MarkAsRead' limit 1),31,UserUserTypeID);


INSERT INTO
  public."NotificationConstructClaimTemplate"
(
  "NotificationConstructTemplateID",
  "NotificationConstructTemplateVersionNumber",
  "NotificationConstructRoleID",
  "ResourceID",
  "OperationID",
  "StateID",
  "StateItemID",
  "IsActive",
  "IsDeleted",
  "RoleID"
)
VALUES (
  NcTID,
  NcTVN,
  null,
  NcResID,
  (select "OperationID" from "Operation" where "OperationName" = 'MarkAsUnread' limit 1),
  null,
  null,
  true,
  false,
  OrgEmployeeRoleID
);

INSERT INTO
  public."ResourceOperationTarget"("ResourceID", "OperationID", "OrganisationTypeID", "UserTypeID")
VALUES
  (NcResID,(select "OperationID" from "Operation" where "OperationName" = 'MarkAsUnread' limit 1),31,UserUserTypeID);


INSERT INTO
  public."NotificationConstructClaimTemplate"
(
  "NotificationConstructTemplateID",
  "NotificationConstructTemplateVersionNumber",
  "NotificationConstructRoleID",
  "ResourceID",
  "OperationID",
  "StateID",
  "StateItemID",
  "IsActive",
  "IsDeleted",
  "RoleID"
)
VALUES (
  NcTID,
  NcTVN,
  null,
  NcResID,
  (select "OperationID" from "Operation" where "OperationName" = 'Send' limit 1),
  null,
  null,
  true,
  false,
  OrgEmployeeRoleID
);

INSERT INTO
  public."ResourceOperationTarget"("ResourceID", "OperationID", "OrganisationTypeID", "UserTypeID")
VALUES
  (NcResID,(select "OperationID" from "Operation" where "OperationName" = 'Send' limit 1),31,UserUserTypeID);


INSERT INTO
  public."NotificationConstructClaimTemplate"
(
  "NotificationConstructTemplateID",
  "NotificationConstructTemplateVersionNumber",
  "NotificationConstructRoleID",
  "ResourceID",
  "OperationID",
  "StateID",
  "StateItemID",
  "IsActive",
  "IsDeleted",
  "RoleID"
)
VALUES (
  NcTID,
  NcTVN,
  null,
  NcResID,
  (select "OperationID" from "Operation" where "OperationName" = 'Configure' limit 1),
  null,
  null,
  true,
  false,
  OrgEmployeeRoleID
);

INSERT INTO
  public."ResourceOperationTarget"("ResourceID", "OperationID", "OrganisationTypeID", "UserTypeID")
VALUES
  (NcResID,(select "OperationID" from "Operation" where "OperationName" = 'Configure' limit 1),31,UserUserTypeID);


INSERT INTO
  public."NotificationConstructClaimTemplate"
(
  "NotificationConstructTemplateID",
  "NotificationConstructTemplateVersionNumber",
  "NotificationConstructRoleID",
  "ResourceID",
  "OperationID",
  "StateID",
  "StateItemID",
  "IsActive",
  "IsDeleted",
  "RoleID"
)
VALUES (
  NcTID,
  NcTVN,
  null,
  NcResID,
  (select "OperationID" from "Operation" where "OperationName" = 'Edit' limit 1),
  null,
  null,
  true,
  false,
  OrgEmployeeRoleID
);

INSERT INTO
  public."ResourceOperationTarget"("ResourceID", "OperationID", "OrganisationTypeID", "UserTypeID")
VALUES
  (NcResID,(select "OperationID" from "Operation" where "OperationName" = 'Edit' limit 1),31,UserUserTypeID);


-- add claims to role so that

-- Add to DOT for specific org type

INSERT INTO
  public."DefaultOrganisationNotificationConstructTemplate"
(
  "DefaultOrganisationTemplateID",
  "NotificationConstructTemplateID",
  "NotificationConstructTemplateVersionNumber",
  "ParentID",
  "DefaultOrganisationTemplateVersionNumber"
)
VALUES (
  (select "DefaultOrganisationTemplateID" from "DefaultOrganisationTemplate" where "Name" = 'Professional Organisation' limit 1),
  NcTID,
  NcTVN,
  null,
  (select "DefaultOrganisationTemplateVersionNumber" from "DefaultOrganisationTemplate" where "Name" = 'Professional Organisation' limit 1)
);


END $$;

SELECT * FROM public."fn_PromoteNotificationConstructTemplate"('DA37A2E3-AA35-4CC5-A768-3DDC0C262110', 1);

-- object recreation
DROP VIEW public."vDefaultEmailAddress";

CREATE VIEW public."vDefaultEmailAddress"(
    "UserID",
    "Username",
    "Email",
    "UserAccountOrganisationID",
    "BranchOrganisationID",
    "BranchEmailAddress",
    "OrganisationID",
    "EmailAddress1",
    "UserAccountOrganisationIsActive",
    "OrganisationIsActive",
    "UserAccountIsActive",
    "IsLoginAllowed",
    "IsTemporaryAccount")
AS
  SELECT ua."ID" AS "UserID",
         ua."Username",
         ua."Email",
         uao."UserAccountOrganisationID",
         uao."OrganisationID" AS "BranchOrganisationID",
         con."EmailAddress1" AS "BranchEmailAddress",
         COALESCE(porg."OrganisationID", uao."OrganisationID") AS
           "OrganisationID",
         pcon."EmailAddress1",
         uao."IsActive" AS "UserAccountOrganisationIsActive",
         org."IsActive" AS "OrganisationIsActive",
         ua."IsActive" AS "UserAccountIsActive",
         ua."IsLoginAllowed",
         ua."IsTemporaryAccount"
  FROM "UserAccounts" ua
       JOIN "UserAccountOrganisation" uao ON uao."UserID" = ua."ID"
       LEFT JOIN "Organisation" org ON org."OrganisationID" =
         uao."OrganisationID"
       LEFT JOIN "Contact" con ON con."ParentID" = uao."OrganisationID" AND
         con."IsPrimaryContact" = true
       LEFT JOIN "Address" addr ON addr."ParentID" = con."ContactID" AND
         addr."IsPrimaryAddress" = true
       LEFT JOIN "Organisation" porg ON porg."OrganisationID" =
         org."ParentOrganisationID"
       LEFT JOIN "Contact" pcon ON pcon."ParentID" = org."OrganisationID" AND
         pcon."IsPrimaryContact" = true
       LEFT JOIN "Address" paddr ON paddr."ParentID" = pcon."ContactID" AND
         paddr."IsPrimaryAddress" = true;

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."vDefaultEmailAddress" TO postgres;
GRANT SELECT
  ON public."vDefaultEmailAddress" TO PUBLIC;
GRANT SELECT
  ON public."vDefaultEmailAddress" TO bef;

-- Update to Mark as Safe notification

-- UPDATE ENTRIES IN NotificationConstructClaimTemplate
UPDATE public."NotificationConstructClaimTemplate"
SET "RoleID" = (select "RoleID" from "Role" where "RoleName" = 'Organisation Employee' limit 1)
WHERE
     "NotificationConstructTemplateID" = (select "NotificationConstructTemplateID" from "NotificationConstructTemplate" WHERE "Name" LIKE 'BankAccountMarkedAsSafe' limit 1) AND
    "NotificationConstructTemplateVersionNumber" = 1 AND
    "ResourceID" = (select "ResourceID" from "Resource" WHERE "ResourceName" LIKE 'BankAccountMarkedAsSafe' limit 1);

-- UPDATE ENTRIES IN ResourceOperationTarget
UPDATE public."ResourceOperationTarget"
SET "UserTypeID" = (select "UserTypeID" from "UserType" where "Name" = 'Organisation Employee' limit 1)
WHERE
     "ResourceID" = (select "ResourceID" from "Resource" WHERE "ResourceName" LIKE 'BankAccountMarkedAsSafe' limit 1);

-- UPDATE ENTRIES IN NotificationConstructClaim
UPDATE "NotificationConstructClaim"
SET "RoleID" = (select "RoleID" from "Role" where "RoleName" = 'Organisation Employee' limit 1)
WHERE "ResourceID" = (select "ResourceID" from "Resource" WHERE "ResourceName" LIKE 'BankAccountMarkedAsSafe' limit 1);

-- UPDATE ENTRIES IN OrganisationRoleClaim
UPDATE "OrganisationRoleClaim" orc
SET "OrganisationRoleID" = (SELECT "OrganisationRoleID" FROM "OrganisationRole" WHERE "RoleName" LIKE 'Organisation Employee' and "OrganisationID" = orc."OrganisationID" limit 1)
WHERE    
     "ResourceID" = (select "ResourceID" from "Resource" WHERE "ResourceName" LIKE 'BankAccountMarkedAsSafe' limit 1) and
    "OrganisationRoleID" = (SELECT "OrganisationRoleID" FROM "OrganisationRole" WHERE "RoleName" LIKE 'Organisation Administrator' and "OrganisationID" = orc."OrganisationID" limit 1);

-- ADD MISSING ENTRIES IN OrganisationRoleClaim
DO $$
DECLARE
     entries CURSOR FOR
         SELECT '
          INSERT INTO
            public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
          SELECT
            nc."OrganisationRoleID",
            ncc."ResourceID",
            ncc."OperationID",
            ncc."StateID",
            ncc."StateItemID",
            ncc."IsActive",
            ncc."IsDeleted",
            ''' || o."OrganisationID" || '''
          FROM
            public."NotificationConstructClaim" ncc
            inner join "OrganisationRole" nc on nc."OrganisationID" = ''' || o."OrganisationID" || ''' and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and nc."IsDeleted" = false
            join "Resource" r on ncc."ResourceID" = r."ResourceID"
          where
            r."ResourceName" LIKE ''NewInternalMessages Notification'' AND
            ncc."IsActive" = true and
            ncc."IsDeleted" = false and
            not exists (
                         select
                           orc."OrganisationRoleClaimID"
                         from
                           "OrganisationRoleClaim" orc
                         where
                           orc."OrganisationID" = ''' || o."OrganisationID" || ''' and
                           orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                           orc."OperationID" = ncc."OperationID" and
                           orc."ResourceID" = ncc."ResourceID"
            ) and
            ncc."NotificationRoleConstructID" is null;' AS sql
FROM "Organisation" o;
BEGIN
   FOR entry IN entries LOOP
      EXECUTE entry.sql;
      raise notice '%', entry.sql;
   END LOOP;
END $$;


insert into "Setting"("Name", "Value") values ('CommonSettings.MessageBirdKey', 'live_1tKhusGs4mzO12QOm0d5mXZq0');
insert into "Setting"("Name", "Value") values ('CommonSettings.SMSOriginator', 'SMS');
insert into "Setting"("Name", "Value") values ('CommonSettings.SupportEmailAddress', 'support@beconsultancy.co.uk');
