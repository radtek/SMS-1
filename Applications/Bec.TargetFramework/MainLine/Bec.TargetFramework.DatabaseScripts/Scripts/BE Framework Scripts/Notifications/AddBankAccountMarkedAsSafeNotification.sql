--Run Operation script first

--0001 Notification
DO $$
Declare NcTID uuid;
Declare NcTVN integer;
Declare NcResID uuid;
Declare OrgEmployeeRoleID uuid;
Declare UserUserTypeID uuid;
Begin

NcTVN := 1;
NcTID := (select uuid_generate_v1());
NcResID := (select uuid_generate_v1());
OrgEmployeeRoleID := (select "RoleID" from "Role" where "RoleName" = 'Organisation Administrator' limit 1);
UserUserTypeID := (select "UserTypeID" from "UserType" where "Name" = 'Organisation Administrator' limit 1);

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
  'BankAccountMarkedAsSafe',
  'Bank Account Marked as Safe Notification',
  4989, -- HTML
  4993, -- System
  'Bank Account Marked as Safe' ,
  'Test',
  '0001',
  'Bec.TargetFramework.SB.Notifications.Mutators.BankAccountMarkedAsSafeMutator, Bec.TargetFramework.SB.Notifications',
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
  E'<?xml version="1.0" encoding="utf-8" standalone="yes"?>
<StiSerializer version="1.02" type="Net" application="StiReport">
  <CacheAllData>True</CacheAllData>
  <Dictionary Ref="1" type="Dictionary" isKey="true">
    <BusinessObjects isList="true" count="2">
      <NotificationSettingDTO Ref="2" type="Stimulsoft.Report.Dictionary.StiBusinessObject" isKey="true">
        <Alias>NotificationSettingDTO</Alias>
        <BusinessObjects isList="true" count="0" />
        <Category>General</Category>
        <Columns isList="true" count="10">
          <value>ExportFormat,System.Nullable`1[System.Int32]</value>
          <value>NotificationConstructID,System.Guid</value>
          <value>NotificationConstructVersionNumber,System.Int32</value>
          <value>NotificiationSentFromParentID,System.Guid</value>
          <value>ServerLogoImageFileNameWithExtension,System.String</value>
          <value>ServerNotificationImageContentURLFolder,System.String</value>
          <value>ServerURL,System.String</value>
          <value>LoginRoute,System.String</value>
          <value>Subject,System.String</value>
          <value>Title,System.String</value>
        </Columns>
        <Dictionary isRef="1" />
        <Guid>af4abf77a08a413fba97a142ac3d403b</Guid>
        <Name>NotificationSettingDTO</Name>
      </NotificationSettingDTO>
      <BankAccountMarkedAsSafeNotificationDTO Ref="3" type="Stimulsoft.Report.Dictionary.StiBusinessObject" isKey="true">
        <Alias>BankAccountMarkedAsSafeNotificationDTO</Alias>
        <BusinessObjects isList="true" count="0" />
        <Category>General</Category>
        <Columns isList="true" count="6">
          <value>AccountNumber,System.String</value>
          <value>DetailsUrl,System.String</value>
          <value>MarkedBy,System.String</value>
          <value>OrganisationId,System.Guid</value>
          <value>Reason,System.String</value>
          <value>SortCode,System.String</value>
        </Columns>
        <Dictionary isRef="1" />
        <Guid>44f8d67b23c44cc0be50ebaa3a9ba35c</Guid>
        <Name>BankAccountMarkedAsSafeNotificationDTO</Name>
      </BankAccountMarkedAsSafeNotificationDTO>
    </BusinessObjects>
    <Databases isList="true" count="0" />
    <DataSources isList="true" count="0" />
    <Relations isList="true" count="0" />
    <Report isRef="0" />
    <Variables isList="true" count="1">
      <value>General</value>
    </Variables>
  </Dictionary>
  <EngineVersion>EngineV2</EngineVersion>
  <GlobalizationStrings isList="true" count="0" />
  <MetaTags isList="true" count="0" />
  <Pages isList="true" count="1">
    <Page1 Ref="4" type="Page" isKey="true">
      <Border>None;Black;2;Solid;False;4;Black</Border>
      <Brush>Transparent</Brush>
      <Components isList="true" count="9">
        <TextContent Ref="5" type="Text" isKey="true">
          <AllowHtmlTags>True</AllowHtmlTags>
          <Brush>Transparent</Brush>
          <ClientRectangle>0,0,13.2,0.6</ClientRectangle>
          <Conditions isList="true" count="0" />
          <Font>Microsoft Sans Serif,11</Font>
          <Margins>0,0,0,0</Margins>
          <Name>TextContent</Name>
          <Page isRef="4" />
          <Parent isRef="4" />
          <Text>&lt;h2&gt;&lt;line-height="1.5"&gt;The following bank account was Marked as Safe&lt;/line-height&gt;&lt;/h2&gt;</Text>
          <TextBrush>[51:51:51]</TextBrush>
          <TextQuality>Wysiwyg</TextQuality>
          <Type>Expression</Type>
        </TextContent>
        <Text1 Ref="6" type="Text" isKey="true">
          <AllowHtmlTags>True</AllowHtmlTags>
          <Brush>Transparent</Brush>
          <ClientRectangle>0.4,1,3.6,0.6</ClientRectangle>
          <Conditions isList="true" count="0" />
          <Font>Microsoft Sans Serif,10</Font>
          <Guid>ebcb4cd1ff9248ecb0d71fac524e64c2</Guid>
          <HorAlignment>Right</HorAlignment>
          <Margins>0,0,0,0</Margins>
          <Name>Text1</Name>
          <Page isRef="4" />
          <Parent isRef="4" />
          <Text>&lt;b&gt;&lt;line-height="1.5"&gt;Account Number:&lt;/line-height&gt;&lt;/b&gt;</Text>
          <TextBrush>[51:51:51]</TextBrush>
          <TextQuality>Wysiwyg</TextQuality>
          <Type>Expression</Type>
        </Text1>
        <Text2 Ref="7" type="Text" isKey="true">
          <AllowHtmlTags>True</AllowHtmlTags>
          <Brush>Transparent</Brush>
          <ClientRectangle>0.4,1.8,3.6,0.6</ClientRectangle>
          <Conditions isList="true" count="0" />
          <Font>Microsoft Sans Serif,10</Font>
          <Guid>33e0aa711397490c80cb73e979bf78e2</Guid>
          <HorAlignment>Right</HorAlignment>
          <Margins>0,0,0,0</Margins>
          <Name>Text2</Name>
          <Page isRef="4" />
          <Parent isRef="4" />
          <Text>&lt;b&gt;&lt;line-height="1.5"&gt;Sort Code:&lt;/line-height&gt;&lt;/b&gt;</Text>
          <TextBrush>[51:51:51]</TextBrush>
          <TextQuality>Wysiwyg</TextQuality>
          <Type>Expression</Type>
        </Text2>
        <Text3 Ref="8" type="Text" isKey="true">
          <AllowHtmlTags>True</AllowHtmlTags>
          <Brush>Transparent</Brush>
          <ClientRectangle>0.4,2.6,3.6,0.6</ClientRectangle>
          <Conditions isList="true" count="0" />
          <Font>Microsoft Sans Serif,10</Font>
          <Guid>6c399a13d2c84d6693f2b15a61d189d8</Guid>
          <HorAlignment>Right</HorAlignment>
          <Margins>0,0,0,0</Margins>
          <Name>Text3</Name>
          <Page isRef="4" />
          <Parent isRef="4" />
          <Text>&lt;b&gt;&lt;line-height="1.5"&gt;Changed By:&lt;/line-height&gt;&lt;/b&gt;</Text>
          <TextBrush>[51:51:51]</TextBrush>
          <TextQuality>Wysiwyg</TextQuality>
          <Type>Expression</Type>
        </Text3>
        <Text5 Ref="9" type="Text" isKey="true">
          <AllowHtmlTags>True</AllowHtmlTags>
          <Brush>Transparent</Brush>
          <ClientRectangle>0.4,3.4,3.6,0.6</ClientRectangle>
          <Conditions isList="true" count="0" />
          <Font>Microsoft Sans Serif,10</Font>
          <Guid>5a73b08d29294c05a09a905e156e3560</Guid>
          <HorAlignment>Right</HorAlignment>
          <Margins>0,0,0,0</Margins>
          <Name>Text5</Name>
          <Page isRef="4" />
          <Parent isRef="4" />
          <Text>&lt;b&gt;&lt;line-height="1.5"&gt;Link to Details:&lt;/line-height&gt;&lt;/b&gt;</Text>
          <TextBrush>[51:51:51]</TextBrush>
          <TextQuality>Wysiwyg</TextQuality>
          <Type>Expression</Type>
        </Text5>
        <Text6 Ref="10" type="Text" isKey="true">
          <AllowHtmlTags>True</AllowHtmlTags>
          <Brush>Transparent</Brush>
          <ClientRectangle>4.6,1,10.2,0.6</ClientRectangle>
          <Conditions isList="true" count="0" />
          <Font>Microsoft Sans Serif,9.75</Font>
          <Guid>d666cef6f51441dda0b39d364072a5a3</Guid>
          <Margins>0,0,0,0</Margins>
          <Name>Text6</Name>
          <Page isRef="4" />
          <Parent isRef="4" />
          <Text>&lt;line-height="1.5"&gt;{BankAccountMarkedAsSafeNotificationDTO.AccountNumber}&lt;/line-height&gt;</Text>
          <TextBrush>[51:51:51]</TextBrush>
          <TextQuality>Wysiwyg</TextQuality>
          <Type>Expression</Type>
        </Text6>
        <Text7 Ref="11" type="Text" isKey="true">
          <AllowHtmlTags>True</AllowHtmlTags>
          <Brush>Transparent</Brush>
          <ClientRectangle>4.6,1.8,10.2,0.6</ClientRectangle>
          <Conditions isList="true" count="0" />
          <Font>Microsoft Sans Serif,9.75</Font>
          <Guid>a43d44a16c9f455fb005c85e01288a46</Guid>
          <Margins>0,0,0,0</Margins>
          <Name>Text7</Name>
          <Page isRef="4" />
          <Parent isRef="4" />
          <Text>&lt;line-height="1.5"&gt;{BankAccountMarkedAsSafeNotificationDTO.SortCode}&lt;/line-height&gt;</Text>
          <TextBrush>[51:51:51]</TextBrush>
          <TextQuality>Wysiwyg</TextQuality>
          <Type>Expression</Type>
        </Text7>
        <Text8 Ref="12" type="Text" isKey="true">
          <AllowHtmlTags>True</AllowHtmlTags>
          <Brush>Transparent</Brush>
          <ClientRectangle>4.6,2.6,10.2,0.6</ClientRectangle>
          <Conditions isList="true" count="0" />
          <Font>Microsoft Sans Serif,9.75</Font>
          <Guid>f5dc17c70f1a40e8a4d0080105b86861</Guid>
          <Margins>0,0,0,0</Margins>
          <Name>Text8</Name>
          <Page isRef="4" />
          <Parent isRef="4" />
          <Text>&lt;line-height="1.5"&gt;{BankAccountMarkedAsSafeNotificationDTO.MarkedBy}&lt;/line-height&gt;</Text>
          <TextBrush>[51:51:51]</TextBrush>
          <TextQuality>Wysiwyg</TextQuality>
          <Type>Expression</Type>
        </Text8>
        <Text10 Ref="13" type="Text" isKey="true">
          <AllowHtmlTags>True</AllowHtmlTags>
          <Brush>Transparent</Brush>
          <ClientRectangle>4.6,3.4,10.2,0.6</ClientRectangle>
          <Conditions isList="true" count="0" />
          <Font>Microsoft Sans Serif,9.75,Underline</Font>
          <Guid>229a1094c32f475bb527a9678a572f42</Guid>
          <Hyperlink>{BankAccountMarkedAsSafeNotificationDTO.DetailsUrl}</Hyperlink>
          <Margins>0,0,0,0</Margins>
          <Name>Text10</Name>
          <Page isRef="4" />
          <Parent isRef="4" />
          <Text>&lt;line-height="1.5"&gt;Click Here&lt;/line-height&gt;
</Text>
          <TextBrush>[51:51:51]</TextBrush>
          <TextQuality>Wysiwyg</TextQuality>
          <Type>Expression</Type>
          <VertAlignment>Center</VertAlignment>
        </Text10>
      </Components>
      <Conditions isList="true" count="0" />
      <Guid>1b83758dda4046518274d0b090f93e62</Guid>
      <Hyperlink>#{NotificationSettingDTO.ServerURL}{NotificationSettingDTO.LoginRoute}</Hyperlink>
      <Margins>1,1,1,1</Margins>
      <Name>Page1</Name>
      <PageHeight>10</PageHeight>
      <PageWidth>17</PageWidth>
      <Report isRef="0" />
      <Watermark Ref="14" type="Stimulsoft.Report.Components.StiWatermark" isKey="true">
        <Font>Arial,100</Font>
        <TextBrush>[50:0:0:0]</TextBrush>
      </Watermark>
    </Page1>
  </Pages>
  <PrinterSettings Ref="15" type="Stimulsoft.Report.Print.StiPrinterSettings" isKey="true" />
  <ReferencedAssemblies isList="true" count="8">
    <value>System.Dll</value>
    <value>System.Drawing.Dll</value>
    <value>System.Windows.Forms.Dll</value>
    <value>System.Data.Dll</value>
    <value>System.Xml.Dll</value>
    <value>Stimulsoft.Controls.Dll</value>
    <value>Stimulsoft.Base.Dll</value>
    <value>Stimulsoft.Report.Dll</value>
  </ReferencedAssemblies>
  <ReportAlias>Report</ReportAlias>
  <ReportChanged>9/29/2015 10:40:38 AM</ReportChanged>
  <ReportCreated>9/29/2014 8:17:02 AM</ReportCreated>
  <ReportFile>C:\as.mrt</ReportFile>
  <ReportGuid>2e2a505e45034da08e9b16bb4d5ea62c</ReportGuid>
  <ReportName>Report</ReportName>
  <ReportUnit>Centimeters</ReportUnit>
  <ReportVersion>2015.1.8</ReportVersion>
  <Script>using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using Stimulsoft.Controls;
using Stimulsoft.Base.Drawing;
using Stimulsoft.Report;
using Stimulsoft.Report.Dialogs;
using Stimulsoft.Report.Components;

namespace Reports
{
    public class Report : Stimulsoft.Report.StiReport
    {
        public Report()        {
            this.InitializeComponent();
        }

        #region StiReport Designer generated code - do not modify
		#endregion StiReport Designer generated code - do not modify
    }
}
</Script>
  <ScriptLanguage>CSharp</ScriptLanguage>
  <Styles isList="true" count="0" />
</StiSerializer>',
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
  'BankAccountMarkedAsSafeNotificationDTO',
  'Bec.TargetFramework.Entities.DTO.Notification.BankAccountMarkedAsSafeNotificationDTO, Bec.TargetFramework.Entities',
  'BankAccountMarkedAsSafeNotificationDTO',
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
  'BankAccountMarkedAsSafe',
  'BankAccountMarkedAsSafe Notification Resource',
  true,
  false,
  null,
  123 -- Notification
);

-- Operations for Notification View/Edit/Send/Configure/MarkAsRead/MarkAsUnRead/Edit MUST EXIST FIRST
-- OrganisationTypeId = 31 - Professional
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
  (NcResID,(select "OperationID" from "Operation" where "OperationName" = 'View' limit 1),31,UserUserTypeID);

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
  (NcResID,(select "OperationID" from "Operation" where "OperationName" = 'MarkAsRead' limit 1),31,UserUserTypeID);


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
  (NcResID,(select "OperationID" from "Operation" where "OperationName" = 'MarkAsUnread' limit 1),31,UserUserTypeID);


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
  (NcResID,(select "OperationID" from "Operation" where "OperationName" = 'Send' limit 1),31,UserUserTypeID);


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
  (NcResID,(select "OperationID" from "Operation" where "OperationName" = 'Configure' limit 1),31,UserUserTypeID);


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
  (NcResID,(select "OperationID" from "Operation" where "OperationName" = 'Edit' limit 1),31,UserUserTypeID);

-- Add to DOT for specific org type

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


END $$;