DO $$
DECLARE ID UUID;
BEGIN

ID := (select dorg."NotificationConstructTemplateID" from "NotificationConstructTemplate" dorg
	where dorg."Name" = 'TcPublic' limit 1);

perform  public."fn_PromoteNotificationConstructTemplate"(ID,1);
END $$;