INSERT INTO public."ClassificationTypeCategory" ("ClassificationTypeCategoryID", "Name", "IsActive", "IsDeleted")
VALUES (2081, E'ActivityTypeID', True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (803001, E'SmsTransaction', NULL, 2081, NULL, True, False);

CREATE TABLE public."Conversation" (
  "ConversationID" UUID NOT NULL,
  "Subject" VARCHAR,
  "ActivityType" INTEGER,
  "ActivityID" UUID,
  "IsSystemMessage" BOOLEAN DEFAULT false NOT NULL,
  "Latest" TIMESTAMP WITH TIME ZONE DEFAULT now() NOT NULL,
  CONSTRAINT "Conversation_pkey" PRIMARY KEY("ConversationID")
) 
WITH (oids = false);

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."Conversation" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."Conversation" TO bef;

ALTER TABLE public."Conversation"
  ALTER COLUMN "ConversationID" SET STATISTICS 0;

ALTER TABLE public."Conversation"
  ALTER COLUMN "ActivityType" SET STATISTICS 0;

ALTER TABLE public."Conversation"
  ALTER COLUMN "ActivityID" SET STATISTICS 0;

CREATE INDEX "Conversation_idx_Activity" ON public."Conversation"
  USING btree ("ActivityType", "ActivityID");
  

CREATE TABLE public."ConversationParticipant" (
  "ConversationID" UUID NOT NULL,
  "UserAccountOrganisationID" UUID NOT NULL,
  "Added" TIMESTAMP WITH TIME ZONE DEFAULT now() NOT NULL,
  CONSTRAINT "ConversationParticipant_pk" PRIMARY KEY("UserAccountOrganisationID", "ConversationID"),
  CONSTRAINT "fk_ConversationParticipant_Conversation" FOREIGN KEY ("ConversationID")
    REFERENCES public."Conversation"("ConversationID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE,
  CONSTRAINT "fk_ConversationParticipant_UserAccountOrganisation" FOREIGN KEY ("UserAccountOrganisationID")
    REFERENCES public."UserAccountOrganisation"("UserAccountOrganisationID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE
) 
WITH (oids = false);

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."ConversationParticipant" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."ConversationParticipant" TO bef;

ALTER TABLE public."ConversationParticipant"
  ALTER COLUMN "ConversationID" SET STATISTICS 0;

ALTER TABLE public."ConversationParticipant"
  ALTER COLUMN "UserAccountOrganisationID" SET STATISTICS 0;



ALTER TABLE public."Notification" ADD COLUMN "ConversationID" UUID;
ALTER TABLE public."Notification"
  ADD CONSTRAINT "fk_Notification_Conversation" FOREIGN KEY ("ConversationID")
    REFERENCES public."Conversation"("ConversationID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;

ALTER TABLE public."Notification" ADD COLUMN "CreatedByUserAccountOrganisationID" UUID;
ALTER TABLE public."Notification"
  ADD CONSTRAINT "fk_Notification_CreatedByUserAccountOrganisation" FOREIGN KEY ("CreatedByUserAccountOrganisationID")
    REFERENCES public."UserAccountOrganisation"("UserAccountOrganisationID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;


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
  '4fb339f0-489f-11e4-a2d3-ef22e599ffbb',
  1,
  'Message',
  'Message',
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
  '4fb339f0-489f-11e4-a2d3-ef22e599ffbb',
  1,
  null,
  true,
  false,
  CURRENT_DATE,
  false,
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
  '4fb24f2c-489f-11e4-be44-93993f001111',
  'Message',
  'Message Resource',
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
  '4fb339f0-489f-11e4-a2d3-ef22e599ffbb',
  1,
  null,
  '4fb24f2c-489f-11e4-be44-93993f001111',
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1),
  null,
  null,
  true,
  false,
  null
);


DO $$
BEGIN
	PERFORM "fn_PromoteNotificationConstructTemplate"('4fb339f0-489f-11e4-a2d3-ef22e599ffbb', 1);
END $$;


CREATE OR REPLACE VIEW public."vConversation"(
    "ConversationID",
    "UserAccountOrganisationID",
    "Subject",
    "Latest",
    "ActivityID",
    "ActivityType",
    "IsSystemMessage")
AS
  SELECT cp."ConversationID",
         cp."UserAccountOrganisationID",
         c."Subject",
         c."Latest",
         c."ActivityID",
         c."ActivityType",
         c."IsSystemMessage"
  FROM "ConversationParticipant" cp
       JOIN "Conversation" c ON c."ConversationID" = cp."ConversationID";

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."vConversation" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."vConversation" TO bef;


CREATE OR REPLACE VIEW public."vMessage"(
    "ConversationID",
    "NotificationID",
    "CreatedByUserAccountOrganisationID",
    "DateSent",
    "NotificationData",
    "Email",
    "FirstName",
    "LastName",
    "OrganisationName",
    "UserType",
    "OrganisationType",
    "NotificationConstructName")
AS
SELECT n."ConversationID",
    n."NotificationID",
    n."CreatedByUserAccountOrganisationID",
    n."DateSent",
    n."NotificationData",
    ua."Email",
    c."FirstName",
    c."LastName",
    orgd."Name" AS "OrganisationName",
        CASE
            WHEN ct."Name"::text = 'SmsTransaction'::text THEN
            CASE
                WHEN ot."Name"::text = 'Personal'::text THEN txt."Description"
                WHEN ot."Name"::text = 'Professional'::text THEN
                    'Conveyancer'::character varying
                ELSE NULL::character varying
            END
            ELSE NULL::character varying
        END AS "UserType",
    ot."Name" AS "OrganisationType",
    nc."Name" AS "NotificationConstructName"
FROM "Notification" n
     JOIN "Conversation" conv ON conv."ConversationID" = n."ConversationID"
     JOIN "NotificationConstruct" nc ON nc."NotificationConstructID" =
         n."NotificationConstructID" AND nc."NotificationConstructVersionNumber" = n."NotificationConstructVersionNumber"
     LEFT JOIN "UserAccountOrganisation" uao ON uao."UserAccountOrganisationID"
         = n."CreatedByUserAccountOrganisationID"
     LEFT JOIN "UserAccounts" ua ON ua."ID" = uao."UserID"
     LEFT JOIN "Organisation" org ON org."OrganisationID" = uao."OrganisationID"
     LEFT JOIN "OrganisationDetail" orgd ON orgd."OrganisationID" = org."OrganisationID"
     LEFT JOIN "OrganisationType" ot ON ot."OrganisationTypeID" =
         org."OrganisationTypeID"
     LEFT JOIN "Contact" c ON c."ContactID" = uao."PrimaryContactID"
     JOIN "ClassificationTypeCategory" ctc ON ctc."Name"::text = 'ActivityTypeID'::text
     LEFT JOIN "ClassificationType" ct ON ct."ClassificationTypeCategoryID" =
         ctc."ClassificationTypeCategoryID" AND ct."ClassificationTypeID" = conv."ActivityType"
     LEFT JOIN sms."SmsUserAccountOrganisationTransaction" tx ON
         tx."SmsTransactionID" = conv."ActivityID" AND tx."UserAccountOrganisationID" = n."CreatedByUserAccountOrganisationID"
     LEFT JOIN sms."SmsUserAccountOrganisationTransactionType" txt ON
         txt."SmsUserAccountOrganisationTransactionTypeID" = tx."SmsUserAccountOrganisationTransactionTypeID";

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."vMessage" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."vMessage" TO bef;

CREATE OR REPLACE VIEW public."vMessageRead"(
    "ConversationID",
    "NotificationID",
    "UserAccountOrganisationID",
    "IsAccepted",
    "AcceptedDate",
    "Email",
    "FirstName",
    "LastName")
AS
  SELECT n."ConversationID",
         nr."NotificationID",
         nr."UserAccountOrganisationID",
         nr."IsAccepted",
         nr."AcceptedDate",
         ua."Email",
         c."FirstName",
         c."LastName"
  FROM "NotificationRecipient" nr
       JOIN "Notification" n ON n."NotificationID" = nr."NotificationID"
       JOIN "UserAccountOrganisation" uao ON uao."UserAccountOrganisationID" =
         nr."UserAccountOrganisationID"
       JOIN "UserAccounts" ua ON ua."ID" = uao."UserID"
       JOIN "Contact" c ON c."ContactID" = uao."PrimaryContactID"
  WHERE nr."IsAccepted" = true;

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."vMessageRead" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."vMessageRead" TO bef;



CREATE OR REPLACE FUNCTION public."fn_ConversationRank" (
  uaoid uuid,
  convid uuid
)
RETURNS integer AS
$body$
declare 
ret integer;
BEGIN
 ret = (select "Row" from (
  SELECT cp."ConversationID", cp."UserAccountOrganisationID", row_number() over (order by c."Latest" desc) as "Row"
  FROM "ConversationParticipant" cp
       JOIN "Conversation" c ON c."ConversationID" = cp."ConversationID"
       where cp."UserAccountOrganisationID" = uaoid
    ) t 
  where t."ConversationID" = convid
  limit 1
  );
  return ret;
END;
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER
COST 100;

GRANT EXECUTE
  ON FUNCTION public."fn_ConversationRank"(uaoid uuid, convid uuid) TO postgres;
GRANT EXECUTE
  ON FUNCTION public."fn_ConversationRank"(uaoid uuid, convid uuid) TO bef;



CREATE OR REPLACE VIEW public."vConversationUnread" (
    "ConversationID",
    "UserAccountOrganisationID",
    "UnreadCount")
AS
SELECT n."ConversationID",
    nr."UserAccountOrganisationID",
    count(nr."NotificationRecipientID") AS "UnreadCount"
FROM "NotificationRecipient" nr
     JOIN "Notification" n ON n."NotificationID" = nr."NotificationID"
WHERE nr."IsAccepted" = false
GROUP BY n."ConversationID", nr."UserAccountOrganisationID";

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."vConversationUnread" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."vConversationUnread" TO bef;


CREATE INDEX "Notification_idx_Conversation" ON public."Notification" USING btree ("ConversationID");
CREATE INDEX "NotificationRecipient_idx_Notification" ON public."NotificationRecipient" USING btree ("NotificationID");
CREATE INDEX "NotificationRecipient_idx_IsAccepted" ON public."NotificationRecipient" USING btree ("IsAccepted");
CREATE INDEX "NotificationRecipient_idx_User" ON public."NotificationRecipient" USING btree ("UserAccountOrganisationID");
CREATE INDEX "ConversationParticipant_idx_Conversation" ON public."ConversationParticipant" USING btree ("ConversationID");
CREATE INDEX "ConversationParticipant_idx_User" ON public."ConversationParticipant" USING btree ("UserAccountOrganisationID");
CREATE INDEX "UserAccountOrganisation_idx_Organisation" ON public."UserAccountOrganisation" USING btree ("OrganisationID");

ALTER TABLE public."NotificationRecipient" ALTER COLUMN "IsAccepted" SET DEFAULT false;
update public."NotificationRecipient" set "IsAccepted" = false where "IsAccepted" is null;
ALTER TABLE public."NotificationRecipient" ALTER COLUMN "IsAccepted" SET NOT NULL;


CREATE OR REPLACE FUNCTION public."fn_GetConversationActivity" (
  orgid uuid,
  activitytype integer,
  activityid uuid,
  l integer,
  o integer
)
RETURNS TABLE (
  "ConversationID" uuid,
  "Subject" varchar,
  "Latest" timestamptz
) AS
$body$
BEGIN
return query
  SELECT c."ConversationID",
         c."Subject",
         c."Latest"
  FROM "Conversation" c

WHERE 
exists (
select * from "ConversationParticipant" cp join "UserAccountOrganisation" uao on cp."UserAccountOrganisationID" = uao."UserAccountOrganisationID"
where uao."OrganisationID" = orgid and cp."ConversationID" = c."ConversationID"
)and 
(c."ActivityType" = activitytype) AND (c."ActivityID" = activityid) AND (c."IsSystemMessage" = false)
order by c."Latest" desc
limit l offset o;

END;
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER
COST 100 ROWS 1000;

GRANT EXECUTE ON FUNCTION public."fn_GetConversationActivity"(orgid uuid, activitytype integer, activityid uuid, l integer, o integer) TO postgres;
GRANT EXECUTE ON FUNCTION public."fn_GetConversationActivity"(orgid uuid, activitytype integer, activityid uuid, l integer, o integer) TO bef;


CREATE OR REPLACE FUNCTION public."fn_GetConversationActivityCount" (
  orgid uuid,
  activitytype integer,
  activityid uuid
)
RETURNS integer AS
$body$
BEGIN
return (
  SELECT count(*)
  FROM "Conversation" c
WHERE 
exists (
select * from "ConversationParticipant" cp join "UserAccountOrganisation" uao on cp."UserAccountOrganisationID" = uao."UserAccountOrganisationID"
where uao."OrganisationID" = orgid and cp."ConversationID" = c."ConversationID"
)and (c."ActivityType" = activitytype) AND (c."ActivityID" = activityid) AND (c."IsSystemMessage" = false));
END;
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER
COST 100;

GRANT EXECUTE ON FUNCTION public."fn_GetConversationActivityCount"(orgid uuid, activitytype integer, activityid uuid) TO postgres;
GRANT EXECUTE ON FUNCTION public."fn_GetConversationActivityCount"(orgid uuid, activitytype integer, activityid uuid) TO bef;





CREATE OR REPLACE VIEW public."vSafeSendRecipient"(
	"SmsTransactionID",
    "UserAccountOrganisationID",
    "OrganisationID",
    "FirstName",
    "LastName",
    "OrganisationName")
AS
  SELECT uaot."SmsTransactionID",
         uao."UserAccountOrganisationID",
         uao."OrganisationID",
         c."FirstName",
         c."LastName",
         NULL::character varying AS "OrganisationName"
  FROM sms."SmsUserAccountOrganisationTransaction" uaot
       JOIN "UserAccountOrganisation" uao ON uaot."UserAccountOrganisationID" =
         uao."UserAccountOrganisationID"
       JOIN "Contact" c ON uao."PrimaryContactID" = c."ContactID"
       JOIN "UserAccounts" ua ON uao."UserID" = ua."ID"
  WHERE 
  	uao."IsActive" = TRUE AND 
	ua."IsActive" = TRUE AND
    ua."IsLoginAllowed" = TRUE AND
    ua."IsTemporaryAccount" = FALSE
  UNION
  SELECT t."SmsTransactionID",
         uao."UserAccountOrganisationID",
         o."OrganisationID",
         c."FirstName",
         c."LastName",
         od."Name" AS "OrganisationName"
  FROM sms."SmsTransaction" t
       JOIN "Organisation" o ON t."OrganisationID" = o."OrganisationID"
       JOIN "OrganisationDetail" od ON o."OrganisationID" = od."OrganisationID"
       JOIN "UserAccountOrganisation" uao ON o."OrganisationID" =
         uao."OrganisationID"
       JOIN "Contact" c ON uao."PrimaryContactID" = c."ContactID"
       JOIN "UserAccounts" ua ON uao."UserID" = ua."ID"
  WHERE 
  	uao."IsActive" = TRUE AND
	ua."IsActive" = TRUE AND
  	ua."IsLoginAllowed" = TRUE AND
    ua."IsTemporaryAccount" = FALSE;

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."vSafeSendRecipient" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."vSafeSendRecipient" TO bef;
  
  
  
  
  
 update "NotificationConstruct" set "NotificationSubject" = 'Bank Account Notification' where "Name" in ('BankAccountMarkedAsFraudSuspicious', 'BankAccountMarkedAsSafe');
update "NotificationConstruct" set "NotificationSubject" = 'Safe Buyer No Match Notification' where "Name" in ('BankAccountCheckNoMatch');

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (803002, E'BankAccount', NULL, 2081, NULL, True, False);

CREATE FUNCTION sms."fn_SmsTransactionRank" (
  orgid uuid,
  txid uuid
)
RETURNS integer AS
$body$
declare 
ret integer;
BEGIN
 ret = (
 select "Row" from (
  SELECT tx."SmsTransactionID", row_number() over (order by tx."CreatedOn" desc) as "Row"
  FROM sms."SmsTransaction" tx where tx."OrganisationID" = orgid
    ) t 
  where t."SmsTransactionID" = txid
  limit 1
  );
  return ret;
END;
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER;
 
 
 
 
 DELETE FROM "UserAccountLoginSessionData"
WHERE "UserAccountID" NOT IN (
 	SELECT ualsd."UserAccountID"
	FROM "UserAccountLoginSessionData" ualsd
	JOIN "UserAccounts" ua ON ualsd."UserAccountID" = ua."ID"
);

DELETE FROM "UserAccountLoginSession"
WHERE "UserSessionID" NOT IN (
 	SELECT uals."UserSessionID"
	FROM "UserAccountLoginSession" uals
	JOIN "UserAccounts" ua ON uals."UserAccountID" = ua."ID"
);

ALTER TABLE public."UserAccountLoginSession"
  ADD CONSTRAINT "UserAccountLoginSession_UserAccounts_fk" FOREIGN KEY ("UserAccountID")
    REFERENCES public."UserAccounts"("ID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;

	
UPDATE "NotificationConstructData" AS ncd
SET "NotificationData" = E'<?xml version="1.0" encoding="utf-8" standalone="yes"?>\\015\\012<StiSerializer version="1.02" type="Net" application="StiReport">\\015\\012  <Dictionary Ref="1" type="Dictionary" isKey="true">\\015\\012    <BusinessObjects isList="true" count="2">\\015\\012      <NotificationSettingDTO Ref="2" type="Stimulsoft.Report.Dictionary.StiBusinessObject" isKey="true">\\015\\012        <Alias>NotificationSettingDTO</Alias>\\015\\012        <BusinessObjects isList="true" count="0" />\\015\\012        <Category>General</Category>\\015\\012        <Columns isList="true" count="11">\\015\\012          <value>ExportFormat,System.Nullable`1[System.Int32]</value>\\015\\012          <value>LoginRoute,System.String</value>\\015\\012          <value>NotificationConstructID,System.Guid</value>\\015\\012          <value>NotificationConstructVersionNumber,System.Int32</value>\\015\\012          <value>NotificationFromEmailAddress,System.String</value>\\015\\012          <value>NotificiationSentFromParentID,System.Guid</value>\\015\\012          <value>ServerLogoImageFileNameWithExtension,System.String</value>\\015\\012          <value>ServerNotificationImageContentURLFolder,System.String</value>\\015\\012          <value>ServerURL,System.String</value>\\015\\012          <value>Subject,System.String</value>\\015\\012          <value>Title,System.String</value>\\015\\012        </Columns>\\015\\012        <Dictionary isRef="1" />\\015\\012        <Guid>1926f055d4144572b36e7a96e6843d70</Guid>\\015\\012        <Name>NotificationSettingDTO</Name>\\015\\012      </NotificationSettingDTO>\\015\\012      <NewInternalMessagesNotificationDTO Ref="3" type="Stimulsoft.Report.Dictionary.StiBusinessObject" isKey="true">\\015\\012        <Alias>NewInternalMessagesNotificationDTO</Alias>\\015\\012        <BusinessObjects isList="true" count="0" />\\015\\012        <Category>General</Category>\\015\\012        <Columns isList="true" count="2">\\015\\012          <value>Count,System.Int32</value>\\015\\012          <value>ProductName,System.String</value>\\015\\012        </Columns>\\015\\012        <Dictionary isRef="1" />\\015\\012        <Guid>9c462515737f4adeb65f3562c03c20d5</Guid>\\015\\012        <Name>NewInternalMessagesNotificationDTO</Name>\\015\\012      </NewInternalMessagesNotificationDTO>\\015\\012    </BusinessObjects>\\015\\012    <Databases isList="true" count="0" />\\015\\012    <DataSources isList="true" count="0" />\\015\\012    <Relations isList="true" count="0" />\\015\\012    <Report isRef="0" />\\015\\012    <Variables isList="true" count="0" />\\015\\012  </Dictionary>\\015\\012  <EngineVersion>EngineV2</EngineVersion>\\015\\012  <GlobalizationStrings isList="true" count="0" />\\015\\012  <MetaTags isList="true" count="0" />\\015\\012  <Pages isList="true" count="1">\\015\\012    <Page1 Ref="4" type="Page" isKey="true">\\015\\012      <Border>None;Black;2;Solid;False;4;Black</Border>\\015\\012      <Brush>Transparent</Brush>\\015\\012      <Components isList="true" count="1">\\015\\012        <Text Ref="5" type="Text" isKey="true">\\015\\012          <AllowHtmlTags>True</AllowHtmlTags>\\015\\012          <AutoWidth>True</AutoWidth>\\015\\012          <Brush>Transparent</Brush>\\015\\012          <CanGrow>True</CanGrow>\\015\\012          <CanShrink>True</CanShrink>\\015\\012          <ClientRectangle>0,0,38,9.4</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Calibri,11.25,Regular,Point,False,0</Font>\\015\\012          <GrowToHeight>True</GrowToHeight>\\015\\012          <Guid>aec152f25a8e4fdbb05d29af446e8573</Guid>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text</Name>\\015\\012          <Page isRef="4" />\\015\\012          <Parent isRef="4" />\\015\\012          <Text>&lt;p&gt;You have a new notification in the {NewInternalMessagesNotificationDTO.ProductName}.&lt;/p&gt;\\015\\012&lt;p&gt;&lt;b&gt;Please log into the Safe Move Scheme secure website portal as described in the Safe Move Scheme Login Security Policy.&lt;/b&gt;&lt;/p&gt;\\015\\012&lt;p&gt;Kind regards,&lt;/p&gt;\\015\\012&lt;p&gt;The {NewInternalMessagesNotificationDTO.ProductName}&lt;/p&gt;</Text>\\015\\012          <TextBrush>Black</TextBrush>\\015\\012          <TextQuality>Wysiwyg</TextQuality>\\015\\012          <Type>Expression</Type>\\015\\012        </Text>\\015\\012      </Components>\\015\\012      <Conditions isList="true" count="0" />\\015\\012      <Guid>3f4c07272ec54ccaae2496d9fb03c747</Guid>\\015\\012      <Margins>1,1,1,1</Margins>\\015\\012      <Name>Page1</Name>\\015\\012      <Orientation>Landscape</Orientation>\\015\\012      <PageHeight>29.7</PageHeight>\\015\\012      <PageWidth>40</PageWidth>\\015\\012      <Report isRef="0" />\\015\\012      <StretchToPrintArea>True</StretchToPrintArea>\\015\\012      <Watermark Ref="6" type="Stimulsoft.Report.Components.StiWatermark" isKey="true">\\015\\012        <Font>Arial,100</Font>\\015\\012        <TextBrush>[50:0:0:0]</TextBrush>\\015\\012      </Watermark>\\015\\012    </Page1>\\015\\012  </Pages>\\015\\012  <PrinterSettings Ref="7" type="Stimulsoft.Report.Print.StiPrinterSettings" isKey="true" />\\015\\012  <ReferencedAssemblies isList="true" count="8">\\015\\012    <value>System.Dll</value>\\015\\012    <value>System.Drawing.Dll</value>\\015\\012    <value>System.Windows.Forms.Dll</value>\\015\\012    <value>System.Data.Dll</value>\\015\\012    <value>System.Xml.Dll</value>\\015\\012    <value>Stimulsoft.Controls.Dll</value>\\015\\012    <value>Stimulsoft.Base.Dll</value>\\015\\012    <value>Stimulsoft.Report.Dll</value>\\015\\012  </ReferencedAssemblies>\\015\\012  <ReportAlias>Report</ReportAlias>\\015\\012  <ReportChanged>10/30/2015 12:06:23 PM</ReportChanged>\\015\\012  <ReportCreated>9/28/2015 10:50:12 AM</ReportCreated>\\015\\012  <ReportFile>AddNewInternalMessagesNotification.mrt</ReportFile>\\015\\012  <ReportGuid>300413c090cc4841b190b03878091ce5</ReportGuid>\\015\\012  <ReportName>Report</ReportName>\\015\\012  <ReportUnit>Centimeters</ReportUnit>\\015\\012  <ReportVersion>2014.3.0</ReportVersion>\\015\\012  <Script>using System;\\015\\012using System.Drawing;\\015\\012using System.Windows.Forms;\\015\\012using System.Data;\\015\\012using Stimulsoft.Controls;\\015\\012using Stimulsoft.Base.Drawing;\\015\\012using Stimulsoft.Report;\\015\\012using Stimulsoft.Report.Dialogs;\\015\\012using Stimulsoft.Report.Components;\\015\\012\\015\\012namespace Reports\\015\\012{\\015\\012    public class Report : Stimulsoft.Report.StiReport\\015\\012    {\\015\\012        public Report()        {\\015\\012            this.InitializeComponent();\\015\\012        }\\015\\012\\015\\012        #region StiReport Designer generated code - do not modify\\015\\012\\011\\011#endregion StiReport Designer generated code - do not modify\\015\\012    }\\015\\012}\\015\\012</Script>\\015\\012  <ScriptLanguage>CSharp</ScriptLanguage>\\015\\012  <Styles isList="true" count="0" />\\015\\012</StiSerializer>'
WHERE EXISTS(
	SELECT * 
    FROM "NotificationConstruct" AS nc
	WHERE ncd."NotificationConstructID" = nc."NotificationConstructID" AND nc."Name" LIKE 'NewInternalMessages');

UPDATE "NotificationConstructDataTemplate" AS ncdt
SET "NotificationData" = E'<?xml version="1.0" encoding="utf-8" standalone="yes"?>\\015\\012<StiSerializer version="1.02" type="Net" application="StiReport">\\015\\012  <Dictionary Ref="1" type="Dictionary" isKey="true">\\015\\012    <BusinessObjects isList="true" count="2">\\015\\012      <NotificationSettingDTO Ref="2" type="Stimulsoft.Report.Dictionary.StiBusinessObject" isKey="true">\\015\\012        <Alias>NotificationSettingDTO</Alias>\\015\\012        <BusinessObjects isList="true" count="0" />\\015\\012        <Category>General</Category>\\015\\012        <Columns isList="true" count="11">\\015\\012          <value>ExportFormat,System.Nullable`1[System.Int32]</value>\\015\\012          <value>LoginRoute,System.String</value>\\015\\012          <value>NotificationConstructID,System.Guid</value>\\015\\012          <value>NotificationConstructVersionNumber,System.Int32</value>\\015\\012          <value>NotificationFromEmailAddress,System.String</value>\\015\\012          <value>NotificiationSentFromParentID,System.Guid</value>\\015\\012          <value>ServerLogoImageFileNameWithExtension,System.String</value>\\015\\012          <value>ServerNotificationImageContentURLFolder,System.String</value>\\015\\012          <value>ServerURL,System.String</value>\\015\\012          <value>Subject,System.String</value>\\015\\012          <value>Title,System.String</value>\\015\\012        </Columns>\\015\\012        <Dictionary isRef="1" />\\015\\012        <Guid>1926f055d4144572b36e7a96e6843d70</Guid>\\015\\012        <Name>NotificationSettingDTO</Name>\\015\\012      </NotificationSettingDTO>\\015\\012      <NewInternalMessagesNotificationDTO Ref="3" type="Stimulsoft.Report.Dictionary.StiBusinessObject" isKey="true">\\015\\012        <Alias>NewInternalMessagesNotificationDTO</Alias>\\015\\012        <BusinessObjects isList="true" count="0" />\\015\\012        <Category>General</Category>\\015\\012        <Columns isList="true" count="2">\\015\\012          <value>Count,System.Int32</value>\\015\\012          <value>ProductName,System.String</value>\\015\\012        </Columns>\\015\\012        <Dictionary isRef="1" />\\015\\012        <Guid>9c462515737f4adeb65f3562c03c20d5</Guid>\\015\\012        <Name>NewInternalMessagesNotificationDTO</Name>\\015\\012      </NewInternalMessagesNotificationDTO>\\015\\012    </BusinessObjects>\\015\\012    <Databases isList="true" count="0" />\\015\\012    <DataSources isList="true" count="0" />\\015\\012    <Relations isList="true" count="0" />\\015\\012    <Report isRef="0" />\\015\\012    <Variables isList="true" count="0" />\\015\\012  </Dictionary>\\015\\012  <EngineVersion>EngineV2</EngineVersion>\\015\\012  <GlobalizationStrings isList="true" count="0" />\\015\\012  <MetaTags isList="true" count="0" />\\015\\012  <Pages isList="true" count="1">\\015\\012    <Page1 Ref="4" type="Page" isKey="true">\\015\\012      <Border>None;Black;2;Solid;False;4;Black</Border>\\015\\012      <Brush>Transparent</Brush>\\015\\012      <Components isList="true" count="1">\\015\\012        <Text Ref="5" type="Text" isKey="true">\\015\\012          <AllowHtmlTags>True</AllowHtmlTags>\\015\\012          <AutoWidth>True</AutoWidth>\\015\\012          <Brush>Transparent</Brush>\\015\\012          <CanGrow>True</CanGrow>\\015\\012          <CanShrink>True</CanShrink>\\015\\012          <ClientRectangle>0,0,38,9.4</ClientRectangle>\\015\\012          <Conditions isList="true" count="0" />\\015\\012          <Font>Calibri,11.25,Regular,Point,False,0</Font>\\015\\012          <GrowToHeight>True</GrowToHeight>\\015\\012          <Guid>aec152f25a8e4fdbb05d29af446e8573</Guid>\\015\\012          <Margins>0,0,0,0</Margins>\\015\\012          <Name>Text</Name>\\015\\012          <Page isRef="4" />\\015\\012          <Parent isRef="4" />\\015\\012          <Text>&lt;p&gt;You have a new notification in the {NewInternalMessagesNotificationDTO.ProductName}.&lt;/p&gt;\\015\\012&lt;p&gt;&lt;b&gt;Please log into the Safe Move Scheme secure website portal as described in the Safe Move Scheme Login Security Policy.&lt;/b&gt;&lt;/p&gt;\\015\\012&lt;p&gt;Kind regards,&lt;/p&gt;\\015\\012&lt;p&gt;The {NewInternalMessagesNotificationDTO.ProductName}&lt;/p&gt;</Text>\\015\\012          <TextBrush>Black</TextBrush>\\015\\012          <TextQuality>Wysiwyg</TextQuality>\\015\\012          <Type>Expression</Type>\\015\\012        </Text>\\015\\012      </Components>\\015\\012      <Conditions isList="true" count="0" />\\015\\012      <Guid>3f4c07272ec54ccaae2496d9fb03c747</Guid>\\015\\012      <Margins>1,1,1,1</Margins>\\015\\012      <Name>Page1</Name>\\015\\012      <Orientation>Landscape</Orientation>\\015\\012      <PageHeight>29.7</PageHeight>\\015\\012      <PageWidth>40</PageWidth>\\015\\012      <Report isRef="0" />\\015\\012      <StretchToPrintArea>True</StretchToPrintArea>\\015\\012      <Watermark Ref="6" type="Stimulsoft.Report.Components.StiWatermark" isKey="true">\\015\\012        <Font>Arial,100</Font>\\015\\012        <TextBrush>[50:0:0:0]</TextBrush>\\015\\012      </Watermark>\\015\\012    </Page1>\\015\\012  </Pages>\\015\\012  <PrinterSettings Ref="7" type="Stimulsoft.Report.Print.StiPrinterSettings" isKey="true" />\\015\\012  <ReferencedAssemblies isList="true" count="8">\\015\\012    <value>System.Dll</value>\\015\\012    <value>System.Drawing.Dll</value>\\015\\012    <value>System.Windows.Forms.Dll</value>\\015\\012    <value>System.Data.Dll</value>\\015\\012    <value>System.Xml.Dll</value>\\015\\012    <value>Stimulsoft.Controls.Dll</value>\\015\\012    <value>Stimulsoft.Base.Dll</value>\\015\\012    <value>Stimulsoft.Report.Dll</value>\\015\\012  </ReferencedAssemblies>\\015\\012  <ReportAlias>Report</ReportAlias>\\015\\012  <ReportChanged>10/30/2015 12:06:23 PM</ReportChanged>\\015\\012  <ReportCreated>9/28/2015 10:50:12 AM</ReportCreated>\\015\\012  <ReportFile>AddNewInternalMessagesNotification.mrt</ReportFile>\\015\\012  <ReportGuid>300413c090cc4841b190b03878091ce5</ReportGuid>\\015\\012  <ReportName>Report</ReportName>\\015\\012  <ReportUnit>Centimeters</ReportUnit>\\015\\012  <ReportVersion>2014.3.0</ReportVersion>\\015\\012  <Script>using System;\\015\\012using System.Drawing;\\015\\012using System.Windows.Forms;\\015\\012using System.Data;\\015\\012using Stimulsoft.Controls;\\015\\012using Stimulsoft.Base.Drawing;\\015\\012using Stimulsoft.Report;\\015\\012using Stimulsoft.Report.Dialogs;\\015\\012using Stimulsoft.Report.Components;\\015\\012\\015\\012namespace Reports\\015\\012{\\015\\012    public class Report : Stimulsoft.Report.StiReport\\015\\012    {\\015\\012        public Report()        {\\015\\012            this.InitializeComponent();\\015\\012        }\\015\\012\\015\\012        #region StiReport Designer generated code - do not modify\\015\\012\\011\\011#endregion StiReport Designer generated code - do not modify\\015\\012    }\\015\\012}\\015\\012</Script>\\015\\012  <ScriptLanguage>CSharp</ScriptLanguage>\\015\\012  <Styles isList="true" count="0" />\\015\\012</StiSerializer>'
WHERE EXISTS(
	SELECT * 
    FROM "NotificationConstructTemplate" AS nct
	WHERE ncdt."NotificationConstructTemplateID" = nct."NotificationConstructTemplateID" AND nct."Name" LIKE 'NewInternalMessages');
	
	
	
	
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
  'BankAccountMarkedAsPotentialFraud',
  'Bank Account Marked as Potential Fraud Notification',
  4989, -- HTML
  4993, -- System
  'Bank Account Marked as Potential Fraud' ,
  'Test',
  '0001',
  'Bec.TargetFramework.SB.Notifications.Mutators.BankAccountMarkedAsPotentialFraudMutator, Bec.TargetFramework.SB.Notifications',
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
      <BankAccountMarkedAsPotentialFraudNotificationDTO Ref="3" type="Stimulsoft.Report.Dictionary.StiBusinessObject" isKey="true">
        <Alias>BankAccountMarkedAsPotentialFraudNotificationDTO</Alias>
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
        <Name>BankAccountMarkedAsPotentialFraudNotificationDTO</Name>
      </BankAccountMarkedAsPotentialFraudNotificationDTO>
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
          <Text>&lt;h2&gt;&lt;line-height="1.5"&gt;The following bank account was Marked as Potential Fraud&lt;/line-height&gt;&lt;/h2&gt;</Text>
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
          <Font>Microsoft Sans Serif,10</Font>
          <Guid>d666cef6f51441dda0b39d364072a5a3</Guid>
          <Margins>0,0,0,0</Margins>
          <Name>Text6</Name>
          <Page isRef="4" />
          <Parent isRef="4" />
          <Text>&lt;line-height="1.5"&gt;{BankAccountMarkedAsPotentialFraudNotificationDTO.AccountNumber}&lt;/line-height&gt;</Text>
          <TextBrush>[51:51:51]</TextBrush>
          <TextQuality>Wysiwyg</TextQuality>
          <Type>Expression</Type>
        </Text6>
        <Text7 Ref="11" type="Text" isKey="true">
          <AllowHtmlTags>True</AllowHtmlTags>
          <Brush>Transparent</Brush>
          <ClientRectangle>4.6,1.8,10.2,0.6</ClientRectangle>
          <Conditions isList="true" count="0" />
          <Font>Microsoft Sans Serif,10</Font>
          <Guid>a43d44a16c9f455fb005c85e01288a46</Guid>
          <Margins>0,0,0,0</Margins>
          <Name>Text7</Name>
          <Page isRef="4" />
          <Parent isRef="4" />
          <Text>&lt;line-height="1.5"&gt;{BankAccountMarkedAsPotentialFraudNotificationDTO.SortCode}&lt;/line-height&gt;</Text>
          <TextBrush>[51:51:51]</TextBrush>
          <TextQuality>Wysiwyg</TextQuality>
          <Type>Expression</Type>
        </Text7>
        <Text8 Ref="12" type="Text" isKey="true">
          <AllowHtmlTags>True</AllowHtmlTags>
          <Brush>Transparent</Brush>
          <ClientRectangle>4.6,2.6,10.2,0.6</ClientRectangle>
          <Conditions isList="true" count="0" />
          <Font>Microsoft Sans Serif,10</Font>
          <Guid>f5dc17c70f1a40e8a4d0080105b86861</Guid>
          <Margins>0,0,0,0</Margins>
          <Name>Text8</Name>
          <Page isRef="4" />
          <Parent isRef="4" />
          <Text>&lt;line-height="1.5"&gt;{BankAccountMarkedAsFraudSuspiciousNotificationDTO.MarkedBy}&lt;/line-height&gt;</Text>
          <TextBrush>[51:51:51]</TextBrush>
          <TextQuality>Wysiwyg</TextQuality>
          <Type>Expression</Type>
        </Text8>
        <Text10 Ref="13" type="Text" isKey="true">
          <AllowHtmlTags>True</AllowHtmlTags>
          <Brush>Transparent</Brush>
          <ClientRectangle>4.6,3.4,10.2,0.6</ClientRectangle>
          <Conditions isList="true" count="0" />
          <Font>Microsoft Sans Serif,10,Underline</Font>
          <Guid>229a1094c32f475bb527a9678a572f42</Guid>
          <Hyperlink>{BankAccountMarkedAsPotentialFraudNotificationDTO.DetailsUrl}</Hyperlink>
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
  <ReportChanged>9/29/2015 10:39:46 AM</ReportChanged>
  <ReportCreated>9/29/2014 8:17:02 AM</ReportCreated>
  <ReportFile>f.mrt</ReportFile>
  <ReportGuid>3e434a44c2dd4ee5bbe1aefbedb5a66f</ReportGuid>
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
  'BankAccountMarkedAsPotentialFraudNotificationDTO',
  'Bec.TargetFramework.Entities.DTO.Notification.BankAccountMarkedAsPotentialFraudNotificationDTO, Bec.TargetFramework.Entities',
  'BankAccountMarkedAsPotentialFraudNotificationDTO',
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
  'BankAccountMarkedAsPotentialFraud',
  'BankAccountMarkedAsPotentialFraud Notification Resource',
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
            r."ResourceName" LIKE ''BankAccountMarkedAsPotentialFraud'' AND
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



CREATE TABLE public."File" (
  "FileID" UUID DEFAULT uuid_generate_v1() NOT NULL,
  "ParentID" UUID NOT NULL,
  "Name" VARCHAR NOT NULL,
  "Data" BYTEA NOT NULL,
  "Type" VARCHAR NOT NULL,
  "UserAccountOrganisationID" UUID,
  "Temporary" boolean default false not null,
  PRIMARY KEY("FileID")
) ;

ALTER TABLE public."File"
  ALTER COLUMN "FileID" SET STATISTICS 0;

ALTER TABLE public."File"
  ALTER COLUMN "ParentID" SET STATISTICS 0;

ALTER TABLE public."File"
  ALTER COLUMN "Name" SET STATISTICS 0;

ALTER TABLE public."File"
  ALTER COLUMN "Data" SET STATISTICS 0; 

CREATE INDEX "File_idx_Parent" ON public."File"
  USING btree ("ParentID");

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."File" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."File" TO bef;

ALTER TABLE public."Notification"
  ALTER COLUMN "NotificationID" DROP DEFAULT;

  ALTER TABLE public."File"
  ADD CONSTRAINT "File_fk_UserAccountOrganisation" FOREIGN KEY ("UserAccountOrganisationID")
    REFERENCES public."UserAccountOrganisation"("UserAccountOrganisationID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;


CREATE FUNCTION public."fn_AttachUploads" (
  uaoid uuid,
  id uuid,
  newid uuid
)
RETURNS void AS
$body$
BEGIN
  update "File" set "ParentID" = newid, "Temporary" = false
  where "ParentID" = id and "UserAccountOrganisationID" = uaoid and "Temporary" = true;
END;
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER;

grant execute on function public."fn_AttachUploads"(uaoid uuid, id uuid, newid uuid) to postgres;
grant execute on function public."fn_AttachUploads"(uaoid uuid, id uuid, newid uuid) to bef;




CREATE OR REPLACE VIEW public."vOrganisationWithStatusAndAdmin"(
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
    "ActiveSafeAccounts")
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
         COALESCE(sb."ActiveSafeAccounts", 0::bigint) AS "ActiveSafeAccounts"
  FROM "Organisation" org
       LEFT JOIN "OrganisationDetail" orgd ON orgd."OrganisationID" =
         org."OrganisationID"
       LEFT JOIN "OrganisationType" orgt ON orgt."OrganisationTypeID" =
         org."OrganisationTypeID"
       LEFT JOIN "vOrganisationStatus" vorgs ON vorgs."OrganisationID" =
         org."OrganisationID"
       LEFT JOIN "vStatusType" vst ON vst."StatusTypeID" = vorgs."StatusTypeID"
         AND vst."StatusTypeValueID" = vorgs."StatusTypeValueID" AND
         vst."StatusTypeVersionNumber" = vorgs."StatusTypeVersionNumber"
       LEFT JOIN "UserAccountOrganisation" uao ON uao."OrganisationID" =
         org."OrganisationID" AND uao."UserTypeID" =((
                                                       SELECT ut."UserTypeID"
                                                       FROM "UserType" ut
                                                       WHERE ut."Name"::text =
                                                         'Organisation Administrator'
                                                         ::text
                                                       LIMIT 1
       ))
       LEFT JOIN "Contact" orgc ON orgc."ParentID" = org."OrganisationID" AND
         orgc."IsPrimaryContact" = true
       LEFT JOIN "Contact" uaoc ON uaoc."ParentID" =
         uao."UserAccountOrganisationID" AND uaoc."IsPrimaryContact" = true
       LEFT JOIN "UserAccounts" ua ON ua."ID" = uao."UserID"
       LEFT JOIN "Address" addr ON addr."ParentID" = orgc."ContactID" AND
         addr."IsPrimaryAddress" = true
       LEFT JOIN "ContactRegulator" conreg ON conreg."ContactID" =
         orgc."ContactID"
       LEFT JOIN 
       (
         SELECT os."OrganisationID",
                os."StatusTypeID",
                os."StatusTypeValueID",
                os."StatusTypeVersionNumber",
                max(os."StatusChangedOn") AS "StatusChangedOn"
         FROM "OrganisationStatus" os
              JOIN "StatusType" st ON st."StatusTypeID" = os."StatusTypeID" AND
                st."Name"::text = 'Professional Organisation Status'::text
              JOIN "StatusTypeValue" sv ON sv."StatusTypeID" = os."StatusTypeID"
                AND sv."StatusTypeValueID" = os."StatusTypeValueID" AND
                sv."Name"::text = 'Verified'::text
         WHERE os."StatusTypeVersionNumber" = 1
         GROUP BY os."OrganisationID",
                  os."StatusTypeID",
                  os."StatusTypeValueID",
                  os."StatusTypeVersionNumber"
       ) verifiedjoin ON verifiedjoin."OrganisationID" = org."OrganisationID"
       LEFT JOIN "OrganisationStatus" verifiedstatus ON
         verifiedstatus."OrganisationID" = verifiedjoin."OrganisationID" AND
         verifiedstatus."StatusTypeID" = verifiedjoin."StatusTypeID" AND
         verifiedstatus."StatusTypeValueID" = verifiedjoin."StatusTypeValueID" AND
         verifiedstatus."StatusTypeVersionNumber" = verifiedjoin."StatusTypeVersionNumber" AND
         verifiedstatus."StatusChangedOn" = verifiedjoin."StatusChangedOn"
       LEFT JOIN 
       (
         SELECT ba."OrganisationID",
                count(ba."OrganisationBankAccountID") AS "ActiveSafeAccounts"
         FROM "OrganisationBankAccount" ba
         WHERE ba."IsActive" = true AND
               (((
                   SELECT st."Name"
                   FROM "OrganisationBankAccountStatus" s
                        LEFT JOIN "StatusTypeValue" st ON st."StatusTypeID" =
                          s."StatusTypeID" AND st."StatusTypeValueID" =
                          s."StatusTypeValueID"
                   WHERE s."OrganisationBankAccountID" =
                     ba."OrganisationBankAccountID"
                   ORDER BY s."StatusChangedOn" DESC
                   LIMIT 1
               ))::text) = 'Safe'::text
         GROUP BY ba."OrganisationID"
       ) sb ON sb."OrganisationID" = org."OrganisationID"
  WHERE orgt."Name"::text ~~ 'Professional'::text AND
        orgc."ContactID" IS NOT NULL AND
        (ua."IsDeleted" IS NULL OR
        ua."IsDeleted" = false);

	
  