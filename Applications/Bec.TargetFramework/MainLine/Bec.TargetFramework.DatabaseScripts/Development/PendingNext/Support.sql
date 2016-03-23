CREATE TABLE public."SupportItem" (
  "SupportItemID" UUID NOT NULL,
  "TicketNumber" INTEGER NOT NULL,
  "UserAccountOrganisationID" UUID NOT NULL,
  "Telephone" VARCHAR(100) NOT NULL,
  "RequestTypeID" INTEGER NOT NULL,
  "Title" VARCHAR(200) NOT NULL,
  "Description" VARCHAR NOT NULL,
  "IsClosed" BOOLEAN DEFAULT false NOT NULL,
  "Reason" VARCHAR,
  "CreatedOn" TIMESTAMP(0) WITH TIME ZONE DEFAULT now() NOT NULL,
  "ClosedOn" TIMESTAMP(0) WITH TIME ZONE,
  "CreatedBy" VARCHAR(200) NOT NULL,
  "ClosedBy" VARCHAR(200),
  "IsDeleted" BOOLEAN DEFAULT false NOT NULL,
  "IsActive" BOOLEAN DEFAULT true NOT NULL,
  CONSTRAINT "RequestSupport_pkey" PRIMARY KEY("SupportItemID"),
  CONSTRAINT "fk_RequestSupport_UserAccountOrganisation" FOREIGN KEY ("UserAccountOrganisationID")
    REFERENCES public."UserAccountOrganisation"("UserAccountOrganisationID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE
) 
WITH (oids = false);

CREATE OR REPLACE FUNCTION public."fn_SupportTicketRank" (
  stid uuid,
  isclose boolean
)
RETURNS integer AS
$body$
declare 
ret integer;
BEGIN
 ret = (
 select "Row" from (
  SELECT st."SupportItemID", row_number() over (order by CASE WHEN isclose = 'True' THEN st."ClosedOn"  ELSE st."CreatedOn" END desc) as "Row"
  FROM public."SupportItem" st WHERE st."IsClosed" = isclose
    ) s 
  where s."SupportItemID" = stid
  limit 1
  );
  return ret;
END;
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER
COST 100;

insert into public."Resource"("ResourceID", "ResourceName", "ResourceDescription", "IsActive")
values (uuid_generate_v1(), 'Support', 'Support', TRUE);


-- support admin can work with Support functions(ShowMeHow and Callout)
	insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Support Administrator' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'Support' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'Add' limit 1), TRUE);
  
insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Support Administrator' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'Support' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'Add' limit 1), TRUE);


insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Organisation Employee' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'Support' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'Send' limit 1), TRUE);
  
insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Support Administrator' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'Support' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'Send' limit 1), TRUE);
  
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
    org."OrganisationID"
  from
    "RoleClaim" rc
    inner join "OrganisationRole" org on org."IsActive" = true and org."IsDeleted" = false and org."ParentID" = rc."RoleID"
  where
    rc."RoleID" =
    (
      select "RoleID"
          from "Role"
          where "RoleName" = 'Support Administrator'
    ) and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = org."OrganisationID" and
                   orc."OrganisationRoleID" = org."OrganisationRoleID" and
                   orc."OperationID" = rc."OperationID" and
                   orc."ResourceID" = rc."ResourceID" and
                   orc."StateID" = rc."StateID" and
                   orc."StateItemID" = rc."StateItemID"
    );
    
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
    org."OrganisationID"
  from
    "RoleClaim" rc
    inner join "OrganisationRole" org on org."IsActive" = true and org."IsDeleted" = false and org."ParentID" = rc."RoleID"
  where
    rc."RoleID" =
    (
      select "RoleID"
          from "Role"
          where "RoleName" = 'Organisation Employee'
    ) and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = org."OrganisationID" and
                   orc."OrganisationRoleID" = org."OrganisationRoleID" and
                   orc."OperationID" = rc."OperationID" and
                   orc."ResourceID" = rc."ResourceID" and
                   orc."StateID" = rc."StateID" and
                   orc."StateItemID" = rc."StateItemID"
    );

-- SafeSend Group
INSERT INTO public."SafeSendGroup" ("SafeSendGroupID", "OrganisationTypeID", "Name")
VALUES (E'd6607a83-6dbd-11e5-bb4d-00155d0a1457', 30, E'Support');

-- group members

insert into public."UserAccountOrganisationSafeSendGroup"
select 

uao."UserAccountOrganisationID",
'd6607a83-6dbd-11e5-bb4d-00155d0a1457',
true,
false

from "UserAccountOrganisation" uao

where exists (select 1 from "UserAccountOrganisationRole" uaor
	where uaor."UserAccountOrganisationID" = uao."UserAccountOrganisationID"
    and uaor."OrganisationRoleID" = (select "OrganisationRoleID" from "OrganisationRole" where "RoleName" = 'Support Administrator'));
