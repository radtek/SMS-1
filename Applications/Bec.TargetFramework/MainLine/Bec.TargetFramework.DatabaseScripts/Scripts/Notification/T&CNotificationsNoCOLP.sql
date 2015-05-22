

-- NOTIFICATIONS

-- Firm Conveyancing
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
  '4fb312fe-489f-11e4-8f39-5f438902bf9f',
  1,
  'TcFirmConveyancing',
  'Firm Conveyancing Terms and Conditions',
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
  '4fb312fe-489f-11e4-8f39-5f438902bf9f',
  1,
  null,
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
  '4fb312fe-489f-11e4-8f39-5f438902bf9f',
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
  '4fb312fe-489f-11e4-8f39-5f438902bf9f',
  1,
  'TermsConditionsDataDTO',
  'Bec.TargetFramework.Entities.TermsConditionsDataDTO, Bec.TargetFramework.Entities',
  'TermsConditionsDataDTO',
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
  '4fb227fe-489f-11e4-b824-13eff2d1a1e2',
  'TcFirmConveyancing',
  'Firm Conveyancing Terms and Conditions Resource',
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
  '4fb312fe-489f-11e4-8f39-5f438902bf9f',
  1,
  null,
  '4fb227fe-489f-11e4-b824-13eff2d1a1e2',
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1),
  null,
  null,
  true,
  false,
  null
);

-- FirmConveyancingIndividual
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
  '4fb312fe-489f-11e4-b279-e39116eaefb1',
  1,
  'TcFirmConveyancingIndividual',
  'Firm Conveyancing Individual Terms and Conditions',
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
  '4fb312fe-489f-11e4-b279-e39116eaefb1',
  1,
  null,
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
  '4fb312fe-489f-11e4-b279-e39116eaefb1',
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
  '4fb312fe-489f-11e4-b279-e39116eaefb1',
  1,
  'TermsConditionsDataDTO',
  'Bec.TargetFramework.Entities.TermsConditionsDataDTO, Bec.TargetFramework.Entities',
  'TermsConditionsDataDTO',
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
  '4fb24f2c-489f-11e4-9b9c-fb75633d3d1c',
  'TcFirmConveyancingIndividual',
  'Firm Conveyancing Individual Terms and Conditions Resource',
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
  '4fb312fe-489f-11e4-b279-e39116eaefb1',
  1,
  null,
  '4fb24f2c-489f-11e4-9b9c-fb75633d3d1c',
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1),
  null,
  null,
  true,
  false,
  null
);

-- STS Sales
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
  '4fb36100-489f-11e4-aab0-af945e16deae',
  1,
  'TcSTSSales',
  'STS Sales Terms and Conditions',
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
  '4fb36100-489f-11e4-aab0-af945e16deae',
  1,
  null,
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
  '4fb36100-489f-11e4-aab0-af945e16deae',
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
  '4fb36100-489f-11e4-aab0-af945e16deae',
  1,
  'TermsConditionsDataDTO',
  'Bec.TargetFramework.Entities.TermsConditionsDataDTO, Bec.TargetFramework.Entities',
  'TermsConditionsDataDTO',
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
  '4fb227fe-489f-11e4-90ad-27a6fb7c01fc',
  'TcSTSSales',
  'STS Sales Terms and Conditions Claim',
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
  '4fb36100-489f-11e4-aab0-af945e16deae',
  1,
  null,
  '4fb227fe-489f-11e4-90ad-27a6fb7c01fc',
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1),
  null,
  null,
  true,
  false,
  null
);


-- STS Purchase
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
  '4fb36100-489f-11e4-9edb-670e734c1d41',
  1,
  'TcSTSPurchase',
  'STS Purchase Terms and Conditions',
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
  '4fb36100-489f-11e4-9edb-670e734c1d41',
  1,
  null,
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
  '4fb36100-489f-11e4-9edb-670e734c1d41',
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
  '4fb36100-489f-11e4-9edb-670e734c1d41',
  1,
  'TermsConditionsDataDTO',
  'Bec.TargetFramework.Entities.TermsConditionsDataDTO, Bec.TargetFramework.Entities',
  'TermsConditionsDataDTO',
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
  '4fb20116-489f-11e4-bb52-dbee293e6936',
  'TcSTSPurchase',
  'STS Purchase and Conditions Claim',
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
  '4fb36100-489f-11e4-9edb-670e734c1d41',
  1,
  null,
  '4fb20116-489f-11e4-bb52-dbee293e6936',
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1),
  null,
  null,
  true,
  false,
  null
);


-- Public
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
  '4fb339f0-489f-11e4-a2d3-ef22e599ccbb',
  1,
  'TcPublic',
  'Public Terms and Conditions',
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
  '4fb339f0-489f-11e4-a2d3-ef22e599ccbb',
  1,
  null,
  true,
  false,
  CURRENT_DATE,
  true,
  false
);

--not required for Ts and Cs
-- Parameters
--INSERT INTO
--  public."NotificationConstructParameterTemplate"
--(
--  "NotificationConstructTemplateID",
--  "NotificationConstructTemplateVersionNumber",
--  "ParameterOrBusinessObjectName",
--  "ObjectType",
--  "ObjectName",
--  "ObjectNameSpace",
--  "ObjectAssembly",
--  "IsMandatory",
--  "IsActive",
--  "IsDeleted",
--  "IsBusinessObject",
--  "BusinessObjectCategoryName"
--)
--VALUES (
--  '4fb339f0-489f-11e4-a2d3-ef22e599ccbb',
--  1,
--  'NotificationSettingDTO',
--  'Bec.TargetFramework.Entities.NotificationSettingDTO, Bec.TargetFramework.Entities',
--  'NotificationSettingDTO',
--  'Bec.TargetFramework.Entities',
--  'Bec.TargetFramework.Entities',
--  true,
--  true,
--  false,
--  true,
--  'General'
--);

--INSERT INTO
--  public."NotificationConstructParameterTemplate"
--(
--  "NotificationConstructTemplateID",
--  "NotificationConstructTemplateVersionNumber",
--  "ParameterOrBusinessObjectName",
--  "ObjectType",
--  "ObjectName",
--  "ObjectNameSpace",
--  "ObjectAssembly",
--  "IsMandatory",
--  "IsActive",
--  "IsDeleted",
--  "IsBusinessObject",
--  "BusinessObjectCategoryName"
--)
--VALUES (
--  '4fb339f0-489f-11e4-a2d3-ef22e599ccbb',
--  1,
--  'TermsConditionsDataDTO',
--  'Bec.TargetFramework.Entities.TermsConditionsDataDTO, Bec.TargetFramework.Entities',
--  'TermsConditionsDataDTO',
--  'Bec.TargetFramework.Entities',
--  'Bec.TargetFramework.Entities',
--  true,
--  true,
--  false,
--  true,
--  'General'
--);

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
  '4fb24f2c-489f-11e4-be44-93993f0045a6',
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
  '4fb339f0-489f-11e4-a2d3-ef22e599ccbb',
  1,
  null,
  '4fb24f2c-489f-11e4-be44-93993f0045a6',
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1),
  null,
  null,
  true,
  false,
  null
);


-- FirmSPIndividual
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
  '4fb339f0-489f-11e4-b944-6febb18b2af7',
  1,
  'TcFirmSPIndividual',
  'Firm Support Partner Individual Terms and Conditions',
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
  '4fb339f0-489f-11e4-b944-6febb18b2af7',
  1,
  null,
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
  '4fb339f0-489f-11e4-b944-6febb18b2af7',
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
  '4fb339f0-489f-11e4-b944-6febb18b2af7',
  1,
  'TermsConditionsDataDTO',
  'Bec.TargetFramework.Entities.TermsConditionsDataDTO, Bec.TargetFramework.Entities',
  'TermsConditionsDataDTO',
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
  '4fb27614-489f-11e4-85a4-6fcc8fecf113',
  'TcFirmSPIndividual',
  'Firm Support Partner Individual Terms and Conditions Resource',
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
  '4fb339f0-489f-11e4-b944-6febb18b2af7',
  1,
  null,
  '4fb27614-489f-11e4-85a4-6fcc8fecf113',
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1),
  null,
  null,
  true,
  false,
  null
);


-- Firm SP
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
  '4fb36100-489f-11e4-84f4-53c0b07c4429',
  1,
  'TcFirmSP',
  'Firm Support Partner Terms and Conditions',
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
  '4fb36100-489f-11e4-84f4-53c0b07c4429',
  1,
  null,
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
  '4fb36100-489f-11e4-84f4-53c0b07c4429',
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
  '4fb36100-489f-11e4-84f4-53c0b07c4429',
  1,
  'TermsConditionsDataDTO',
  'Bec.TargetFramework.Entities.TermsConditionsDataDTO, Bec.TargetFramework.Entities',
  'TermsConditionsDataDTO',
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
  '4fb27614-489f-11e4-8ef0-23e182a555c0',
  'TcFirmSP',
  'Firm Support Partner Terms and Conditions',
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
  '4fb36100-489f-11e4-84f4-53c0b07c4429',
  1,
  null,
  '4fb27614-489f-11e4-8ef0-23e182a555c0',
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1),
  null,
  null,
  true,
  false,
  null
);

---

-- Create Notification Group Templates

--------------------------------------------------------------


-- TC Group
INSERT INTO
  public."NotificationConstructGroupTemplate"("NotificationConstructGroupTemplateID",
    "NotificationConstructGroupTemplateVersion", "Name", "Description", "IsActive", "IsDeleted",
    "NotificationConstructGroupTypeID")
VALUES
  ('4fb3ae4e-489f-11e4-af43-6b8afb4dfff3', 1, 'TC', 'Terms and Conditions', true, false, 670101
    );

-- SP


INSERT INTO
  public."NotificationConstructGroupNotificationConstructTemplate"
(
  "NotificationConstructGroupNotificationConstructTemplateVersion",
  "NotificationConstructGroupTemplateID",
  "NotificationConstructGroupTemplateVersion",
  "UserTypeID",
  "NotificationConstructTemplateID",
  "NotificationConstructTemplateVersionNumber",
  "IsActive",
  "IsDeleted",
  "OrganisationTypeID"
)
VALUES (
  1,
  '4fb3ae4e-489f-11e4-af43-6b8afb4dfff3',
  1,
  '9e8ca436-2139-11e4-a37d-8771a20de3d2',
  '4fb339f0-489f-11e4-a2d3-ef22e599ccbb',
  1,
  true,
  false,
 31
);

INSERT INTO
  public."NotificationConstructGroupNotificationConstructTemplate"
(
  "NotificationConstructGroupNotificationConstructTemplateVersion",
  "NotificationConstructGroupTemplateID",
  "NotificationConstructGroupTemplateVersion",
  "UserTypeID",
  "NotificationConstructTemplateID",
  "NotificationConstructTemplateVersionNumber",
  "IsActive",
  "IsDeleted",
  "OrganisationTypeID"
)
VALUES (
  1,
  '4fb3ae4e-489f-11e4-af43-6b8afb4dfff3',
  1,
  '9e8ca436-2139-11e4-a37d-8771a20de3d2',
  '4fb339f0-489f-11e4-b944-6febb18b2af7',
  1,
  true,
  false,
  31
);

INSERT INTO
  public."NotificationConstructGroupNotificationConstructTemplate"
(
  "NotificationConstructGroupNotificationConstructTemplateVersion",
  "NotificationConstructGroupTemplateID",
  "NotificationConstructGroupTemplateVersion",
  "UserTypeID",
  "NotificationConstructTemplateID",
  "NotificationConstructTemplateVersionNumber",
  "IsActive",
  "IsDeleted",
  "OrganisationTypeID"
)
VALUES (
  1,
  '4fb3ae4e-489f-11e4-af43-6b8afb4dfff3',
  1,
  '9e8ca436-2139-11e4-a37d-8771a20de3d2',
  '4fb36100-489f-11e4-84f4-53c0b07c4429',
  1,
  true,
  false,
  31
);

INSERT INTO
  public."NotificationConstructGroupNotificationConstructTemplate"
(
  "NotificationConstructGroupNotificationConstructTemplateVersion",
  "NotificationConstructGroupTemplateID",
  "NotificationConstructGroupTemplateVersion",
  "UserTypeID",
  "NotificationConstructTemplateID",
  "NotificationConstructTemplateVersionNumber",
  "IsActive",
  "IsDeleted",
  "OrganisationTypeID"
)
VALUES (
  1,
  '4fb3ae4e-489f-11e4-af43-6b8afb4dfff3',
  1,
  '9e8ca436-2139-11e4-a37d-8771a20de3d2',
  '4fb36100-489f-11e4-9edb-670e734c1d41',
  1,
  true,
  false,
  31
);

INSERT INTO
  public."NotificationConstructGroupNotificationConstructTemplate"
(
  "NotificationConstructGroupNotificationConstructTemplateVersion",
  "NotificationConstructGroupTemplateID",
  "NotificationConstructGroupTemplateVersion",
  "UserTypeID",
  "NotificationConstructTemplateID",
  "NotificationConstructTemplateVersionNumber",
  "IsActive",
  "IsDeleted",
  "OrganisationTypeID"
)
VALUES (
  1,
  '4fb3ae4e-489f-11e4-af43-6b8afb4dfff3',
  1,
  '9e8ca436-2139-11e4-a37d-8771a20de3d2',
  '4fb36100-489f-11e4-aab0-af945e16deae',
  1,
  true,
  false,
  31
);

------- promotion because I am annoyed at the lathargic devs

-- promote nots
SELECT * FROM public."fn_PromoteNotificationConstructTemplate"('4fb312fe-489f-11e4-8f39-5f438902bf9f', 1);
SELECT * FROM public."fn_PromoteNotificationConstructTemplate"('4fb312fe-489f-11e4-b279-e39116eaefb1', 1);
SELECT * FROM public."fn_PromoteNotificationConstructTemplate"('4fb339f0-489f-11e4-a2d3-ef22e599ccbb', 1);
SELECT * FROM public."fn_PromoteNotificationConstructTemplate"('4fb339f0-489f-11e4-b944-6febb18b2af7', 1);
SELECT * FROM public."fn_PromoteNotificationConstructTemplate"('4fb36100-489f-11e4-84f4-53c0b07c4429', 1);
SELECT * FROM public."fn_PromoteNotificationConstructTemplate"('4fb36100-489f-11e4-9edb-670e734c1d41', 1);
SELECT * FROM public."fn_PromoteNotificationConstructTemplate"('4fb36100-489f-11e4-aab0-af945e16deae', 1);

-- promote group
INSERT INTO
  public."NotificationConstructGroup"
(
  "NotificationConstructGroupID",
  "NotificationConstructGroupVersion",
  "Name",
  "Description",
  "IsActive",
  "IsDeleted",
  "ParentID",
  "NotificationConstructGroupTemplateID",
  "NotificationConstructGroupTemplateVersion",
  "NotificationConstructGroupTypeID",
  "NotificationConstructGroupCategoryID"
)
SELECT
  '4fb3ae4e-489f-11e4-af43-6b8afb4dfff3',
   1,
  ngt."Name",
  ngt."Description",
  ngt."IsActive",
  ngt."IsDeleted",
  ngt."ParentID",
  ngt."NotificationConstructGroupTemplateID",
  ngt."NotificationConstructGroupTemplateVersion",
  ngt."NotificationConstructGroupTypeID",
  ngt."NotificationConstructGroupCategoryID"

FROM
  public."NotificationConstructGroupTemplate" ngt

  where ngt."Name" = 'TC' limit 1
  ;

INSERT INTO
  public."NotificationConstructGroupNotificationConstruct"
(
  "NotificationConstructGroupNotificationConstructVersion",
  "NotificationConstructGroupID",
  "NotificationConstructGroupVersion",
  "UserTypeID",
  "NotificationConstructID",
  "NotificationConstructVersionNumber",
  "WorkflowID",
  "WorkflowVersionNumber",
  "IsActive",
  "IsDeleted",
  "ConditionString",
  "OrganisationTypeID"
)
SELECT
  1,
  ncg."NotificationConstructGroupID",
  ncg."NotificationConstructGroupVersion",
  ngt."UserTypeID",
  nc."NotificationConstructID",
  nc."NotificationConstructVersionNumber",
  ngt."WorkflowTemplateID",
  ngt."WorkflowTemplateVersionNumber",
  ngt."IsActive",
  ngt."IsDeleted",
  ngt."ConditionString",
  ngt."OrganisationTypeID"
FROM
  public."NotificationConstructGroupNotificationConstructTemplate" ngt

  left outer join "NotificationConstructGroup" ncg on
  	ncg."NotificationConstructGroupTemplateID" = ngt."NotificationConstructGroupTemplateID"
    and
    ncg."NotificationConstructGroupTemplateVersion" = ngt."NotificationConstructGroupTemplateVersion"

  left outer join "NotificationConstruct" nc
  	on nc."NotificationConstructTemplateID" = ngt."NotificationConstructTemplateID"
    and nc."NotificationConstructTemplateVersionNumber" = ngt."NotificationConstructTemplateVersionNumber"

  where ngt."NotificationConstructGroupTemplateID" = '4fb3ae4e-489f-11e4-af43-6b8afb4dfff3'
  and ngt."NotificationConstructGroupTemplateVersion" = 1 ;


