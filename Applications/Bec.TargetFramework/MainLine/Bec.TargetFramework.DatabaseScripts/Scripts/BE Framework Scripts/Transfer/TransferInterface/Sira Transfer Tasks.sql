
-- Process Search Transfer Task
DO $$
Declare TransferTaskID uuid;
Declare ProcessSearchforSiraOrchestratorHandler uuid;
Declare BaseConnectionTaskID uuid;
Declare SourceConnectionID uuid;
Declare DestinationConnectionID uuid;
Declare OrchestratorID uuid;
Declare CoordinatorID uuid;
Begin

TransferTaskID := (select uuid_generate_v1());
ProcessSearchforSiraOrchestratorHandler  := (select uuid_generate_v1());
BaseConnectionTaskID := (select uuid_generate_v1());
SourceConnectionID := (select uuid_generate_v1());
DestinationConnectionID := (select uuid_generate_v1());
OrchestratorID := (select uuid_generate_v1());
CoordinatorID := (select uuid_generate_v1());

-- TASK
INSERT INTO
  public."TransferTask"
(
  "TransferTaskID",
  "Name",
  "IsScheduleDrivenTask",
  "ApplicationID",
  "ApplicationEnvironment"
)
VALUES (
  TransferTaskID,
  'ProcessSearchForSiraBatch',
  false,
  1000000002,
  1000000101
);

-- Handlers
INSERT INTO public."TransferHandler"("TransferHandlerID",
  "TransferHandlerVersionNumber", "Name", "HandlerTypeName",
  "HandlerTypeAssemblyName")
VALUES (ProcessSearchforSiraOrchestratorHandler, 1, 'Process Search for Sira Orchestrator Handler','Bec.TargetFramework.Transfer.Process.Handlers.ProcessSearchForSiraOrchestrator',
  'Bec.TargetFramework.Transfer.Process');

INSERT INTO public."TransferHandler"("TransferHandlerID",
  "TransferHandlerVersionNumber", "Name", "HandlerTypeName",
  "HandlerTypeAssemblyName")
VALUES (BaseConnectionTaskID, 1, 'Base Connection Handler','Bec.TargetFramework.Transfer.Infrastructure.Base.TransferConnectionBase',
  'Bec.TargetFramework.Transfer.Infrastructure');


-- FileFolder
-- None for this task

-- Connection
INSERT INTO public."TransferConnection"("TransferConnectionID", "Name",
  "TransferConnectionVersionNumber",
  "TransferConnectionTypeID", "TransferHandlerID",
  "TransferHandlerVersionNumber")
VALUES (SourceConnectionID, 'Source Connection',
  1,
   5000103,BaseConnectionTaskID,1);

INSERT INTO public."TransferConnection"("TransferConnectionID", "Name",
"TransferConnectionVersionNumber",
"TransferConnectionTypeID", "TransferHandlerID",
"TransferHandlerVersionNumber")
VALUES (DestinationConnectionID, 'Destination Connection',
  1,
   5000103,BaseConnectionTaskID,1);

-- Orchestrator
INSERT INTO
  public."TransferOrchestrator"
(
  "TransferOrchestratorID",
  "TransferOrchestratorVersionNumber",
  "Name",
  "TransferHandlerID",
  "TransferHandlerVersionNumber"
)
VALUES (
  OrchestratorID,
  1,
  'Process Search for Sira Orchestrator',
  ProcessSearchforSiraOrchestratorHandler,
  1
);

-- Coordinator
INSERT INTO
  public."TransferTaskCoordinator"
(
  "TransferTaskCoordinatorID",
  "TransferTaskCoordinatorVersionNumber",
  "Name",
  "TransferTaskID",
  "TransferOrchestratorID",
  "TransferOrchestratorVersionNumber"
)
VALUES (
  CoordinatorID,
  1,
  'Process Search for Sira Coordinator',
  TransferTaskID,
  OrchestratorID,
  1
);

-- Coordinator Links
INSERT INTO
  public."TransferTaskCoordinatorSource"
(
  "TransferTaskCoordinatorID",
  "TransferTaskCoordinatorVersionNumber",
  "TransferConnectionID",
  "TransferConnectionVersionNumber"
)
VALUES (
  CoordinatorID,
  1,
  SourceConnectionID,
  1
);

INSERT INTO
  public."TransferTaskCoordinatorDestination"
(
  "TransferTaskCoordinatorID",
  "TransferTaskCoordinatorVersionNumber",
  "TransferConnectionID",
  "TransferConnectionVersionNumber"
)
VALUES (
  CoordinatorID,
  1,
  DestinationConnectionID,
  1
);



END $$;

-- link to Transfer Interface Step

UPDATE
  public."TransferInterfaceStep"
SET
  "TransferTaskCoordinatorID" = (select "TransferTaskCoordinatorID" from "TransferTaskCoordinator" where "Name" =  'Process Search for Sira' limit 1),
  "TransferTaskCoordinatorVersionNumber" = (select "TransferTaskCoordinatorVersionNumber" from "TransferTaskCoordinator" where "Name" =  'Process Search for Sira' limit 1),
  "TransferInterfaceID" = (select "TransferInterfaceID" from "TransferInterface" where "Name" = 'STStoSiraBatchProcess' limit 1)
WHERE
	"Name" = 'ProcessSearchForSiraBatch'
;


