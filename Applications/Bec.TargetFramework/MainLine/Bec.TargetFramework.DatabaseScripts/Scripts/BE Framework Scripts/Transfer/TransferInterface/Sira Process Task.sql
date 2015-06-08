
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



-- Process Search Transfer Task
DO $$
Declare TransferMutatorID uuid;
Declare TransferTaskID uuid;
Declare HandlerOneID uuid;
Declare HandlerTwoID uuid;
Declare HandlerThreeID uuid;

Declare MutatorHandlerOneID uuid;
Declare MutatorHandlerTwoID uuid;
Declare MutatorHandlerThreeID uuid;


Declare OrchestratorID uuid;
Declare CoordinatorID uuid;

Begin

TransferTaskID := (select "TransferTaskID" from "TransferTask" where "Name" = 'ProcessSearchForSiraBatch' limit 1);

CoordinatorID := (select "TransferTaskCoordinatorID" from "TransferTaskCoordinator" ttc where ttc."TransferTaskID" =TransferTaskID
	 limit 1);

HandlerOneID  := (select uuid_generate_v1());
HandlerTwoID := (select uuid_generate_v1());
HandlerThreeID := (select uuid_generate_v1());
MutatorHandlerOneID  := (select uuid_generate_v1());
MutatorHandlerTwoID := (select uuid_generate_v1());
MutatorHandlerThreeID := (select uuid_generate_v1());

-- Mutation Handlers
INSERT INTO public."TransferHandler"("TransferHandlerID",
  "TransferHandlerVersionNumber", "Name", "HandlerTypeName",
  "HandlerTypeAssemblyName")
VALUES (HandlerOneID, 1, 'AddApplicationHandlerMock','Bec.TargetFramework.Transfer.ProcessTest.Handlers.AddApplicationHandlerMock',
  'Bec.TargetFramework.Transfer.ProcessTest');

INSERT INTO public."TransferHandler"("TransferHandlerID",
  "TransferHandlerVersionNumber", "Name", "HandlerTypeName",
  "HandlerTypeAssemblyName")
VALUES (HandlerTwoID, 1, 'AddOtherPartiesHandlerMock','Bec.TargetFramework.Transfer.ProcessTest.Handlers.AddOtherPartiesHandlerMock',
  'Bec.TargetFramework.Transfer.ProcessTest');

INSERT INTO public."TransferHandler"("TransferHandlerID",
  "TransferHandlerVersionNumber", "Name", "HandlerTypeName",
  "HandlerTypeAssemblyName")
VALUES (HandlerThreeID, 1, 'AddPartyAlertsHandlerMock','Bec.TargetFramework.Transfer.ProcessTest.Handlers.AddPartyAlertsHandlerMock',
  'Bec.TargetFramework.Transfer.ProcessTest');

-- muatation insert
INSERT INTO public."TransferMutator"("TransferMutatorID",
  "TransferMutatorVersionNumber", "Name", "TransferHandlerID",
  "TransferHandlerVersionNumber")
VALUES (MutatorHandlerOneID, 1, 'AddApplicationHandlerMock', HandlerOneID, 1);

INSERT INTO public."TransferMutator"("TransferMutatorID",
  "TransferMutatorVersionNumber", "Name", "TransferHandlerID",
  "TransferHandlerVersionNumber")
VALUES (MutatorHandlerTwoID, 1, 'AddOtherPartiesHandlerMock', HandlerTwoID, 1);

INSERT INTO public."TransferMutator"("TransferMutatorID",
  "TransferMutatorVersionNumber", "Name", "TransferHandlerID",
  "TransferHandlerVersionNumber")
VALUES (MutatorHandlerThreeID, 1, 'AddPartyAlertsHandlerMock', HandlerThreeID, 1);

-- link to co-ordinator
INSERT INTO
  public."TransferTaskCoordinatorMutator"
(
  "TransferTaskCoordinatorID",
  "TransferTaskCoordinatorVersionNumber",
  "IsStart",
  "IsEnd",
  "TransferMutatorID",
  "TransferMutatorVersionNumber",
  "Order"
)
VALUES (
  CoordinatorID,
  1,
  true,
  false,
  MutatorHandlerTwoID,
  1,
  0
);

INSERT INTO
  public."TransferTaskCoordinatorMutator"
(
  "TransferTaskCoordinatorID",
  "TransferTaskCoordinatorVersionNumber",
  "IsStart",
  "IsEnd",
  "TransferMutatorID",
  "TransferMutatorVersionNumber",
  "Order"
)
VALUES (
  CoordinatorID,
  1,
  true,
  false,
  MutatorHandlerThreeID,
  1,
  1
);

INSERT INTO
  public."TransferTaskCoordinatorMutator"
(
  "TransferTaskCoordinatorID",
  "TransferTaskCoordinatorVersionNumber",
  "IsStart",
  "IsEnd",
  "TransferMutatorID",
  "TransferMutatorVersionNumber",
  "Order"
)
VALUES (
  CoordinatorID,
  1,
  true,
  false,
  MutatorHandlerOneID,
  1,
  2
);

END $$;