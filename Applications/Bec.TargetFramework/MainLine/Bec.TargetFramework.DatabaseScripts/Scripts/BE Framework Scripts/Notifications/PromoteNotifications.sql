-- Promotes all notification templates to main tables
select

(SELECT count(*) FROM "fn_PromoteNotificationConstructTemplate"(nct."NotificationConstructTemplateID",1))

from "NotificationConstructTemplate" nct

where not exists (select * from "NotificationConstruct" nc where nc."NotificationConstructTemplateID" = nct."NotificationConstructTemplateID"
	and nc."NotificationConstructTemplateVersionNumber" = nct."NotificationConstructTemplateVersionNumber")
;