-- =======================================================================
-- 01_TransactionsOverviewResourcesAndRoles
-- =======================================================================

insert into public."Resource"("ResourceID", "ResourceName", "ResourceDescription", "IsActive")
values (uuid_generate_v1(), 'SmsTransactionsOverview', 'SmsTransactionsOverview', TRUE);

INSERT INTO public."Role" ("RoleID", "RoleName", "RoleDescription", "RoleTypeID", "RoleSubTypeID", "RoleCategoryID", "RoleSubCategoryID", "IsActive", "IsDeleted", "IsGlobal")
VALUES (uuid_generate_v1(), E'Lender Employee', E'Lender Employee Role',
(select dot."ClassificationTypeID" from "ClassificationType" dot where dot."ClassificationTypeCategoryID" = 130 and dot."Name" = 'Global' limit 1),
 NULL, NULL, NULL, True, False, True);
 
-- Lender Administrator Add ProUsers
     insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Lender Administrator' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'ProUsers' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'Add' limit 1), TRUE);


-- Lender Employee view homepage
    insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Lender Employee' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'Home' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1), TRUE);

  -- Lender Employee SmsTransactionsOverview
    insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Lender Employee' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'SmsTransactionsOverview' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1), TRUE);

-- Delete redundant stuff
delete from public."RoleClaim"
  where 
	"RoleID" = (select "RoleID" from "Role" where "RoleName" = 'Lender Administrator' limit 1) AND 
	"ResourceID" = (select "ResourceID" from "Resource" where "ResourceName" = 'Home' limit 1) AND 
	"OperationID" = (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1);


-- ============== UPDATE Lender Template ========================
DO $$
Declare DoTemplateID uuid;
Declare DoVersionNumber integer;
Declare EmployeeRoleID uuid;
Declare DefaultOrganisationID uuid;

BEGIN
-- declare variables
	EmployeeRoleID := (select "RoleID" from "Role" where "RoleName" = 'Lender Employee' limit 1);
	DoTemplateID := (select dot."DefaultOrganisationTemplateID" from "DefaultOrganisationTemplate" dot where dot."Name" = 'Lender Organisation' limit 1);
	DoVersionNumber = 1;

	DefaultOrganisationID := (select dorg."DefaultOrganisationID" from "DefaultOrganisation" dorg 
	where dorg."DefaultOrganisationTemplateID" = DoTemplateID limit 1);

	INSERT INTO
	  public."DefaultOrganisationRoleTemplate"
	(
	  "DefaultOrganisationTemplateID",
	  "RoleID",
	  "IsDefaultOrganisationSpecific",
	  "DefaultOrganisationTemplateVersionNumber",
	  "IsDefault"
	)
	VALUES (
	  DoTemplateID,
	  EmployeeRoleID,
	  false,
	  DoVersionNumber,
	  true
	);
  
	INSERT INTO public."DefaultOrganisationRoleTargetTemplate"
	(
	  "DefaultOrganisationRoleTemplateID",
	  "DefaultOrganisationUserTargetTemplateID"
	)
	select
	(select dot."DefaultOrganisationRoleTemplateID" from "DefaultOrganisationRoleTemplate" dot where dot."DefaultOrganisationTemplateID" = DoTemplateID
  		and dot."RoleID" = EmployeeRoleID and dot."DefaultOrganisationTemplateVersionNumber" = DoVersionNumber limit 1),
		"DefaultOrganisationUserTargetTemplateID"
	from "DefaultOrganisationUserTargetTemplate"
	where "DefaultOrganisationTemplateID" = DoTemplateID and "DefaultOrganisationTemplateVersionNumber" = DoVersionNumber;

	INSERT INTO 
	  public."DefaultOrganisationRole"
	(
	  "DefaultOrganisationID",
	  "DefaultOrganisationVersionNumber",
	  "RoleName",
	  "RoleDescription",
	  "RoleTypeID",
	  "RoleSubTypeID",
	  "RoleCategoryID",
	  "RoleSubCategoryID",
	  "ParentID",
	  "RoleID",
	  "IsActive",
	  "IsDeleted",
	  "IsDefaultOrganisationSpecific",
	  "IsDefault"
	)
	SELECT 
	  DefaultOrganisationID,
	  1,
	  wt."RoleName",
	  wt."RoleDescription",
	  wt."RoleTypeID",
	  wt."RoleSubTypeID",
	  wt."RoleCategoryID",
	  wt."RoleSubCategoryID",
	  wt."DefaultOrganisationRoleTemplateID",
	  wt."RoleID",
	  wt."IsActive",
	  wt."IsDeleted",
	  wt."IsDefaultOrganisationSpecific",
	  wt."IsDefault"
	FROM 
		public."DefaultOrganisationRoleTemplate"  wt 
		join public."Role" r on wt."RoleID" = r."RoleID"
	  where wt."DefaultOrganisationTemplateID" = DoTemplateID and wt."DefaultOrganisationTemplateVersionNumber" = DoVersionNumber AND
		r."RoleName" = 'Lender Employee';
  

  -- ROLE CLAIM
	INSERT INTO 
	  public."DefaultOrganisationRoleClaim"
	(
	  "DefaultOrganisationRoleID",
	  "ResourceID",
	  "OperationID",
	  "StateID",
	  "StateItemID",
	  "IsActive",
	  "IsDeleted"
	)
	SELECT 
	  dor."DefaultOrganisationRoleID",
	  dd."ResourceID",
	  dd."OperationID",
	  dd."StateID",
	  dd."StateItemID",
	  dd."IsActive",
	  dd."IsDeleted"
	FROM 
	  public."DefaultOrganisationRoleClaimTemplate" dd 
	  left outer join "DefaultOrganisationRoleTemplate" dort on dort."DefaultOrganisationRoleTemplateID" = dd."DefaultOrganisationRoleTemplateID"
	  left outer join "DefaultOrganisationRole" dor on dor."RoleName" = dort."RoleName" and dor."DefaultOrganisationID" = DefaultOrganisationID and dor."DefaultOrganisationVersionNumber" = DoVersionNumber
	  where dort."DefaultOrganisationTemplateID" = DoTemplateID and dort."DefaultOrganisationTemplateVersionNumber" = DoVersionNumber AND
	  	dor."RoleName" = 'Lender Employee';


	INSERT INTO 
	  public."DefaultOrganisationRoleTarget"
	(
	  "DefaultOrganisationRoleID",
	  "IsActive",
	  "IsDeleted",
	  "DefaultOrganisationUserTargetID"
	)
	SELECT 
	  COALESCE(rg."DefaultOrganisationRoleID" ,rg1."DefaultOrganisationRoleID"),
	  wt."IsActive",
	  wt."IsDeleted",
	  dut."DefaultOrganisationUserTargetID"
	FROM 
	  public."DefaultOrganisationRoleTargetTemplate" wt 
	  left outer join "DefaultOrganisationUserTargetTemplate" ut on ut."DefaultOrganisationUserTargetTemplateID" = wt."DefaultOrganisationUserTargetTemplateID"
	  left outer join "DefaultOrganisationRoleTemplate" dor on dor."DefaultOrganisationRoleTemplateID" = wt."DefaultOrganisationRoleTemplateID" 
	  left outer join "DefaultOrganisationRole" rg on rg."RoleName" = dor."RoleName" and rg."DefaultOrganisationID" = DefaultOrganisationID and rg."DefaultOrganisationVersionNumber" = 1
	  left outer join "DefaultOrganisationRole" rg1 on rg1."RoleID" = dor."RoleID" and rg1."DefaultOrganisationID" = DefaultOrganisationID and rg1."DefaultOrganisationVersionNumber" = 1
	   left outer join "DefaultOrganisationUserTarget" dut on dut."ParentID" = ut."DefaultOrganisationUserTargetTemplateID"
	  left outer join "Role" r1 on r1."RoleID" = rg."RoleID"
	  left outer join "Role" r2 on r2."RoleID" = rg1."RoleID"
	  where ut."DefaultOrganisationTemplateID" = DoTemplateID and ut."DefaultOrganisationTemplateVersionNumber" = DoVersionNumber
  		and ut."DefaultOrganisationUserTargetTemplateID" is not null and COALESCE(rg."DefaultOrganisationRoleID" ,rg1."DefaultOrganisationRoleID") is not null
		 AND (r1."RoleName" = 'Lender Employee' OR r2."RoleName" = 'Lender Employee');
  
END $$;

-- =======================================================================
-- END - 01_TransactionsOverviewResourcesAndRoles
-- =======================================================================

-- =======================================================================
-- 02_lender-mapping
-- =======================================================================

ALTER TABLE public."Lender" ADD COLUMN "OrganisationID" UUID;

ALTER TABLE public."Lender"
  ADD CONSTRAINT "Lender_Organisation_fk" FOREIGN KEY ("OrganisationID")
    REFERENCES public."Organisation"("OrganisationID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;

-- =======================================================================
-- End - 02_lender-mapping
-- =======================================================================

-- =======================================================================
-- 03_SafeSendFunctions
-- =======================================================================

CREATE TABLE public."SafeSendGroup" (
  "SafeSendGroupID" UUID NOT NULL,
  "OrganisationTypeID" INTEGER NOT NULL,
  "Name" VARCHAR(100) NOT NULL UNIQUE,
  PRIMARY KEY("SafeSendGroupID")
);

ALTER TABLE public."SafeSendGroup"
  ADD CONSTRAINT "SafeSendGroup_OrganisationType_fk" FOREIGN KEY ("OrganisationTypeID")
    REFERENCES public."OrganisationType"("OrganisationTypeID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."SafeSendGroup" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."SafeSendGroup" TO bef;

-- =============

CREATE TABLE public."UserAccountOrganisationSafeSendGroup" (
  "UserAccountOrganisationID" UUID NOT NULL,
  "SafeSendGroupID" UUID NOT NULL,
  "IsActive" BOOLEAN DEFAULT true NOT NULL,
  "IsDeleted" BOOLEAN DEFAULT false NOT NULL,
  PRIMARY KEY("UserAccountOrganisationID", "SafeSendGroupID")
) ;

ALTER TABLE public."UserAccountOrganisationSafeSendGroup"
  ADD CONSTRAINT "UserAccountOrganisationSafeSendGroup_UserAccountOrganisation_fk" FOREIGN KEY ("UserAccountOrganisationID")
    REFERENCES public."UserAccountOrganisation"("UserAccountOrganisationID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;

ALTER TABLE public."UserAccountOrganisationSafeSendGroup"
  ADD CONSTRAINT "UserAccountOrganisationSafeSendGroup_SafeSendGroup_fk" FOREIGN KEY ("SafeSendGroupID")
    REFERENCES public."SafeSendGroup"("SafeSendGroupID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."UserAccountOrganisationSafeSendGroup" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."UserAccountOrganisationSafeSendGroup" TO bef;

-- =============

CREATE TABLE public."ConversationSafeSendGroupParticipant" (
  "ConversationID" UUID NOT NULL,
  "OrganisationID" UUID NOT NULL,
  "SafeSendGroupID" UUID NOT NULL,
  "Added" TIMESTAMP(0) WITH TIME ZONE DEFAULT now() NOT NULL,
  PRIMARY KEY("ConversationID", "SafeSendGroupID")
);

ALTER TABLE public."ConversationSafeSendGroupParticipant"
  ADD CONSTRAINT "ConversationSafeSendGroupParticipant_Conversation_fk" FOREIGN KEY ("ConversationID")
    REFERENCES public."Conversation"("ConversationID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;

ALTER TABLE public."ConversationSafeSendGroupParticipant"
  ADD CONSTRAINT "ConversationSafeSendGroupParticipant_Organisation_fk" FOREIGN KEY ("OrganisationID")
    REFERENCES public."Organisation"("OrganisationID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;
    
ALTER TABLE public."ConversationSafeSendGroupParticipant"
  ADD CONSTRAINT "ConversationSafeSendGroupParticipant_SafeSendGroup_fk" FOREIGN KEY ("SafeSendGroupID")
    REFERENCES public."SafeSendGroup"("SafeSendGroupID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."ConversationSafeSendGroupParticipant" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."ConversationSafeSendGroupParticipant" TO bef;

-- =============

INSERT INTO public."SafeSendGroup"("SafeSendGroupID", "OrganisationTypeID", "Name") VALUES (uuid_generate_v1(), 38, 'Mortgage Offer');
INSERT INTO public."SafeSendGroup"("SafeSendGroupID", "OrganisationTypeID", "Name") VALUES (uuid_generate_v1(), 38, 'Valuation/Security Risk Reporting');
INSERT INTO public."SafeSendGroup"("SafeSendGroupID", "OrganisationTypeID", "Name") VALUES (uuid_generate_v1(), 38, 'Fraud Risk Reporting');
INSERT INTO public."SafeSendGroup"("SafeSendGroupID", "OrganisationTypeID", "Name") VALUES (uuid_generate_v1(), 38, 'Certificate of Title');
INSERT INTO public."SafeSendGroup"("SafeSendGroupID", "OrganisationTypeID", "Name") VALUES (uuid_generate_v1(), 38, 'Redemption Statement');
INSERT INTO public."SafeSendGroup"("SafeSendGroupID", "OrganisationTypeID", "Name") VALUES (uuid_generate_v1(), 38, 'Title Information Document');
INSERT INTO public."SafeSendGroup"("SafeSendGroupID", "OrganisationTypeID", "Name") VALUES (uuid_generate_v1(), 38, 'Requisitions at HMLR');

-- =======================================================================
-- End - 03_SafeSendFunctions
-- =======================================================================

-- =======================================================================
-- 04_conversations-update
-- =======================================================================

CREATE OR REPLACE VIEW public."vConversation"(
    "ConversationID",
    "UserAccountOrganisationID",
    "Subject",
    "Latest",
    "ActivityID",
    "ActivityType",
    "IsSystemMessage")
AS
  SELECT c."ConversationID",
         v."UserAccountOrganisationID",
         c."Subject",
         c."Latest",
         c."ActivityID",
         c."ActivityType",
         c."IsSystemMessage"
  FROM "Conversation" c 
  join
  (SELECT cp."ConversationID", cp."UserAccountOrganisationID" FROM "ConversationParticipant" cp
   UNION
  SELECT cfp."ConversationID" ,uaof."UserAccountOrganisationID"
   FROM "UserAccountOrganisationSafeSendGroup" uaof
   JOIN "UserAccountOrganisation" uao ON uao."UserAccountOrganisationID" = uaof."UserAccountOrganisationID"
   JOIN "ConversationSafeSendGroupParticipant" cfp ON cfp."SafeSendGroupID" = uaof."SafeSendGroupID" AND cfp."OrganisationID" = uao."OrganisationID")
  v on v."ConversationID" = c."ConversationID";



 -- object recreation
DROP FUNCTION public."fn_GetConversationActivity"(orgid uuid, activitytype integer, activityid uuid, l integer, o integer);

CREATE FUNCTION public."fn_GetConversationActivity" (
  orgid uuid,
  activitytype integer,
  activityid uuid,
  l integer,
  o integer,
  userorgtypename varchar,
  uaoid uuid
)
RETURNS TABLE (
  "ConversationID" uuid,
  "Subject" varchar,
  "Latest" timestamptz
) AS
$body$
BEGIN
if (userorgtypename = 'Professional') then
  --anyone in org
  return query SELECT c."ConversationID", c."Subject", c."Latest" FROM "Conversation" c
  WHERE (
   exists (select * from "ConversationParticipant" cp join "UserAccountOrganisation" uao on cp."UserAccountOrganisationID" = uao."UserAccountOrganisationID"
   where uao."OrganisationID" = orgid and cp."ConversationID" = c."ConversationID")
  )
  and 
  (c."ActivityType" = activitytype) AND (c."ActivityID" = activityid) AND (c."IsSystemMessage" = false)
  order by c."Latest" desc
  limit l offset o;

elsif (userorgtypename = 'Lender') then
  --exact uao or in SafeSendGroup
  return query SELECT c."ConversationID", c."Subject", c."Latest" FROM "Conversation" c
  WHERE (
   exists (select * from "ConversationParticipant" cp
   where cp."UserAccountOrganisationID" = uaoid and cp."ConversationID" = c."ConversationID")
  or
   exists (select * from "ConversationSafeSendGroupParticipant" cfp join "UserAccountOrganisationSafeSendGroup" uaof on uaof."SafeSendGroupID" = cfp."SafeSendGroupID"
   where cfp."ConversationID" = c."ConversationID" and cfp."OrganisationID" = orgid and uaof."UserAccountOrganisationID" = uaoid)
  )
  and 
  (c."ActivityType" = activitytype) AND (c."ActivityID" = activityid) AND (c."IsSystemMessage" = false)
  order by c."Latest" desc
  limit l offset o;
else
  --exact uao
  return query SELECT c."ConversationID", c."Subject", c."Latest" FROM "Conversation" c
  WHERE (
   exists (select * from "ConversationParticipant" cp
   where cp."UserAccountOrganisationID" = uaoid and cp."ConversationID" = c."ConversationID")
  )
  and 
  (c."ActivityType" = activitytype) AND (c."ActivityID" = activityid) AND (c."IsSystemMessage" = false)
  order by c."Latest" desc
  limit l offset o;
end if;


END;
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER
COST 100 ROWS 1000;





 -- object recreation
DROP FUNCTION public."fn_GetConversationActivityCount"(orgid uuid, activitytype integer, activityid uuid);

CREATE FUNCTION public."fn_GetConversationActivityCount" (
  orgid uuid,
  activitytype integer,
  activityid uuid,
  userorgtypename varchar,
  uaoid uuid
)
RETURNS integer AS
$body$
BEGIN
if (userorgtypename = 'Professional') then

return (SELECT count(*) FROM "Conversation" c
WHERE (
 exists (select * from "ConversationParticipant" cp join "UserAccountOrganisation" uao on cp."UserAccountOrganisationID" = uao."UserAccountOrganisationID"
 where uao."OrganisationID" = orgid and cp."ConversationID" = c."ConversationID")
)
and (c."ActivityType" = activitytype) AND (c."ActivityID" = activityid) AND (c."IsSystemMessage" = false));

elsif (userorgtypename = 'Lender') then

return (SELECT count(*) FROM "Conversation" c
WHERE (
 exists (select * from "ConversationParticipant" cp
 where cp."UserAccountOrganisationID" = uaoid and cp."ConversationID" = c."ConversationID")
or
 exists (select * from "ConversationSafeSendGroupParticipant" cfp join "UserAccountOrganisationSafeSendGroup" uaof on uaof."SafeSendGroupID" = cfp."SafeSendGroupID"
 where cfp."ConversationID" = c."ConversationID" and cfp."OrganisationID" = orgid and uaof."UserAccountOrganisationID" = uaoid)
)
and (c."ActivityType" = activitytype) AND (c."ActivityID" = activityid) AND (c."IsSystemMessage" = false));

else

return (SELECT count(*) FROM "Conversation" c
WHERE (
 exists (select * from "ConversationParticipant" cp
 where cp."UserAccountOrganisationID" = uaoid and cp."ConversationID" = c."ConversationID")
)
and (c."ActivityType" = activitytype) AND (c."ActivityID" = activityid) AND (c."IsSystemMessage" = false));

end if;

END;
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER
COST 100;



 -- object recreation
DROP VIEW public."vSafeSendRecipient";

CREATE VIEW public."vSafeSendRecipient"(
    "SmsTransactionID",
    "RelatedID",
    "OrganisationID",
    "FirstName",
    "LastName",
    "OrganisationName",
    "OrganisationTypeName",
    "IsSafeSendGroup")
AS
  SELECT uaot."SmsTransactionID",
         uao."UserAccountOrganisationID" AS "RelatedID",
         uao."OrganisationID",
         c."FirstName",
         c."LastName",
         NULL::character varying AS "OrganisationName",
         'Personal' as "OrganisationTypeName",
         false AS "IsSafeSendGroup"
  FROM sms."SmsUserAccountOrganisationTransaction" uaot
       JOIN "UserAccountOrganisation" uao ON uaot."UserAccountOrganisationID" =
         uao."UserAccountOrganisationID"
       JOIN "Contact" c ON uao."PrimaryContactID" = c."ContactID"
       JOIN "UserAccounts" ua ON uao."UserID" = ua."ID"
  WHERE uao."IsActive" = true AND
        ua."IsActive" = true AND
        ua."IsLoginAllowed" = true AND
        ua."IsTemporaryAccount" = false
  UNION
  SELECT t."SmsTransactionID",
         uao."UserAccountOrganisationID" AS "RelatedID",
         o."OrganisationID",
         c."FirstName",
         c."LastName",
         od."Name" AS "OrganisationName",
		 ot."Name" as "OrganisationTypeName",
         false AS "IsSafeSendGroup"
  FROM sms."SmsTransaction" t
       JOIN "Organisation" o ON t."OrganisationID" = o."OrganisationID"
       JOIN "OrganisationDetail" od ON o."OrganisationID" = od."OrganisationID"
       JOIN "OrganisationType" ot ON o."OrganisationTypeID" =
         ot."OrganisationTypeID"
       JOIN "UserAccountOrganisation" uao ON o."OrganisationID" =
         uao."OrganisationID"
       JOIN "Contact" c ON uao."PrimaryContactID" = c."ContactID"
       JOIN "UserAccounts" ua ON uao."UserID" = ua."ID"
  WHERE uao."IsActive" = true AND
        ua."IsActive" = true AND
        ua."IsLoginAllowed" = true AND
        ua."IsTemporaryAccount" = false
  UNION
  SELECT t."SmsTransactionID",
         f."SafeSendGroupID" AS "RelatedID",
         o."OrganisationID",
         f."Name" AS "FirstName",
         NULL::character varying (100) AS "LastName",
         od."Name" AS "OrganisationName",
		 ot."Name" as "OrganisationTypeName",
         true AS "IsSafeSendGroup"
  FROM sms."SmsTransaction" t
       JOIN "Lender" l ON l."Name"::text = t."LenderName"::text
       JOIN "Organisation" o ON l."OrganisationID" = o."OrganisationID"
       JOIN "OrganisationDetail" od ON o."OrganisationID" = od."OrganisationID"
       JOIN "OrganisationType" ot ON o."OrganisationTypeID" =
         ot."OrganisationTypeID"
       JOIN "SafeSendGroup" f ON ot."OrganisationTypeID" = f."OrganisationTypeID"
  WHERE EXISTS(
  	SELECT *
    FROM "UserAccountOrganisation" uao
    JOIN "UserAccounts" ua ON uao."UserID" = ua."ID"
    JOIN "UserAccountOrganisationSafeSendGroup" uaossg ON uao."UserAccountOrganisationID" = uaossg."UserAccountOrganisationID"
    WHERE
    	uao."OrganisationID" = o."OrganisationID" and
        uaossg."SafeSendGroupID" = f."SafeSendGroupID" and
    	uao."IsActive" = true and 
    	uao."IsDeleted" = false and
        ua."IsLoginAllowed" = true and
        ua."IsActive" = true and
        ua."IsTemporaryAccount" = false);

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."vSafeSendRecipient" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."vSafeSendRecipient" TO bef;


ALTER TABLE public."Notification" ADD COLUMN "CreatedBySafeSendGroupID" UUID;


 -- object recreation
DROP VIEW public."vMessage";

CREATE VIEW public."vMessage"(
    "ConversationID",
    "NotificationID",
    "CreatedByUserAccountOrganisationID",
    "DateSent",
    "NotificationData",
    "Email",
    "FirstName",
    "LastName",
    "OrganisationName",
    "UserType",
    "OrganisationType",
    "NotificationConstructName",
    "SafeSendGroupName")
AS
  SELECT n."ConversationID",
         n."NotificationID",
         n."CreatedByUserAccountOrganisationID",
         n."DateSent",
         n."NotificationData",
         ua."Email",
         c."FirstName",
         c."LastName",
         orgd."Name" AS "OrganisationName",
         CASE
           WHEN ct."Name"::text = 'SmsTransaction'::text THEN CASE
                                                                WHEN ot."Name"::
                                                                  text =
                                                                  'Personal'::
                                                                  text THEN
                                                                  txt."Description"
                                                                WHEN ot."Name"::
                                                                  text =
                                                                  'Professional'
                                                                  ::text THEN
                                                                  'Conveyancer'
                                                                  ::character
                                                                  varying
                                                                WHEN ot."Name"::
                                                                  text =
                                                                  'Lender'::text
                                                                  THEN 'Lender'
                                                                  ::character
                                                                  varying
                                                                ELSE NULL::
                                                                  character
                                                                  varying
                                                              END
           ELSE NULL::character varying
         END AS "UserType",
         ot."Name" AS "OrganisationType",
         nc."Name" AS "NotificationConstructName",
         f."Name" as "SafeSendGroupName"
  FROM "Notification" n
       JOIN "Conversation" conv ON conv."ConversationID" = n."ConversationID"
       JOIN "NotificationConstruct" nc ON nc."NotificationConstructID" =
         n."NotificationConstructID" AND nc."NotificationConstructVersionNumber"
         = n."NotificationConstructVersionNumber"
       LEFT JOIN "UserAccountOrganisation" uao ON
         uao."UserAccountOrganisationID" =
         n."CreatedByUserAccountOrganisationID"
       LEFT JOIN "UserAccounts" ua ON ua."ID" = uao."UserID"
       LEFT JOIN "Organisation" org ON org."OrganisationID" =
         uao."OrganisationID"
       LEFT JOIN "OrganisationDetail" orgd ON orgd."OrganisationID" =
         org."OrganisationID"
       LEFT JOIN "OrganisationType" ot ON ot."OrganisationTypeID" =
         org."OrganisationTypeID"
       LEFT JOIN "Contact" c ON c."ContactID" = uao."PrimaryContactID"
       JOIN "ClassificationTypeCategory" ctc ON ctc."Name"::text =
         'ActivityTypeID'::text
       LEFT JOIN "ClassificationType" ct ON ct."ClassificationTypeCategoryID" =
         ctc."ClassificationTypeCategoryID" AND ct."ClassificationTypeID" =
         conv."ActivityType"
       LEFT JOIN sms."SmsUserAccountOrganisationTransaction" tx ON
         tx."SmsTransactionID" = conv."ActivityID" AND
         tx."UserAccountOrganisationID" = n."CreatedByUserAccountOrganisationID"
       LEFT JOIN sms."SmsUserAccountOrganisationTransactionType" txt ON
         txt."SmsUserAccountOrganisationTransactionTypeID" =
         tx."SmsUserAccountOrganisationTransactionTypeID"
       left join "SafeSendGroup" f on f."SafeSendGroupID" = n."CreatedBySafeSendGroupID" and f."OrganisationTypeID" = ot."OrganisationTypeID";

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."vMessage" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."vMessage" TO bef;

-- =======================================================================
-- End - 04_conversations-update
-- =======================================================================

-- =======================================================================
-- 05_delegate-sro-authority
-- =======================================================================

ALTER TABLE public."Organisation"
  ADD COLUMN "AuthorityDelegatedByContactID" UUID;

ALTER TABLE public."Organisation"
  ADD CONSTRAINT "Organisation_Contact_fk" FOREIGN KEY ("AuthorityDelegatedByContactID")
    REFERENCES public."Contact"("ContactID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;

	
DROP VIEW public."vOrganisationWithStatusAndAdmin";

CREATE VIEW public."vOrganisationWithStatusAndAdmin" (
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
    "RegisteredAsName",
    "OrganisationRecommendationSourceID",
    "SchemeID",
    "FilesPerMonth",
    "ActiveSafeAccounts",
	"PendingValidationAccounts",
    "OrganisationTypeDescription",
    "BrokerType",
    "BrokerBusinessType",
	"AuthorityDelegatedBySalutation",
	"AuthorityDelegatedByFirstName",
	"AuthorityDelegatedByLastName",
	"AuthorityDelegatedByEmail")
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
    orgd."RegisteredAsName",
    org."OrganisationRecommendationSourceID",
    org."SchemeID",
    org."FilesPerMonth",
    COALESCE(sb."ActiveSafeAccounts", 0::bigint) AS "ActiveSafeAccounts",
	COALESCE(pvb."PendingValidationAccounts", 0::bigint) AS "PendingValidationAccounts",
    orgt."Description" AS "OrganisationTypeDescription",
    org."BrokerType",
    org."BrokerBusinessType",
	adc."Salutation",
	adc."FirstName",
	adc."LastName",
	adc."EmailAddress1"
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
                max(os."StatusChangedOn") AS "StatusChangedOn"
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
         verifiedjoin."StatusTypeVersionNumber" AND
         verifiedstatus."StatusChangedOn" = verifiedjoin."StatusChangedOn"
       LEFT JOIN 
       (
         SELECT ba."OrganisationID",
                count(ba."OrganisationBankAccountID") AS "ActiveSafeAccounts"
         FROM "OrganisationBankAccount" ba
         WHERE ba."IsActive" = true AND
               (((
                   SELECT st."Name"
                   FROM "OrganisationBankAccountStatus" s
                        LEFT JOIN "StatusTypeValue" st ON st."StatusTypeID" =
                          s."StatusTypeID" AND st."StatusTypeValueID" =
                          s."StatusTypeValueID"
                   WHERE s."OrganisationBankAccountID" =
                     ba."OrganisationBankAccountID"
                   ORDER BY s."StatusChangedOn" DESC
                   LIMIT 1
               ))::text) = 'Safe'::text
         GROUP BY ba."OrganisationID"
       ) sb ON sb."OrganisationID" = org."OrganisationID"
       LEFT JOIN 
       (
         SELECT ba."OrganisationID",
                count(ba."OrganisationBankAccountID") AS "PendingValidationAccounts"
         FROM "OrganisationBankAccount" ba
         WHERE (((
                   SELECT st."Name"
                   FROM "OrganisationBankAccountStatus" s
                        LEFT JOIN "StatusTypeValue" st ON st."StatusTypeID" =
                          s."StatusTypeID" AND st."StatusTypeValueID" =
                          s."StatusTypeValueID"
                   WHERE s."OrganisationBankAccountID" =
                     ba."OrganisationBankAccountID"
                   ORDER BY s."StatusChangedOn" DESC
                   LIMIT 1
               ))::text) = 'Pending Validation'::text
         GROUP BY ba."OrganisationID"
       ) pvb ON pvb."OrganisationID" = org."OrganisationID"
	   LEFT JOIN "Contact" adc ON org."AuthorityDelegatedByContactID" = adc."ContactID"
  WHERE (orgt."Name"::text <> ALL (ARRAY [ 'Temporary'::character varying::text,
    'Personal'::character varying::text, 'Administration'::character varying::
    text, 'Supplier'::character varying::text ])) AND
        orgc."ContactID" IS NOT NULL AND
        (ua."IsDeleted" IS NULL OR
        ua."IsDeleted" = false);

grant select, insert, update, delete on public."vOrganisationWithStatusAndAdmin" to bef;
grant select, insert, update, delete on public."vOrganisationWithStatusAndAdmin" to postgres;

-- =======================================================================
-- End - 05_delegate-sro-authority
-- =======================================================================

-- =======================================================================
-- 06_update-pin-message
-- =======================================================================

update "Setting"
set "Value" = 'PIN'
where "Name" = 'CommonSettings.SMSOriginator';

-- =======================================================================
-- End - 06_update-pin-message
-- =======================================================================

-- =======================================================================
-- 07_update-organisation-settings
-- =======================================================================

DROP TABLE public."OrganisationSetting";

CREATE TABLE public."OrganisationSetting" (
  "OrganisationSettingID" UUID NOT NULL,
  "Name" VARCHAR(200) NOT NULL,
  "Value" VARCHAR(2000) NOT NULL,
  "IsActive" BOOLEAN DEFAULT true NOT NULL,
  "IsDeleted" BOOLEAN DEFAULT false NOT NULL,
  "OrganisationID" UUID NOT NULL,
  CONSTRAINT "pkOrganisationSetting" PRIMARY KEY("OrganisationSettingID"),
  CONSTRAINT "fk_OrganisationSetting_Organisation" FOREIGN KEY ("OrganisationID")
    REFERENCES public."Organisation"("OrganisationID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE
) 
WITH (oids = false);

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."OrganisationSetting" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."OrganisationSetting" TO bef;

-- =======================================================================
-- End - 07_update-organisation-settings
-- =======================================================================