﻿
-- Admin Organisation
DO $$
Declare DoTemplateID uuid;
Declare DoVersionNumber integer;
Declare UserRoleID uuid;
Declare SupportRoleID uuid;
Declare FinanceRoleID uuid;
Declare OrganisationTypeID integer;
Declare userUser uuid;
Declare adminUser uuid;
Begin

-- declare variables
UserRoleID := (select "RoleID" from "Role" where "RoleName" = 'Administration User' limit 1);
SupportRoleID := (select "RoleID" from "Role" where "RoleName" = 'Support Administrator' limit 1);
FinanceRoleID := (select "RoleID" from "Role" where "RoleName" = 'Finance Administrator' limit 1);
OrganisationTypeID := (select "OrganisationTypeID" from "OrganisationType" where "Name" = 'Administration' limit 1);
userUser := (select "UserTypeID" from "UserType" where "Name" = 'User');
adminUser := (select "UserTypeID" from "UserType" where "Name" = 'Administrator');

INSERT INTO
  public."DefaultOrganisationTemplate"
(
  "DefaultOrganisationTemplateVersionNumber",
  "Name",
  "Description",
  "IsActive",
  "IsDeleted",
  "OrganisationTypeID"
)
VALUES (
  1,
  'Administration',
  'Template for an Administration Organisation',
  true,
  false,
  OrganisationTypeID
);

DoTemplateID:= (select dot."DefaultOrganisationTemplateID" from "DefaultOrganisationTemplate" dot where dot."Name" = 'Administration' limit 1);
DoVersionNumber = 1;

-- status types
INSERT INTO
  public."DefaultOrganisationStatusTypeTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "ParentID",
  "IsActive",
  "IsDeleted",
  "DefaultOrganisationTemplateID",
  "DefaultOrganisationTemplateVersionNumber",
  "DefaultStatusTypeValueTemplateID"
)
VALUES (
  (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'User Organisation Status'),
  1,
  null,
  true,
  false,
  DoTemplateID,
  DoVersionNumber,
  (select "StatusTypeValueTemplateID" from "vStatusTypeTemplate" where "IsStart" = true and "TemplateName" =  'User Organisation Status' limit 1)
);

INSERT INTO
  public."DefaultOrganisationStatusTypeTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "ParentID",
  "IsActive",
  "IsDeleted",
  "DefaultOrganisationTemplateID",
  "DefaultOrganisationTemplateVersionNumber",
  "DefaultStatusTypeValueTemplateID"
)
VALUES (
  (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Branch Status'),
  1,
  null,
  true,
  false,
  DoTemplateID,
  DoVersionNumber,
  (select "StatusTypeValueTemplateID" from "vStatusTypeTemplate" where "IsStart" = true and "TemplateName"  = 'Branch Status' limit 1)
);

INSERT INTO
  public."DefaultOrganisationStatusTypeTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "ParentID",
  "IsActive",
  "IsDeleted",
  "DefaultOrganisationTemplateID",
  "DefaultOrganisationTemplateVersionNumber",
  "DefaultStatusTypeValueTemplateID"
)
VALUES (
  (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Organisation Status'),
  1,
  null,
  true,
  false,
  DoTemplateID,
  DoVersionNumber,
  (select "StatusTypeValueTemplateID" from "vStatusTypeTemplate" where "IsStart" = true and "TemplateName" = 'Organisation Status' limit 1)
);

-- set organisation target
INSERT INTO
  public."DefaultOrganisationTargetTemplate"
(
  "OrganisationTypeID",
  "DefaultOrganisationTemplateID",
  "IsActive",
  "IsDeleted",
  "DefaultOrganisationTemplateVersionNumber",
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber"
)
VALUES (
  OrganisationTypeID,
  DoTemplateID,
  true,
  false,
  DoVersionNumber,
  (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Organisation Status'),
 (select "StatusTypeTemplateVersionNumber" from "StatusTypeTemplate" where "Name" = 'Organisation Status')
);

-- set organisation branch target
INSERT INTO
  public."DefaultOrganisationTargetTemplate"
(
  "OrganisationTypeID",
  "DefaultOrganisationTemplateID",
  "IsActive",
  "IsDeleted",
  "DefaultOrganisationTemplateVersionNumber",
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber"
)
VALUES (
  OrganisationTypeID,
  DoTemplateID,
  true,
  false,
  DoVersionNumber,
  (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Branch Status'),
 (select "StatusTypeTemplateVersionNumber" from "StatusTypeTemplate" where "Name" = 'Branch Status')
);

-- user types
INSERT INTO
  public."DefaultOrganisationUserTargetTemplate"
(
  "DefaultOrganisationTemplateID",
  "DefaultOrganisationTemplateVersionNumber",
  "IsActive",
  "IsDeleted",
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "UserTypeID",
  "IsDefault"
)
VALUES (
  DoTemplateID,
  DoVersionNumber,
  true,
  false,
  (select "StatusTypeTemplateID" from "vStatusTypeTemplate" where "IsStart" = true and "TemplateName" = 'User Organisation Status' limit 1),
  1,
  (select "UserTypeID" from "UserType" where "Name" = 'Administrator' limit 1),
  true
);

INSERT INTO
  public."DefaultOrganisationUserTargetTemplate"
(
  "DefaultOrganisationTemplateID",
  "DefaultOrganisationTemplateVersionNumber",
  "IsActive",
  "IsDeleted",
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "UserTypeID",
  "IsDefault"
)
VALUES (
  DoTemplateID,
  DoVersionNumber,
  true,
  false,
  (select "StatusTypeTemplateID" from "vStatusTypeTemplate" where "IsStart" = true and "TemplateName" = 'User Organisation Status' limit 1),
  1,
  (select "UserTypeID" from "UserType" where "Name" = 'User' limit 1),
  true
);

-- Security
INSERT INTO
  public."DefaultOrganisationRoleTemplate"
(
  "DefaultOrganisationTemplateID",
  "RoleID",
  "IsDefaultOrganisationSpecific",
  "DefaultOrganisationTemplateVersionNumber"
)
VALUES (
  DoTemplateID,
  UserRoleID,
  false,
  DoVersionNumber
);

INSERT INTO
  public."DefaultOrganisationRoleTemplate"
(
  "DefaultOrganisationTemplateID",
  "RoleID",
  "IsDefaultOrganisationSpecific",
  "DefaultOrganisationTemplateVersionNumber"
)
VALUES (
  DoTemplateID,
  SupportRoleID,
  false,
  DoVersionNumber
);

INSERT INTO
  public."DefaultOrganisationRoleTemplate"
(
  "DefaultOrganisationTemplateID",
  "RoleID",
  "IsDefaultOrganisationSpecific",
  "DefaultOrganisationTemplateVersionNumber"
)
VALUES (
  DoTemplateID,
  FinanceRoleID,
  false,
  DoVersionNumber
);

INSERT INTO
  public."DefaultOrganisationGroupTemplate"
(
  "DefaultOrganisationTemplateID",
  "GroupName",
  "GroupDescription",
  "GroupTypeID",
  "IsDefaultOrganisationSpecific",
  "DefaultOrganisationTemplateVersionNumber"
)
VALUES (
  DoTemplateID,
  'Administration User',
  'Administration User Group',
  (select dot."ClassificationTypeID" from "ClassificationType" dot where dot."ClassificationTypeCategoryID" = 80 and dot."Name" = 'Default Organisation' limit 1),
  true,
  DoVersionNumber
);

-- add role to group
INSERT INTO
  public."DefaultOrganisationGroupRoleTemplate"
(
  "DefaultOrganisationGroupTemplateID",
  "DefaultOrganisationRoleTemplateID"
)
VALUES (
  (select dot."DefaultOrganisationGroupTemplateID" from "DefaultOrganisationGroupTemplate" dot where dot."DefaultOrganisationTemplateID" = DoTemplateID
  	and dot."GroupName" = 'Administration User' and dot."DefaultOrganisationTemplateVersionNumber" = DoVersionNumber limit 1) ,
  (select dot."DefaultOrganisationRoleTemplateID" from "DefaultOrganisationRoleTemplate" dot where dot."DefaultOrganisationTemplateID" = DoTemplateID
  	and dot."RoleID" = UserRoleID and dot."DefaultOrganisationTemplateVersionNumber" = DoVersionNumber limit 1)
);

--- add a temp branch
INSERT INTO
  public."DefaultOrganisationBranchTemplate"
(
  "DefaultOrganisationTemplateID",
  "OrganisationTypeID",
  "BranchName",
  "DefaultOrganisationTemplateVersionNumber",
  "BranchSubType"
)
VALUES (
  DoTemplateID,
  (select "OrganisationTypeID" from "OrganisationType" where "Name" = 'Branch' limit 1),
  'Branch',
  DoVersionNumber,
  1000
);

-- add user target

INSERT INTO public."DefaultOrganisationRoleTargetTemplate"
(
  "DefaultOrganisationRoleTemplateID",
  "DefaultOrganisationUserTargetTemplateID"
)
select
(select dot."DefaultOrganisationRoleTemplateID" from "DefaultOrganisationRoleTemplate" dot where dot."DefaultOrganisationTemplateID" = DoTemplateID
  	and dot."RoleID" = UserRoleID and dot."DefaultOrganisationTemplateVersionNumber" = DoVersionNumber limit 1),
    "DefaultOrganisationUserTargetTemplateID"
from "DefaultOrganisationUserTargetTemplate"
where "DefaultOrganisationTemplateID" = DoTemplateID and "DefaultOrganisationTemplateVersionNumber" = DoVersionNumber
and "UserTypeID" = adminUser;

INSERT INTO public."DefaultOrganisationRoleTargetTemplate"
(
  "DefaultOrganisationRoleTemplateID",
  "DefaultOrganisationUserTargetTemplateID"
)
select
(select dot."DefaultOrganisationRoleTemplateID" from "DefaultOrganisationRoleTemplate" dot where dot."DefaultOrganisationTemplateID" = DoTemplateID
  	and dot."RoleID" = SupportRoleID and dot."DefaultOrganisationTemplateVersionNumber" = DoVersionNumber limit 1),
    "DefaultOrganisationUserTargetTemplateID"
from "DefaultOrganisationUserTargetTemplate"
where "DefaultOrganisationTemplateID" = DoTemplateID and "DefaultOrganisationTemplateVersionNumber" = DoVersionNumber;
--and "UserTypeID" = userUser; --all users, no filter

INSERT INTO public."DefaultOrganisationRoleTargetTemplate"
(
  "DefaultOrganisationRoleTemplateID",
  "DefaultOrganisationUserTargetTemplateID"
)
select
(select dot."DefaultOrganisationRoleTemplateID" from "DefaultOrganisationRoleTemplate" dot where dot."DefaultOrganisationTemplateID" = DoTemplateID
  	and dot."RoleID" = FinanceRoleID and dot."DefaultOrganisationTemplateVersionNumber" = DoVersionNumber limit 1),
    "DefaultOrganisationUserTargetTemplateID"
from "DefaultOrganisationUserTargetTemplate"
where "DefaultOrganisationTemplateID" = DoTemplateID and "DefaultOrganisationTemplateVersionNumber" = DoVersionNumber;
--and "UserTypeID" = userUser; --all users, no filter

INSERT INTO
  public."DefaultOrganisationGroupTargetTemplate"
(
  "DefaultOrganisationGroupTemplateID",
  "DefaultOrganisationUserTargetTemplateID"
)
VALUES (
  (select dot."DefaultOrganisationGroupTemplateID" from "DefaultOrganisationGroupTemplate" dot where dot."DefaultOrganisationTemplateID" = DoTemplateID
  	and dot."GroupName" = 'Administration User' and dot."DefaultOrganisationTemplateVersionNumber" = DoVersionNumber limit 1),
  (select "DefaultOrganisationUserTargetTemplateID" from "DefaultOrganisationUserTargetTemplate" where "DefaultOrganisationTemplateID" = DoTemplateID
  	and "DefaultOrganisationTemplateVersionNumber" = DoVersionNumber limit 1)
);

perform "fn_PromoteDefaultOrganisationTemplate"(DoTemplateID, DoVersionNumber);

END $$;