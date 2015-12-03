INSERT INTO public."ClassificationTypeCategory" ("ClassificationTypeCategoryID", "Name", "IsActive", "IsDeleted")
VALUES (2081, E'ActivityTypeID', True, False);

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (803001, E'SmsTransaction', NULL, 2081, NULL, True, False);

CREATE TABLE public."Conversation" (
  "ConversationID" UUID NOT NULL,
  "Subject" VARCHAR,
  "ActivityType" INTEGER,
  "ActivityID" UUID,
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



SELECT * FROM public."fn_PromoteNotificationConstructTemplate"('4fb339f0-489f-11e4-a2d3-ef22e599ffbb', 1);


CREATE OR REPLACE VIEW public."vConversation"(
    "ConversationID",
    "UserAccountOrganisationID",
    "Subject",
    "Latest",
    "Unread",
    "ActivityID",
    "ActivityType",
    "IsSystemMessage")
AS
  SELECT cp."ConversationID",
         cp."UserAccountOrganisationID",
         c."Subject",
         l."Latest",
         COALESCE(ur."UnreadCount", 0::bigint) AS "Unread",
         c."ActivityID",
         c."ActivityType",
         c."IsSystemMessage"
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

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."vConversation" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."vConversation" TO bef;

CREATE OR REPLACE VIEW public."vConversationActivity"(
    "ConversationID",
    "ActivityType",
    "ActivityID",
    "Subject",
    "Latest",
    "IsSystemMessage",
    "OrganisationID")
AS
  SELECT c."ConversationID",
         c."ActivityType",
         c."ActivityID",
         c."Subject",
         l."Latest",
         c."IsSystemMessage",
         o."OrganisationID"
  FROM "Conversation" c
       JOIN 
       (
         SELECT "Notification"."ConversationID",
                max("Notification"."DateSent") AS "Latest"
         FROM "Notification"
         GROUP BY "Notification"."ConversationID"
       ) l ON l."ConversationID" = c."ConversationID"
       JOIN 
       (
         SELECT cp."ConversationID",
                uao."OrganisationID"
         FROM "ConversationParticipant" cp
              JOIN "UserAccountOrganisation" uao ON
                uao."UserAccountOrganisationID" = cp."UserAccountOrganisationID"
         GROUP BY cp."ConversationID",
                  uao."OrganisationID"
       ) o ON o."ConversationID" = c."ConversationID"
  ORDER BY l."Latest" DESC;

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."vConversationActivity" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."vConversationActivity" TO bef;


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
  SELECT cp."ConversationID", cp."UserAccountOrganisationID", row_number() over (order by l."Latest" desc) as "Row"
  FROM "ConversationParticipant" cp
       JOIN "Conversation" c ON c."ConversationID" = cp."ConversationID"
       JOIN 
       (
         SELECT "Notification"."ConversationID", max("Notification"."DateSent") AS "Latest"
         FROM "Notification" GROUP BY "Notification"."ConversationID"
       ) l ON l."ConversationID" = c."ConversationID"
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

