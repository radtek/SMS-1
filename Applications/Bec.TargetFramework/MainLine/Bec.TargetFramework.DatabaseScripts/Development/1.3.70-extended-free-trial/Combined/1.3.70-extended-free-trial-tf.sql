INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "ClassificationTypeCategoryID") VALUES (5243, E'Declined to participate', 8504);

update "StatusTypeValue" set "Description" = 'Please note that at least one validated bank account is required to add transactions.' where
"StatusTypeID" = (select "StatusTypeID" from "StatusType" where "Name" = 'Bank Account Status') and
"Name" = 'Pending Validation';

ALTER TABLE sms."SmsTransaction" ADD COLUMN "IsProductAdvised" BOOLEAN DEFAULT true NOT NULL;
ALTER TABLE sms."SmsTransaction" ADD COLUMN "InvoiceID" UUID;
ALTER TABLE sms."SmsTransaction" ADD COLUMN "ShoppingCartID" UUID;
ALTER TABLE sms."SmsTransaction" ADD COLUMN "ProductAdvisedOn" TIMESTAMP(0) WITH TIME ZONE;
ALTER TABLE sms."SmsTransaction" ADD COLUMN "ProductDeclinedOn" TIMESTAMP(0) WITH TIME ZONE;

ALTER TABLE sms."SmsTransaction"
  ADD CONSTRAINT "SmsTransaction_Invoice_fk" FOREIGN KEY ("InvoiceID")
    REFERENCES public."Invoice"("InvoiceID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;


ALTER TABLE sms."SmsTransaction"
  ADD CONSTRAINT "SmsTransaction_fk" FOREIGN KEY ("ShoppingCartID")
    REFERENCES public."ShoppingCart"("ShoppingCartID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;


update sms."SmsTransaction" tx set "InvoiceID" = 
(select "InvoiceID" from "Invoice" inv 
   where abs(extract(epoch from inv."CreatedOn") - extract (epoch from tx."CreatedOn")) < 2 or
    abs((extract(epoch from inv."CreatedOn")-3600) - extract (epoch from tx."CreatedOn")) < 2);



INSERT INTO public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES (70,'DeductionTypeID');
  
INSERT INTO public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES ('Sales Tax','Value Added Tax',70,true,false);


-- Deduction Template for UK
INSERT INTO
  public."DeductionTemplate"
(
  "DeductionTypeID",
  "Name",
  "Description",
  "IsActive",
  "IsDeleted",
  "IsPercentageBased",
  "DeductionTemplateVersionNumber"
)
VALUES (
  (select c."ClassificationTypeID" from "ClassificationType" c where c."ClassificationTypeCategoryID" = 70 and c."Name" = 'Sales Tax' limit 1),
  'VAT',
  'Value Added Tax',
  true,
  false,
  true,
  1
);

INSERT INTO
  public."CountryDeductionTemplate"
(
  "DeductionTemplateID",
  "CountryCode",
  "DeductionPercentage",
  "DeductionValue",
  "IsActive",
  "IsDeleted",
  "IsAppliedToAllOrders",
  "DeductionTemplateVersionNumber"
)
select
dt."DeductionTemplateID",
'UK',
0.20,
0,
true,
false,
true,
dt."DeductionTemplateVersionNumber"

  from "DeductionTemplate" dt where dt."DeductionTypeID" = (select c."ClassificationTypeID" from "ClassificationType" c where c."ClassificationTypeCategoryID" = 70 and c."Name" = 'Sales Tax' limit 1) limit 1;


-- Deduction for UK
INSERT INTO
  public."Deduction"
(
  "DeductionTypeID",
  "Name",
  "Description",
  "IsActive",
  "IsDeleted",
  "IsPercentageBased",
  "DeductionVersionNumber"
)
select
dt."DeductionTypeID",
dt."Name",
dt."Description",
true,
false,
true,
1
  from "DeductionTemplate" dt where dt."DeductionTypeID" = (select c."ClassificationTypeID" from "ClassificationType" c where c."ClassificationTypeCategoryID" = 70 and c."Name" = 'Sales Tax' limit 1) limit 1;

INSERT INTO
  public."CountryDeduction"
(
  "CountryCode",
  "DeductionPercentage",
  "DeductionValue",
  "IsActive",
  "IsDeleted",
  "IsAppliedToAllOrders",
  "DeductionID",
  "DeductionVersionNumber"
)
SELECT
  cdt."CountryCode",
  cdt."DeductionPercentage",
 cdt."DeductionValue",
  true,
  false,
  cdt."IsAppliedToAllOrders",
  d."DeductionID",
  d."DeductionVersionNumber"
FROM
  public."CountryDeductionTemplate" cdt

  left outer join "DeductionTemplate" dt on dt."DeductionTemplateID" = cdt."DeductionTemplateID" and dt."DeductionTemplateVersionNumber" = cdt."DeductionTemplateVersionNumber"
  left outer join "Deduction" d on d."DeductionTypeID" = (select c."ClassificationTypeID" from "ClassificationType" c where c."ClassificationTypeCategoryID" = 70 and c."Name" = 'Sales Tax' limit 1)
  ;


-- =================================================================================================================

--Run Operation script first

--0001 Notification
DO $$
Declare NcTID uuid;
Declare NcTVN integer;
Declare NcResID uuid;
Declare UserRoleID uuid;
Declare UserUserTypeID uuid;
Begin

NcTVN := 1;
NcTID := (select uuid_generate_v1());
NcResID := (select uuid_generate_v1());
UserRoleID := (select "RoleID" from "Role" where "RoleName" = 'User' limit 1);
UserUserTypeID := (select "UserTypeID" from "UserType" where "Name" = 'User' limit 1);

INSERT INTO
  public."NotificationConstructTemplate"
(
  "NotificationConstructTemplateID",
  "NotificationConstructTemplateVersionNumber",
  "Name",
  "Description",
  "DefaultNotificationExportFormatID",
  "DefaultNotificationDeliveryMethodID",
  "NotificationSubject",
  "NotificationTitle",
  "NotificationReference",
  "NotificationConstructMutatorObjectType",
  "CanBeIncludedInBatchNotification"
)
VALUES (
  NcTID,
  NcTVN,
  'ProductAdvised',
  'Product Advised Notification',
  4989, -- HTML
  4993, -- System
  'Important Advice From Your Conveyancer',
  'Test',
  '0001',
  'Bec.TargetFramework.SB.Notifications.Mutators.ProductAdvisedMutator, Bec.TargetFramework.SB.Notifications',
  false
);

INSERT INTO
  public."NotificationConstructTargetTemplate"
(
  "NotificationConstructTemplateID",
  "NotificationConstructTemplateVersionNumber",
  "OrganisationTypeID",
  "UserTypeID",
  "IsSingleUser",
  "IsOrganisationBranchOnly",
  "IsDefaultTarget",
  "IsActive",
  "IsDeleted"
)
VALUES (
  NcTID,
  NcTVN,
  null,
  UserUserTypeID,
  true,
  false,
  true,
  true,
  false
);

INSERT INTO
  public."NotificationConstructTargetTemplate"
(
  "NotificationConstructTemplateID",
  "NotificationConstructTemplateVersionNumber",
  "OrganisationTypeID",
  "UserTypeID",
  "IsSingleUser",
  "IsOrganisationBranchOnly",
  "IsDefaultTarget",
  "IsActive",
  "IsDeleted"
)
VALUES (
  NcTID,
  NcTVN,
  null,
  UserUserTypeID,
  true,
  false,
  true,
  true,
  false
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
  NcTID,
  NcTVN,
  E'<?xml version="1.0" encoding="utf-8" standalone="yes"?>\\015\\012<StiSerializer version="1.02" type="Net" application="StiReport">\\015\\012  <CacheAllData>True</CacheAllData>\\015\\012  <Dictionary Ref="1" type="Dictionary" isKey="true">\\015\\012    <BusinessObjects isList="true" count="2">\\015\\012      <NotificationSettingDTO Ref="2" type="Stimulsoft.Report.Dictionary.StiBusinessObject" isKey="true">\\015\\012        <Alias>NotificationSettingDTO</Alias>\\015\\012        <BusinessObjects isList="true" count="0" />\\015\\012        <Category>General</Category>\\015\\012        <Columns isList="true" count="10">\\015\\012          <value>ExportFormat,System.Nullable`1[System.Int32]</value>\\015\\012          <value>NotificationConstructID,System.Guid</value>\\015\\012          <value>NotificationConstructVersionNumber,System.Int32</value>\\015\\012          <value>NotificiationSentFromParentID,System.Guid</value>\\015\\012          <value>ServerLogoImageFileNameWithExtension,System.String</value>\\015\\012          <value>ServerNotificationImageContentURLFolder,System.String</value>\\015\\012          <value>ServerURL,System.String</value>\\015\\012          <value>LoginRoute,System.String</value>\\015\\012          <value>Subject,System.String</value>\\015\\012          <value>Title,System.String</value>\\015\\012        </Columns>\\015\\012        <Dictionary isRef="1" />\\015\\012        <Guid>af4abf77a08a413fba97a142ac3d403b</Guid>\\015\\012        <Name>NotificationSettingDTO</Name>\\015\\012      </NotificationSettingDTO>\\015\\012    </BusinessObjects>\\015\\012    <Databases isList="true" count="0" />\\015\\012    <DataSources isList="true" count="0" />\\015\\012    <Relations isList="true" count="0" />\\015\\012    <Report isRef="0" />\\015\\012    <Variables isList="true" count="1">\\015\\012      <value>General</value>\\015\\012    </Variables>\\015\\012  </Dictionary>\\015\\012  <EngineVersion>EngineV2</EngineVersion>\\015\\012  <GlobalizationStrings isList="true" count="0" />\\015\\012  <MetaTags isList="true" count="0" />\\015\\012  <Pages isList="true" count="1">\\015\\012    <Page1 Ref="4" type="Page" isKey="true">\\015\\012      <Border>None;Black;2;Solid;False;4;Black</Border>\\015\\012      <Brush>Transparent</Brush>\\015\\012      <Components isList="true" count="1">\\015\\012        <TextContent Ref="5" type="Text" isKey="true">\\015\\012          <AllowHtmlTags>True</AllowHtmlTags>\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>0,0,13.2,0.6</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Microsoft Sans Serif,11</Font>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>TextContent</Name>\\015\\012          <Page isRef="4" />\\015\\012          <Parent isRef="4" />\\015\\012          <Text>&lt;h2&gt;&lt;line-height="1.5"&gt;&lt;/line-height&gt;&lt;/h2&gt;</Text>\\015\\012          <TextBrush>[51:51:51]</TextBrush>\\015\\012          <TextQuality>Wysiwyg</TextQuality>\\015\\012          <Type>Expression</Type>\\015\\012        </TextContent>\\015\\012      </Components>\\015\\012      <Conditions isList="true" count="0" />\\015\\012      <Guid>1b83758dda4046518274d0b090f93e62</Guid>\\015\\012      <Hyperlink>#{NotificationSettingDTO.ServerURL}{NotificationSettingDTO.LoginRoute}</Hyperlink>\\015\\012      <Margins>1,1,1,1</Margins>\\015\\012      <Name>Page1</Name>\\015\\012      <PageHeight>10</PageHeight>\\015\\012      <PageWidth>17</PageWidth>\\015\\012      <Report isRef="0" />\\015\\012      <Watermark Ref="6" type="Stimulsoft.Report.Components.StiWatermark" isKey="true">\\015\\012        <Font>Arial,100</Font>\\015\\012        <TextBrush>[50:0:0:0]</TextBrush>\\015\\012      </Watermark>\\015\\012    </Page1>\\015\\012  </Pages>\\015\\012  <PrinterSettings Ref="7" type="Stimulsoft.Report.Print.StiPrinterSettings" isKey="true" />\\015\\012  <ReferencedAssemblies isList="true" count="8">\\015\\012    <value>System.Dll</value>\\015\\012    <value>System.Drawing.Dll</value>\\015\\012    <value>System.Windows.Forms.Dll</value>\\015\\012    <value>System.Data.Dll</value>\\015\\012    <value>System.Xml.Dll</value>\\015\\012    <value>Stimulsoft.Controls.Dll</value>\\015\\012    <value>Stimulsoft.Base.Dll</value>\\015\\012    <value>Stimulsoft.Report.Dll</value>\\015\\012  </ReferencedAssemblies>\\015\\012  <ReportAlias>Report</ReportAlias>\\015\\012  <ReportChanged>2/3/2016 10:33:40 AM</ReportChanged>\\015\\012  <ReportCreated>9/29/2014 8:17:02 AM</ReportCreated>\\015\\012  <ReportFile>ProductAdvised.mrt</ReportFile>\\015\\012  <ReportGuid>2c080c97d28641b18c563245d1a76f2a</ReportGuid>\\015\\012  <ReportName>Report</ReportName>\\015\\012  <ReportUnit>Centimeters</ReportUnit>\\015\\012  <ReportVersion>2015.1.8</ReportVersion>\\015\\012  <Script>using System;\\015\\012using System.Drawing;\\015\\012using System.Windows.Forms;\\015\\012using System.Data;\\015\\012using Stimulsoft.Controls;\\015\\012using Stimulsoft.Base.Drawing;\\015\\012using Stimulsoft.Report;\\015\\012using Stimulsoft.Report.Dialogs;\\015\\012using Stimulsoft.Report.Components;\\015\\012\\015\\012namespace Reports\\015\\012{\\015\\012    public class Report : Stimulsoft.Report.StiReport\\015\\012    {\\015\\012        public Report()        {\\015\\012            this.InitializeComponent();\\015\\012        }\\015\\012\\015\\012        #region StiReport Designer generated code - do not modify\\015\\012\\011\\011#endregion StiReport Designer generated code - do not modify\\015\\012    }\\015\\012}\\015\\012</Script>\\015\\012  <ScriptLanguage>CSharp</ScriptLanguage>\\015\\012  <Styles isList="true" count="0" />\\015\\012</StiSerializer>\\015\\012',
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
  NcTID,
  NcTVN,
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
  NcTID,
  NcTVN,
  'ProductAdvisedNotificationDTO',
  'Bec.TargetFramework.Entities.DTO.Notification.ProductAdvisedNotificationDTO, Bec.TargetFramework.Entities',
  'ProductAdvisedNotificationDTO',
  'Bec.TargetFramework.Entities.DTO.Notification',
  'Bec.TargetFramework.Entities',
  true,
  true,
  false,
  true,
  'General'
);

INSERT INTO
  public."Resource"
(
  "ResourceID",
  "ResourceName",
  "ResourceDescription",
  "IsActive",
  "IsDeleted",
  "ParentID",
  "ResourceTypeID"
)
VALUES (
  NcResID,
  'ProductAdvised',
  'ProductAdvised Notification Resource',
  true,
  false,
  null,
  123 -- Notification
);

-- Operations for Notification View/Edit/Send/Configure/MarkAsRead/MarkAsUnRead/Edit MUST EXIST FIRST
-- OrganisationTypeId = 31 - Professional
-- NotificationConstructClaimTemplate for OrgEmployee - View
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
  NcTID,
  NcTVN,
  null,
  NcResID,
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1),
  null,
  null,
  true,
  false,
  UserRoleID
);

INSERT INTO
  public."ResourceOperationTarget"("ResourceID", "OperationID", "OrganisationTypeID", "UserTypeID")
VALUES
  (NcResID,(select "OperationID" from "Operation" where "OperationName" = 'View' limit 1),31,UserUserTypeID);

-- NotificationConstructClaimTemplate for OrgEmployee - MarkAsRead
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
  NcTID,
  NcTVN,
  null,
  NcResID,
  (select "OperationID" from "Operation" where "OperationName" = 'MarkAsRead' limit 1),
  null,
  null,
  true,
  false,
  UserRoleID
);

INSERT INTO
  public."ResourceOperationTarget"("ResourceID", "OperationID", "OrganisationTypeID", "UserTypeID")
VALUES
  (NcResID,(select "OperationID" from "Operation" where "OperationName" = 'MarkAsRead' limit 1),31,UserUserTypeID);

-- NotificationConstructClaimTemplate for OrgEmployee - MarkAsUnread
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
  NcTID,
  NcTVN,
  null,
  NcResID,
  (select "OperationID" from "Operation" where "OperationName" = 'MarkAsUnread' limit 1),
  null,
  null,
  true,
  false,
  UserRoleID
);

INSERT INTO
  public."ResourceOperationTarget"("ResourceID", "OperationID", "OrganisationTypeID", "UserTypeID")
VALUES
  (NcResID,(select "OperationID" from "Operation" where "OperationName" = 'MarkAsUnread' limit 1),31,UserUserTypeID);

-- NotificationConstructClaimTemplate for OrgEmployee - Send
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
  NcTID,
  NcTVN,
  null,
  NcResID,
  (select "OperationID" from "Operation" where "OperationName" = 'Send' limit 1),
  null,
  null,
  true,
  false,
  UserRoleID
);

INSERT INTO
  public."ResourceOperationTarget"("ResourceID", "OperationID", "OrganisationTypeID", "UserTypeID")
VALUES
  (NcResID,(select "OperationID" from "Operation" where "OperationName" = 'Send' limit 1),31,UserUserTypeID);

-- NotificationConstructClaimTemplate for OrgEmployee - Configure
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
  NcTID,
  NcTVN,
  null,
  NcResID,
  (select "OperationID" from "Operation" where "OperationName" = 'Configure' limit 1),
  null,
  null,
  true,
  false,
  UserRoleID
);

INSERT INTO
  public."ResourceOperationTarget"("ResourceID", "OperationID", "OrganisationTypeID", "UserTypeID")
VALUES
  (NcResID,(select "OperationID" from "Operation" where "OperationName" = 'Configure' limit 1),31,UserUserTypeID);

-- NotificationConstructClaimTemplate for OrgEmployee - Edit
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
  NcTID,
  NcTVN,
  null,
  NcResID,
  (select "OperationID" from "Operation" where "OperationName" = 'Edit' limit 1),
  null,
  null,
  true,
  false,
  UserRoleID
);

INSERT INTO
  public."ResourceOperationTarget"("ResourceID", "OperationID", "OrganisationTypeID", "UserTypeID")
VALUES
  (NcResID,(select "OperationID" from "Operation" where "OperationName" = 'Edit' limit 1),31,UserUserTypeID);

-- Add to DOT for specific org type

-- DefaultOrganisationNotificationConstructTemplate
INSERT INTO
  public."DefaultOrganisationNotificationConstructTemplate"
(
  "DefaultOrganisationTemplateID",
  "NotificationConstructTemplateID",
  "NotificationConstructTemplateVersionNumber",
  "ParentID",
  "DefaultOrganisationTemplateVersionNumber"
)
VALUES (
  (select "DefaultOrganisationTemplateID" from "DefaultOrganisationTemplate" where "Name" = 'Personal Organisation' limit 1),
  NcTID,
  NcTVN,
  null,
  (select "DefaultOrganisationTemplateVersionNumber" from "DefaultOrganisationTemplate" where "Name" = 'Personal Organisation' limit 1)
);


-- Promotes all notification templates to main tables
PERFORM

(SELECT count(*) FROM "fn_PromoteNotificationConstructTemplate"(nct."NotificationConstructTemplateID",1))

from "NotificationConstructTemplate" nct

where not exists (select * from "NotificationConstruct" nc where nc."NotificationConstructTemplateID" = nct."NotificationConstructTemplateID"
	and nc."NotificationConstructTemplateVersionNumber" = nct."NotificationConstructTemplateVersionNumber")
;


END $$;


-- ADD MISSING ENTRIES IN OrganisationRoleClaim
DO $$
DECLARE
     entries CURSOR FOR
         SELECT '
          INSERT INTO
            public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", "OrganisationID")
          SELECT
            nc."OrganisationRoleID",
            ncc."ResourceID",
            ncc."OperationID",
            ncc."StateID",
            ncc."StateItemID",
            ncc."IsActive",
            ncc."IsDeleted",
            ''' || o."OrganisationID" || '''
          FROM
            public."NotificationConstructClaim" ncc
            inner join "OrganisationRole" nc on nc."OrganisationID" = ''' || o."OrganisationID" || ''' and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and nc."IsDeleted" = false
            join "Resource" r on ncc."ResourceID" = r."ResourceID"
          where
            r."ResourceName" LIKE ''ProductAdvised'' AND
            ncc."IsActive" = true and
            ncc."IsDeleted" = false and
            not exists (
                         select
                           orc."OrganisationRoleClaimID"
                         from
                           "OrganisationRoleClaim" orc
                         where
                           orc."OrganisationID" = ''' || o."OrganisationID" || ''' and
                           orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                           orc."OperationID" = ncc."OperationID" and
                           orc."ResourceID" = ncc."ResourceID"
            ) and
            ncc."NotificationRoleConstructID" is null;' AS sql
FROM "Organisation" o;
BEGIN
   FOR entry IN entries LOOP
      EXECUTE entry.sql;
      raise notice '%', entry.sql;
   END LOOP;
END $$;


-- =========================================================================================================


ALTER TABLE public."OrganisationTradingName" ALTER COLUMN "OrganisationTradingNameID" TYPE UUID using null;
ALTER TABLE public."OrganisationTradingName" ALTER COLUMN "OrganisationTradingNameID" SET DEFAULT uuid_generate_v1();

INSERT INTO public."OrganisationType" ("OrganisationTypeID", "Name", "Description", "IsActive", "IsDeleted")
VALUES (37, E'MortgageBroker', E'Mortgage Broker', True, False);

INSERT INTO public."OrganisationType" ("OrganisationTypeID", "Name", "Description", "IsActive", "IsDeleted")
VALUES (38, E'Lender', E'Lender', True, False);

ALTER TABLE public."Organisation" ADD COLUMN "BrokerType" INTEGER;
ALTER TABLE public."Organisation" ADD COLUMN "BrokerBusinessType" INTEGER;

drop view public."vOrganisationWithStatusAndAdmin";

CREATE VIEW public."vOrganisationWithStatusAndAdmin" (
    "OrganisationID",
    "Name",
    "CreatedOn",
    "CreatedBy",
    "OrganisationVerified",
    "PinCreated",
    "PinCode",
    "OrganisationAdminSalutation",
    "OrganisationAdminFirstName",
    "OrganisationAdminLastName",
    "OrganisationAdminTelephone",
    "OrganisationAdminEmail",
    "Regulator",
    "RegulatorOther",
    "RegulatorNumber",
    "Line1",
    "Line2",
    "Town",
    "County",
    "PostalCode",
    "AdditionalAddressInformation",
    "StatusTypeID",
    "StatusTypeValueID",
    "StatusTypeVersionNumber",
    "OrganisationAdminUserID",
    "StatusValueName",
    "StatusChangedOn",
    "StatusChangedBy",
    "Reason",
    "Notes",
    "OrganisationAdminCreated",
    "VerifiedOn",
    "VerifiedBy",
    "VerifiedNotes",
    "UserAccountOrganisationID",
    "RegisteredAsName",
    "OrganisationRecommendationSourceID",
    "SchemeID",
    "FilesPerMonth",
    "ActiveSafeAccounts",
    "OrganisationTypeDescription",
    "BrokerType",
    "BrokerBusinessType")
AS
SELECT org."OrganisationID",
    orgd."Name",
    org."CreatedOn",
    org."CreatedBy",
        CASE
            WHEN vst."Name"::text = 'Verified'::text THEN true
            ELSE false
        END AS "OrganisationVerified",
    uao."PinCreated",
    uao."PinCode",
    uaoc."Salutation" AS "OrganisationAdminSalutation",
    uaoc."FirstName" AS "OrganisationAdminFirstName",
    uaoc."LastName" AS "OrganisationAdminLastName",
    uaoc."Telephone1" AS "OrganisationAdminTelephone",
    ua."Email" AS "OrganisationAdminEmail",
    conreg."RegulatorName" AS "Regulator",
    conreg."RegulatorOtherName" AS "RegulatorOther",
    conreg."RegulatorNumber",
    addr."Line1",
    addr."Line2",
    addr."Town",
    addr."County",
    addr."PostalCode",
    addr."AdditionalAddressInformation",
    vorgs."StatusTypeID",
    vorgs."StatusTypeValueID",
    vorgs."StatusTypeVersionNumber",
    ua."ID" AS "OrganisationAdminUserID",
    vorgs."StatusValueName",
    vorgs."StatusChangedOn",
    vorgs."StatusChangedBy",
    vorgs."Reason",
    vorgs."Notes",
    ua."Created" AS "OrganisationAdminCreated",
    verifiedstatus."StatusChangedOn" AS "VerifiedOn",
    verifiedstatus."StatusChangedBy" AS "VerifiedBy",
    verifiedstatus."Notes" AS "VerifiedNotes",
    uao."UserAccountOrganisationID",
    orgd."RegisteredAsName",
    org."OrganisationRecommendationSourceID",
    org."SchemeID",
    org."FilesPerMonth",
    COALESCE(sb."ActiveSafeAccounts", 0::bigint) AS "ActiveSafeAccounts",
    orgt."Description" AS "OrganisationTypeDescription",
    org."BrokerType",
    org."BrokerBusinessType"
FROM "Organisation" org
     LEFT JOIN "OrganisationDetail" orgd ON orgd."OrganisationID" = org."OrganisationID"
     LEFT JOIN "OrganisationType" orgt ON orgt."OrganisationTypeID" =
         org."OrganisationTypeID"
     LEFT JOIN "vOrganisationStatus" vorgs ON vorgs."OrganisationID" =
         org."OrganisationID"
     LEFT JOIN "vStatusType" vst ON vst."StatusTypeID" = vorgs."StatusTypeID"
         AND vst."StatusTypeValueID" = vorgs."StatusTypeValueID" AND vst."StatusTypeVersionNumber" = vorgs."StatusTypeVersionNumber"
     LEFT JOIN "UserAccountOrganisation" uao ON uao."OrganisationID" =
         org."OrganisationID" AND uao."UserTypeID" = ((
    SELECT ut."UserTypeID"
    FROM "UserType" ut
    WHERE ut."Name"::text = 'Organisation Administrator'::text
    LIMIT 1
    ))
     LEFT JOIN "Contact" orgc ON orgc."ParentID" = org."OrganisationID" AND
         orgc."IsPrimaryContact" = true
     LEFT JOIN "Contact" uaoc ON uaoc."ParentID" =
         uao."UserAccountOrganisationID" AND uaoc."IsPrimaryContact" = true
     LEFT JOIN "UserAccounts" ua ON ua."ID" = uao."UserID"
     LEFT JOIN "Address" addr ON addr."ParentID" = orgc."ContactID" AND
         addr."IsPrimaryAddress" = true
     LEFT JOIN "ContactRegulator" conreg ON conreg."ContactID" = orgc."ContactID"
     LEFT JOIN (
    SELECT os."OrganisationID",
            os."StatusTypeID",
            os."StatusTypeValueID",
            os."StatusTypeVersionNumber",
            max(os."StatusChangedOn") AS "StatusChangedOn"
    FROM "OrganisationStatus" os
             JOIN "StatusType" st ON st."StatusTypeID" = os."StatusTypeID" AND
                 st."Name"::text = 'Professional Organisation Status'::text
             JOIN "StatusTypeValue" sv ON sv."StatusTypeID" = os."StatusTypeID"
                 AND sv."StatusTypeValueID" = os."StatusTypeValueID" AND sv."Name"::text = 'Verified'::text
    WHERE os."StatusTypeVersionNumber" = 1
    GROUP BY os."OrganisationID", os."StatusTypeID", os."StatusTypeValueID",
        os."StatusTypeVersionNumber"
    ) verifiedjoin ON verifiedjoin."OrganisationID" = org."OrganisationID"
     LEFT JOIN "OrganisationStatus" verifiedstatus ON
         verifiedstatus."OrganisationID" = verifiedjoin."OrganisationID" AND verifiedstatus."StatusTypeID" = verifiedjoin."StatusTypeID" AND verifiedstatus."StatusTypeValueID" = verifiedjoin."StatusTypeValueID" AND verifiedstatus."StatusTypeVersionNumber" = verifiedjoin."StatusTypeVersionNumber" AND verifiedstatus."StatusChangedOn" = verifiedjoin."StatusChangedOn"
     LEFT JOIN (
    SELECT ba."OrganisationID",
            count(ba."OrganisationBankAccountID") AS "ActiveSafeAccounts"
    FROM "OrganisationBankAccount" ba
    WHERE ba."IsActive" = true AND (((
        SELECT st."Name"
        FROM "OrganisationBankAccountStatus" s
                     LEFT JOIN "StatusTypeValue" st ON st."StatusTypeID" =
                         s."StatusTypeID" AND st."StatusTypeValueID" = s."StatusTypeValueID"
        WHERE s."OrganisationBankAccountID" = ba."OrganisationBankAccountID"
        ORDER BY s."StatusChangedOn" DESC
        LIMIT 1
        ))::text) = 'Safe'::text
    GROUP BY ba."OrganisationID"
    ) sb ON sb."OrganisationID" = org."OrganisationID"
WHERE (orgt."Name"::text <> ALL (ARRAY['Temporary'::character varying::text,
    'Personal'::character varying::text, 'Administration'::character varying::text, 'Supplier'::character varying::text])) AND orgc."ContactID" IS NOT NULL AND (ua."IsDeleted" IS NULL OR ua."IsDeleted" = false);

GRANT SELECT, INSERT, UPDATE, DELETE ON public."vOrganisationWithStatusAndAdmin" TO bef;

 -- object recreation
DROP FUNCTION public."fn_CreateOrganisationFromDefault"(organisationtypeid integer, defaultorganisationid uuid, organisationversionnumber integer, organisationname varchar, tradingname varchar, organisationdescription varchar, createdby varchar, organisationrecommendationsourceid integer);

CREATE FUNCTION public."fn_CreateOrganisationFromDefault" (
  organisationtypeid integer,
  defaultorganisationid uuid,
  organisationversionnumber integer,
  organisationname varchar,
  tradingname varchar,
  organisationdescription varchar,
  createdby varchar,
  organisationrecommendationsourceid integer,
  brokertype integer,
  brokerbusinesstype integer
)
RETURNS uuid AS
$body$
Declare
  OrganisationID uuid;
  SchemeID integer;
  LoopRow RECORD;
begin
  OrganisationID := uuid_generate_v1();
  
  SchemeID := NULL;
  if(organisationtypeid <> 29) then
    begin  
      SchemeID := trunc(random() * 89999) + 10000;
      while exists (select "OrganisationID" from "Organisation" where "SchemeID" = SchemeID)
      loop
        SchemeID := trunc(random() * 89999) + 10000;
      end loop;
    end;
  end if;
  
  -- If no defaultorgid then determine from orgtypeid
  if(defaultorganisationid is null) then
    Begin
      defaultorganisationid := (
      select
        DOrg."DefaultOrganisationID"
      from
        "DefaultOrganisation" DOrg
        inner join "DefaultOrganisationTarget" DOT on DOrg."DefaultOrganisationVersionNumber" = DOT."DefaultOrganisationVersionNumber" and 

DOrg."DefaultOrganisationID" = DOT."DefaultOrganisationID"
          and DOT."OrganisationTypeID" = organisationtypeid
      limit
        1);
    End;
  End if;

  -- create new organisation

  INSERT INTO
    "Organisation"("OrganisationID", "IsBranch", "IsHeadOffice", "IsActive", "IsDeleted", "IsUserOrganisation", "DefaultOrganisationID", 

"DefaultOrganisationVersionNumber", "OrganisationTypeID", "CreatedBy", "OrganisationRecommendationSourceID", "SchemeID", "BrokerType", "BrokerBusinessType")
  SELECT
    OrganisationID,
    False,
    False,
    True,
    False,
    False,
    defaultorganisationid,
    organisationversionnumber,
    wt."OrganisationTypeID",
    createdby,
    organisationrecommendationsourceid,
    SchemeID,
    brokertype,
    brokerbusinesstype
  FROM
    public."DefaultOrganisation" wt
  where
    wt."DefaultOrganisationID" = defaultorganisationid and
    wt."DefaultOrganisationVersionNumber" = organisationversionnumber;

  -- add org default

  INSERT INTO
    public."OrganisationDetail"("OrganisationID", "Name", "Description", "RegisteredAsName")
  VALUES
    (OrganisationID, organisationname, organisationdescription, tradingname);
 
  -- add payment methods
  INSERT INTO
  public."OrganisationPaymentMethod"
(
  "OrganisationID",
  "GlobalPaymentMethodID",
  "OrganisationBankAccountID",
  "IsActive",
  "IsDeleted",
  "IsDirectDebit",
  "IsBACS",
  "OrganisationDirectDebitMandateID",
  "IsPrimary",
  "StatusTypeID",
  "StatusTypeVersionNumber",
  "StatusTypeValueID",
  "DirectDebitMonthCollectionPeriodNumber",
  "BACSMonthPaymentDay",
  "DirectDebitNumberOfNotificationDaysBeforeCollection",
  "BACSNumberOfNotificationDaysBeforeExpectationOfPayment"
)
SELECT
  OrganisationID,
  wt."GlobalPaymentMethodID",
  null,
  true,
  false,
  pm."IsDirectDebit",
  (case when pm."IsDirectDebit" = false and pm."Name" <> 'BACS' then false else true end),
  null,
  (case when pm."Name" = 'BACS' then true else false end),
  st."StatusTypeID",
  st."StatusTypeVersionNumber",
  st."StatusTypeValueID",
  pm."DirectDebitDefaultMonthlyPeriodNumber",
  pm."BACSDefaultMonthlyPaymentDay",
  pm."DirectDebitDefaultNumberOfNotificationDaysBeforeCollection",
  pm."BACSDefaultNumberOfNotificationDaysBeforeExpectationOfPayment"
FROM
  public."DefaultOrganisationPaymentMethod" wt
 
  left outer join "GlobalPaymentMethod" pm on pm."GlobalPaymentMethodID" = wt."GlobalPaymentMethodID"
  left outer join "vStatusType" st on st."StatusTypeName" = 'OrganisationPaymentMethod Status' and st."IsStart" = true
                                              
 
  where wt."DefaultOrganisationID" = defaultorganisationid and wt."DefaultOrganisationVersionNumber" = organisationversionnumber
  and not exists (select * from "OrganisationPaymentMethod" dd where dd."OrganisationID" = OrganisationID and dd."GlobalPaymentMethodID" = 

wt."GlobalPaymentMethodID" limit 1)
  ;
 
-- add base financials
INSERT INTO
  public."OrganisationFinancialDetail"
(
  "OrganisationID",
  "FinancialStatusTypeID",
  "FinancialStatusTypeVersionNumber",
  "FinancialStatusTypeValueID",
  "HasACreditLimit",
  "CreditLimit",
  "NumberOfLatePayments",
  "HasLatePayments"
)
VALUES (
  OrganisationID,
  (select "StatusTypeID" from "vStatusType" st where st."StatusTypeName" = 'OrganisationFinancial Status' and st."IsStart" = true limit 1),
  (select "StatusTypeVersionNumber" from "vStatusType" st where st."StatusTypeName" = 'OrganisationFinancial Status' and st."IsStart" = true 

limit 1),
  (select "StatusTypeValueID" from "vStatusType" st where st."StatusTypeName" = 'OrganisationFinancial Status' and st."IsStart" = true limit 

1),
  false,
  0,
  0,
  false
);


-- add accounting periods
INSERT INTO
  public."OrganisationAccountingPeriod"
(
  "OrganisationID",
  "GlobalAccountingPeriodID"
)
SELECT
  OrganisationID,
  wt."GlobalAccountingPeriodID"
FROM
  public."GlobalAccountingPeriod" wt
 
  where not exists (select * from "OrganisationAccountingPeriod" gp where gp."OrganisationID" = OrganisatioNID and 

gp."GlobalAccountingPeriodID" = wt."GlobalAccountingPeriodID" limit 1)
  ;
 
INSERT INTO
  public."OrganisationLedgerAccount"
(
  "LedgerAccountTypeID",
  "LedgerAccountCategoryID",
  "Name",
  "Description",
  "ParentID",
  "CreatedOn",
  "CreatedBy",
  "Balance",
  "HandlesCredit",
  "HandlesDebit",
  "OpenedOn",
  "IsActive",
  "IsDeleted",
  "OrganisationID",
  "AccountingTypeID"
)
SELECT
  wt."LedgerAccountTypeID",
  null,
  wt."LedgerAccountName",
  '',
  null,
  CURRENT_DATE,
  'System',
  0,
  wt."HandlesCredit",
  wt."HandlesDebit",
  CURRENT_DATE,
  true,
  false,
  OrganisationID,
  0
FROM
  public."DefaultOrganisationLedger" wt
  where
    wt."DefaultOrganisationID" = defaultorganisationid and
    wt."DefaultOrganisationVersionNumber" = organisationversionnumber
   
    and not exists(select * from "OrganisationLedgerAccount" le where le."LedgerAccountTypeID" = wt."LedgerAccountTypeID" and 

le."OrganisationID" = OrganisationID limit 1);



  -- create organisationroles which are not default organisation specific nad global, could be duplicates

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "RoleDescription", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID", "IsDefault")
  select
    OrganisationID,
    r."RoleName",
    r."RoleDescription",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID",
    coalesce(dr."IsDefault", false)
  from
    "Role" r left join "DefaultOrganisationRole" dr on dr."DefaultOrganisationID" = defaultorganisationid and dr."RoleID" = r."RoleID"
  where
    r."RoleID" in (
                    select
                      dor."RoleID"
                    from
                      "DefaultOrganisationRole" dor
                    where
                      dor."DefaultOrganisationID" = defaultorganisationid and
                      dor."IsActive" = true and
                      dor."IsDeleted" = false and
                      COALESCE(dor."IsDefaultOrganisationSpecific", false) = false
    ) and
    r."RoleID" not in (
                        select
                          org."ParentID"
                        from
                          "OrganisationRole" org
                        where
                          org."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false and
    r."IsGlobal" = true;

  -- add roleclaims which are not default organisation specific, parentID is RoleID, and are global roles

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
    OrganisationID
  from
    "RoleClaim" rc
    inner join "OrganisationRole" org on org."OrganisationID" = OrganisationID and org."IsActive" = true and org."IsDeleted" = false and 

org."ParentID" = rc."RoleID"
  where
    rc."RoleID" =
    (
      select
        orgr."ParentID"
      from
        "OrganisationRole" orgr
      where
        orgr."OrganisationRoleID" = org."OrganisationRoleID"
    ) and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = org."OrganisationRoleID" and
                   orc."OperationID" = rc."OperationID" and
                   orc."ResourceID" = rc."ResourceID" and
                   orc."StateID" = rc."StateID" and
                   orc."StateItemID" = rc."StateItemID"
    );

  -- add do specific roles

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "RoleDescription", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID", "IsDefault")
  select
    OrganisationID,
    dor."RoleName",
    r."RoleDescription",
    true,
    dor."RoleTypeID",
    true,
    false,
    dor."DefaultOrganisationRoleID",
    dor."IsDefault"
  from
    "DefaultOrganisationRole" dor join "Role" r on r."RoleID" = dor."RoleID"
  where
    dor."IsActive" = true and
    dor."IsDeleted" = false and
    dor."IsDefaultOrganisationSpecific" = true and
    dor."DefaultOrganisationID" = defaultorganisationid and
    dor."DefaultOrganisationRoleID" not in (
                                             select
                                               dor1."ParentID"
                                             from
                                               "OrganisationRole" dor1
                                             where
                                               dor1."OrganisationID" = OrganisationID
    );

  -- add do specific claims

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
    OrganisationID
  from
    "DefaultOrganisationRoleClaim" rc
    inner join "OrganisationRole" org on org."OrganisationID" = OrganisationID and org."ParentID" = rc."DefaultOrganisationRoleID" and 

org."IsActive" = true and org."IsDeleted" = FALSE
  where
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = org."OrganisationRoleID" and
                   orc."OperationID" = rc."OperationID" and
                   orc."ResourceID" = rc."ResourceID" and
                   orc."StateID" = rc."StateID" and
                   orc."StateItemID" = rc."StateItemID"
    );

  -- add global groups
  -- create organisationroles which are not default organisation specific and global

  insert into
    public."OrganisationGroup"("OrganisationID", "GroupName", "IsManaged", "GroupTypeID", "IsActive", "IsDeleted", "ParentID")
  select
    OrganisationID,
    r."GroupName",
    true,
    r."GroupTypeID",
    true,
    false,
    r."GroupID"
  from
    "Group" r
  where
    r."GroupID" in (
                     select
                       dor."GroupID"
                     from
                       "DefaultOrganisationGroup" dor
                     where
                       dor."DefaultOrganisationID" = defaultorganisationid and
                       dor."IsActive" = true and
                       dor."IsDeleted" = false and
                       COALESCE(dor."IsDefaultOrganisationSpecific", false) = false
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false and
    r."IsGlobal" = true and
    r."GroupID" not in (
                         select
                           rg."ParentID"
                         from
                           "OrganisationGroup" rg
                         where
                           rg."OrganisationID" = OrganisationID
    );

  -- add global group roles

  insert into
    "OrganisationGroupRole"("OrganisationGroupID", "OrganisationRoleID", "IsActive", "IsDeleted")
  select
    org."OrganisationGroupID",
    orgr."OrganisationRoleID",
    true,
    false
  from
    "GroupRole" rc
    inner join "OrganisationGroup" org on org."OrganisationID" = OrganisationID and org."ParentID" = rc."GroupID" and org."IsActive" = true and 

org."IsDeleted" = false
    inner join "OrganisationRole" orgr on orgr."OrganisationID" = OrganisationID and orgr."ParentID" = rc."RoleID" and orgr."IsActive" = true 

and orgr."IsDeleted" = false
  where
    rc."GroupID" =
    (
      select
        orgr."ParentID"
      from
        "OrganisationGroup" orgr
      where
        orgr."OrganisationGroupID" = org."OrganisationGroupID"
    );

  -- add do specific groups

  insert into
    public."OrganisationGroup"("OrganisationID", "GroupName", "IsManaged", "GroupTypeID", "IsActive", "IsDeleted", "ParentID")
  select
    OrganisationID,
    dor."GroupName",
    true,
    dor."GroupTypeID",
    true,
    false,
    dor."DefaultOrganisationGroupID"
  from
    "DefaultOrganisationGroup" dor
  where
    dor."IsActive" = true and
    dor."IsDeleted" = false and
    dor."IsDefaultOrganisationSpecific" = true and
    dor."DefaultOrganisationID" = defaultorganisationid and
    dor."DefaultOrganisationGroupID" not in (
                                              select
                                                dor1."ParentID"
                                              from
                                                "OrganisationGroup" dor1
                                              where
                                                dor1."OrganisationID" = OrganisationID
    );

  -- add do specific group roles

  insert into
    "OrganisationGroupRole"("OrganisationGroupID", "OrganisationRoleID", "IsActive", "IsDeleted")
  select
    org."OrganisationGroupID",
    orr."OrganisationRoleID",
    true,
    false
  from
    "DefaultOrganisationGroupRole" rc
    inner join "OrganisationGroup" org on org."OrganisationID" = OrganisationID and org."ParentID" = rc."DefaultOrganisationGroupID" and 

org."IsActive" = true and org."IsDeleted" = false
    left join "OrganisationRole" orr on orr."ParentID" = rc."DefaultOrganisationRoleID" and orr."IsActive" = true and orr."IsDeleted" = false 

and orr."OrganisationID" = OrganisationID
  where
    rc."DefaultOrganisationGroupID" =
    (
      select
        orgr."ParentID"
      from
        "OrganisationGroup" orgr
      where
        orgr."OrganisationGroupID" = org."OrganisationGroupID"
    );

  -- Organisation NC /  ROLE / CLAIM

/*  INSERT INTO
    public."OrganisationNotificationConstruct"("NotificationConstructID", "NotificationConstructVersionNumber", "IsActive", "IsDeleted", 

"OrganisationID", "ParentID")
  SELECT
    "NotificationConstructID",
    "NotificationConstructVersionNumber",
    true,
    false,
    OrganisationID,
    "DefaultOrganisationNotificationConstructID"
  FROM
    public."DefaultOrganisationNotificationConstruct"
  where
    "DefaultOrganisationID" = defaultorganisationid;*/

  -- NC Roles

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    ncr."RoleName",
    true,
    ncr."RoleSubTypeID",
    true,
    false,
    ncr."NotificationRoleConstructID"
  FROM
    public."NotificationConstructRole" ncr
    inner join "DefaultOrganisationNotificationConstruct" donc on donc."NotificationConstructID" = ncr."NotificationConstructID" and 

donc."NotificationConstructVersionNumber" =
      ncr."NotificationConstructVersionNumber" and donc."IsActive" = true and donc."IsDeleted" = false and donc."DefaultOrganisationID" = 

defaultorganisationid
  where
    ncr."IsActive" = true and
    ncr."IsDeleted" = false and
    ncr."NotificationRoleConstructID" not in (
                                               select
                                                 orn."ParentID"
                                               from
                                                 "OrganisationRole" orn
                                               where
                                                 orn."OrganisationID" = OrganisationID
    );

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA NC CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "NotificationConstructClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID"
    inner join "DefaultOrganisationNotificationConstruct" donc on donc."NotificationConstructID" = ncc."NotificationConstructID" and 

donc."NotificationConstructVersionNumber" =
      ncc."NotificationConstructVersionNumber" and donc."IsActive" = true and donc."IsDeleted" = false and donc."DefaultOrganisationID" = 

defaultorganisationid
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false and
    ncc."NotificationRoleConstructID" is null;

  -- NC CLAIMS THAT ARE DIRECT FROM NC ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."NotificationConstructClaim" ncc
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."NotificationRoleConstructID" and 

nc."IsActive" = true and nc."IsDeleted" = false and
      ncc."IsActive" = true and ncc."IsDeleted" = false and ncc."RoleID" is null and not exists (
                                                                                                  select
                                                                                                    orc."OrganisationRoleClaimID"
                                                                                                  from
                                                                                                    "OrganisationRoleClaim" orc
                                                                                                  where
                                                                                                    orc."OrganisationID" = OrganisationID and
                                                                                                    orc."OrganisationRoleID" = 

nc."OrganisationRoleID" and
                                                                                                    orc."OperationID" = ncc."OperationID" and
                                                                                                    orc."ResourceID" = ncc."ResourceID" and
                                                                                                    orc."StateID" = ncc."StateID" and
                                                                                                    orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA NC CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."NotificationConstructClaim" ncc
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."NotificationRoleConstructID" is null;

  ----------------------- Artefact
  -- Org Artefact

  INSERT INTO
    public."OrganisationArtefact"("OrganisationID", "ArtefactID", "ArtefactVersionNumber", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    "ArtefactID",
    "ArtefactVersionNumber",
    "IsActive",
    "IsDeleted",
    "ArtefactID"
  FROM
    public."DefaultOrganisationArtefact"
  where
    "DefaultOrganisationID" = defaultorganisationid and
    "IsActive" = true and
    "IsDeleted" = false;

  -- Artefact Specific Roles

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    ncr."RoleName",
    true,
    ncr."RoleTypeID",
    true,
    false,
    ncr."ArtefactRoleID"
  FROM
    public."ArtefactRole" ncr
    inner join "DefaultOrganisationArtefact" donc on donc."ArtefactID" = ncr."ArtefactID" and donc."ArtefactVersionNumber" = 

ncr."ArtefactVersionNumber" and donc."IsActive" = true and donc."IsDeleted"
      = false and donc."DefaultOrganisationID" = defaultorganisationid
  where
    ncr."IsActive" = true and
    ncr."IsDeleted" = false and
    ncr."ArtefactRoleID" not in (
                                  select
                                    orn."ParentID"
                                  from
                                    "OrganisationRole" orn
                                  where
                                    orn."OrganisationID" = OrganisationID
    );

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA NC CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "ArtefactClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID"
    inner join "DefaultOrganisationArtefact" donc on donc."ArtefactID" = ncc."ArtefactID" and donc."ArtefactVersionNumber" = 

ncc."ArtefactVersionNumber" and donc."IsActive" = true and donc."IsDeleted"
      = false and donc."DefaultOrganisationID" = defaultorganisationid
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false and
    ncc."ArtefactRoleID" is null;

  -- ARTEFACT CLAIMS THAT ARE DIRECT FROM ARTEFACT ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."ArtefactClaim" ncc
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."ArtefactRoleID" and nc."IsActive" = true 

and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA NC CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."ArtefactClaim" ncc
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."ArtefactRoleID" is null;

  -------------------------- MODULE

  -- Module Specific Roles

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    ncr."RoleName",
    true,
    ncr."RoleTypeID",
    true,
    false,
    ncr."RoleID"
  FROM
    public."ModuleRole" ncr
    inner join "DefaultOrganisationModule" donc on donc."ModuleID" = ncr."ModuleID" and donc."ModuleVersionNumber" = ncr."ModuleVersionNumber" 

and donc."IsActive" = true and donc."IsDeleted" = false
      and donc."DefaultOrganisationID" = defaultorganisationid
  where
    ncr."IsActive" = true and
    ncr."IsDeleted" = false and
    ncr."RoleID" not in (
                          select
                            orn."ParentID"
                          from
                            "OrganisationRole" orn
                          where
                            orn."OrganisationID" = OrganisationID
    );

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA MODULE CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "ModuleClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID"
    inner join "DefaultOrganisationModule" donc on donc."ModuleID" = ncc."ModuleID" and donc."ModuleVersionNumber" = ncc."ModuleVersionNumber" 

and donc."IsActive" = true and donc."IsDeleted" = false
      and donc."DefaultOrganisationID" = defaultorganisationid
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false and
    ncc."ModuleRoleID" is null;

  -- Module CLAIMS THAT ARE DIRECT FROM Module ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."ModuleClaim" ncc
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."ModuleRoleID" and nc."IsActive" = true 

and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA MODULE CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."ModuleClaim" ncc
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."ModuleRoleID" is null;

  ----------------------------------- WORKFLOW
/*
  INSERT INTO
    public."OrganisationWorkflow"("OrganisationID", "WorkflowID", "VersionNumber", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    "WorkflowID",
    "WorkflowVersionNumber",
    "IsActive",
    "IsDeleted",
    dow . "DefaultOrganisationID"
  FROM
    public."DefaultOrganisationWorkflow" dow
  where
    dow . "DefaultOrganisationID" = defaultorganisationid and
    dow . "IsActive" = true and
    dow . "IsDeleted" = FALSE and
    not exists (
                 select
                   dow1."OrganisationWorkflowID"
                 from
                   "OrganisationWorkflow" dow1
                 where
                   dow1."OrganisationID" = OrganisationID and
                   dow1."IsActive" = true and
                   dow1."IsDeleted" = false and
                   dow1."WorkflowID" = dow . "WorkflowID" and
                   dow1."VersionNumber" = dow . "WorkflowVersionNumber" and
                   dow1."ParentID" = dow . "DefaultOrganisationID"
    );

  -- Workflow Specific Roles

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    ncr."RoleName",
    true,
    ncr."RoleTypeID",
    true,
    false,
    ncr."WorkflowRoleID"
  FROM
    public."WorkflowRole" ncr
    inner join "DefaultOrganisationWorkflow" donc on donc."WorkflowID" = ncr."WorkflowID" and donc."WorkflowVersionNumber" = 

ncr."WorkflowVersionNumber" and donc."IsActive" = true and donc."IsDeleted"
      = false and donc."DefaultOrganisationID" = defaultorganisationid
  where
    ncr."IsActive" = true and
    ncr."IsDeleted" = false and
    ncr."WorkflowRoleID" not in (
                                  select
                                    orn."ParentID"
                                  from
                                    "OrganisationRole" orn
                                  where
                                    orn."OrganisationID" = OrganisationID
    );

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA WF CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "WorkflowClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID" and ncc."WorkflowRoleID" is null
    inner join "DefaultOrganisationWorkflow" donc on donc."WorkflowID" = ncc."WorkflowID" and donc."WorkflowVersionNumber" = 

ncc."WorkflowVersionNumber" and donc."IsActive" = true and donc."IsDeleted"
      = false and donc."DefaultOrganisationID" = defaultorganisationid
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false;

  -- Workflow CLAIMS THAT ARE DIRECT FROM Workflow ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."WorkflowClaim" ncc
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."WorkflowRoleID" and nc."IsActive" = true 

and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA WF CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."WorkflowClaim" ncc
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."WorkflowRoleID" is null;

  ------------------------ MODULE WORKFLOW ROLECLAIMS

  -- Workflow Specific Roles
/*
  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    wr."RoleName",
    true,
    wr."RoleTypeID",
    true,
    false,
    wr."WorkflowRoleID"
  FROM
    public."ModuleWorkflow" mw
    inner join "OrganisationModuleSubscription" donc on donc."ModuleID" = mw."ModuleID" and donc."ModuleVersionNumber" = 

mw."ModuleVersionNumber" and donc."IsActive" = true and donc."IsDeleted" =
      false and donc."OrganisationID" = OrganisationID
    inner join "WorkflowRole" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
  where
    mw."IsActive" = true and
    mw."IsDeleted" = false and
    wr."WorkflowRoleID" not in (
                                 select
                                   orn."ParentID"
                                 from
                                   "OrganisationRole" orn
                                 where
                                   orn."OrganisationID" = OrganisationID
    );*/

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA WF CLAIMS

/*  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "WorkflowClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID" and ncc."WorkflowRoleID" is null
    inner join "ModuleWorkflow" mw on mw."WorkflowID" = ncc."WorkflowID" and mw."WorkflowVersionNumber" = ncc."WorkflowVersionNumber" and 

mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."ModuleID" = mw."ModuleID" and 

ow."ModuleVersionNumber" = mw."ModuleVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false;*/

  -- Workflow CLAIMS THAT ARE DIRECT FROM Workflow ROLES NOT GLOBAL

  /*INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."WorkflowClaim" ncc
    inner join "ModuleWorkflow" mw on mw."WorkflowID" = ncc."WorkflowID" and mw."WorkflowVersionNumber" = ncc."WorkflowVersionNumber" and 

mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."ModuleID" = mw."ModuleID" and 

ow."ModuleVersionNumber" = mw."ModuleVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."WorkflowRoleID" and nc."IsActive" = true 

and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );*/

  -- INSERT CLAIMS LINKED VIA WF CLAIMS GLOBAL
/*
  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."WorkflowClaim" ncc
    inner join "ModuleWorkflow" mw on mw."WorkflowID" = ncc."WorkflowID" and mw."WorkflowVersionNumber" = ncc."WorkflowVersionNumber" and 

mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."ModuleID" = mw."ModuleID" and 

ow."ModuleVersionNumber" = mw."ModuleVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."WorkflowRoleID" is null;*/
*/
  --------------------------------    MODULE NC ROLE/CLAIMS ----------------------               

  -- Workflow Specific Roles
/*
  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    wr."RoleName",
    true,
    wr."RoleTypeID",
    true,
    false,
    wr."NotificationRoleConstructID"
  FROM
    public."ModuleNotificationConstruct" mw
    inner join "OrganisationModuleSubscription" donc on donc."ModuleID" = mw."ModuleID" and donc."ModuleVersionNumber" = 

mw."ModuleVersionNumber" and donc."IsActive" = true and donc."IsDeleted" =
      false and donc."OrganisationID" = OrganisationID
    inner join "NotificationConstructRole" wr on wr."NotificationConstructID" = mw."ModuleNotificationConstructID" and 

wr."NotificationConstructVersionNumber" = mw."NotificationConstructVersionNumber"
      and wr."IsActive" = true and wr."IsDeleted" = false
  where
    mw."IsActive" = true and
    mw."IsDeleted" = false and
    wr."NotificationRoleConstructID" not in (
                                              select
                                                orn."ParentID"
                                              from
                                                "OrganisationRole" orn
                                              where
                                                orn."OrganisationID" = OrganisationID
    );*/

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA WF CLAIMS

/*  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "NotificationConstructClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID" and ncc."NotificationRoleConstructID" 

is null
    inner join "ModuleNotificationConstruct" mw on mw."NotificationConstructID" = ncc."NotificationConstructID" and 

mw."NotificationConstructVersionNumber" = ncc."NotificationConstructVersionNumber"
      and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."ModuleID" = mw."ModuleID" and 

ow."ModuleVersionNumber" = mw."ModuleVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false;*/

  -- Workflow CLAIMS THAT ARE DIRECT FROM Workflow ROLES NOT GLOBAL

  /*INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."NotificationConstructClaim" ncc
    inner join "ModuleNotificationConstruct" mw on mw."NotificationConstructID" = ncc."NotificationConstructID" and 

mw."NotificationConstructVersionNumber" = ncc."NotificationConstructVersionNumber"
      and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."ModuleID" = mw."ModuleID" and 

ow."ModuleVersionNumber" = mw."ModuleVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."NotificationRoleConstructID" and 

nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );
*/
  -- INSERT CLAIMS LINKED VIA WF CLAIMS GLOBAL

  /*INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."NotificationConstructClaim" ncc
    inner join "ModuleNotificationConstruct" mw on mw."NotificationConstructID" = ncc."NotificationConstructID" and 

mw."NotificationConstructVersionNumber" = ncc."NotificationConstructVersionNumber"
      and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."ModuleID" = mw."ModuleID" and 

ow."ModuleVersionNumber" = mw."ModuleVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."NotificationRoleConstructID" is null;*/

  ---------------------------------------------- ARTEFACT WORKFLOW AND NC ---------------
  -- Workflow Specific Roles
/*
  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    wr."RoleName",
    true,
    wr."RoleTypeID",
    true,
    false,
    wr."WorkflowRoleID"
  FROM
    public."ArtefactWorkflow" mw
    inner join "OrganisationArtefact" donc on donc."ArtefactID" = mw."ArtefactID" and donc."ArtefactVersionNumber" = mw."ArtefactVersionNumber" 

and donc."IsActive" = true and donc."IsDeleted" = false
      and donc."OrganisationID" = OrganisationID
    inner join "WorkflowRole" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
  where
    mw."IsActive" = true and
    mw."IsDeleted" = false and
    wr."WorkflowRoleID" not in (
                                 select
                                   orn."ParentID"
                                 from
                                   "OrganisationRole" orn
                                 where
                                   orn."OrganisationID" = OrganisationID
    );

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA WF CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "WorkflowClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID" and ncc."WorkflowRoleID" is null
    inner join "ArtefactWorkflow" mw on mw."WorkflowID" = ncc."WorkflowID" and mw."WorkflowVersionNumber" = ncc."WorkflowVersionNumber" and 

mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."ArtefactID" = mw."ArtefactID" and 

ow."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false;

  -- Workflow CLAIMS THAT ARE DIRECT FROM Workflow ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."WorkflowClaim" ncc
    inner join "ArtefactWorkflow" mw on mw."WorkflowID" = ncc."WorkflowID" and mw."WorkflowVersionNumber" = ncc."WorkflowVersionNumber" and 

mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."ArtefactID" = mw."ArtefactID" and 

ow."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."WorkflowRoleID" and nc."IsActive" = true 

and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA WF CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."WorkflowClaim" ncc
    inner join "ArtefactWorkflow" mw on mw."WorkflowID" = ncc."WorkflowID" and mw."WorkflowVersionNumber" = ncc."WorkflowVersionNumber" and 

mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."ArtefactID" = mw."ArtefactID" and 

ow."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."WorkflowRoleID" is null;
*/
  --------------------------------    Artefact NC ROLE/CLAIMS ----------------------               

  -- Workflow Specific Roles

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    wr."RoleName",
    true,
    wr."RoleTypeID",
    true,
    false,
    wr."NotificationRoleConstructID"
  FROM
    public."ArtefactNotificationConstruct" mw
    inner join "OrganisationArtefact" donc on donc."ArtefactID" = mw."ArtefactID" and donc."ArtefactVersionNumber" = mw."ArtefactVersionNumber" 

and donc."IsActive" = true and donc."IsDeleted" = false
      and donc."OrganisationID" = OrganisationID
    inner join "NotificationConstructRole" wr on wr."NotificationConstructID" = mw."ArtefactNotificationConstructID" and 

wr."NotificationConstructVersionNumber" =
      mw."NotificationConstructVersionNumber" and wr."IsActive" = true and wr."IsDeleted" = false
  where
    mw."IsActive" = true and
    mw."IsDeleted" = false and
    wr."NotificationRoleConstructID" not in (
                                              select
                                                orn."ParentID"
                                              from
                                                "OrganisationRole" orn
                                              where
                                                orn."OrganisationID" = OrganisationID
    );

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA WF CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "NotificationConstructClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID" and ncc."NotificationRoleConstructID" 

is null
    inner join "ArtefactNotificationConstruct" mw on mw."NotificationConstructID" = ncc."NotificationConstructID" and 

mw."NotificationConstructVersionNumber" = ncc."NotificationConstructVersionNumber"
      and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."ArtefactID" = mw."ArtefactID" and 

ow."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false;

  -- Workflow CLAIMS THAT ARE DIRECT FROM Workflow ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."NotificationConstructClaim" ncc
    inner join "ArtefactNotificationConstruct" mw on mw."NotificationConstructID" = ncc."NotificationConstructID" and 

mw."NotificationConstructVersionNumber" = ncc."NotificationConstructVersionNumber"
      and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."NotificationRoleConstructID" and 

nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA WF CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."NotificationConstructClaim" ncc
    inner join "ArtefactNotificationConstruct" mw on mw."NotificationConstructID" = ncc."NotificationConstructID" and 

mw."NotificationConstructVersionNumber" = ncc."NotificationConstructVersionNumber"
      and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."ArtefactID" = mw."ArtefactID" and 

ow."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."NotificationRoleConstructID" is null;

  ------------------------------------ ORGANISATION WORKFLOW NC ROLE / CLAIMS ---------------------------

  -- Workflow Specific Roles
/*
  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    ncr."RoleName",
    true,
    ncr."RoleTypeID",
    true,
    false,
    ncr."NotificationRoleConstructID"
  FROM
    public."ModuleWorkflow" mw
    inner join "OrganisationModuleSubscription" donc on donc."ModuleID" = mw."ModuleID" and donc."ModuleVersionNumber" = 

mw."ModuleVersionNumber" and donc."IsActive" = true and donc."IsDeleted" =
      false and donc."OrganisationID" = OrganisationID
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = 

mw."WorkflowVersionNumber"
    inner join "NotificationConstructRole" ncr on ncr."NotificationConstructID" = wr."NotificationConstructID" and 

ncr."NotificationConstructVersionNumber" = wr."NotificationConstructVersionNumber"
      and ncr."IsActive" = true and ncr."IsDeleted" = false
  where
    mw."IsActive" = true and
    mw."IsDeleted" = false and
    ncr."NotificationRoleConstructID" not in (
                                               select
                                                 orn."ParentID"
                                               from
                                                 "OrganisationRole" orn
                                               where
                                                 orn."OrganisationID" = OrganisationID
    );
*/
  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA WF CLAIMS
/*
  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false
    inner join "ModuleWorkflow" mw on mw."ModuleID" = ow."ModuleID" and mw."ModuleVersionNumber" = ow."ModuleVersionNumber" and mw."IsActive" = 

true and mw."IsDeleted" = FALSE
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = 

mw."WorkflowVersionNumber"
    inner join "NotificationConstructClaim" ncr on ncr."RoleID" = r."RoleID" and ncr."NotificationRoleConstructID" is null and 

ncr."NotificationConstructID" = wr."NotificationConstructID" and
      ncr."NotificationConstructVersionNumber" = wr."NotificationConstructVersionNumber" and ncr."IsActive" = true and ncr."IsDeleted" = false
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false;
*/
  -- Workflow CLAIMS THAT ARE DIRECT FROM Workflow ROLES NOT GLOBAL

  /*INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."NotificationConstructClaim" ncc
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false
    inner join "ModuleWorkflow" mw on mw."ModuleID" = ow."ModuleID" and mw."ModuleVersionNumber" = ow."ModuleVersionNumber" and mw."IsActive" = 

true and mw."IsDeleted" = FALSE
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = 

mw."WorkflowVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."NotificationRoleConstructID" and 

nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );*/

  -- INSERT CLAIMS LINKED VIA WF CLAIMS GLOBAL
/*
  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."NotificationConstructClaim" ncc
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false
    inner join "ModuleWorkflow" mw on mw."ModuleID" = ow."ModuleID" and mw."ModuleVersionNumber" = ow."ModuleVersionNumber" and mw."IsActive" = 

true and mw."IsDeleted" = FALSE
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = 

mw."WorkflowVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."NotificationRoleConstructID" is null;*/
  -------------------------------------------------------
  ------------------------------------------------------- ARTEFACEWORKFLOW NC
  -- Workflow Specific Roles
/*
  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    ncr."RoleName",
    true,
    ncr."RoleTypeID",
    true,
    false,
    ncr."NotificationRoleConstructID"
  FROM
    public."ArtefactWorkflow" mw
    inner join "OrganisationArtefact" donc on donc."ArtefactID" = mw."ArtefactID" and donc."ArtefactVersionNumber" = mw."ArtefactVersionNumber" 

and donc."IsActive" = true and donc."IsDeleted" = false
      and donc."OrganisationID" = OrganisationID
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = 

mw."WorkflowVersionNumber"
    inner join "NotificationConstructRole" ncr on ncr."NotificationConstructID" = wr."NotificationConstructID" and 

ncr."NotificationConstructVersionNumber" = wr."NotificationConstructVersionNumber"
      and ncr."IsActive" = true and ncr."IsDeleted" = false
  where
    mw."IsActive" = true and
    mw."IsDeleted" = false and
    ncr."NotificationRoleConstructID" not in (
                                               select
                                                 orn."ParentID"
                                               from
                                                 "OrganisationRole" orn
                                               where
                                                 orn."OrganisationID" = OrganisationID
    );

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA WF CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false
    inner join "ArtefactWorkflow" mw on mw."ArtefactID" = ow."ArtefactID" and mw."ArtefactVersionNumber" = ow."ArtefactVersionNumber" and 

mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = 

mw."WorkflowVersionNumber"
    inner join "NotificationConstructClaim" ncr on ncr."RoleID" = r."RoleID" and ncr."NotificationRoleConstructID" is null and 

ncr."NotificationConstructID" = wr."NotificationConstructID" and
      ncr."NotificationConstructVersionNumber" = wr."NotificationConstructVersionNumber" and ncr."IsActive" = true and ncr."IsDeleted" = false
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false;

  -- Workflow CLAIMS THAT ARE DIRECT FROM Workflow ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."NotificationConstructClaim" ncc
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false
    inner join "ArtefactWorkflow" mw on mw."ArtefactID" = ow."ArtefactID" and mw."ArtefactVersionNumber" = ow."ArtefactVersionNumber" and 

mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = 

mw."WorkflowVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."NotificationRoleConstructID" and 

nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA WF CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."NotificationConstructClaim" ncc
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false
    inner join "ArtefactWorkflow" mw on mw."ArtefactID" = ow."ArtefactID" and mw."ArtefactVersionNumber" = ow."ArtefactVersionNumber" and 

mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = 

mw."WorkflowVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."NotificationRoleConstructID" is null;
  -------------------------------------------------------
  ------------------------------------------------------- ORGANISATION WORKFLOW NC ROLE / CLAIMS
  -- Workflow Specific Roles

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    ncr."RoleName",
    true,
    ncr."RoleTypeID",
    true,
    false,
    ncr."NotificationRoleConstructID"
  FROM
    public."OrganisationWorkflow" mw
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."VersionNumber"
    inner join "NotificationConstructRole" ncr on ncr."NotificationConstructID" = wr."NotificationConstructID" and 

ncr."NotificationConstructVersionNumber" = wr."NotificationConstructVersionNumber"
      and ncr."IsActive" = true and ncr."IsDeleted" = false
  where
    mw."IsActive" = true and
    mw."IsDeleted" = false and
    ncr."NotificationRoleConstructID" not in (
                                               select
                                                 orn."ParentID"
                                               from
                                                 "OrganisationRole" orn
                                               where
                                                 orn."OrganisationID" = OrganisationID
    ) and
    mw."OrganisationID" = OrganisationID;

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA WF CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "OrganisationWorkflow" mw on mw."OrganisationID" = OrganisationID and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."VersionNumber"
    inner join "NotificationConstructClaim" ncr on ncr."RoleID" = r."RoleID" and ncr."NotificationRoleConstructID" is null and 

ncr."NotificationConstructID" = wr."NotificationConstructID" and
      ncr."NotificationConstructVersionNumber" = wr."NotificationConstructVersionNumber" and ncr."IsActive" = true and ncr."IsDeleted" = false
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false;

  -- Workflow CLAIMS THAT ARE DIRECT FROM Workflow ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."NotificationConstructClaim" ncc
    inner join "OrganisationWorkflow" mw on mw."OrganisationID" = OrganisationID and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."VersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."NotificationRoleConstructID" and 

nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA WF CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."NotificationConstructClaim" ncc
    inner join "OrganisationWorkflow" mw on mw."OrganisationID" = OrganisationID and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowNotificationConstruct" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."VersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."NotificationRoleConstructID" is null;
  -------------------------------------------------------
  */
  ------------------------------------------------------- MODULE ARTEFACT
/*
  INSERT INTO
    public."OrganisationArtefact"("OrganisationID", "ArtefactID", "ArtefactVersionNumber", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    "ArtefactID",
    "ArtefactVersionNumber",
    ma."IsActive",
    ma."IsDeleted",
    "ArtefactID"
  FROM
    public."ModuleArtefact" ma
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false 

and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
  where
    ma."IsActive" = true and
    ma."IsDeleted" = FALSE and
    not exists (
                 select
                   ma1."ArtefactID"
                 from
                   "OrganisationArtefact" ma1
                 where
                   ma1."OrganisationID" = OrganisationID and
                   ma1."ArtefactID" = ma."ArtefactID" and
                   ma1."ArtefactVersionNumber" = ma."ArtefactVersionNumber"
    );

  -- Artefact Specific Roles

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    ncr."RoleName",
    true,
    ncr."RoleTypeID",
    true,
    false,
    ncr."ArtefactRoleID"
  FROM
    public."ArtefactRole" ncr
    inner join "ModuleArtefact" ma on ma."ArtefactID" = ncr."ArtefactID" and ma."ArtefactVersionNumber" = ncr."ArtefactVersionNumber" and 

ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false 

and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
  where
    ncr."IsActive" = true and
    ncr."IsDeleted" = false and
    ncr."ArtefactRoleID" not in (
                                  select
                                    orn."ParentID"
                                  from
                                    "OrganisationRole" orn
                                  where
                                    orn."OrganisationID" = OrganisationID
    );

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA NC CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "ArtefactClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID"
    inner join "ModuleArtefact" ma on ma."ArtefactID" = ncc."ArtefactID" and ma."ArtefactVersionNumber" = ncc."ArtefactVersionNumber" and 

ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false 

and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false and
    ncc."ArtefactRoleID" is null;

  -- ARTEFACT CLAIMS THAT ARE DIRECT FROM ARTEFACT ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."ArtefactClaim" ncc
    inner join "ModuleArtefact" ma on ma."ArtefactID" = ncc."ArtefactID" and ma."ArtefactVersionNumber" = ncc."ArtefactVersionNumber" and 

ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false 

and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."ArtefactRoleID" and nc."IsActive" = true 

and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA NC CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."ArtefactClaim" ncc
    inner join "ModuleArtefact" ma on ma."ArtefactID" = ncc."ArtefactID" and ma."ArtefactVersionNumber" = ncc."ArtefactVersionNumber" and 

ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false 

and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."ArtefactRoleID" is null;

  -- Workflow Specific Roles

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    wr."RoleName",
    true,
    wr."RoleTypeID",
    true,
    false,
    wr."WorkflowRoleID"
  FROM
    public."ArtefactWorkflow" mw
    inner join "ModuleArtefact" ma on ma."ArtefactID" = mw."ArtefactID" and ma."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and 

ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false 

and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
    inner join "OrganisationArtefact" donc on donc."ArtefactID" = mw."ArtefactID" and donc."ArtefactVersionNumber" = mw."ArtefactVersionNumber" 

and donc."IsActive" = true and donc."IsDeleted" = false
      and donc."OrganisationID" = OrganisationID
    inner join "WorkflowRole" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
  where
    mw."IsActive" = true and
    mw."IsDeleted" = false and
    wr."WorkflowRoleID" not in (
                                 select
                                   orn."ParentID"
                                 from
                                   "OrganisationRole" orn
                                 where
                                   orn."OrganisationID" = OrganisationID
    );*/

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA WF CLAIMS
/*
  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "WorkflowClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID" and ncc."WorkflowRoleID" is null
    inner join "ArtefactWorkflow" mw on mw."WorkflowID" = ncc."WorkflowID" and mw."WorkflowVersionNumber" = ncc."WorkflowVersionNumber" and 

mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "ModuleArtefact" ma on ma."ArtefactID" = mw."ArtefactID" and ma."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and 

ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false 

and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
    inner join "OrganisationArtefact" oa on oa."OrganisationID" = OrganisationID and oa."ArtefactID" = mw."ArtefactID" and 

oa."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and oa."IsActive" =
      true and oa."IsDeleted" = false
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false;
*/
  -- Workflow CLAIMS THAT ARE DIRECT FROM Workflow ROLES NOT GLOBAL
/*
  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."WorkflowClaim" ncc
    inner join "ArtefactWorkflow" mw on mw."WorkflowID" = ncc."WorkflowID" and mw."WorkflowVersionNumber" = ncc."WorkflowVersionNumber" and 

mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "ModuleArtefact" ma on ma."ArtefactID" = mw."ArtefactID" and ma."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and 

ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false 

and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
    inner join "OrganisationArtefact" oa on oa."OrganisationID" = OrganisationID and oa."ArtefactID" = mw."ArtefactID" and 

oa."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and oa."IsActive" =
      true and oa."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."WorkflowRoleID" and nc."IsActive" = true 

and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA WF CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."WorkflowClaim" ncc
    inner join "ArtefactWorkflow" mw on mw."WorkflowID" = ncc."WorkflowID" and mw."WorkflowVersionNumber" = ncc."WorkflowVersionNumber" and 

mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "ModuleArtefact" ma on ma."ArtefactID" = mw."ArtefactID" and ma."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and 

ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false 

and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
    inner join "OrganisationArtefact" oa on oa."OrganisationID" = OrganisationID and oa."ArtefactID" = mw."ArtefactID" and 

oa."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and oa."IsActive" =
      true and oa."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."WorkflowRoleID" is null;

  --------------------------------    Artefact NC ROLE/CLAIMS ----------------------               

  -- Workflow Specific Roles

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    wr."RoleName",
    true,
    wr."RoleTypeID",
    true,
    false,
    wr."NotificationRoleConstructID"
  FROM
    public."ArtefactNotificationConstruct" mw
    inner join "ModuleArtefact" ma on ma."ArtefactID" = mw."ArtefactID" and ma."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and 

ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false 

and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
    inner join "OrganisationArtefact" donc on donc."ArtefactID" = mw."ArtefactID" and donc."ArtefactVersionNumber" = mw."ArtefactVersionNumber" 

and donc."IsActive" = true and donc."IsDeleted" = false
      and donc."OrganisationID" = OrganisationID
    inner join "NotificationConstructRole" wr on wr."NotificationConstructID" = mw."ArtefactNotificationConstructID" and 

wr."NotificationConstructVersionNumber" =
      mw."NotificationConstructVersionNumber" and wr."IsActive" = true and wr."IsDeleted" = false
  where
    mw."IsActive" = true and
    mw."IsDeleted" = false and
    wr."NotificationRoleConstructID" not in (
                                              select
                                                orn."ParentID"
                                              from
                                                "OrganisationRole" orn
                                              where
                                                orn."OrganisationID" = OrganisationID
    );

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA WF CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "NotificationConstructClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID" and ncc."NotificationRoleConstructID" 

is null
    inner join "ArtefactNotificationConstruct" mw on mw."NotificationConstructID" = ncc."NotificationConstructID" and 

mw."NotificationConstructVersionNumber" = ncc."NotificationConstructVersionNumber"
      and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "ModuleArtefact" ma on ma."ArtefactID" = mw."ArtefactID" and ma."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and 

ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false 

and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
    inner join "OrganisationArtefact" oa on oa."OrganisationID" = OrganisationID and oa."ArtefactID" = mw."ArtefactID" and 

oa."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and oa."IsActive" =
      true and oa."IsDeleted" = false
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false;

  -- Workflow CLAIMS THAT ARE DIRECT FROM Workflow ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."NotificationConstructClaim" ncc
    inner join "ArtefactNotificationConstruct" mw on mw."NotificationConstructID" = ncc."NotificationConstructID" and 

mw."NotificationConstructVersionNumber" = ncc."NotificationConstructVersionNumber"
      and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "ModuleArtefact" ma on ma."ArtefactID" = mw."ArtefactID" and ma."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and 

ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false 

and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."NotificationRoleConstructID" and 

nc."IsActive" = true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA WF CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."NotificationConstructClaim" ncc
    inner join "ArtefactNotificationConstruct" mw on mw."NotificationConstructID" = ncc."NotificationConstructID" and 

mw."NotificationConstructVersionNumber" = ncc."NotificationConstructVersionNumber"
      and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "ModuleArtefact" ma on ma."ArtefactID" = mw."ArtefactID" and ma."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and 

ma."IsActive" = true and ma."IsDeleted" = false
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false 

and ow."ModuleID" = ma."ModuleID" and
      ow."ModuleVersionNumber" = ma."ModuleVersionNumber"
    inner join "OrganisationArtefact" oa on oa."OrganisationID" = OrganisationID and oa."ArtefactID" = mw."ArtefactID" and 

oa."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and oa."IsActive" =
      true and oa."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."NotificationRoleConstructID" is null;*/

  ----------------------------------------------------------------------------
  -------------------------------------- ORG STATUS TYPE
  -- Org StatusType

  INSERT INTO
    public."OrganisationStatusType"("OrganisationID", "StatusTypeID", "StatusTypeVersionNumber", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    "StatusTypeID",
    "StatusTypeVersionNumber",
    "IsActive",
    "IsDeleted",
    "DefaultOrganisationID"
  FROM
    public."DefaultOrganisationStatusType"
  where
    "DefaultOrganisationID" = defaultorganisationid and
    "IsActive" = true and
    "IsDeleted" = false;

  -- StatusType Specific Roles

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    ncr."RoleName",
    true,
    ncr."RoleTypeID",
    true,
    false,
    ncr."StatusTypeRoleID"
  FROM
    public."StatusTypeRole" ncr
    inner join "DefaultOrganisationStatusType" donc on donc."StatusTypeID" = ncr."StatusTypeID" and donc."StatusTypeVersionNumber" = 

ncr."StatusTypeVersionNumber" and donc."IsActive" = true and
      donc."IsDeleted" = false and donc."DefaultOrganisationID" = defaultorganisationid
  where
    ncr."IsActive" = true and
    ncr."IsDeleted" = false and
    ncr."StatusTypeRoleID" not in (
                                    select
                                      orn."ParentID"
                                    from
                                      "OrganisationRole" orn
                                    where
                                      orn."OrganisationID" = OrganisationID
    );

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA NC CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "StatusTypeClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID"
    inner join "DefaultOrganisationStatusType" donc on donc."StatusTypeID" = ncc."StatusTypeID" and donc."StatusTypeVersionNumber" = 

ncc."StatusTypeVersionNumber" and donc."IsActive" = true and
      donc."IsDeleted" = false and donc."DefaultOrganisationID" = defaultorganisationid
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false and
    ncc."StatusTypeRoleID" is null;

  -- StatusType CLAIMS THAT ARE DIRECT FROM StatusType ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."StatusTypeClaim" ncc
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."StatusTypeRoleID" and nc."IsActive" = 

true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA NC CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."StatusTypeClaim" ncc
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."StatusTypeRoleID" is null;

  -----------------------------------------------------------------
  ---------------- DO-WF
/*
  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    mw."RoleName",
    true,
    mw."RoleTypeID",
    true,
    false,
    mw."StatusTypeRoleID"
  FROM
    public."StatusTypeRole" mw
    inner join "ModuleStatusType" mst on mst."StatusTypeID" = mw."StatusTypeID" and mst."StatusTypeVersionNumber" = 

mw."StatusTypeVersionNumber" and mst."IsActive" = true and mst."IsDeleted" = false
    inner join "OrganisationModuleSubscription" donc on donc."ModuleID" = mst."ModuleID" and donc."ModuleVersionNumber" = 

mst."ModuleVersionNumber" and donc."IsActive" = true and donc."IsDeleted" =
      false and donc."OrganisationID" = OrganisationID
  where
    mw."IsActive" = true and
    mw."IsDeleted" = false and
    mw."StatusTypeRoleID" not in (
                                   select
                                     orn."ParentID"
                                   from
                                     "OrganisationRole" orn
                                   where
                                     orn."OrganisationID" = OrganisationID
    );

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA WF CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "StatusTypeClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID" and ncc."StatusTypeRoleID" is null
    inner join "ModuleStatusType" mw on mw."StatusTypeID" = ncc."StatusTypeID" and mw."StatusTypeVersionNumber" = ncc."StatusTypeVersionNumber" 

and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."ModuleID" = mw."ModuleID" and 

ow."ModuleVersionNumber" = mw."ModuleVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false;

  -- StatusType CLAIMS THAT ARE DIRECT FROM StatusType ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."StatusTypeClaim" ncc
    inner join "ModuleStatusType" mw on mw."StatusTypeID" = ncc."StatusTypeID" and mw."StatusTypeVersionNumber" = ncc."StatusTypeVersionNumber" 

and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."ModuleID" = mw."ModuleID" and 

ow."ModuleVersionNumber" = mw."ModuleVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."StatusTypeRoleID" and nc."IsActive" = 

true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA WF CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."StatusTypeClaim" ncc
    inner join "ModuleStatusType" mw on mw."StatusTypeID" = ncc."StatusTypeID" and mw."StatusTypeVersionNumber" = ncc."StatusTypeVersionNumber" 

and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."ModuleID" = mw."ModuleID" and 

ow."ModuleVersionNumber" = mw."ModuleVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."StatusTypeRoleID" is null;*/
  ----------------------------------------------------
  -------------------- DO - AR - STR
  -- Workflow Specific Roles

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    wr."RoleName",
    true,
    wr."RoleTypeID",
    true,
    false,
    wr."StatusTypeRoleID"
  FROM
    public."ArtefactStatusType" mw
    inner join "OrganisationArtefact" donc on donc."ArtefactID" = mw."ArtefactID" and donc."ArtefactVersionNumber" = mw."ArtefactVersionNumber" 

and donc."IsActive" = true and donc."IsDeleted" = false
      and donc."OrganisationID" = OrganisationID
    inner join "StatusTypeRole" wr on wr."StatusTypeID" = mw."StatusTypeID" and wr."StatusTypeVersionNumber" = mw."StatusTypeVersionNumber"
  where
    wr."StatusTypeRoleID" not in (
                                   select
                                     orn."ParentID"
                                   from
                                     "OrganisationRole" orn
                                   where
                                     orn."OrganisationID" = OrganisationID
    );

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA WF CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "StatusTypeClaim" ncc on ncc."RoleID" is not null and ncc."RoleID" = r."RoleID" and ncc."StatusTypeRoleID" is null
    inner join "ArtefactStatusType" mw on mw."StatusTypeID" = ncc."StatusTypeID" and mw."StatusTypeVersionNumber" = 

ncc."StatusTypeVersionNumber"
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."ArtefactID" = mw."ArtefactID" and 

ow."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false;

  -- StatusType CLAIMS THAT ARE DIRECT FROM StatusType ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."StatusTypeClaim" ncc
    inner join "ArtefactStatusType" mw on mw."StatusTypeID" = ncc."StatusTypeID" and mw."StatusTypeVersionNumber" = 

ncc."StatusTypeVersionNumber"
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."ArtefactID" = mw."ArtefactID" and 

ow."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."StatusTypeRoleID" and nc."IsActive" = 

true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA WF CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."StatusTypeClaim" ncc
    inner join "ArtefactStatusType" mw on mw."StatusTypeID" = ncc."StatusTypeID" and mw."StatusTypeVersionNumber" = 

ncc."StatusTypeVersionNumber"
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."ArtefactID" = mw."ArtefactID" and 

ow."ArtefactVersionNumber" = mw."ArtefactVersionNumber" and ow."IsActive" =
      true and ow."IsDeleted" = false
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."StatusTypeRoleID" is null;
  -----------------------------------------------------
  --------------------- DO - M - WF - STR
  -- Workflow Specific Roles

/* insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    ncr."RoleName",
    true,
    ncr."RoleTypeID",
    true,
    false,
    ncr."StatusTypeRoleID"
  FROM
    public."ModuleWorkflow" mw
    inner join "OrganisationModuleSubscription" donc on donc."ModuleID" = mw."ModuleID" and donc."ModuleVersionNumber" = 

mw."ModuleVersionNumber" and donc."IsActive" = true and donc."IsDeleted" =
      false and donc."OrganisationID" = OrganisationID
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "StatusTypeRole" ncr on ncr."StatusTypeID" = wr."StatusTypeID" and ncr."StatusTypeVersionNumber" = wr."StatusTypeVersionNumber" 

and ncr."IsActive" = true and ncr."IsDeleted" = false
  where
    mw."IsActive" = true and
    mw."IsDeleted" = false and
    ncr."StatusTypeRoleID" not in (
                                    select
                                      orn."ParentID"
                                    from
                                      "OrganisationRole" orn
                                    where
                                      orn."OrganisationID" = OrganisationID
    );

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA WF CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false
    inner join "ModuleWorkflow" mw on mw."ModuleID" = ow."ModuleID" and mw."ModuleVersionNumber" = ow."ModuleVersionNumber" and mw."IsActive" = 

true and mw."IsDeleted" = FALSE
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "StatusTypeClaim" ncr on ncr."RoleID" = r."RoleID" and ncr."StatusTypeRoleID" is null and ncr."StatusTypeID" = wr."StatusTypeID" 

and ncr."StatusTypeVersionNumber" =
      wr."StatusTypeVersionNumber" and ncr."IsActive" = true and ncr."IsDeleted" = false
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false;

  -- Workflow CLAIMS THAT ARE DIRECT FROM Workflow ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."StatusTypeClaim" ncc
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false
    inner join "ModuleWorkflow" mw on mw."ModuleID" = ow."ModuleID" and mw."ModuleVersionNumber" = ow."ModuleVersionNumber" and mw."IsActive" = 

true and mw."IsDeleted" = FALSE
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."StatusTypeRoleID" and nc."IsActive" = 

true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA WF CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."StatusTypeClaim" ncc
    inner join "OrganisationModuleSubscription" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false
    inner join "ModuleWorkflow" mw on mw."ModuleID" = ow."ModuleID" and mw."ModuleVersionNumber" = ow."ModuleVersionNumber" and mw."IsActive" = 

true and mw."IsDeleted" = FALSE
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."StatusTypeRoleID" is null;*/
  -----------------------------------------------------
  ---------------------------------- DO - AR -WF - STR
/*
  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    ncr."RoleName",
    true,
    ncr."RoleTypeID",
    true,
    false,
    ncr."StatusTypeRoleID"
  FROM
    public."ArtefactWorkflow" mw
    inner join "OrganisationArtefact" donc on donc."ArtefactID" = mw."ArtefactID" and donc."ArtefactVersionNumber" = mw."ArtefactVersionNumber" 

and donc."IsActive" = true and donc."IsDeleted" = false
      and donc."OrganisationID" = OrganisationID
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "StatusTypeRole" ncr on ncr."StatusTypeID" = wr."StatusTypeID" and ncr."StatusTypeVersionNumber" = wr."StatusTypeVersionNumber" 

and ncr."IsActive" = true and ncr."IsDeleted" = false
  where
    mw."IsActive" = true and
    mw."IsDeleted" = false and
    ncr."StatusTypeRoleID" not in (
                                    select
                                      orn."ParentID"
                                    from
                                      "OrganisationRole" orn
                                    where
                                      orn."OrganisationID" = OrganisationID
    );

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA WF CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false
    inner join "ArtefactWorkflow" mw on mw."ArtefactID" = ow."ArtefactID" and mw."ArtefactVersionNumber" = ow."ArtefactVersionNumber" and 

mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "StatusTypeClaim" ncr on ncr."RoleID" = r."RoleID" and ncr."StatusTypeRoleID" is null and ncr."StatusTypeID" = wr."StatusTypeID" 

and ncr."StatusTypeVersionNumber" =
      wr."StatusTypeVersionNumber" and ncr."IsActive" = true and ncr."IsDeleted" = false
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false;

  -- Workflow CLAIMS THAT ARE DIRECT FROM Workflow ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."StatusTypeClaim" ncc
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false
    inner join "ArtefactWorkflow" mw on mw."ArtefactID" = ow."ArtefactID" and mw."ArtefactVersionNumber" = ow."ArtefactVersionNumber" and 

mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."StatusTypeRoleID" and nc."IsActive" = 

true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA WF CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."StatusTypeClaim" ncc
    inner join "OrganisationArtefact" ow on ow."OrganisationID" = OrganisationID and ow."IsActive" = true and ow."IsDeleted" = false
    inner join "ArtefactWorkflow" mw on mw."ArtefactID" = ow."ArtefactID" and mw."ArtefactVersionNumber" = ow."ArtefactVersionNumber" and 

mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."WorkflowVersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."StatusTypeRoleID" is null;

  ----------------------------------------
  -------------------------- DO - WF - STR
  -- Workflow Specific Roles

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    ncr."RoleName",
    true,
    ncr."RoleTypeID",
    true,
    false,
    ncr."StatusTypeRoleID"
  FROM
    public."OrganisationWorkflow" mw
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."VersionNumber"
    inner join "StatusTypeRole" ncr on ncr."StatusTypeID" = wr."StatusTypeID" and ncr."StatusTypeVersionNumber" = wr."StatusTypeVersionNumber" 

and ncr."IsActive" = true and ncr."IsDeleted" = false
  where
    mw."IsActive" = true and
    mw."IsDeleted" = false and
    ncr."StatusTypeRoleID" not in (
                                    select
                                      orn."ParentID"
                                    from
                                      "OrganisationRole" orn
                                    where
                                      orn."OrganisationID" = OrganisationID
    ) and
    mw."OrganisationID" = OrganisationID;

  -- INSERT GLOBAL ROLES THAT ARE LINKED VIA WF CLAIMS

  insert into
    public."OrganisationRole"("OrganisationID", "RoleName", "IsManaged", "RoleTypeID", "IsActive", "IsDeleted", "ParentID")
  SELECT
    OrganisationID,
    r."RoleName",
    true,
    r."RoleTypeID",
    true,
    false,
    r."RoleID"
  FROM
    public."Role" r
    inner join "OrganisationWorkflow" mw on mw."OrganisationID" = OrganisationID and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."VersionNumber"
    inner join "StatusTypeClaim" ncr on ncr."RoleID" = r."RoleID" and ncr."StatusTypeRoleID" is null and ncr."StatusTypeID" = wr."StatusTypeID" 

and ncr."StatusTypeVersionNumber" =
      wr."StatusTypeVersionNumber" and ncr."IsActive" = true and ncr."IsDeleted" = false
  where
    r."RoleID" not in (
                        select
                          rr."ParentID"
                        from
                          "OrganisationRole" rr
                        where
                          rr."OrganisationID" = OrganisationID
    ) and
    r."IsActive" = true and
    r."IsDeleted" = false;

  -- Workflow CLAIMS THAT ARE DIRECT FROM Workflow ROLES NOT GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."StatusTypeClaim" ncc
    inner join "OrganisationWorkflow" mw on mw."OrganisationID" = OrganisationID and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."VersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."StatusTypeRoleID" and nc."IsActive" = 

true and nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    ncc."RoleID" is null and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    );

  -- INSERT CLAIMS LINKED VIA WF CLAIMS GLOBAL

  INSERT INTO
    public."OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted", 

"OrganisationID")
  SELECT
    nc."OrganisationRoleID",
    ncc."ResourceID",
    ncc."OperationID",
    ncc."StateID",
    ncc."StateItemID",
    ncc."IsActive",
    ncc."IsDeleted",
    OrganisationID
  FROM
    public."StatusTypeClaim" ncc
    inner join "OrganisationWorkflow" mw on mw."OrganisationID" = OrganisationID and mw."IsActive" = true and mw."IsDeleted" = FALSE
    inner join "WorkflowStatusType" wr on wr."WorkflowID" = mw."WorkflowID" and wr."WorkflowVersionNumber" = mw."VersionNumber"
    inner join "OrganisationRole" nc on nc."OrganisationID" = OrganisationID and nc."ParentID" = ncc."RoleID" and nc."IsActive" = true and 

nc."IsDeleted" = false
  where
    ncc."IsActive" = true and
    ncc."IsDeleted" = false and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = OrganisationID and
                   orc."OrganisationRoleID" = nc."OrganisationRoleID" and
                   orc."OperationID" = ncc."OperationID" and
                   orc."ResourceID" = ncc."ResourceID" and
                   orc."StateID" = ncc."StateID" and
                   orc."StateItemID" = ncc."StateItemID"
    ) and
    ncc."StatusTypeRoleID" is null;
    */
   
  ------------------------ Branch

  -- create branches as needed

  INSERT INTO
    public."Organisation"("OrganisationID", "OrganisationTypeID", "IsBranch", "IsHeadOffice", "CreatedOn", "CreatedBy", 

"DefaultOrganisationID", "DefaultOrganisationVersionNumber",
      "ParentOrganisationID", "ParentID")
  SELECT
    uuid_generate_v1(),
    (
      select
        "OrganisationTypeID"
      from
        "OrganisationType"
      where
        "Name" = 'Branch'
      limit
        1
    ),
    true,
    false,
    CURRENT_DATE,
    'System',
    defaultorganisationid,
    organisationversionnumber,
    OrganisationID,
    wt."DefaultOrganisationBranchID"
  FROM
    public."DefaultOrganisationBranch" wt
  where
    wt."DefaultOrganisationID" = defaultorganisationid and
    wt."DefaultOrganisationVersionNumber" = organisationversionnumber;
  INSERT INTO
    public."OrganisationDetail"("OrganisationID", "Name", "Description")
  SELECT
    org."OrganisationID",
    dob."BranchName",
    'Branch'
  FROM
    public."Organisation" org
    left outer join "DefaultOrganisationBranch" dob on dob."DefaultOrganisationBranchID" = org."ParentID"
  where
    org."ParentOrganisationID" = OrganisationID;

  -- User Type

  INSERT INTO
    public."OrganisationUserType"("OrganisationID", "UserTypeID", "IsActive", "IsDeleted", "IsForDefaultUser")
  SELECT
    OrganisationID,
    wt."UserTypeID",
    wt."IsActive",
    wt."IsDeleted",
    wt."IsForDefaultUser"
  FROM
    public."DefaultOrganisationUserType" wt
  where
    wt."DefaultOrganisationID" = defaultorganisationid and
    wt."DefaultOrganisationVersionNumber" = organisationversionnumber;

  -- Organisation Default Status 

  INSERT INTO
    public."OrganisationStatus"("OrganisationID", "StatusTypeID", "StatusTypeVersionNumber", "StatusTypeValueID", "StatusChangedOn", 

"StatusChangedBy", "ParentID")
  SELECT
    OrganisationID,
    wt."StatusTypeID",
    wt."StatusTypeVersionNumber",
    st."StatusTypeValueID",
    CURRENT_DATE,
    'System',
    null
  FROM
    public."DefaultOrganisationTarget" wt
    left outer join "vStatusType" st on st."StatusTypeID" = wt."StatusTypeID" and st."StatusTypeVersionNumber" = wt."StatusTypeVersionNumber" 

and
      st."IsStart" = true
  where
    wt."DefaultOrganisationID" = defaultorganisationid and
    wt."DefaultOrganisationVersionNumber" = organisationversionnumber and
    st."StatusTypeValueID" is not null;

  -- Organisation Branch Default Status, same as parent
  FOR LoopRow IN
  SELECT
    *
  FROM
    "Organisation"
  where
    "ParentOrganisationID" = OrganisationID
  LOOP
    INSERT INTO
      public."OrganisationStatus"("OrganisationID", "StatusTypeID", "StatusTypeVersionNumber", "StatusTypeValueID", "StatusChangedOn", 

"StatusChangedBy", "ParentID")
    SELECT
      loopRow."OrganisationID",
      wt."StatusTypeID",
      wt."StatusTypeVersionNumber",
      st."StatusTypeValueID",
      CURRENT_DATE,
      'System',
      null
    FROM
      public."DefaultOrganisationTarget" wt
      left outer join "vStatusType" st on st."StatusTypeID" = wt."StatusTypeID" and st."StatusTypeVersionNumber" = wt."StatusTypeVersionNumber" 

and st."StatusTypeName" = 'Branch Status' and
        st."IsStart" = true
    where
      wt."DefaultOrganisationID" = defaultorganisationid and
      wt."DefaultOrganisationVersionNumber" = organisationversionnumber and
      st."StatusTypeValueID" is not null;

  END LOOP;

  RETURN OrganisationId;
end;
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER
COST 100;


INSERT INTO public."Role" ("RoleID", "RoleName", "RoleDescription", "RoleTypeID", "RoleSubTypeID", "RoleCategoryID", "RoleSubCategoryID", "IsActive", "IsDeleted", "IsGlobal")
VALUES (uuid_generate_v1(), E'Broker Administrator', E'Broker Administrator Role',
(select dot."ClassificationTypeID" from "ClassificationType" dot where dot."ClassificationTypeCategoryID" = 130 and dot."Name" = 'Global' limit 1),
 NULL, NULL, NULL, True, False, True);

INSERT INTO public."Role" ("RoleID", "RoleName", "RoleDescription", "RoleTypeID", "RoleSubTypeID", "RoleCategoryID", "RoleSubCategoryID", "IsActive", "IsDeleted", "IsGlobal")
VALUES (uuid_generate_v1(), E'Lender Administrator', E'Lender Administrator Role',
(select dot."ClassificationTypeID" from "ClassificationType" dot where dot."ClassificationTypeCategoryID" = 130 and dot."Name" = 'Global' limit 1),
 NULL, NULL, NULL, True, False, True);

  --view homepage
    insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Broker Administrator' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'Home' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1), TRUE);

 --view homepage
    insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Lender Administrator' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'Home' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1), TRUE);

  
  
-- Broker TsCs
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
  '4faaa2fe-489f-11e4-8f39-5f438902bf9f',
  1,
  'TcMortgageBroker',
  'Mortgage Broker Terms and Conditions',
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
  '4faaa2fe-489f-11e4-8f39-5f438902bf9f',
  1,
  E'\\357\\273\\277<?xml version="1.0" encoding="utf-8" standalone="yes"?>\\015\\012<StiSerializer version="1.02" type="Net" application="StiReport">\\015\\012  <Dictionary Ref="1" type="Dictionary" isKey="true">\\015\\012    <BusinessObjects isList="true" count="0" />\\015\\012    <Databases isList="true" count="0" />\\015\\012    <DataSources isList="true" count="0" />\\015\\012    <Relations isList="true" count="0" />\\015\\012    <Report isRef="0" />\\015\\012    <Variables isList="true" count="1">\\015\\012      <value>General</value>\\015\\012    </Variables>\\015\\012  </Dictionary>\\015\\012  <EngineVersion>EngineV2</EngineVersion>\\015\\012  <GlobalizationStrings isList="true" count="0" />\\015\\012  <MetaTags isList="true" count="0" />\\015\\012  <Pages isList="true" count="1">\\015\\012    <Page1 Ref="2" type="Page" isKey="true">\\015\\012      <Border>None;Black;2;Solid;False;4;Black</Border>\\015\\012      <Brush>Transparent</Brush>\\015\\012      <Components isList="true" count="2">\\015\\012        <PageHeaderBand1 Ref="3" type="PageHeaderBand" isKey="true">\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>0,0.4,19,3.2</ClientRectangle>\\015\\012          <Components isList="true" count="2">\\015\\012            <Image1 Ref="4" type="Image" isKey="true">\\015\\012              <AspectRatio>True</AspectRatio>\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>0,0,12,3</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Guid>d4618a2ea202466e9f00d982451b0609</Guid>\\015\\012              <Image>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BwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEA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AAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAADL/d//+//J4YbMMrwhwgAAAABJRU5ErkJggg==</Image>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>Image1</Name>\\015\\012              <Page isRef="2" />\\015\\012              <Parent isRef="3" />\\015\\012              <Stretch>True</Stretch>\\015\\012            </Image1>\\015\\012            <TextVersion Ref="5" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>16.6,0,2.4,0.6</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,8</Font>\\015\\012              <Guid>d453c64579d24772b1ade666371c2ffb</Guid>\\015\\012              <HorAlignment>Right</HorAlignment>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>TextVersion</Name>\\015\\012              <Page isRef="2" />\\015\\012              <Parent isRef="3" />\\015\\012              <Text>Version: 1.0</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <Type>Expression</Type>\\015\\012            </TextVersion>\\015\\012          </Components>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Name>PageHeaderBand1</Name>\\015\\012          <Page isRef="2" />\\015\\012          <Parent isRef="2" />\\015\\012        </PageHeaderBand1>\\015\\012        <DataBand1 Ref="6" type="DataBand" isKey="true">\\015\\012          <Brush>Transparent</Brush>\\015\\012          <CanBreak>True</CanBreak>\\015\\012          <ClientRectangle>0,4.4,19,6.4</ClientRectangle>\\015\\012          <Components isList="true" count="2">\\015\\012            <TextContent Ref="7" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <CanBreak>True</CanBreak>\\015\\012              <CanGrow>True</CanGrow>\\015\\012              <ClientRectangle>0,0,19,3.2</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,8</Font>\\015\\012              <Guid>2aadb8b5addd4e31b8b69efa105a7b28</Guid>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>TextContent</Name>\\015\\012              <Page isRef="2" />\\015\\012              <Parent isRef="6" />\\015\\012              <Text>The Safe Move Scheme Terms and Conditions for Conveyancing Organisations Representing Property Buyers, Sellers and Lenders\\015\\012\\015\\0121. GENERAL\\015\\012\\015\\0121.1 These Terms and Conditions are a legal agreement between Your organisation or company (\\342\\200\\234Licensee\\342\\200\\235, \\342\\200\\234Your\\342\\200\\235 or \\342\\200\\234You\\342\\200\\235) and BE Consultancy Limited (company number 05742032) trading as \\342\\200\\230the Safe Move Scheme\\342\\200\\231 and Our registered address is Marlesfield House, 114 - 116 Main Road, Sidcup, DA14 6NG (\\342\\200\\234Licensor\\342\\200\\235, \\342\\200\\234We\\342\\200\\235, \\342\\200\\234Our\\342\\200\\235, or \\342\\200\\234Us\\342\\200\\235). \\015\\012\\015\\0121.2 These Terms and Conditions govern Your use of Our Safe Move Scheme, which is accessible by way of the Website and Our provision of the Services to You.\\015\\012\\015\\0121.3 We agree to provide the Services to You via the Website in accordance with these Terms and Conditions. These Terms and Conditions do not transfer any rights or title in the Services, Website (or anything created by either) to You and We remain the owner at all times.\\015\\012\\015\\0121.4 We reserve the right to decline the provision of the Services to any user at any time\\015\\012\\015\\0122. IMPORTANT NOTICE TO ALL USERS\\015\\012\\015\\0122.1 WE ADVISE YOU TO PRINT AND KEEP A COPY OF THESE TERMS AND CONDITIONS.\\015\\012\\015\\0122.2 By selecting the box below You agree to be bound by these Terms and Conditions, which will bind You and Your employees. Please note the limitations of liability set out at clause 12.\\015\\012\\015\\0122.3 If You do not agree to these Terms and Conditions, We are not able to provide the Services to You and You must discontinue the process now.  In this case, the process will end and You will not be able to access or make use of the Services.\\015\\012\\015\\0122.4 These Terms and Conditions are a legal agreement between us and can only be modified with our written consent. We may change these Terms and Conditions at our discretion by changing them on our website. Clause 17.8 states when the last changes were made. The current version of these Terms and Conditions as displayed on our Portal, will apply. \\015\\012\\015\\0122.5 Misuse of the Services is prohibited. Please refer to clause 8 for Your obligations in relation to the use of the Services. \\015\\012\\015\\0123. DEFINITIONS\\015\\012\\015\\0123.1 In these Terms and Conditions, the following definitions shall apply:\\015\\012\\015\\012\\342\\200\\234Agreement\\342\\200\\235 means the agreement between us which incorporates these Terms and Conditions;\\015\\012\\342\\200\\234Buyer\\342\\200\\235 means the buyer in the Transaction;\\015\\012\\342\\200\\234Buyer\\342\\200\\231s Conveyancer\\342\\200\\235 means the conveyancing professional acting for and on behalf of the Buyer in the Transaction;\\015\\012\\342\\200\\234Charges\\342\\200\\235 means the charges payable for the provision of the Services;\\015\\012\\342\\200\\234Client\\342\\200\\235 means the person/s and/or organisation/s who has instructed the conveyancer in relation to the Transaction;\\015\\012\\342\\200\\234Client Data\\342\\200\\235 means the data added by the Client or on behalf of the Client;\\015\\012\\342\\200\\234Conveyancers\\342\\200\\235 means all conveyancing professionals acting for and on behalf of the Seller and Buyer and Lender in the Transaction;\\015\\012\\342\\200\\234Data\\342\\200\\235 means any Client Data, any data relating to \\342\\200\\231parties\\342\\200\\231 involved in the Transaction, together with any data collected by the system relating to the Transaction;\\015\\012\\342\\200\\234DPA\\342\\200\\235 means the Data Protection Act 1998, as amended and updated from time to time;\\015\\012\\342\\200\\234Insurance\\342\\200\\235 means the insurance policy supplied by us as part of providing Services;\\015\\012\\342\\200\\234Intellectual Property Rights\\342\\200\\235 means all intellectual property rights and industry property rights of any kind including without limitation patents, patent applications, copyright, know how, technical and commercial information, design (whether registered or unregistered), design rights, internet domain names, database rights, trade marks, service marks or business names, applications to register any of the foregoing rights, trade secrets and rights of confidence, in each case ion any part of the world and whether or not registered or registerable;\\015\\012\\342\\200\\234Lender\\342\\200\\235 means the entity which is lending funds to the Buyer in the Transaction;\\015\\012\\342\\200\\234Logo\\342\\200\\235 the logo device displayed in Appendix A in 19.1 below;\\015\\012\\342\\200\\234Party/ies\\342\\200\\235 means the entity/ies with a personal or professional interest in the Transaction;\\015\\012\\342\\200\\234Portal\\342\\200\\235 means the portal available on the Website www.safemovescheme.co.uk, from which the Services can be accessed;\\015\\012\\342\\200\\234Privacy Policy\\342\\200\\235 means our privacy policy which can be found at www.safemovescheme.co.uk, which sets out how we can process personal data on your behalf;\\015\\012\\342\\200\\234Property\\342\\200\\235 means the property being purchased or sold as part of the Transaction;\\015\\012\\342\\200\\234Protected Events\\342\\200\\235 Loss caused by fraud which prevents you from registering your ownership on the HMLR Proprietorship Register following exchange of contracts on the Transaction\\015\\012\\342\\200\\234Report\\342\\200\\235 means the report which is provided by us which incorporates data provided by us, or a Third Party Data Provider;\\015\\012\\342\\200\\234Seller\\342\\200\\235 means the seller in the Transaction;\\015\\012\\342\\200\\234Seller\\342\\200\\231s Conveyancer\\342\\200\\235 means the conveyancing professional acting for and on behalf of the Seller in the Transaction;\\015\\012\\342\\200\\234Services\\342\\200\\235 means the services made available to you by us including fraud detection, prevention and insurance cover referred to as Safe Buyer and Safe Seller as further described in www.safemovescheme.co.uk;\\015\\012\\342\\200\\234Terms and Conditions\\342\\200\\235 means the Safe Move Scheme Terms and Conditions as set out in this document, as amended from time to time by us;\\015\\012\\342\\200\\234Third Party Data Provider\\342\\200\\235 means third parties who licence their data to be delivered by us to provide Services;\\015\\012\\342\\200\\234Transaction\\342\\200\\235 means the sale or purchase of a property;\\015\\012\\342\\200\\234User/s\\342\\200\\235 means any person/s using the Portal;\\015\\012\\342\\200\\234Website\\342\\200\\235 means the website found at www.safemovescheme.co.uk;\\015\\012\\342\\200\\234Working Hours\\342\\200\\235 means 09:00 to 17:00 Monday to Friday excluding bank holidays in England and Wales.\\015\\012\\015\\0124. PROVISON OF THE SERVICES\\015\\012\\015\\0124.1 Subject to Us receiving payment for Services We will provide the Services to You in accordance with these Terms and Conditions.\\015\\012\\015\\0124.2 We will endeavour to make the Services available to You during Working Hours. We will use reasonable endeavours to ensure that any maintenance to the Website or Services only occurs outside of Working Hours; however, You acknowledge and agree that this may sometimes not be possible.\\015\\012\\015\\0124.3 We may from to time to time conduct maintenance of the Services or suspend or discontinue any aspect of the Portal or Website, which may include Your access to it. Subject to Our notifying You to the contrary, any amendments or new content to the Services will be subject to these Terms and Conditions.\\015\\012\\015\\0124.4 You acknowledge and agree that Our ability to provide the Services to You is dependent on the Buyer, the Buyer\\342\\200\\231s Conveyancer, the Seller\\342\\200\\231s Conveyancer and the Seller providing data and paying the charges (as may be relevant). In the event that any of these parties do not provide Us with the information, or fail to pay the relevant charges, We will be unable to provide all or part of the Services to You. You will be notified in the event that the Client has not completed their obligations within certain timescales specified by Us.\\015\\012\\015\\0125. USING THE SAFE MOVE SCHEME\\015\\012\\015\\0125.1 To use the Service, You must login to the Portal and submit true and accurate details. At Our sole discretion, We may refuse Your application for the Services. \\015\\012\\015\\0125.2 We reserve the right to refuse registration to, or suspend Your (or any of Your employees\\342\\200\\231) use of, the Services, the Report, or any associated intellectual property at any time, at Our absolute discretion.\\015\\012\\015\\0125.3 Each login is for a single user only. Your employees may not share their username and password with any other person or with multiple users on a network. \\015\\012\\015\\0125.4 You warrant and undertake that all information provided by You to Us, for the purposes of using the Services, is accurate and complete. \\015\\012\\015\\0125.5 You accept sole responsibility for all use of and for keeping confidential any account ID and password that may have been given to You or chosen by You for use in accessing the Portal. You will notify Us immediately of any unauthorised use of them or any other breach of security of the Portal of which You become aware, or which You reasonably believe may occur. \\015\\012\\015\\0126. INTELLECTUAL PROPERTY\\015\\012\\015\\0126.1 The copyright and all other Intellectual Property Rights relating to the Logo and vesting in the Portal (including all database rights, trade marks, service marks, trading names, text, graphics, code, files and links), the Website and the Report belong to us, or our licensor(s). \\015\\012\\015\\0126.2 Other than the limited licences set out in these Terms and Conditions, nothing shall have the effect of transferring any right title or interest in the Intellectual Property Rights, described at Clause 6.1, to you. \\015\\012\\015\\0126.3 Subject to You complying with Your obligations under this Agreement, We hereby grant You a non-transferable, revocable licence to:\\015\\012\\015\\0126.3.1 Make and store electronic or hard copies of the Report solely in relation to the Transaction;\\015\\012\\015\\0126.3.2 incorporate the Report into written advice prepared by You for the Client or Lender (as the case may be) in the normal course of business; or\\015\\012\\015\\0126.3.3 disclose the Report in the normal course of business to: (i) the Client for whom the Report relates; (ii) the Lender; or (iii) any person who acts in a professional or advisory capacity for any person named in this clause 6.3.3.\\015\\012\\015\\0126.4 Notwithstanding the limited licence granted under clause 6.3, You must not copy, transmit, modify, republish, store (in whole or in part), frame, pass-off or link to any material or information utilised from the Services (or downloaded from the Website) without Our prior written consent. \\015\\012\\015\\0126.5 Without limitation to the rights granted in these Terms and Conditions, the Logo is our registered trade mark. You may not use or copy this or any other logos, brand or trade marks belonging to us without our prior written consent. \\015\\012\\015\\0126.6 You undertake that You will not make or store any copy or copies of the Report, save that You may store the Report only to the extent that it is associated with the Transaction. You shall not store any data contained within the Report in a way which would or could facilitate its use providing search related information against another property transaction. A breach of this clause 6.6 shall be deemed to be irremediable and We shall have the right to immediately terminate this Agreement and any licence granted to You in relation to the use of the Report.\\015\\012\\015\\0126.7 The Website may contain links to Websites operated by third parties. We have no control over their individual content. We therefore make no warranties, or representations as to the accuracy or completeness of any of the information appearing in relation to any linked Websites. The links are for Your convenience only. We do not recommend any products or services advertised on those Websites. If You decide to access any third party Website linked from Our Website, You do so at Your own risk. \\015\\012\\015\\0126.8 Any communications such as press releases, Website content and printed material that make reference to the Safe Move Scheme must be approved in writing by BE Consultancy Ltd before being used.\\015\\012\\015\\0127. DATA\\015\\012\\015\\0127.1 We will collect and process the personal data (as defined in the DPA) provided by Conveyancers and the Client. Our Privacy Policy, applies to all personal data that We collect. The terms of the Privacy Policy, are incorporated into the terms of this Agreement.\\015\\012\\015\\0127.2 We will comply with the DPA in the manner and for the purposes We process personal data provided by You. For the purposes of the DPA, You shall be the data processor and We shall be the data controller.\\015\\012\\015\\0127.3 We will use the personal data provided by You to provide the Services in accordance with the Terms and Conditions and may also:\\015\\012\\015\\0127.3.1 Pass the personal data to a Third Party Data Provider to the extent necessary to allow the Third Party Data Provider to provide services to Us as part of the Services;\\015\\012\\015\\0127.3.2 if We are requested to do so by a regulatory body, governmental authority or court of competent jurisdiction;\\015\\012\\015\\0127.3.3 if We are compelled to do so by law; or\\015\\012\\015\\0127.3.4 if We reasonably believe an emergency, potential illegal activity, or some other reasonable reason exists for doing so.\\015\\012\\015\\0127.4 You shall in processing the data for the purposes of this Agreement:\\015\\012\\015\\0127.4.1 Do so only for the purpose of this Agreement;\\015\\012\\015\\0127.4.2 comply with all relevant information that We (as data controller) may give from time to time;\\015\\012\\015\\0127.4.3 take appropriate technical and organisational security measures to safeguard such data against unauthorised or unlawful processing and against accidental loss or destruction of, or damage to that data;\\015\\012\\015\\0127.4.4 not cause or allow such data to be transferred out of or otherwise processed outside of the European Economic Area;\\015\\012\\015\\0127.4.5 not pass such data on to any third party save its employees and members of its group, except where it has entered into a written contract with that third party under which that third party agrees to obligations that are materially equivalent to those set out in this Clause 7;\\015\\012\\015\\0127.4.6 procure that all members of Your group who reasonably require access to such data for the purposes of this Agreement, comply with the terms of this Clause 7 as if they were a party to them in Your place;\\015\\012\\015\\0127.4.7 notify Us promptly (and in any event within 2 days) of receiving any complaint or subject access request, and comply with all relevant instructions We may give as to how to handle such complaint or subject access request; and\\015\\012\\015\\0127.4.8 notify Us immediately in the event that You become aware of any unauthorised or unlawful processing or accidental loss or destruction of, or damage to such data.\\015\\012\\015\\0127.5 For the purpose of this clause 7, the phrase \\342\\200\\234personal data\\342\\200\\235, \\342\\200\\234data controller\\342\\200\\235, \\342\\200\\234data processor\\342\\200\\235 \\342\\200\\234processor\\342\\200\\235 bear the meaning given in the Data Protection Act 1998.\\015\\012\\015\\0127.6 You warrant and represent that You have received express consent from the Client to allow Us to process their personal data and to use the personal data in the manner set out in clause 7.\\015\\012\\015\\0127.7 To the extent that We may incur any loss, damage, costs (including court and other legal costs), or expenses as a result of Your failure to comply with this clause 7, You shall indemnify Us in full and keep Us indemnified at all times.\\015\\012\\015\\0128. YOUR OBLIGATIONS AND CONDUCT\\015\\012\\015\\0128.1 You accept that You are solely responsible for ensuring that Your computer systems meet all relevant technical specifications necessary to use the Services.\\015\\012\\015\\0128.2 You must not misuse the Services. In particular, Your must not hack into, circumvent security or otherwise disrupt the operation of the Portal, Website or Services, or attempt to carry out any of the foregoing. \\015\\012\\015\\0128.3 You must not use or attempt to use any automated program (including, without limitation, any spider or other Web crawler) to access the Services, Portal or the Website, or to search, display or obtain links to any part of the Services, Portal, or the Website, unless doing so with prior written permission.  Any such use or attempted use of an automated program shall be a misuse of the Services, the Portal and/or the Website. A breach of this clause 8 shall be deemed to be irremediable and We shall have the right to immediately terminate this Agreement.\\015\\012\\015\\0128.4 You must deploy and maintain current industry standard virus protection and take all reasonable precautions to ensure that You do not, and do not allow any third party, directly or indirectly to upload, transmit, or distribute computer viruses, worms, malicious code, macro viruses, Trojan horses, or similar programs.\\015\\012\\015\\0128.5 You must not include links to the Portal or Website in any other Website without Our prior written consent. In particular (but without limiting the foregoing) You must not include in any other Website any "deep link" to any page on the Website other than the home page at www.safemovescheme.co.uk without Our prior written consent. \\015\\012\\015\\0128.6 You must not upload or use inappropriate or offensive language or content or solicit any commercial services in any communication, form or email You send or submit, from or to the Services. \\015\\012\\015\\0128.7 You acknowledge and agree that You shall make reasonable inspection of any Report, whether provided by Us in relation to Services or otherwise, and all associated Data to satisfy Yourself that there are no apparent defects and that You will decide whether or not the transaction may proceed in the best interest of the Client. We will not be liable to You for any such defect or failure to identify such defects.\\015\\012\\015\\0128.8 Notwithstanding Our obligations to Your in relation to the contents of the Report, Your acknowledge and agree that We shall not be liable to You for any professional judgments and decisions that You may make resulting from the Report.\\015\\012\\015\\0128.9 You warrant and represent that:\\015\\012\\015\\0128.9.1 The information supplied by You when utilising the Services is true, accurate and complete and that it will notify Us in writing of any changes in such information;\\015\\012\\015\\0128.9.2 You will keep all information provided by Us confidential and shall take all reasonable steps to ensure that any such information provided to third parties is also kept confidential. In doing so You shall ensure that such confidential information is kept in a manner no less secure than Your own confidential information.\\015\\012\\015\\0128.9.3 You will not allow any third party to use the Portal or any materials (including the Report), documents or data taken from the Portal or Website;\\015\\012\\015\\0128.9.4 You are authorised to receive the Services in accordance with the Terms and Conditions; \\015\\012\\015\\0128.9.5 You will keep confidential and secure all user names and passwords used in relation to the Services; \\015\\012\\015\\0128.9.6 You warrant and represent that You will ensure all images of documents that You upload to the Portal are good quality faithful representations of the document in Your possession;\\015\\012\\015\\0128.9.7 You will ensure all documents that You upload to the Portal have not been altered for the purpose of misleading any user; and\\015\\012\\015\\0128.9.8 You will only upload appropriate documents and images to the Portal; and\\015\\012\\015\\0128.9.9 You will not copy, replicate, or reconstruct (or attempt any of them, or procure a third party to undertake any of them on Your behalf) any aspect of the Services.\\015\\012\\015\\0129. CHARGES\\015\\012\\015\\0129.1 You acknowledge and agree that the provision of the Services to You is subject to the payment of the Charges. In the event that the Charges are not paid within the period of time as specified by Us, We will notify You by email.\\015\\012\\015\\0129.2 You also acknowledge that elements of the Services are dependent on the fulfilment of tasks by the Buyer, Seller, Buyer\\342\\200\\231s Conveyancer and Seller\\342\\200\\231s Conveyancer. To the extent that any of the above fails to fulfil these tasks, We may be unable to provide the Seller\\342\\200\\231s Conveyancer\\342\\200\\231s Data, the Seller\\342\\200\\231s data, or any information in relation to the Property in the Report.\\015\\012\\015\\0129.3 You also acknowledge that elements of the Services are dependent on the payment of further charges. To the extent that if the charges remain unpaid, We will be unable to provide Insurance or any information in relation to the Property in the Report.\\015\\012\\015\\01210. BARRING FROM THE SYSTEM\\015\\012\\015\\01210.1 We reserve the right to bar users from the Portal and/or restrict or block their access or use of any and all elements of the Services, on a permanent or temporary basis at Our sole discretion. Any such user shall be notified and must not then attempt to use the Services under any other name or through any other user. \\015\\012\\015\\01211. WARRANTY\\015\\012\\015\\01211.1 Whilst We endeavour to ensure that any material provided under the Services and available from the Portal and Website is not contaminated in any way, We do not warrant that such material will be free from infection, viruses and/or similar code. We also do not accept any liability for loss of Your password or account ID caused by a breakdown, error, loss of power or otherwise caused by or to Your computer system or network.\\015\\012\\015\\01211.2 We warrant that:\\015\\012\\015\\01211.2.1 The Services will be performed with reasonable skill and care and in accordance with these Terms and Conditions;\\015\\012\\015\\01211.2.2 We are authorised to provide the Services;\\015\\012\\015\\01211.2.3 the provision of the Services will not infringe any third party Intellectual Property Rights; and\\015\\012\\015\\01211.2.4 the Services will comply with all relevant laws, regulations and codes of practice.\\015\\012\\015\\01211.3 Due to the nature of software and the internet, We do not warrant that Your access to, or the running of, the Portal will be uninterrupted or error free. We shall not be liable if We cannot process Your request due to circumstances beyond Our reasonable control.\\015\\012\\015\\01211.4 The information provided under the Services does not constitute specific advice. Whilst We endeavour to ensure that the information provided is accurate, complete and up-to-date We make no warranties or representations that this is the case.\\015\\012\\015\\01211.5 We make no warranty or guarantee that the Services, Website or Portal, or any information available over any of them, comply with laws other than those of England and Wales.\\015\\012\\015\\01211.6 To the maximum extent permitted by law, We make no representations, warranties or conditions of any kind, either express or implied, with respect to any data provided by a Third Party Data Provider, including (but not limited to) any warranty that the responses are complete, accurate, of satisfactory quality, or fit for a particular purpose.\\015\\012\\015\\01212. LIABILITY\\015\\012\\015\\01212.1 Nothing in these Terms and Conditions will be deemed to exclude Our liability to You for death or personal injury arising from Our negligence, or any other liability the exclusion or restriction of which is expressly prohibited by law. \\015\\012\\015\\01212.2 You acknowledge and accept that We only provide the Services on the express condition that We will not be responsible for nor shall We have any liability to You, the Clients, the Seller, the Seller\\342\\200\\231s Conveyancer, the Buyer\\342\\200\\231s Conveyancer, any Party or any third party directly, indirectly, whether in contract, tort or otherwise for:\\015\\012\\015\\01212.2.1 Inaccuracies or errors in or omissions from any data provided by a Third Party Data Provider;\\015\\012\\015\\01212.2.2 inaccuracies or errors in or omissions from any register or other information source maintained or used by a Third Party Data Provider; or\\015\\012\\015\\01212.2.3 any act or omission by a Third Party Data Provider.\\015\\012\\015\\01212.3 We shall not be liable for any loss or damage sustained by You, the Clients, or any other third party directly or indirectly whether in contract, tort or otherwise making use of or relying on the Report including but not limited to any loss or damage resulting as a consequence of:\\015\\012\\015\\01212.3.1 any failure by You to have in place all necessary means of receiving the Report, the maintenance of internet access, appropriate email facilities or security measures; or\\015\\012\\015\\01212.3.2 (i) inaccuracies or errors in or omission from any Report; or (ii) any Report which is inaccurate, incomplete, illegal, out of sequence or in the wrong form, or in respect of the wrong Client; unless and then only to the extent that, the loss or damage sustained shall be as a direct consequence of the negligent act or omission by Us.\\015\\012\\015\\01212.4 We may put in place such systems as We from time to time see fit to prevent automated programs being used to obtain unauthorised access to the Services, Portal and Website. You are not permitted to use automated programs for such purposes and any such use or attempted use by You of such automated programs is at Your own risk. Subject to clause 12.2, We shall not be liable to You for any consequences arising out of or in connection with any such use or attempted use of automated programs to obtain unauthorised access to the Services, Website, or Portal. \\015\\012\\015\\01212.5 Without prejudice and subject to the foregoing clauses, Our total aggregate liability for all claims by You, the Clients, or any third parties, whether in contract, tort or otherwise for any breach of Our obligations under this Agreement, shall not exceed the lesser of:\\015\\012\\015\\01212.5.1 (i) the value of the interest(s) being acquired; or (ii) the amount of loan(s) being made; or (iii) the purchase price paid; (as the case may be) by the claiming parties in or for (or against the security of) the property/ properties in respect of which the Report relates; or\\015\\012\\015\\01212.5.2 where the Report is/ are being made for a purpose other than obtaining Services, the value of the property/ properties in respect of which the Report was/ Were made as at the date of the Report; or\\015\\012\\015\\01212.5.3 the sum of \\302\\2431,000,000.\\015\\012\\015\\01212.6 Subject to clauses 12.2 inclusive, We shall not be liable to You for any indirect, consequential, special or punitive loss, damage, costs and expenses; together with any directly or indirectly incurred: loss of profit; loss of business; loss of reputation; depletion of goodwill; or loss of, damage to or corruption of data.\\015\\012\\015\\01212.7 You accept that when You use the Services, details will be passed directly to Conveyancers, lending institutions and other relevant organisations providing related services to the Safe Move Scheme to reduce the risk of fraudulent transactions occurring. Whilst We prohibit these organisations from contacting Your customers for any other reason other than facilitating the Safe Move Scheme, We do not accept any liability for any subsequent communications that You and Your customers receive directly from these organisations. \\015\\012\\015\\01212.8 We do not provide advice and any information provided in accordance with the Services is provided to enable professional advisers to make a more informed decision. We do not accept any liability for any advice provided by lawyers or any other organisation associated with the Services and do not accept responsibility for any loss resulting from reliance on any such advice.\\015\\012\\015\\01212.9 We do not accept financial responsibility for any financial loss incurred as a result of the performance of an organisation associated with the Services.\\015\\012\\015\\01212.10 We shall have no liability to any third party, unless expressly agreed by Us in writing.\\015\\012\\015\\01213. TERMINATION\\015\\012\\015\\01213.1 Without prejudice to Our other rights and remedies, We may, at Our absolute discretion, terminate this Agreement or Your account with Us if:\\015\\012\\015\\01213.1.1 You cease to be an accredited member of Your profession;\\015\\012\\015\\01213.1.2 We believe, in Our reasonable opinion, that You have materially breached these Terms and Conditions or acted in a manner inconsistent with these Terms and Conditions;\\015\\012\\015\\01213.1.3 You cease or threaten to cease to carry on Your business;\\015\\012\\015\\01213.1.4 You have a liquidator, receiver or administrative receiver appointed to You or over any part of Your undertaking or assets;\\015\\012\\015\\01213.1.5 You pass, or propose to pass a resolution for winding up (other than for a bona fide scheme or solvent amalgamation or reconstruction where the resultant entity shall assume all Your liabilities) and/ or You convene a meeting with Your creditors;\\015\\012\\015\\01213.1.6 You are declared bankrupt, or are subject to a bankruptcy petition, or You are wound up by court order or are subject to a winding up petition;\\015\\012\\015\\01213.1.7 You propose, or enter into, any voluntary arrangement with Your creditors;\\015\\012\\015\\01213.1.8 You take, or are subject to any steps (including making of an application or giving of notice) for the appointment or proposed appointment of an administrator;\\015\\012\\015\\01213.1.9 You are subject to any other proceedings relating to Your solvency or possible solvency; or\\015\\012\\015\\01213.1.10 You are subject to any similar action in any jurisdiction because of debt.\\015\\012\\015\\01213.2 We may terminate Your account without notice (including all usernames and passwords) if any information is or becomes untrue, inaccurate, out of date, or incomplete.\\015\\012\\015\\01213.3 You may terminate Your account at any time by giving 28 days written notice to Us.\\015\\012\\015\\01213.4 In the event of termination of Your account at any time, Your entitlement to use the Services ceases immediately. You acknowledge that any Charges paid by the Client may still remain payable.\\015\\012\\015\\01213.5 Clauses 6, 7, 9, 11, 12 and 14 shall survive termination of expiry of the Agreement.\\015\\012\\015\\01213.6 Notwithstanding termination or expiry, We will fulfil any Report which You have ordered (and which has been paid for by the Client) prior to the termination or expiry, unless You have breached Clauses 6.5 or 8.2 of this Agreement.\\015\\012\\015\\01213.7 We may terminate or suspend any user accounts that have been inactive for a period of greater than 12 months.\\015\\012\\015\\01214. LEGAL JURISDICTION\\015\\012\\015\\01214.1 English law shall apply to these Terms and Conditions and any non-contractual obligations arising out of or in connections with them. Both parties irrevocably agree that the courts of England and Wales will have exclusive jurisdiction to settle any dispute which may arise out of, under, or in connection with these Terms and for those purposes irrevocably submit all disputes to the exclusive jurisdiction of the English courts. \\015\\012\\015\\01215. NOTICES\\015\\012\\015\\01215.1 All notices shall be given:\\015\\012\\015\\01215.1.1 To Us, by recorded post to BE Consultancy Limited. Our address is Marlesfield House, 114 - 116 Main Road, Sidcup, DA14 6NG; and\\015\\012\\015\\01215.1.2 to You, by email to the email address that You provide to Us at the point of Your registration.\\015\\012\\015\\01215.2 All notices sent by email will be deemed to have been received on receipt (or, when received on a UK national holiday or on a Saturday or a Sunday, the next working day following the day of receipt). All notice sent by post will be deemed to have been received upon signature of a current employee of BE Consultancy Limited.\\015\\012\\015\\01216. CUSTOMER FEEDBACK AND QUALITY\\015\\012\\015\\01216.1 We operate a system to ensure that all customer feedback is dealt with fairly and consistently, and is properly recorded. We Welcome any suggestions that You make about how We may improve Our service. Please write to Us at Customer Services, BE Consultancy Limited, Marlesfield House, 114 - 116 Main Road, Sidcup, DA14 6NG. We aim to acknowledge all customer feedback. \\015\\012\\015\\01216.2 Phone calls directed to Our offices may be recorded for training and quality purposes.\\015\\012\\015\\01217. GENERAL\\015\\012\\015\\01217.1 We will not be liable for any delay, interruption or failure in performance or Our obligations under this Agreement if caused or contributed to by any circumstance which is outside Our reasonable control, including (without limitation) war (declared or undeclared), flood, riot, act of god, strike or other labour dispute, suspension or delay of service at public registries, delays or failures by Third Party Data Providers, change in the law, lack of power, or telecommunications failure.\\015\\012\\015\\01217.2 System maintenance will be conducted where possible outside normal business hours to minimise inconvenience for users.\\015\\012\\015\\01217.3 These Terms and Conditions are the whole agreement between You and Us. You acknowledge that You have not entered into this agreement in reliance on any warranty or representation made by Us (unless made fraudulently). \\015\\012\\015\\01217.4 If a court decides that any part of these Terms and Conditions cannot be enforced, that particular part of these Terms will not apply, but the rest of these Terms and Conditions will. \\015\\012\\015\\01217.5 A waiver by a party of a breach of any provision shall not be deemed a continuing waiver or a waiver of any subsequent breach of the same or any other provisions. Failure or delay in exercising any right under these Terms shall not prevent the exercise of that or any other right. \\015\\012\\015\\01217.6 You may not assign or transfer any benefit, interest or obligation under these Terms. \\015\\012\\015\\01217.7 The provisions of the Contracts (Rights of Third Parties) Act 1999 shall not apply to these Terms. \\015\\012\\015\\01217.8 These Terms and Conditions were last updated on 22nd September 2015.\\015\\012\\015\\01218. APPENDIX A\\015\\012\\015\\01218.1\\015\\012</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <TextOptions>,,,,WordWrap=True,A=0</TextOptions>\\015\\012              <Type>Expression</Type>\\015\\012            </TextContent>\\015\\012            <Image2 Ref="8" type="Image" isKey="true">\\015\\012              <AspectRatio>True</AspectRatio>\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>1.2,3.2,12,3</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Guid>4302b0556ae84b0bb92f899f03f02ec3</Guid>\\015\\012              <Image>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BwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEA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AAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAADL/d//+//J4YbMMrwhwgAAAABJRU5ErkJggg==</Image>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>Image2</Name>\\015\\012              <Page isRef="2" />\\015\\012              <Parent isRef="6" />\\015\\012              <Stretch>True</Stretch>\\015\\012            </Image2>\\015\\012          </Components>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Filters isList="true" count="0" />\\015\\012          <Name>DataBand1</Name>\\015\\012          <Page isRef="2" />\\015\\012          <Parent isRef="2" />\\015\\012          <Sort isList="true" count="0" />\\015\\012        </DataBand1>\\015\\012      </Components>\\015\\012      <Conditions isList="true" count="0" />\\015\\012      <Guid>2673caf849244e118b74ecc2b931b511</Guid>\\015\\012      <Margins>1,1,1,1</Margins>\\015\\012      <Name>Page1</Name>\\015\\012      <PageHeight>29.7</PageHeight>\\015\\012      <PageWidth>21</PageWidth>\\015\\012      <Report isRef="0" />\\015\\012      <Watermark Ref="9" type="Stimulsoft.Report.Components.StiWatermark" isKey="true">\\015\\012        <Font>Arial,100</Font>\\015\\012        <TextBrush>[50:0:0:0]</TextBrush>\\015\\012      </Watermark>\\015\\012    </Page1>\\015\\012  </Pages>\\015\\012  <PrinterSettings Ref="10" type="Stimulsoft.Report.Print.StiPrinterSettings" isKey="true" />\\015\\012  <ReferencedAssemblies isList="true" count="8">\\015\\012    <value>System.Dll</value>\\015\\012    <value>System.Drawing.Dll</value>\\015\\012    <value>System.Windows.Forms.Dll</value>\\015\\012    <value>System.Data.Dll</value>\\015\\012    <value>System.Xml.Dll</value>\\015\\012    <value>Stimulsoft.Controls.Dll</value>\\015\\012    <value>Stimulsoft.Base.Dll</value>\\015\\012    <value>Stimulsoft.Report.Dll</value>\\015\\012  </ReferencedAssemblies>\\015\\012  <ReportAlias>Report</ReportAlias>\\015\\012  <ReportChanged>9/23/2015 11:01:52 AM</ReportChanged>\\015\\012  <ReportCreated>4/20/2015 5:01:58 PM</ReportCreated>\\015\\012  <ReportFile>C:\\134Reports\\134TcFirmConveyancing.mrt</ReportFile>\\015\\012  <ReportGuid>1ebb47fba9de48d09e4e05544f1f7652</ReportGuid>\\015\\012  <ReportName>Report</ReportName>\\015\\012  <ReportUnit>Centimeters</ReportUnit>\\015\\012  <ReportVersion>2015.1.8</ReportVersion>\\015\\012  <Script>using System;\\015\\012using System.Drawing;\\015\\012using System.Windows.Forms;\\015\\012using System.Data;\\015\\012using Stimulsoft.Controls;\\015\\012using Stimulsoft.Base.Drawing;\\015\\012using Stimulsoft.Report;\\015\\012using Stimulsoft.Report.Dialogs;\\015\\012using Stimulsoft.Report.Components;\\015\\012\\015\\012namespace Reports\\015\\012{\\015\\012    public class Report : Stimulsoft.Report.StiReport\\015\\012    {\\015\\012        public Report()        {\\015\\012            this.InitializeComponent();\\015\\012        }\\015\\012\\015\\012        #region StiReport Designer generated code - do not modify\\015\\012\\011\\011#endregion StiReport Designer generated code - do not modify\\015\\012    }\\015\\012}\\015\\012</Script>\\015\\012  <ScriptLanguage>CSharp</ScriptLanguage>\\015\\012  <Styles isList="true" count="0" />\\015\\012</StiSerializer>',
  true,
  false,
  CURRENT_DATE,
  true,
  false
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
  '4fbbb7fe-489f-11e4-b824-13eff2d1a1e2',
  'TcMortgageBroker',
  'Mortgage Broker Terms and Conditions Resource',
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
  '4faaa2fe-489f-11e4-8f39-5f438902bf9f',
  1,
  null,
  '4fbbb7fe-489f-11e4-b824-13eff2d1a1e2',
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1),
  null,
  null,
  true,
  false,
  null
);


-- Lender TsCs
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
  '4fccc2fe-489f-11e4-8f39-5f438902bf9f',
  1,
  'TcLender',
  'Lender Terms and Conditions',
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
  '4fccc2fe-489f-11e4-8f39-5f438902bf9f',
  1,
  E'\\357\\273\\277<?xml version="1.0" encoding="utf-8" standalone="yes"?>\\015\\012<StiSerializer version="1.02" type="Net" application="StiReport">\\015\\012  <Dictionary Ref="1" type="Dictionary" isKey="true">\\015\\012    <BusinessObjects isList="true" count="0" />\\015\\012    <Databases isList="true" count="0" />\\015\\012    <DataSources isList="true" count="0" />\\015\\012    <Relations isList="true" count="0" />\\015\\012    <Report isRef="0" />\\015\\012    <Variables isList="true" count="1">\\015\\012      <value>General</value>\\015\\012    </Variables>\\015\\012  </Dictionary>\\015\\012  <EngineVersion>EngineV2</EngineVersion>\\015\\012  <GlobalizationStrings isList="true" count="0" />\\015\\012  <MetaTags isList="true" count="0" />\\015\\012  <Pages isList="true" count="1">\\015\\012    <Page1 Ref="2" type="Page" isKey="true">\\015\\012      <Border>None;Black;2;Solid;False;4;Black</Border>\\015\\012      <Brush>Transparent</Brush>\\015\\012      <Components isList="true" count="2">\\015\\012        <PageHeaderBand1 Ref="3" type="PageHeaderBand" isKey="true">\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>0,0.4,19,3.2</ClientRectangle>\\015\\012          <Components isList="true" count="2">\\015\\012            <Image1 Ref="4" type="Image" isKey="true">\\015\\012              <AspectRatio>True</AspectRatio>\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>0,0,12,3</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Guid>d4618a2ea202466e9f00d982451b0609</Guid>\\015\\012              <Image>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BwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEA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AAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAADL/d//+//J4YbMMrwhwgAAAABJRU5ErkJggg==</Image>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>Image1</Name>\\015\\012              <Page isRef="2" />\\015\\012              <Parent isRef="3" />\\015\\012              <Stretch>True</Stretch>\\015\\012            </Image1>\\015\\012            <TextVersion Ref="5" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>16.6,0,2.4,0.6</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,8</Font>\\015\\012              <Guid>d453c64579d24772b1ade666371c2ffb</Guid>\\015\\012              <HorAlignment>Right</HorAlignment>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>TextVersion</Name>\\015\\012              <Page isRef="2" />\\015\\012              <Parent isRef="3" />\\015\\012              <Text>Version: 1.0</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <Type>Expression</Type>\\015\\012            </TextVersion>\\015\\012          </Components>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Name>PageHeaderBand1</Name>\\015\\012          <Page isRef="2" />\\015\\012          <Parent isRef="2" />\\015\\012        </PageHeaderBand1>\\015\\012        <DataBand1 Ref="6" type="DataBand" isKey="true">\\015\\012          <Brush>Transparent</Brush>\\015\\012          <CanBreak>True</CanBreak>\\015\\012          <ClientRectangle>0,4.4,19,6.4</ClientRectangle>\\015\\012          <Components isList="true" count="2">\\015\\012            <TextContent Ref="7" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <CanBreak>True</CanBreak>\\015\\012              <CanGrow>True</CanGrow>\\015\\012              <ClientRectangle>0,0,19,3.2</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,8</Font>\\015\\012              <Guid>2aadb8b5addd4e31b8b69efa105a7b28</Guid>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>TextContent</Name>\\015\\012              <Page isRef="2" />\\015\\012              <Parent isRef="6" />\\015\\012              <Text>The Safe Move Scheme Terms and Conditions for Conveyancing Organisations Representing Property Buyers, Sellers and Lenders\\015\\012\\015\\0121. GENERAL\\015\\012\\015\\0121.1 These Terms and Conditions are a legal agreement between Your organisation or company (\\342\\200\\234Licensee\\342\\200\\235, \\342\\200\\234Your\\342\\200\\235 or \\342\\200\\234You\\342\\200\\235) and BE Consultancy Limited (company number 05742032) trading as \\342\\200\\230the Safe Move Scheme\\342\\200\\231 and Our registered address is Marlesfield House, 114 - 116 Main Road, Sidcup, DA14 6NG (\\342\\200\\234Licensor\\342\\200\\235, \\342\\200\\234We\\342\\200\\235, \\342\\200\\234Our\\342\\200\\235, or \\342\\200\\234Us\\342\\200\\235). \\015\\012\\015\\0121.2 These Terms and Conditions govern Your use of Our Safe Move Scheme, which is accessible by way of the Website and Our provision of the Services to You.\\015\\012\\015\\0121.3 We agree to provide the Services to You via the Website in accordance with these Terms and Conditions. These Terms and Conditions do not transfer any rights or title in the Services, Website (or anything created by either) to You and We remain the owner at all times.\\015\\012\\015\\0121.4 We reserve the right to decline the provision of the Services to any user at any time\\015\\012\\015\\0122. IMPORTANT NOTICE TO ALL USERS\\015\\012\\015\\0122.1 WE ADVISE YOU TO PRINT AND KEEP A COPY OF THESE TERMS AND CONDITIONS.\\015\\012\\015\\0122.2 By selecting the box below You agree to be bound by these Terms and Conditions, which will bind You and Your employees. Please note the limitations of liability set out at clause 12.\\015\\012\\015\\0122.3 If You do not agree to these Terms and Conditions, We are not able to provide the Services to You and You must discontinue the process now.  In this case, the process will end and You will not be able to access or make use of the Services.\\015\\012\\015\\0122.4 These Terms and Conditions are a legal agreement between us and can only be modified with our written consent. We may change these Terms and Conditions at our discretion by changing them on our website. Clause 17.8 states when the last changes were made. The current version of these Terms and Conditions as displayed on our Portal, will apply. \\015\\012\\015\\0122.5 Misuse of the Services is prohibited. Please refer to clause 8 for Your obligations in relation to the use of the Services. \\015\\012\\015\\0123. DEFINITIONS\\015\\012\\015\\0123.1 In these Terms and Conditions, the following definitions shall apply:\\015\\012\\015\\012\\342\\200\\234Agreement\\342\\200\\235 means the agreement between us which incorporates these Terms and Conditions;\\015\\012\\342\\200\\234Buyer\\342\\200\\235 means the buyer in the Transaction;\\015\\012\\342\\200\\234Buyer\\342\\200\\231s Conveyancer\\342\\200\\235 means the conveyancing professional acting for and on behalf of the Buyer in the Transaction;\\015\\012\\342\\200\\234Charges\\342\\200\\235 means the charges payable for the provision of the Services;\\015\\012\\342\\200\\234Client\\342\\200\\235 means the person/s and/or organisation/s who has instructed the conveyancer in relation to the Transaction;\\015\\012\\342\\200\\234Client Data\\342\\200\\235 means the data added by the Client or on behalf of the Client;\\015\\012\\342\\200\\234Conveyancers\\342\\200\\235 means all conveyancing professionals acting for and on behalf of the Seller and Buyer and Lender in the Transaction;\\015\\012\\342\\200\\234Data\\342\\200\\235 means any Client Data, any data relating to \\342\\200\\231parties\\342\\200\\231 involved in the Transaction, together with any data collected by the system relating to the Transaction;\\015\\012\\342\\200\\234DPA\\342\\200\\235 means the Data Protection Act 1998, as amended and updated from time to time;\\015\\012\\342\\200\\234Insurance\\342\\200\\235 means the insurance policy supplied by us as part of providing Services;\\015\\012\\342\\200\\234Intellectual Property Rights\\342\\200\\235 means all intellectual property rights and industry property rights of any kind including without limitation patents, patent applications, copyright, know how, technical and commercial information, design (whether registered or unregistered), design rights, internet domain names, database rights, trade marks, service marks or business names, applications to register any of the foregoing rights, trade secrets and rights of confidence, in each case ion any part of the world and whether or not registered or registerable;\\015\\012\\342\\200\\234Lender\\342\\200\\235 means the entity which is lending funds to the Buyer in the Transaction;\\015\\012\\342\\200\\234Logo\\342\\200\\235 the logo device displayed in Appendix A in 19.1 below;\\015\\012\\342\\200\\234Party/ies\\342\\200\\235 means the entity/ies with a personal or professional interest in the Transaction;\\015\\012\\342\\200\\234Portal\\342\\200\\235 means the portal available on the Website www.safemovescheme.co.uk, from which the Services can be accessed;\\015\\012\\342\\200\\234Privacy Policy\\342\\200\\235 means our privacy policy which can be found at www.safemovescheme.co.uk, which sets out how we can process personal data on your behalf;\\015\\012\\342\\200\\234Property\\342\\200\\235 means the property being purchased or sold as part of the Transaction;\\015\\012\\342\\200\\234Protected Events\\342\\200\\235 Loss caused by fraud which prevents you from registering your ownership on the HMLR Proprietorship Register following exchange of contracts on the Transaction\\015\\012\\342\\200\\234Report\\342\\200\\235 means the report which is provided by us which incorporates data provided by us, or a Third Party Data Provider;\\015\\012\\342\\200\\234Seller\\342\\200\\235 means the seller in the Transaction;\\015\\012\\342\\200\\234Seller\\342\\200\\231s Conveyancer\\342\\200\\235 means the conveyancing professional acting for and on behalf of the Seller in the Transaction;\\015\\012\\342\\200\\234Services\\342\\200\\235 means the services made available to you by us including fraud detection, prevention and insurance cover referred to as Safe Buyer and Safe Seller as further described in www.safemovescheme.co.uk;\\015\\012\\342\\200\\234Terms and Conditions\\342\\200\\235 means the Safe Move Scheme Terms and Conditions as set out in this document, as amended from time to time by us;\\015\\012\\342\\200\\234Third Party Data Provider\\342\\200\\235 means third parties who licence their data to be delivered by us to provide Services;\\015\\012\\342\\200\\234Transaction\\342\\200\\235 means the sale or purchase of a property;\\015\\012\\342\\200\\234User/s\\342\\200\\235 means any person/s using the Portal;\\015\\012\\342\\200\\234Website\\342\\200\\235 means the website found at www.safemovescheme.co.uk;\\015\\012\\342\\200\\234Working Hours\\342\\200\\235 means 09:00 to 17:00 Monday to Friday excluding bank holidays in England and Wales.\\015\\012\\015\\0124. PROVISON OF THE SERVICES\\015\\012\\015\\0124.1 Subject to Us receiving payment for Services We will provide the Services to You in accordance with these Terms and Conditions.\\015\\012\\015\\0124.2 We will endeavour to make the Services available to You during Working Hours. We will use reasonable endeavours to ensure that any maintenance to the Website or Services only occurs outside of Working Hours; however, You acknowledge and agree that this may sometimes not be possible.\\015\\012\\015\\0124.3 We may from to time to time conduct maintenance of the Services or suspend or discontinue any aspect of the Portal or Website, which may include Your access to it. Subject to Our notifying You to the contrary, any amendments or new content to the Services will be subject to these Terms and Conditions.\\015\\012\\015\\0124.4 You acknowledge and agree that Our ability to provide the Services to You is dependent on the Buyer, the Buyer\\342\\200\\231s Conveyancer, the Seller\\342\\200\\231s Conveyancer and the Seller providing data and paying the charges (as may be relevant). In the event that any of these parties do not provide Us with the information, or fail to pay the relevant charges, We will be unable to provide all or part of the Services to You. You will be notified in the event that the Client has not completed their obligations within certain timescales specified by Us.\\015\\012\\015\\0125. USING THE SAFE MOVE SCHEME\\015\\012\\015\\0125.1 To use the Service, You must login to the Portal and submit true and accurate details. At Our sole discretion, We may refuse Your application for the Services. \\015\\012\\015\\0125.2 We reserve the right to refuse registration to, or suspend Your (or any of Your employees\\342\\200\\231) use of, the Services, the Report, or any associated intellectual property at any time, at Our absolute discretion.\\015\\012\\015\\0125.3 Each login is for a single user only. Your employees may not share their username and password with any other person or with multiple users on a network. \\015\\012\\015\\0125.4 You warrant and undertake that all information provided by You to Us, for the purposes of using the Services, is accurate and complete. \\015\\012\\015\\0125.5 You accept sole responsibility for all use of and for keeping confidential any account ID and password that may have been given to You or chosen by You for use in accessing the Portal. You will notify Us immediately of any unauthorised use of them or any other breach of security of the Portal of which You become aware, or which You reasonably believe may occur. \\015\\012\\015\\0126. INTELLECTUAL PROPERTY\\015\\012\\015\\0126.1 The copyright and all other Intellectual Property Rights relating to the Logo and vesting in the Portal (including all database rights, trade marks, service marks, trading names, text, graphics, code, files and links), the Website and the Report belong to us, or our licensor(s). \\015\\012\\015\\0126.2 Other than the limited licences set out in these Terms and Conditions, nothing shall have the effect of transferring any right title or interest in the Intellectual Property Rights, described at Clause 6.1, to you. \\015\\012\\015\\0126.3 Subject to You complying with Your obligations under this Agreement, We hereby grant You a non-transferable, revocable licence to:\\015\\012\\015\\0126.3.1 Make and store electronic or hard copies of the Report solely in relation to the Transaction;\\015\\012\\015\\0126.3.2 incorporate the Report into written advice prepared by You for the Client or Lender (as the case may be) in the normal course of business; or\\015\\012\\015\\0126.3.3 disclose the Report in the normal course of business to: (i) the Client for whom the Report relates; (ii) the Lender; or (iii) any person who acts in a professional or advisory capacity for any person named in this clause 6.3.3.\\015\\012\\015\\0126.4 Notwithstanding the limited licence granted under clause 6.3, You must not copy, transmit, modify, republish, store (in whole or in part), frame, pass-off or link to any material or information utilised from the Services (or downloaded from the Website) without Our prior written consent. \\015\\012\\015\\0126.5 Without limitation to the rights granted in these Terms and Conditions, the Logo is our registered trade mark. You may not use or copy this or any other logos, brand or trade marks belonging to us without our prior written consent. \\015\\012\\015\\0126.6 You undertake that You will not make or store any copy or copies of the Report, save that You may store the Report only to the extent that it is associated with the Transaction. You shall not store any data contained within the Report in a way which would or could facilitate its use providing search related information against another property transaction. A breach of this clause 6.6 shall be deemed to be irremediable and We shall have the right to immediately terminate this Agreement and any licence granted to You in relation to the use of the Report.\\015\\012\\015\\0126.7 The Website may contain links to Websites operated by third parties. We have no control over their individual content. We therefore make no warranties, or representations as to the accuracy or completeness of any of the information appearing in relation to any linked Websites. The links are for Your convenience only. We do not recommend any products or services advertised on those Websites. If You decide to access any third party Website linked from Our Website, You do so at Your own risk. \\015\\012\\015\\0126.8 Any communications such as press releases, Website content and printed material that make reference to the Safe Move Scheme must be approved in writing by BE Consultancy Ltd before being used.\\015\\012\\015\\0127. DATA\\015\\012\\015\\0127.1 We will collect and process the personal data (as defined in the DPA) provided by Conveyancers and the Client. Our Privacy Policy, applies to all personal data that We collect. The terms of the Privacy Policy, are incorporated into the terms of this Agreement.\\015\\012\\015\\0127.2 We will comply with the DPA in the manner and for the purposes We process personal data provided by You. For the purposes of the DPA, You shall be the data processor and We shall be the data controller.\\015\\012\\015\\0127.3 We will use the personal data provided by You to provide the Services in accordance with the Terms and Conditions and may also:\\015\\012\\015\\0127.3.1 Pass the personal data to a Third Party Data Provider to the extent necessary to allow the Third Party Data Provider to provide services to Us as part of the Services;\\015\\012\\015\\0127.3.2 if We are requested to do so by a regulatory body, governmental authority or court of competent jurisdiction;\\015\\012\\015\\0127.3.3 if We are compelled to do so by law; or\\015\\012\\015\\0127.3.4 if We reasonably believe an emergency, potential illegal activity, or some other reasonable reason exists for doing so.\\015\\012\\015\\0127.4 You shall in processing the data for the purposes of this Agreement:\\015\\012\\015\\0127.4.1 Do so only for the purpose of this Agreement;\\015\\012\\015\\0127.4.2 comply with all relevant information that We (as data controller) may give from time to time;\\015\\012\\015\\0127.4.3 take appropriate technical and organisational security measures to safeguard such data against unauthorised or unlawful processing and against accidental loss or destruction of, or damage to that data;\\015\\012\\015\\0127.4.4 not cause or allow such data to be transferred out of or otherwise processed outside of the European Economic Area;\\015\\012\\015\\0127.4.5 not pass such data on to any third party save its employees and members of its group, except where it has entered into a written contract with that third party under which that third party agrees to obligations that are materially equivalent to those set out in this Clause 7;\\015\\012\\015\\0127.4.6 procure that all members of Your group who reasonably require access to such data for the purposes of this Agreement, comply with the terms of this Clause 7 as if they were a party to them in Your place;\\015\\012\\015\\0127.4.7 notify Us promptly (and in any event within 2 days) of receiving any complaint or subject access request, and comply with all relevant instructions We may give as to how to handle such complaint or subject access request; and\\015\\012\\015\\0127.4.8 notify Us immediately in the event that You become aware of any unauthorised or unlawful processing or accidental loss or destruction of, or damage to such data.\\015\\012\\015\\0127.5 For the purpose of this clause 7, the phrase \\342\\200\\234personal data\\342\\200\\235, \\342\\200\\234data controller\\342\\200\\235, \\342\\200\\234data processor\\342\\200\\235 \\342\\200\\234processor\\342\\200\\235 bear the meaning given in the Data Protection Act 1998.\\015\\012\\015\\0127.6 You warrant and represent that You have received express consent from the Client to allow Us to process their personal data and to use the personal data in the manner set out in clause 7.\\015\\012\\015\\0127.7 To the extent that We may incur any loss, damage, costs (including court and other legal costs), or expenses as a result of Your failure to comply with this clause 7, You shall indemnify Us in full and keep Us indemnified at all times.\\015\\012\\015\\0128. YOUR OBLIGATIONS AND CONDUCT\\015\\012\\015\\0128.1 You accept that You are solely responsible for ensuring that Your computer systems meet all relevant technical specifications necessary to use the Services.\\015\\012\\015\\0128.2 You must not misuse the Services. In particular, Your must not hack into, circumvent security or otherwise disrupt the operation of the Portal, Website or Services, or attempt to carry out any of the foregoing. \\015\\012\\015\\0128.3 You must not use or attempt to use any automated program (including, without limitation, any spider or other Web crawler) to access the Services, Portal or the Website, or to search, display or obtain links to any part of the Services, Portal, or the Website, unless doing so with prior written permission.  Any such use or attempted use of an automated program shall be a misuse of the Services, the Portal and/or the Website. A breach of this clause 8 shall be deemed to be irremediable and We shall have the right to immediately terminate this Agreement.\\015\\012\\015\\0128.4 You must deploy and maintain current industry standard virus protection and take all reasonable precautions to ensure that You do not, and do not allow any third party, directly or indirectly to upload, transmit, or distribute computer viruses, worms, malicious code, macro viruses, Trojan horses, or similar programs.\\015\\012\\015\\0128.5 You must not include links to the Portal or Website in any other Website without Our prior written consent. In particular (but without limiting the foregoing) You must not include in any other Website any "deep link" to any page on the Website other than the home page at www.safemovescheme.co.uk without Our prior written consent. \\015\\012\\015\\0128.6 You must not upload or use inappropriate or offensive language or content or solicit any commercial services in any communication, form or email You send or submit, from or to the Services. \\015\\012\\015\\0128.7 You acknowledge and agree that You shall make reasonable inspection of any Report, whether provided by Us in relation to Services or otherwise, and all associated Data to satisfy Yourself that there are no apparent defects and that You will decide whether or not the transaction may proceed in the best interest of the Client. We will not be liable to You for any such defect or failure to identify such defects.\\015\\012\\015\\0128.8 Notwithstanding Our obligations to Your in relation to the contents of the Report, Your acknowledge and agree that We shall not be liable to You for any professional judgments and decisions that You may make resulting from the Report.\\015\\012\\015\\0128.9 You warrant and represent that:\\015\\012\\015\\0128.9.1 The information supplied by You when utilising the Services is true, accurate and complete and that it will notify Us in writing of any changes in such information;\\015\\012\\015\\0128.9.2 You will keep all information provided by Us confidential and shall take all reasonable steps to ensure that any such information provided to third parties is also kept confidential. In doing so You shall ensure that such confidential information is kept in a manner no less secure than Your own confidential information.\\015\\012\\015\\0128.9.3 You will not allow any third party to use the Portal or any materials (including the Report), documents or data taken from the Portal or Website;\\015\\012\\015\\0128.9.4 You are authorised to receive the Services in accordance with the Terms and Conditions; \\015\\012\\015\\0128.9.5 You will keep confidential and secure all user names and passwords used in relation to the Services; \\015\\012\\015\\0128.9.6 You warrant and represent that You will ensure all images of documents that You upload to the Portal are good quality faithful representations of the document in Your possession;\\015\\012\\015\\0128.9.7 You will ensure all documents that You upload to the Portal have not been altered for the purpose of misleading any user; and\\015\\012\\015\\0128.9.8 You will only upload appropriate documents and images to the Portal; and\\015\\012\\015\\0128.9.9 You will not copy, replicate, or reconstruct (or attempt any of them, or procure a third party to undertake any of them on Your behalf) any aspect of the Services.\\015\\012\\015\\0129. CHARGES\\015\\012\\015\\0129.1 You acknowledge and agree that the provision of the Services to You is subject to the payment of the Charges. In the event that the Charges are not paid within the period of time as specified by Us, We will notify You by email.\\015\\012\\015\\0129.2 You also acknowledge that elements of the Services are dependent on the fulfilment of tasks by the Buyer, Seller, Buyer\\342\\200\\231s Conveyancer and Seller\\342\\200\\231s Conveyancer. To the extent that any of the above fails to fulfil these tasks, We may be unable to provide the Seller\\342\\200\\231s Conveyancer\\342\\200\\231s Data, the Seller\\342\\200\\231s data, or any information in relation to the Property in the Report.\\015\\012\\015\\0129.3 You also acknowledge that elements of the Services are dependent on the payment of further charges. To the extent that if the charges remain unpaid, We will be unable to provide Insurance or any information in relation to the Property in the Report.\\015\\012\\015\\01210. BARRING FROM THE SYSTEM\\015\\012\\015\\01210.1 We reserve the right to bar users from the Portal and/or restrict or block their access or use of any and all elements of the Services, on a permanent or temporary basis at Our sole discretion. Any such user shall be notified and must not then attempt to use the Services under any other name or through any other user. \\015\\012\\015\\01211. WARRANTY\\015\\012\\015\\01211.1 Whilst We endeavour to ensure that any material provided under the Services and available from the Portal and Website is not contaminated in any way, We do not warrant that such material will be free from infection, viruses and/or similar code. We also do not accept any liability for loss of Your password or account ID caused by a breakdown, error, loss of power or otherwise caused by or to Your computer system or network.\\015\\012\\015\\01211.2 We warrant that:\\015\\012\\015\\01211.2.1 The Services will be performed with reasonable skill and care and in accordance with these Terms and Conditions;\\015\\012\\015\\01211.2.2 We are authorised to provide the Services;\\015\\012\\015\\01211.2.3 the provision of the Services will not infringe any third party Intellectual Property Rights; and\\015\\012\\015\\01211.2.4 the Services will comply with all relevant laws, regulations and codes of practice.\\015\\012\\015\\01211.3 Due to the nature of software and the internet, We do not warrant that Your access to, or the running of, the Portal will be uninterrupted or error free. We shall not be liable if We cannot process Your request due to circumstances beyond Our reasonable control.\\015\\012\\015\\01211.4 The information provided under the Services does not constitute specific advice. Whilst We endeavour to ensure that the information provided is accurate, complete and up-to-date We make no warranties or representations that this is the case.\\015\\012\\015\\01211.5 We make no warranty or guarantee that the Services, Website or Portal, or any information available over any of them, comply with laws other than those of England and Wales.\\015\\012\\015\\01211.6 To the maximum extent permitted by law, We make no representations, warranties or conditions of any kind, either express or implied, with respect to any data provided by a Third Party Data Provider, including (but not limited to) any warranty that the responses are complete, accurate, of satisfactory quality, or fit for a particular purpose.\\015\\012\\015\\01212. LIABILITY\\015\\012\\015\\01212.1 Nothing in these Terms and Conditions will be deemed to exclude Our liability to You for death or personal injury arising from Our negligence, or any other liability the exclusion or restriction of which is expressly prohibited by law. \\015\\012\\015\\01212.2 You acknowledge and accept that We only provide the Services on the express condition that We will not be responsible for nor shall We have any liability to You, the Clients, the Seller, the Seller\\342\\200\\231s Conveyancer, the Buyer\\342\\200\\231s Conveyancer, any Party or any third party directly, indirectly, whether in contract, tort or otherwise for:\\015\\012\\015\\01212.2.1 Inaccuracies or errors in or omissions from any data provided by a Third Party Data Provider;\\015\\012\\015\\01212.2.2 inaccuracies or errors in or omissions from any register or other information source maintained or used by a Third Party Data Provider; or\\015\\012\\015\\01212.2.3 any act or omission by a Third Party Data Provider.\\015\\012\\015\\01212.3 We shall not be liable for any loss or damage sustained by You, the Clients, or any other third party directly or indirectly whether in contract, tort or otherwise making use of or relying on the Report including but not limited to any loss or damage resulting as a consequence of:\\015\\012\\015\\01212.3.1 any failure by You to have in place all necessary means of receiving the Report, the maintenance of internet access, appropriate email facilities or security measures; or\\015\\012\\015\\01212.3.2 (i) inaccuracies or errors in or omission from any Report; or (ii) any Report which is inaccurate, incomplete, illegal, out of sequence or in the wrong form, or in respect of the wrong Client; unless and then only to the extent that, the loss or damage sustained shall be as a direct consequence of the negligent act or omission by Us.\\015\\012\\015\\01212.4 We may put in place such systems as We from time to time see fit to prevent automated programs being used to obtain unauthorised access to the Services, Portal and Website. You are not permitted to use automated programs for such purposes and any such use or attempted use by You of such automated programs is at Your own risk. Subject to clause 12.2, We shall not be liable to You for any consequences arising out of or in connection with any such use or attempted use of automated programs to obtain unauthorised access to the Services, Website, or Portal. \\015\\012\\015\\01212.5 Without prejudice and subject to the foregoing clauses, Our total aggregate liability for all claims by You, the Clients, or any third parties, whether in contract, tort or otherwise for any breach of Our obligations under this Agreement, shall not exceed the lesser of:\\015\\012\\015\\01212.5.1 (i) the value of the interest(s) being acquired; or (ii) the amount of loan(s) being made; or (iii) the purchase price paid; (as the case may be) by the claiming parties in or for (or against the security of) the property/ properties in respect of which the Report relates; or\\015\\012\\015\\01212.5.2 where the Report is/ are being made for a purpose other than obtaining Services, the value of the property/ properties in respect of which the Report was/ Were made as at the date of the Report; or\\015\\012\\015\\01212.5.3 the sum of \\302\\2431,000,000.\\015\\012\\015\\01212.6 Subject to clauses 12.2 inclusive, We shall not be liable to You for any indirect, consequential, special or punitive loss, damage, costs and expenses; together with any directly or indirectly incurred: loss of profit; loss of business; loss of reputation; depletion of goodwill; or loss of, damage to or corruption of data.\\015\\012\\015\\01212.7 You accept that when You use the Services, details will be passed directly to Conveyancers, lending institutions and other relevant organisations providing related services to the Safe Move Scheme to reduce the risk of fraudulent transactions occurring. Whilst We prohibit these organisations from contacting Your customers for any other reason other than facilitating the Safe Move Scheme, We do not accept any liability for any subsequent communications that You and Your customers receive directly from these organisations. \\015\\012\\015\\01212.8 We do not provide advice and any information provided in accordance with the Services is provided to enable professional advisers to make a more informed decision. We do not accept any liability for any advice provided by lawyers or any other organisation associated with the Services and do not accept responsibility for any loss resulting from reliance on any such advice.\\015\\012\\015\\01212.9 We do not accept financial responsibility for any financial loss incurred as a result of the performance of an organisation associated with the Services.\\015\\012\\015\\01212.10 We shall have no liability to any third party, unless expressly agreed by Us in writing.\\015\\012\\015\\01213. TERMINATION\\015\\012\\015\\01213.1 Without prejudice to Our other rights and remedies, We may, at Our absolute discretion, terminate this Agreement or Your account with Us if:\\015\\012\\015\\01213.1.1 You cease to be an accredited member of Your profession;\\015\\012\\015\\01213.1.2 We believe, in Our reasonable opinion, that You have materially breached these Terms and Conditions or acted in a manner inconsistent with these Terms and Conditions;\\015\\012\\015\\01213.1.3 You cease or threaten to cease to carry on Your business;\\015\\012\\015\\01213.1.4 You have a liquidator, receiver or administrative receiver appointed to You or over any part of Your undertaking or assets;\\015\\012\\015\\01213.1.5 You pass, or propose to pass a resolution for winding up (other than for a bona fide scheme or solvent amalgamation or reconstruction where the resultant entity shall assume all Your liabilities) and/ or You convene a meeting with Your creditors;\\015\\012\\015\\01213.1.6 You are declared bankrupt, or are subject to a bankruptcy petition, or You are wound up by court order or are subject to a winding up petition;\\015\\012\\015\\01213.1.7 You propose, or enter into, any voluntary arrangement with Your creditors;\\015\\012\\015\\01213.1.8 You take, or are subject to any steps (including making of an application or giving of notice) for the appointment or proposed appointment of an administrator;\\015\\012\\015\\01213.1.9 You are subject to any other proceedings relating to Your solvency or possible solvency; or\\015\\012\\015\\01213.1.10 You are subject to any similar action in any jurisdiction because of debt.\\015\\012\\015\\01213.2 We may terminate Your account without notice (including all usernames and passwords) if any information is or becomes untrue, inaccurate, out of date, or incomplete.\\015\\012\\015\\01213.3 You may terminate Your account at any time by giving 28 days written notice to Us.\\015\\012\\015\\01213.4 In the event of termination of Your account at any time, Your entitlement to use the Services ceases immediately. You acknowledge that any Charges paid by the Client may still remain payable.\\015\\012\\015\\01213.5 Clauses 6, 7, 9, 11, 12 and 14 shall survive termination of expiry of the Agreement.\\015\\012\\015\\01213.6 Notwithstanding termination or expiry, We will fulfil any Report which You have ordered (and which has been paid for by the Client) prior to the termination or expiry, unless You have breached Clauses 6.5 or 8.2 of this Agreement.\\015\\012\\015\\01213.7 We may terminate or suspend any user accounts that have been inactive for a period of greater than 12 months.\\015\\012\\015\\01214. LEGAL JURISDICTION\\015\\012\\015\\01214.1 English law shall apply to these Terms and Conditions and any non-contractual obligations arising out of or in connections with them. Both parties irrevocably agree that the courts of England and Wales will have exclusive jurisdiction to settle any dispute which may arise out of, under, or in connection with these Terms and for those purposes irrevocably submit all disputes to the exclusive jurisdiction of the English courts. \\015\\012\\015\\01215. NOTICES\\015\\012\\015\\01215.1 All notices shall be given:\\015\\012\\015\\01215.1.1 To Us, by recorded post to BE Consultancy Limited. Our address is Marlesfield House, 114 - 116 Main Road, Sidcup, DA14 6NG; and\\015\\012\\015\\01215.1.2 to You, by email to the email address that You provide to Us at the point of Your registration.\\015\\012\\015\\01215.2 All notices sent by email will be deemed to have been received on receipt (or, when received on a UK national holiday or on a Saturday or a Sunday, the next working day following the day of receipt). All notice sent by post will be deemed to have been received upon signature of a current employee of BE Consultancy Limited.\\015\\012\\015\\01216. CUSTOMER FEEDBACK AND QUALITY\\015\\012\\015\\01216.1 We operate a system to ensure that all customer feedback is dealt with fairly and consistently, and is properly recorded. We Welcome any suggestions that You make about how We may improve Our service. Please write to Us at Customer Services, BE Consultancy Limited, Marlesfield House, 114 - 116 Main Road, Sidcup, DA14 6NG. We aim to acknowledge all customer feedback. \\015\\012\\015\\01216.2 Phone calls directed to Our offices may be recorded for training and quality purposes.\\015\\012\\015\\01217. GENERAL\\015\\012\\015\\01217.1 We will not be liable for any delay, interruption or failure in performance or Our obligations under this Agreement if caused or contributed to by any circumstance which is outside Our reasonable control, including (without limitation) war (declared or undeclared), flood, riot, act of god, strike or other labour dispute, suspension or delay of service at public registries, delays or failures by Third Party Data Providers, change in the law, lack of power, or telecommunications failure.\\015\\012\\015\\01217.2 System maintenance will be conducted where possible outside normal business hours to minimise inconvenience for users.\\015\\012\\015\\01217.3 These Terms and Conditions are the whole agreement between You and Us. You acknowledge that You have not entered into this agreement in reliance on any warranty or representation made by Us (unless made fraudulently). \\015\\012\\015\\01217.4 If a court decides that any part of these Terms and Conditions cannot be enforced, that particular part of these Terms will not apply, but the rest of these Terms and Conditions will. \\015\\012\\015\\01217.5 A waiver by a party of a breach of any provision shall not be deemed a continuing waiver or a waiver of any subsequent breach of the same or any other provisions. Failure or delay in exercising any right under these Terms shall not prevent the exercise of that or any other right. \\015\\012\\015\\01217.6 You may not assign or transfer any benefit, interest or obligation under these Terms. \\015\\012\\015\\01217.7 The provisions of the Contracts (Rights of Third Parties) Act 1999 shall not apply to these Terms. \\015\\012\\015\\01217.8 These Terms and Conditions were last updated on 22nd September 2015.\\015\\012\\015\\01218. APPENDIX A\\015\\012\\015\\01218.1\\015\\012</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <TextOptions>,,,,WordWrap=True,A=0</TextOptions>\\015\\012              <Type>Expression</Type>\\015\\012            </TextContent>\\015\\012            <Image2 Ref="8" type="Image" isKey="true">\\015\\012              <AspectRatio>True</AspectRatio>\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>1.2,3.2,12,3</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Guid>4302b0556ae84b0bb92f899f03f02ec3</Guid>\\015\\012              <Image>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BwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEAAAAAAAAAAAAAAACYQ3oQAAAAAAAAAAAAAAAA5pAeBAAAAAAAAAAAAAAAgDmkBwEAAAAAAAAAAAAAAGAO6UEA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AAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAABrSDcCAAAAAAAAAAAAAADAGtKNAAAAAAAAAAAAAAAAsIZ0IwAAAAAAAAAAAAAAAKwh3QgAAAAAAAAAAAAAAADL/d//+//J4YbMMrwhwgAAAABJRU5ErkJggg==</Image>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>Image2</Name>\\015\\012              <Page isRef="2" />\\015\\012              <Parent isRef="6" />\\015\\012              <Stretch>True</Stretch>\\015\\012            </Image2>\\015\\012          </Components>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Filters isList="true" count="0" />\\015\\012          <Name>DataBand1</Name>\\015\\012          <Page isRef="2" />\\015\\012          <Parent isRef="2" />\\015\\012          <Sort isList="true" count="0" />\\015\\012        </DataBand1>\\015\\012      </Components>\\015\\012      <Conditions isList="true" count="0" />\\015\\012      <Guid>2673caf849244e118b74ecc2b931b511</Guid>\\015\\012      <Margins>1,1,1,1</Margins>\\015\\012      <Name>Page1</Name>\\015\\012      <PageHeight>29.7</PageHeight>\\015\\012      <PageWidth>21</PageWidth>\\015\\012      <Report isRef="0" />\\015\\012      <Watermark Ref="9" type="Stimulsoft.Report.Components.StiWatermark" isKey="true">\\015\\012        <Font>Arial,100</Font>\\015\\012        <TextBrush>[50:0:0:0]</TextBrush>\\015\\012      </Watermark>\\015\\012    </Page1>\\015\\012  </Pages>\\015\\012  <PrinterSettings Ref="10" type="Stimulsoft.Report.Print.StiPrinterSettings" isKey="true" />\\015\\012  <ReferencedAssemblies isList="true" count="8">\\015\\012    <value>System.Dll</value>\\015\\012    <value>System.Drawing.Dll</value>\\015\\012    <value>System.Windows.Forms.Dll</value>\\015\\012    <value>System.Data.Dll</value>\\015\\012    <value>System.Xml.Dll</value>\\015\\012    <value>Stimulsoft.Controls.Dll</value>\\015\\012    <value>Stimulsoft.Base.Dll</value>\\015\\012    <value>Stimulsoft.Report.Dll</value>\\015\\012  </ReferencedAssemblies>\\015\\012  <ReportAlias>Report</ReportAlias>\\015\\012  <ReportChanged>9/23/2015 11:01:52 AM</ReportChanged>\\015\\012  <ReportCreated>4/20/2015 5:01:58 PM</ReportCreated>\\015\\012  <ReportFile>C:\\134Reports\\134TcFirmConveyancing.mrt</ReportFile>\\015\\012  <ReportGuid>1ebb47fba9de48d09e4e05544f1f7652</ReportGuid>\\015\\012  <ReportName>Report</ReportName>\\015\\012  <ReportUnit>Centimeters</ReportUnit>\\015\\012  <ReportVersion>2015.1.8</ReportVersion>\\015\\012  <Script>using System;\\015\\012using System.Drawing;\\015\\012using System.Windows.Forms;\\015\\012using System.Data;\\015\\012using Stimulsoft.Controls;\\015\\012using Stimulsoft.Base.Drawing;\\015\\012using Stimulsoft.Report;\\015\\012using Stimulsoft.Report.Dialogs;\\015\\012using Stimulsoft.Report.Components;\\015\\012\\015\\012namespace Reports\\015\\012{\\015\\012    public class Report : Stimulsoft.Report.StiReport\\015\\012    {\\015\\012        public Report()        {\\015\\012            this.InitializeComponent();\\015\\012        }\\015\\012\\015\\012        #region StiReport Designer generated code - do not modify\\015\\012\\011\\011#endregion StiReport Designer generated code - do not modify\\015\\012    }\\015\\012}\\015\\012</Script>\\015\\012  <ScriptLanguage>CSharp</ScriptLanguage>\\015\\012  <Styles isList="true" count="0" />\\015\\012</StiSerializer>',
  true,
  false,
  CURRENT_DATE,
  true,
  false
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
  '4fddd7fe-489f-11e4-b824-13eff2d1a1e2',
  'TcLender',
  'Lender Terms and Conditions Resource',
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
  '4fccc2fe-489f-11e4-8f39-5f438902bf9f',
  1,
  null,
  '4fddd7fe-489f-11e4-b824-13eff2d1a1e2',
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1),
  null,
  null,
  true,
  false,
  null
);


select

(SELECT count(*) FROM "fn_PromoteNotificationConstructTemplate"(nct."NotificationConstructTemplateID",1))

from "NotificationConstructTemplate" nct

where not exists (select * from "NotificationConstruct" nc where nc."NotificationConstructTemplateID" = nct."NotificationConstructTemplateID"
	and nc."NotificationConstructTemplateVersionNumber" = nct."NotificationConstructTemplateVersionNumber")
;


--also run 2x broker and 2x lender scripts after running this:
--Scripts\BE Framework Scripts\Setup\Organisation\Lender\*
--Scripts\BE Framework Scripts\Setup\Organisation\Broker\*


-- Admin Organisation
DO $$
Declare DoTemplateID uuid;
Declare DoVersionNumber integer;
Declare UserRoleID uuid;
Declare EmployeeRoleID uuid;
Declare OrganisationTypeID integer;
Declare userUser uuid;
Declare adminUser uuid;
Begin

-- declare variables
UserRoleID := (select "RoleID" from "Role" where "RoleName" = 'Lender Administrator' limit 1);
OrganisationTypeID := (select "OrganisationTypeID" from "OrganisationType" where "Name" = 'Lender' limit 1);
userUser := (select "UserTypeID" from "UserType" where "Name" = 'User');

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
  'Lender Organisation',
  'Template for a Lender Organisation',
  true,
  false,
  OrganisationTypeID
);

DoTemplateID:= (select dot."DefaultOrganisationTemplateID" from "DefaultOrganisationTemplate" dot where dot."Name" = 'Lender Organisation' limit 1);
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
  (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Professional Organisation Status'),
  1,
  null,
  true,
  false,
  DoTemplateID,
  DoVersionNumber,
  (select "StatusTypeValueTemplateID" from "vStatusTypeTemplate" where "IsStart" = true and "TemplateName" =  'Professional Organisation Status' limit 1)
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
  (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Professional Organisation Status'),
 (select "StatusTypeTemplateVersionNumber" from "StatusTypeTemplate" where "Name" = 'Professional Organisation Status')
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
  (select "UserTypeID" from "UserType" where "Name" = 'Organisation Administrator' limit 1),
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
  "DefaultOrganisationTemplateVersionNumber",
  "IsDefault"
)
VALUES (
  DoTemplateID,
  UserRoleID,
  false,
  DoVersionNumber,
  false
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
where "DefaultOrganisationTemplateID" = DoTemplateID and "DefaultOrganisationTemplateVersionNumber" = DoVersionNumber;
--and "UserTypeID" = userUser; --no filters, all users


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

END $$;

-- =============================================================

DO $$
Declare DoTemplateID uuid;
Declare DoVersionNumber integer;
Begin

DoTemplateID:= (select dot."DefaultOrganisationTemplateID" from "DefaultOrganisationTemplate" dot where dot."Name" = 'Lender Organisation' limit 1);
DoVersionNumber = 1;

perform "fn_PromoteDefaultOrganisationTemplate"(DoTemplateID, DoVersionNumber);

END $$;

-- =======================================



-- Admin Organisation
DO $$
Declare DoTemplateID uuid;
Declare DoVersionNumber integer;
Declare UserRoleID uuid;
Declare EmployeeRoleID uuid;
Declare OrganisationTypeID integer;
Declare userUser uuid;
Declare adminUser uuid;
Begin

-- declare variables
UserRoleID := (select "RoleID" from "Role" where "RoleName" = 'Broker Administrator' limit 1);
OrganisationTypeID := (select "OrganisationTypeID" from "OrganisationType" where "Name" = 'MortgageBroker' limit 1);
userUser := (select "UserTypeID" from "UserType" where "Name" = 'User');
adminUser := (select "UserTypeID" from "UserType" where "Name" = 'Organisation Administrator');

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
  'Mortgage Broker Organisation',
  'Template for a Mortgage Broker Organisation',
  true,
  false,
  OrganisationTypeID
);

DoTemplateID:= (select dot."DefaultOrganisationTemplateID" from "DefaultOrganisationTemplate" dot where dot."Name" = 'Mortgage Broker Organisation' limit 1);
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
  (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Professional Organisation Status'),
  1,
  null,
  true,
  false,
  DoTemplateID,
  DoVersionNumber,
  (select "StatusTypeValueTemplateID" from "vStatusTypeTemplate" where "IsStart" = true and "TemplateName" =  'Professional Organisation Status' limit 1)
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
  (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Professional Organisation Status'),
 (select "StatusTypeTemplateVersionNumber" from "StatusTypeTemplate" where "Name" = 'Professional Organisation Status')
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
  (select "UserTypeID" from "UserType" where "Name" = 'Organisation Administrator' limit 1),
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
  "DefaultOrganisationTemplateVersionNumber",
  "IsDefault"
)
VALUES (
  DoTemplateID,
  UserRoleID,
  false,
  DoVersionNumber,
  false
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
where "DefaultOrganisationTemplateID" = DoTemplateID and "DefaultOrganisationTemplateVersionNumber" = DoVersionNumber;
--and "UserTypeID" = userUser; --no filters, all users


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

END $$;

-- ========================================================

DO $$
Declare DoTemplateID uuid;
Declare DoVersionNumber integer;
Begin

DoTemplateID:= (select dot."DefaultOrganisationTemplateID" from "DefaultOrganisationTemplate" dot where dot."Name" = 'Mortgage Broker Organisation' limit 1);
DoVersionNumber = 1;

perform "fn_PromoteDefaultOrganisationTemplate"(DoTemplateID, DoVersionNumber);

END $$;