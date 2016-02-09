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
   FROM "UserAccountOrganisationFunction" uaof
   JOIN "UserAccountOrganisation" uao ON uao."UserAccountOrganisationID" = uaof."UserAccountOrganisationID"
   JOIN "ConversationFunctionParticipant" cfp ON cfp."FunctionID" = uaof."FunctionID" AND cfp."OrganisationID" = uao."OrganisationID")
   
  v on v."ConversationID" = c."ConversationID";



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

WHERE (
 exists (select * from "ConversationParticipant" cp join "UserAccountOrganisation" uao on cp."UserAccountOrganisationID" = uao."UserAccountOrganisationID"
 where uao."OrganisationID" = orgid and cp."ConversationID" = c."ConversationID")
or
 exists (select * from "ConversationFunctionParticipant" cfp
 where cfp."ConversationID" = c."ConversationID" and cfp."OrganisationID" = orgid)
)
and 
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
WHERE (
 exists (select * from "ConversationParticipant" cp join "UserAccountOrganisation" uao on cp."UserAccountOrganisationID" = uao."UserAccountOrganisationID"
 where uao."OrganisationID" = orgid and cp."ConversationID" = c."ConversationID")
or
 exists (select * from "ConversationFunctionParticipant" cfp
 where cfp."ConversationID" = c."ConversationID" and cfp."OrganisationID" = orgid)
)
and (c."ActivityType" = activitytype) AND (c."ActivityID" = activityid) AND (c."IsSystemMessage" = false));
END;
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER
COST 100;
