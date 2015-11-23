INSERT INTO public."ClassificationTypeCategory" ("ClassificationTypeCategoryID", "Name", "IsActive", "IsDeleted")
VALUES (2081, E'ActivityTypeID', True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (803001, E'SmsTransaction', NULL, 2081, NULL, True, False);

CREATE TABLE public."Conversation" (
  "ConversationID" UUID NOT NULL,
  "Subject" VARCHAR,
  "ActivityType" INTEGER,
  "ActivityID" UUID,
  PRIMARY KEY("ConversationID")
) ;

ALTER TABLE public."Conversation"
  ALTER COLUMN "ConversationID" SET STATISTICS 0;

ALTER TABLE public."Conversation"
  ALTER COLUMN "ActivityType" SET STATISTICS 0;

ALTER TABLE public."Conversation"
  ALTER COLUMN "ActivityID" SET STATISTICS 0;


CREATE TABLE public."ConversationParticipant" (
  "ConversationID" UUID NOT NULL,
  "UserAccountOrganisationID" UUID NOT NULL,
  "Added" TIMESTAMP(0) WITH TIME ZONE DEFAULT now() NOT NULL,
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



SELECT * FROM public."fn_PromoteNotificationConstructTemplate"('4fb339f0-489f-11e4-a2d3-ef22e599ffbb', 1);



CREATE OR REPLACE VIEW public."vConversation"(
    "ConversationID",
    "UserAccountOrganisationID",
    "Subject",
    "Latest",
    "Unread")
AS
  SELECT cp."ConversationID",
         cp."UserAccountOrganisationID",
         c."Subject",
         l."Latest",
         COALESCE(ur."UnreadCount", 0::bigint) AS "Unread"
  FROM "ConversationParticipant" cp
       JOIN "Conversation" c ON c."ConversationID" = cp."ConversationID"
       JOIN 
       (
         SELECT "Notification"."ConversationID",
                max("Notification"."DateSent") AS "Latest"
         FROM "Notification"
         GROUP BY "Notification"."ConversationID"
       ) l ON l."ConversationID" = c."ConversationID"
       LEFT JOIN 
       (
         SELECT n."ConversationID",
                nr."UserAccountOrganisationID",
                count(nr."NotificationRecipientID") AS "UnreadCount"
         FROM "NotificationRecipient" nr
              JOIN "Notification" n ON n."NotificationID" = nr."NotificationID"
         WHERE COALESCE(nr."IsAccepted", false) = false
         GROUP BY n."ConversationID",
                  nr."UserAccountOrganisationID"
       ) ur ON ur."ConversationID" = c."ConversationID" AND
         ur."UserAccountOrganisationID" = cp."UserAccountOrganisationID";


CREATE OR REPLACE VIEW public."vConversationActivity"(
    "ConversationID",
    "ActivityType",
    "ActivityID",
    "Subject",
    "Latest")
AS
  SELECT c."ConversationID",
         c."ActivityType",
         c."ActivityID",
         c."Subject",
         l."Latest"
  FROM "Conversation" c
       JOIN 
       (
         SELECT "Notification"."ConversationID",
                max("Notification"."DateSent") AS "Latest"
         FROM "Notification"
         GROUP BY "Notification"."ConversationID"
       ) l ON l."ConversationID" = c."ConversationID";