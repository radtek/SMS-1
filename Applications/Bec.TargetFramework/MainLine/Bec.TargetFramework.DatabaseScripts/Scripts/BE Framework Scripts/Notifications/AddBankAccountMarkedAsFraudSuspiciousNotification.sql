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
  'BankAccountMarkedAsFraudSuspicious',
  'Bank Account Marked as Fraud Suspicious Notification',
  4989, -- HTML
  4993, -- System
  'Bank Account Marked as Fraud Suspicious' ,
  'Test',
  '0001',
  'Bec.TargetFramework.SB.Notifications.Mutators.BankAccountMarkedAsFraudSuspiciousMutator, Bec.TargetFramework.SB.Notifications',
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
      <BankAccountMarkedAsFraudSuspiciousNotificationDTO Ref="3" type="Stimulsoft.Report.Dictionary.StiBusinessObject" isKey="true">
        <Alias>BankAccountMarkedAsFraudSuspiciousNotificationDTO</Alias>
        <BusinessObjects isList="true" count="0" />
        <Category>General</Category>
        <Columns isList="true" count="6">
          <value>AccountNumber,System.String</value>
          <value>DetailsUrl,System.String</value>
          <value>MarkedBy,System.String</value>
          <value>Reason,System.String</value>
          <value>SortCode,System.String</value>
          <value>UserAccountOrganisationIds,System.Collections.Generic.IEnumerable`1[System.Guid]</value>
        </Columns>
        <Dictionary isRef="1" />
        <Guid>52a0e19226cf4087a42d060c394e8503</Guid>
        <Name>BankAccountMarkedAsFraudSuspiciousNotificationDTO</Name>
      </BankAccountMarkedAsFraudSuspiciousNotificationDTO>
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
      <Components isList="true" count="11">
        <TextContent Ref="5" type="Text" isKey="true">
          <AllowHtmlTags>True</AllowHtmlTags>
          <Brush>Transparent</Brush>
          <ClientRectangle>0,0,13.2,0.4</ClientRectangle>
          <Conditions isList="true" count="0" />
          <Font>Arial,11</Font>
          <Margins>0,0,0,0</Margins>
          <Name>TextContent</Name>
          <Page isRef="4" />
          <Parent isRef="4" />
          <Text>&lt;h2&gt;The following bank account was Marked as Fraud Suspicious&lt;/h2&gt;</Text>
          <TextBrush>Black</TextBrush>
          <TextQuality>Wysiwyg</TextQuality>
          <Type>Expression</Type>
        </TextContent>
        <Text1 Ref="6" type="Text" isKey="true">
          <AllowHtmlTags>True</AllowHtmlTags>
          <Brush>Transparent</Brush>
          <ClientRectangle>0,1,3.6,0.4</ClientRectangle>
          <Conditions isList="true" count="0" />
          <Font>Arial,11</Font>
          <Guid>ebcb4cd1ff9248ecb0d71fac524e64c2</Guid>
          <Margins>0,0,0,0</Margins>
          <Name>Text1</Name>
          <Page isRef="4" />
          <Parent isRef="4" />
          <Text>&lt;b&gt;Account Number:&lt;/b&gt;</Text>
          <TextBrush>Black</TextBrush>
          <TextQuality>Wysiwyg</TextQuality>
          <Type>Expression</Type>
        </Text1>
        <Text2 Ref="7" type="Text" isKey="true">
          <AllowHtmlTags>True</AllowHtmlTags>
          <Brush>Transparent</Brush>
          <ClientRectangle>0,1.6,3.6,0.4</ClientRectangle>
          <Conditions isList="true" count="0" />
          <Font>Arial,11</Font>
          <Guid>33e0aa711397490c80cb73e979bf78e2</Guid>
          <Margins>0,0,0,0</Margins>
          <Name>Text2</Name>
          <Page isRef="4" />
          <Parent isRef="4" />
          <Text>&lt;b&gt;Sort Code:&lt;/b&gt;</Text>
          <TextBrush>Black</TextBrush>
          <TextQuality>Wysiwyg</TextQuality>
          <Type>Expression</Type>
        </Text2>
        <Text3 Ref="8" type="Text" isKey="true">
          <AllowHtmlTags>True</AllowHtmlTags>
          <Brush>Transparent</Brush>
          <ClientRectangle>0,2.2,3.6,0.4</ClientRectangle>
          <Conditions isList="true" count="0" />
          <Font>Arial,11</Font>
          <Guid>6c399a13d2c84d6693f2b15a61d189d8</Guid>
          <Margins>0,0,0,0</Margins>
          <Name>Text3</Name>
          <Page isRef="4" />
          <Parent isRef="4" />
          <Text>&lt;b&gt;Marked By:&lt;/b&gt;</Text>
          <TextBrush>Black</TextBrush>
          <TextQuality>Wysiwyg</TextQuality>
          <Type>Expression</Type>
        </Text3>
        <Text4 Ref="9" type="Text" isKey="true">
          <AllowHtmlTags>True</AllowHtmlTags>
          <Brush>Transparent</Brush>
          <ClientRectangle>0,2.8,3.6,0.4</ClientRectangle>
          <Conditions isList="true" count="0" />
          <Font>Arial,11</Font>
          <Guid>f529bd40df864983ac80b72c57474403</Guid>
          <Margins>0,0,0,0</Margins>
          <Name>Text4</Name>
          <Page isRef="4" />
          <Parent isRef="4" />
          <Text>&lt;b&gt;Reason:&lt;/b&gt;</Text>
          <TextBrush>Black</TextBrush>
          <TextQuality>Wysiwyg</TextQuality>
          <Type>Expression</Type>
        </Text4>
        <Text5 Ref="10" type="Text" isKey="true">
          <AllowHtmlTags>True</AllowHtmlTags>
          <Brush>Transparent</Brush>
          <ClientRectangle>0,3.4,3.6,0.4</ClientRectangle>
          <Conditions isList="true" count="0" />
          <Font>Arial,11</Font>
          <Guid>5a73b08d29294c05a09a905e156e3560</Guid>
          <Margins>0,0,0,0</Margins>
          <Name>Text5</Name>
          <Page isRef="4" />
          <Parent isRef="4" />
          <Text>&lt;b&gt;Link to Details:&lt;/b&gt;</Text>
          <TextBrush>Black</TextBrush>
          <TextQuality>Wysiwyg</TextQuality>
          <Type>Expression</Type>
        </Text5>
        <Text6 Ref="11" type="Text" isKey="true">
          <AllowHtmlTags>True</AllowHtmlTags>
          <Brush>Transparent</Brush>
          <ClientRectangle>4,1,11,0.4</ClientRectangle>
          <Conditions isList="true" count="0" />
          <Font>Arial,11</Font>
          <Guid>d666cef6f51441dda0b39d364072a5a3</Guid>
          <Margins>0,0,0,0</Margins>
          <Name>Text6</Name>
          <Page isRef="4" />
          <Parent isRef="4" />
          <Text>{BankAccountMarkedAsFraudSuspiciousNotificationDTO.AccountNumber}</Text>
          <TextBrush>Black</TextBrush>
          <TextQuality>Wysiwyg</TextQuality>
          <Type>Expression</Type>
        </Text6>
        <Text7 Ref="12" type="Text" isKey="true">
          <AllowHtmlTags>True</AllowHtmlTags>
          <Brush>Transparent</Brush>
          <ClientRectangle>4,1.6,11,0.4</ClientRectangle>
          <Conditions isList="true" count="0" />
          <Font>Arial,11</Font>
          <Guid>a43d44a16c9f455fb005c85e01288a46</Guid>
          <Margins>0,0,0,0</Margins>
          <Name>Text7</Name>
          <Page isRef="4" />
          <Parent isRef="4" />
          <Text>{BankAccountMarkedAsFraudSuspiciousNotificationDTO.SortCode}</Text>
          <TextBrush>Black</TextBrush>
          <TextQuality>Wysiwyg</TextQuality>
          <Type>DataColumn</Type>
        </Text7>
        <Text8 Ref="13" type="Text" isKey="true">
          <AllowHtmlTags>True</AllowHtmlTags>
          <Brush>Transparent</Brush>
          <ClientRectangle>4,2.2,11,0.4</ClientRectangle>
          <Conditions isList="true" count="0" />
          <Font>Arial,11</Font>
          <Guid>f5dc17c70f1a40e8a4d0080105b86861</Guid>
          <Margins>0,0,0,0</Margins>
          <Name>Text8</Name>
          <Page isRef="4" />
          <Parent isRef="4" />
          <Text>{BankAccountMarkedAsFraudSuspiciousNotificationDTO.MarkedBy}</Text>
          <TextBrush>Black</TextBrush>
          <TextQuality>Wysiwyg</TextQuality>
          <Type>DataColumn</Type>
        </Text8>
        <Text9 Ref="14" type="Text" isKey="true">
          <AllowHtmlTags>True</AllowHtmlTags>
          <Brush>Transparent</Brush>
          <ClientRectangle>4,2.8,11,0.4</ClientRectangle>
          <Conditions isList="true" count="0" />
          <Font>Arial,11</Font>
          <Guid>48927f2ae58c41d6abd74782fb99cb39</Guid>
          <Margins>0,0,0,0</Margins>
          <Name>Text9</Name>
          <Page isRef="4" />
          <Parent isRef="4" />
          <Text>{BankAccountMarkedAsFraudSuspiciousNotificationDTO.Reason}</Text>
          <TextBrush>Black</TextBrush>
          <TextQuality>Wysiwyg</TextQuality>
          <Type>DataColumn</Type>
        </Text9>
        <Text10 Ref="15" type="Text" isKey="true">
          <AllowHtmlTags>True</AllowHtmlTags>
          <Brush>Transparent</Brush>
          <ClientRectangle>4,3.4,11,0.4</ClientRectangle>
          <Conditions isList="true" count="0" />
          <Font>Arial,11,Underline</Font>
          <Guid>229a1094c32f475bb527a9678a572f42</Guid>
          <Hyperlink>{BankAccountMarkedAsFraudSuspiciousNotificationDTO.DetailsUrl}</Hyperlink>
          <Margins>0,0,0,0</Margins>
          <Name>Text10</Name>
          <Page isRef="4" />
          <Parent isRef="4" />
          <Text>Click Here
</Text>
          <TextBrush>Black</TextBrush>
          <TextQuality>Wysiwyg</TextQuality>
          <Type>Expression</Type>
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
      <Watermark Ref="16" type="Stimulsoft.Report.Components.StiWatermark" isKey="true">
        <Font>Arial,100</Font>
        <TextBrush>[50:0:0:0]</TextBrush>
      </Watermark>
    </Page1>
  </Pages>
  <PrinterSettings Ref="17" type="Stimulsoft.Report.Print.StiPrinterSettings" isKey="true" />
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
  <ReportChanged>8/7/2015 10:35:39 AM</ReportChanged>
  <ReportCreated>9/29/2014 8:17:02 AM</ReportCreated>
  <ReportFile>C:\GitRepositories\BEF\Applications\Bec.TargetFramework\MainLine\Bec.TargetFramework.DatabaseScripts\Reports\BEF\BankAccountMarkedAsFraudSuspicious.mrt</ReportFile>
  <ReportGuid>9da7dbe08eb343bdb55b018dc791a800</ReportGuid>
  <ReportName>Report</ReportName>
  <ReportUnit>Centimeters</ReportUnit>
  <ReportVersion>2014.3.0</ReportVersion>
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
  'BankAccountMarkedAsFraudSuspiciousNotificationDTO',
  'Bec.TargetFramework.Entities.DTO.Notification.BankAccountMarkedAsFraudSuspiciousNotificationDTO, Bec.TargetFramework.Entities',
  'BankAccountMarkedAsFraudSuspiciousNotificationDTO',
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
  "ParentID"
)
VALUES (
  NcResID,
  'BankAccountMarkedAsFraudSuspicious Notification',
  'BankAccountMarkedAsFraudSuspicious Resource',
  true,
  false,
  null
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