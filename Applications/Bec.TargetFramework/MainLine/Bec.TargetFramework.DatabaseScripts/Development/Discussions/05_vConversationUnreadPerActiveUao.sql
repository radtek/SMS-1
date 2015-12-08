
CREATE VIEW public."vConversationUnreadPerActiveUao"(
    "UserAccountOrganisationID",
    "UnreadCount")
AS
	SELECT 
		uao."UserAccountOrganisationID",
		ur."UnreadCount"::integer AS "UnreadCount"
	FROM "UserAccounts" ua
	JOIN "UserAccountOrganisation" uao ON ua."ID" = uao."UserID"
	JOIN 
	(
		SELECT 
			nr."UserAccountOrganisationID",
			count(nr."NotificationRecipientID") AS "UnreadCount"
 		FROM "NotificationRecipient" nr
		JOIN "Notification" n ON n."NotificationID" = nr."NotificationID"
 		WHERE 
			COALESCE(nr."IsAccepted", false) = false AND
			n."ConversationID" IS NOT NULL
 		GROUP BY nr."UserAccountOrganisationID"
	) ur ON ur."UserAccountOrganisationID" = uao."UserAccountOrganisationID"
	WHERE 
		ua."IsDeleted" = false AND
		ua."IsTemporaryAccount" = false AND
		ua."IsLoginAllowed" = true AND
		uao."IsActive" = true AND
		uao."IsDeleted" = false;

		
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."vConversationUnreadPerActiveUao" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."vConversationUnreadPerActiveUao" TO bef;