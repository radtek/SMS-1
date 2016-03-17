
-- Message 'notification'
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
  '4fb339f0-489f-11e4-a2d3-ef22e59948be',
  1,
  'SafeBuyerReceipt',
  'Safe Buyer Receipt',
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
  '4fb339f0-489f-11e4-a2d3-ef22e59948be',
  1,
  E'\\357\\273\\277<?xml version="1.0" encoding="utf-8" standalone="yes"?>\\015\\012<StiSerializer version="1.02" type="Net" application="StiReport">\\015\\012  <Dictionary Ref="1" type="Dictionary" isKey="true">\\015\\012    <BusinessObjects isList="true" count="1">\\015\\012      <SafeBuyerReceiptDTO Ref="2" type="Stimulsoft.Report.Dictionary.StiBusinessObject" isKey="true">\\015\\012        <Alias>SafeBuyerReceiptDTO</Alias>\\015\\012        <BusinessObjects isList="true" count="3">\\015\\012          <BecAddress Ref="3" type="Stimulsoft.Report.Dictionary.StiBusinessObject" isKey="true">\\015\\012            <Alias>BecAddress</Alias>\\015\\012            <BusinessObjects isList="true" count="0" />\\015\\012            <Category />\\015\\012            <Columns isList="true" count="5">\\015\\012              <value>Line1,System.String</value>\\015\\012              <value>Line2,System.String</value>\\015\\012              <value>Town,System.String</value>\\015\\012              <value>County,System.String</value>\\015\\012              <value>PostalCode,System.String</value>\\015\\012            </Columns>\\015\\012            <Dictionary isRef="1" />\\015\\012            <Guid>73e54ab5452d4426bade5ae33f8c16c2</Guid>\\015\\012            <Name>BecAddress</Name>\\015\\012          </BecAddress>\\015\\012          <CustomerAddress Ref="4" type="Stimulsoft.Report.Dictionary.StiBusinessObject" isKey="true">\\015\\012            <Alias>CustomerAddress</Alias>\\015\\012            <BusinessObjects isList="true" count="0" />\\015\\012            <Category />\\015\\012            <Columns isList="true" count="5">\\015\\012              <value>Line1,System.String</value>\\015\\012              <value>Line2,System.String</value>\\015\\012              <value>Town,System.String</value>\\015\\012              <value>County,System.String</value>\\015\\012              <value>PostalCode,System.String</value>\\015\\012            </Columns>\\015\\012            <Dictionary isRef="1" />\\015\\012            <Guid>1609c84a0acb4a52a415ae431dbee07b</Guid>\\015\\012            <Name>CustomerAddress</Name>\\015\\012          </CustomerAddress>\\015\\012          <Items Ref="5" type="Stimulsoft.Report.Dictionary.StiBusinessObject" isKey="true">\\015\\012            <Alias>Items</Alias>\\015\\012            <BusinessObjects isList="true" count="0" />\\015\\012            <Category />\\015\\012            <Columns isList="true" count="5">\\015\\012              <value>Quantity,System.Decimal</value>\\015\\012              <value>Description,System.String</value>\\015\\012              <value>Goods,System.Decimal</value>\\015\\012              <value>Vat,System.Decimal</value>\\015\\012              <value>Total,System.Decimal</value>\\015\\012            </Columns>\\015\\012            <Dictionary isRef="1" />\\015\\012            <Guid>7ca8ab0073244b60ba07a06527196f83</Guid>\\015\\012            <Name>Items</Name>\\015\\012          </Items>\\015\\012        </BusinessObjects>\\015\\012        <Category />\\015\\012        <Columns isList="true" count="8">\\015\\012          <value>CompanyName,System.String</value>\\015\\012          <value>CustomerName,System.String</value>\\015\\012          <value>Goods,System.Decimal</value>\\015\\012          <value>InvoiceDate,System.DateTime</value>\\015\\012          <value>InvoiceNumber,System.Int32</value>\\015\\012          <value>Total,System.Decimal</value>\\015\\012          <value>Vat,System.Decimal</value>\\015\\012          <value>VatNumber,System.String</value>\\015\\012        </Columns>\\015\\012        <Dictionary isRef="1" />\\015\\012        <Guid>a7337ecb27254b1bb734601eeb800421</Guid>\\015\\012        <Name>SafeBuyerReceiptDTO</Name>\\015\\012      </SafeBuyerReceiptDTO>\\015\\012    </BusinessObjects>\\015\\012    <Databases isList="true" count="0" />\\015\\012    <DataSources isList="true" count="0" />\\015\\012    <Relations isList="true" count="0" />\\015\\012    <Report isRef="0" />\\015\\012    <Variables isList="true" count="1">\\015\\012      <value>General</value>\\015\\012    </Variables>\\015\\012  </Dictionary>\\015\\012  <EngineVersion>EngineV2</EngineVersion>\\015\\012  <GlobalizationStrings isList="true" count="0" />\\015\\012  <MetaTags isList="true" count="0" />\\015\\012  <Pages isList="true" count="1">\\015\\012    <Page1 Ref="6" type="Page" isKey="true">\\015\\012      <Border>None;Black;2;Solid;False;4;Black</Border>\\015\\012      <Brush>Transparent</Brush>\\015\\012      <Components isList="true" count="4">\\015\\012        <ReportTitle Ref="7" type="ReportTitleBand" isKey="true">\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>0,0.4,19,9.2</ClientRectangle>\\015\\012          <Components isList="true" count="16">\\015\\012            <ReportTitleText Ref="8" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>0,0,7.6,1.2</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,20,Bold</Font>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>ReportTitleText</Name>\\015\\012              <Page isRef="6" />\\015\\012              <Parent isRef="7" />\\015\\012              <Text>Safe Buyer Receipt</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <Type>Expression</Type>\\015\\012              <VertAlignment>Center</VertAlignment>\\015\\012            </ReportTitleText>\\015\\012            <Text2 Ref="9" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>0,2.4,10.8,0.6</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,12</Font>\\015\\012              <GrowToHeight>True</GrowToHeight>\\015\\012              <Guid>106407e22a754165b0b657365ffa58e3</Guid>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>Text2</Name>\\015\\012              <Page isRef="6" />\\015\\012              <Parent isRef="7" />\\015\\012              <Text>{SafeBuyerReceiptDTO.CustomerName}</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <TextOptions>,,,,WordWrap=True,A=0</TextOptions>\\015\\012              <TextQuality>Wysiwyg</TextQuality>\\015\\012              <Type>Expression</Type>\\015\\012            </Text2>\\015\\012            <Text1 Ref="10" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>0,3,10.8,0.6</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,12</Font>\\015\\012              <GrowToHeight>True</GrowToHeight>\\015\\012              <Guid>4fee3ed122424ee1b8fc0ff26deec1a6</Guid>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>Text1</Name>\\015\\012              <Page isRef="6" />\\015\\012              <Parent isRef="7" />\\015\\012              <Text>{SafeBuyerReceiptDTO.CustomerAddress.Line1}</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <TextOptions>,,,,WordWrap=True,A=0</TextOptions>\\015\\012              <TextQuality>Wysiwyg</TextQuality>\\015\\012              <Type>Expression</Type>\\015\\012            </Text1>\\015\\012            <Text3 Ref="11" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>0,3.6,10.8,0.6</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,12</Font>\\015\\012              <GrowToHeight>True</GrowToHeight>\\015\\012              <Guid>2169901743b24c8db6a5c04949c85556</Guid>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>Text3</Name>\\015\\012              <Page isRef="6" />\\015\\012              <Parent isRef="7" />\\015\\012              <Text>{SafeBuyerReceiptDTO.CustomerAddress.Line2}</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <TextOptions>,,,,WordWrap=True,A=0</TextOptions>\\015\\012              <TextQuality>Wysiwyg</TextQuality>\\015\\012              <Type>Expression</Type>\\015\\012            </Text3>\\015\\012            <Text4 Ref="12" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>0,4.2,10.8,0.6</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,12</Font>\\015\\012              <GrowToHeight>True</GrowToHeight>\\015\\012              <Guid>865960acde9347f49b3babe6b62c6ed3</Guid>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>Text4</Name>\\015\\012              <Page isRef="6" />\\015\\012              <Parent isRef="7" />\\015\\012              <Text>{SafeBuyerReceiptDTO.CustomerAddress.Town}</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <TextOptions>,,,,WordWrap=True,A=0</TextOptions>\\015\\012              <TextQuality>Wysiwyg</TextQuality>\\015\\012              <Type>Expression</Type>\\015\\012            </Text4>\\015\\012            <Text5 Ref="13" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>0,4.8,10.8,0.6</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,12</Font>\\015\\012              <GrowToHeight>True</GrowToHeight>\\015\\012              <Guid>5fbe1b5ea05a4572920336ce075b5353</Guid>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>Text5</Name>\\015\\012              <Page isRef="6" />\\015\\012              <Parent isRef="7" />\\015\\012              <Text>{SafeBuyerReceiptDTO.CustomerAddress.County}</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <TextOptions>,,,,WordWrap=True,A=0</TextOptions>\\015\\012              <TextQuality>Wysiwyg</TextQuality>\\015\\012              <Type>Expression</Type>\\015\\012            </Text5>\\015\\012            <Text6 Ref="14" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>0,5.4,10.8,0.6</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,12</Font>\\015\\012              <GrowToHeight>True</GrowToHeight>\\015\\012              <Guid>2e1af32038754719929eb1a246813c36</Guid>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>Text6</Name>\\015\\012              <Page isRef="6" />\\015\\012              <Parent isRef="7" />\\015\\012              <Text>{SafeBuyerReceiptDTO.CustomerAddress.PostalCode}</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <TextOptions>,,,,WordWrap=True,A=0</TextOptions>\\015\\012              <TextQuality>Wysiwyg</TextQuality>\\015\\012              <Type>Expression</Type>\\015\\012            </Text6>\\015\\012            <Text7 Ref="15" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>13.6,2.6,5.4,0.6</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,12</Font>\\015\\012              <GrowToHeight>True</GrowToHeight>\\015\\012              <Guid>8ad11b4eb79149d7a619bc2d19b153eb</Guid>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>Text7</Name>\\015\\012              <Page isRef="6" />\\015\\012              <Parent isRef="7" />\\015\\012              <Text>{SafeBuyerReceiptDTO.BecAddress.Line1}</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <TextOptions>,,,,WordWrap=True,A=0</TextOptions>\\015\\012              <TextQuality>Wysiwyg</TextQuality>\\015\\012              <Type>Expression</Type>\\015\\012            </Text7>\\015\\012            <Text9 Ref="16" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>13.6,3.2,5.4,0.6</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,12</Font>\\015\\012              <GrowToHeight>True</GrowToHeight>\\015\\012              <Guid>10f4729d51e34674b1cf129d8dc848f5</Guid>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>Text9</Name>\\015\\012              <Page isRef="6" />\\015\\012              <Parent isRef="7" />\\015\\012              <Text>{SafeBuyerReceiptDTO.BecAddress.Line2}</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <TextOptions>,,,,WordWrap=True,A=0</TextOptions>\\015\\012              <TextQuality>Wysiwyg</TextQuality>\\015\\012              <Type>Expression</Type>\\015\\012            </Text9>\\015\\012            <Text10 Ref="17" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>13.6,3.8,5.4,0.6</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,12</Font>\\015\\012              <GrowToHeight>True</GrowToHeight>\\015\\012              <Guid>b8f3f238120146579d163963b64329b8</Guid>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>Text10</Name>\\015\\012              <Page isRef="6" />\\015\\012              <Parent isRef="7" />\\015\\012              <Text>{SafeBuyerReceiptDTO.BecAddress.Town}</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <TextOptions>,,,,WordWrap=True,A=0</TextOptions>\\015\\012              <TextQuality>Wysiwyg</TextQuality>\\015\\012              <Type>Expression</Type>\\015\\012            </Text10>\\015\\012            <Text11 Ref="18" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>13.6,4.4,5.4,0.6</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,12</Font>\\015\\012              <GrowToHeight>True</GrowToHeight>\\015\\012              <Guid>5b1953f17aba4a3687de9497fc0f07cf</Guid>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>Text11</Name>\\015\\012              <Page isRef="6" />\\015\\012              <Parent isRef="7" />\\015\\012              <Text>{SafeBuyerReceiptDTO.BecAddress.County}</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <TextOptions>,,,,WordWrap=True,A=0</TextOptions>\\015\\012              <TextQuality>Wysiwyg</TextQuality>\\015\\012              <Type>Expression</Type>\\015\\012            </Text11>\\015\\012            <Text12 Ref="19" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>13.6,5,5.4,0.6</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,12</Font>\\015\\012              <GrowToHeight>True</GrowToHeight>\\015\\012              <Guid>6fff638e4e2a49b5a57c0275daf9f5fc</Guid>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>Text12</Name>\\015\\012              <Page isRef="6" />\\015\\012              <Parent isRef="7" />\\015\\012              <Text>{SafeBuyerReceiptDTO.BecAddress.PostalCode}</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <TextOptions>,,,,WordWrap=True,A=0</TextOptions>\\015\\012              <TextQuality>Wysiwyg</TextQuality>\\015\\012              <Type>Expression</Type>\\015\\012            </Text12>\\015\\012            <Text8 Ref="20" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>13.6,2,5.4,0.6</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,12</Font>\\015\\012              <GrowToHeight>True</GrowToHeight>\\015\\012              <Guid>d93beb8213f14fdda57b92425787247f</Guid>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>Text8</Name>\\015\\012              <Page isRef="6" />\\015\\012              <Parent isRef="7" />\\015\\012              <Text>{SafeBuyerReceiptDTO.CompanyName}</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <TextOptions>,,,,WordWrap=True,A=0</TextOptions>\\015\\012              <TextQuality>Wysiwyg</TextQuality>\\015\\012              <Type>Expression</Type>\\015\\012            </Text8>\\015\\012            <Text13 Ref="21" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>13.6,5.6,5.4,0.6</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,12</Font>\\015\\012              <GrowToHeight>True</GrowToHeight>\\015\\012              <Guid>2c160a88c5904d88977edb3b0e954c75</Guid>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>Text13</Name>\\015\\012              <Page isRef="6" />\\015\\012              <Parent isRef="7" />\\015\\012              <Text>{SafeBuyerReceiptDTO.VatNumber}</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <TextOptions>,,,,WordWrap=True,A=0</TextOptions>\\015\\012              <TextQuality>Wysiwyg</TextQuality>\\015\\012              <Type>Expression</Type>\\015\\012            </Text13>\\015\\012            <Text16 Ref="22" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>3.6,7.8,5.4,0.6</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,12</Font>\\015\\012              <GrowToHeight>True</GrowToHeight>\\015\\012              <Guid>ec48817152564b2dab486393a83f7496</Guid>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>Text16</Name>\\015\\012              <Page isRef="6" />\\015\\012              <Parent isRef="7" />\\015\\012              <Text>{SafeBuyerReceiptDTO.InvoiceDate}</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <TextOptions>,,,,WordWrap=True,A=0</TextOptions>\\015\\012              <TextQuality>Wysiwyg</TextQuality>\\015\\012              <Type>Expression</Type>\\015\\012            </Text16>\\015\\012            <Text17 Ref="23" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>0,7.8,3.4,0.6</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,12</Font>\\015\\012              <Guid>5e4cce6b0bab43a1bbca2cc92b24055b</Guid>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>Text17</Name>\\015\\012              <Page isRef="6" />\\015\\012              <Parent isRef="7" />\\015\\012              <Text>Date:</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <Type>Expression</Type>\\015\\012            </Text17>\\015\\012          </Components>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Name>ReportTitle</Name>\\015\\012          <Page isRef="6" />\\015\\012          <Parent isRef="6" />\\015\\012        </ReportTitle>\\015\\012        <Header Ref="24" type="HeaderBand" isKey="true">\\015\\012          <Border>Bottom;[127:127:127];1;Solid;False;4;Black</Border>\\015\\012          <Brush>Transparent</Brush>\\015\\012          <ClientRectangle>0,10.4,19,0.8</ClientRectangle>\\015\\012          <Components isList="true" count="3">\\015\\012            <Text18 Ref="25" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>0,0,2,0.6</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,12</Font>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>Text18</Name>\\015\\012              <Page isRef="6" />\\015\\012              <Parent isRef="24" />\\015\\012              <Text>Quantity</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <Type>Expression</Type>\\015\\012            </Text18>\\015\\012            <Text19 Ref="26" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>2.2,0,2.4,0.6</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,12</Font>\\015\\012              <Guid>e76dcf959c9b4255b349d477ac956771</Guid>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>Text19</Name>\\015\\012              <Page isRef="6" />\\015\\012              <Parent isRef="24" />\\015\\012              <Text>Description</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <Type>Expression</Type>\\015\\012            </Text19>\\015\\012            <Text20 Ref="27" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>16.8,0,2.2,0.6</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,12</Font>\\015\\012              <Guid>b2c1375e1023441ba20c10ebcad8c481</Guid>\\015\\012              <HorAlignment>Right</HorAlignment>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>Text20</Name>\\015\\012              <Page isRef="6" />\\015\\012              <Parent isRef="24" />\\015\\012              <Text>Price</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <Type>Expression</Type>\\015\\012            </Text20>\\015\\012          </Components>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Name>Header</Name>\\015\\012          <Page isRef="6" />\\015\\012          <Parent isRef="6" />\\015\\012        </Header>\\015\\012        <Data Ref="28" type="DataBand" isKey="true">\\015\\012          <Border>Bottom;[127:127:127];1;Solid;False;4;Black</Border>\\015\\012          <Brush>Transparent</Brush>\\015\\012          <BusinessObjectGuid>7ca8ab0073244b60ba07a06527196f83</BusinessObjectGuid>\\015\\012          <CanGrow>False</CanGrow>\\015\\012          <ClientRectangle>0,12,19,1</ClientRectangle>\\015\\012          <Components isList="true" count="3">\\015\\012            <DataText1 Ref="29" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>0,0.2,2,0.6</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,12</Font>\\015\\012              <GrowToHeight>True</GrowToHeight>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>DataText1</Name>\\015\\012              <Page isRef="6" />\\015\\012              <Parent isRef="28" />\\015\\012              <Text>{SafeBuyerReceiptDTO.Items.Quantity}</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <TextOptions>,,,,WordWrap=True,A=0</TextOptions>\\015\\012              <TextQuality>Wysiwyg</TextQuality>\\015\\012              <Type>Expression</Type>\\015\\012            </DataText1>\\015\\012            <Text23 Ref="30" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>2.2,0.2,8.4,0.6</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,12</Font>\\015\\012              <GrowToHeight>True</GrowToHeight>\\015\\012              <Guid>62d72f2aee81485ba9d0dcec3a21335a</Guid>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>Text23</Name>\\015\\012              <Page isRef="6" />\\015\\012              <Parent isRef="28" />\\015\\012              <Text>{SafeBuyerReceiptDTO.Items.Description}</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <TextOptions>,,,,WordWrap=True,A=0</TextOptions>\\015\\012              <TextQuality>Wysiwyg</TextQuality>\\015\\012              <Type>Expression</Type>\\015\\012            </Text23>\\015\\012            <Text24 Ref="31" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>16.8,0.2,2.2,0.6</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,12</Font>\\015\\012              <GrowToHeight>True</GrowToHeight>\\015\\012              <Guid>97f2124cc4fe4298807e90696c4389d6</Guid>\\015\\012              <HorAlignment>Right</HorAlignment>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>Text24</Name>\\015\\012              <Page isRef="6" />\\015\\012              <Parent isRef="28" />\\015\\012              <Text>{SafeBuyerReceiptDTO.Items.Goods}</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <TextFormat Ref="32" type="CurrencyFormat" isKey="true">\\015\\012                <GroupSeparator>,</GroupSeparator>\\015\\012                <NegativePattern>1</NegativePattern>\\015\\012                <PositivePattern>0</PositivePattern>\\015\\012                <Symbol>\\302\\243</Symbol>\\015\\012              </TextFormat>\\015\\012              <TextOptions>,,,,WordWrap=True,A=0</TextOptions>\\015\\012              <TextQuality>Wysiwyg</TextQuality>\\015\\012              <Type>Expression</Type>\\015\\012            </Text24>\\015\\012          </Components>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <DataRelationName isNull="true" />\\015\\012          <DataSourceName isNull="true" />\\015\\012          <Filters isList="true" count="0" />\\015\\012          <Name>Data</Name>\\015\\012          <Page isRef="6" />\\015\\012          <Parent isRef="6" />\\015\\012          <Sort isList="true" count="0" />\\015\\012        </Data>\\015\\012        <Footer Ref="33" type="FooterBand" isKey="true">\\015\\012          <Brush>Transparent</Brush>\\015\\012          <CanGrow>False</CanGrow>\\015\\012          <ClientRectangle>0,13.8,19,4.2</ClientRectangle>\\015\\012          <Components isList="true" count="6">\\015\\012            <Text31 Ref="34" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>16.8,1.2,2.2,0.6</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,12</Font>\\015\\012              <GrowToHeight>True</GrowToHeight>\\015\\012              <Guid>f298583c0ad742da9c2cffaa05082f4b</Guid>\\015\\012              <HorAlignment>Right</HorAlignment>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>Text31</Name>\\015\\012              <Page isRef="6" />\\015\\012              <Parent isRef="33" />\\015\\012              <Text>{SafeBuyerReceiptDTO.Goods}</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <TextFormat Ref="35" type="CurrencyFormat" isKey="true">\\015\\012                <GroupSeparator>,</GroupSeparator>\\015\\012                <NegativePattern>1</NegativePattern>\\015\\012                <PositivePattern>0</PositivePattern>\\015\\012                <Symbol>\\302\\243</Symbol>\\015\\012              </TextFormat>\\015\\012              <TextOptions>,,,,WordWrap=True,A=0</TextOptions>\\015\\012              <TextQuality>Wysiwyg</TextQuality>\\015\\012              <Type>Expression</Type>\\015\\012            </Text31>\\015\\012            <Text27 Ref="36" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>16.8,2.8,2.2,0.6</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,12</Font>\\015\\012              <GrowToHeight>True</GrowToHeight>\\015\\012              <Guid>12eb986e603a46ee9690dc3ee809edca</Guid>\\015\\012              <HorAlignment>Right</HorAlignment>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>Text27</Name>\\015\\012              <Page isRef="6" />\\015\\012              <Parent isRef="33" />\\015\\012              <Text>{SafeBuyerReceiptDTO.Total}</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <TextFormat Ref="37" type="CurrencyFormat" isKey="true">\\015\\012                <GroupSeparator>,</GroupSeparator>\\015\\012                <NegativePattern>1</NegativePattern>\\015\\012                <PositivePattern>0</PositivePattern>\\015\\012                <Symbol>\\302\\243</Symbol>\\015\\012              </TextFormat>\\015\\012              <TextOptions>,,,,WordWrap=True,A=0</TextOptions>\\015\\012              <TextQuality>Wysiwyg</TextQuality>\\015\\012              <Type>Expression</Type>\\015\\012            </Text27>\\015\\012            <Text28 Ref="38" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>14.2,2.8,2.4,0.6</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,12</Font>\\015\\012              <Guid>5e3b9e7febfd4d87a74fcb543ddecf60</Guid>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>Text28</Name>\\015\\012              <Page isRef="6" />\\015\\012              <Parent isRef="33" />\\015\\012              <Text>Total Paid</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <Type>Expression</Type>\\015\\012            </Text28>\\015\\012            <Text29 Ref="39" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>16.8,2,2.2,0.6</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,12</Font>\\015\\012              <GrowToHeight>True</GrowToHeight>\\015\\012              <Guid>2c063ffa0a394323acf483b0b90b243e</Guid>\\015\\012              <HorAlignment>Right</HorAlignment>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>Text29</Name>\\015\\012              <Page isRef="6" />\\015\\012              <Parent isRef="33" />\\015\\012              <Text>{SafeBuyerReceiptDTO.Vat}</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <TextFormat Ref="40" type="CurrencyFormat" isKey="true">\\015\\012                <GroupSeparator>,</GroupSeparator>\\015\\012                <NegativePattern>1</NegativePattern>\\015\\012                <PositivePattern>0</PositivePattern>\\015\\012                <Symbol>\\302\\243</Symbol>\\015\\012              </TextFormat>\\015\\012              <TextOptions>,,,,WordWrap=True,A=0</TextOptions>\\015\\012              <TextQuality>Wysiwyg</TextQuality>\\015\\012              <Type>Expression</Type>\\015\\012            </Text29>\\015\\012            <Text30 Ref="41" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>14.2,2,2.4,0.6</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,12</Font>\\015\\012              <Guid>3cd468e676754affab67423b19414f33</Guid>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>Text30</Name>\\015\\012              <Page isRef="6" />\\015\\012              <Parent isRef="33" />\\015\\012              <Text>Total VAT</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <Type>Expression</Type>\\015\\012            </Text30>\\015\\012            <Text32 Ref="42" type="Text" isKey="true">\\015\\012              <Brush>Transparent</Brush>\\015\\012              <ClientRectangle>14.2,1.2,2.4,0.6</ClientRectangle>\\015\\012              <Conditions isList="true" count="0" />\\015\\012              <Font>Arial,12</Font>\\015\\012              <Guid>459b1fb0ec6e48b392647918a1c368b5</Guid>\\015\\012              <Margins>0,0,0,0</Margins>\\015\\012              <Name>Text32</Name>\\015\\012              <Page isRef="6" />\\015\\012              <Parent isRef="33" />\\015\\012              <Text>Total Goods</Text>\\015\\012              <TextBrush>Black</TextBrush>\\015\\012              <Type>Expression</Type>\\015\\012            </Text32>\\015\\012          </Components>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Name>Footer</Name>\\015\\012          <Page isRef="6" />\\015\\012          <Parent isRef="6" />\\015\\012        </Footer>\\015\\012      </Components>\\015\\012      <Conditions isList="true" count="0" />\\015\\012      <Guid>2497c05ec1ac4704ac58263512508d10</Guid>\\015\\012      <Margins>1,1,1,1</Margins>\\015\\012      <Name>Page1</Name>\\015\\012      <PageHeight>29.7</PageHeight>\\015\\012      <PageWidth>21</PageWidth>\\015\\012      <Report isRef="0" />\\015\\012      <Watermark Ref="43" type="Stimulsoft.Report.Components.StiWatermark" isKey="true">\\015\\012        <Font>Arial,100</Font>\\015\\012        <TextBrush>[50:0:0:0]</TextBrush>\\015\\012      </Watermark>\\015\\012    </Page1>\\015\\012  </Pages>\\015\\012  <PrinterSettings Ref="44" type="Stimulsoft.Report.Print.StiPrinterSettings" isKey="true" />\\015\\012  <ReferencedAssemblies isList="true" count="8">\\015\\012    <value>System.Dll</value>\\015\\012    <value>System.Drawing.Dll</value>\\015\\012    <value>System.Windows.Forms.Dll</value>\\015\\012    <value>System.Data.Dll</value>\\015\\012    <value>System.Xml.Dll</value>\\015\\012    <value>Stimulsoft.Controls.Dll</value>\\015\\012    <value>Stimulsoft.Base.Dll</value>\\015\\012    <value>Stimulsoft.Report.Dll</value>\\015\\012  </ReferencedAssemblies>\\015\\012  <ReportAlias>Report</ReportAlias>\\015\\012  <ReportChanged>3/17/2016 3:47:57 PM</ReportChanged>\\015\\012  <ReportCreated>3/15/2016 3:12:47 PM</ReportCreated>\\015\\012  <ReportFile>C:\\134reports\\134Invoice.mrt</ReportFile>\\015\\012  <ReportGuid>21d7f0849e344155a62481c413888b20</ReportGuid>\\015\\012  <ReportName>Report</ReportName>\\015\\012  <ReportUnit>Centimeters</ReportUnit>\\015\\012  <ReportVersion>2015.1.8</ReportVersion>\\015\\012  <Script>using System;\\015\\012using System.Drawing;\\015\\012using System.Windows.Forms;\\015\\012using System.Data;\\015\\012using Stimulsoft.Controls;\\015\\012using Stimulsoft.Base.Drawing;\\015\\012using Stimulsoft.Report;\\015\\012using Stimulsoft.Report.Dialogs;\\015\\012using Stimulsoft.Report.Components;\\015\\012\\015\\012namespace Reports\\015\\012{\\015\\012    public class Report : Stimulsoft.Report.StiReport\\015\\012    {\\015\\012        public Report()        {\\015\\012            this.InitializeComponent();\\015\\012        }\\015\\012\\015\\012        #region StiReport Designer generated code - do not modify\\015\\012\\011\\011#endregion StiReport Designer generated code - do not modify\\015\\012    }\\015\\012}\\015\\012</Script>\\015\\012  <ScriptLanguage>CSharp</ScriptLanguage>\\015\\012  <Styles isList="true" count="0" />\\015\\012</StiSerializer>',
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
  '4fb339f0-489f-11e4-a2d3-ef22111148be',
  'SafeBuyerReceipt',
  'SafeBuyerReceipt Resource',
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
  '4fb339f0-489f-11e4-a2d3-ef22e59948be',
  1,
  null,
  '4fb339f0-489f-11e4-a2d3-ef22111148be',
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1),
  null,
  null,
  true,
  false,
  null
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
  '4fb339f0-489f-11e4-a2d3-ef22e59948be',
  1,
  'SafeBuyerReceiptDTO',
  'Bec.TargetFramework.Entities.SafeBuyerReceiptDTO, Bec.TargetFramework.Entities',
  'SafeBuyerReceiptDTO',
  'Bec.TargetFramework.Entities',
  'Bec.TargetFramework.Entities',
  true,
  true,
  false,
  true,
  'General'
);

DO $$
BEGIN
	PERFORM "fn_PromoteNotificationConstructTemplate"('4fb339f0-489f-11e4-a2d3-ef22e59948be', 1);
END $$;


INSERT INTO legal."LegalOrganisationDetails" ("OrganisationID", "IsVATRegistered", "VATNumber")
VALUES (E'dc13c5b0-611a-11e5-9f66-00155d0a1426', True, E'924813717');

DO $$

declare orgID uuid;
declare addressID uuid;
declare contactID uuid;
begin

contactID := (select uuid_generate_v1());
addressID := (select uuid_generate_v1());
orgID := (select "OrganisationID" from "Organisation" where "OrganisationTypeID" = 30);

insert into "Contact" ("ContactID", "ParentID", "ContactName") values (contactID, orgID, '');

insert into "Address" ("AddressID", "ParentID", "Name", "AddressTypeID", "Line1", "Line2", "Town", "County", "PostalCode")
values (addressID, contactID, '', 4974, 'Marlesfield House', '114 - 116 Main Road', 'Sidcup', 'Kent', 'DA14 6NG');

END $$;

 -- object recreation
DROP VIEW public."vOrganisationDetail";

CREATE VIEW public."vOrganisationDetail"(
    "OrganisationID",
    "OrganisationName",
    "OrganisationTypeID",
    "OrganisationSubTypeID",
    "OrganisationCategoryID",
    "IsBranch",
    "IsHeadOffice",
    "IsActive",
    "IsDeleted",
    "IsUserOrganisation",
    "CreatedOn",
    "CreatedBy",
    "ModifiedOn",
    "ModifiedBy",
    "OrganisationSubCategoryID",
    "DefaultOrganisationID",
    "DefaultOrganisationVersionNumber",
    "ParentID",
    "ParentOrganisationID",
    "IsPaymentProvider",
    "ContactID",
    "ContactName",
    "MasterContactID",
    "OwnerID",
    "CustomerTypeID",
    "PreferredContactMethodID",
    "IsBackOfficeCustomer",
    "Salutation",
    "JobTitle",
    "FirstName",
    "Department",
    "NickName",
    "MiddleName",
    "LastName",
    "BirthDate",
    "Description",
    "GenderTypeID",
    "HasChildren",
    "EducationTypeID",
    "WebSiteURL",
    "EmailAddress1",
    "EmailAddress2",
    "EmailAddress3",
    "AssistantName",
    "AssistantPhone",
    "ManagerName",
    "ManagerPhone",
    "CountryTypeID",
    "DoNotFax",
    "DoNotEmail",
    "DoNotTelephone",
    "IsPrivate",
    "Telephone1",
    "Telephone2",
    "Telephone3",
    "Fax",
    "MobileNumber1",
    "MobileNumber2",
    "MobileNumber3",
    "OrganisationUnitID",
    "ParentContactID",
    "IsPrimaryContact",
    "ContactTypeID",
    "ContactSubTypeID",
    "ContactCategoryID",
    "FirmName",
    "AddressID",
    "Name",
    "PrimaryContactName",
    "Line1",
    "Line2",
    "Line3",
    "City",
    "StateOrProvince",
    "County",
    "Country",
    "PostOfficeBox",
    "PostalCode",
    "UTCOffSet",
    "Latitude",
    "Longitude",
    "AddressTypeID",
    "AddressNumber",
    "IsPrimaryAddress",
    "AddressCategoryID",
    "AddressSubTypeID",
    "BuildingName",
    "Order",
    "CountryCode",
    "AdditionalAddressInformation",
    "Town",
    "IsVATRegistered",
    "VATNumber",
    "IsCompanyHouseRegistered",
    "RegisteredCompanyNumber",
    "PartnersCount",
    "RegisteredPractitionersCount",
    "StaffCount",
    "MonthlyCompletionsCount")
AS
  SELECT org."OrganisationID",
	     od."Name",
         org."OrganisationTypeID",
         org."OrganisationSubTypeID",
         org."OrganisationCategoryID",
         org."IsBranch",
         org."IsHeadOffice",
         org."IsActive",
         org."IsDeleted",
         org."IsUserOrganisation",
         org."CreatedOn",
         org."CreatedBy",
         org."ModifiedOn",
         org."ModifiedBy",
         org."OrganisationSubCategoryID",
         org."DefaultOrganisationID",
         org."DefaultOrganisationVersionNumber",
         org."ParentID",
         org."ParentOrganisationID",
         org."IsPaymentProvider",
         ct."ContactID",
         ct."ContactName",
         ct."MasterContactID",
         ct."OwnerID",
         ct."CustomerTypeID",
         ct."PreferredContactMethodID",
         ct."IsBackOfficeCustomer",
         ct."Salutation",
         ct."JobTitle",
         ct."FirstName",
         ct."Department",
         ct."NickName",
         ct."MiddleName",
         ct."LastName",
         ct."BirthDate",
         ct."Description",
         ct."GenderTypeID",
         ct."HasChildren",
         ct."EducationTypeID",
         ct."WebSiteURL",
         ct."EmailAddress1",
         ct."EmailAddress2",
         ct."EmailAddress3",
         ct."AssistantName",
         ct."AssistantPhone",
         ct."ManagerName",
         ct."ManagerPhone",
         ct."CountryTypeID",
         ct."DoNotFax",
         ct."DoNotEmail",
         ct."DoNotTelephone",
         ct."IsPrivate",
         ct."Telephone1",
         ct."Telephone2",
         ct."Telephone3",
         ct."Fax",
         ct."MobileNumber1",
         ct."MobileNumber2",
         ct."MobileNumber3",
         ct."OrganisationUnitID",
         ct."ParentContactID",
         ct."IsPrimaryContact",
         ct."ContactTypeID",
         ct."ContactSubTypeID",
         ct."ContactCategoryID",
         ct."FirmName",
         add . "AddressID",
         add . "Name",
         add . "PrimaryContactName",
         add . "Line1",
         add . "Line2",
         add . "Line3",
         add . "City",
         add . "StateOrProvince",
         add . "County",
         add . "Country",
         add . "PostOfficeBox",
         add . "PostalCode",
         add . "UTCOffSet",
         add . "Latitude",
         add . "Longitude",
         add . "AddressTypeID",
         add . "AddressNumber",
         add . "IsPrimaryAddress",
         add . "AddressCategoryID",
         add . "AddressSubTypeID",
         add . "BuildingName",
         add . "Order",
         add . "CountryCode",
         add . "AdditionalAddressInformation",
         add . "Town",
         lod."IsVATRegistered",
         lod."VATNumber",
         lod."IsCompanyHouseRegistered",
         lod."RegisteredCompanyNumber",
         lod."PartnersCount",
         lod."RegisteredPractitionersCount",
         lod."StaffCount",
         lod."MonthlyCompletionsCount"
  FROM "Organisation" org
       JOIN "OrganisationDetail" od ON od."OrganisationID" =
         org."OrganisationID"
       JOIN "Contact" ct ON ct."ParentID" = org."OrganisationID"
       JOIN "Address" add ON add . "ParentID" = ct."ContactID"
       LEFT JOIN legal."LegalOrganisationDetails" lod ON lod."OrganisationID" =
         org."OrganisationID";

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."vOrganisationDetail" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."vOrganisationDetail" TO bef;