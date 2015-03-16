

select

"ID",
"Username",
"Email",
"IsTemporaryAccount",
"Created",
date_part('day',(CURRENT_TIMESTAMP - "Created")) as "DaysSinceCreation",
date_part('hour',(CURRENT_TIMESTAMP - "Created")) as "HoursSinceCreation",
(case when date_part('day',(CURRENT_TIMESTAMP - "Created")) between 7 and 14 then true else false end) as "Between7and14DaysNotLoggedIn",
(case when date_part('day',(CURRENT_TIMESTAMP - "Created")) between 14 and 21 then true else false end) as "Between14and21DaysNotLoggedIn",
(case when date_part('day',(CURRENT_TIMESTAMP - "Created")) between 0 and 7 then true else false end) as "Between0and7DaysNotLoggedIn",
(case when date_part('day',(CURRENT_TIMESTAMP - "Created")) > 21 then true else false end) as "GreaterThan21DaysNotLoggedIn",
(case when "LastLogin" is null then true else false end) as "NotLoggedIn",

(select count(*) from "NotificationRecipientLog" nrl
left outer join "NotificationRecipient" nr on nr."NotificationRecipientID" = nrl."NotificationRecipientID"
left outer join "Notification" note on note."NotificationID" = nr."NotificationID"
left outer join "NotificationConstruct" nc on nc."NotificationConstructID" = note."NotificationConstructID" and nc."NotificationConstructVersionNumber" = note."NotificationConstructVersionNumber"

where nr."UserID" = "ID" and nc."Name" = 'COLPRegistrationReminder' and nrl."IsSent" = true and nrl."IsRead" = false) as "COLPRemindersNotReadEver",

(select count(*) from "NotificationRecipientLog" nrl
left outer join "NotificationRecipient" nr on nr."NotificationRecipientID" = nrl."NotificationRecipientID"
left outer join "Notification" note on note."NotificationID" = nr."NotificationID"
left outer join "NotificationConstruct" nc on nc."NotificationConstructID" = note."NotificationConstructID" and nc."NotificationConstructVersionNumber" = note."NotificationConstructVersionNumber"

where nr."UserID" = "ID" and nc."Name" = 'COLPRegistrationSummary' and nrl."IsSent" = true and nrl."IsRead" = false) as "COLPRegistrationsNotReadEver",


(select count(*) from "NotificationRecipientLog" nrl
left outer join "NotificationRecipient" nr on nr."NotificationRecipientID" = nrl."NotificationRecipientID"
left outer join "Notification" note on note."NotificationID" = nr."NotificationID"
left outer join "NotificationConstruct" nc on nc."NotificationConstructID" = note."NotificationConstructID" and nc."NotificationConstructVersionNumber" = note."NotificationConstructVersionNumber"

where nr."UserID" = "ID" and nc."Name" = 'COLPRegistrationReminder' and nrl."IsSent" = true and nrl."IsRead" = false and date_part('day',(CURRENT_TIMESTAMP - "Created")) between 7 and 14) as "COLPRemindersNotReadBetween7and14Days",

(select count(*) from "NotificationRecipientLog" nrl
left outer join "NotificationRecipient" nr on nr."NotificationRecipientID" = nrl."NotificationRecipientID"
left outer join "Notification" note on note."NotificationID" = nr."NotificationID"
left outer join "NotificationConstruct" nc on nc."NotificationConstructID" = note."NotificationConstructID" and nc."NotificationConstructVersionNumber" = note."NotificationConstructVersionNumber"

where nr."UserID" = "ID" and nc."Name" = 'COLPRegistrationReminder' and nrl."IsSent" = true and nrl."IsRead" = false and date_part('day',(CURRENT_TIMESTAMP - "Created")) between 14 and 21) as "COLPRemindersNotReadBetween14and21Days",

(select count(*) from "NotificationRecipientLog" nrl
left outer join "NotificationRecipient" nr on nr."NotificationRecipientID" = nrl."NotificationRecipientID"
left outer join "Notification" note on note."NotificationID" = nr."NotificationID"
left outer join "NotificationConstruct" nc on nc."NotificationConstructID" = note."NotificationConstructID" and nc."NotificationConstructVersionNumber" = note."NotificationConstructVersionNumber"

where nr."UserID" = "ID" and nc."Name" = 'COLPRegistrationReminder' and nrl."IsSent" = true and nrl."IsRead" = false and date_part('day',(CURRENT_TIMESTAMP - "Created")) between 0 and 7) as "COLPRemindersNotReadBetween0and7Days",

(select wdi."DataContent" from "WorkflowInstance" wi

inner join "Workflow" wf on wf."WorkflowID" = wi."WorkflowID" and wf."WorkflowVersionNumber" = wi."WorkflowVersionNumber" and wf."Name" = 'Login'

inner join "WorkflowInstanceExecution" wie on wie."WorkflowID" = wf."WorkflowID" and wie."WorkflowVersionNumber" = wf."WorkflowVersionNumber" and wie."WorkflowInstanceID" = wi."WorkflowInstanceID"

and wie."WorkflowInstanceExecutionID" = (select wie2."WorkflowInstanceExecutionID" from "WorkflowInstanceExecution" wie2 where wie2."WorkflowID" = wf."WorkflowID" and wie2."WorkflowVersionNumber" = wf."WorkflowVersionNumber" and wie2."WorkflowInstanceID" = wi."WorkflowInstanceID" order by wie2."CreatedOn" desc limit 1)

inner join "WorkflowInstanceExecutionStatusEvent" wied on wied."WorkflowInstanceExecutionID" = wie."WorkflowInstanceExecutionID"

and wied."WorkflowInstanceExecutionStatusEventID" = (select wied2."WorkflowInstanceExecutionStatusEventID" from "WorkflowInstanceExecutionStatusEvent" wied2 where wied2."WorkflowInstanceExecutionID" = wie."WorkflowInstanceExecutionID"  order by wied2."EventDate" desc limit 1)

inner join "WorkflowInstanceExecutionDataItem" wdi on wdi."WorkflowInstanceExecutionStatusEventID" = wied."WorkflowInstanceExecutionStatusEventID" and wdi."WorkflowInstanceExecutionDataItemID"
 = (select wdi2."WorkflowInstanceExecutionDataItemID" from  "WorkflowInstanceExecutionDataItem" wdi2 where wdi2."WorkflowInstanceExecutionStatusEventID" = wied."WorkflowInstanceExecutionStatusEventID"
 	order by wdi2."WorkflowInstanceExecutionDataItemID" desc limit 1)



  where wi."ParentID" = "ID")

   as "LoginWorkflowDataContent"




 from "UserAccounts"





where "LastLogin" is null

;