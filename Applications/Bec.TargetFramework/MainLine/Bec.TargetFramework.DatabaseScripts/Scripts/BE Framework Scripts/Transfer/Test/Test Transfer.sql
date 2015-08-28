DO $$
Declare TransferTaskID uuid;
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
  'Test Transfer',
  false,
  1000000002,
  1000000101
);

-- Handlers
INSERT INTO public."TransferHandler"("TransferHandlerID",
  "TransferHandlerVersionNumber", "Name", "HandlerTypeName",
  "HandlerTypeAssemblyName")
VALUES ('eddf95f4-f4bd-11e4-8142-00155d0a1426', 1, 'Test Orchestrator Handler','Bec.TargetFramework.Transfer.Infrastructure.Orchestrators.DefaultOrchestrator',
  'Bec.TargetFramework.Transfer.Infrastructure');

INSERT INTO public."TransferHandler"("TransferHandlerID",
  "TransferHandlerVersionNumber", "Name", "HandlerTypeName",
  "HandlerTypeAssemblyName")
VALUES ('eddf95f5-f4bd-11e4-8143-00155d0a1426', 1, 'Test Source Connection Handler','Bec.TargetFramework.Transfer.FTP.Connections.SftpConnection',
  'Bec.TargetFramework.Transfer.FTP');

INSERT INTO public."TransferHandler"("TransferHandlerID",
  "TransferHandlerVersionNumber", "Name", "HandlerTypeName",
  "HandlerTypeAssemblyName")
VALUES ('eddf95f6-f4bd-11e4-8144-00155d0a1426', 1, 'Test Destination Connection Handler','Bec.TargetFramework.Transfer.FTP.Connections.SftpConnection',
  'Bec.TargetFramework.Transfer.FTP');

-- FileFolder
INSERT INTO public."TransferFolderFile"("TransferFolderFileID", "Name",
  "FolderPath", "TransferFolderFileVersionNumber", "IsAbsolutePath",
  "FileExtension", "FileName")
VALUES ('eddf95f9-f4bd-11e4-8147-00155d0a1426','Test Source File','Test', 1,
  true,'.txt','TestSource');

INSERT INTO public."TransferFolderFile"("TransferFolderFileID", "Name",
  "FolderPath", "TransferFolderFileVersionNumber", "IsAbsolutePath",
  "FileExtension", "FileName")
VALUES ('eddf95fc-f4bd-11e4-814a-00155d0a1426','Test Destination File','Test', 1,
  true,'.txt','TestDestination');

-- Connection
INSERT INTO public."TransferConnection"("TransferConnectionID", "Name",
  "HostAddress", "Username", "Password", "Port", "IsAutoResume",
  "TimeoutInSeconds", "NumberOfRetries", "TransferConnectionVersionNumber",
  "TransferConnectionTypeID", "TransferFolderFileID",
  "TransferFolderFileVersionNumber", "TransferHandlerID",
  "TransferHandlerVersionNumber")
VALUES ('eddf95f7-f4bd-11e4-8145-00155d0a1426', 'Source SFTP Connection',
  '192.168.10.181','test','test',21, true, 60, 1, 1, 5000101,
  'eddf95f9-f4bd-11e4-8147-00155d0a1426',1,'eddf95f5-f4bd-11e4-8143-00155d0a1426',
  1);

INSERT INTO public."TransferConnection"("TransferConnectionID", "Name",
  "HostAddress", "Username", "Password", "Port", "IsAutoResume",
  "TimeoutInSeconds", "NumberOfRetries", "TransferConnectionVersionNumber",
  "TransferConnectionTypeID", "TransferFolderFileID",
  "TransferFolderFileVersionNumber", "TransferHandlerID",
  "TransferHandlerVersionNumber")
VALUES ('eddf95f8-f4bd-11e4-8146-00155d0a1426', 'Destination SFTP Connection',
  '192.168.10.191','test','test',21, true, 60, 1, 1, 5000101,
  'eddf95fc-f4bd-11e4-814a-00155d0a1426',1,'eddf95f6-f4bd-11e4-8144-00155d0a1426',
  1);

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
  'eddf95fa-f4bd-11e4-8148-00155d0a1426',
  1,
  'Test Orchestrator',
  'eddf95f4-f4bd-11e4-8142-00155d0a1426',
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
  'eddf95fb-f4bd-11e4-8149-00155d0a1426',
  1,
  'Test Coordinator',
  TransferTaskID,
  'eddf95fa-f4bd-11e4-8148-00155d0a1426',
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
   'eddf95fb-f4bd-11e4-8149-00155d0a1426',
  1,
  'eddf95f7-f4bd-11e4-8145-00155d0a1426',
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
    'eddf95fb-f4bd-11e4-8149-00155d0a1426',
  1,
  'eddf95f8-f4bd-11e4-8146-00155d0a1426',
  1
);



END $$;
