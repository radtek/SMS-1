-- ONline Payment Receipt
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
  'b7fd9ff4-4f8f-11e4-a3a7-4bf9c31f725c',
  1,
  'OnlineReceipt',
  'OnlineReceipt',
  4989,
  4992,
  'Bec.TargetFramework.SB.Notifications.Mutators.OnlineReceiptMutator, Bec.TargetFramework.SB.Notifications'
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
  'b7fd9ff4-4f8f-11e4-a3a7-4bf9c31f725c',
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
  'b7fd9ff4-4f8f-11e4-a3a7-4bf9c31f725c',
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
  'b7fd9ff4-4f8f-11e4-a3a7-4bf9c31f725c',
  1,
  'VOrganisationDetailDTO',
  'Bec.TargetFramework.Entities.VOrganisationDetailDTO, Bec.TargetFramework.Entities',
  'VOrganisationDetailDTO',
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
  'b7fd9ff4-4f8f-11e4-a3a7-4bf9c31f725c',
  1,
  'VUserOrganisationDTO',
  'Bec.TargetFramework.Entities.VUserOrganisationDTO, Bec.TargetFramework.Entities',
  'VUserOrganisationDTO',
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
  'b7fd9ff4-4f8f-11e4-a3a7-4bf9c31f725c',
  1,
  'VInvoiceWithCurrentTransactionOrderStatusDTO',
  'Bec.TargetFramework.Entities.VInvoiceWithCurrentTransactionOrderStatusDTO, Bec.TargetFramework.Entities',
  'VInvoiceWithCurrentTransactionOrderStatusDTO',
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
  'b7fd9ff4-4f8f-11e4-a3a7-4bf9c31f725c',
  1,
  'InvoiceDTO',
  'Bec.TargetFramework.Entities.InvoiceDTO, Bec.TargetFramework.Entities',
  'InvoiceDTO',
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
  'b7fd9ff4-4f8f-11e4-a3a7-4bf9c31f725c',
  1,
  'OrderRequestDTO',
  'Bec.TargetFramework.Entities.OrderRequestDTO, Bec.TargetFramework.Entities',
  'OrderRequestDTO',
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
  'b7fdc704-4f8f-11e4-a6db-eb8bf36842e6',
  'OnlineReceipt',
  'OnlineReceipt Resource',
  true,
  false,
  'b7fd9ff4-4f8f-11e4-a3a7-4bf9c31f725c'
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
  'b7fd9ff4-4f8f-11e4-a3a7-4bf9c31f725c',
  1,
  null,
  'b7fdc704-4f8f-11e4-a6db-eb8bf36842e6',
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1),
  null,
  null,
  true,
  false,
  null
);

SELECT * FROM public."fn_PromoteNotificationConstructTemplate"('b7fd9ff4-4f8f-11e4-a3a7-4bf9c31f725c', 1);