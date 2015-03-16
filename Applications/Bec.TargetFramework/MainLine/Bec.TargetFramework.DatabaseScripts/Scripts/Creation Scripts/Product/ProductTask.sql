
DO $$
Declare ProductPurchaseTask uuid;
Declare ProductPurchase uuid;
Declare ExperianKYCProductID uuid;
Declare ExperianKYCProductVersionNumber integer;
Declare ExperianBankProductID uuid;
Declare ExperianBankProductVersionNumber integer;
Declare FirstDataProductID uuid;
Declare FirstDataProductVersionNumber integer;
Declare LandRegistryProductID uuid;
Declare LandRegistryProductVersionNumber integer;
Declare InsuranceProductID uuid;
Declare InsuranceProductVersionNumber integer;
Begin

-- base templates
INSERT INTO
  public."StatusTypeTemplate"("StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES
  (1, 'ProductPurchaseTask Status', 'ProductPurchaseTask Status', true, false);

ProductPurchaseTask := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'ProductPurchaseTask Status');

INSERT INTO
  public."StatusTypeTemplate"("StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES
  (1, 'ProductPurchase Status', 'ProductPurchase Status', true, false);

ProductPurchase := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'ProductPurchase Status');

-- Invoice
INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  ProductPurchaseTask,
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
  ProductPurchaseTask,
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
  ProductPurchaseTask,
  1,
  'Failed',
  'Failed'
);


-- ProductPurchase
INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  ProductPurchase,
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
  ProductPurchase,
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
  ProductPurchase,
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
  ProductPurchase,
  1,
  'Failed',
  'Failed'
);

-- ProductPurchaseTask

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
  ProductPurchaseTask,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ProductPurchaseTask and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Pending' limit 1),
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
  ProductPurchaseTask,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ProductPurchaseTask and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Successful' limit 1),
  1,
  false,
  TRUE
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
  ProductPurchaseTask,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ProductPurchaseTask and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Failed' limit 1),
  2,
  false,
  TRUE
);

-- ProductPurchase
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
  ProductPurchase,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ProductPurchase and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Pending' limit 1),
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
  ProductPurchase,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ProductPurchase and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Processing' limit 1),
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
  ProductPurchase,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ProductPurchase and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Successful' limit 1),
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
  ProductPurchase,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ProductPurchase and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Failed' limit 1),
  3,
  false,
  true
);

-- promote st's
perform "fn_PromoteStatusTypeTemplate"(ProductPurchaseTask,1);
perform "fn_PromoteStatusTypeTemplate"(ProductPurchase,1);


-- create tasks
INSERT INTO
  public."ProductTask"
(
  "Name",
  "Description",
  "IsActive",
  "IsDeleted",
  "ProductTaskTypeID",
  "ObjectName",
  "ObjectAssembly",
  "HandlerMessageTypeName",
  "HandlerMessageTypeAssembly",
  "IsHandlerBasedTask"
)
VALUES (
  'Experian KYC ProveID Task',
  'Experian KYC ProveID Task',
  true,
  false,
  2000000,
  null,
  null,
  '',
  '',
  true
);

INSERT INTO
  public."ProductTask"
(
  "Name",
  "Description",
  "IsActive",
  "IsDeleted",
  "ProductTaskTypeID",
  "ObjectName",
  "ObjectAssembly",
  "HandlerMessageTypeName",
  "HandlerMessageTypeAssembly",
  "IsHandlerBasedTask"
)
VALUES (
  'Experian Bank Wizard Individual Task',
  'Experian Bank Wizard Individual Task',
  true,
  false,
  2000000,
  null,
  null,
  '',
  '',
  true
);

-- add to experian products

ExperianKYCProductID := (select "ProductTemplateID" from "ProductDetailTemplate" where "Name" = 'Experian Prove ID KYC UK Individual' and "IsActive" = true order by "ProductVersionID" desc limit 1);
ExperianKYCProductVersionNumber := (select "ProductVersionID" from "ProductDetailTemplate" where "Name" = 'Experian Prove ID KYC UK Individual' and "IsActive" = true order by "ProductVersionID" desc limit 1);
ExperianBankProductID := (select "ProductTemplateID" from "ProductDetailTemplate" where "Name" = 'Experian Bank Wizard UK Individual' and "IsActive" = true order by "ProductVersionID" desc limit 1);
ExperianBankProductVersionNumber := (select "ProductVersionID" from "ProductDetailTemplate" where "Name" = 'Experian Bank Wizard UK Individual' and "IsActive" = true order by "ProductVersionID" desc limit 1);
FirstDataProductID := (select "ProductTemplateID" from "ProductDetailTemplate" where "Name" = 'Firstdata Processing Fee' and "IsActive" = true order by "ProductVersionID" desc limit 1);
FirstDataProductVersionNumber := (select "ProductVersionID" from "ProductDetailTemplate" where "Name" = 'Firstdata Processing Fee' and "IsActive" = true order by "ProductVersionID" desc limit 1);
LandRegistryProductID := (select "ProductTemplateID" from "ProductDetailTemplate" where "Name" = 'OC1/2 Official Copies' and "IsActive" = true order by "ProductVersionID" desc limit 1);
LandRegistryProductVersionNumber := (select "ProductVersionID" from "ProductDetailTemplate" where "Name" = 'OC1/2 Official Copies' and "IsActive" = true order by "ProductVersionID" desc limit 1);
InsuranceProductID := (select "ProductTemplateID" from "ProductDetailTemplate" where "Name" = 'DUAL Hijack Insurance' and "IsActive" = true order by "ProductVersionID" desc limit 1);
InsuranceProductVersionNumber := (select "ProductVersionID" from "ProductDetailTemplate" where "Name" = 'DUAL Hijack Insurance' and "IsActive" = true order by "ProductVersionID" desc limit 1);

-- create product product task templates etc
INSERT INTO
  public."ProductProductTaskTemplate"
(
  "ProductTemplateID",
  "ProductVersionID",
  "ProductTaskID"
)
VALUES (
  ExperianKYCProductID,
  ExperianKYCProductVersionNumber,
  (select "ProductTaskID" from "ProductTask" where "Name" = 'Experian KYC ProveID Task' limit 1)
);

INSERT INTO
  public."ProductProductTask"
(
  "ProductTaskID",
  "ProductID",
  "ProductVersionID"
)
VALUES (
  (select "ProductTaskID" from "ProductTask" where "Name" = 'Experian KYC ProveID Task' limit 1),
  (select "ProductID" from "Product" where "ProductTemplateID" = ExperianKYCProductID and "ProductVersionID" = ExperianKYCProductVersionNumber limit 1),
  (select "ProductVersionID"  from "Product" where "ProductTemplateID" = ExperianKYCProductID and "ProductVersionID" = ExperianKYCProductVersionNumber limit 1)
);

INSERT INTO
  public."ProductProductTaskTemplate"
(
  "ProductTemplateID",
  "ProductVersionID",
  "ProductTaskID"
)
VALUES (
  ExperianBankProductID,
  ExperianBankProductVersionNumber,
  (select "ProductTaskID" from "ProductTask" where "Name" = 'Experian Bank Wizard Individual Task' limit 1)
);

INSERT INTO
  public."ProductProductTask"
(
  "ProductTaskID",
  "ProductID",
  "ProductVersionID"
)
VALUES (
  (select "ProductTaskID" from "ProductTask" where "Name" = 'Experian Bank Wizard Individual Task' limit 1),
  (select "ProductID" from "Product" where "ProductTemplateID" = ExperianBankProductID and "ProductVersionID" = ExperianBankProductVersionNumber limit 1),
  (select "ProductVersionID"  from "Product" where "ProductTemplateID" = ExperianBankProductID and "ProductVersionID" = ExperianBankProductVersionNumber limit 1)
);

END $$;