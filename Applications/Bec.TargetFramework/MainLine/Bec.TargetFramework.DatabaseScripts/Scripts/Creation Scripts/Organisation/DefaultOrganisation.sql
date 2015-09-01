﻿

-- Temp Organisation
DO $$
Declare DoTemplateID uuid;
Declare DoVersionNumber integer;
Declare UserRoleID uuid;
Declare OrganisationTypeID integer;
Begin

-- declare variables
UserRoleID := (select "RoleID" from "Role" where "RoleName" = 'Temporary User' limit 1);
OrganisationTypeID := (select "OrganisationTypeID" from "OrganisationType" where "Name" = 'Temporary' limit 1);

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
  'Temporary',
  'Template for a Temporary Organisation',
  true,
  false,
  OrganisationTypeID
);

DoTemplateID:= (select dot."DefaultOrganisationTemplateID" from "DefaultOrganisationTemplate" dot where dot."Name" = 'Temporary' limit 1);
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
  (select "UserTypeID" from "UserType" where "Name" = 'Temporary' limit 1),
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
  'Temporary User',
  'Temporary User Group',
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
  	and dot."GroupName" = 'Temporary User' and dot."DefaultOrganisationTemplateVersionNumber" = DoVersionNumber limit 1) ,
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
  'Temporary Branch',
  DoVersionNumber,
  1000
);

-- add user target
INSERT INTO
  public."DefaultOrganisationRoleTargetTemplate"
(
  "DefaultOrganisationRoleTemplateID",
  "DefaultOrganisationUserTargetTemplateID"
)
VALUES (
  (select dot."DefaultOrganisationRoleTemplateID" from "DefaultOrganisationRoleTemplate" dot where dot."DefaultOrganisationTemplateID" = DoTemplateID
  	and dot."RoleID" = UserRoleID and dot."DefaultOrganisationTemplateVersionNumber" = DoVersionNumber limit 1),
  (select "DefaultOrganisationUserTargetTemplateID" from "DefaultOrganisationUserTargetTemplate" where "DefaultOrganisationTemplateID" = DoTemplateID
  	and "DefaultOrganisationTemplateVersionNumber" = DoVersionNumber limit 1)
);

INSERT INTO
  public."DefaultOrganisationGroupTargetTemplate"
(
  "DefaultOrganisationGroupTemplateID",
  "DefaultOrganisationUserTargetTemplateID"
)
VALUES (
  (select dot."DefaultOrganisationGroupTemplateID" from "DefaultOrganisationGroupTemplate" dot where dot."DefaultOrganisationTemplateID" = DoTemplateID
  	and dot."GroupName" = 'Temporary User' and dot."DefaultOrganisationTemplateVersionNumber" = DoVersionNumber limit 1),
  (select "DefaultOrganisationUserTargetTemplateID" from "DefaultOrganisationUserTargetTemplate" where "DefaultOrganisationTemplateID" = DoTemplateID
  	and "DefaultOrganisationTemplateVersionNumber" = DoVersionNumber limit 1)
);

perform "fn_PromoteDefaultOrganisationTemplate"(DoTemplateID, DoVersionNumber);

END $$;

------------------------------------------------------------------------------------------------------------------------------------------

-- Personal Organisation
DO $$
Declare DoTemplateID uuid;
Declare DoVersionNumber integer;
Declare UserRoleID uuid;
Declare OrganisationTypeID integer;
Begin

-- declare variables
UserRoleID := (select "RoleID" from "Role" where "RoleName" = 'User' limit 1);
OrganisationTypeID := (select "OrganisationTypeID" from "OrganisationType" where "Name" = 'Temporary' limit 1);

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
  'Personal',
  'Template for a Personal Organisation',
  true,
  false,
  (select "OrganisationTypeID" from "OrganisationType" where "Name" = 'Personal')
);

DoTemplateID:= (select dot."DefaultOrganisationTemplateID" from "DefaultOrganisationTemplate" dot where dot."Name" = 'Personal' limit 1);
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
  (select "StatusTypeValueTemplateID" from "vStatusTypeTemplate" where "IsStart" = true and "TemplateName" = 'User Organisation Status' limit 1)
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
  (select "StatusTypeValueTemplateID" from "vStatusTypeTemplate" where "IsStart" = true and "TemplateName" = 'Branch Status' limit 1)
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
  public."DefaultOrganisationUserTypeTemplate"
(
  "DefaultOrganisationTemplateID",
  "DefaultOrganisationTemplateVersionNumber",
  "UserTypeID",
  "IsForDefaultUser"
)
VALUES (
  DoTemplateID,
  DoVersionNumber,
  (select "UserTypeID" from "UserType" where "Name" = 'User' limit 1),
  true
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
  'Personal User',
  'Personal User Group',
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
  	and dot."GroupName" = 'Personal User' and dot."DefaultOrganisationTemplateVersionNumber" = DoVersionNumber limit 1) ,
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
  'Personal Branch',
  DoVersionNumber,
  1000
);

-- add user target
INSERT INTO
  public."DefaultOrganisationRoleTargetTemplate"
(
  "DefaultOrganisationRoleTemplateID",
  "DefaultOrganisationUserTargetTemplateID"
)
VALUES (
  (select dot."DefaultOrganisationRoleTemplateID" from "DefaultOrganisationRoleTemplate" dot where dot."DefaultOrganisationTemplateID" = DoTemplateID
  	and dot."RoleID" = UserRoleID and dot."DefaultOrganisationTemplateVersionNumber" = DoVersionNumber limit 1),
  (select "DefaultOrganisationUserTargetTemplateID" from "DefaultOrganisationUserTargetTemplate" where "DefaultOrganisationTemplateID" = DoTemplateID
  	and "DefaultOrganisationTemplateVersionNumber" = DoVersionNumber limit 1)
);

INSERT INTO
  public."DefaultOrganisationGroupTargetTemplate"
(
  "DefaultOrganisationGroupTemplateID",
  "DefaultOrganisationUserTargetTemplateID"
)
VALUES (
  (select dot."DefaultOrganisationGroupTemplateID" from "DefaultOrganisationGroupTemplate" dot where dot."DefaultOrganisationTemplateID" = DoTemplateID
  	and dot."GroupName" = 'Personal User' and dot."DefaultOrganisationTemplateVersionNumber" = DoVersionNumber limit 1),
  (select "DefaultOrganisationUserTargetTemplateID" from "DefaultOrganisationUserTargetTemplate" where "DefaultOrganisationTemplateID" = DoTemplateID
  	and "DefaultOrganisationTemplateVersionNumber" = DoVersionNumber limit 1)
);

-- add 2 ledger accounts
INSERT INTO
  public."DefaultOrganisationLedgerTemplate"
(
  "DefaultOrganisationTemplateID",
  "DefaultOrganisationTemplateVersionNumber",
  "LedgerAccountTypeID",
  "LedgerAccountName",
  "HandlesCredit",
  "HandlesDebit",
  "IsActive",
  "IsDeleted"
)
VALUES (
  DoTemplateID,
  DoVersionNumber,
  (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Sales' and "ClassificationTypeCategoryID" = 8500 limit 1),
  'Sales',
  true,
  false,
  true,
  false
);

INSERT INTO
  public."DefaultOrganisationLedgerTemplate"
(
  "DefaultOrganisationTemplateID",
  "DefaultOrganisationTemplateVersionNumber",
  "LedgerAccountTypeID",
  "LedgerAccountName",
  "HandlesCredit",
  "HandlesDebit",
  "IsActive",
  "IsDeleted"
)
VALUES (
  DoTemplateID,
  DoVersionNumber,
  (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Purchasing' and "ClassificationTypeCategoryID" = 8500 limit 1),
  'Purchasing',
  false,
  true,
  true,
  false
);

INSERT INTO
  public."DefaultOrganisationLedgerTemplate"
(
  "DefaultOrganisationTemplateID",
  "DefaultOrganisationTemplateVersionNumber",
  "LedgerAccountTypeID",
  "LedgerAccountName",
  "HandlesCredit",
  "HandlesDebit",
  "IsActive",
  "IsDeleted"
)
VALUES (
  DoTemplateID,
  DoVersionNumber,
  (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Merchant' and "ClassificationTypeCategoryID" = 8500 limit 1),
  'Main',
  false,
  true,
  true,
  false
);


-- personal payment only gets card payments
INSERT INTO
  public."DefaultOrganisationPaymentMethodTemplate"
(
  "DefaultOrganisationTemplateID",
  "DefaultOrganisationTemplateVersionNumber",
  "GlobalPaymentMethodID",
  "IsActive",
  "IsDeleted"
)
VALUES (
  DoTemplateID,
  DoVersionNumber,
  (select "GlobalPaymentMethodID" from "GlobalPaymentMethod" where "Name" = 'Card' limit 1 ),
  true,
  false
);

perform "fn_PromoteDefaultOrganisationTemplate"(DoTemplateID, DoVersionNumber);

END $$;

------------------------------------------------------------------------------------------------------------------------------------------*/