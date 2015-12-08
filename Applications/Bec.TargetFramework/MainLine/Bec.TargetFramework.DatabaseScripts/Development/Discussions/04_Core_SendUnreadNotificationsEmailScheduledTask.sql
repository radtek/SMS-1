INSERT INTO 
  public."ClassificationTypeCategory"
(
  "ClassificationTypeCategoryID",
  "Name",
  "IsActive",
  "IsDeleted"
)
VALUES (
  1000,
  'ApplicationID',
  TRUE,--:IsActive,
  FALSE--:IsDeleted
);

INSERT INTO 
  public."ClassificationType"
(
  "ClassificationTypeID",
  "Name",
  "Description",
  "ClassificationTypeCategoryID",
  "ParentClassificationTypeCategoryID",
  "IsActive",
  "IsDeleted"
)
VALUES (
  1000000001,
  'BEF',
  '',--:Description,
  1000,
  NULL,--:ParentClassificationTypeCategoryID,
  TRUE,--:IsActive,
  FALSE--:IsDeleted
);


INSERT INTO 
  public."ClassificationType"
(
  "ClassificationTypeID",
  "Name",
  "Description",
  "ClassificationTypeCategoryID",
  "ParentClassificationTypeCategoryID",
  "IsActive",
  "IsDeleted"
)
VALUES (
  1000000101,
  'DEV',
  '',--:Description,
  1000,
  NULL,--:ParentClassificationTypeCategoryID,
  TRUE,--:IsActive,
  FALSE--:IsDeleted
);

DO $$
	DECLARE busTaskHandlerId uuid;
	DECLARE busTaskId uuid;
	DECLARE busTaskScheduleId uuid;
BEGIN
	busTaskHandlerId := 'F9C0C90F-D23C-42AE-B69A-FBB80EFAB587';
	busTaskId := '783E41BB-5EDD-4653-9C0B-A8A440EF4F5E';
	busTaskScheduleId := '7A2BDC60-DE7D-4B28-8641-66B27FF45B19';

	INSERT INTO 
	  public."BusTaskHandler"
	(
	  "BusTaskHandlerID",
	  "BusTaskHandlerVersionNumber",
	  "Name",
	  "Description",
	  "IsActive",
	  "IsDeleted",
	  "CreatedOn",
	  "CreatedBy",
	  "ModifiedOn",
	  "ModifiedBy",
	  "HandlerObjectTypeName",
	  "HandlerObjectTypeAssemblyName",
	  "MessageTypeName",
	  "MessageTypeAssemblyName",
	  "HandlerMessageTypeName",
	  "HandlerMessageTypeAssemblyName",
	  "BusTaskHandleTypeID",
	  "BusTaskHandleCategoryID",
	  "BusTaskHandlerGroupName",
	  "ParentID"
	)
	VALUES (
	  busTaskHandlerId,
	  1,--:BusTaskHandlerVersionNumber,
	  'SendUnreadNotificationsEmailScheduledTask',
	  NULL,--:Description,
	  TRUE,--:IsActive,
	  FALSE,--:IsDeleted,
	  CURRENT_DATE,
	  'System',
	  NULL,--:ModifiedOn,
	  NULL,--:ModifiedBy,
	  'Bec.TargetFramework.SB.Infrastructure.Quartz.Jobs.SendUnreadNotificationsEmailScheduledTask',--:HandlerObjectTypeName,
	  'Bec.TargetFramework.SB.Infrastructure.Quartz',--:HandlerObjectTypeAssemblyName,
	  NULL,--:MessageTypeName,
	  NULL,--:MessageTypeAssemblyName,
	  NULL,--:HandlerMessageTypeName,
	  NULL,--:HandlerMessageTypeAssemblyName,
	  NULL,--:BusTaskHandleTypeID,
	  NULL,--:BusTaskHandleCategoryID,
	  NULL,--:BusTaskHandlerGroupName,
	  NULL--:ParentID
	);

	INSERT INTO 
	  public."BusTask"
	(
	  "BusTaskID",
	  "Name",
	  "Description",
	  "IsActive",
	  "IsDeleted",
	  "CreatedOn",
	  "CreatedBy",
	  "ModifiedOn",
	  "ModifiedBy",
	  "BusTaskHandlerID",
	  "BusTaskHandlerVersionNumber",
	  "IsScheduleDrivenTask",
	  "BusTaskTypeID",
	  "BusTaskCategoryID",
	  "BusTaskGroupName",
	  "ApplicationID",
	  "ApplicationEnvironmentID",
	  "ParentID",
	  "ReferenceNumber"
	)
	VALUES (
	  busTaskId,
	  'SendUnreadNotificationsEmailScheduledTask',
	  '',
	  TRUE,--IsActive,
	  FALSE,--:IsDeleted,
	  CURRENT_DATE,
	  'System',
	  NULL,--:ModifiedOn,
	  NULL,---:ModifiedBy,
	  busTaskHandlerId,
	  1,--:BusTaskHandlerVersionNumber,
	  TRUE,--:IsScheduleDrivenTask,
	  NULL,--:BusTaskTypeID,
	  NULL,--:BusTaskCategoryID,
	  'Test',--:BusTaskGroupName,
	  1000000001,--:ApplicationID,
	  1000000101,--:ApplicationEnvironmentID,
	  NULL,--:ParentID,
	  NULL--:ReferenceNumber
	);


	INSERT INTO 
	  public."BusTaskSchedule"
	(
	  "BusTaskScheduleID",
	  "IsActive",
	  "IsDeleted",
	  "RepeatForever",
	  "IsCronDriven",
	  "CronScheduleString",
	  "IsCalendarDriven",
	  "RepeatEveryNumberOfSeconds",
	  "RepeatEveryDay",
	  "RepeatMondayToFriday",
	  "RepeatSaturdayAndSunday",
	  "RepeatEveryNumberOfDays",
	  "HasSpecificDailyStartTime",
	  "SpecificDailyStartTimeHour",
	  "BusTaskID",
	  "ParentID"
	)
	VALUES (
	  busTaskScheduleId,
	  TRUE,--:IsActive,
	  FALSE,--:IsDeleted,
	  TRUE,--:RepeatForever,
	  TRUE,--:IsCronDriven,
	  '0 0 9,13 ? * *',--:CronScheduleString,
	  FALSE,--:IsCalendarDriven,
	  NULL,--:RepeatEveryNumberOfSeconds,
	  TRUE,--:RepeatEveryDay,
	  TRUE,--:RepeatMondayToFriday,
	  TRUE,--:RepeatSaturdayAndSunday,
	  NULL,--:RepeatEveryNumberOfDays,
	  FALSE,--:HasSpecificDailyStartTime,
	  NULL,--:SpecificDailyStartTimeHour,
	  busTaskId,
	  NULL--:ParentID
	);

END $$;