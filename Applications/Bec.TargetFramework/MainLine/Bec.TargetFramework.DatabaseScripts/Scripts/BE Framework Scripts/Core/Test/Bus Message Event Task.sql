-- Test Event Subscriber
INSERT INTO public."BusEventType" ("BusEventTypeID", "Name")
VALUES (E'707d82de-3ddd-11e4-95c4-a77fdf4021b5', E'Test');

INSERT INTO public."BusEvent" ("BusEventID", "BusEventName", "BusEventDescription", "BusEventTypeID")
VALUES (E'4633a062-400d-11e4-92d1-3bbc97b163aa', E'TestEvent', E'TestEvent', E'707d82de-3ddd-11e4-95c4-a77fdf4021b5');

INSERT INTO public."BusEventMessageSubscriber" ("BusEventMessageSubscriberID", "Name", "ObjectName", "ObjectAssembly", "DefaultMessageSubscriberFilter")
VALUES (E'6f85fd84-400d-11e4-a6c8-1fe24de621cb', E'TestEvent', E'Bec.TargetFramework.SB.Messages.Events.TestEvent', E'Bec.TargetFramework.SB.Messages', NULL);

INSERT INTO public."BusEventBusEventMessageSubscriber" ("BusEventID", "BusEventMessageSubscriberID", "IsActive", "IsDeleted", "BusEventMessageSubscriberFilter")
VALUES (E'4633a062-400d-11e4-92d1-3bbc97b163aa', E'6f85fd84-400d-11e4-a6c8-1fe24de621cb', True, False, NULL);

-- Test Task
INSERT INTO public."BusTaskHandler" ("BusTaskHandlerID", "Name", "ObjectTypeName", "IsActive", "IsDeleted", "ObjectTypeAssembly", "MessageTypeName", "MessageTypeAssembly")
VALUES (E'54e6b9b0-47f5-11e4-bdc4-1fff1c7f479e', E'TestScheduledTask', E'Bec.TargetFramework.SB.TaskHandlers.ScheduledTaskHandlers.TestScheduledTask, Bec.TargetFramework.SB.TaskHandlers', True, False, E'Bec.TargetFramework.SB.TaskHandlers', E'Bec.TargetFramework.SB.TaskHandlers.ScheduledTaskHandlers.TestScheduledTaskMessage', E'Bec.TargetFramework.SB.TaskHandlers');

INSERT INTO public."BusTask" ("BusTaskID", "Name", "Description", "CreatedOn", "IsActive", "IsDeleted", "BusTaskHandlerID","BusTaskVersionNumber")
VALUES (E'3b1ab5ea-47f5-11e4-8c12-d39d0d71000d', E'TestScheduledTask', E'Test Scheduled Task', E'2014-09-29 00:00:00', True, False, E'54e6b9b0-47f5-11e4-bdc4-1fff1c7f479e',1);

INSERT INTO public."BusTaskSchedule" ("BusTaskScheduleID", "BusTaskID", "IntervalInMinutes", "IsActive", "IsDeleted","BusTaskVersionNumber")
VALUES (E'8e9cf002-47f5-11e4-9b97-03ba009b2b53', E'3b1ab5ea-47f5-11e4-8c12-d39d0d71000d', 200, True, False,1);
