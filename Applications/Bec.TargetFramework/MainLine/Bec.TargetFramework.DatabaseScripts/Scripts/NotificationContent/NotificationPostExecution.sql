-- promote parent notifications
select

(SELECT count(*) FROM "fn_PromoteNotificationConstructTemplate"(nct."NotificationConstructTemplateID",1))

from "NotificationConstructTemplate" nct

where not exists (select * from "NotificationConstruct" nc where nc."NotificationConstructTemplateID" = nct."NotificationConstructTemplateID"
	and nc."NotificationConstructTemplateVersionNumber" = nct."NotificationConstructTemplateVersionNumber")

    and nct."Name" in ('ExternalBatchNotification','ExternalNotification')

;

-- Promote all child Notifications
select

(SELECT count(*) FROM "fn_PromoteNotificationConstructTemplate"(nct."NotificationConstructTemplateID",1))

from "NotificationConstructTemplate" nct

where not exists (select * from "NotificationConstruct" nc where nc."NotificationConstructTemplateID" = nct."NotificationConstructTemplateID"
	and nc."NotificationConstructTemplateVersionNumber" = nct."NotificationConstructTemplateVersionNumber")

    and nct."Name" not in ('ExternalBatchNotification','ExternalNotification')

;