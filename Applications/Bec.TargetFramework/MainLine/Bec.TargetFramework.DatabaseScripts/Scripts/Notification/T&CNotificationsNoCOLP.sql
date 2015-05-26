

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
  E'\\357\\273\\277<?xml version="1.0" encoding="utf-8" standalone="yes"?>\\015\\012<StiSerializer version="1.02" type="Net" application="StiReport">\\015\\012  <Dictionary Ref="1" type="Dictionary" isKey="true">\\015\\012    <BusinessObjects isList="true" count="0" />\\015\\012    <Databases isList="true" count="0" />\\015\\012    <DataSources isList="true" count="0" />\\015\\012    <Relations isList="true" count="0" />\\015\\012    <Report isRef="0" />\\015\\012    <Variables isList="true" count="1">\\015\\012      <value>General</value>\\015\\012    </Variables>\\015\\012  </Dictionary>\\015\\012  <EngineVersion>EngineV2</EngineVersion>\\015\\012  <GlobalizationStrings isList="true" count="0" />\\015\\012  <MetaTags isList="true" count="0" />\\015\\012  <Pages isList="true" count="1">\\015\\012    <Page1 Ref="2" type="Page" isKey="true">\\015\\012      <Border>None;Black;2;Solid;False;4;Black</Border>\\015\\012      <Brush>Transparent</Brush>\\015\\012      <Components isList="true" count="2">\\015\\012        <PageHeaderBand1 Ref="3" type="PageHeaderBand" isKey="true">\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>0,0.4,19,3.2</ClientRectangle>\\015\\012          <Components isList="true" count="2">\\015\\012            <Image1 Ref="4" type="Image" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>0,0,11.8,2.8</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Guid>d4618a2ea202466e9f00d982451b0609</Guid>\\015\\012              <Image>/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAMCAgMCAgMDAwMEAwMEBQgFBQQEBQoHBwYIDAoMDAsKCwsNDhIQDQ4RDgsLEBYQERMUFRUVDA8XGBYUGBIUFRT/2wBDAQMEBAUEBQkFBQkUDQsNFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBT/wAARCABgAbUDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD9U6KKKACkpaTNAEIDA8BRT9+3qc1zviXx94e8Hx+ZrOr2lkCOFllAZv8AgNecX37V3gGzk2RX95eH+9bWjkf+PYrspYPEYj+FBv5HmV8zwWG92tWjE9p37uhxTCGY8gGvGLH9rHwDeP5ct/e2f+1c2jgf+O5r0jw14+8PeMY/M0bV7S+AHKxSgsv/AAGirg8Rh/4sGvkFDM8FiXy0asZfM6WlpM0tcZ6YUUUUAFFFFABRRRQAUUUUAFFFFABRRSUALRSUtABRRSUALRSZooAWiikoAWikpaACiiigAopKNw6Z5oAWiikoAWikooAWikzS0AFFFFABRRRQAUUUUAFFJRmgBaKKKACikpaACiiigAopKGYBSfSgCneX1vp9tJcXMqQwRruaR22qq/Wvkv4t/tTXurXE+meDXazs1+RtU2/vJP8Ac/ur71X/AGnvjFL4g1mbwnpU/l6TZtsvXX/l4m/uf7qf+h49K5n4I/Aq6+Kl4Ly9eWz8OwNtlmU4e4buif8AxdfdZblmHwmH+v4/boj8rzjOsXmGL/s3K/8AwI870/S9Z8ZatItna3uuanL87lVeZ/8Agb16RpP7LPxA1KFZWsLXTt3VLq6Xf/45vr7J8MeD9G8H6WljpFhBYWsf8MSYzx1Y/wARrl/Gvxs8H+FLW8huPENmmpJE+yGI+a6vtyOForcR4urLkwVLQVLhDBUI8+ZVrv8A8BPl3VP2WfiBp0TSrYWuo7eiWt0u/wD8f2V5zqGl614N1eNby1vdC1OL503I8L/8Aevr74N/tD6B4n8F6EPEXiOzXxNLDm7SVfs6793/AHx6dK9P8TeFdH8daO9lqlnb6jZSrld4B/4ErVNHiTEw5VjaV4S8iq/COCq839n1rTj/ANvHzN8Jf2pr3TbiDTfGL/bLNvkXVEX95H/v/wB5fevrGzvoNQtY7i2lSaCRdyyI25WX618O/G74G3XwrvDeWTNeeHZ22xSv9+3f+4//AMXXUfsv/GCXQdYh8J6rOZNMvWxZM3/LCX+5/uv/AOh59avMssw+Lw/1/L9uqFk+dYvL8V/Zuaf+BH2MtfJX7TGofGjwtfa7rmm61/Zvge3aHyvscsKzLv2J/c3/AHzX1ov3RXjP7X//ACQLxF/v2/8A6PSvz2t8B+rx3OL/AGJfFGteKvD3iq51vWL7V7hL6IJJeTNMUHl9Bn8K+mvWvkr9hfUrXQ/h/wCLr2/uoLOzTUULTXEoRF/cj1r3Ox+PXw71DU0sbbxlo8l27bET7UvzH/e6VFKX7uIT+I9DpaYkgkQMtMmmS3haWV1SNBuZm/hrqIJqSvObz9oD4c6defZbnxno8c6tsKi5D/8Ajw4rttJ1ay1zT47ywu4Ly0lHyTW8odG/4EKz5ogXvwprbvTNHCqctXIeIPil4S8K3Bt9T8QafZz/APPGW5QOP+A5zW0Kcqvuwjc561alRjzVZcp2P4Uh+lc34Z+IPh/xgWXSNYs9RdPvrBMCw/4DW5dXkFjC008yRRKMs8j7VWm4ThLkktRxrU5w54y0LK59KG+ma8+k+N3gS1ufIbxPpqye9wP/AELpXY6Rrllrlmt3Y3cN5bP92W3kDqfxFVOjVhrOJnSxdCtLlpT5i+cY54FHG3jkVnapr2naLGGv723tV/6eJVQfqaoeH/HXh/xObsaTq1rfm1OJ/s8wfZ+VT7OfLzqJbr0VLkc/eN9QW6rilPpjNcPefGnwPp999juPE2nRXWdvltcjNdfZ30N9bpcQSrNDIu5ZI23Kwqp06sNZxsKliKNZ8sJ8xaXJxkUjfSo3kSGMuzbVX1ridU+NHgfSbhoLrxNpyTL95EuQ5H/fNKnTq1fgjcdXEUaP8Waid5ijFYHh7xtofjCF5dH1a11JE+8bWZX2/lVab4keFrVmSTxHpKMv3lkvogf/AEKj2VXm5eUPrFHl5+fQ6fn0xRVK01O1vLGO8guIp7N03pNHIGRl/vbqwn+KHhGP73ibR/8AwPi/+KqY05y+GI5VqVP45GP8XrTxpeeHYY/A9xFbal9ozK0hUDytj5+93zsr5ZsfG3j22+K2k6Fr/iO/luYNVhguYEuP3ZG9P7lfbsVwl5AskLq8Mi7o5EOVZa+IvEYI/agYHlv+Eghz/wB9pX1uRuE4VqU4R92L9T4DiinKjOjiKc5e9OP2vdPuZlLA1HvG4oDkgVR1jXNP0OFXv7+3sEYbVa4mVN3t81fI3w5+KWqa18eoLrXPET/2XDLc7Fln8q2VNj7P9g14mEwNXFwqVILSCufT47N6OAqUaU95ysfZoGBxzSY3dRiudsviB4c1K6itbbXNOuLmU7Uhhu0dm/AGtq6uobOFpZ5kiiUZZ3faq157hOLtJHsxrU5rnjPQsL9KU5HQVwS/GzwL9s+y/wDCT6b527b/AMfI25/3un6120NxFcQrLE6ujfMrKetE6VWn8cbE0sRRrfwp8xYpOaxdW8X6L4fjZtR1WzsQvX7TcIn8zUWmeM9D1rRX1Wz1O0n01Nwa7jmBi+Xr81L2U+Xm5Q9vS5uVzN5c+lKWPauFs/jR4HvNQjsoPE2nSXTttSMXK5Y13G4SKCDxTnSnT+ONgo4ilW/hS5h34UjbvrSY2qctXGa18WfB/h24MGo+ItNtrhfvRNcoWX8KUKU6vuwjcK1alRjzVZcp2XfnFLznjFcxpHxH8M69Y3F5Ya9p9xbW6b5ZI7hCIl/2/wC7+NRf8LS8Hj/matHP/b9F/jV+xq7chH1rD25ueP3nXUtc9Y+NtA1Cxub+11exuLO14nuIblHjj/3mBwKo/wDC0vB3/Q06P/4Hxf41Psan8o/rFD+c6/bSVT0vVrTWbOO8sLmK7tpRlJoXDK35VdbrUWOiMlLVDqKSikUR+/tXFfFzxYPAfw/1rV1I+0pFttwe8rfKn6kV2i/eA9q+fv2ytQaHwJpNmo+W5v8ALf8AAI3NejluH+sYulRl1Z4+cYmWEwFWtHpE+XfCPhu58ceLbDRoXd7m/uNsk/8Ac/vvX6H+HdAsvCuhWWlWEQgs7SLyo4x2FfJP7IGjJqHxGvrySPK2VixX2dn2j/x0NX0J8cPGUXhX4Z+Ip4L2FNQW3MMSeYodXf5B/wChV9RxFUlicbDBx2X/ALcfEcJ4eOEy+rmU93/6TE+fvj98frzxHqlz4e8PXTWujW7+TPcQPsa5b+IB/wC5/wCh15H4d+HniHxfa3E+jaTPeW0av5lyq7IV/wCBvT/hz4ag8ZeM9J0aa5W3tp5c3EofZthT53FfeFxN4f0Lwbe6dp13YW0EFlIkcUMyYQbDgAZrtx2Oo5HRhhsND3zycty3E8SYmeMxk/cPgKx+H/iG18Eadr0ukTvo1xD5iXiLvTZ/t/3K774M/HPVPhjqUNrcSy3vhx2xNZu+8xD+/D/8RX0d+znqOlr8B/B8F1eWuRY7WilmT++9fM/x98G6X4J8fzRaRLbjTL6L7TbpDKjJF/fSsMozClmlGOBxUPsm2eZPiMlr/wBp4Of2v6/7dPtvVdP0vx94TmtJfLu9L1K36ryHRx8rCvz38YeGrrwL4u1DSJHdLnT7jYk/9/8AuPX1f+yj40h1P4a/2bdXsQn0+7e2iV5V37GIdP8A0OvKf2v9HWy+JNjeqn/H7Yru92WTb/VKzyOcsHj6uAb91nVxLCOY5XSzKC99f1+Z9N/CPxgPH3gDR9WYj7RJEBPj/nqvyv8AqDXHftff8kC8Rf79v/6PSuf/AGNtQaXwNqlo/S1vyB9GRDW9+2B/yQHxD/v23/o5K+PzXD/V8RVox6H32SYqWLwVGtM+V/2dP2d1+NtjqFxf65cWGjafcIjWlsu95n2f7fypXoPxv/Yz0fwl4Gvde8K319NNpsXnXFneOkgmhTl9nyffrpv2A/8AkSvE3/YRT/0UK9u+N2vWvhn4T+LL69dEj/s6aFN38TuhRF/77YV4cacPZcx70pS5zwP9hz4qX2tQ6j4M1O4a6Wxg+06c8j72WESbWQ/Ten51xf7TXxY1X4m/E0/DzR9QTTtCt7xLKZ2l8uO4m/jeZ/7if+yVP+wV4dnufHmu60U/0Wz0/wCyh/8Apo7of/QEryNfDNnqPx5uNC8Uyy2dnca3NbXUyyeW675n+f5/+AVjzz9lGJX2z6Oj/Zm+CkPhkWUnim1/tXyudUOrxA7/AO/s37Nmf4K81/ZH8a6h4G+Mn/CJNe/atJ1J5rZkjffD5yF9kqfXZ/4/Xs6fsF/D3vf64/8A28Rf/G6674d/sreCfhl4hg1zT4769v4E2wm/uPMWH/bRdvD1t7OXPH3TPmOH/ai+Mt/pd+PB+gzvazsqteXMX3/n+5Enuak8Ffsg6RcaHDP4lvrxtWnXe8Nq6JHH/scJ83415L8XZX0n4/alcX6gwxalDM5b/nj8j/8AoFfc9rLDdQiaKRXSRQyuvda/QsZUnluCw8cN7vOrt/cfl+XUIZ1mGKq473uT3YxPLPhV+z3pPwr8QXmrwahPfzyxeTALhVU26fxcj71eD+OPF2sftBfFK28NWF28GhtO8MEIHyFE+/M4/j+lfZeqRmfTbqGNgsksTIp+q18Nfs5X0fh/40aTFfnyJG82zO/+GXY6Ef8AfVaZVUliFicbW96rCPujzyjTwzwmX0fcpTl734H0Kn7J3gJdLFqbW6efZ/x+G6fzN357f0r580vVtY/Zy+LFzp4unnsYpo1uof4Lq3Y/f2f3wtfdy4+lfDP7R8y+JPjZf2dh+/n/ANGstifxzf3P/H6eR4ipjKtSjipc0OV7kcR4OhltCjiMHHllGS+E9u+PXwT0rxxaX3jCTULpZrXTHeKGNl8ltiO6np7187/BvwJrPxI1S/0LTtXfSbCSJZr8Bn+ddxKfJ/F96vszxxZ/2Z8IdZtPvtBossX12wkV87/sY/8AI569/wBeCf8AoZq8BjKkcurPm+C3Kc+bZfRnnGGjy/xfiNvxl+yVoeg+CdRvtN1S9fUrK3e43TbDFJsUttKbOnFUv2OfFl3Jq2q+G5pHexFv9st1f/lk2/a4X2ywr6P8ett8D+ID3FhOf/HGr5X/AGNY/wDi4mqP/wBQz/2dKxoYqtj8sxDxEublOvFYOhluc4VYSPLzHX/tieL9V02z0bRLaSS0sr5ZJrl4zt83YUOyofhN8C/hr4t8F2dxNc/2tqk8SPcbL3a8D4+5tQ8bOld58XNb8AeKNas/AviXz5dUuJE+ztDE+6CRvuOH7V5Z4m/Y71jSWe88Na8tw6fOkd0nlS/9/EqsLiKcMDChKcqM979JGeYYWtLMauLjTjiIfDy/ym3+zn8NPEfgT4keIlvtMmttJa2a3ivGKbZdk37vp/sV5v8AtHfCrRvhrr2m/wBmNO/9oLNNL9off8+//wCzruP2Yfizr2peKZPCus3MupWzwNJBPctvmjdCMoWHVcVF+2ou3XvDPvBMf/H0rswzxVPOVCvvI8vEU8JW4e9rhvsy+19n3j2/4RWMdx8G/DVq4KrNpkatt7bk/wDr18l/H74YaR8MPE1jpukGd4J7PzW+0SeY5bc65/Wvrz4Juk3wo8LMrbkNhDg/8BFfOf7Z2P8AhPtJxz/xLf8A2d64snqShms4/wCI9fiCjTnklGty+9HlPqP4brt+HfhxfTTbf/0UtfH2vf8AJ0g/7GOH/wBDSvsH4f8A/Ig+Hv8AsH2//oC18faz8/7Unzf9DFDj/vtKjJf42J/wSNOI9cLg/wDFE+o/in8IdK+LFjYw6pPc262btKn2VkByw/2lNfGvwo8A2Pj74kW3h2+knis5fO+aIoH+RK/QaRtsTjHbFfEH7NDbvjlZP/s3Y/8AHXrTJMRUhg8T73wx938TLiTB0KmY4Pmj8cve/wDJT3nwn+yt4W8I+JrDWrS/1KW5spfOjWaRCm/1+5WF8XvhT48+KXjuGxl1OG08HbN4aP7seP76fxv/AOO19C5UKSW5x1r5P8ffHjxX448df8Ir4Cc2cfnvapcR7fNnZPvvub7ifrXn5fWx+NxHtVL4Y/FL7J62aUcsy/CqjOHuyl8MftFj4m/sr6F4U8DX2p6Pf3s99Yw+cy3ToySqgy4+58vf8q0v2OfFl5fabrHh+4laa2sjHLa7x/q0blk/A1i+L/gv8SNL8Harqmr+Pp7mGC1kmuLNZ5WSVAh3pSfsWp/xUHiVv+nWH/0KSvbqt1sqrOpV9pys+aoL6tnmHVKh7JSHftI/BHTNBsdX8aR3t1NeXV4kjQMU8tS7jNcf8GPg1qfxe0iVJtcmsfDVncbPs0fzBph9/av3P+B173+1kB/wqC5x/wA/tv8A+hisf9jP/kn+r/8AYTf/ANASsaOOrU8n9qpe8pHRiMtw1TiL6u4+7KPMeb/HH9nPSfh54Q/tvR7u6mEUixTxXbrIHRjgsvHBr1P9k/xhfeIvANzZ30rXUul3P2aKVx85i2BkU/QVsftSr/xZjVv+utv/AOjkrj/2Lxjwrr56Fr1f0QVjUryxmSSnW96UZHXSw1PL+IY0cP7sZQMD9pj4wanceIR4K8PTSwrHtS9ktm+eR3+5CPrWv4V/Y90T+xoX12/vG1WVRJL9kdERG/uj5Pm/GvHvE10mg/tG3V1qZ2QQeIEmkL/3PO3/APoFfdqTKy7lO9MZzWeOq1stwtGlhPd5ldvuTldClnWNxNbHPm5JcsY/ynjngn9mPQ/CNjr1tcXtzqKavB9jkZ/3bJDj7gKfzr5u+PHwrg+Ffi+O1sUlfSbuLzoPObc+f403/wCfv199MyNgE814x+1F4H/4Sr4dS3tvEHvtIf7WnrsH+tX/AL4y3/ABWGV5tXjjU60/j0O3PMiwzy6f1aHvQJ/hr8KvCFx8MLi001Ln+yfEluk04a43uQUHy76+afCfw00z4gfGSbQNJSRfDsM775g+9jbp/Hv/ANv/ANnrqfhz8bD4X+BniLRWn2albv5Nh/f2S/ex/ufO9epfsl/D3/hHvBk2v3cWy81dx5W7qluvCH/gf3/xWvTbrZTHE1Zy3fLH/wCS+48KnHDZ3VwWHpR+CPNL/wCR/wDAj17wd4PsfA/h6x0XTVZLK0VlhWVt7csW69+Sa6D3opc18JKUpy5pH6tCEaUeWI6iiikaEI4YfSvnn9s60aTwXoV0v3YdQ2N/wON//ia+h26n6V518ePCLeMfhfrVjBGGuok+026+rp83/wAV+delltaNHG0qku54mdUJYnL61KP8p4F+xtqSQeOtZsnf57iwDr/wCT/7OvTf2jfgz4Y8R+E/EniQaDbz+JhbrKL47vM2ps9P9hP0r5c+GHjBvAPjjSdby4ht5dlwv96J/kY1+hVvNa6zYLKjpdWd1EHVh8yMrCvoOIqXscdDEyjzQdv/ACU+Q4TxH1jLJ4KEuWcf/bj84vhzp3ha08ZaU/iDTLa+0dpdl1HPv8va/wAm/wD4B9+vsLWP2a/hZH4fvruDwdp6utrI0TK0n9w/7dfOvxu+Dt98Ltfmmghabw5dvvtbkf8ALH/pi9QeEP2gPFfg3QJdGWWLU9MaJ4UhvCW8pNn8L967czyihmlKGLwKjtseXk+eV8mxE8Bmal/X/tp7N8B/2ffh34s+EPhfV9X8K2d7qN3ab5rmR33u29/9uvC/j54d8FaZ48m0vwro1pYWdlEYbgWrPsaXPzfp8lGg/HzxXp/wz0fwxps0el2dnbeQLm1B+0Om/wDvdF/4BVD4c/DnV/iZ4iTTdNifyN++7vH+5br/AH3/ANus8lyWnhaf1zGcvLynRn+f1MdUWW5dzc3Me2/sr/BLwvrHhdPEWr6Fb3Oopf8Am2V2+7egTb/7OHrG/bI1FZvH2j2qN89vYb2+ju4/9kr6j0fS9O8AeFreztylrpunW/3nP3VQfMzH9a+BPib4ybx5461bXPm8m4l2W6uMbYk+RDUZHRjiszniaUeWCNOJKssHlFLAVZc05H0p+xjZtH4L126b7suobF/4BGn/AMVXYftLeDNc8ffCrUNF8O2qXuozTwv5TyogKo4c8vx2FafwH8It4M+F+i2MybLqaP7ROv8A00f5jXoi9vpXy2aVY4nF1p92fb5Lh5YbL6NGf8p8O+B/gd8efhRYpqHhS4t4HvU8y70z7RC+x/8AbR/k3/7laGtfBD46fGy+tYvG+pWml6XC+/y2lTYn+2kMP33/AN+vtaivG+rxPe5jjPhf8M9H+E/hO20LRkIhj+eWd/8AWTyn7zv7mvH/ANob9k9fidqTeIvDt1Fp+usuLiC4B8m6/wBr/Zf3r6SxRWsqcZR5A5j4r0rwb+07oNrHpVreyfZY12JJJfW021f99/nr0b4K/BP4k6H45g8W+N/GL6hKkLw/YDM9xnd9fkT/AIBX0fkUm2so0IoOY8W+OfwBg+J4j1LTJksNet02eZImUnT+4/8A8VXleg+BPj14NsxpWlzlLNV2Rn7VDIqj/Y3/AHa+vDjvUbAk8D9a+kw+b16FL2MoxnD+8fK4rh/C4qv9ZjOUJf3Zcp4R8J/hb4+0vxgmv+L/ABM16gheL7B5jyDLc+yr+FZnxn/Zjm8S6zL4h8KXUdnqEr+bcWkzFUd/76P/AAP719FyfL/Fj60bjsGGrOnmWJp11iKej/A1nkmEqYX6pU97z+0fMC2v7RC6f/Zm638vZs+2PLb+d/31XQ/Bv9nD/hD9WTxD4mul1PXFbfEijcsTf3938T+9e+FRgcZ5pz/OMdPpWlTNqtSMoQhGHNvyoxo5Bh6dSFWtOVRw+HmlseOfHDwz8RPEyw2XhC7tY9KntpIbyKdkQtv47qf4c15B4R+Bfxf8B3M91oEun2M8w2O4nSTcv/A0r7FHyjmg89qMPm1XDUfYRhHl/wAJWKyDD4vELFTnLm/xHi3xZ8O/EvXtF0my8NXNsiy2kkWqCR0Tc7KgyPl/3/zryDwj8B/i54DvprzQZdPsLmWPyXfz1k3L/wADSvsfNGT9aeHzarh6LoQhHlf90nFcP4fFYhYmdWXMv7x83fHb4J+LvGXiTR/EOgG3kvbe1iSX9+YXEqPv3oazGtf2iNUsX06R7e2Rk2Ncb7dZB/wJK+oc4IHT2zRsUBsjjvRTzirCnClKEZcm3NEirw/RnVnVhVnDn+LlkeKfAn4At8L5Z9Y1S5ju9bmj8lfKGEhT0/2m963/AI3fCGH4r+HYY0mWz1SzbzLa4b7o/vKw7oRXqPXpScHrXHLMMRPEfW3L3z045ThYYP6jGPuHx94e+Gfxx8J276LpE/2PT93Dx3UUkKj/AGN/zpUHjH9lXxq1nbagmoL4m1meUfbVkmCbf9ve/wB+vsRuGUbsD0pRkSH5s+1ess+xMJ+0hGKf+Hc8N8LYOdL2M5zkv8XwnzP4e8J/HXTfD89tHqlnavHFFDaQvJE4RUODzs/u1xTfs9/FabxKPEDNp41nz/tP2j7Sv+t/v/6uvs8cdsUc55AAqKeeV6MpzhCHvf3S6vDOHrQhCdWfu/3jzv4S2Hjez0G8Tx1dQ3moNOfJkhCf6raP7iivn7Xf2c/H3g7xo+q+DmW5hWR5LS5huEili3/wOr9RX2C4B2jafwNO3KylV5Irkw+aVsNVnUhCPv7xt7p2YrIsPjKNOjVlK8Phlze8fOXhPwX8btS8SadeeI9djttNt50muLbzk/fJ/Gm2JMVy/jH9mvxn4X8ZNrngmZJojcSXMGyVIpbff1T5/vivrTbhcD5hSqvGOnsa3hnOIp1XUhCP+Hl90xqcOYWtS9nUnKT/AJub3j5ck+EPxf8AiVB5Xi7xKNMsMYe2Uoxf/gMXyVzPg34Q/GTwHe3jaBFb6a9wdkszTxSqyJ9zhq+yGzjgD3zSqvy471cc9xEIShyR5H9nl0MZcMYWUo1faT519rm94+bfi58N/iv48unsY7qxn0Dbbt5Lyop81FQu33P7++sz4W/Cv4ueAdRs7a3urGz0M3qTXsKSoxZMoHx8n90V9T5NHNRHOK0cP9W5I8v+E2lw7h5Yr657WfP/AIj53+OXgP4n+PtYu9O0uazfwpKkTrDPKiYdOeyF/vVh/CP4T/Ff4e6xZQpcWNt4flu1mv4UlRi6/wAePkr6iP3M8ZxSj7oPGaiGb1YYb6qoR5f8Jcsgw8sX9c9pLn/xf1oeG/HL9npfiRdf2xpE8Vnrap5ciS5MVwv8O/8Aut7153ofg34/eG7MaTp90yWUfyR7rq3dVT/Zd/nr62Yk4OKYT83ynPtmlQzfEUaXsZQjOP8AeV7BiOH8LWrvERnKEpfyy5TxL4Q/C7xxofiKfXfFviWTUmmgMX2FpHk75zuPyp/wAV7TcQpPayRyqpRlIYN021Ox2qSTwK+Uvj5+0R/an2nwp4Teb5me1vb6NdrN/AYofepo0q+bYjT/AIESsTXwmQ4J8+v/AKVI8s8O/Dm18bfF6fw5o87XOix3rk3Mf8Fsj/5SvvSw0+HTbOG0gjEcESqiIvZVryj9nT4Sn4b+GJLzUovL13Ugsk6f88E/hiH0r2IchfmroznHvF1VCMrxhocnDeVrA0PbThyznr/h/uktLRRXz59iFFFFABTWUMpGOop1JQB8J/tEfCib4eeKn1CziP8AYepM7xOv3Yn/AI4f/iK6b9nv4/L4RWHwz4jmP9k7sWt45/49/wDYb/Z/9B719UeJvDOn+MNFuNI1WBbqzuFKvG4zn3r4s+Ln7P8Arnw4uprm1il1bQP4LyFfni/67J/7PX6BgMbhs1w31LG/H0Z+Q5rluLyLF/2lly9zqv6+yfbd1Fp/iLTWjlSG/sJ0xtYK8bqfbuK8U8afsm+ENStLy501bzS5/Kd1itZdyM2z+4+a+bPAvxe8U/Dv5dF1V/sf/Pnc/vof++P4P+AV69pX7ampRrs1LwzbzP8A3ra6ZB/4+lcc8lzPBy/2OV/Q74cR5NmUYvHw5Zlj4L/sr6JqXgXQtU8RRaml/PD5k+mzyGJYG3H5MY3frX0fpGi6L4H0b7PYW1rpOm267zsARV9WavmfVP20NUkj2ad4at4ZO73N07j/AMdRa8i8dfF/xT8RMrrWqN9i/wCfOH9zD/3x/H/wOnSyTM8Uo0sTLlhHuFbiLJcBKVXBQ55y/r4j0v8AaG/aAHjBZvDXh2V/7G3YuryM/wDH1/sJ/s/+hfzwP2dvhRN8QPFSaleRZ0PTWR5Wb7ssv8MX/wAXVb4Sfs+a58R7qG5uopdJ0D+O8mX55f8Arin/ALPX2t4Z8M6d4P0WDStKgS1srdQscaDpXZmGOw2V4b6hgvi6s48qy3F51i/7RzH4Oi/r7JtqoVQB2paSlr8+P1sKKKKACiiigAooooAKSlooASjHtS0UAJRS0UAIKKz9a0saxpdzZtc3Nn56bPOspfKmT/cfsa8PtvAtzN8Y9Q8MN4y8XHS7fQ4dQX/icPv8153T7/8AwCs5SA9/z7UbvavEYvjJf+FdU0PRNbs9IMdxeQaSEtvECXd9HI3yI8ybE3f7Va8PxkvLjVvEKnwzImhaBfTW2oaw97GqKkSby6J9526fJ+tHtIlcp6vkelG72rxhfjN4lisdD1a+8GR2Wh6zf21pbSPqf+lIsz7Ud4fLx3+5vqLV/j40MmtXGl6dpV3p2jyTQz/bdZS2urh4v9cIYth6f7ZTdS9pEfKe2cUvFeGeGviR4o8RfFjUE0qyg1Dw3Npmn3lus175Rihl3/viuz77/wBz/YpNB+LU+l+HPDsWl6LqOvXet6rfWcUN/qZd0eF5P+Wrp9z5D/uVPtYhynue2jb715F/wvGbRrHxPH4j0P7DreitbItlp9x9pW6Nx/qNjlE++/yfWrul/EjxND408P6B4j8MWmlvrCXLwz2eqfadnlJv2svlp2Nac8SeU9R4oryr9oLxHeeFfAttf2N3d2rpq1irNZ/6x089N6f7W5Miua+IXxiXU5PCllo0XiDSJ7nxDYQzT3WmXNmjwvJ88e90/jGPlolLlHynvPFHy14xb/FSPw+viMWmn6lqusS+Jn0ay0+4vtwlm8tH+Rm4hi2fPTPEfxE8QzWvinw3rmhW+i6hH4Yu9TivbDUTOhxlB/AjpzS5ohyntdArxHwR8TvEOk6T4Bj1rw2INH1iK20+DUf7R8+5854d6O6bPuvs/v11vx61W90T4P8Aiu/0+7lsr23sXkhuIW2uj+tHN7tyT0Dijivmu18aWXhPxR4Zm8N+OtQ8UQTK82vafdX/APaUNvZpC7vPvH+pdHA/366Sz/aCdW0a9vrHTIdE1e5ht4jb6ust9b+cdsTzQBMd037X+T3qPaxK5T3GivF5Pi74n1rTvFEmieEM2+j3N9ZNqVzqCpHvh3/OibNz1ynwx8Q6n4P8N+G5v7Fm1fxh4ujSS3efXJZkul8sTTXEu8bIdu/7iJR7UOU+kuKOK8b1P46XXhjSPFX9t+HfsuvaBBDdPp9rdmWK7ilfYjwvsz9/1TtVzV/ip4g0P+xorjwRIl9rGoNY2Vm2pw79ghL73P3UPy/czWnNEOU9Y20ba8YX4v8Ai24bxFYxeCLd9a8P/PqC/wBqj7MEZPMj8l/L3uzJ6olaurfFy9/4R/w/rej2Ojx6XqtnHd+dr+srYBN4BCfcfc2KOaIuU9Rb5uCK5KT4Y+GZPEyeIG0W0/thel55Q37v73+9/tda4W1/aAbVvD/hPUNI8Oyahe6/e3Nh9iW+RVilhRy/73G10/dn5qtH43TaHZ+Kx4n0P+ztV0L7Mfsen3H2lbv7SQkIRyifMX+SqjX5PgkZTw8a3xxPX8CivK734neIfCOj32reL/DFvpmmQwh45LHUkuH855FSOBlZE+di/wB/7tQeHvjRPceLNI0PV7PSoX1dXNrNpGrLfbHRN5SUbE2/J/F3qOaJoeuUUUVoAUUUUAFFFFACUxlEg5HFSUUC33PJvGH7OHgvxhLJcPp39n3bj5rjT2MJb/gP3f0rze8/Yrtnb/RfFM8Kf3JbVZP/AGavp7PvQ2O4r1aOb43DR5IVWfPYjh/LcVLnq0tT5hs/2K7ZG/0rxTPMn9yK1WP/ANmr0jwh+zf4K8HzR3Cab9vu1Hy3GoMZiv8AwH7v6V6suO1G73orZvjcTHknVY8Pw/luFlz0qQiqIxwOKfS0V5R9BtogooooGFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFcBP8P7q4+JWteIRerDa3+hppKpEP3sTiR33/8Aj9d/RQB87aN8DfFVp4f8OaGy+F7Sy0TVLO9a+tYZftWoJC+8s/8Acd/+B13+l/DX7PovxB0/VrlZrDxLf3V1i2yHihlhSP8A76+SvSNtG2s/ZxL5mfKEfiLUfFY8EeFrDxZpHiqDTtZsHRdN0+ZLnybd9/nXO/5IdiJ/wOvQovhHrvhbUtVGiaf4S1rTr27mvIW1y3kFzavM+903Ij703/7le2JGqfdXFPqPZBzHlVv4G8U6J48j1/SZtGuI7zTbTTtRgmR4PL8l3O+AqG/56P8AK351n+Hfg5qOi/8ACFebqNqx0LVb/UJdm794lx521E/7+V7Huo3VfJEnmPEviV8M0uJ/G/iDUtai0eyuodNmtb1IXmezms3dw7p/Gu9+lc94O8Rav8Q/jB4SvW1rSfEFrpFrePcTaFazLbW5kRETdM/3nf8Auf7FfR+RTI0SP7q7anlK5jivix4KuvHfhu2sLO4itp4dRtL0yTcrshnSRh/47TviV4NuvG1noEVpcQwNp+uWepv5ozvSF97IP9qu3oquUg+f/Gnw/wD+EV03WNe1DxDaaJdJ4p/tzTb6eJ5YYfMjSHyZVH8L/P09ayfDSav8VvGnie6Gq6ZqcM3habSU1DTLaZbOKaZ/lTe/3+Pnb8K+k/v0LH5abVqPZF8x5vqHw2v73wz8PtOS6gSfw5e2NzcP82yVYYtj7Prnitz4qeE7jx18PNe0C0uIrW41C2eBJphlVz3rr6K05SDmpPBOmXHhO80NrW3toL6zezuPssSpuDpsevOPC/wz8U+G/wCzNNNh4Lu7WykjU6w1m6XksKcA+Xs2ebs/j317ZRS5QPOPCvw9vNC8JeL9Jmubd7jWNR1K8iZd21FuXcpv/OsaT4U63pugfD+bSL2z/wCEj8I2f2XFyH+y3SPEscyZ+8v3PkbtXsFFHLEDwvXvg74k8b6b4svtavtNtfEGs2ltp9vDah2trS2hm877333Z3Ln8q77xp4NuvEviXwZqFtPDDFot9JdSq4+Z1aF4/l/77rtN1G6nyxHzHn1l8Pr21174g37XUBTxIsKW6Yb91stvJ+euG074L+JPDWo+G76zj8P67NYaBbaNKmsK5S3eHrNDhP4/+AV71xRxS5Yj5jxbwn8FdY0SHwd9q1CwluNF1i/1O48iNkSVLnzvkRP4P9Z+lXPGnwZuvF2t+MLltRjtF1a3sPsLom57e5tnd0d/Vd2zj2r13bRto9nEfMzyPXPAfjT4jeHb/QvFVxoVlayRI0M2mpNM/wBpR0dHdH+TZ8n3PernhXwj4n0/W7SbUdI8G6fbwBhJdaPayfaZTt4KblGzn3evUqKOUgKKKK0AKKKKAP/Z</Image>\\015\\012              <Name>Image1</Name>\\015\\012              <Page isRef="2" />\\015\\012              <Parent isRef="3" />\\015\\012            </Image1>\\015\\012            <TextVersion Ref="5" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>16.4,0,2.4,0.6</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,8</Font>\\015\\012              <HorAlignment>Right</HorAlignment>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>TextVersion</Name>\\015\\012              <Page isRef="2" />\\015\\012              <Parent isRef="3" />\\015\\012              <Text>Version: 0.1</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <Type>Expression</Type>\\015\\012            </TextVersion>\\015\\012          </Components>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Name>PageHeaderBand1</Name>\\015\\012          <Page isRef="2" />\\015\\012          <Parent isRef="2" />\\015\\012        </PageHeaderBand1>\\015\\012        <DataBand1 Ref="6" type="DataBand" isKey="true">\\015\\012          <Brush>Transparent</Brush>\\015\\012          <CanBreak>True</CanBreak>\\015\\012          <ClientRectangle>0,4.4,19,4</ClientRectangle>\\015\\012          <Components isList="true" count="1">\\015\\012            <TextContent Ref="7" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <CanBreak>True</CanBreak>\\015\\012              <CanGrow>True</CanGrow>\\015\\012              <ClientRectangle>0,0,18.6,3.8</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,8</Font>\\015\\012              <Guid>2aadb8b5addd4e31b8b69efa105a7b28</Guid>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>TextContent</Name>\\015\\012              <Page isRef="2" />\\015\\012              <Parent isRef="6" />\\015\\012              <Text>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin et nunc ac felis iaculis vulputate fringilla sed leo. Praesent finibus pharetra urna id convallis. Phasellus leo augue, placerat vel ligula et, scelerisque vehicula tortor. Nulla laoreet ullamcorper turpis at egestas. Integer rhoncus odio ac bibendum rhoncus. Duis in nunc turpis. Sed ante purus, facilisis pharetra pretium eget, iaculis ac felis. Suspendisse potenti.\\015\\012\\015\\012Fusce lorem libero, consectetur sit amet viverra volutpat, malesuada non leo. Mauris aliquam varius ipsum, non fermentum nulla fringilla et. Nam in dignissim nibh. Praesent ut efficitur quam, ac rutrum arcu. Integer porttitor pulvinar massa id mollis. In ligula sapien, interdum ac posuere non, varius nec purus. Vivamus consectetur dolor ac scelerisque tincidunt. Ut ornare, purus vel congue vestibulum, metus nulla finibus ante, in dapibus nisl felis sagittis lacus. Aliquam blandit ex eu gravida suscipit. Vivamus lobortis nunc quis urna dapibus, in scelerisque nisi feugiat. Nullam quis dui vitae purus suscipit pharetra vitae ac orci. Proin non fringilla nulla, at laoreet purus. Ut eget massa eget elit porta molestie. Ut dapibus, arcu ut cursus varius, orci odio hendrerit nisl, eget dignissim arcu urna a nulla. Nunc tempor dui vel ligula aliquam, nec mattis est rhoncus.\\015\\012\\015\\012Nullam metus nisl, porttitor ac tincidunt non, tristique ut risus. Etiam orci sapien, ullamcorper vitae finibus feugiat, tempor mollis ipsum. Etiam pretium ultricies molestie. Pellentesque volutpat orci non erat varius, at viverra arcu vehicula. Duis sed quam sed erat feugiat rutrum et vel sem. Morbi libero augue, placerat a volutpat id, ornare a leo. Sed sed arcu et quam gravida tristique condimentum finibus felis. Phasellus tempor, turpis quis eleifend gravida, mauris felis feugiat nulla, sed tristique justo purus in libero.\\015\\012\\015\\012Suspendisse laoreet nisl non rutrum lacinia. In hac habitasse platea dictumst. Sed auctor fringilla magna, ac tincidunt sapien tincidunt fringilla. Morbi leo purus, egestas eget ultricies in, vestibulum a mi. Vivamus vel cursus nisl, id laoreet neque. Nam porta mi nec dui fringilla hendrerit. Etiam molestie nulla a metus mattis, quis accumsan urna scelerisque. Ut sed ullamcorper dui.\\015\\012\\015\\012Cras pulvinar risus sed risus elementum, in cursus purus vestibulum. Mauris sodales vitae nunc vitae convallis. Mauris ullamcorper, ante efficitur sodales lacinia, enim felis vehicula ipsum, in egestas nulla ligula et mi. Ut vel velit posuere, volutpat nisi sed, sodales nulla. Aliquam scelerisque dui sed lectus molestie, id varius quam porta. Sed iaculis placerat nulla, ultricies dictum metus rhoncus venenatis. Vestibulum tristique lobortis enim quis consectetur. Praesent sit amet lorem in odio interdum varius eu eu sapien. Vivamus tempus hendrerit suscipit. Etiam tincidunt ullamcorper elit, vel pellentesque ante maximus non. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Aenean cursus viverra lorem vel vestibulum.\\015\\012\\015\\012Quisque eget interdum risus, sit amet hendrerit nisi. Donec quis libero id tortor feugiat condimentum. Nam lectus neque, commodo sit amet mauris et, rutrum ultricies purus. Etiam eleifend ante eu eleifend viverra. Donec non metus vel metus tempor laoreet eu vitae lacus. Pellentesque interdum ut tellus eu viverra. Vivamus ut velit quis magna malesuada blandit.\\015\\012\\015\\012Vivamus maximus libero nulla. Integer ac tincidunt neque, vel euismod nisl. Mauris facilisis risus enim, sed posuere ligula volutpat vel. In erat augue, maximus et interdum vitae, rutrum a diam. Curabitur placerat tortor eget dolor euismod, ac efficitur leo pharetra. Nam neque ante, volutpat in aliquam id, consequat at elit. Cras viverra lorem augue, suscipit suscipit orci imperdiet id. Proin ut leo non arcu ornare imperdiet. Suspendisse semper lectus at rhoncus convallis. Nam nunc leo, tristique venenatis risus at, congue convallis sapien. Suspendisse vestibulum arcu et tortor malesuada, accumsan ullamcorper lacus consequat.\\015\\012\\015\\012Vestibulum suscipit est enim. In cursus, sem sed congue luctus, justo sapien hendrerit neque, sit amet tincidunt mauris massa ac leo. Suspendisse accumsan risus nunc, a pharetra justo viverra ac. In mattis massa turpis, et ultricies metus feugiat non. Nullam quis lacus vitae nunc sollicitudin aliquam in vitae quam. Quisque quis gravida sapien, quis ultrices justo. Aenean maximus, tortor a consequat tristique, neque mi auctor mi, ac interdum mi massa et orci. Pellentesque congue, ligula quis porttitor aliquam, sem dolor eleifend augue, quis laoreet dui tortor eget nunc. Aliquam ornare eleifend justo, ut vestibulum massa varius ut. Aliquam tempus scelerisque mi, placerat laoreet dui mollis tempus. Nulla hendrerit tincidunt eros. Nulla in gravida enim, nec dignissim nulla. Donec sed vulputate ligula.\\015\\012\\015\\012Aliquam vitae iaculis odio. In hac habitasse platea dictumst. Maecenas varius quis sapien sed lobortis. Vivamus ac lacus eget turpis fermentum blandit. Nulla molestie dolor lectus, ac tristique mi rhoncus ut. Mauris egestas nunc vitae urna consectetur tristique. Etiam orci quam, efficitur a laoreet nec, sollicitudin vel odio. Quisque ac efficitur elit. Nam facilisis consequat pretium. Mauris ut tortor a sapien faucibus sodales laoreet non odio. Donec dictum lorem vitae sem rhoncus, a ullamcorper purus aliquam. Vestibulum laoreet libero non lacus rhoncus, sit amet egestas lacus tempus. Morbi varius viverra scelerisque. Aliquam aliquam laoreet purus, sit amet luctus metus pretium ut. Donec venenatis congue odio, nec aliquam tellus euismod eu.\\015\\012\\015\\012Proin interdum nisl non rhoncus bibendum. Nulla sit amet justo vitae sapien ultrices commodo. Vivamus varius nulla nec nisl cursus semper. Ut quis lacus in arcu iaculis commodo. Nulla mollis ultrices augue vel tincidunt. Vivamus vitae risus euismod est varius ornare. Cras laoreet porttitor ex. Nulla risus mauris, bibendum a ultrices sit amet, finibus maximus mi. Ut ac sapien condimentum, maximus velit consequat, commodo neque. Phasellus tempus sed eros eu interdum. Aliquam efficitur ultrices suscipit. In pulvinar ultricies eros quis pellentesque. Cras porta sem velit, nec hendrerit nisi blandit porttitor. Nam non volutpat erat.\\015\\012\\015\\012In egestas dictum nulla, pellentesque euismod nisl bibendum eget. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus et dolor eget turpis consequat accumsan. Praesent sit amet luctus ipsum. Proin ullamcorper erat non quam congue, eu ultricies velit mattis. Fusce faucibus orci in vestibulum accumsan. Duis est mi, dictum a lacus volutpat, dapibus suscipit sapien. Ut eget arcu non orci aliquet rutrum vel at justo. Maecenas ut velit in risus semper sagittis. Aliquam commodo odio id pretium faucibus.\\015\\012\\015\\012Cras viverra et velit vel rhoncus. Aliquam erat volutpat. Cras vestibulum elementum nisi, sit amet consectetur felis placerat vitae. Praesent et eros sodales urna rutrum volutpat. Etiam euismod magna tellus, nec fringilla elit interdum non. Nam eget arcu vehicula, elementum justo in, mollis metus. Proin dapibus varius eleifend. Proin ac vulputate risus. Nulla sed tristique neque. Aliquam vitae convallis mauris. In consectetur velit tellus, ac feugiat orci rutrum ut. Maecenas vel consequat elit. Aliquam molestie orci eu odio mattis tempus. Aliquam nec libero convallis urna convallis porttitor. Morbi consectetur ultricies nibh quis dictum. In ullamcorper ipsum sit amet enim tincidunt, at varius neque tempor.\\015\\012\\015\\012Sed pulvinar volutpat enim id laoreet. Ut rhoncus varius enim non sollicitudin. Cras vitae nibh malesuada, imperdiet turpis quis, efficitur erat. Ut congue, purus ut dictum cursus, diam sapien vulputate nulla, quis ullamcorper dolor sapien quis quam. Aliquam nec dui lobortis, tincidunt sapien in, porttitor ligula. Donec suscipit elit eu lectus tristique ornare. In eget risus magna. Donec non odio imperdiet, porta erat id, tempus felis. Mauris sagittis neque at feugiat vestibulum. Donec id ex neque. Morbi malesuada ante sapien, a faucibus diam pharetra ac. Aenean sed felis fringilla, suscipit risus vel, porta ipsum. Praesent in ipsum erat.\\015\\012\\015\\012Ut id pretium felis, nec pretium ligula. Praesent eleifend ullamcorper ante quis tempus. Morbi volutpat sapien nibh, a elementum nunc maximus ut. Pellentesque condimentum mauris quam, a feugiat turpis faucibus in. Nulla facilisi. In tincidunt nulla laoreet eros aliquam pellentesque. Cras euismod viverra quam vitae tempus. Mauris tristique nunc et lacus rhoncus, ac laoreet tortor convallis. Aliquam vulputate tincidunt sollicitudin. Morbi massa quam, ultrices ut leo a, consectetur ultricies nunc. Maecenas tempor erat faucibus rutrum sodales. Cras venenatis cursus dui id maximus. Mauris eget purus elementum, ullamcorper nisl eget, malesuada turpis. Ut risus urna, lacinia ac venenatis viverra, viverra sit amet justo. Integer vitae ligula eget turpis congue tristique eget non elit.\\015\\012\\015\\012Praesent non eros sit amet tellus dignissim consectetur vitae dapibus ex. Nullam aliquam accumsan pretium. Morbi commodo dictum fermentum. Suspendisse potenti. Sed ultrices eget lorem sit amet rutrum. Praesent vulputate risus a libero aliquam pulvinar. Pellentesque eget facilisis orci. Donec metus dui, commodo eget neque eget, euismod congue metus. In a accumsan arcu. Sed sit amet ante turpis. Nunc id volutpat massa, nec tristique turpis. Nulla eleifend venenatis ligula.\\015\\012\\015\\012Donec pellentesque elit et bibendum vehicula. Suspendisse mollis libero et elit lacinia rutrum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Praesent arcu ipsum, congue ac interdum ornare, dignissim sed orci. Nunc sed porttitor arcu. Proin id erat ut tellus euismod malesuada at nec orci. Phasellus eget neque lorem. Aenean et ex ultricies, consequat turpis sit amet, lacinia felis. Aliquam erat volutpat. Vestibulum et consequat magna, quis placerat orci. Suspendisse in varius nunc.\\015\\012\\015\\012Curabitur sapien diam, dictum eget massa a, molestie blandit enim. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nam aliquet, dui id vestibulum placerat, risus erat luctus dui, ac condimentum nunc sem quis elit. Vivamus consectetur elit a magna lobortis auctor. Nunc pulvinar et elit vitae dignissim. Curabitur pulvinar massa quis neque convallis posuere non vel nisl. Sed lacinia luctus erat, ut tempus orci venenatis eget. Phasellus congue pulvinar dolor vitae congue. Ut non elementum risus. Nulla facilisi. Nam imperdiet elit id tellus eleifend, nec vehicula felis dignissim. Maecenas quis tempus mi.\\015\\012\\015\\012In sollicitudin mi luctus, malesuada libero sit amet, efficitur lorem. Fusce imperdiet leo id lacinia mattis. Nullam ultrices placerat velit. Praesent non accumsan risus. Duis massa nulla, venenatis vel euismod quis, vehicula nec massa. Praesent scelerisque nunc nec laoreet pulvinar. Nunc congue, mi ut dignissim euismod, purus lorem varius ante, eget suscipit orci nibh a sapien.\\015\\012\\015\\012Sed auctor eleifend molestie. Cras sodales lectus sit amet bibendum facilisis. Sed ac nunc eget augue gravida volutpat. Donec vel faucibus odio, vel maximus ipsum. Duis efficitur blandit tortor, eu consequat turpis. Vivamus tincidunt vitae sapien non vehicula. Quisque aliquet massa ac mauris efficitur vehicula. Integer luctus orci non neque gravida ornare. Maecenas feugiat tempus placerat. In vitae dui magna. Cras feugiat nibh id fringilla posuere.\\015\\012\\015\\012Maecenas non mollis libero. Nulla rhoncus, arcu ut mollis posuere, risus libero semper turpis, a eleifend libero turpis eget ipsum. Etiam at placerat orci, et elementum dui. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean dignissim turpis ligula, eget cursus neque tempor at. Morbi vel bibendum justo. Mauris mattis sapien lorem, ut mattis dolor aliquam ac. Aliquam mollis fermentum velit, ut pellentesque odio elementum quis. Vestibulum pretium magna erat, ultricies pretium felis aliquam non. Nunc pharetra fermentum arcu sit amet fermentum. Mauris at nunc pellentesque elit convallis interdum. Nulla facilisi. Duis accumsan leo ut fringilla vulputate. Donec nisl diam, posuere non massa sed, fermentum consectetur nisi. In accumsan lacus vel orci efficitur eleifend.\\015\\012\\015\\012Sed a sapien ut justo pulvinar sodales. Fusce lobortis commodo ornare. Proin eget sapien congue lacus mattis lobortis mollis quis magna. Cras mauris nisi, finibus nec magna eu, ullamcorper suscipit leo. Aenean imperdiet purus at justo convallis ullamcorper. Mauris condimentum imperdiet magna, id cursus nulla aliquam quis. Vestibulum fermentum neque at consectetur aliquam. Sed ornare, orci id blandit tincidunt, mi mauris condimentum urna, in tincidunt diam eros ac magna. Donec ac vestibulum sem. Nulla vestibulum elit nisl, id cursus lacus tincidunt vitae. Donec accumsan eu lacus posuere fermentum. Sed finibus euismod nisl, eget bibendum lacus pulvinar nec.\\015\\012\\015\\012Aliquam eget lacus ac ex faucibus varius nec sit amet erat. Integer elementum lorem nulla, sed hendrerit risus efficitur quis. Donec eget lorem lorem. Fusce suscipit risus sed purus lobortis scelerisque. Fusce aliquet eros nec elit lobortis tincidunt. Ut fringilla risus velit, a sollicitudin ex vestibulum et. Pellentesque vel tincidunt neque.\\015\\012\\015\\012Ut maximus ultrices ex non vehicula. Nullam vestibulum suscipit quam. Vivamus placerat odio purus, eget tincidunt erat mollis a. In pellentesque vehicula eleifend. Duis eu dapibus dui. Nullam pharetra imperdiet ultricies. Cras molestie, enim eget egestas ultricies, eros nibh commodo neque, a finibus nisl eros in urna. Pellentesque dui justo, commodo nec laoreet non, lobortis in enim. Morbi nisi ipsum, tempus eget eros vel, condimentum rutrum dui. Cras pharetra lacus tellus, quis bibendum eros placerat lacinia. Aliquam sed enim et metus faucibus posuere nec a sapien. Curabitur convallis metus odio, id aliquam dolor euismod in. Etiam ac lacus vel magna viverra feugiat.\\015\\012\\015\\012Phasellus semper pharetra leo et rutrum. Aliquam eget tortor odio. Nulla ac neque ante. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus pretium lorem eget urna pharetra hendrerit. Suspendisse ultricies imperdiet iaculis. Phasellus a sem turpis. Fusce accumsan est in eros sagittis faucibus.\\015\\012\\015\\012Praesent aliquam fermentum erat, quis molestie leo. Nam cursus massa magna. Mauris convallis nisi nibh, ac bibendum nunc mattis quis. Nam scelerisque consectetur justo. Ut eu odio tortor. Cras euismod est porta pharetra malesuada. Sed varius lacus cursus nisl suscipit dignissim. Nullam auctor in ex at dignissim. Integer sed mattis ex. Cras justo lacus, viverra id mollis et, tempus ut risus. Proin porttitor quis elit quis pulvinar.\\015\\012\\015\\012Vestibulum accumsan lectus non mauris dignissim hendrerit. Aliquam tortor tortor, dictum at vulputate vitae, facilisis nec justo. Cras eu accumsan metus. Vivamus at tincidunt nunc. Vivamus feugiat dictum ligula non auctor. Proin non faucibus libero, vitae feugiat risus. Morbi non facilisis enim. Donec non ornare turpis. In nec sapien at enim dictum porta. Nam id pellentesque lacus. Donec tempor bibendum blandit. Cras sit amet hendrerit nunc. Aenean id iaculis nisi, sit amet semper ex. Pellentesque elementum tellus erat, in mattis lectus elementum vitae. Curabitur laoreet libero non pellentesque consequat.\\015\\012\\015\\012Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Praesent sollicitudin magna vel elementum venenatis. Curabitur magna felis, scelerisque pharetra odio in, iaculis maximus nisi. Integer id felis ornare, ornare elit et, consequat nisi. Maecenas vel gravida ipsum, vel ullamcorper elit. Duis volutpat malesuada metus, quis pretium ligula bibendum in. Donec auctor nisi in dignissim condimentum.\\015\\012\\015\\012Phasellus volutpat diam eu quam vestibulum ornare. Sed id odio eu sem rhoncus iaculis eget eget metus. Fusce ultrices mauris pulvinar erat pulvinar pretium. Pellentesque id suscipit ante, finibus porttitor metus. Cras nec eros sit amet dui rhoncus ultrices. Phasellus suscipit velit ac eros porta elementum. Nullam luctus tortor eu sem tristique bibendum. Ut a nulla eu mauris iaculis convallis ut vitae tortor. Sed tincidunt, mauris vitae elementum malesuada, turpis mi tempus justo, a pulvinar neque erat quis nibh. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nulla ac tellus in nisi finibus pellentesque eget eget velit. Cras hendrerit maximus diam, eget porttitor leo condimentum fringilla.\\015\\012\\015\\012Maecenas posuere elit a lectus tempor tincidunt. Praesent sit amet lacinia urna. Etiam tristique bibendum ullamcorper. Etiam congue mollis tortor, vel aliquet dolor accumsan vitae. Aenean sollicitudin pulvinar tempor. Morbi ultrices rhoncus erat eget blandit. Curabitur faucibus ultrices egestas. Morbi efficitur, diam nec fringilla rhoncus, nisi quam posuere urna, eu interdum felis magna nec neque. Donec ultricies id nisi sed pretium. Duis consequat ornare ante ut pharetra.\\015\\012\\015\\012Maecenas convallis risus at leo pulvinar tincidunt. Suspendisse tincidunt fermentum est. Sed eu ipsum ultricies, mollis elit sit amet, blandit nulla. Integer a ipsum enim. Mauris lacinia ex ut augue cursus tristique. Vestibulum fringilla quis leo sit amet hendrerit. Mauris sit amet bibendum nunc, vitae hendrerit arcu. Proin in augue sed arcu rhoncus rutrum ac iaculis ligula. Vestibulum mattis nunc tortor, sed hendrerit eros viverra eu.\\015\\012\\015\\012Integer in nulla quis arcu euismod suscipit. Sed sit amet nisi ex. Aliquam eu magna nec nisl commodo ultricies. Duis laoreet, mi eu facilisis elementum, eros erat iaculis nisi, vel viverra purus lectus a lorem. Pellentesque mollis rutrum nibh, sit amet ullamcorper ligula bibendum a. Curabitur vitae sem id arcu condimentum tristique in vel lorem. Aenean vitae malesuada sem. Integer quam dui, placerat vel placerat id, suscipit fringilla nunc. Vestibulum ex turpis, tincidunt mattis dapibus et, mollis id leo. In ac dolor lobortis, viverra dui eu, vehicula arcu. Nullam at tortor vitae arcu efficitur egestas. Sed in ullamcorper justo, vitae lobortis tortor.\\015\\012\\015\\012Duis tempor justo vitae purus vulputate, sed posuere sapien iaculis. Vivamus condimentum lobortis porta. Proin venenatis feugiat blandit. Vivamus venenatis volutpat lectus non pretium. Etiam ac dictum diam, vulputate ultrices massa. Proin eget blandit quam. Aliquam et nibh sed elit accumsan commodo. Nulla facilisi. Donec a erat est. Phasellus suscipit molestie pellentesque. Pellentesque placerat eget nunc id suscipit. Vivamus tempus finibus molestie. Nam tincidunt tristique pharetra.\\015\\012\\015\\012Vivamus eget venenatis arcu. Nullam lacinia massa in nulla blandit vestibulum. Nullam sagittis diam id lorem elementum, nec efficitur diam fermentum. Phasellus nec arcu vitae arcu convallis congue eu in felis. Vivamus sagittis auctor neque vitae porttitor. Mauris pellentesque lorem non vulputate dignissim. Nullam sit amet eros urna. Quisque sollicitudin mollis elit, et posuere magna dictum in. Integer in dui condimentum tortor tincidunt feugiat. Curabitur ut arcu sit amet nulla condimentum efficitur. Sed ut gravida mi, vitae bibendum nisl. Aenean congue lorem at libero vehicula, eget pulvinar mauris luctus. Nulla facilisi. Curabitur imperdiet nibh non semper tincidunt. Nullam accumsan est in ante congue sodales. Morbi at felis eu tortor hendrerit euismod.\\015\\012\\015\\012Donec pellentesque mi non lectus tempus, ut efficitur nisi convallis. Aenean lobortis tristique ex. Cras malesuada dolor malesuada, tincidunt dui finibus, tincidunt mi. Quisque interdum bibendum mollis. Nam placerat pharetra lectus at consequat. Sed non pharetra nulla, vitae vestibulum quam. Donec vel lobortis libero, eu venenatis nibh.\\015\\012\\015\\012Donec nec tortor vel velit consequat sagittis. Curabitur imperdiet malesuada ex, a vehicula ipsum viverra id. Fusce auctor finibus neque, finibus ornare ipsum commodo non. Mauris euismod consectetur dictum. Cras vitae venenatis quam, nec efficitur tellus. Aenean non maximus enim. Cras in pellentesque augue, sed lobortis eros. Etiam augue neque, ultricies cursus rhoncus vel, pretium vitae ex. Quisque vestibulum est nec metus blandit, id volutpat lorem volutpat. Quisque at odio cursus, accumsan elit eget, dignissim enim.\\015\\012\\015\\012Quisque eu dolor luctus, interdum purus a, venenatis turpis. Quisque et augue finibus mi ultricies hendrerit. Proin sem ipsum, faucibus a libero eget, faucibus porttitor metus. Integer pharetra odio auctor, hendrerit nisl et, auctor nibh. Praesent elementum purus eleifend, maximus turpis rutrum, semper dolor. Morbi faucibus, ante fringilla convallis interdum, neque turpis mattis lorem, ut interdum tellus justo ut nisl. Cras nec efficitur sapien. Integer eget tristique quam, in porttitor sapien. In tincidunt est est, ac malesuada purus dictum a.\\015\\012\\015\\012Curabitur eget odio non nibh feugiat lacinia a a est. Donec eget aliquam ligula. Quisque tincidunt erat vitae lacus pulvinar, in venenatis nibh venenatis. Aenean vel sollicitudin risus. Nunc ac turpis facilisis velit tempor gravida quis nec erat. Vestibulum consequat et risus et eleifend. Nam consectetur orci quis congue vulputate. Integer molestie semper fermentum.\\015\\012\\015\\012Sed nec malesuada lacus. Vivamus id justo vestibulum, pellentesque lectus eu, pulvinar lectus. Etiam eu ipsum quis lorem finibus eleifend. Vestibulum et neque ac tortor fermentum placerat. Mauris sed volutpat odio, eget malesuada nisl. Ut augue urna, rhoncus vel maximus sit amet, rhoncus porttitor nibh. Duis fringilla accumsan dolor, dapibus suscipit purus varius id. Interdum et malesuada fames ac ante ipsum primis in faucibus. Curabitur sit amet elementum orci. Etiam vestibulum mi nec diam venenatis, ultrices commodo metus eleifend. Aenean tincidunt neque auctor magna aliquet ornare. Maecenas lectus arcu, auctor vel vehicula ut, consectetur eget tortor. Nam porttitor urna id urna eleifend, sed lacinia felis malesuada. Cras consequat fermentum odio sed lobortis.\\015\\012\\015\\012Aenean placerat dapibus purus, vitae molestie orci vulputate ut. Sed pellentesque orci nisi, nec pretium libero sollicitudin at. Etiam non metus nulla. Maecenas quis lorem accumsan, placerat turpis eu, mattis ante. Etiam lorem nisi, gravida id nulla at, vulputate rhoncus odio. Sed congue metus sed lectus euismod, a pharetra elit ullamcorper. Donec viverra, enim at lobortis tempus, nibh sapien efficitur arcu, in euismod mi arcu sagittis lacus. Quisque bibendum porta commodo. Phasellus pharetra condimentum vestibulum. Phasellus et felis velit.\\015\\012\\015\\012Ut sed elit et justo rutrum lobortis non vel justo. Etiam eu commodo orci. Maecenas sit amet leo felis. Ut a orci molestie, elementum dolor ut, accumsan neque. Quisque sit amet semper turpis, in interdum nisi. Aliquam molestie imperdiet justo, quis sodales tortor pulvinar ut. Morbi tempor, dolor a laoreet vestibulum, turpis ex vestibulum nisi, eu consequat orci turpis ut dui. Nunc id accumsan ligula, id hendrerit nisi. Aliquam cursus odio imperdiet magna tempus vulputate. Cras mollis, nisl eleifend pharetra luctus, nisl lacus elementum est, vitae eleifend velit ex ac felis. Aenean vel auctor ex. Sed eget enim vitae risus condimentum imperdiet. Vestibulum justo odio, sagittis eget tempor eget, ornare eu massa. Duis id pharetra ipsum, et finibus diam. Vivamus mollis dapibus felis vitae convallis. Pellentesque mauris purus, scelerisque ac nisi eu, malesuada finibus lectus.\\015\\012\\015\\012Proin pretium, sem non luctus ultrices, arcu ipsum tristique tellus, vel porttitor ipsum magna et mauris. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Phasellus venenatis, ante quis finibus posuere, odio neque scelerisque lorem, at convallis nunc arcu eget nibh. Nullam a nisi non nibh congue fermentum. Fusce aliquam metus metus, vel laoreet tellus consequat eget. Suspendisse porta, leo eu suscipit tincidunt, lectus eros pretium justo, eget dapibus massa lectus ut ligula. Praesent facilisis nulla quis enim aliquam varius.\\015\\012\\015\\012Vestibulum ornare ex non massa consequat rutrum. Quisque elementum quam vitae lorem iaculis, et hendrerit urna sodales. Integer lobortis laoreet enim, eget consequat nunc maximus id. Nunc ut dignissim est. In porttitor justo quis diam feugiat luctus. Nunc rhoncus dictum mattis. Donec nec dictum nunc, non hendrerit nisi. Morbi sagittis suscipit neque, eget blandit nunc euismod a. Aenean lobortis augue in venenatis condimentum. Proin fermentum, nisi a ultrices facilisis, velit massa lacinia libero, quis condimentum magna nisl a quam. Ut at sodales erat, id porttitor turpis. Cras arcu leo, ullamcorper quis tincidunt quis, eleifend sed nisi. Pellentesque lorem nulla, semper a eros nec, rhoncus euismod sem.\\015\\012\\015\\012Phasellus ut enim ante. Cras non risus et dui vehicula cursus vel consectetur lorem. Donec blandit consectetur lacus, quis bibendum felis accumsan nec. Praesent sollicitudin sed erat a pulvinar. Fusce id nunc volutpat risus dapibus tempor. In lobortis, tortor ut facilisis iaculis, mauris justo maximus leo, auctor varius nisi metus sit amet leo. Vestibulum venenatis pharetra semper. Nam pretium urna ut magna congue, ac ullamcorper mauris rhoncus. Aenean mattis, massa et luctus maximus, magna purus rutrum nisl, quis mollis leo tellus a eros.\\015\\012\\015\\012Donec imperdiet nulla vitae ornare scelerisque. Pellentesque hendrerit finibus lacus vel venenatis. Aenean nec gravida tellus. Suspendisse vel feugiat orci. Morbi tristique maximus mi non bibendum. In tempus turpis vel est fringilla, et ornare tortor faucibus. Praesent placerat sem sit amet lobortis fermentum. Vestibulum laoreet odio augue, at feugiat dui tempus sed. Sed volutpat auctor tempor.\\015\\012\\015\\012Sed pretium hendrerit condimentum. Quisque purus nunc, consequat et dapibus facilisis, luctus eu sapien. Cras gravida viverra lacus, ut mollis elit bibendum at. Ut sagittis dolor quis mauris auctor, sit amet elementum nisi eleifend. Quisque in metus tincidunt, ornare nisi sed, ultricies sem. Vivamus maximus bibendum tortor vel facilisis. Nullam mollis lectus vitae tellus blandit, ac pulvinar leo facilisis. Proin leo enim, euismod at blandit vitae, laoreet vitae est.\\015\\012\\015\\012Phasellus neque velit, cursus sit amet accumsan vel, suscipit et justo. Cras ultrices dictum facilisis. Morbi velit est, blandit vitae mi nec, luctus lobortis libero. Integer nisi enim, aliquet sed fermentum at, vehicula ut est. Ut blandit eleifend diam tristique maximus. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Quisque ligula erat, sollicitudin quis vestibulum at, maximus ac ipsum. Mauris a dapibus est. Vivamus id maximus nisi. Sed nec magna at dolor elementum volutpat. Aenean vel ex vel tellus iaculis imperdiet quis eu arcu. Vivamus quis magna porta, dapibus justo eget, lacinia enim. In nec gravida sem.\\015\\012\\015\\012Nullam auctor erat sed mi sagittis imperdiet. Suspendisse potenti. Proin tincidunt dapibus vulputate. Quisque non ligula eget augue volutpat euismod. Duis tellus sem, iaculis in metus mattis, venenatis tincidunt dui. Suspendisse eu consequat diam, sed malesuada nunc. Nam sit amet nisl ac arcu vestibulum hendrerit. Aliquam erat volutpat. Duis urna dui, auctor et risus ac, consequat gravida lectus. Maecenas non sem sit amet purus ornare vestibulum. Vivamus varius dolor sem, in vestibulum ligula blandit in. Morbi facilisis lectus venenatis, egestas quam at, fermentum justo. Phasellus hendrerit eu purus eu dignissim.\\015\\012\\015\\012Duis blandit dignissim iaculis. Cras sit amet dolor dolor. In condimentum mauris orci, in ullamcorper leo viverra in. Cras vitae viverra libero, ut blandit mi. Ut non vehicula nulla. Nullam sed nibh nec ipsum finibus dapibus eu in metus. Curabitur pellentesque augue semper, viverra quam ut, laoreet magna. Morbi imperdiet nunc et ex varius consectetur. Sed dui massa, tempor id faucibus sed, congue sit amet eros.\\015\\012\\015\\012Suspendisse potenti. Morbi sapien augue, dapibus commodo mauris ut, laoreet dapibus diam. Etiam et arcu sodales, vulputate arcu eget, laoreet ante. Suspendisse potenti. Aenean ut elit id nibh ullamcorper feugiat eget nec odio. Ut elementum lobortis velit at venenatis. Vivamus pulvinar blandit pulvinar. Aliquam luctus rhoncus turpis, a tempus purus pellentesque ac. Maecenas ultrices neque id ligula ullamcorper, in dignissim nunc dictum. Vestibulum ut pellentesque turpis, sed maximus dui. Nunc tortor mi, porttitor eget elit non, rutrum facilisis nisl. Phasellus auctor nulla tellus, nec sagittis nulla porttitor quis. Praesent quis dapibus elit. Aenean id turpis vitae elit molestie lobortis. Vivamus suscipit velit et ipsum vehicula interdum.\\015\\012\\015\\012Aliquam et felis ut erat placerat consequat. Donec bibendum finibus sollicitudin. Etiam rhoncus imperdiet viverra. Phasellus dictum scelerisque odio, mollis aliquet nisl tempus quis. Nullam tincidunt dolor nibh, in convallis massa cursus eget. Morbi nec fringilla nunc. Nam mattis mauris quis lorem suscipit, ut malesuada tellus sodales. Vivamus imperdiet, nisl in finibus imperdiet, sapien sapien semper felis, quis convallis tortor risus quis sapien. Cras aliquet ullamcorper lorem, ac fringilla orci venenatis id. Pellentesque non mi purus. Nunc imperdiet fringilla turpis eget facilisis. Nam dignissim sem sed turpis volutpat consequat. Praesent eget ex nunc.\\015\\012\\015\\012Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin et nunc ac felis iaculis vulputate fringilla sed leo. Praesent finibus pharetra urna id convallis. Phasellus leo augue, placerat vel ligula et, scelerisque vehicula tortor. Nulla laoreet ullamcorper turpis at egestas. Integer rhoncus odio ac bibendum rhoncus. Duis in nunc turpis. Sed ante purus, facilisis pharetra pretium eget, iaculis ac felis. Suspendisse potenti.\\015\\012\\015\\012Fusce lorem libero, consectetur sit amet viverra volutpat, malesuada non leo. Mauris aliquam varius ipsum, non fermentum nulla fringilla et. Nam in dignissim nibh. Praesent ut efficitur quam, ac rutrum arcu. Integer porttitor pulvinar massa id mollis. In ligula sapien, interdum ac posuere non, varius nec purus. Vivamus consectetur dolor ac scelerisque tincidunt. Ut ornare, purus vel congue vestibulum, metus nulla finibus ante, in dapibus nisl felis sagittis lacus. Aliquam blandit ex eu gravida suscipit. Vivamus lobortis nunc quis urna dapibus, in scelerisque nisi feugiat. Nullam quis dui vitae purus suscipit pharetra vitae ac orci. Proin non fringilla nulla, at laoreet purus. Ut eget massa eget elit porta molestie. Ut dapibus, arcu ut cursus varius, orci odio hendrerit nisl, eget dignissim arcu urna a nulla. Nunc tempor dui vel ligula aliquam, nec mattis est rhoncus.\\015\\012\\015\\012Nullam metus nisl, porttitor ac tincidunt non, tristique ut risus. Etiam orci sapien, ullamcorper vitae finibus feugiat, tempor mollis ipsum. Etiam pretium ultricies molestie. Pellentesque volutpat orci non erat varius, at viverra arcu vehicula. Duis sed quam sed erat feugiat rutrum et vel sem. Morbi libero augue, placerat a volutpat id, ornare a leo. Sed sed arcu et quam gravida tristique condimentum finibus felis. Phasellus tempor, turpis quis eleifend gravida, mauris felis feugiat nulla, sed tristique justo purus in libero.\\015\\012\\015\\012Suspendisse laoreet nisl non rutrum lacinia. In hac habitasse platea dictumst. Sed auctor fringilla magna, ac tincidunt sapien tincidunt fringilla. Morbi leo purus, egestas eget ultricies in, vestibulum a mi. Vivamus vel cursus nisl, id laoreet neque. Nam porta mi nec dui fringilla hendrerit. Etiam molestie nulla a metus mattis, quis accumsan urna scelerisque. Ut sed ullamcorper dui.\\015\\012\\015\\012Cras pulvinar risus sed risus elementum, in cursus purus vestibulum. Mauris sodales vitae nunc vitae convallis. Mauris ullamcorper, ante efficitur sodales lacinia, enim felis vehicula ipsum, in egestas nulla ligula et mi. Ut vel velit posuere, volutpat nisi sed, sodales nulla. Aliquam scelerisque dui sed lectus molestie, id varius quam porta. Sed iaculis placerat nulla, ultricies dictum metus rhoncus venenatis. Vestibulum tristique lobortis enim quis consectetur. Praesent sit amet lorem in odio interdum varius eu eu sapien. Vivamus tempus hendrerit suscipit. Etiam tincidunt ullamcorper elit, vel pellentesque ante maximus non. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Aenean cursus viverra lorem vel vestibulum.\\015\\012\\015\\012Quisque eget interdum risus, sit amet hendrerit nisi. Donec quis libero id tortor feugiat condimentum. Nam lectus neque, commodo sit amet mauris et, rutrum ultricies purus. Etiam eleifend ante eu eleifend viverra. Donec non metus vel metus tempor laoreet eu vitae lacus. Pellentesque interdum ut tellus eu viverra. Vivamus ut velit quis magna malesuada blandit.\\015\\012\\015\\012Vivamus maximus libero nulla. Integer ac tincidunt neque, vel euismod nisl. Mauris facilisis risus enim, sed posuere ligula volutpat vel. In erat augue, maximus et interdum vitae, rutrum a diam. Curabitur placerat tortor eget dolor euismod, ac efficitur leo pharetra. Nam neque ante, volutpat in aliquam id, consequat at elit. Cras viverra lorem augue, suscipit suscipit orci imperdiet id. Proin ut leo non arcu ornare imperdiet. Suspendisse semper lectus at rhoncus convallis. Nam nunc leo, tristique venenatis risus at, congue convallis sapien. Suspendisse vestibulum arcu et tortor malesuada, accumsan ullamcorper lacus consequat.\\015\\012\\015\\012Vestibulum suscipit est enim. In cursus, sem sed congue luctus, justo sapien hendrerit neque, sit amet tincidunt mauris massa ac leo. Suspendisse accumsan risus nunc, a pharetra justo viverra ac. In mattis massa turpis, et ultricies metus feugiat non. Nullam quis lacus vitae nunc sollicitudin aliquam in vitae quam. Quisque quis gravida sapien, quis ultrices justo. Aenean maximus, tortor a consequat tristique, neque mi auctor mi, ac interdum mi massa et orci. Pellentesque congue, ligula quis porttitor aliquam, sem dolor eleifend augue, quis laoreet dui tortor eget nunc. Aliquam ornare eleifend justo, ut vestibulum massa varius ut. Aliquam tempus scelerisque mi, placerat laoreet dui mollis tempus. Nulla hendrerit tincidunt eros. Nulla in gravida enim, nec dignissim nulla. Donec sed vulputate ligula.\\015\\012\\015\\012Aliquam vitae iaculis odio. In hac habitasse platea dictumst. Maecenas varius quis sapien sed lobortis. Vivamus ac lacus eget turpis fermentum blandit. Nulla molestie dolor lectus, ac tristique mi rhoncus ut. Mauris egestas nunc vitae urna consectetur tristique. Etiam orci quam, efficitur a laoreet nec, sollicitudin vel odio. Quisque ac efficitur elit. Nam facilisis consequat pretium. Mauris ut tortor a sapien faucibus sodales laoreet non odio. Donec dictum lorem vitae sem rhoncus, a ullamcorper purus aliquam. Vestibulum laoreet libero non lacus rhoncus, sit amet egestas lacus tempus. Morbi varius viverra scelerisque. Aliquam aliquam laoreet purus, sit amet luctus metus pretium ut. Donec venenatis congue odio, nec aliquam tellus euismod eu.\\015\\012\\015\\012Proin interdum nisl non rhoncus bibendum. Nulla sit amet justo vitae sapien ultrices commodo. Vivamus varius nulla nec nisl cursus semper. Ut quis lacus in arcu iaculis commodo. Nulla mollis ultrices augue vel tincidunt. Vivamus vitae risus euismod est varius ornare. Cras laoreet porttitor ex. Nulla risus mauris, bibendum a ultrices sit amet, finibus maximus mi. Ut ac sapien condimentum, maximus velit consequat, commodo neque. Phasellus tempus sed eros eu interdum. Aliquam efficitur ultrices suscipit. In pulvinar ultricies eros quis pellentesque. Cras porta sem velit, nec hendrerit nisi blandit porttitor. Nam non volutpat erat.\\015\\012\\015\\012In egestas dictum nulla, pellentesque euismod nisl bibendum eget. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus et dolor eget turpis consequat accumsan. Praesent sit amet luctus ipsum. Proin ullamcorper erat non quam congue, eu ultricies velit mattis. Fusce faucibus orci in vestibulum accumsan. Duis est mi, dictum a lacus volutpat, dapibus suscipit sapien. Ut eget arcu non orci aliquet rutrum vel at justo. Maecenas ut velit in risus semper sagittis. Aliquam commodo odio id pretium faucibus.\\015\\012\\015\\012Cras viverra et velit vel rhoncus. Aliquam erat volutpat. Cras vestibulum elementum nisi, sit amet consectetur felis placerat vitae. Praesent et eros sodales urna rutrum volutpat. Etiam euismod magna tellus, nec fringilla elit interdum non. Nam eget arcu vehicula, elementum justo in, mollis metus. Proin dapibus varius eleifend. Proin ac vulputate risus. Nulla sed tristique neque. Aliquam vitae convallis mauris. In consectetur velit tellus, ac feugiat orci rutrum ut. Maecenas vel consequat elit. Aliquam molestie orci eu odio mattis tempus. Aliquam nec libero convallis urna convallis porttitor. Morbi consectetur ultricies nibh quis dictum. In ullamcorper ipsum sit amet enim tincidunt, at varius neque tempor.\\015\\012\\015\\012Sed pulvinar volutpat enim id laoreet. Ut rhoncus varius enim non sollicitudin. Cras vitae nibh malesuada, imperdiet turpis quis, efficitur erat. Ut congue, purus ut dictum cursus, diam sapien vulputate nulla, quis ullamcorper dolor sapien quis quam. Aliquam nec dui lobortis, tincidunt sapien in, porttitor ligula. Donec suscipit elit eu lectus tristique ornare. In eget risus magna. Donec non odio imperdiet, porta erat id, tempus felis. Mauris sagittis neque at feugiat vestibulum. Donec id ex neque. Morbi malesuada ante sapien, a faucibus diam pharetra ac. Aenean sed felis fringilla, suscipit risus vel, porta ipsum. Praesent in ipsum erat.\\015\\012\\015\\012Ut id pretium felis, nec pretium ligula. Praesent eleifend ullamcorper ante quis tempus. Morbi volutpat sapien nibh, a elementum nunc maximus ut. Pellentesque condimentum mauris quam, a feugiat turpis faucibus in. Nulla facilisi. In tincidunt nulla laoreet eros aliquam pellentesque. Cras euismod viverra quam vitae tempus. Mauris tristique nunc et lacus rhoncus, ac laoreet tortor convallis. Aliquam vulputate tincidunt sollicitudin. Morbi massa quam, ultrices ut leo a, consectetur ultricies nunc. Maecenas tempor erat faucibus rutrum sodales. Cras venenatis cursus dui id maximus. Mauris eget purus elementum, ullamcorper nisl eget, malesuada turpis. Ut risus urna, lacinia ac venenatis viverra, viverra sit amet justo. Integer vitae ligula eget turpis congue tristique eget non elit.\\015\\012\\015\\012Praesent non eros sit amet tellus dignissim consectetur vitae dapibus ex. Nullam aliquam accumsan pretium. Morbi commodo dictum fermentum. Suspendisse potenti. Sed ultrices eget lorem sit amet rutrum. Praesent vulputate risus a libero aliquam pulvinar. Pellentesque eget facilisis orci. Donec metus dui, commodo eget neque eget, euismod congue metus. In a accumsan arcu. Sed sit amet ante turpis. Nunc id volutpat massa, nec tristique turpis. Nulla eleifend venenatis ligula.\\015\\012\\015\\012Donec pellentesque elit et bibendum vehicula. Suspendisse mollis libero et elit lacinia rutrum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Praesent arcu ipsum, congue ac interdum ornare, dignissim sed orci. Nunc sed porttitor arcu. Proin id erat ut tellus euismod malesuada at nec orci. Phasellus eget neque lorem. Aenean et ex ultricies, consequat turpis sit amet, lacinia felis. Aliquam erat volutpat. Vestibulum et consequat magna, quis placerat orci. Suspendisse in varius nunc.\\015\\012\\015\\012Curabitur sapien diam, dictum eget massa a, molestie blandit enim. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nam aliquet, dui id vestibulum placerat, risus erat luctus dui, ac condimentum nunc sem quis elit. Vivamus consectetur elit a magna lobortis auctor. Nunc pulvinar et elit vitae dignissim. Curabitur pulvinar massa quis neque convallis posuere non vel nisl. Sed lacinia luctus erat, ut tempus orci venenatis eget. Phasellus congue pulvinar dolor vitae congue. Ut non elementum risus. Nulla facilisi. Nam imperdiet elit id tellus eleifend, nec vehicula felis dignissim. Maecenas quis tempus mi.\\015\\012\\015\\012In sollicitudin mi luctus, malesuada libero sit amet, efficitur lorem. Fusce imperdiet leo id lacinia mattis. Nullam ultrices placerat velit. Praesent non accumsan risus. Duis massa nulla, venenatis vel euismod quis, vehicula nec massa. Praesent scelerisque nunc nec laoreet pulvinar. Nunc congue, mi ut dignissim euismod, purus lorem varius ante, eget suscipit orci nibh a sapien.\\015\\012\\015\\012Sed auctor eleifend molestie. Cras sodales lectus sit amet bibendum facilisis. Sed ac nunc eget augue gravida volutpat. Donec vel faucibus odio, vel maximus ipsum. Duis efficitur blandit tortor, eu consequat turpis. Vivamus tincidunt vitae sapien non vehicula. Quisque aliquet massa ac mauris efficitur vehicula. Integer luctus orci non neque gravida ornare. Maecenas feugiat tempus placerat. In vitae dui magna. Cras feugiat nibh id fringilla posuere.\\015\\012\\015\\012Maecenas non mollis libero. Nulla rhoncus, arcu ut mollis posuere, risus libero semper turpis, a eleifend libero turpis eget ipsum. Etiam at placerat orci, et elementum dui. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean dignissim turpis ligula, eget cursus neque tempor at. Morbi vel bibendum justo. Mauris mattis sapien lorem, ut mattis dolor aliquam ac. Aliquam mollis fermentum velit, ut pellentesque odio elementum quis. Vestibulum pretium magna erat, ultricies pretium felis aliquam non. Nunc pharetra fermentum arcu sit amet fermentum. Mauris at nunc pellentesque elit convallis interdum. Nulla facilisi. Duis accumsan leo ut fringilla vulputate. Donec nisl diam, posuere non massa sed, fermentum consectetur nisi. In accumsan lacus vel orci efficitur eleifend.\\015\\012\\015\\012Sed a sapien ut justo pulvinar sodales. Fusce lobortis commodo ornare. Proin eget sapien congue lacus mattis lobortis mollis quis magna. Cras mauris nisi, finibus nec magna eu, ullamcorper suscipit leo. Aenean imperdiet purus at justo convallis ullamcorper. Mauris condimentum imperdiet magna, id cursus nulla aliquam quis. Vestibulum fermentum neque at consectetur aliquam. Sed ornare, orci id blandit tincidunt, mi mauris condimentum urna, in tincidunt diam eros ac magna. Donec ac vestibulum sem. Nulla vestibulum elit nisl, id cursus lacus tincidunt vitae. Donec accumsan eu lacus posuere fermentum. Sed finibus euismod nisl, eget bibendum lacus pulvinar nec.\\015\\012\\015\\012Aliquam eget lacus ac ex faucibus varius nec sit amet erat. Integer elementum lorem nulla, sed hendrerit risus efficitur quis. Donec eget lorem lorem. Fusce suscipit risus sed purus lobortis scelerisque. Fusce aliquet eros nec elit lobortis tincidunt. Ut fringilla risus velit, a sollicitudin ex vestibulum et. Pellentesque vel tincidunt neque.\\015\\012\\015\\012Ut maximus ultrices ex non vehicula. Nullam vestibulum suscipit quam. Vivamus placerat odio purus, eget tincidunt erat mollis a. In pellentesque vehicula eleifend. Duis eu dapibus dui. Nullam pharetra imperdiet ultricies. Cras molestie, enim eget egestas ultricies, eros nibh commodo neque, a finibus nisl eros in urna. Pellentesque dui justo, commodo nec laoreet non, lobortis in enim. Morbi nisi ipsum, tempus eget eros vel, condimentum rutrum dui. Cras pharetra lacus tellus, quis bibendum eros placerat lacinia. Aliquam sed enim et metus faucibus posuere nec a sapien. Curabitur convallis metus odio, id aliquam dolor euismod in. Etiam ac lacus vel magna viverra feugiat.\\015\\012\\015\\012Phasellus semper pharetra leo et rutrum. Aliquam eget tortor odio. Nulla ac neque ante. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus pretium lorem eget urna pharetra hendrerit. Suspendisse ultricies imperdiet iaculis. Phasellus a sem turpis. Fusce accumsan est in eros sagittis faucibus.\\015\\012\\015\\012Praesent aliquam fermentum erat, quis molestie leo. Nam cursus massa magna. Mauris convallis nisi nibh, ac bibendum nunc mattis quis. Nam scelerisque consectetur justo. Ut eu odio tortor. Cras euismod est porta pharetra malesuada. Sed varius lacus cursus nisl suscipit dignissim. Nullam auctor in ex at dignissim. Integer sed mattis ex. Cras justo lacus, viverra id mollis et, tempus ut risus. Proin porttitor quis elit quis pulvinar.\\015\\012\\015\\012Vestibulum accumsan lectus non mauris dignissim hendrerit. Aliquam tortor tortor, dictum at vulputate vitae, facilisis nec justo. Cras eu accumsan metus. Vivamus at tincidunt nunc. Vivamus feugiat dictum ligula non auctor. Proin non faucibus libero, vitae feugiat risus. Morbi non facilisis enim. Donec non ornare turpis. In nec sapien at enim dictum porta. Nam id pellentesque lacus. Donec tempor bibendum blandit. Cras sit amet hendrerit nunc. Aenean id iaculis nisi, sit amet semper ex. Pellentesque elementum tellus erat, in mattis lectus elementum vitae. Curabitur laoreet libero non pellentesque consequat.\\015\\012\\015\\012Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Praesent sollicitudin magna vel elementum venenatis. Curabitur magna felis, scelerisque pharetra odio in, iaculis maximus nisi. Integer id felis ornare, ornare elit et, consequat nisi. Maecenas vel gravida ipsum, vel ullamcorper elit. Duis volutpat malesuada metus, quis pretium ligula bibendum in. Donec auctor nisi in dignissim condimentum.\\015\\012\\015\\012Phasellus volutpat diam eu quam vestibulum ornare. Sed id odio eu sem rhoncus iaculis eget eget metus. Fusce ultrices mauris pulvinar erat pulvinar pretium. Pellentesque id suscipit ante, finibus porttitor metus. Cras nec eros sit amet dui rhoncus ultrices. Phasellus suscipit velit ac eros porta elementum. Nullam luctus tortor eu sem tristique bibendum. Ut a nulla eu mauris iaculis convallis ut vitae tortor. Sed tincidunt, mauris vitae elementum malesuada, turpis mi tempus justo, a pulvinar neque erat quis nibh. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nulla ac tellus in nisi finibus pellentesque eget eget velit. Cras hendrerit maximus diam, eget porttitor leo condimentum fringilla.\\015\\012\\015\\012Maecenas posuere elit a lectus tempor tincidunt. Praesent sit amet lacinia urna. Etiam tristique bibendum ullamcorper. Etiam congue mollis tortor, vel aliquet dolor accumsan vitae. Aenean sollicitudin pulvinar tempor. Morbi ultrices rhoncus erat eget blandit. Curabitur faucibus ultrices egestas. Morbi efficitur, diam nec fringilla rhoncus, nisi quam posuere urna, eu interdum felis magna nec neque. Donec ultricies id nisi sed pretium. Duis consequat ornare ante ut pharetra.\\015\\012\\015\\012Maecenas convallis risus at leo pulvinar tincidunt. Suspendisse tincidunt fermentum est. Sed eu ipsum ultricies, mollis elit sit amet, blandit nulla. Integer a ipsum enim. Mauris lacinia ex ut augue cursus tristique. Vestibulum fringilla quis leo sit amet hendrerit. Mauris sit amet bibendum nunc, vitae hendrerit arcu. Proin in augue sed arcu rhoncus rutrum ac iaculis ligula. Vestibulum mattis nunc tortor, sed hendrerit eros viverra eu.\\015\\012\\015\\012Integer in nulla quis arcu euismod suscipit. Sed sit amet nisi ex. Aliquam eu magna nec nisl commodo ultricies. Duis laoreet, mi eu facilisis elementum, eros erat iaculis nisi, vel viverra purus lectus a lorem. Pellentesque mollis rutrum nibh, sit amet ullamcorper ligula bibendum a. Curabitur vitae sem id arcu condimentum tristique in vel lorem. Aenean vitae malesuada sem. Integer quam dui, placerat vel placerat id, suscipit fringilla nunc. Vestibulum ex turpis, tincidunt mattis dapibus et, mollis id leo. In ac dolor lobortis, viverra dui eu, vehicula arcu. Nullam at tortor vitae arcu efficitur egestas. Sed in ullamcorper justo, vitae lobortis tortor.\\015\\012\\015\\012Duis tempor justo vitae purus vulputate, sed posuere sapien iaculis. Vivamus condimentum lobortis porta. Proin venenatis feugiat blandit. Vivamus venenatis volutpat lectus non pretium. Etiam ac dictum diam, vulputate ultrices massa. Proin eget blandit quam. Aliquam et nibh sed elit accumsan commodo. Nulla facilisi. Donec a erat est. Phasellus suscipit molestie pellentesque. Pellentesque placerat eget nunc id suscipit. Vivamus tempus finibus molestie. Nam tincidunt tristique pharetra.\\015\\012\\015\\012Vivamus eget venenatis arcu. Nullam lacinia massa in nulla blandit vestibulum. Nullam sagittis diam id lorem elementum, nec efficitur diam fermentum. Phasellus nec arcu vitae arcu convallis congue eu in felis. Vivamus sagittis auctor neque vitae porttitor. Mauris pellentesque lorem non vulputate dignissim. Nullam sit amet eros urna. Quisque sollicitudin mollis elit, et posuere magna dictum in. Integer in dui condimentum tortor tincidunt feugiat. Curabitur ut arcu sit amet nulla condimentum efficitur. Sed ut gravida mi, vitae bibendum nisl. Aenean congue lorem at libero vehicula, eget pulvinar mauris luctus. Nulla facilisi. Curabitur imperdiet nibh non semper tincidunt. Nullam accumsan est in ante congue sodales. Morbi at felis eu tortor hendrerit euismod.\\015\\012\\015\\012Donec pellentesque mi non lectus tempus, ut efficitur nisi convallis. Aenean lobortis tristique ex. Cras malesuada dolor malesuada, tincidunt dui finibus, tincidunt mi. Quisque interdum bibendum mollis. Nam placerat pharetra lectus at consequat. Sed non pharetra nulla, vitae vestibulum quam. Donec vel lobortis libero, eu venenatis nibh.\\015\\012\\015\\012Donec nec tortor vel velit consequat sagittis. Curabitur imperdiet malesuada ex, a vehicula ipsum viverra id. Fusce auctor finibus neque, finibus ornare ipsum commodo non. Mauris euismod consectetur dictum. Cras vitae venenatis quam, nec efficitur tellus. Aenean non maximus enim. Cras in pellentesque augue, sed lobortis eros. Etiam augue neque, ultricies cursus rhoncus vel, pretium vitae ex. Quisque vestibulum est nec metus blandit, id volutpat lorem volutpat. Quisque at odio cursus, accumsan elit eget, dignissim enim.\\015\\012\\015\\012Quisque eu dolor luctus, interdum purus a, venenatis turpis. Quisque et augue finibus mi ultricies hendrerit. Proin sem ipsum, faucibus a libero eget, faucibus porttitor metus. Integer pharetra odio auctor, hendrerit nisl et, auctor nibh. Praesent elementum purus eleifend, maximus turpis rutrum, semper dolor. Morbi faucibus, ante fringilla convallis interdum, neque turpis mattis lorem, ut interdum tellus justo ut nisl. Cras nec efficitur sapien. Integer eget tristique quam, in porttitor sapien. In tincidunt est est, ac malesuada purus dictum a.\\015\\012\\015\\012Curabitur eget odio non nibh feugiat lacinia a a est. Donec eget aliquam ligula. Quisque tincidunt erat vitae lacus pulvinar, in venenatis nibh venenatis. Aenean vel sollicitudin risus. Nunc ac turpis facilisis velit tempor gravida quis nec erat. Vestibulum consequat et risus et eleifend. Nam consectetur orci quis congue vulputate. Integer molestie semper fermentum.\\015\\012\\015\\012Sed nec malesuada lacus. Vivamus id justo vestibulum, pellentesque lectus eu, pulvinar lectus. Etiam eu ipsum quis lorem finibus eleifend. Vestibulum et neque ac tortor fermentum placerat. Mauris sed volutpat odio, eget malesuada nisl. Ut augue urna, rhoncus vel maximus sit amet, rhoncus porttitor nibh. Duis fringilla accumsan dolor, dapibus suscipit purus varius id. Interdum et malesuada fames ac ante ipsum primis in faucibus. Curabitur sit amet elementum orci. Etiam vestibulum mi nec diam venenatis, ultrices commodo metus eleifend. Aenean tincidunt neque auctor magna aliquet ornare. Maecenas lectus arcu, auctor vel vehicula ut, consectetur eget tortor. Nam porttitor urna id urna eleifend, sed lacinia felis malesuada. Cras consequat fermentum odio sed lobortis.\\015\\012\\015\\012Aenean placerat dapibus purus, vitae molestie orci vulputate ut. Sed pellentesque orci nisi, nec pretium libero sollicitudin at. Etiam non metus nulla. Maecenas quis lorem accumsan, placerat turpis eu, mattis ante. Etiam lorem nisi, gravida id nulla at, vulputate rhoncus odio. Sed congue metus sed lectus euismod, a pharetra elit ullamcorper. Donec viverra, enim at lobortis tempus, nibh sapien efficitur arcu, in euismod mi arcu sagittis lacus. Quisque bibendum porta commodo. Phasellus pharetra condimentum vestibulum. Phasellus et felis velit.\\015\\012\\015\\012Ut sed elit et justo rutrum lobortis non vel justo. Etiam eu commodo orci. Maecenas sit amet leo felis. Ut a orci molestie, elementum dolor ut, accumsan neque. Quisque sit amet semper turpis, in interdum nisi. Aliquam molestie imperdiet justo, quis sodales tortor pulvinar ut. Morbi tempor, dolor a laoreet vestibulum, turpis ex vestibulum nisi, eu consequat orci turpis ut dui. Nunc id accumsan ligula, id hendrerit nisi. Aliquam cursus odio imperdiet magna tempus vulputate. Cras mollis, nisl eleifend pharetra luctus, nisl lacus elementum est, vitae eleifend velit ex ac felis. Aenean vel auctor ex. Sed eget enim vitae risus condimentum imperdiet. Vestibulum justo odio, sagittis eget tempor eget, ornare eu massa. Duis id pharetra ipsum, et finibus diam. Vivamus mollis dapibus felis vitae convallis. Pellentesque mauris purus, scelerisque ac nisi eu, malesuada finibus lectus.\\015\\012\\015\\012Proin pretium, sem non luctus ultrices, arcu ipsum tristique tellus, vel porttitor ipsum magna et mauris. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Phasellus venenatis, ante quis finibus posuere, odio neque scelerisque lorem, at convallis nunc arcu eget nibh. Nullam a nisi non nibh congue fermentum. Fusce aliquam metus metus, vel laoreet tellus consequat eget. Suspendisse porta, leo eu suscipit tincidunt, lectus eros pretium justo, eget dapibus massa lectus ut ligula. Praesent facilisis nulla quis enim aliquam varius.\\015\\012\\015\\012Vestibulum ornare ex non massa consequat rutrum. Quisque elementum quam vitae lorem iaculis, et hendrerit urna sodales. Integer lobortis laoreet enim, eget consequat nunc maximus id. Nunc ut dignissim est. In porttitor justo quis diam feugiat luctus. Nunc rhoncus dictum mattis. Donec nec dictum nunc, non hendrerit nisi. Morbi sagittis suscipit neque, eget blandit nunc euismod a. Aenean lobortis augue in venenatis condimentum. Proin fermentum, nisi a ultrices facilisis, velit massa lacinia libero, quis condimentum magna nisl a quam. Ut at sodales erat, id porttitor turpis. Cras arcu leo, ullamcorper quis tincidunt quis, eleifend sed nisi. Pellentesque lorem nulla, semper a eros nec, rhoncus euismod sem.\\015\\012\\015\\012Phasellus ut enim ante. Cras non risus et dui vehicula cursus vel consectetur lorem. Donec blandit consectetur lacus, quis bibendum felis accumsan nec. Praesent sollicitudin sed erat a pulvinar. Fusce id nunc volutpat risus dapibus tempor. In lobortis, tortor ut facilisis iaculis, mauris justo maximus leo, auctor varius nisi metus sit amet leo. Vestibulum venenatis pharetra semper. Nam pretium urna ut magna congue, ac ullamcorper mauris rhoncus. Aenean mattis, massa et luctus maximus, magna purus rutrum nisl, quis mollis leo tellus a eros.\\015\\012\\015\\012Donec imperdiet nulla vitae ornare scelerisque. Pellentesque hendrerit finibus lacus vel venenatis. Aenean nec gravida tellus. Suspendisse vel feugiat orci. Morbi tristique maximus mi non bibendum. In tempus turpis vel est fringilla, et ornare tortor faucibus. Praesent placerat sem sit amet lobortis fermentum. Vestibulum laoreet odio augue, at feugiat dui tempus sed. Sed volutpat auctor tempor.\\015\\012\\015\\012Sed pretium hendrerit condimentum. Quisque purus nunc, consequat et dapibus facilisis, luctus eu sapien. Cras gravida viverra lacus, ut mollis elit bibendum at. Ut sagittis dolor quis mauris auctor, sit amet elementum nisi eleifend. Quisque in metus tincidunt, ornare nisi sed, ultricies sem. Vivamus maximus bibendum tortor vel facilisis. Nullam mollis lectus vitae tellus blandit, ac pulvinar leo facilisis. Proin leo enim, euismod at blandit vitae, laoreet vitae est.\\015\\012\\015\\012Phasellus neque velit, cursus sit amet accumsan vel, suscipit et justo. Cras ultrices dictum facilisis. Morbi velit est, blandit vitae mi nec, luctus lobortis libero. Integer nisi enim, aliquet sed fermentum at, vehicula ut est. Ut blandit eleifend diam tristique maximus. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Quisque ligula erat, sollicitudin quis vestibulum at, maximus ac ipsum. Mauris a dapibus est. Vivamus id maximus nisi. Sed nec magna at dolor elementum volutpat. Aenean vel ex vel tellus iaculis imperdiet quis eu arcu. Vivamus quis magna porta, dapibus justo eget, lacinia enim. In nec gravida sem.\\015\\012\\015\\012Nullam auctor erat sed mi sagittis imperdiet. Suspendisse potenti. Proin tincidunt dapibus vulputate. Quisque non ligula eget augue volutpat euismod. Duis tellus sem, iaculis in metus mattis, venenatis tincidunt dui. Suspendisse eu consequat diam, sed malesuada nunc. Nam sit amet nisl ac arcu vestibulum hendrerit. Aliquam erat volutpat. Duis urna dui, auctor et risus ac, consequat gravida lectus. Maecenas non sem sit amet purus ornare vestibulum. Vivamus varius dolor sem, in vestibulum ligula blandit in. Morbi facilisis lectus venenatis, egestas quam at, fermentum justo. Phasellus hendrerit eu purus eu dignissim.\\015\\012\\015\\012Duis blandit dignissim iaculis. Cras sit amet dolor dolor. In condimentum mauris orci, in ullamcorper leo viverra in. Cras vitae viverra libero, ut blandit mi. Ut non vehicula nulla. Nullam sed nibh nec ipsum finibus dapibus eu in metus. Curabitur pellentesque augue semper, viverra quam ut, laoreet magna. Morbi imperdiet nunc et ex varius consectetur. Sed dui massa, tempor id faucibus sed, congue sit amet eros.\\015\\012\\015\\012Suspendisse potenti. Morbi sapien augue, dapibus commodo mauris ut, laoreet dapibus diam. Etiam et arcu sodales, vulputate arcu eget, laoreet ante. Suspendisse potenti. Aenean ut elit id nibh ullamcorper feugiat eget nec odio. Ut elementum lobortis velit at venenatis. Vivamus pulvinar blandit pulvinar. Aliquam luctus rhoncus turpis, a tempus purus pellentesque ac. Maecenas ultrices neque id ligula ullamcorper, in dignissim nunc dictum. Vestibulum ut pellentesque turpis, sed maximus dui. Nunc tortor mi, porttitor eget elit non, rutrum facilisis nisl. Phasellus auctor nulla tellus, nec sagittis nulla porttitor quis. Praesent quis dapibus elit. Aenean id turpis vitae elit molestie lobortis. Vivamus suscipit velit et ipsum vehicula interdum.\\015\\012\\015\\012Aliquam et felis ut erat placerat consequat. Donec bibendum finibus sollicitudin. Etiam rhoncus imperdiet viverra. Phasellus dictum scelerisque odio, mollis aliquet nisl tempus quis. Nullam tincidunt dolor nibh, in convallis massa cursus eget. Morbi nec fringilla nunc. Nam mattis mauris quis lorem suscipit, ut malesuada tellus sodales. Vivamus imperdiet, nisl in finibus imperdiet, sapien sapien semper felis, quis convallis tortor risus quis sapien. Cras aliquet ullamcorper lorem, ac fringilla orci venenatis id. Pellentesque non mi purus. Nunc imperdiet fringilla turpis eget facilisis. Nam dignissim sem sed turpis volutpat consequat. Praesent eget ex nunc.</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <TextOptions>HotkeyPrefix=None, LineLimit=False, RightToLeft=False, Trimming=None, WordWrap=True, Angle=0, FirstTabOffset=40, DistanceBetweenTabs=20,</TextOptions>\\015\\012              <Type>Expression</Type>\\015\\012            </TextContent>\\015\\012          </Components>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Filters isList="true" count="0" />\\015\\012          <Name>DataBand1</Name>\\015\\012          <Page isRef="2" />\\015\\012          <Parent isRef="2" />\\015\\012          <Sort isList="true" count="0" />\\015\\012        </DataBand1>\\015\\012      </Components>\\015\\012      <Conditions isList="true" count="0" />\\015\\012      <Guid>2673caf849244e118b74ecc2b931b511</Guid>\\015\\012      <Margins>1,1,1,1</Margins>\\015\\012      <Name>Page1</Name>\\015\\012      <PageHeight>29.7</PageHeight>\\015\\012      <PageWidth>21</PageWidth>\\015\\012      <Report isRef="0" />\\015\\012      <Watermark Ref="8" type="Stimulsoft.Report.Components.StiWatermark" isKey="true">\\015\\012        <Font>Arial,100</Font>\\015\\012        <TextBrush>[50:0:0:0]</TextBrush>\\015\\012      </Watermark>\\015\\012    </Page1>\\015\\012  </Pages>\\015\\012  <PrinterSettings Ref="9" type="Stimulsoft.Report.Print.StiPrinterSettings" isKey="true" />\\015\\012  <ReferencedAssemblies isList="true" count="8">\\015\\012    <value>System.Dll</value>\\015\\012    <value>System.Drawing.Dll</value>\\015\\012    <value>System.Windows.Forms.Dll</value>\\015\\012    <value>System.Data.Dll</value>\\015\\012    <value>System.Xml.Dll</value>\\015\\012    <value>Stimulsoft.Controls.Dll</value>\\015\\012    <value>Stimulsoft.Base.Dll</value>\\015\\012    <value>Stimulsoft.Report.Dll</value>\\015\\012  </ReferencedAssemblies>\\015\\012  <ReportAlias>Report</ReportAlias>\\015\\012  <ReportChanged>4/21/2015 9:51:52 AM</ReportChanged>\\015\\012  <ReportCreated>4/20/2015 5:01:58 PM</ReportCreated>\\015\\012  <ReportFile>C:\\134Reports\\134test1.mrt</ReportFile>\\015\\012  <ReportGuid>da06a4fb091c42a4b3ec06aa1b8f0733</ReportGuid>\\015\\012  <ReportName>Report</ReportName>\\015\\012  <ReportUnit>Centimeters</ReportUnit>\\015\\012  <ReportVersion>2014.3.0</ReportVersion>\\015\\012  <Script>using System;\\015\\012using System.Drawing;\\015\\012using System.Windows.Forms;\\015\\012using System.Data;\\015\\012using Stimulsoft.Controls;\\015\\012using Stimulsoft.Base.Drawing;\\015\\012using Stimulsoft.Report;\\015\\012using Stimulsoft.Report.Dialogs;\\015\\012using Stimulsoft.Report.Components;\\015\\012\\015\\012namespace Reports\\015\\012{\\015\\012    public class Report : Stimulsoft.Report.StiReport\\015\\012    {\\015\\012        public Report()        {\\015\\012            this.InitializeComponent();\\015\\012        }\\015\\012\\015\\012        #region StiReport Designer generated code - do not modify\\015\\012\\011\\011#endregion StiReport Designer generated code - do not modify\\015\\012    }\\015\\012}\\015\\012</Script>\\015\\012  <ScriptLanguage>CSharp</ScriptLanguage>\\015\\012  <Styles isList="true" count="0" />\\015\\012</StiSerializer>',
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


