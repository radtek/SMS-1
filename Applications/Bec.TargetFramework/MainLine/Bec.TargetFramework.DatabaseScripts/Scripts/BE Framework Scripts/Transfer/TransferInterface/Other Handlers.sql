DO $$
Declare CollateID uuid;
Declare DetermineID uuid;
Declare ProcessID uuid;
Declare SendID uuid;
Declare CollateHandlerID uuid;
Declare DetermineHandlerID uuid;
Declare ProcessHandlerID uuid;
Declare SendHandlerID uuid;
Begin

CollateID := (select "TransferInterfaceStepID" from "TransferInterfaceStep" where "Name" = 'CollateSearchesForSiraBatch' limit 1);
DetermineID := (select "TransferInterfaceStepID" from "TransferInterfaceStep" where "Name" = 'DetermineSearchScopeForSiraBatch' limit 1);
ProcessID := (select "TransferInterfaceStepID" from "TransferInterfaceStep" where "Name" = 'ProcessSearchForSiraBatch' limit 1);
SendID := (select "TransferInterfaceStepID" from "TransferInterfaceStep" where "Name" = 'SendSiraBatch' limit 1);
CollateHandlerID := (select uuid_generate_v1());
DetermineHandlerID := (select uuid_generate_v1());
ProcessHandlerID := (select uuid_generate_v1());
SendHandlerID := (select uuid_generate_v1());

-- insert handlers
INSERT INTO public."TransferHandler"("TransferHandlerID",
  "TransferHandlerVersionNumber", "Name", "HandlerTypeName",
  "HandlerTypeAssemblyName")
VALUES (CollateHandlerID, 1, 'Collate Searches for Batch','Bec.TargetFramework.Transfer.Process.ScheduledTasks.CollateSearchesForSiraTask',
  'Bec.TargetFramework.Transfer.Process');

INSERT INTO public."TransferHandler"("TransferHandlerID",
  "TransferHandlerVersionNumber", "Name", "HandlerTypeName",
  "HandlerTypeAssemblyName")
VALUES (DetermineHandlerID, 1, 'Determine Searches for Batch','Bec.TargetFramework.Transfer.Process.ScheduledTasks.DetermineSearchScopeForSiraTask',
  'Bec.TargetFramework.Transfer.Process');

INSERT INTO public."TransferHandler"("TransferHandlerID",
  "TransferHandlerVersionNumber", "Name", "HandlerTypeName",
  "HandlerTypeAssemblyName")
VALUES (ProcessHandlerID, 1, 'Process Searches for Batch','Bec.TargetFramework.Transfer.Process.ScheduledTasks.ProcessSearchForSiraTask',
  'Bec.TargetFramework.Transfer.Process');

INSERT INTO public."TransferHandler"("TransferHandlerID",
  "TransferHandlerVersionNumber", "Name", "HandlerTypeName",
  "HandlerTypeAssemblyName")
VALUES (SendHandlerID, 1, 'Send Searches in Batch','Bec.TargetFramework.Transfer.Process.ScheduledTasks.SendSearchesForSiraTask',
  'Bec.TargetFramework.Transfer.Process');

 -- create step mappings
UPDATE
  public."TransferInterfaceStep"
SET
  "TransferHandlerID" = CollateHandlerID,
  "TransferHandlerVersionNumber" = 1
WHERE
	"TransferInterfaceStepID" = CollateID and "TransferInterfaceStepVersionNumber" = 1
;

UPDATE
  public."TransferInterfaceStep"
SET
  "TransferHandlerID" = DetermineHandlerID,
  "TransferHandlerVersionNumber" = 1
WHERE
	"TransferInterfaceStepID" = DetermineID and "TransferInterfaceStepVersionNumber" = 1
;

UPDATE
  public."TransferInterfaceStep"
SET
  "TransferHandlerID" = SendHandlerID,
  "TransferHandlerVersionNumber" = 1
WHERE
	"TransferInterfaceStepID" = SendID and "TransferInterfaceStepVersionNumber" = 1
;

UPDATE
  public."TransferInterfaceStep"
SET
  "TransferHandlerID" = ProcessHandlerID,
  "TransferHandlerVersionNumber" = 1
WHERE
	"TransferInterfaceStepID" = ProcessID and "TransferInterfaceStepVersionNumber" = 1
;

END $$;