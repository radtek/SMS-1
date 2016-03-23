
INSERT INTO public."OrganisationRoleClaim" ("OrganisationID", "OrganisationRoleID", "ResourceID" , "OperationID")
VALUES (
(SELECT "OrganisationID" FROM "OrganisationRole"
WHERE "ParentID"= (select "RoleID" from "Role" where "RoleName" = 'Support Administrator' limit 1)),
(SELECT "OrganisationRoleID" FROM "OrganisationRole"
WHERE "ParentID"= (select "RoleID" from "Role" where "RoleName" = 'Support Administrator' limit 1)),
(select "ResourceID" from "Resource" where "ResourceName" = 'SupportItem' limit 1),
(select "OperationID" from "Operation" where "OperationName" = 'Add' limit 1))


INSERT INTO public."OrganisationRoleClaim" ("OrganisationID", "OrganisationRoleID", "ResourceID" , "OperationID")
VALUES (
(SELECT "OrganisationID" FROM "OrganisationRole"
WHERE "ParentID"= (select "RoleID" from "Role" where "RoleName" = 'Organisation Employee' limit 1)),
(SELECT "OrganisationRoleID" FROM "OrganisationRole"
WHERE "ParentID"= (select "RoleID" from "Role" where "RoleName" = 'Organisation Employee' limit 1)),
(select "ResourceID" from "Resource" where "ResourceName" = 'SupportItem' limit 1),
(select "OperationID" from "Operation" where "OperationName" = 'Send' limit 1))