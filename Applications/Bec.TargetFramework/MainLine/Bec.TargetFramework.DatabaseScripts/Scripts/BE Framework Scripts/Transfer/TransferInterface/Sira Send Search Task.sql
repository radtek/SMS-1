
-- Process Search Transfer Task
DO $$
Declare TransferTaskID uuid;
Declare SendSearchForSiraBatchOrchestratorHandlerID uuid;
Declare BaseConnectionHandlerID uuid;
Declare SFTPDestinationConnectionHandlerID uuid;

Declare DestinationFileFolderID uuid;

Declare SourceConnectionID uuid;
Declare DestinationConnectionID uuid;

Declare OrchestratorID uuid;
Declare CoordinatorID uuid;
Begin

TransferTaskID := (select uuid_generate_v1());

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
  'SendSearchForSiraBatch',
  false,
  1000000002,
  1000000101
);

-- handler Ids
SendSearchForSiraBatchOrchestratorHandlerID  := (select uuid_generate_v1());

-- Handlers
INSERT INTO public."TransferHandler"("TransferHandlerID",
  "TransferHandlerVersionNumber", "Name", "HandlerTypeName",
  "HandlerTypeAssemblyName")
VALUES (SendSearchForSiraBatchOrchestratorHandlerID, 1, 'Send Search Sira Orchestrator Handler','Bec.TargetFramework.Transfer.Process.Handlers.SendSearchForSiraOrchestrator',
  'Bec.TargetFramework.Transfer.Process');

BaseConnectionHandlerID := (select uuid_generate_v1());
SFTPDestinationConnectionHandlerID  := (select uuid_generate_v1());

INSERT INTO public."TransferHandler"("TransferHandlerID",
  "TransferHandlerVersionNumber", "Name", "HandlerTypeName",
  "HandlerTypeAssemblyName")
VALUES (BaseConnectionHandlerID, 1, 'Empty Connection Handler','Bec.TargetFramework.Transfer.Infrastructure.Base.TransferConnectionBase',
  'Bec.TargetFramework.Transfer.Infrastructure');

INSERT INTO public."TransferHandler"("TransferHandlerID",
  "TransferHandlerVersionNumber", "Name", "HandlerTypeName",
  "HandlerTypeAssemblyName")
VALUES (SFTPDestinationConnectionHandlerID, 1, 'SendSearchForSira Destination Connection Handler','Bec.TargetFramework.Transfer.FTP.Connections.SftpContextDrivenConnection',
  'Bec.TargetFramework.Transfer.FTP');

-- other child
DestinationFileFolderID := (select uuid_generate_v1());

-- FileFolder
INSERT INTO public."TransferFolderFile"("TransferFolderFileID", "Name",
  "FolderPath", "TransferFolderFileVersionNumber", "IsAbsolutePath",
  "FileExtension", "FileName")
VALUES (DestinationFileFolderID,'SendSearchForSira Destination File','', 1,
  true,'.txt','TestSource');


-- connections
SourceConnectionID := (select uuid_generate_v1());
DestinationConnectionID := (select uuid_generate_v1());

-- Connection
INSERT INTO public."TransferConnection"("TransferConnectionID", "Name",
  "TransferConnectionVersionNumber",
  "TransferConnectionTypeID", "TransferHandlerID",
  "TransferHandlerVersionNumber")
VALUES (SourceConnectionID, 'SendSearchForSira Source Connection',
  1,
   5000103,BaseConnectionHandlerID,1);

INSERT INTO public."TransferConnection"("TransferConnectionID", "Name",
  "HostAddress", "Username", "Password", "Port", "IsAutoResume",
  "TimeoutInSeconds", "NumberOfRetries", "TransferConnectionVersionNumber",
  "TransferConnectionTypeID", "TransferFolderFileID",
  "TransferFolderFileVersionNumber", "TransferHandlerID",
  "TransferHandlerVersionNumber")
VALUES (DestinationConnectionID, 'SendSearchForSira Destination SFTP Connection',
  '192.168.10.141','admin','admin',22, true, 60, 1, 1, 5000101,
  DestinationFileFolderID,1,SFTPDestinationConnectionHandlerID,
  1);

-- Orchestrator

OrchestratorID := (select uuid_generate_v1());

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
  'SendSearchForSira Orchestrator',
  SendSearchForSiraBatchOrchestratorHandlerID,
  1
);

-- Coordinator

CoordinatorID := (select uuid_generate_v1());

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
  'SendSearchForSira Coordinator',
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


UPDATE
  public."TransferInterfaceStep"
SET
  "TransferTaskCoordinatorID" = (select "TransferTaskCoordinatorID" from "TransferTaskCoordinator" where "Name" =  'SendSearchForSira Coordinator' limit 1),
  "TransferTaskCoordinatorVersionNumber" = (select "TransferTaskCoordinatorVersionNumber" from "TransferTaskCoordinator" where "Name" =  'SendSearchForSira Coordinator' limit 1),
  "TransferTaskID" = (select "TransferTaskID" from "TransferTask" where "Name" = 'SendSearchForSiraBatch' limit 1)
WHERE
	"Name" = 'SendSiraBatch'
;



END $$;
