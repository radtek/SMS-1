
-- Process Search Transfer Task
DO $$
Declare TaskHandlerID uuid;
Declare BusTaskID uuid;
Declare BusTaskScheduleID uuid;
Begin

TaskHandlerID :=  (select uuid_generate_v1());
BusTaskID :=  (select uuid_generate_v1());
BusTaskScheduleID :=  (select uuid_generate_v1());

-- Test Task
INSERT INTO public."BusTaskHandler" ("BusTaskHandlerID", "Name", "ObjectTypeName", "IsActive", "IsDeleted", "ObjectTypeAssembly", "MessageTypeName", "MessageTypeAssembly")
VALUES (TaskHandlerID, E'TestScheduledTask', E'Bec.TargetFramework.SB.TaskHandlers.ScheduledTaskHandlers.TestScheduledTask, Bec.TargetFramework.SB.TaskHandlers', True, False, E'Bec.TargetFramework.SB.TaskHandlers', E'Bec.TargetFramework.SB.TaskHandlers.ScheduledTaskHandlers.TestScheduledTaskMessage', E'Bec.TargetFramework.SB.TaskHandlers');

INSERT INTO public."BusTask" ("BusTaskID", "Name", "Description", "CreatedOn", "IsActive", "IsDeleted", "BusTaskHandlerID","BusTaskVersionNumber")
VALUES (BusTaskID, E'TestScheduledTask', E'Test Scheduled Task', E'2014-09-29 00:00:00', True, False, E'54e6b9b0-47f5-11e4-bdc4-1fff1c7f479e',1);

INSERT INTO public."BusTaskSchedule" ("BusTaskScheduleID", "BusTaskID", "IntervalInMinutes", "IsActive", "IsDeleted","BusTaskVersionNumber")
VALUES (BusTaskScheduleID, BusTaskID, 500, True, False,1);




END $$;