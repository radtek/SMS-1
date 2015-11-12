--Run Operation script first

--0001 Notification
DO $$
Declare NcTID uuid;
Declare NcTVN integer;
Declare NcResID uuid;
Declare OrgEmployeeRoleID uuid;
Declare OrgEmployeeUserTypeID uuid;
Begin

NcTVN := 1;
NcTID := (select uuid_generate_v1());
NcResID := (select uuid_generate_v1());
OrgEmployeeRoleID := (select "RoleID" from "Role" where "RoleName" = 'Organisation Employee' limit 1);
OrgEmployeeUserTypeID := (select "UserTypeID" from "UserType" where "Name" = 'Organisation Employee' limit 1);

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
  'BankAccountCheckNoMatch',
  'Bank Account Check No Match Notification',
  4989, -- HTML
  4993, -- System
  'Bank Account Check No Match' ,
  'Test',
  '0001',
  'Bec.TargetFramework.SB.Notifications.Mutators.BankAccountCheckNoMatchMutator, Bec.TargetFramework.SB.Notifications',
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
  OrgEmployeeUserTypeID,
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
  OrgEmployeeUserTypeID,
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
  E'\\357\\273\\277<?xml version="1.0" encoding="utf-8" standalone="yes"?>\\015\\012<StiSerializer version="1.02" type="Net" application="StiReport">\\015\\012  <CacheAllData>True</CacheAllData>\\015\\012  <Dictionary Ref="1" type="Dictionary" isKey="true">\\015\\012    <BusinessObjects isList="true" count="2">\\015\\012      <NotificationSettingDTO Ref="2" type="Stimulsoft.Report.Dictionary.StiBusinessObject" isKey="true">\\015\\012        <Alias>NotificationSettingDTO</Alias>\\015\\012        <BusinessObjects isList="true" count="0" />\\015\\012        <Category>General</Category>\\015\\012        <Columns isList="true" count="10">\\015\\012          <value>ExportFormat,System.Nullable`1[System.Int32]</value>\\015\\012          <value>NotificationConstructID,System.Guid</value>\\015\\012          <value>NotificationConstructVersionNumber,System.Int32</value>\\015\\012          <value>NotificiationSentFromParentID,System.Guid</value>\\015\\012          <value>ServerLogoImageFileNameWithExtension,System.String</value>\\015\\012          <value>ServerNotificationImageContentURLFolder,System.String</value>\\015\\012          <value>ServerURL,System.String</value>\\015\\012          <value>LoginRoute,System.String</value>\\015\\012          <value>Subject,System.String</value>\\015\\012          <value>Title,System.String</value>\\015\\012        </Columns>\\015\\012        <Dictionary isRef="1" />\\015\\012        <Guid>af4abf77a08a413fba97a142ac3d403b</Guid>\\015\\012        <Name>NotificationSettingDTO</Name>\\015\\012      </NotificationSettingDTO>\\015\\012      <BankAccountCheckNoMatchNotificationDTO Ref="3" type="Stimulsoft.Report.Dictionary.StiBusinessObject" isKey="true">\\015\\012        <Alias>BankAccountCheckNoMatchNotificationDTO</Alias>\\015\\012        <BusinessObjects isList="true" count="0" />\\015\\012        <Category>General</Category>\\015\\012        <Columns isList="true" count="6">\\015\\012          <value>AccountNumber,System.String</value>\\015\\012          <value>DetailsUrl,System.String</value>\\015\\012          <value>MarkedBy,System.String</value>\\015\\012          <value>OrganisationId,System.Guid</value>\\015\\012          <value>Reason,System.String</value>\\015\\012          <value>SortCode,System.String</value>\\015\\012        </Columns>\\015\\012        <Dictionary isRef="1" />\\015\\012        <Guid>44f8d67b23c44cc0be50ebaa3a9ba35c</Guid>\\015\\012        <Name>BankAccountCheckNoMatchNotificationDTO</Name>\\015\\012      </BankAccountCheckNoMatchNotificationDTO>\\015\\012    </BusinessObjects>\\015\\012    <Databases isList="true" count="0" />\\015\\012    <DataSources isList="true" count="0" />\\015\\012    <Relations isList="true" count="0" />\\015\\012    <Report isRef="0" />\\015\\012    <Variables isList="true" count="1">\\015\\012      <value>General</value>\\015\\012    </Variables>\\015\\012  </Dictionary>\\015\\012  <EngineVersion>EngineV2</EngineVersion>\\015\\012  <GlobalizationStrings isList="true" count="0" />\\015\\012  <MetaTags isList="true" count="0" />\\015\\012  <Pages isList="true" count="1">\\015\\012    <Page1 Ref="4" type="Page" isKey="true">\\015\\012      <Border>None;Black;2;Solid;False;4;Black</Border>\\015\\012      <Brush>Transparent</Brush>\\015\\012      <Components isList="true" count="8">\\015\\012        <TextContent Ref="5" type="Text" isKey="true">\\015\\012          <AllowHtmlTags>True</AllowHtmlTags>\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>0,0,13.2,0.6</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Microsoft Sans Serif,11</Font>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>TextContent</Name>\\015\\012          <Page isRef="4" />\\015\\012          <Parent isRef="4" />\\015\\012          <Text>&lt;h2&gt;&lt;line-height="1.5"&gt;The following bank account details were submitted by a user.&lt;/line-height&gt;&lt;/h2&gt;</Text>\\015\\012          <TextBrush>[51:51:51]</TextBrush>\\015\\012          <TextQuality>Wysiwyg</TextQuality>\\015\\012          <Type>Expression</Type>\\015\\012        </TextContent>\\015\\012        <Text1 Ref="6" type="Text" isKey="true">\\015\\012          <AllowHtmlTags>True</AllowHtmlTags>\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>0.4,1.8,3.6,0.6</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Microsoft Sans Serif,10</Font>\\015\\012          <Guid>ebcb4cd1ff9248ecb0d71fac524e64c2</Guid>\\015\\012          <HorAlignment>Right</HorAlignment>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text1</Name>\\015\\012          <Page isRef="4" />\\015\\012          <Parent isRef="4" />\\015\\012          <Text>&lt;b&gt;&lt;line-height="1.5"&gt;Account Number:&lt;/line-height&gt;&lt;/b&gt;</Text>\\015\\012          <TextBrush>[51:51:51]</TextBrush>\\015\\012          <TextQuality>Wysiwyg</TextQuality>\\015\\012          <Type>Expression</Type>\\015\\012        </Text1>\\015\\012        <Text2 Ref="7" type="Text" isKey="true">\\015\\012          <AllowHtmlTags>True</AllowHtmlTags>\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>0.4,2.6,3.6,0.6</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Microsoft Sans Serif,10</Font>\\015\\012          <Guid>33e0aa711397490c80cb73e979bf78e2</Guid>\\015\\012          <HorAlignment>Right</HorAlignment>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text2</Name>\\015\\012          <Page isRef="4" />\\015\\012          <Parent isRef="4" />\\015\\012          <Text>&lt;b&gt;&lt;line-height="1.5"&gt;Sort Code:&lt;/line-height&gt;&lt;/b&gt;</Text>\\015\\012          <TextBrush>[51:51:51]</TextBrush>\\015\\012          <TextQuality>Wysiwyg</TextQuality>\\015\\012          <Type>Expression</Type>\\015\\012        </Text2>\\015\\012        <Text3 Ref="8" type="Text" isKey="true">\\015\\012          <AllowHtmlTags>True</AllowHtmlTags>\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>0.4,3.4,3.6,0.6</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Microsoft Sans Serif,10</Font>\\015\\012          <Guid>6c399a13d2c84d6693f2b15a61d189d8</Guid>\\015\\012          <HorAlignment>Right</HorAlignment>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text3</Name>\\015\\012          <Page isRef="4" />\\015\\012          <Parent isRef="4" />\\015\\012          <Text>&lt;b&gt;&lt;line-height="1.5"&gt;Checked By:&lt;/line-height&gt;&lt;/b&gt;</Text>\\015\\012          <TextBrush>[51:51:51]</TextBrush>\\015\\012          <TextQuality>Wysiwyg</TextQuality>\\015\\012          <Type>Expression</Type>\\015\\012        </Text3>\\015\\012        <Text6 Ref="9" type="Text" isKey="true">\\015\\012          <AllowHtmlTags>True</AllowHtmlTags>\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>4.6,1.8,10.2,0.6</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Microsoft Sans Serif,9.75</Font>\\015\\012          <Guid>d666cef6f51441dda0b39d364072a5a3</Guid>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text6</Name>\\015\\012          <Page isRef="4" />\\015\\012          <Parent isRef="4" />\\015\\012          <Text>&lt;line-height="1.5"&gt;{BankAccountCheckNoMatchNotificationDTO.AccountNumber}&lt;/line-height&gt;</Text>\\015\\012          <TextBrush>[51:51:51]</TextBrush>\\015\\012          <TextQuality>Wysiwyg</TextQuality>\\015\\012          <Type>Expression</Type>\\015\\012        </Text6>\\015\\012        <Text7 Ref="10" type="Text" isKey="true">\\015\\012          <AllowHtmlTags>True</AllowHtmlTags>\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>4.6,2.6,10.2,0.6</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Microsoft Sans Serif,9.75</Font>\\015\\012          <Guid>a43d44a16c9f455fb005c85e01288a46</Guid>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text7</Name>\\015\\012          <Page isRef="4" />\\015\\012          <Parent isRef="4" />\\015\\012          <Text>&lt;line-height="1.5"&gt;{BankAccountCheckNoMatchNotificationDTO.SortCode}&lt;/line-height&gt;</Text>\\015\\012          <TextBrush>[51:51:51]</TextBrush>\\015\\012          <TextQuality>Wysiwyg</TextQuality>\\015\\012          <Type>Expression</Type>\\015\\012        </Text7>\\015\\012        <Text8 Ref="11" type="Text" isKey="true">\\015\\012          <AllowHtmlTags>True</AllowHtmlTags>\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>4.6,3.4,10.2,0.6</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Microsoft Sans Serif,9.75</Font>\\015\\012          <Guid>f5dc17c70f1a40e8a4d0080105b86861</Guid>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text8</Name>\\015\\012          <Page isRef="4" />\\015\\012          <Parent isRef="4" />\\015\\012          <Text>&lt;line-height="1.5"&gt;{BankAccountCheckNoMatchNotificationDTO.MarkedBy}&lt;/line-height&gt;</Text>\\015\\012          <TextBrush>[51:51:51]</TextBrush>\\015\\012          <TextQuality>Wysiwyg</TextQuality>\\015\\012          <Type>Expression</Type>\\015\\012        </Text8>\\015\\012        <Text4 Ref="12" type="Text" isKey="true">\\015\\012          <AllowHtmlTags>True</AllowHtmlTags>\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>0,0.8,13.2,0.6</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Microsoft Sans Serif,11</Font>\\015\\012          <Guid>a286b7aeed78475094d16b2facde7627</Guid>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text4</Name>\\015\\012          <Page isRef="4" />\\015\\012          <Parent isRef="4" />\\015\\012          <Text>&lt;h2&gt;&lt;line-height="1.5"&gt;The details did not match an active safe bank account.&lt;/line-height&gt;&lt;/h2&gt;</Text>\\015\\012          <TextBrush>[51:51:51]</TextBrush>\\015\\012          <TextQuality>Wysiwyg</TextQuality>\\015\\012          <Type>Expression</Type>\\015\\012        </Text4>\\015\\012      </Components>\\015\\012      <Conditions isList="true" count="0" />\\015\\012      <Guid>1b83758dda4046518274d0b090f93e62</Guid>\\015\\012      <Hyperlink>#{NotificationSettingDTO.ServerURL}{NotificationSettingDTO.LoginRoute}</Hyperlink>\\015\\012      <Margins>1,1,1,1</Margins>\\015\\012      <Name>Page1</Name>\\015\\012      <PageHeight>10</PageHeight>\\015\\012      <PageWidth>17</PageWidth>\\015\\012      <Report isRef="0" />\\015\\012      <Watermark Ref="13" type="Stimulsoft.Report.Components.StiWatermark" isKey="true">\\015\\012        <Font>Arial,100</Font>\\015\\012        <TextBrush>[50:0:0:0]</TextBrush>\\015\\012      </Watermark>\\015\\012    </Page1>\\015\\012  </Pages>\\015\\012  <PrinterSettings Ref="14" type="Stimulsoft.Report.Print.StiPrinterSettings" isKey="true" />\\015\\012  <ReferencedAssemblies isList="true" count="8">\\015\\012    <value>System.Dll</value>\\015\\012    <value>System.Drawing.Dll</value>\\015\\012    <value>System.Windows.Forms.Dll</value>\\015\\012    <value>System.Data.Dll</value>\\015\\012    <value>System.Xml.Dll</value>\\015\\012    <value>Stimulsoft.Controls.Dll</value>\\015\\012    <value>Stimulsoft.Base.Dll</value>\\015\\012    <value>Stimulsoft.Report.Dll</value>\\015\\012  </ReferencedAssemblies>\\015\\012  <ReportAlias>Report</ReportAlias>\\015\\012  <ReportChanged>11/12/2015 3:58:36 PM</ReportChanged>\\015\\012  <ReportCreated>9/29/2014 8:17:02 AM</ReportCreated>\\015\\012  <ReportFile>C:\\134Reports\\134bank no match.mrt</ReportFile>\\015\\012  <ReportGuid>3e8e5331a70c409abf9fa86553964456</ReportGuid>\\015\\012  <ReportName>Report</ReportName>\\015\\012  <ReportUnit>Centimeters</ReportUnit>\\015\\012  <ReportVersion>2015.1.8</ReportVersion>\\015\\012  <Script>using System;\\015\\012using System.Drawing;\\015\\012using System.Windows.Forms;\\015\\012using System.Data;\\015\\012using Stimulsoft.Controls;\\015\\012using Stimulsoft.Base.Drawing;\\015\\012using Stimulsoft.Report;\\015\\012using Stimulsoft.Report.Dialogs;\\015\\012using Stimulsoft.Report.Components;\\015\\012\\015\\012namespace Reports\\015\\012{\\015\\012    public class Report : Stimulsoft.Report.StiReport\\015\\012    {\\015\\012        public Report()        {\\015\\012            this.InitializeComponent();\\015\\012        }\\015\\012\\015\\012        #region StiReport Designer generated code - do not modify\\015\\012\\011\\011#endregion StiReport Designer generated code - do not modify\\015\\012    }\\015\\012}\\015\\012</Script>\\015\\012  <ScriptLanguage>CSharp</ScriptLanguage>\\015\\012  <Styles isList="true" count="0" />\\015\\012</StiSerializer>',
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
  'BankAccountCheckNoMatchNotificationDTO',
  'Bec.TargetFramework.Entities.DTO.Notification.BankAccountCheckNoMatchNotificationDTO, Bec.TargetFramework.Entities',
  'BankAccountCheckNoMatchNotificationDTO',
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
  'BankAccountCheckNoMatch',
  'BankAccountCheckNoMatch Notification Resource',
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
  OrgEmployeeRoleID
);

INSERT INTO
  public."ResourceOperationTarget"("ResourceID", "OperationID", "OrganisationTypeID", "UserTypeID")
VALUES
  (NcResID,(select "OperationID" from "Operation" where "OperationName" = 'View' limit 1),31,OrgEmployeeUserTypeID);

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
  OrgEmployeeRoleID
);

INSERT INTO
  public."ResourceOperationTarget"("ResourceID", "OperationID", "OrganisationTypeID", "UserTypeID")
VALUES
  (NcResID,(select "OperationID" from "Operation" where "OperationName" = 'MarkAsRead' limit 1),31,OrgEmployeeUserTypeID);

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
  OrgEmployeeRoleID
);

INSERT INTO
  public."ResourceOperationTarget"("ResourceID", "OperationID", "OrganisationTypeID", "UserTypeID")
VALUES
  (NcResID,(select "OperationID" from "Operation" where "OperationName" = 'MarkAsUnread' limit 1),31,OrgEmployeeUserTypeID);

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
  OrgEmployeeRoleID
);

INSERT INTO
  public."ResourceOperationTarget"("ResourceID", "OperationID", "OrganisationTypeID", "UserTypeID")
VALUES
  (NcResID,(select "OperationID" from "Operation" where "OperationName" = 'Send' limit 1),31,OrgEmployeeUserTypeID);

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
  OrgEmployeeRoleID
);

INSERT INTO
  public."ResourceOperationTarget"("ResourceID", "OperationID", "OrganisationTypeID", "UserTypeID")
VALUES
  (NcResID,(select "OperationID" from "Operation" where "OperationName" = 'Configure' limit 1),31,OrgEmployeeUserTypeID);

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
  OrgEmployeeRoleID
);

INSERT INTO
  public."ResourceOperationTarget"("ResourceID", "OperationID", "OrganisationTypeID", "UserTypeID")
VALUES
  (NcResID,(select "OperationID" from "Operation" where "OperationName" = 'Edit' limit 1),31,OrgEmployeeUserTypeID);

-- Add to DOT for specific org type

-- DefaultOrganisationNotificationConstructTemplate OrgAdmin
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
  (select "DefaultOrganisationTemplateID" from "DefaultOrganisationTemplate" where "Name" = 'Professional Organisation' limit 1),
  NcTID,
  NcTVN,
  null,
  (select "DefaultOrganisationTemplateVersionNumber" from "DefaultOrganisationTemplate" where "Name" = 'Professional Organisation' limit 1)
);


-- Promotes all notification templates to main tables
select

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
            r."ResourceName" LIKE ''BankAccountCheckNoMatch'' AND
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

