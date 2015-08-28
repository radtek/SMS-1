
DO $$
Declare ModuleID UUID;
Declare ModuleVN integer;
Declare MenuStateTypeID integer;
Declare MenuStateTypeID1 integer;
Declare MenuStateTypeID2 integer;
Declare MenuStateID uuid;
Declare MenuStateID1 uuid;
Declare MenuStateID2 uuid;
Declare MenuSubStateID uuid;
Declare MenuSubStateID1 uuid;
Declare MenuSubStateID2 uuid;
Declare AdminRoleID uuid;
Declare LoopRow RECORD;
Declare ResourceTypeID integer;
Declare ResourceID UUID;
Begin

ModuleID := uuid_generate_v1();
ModuleVN := 1;

MenuStateTypeID := (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'CenterTopMenu' and "ClassificationTypeCategoryID" = 150 limit 1);

MenuStateTypeID1 := (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Default Organisation' and "ClassificationTypeCategoryID" = 150 limit 1);

MenuStateTypeID2 := (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Global' and "ClassificationTypeCategoryID" = 150 limit 1);

ResourceTypeID := (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Module' limit 1);

INSERT INTO
  public."ModuleTemplate"
(
  "ModuleTemplateID",
  "Name",
  "Description",
  "IsActive",
  "IsDeleted",
  "ModuleTemplateVersionNumber"
)
VALUES (
  ModuleID,
  'Administration Module',
  'Administration Module',
  true,
  false,
  ModuleVN
);
--- SUBSCRIPTION ---



--- SECURITY ----


-- add claim

-- add menu claims
INSERT INTO
  public."State"
(
  "StateName",
  "StateDescription",
  "StateTypeID"
)
VALUES (
  'AdministrationModuleMenu',
  'Administration Module Menu',
  MenuStateTypeID
);

MenuStateID := (select "StateID" from "State" where "StateName" = 'AdministrationModuleMenu' and "StateTypeID" = MenuStateTypeID limit 1);

-- add root menu item (center)
INSERT INTO
  public."StateItem"
(
  "StateItemName",
  "StateItemDescription",
  "StateID"
)
VALUES (
  'Administration',
  'Administration',
  MenuStateID
);

MenuSubStateID := (select "StateItemID" from "StateItem" where "StateID" = MenuStateID and "StateItemName" = 'Administration' limit 1);

-- add sub menu item
INSERT INTO
  public."StateItem"
(
  "StateItemName",
  "StateItemDescription",
  "StateID",
  "ParentStateItemID",
  "StateItemOrder"
)
VALUES (
  'UserManagement',
  'User Management',
  MenuStateID,
  MenuSubStateID,
  0
);

INSERT INTO
  public."StateItem"
(
  "StateItemName",
  "StateItemDescription",
  "StateID",
  "ParentStateItemID",
  "StateItemOrder"
)
VALUES (
  'OrganisationManagement',
  'Organisation Management',
  MenuStateID,
  MenuSubStateID,
  0
);


--Menu 2

INSERT INTO
  public."State"
(
  "StateName",
  "StateDescription",
  "StateTypeID"
)
VALUES (
  'AdministrationModuleMenu',
  'Administration Module Menu',
  MenuStateTypeID1
);

MenuStateID1 := (select "StateID" from "State" where "StateName" = 'AdministrationModuleMenu' and "StateTypeID" = MenuStateTypeID1 limit 1);

-- add root menu item (center)
INSERT INTO
  public."StateItem"
(
  "StateItemName",
  "StateItemDescription",
  "StateID"
)
VALUES (
  'Administration',
  'Administration',
  MenuStateID1
);

MenuSubStateID1 := (select "StateItemID" from "StateItem" where "StateID" = MenuStateID1 and "StateItemName" = 'Administration' limit 1);

-- add sub menu item
INSERT INTO
  public."StateItem"
(
  "StateItemName",
  "StateItemDescription",
  "StateID",
  "ParentStateItemID",
  "StateItemOrder"
)
VALUES (
  'UserManagement',
  'User Management',
  MenuStateID1,
  MenuSubStateID1,
  0
);

INSERT INTO
  public."StateItem"
(
  "StateItemName",
  "StateItemDescription",
  "StateID",
  "ParentStateItemID",
  "StateItemOrder"
)
VALUES (
  'OrganisationManagement',
  'Organisation Management',
  MenuStateID1,
  MenuSubStateID1,
  0
);


--Menu 3

INSERT INTO
  public."State"
(
  "StateName",
  "StateDescription",
  "StateTypeID"
)
VALUES (
  'AdministrationModuleMenu',
  'Administration Module Menu',
  MenuStateTypeID2
);

MenuStateID2 := (select "StateID" from "State" where "StateName" = 'AdministrationModuleMenu' and "StateTypeID" = MenuStateTypeID2 limit 1);

-- add root menu item (center)
INSERT INTO
  public."StateItem"
(
  "StateItemName",
  "StateItemDescription",
  "StateID"
)
VALUES (
  'Administration',
  'Administration',
  MenuStateID2
);

MenuSubStateID2 := (select "StateItemID" from "StateItem" where "StateID" = MenuStateID2 and "StateItemName" = 'Administration' limit 1);

-- add sub menu item
INSERT INTO
  public."StateItem"
(
  "StateItemName",
  "StateItemDescription",
  "StateID",
  "ParentStateItemID",
  "StateItemOrder"
)
VALUES (
  'UserManagement',
  'User Management',
  MenuStateID2,
  MenuSubStateID2,
  0
);

INSERT INTO
  public."StateItem"
(
  "StateItemName",
  "StateItemDescription",
  "StateID",
  "ParentStateItemID",
  "StateItemOrder"
)
VALUES (
  'OrganisationManagement',
  'Organisation Management',
  MenuStateID2,
  MenuSubStateID2,
  0
);


-- add module role entry

AdminRoleID := (select "RoleID" from "Role" where "IsGlobal" = true and "RoleName" = 'Administration User' limit 1);

INSERT INTO
  public."ModuleClaimTemplate"
(
  "RoleID",
  "StateID",
  "StateItemID",
  "ModuleTemplateID",
  "ModuleTemplateVersionNumber"
)
VALUES (
  AdminRoleID,
  MenuStateID,
  MenuSubStateID,
  ModuleID,
  ModuleVN
);

-- sub items
FOR LoopRow IN
        SELECT *
        FROM   "StateItem"
        Where "StateID" = MenuStateID and "ParentStateItemID" = MenuSubStateID
LOOP

INSERT INTO
  public."ModuleClaimTemplate"
(
  "RoleID",
  "StateID",
  "StateItemID",
  "ModuleTemplateID",
  "ModuleTemplateVersionNumber"
)
VALUES (
  AdminRoleID,
  MenuStateID,
  LoopRow."StateItemID",
  ModuleID,
  ModuleVN
);

END LOOP;


INSERT INTO
  public."ModuleClaimTemplate"
(
  "RoleID",
  "StateID",
  "StateItemID",
  "ModuleTemplateID",
  "ModuleTemplateVersionNumber"
)
VALUES (
  AdminRoleID,
  MenuStateID1,
  MenuSubStateID2,
  ModuleID,
  ModuleVN
);

-- sub items
FOR LoopRow IN
        SELECT *
        FROM   "StateItem"
        Where "StateID" = MenuStateID1 and "ParentStateItemID" = MenuSubStateID1
LOOP

INSERT INTO
  public."ModuleClaimTemplate"
(
  "RoleID",
  "StateID",
  "StateItemID",
  "ModuleTemplateID",
  "ModuleTemplateVersionNumber"
)
VALUES (
  AdminRoleID,
  MenuStateID1,
  LoopRow."StateItemID",
  ModuleID,
  ModuleVN
);

END LOOP;


INSERT INTO
  public."ModuleClaimTemplate"
(
  "RoleID",
  "StateID",
  "StateItemID",
  "ModuleTemplateID",
  "ModuleTemplateVersionNumber"
)
VALUES (
  AdminRoleID,
  MenuStateID2,
  MenuSubStateID2,
  ModuleID,
  ModuleVN
);

-- sub items
FOR LoopRow IN
        SELECT *
        FROM   "StateItem"
        Where "StateID" = MenuStateID2 and "ParentStateItemID" = MenuSubStateID2
LOOP

INSERT INTO
  public."ModuleClaimTemplate"
(
  "RoleID",
  "StateID",
  "StateItemID",
  "ModuleTemplateID",
  "ModuleTemplateVersionNumber"
)
VALUES (
  AdminRoleID,
  MenuStateID2,
  LoopRow."StateItemID",
  ModuleID,
  ModuleVN
);

END LOOP;



-- add resource with view operation
INSERT INTO
  public."Resource"
(
  "ResourceName",
  "ResourceDescription",
  "ResourceTypeID"
)
VALUES (
  'AdministrationModule',
  'Administration Module',
  ResourceTypeID
);

ResourceID := (select "ResourceID" from "Resource" where "ResourceName" = 'AdministrationModule' limit 1);

-- add operation for view
INSERT INTO
  public."ResourceOperation"
(
  "ResourceID",
  "OperationID"
)
VALUES (
  ResourceID,
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1)
);

INSERT INTO
  public."ModuleClaimTemplate"
(
  "RoleID",
  "ResourceID",
  "OperationID",
  "ModuleTemplateID",
  "ModuleTemplateVersionNumber"
)
VALUES (
  AdminRoleID,
  ResourceID,
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1),
  ModuleID,
  ModuleVN
);

END $$;