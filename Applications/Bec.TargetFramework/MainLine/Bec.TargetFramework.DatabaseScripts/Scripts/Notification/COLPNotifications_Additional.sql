-- CLC Firm Reg 0002
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
  'dd977c2a-47de-11e4-bafa-f30ff879ce17',
  1,
  'COLPRegistrationReminder',
  'COLPRegistrationReminder',
  4989,
  4992,
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
  'dd977c2a-47de-11e4-bafa-f30ff879ce17',
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
  'dd977c2a-47de-11e4-bafa-f30ff879ce17',
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
  'dd977c2a-47de-11e4-bafa-f30ff879ce17',
  1,
  'RegistrationDTO',
  'Bec.TargetFramework.Entities.RegistrationDTO, Bec.TargetFramework.Entities',
  'RegistrationDTO',
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
  'dd977c2a-47de-11e4-bafa-f30ff879ce17',
  1,
  'TemporaryAccountDTO',
  'Bec.TargetFramework.Entities.TemporaryAccountDTO, Bec.TargetFramework.Entities',
  'TemporaryAccountDTO',
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
  '319cc5b4-47df-11e4-be99-07519e9d4f61',
  'COLPRegistrationReminder',
  'COLP Registration Reminder Claim',
  true,
  false,
  'dd977c2a-47de-11e4-bafa-f30ff879ce17'
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
  'dd977c2a-47de-11e4-bafa-f30ff879ce17',
  1,
  null,
  '319cc5b4-47df-11e4-be99-07519e9d4f61',
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1),
  null,
  null,
  true,
  false,
  null
);

---------- COLP Reg 0003
-- CLC Firm Reg
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
  '5b82d53a-47df-11e4-97e4-33de6166e4d7',
  1,
  'COLPNewTempPassword',
  'COLP New Temp Password',
  4989,
  4992,
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
  '5b82d53a-47df-11e4-97e4-33de6166e4d7',
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
  '5b82d53a-47df-11e4-97e4-33de6166e4d7',
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
  '5b82d53a-47df-11e4-97e4-33de6166e4d7',
  1,
  'RegistrationDTO',
  'Bec.TargetFramework.Entities.RegistrationDTO, Bec.TargetFramework.Entities',
  'RegistrationDTO',
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
  '5b82d53a-47df-11e4-97e4-33de6166e4d7',
  1,
  'TemporaryAccountDTO',
  'Bec.TargetFramework.Entities.TemporaryAccountDTO, Bec.TargetFramework.Entities',
  'TemporaryAccountDTO',
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
  '889c9358-47df-11e4-ba7c-e3eea5656fd6',
  'COLPRegistrationSummary',
  'COLP Registration Summary Notification Claim',
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
  '5b82d53a-47df-11e4-97e4-33de6166e4d7',
  1,
  null,
  '889c9358-47df-11e4-ba7c-e3eea5656fd6',
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1),
  null,
  null,
  true,
  false,
  null
);