DO $$
Declare TBusTaskID uuid;
Declare TBusTaskHandlerID uuid;
Declare TBusTaskHandlerVersionNumber integer;
Begin

--bus task handler
TBusTaskHandlerID := (select uuid_generate_v1());
TBusTaskHandlerVersionNumber := 1;

INSERT INTO public."BusTaskHandler" (
 "BusTaskHandlerID",
 "BusTaskHandlerVersionNumber",
 "Name",
 "CreatedBy",
 "HandlerObjectTypeName",
 "HandlerObjectTypeAssemblyName"
)
VALUES (
 TBusTaskHandlerID,
 TBusTaskHandlerVersionNumber,
 E'CreditTopUpTask',
 E'Setup',
 E'Bec.TargetFramework.SB.TaskHandlers.EventHandlers.CreditTopUpHandler, Bec.TargetFramework.SB.TaskHandlers',
 E'Bec.TargetFramework.SB.TaskHandlers'
);


--bus task
TBusTaskID := E'b43f6a43-edc1-11e4-8341-00155d0a1426';

INSERT INTO public."BusTask" (
 "BusTaskID",
 "Name",
 "Description",
 "CreatedOn",
 "BusTaskHandlerID",
 "BusTaskHandlerVersionNumber")
VALUES (
 TBusTaskID,
 E'CreditTopUpTask',
 E'Credit Top Up Task',
 E'2014-09-29 00:00:00',
 TBusTaskHandlerID,
 TBusTaskHandlerVersionNumber
);

end $$;