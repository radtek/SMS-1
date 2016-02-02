update public."NotificationConstructData" set "NotificationData" = E'\\357\\273\\277<?xml version="1.0" encoding="utf-8" standalone="yes"?>\\015\\012<StiSerializer version="1.02" type="Net" application="StiReport">\\015\\012  <CacheAllData>True</CacheAllData>\\015\\012  <Dictionary Ref="1" type="Dictionary" isKey="true">\\015\\012    <BusinessObjects isList="true" count="2">\\015\\012      <NotificationSettingDTO Ref="2" type="Stimulsoft.Report.Dictionary.StiBusinessObject" isKey="true">\\015\\012        <Alias>NotificationSettingDTO</Alias>\\015\\012        <BusinessObjects isList="true" count="0" />\\015\\012        <Category>General</Category>\\015\\012        <Columns isList="true" count="10">\\015\\012          <value>ExportFormat,System.Nullable`1[System.Int32]</value>\\015\\012          <value>NotificationConstructID,System.Guid</value>\\015\\012          <value>NotificationConstructVersionNumber,System.Int32</value>\\015\\012          <value>NotificiationSentFromParentID,System.Guid</value>\\015\\012          <value>ServerLogoImageFileNameWithExtension,System.String</value>\\015\\012          <value>ServerNotificationImageContentURLFolder,System.String</value>\\015\\012          <value>ServerURL,System.String</value>\\015\\012          <value>LoginRoute,System.String</value>\\015\\012          <value>Subject,System.String</value>\\015\\012          <value>Title,System.String</value>\\015\\012        </Columns>\\015\\012        <Dictionary isRef="1" />\\015\\012        <Guid>af4abf77a08a413fba97a142ac3d403b</Guid>\\015\\012        <Name>NotificationSettingDTO</Name>\\015\\012      </NotificationSettingDTO>\\015\\012      <BankAccountMarkedAsSafeNotificationDTO Ref="3" type="Stimulsoft.Report.Dictionary.StiBusinessObject" isKey="true">\\015\\012        <Alias>BankAccountMarkedAsSafeNotificationDTO</Alias>\\015\\012        <BusinessObjects isList="true" count="0" />\\015\\012        <Category>General</Category>\\015\\012        <Columns isList="true" count="6">\\015\\012          <value>AccountNumber,System.String</value>\\015\\012          <value>DetailsUrl,System.String</value>\\015\\012          <value>MarkedBy,System.String</value>\\015\\012          <value>OrganisationId,System.Guid</value>\\015\\012          <value>Reason,System.String</value>\\015\\012          <value>SortCode,System.String</value>\\015\\012        </Columns>\\015\\012        <Dictionary isRef="1" />\\015\\012        <Guid>44f8d67b23c44cc0be50ebaa3a9ba35c</Guid>\\015\\012        <Name>BankAccountMarkedAsSafeNotificationDTO</Name>\\015\\012      </BankAccountMarkedAsSafeNotificationDTO>\\015\\012    </BusinessObjects>\\015\\012    <Databases isList="true" count="0" />\\015\\012    <DataSources isList="true" count="0" />\\015\\012    <Relations isList="true" count="0" />\\015\\012    <Report isRef="0" />\\015\\012    <Variables isList="true" count="1">\\015\\012      <value>General</value>\\015\\012    </Variables>\\015\\012  </Dictionary>\\015\\012  <EngineVersion>EngineV2</EngineVersion>\\015\\012  <GlobalizationStrings isList="true" count="0" />\\015\\012  <MetaTags isList="true" count="0" />\\015\\012  <Pages isList="true" count="1">\\015\\012    <Page1 Ref="4" type="Page" isKey="true">\\015\\012      <Border>None;Black;2;Solid;False;4;Black</Border>\\015\\012      <Brush>Transparent</Brush>\\015\\012      <Components isList="true" count="5">\\015\\012        <TextContent Ref="5" type="Text" isKey="true">\\015\\012          <AllowHtmlTags>True</AllowHtmlTags>\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>0,0,15,2</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Microsoft Sans Serif,11</Font>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>TextContent</Name>\\015\\012          <Page isRef="4" />\\015\\012          <Parent isRef="4" />\\015\\012          <Text>Bank account {BankAccountMarkedAsSafeNotificationDTO.SortCode}, {BankAccountMarkedAsSafeNotificationDTO.AccountNumber} has been marked as safe - you can now add transactionsto the Safe Move Scheme. For further details please see the Downloads section.</Text>\\015\\012          <TextBrush>[51:51:51]</TextBrush>\\015\\012          <TextOptions>,,,,WordWrap=True,A=0</TextOptions>\\015\\012          <TextQuality>Wysiwyg</TextQuality>\\015\\012          <Type>Expression</Type>\\015\\012        </TextContent>\\015\\012        <Text3 Ref="6" type="Text" isKey="true">\\015\\012          <AllowHtmlTags>True</AllowHtmlTags>\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>0.4,2.6,3.6,0.6</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Microsoft Sans Serif,10</Font>\\015\\012          <Guid>6c399a13d2c84d6693f2b15a61d189d8</Guid>\\015\\012          <HorAlignment>Right</HorAlignment>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text3</Name>\\015\\012          <Page isRef="4" />\\015\\012          <Parent isRef="4" />\\015\\012          <Text>&lt;b&gt;&lt;line-height="1.5"&gt;Changed By:&lt;/line-height&gt;&lt;/b&gt;</Text>\\015\\012          <TextBrush>[51:51:51]</TextBrush>\\015\\012          <TextQuality>Wysiwyg</TextQuality>\\015\\012          <Type>Expression</Type>\\015\\012        </Text3>\\015\\012        <Text5 Ref="7" type="Text" isKey="true">\\015\\012          <AllowHtmlTags>True</AllowHtmlTags>\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>0.4,3.4,3.6,0.6</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Microsoft Sans Serif,10</Font>\\015\\012          <Guid>5a73b08d29294c05a09a905e156e3560</Guid>\\015\\012          <HorAlignment>Right</HorAlignment>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text5</Name>\\015\\012          <Page isRef="4" />\\015\\012          <Parent isRef="4" />\\015\\012          <Text>&lt;b&gt;&lt;line-height="1.5"&gt;Link to Details:&lt;/line-height&gt;&lt;/b&gt;</Text>\\015\\012          <TextBrush>[51:51:51]</TextBrush>\\015\\012          <TextQuality>Wysiwyg</TextQuality>\\015\\012          <Type>Expression</Type>\\015\\012        </Text5>\\015\\012        <Text8 Ref="8" type="Text" isKey="true">\\015\\012          <AllowHtmlTags>True</AllowHtmlTags>\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>4.6,2.6,10.2,0.6</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Microsoft Sans Serif,9.75</Font>\\015\\012          <Guid>f5dc17c70f1a40e8a4d0080105b86861</Guid>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text8</Name>\\015\\012          <Page isRef="4" />\\015\\012          <Parent isRef="4" />\\015\\012          <Text>&lt;line-height="1.5"&gt;{BankAccountMarkedAsSafeNotificationDTO.MarkedBy}&lt;/line-height&gt;</Text>\\015\\012          <TextBrush>[51:51:51]</TextBrush>\\015\\012          <TextQuality>Wysiwyg</TextQuality>\\015\\012          <Type>Expression</Type>\\015\\012        </Text8>\\015\\012        <Text10 Ref="9" type="Text" isKey="true">\\015\\012          <AllowHtmlTags>True</AllowHtmlTags>\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>4.6,3.4,10.2,0.6</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Microsoft Sans Serif,9.75,Underline</Font>\\015\\012          <Guid>229a1094c32f475bb527a9678a572f42</Guid>\\015\\012          <Hyperlink>{BankAccountMarkedAsSafeNotificationDTO.DetailsUrl}</Hyperlink>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text10</Name>\\015\\012          <Page isRef="4" />\\015\\012          <Parent isRef="4" />\\015\\012          <Text>&lt;line-height="1.5"&gt;Click Here&lt;/line-height&gt;\\015\\012</Text>\\015\\012          <TextBrush>[51:51:51]</TextBrush>\\015\\012          <TextQuality>Wysiwyg</TextQuality>\\015\\012          <Type>Expression</Type>\\015\\012          <VertAlignment>Center</VertAlignment>\\015\\012        </Text10>\\015\\012      </Components>\\015\\012      <Conditions isList="true" count="0" />\\015\\012      <Guid>1b83758dda4046518274d0b090f93e62</Guid>\\015\\012      <Hyperlink>#{NotificationSettingDTO.ServerURL}{NotificationSettingDTO.LoginRoute}</Hyperlink>\\015\\012      <Margins>1,1,1,1</Margins>\\015\\012      <Name>Page1</Name>\\015\\012      <PageHeight>10</PageHeight>\\015\\012      <PageWidth>17</PageWidth>\\015\\012      <Report isRef="0" />\\015\\012      <Watermark Ref="10" type="Stimulsoft.Report.Components.StiWatermark" isKey="true">\\015\\012        <Font>Arial,100</Font>\\015\\012        <TextBrush>[50:0:0:0]</TextBrush>\\015\\012      </Watermark>\\015\\012    </Page1>\\015\\012  </Pages>\\015\\012  <PrinterSettings Ref="11" type="Stimulsoft.Report.Print.StiPrinterSettings" isKey="true" />\\015\\012  <ReferencedAssemblies isList="true" count="8">\\015\\012    <value>System.Dll</value>\\015\\012    <value>System.Drawing.Dll</value>\\015\\012    <value>System.Windows.Forms.Dll</value>\\015\\012    <value>System.Data.Dll</value>\\015\\012    <value>System.Xml.Dll</value>\\015\\012    <value>Stimulsoft.Controls.Dll</value>\\015\\012    <value>Stimulsoft.Base.Dll</value>\\015\\012    <value>Stimulsoft.Report.Dll</value>\\015\\012  </ReferencedAssemblies>\\015\\012  <ReportAlias>Report</ReportAlias>\\015\\012  <ReportChanged>2/2/2016 12:41:57 PM</ReportChanged>\\015\\012  <ReportCreated>9/29/2014 8:17:02 AM</ReportCreated>\\015\\012  <ReportFile>C:\\134reports\\134bank account marked safe.mrt</ReportFile>\\015\\012  <ReportGuid>74950dc68c6f4dc8be480dc48c1bc20a</ReportGuid>\\015\\012  <ReportName>Report</ReportName>\\015\\012  <ReportUnit>Centimeters</ReportUnit>\\015\\012  <ReportVersion>2015.1.8</ReportVersion>\\015\\012  <Script>using System;\\015\\012using System.Drawing;\\015\\012using System.Windows.Forms;\\015\\012using System.Data;\\015\\012using Stimulsoft.Controls;\\015\\012using Stimulsoft.Base.Drawing;\\015\\012using Stimulsoft.Report;\\015\\012using Stimulsoft.Report.Dialogs;\\015\\012using Stimulsoft.Report.Components;\\015\\012\\015\\012namespace Reports\\015\\012{\\015\\012    public class Report : Stimulsoft.Report.StiReport\\015\\012    {\\015\\012        public Report()        {\\015\\012            this.InitializeComponent();\\015\\012        }\\015\\012\\015\\012        #region StiReport Designer generated code - do not modify\\015\\012\\011\\011#endregion StiReport Designer generated code - do not modify\\015\\012    }\\015\\012}\\015\\012</Script>\\015\\012  <ScriptLanguage>CSharp</ScriptLanguage>\\015\\012  <Styles isList="true" count="0" />\\015\\012</StiSerializer>'
where "NotificationConstructID" = (select "NotificationConstructID" from "NotificationConstruct" where "Name"  = 'BankAccountMarkedAsSafe');

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
    abs((extract(epoch from inv."CreatedOn")-3600) - extract (epoch from tx."CreatedOn")) < 2)



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
