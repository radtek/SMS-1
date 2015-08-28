



---------- Types


INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (40000000,'TransferInterfaceTypeID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (40000001,'Sira','',40000000,true,false);

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (40000100,'LenderName');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (40000101,'Paragon','',40000100,true,false);

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (40000200,'LenderDomainName');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (40000201,'PARA','',40000200,true,false);


------------



--------------------------
--- Interface Status
--------------------------





DO $$
Declare ServiceInterfaceProcessLogStatusID uuid;
Begin

-- base templates
INSERT INTO
  public."StatusTypeTemplate"("StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES
  (1, 'Transfer Interface Status', 'Transfer Interface Status', true, false);

ServiceInterfaceProcessLogStatusID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Transfer Interface Status');


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



-----------------------
-- Interface Step

DO $$
Declare ServiceInterfaceProcessLogStatusID uuid;
Begin

-- base templates
INSERT INTO
  public."StatusTypeTemplate"("StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES
  (1, 'Transfer Interface Step Status', 'Transfer Interface Step Status', true, false);

ServiceInterfaceProcessLogStatusID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Transfer Interface Step Status');


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


-------------------------

-----------------------
-- Interface Step

DO $$
Declare ServiceInterfaceProcessLogStatusID uuid;
Begin

-- base templates
INSERT INTO
  public."StatusTypeTemplate"("StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES
  (1, 'Transfer Interface Input Status', 'Transfer Interface Input Status', true, false);

ServiceInterfaceProcessLogStatusID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Transfer Interface Input Status');


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
  'Failed Mutation',
  'Failed Mutation'
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
  'Successful Mutation',
  'Successful Mutation'
);

--- new

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
  'Successful Inclusion in Batch',
  'Successful Inclusion in Batch'
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
  'Failed Inclusion in Batch',
  'Failed Inclusion in Batch'
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
  'Successful Processing',
  'Successful Processing'
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
  'Failed Processing',
  'Failed Processing'
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
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ServiceInterfaceProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Failed Mutation' limit 1),
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
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ServiceInterfaceProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Successful Mutation' limit 1),
  3,
  false,
  false
);

-- new

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
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ServiceInterfaceProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Successful Inclusion in Batch' limit 1),
  4,
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
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ServiceInterfaceProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Failed Inclusion in Batch' limit 1),
  5,
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
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ServiceInterfaceProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Successful Processing' limit 1),
  6,
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
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ServiceInterfaceProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Successful Processing' limit 1),
  7,
  false,
  false
);

END $$;

