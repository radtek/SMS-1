
-- Admin Organisation
DO $$
Declare DoTemplateID uuid;
Declare DoVersionNumber integer;
Declare UserRoleID uuid;
Declare OrganisationTypeID integer;
Begin

-- declare variables

OrganisationTypeID := (select "OrganisationTypeID" from "OrganisationType" where "Name" = 'Conveyancy' limit 1);

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
  'Conveyancing Organisation',
  'Template for an Conveyancing Organisation',
  true,
  false,
  OrganisationTypeID
);

DoTemplateID:= (select dot."DefaultOrganisationTemplateID" from "DefaultOrganisationTemplate" dot where dot."Name" = 'Conveyancing Organisation' limit 1);
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
  (select "UserTypeID" from "UserType" where "Name" = 'User' limit 1),
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
  (select "UserTypeID" from "UserType" where "Name" = 'Compliance Officer' limit 1),
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
  (select "UserTypeID" from "UserType" where "Name" = 'Branch Administrator' limit 1),
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
  (select "RoleID" from "Role" where "RoleName" = 'STS User' limit 1),
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
  (select "RoleID" from "Role" where "RoleName" = 'STS Employee' limit 1),
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
  (select "RoleID" from "Role" where "RoleName" = 'STS Admin' limit 1),
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
  (select "RoleID" from "Role" where "RoleName" = 'Organisation Administrator' limit 1),
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
  (select "RoleID" from "Role" where "RoleName" = 'Organisation Branch Administrator' limit 1),
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
  (select "RoleID" from "Role" where "RoleName" = 'Organisation Employee' limit 1),
  false,
  DoVersionNumber
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

-- user
INSERT INTO
  public."DefaultOrganisationRoleTargetTemplate"
(
  "DefaultOrganisationRoleTemplateID",
  "DefaultOrganisationUserTargetTemplateID"
)
VALUES (
  (select dot."DefaultOrganisationRoleTemplateID" from "DefaultOrganisationRoleTemplate" dot where dot."DefaultOrganisationTemplateID" = DoTemplateID
  	and dot."RoleID" = (select "RoleID" from "Role" where "RoleName" = 'Organisation Employee' limit 1) and dot."DefaultOrganisationTemplateVersionNumber" = DoVersionNumber limit 1),
  (select "DefaultOrganisationUserTargetTemplateID" from "DefaultOrganisationUserTargetTemplate" where "DefaultOrganisationTemplateID" = DoTemplateID
  	and "DefaultOrganisationTemplateVersionNumber" = DoVersionNumber and "UserTypeID" = (select "UserTypeID" from "UserType" where "Name" = 'User' limit 1) limit 1)
);


INSERT INTO
  public."DefaultOrganisationRoleTargetTemplate"
(
  "DefaultOrganisationRoleTemplateID",
  "DefaultOrganisationUserTargetTemplateID"
)
VALUES (
  (select dot."DefaultOrganisationRoleTemplateID" from "DefaultOrganisationRoleTemplate" dot where dot."DefaultOrganisationTemplateID" = DoTemplateID
  	and dot."RoleID" = (select "RoleID" from "Role" where "RoleName" = 'STS Employee' limit 1) and dot."DefaultOrganisationTemplateVersionNumber" = DoVersionNumber limit 1),
  (select "DefaultOrganisationUserTargetTemplateID" from "DefaultOrganisationUserTargetTemplate" where "DefaultOrganisationTemplateID" = DoTemplateID
  	and "DefaultOrganisationTemplateVersionNumber" = DoVersionNumber and "UserTypeID" = (select "UserTypeID" from "UserType" where "Name" = 'User' limit 1)  limit 1)
);

-- admin - gets all 4
INSERT INTO
  public."DefaultOrganisationRoleTargetTemplate"
(
  "DefaultOrganisationRoleTemplateID",
  "DefaultOrganisationUserTargetTemplateID"
)
VALUES (
  (select dot."DefaultOrganisationRoleTemplateID" from "DefaultOrganisationRoleTemplate" dot where dot."DefaultOrganisationTemplateID" = DoTemplateID
  	and dot."RoleID" = (select "RoleID" from "Role" where "RoleName" = 'Organisation Employee' limit 1) and dot."DefaultOrganisationTemplateVersionNumber" = DoVersionNumber limit 1),
  (select "DefaultOrganisationUserTargetTemplateID" from "DefaultOrganisationUserTargetTemplate" where "DefaultOrganisationTemplateID" = DoTemplateID
  	and "DefaultOrganisationTemplateVersionNumber" = DoVersionNumber and "UserTypeID" = (select "UserTypeID" from "UserType" where "Name" = 'Compliance Officer' limit 1)  limit 1)
);

INSERT INTO
  public."DefaultOrganisationRoleTargetTemplate"
(
  "DefaultOrganisationRoleTemplateID",
  "DefaultOrganisationUserTargetTemplateID"
)
VALUES (
  (select dot."DefaultOrganisationRoleTemplateID" from "DefaultOrganisationRoleTemplate" dot where dot."DefaultOrganisationTemplateID" = DoTemplateID
  	and dot."RoleID" = (select "RoleID" from "Role" where "RoleName" = 'STS Employee' limit 1) and dot."DefaultOrganisationTemplateVersionNumber" = DoVersionNumber limit 1),
  (select "DefaultOrganisationUserTargetTemplateID" from "DefaultOrganisationUserTargetTemplate" where "DefaultOrganisationTemplateID" = DoTemplateID
  	and "DefaultOrganisationTemplateVersionNumber" = DoVersionNumber and "UserTypeID" = (select "UserTypeID" from "UserType" where "Name" = 'Compliance Officer' limit 1)  limit 1)
);
INSERT INTO
  public."DefaultOrganisationRoleTargetTemplate"
(
  "DefaultOrganisationRoleTemplateID",
  "DefaultOrganisationUserTargetTemplateID"
)
VALUES (
  (select dot."DefaultOrganisationRoleTemplateID" from "DefaultOrganisationRoleTemplate" dot where dot."DefaultOrganisationTemplateID" = DoTemplateID
  	and dot."RoleID" = (select "RoleID" from "Role" where "RoleName" = 'STS Admin' limit 1) and dot."DefaultOrganisationTemplateVersionNumber" = DoVersionNumber limit 1),
  (select "DefaultOrganisationUserTargetTemplateID" from "DefaultOrganisationUserTargetTemplate" where "DefaultOrganisationTemplateID" = DoTemplateID
  	and "DefaultOrganisationTemplateVersionNumber" = DoVersionNumber and "UserTypeID" = (select "UserTypeID" from "UserType" where "Name" = 'Compliance Officer' limit 1)  limit 1)
);

INSERT INTO
  public."DefaultOrganisationRoleTargetTemplate"
(
  "DefaultOrganisationRoleTemplateID",
  "DefaultOrganisationUserTargetTemplateID"
)
VALUES (
  (select dot."DefaultOrganisationRoleTemplateID" from "DefaultOrganisationRoleTemplate" dot where dot."DefaultOrganisationTemplateID" = DoTemplateID
  	and dot."RoleID" = (select "RoleID" from "Role" where "RoleName" = 'Organisation Administrator' limit 1) and dot."DefaultOrganisationTemplateVersionNumber" = DoVersionNumber limit 1),
  (select "DefaultOrganisationUserTargetTemplateID" from "DefaultOrganisationUserTargetTemplate" where "DefaultOrganisationTemplateID" = DoTemplateID
  	and "DefaultOrganisationTemplateVersionNumber" = DoVersionNumber and "UserTypeID" = (select "UserTypeID" from "UserType" where "Name" = 'Compliance Officer' limit 1)  limit 1)
);

-- branch administrator gets 3
INSERT INTO
  public."DefaultOrganisationRoleTargetTemplate"
(
  "DefaultOrganisationRoleTemplateID",
  "DefaultOrganisationUserTargetTemplateID"
)
VALUES (
  (select dot."DefaultOrganisationRoleTemplateID" from "DefaultOrganisationRoleTemplate" dot where dot."DefaultOrganisationTemplateID" = DoTemplateID
  	and dot."RoleID" = (select "RoleID" from "Role" where "RoleName" = 'Organisation Employee' limit 1) and dot."DefaultOrganisationTemplateVersionNumber" = DoVersionNumber limit 1),
  (select "DefaultOrganisationUserTargetTemplateID" from "DefaultOrganisationUserTargetTemplate" where "DefaultOrganisationTemplateID" = DoTemplateID
  	and "DefaultOrganisationTemplateVersionNumber" = DoVersionNumber and "UserTypeID" = (select "UserTypeID" from "UserType" where "Name" = 'Branch Administrator' limit 1)  limit 1)
);

INSERT INTO
  public."DefaultOrganisationRoleTargetTemplate"
(
  "DefaultOrganisationRoleTemplateID",
  "DefaultOrganisationUserTargetTemplateID"
)
VALUES (
  (select dot."DefaultOrganisationRoleTemplateID" from "DefaultOrganisationRoleTemplate" dot where dot."DefaultOrganisationTemplateID" = DoTemplateID
  	and dot."RoleID" = (select "RoleID" from "Role" where "RoleName" = 'STS Employee' limit 1) and dot."DefaultOrganisationTemplateVersionNumber" = DoVersionNumber limit 1),
  (select "DefaultOrganisationUserTargetTemplateID" from "DefaultOrganisationUserTargetTemplate" where "DefaultOrganisationTemplateID" = DoTemplateID
  	and "DefaultOrganisationTemplateVersionNumber" = DoVersionNumber and "UserTypeID" = (select "UserTypeID" from "UserType" where "Name" = 'Branch Administrator' limit 1)  limit 1)
);
INSERT INTO
  public."DefaultOrganisationRoleTargetTemplate"
(
  "DefaultOrganisationRoleTemplateID",
  "DefaultOrganisationUserTargetTemplateID"
)
VALUES (
  (select dot."DefaultOrganisationRoleTemplateID" from "DefaultOrganisationRoleTemplate" dot where dot."DefaultOrganisationTemplateID" = DoTemplateID
  	and dot."RoleID" = (select "RoleID" from "Role" where "RoleName" = 'Organisation Branch Administrator' limit 1) and dot."DefaultOrganisationTemplateVersionNumber" = DoVersionNumber limit 1),
  (select "DefaultOrganisationUserTargetTemplateID" from "DefaultOrganisationUserTargetTemplate" where "DefaultOrganisationTemplateID" = DoTemplateID
  	and "DefaultOrganisationTemplateVersionNumber" = DoVersionNumber and "UserTypeID" = (select "UserTypeID" from "UserType" where "Name" = 'Branch Administrator' limit 1)  limit 1)
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
  (select "GlobalPaymentMethodID" from "GlobalPaymentMethod" where "Name" = 'Direct Debit' limit 1 ),
  true,
  false
);

perform "fn_PromoteDefaultOrganisationTemplate"(DoTemplateID, DoVersionNumber);

END $$;