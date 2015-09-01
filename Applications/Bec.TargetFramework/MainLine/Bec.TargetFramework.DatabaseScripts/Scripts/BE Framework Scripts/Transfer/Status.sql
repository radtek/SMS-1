﻿DO $$
Declare ServiceInterfaceProcessLogStatusID uuid;
Begin

-- base templates
INSERT INTO
  public."StatusTypeTemplate"("StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES
  (1, 'Transfer Task Coordinator Status', 'Transfer Task Coordinator Status', true, false);

ServiceInterfaceProcessLogStatusID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Transfer Task Coordinator Status');


-- add values USER
INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  ServiceInterfaceProcessLogStatusID,
  1,
  'Initialized',
  'Initialized'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  ServiceInterfaceProcessLogStatusID,
  1,
  'Processing',
  'Processing'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  ServiceInterfaceProcessLogStatusID,
  1,
  'Failed',
  'Failed'
);


INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  ServiceInterfaceProcessLogStatusID,
  1,
  'Successful',
  'Successful'
);

--- structures

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  ServiceInterfaceProcessLogStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ServiceInterfaceProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Initialized' limit 1),
  0,
  true,
  false
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  ServiceInterfaceProcessLogStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ServiceInterfaceProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Processing' limit 1),
  1,
  false,
  false
);


INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  ServiceInterfaceProcessLogStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ServiceInterfaceProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Failed' limit 1),
  2,
  false,
  true
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  ServiceInterfaceProcessLogStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ServiceInterfaceProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Successful' limit 1),
  3,
  false,
  true
);


END $$;