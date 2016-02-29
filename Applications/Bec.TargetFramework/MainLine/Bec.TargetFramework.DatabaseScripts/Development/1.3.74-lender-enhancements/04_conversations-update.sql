-- =======================================================================
-- 04_conversations-update
-- =======================================================================

CREATE OR REPLACE VIEW public."vConversation"(
    "ConversationID",
    "UserAccountOrganisationID",
    "Subject",
    "Latest",
    "ActivityID",
    "ActivityType",
    "IsSystemMessage")
AS
  SELECT c."ConversationID",
         v."UserAccountOrganisationID",
         c."Subject",
         c."Latest",
         c."ActivityID",
         c."ActivityType",
         c."IsSystemMessage"
  FROM "Conversation" c 
  join
  (SELECT cp."ConversationID", cp."UserAccountOrganisationID" FROM "ConversationParticipant" cp
   UNION
  SELECT cfp."ConversationID" ,uaof."UserAccountOrganisationID"
   FROM "UserAccountOrganisationSafeSendGroup" uaof
   JOIN "UserAccountOrganisation" uao ON uao."UserAccountOrganisationID" = uaof."UserAccountOrganisationID"
   JOIN "ConversationSafeSendGroupParticipant" cfp ON cfp."SafeSendGroupID" = uaof."SafeSendGroupID" AND cfp."OrganisationID" = uao."OrganisationID")
  v on v."ConversationID" = c."ConversationID";



 -- object recreation
DROP FUNCTION public."fn_GetConversationActivity"(orgid uuid, activitytype integer, activityid uuid, l integer, o integer);

CREATE FUNCTION public."fn_GetConversationActivity" (
  orgid uuid,
  activitytype integer,
  activityid uuid,
  l integer,
  o integer,
  userorgtypename varchar,
  uaoid uuid
)
RETURNS TABLE (
  "ConversationID" uuid,
  "Subject" varchar,
  "Latest" timestamptz
) AS
$body$
BEGIN
if (userorgtypename = 'Professional') then
  --anyone in org
  return query SELECT c."ConversationID", c."Subject", c."Latest" FROM "Conversation" c
  WHERE (
   exists (select * from "ConversationParticipant" cp join "UserAccountOrganisation" uao on cp."UserAccountOrganisationID" = uao."UserAccountOrganisationID"
   where uao."OrganisationID" = orgid and cp."ConversationID" = c."ConversationID")
  )
  and 
  (c."ActivityType" = activitytype) AND (c."ActivityID" = activityid) AND (c."IsSystemMessage" = false)
  order by c."Latest" desc
  limit l offset o;

elsif (userorgtypename = 'Lender') then
  --exact uao or in SafeSendGroup
  return query SELECT c."ConversationID", c."Subject", c."Latest" FROM "Conversation" c
  WHERE (
   exists (select * from "ConversationParticipant" cp
   where cp."UserAccountOrganisationID" = uaoid and cp."ConversationID" = c."ConversationID")
  or
   exists (select * from "ConversationSafeSendGroupParticipant" cfp join "UserAccountOrganisationSafeSendGroup" uaof on uaof."SafeSendGroupID" = cfp."SafeSendGroupID"
   where cfp."ConversationID" = c."ConversationID" and cfp."OrganisationID" = orgid and uaof."UserAccountOrganisationID" = uaoid)
  )
  and 
  (c."ActivityType" = activitytype) AND (c."ActivityID" = activityid) AND (c."IsSystemMessage" = false)
  order by c."Latest" desc
  limit l offset o;
else
  --exact uao
  return query SELECT c."ConversationID", c."Subject", c."Latest" FROM "Conversation" c
  WHERE (
   exists (select * from "ConversationParticipant" cp
   where cp."UserAccountOrganisationID" = uaoid and cp."ConversationID" = c."ConversationID")
  )
  and 
  (c."ActivityType" = activitytype) AND (c."ActivityID" = activityid) AND (c."IsSystemMessage" = false)
  order by c."Latest" desc
  limit l offset o;
end if;


END;
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER
COST 100 ROWS 1000;





 -- object recreation
DROP FUNCTION public."fn_GetConversationActivityCount"(orgid uuid, activitytype integer, activityid uuid);

CREATE FUNCTION public."fn_GetConversationActivityCount" (
  orgid uuid,
  activitytype integer,
  activityid uuid,
  userorgtypename varchar,
  uaoid uuid
)
RETURNS integer AS
$body$
BEGIN
if (userorgtypename = 'Professional') then

return (SELECT count(*) FROM "Conversation" c
WHERE (
 exists (select * from "ConversationParticipant" cp join "UserAccountOrganisation" uao on cp."UserAccountOrganisationID" = uao."UserAccountOrganisationID"
 where uao."OrganisationID" = orgid and cp."ConversationID" = c."ConversationID")
)
and (c."ActivityType" = activitytype) AND (c."ActivityID" = activityid) AND (c."IsSystemMessage" = false));

elsif (userorgtypename = 'Lender') then

return (SELECT count(*) FROM "Conversation" c
WHERE (
 exists (select * from "ConversationParticipant" cp
 where cp."UserAccountOrganisationID" = uaoid and cp."ConversationID" = c."ConversationID")
or
 exists (select * from "ConversationSafeSendGroupParticipant" cfp join "UserAccountOrganisationSafeSendGroup" uaof on uaof."SafeSendGroupID" = cfp."SafeSendGroupID"
 where cfp."ConversationID" = c."ConversationID" and cfp."OrganisationID" = orgid and uaof."UserAccountOrganisationID" = uaoid)
)
and (c."ActivityType" = activitytype) AND (c."ActivityID" = activityid) AND (c."IsSystemMessage" = false));

else

return (SELECT count(*) FROM "Conversation" c
WHERE (
 exists (select * from "ConversationParticipant" cp
 where cp."UserAccountOrganisationID" = uaoid and cp."ConversationID" = c."ConversationID")
)
and (c."ActivityType" = activitytype) AND (c."ActivityID" = activityid) AND (c."IsSystemMessage" = false));

end if;

END;
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER
COST 100;



 -- object recreation
DROP VIEW public."vSafeSendRecipient";

CREATE VIEW public."vSafeSendRecipient"(
    "SmsTransactionID",
    "RelatedID",
    "OrganisationID",
    "FirstName",
    "LastName",
    "OrganisationName",
    "OrganisationTypeName",
    "IsSafeSendGroup")
AS
  SELECT uaot."SmsTransactionID",
         uao."UserAccountOrganisationID" AS "RelatedID",
         uao."OrganisationID",
         c."FirstName",
         c."LastName",
         NULL::character varying AS "OrganisationName",
         'Personal' as "OrganisationTypeName",
         false AS "IsSafeSendGroup"
  FROM sms."SmsUserAccountOrganisationTransaction" uaot
       JOIN "UserAccountOrganisation" uao ON uaot."UserAccountOrganisationID" =
         uao."UserAccountOrganisationID"
       JOIN "Contact" c ON uao."PrimaryContactID" = c."ContactID"
       JOIN "UserAccounts" ua ON uao."UserID" = ua."ID"
  WHERE uao."IsActive" = true AND
        ua."IsActive" = true AND
        ua."IsLoginAllowed" = true AND
        ua."IsTemporaryAccount" = false
  UNION
  SELECT t."SmsTransactionID",
         uao."UserAccountOrganisationID" AS "RelatedID",
         o."OrganisationID",
         c."FirstName",
         c."LastName",
         od."Name" AS "OrganisationName",
		 ot."Name" as "OrganisationTypeName",
         false AS "IsSafeSendGroup"
  FROM sms."SmsTransaction" t
       JOIN "Organisation" o ON t."OrganisationID" = o."OrganisationID"
       JOIN "OrganisationDetail" od ON o."OrganisationID" = od."OrganisationID"
       JOIN "OrganisationType" ot ON o."OrganisationTypeID" =
         ot."OrganisationTypeID"
       JOIN "UserAccountOrganisation" uao ON o."OrganisationID" =
         uao."OrganisationID"
       JOIN "Contact" c ON uao."PrimaryContactID" = c."ContactID"
       JOIN "UserAccounts" ua ON uao."UserID" = ua."ID"
  WHERE uao."IsActive" = true AND
        ua."IsActive" = true AND
        ua."IsLoginAllowed" = true AND
        ua."IsTemporaryAccount" = false
  UNION
  SELECT t."SmsTransactionID",
         f."SafeSendGroupID" AS "RelatedID",
         o."OrganisationID",
         f."Name" AS "FirstName",
         NULL::character varying (100) AS "LastName",
         od."Name" AS "OrganisationName",
		 ot."Name" as "OrganisationTypeName",
         true AS "IsSafeSendGroup"
  FROM sms."SmsTransaction" t
       JOIN "Lender" l ON l."Name"::text = t."LenderName"::text
       JOIN "Organisation" o ON l."OrganisationID" = o."OrganisationID"
       JOIN "OrganisationDetail" od ON o."OrganisationID" = od."OrganisationID"
       JOIN "OrganisationType" ot ON o."OrganisationTypeID" =
         ot."OrganisationTypeID"
       JOIN "SafeSendGroup" f ON ot."OrganisationTypeID" = f."OrganisationTypeID"
  WHERE EXISTS(
  	SELECT *
    FROM "UserAccountOrganisation" uao
    JOIN "UserAccounts" ua ON uao."UserID" = ua."ID"
    JOIN "UserAccountOrganisationSafeSendGroup" uaossg ON uao."UserAccountOrganisationID" = uaossg."UserAccountOrganisationID"
    WHERE
    	uao."OrganisationID" = o."OrganisationID" and
        uaossg."SafeSendGroupID" = f."SafeSendGroupID" and
    	uao."IsActive" = true and 
    	uao."IsDeleted" = false and
        ua."IsLoginAllowed" = true and
        ua."IsActive" = true and
        ua."IsTemporaryAccount" = false);

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."vSafeSendRecipient" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."vSafeSendRecipient" TO bef;


ALTER TABLE public."Notification" ADD COLUMN "CreatedBySafeSendGroupID" UUID;


 -- object recreation
DROP VIEW public."vMessage";

CREATE VIEW public."vMessage"(
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
    "NotificationConstructName",
    "SafeSendGroupName")
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
           WHEN ct."Name"::text = 'SmsTransaction'::text THEN CASE
                                                                WHEN ot."Name"::
                                                                  text =
                                                                  'Personal'::
                                                                  text THEN
                                                                  txt."Description"
                                                                WHEN ot."Name"::
                                                                  text =
                                                                  'Professional'
                                                                  ::text THEN
                                                                  'Conveyancer'
                                                                  ::character
                                                                  varying
                                                                WHEN ot."Name"::
                                                                  text =
                                                                  'Lender'::text
                                                                  THEN 'Lender'
                                                                  ::character
                                                                  varying
                                                                ELSE NULL::
                                                                  character
                                                                  varying
                                                              END
           ELSE NULL::character varying
         END AS "UserType",
         ot."Name" AS "OrganisationType",
         nc."Name" AS "NotificationConstructName",
         f."Name" as "SafeSendGroupName"
  FROM "Notification" n
       JOIN "Conversation" conv ON conv."ConversationID" = n."ConversationID"
       JOIN "NotificationConstruct" nc ON nc."NotificationConstructID" =
         n."NotificationConstructID" AND nc."NotificationConstructVersionNumber"
         = n."NotificationConstructVersionNumber"
       LEFT JOIN "UserAccountOrganisation" uao ON
         uao."UserAccountOrganisationID" =
         n."CreatedByUserAccountOrganisationID"
       LEFT JOIN "UserAccounts" ua ON ua."ID" = uao."UserID"
       LEFT JOIN "Organisation" org ON org."OrganisationID" =
         uao."OrganisationID"
       LEFT JOIN "OrganisationDetail" orgd ON orgd."OrganisationID" =
         org."OrganisationID"
       LEFT JOIN "OrganisationType" ot ON ot."OrganisationTypeID" =
         org."OrganisationTypeID"
       LEFT JOIN "Contact" c ON c."ContactID" = uao."PrimaryContactID"
       JOIN "ClassificationTypeCategory" ctc ON ctc."Name"::text =
         'ActivityTypeID'::text
       LEFT JOIN "ClassificationType" ct ON ct."ClassificationTypeCategoryID" =
         ctc."ClassificationTypeCategoryID" AND ct."ClassificationTypeID" =
         conv."ActivityType"
       LEFT JOIN sms."SmsUserAccountOrganisationTransaction" tx ON
         tx."SmsTransactionID" = conv."ActivityID" AND
         tx."UserAccountOrganisationID" = n."CreatedByUserAccountOrganisationID"
       LEFT JOIN sms."SmsUserAccountOrganisationTransactionType" txt ON
         txt."SmsUserAccountOrganisationTransactionTypeID" =
         tx."SmsUserAccountOrganisationTransactionTypeID"
       left join "SafeSendGroup" f on f."SafeSendGroupID" = n."CreatedBySafeSendGroupID" and f."OrganisationTypeID" = ot."OrganisationTypeID";

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."vMessage" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."vMessage" TO bef;

-- =======================================================================
-- End - 04_conversations-update
-- =======================================================================