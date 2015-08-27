--Run Operation script first
-- Run ExternalNotification and ExternalBatchNotification first

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
OrgEmployeeRoleID := (select "RoleID" from "Role" where "RoleName" = 'User' limit 1);
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
  'AddNewUserTempDetails',
  'Add New User Temp Details Notification',
  4989,
  4992,
  'New User Registration',
  'Test',
  '0001',
  'Bec.TargetFramework.SB.Notifications.Mutators.AddNewUserTempDetailsMutator, Bec.TargetFramework.SB.Notifications',
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
  E'\\357\\273\\277<?xml version="1.0" encoding="utf-8" standalone="yes"?>\\015\\012<StiSerializer version="1.02" type="Net" application="StiReport">\\015\\012  <CacheAllData>True</CacheAllData>\\015\\012  <Dictionary Ref="1" type="Dictionary" isKey="true">\\015\\012    <BusinessObjects isList="true" count="2">\\015\\012      <AddNewCompanyAndAdministratorDTO Ref="2" type="Stimulsoft.Report.Dictionary.StiBusinessObject" isKey="true">\\015\\012        <Alias>AddNewCompanyAndAdministratorDTO</Alias>\\015\\012        <BusinessObjects isList="true" count="0" />\\015\\012        <Category />\\015\\012        <Columns isList="true" count="10">\\015\\012          <value>FirstName,System.String</value>\\015\\012          <value>LastName,System.String</value>\\015\\012          <value>Password,System.String</value>\\015\\012          <value>ProductName,System.String</value>\\015\\012          <value>Salutation,System.String</value>\\015\\012          <value>Username,System.String</value>\\015\\012          <value>WebsiteURL,System.String</value>\\015\\012          <value>InviterSalutation,System.String</value>\\015\\012          <value>InviterFirstName,System.String</value>\\015\\012          <value>InviterLastName,System.String</value>\\015\\012        </Columns>\\015\\012        <Dictionary isRef="1" />\\015\\012        <Guid>922ef5bd22564fa6af64ad87fcdb8f1b</Guid>\\015\\012        <Name>AddNewCompanyAndAdministratorDTO</Name>\\015\\012      </AddNewCompanyAndAdministratorDTO>\\015\\012      <NotificationSettingDTO Ref="3" type="Stimulsoft.Report.Dictionary.StiBusinessObject" isKey="true">\\015\\012        <Alias>NotificationSettingDTO</Alias>\\015\\012        <BusinessObjects isList="true" count="0" />\\015\\012        <Category />\\015\\012        <Columns isList="true" count="11">\\015\\012          <value>ExportFormat,System.Nullable`1[System.Int32]</value>\\015\\012          <value>LoginRoute,System.String</value>\\015\\012          <value>NotificationConstructID,System.Guid</value>\\015\\012          <value>NotificationConstructVersionNumber,System.Int32</value>\\015\\012          <value>NotificationFromEmailAddress,System.String</value>\\015\\012          <value>NotificiationSentFromParentID,System.Guid</value>\\015\\012          <value>ServerLogoImageFileNameWithExtension,System.String</value>\\015\\012          <value>ServerNotificationImageContentURLFolder,System.String</value>\\015\\012          <value>ServerURL,System.String</value>\\015\\012          <value>Subject,System.String</value>\\015\\012          <value>Title,System.String</value>\\015\\012        </Columns>\\015\\012        <Dictionary isRef="1" />\\015\\012        <Guid>40876b7425c04da492dd1fdbb0f3a9f0</Guid>\\015\\012        <Name>NotificationSettingDTO</Name>\\015\\012      </NotificationSettingDTO>\\015\\012    </BusinessObjects>\\015\\012    <Databases isList="true" count="0" />\\015\\012    <DataSources isList="true" count="0" />\\015\\012    <Relations isList="true" count="0" />\\015\\012    <Report isRef="0" />\\015\\012    <Variables isList="true" count="1">\\015\\012      <value>General</value>\\015\\012    </Variables>\\015\\012  </Dictionary>\\015\\012  <EngineVersion>EngineV2</EngineVersion>\\015\\012  <GlobalizationStrings isList="true" count="0" />\\015\\012  <MetaTags isList="true" count="0" />\\015\\012  <Pages isList="true" count="1">\\015\\012    <Page1 Ref="4" type="Page" isKey="true">\\015\\012      <Border>None;Black;2;Solid;False;4;Black</Border>\\015\\012      <Brush>Transparent</Brush>\\015\\012      <Components isList="true" count="1">\\015\\012        <Text Ref="5" type="Text" isKey="true">\\015\\012          <AllowHtmlTags>True</AllowHtmlTags>\\015\\012          <AutoWidth>True</AutoWidth>\\015\\012          <Brush>Transparent</Brush>\\015\\012          <CanGrow>True</CanGrow>\\015\\012          <CanShrink>True</CanShrink>\\015\\012          <ClientRectangle>0,0,19,7.6</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Calibri,11.25,Regular,Point,False,0</Font>\\015\\012          <GrowToHeight>True</GrowToHeight>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text</Name>\\015\\012          <Page isRef="4" />\\015\\012          <Parent isRef="4" />\\015\\012          <Text>&lt;p&gt;\\015\\012Dear {AddNewCompanyAndAdministratorDTO.Salutation} {AddNewCompanyAndAdministratorDTO.FirstName} {AddNewCompanyAndAdministratorDTO.LastName},\\015\\012&lt;/p&gt;\\015\\012&lt;p&gt;\\015\\012{AddNewCompanyAndAdministratorDTO.InviterSalutation} {AddNewCompanyAndAdministratorDTO.InviterFirstName} {AddNewCompanyAndAdministratorDTO.InviterLastName} has invited you to the Safe Move Scheme system.\\015\\012&lt;/p&gt;\\015\\012&lt;p&gt;\\015\\012Please go to {AddNewCompanyAndAdministratorDTO.WebsiteURL} and login using the temporary details below:\\015\\012&lt;/p&gt;\\015\\012&lt;p&gt;\\015\\012Username: {AddNewCompanyAndAdministratorDTO.Username}\\015\\012&lt;br/&gt;\\015\\012Password: {AddNewCompanyAndAdministratorDTO.Password}\\015\\012&lt;/p&gt;\\015\\012&lt;p&gt;\\015\\012Please note that these are temporary login details to enable you to register and create your own secure login details. These account details will expire after 7 days.\\015\\012&lt;/p&gt;\\015\\012&lt;p&gt;\\015\\012Kind regards,\\015\\012&lt;/p&gt;\\015\\012&lt;p&gt;\\015\\012The {AddNewCompanyAndAdministratorDTO.ProductName} team\\015\\012&lt;/p&gt;</Text>\\015\\012          <TextBrush>Black</TextBrush>\\015\\012          <TextQuality>Wysiwyg</TextQuality>\\015\\012          <Type>Expression</Type>\\015\\012        </Text>\\015\\012      </Components>\\015\\012      <Conditions isList="true" count="0" />\\015\\012      <Guid>1b83758dda4046518274d0b090f93e62</Guid>\\015\\012      <Hyperlink>#{NotificationSettingDTO.ServerURL}{NotificationSettingDTO.LoginRoute}</Hyperlink>\\015\\012      <Margins>1,1,1,1</Margins>\\015\\012      <Name>Page1</Name>\\015\\012      <PageHeight>29.7</PageHeight>\\015\\012      <PageWidth>21</PageWidth>\\015\\012      <Report isRef="0" />\\015\\012      <Watermark Ref="6" type="Stimulsoft.Report.Components.StiWatermark" isKey="true">\\015\\012        <Font>Arial,100</Font>\\015\\012        <TextBrush>[50:0:0:0]</TextBrush>\\015\\012      </Watermark>\\015\\012    </Page1>\\015\\012  </Pages>\\015\\012  <PrinterSettings Ref="7" type="Stimulsoft.Report.Print.StiPrinterSettings" isKey="true" />\\015\\012  <ReferencedAssemblies isList="true" count="8">\\015\\012    <value>System.Dll</value>\\015\\012    <value>System.Drawing.Dll</value>\\015\\012    <value>System.Windows.Forms.Dll</value>\\015\\012    <value>System.Data.Dll</value>\\015\\012    <value>System.Xml.Dll</value>\\015\\012    <value>Stimulsoft.Controls.Dll</value>\\015\\012    <value>Stimulsoft.Base.Dll</value>\\015\\012    <value>Stimulsoft.Report.Dll</value>\\015\\012  </ReferencedAssemblies>\\015\\012  <ReportAlias>Report</ReportAlias>\\015\\012  <ReportChanged>8/27/2015 3:34:09 PM</ReportChanged>\\015\\012  <ReportCreated>9/29/2014 8:17:02 AM</ReportCreated>\\015\\012  <ReportFile>C:\\134Reports\\134uat\\134user.mrt</ReportFile>\\015\\012  <ReportGuid>566ad34d71f346ec8322c93813841df9</ReportGuid>\\015\\012  <ReportName>Report</ReportName>\\015\\012  <ReportUnit>Centimeters</ReportUnit>\\015\\012  <ReportVersion>2014.3.0</ReportVersion>\\015\\012  <Script>using System;\\015\\012using System.Drawing;\\015\\012using System.Windows.Forms;\\015\\012using System.Data;\\015\\012using Stimulsoft.Controls;\\015\\012using Stimulsoft.Base.Drawing;\\015\\012using Stimulsoft.Report;\\015\\012using Stimulsoft.Report.Dialogs;\\015\\012using Stimulsoft.Report.Components;\\015\\012\\015\\012namespace Reports\\015\\012{\\015\\012    public class Report : Stimulsoft.Report.StiReport\\015\\012    {\\015\\012        public Report()        {\\015\\012            this.InitializeComponent();\\015\\012        }\\015\\012\\015\\012        #region StiReport Designer generated code - do not modify\\015\\012\\011\\011#endregion StiReport Designer generated code - do not modify\\015\\012    }\\015\\012}\\015\\012</Script>\\015\\012  <ScriptLanguage>CSharp</ScriptLanguage>\\015\\012  <Styles isList="true" count="0" />\\015\\012</StiSerializer>',
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
  'AddNewCompanyAndAdministratorDTO',
  'Bec.TargetFramework.Entities.AddNewCompanyAndAdministratorDTO, Bec.TargetFramework.Entities',
  'AddNewCompanyAndAdministratorDTO',
  'Bec.TargetFramework.Entities',
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
  'AddNewUserTempDetails Notification',
  'AddNewUserTempDetails Resource',
  true,
  false,
  null
);

-- Operations for Notification View/Edit/Send/Configure/MarkAsRead/MarkAsUnRead/Edit MUST EXIST FIRST

-- For
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


-- add claims to role so that

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