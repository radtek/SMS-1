/* Data for the 'public.BusTask' table  (Records 1 - 4) */

/* Data for the 'public.BusTaskHandler' table  (Records 1 - 4) */

INSERT INTO public."BusTaskHandler" ("BusTaskHandlerID", "BusTaskHandlerVersionNumber", "Name", "Description", "IsActive", "IsDeleted", "CreatedOn", "CreatedBy", "ModifiedOn", "ModifiedBy", "HandlerObjectTypeName", "HandlerObjectTypeAssemblyName", "MessageTypeName", "MessageTypeAssemblyName", "HandlerMessageTypeName", "HandlerMessageTypeAssemblyName", "BusTaskHandleTypeID", "BusTaskHandleCategoryID", "BusTaskHandlerGroupName", "ParentID")
VALUES (E'1f65b5bc-604e-11e5-9e29-5cf9dde5b474', 1, E'SendSiraBatch', NULL, True, False, E'2015-09-21 11:46:23.014', E'System', E'2015-09-21 11:46:23.014', NULL, E'Bec.TargetFramework.Transfer.Process.ScheduledTasks.SendSearchesForSiraTask', E'Bec.TargetFramework.Transfer.Process', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

INSERT INTO public."BusTaskHandler" ("BusTaskHandlerID", "BusTaskHandlerVersionNumber", "Name", "Description", "IsActive", "IsDeleted", "CreatedOn", "CreatedBy", "ModifiedOn", "ModifiedBy", "HandlerObjectTypeName", "HandlerObjectTypeAssemblyName", "MessageTypeName", "MessageTypeAssemblyName", "HandlerMessageTypeName", "HandlerMessageTypeAssemblyName", "BusTaskHandleTypeID", "BusTaskHandleCategoryID", "BusTaskHandlerGroupName", "ParentID")
VALUES (E'1f658eb9-604e-11e5-9e26-5cf9dde5b474', 1, E'CollateSearchesForSiraBatch', NULL, True, False, E'2015-09-21 11:46:23.014', E'System', E'2015-09-21 11:46:23.014', NULL, E'Bec.TargetFramework.Transfer.Process.ScheduledTasks.CollateSearchesForSiraTask', E'Bec.TargetFramework.Transfer.Process', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

INSERT INTO public."BusTaskHandler" ("BusTaskHandlerID", "BusTaskHandlerVersionNumber", "Name", "Description", "IsActive", "IsDeleted", "CreatedOn", "CreatedBy", "ModifiedOn", "ModifiedBy", "HandlerObjectTypeName", "HandlerObjectTypeAssemblyName", "MessageTypeName", "MessageTypeAssemblyName", "HandlerMessageTypeName", "HandlerMessageTypeAssemblyName", "BusTaskHandleTypeID", "BusTaskHandleCategoryID", "BusTaskHandlerGroupName", "ParentID")
VALUES (E'1f658eb6-604e-11e5-9e23-5cf9dde5b474', 1, E'ProcessSearchForSiraBatch', NULL, True, False, E'2015-09-21 11:46:23.014', E'System', E'2015-09-21 11:46:23.014', NULL, E'Bec.TargetFramework.Transfer.Process.ScheduledTasks.ProcessSearchForSiraTask', E'Bec.TargetFramework.Transfer.Process', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

INSERT INTO public."BusTaskHandler" ("BusTaskHandlerID", "BusTaskHandlerVersionNumber", "Name", "Description", "IsActive", "IsDeleted", "CreatedOn", "CreatedBy", "ModifiedOn", "ModifiedBy", "HandlerObjectTypeName", "HandlerObjectTypeAssemblyName", "MessageTypeName", "MessageTypeAssemblyName", "HandlerMessageTypeName", "HandlerMessageTypeAssemblyName", "BusTaskHandleTypeID", "BusTaskHandleCategoryID", "BusTaskHandlerGroupName", "ParentID")
VALUES (E'1f6567a6-604e-11e5-9e20-5cf9dde5b474', 1, E'DetermineSearchScopeForSiraBatch', NULL, True, False, E'2015-09-21 11:46:23.014', E'System', E'2015-09-21 11:46:23.014', NULL, E'Bec.TargetFramework.Transfer.Process.ScheduledTasks.DetermineSearchScopeForSiraTask', E'Bec.TargetFramework.Transfer.Process', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

INSERT INTO public."BusTask" ("BusTaskID", "Name", "Description", "IsActive", "IsDeleted", "CreatedOn", "CreatedBy", "ModifiedOn", "ModifiedBy", "BusTaskHandlerID", "BusTaskHandlerVersionNumber", "IsScheduleDrivenTask", "BusTaskTypeID", "BusTaskCategoryID", "BusTaskGroupName", "ApplicationID", "ApplicationEnvironmentID", "ParentID", "ReferenceNumber")
VALUES (E'1f6567a7-604e-11e5-9e21-5cf9dde5b474', E'DetermineSearchScopeForSiraBatch', E'DetermineSearchScopeForSiraBatch', True, False, E'2015-09-21 11:46:23.014', NULL, E'2015-09-21 11:46:23.014', NULL, E'1f6567a6-604e-11e5-9e20-5cf9dde5b474', 1, True, NULL, NULL, NULL, 1000000002, 1000000105, NULL, NULL);

INSERT INTO public."BusTask" ("BusTaskID", "Name", "Description", "IsActive", "IsDeleted", "CreatedOn", "CreatedBy", "ModifiedOn", "ModifiedBy", "BusTaskHandlerID", "BusTaskHandlerVersionNumber", "IsScheduleDrivenTask", "BusTaskTypeID", "BusTaskCategoryID", "BusTaskGroupName", "ApplicationID", "ApplicationEnvironmentID", "ParentID", "ReferenceNumber")
VALUES (E'1f658eb7-604e-11e5-9e24-5cf9dde5b474', E'ProcessSearchForSiraBatch', E'ProcessSearchForSiraBatch', True, False, E'2015-09-21 11:46:23.014', NULL, E'2015-09-21 11:46:23.014', NULL, E'1f658eb6-604e-11e5-9e23-5cf9dde5b474', 1, True, NULL, NULL, NULL, 1000000002, 1000000105, NULL, NULL);

INSERT INTO public."BusTask" ("BusTaskID", "Name", "Description", "IsActive", "IsDeleted", "CreatedOn", "CreatedBy", "ModifiedOn", "ModifiedBy", "BusTaskHandlerID", "BusTaskHandlerVersionNumber", "IsScheduleDrivenTask", "BusTaskTypeID", "BusTaskCategoryID", "BusTaskGroupName", "ApplicationID", "ApplicationEnvironmentID", "ParentID", "ReferenceNumber")
VALUES (E'1f658eba-604e-11e5-9e27-5cf9dde5b474', E'CollateSearchesForSiraBatch', E'CollateSearchesForSiraBatch', True, False, E'2015-09-21 11:46:23.014', NULL, E'2015-09-21 11:46:23.014', NULL, E'1f658eb9-604e-11e5-9e26-5cf9dde5b474', 1, True, NULL, NULL, NULL, 1000000002, 1000000105, NULL, NULL);

INSERT INTO public."BusTask" ("BusTaskID", "Name", "Description", "IsActive", "IsDeleted", "CreatedOn", "CreatedBy", "ModifiedOn", "ModifiedBy", "BusTaskHandlerID", "BusTaskHandlerVersionNumber", "IsScheduleDrivenTask", "BusTaskTypeID", "BusTaskCategoryID", "BusTaskGroupName", "ApplicationID", "ApplicationEnvironmentID", "ParentID", "ReferenceNumber")
VALUES (E'1f65b5bd-604e-11e5-9e2a-5cf9dde5b474', E'SendSiraBatch', E'SendSearchesForSiraTask', True, False, E'2015-09-21 11:46:23.014', NULL, E'2015-09-21 11:46:23.014', NULL, E'1f65b5bc-604e-11e5-9e29-5cf9dde5b474', 1, True, NULL, NULL, NULL, 1000000002, 1000000105, NULL, NULL);

/* Data for the 'public.BusTaskSchedule' table  (Records 1 - 4) */

INSERT INTO public."BusTaskSchedule" ("BusTaskScheduleID", "IsActive", "IsDeleted", "RepeatForever", "IsCronDriven", "CronScheduleString", "IsCalendarDriven", "RepeatEveryNumberOfSeconds", "RepeatEveryDay", "RepeatMondayToFriday", "RepeatSaturdayAndSunday", "RepeatEveryNumberOfDays", "HasSpecificDailyStartTime", "SpecificDailyStartTimeHour", "BusTaskID", "ParentID")
VALUES (E'1f658eb8-604e-11e5-9e25-5cf9dde5b474', True, False, False, True, E'0 0 1 ? * MON-FRI *', False, NULL, False, False, False, NULL, False, NULL, E'1f658eb7-604e-11e5-9e24-5cf9dde5b474', NULL);

INSERT INTO public."BusTaskSchedule" ("BusTaskScheduleID", "IsActive", "IsDeleted", "RepeatForever", "IsCronDriven", "CronScheduleString", "IsCalendarDriven", "RepeatEveryNumberOfSeconds", "RepeatEveryDay", "RepeatMondayToFriday", "RepeatSaturdayAndSunday", "RepeatEveryNumberOfDays", "HasSpecificDailyStartTime", "SpecificDailyStartTimeHour", "BusTaskID", "ParentID")
VALUES (E'1f658ebb-604e-11e5-9e28-5cf9dde5b474', True, False, False, True, E'0 0 4 ? * MON-FRI *', False, NULL, False, False, False, NULL, False, NULL, E'1f658eba-604e-11e5-9e27-5cf9dde5b474', NULL);

INSERT INTO public."BusTaskSchedule" ("BusTaskScheduleID", "IsActive", "IsDeleted", "RepeatForever", "IsCronDriven", "CronScheduleString", "IsCalendarDriven", "RepeatEveryNumberOfSeconds", "RepeatEveryDay", "RepeatMondayToFriday", "RepeatSaturdayAndSunday", "RepeatEveryNumberOfDays", "HasSpecificDailyStartTime", "SpecificDailyStartTimeHour", "BusTaskID", "ParentID")
VALUES (E'1f65b5be-604e-11e5-9e2b-5cf9dde5b474', True, False, False, True, E'0 0 14 ? * MON-FRI *', False, NULL, False, False, False, NULL, False, NULL, E'1f65b5bd-604e-11e5-9e2a-5cf9dde5b474', NULL);

INSERT INTO public."BusTaskSchedule" ("BusTaskScheduleID", "IsActive", "IsDeleted", "RepeatForever", "IsCronDriven", "CronScheduleString", "IsCalendarDriven", "RepeatEveryNumberOfSeconds", "RepeatEveryDay", "RepeatMondayToFriday", "RepeatSaturdayAndSunday", "RepeatEveryNumberOfDays", "HasSpecificDailyStartTime", "SpecificDailyStartTimeHour", "BusTaskID", "ParentID")
VALUES (E'1f6567a8-604e-11e5-9e22-5cf9dde5b474', True, False, False, True, E'0 20 13 ? * MON-FRI *', False, NULL, False, False, False, NULL, False, NULL, E'1f6567a7-604e-11e5-9e21-5cf9dde5b474', NULL);

