
DO $$
Declare ServiceInterfaceProcessLogStatusID uuid;
Begin

-- base templates
INSERT INTO
  public."StatusTypeTemplate"("StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES
  (1, 'Bus Message Process Log Status', 'Bus Message Process Log Status', true, false);

ServiceInterfaceProcessLogStatusID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Bus Message Process Log Status');


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
  'Pending',
  'Pending'
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
  'Sent',
  'Sent'
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
  'Received',
  'Received'
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
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ServiceInterfaceProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Pending' limit 1),
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
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ServiceInterfaceProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Sent' limit 1),
  0,
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
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ServiceInterfaceProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Received' limit 1),
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
  true,
  false
);


END $$;


-- BusTaskScheduleProcessLog


DO $$
Declare ServiceInterfaceProcessLogStatusID uuid;
Begin

-- base templates
INSERT INTO
  public."StatusTypeTemplate"("StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES
  (1, 'Bus Task Schedule Process Log Status', 'Bus Task Schedule Process Log Status', true, false);

ServiceInterfaceProcessLogStatusID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Bus Task Schedule Process Log Status');


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
  'Pending',
  'Pending'
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
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ServiceInterfaceProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Pending' limit 1),
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
  true,
  false
);


END $$;


-- ProductPurchaseBusTaskProcessLog


DO $$
Declare ServiceInterfaceProcessLogStatusID uuid;
Begin

-- base templates
INSERT INTO
  public."StatusTypeTemplate"("StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES
  (1, 'Product Purchase Bus Task Process Log Status', 'Product Purchase Bus Task Process Log Status', true, false);

ServiceInterfaceProcessLogStatusID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Product Purchase Bus Task Process Log Status');


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
  'Pending',
  'Pending'
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
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ServiceInterfaceProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Pending' limit 1),
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
  true,
  false
);


END $$;

DO $$
Declare ServiceInterfaceProcessLogStatusID uuid;
Declare ServiceInterfaceProcessLogStatusVersionNumber int;
Begin
ServiceInterfaceProcessLogStatusID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Bus Message Process Log Status');
ServiceInterfaceProcessLogStatusVersionNumber := (select "StatusTypeTemplateVersionNumber" from "StatusTypeTemplate" where "Name" = 'Bus Message Process Log Status');

perform public."fn_PromoteStatusTypeTemplate"(ServiceInterfaceProcessLogStatusID, ServiceInterfaceProcessLogStatusVersionNumber);


end $$;


DO $$
Declare ServiceInterfaceProcessLogStatusID uuid;
Declare ServiceInterfaceProcessLogStatusVersionNumber int;
Begin
ServiceInterfaceProcessLogStatusID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Bus Task Schedule Process Log Status');
ServiceInterfaceProcessLogStatusVersionNumber := (select "StatusTypeTemplateVersionNumber" from "StatusTypeTemplate" where "Name" = 'Bus Task Schedule Process Log Status');

perform public."fn_PromoteStatusTypeTemplate"(ServiceInterfaceProcessLogStatusID, ServiceInterfaceProcessLogStatusVersionNumber);


end $$;

DO $$
Declare ServiceInterfaceProcessLogStatusID uuid;
Declare ServiceInterfaceProcessLogStatusVersionNumber int;
Begin
ServiceInterfaceProcessLogStatusID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Product Purchase Bus Task Process Log Status');
ServiceInterfaceProcessLogStatusVersionNumber := (select "StatusTypeTemplateVersionNumber" from "StatusTypeTemplate" where "Name" = 'Product Purchase Bus Task Process Log Status');

perform public."fn_PromoteStatusTypeTemplate"(ServiceInterfaceProcessLogStatusID, ServiceInterfaceProcessLogStatusVersionNumber);


end $$;