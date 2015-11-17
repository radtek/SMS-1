ALTER TABLE public."DefaultOrganisationRoleTemplate" ADD COLUMN "IsDefault" BOOLEAN DEFAULT false NOT NULL;
ALTER TABLE public."DefaultOrganisationRole" ADD COLUMN "IsDefault" BOOLEAN DEFAULT FALSE NOT NULL;
ALTER TABLE public."OrganisationRole" ADD COLUMN "IsDefault" BOOLEAN DEFAULT false NOT NULL;

update "DefaultOrganisationRoleTemplate" a
set "IsDefault" = true
from "Role" r 
where r."RoleID" = a."RoleID" and r."RoleName" in ('Support Administrator', 'Organisation Employee', 'User');

update "DefaultOrganisationRole" a
set "IsDefault" = true
from "Role" r 
where r."RoleID" = a."RoleID" and r."RoleName" in ('Support Administrator', 'Organisation Employee', 'User');

update "Role" set "RoleDescription" = 'Administration User: This role gives the highest level of administrative permissions' where "RoleName" = 'Administration User';
update "Role" set "RoleDescription" = 'Organisation Administrator: This role gives permission to add users and bank accounts' where "RoleName" = 'Organisation Administrator';
update "Role" set "RoleDescription" = 'Finance Administrator: This role gives permission to configure bank accounts' where "RoleName" = 'Finance Administrator';

update "OrganisationRole" set "IsDefault" = true where "RoleName" in ('Support Administrator', 'Organisation Employee', 'User');

update "OrganisationRole" oro set "RoleDescription" = r."RoleDescription" from "Role" r where r."RoleID" = oro."ParentID";

--update function
CREATE OR REPLACE FUNCTION public."fn_PromoteDefaultOrganisationTemplate" (
  defaultorganisationtemplateid uuid,
  defaultorganisationtemplateversionnumber integer
)
RETURNS void AS
$body$
DECLARE
  DefaultOrganisationID UUID;
  DefaultOrganisationVersionNumber integer;
  LoopRow RECORD;
  LoopUUID UUID;
BEGIN
  
DefaultOrganisationID := (select dorg."DefaultOrganisationID" from "DefaultOrganisation" dorg 
	where dorg."DefaultOrganisationTemplateID" =  defaultorganisationtemplateid limit 1);
    
DefaultOrganisationVersionNumber := (select dorg."DefaultOrganisationVersionNumber" from "DefaultOrganisation" dorg 
	where dorg."DefaultOrganisationTemplateID" = defaultorganisationtemplateid order by dorg."DefaultOrganisationVersionNumber" desc limit 1);

if(DefaultOrganisationID is null or (DefaultOrganisationID is not null and defaultorganisationtemplateversionnumber is null))
THEN
BEGIN

-- populate variables
IF(DefaultOrganisationID is null)
THEN
BEGIN
	DefaultOrganisationID := uuid_generate_v1();
END;
END IF;


	DefaultOrganisationVersionNumber := defaultorganisationtemplateversionnumber;


-- insert DO
INSERT INTO 
  public."DefaultOrganisation"
(
  "DefaultOrganisationID",
  "DefaultOrganisationVersionNumber",
  "Name",
  "Description",
  "IsActive",
  "IsDeleted",
  "DefaultOrganisationTemplateID",
  "DefaultOrganisationTemplateVersionNumber",
  "OrganisationTypeID"
)
SELECT 
  DefaultOrganisationID,
  DefaultOrganisationVersionNumber,
  wt."Name",
  wt."Description",
  wt."IsActive",
  wt."IsDeleted",
  defaultorganisationtemplateid,
  defaultorganisationtemplateversionnumber,
  wt."OrganisationTypeID"
FROM 
  public."DefaultOrganisationTemplate" wt where wt."DefaultOrganisationTemplateID" = defaultorganisationtemplateid and wt."DefaultOrganisationTemplateVersionNumber" =defaultorganisationtemplateversionnumber ;

-- DOT ART
-- Check ART version exists
FOR LoopRow IN
	select * from "DefaultOrganisationArtefactTemplate"
    	where "DefaultOrganisationTemplateID" = defaultorganisationtemplateid and "DefaultOrganisationTemplateVersionNumber" = defaultorganisationtemplateversionnumber
        	and "ArtefactTemplateID" not in (select ar."ArtefactTemplateID" from "Artefact" ar where ar."ArtefactTemplateID" = "ArtefactTemplateID" and ar."ArtefactTemplateVersionNumber" = "ArtefactTemplateVersionNumber")
LOOP
    BEGIN
    	perform "fn_PromoteArtefactTemplate"(LoopRow."ArtefactTemplateID",LoopRow."ArtefactTemplateVersionNumber");
    END;
END LOOP;

-- Add DOT ARTS to DO
INSERT INTO 
  public."DefaultOrganisationArtefact"
(
  "DefaultOrganisationID",
  "DefaultOrganisationVersionNumber",
  "ArtefactID",
  "ArtefactVersionNumber",
  "ParentID",
  "IsActive",
  "IsDeleted"
)
SELECT 
  DefaultOrganisationID,
  DefaultOrganisationVersionNumber,
  ar."ArtefactID",
  ar."ArtefactVersionNumber",
  wt."ParentID",
  wt."IsActive",
  wt."IsDeleted"
FROM 
  public."DefaultOrganisationArtefactTemplate"  wt 
  
  left outer join "Artefact" ar on ar."ArtefactTemplateID" = wt."ArtefactTemplateID" and ar."ArtefactTemplateVersionNumber" = wt."ArtefactTemplateVersionNumber"

  where wt."DefaultOrganisationTemplateID" = defaultorganisationtemplateid and wt."DefaultOrganisationTemplateVersionNumber" =defaultorganisationtemplateversionnumber ;
  
---------------- END DOT ART
-- DOT MT
-- Check MT version exists
FOR LoopRow IN
	select * from "DefaultOrganisationModuleTemplate" 
    	where "DefaultOrganisationTemplateID" = defaultorganisationtemplateid and "DefaultOrganisationTemplateVersionNumber" = defaultorganisationtemplateversionnumber
        and "ModuleTemplateID" not in (select mt."ModuleTemplateID" from "Module" mt where mt."ModuleTemplateID" = "ModuleTemplateID" and mt."ModuleTemplateVersionNumber" = "ModuleTemplateVersionNumber")
LOOP
    BEGIN
    	perform "fn_PromoteModuleTemplate"(LoopRow."ModuleTemplateID",LoopRow."ModuleTemplateVersionNumber");
	END;
END LOOP;

-- Add DOT MT to DO
INSERT INTO 
  public."DefaultOrganisationModule"
(
  "DefaultOrganisationID",
  "DefaultOrganisationVersionNumber",
  "ModuleID",
  "ModuleVersionNumber",
  "ParentID",
  "IsActive",
  "IsDeleted"
)
SELECT 
  DefaultOrganisationID,
  DefaultOrganisationVersionNumber,
  m."ModuleID",
  m."ModuleVersionNumber",
  null,
  wt."IsActive",
  wt."IsDeleted"
FROM 
  public."DefaultOrganisationModuleTemplate"  wt 
  
  left outer join "Module" m on m."ModuleTemplateID" = wt."ModuleTemplateID" and m."ModuleTemplateVersionNumber" = wt."ModuleTemplateVersionNumber"
  
  where wt."DefaultOrganisationTemplateID" = defaultorganisationtemplateid and wt."DefaultOrganisationTemplateVersionNumber" =defaultorganisationtemplateversionnumber ;
------ End DOT MT 
---------------- END DOT ART
-- DOT STT
-- Check STT version exists
FOR LoopRow IN
	select * from "DefaultOrganisationStatusTypeTemplate" 
    	where "DefaultOrganisationTemplateID" = defaultorganisationtemplateid and "DefaultOrganisationTemplateVersionNumber" = defaultorganisationtemplateversionnumber
        and "StatusTypeTemplateID" not in (select st."StatusTypeTemplateID" from "StatusType" st where st."StatusTypeTemplateID" = "StatusTypeTemplateID" and st."StatusTypeTemplateVersionNumber" = "StatusTypeTemplateVersionNumber")
LOOP
    BEGIN
    	perform "fn_PromoteStatusTypeTemplate"(LoopRow."StatusTypeTemplateID",LoopRow."StatusTypeTemplateVersionNumber");
    END;
END LOOP;

-- Add DOT STT to DO
INSERT INTO 
  public."DefaultOrganisationStatusType"
(
  "DefaultOrganisationID",
  "DefaultOrganisationVersionNumber",
  "StatusTypeID",
  "StatusTypeVersionNumber",
  "ParentID",
  "IsActive",
  "IsDeleted",
  "DefaultStatusTypeValueID"
)
SELECT 
  DefaultOrganisationID,
  DefaultOrganisationVersionNumber,
  st."StatusTypeID",
  st."StatusTypeVersionNumber",
  wt."ParentID",
  wt."IsActive",
  wt."IsDeleted",
  stv."StatusTypeValueID"
FROM 
  public."DefaultOrganisationStatusTypeTemplate" wt
  
  left outer join "StatusType" st on st."StatusTypeTemplateID" = wt."StatusTypeTemplateID" and st."StatusTypeTemplateVersionNumber" = wt."StatusTypeTemplateVersionNumber"

  left outer join "StatusTypeValueTemplate" stvt on stvt."StatusTypeValueTemplateID" = wt."DefaultStatusTypeValueTemplateID"
  
  left outer join "StatusTypeValue" stv on stv."StatusTypeID" = st."StatusTypeID" and stv."StatusTypeVersionNumber" = st."StatusTypeVersionNumber"
  	and stv."Name" = stvt."Name"

  where wt."DefaultOrganisationTemplateID" = defaultorganisationtemplateid and wt."DefaultOrganisationTemplateVersionNumber" =defaultorganisationtemplateversionnumber ;
  
------ End DOT STT 

-- DOT NCT
-- Check NCT version exists
FOR LoopRow IN
	select * from "DefaultOrganisationNotificationConstructTemplate" 
    	where "DefaultOrganisationTemplateID" = defaultorganisationtemplateid and "DefaultOrganisationTemplateVersionNumber" = defaultorganisationtemplateversionnumber
        and "NotificationConstructTemplateID" not in (select nc."NotificationConstructTemplateID" from "NotificationConstruct" nc where nc."NotificationConstructTemplateID" = "NotificationConstructTemplateID"
        	and nc."NotificationConstructTemplateVersionNumber" = "NotificationConstructTemplateVersionNumber")
LOOP
    BEGIN
    	perform "fn_PromoteNotificationConstructTemplate"(LoopRow."NotificationConstructTemplateID",LoopRow."NotificationConstructTemplateVersionNumber");
    END;
END LOOP;

-- Add DOT NCT to DO
INSERT INTO 
  public."DefaultOrganisationNotificationConstruct"
(
  "DefaultOrganisationID",
  "DefaultOrganisationVersionNumber",
  "NotificationConstructID",
  "NotificationConstructVersionNumber",
  "ParentID",
  "IsActive",
  "IsDeleted"
)
SELECT 
  DefaultOrganisationID,
  DefaultOrganisationVersionNumber,
  st."NotificationConstructID",
  st."NotificationConstructVersionNumber",
  wt."ParentID",
  wt."IsActive",
  wt."IsDeleted"
FROM 
  public."DefaultOrganisationNotificationConstructTemplate" wt
  
  left outer join "NotificationConstruct" st on st."NotificationConstructTemplateID" = wt."NotificationConstructTemplateID" and st."NotificationConstructTemplateVersionNumber" = wt."NotificationConstructTemplateVersionNumber"
  
  where wt."DefaultOrganisationTemplateID" = defaultorganisationtemplateid and wt."DefaultOrganisationTemplateVersionNumber" =defaultorganisationtemplateversionnumber ;
------ End DOT NCT 

/*
-- DOT WT
-- Check WT version exists
FOR LoopRow IN
	select * from "DefaultOrganisationWorkflowTemplate" 
    	where "DefaultOrganisationTemplateID" = defaultorganisationtemplateid and "DefaultOrganisationTemplateVersionNumber" = defaultorganisationtemplateversionnumber
        and "WorkflowTemplateID" not in (select w."WorkflowTemplateID" from "Workflow" w where w."WorkflowTemplateID" = "WorkflowTemplateID" and w."WorkflowTemplateVersionNumber" = "WorkflowTemplateVersionNumber")
LOOP
    BEGIN
    	perform "fn_PromoteWorkflowTemplate"(LoopRow."WorkflowTemplateID",LoopRow."WorkflowTemplateVersionNumber");
    END;
END LOOP;

-- Add DOT WT to DO
INSERT INTO 
  public."DefaultOrganisationWorkflow"
(
  "DefaultOrganisationID",
  "DefaultOrganisationVersionNumber",
  "WorkflowID",
  "WorkflowVersionNumber",
  "ParentID",
  "IsActive",
  "IsDeleted"
)
SELECT 
  DefaultOrganisationID,
  DefaultOrganisationVersionNumber,
  st."WorkflowID",
  st."WorkflowVersionNumber",
  "ParentID",
  "IsActive",
  "IsDeleted"
FROM 
  public."DefaultOrganisationWorkflowTemplate"  wt
  
  left outer join "Workflow" st on st."WorkflowTemplateID" = wt."WorkflowTemplateID" and st."WorkflowTemplateVersionNumber" = wt."WorkflowTemplateVersionNumber"
  
  where wt."DefaultOrganisationTemplateID" = defaultorganisationtemplateid and wt."DefaultOrganisationTemplateVersionNumber" =defaultorganisationtemplateversionnumber ;
------ End DOT WT +*/

END;
END IF;
------ End MT 

-- Branch
INSERT INTO 
  public."DefaultOrganisationBranch"
(
  "DefaultOrganisationID",
  "DefaultOrganisationVersionNumber",
  "OrganisationTypeID",
  "BranchName",
  "BranchSubType"
)
SELECT 
  DefaultOrganisationID,
  DefaultOrganisationVersionNumber,
  wt."OrganisationTypeID",
  wt."BranchName",
  wt."BranchSubType"
FROM 
  public."DefaultOrganisationBranchTemplate" wt
  
  where wt."DefaultOrganisationTemplateID" = defaultorganisationtemplateid and wt."DefaultOrganisationTemplateVersionNumber" =defaultorganisationtemplateversionnumber ;

-- INSERT BUCKETS
INSERT INTO 
  public."Bucket"
(
  "BucketName",
  "BucketDescription",
  "BucketTypeID",
  "BucketSubTypeID",
  "BucketCategoryID",
  "BucketSubCategoryID",
  "IsGlobal",
  "IsActive",
  "IsDeleted"
)
SELECT 
  wt."BucketName",
  wt."BucketDescription",
  wt."BucketTypeID",
  wt."BucketSubTypeID",
  wt."BucketCategoryID",
  wt."BucketSubCategoryID",
  wt."IsGlobal",
  wt."IsActive",
  wt."IsDeleted"
FROM 
  public."BucketTemplate" wt
  
  inner join "DefaultOrganisationBucketTemplate" dt on dt."DefaultOrganisationTemplateID" = defaultorganisationtemplateid and dt."DefaultOrganisationTemplateVersionNumber" =defaultorganisationtemplateversionnumber 
  	and dt."BucketTemplateID" = wt."BucketTemplateID"
    
  where wt."BucketName" not in (select "BucketName" from "Bucket");
  
-- Bucket
INSERT INTO 
  public."DefaultOrganisationBucket"
(
  "DefaultOrganisationID",
  "DefaultOrganisationVersionNumber",
  "BucketTemplateID"
)
SELECT 
  DefaultOrganisationID,
  DefaultOrganisationVersionNumber,
  b."BucketID"
FROM 
  public."DefaultOrganisationBucketTemplate" wt
  
  left outer join "BucketTemplate" bt on bt."BucketTemplateID" = wt."BucketTemplateID"
  left outer join "Bucket" b on b."BucketName" = bt."BucketName"
  
  where wt."DefaultOrganisationTemplateID" = defaultorganisationtemplateid and wt."DefaultOrganisationTemplateVersionNumber" =defaultorganisationtemplateversionnumber ;
  
-- ROLE
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
  DefaultOrganisationVersionNumber,
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
  
  where wt."DefaultOrganisationTemplateID" = defaultorganisationtemplateid and wt."DefaultOrganisationTemplateVersionNumber" =defaultorganisationtemplateversionnumber ;
  
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
  
  left outer join "DefaultOrganisationRole" dor on dor."RoleName" = dort."RoleName" and dor."DefaultOrganisationID" = DefaultOrganisationID and dor."DefaultOrganisationVersionNumber" = DefaultOrganisationVersionNumber
  
  where dort."DefaultOrganisationTemplateID" = defaultorganisationtemplateid and dort."DefaultOrganisationTemplateVersionNumber" =defaultorganisationtemplateversionnumber ;
  
  
-- GROUP
INSERT INTO 
  public."DefaultOrganisationGroup"
(
  "DefaultOrganisationID",
  "DefaultOrganisationVersionNumber",
  "GroupName",
  "GroupDescription",
  "GroupTypeID",
  "GroupSubTypeID",
  "GroupCategoryID",
  "GroupSubCategoryID",
  "ParentID",
  "GroupID",
  "IsActive",
  "IsDeleted",
  "IsDefaultOrganisationSpecific"
)
SELECT 
  DefaultOrganisationID,
  DefaultOrganisationVersionNumber,
  wt."GroupName",
  wt."GroupDescription",
  wt."GroupTypeID",
  wt."GroupSubTypeID",
  wt."GroupCategoryID",
  wt."GroupSubCategoryID",
  wt."DefaultOrganisationGroupTemplateID",
  wt."GroupID",
  wt."IsActive",
  wt."IsDeleted",
  wt."IsDefaultOrganisationSpecific"
FROM 
  public."DefaultOrganisationGroupTemplate"   wt 
  
  where wt."DefaultOrganisationTemplateID" = defaultorganisationtemplateid and wt."DefaultOrganisationTemplateVersionNumber" =defaultorganisationtemplateversionnumber ;

-- GROUPROLE
INSERT INTO 
  public."DefaultOrganisationGroupRole"
(
  "DefaultOrganisationGroupID",
  "DefaultOrganisationRoleID"
)
SELECT 
  dor1."DefaultOrganisationGroupID",
  dor."DefaultOrganisationRoleID"
FROM 
  public."DefaultOrganisationGroupRoleTemplate" ddtt 
  
  left outer join "DefaultOrganisationRoleTemplate" dort on dort."DefaultOrganisationRoleTemplateID" = ddtt."DefaultOrganisationRoleTemplateID"
  
  left outer join "DefaultOrganisationRole" dor on dor."RoleName" = dort."RoleName" and dor."ParentID" = dort."DefaultOrganisationRoleTemplateID"
  
  left outer join "DefaultOrganisationGroupTemplate" dort1 on dort1."DefaultOrganisationGroupTemplateID" = ddtt."DefaultOrganisationGroupTemplateID"
  
  left outer join "DefaultOrganisationGroup" dor1 on dor1."GroupName" = dort1."GroupName" and dor1."ParentID" = dort1."DefaultOrganisationGroupTemplateID"
  
  where dor1."DefaultOrganisationGroupID" is not null and dor."DefaultOrganisationRoleID" is not null;

-- TARGETS

INSERT INTO 
  public."DefaultOrganisationUserTarget"
(
  "DefaultOrganisationID",
  "DefaultOrganisationVersionNumber",
  "UserSubTypeID",
  "UserCategoryID",
  "UserSubCategoryID",
  "IsActive",
  "IsDeleted",
  "StatusTypeID",
  "StatusTypeVersionNumber",
  "UserTypeID",
  "ParentID",
  "IsDefault"
)
SELECT 
  DefaultOrganisationID,
  DefaultOrganisationVersionNumber,
  wt."UserSubTypeID",
  wt."UserCategoryID",
  wt."UserSubCategoryID",
  wt."IsActive",
  wt."IsDeleted",
  st."StatusTypeID",
  st."StatusTypeVersionNumber",
  wt."UserTypeID",
  wt."DefaultOrganisationUserTargetTemplateID",
  wt."IsDefault"
FROM 
  public."DefaultOrganisationUserTargetTemplate"  wt 
  
  left outer join "StatusType" st on st."StatusTypeTemplateID" = wt."StatusTypeTemplateID" and st."StatusTypeTemplateVersionNumber" = wt."StatusTypeTemplateVersionNumber"
  
  where wt."DefaultOrganisationTemplateID" = defaultorganisationtemplateid and wt."DefaultOrganisationTemplateVersionNumber" =defaultorganisationtemplateversionnumber ;

INSERT INTO 
  public."DefaultOrganisationUserType"
(
  "DefaultOrganisationID",
  "DefaultOrganisationVersionNumber",
  "UserTypeID",
  "IsActive",
  "IsDeleted",
  "IsForDefaultUser"
)
SELECT 
  DefaultOrganisationID,
  DefaultOrganisationVersionNumber,
  wt."UserTypeID",
  wt."IsActive",
  wt."IsDeleted",
  wt."IsForDefaultUser"
FROM 
  public."DefaultOrganisationUserTypeTemplate"  wt 
  
  where wt."DefaultOrganisationTemplateID" = defaultorganisationtemplateid and wt."DefaultOrganisationTemplateVersionNumber" =defaultorganisationtemplateversionnumber ;

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
  left outer join "DefaultOrganisationRole" rg on rg."RoleName" = dor."RoleName" and rg."DefaultOrganisationID" = DefaultOrganisationID and rg."DefaultOrganisationVersionNumber" = DefaultOrganisationVersionNumber
  left outer join "DefaultOrganisationRole" rg1 on rg1."RoleID" = dor."RoleID" and rg1."DefaultOrganisationID" = DefaultOrganisationID and rg1."DefaultOrganisationVersionNumber" = DefaultOrganisationVersionNumber
   left outer join "DefaultOrganisationUserTarget" dut on dut."ParentID" = ut."DefaultOrganisationUserTargetTemplateID"
  where ut."DefaultOrganisationTemplateID" = defaultorganisationtemplateid and ut."DefaultOrganisationTemplateVersionNumber" = defaultorganisationtemplateversionnumber
  	and ut."DefaultOrganisationUserTargetTemplateID" is not null and COALESCE(rg."DefaultOrganisationRoleID" ,rg1."DefaultOrganisationRoleID") is not null
  ;

INSERT INTO 
  public."DefaultOrganisationGroupTarget"
(
  "DefaultOrganisationGroupID",
  "IsActive",
  "IsDeleted",
  "DefaultOrganisationUserTargetID"
)
SELECT 
  dor."DefaultOrganisationGroupID",
  wt."IsActive",
  wt."IsDeleted",
  dut."DefaultOrganisationUserTargetID"
FROM 
  public."DefaultOrganisationGroupTargetTemplate" wt 
  left outer join "DefaultOrganisationUserTargetTemplate" ut on ut."DefaultOrganisationUserTargetTemplateID" = wt."DefaultOrganisationUserTargetTemplateID"
  left outer join "DefaultOrganisationGroupTemplate" dorr on dorr."DefaultOrganisationGroupTemplateID" = wt."DefaultOrganisationGroupTemplateID"
  left outer join "DefaultOrganisationGroup" dor on dor."GroupName" = dorr."GroupName" and dor."DefaultOrganisationID" = DefaultOrganisationID and dor."DefaultOrganisationVersionNumber" = DefaultOrganisationVersionNumber
 left outer join "DefaultOrganisationUserTarget" dut on dut."ParentID" = ut."DefaultOrganisationUserTargetTemplateID"
  where ut."DefaultOrganisationTemplateID" = defaultorganisationtemplateid and ut."DefaultOrganisationTemplateVersionNumber" = defaultorganisationtemplateversionnumber
  	and ut."DefaultOrganisationUserTargetTemplateID" is not null and dor."DefaultOrganisationGroupID" is not null
;

-- DO ORganisationtarget
INSERT INTO 
  public."DefaultOrganisationTarget"
(
  "OrganisationTypeID",
  "DefaultOrganisationID",
  "IsActive",
  "IsDeleted",
  "DefaultOrganisationVersionNumber",
  "StatusTypeID",
  "StatusTypeVersionNumber"
)
SELECT 
  "OrganisationTypeID",
  DefaultOrganisationID,
  wt."IsActive",
  wt."IsDeleted",
  DefaultOrganisationVersionNumber,
  stt."StatusTypeID",
  stt."StatusTypeVersionNumber"
FROM 
  public."DefaultOrganisationTargetTemplate" wt
  
  left outer join "StatusType" stt on stt."StatusTypeTemplateID" = wt."StatusTypeTemplateID" and stt."StatusTypeTemplateVersionNumber" = wt."StatusTypeTemplateVersionNumber"
  
  where wt."DefaultOrganisationTemplateID" = defaultorganisationtemplateid and wt."DefaultOrganisationTemplateVersionNumber" =defaultorganisationtemplateversionnumber ;

-- ledger accounts
INSERT INTO 
  public."DefaultOrganisationLedger"
(
  "DefaultOrganisationID",
  "DefaultOrganisationVersionNumber",
  "LedgerAccountTypeID",
  "LedgerAccountName",
  "HandlesCredit",
  "HandlesDebit",
  "IsActive",
  "IsDeleted",
  "ParentID"
)
SELECT 
  DefaultOrganisationID,
  DefaultOrganisationVersionNumber,
  wt."LedgerAccountTypeID",
  wt."LedgerAccountName",
  wt."HandlesCredit",
  wt."HandlesDebit",
  wt."IsActive",
  wt."IsDeleted",
  wt."DefaultOrganisationLedgerTemplateID"
FROM 
  public."DefaultOrganisationLedgerTemplate" wt
  
  where wt."DefaultOrganisationTemplateID" = defaultorganisationtemplateid and wt."DefaultOrganisationTemplateVersionNumber" =defaultorganisationtemplateversionnumber 
  and not exists(select * from "DefaultOrganisationLedger" dol where dol."ParentID" = wt."DefaultOrganisationLedgerTemplateID" limit 1);

-- payment method
INSERT INTO 
  public."DefaultOrganisationPaymentMethod"
(
  "DefaultOrganisationID",
  "DefaultOrganisationVersionNumber",
  "GlobalPaymentMethodID",
  "IsActive",
  "IsDeleted"
)
SELECT 
  DefaultOrganisationID,
  DefaultOrganisationVersionNumber,
  wt."GlobalPaymentMethodID",
  wt."IsActive",
  wt."IsDeleted"
FROM 
  public."DefaultOrganisationPaymentMethodTemplate" wt
  
  where wt."DefaultOrganisationTemplateID" = defaultorganisationtemplateid and wt."DefaultOrganisationTemplateVersionNumber" =defaultorganisationtemplateversionnumber 
  
  ;


--EXCEPTION
--	WHEN
END;
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER
COST 100;





--update another function


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
        inner join "DefaultOrganisationTarget" DOT on DOrg."DefaultOrganisationVersionNumber" = DOT."DefaultOrganisationVersionNumber" and 

DOrg."DefaultOrganisationID" = DOT."DefaultOrganisationID"
          and DOT."OrganisationTypeID" = organisationtypeid
      limit
        1);
    End;
  End if;

  -- create new organisation

  INSERT INTO
    "Organisation"("OrganisationID", "IsBranch", "IsHeadOffice", "IsActive", "IsDeleted", "IsUserOrganisation", "DefaultOrganisationID", 

"DefaultOrganisationVersionNumber", "OrganisationTypeID", "CreatedBy", "OrganisationRecommendationSourceID", "SchemeID")
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
  and not exists (select * from "OrganisationPaymentMethod" dd where dd."OrganisationID" = OrganisationID and dd."GlobalPaymentMethodID" = 

wt."GlobalPaymentMethodID" limit 1)
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
  (select "StatusTypeVersionNumber" from "vStatusType" st where st."StatusTypeName" = 'OrganisationFinancial Status' and st."IsStart" = true 

limit 1),
  (select "StatusTypeValueID" from "vStatusType" st where st."StatusTypeName" = 'OrganisationFinancial Status' and st."IsStart" = true limit 

1),
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
 
  where not exists (select * from "OrganisationAccountingPeriod" gp where gp."OrganisationID" = OrganisatioNID and 

gp."GlobalAccountingPeriodID" = wt."GlobalAccountingPeriodID" limit 1)
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
   
    and not exists(select * from "OrganisationLedgerAccount" le where le."LedgerAccountTypeID" = wt."LedgerAccountTypeID" and 

le."OrganisationID" = OrganisationID limit 1);



  -- create organisationroles which are not default organisation specific nad global, could be duplicates

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "RoleDescription", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID", "IsDefault")
  select
    OrganisationID,
    r."RoleName",
    r."RoleDescription",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID",
    coalesce(dr."IsDefault", false)
  from
    "Role" r left join "DefaultOrganisationRole" dr on dr."DefaultOrganisationID" = defaultorganisationid and dr."RoleID" = r."RoleID"
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
    "OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "OrganisationRole" org on org."OrganisationID" = OrganisationID and org."IsActive" = true and org."IsDeleted" = false and 

org."ParentID" = rc."RoleID"
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
    public."OrganisationRole"("OrganisationID", "RoleName", "RoleDescription", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID", "IsDefault")
  select
    OrganisationID,
    dor."RoleName",
    r."RoleDescription",
    true,
    dor."RoleTypeID",
    true,
    false,
    dor."DefaultOrganisationRoleID",
    dor."IsDefault"
  from
    "DefaultOrganisationRole" dor join "Role" r on r."RoleID" = dor."RoleID"
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
    "OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "OrganisationRole" org on org."OrganisationID" = OrganisationID and org."ParentID" = rc."DefaultOrganisationRoleID" and 

org."IsActive" = true and org."IsDeleted" = FALSE
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
    inner join "OrganisationGroup" org on org."OrganisationID" = OrganisationID and org."ParentID" = rc."GroupID" and org."IsActive" = true and 

org."IsDeleted" = false
    inner join "OrganisationRole" orgr on orgr."OrganisationID" = OrganisationID and orgr."ParentID" = rc."RoleID" and orgr."IsActive" = true 

and orgr."IsDeleted" = false
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
    inner join "OrganisationGroup" org on org."OrganisationID" = OrganisationID and org."ParentID" = rc."DefaultOrganisationGroupID" and 

org."IsActive" = true and org."IsDeleted" = false
    left join "OrganisationRole" orr on orr."ParentID" = rc."DefaultOrganisationRoleID" and orr."IsActive" = true and orr."IsDeleted" = false 

and orr."OrganisationID" = OrganisationID
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
    public."OrganisationNotificationConstruct"("NotificationConstructID", "NotificationConstructVersionNumber", "IsActive", "IsDeleted", 

"OrganisationID", "ParentID")
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
    inner join "DefaultOrganisationNotificationConstruct" donc on donc."NotificationConstructID" = ncr."NotificationConstructID" and 

donc."NotificationConstructVersionNumber" =
      ncr."NotificationConstructVersionNumber" and donc."IsActive" = true and donc."IsDeleted" = false and donc."DefaultOrganisationID" = 

defaultorganisationid
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
    inner join "DefaultOrganisationNotificationConstruct" donc on donc."NotificationConstructID" = ncc."NotificationConstructID" and 

donc."NotificationConstructVersionNumber" =
      ncc."NotificationConstructVersionNumber" and donc."IsActive" = true and donc."IsDeleted" = false and donc."DefaultOrganisationID" = 

defaultorganisationid
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."NotificationRoleConstructID" and 

nc."IsActive" = true and nc."IsDeleted" = false and
      ncc."IsActive" = true and ncc."IsDeleted" = false and ncc."RoleID" is null and not exists (
                                                                                                  select
                                                                                                    orc."OrganisationRoleClaimID"
                                                                                                  from
                                                                                                    "OrganisationRoleClaim" orc
                                                                                                  where
                                                                                                    orc."OrganisationID" = OrganisationID and
                                                                                                    orc."OrganisationRoleID" = 

nc."OrganisationRoleID" and
                                                                                                    orc."OperationID" = ncc."OperationID" and
                                                                                                    orc."ResourceID" = ncc."ResourceID" and
                                                                                                    orc."StateID" = ncc."StateID" and
                                                                                                    orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA NC CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
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
    inner join "DefaultOrganisationArtefact" donc on donc."ArtefactID" = ncr."ArtefactID" and donc."ArtefactVersionNumber" = 

ncr."ArtefactVersionNumber" and donc."IsActive" = true and donc."IsDeleted"
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
    inner join "DefaultOrganisationArtefact" donc on donc."ArtefactID" = ncc."ArtefactID" and donc."ArtefactVersionNumber" = 

ncc."ArtefactVersionNumber" and donc."IsActive" = true and donc."IsDeleted"
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."ArtefactRoleID" and nc."IsActive" = true 

and nc."IsDeleted" = false
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
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
    inner join "DefaultOrganisationModule" donc on donc."ModuleID" = ncr."ModuleID" and donc."ModuleVersionNumber" = ncr."ModuleVersionNumber" 

and donc."IsActive" = true and donc."IsDeleted" = false
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
    inner join "DefaultOrganisationModule" donc on donc."ModuleID" = ncc."ModuleID" and donc."ModuleVersionNumber" = ncc."ModuleVersionNumber" 

and donc."IsActive" = true and donc."IsDeleted" = false
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."ModuleRoleID" and nc."IsActive" = true 

and nc."IsDeleted" = false
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
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
    inner join "DefaultOrganisationWorkflow" donc on donc."WorkflowID" = ncr."WorkflowID" and donc."WorkflowVersionNumber" = 

ncr."WorkflowVersionNumber" and donc."IsActive" = true and donc."IsDeleted"
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
    inner join "DefaultOrganisationWorkflow" donc on donc."WorkflowID" = ncc."WorkflowID" and donc."WorkflowVersionNumber" = 

ncc."WorkflowVersionNumber" and donc."IsActive" = true and donc."IsDeleted"
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."WorkflowRoleID" and nc."IsActive" = true 

and nc."IsDeleted" = false
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
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
    inner join "OrganisationModuleSubscription" donc on donc."ModuleID" = mw."ModuleID" and donc."ModuleVersionNumber" = 

mw."ModuleVersionNumber" and donc."IsActive" = true and donc."IsDeleted" =
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
    inner join "ModuleWorkflow" mw on mw."WorkflowID" = ncc."WorkflowID" and mw."WorkflowVersionNumber" = ncc."WorkflowVersionNumber" and 

mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."ModuleID" = mw."ModuleID" and 

ow."ModuleVersionNumber" = mw."ModuleVersionNumber" and ow."IsActive" =
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "ModuleWorkflow" mw on mw."WorkflowID" = ncc."WorkflowID" and mw."WorkflowVersionNumber" = ncc."WorkflowVersionNumber" and 

mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."ModuleID" = mw."ModuleID" and 

ow."ModuleVersionNumber" = mw."ModuleVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."WorkflowRoleID" and nc."IsActive" = true 

and nc."IsDeleted" = false
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "ModuleWorkflow" mw on mw."WorkflowID" = ncc."WorkflowID" and mw."WorkflowVersionNumber" = ncc."WorkflowVersionNumber" and 

mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."ModuleID" = mw."ModuleID" and 

ow."ModuleVersionNumber" = mw."ModuleVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
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
    inner join "OrganisationModuleSubscription" donc on donc."ModuleID" = mw."ModuleID" and donc."ModuleVersionNumber" = 

mw."ModuleVersionNumber" and donc."IsActive" = true and donc."IsDeleted" =
      false and donc."OrganisationID" = OrganisationID
    inner join "NotificationConstructRole" wr on wr."NotificationConstructID" = mw."ModuleNotificationConstructID" and 

wr."NotificationConstructVersionNumber" = mw."NotificationConstructVersionNumber"
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
    inner join "NotificationConstructClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID" and ncc."NotificationRoleConstructID" 

is null
    inner join "ModuleNotificationConstruct" mw on mw."NotificationConstructID" = ncc."NotificationConstructID" and 

mw."NotificationConstructVersionNumber" = ncc."NotificationConstructVersionNumber"
      and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."ModuleID" = mw."ModuleID" and 

ow."ModuleVersionNumber" = mw."ModuleVersionNumber" and ow."IsActive" =
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "ModuleNotificationConstruct" mw on mw."NotificationConstructID" = ncc."NotificationConstructID" and 

mw."NotificationConstructVersionNumber" = ncc."NotificationConstructVersionNumber"
      and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."ModuleID" = mw."ModuleID" and 

ow."ModuleVersionNumber" = mw."ModuleVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."NotificationRoleConstructID" and 

nc."IsActive" = true and nc."IsDeleted" = false
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "ModuleNotificationConstruct" mw on mw."NotificationConstructID" = ncc."NotificationConstructID" and 

mw."NotificationConstructVersionNumber" = ncc."NotificationConstructVersionNumber"
      and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."ModuleID" = mw."ModuleID" and 

ow."ModuleVersionNumber" = mw."ModuleVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
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
    inner join "OrganisationArtefact" donc on donc."ArtefactID" = mw."ArtefactID" and donc."ArtefactVersionNumber" = mw."ArtefactVersionNumber" 

and donc."IsActive" = true and donc."IsDeleted" = false
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
    inner join "ArtefactWorkflow" mw on mw."WorkflowID" = ncc."WorkflowID" and mw."WorkflowVersionNumber" = ncc."WorkflowVersionNumber" and 

mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."ArtefactID" = mw."ArtefactID" and 

ow."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ow."IsActive" =
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "ArtefactWorkflow" mw on mw."WorkflowID" = ncc."WorkflowID" and mw."WorkflowVersionNumber" = ncc."WorkflowVersionNumber" and 

mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."ArtefactID" = mw."ArtefactID" and 

ow."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."WorkflowRoleID" and nc."IsActive" = true 

and nc."IsDeleted" = false
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "ArtefactWorkflow" mw on mw."WorkflowID" = ncc."WorkflowID" and mw."WorkflowVersionNumber" = ncc."WorkflowVersionNumber" and 

mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."ArtefactID" = mw."ArtefactID" and 

ow."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
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
    inner join "OrganisationArtefact" donc on donc."ArtefactID" = mw."ArtefactID" and donc."ArtefactVersionNumber" = mw."ArtefactVersionNumber" 

and donc."IsActive" = true and donc."IsDeleted" = false
      and donc."OrganisationID" = OrganisationID
    inner join "NotificationConstructRole" wr on wr."NotificationConstructID" = mw."ArtefactNotificationConstructID" and 

wr."NotificationConstructVersionNumber" =
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
    inner join "NotificationConstructClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID" and ncc."NotificationRoleConstructID" 

is null
    inner join "ArtefactNotificationConstruct" mw on mw."NotificationConstructID" = ncc."NotificationConstructID" and 

mw."NotificationConstructVersionNumber" = ncc."NotificationConstructVersionNumber"
      and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."ArtefactID" = mw."ArtefactID" and 

ow."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ow."IsActive" =
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "ArtefactNotificationConstruct" mw on mw."NotificationConstructID" = ncc."NotificationConstructID" and 

mw."NotificationConstructVersionNumber" = ncc."NotificationConstructVersionNumber"
      and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."NotificationRoleConstructID" and 

nc."IsActive" = true and nc."IsDeleted" = false
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "ArtefactNotificationConstruct" mw on mw."NotificationConstructID" = ncc."NotificationConstructID" and 

mw."NotificationConstructVersionNumber" = ncc."NotificationConstructVersionNumber"
      and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."ArtefactID" = mw."ArtefactID" and 

ow."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
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
    inner join "OrganisationModuleSubscription" donc on donc."ModuleID" = mw."ModuleID" and donc."ModuleVersionNumber" = 

mw."ModuleVersionNumber" and donc."IsActive" = true and donc."IsDeleted" =
      false and donc."OrganisationID" = OrganisationID
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = 

mw."WorkflowVersionNumber"
    inner join "NotificationConstructRole" ncr on ncr."NotificationConstructID" = wr."NotificationConstructID" and 

ncr."NotificationConstructVersionNumber" = wr."NotificationConstructVersionNumber"
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
    inner join "ModuleWorkflow" mw on mw."ModuleID" = ow."ModuleID" and mw."ModuleVersionNumber" = ow."ModuleVersionNumber" and mw."IsActive" = 

true and mw."IsDeleted" = FALSE
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = 

mw."WorkflowVersionNumber"
    inner join "NotificationConstructClaim" ncr on ncr."RoleID" = r."RoleID" and ncr."NotificationRoleConstructID" is null and 

ncr."NotificationConstructID" = wr."NotificationConstructID" and
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "ModuleWorkflow" mw on mw."ModuleID" = ow."ModuleID" and mw."ModuleVersionNumber" = ow."ModuleVersionNumber" and mw."IsActive" = 

true and mw."IsDeleted" = FALSE
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = 

mw."WorkflowVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."NotificationRoleConstructID" and 

nc."IsActive" = true and nc."IsDeleted" = false
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "ModuleWorkflow" mw on mw."ModuleID" = ow."ModuleID" and mw."ModuleVersionNumber" = ow."ModuleVersionNumber" and mw."IsActive" = 

true and mw."IsDeleted" = FALSE
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = 

mw."WorkflowVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
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
    inner join "OrganisationArtefact" donc on donc."ArtefactID" = mw."ArtefactID" and donc."ArtefactVersionNumber" = mw."ArtefactVersionNumber" 

and donc."IsActive" = true and donc."IsDeleted" = false
      and donc."OrganisationID" = OrganisationID
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = 

mw."WorkflowVersionNumber"
    inner join "NotificationConstructRole" ncr on ncr."NotificationConstructID" = wr."NotificationConstructID" and 

ncr."NotificationConstructVersionNumber" = wr."NotificationConstructVersionNumber"
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
    inner join "ArtefactWorkflow" mw on mw."ArtefactID" = ow."ArtefactID" and mw."ArtefactVersionNumber" = ow."ArtefactVersionNumber" and 

mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = 

mw."WorkflowVersionNumber"
    inner join "NotificationConstructClaim" ncr on ncr."RoleID" = r."RoleID" and ncr."NotificationRoleConstructID" is null and 

ncr."NotificationConstructID" = wr."NotificationConstructID" and
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "ArtefactWorkflow" mw on mw."ArtefactID" = ow."ArtefactID" and mw."ArtefactVersionNumber" = ow."ArtefactVersionNumber" and 

mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = 

mw."WorkflowVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."NotificationRoleConstructID" and 

nc."IsActive" = true and nc."IsDeleted" = false
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "ArtefactWorkflow" mw on mw."ArtefactID" = ow."ArtefactID" and mw."ArtefactVersionNumber" = ow."ArtefactVersionNumber" and 

mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = 

mw."WorkflowVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
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
    inner join "NotificationConstructRole" ncr on ncr."NotificationConstructID" = wr."NotificationConstructID" and 

ncr."NotificationConstructVersionNumber" = wr."NotificationConstructVersionNumber"
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
    inner join "NotificationConstructClaim" ncr on ncr."RoleID" = r."RoleID" and ncr."NotificationRoleConstructID" is null and 

ncr."NotificationConstructID" = wr."NotificationConstructID" and
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."NotificationRoleConstructID" and 

nc."IsActive" = true and nc."IsDeleted" = false
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
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
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false 

and ow."ModuleID" = ma."ModuleID" and
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
    inner join "ModuleArtefact" ma on ma."ArtefactID" = ncr."ArtefactID" and ma."ArtefactVersionNumber" = ncr."ArtefactVersionNumber" and 

ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false 

and ow."ModuleID" = ma."ModuleID" and
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
    inner join "ModuleArtefact" ma on ma."ArtefactID" = ncc."ArtefactID" and ma."ArtefactVersionNumber" = ncc."ArtefactVersionNumber" and 

ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false 

and ow."ModuleID" = ma."ModuleID" and
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "ModuleArtefact" ma on ma."ArtefactID" = ncc."ArtefactID" and ma."ArtefactVersionNumber" = ncc."ArtefactVersionNumber" and 

ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false 

and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."ArtefactRoleID" and nc."IsActive" = true 

and nc."IsDeleted" = false
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "ModuleArtefact" ma on ma."ArtefactID" = ncc."ArtefactID" and ma."ArtefactVersionNumber" = ncc."ArtefactVersionNumber" and 

ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false 

and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
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
    inner join "ModuleArtefact" ma on ma."ArtefactID" = mw."ArtefactID" and ma."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and 

ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false 

and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
    inner join "OrganisationArtefact" donc on donc."ArtefactID" = mw."ArtefactID" and donc."ArtefactVersionNumber" = mw."ArtefactVersionNumber" 

and donc."IsActive" = true and donc."IsDeleted" = false
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
    inner join "ArtefactWorkflow" mw on mw."WorkflowID" = ncc."WorkflowID" and mw."WorkflowVersionNumber" = ncc."WorkflowVersionNumber" and 

mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "ModuleArtefact" ma on ma."ArtefactID" = mw."ArtefactID" and ma."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and 

ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false 

and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
    inner join "OrganisationArtefact" oa on oa."OrganisationID" = OrganisationID and oa."ArtefactID" = mw."ArtefactID" and 

oa."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and oa."IsActive" =
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "ArtefactWorkflow" mw on mw."WorkflowID" = ncc."WorkflowID" and mw."WorkflowVersionNumber" = ncc."WorkflowVersionNumber" and 

mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "ModuleArtefact" ma on ma."ArtefactID" = mw."ArtefactID" and ma."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and 

ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false 

and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
    inner join "OrganisationArtefact" oa on oa."OrganisationID" = OrganisationID and oa."ArtefactID" = mw."ArtefactID" and 

oa."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and oa."IsActive" =
      true and oa."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."WorkflowRoleID" and nc."IsActive" = true 

and nc."IsDeleted" = false
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "ArtefactWorkflow" mw on mw."WorkflowID" = ncc."WorkflowID" and mw."WorkflowVersionNumber" = ncc."WorkflowVersionNumber" and 

mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "ModuleArtefact" ma on ma."ArtefactID" = mw."ArtefactID" and ma."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and 

ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false 

and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
    inner join "OrganisationArtefact" oa on oa."OrganisationID" = OrganisationID and oa."ArtefactID" = mw."ArtefactID" and 

oa."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and oa."IsActive" =
      true and oa."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
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
    inner join "ModuleArtefact" ma on ma."ArtefactID" = mw."ArtefactID" and ma."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and 

ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false 

and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
    inner join "OrganisationArtefact" donc on donc."ArtefactID" = mw."ArtefactID" and donc."ArtefactVersionNumber" = mw."ArtefactVersionNumber" 

and donc."IsActive" = true and donc."IsDeleted" = false
      and donc."OrganisationID" = OrganisationID
    inner join "NotificationConstructRole" wr on wr."NotificationConstructID" = mw."ArtefactNotificationConstructID" and 

wr."NotificationConstructVersionNumber" =
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
    inner join "NotificationConstructClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID" and ncc."NotificationRoleConstructID" 

is null
    inner join "ArtefactNotificationConstruct" mw on mw."NotificationConstructID" = ncc."NotificationConstructID" and 

mw."NotificationConstructVersionNumber" = ncc."NotificationConstructVersionNumber"
      and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "ModuleArtefact" ma on ma."ArtefactID" = mw."ArtefactID" and ma."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and 

ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false 

and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
    inner join "OrganisationArtefact" oa on oa."OrganisationID" = OrganisationID and oa."ArtefactID" = mw."ArtefactID" and 

oa."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and oa."IsActive" =
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "ArtefactNotificationConstruct" mw on mw."NotificationConstructID" = ncc."NotificationConstructID" and 

mw."NotificationConstructVersionNumber" = ncc."NotificationConstructVersionNumber"
      and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "ModuleArtefact" ma on ma."ArtefactID" = mw."ArtefactID" and ma."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and 

ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false 

and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."NotificationRoleConstructID" and 

nc."IsActive" = true and nc."IsDeleted" = false
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "ArtefactNotificationConstruct" mw on mw."NotificationConstructID" = ncc."NotificationConstructID" and 

mw."NotificationConstructVersionNumber" = ncc."NotificationConstructVersionNumber"
      and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "ModuleArtefact" ma on ma."ArtefactID" = mw."ArtefactID" and ma."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and 

ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false 

and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
    inner join "OrganisationArtefact" oa on oa."OrganisationID" = OrganisationID and oa."ArtefactID" = mw."ArtefactID" and 

oa."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and oa."IsActive" =
      true and oa."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
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
    inner join "DefaultOrganisationStatusType" donc on donc."StatusTypeID" = ncr."StatusTypeID" and donc."StatusTypeVersionNumber" = 

ncr."StatusTypeVersionNumber" and donc."IsActive" = true and
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
    inner join "DefaultOrganisationStatusType" donc on donc."StatusTypeID" = ncc."StatusTypeID" and donc."StatusTypeVersionNumber" = 

ncc."StatusTypeVersionNumber" and donc."IsActive" = true and
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."StatusTypeRoleID" and nc."IsActive" = 

true and nc."IsDeleted" = false
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
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
    inner join "ModuleStatusType" mst on mst."StatusTypeID" = mw."StatusTypeID" and mst."StatusTypeVersionNumber" = 

mw."StatusTypeVersionNumber" and mst."IsActive" = true and mst."IsDeleted" = false
    inner join "OrganisationModuleSubscription" donc on donc."ModuleID" = mst."ModuleID" and donc."ModuleVersionNumber" = 

mst."ModuleVersionNumber" and donc."IsActive" = true and donc."IsDeleted" =
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
    inner join "ModuleStatusType" mw on mw."StatusTypeID" = ncc."StatusTypeID" and mw."StatusTypeVersionNumber" = ncc."StatusTypeVersionNumber" 

and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."ModuleID" = mw."ModuleID" and 

ow."ModuleVersionNumber" = mw."ModuleVersionNumber" and ow."IsActive" =
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "ModuleStatusType" mw on mw."StatusTypeID" = ncc."StatusTypeID" and mw."StatusTypeVersionNumber" = ncc."StatusTypeVersionNumber" 

and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."ModuleID" = mw."ModuleID" and 

ow."ModuleVersionNumber" = mw."ModuleVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."StatusTypeRoleID" and nc."IsActive" = 

true and nc."IsDeleted" = false
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "ModuleStatusType" mw on mw."StatusTypeID" = ncc."StatusTypeID" and mw."StatusTypeVersionNumber" = ncc."StatusTypeVersionNumber" 

and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."ModuleID" = mw."ModuleID" and 

ow."ModuleVersionNumber" = mw."ModuleVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
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
    inner join "OrganisationArtefact" donc on donc."ArtefactID" = mw."ArtefactID" and donc."ArtefactVersionNumber" = mw."ArtefactVersionNumber" 

and donc."IsActive" = true and donc."IsDeleted" = false
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
    inner join "ArtefactStatusType" mw on mw."StatusTypeID" = ncc."StatusTypeID" and mw."StatusTypeVersionNumber" = 

ncc."StatusTypeVersionNumber"
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."ArtefactID" = mw."ArtefactID" and 

ow."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ow."IsActive" =
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "ArtefactStatusType" mw on mw."StatusTypeID" = ncc."StatusTypeID" and mw."StatusTypeVersionNumber" = 

ncc."StatusTypeVersionNumber"
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."ArtefactID" = mw."ArtefactID" and 

ow."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."StatusTypeRoleID" and nc."IsActive" = 

true and nc."IsDeleted" = false
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "ArtefactStatusType" mw on mw."StatusTypeID" = ncc."StatusTypeID" and mw."StatusTypeVersionNumber" = 

ncc."StatusTypeVersionNumber"
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."ArtefactID" = mw."ArtefactID" and 

ow."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
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
    inner join "OrganisationModuleSubscription" donc on donc."ModuleID" = mw."ModuleID" and donc."ModuleVersionNumber" = 

mw."ModuleVersionNumber" and donc."IsActive" = true and donc."IsDeleted" =
      false and donc."OrganisationID" = OrganisationID
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "StatusTypeRole" ncr on ncr."StatusTypeID" = wr."StatusTypeID" and ncr."StatusTypeVersionNumber" = wr."StatusTypeVersionNumber" 

and ncr."IsActive" = true and ncr."IsDeleted" = false
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
    inner join "ModuleWorkflow" mw on mw."ModuleID" = ow."ModuleID" and mw."ModuleVersionNumber" = ow."ModuleVersionNumber" and mw."IsActive" = 

true and mw."IsDeleted" = FALSE
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "StatusTypeClaim" ncr on ncr."RoleID" = r."RoleID" and ncr."StatusTypeRoleID" is null and ncr."StatusTypeID" = wr."StatusTypeID" 

and ncr."StatusTypeVersionNumber" =
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "ModuleWorkflow" mw on mw."ModuleID" = ow."ModuleID" and mw."ModuleVersionNumber" = ow."ModuleVersionNumber" and mw."IsActive" = 

true and mw."IsDeleted" = FALSE
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."StatusTypeRoleID" and nc."IsActive" = 

true and nc."IsDeleted" = false
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "ModuleWorkflow" mw on mw."ModuleID" = ow."ModuleID" and mw."ModuleVersionNumber" = ow."ModuleVersionNumber" and mw."IsActive" = 

true and mw."IsDeleted" = FALSE
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
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
    inner join "OrganisationArtefact" donc on donc."ArtefactID" = mw."ArtefactID" and donc."ArtefactVersionNumber" = mw."ArtefactVersionNumber" 

and donc."IsActive" = true and donc."IsDeleted" = false
      and donc."OrganisationID" = OrganisationID
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "StatusTypeRole" ncr on ncr."StatusTypeID" = wr."StatusTypeID" and ncr."StatusTypeVersionNumber" = wr."StatusTypeVersionNumber" 

and ncr."IsActive" = true and ncr."IsDeleted" = false
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
    inner join "ArtefactWorkflow" mw on mw."ArtefactID" = ow."ArtefactID" and mw."ArtefactVersionNumber" = ow."ArtefactVersionNumber" and 

mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "StatusTypeClaim" ncr on ncr."RoleID" = r."RoleID" and ncr."StatusTypeRoleID" is null and ncr."StatusTypeID" = wr."StatusTypeID" 

and ncr."StatusTypeVersionNumber" =
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "ArtefactWorkflow" mw on mw."ArtefactID" = ow."ArtefactID" and mw."ArtefactVersionNumber" = ow."ArtefactVersionNumber" and 

mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."StatusTypeRoleID" and nc."IsActive" = 

true and nc."IsDeleted" = false
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "ArtefactWorkflow" mw on mw."ArtefactID" = ow."ArtefactID" and mw."ArtefactVersionNumber" = ow."ArtefactVersionNumber" and 

mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
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
    inner join "StatusTypeRole" ncr on ncr."StatusTypeID" = wr."StatusTypeID" and ncr."StatusTypeVersionNumber" = wr."StatusTypeVersionNumber" 

and ncr."IsActive" = true and ncr."IsDeleted" = false
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
    inner join "StatusTypeClaim" ncr on ncr."RoleID" = r."RoleID" and ncr."StatusTypeRoleID" is null and ncr."StatusTypeID" = wr."StatusTypeID" 

and ncr."StatusTypeVersionNumber" =
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."StatusTypeRoleID" and nc."IsActive" = 

true and nc."IsDeleted" = false
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
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
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
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
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
    public."Organisation"("OrganisationID", "OrganisationTypeID", "IsBranch", "IsHeadOffice", "CreatedOn", "CreatedBy", 

"DefaultOrganisationID", "DefaultOrganisationVersionNumber",
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
    public."OrganisationStatus"("OrganisationID", "StatusTypeID", "StatusTypeVersionNumber", "StatusTypeValueID", "StatusChangedOn", 

"StatusChangedBy", "ParentID")
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
    left outer join "vStatusType" st on st."StatusTypeID" = wt."StatusTypeID" and st."StatusTypeVersionNumber" = wt."StatusTypeVersionNumber" 

and
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
      public."OrganisationStatus"("OrganisationID", "StatusTypeID", "StatusTypeVersionNumber", "StatusTypeValueID", "StatusChangedOn", 

"StatusChangedBy", "ParentID")
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
      left outer join "vStatusType" st on st."StatusTypeID" = wt."StatusTypeID" and st."StatusTypeVersionNumber" = wt."StatusTypeVersionNumber" 

and st."StatusTypeName" = 'Branch Status' and
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