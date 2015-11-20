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


CREATE VIEW public."vMessage" (
    "ConversationID",
    "UserAccountOrganisationID",
    "NotificationID",
    "Message",
    "Read",
    "DateSent")
AS
SELECT n."ConversationID",
    nr."UserAccountOrganisationID",
    n."NotificationID",
    n."NotificationData" ->> 'Message'::text AS "Message",
    COALESCE(nr."IsAccepted", false) AS "Read",
    n."DateSent"
FROM "NotificationRecipient" nr
     JOIN "Notification" n ON nr."NotificationID" = n."NotificationID"
     JOIN "NotificationConstruct" nc ON nc."NotificationConstructID" =
         n."NotificationConstructID" AND nc."NotificationConstructVersionNumber" = n."NotificationConstructVersionNumber" AND nc."Name"::text = 'Message'::text;



CREATE OR REPLACE VIEW public."vMessageLatest"(
    "ConversationID",
    "UserAccountOrganisationID",
    "MostRecentNotificationID",
    "FirstUnreadNotificationID")
AS
  SELECT cp."ConversationID",
         cp."UserAccountOrganisationID",
         (
           SELECT m."NotificationID"
           FROM "vMessage" m
           WHERE m."ConversationID" = cp."ConversationID" AND
                 m."UserAccountOrganisationID" = cp."UserAccountOrganisationID"
           ORDER BY m."DateSent" DESC
           LIMIT 1
         ) AS "MostRecentNotificationID",
         (
           SELECT m."NotificationID"
           FROM "vMessage" m
           WHERE m."ConversationID" = cp."ConversationID" AND
                 m."UserAccountOrganisationID" = cp."UserAccountOrganisationID"
  AND
                 m."Read" = false
           ORDER BY m."DateSent"
           LIMIT 1
         ) AS "FirstUnreadNotificationID"
  FROM "ConversationParticipant" cp;



CREATE VIEW public."vConversations" (
    "UserAccountOrganisationID",
    "ConversationID",
    "Subject",
    "ActivityType",
    "ActivityID",
    "MostRecentDate",
    "MostRecentMessage",
    "MostRecentEmail",
    "MostRecentFirstName",
    "MostRecentLastName",
    "MostRecentOrganisationType",
    "FirstUnreadDate",
    "FirstUnreadMessage",
    "FirstUnreadEmail",
    "FirstUnreadFirstName",
    "FirstUnreadLastName",
    "FirstUnreadOrganisationType")
AS
SELECT m."UserAccountOrganisationID",
    c."ConversationID",
    c."Subject",
    c."ActivityType",
    c."ActivityID",
    nmostrecent."DateSent" AS "MostRecentDate",
    nmostrecent."NotificationData" ->> 'Message'::text AS "MostRecentMessage",
    mrua."Email" AS "MostRecentEmail",
    mrc."FirstName" AS "MostRecentFirstName",
    mrc."LastName" AS "MostRecentLastName",
    mrot."Name" AS "MostRecentOrganisationType",
    nfirstunread."DateSent" AS "FirstUnreadDate",
    nfirstunread."NotificationData" ->> 'Message'::text AS "FirstUnreadMessage",
    fuua."Email" AS "FirstUnreadEmail",
    fuc."FirstName" AS "FirstUnreadFirstName",
    fuc."LastName" AS "FirstUnreadLastName",
    fuot."Name" AS "FirstUnreadOrganisationType"
FROM "vMessageLatest" m
     JOIN "Conversation" c ON c."ConversationID" = m."ConversationID"
     LEFT JOIN "Notification" nfirstunread ON nfirstunread."NotificationID" =
         m."FirstUnreadNotificationID"
     LEFT JOIN "UserAccountOrganisation" fuuao ON
         fuuao."UserAccountOrganisationID" = nfirstunread."CreatedByUserAccountOrganisationID"
     LEFT JOIN "UserAccounts" fuua ON fuua."ID" = fuuao."UserID"
     LEFT JOIN "Organisation" fuorg ON fuorg."OrganisationID" = fuuao."OrganisationID"
     LEFT JOIN "OrganisationType" fuot ON fuot."OrganisationTypeID" =
         fuorg."OrganisationTypeID"
     LEFT JOIN "Contact" fuc ON fuc."ContactID" = fuuao."PrimaryContactID"
     JOIN "Notification" nmostrecent ON nmostrecent."NotificationID" =
         m."MostRecentNotificationID"
     JOIN "UserAccountOrganisation" mruao ON mruao."UserAccountOrganisationID"
         = nmostrecent."CreatedByUserAccountOrganisationID"
     JOIN "UserAccounts" mrua ON mrua."ID" = mruao."UserID"
     JOIN "Organisation" mrorg ON mrorg."OrganisationID" = mruao."OrganisationID"
     JOIN "OrganisationType" mrot ON mrot."OrganisationTypeID" =
         mrorg."OrganisationTypeID"
     JOIN "Contact" mrc ON mrc."ContactID" = mruao."PrimaryContactID"
ORDER BY nmostrecent."DateSent" DESC;