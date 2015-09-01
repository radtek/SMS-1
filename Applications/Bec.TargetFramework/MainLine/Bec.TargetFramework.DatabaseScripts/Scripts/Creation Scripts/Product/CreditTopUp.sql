﻿-- Credit Top Up

DO $$
Declare BecID uuid;
Declare OrganisationTypeID integer;
Declare TProductID uuid;
Declare TProductVersion integer;
Declare TPlanID uuid;
Declare TPlanVersion integer;
Declare TPTID uuid;
Declare LoopRow Record;
Declare TProductBusTaskTemplateID uuid;
Declare TBusTaskID uuid;
Declare TBusTaskHandlerID uuid;
Declare TBusTaskHandlerVersionNumber integer;
Begin

-- declare variables
OrganisationTypeID := (select "OrganisationTypeID" from "OrganisationType" where "Name" = 'Administration' limit 1);
BecID := (select v."OrganisationID" from "vOrganisation" v  where v."OrganisationTypeID" = OrganisationTypeID and v."Name" = 'BE Consultancy Ltd' limit 1);

-- create products


------------- Seller Fraud Insurance
TProductID := (select uuid_generate_v1());
TProductVersion = 1;

INSERT INTO
  public."ProductTemplate"
(
  "ProductTemplateID",
  "IsActive",
  "IsDeleted",
  "IsPackage",
  "ProductVersionID",
  "ParentID",
  "OwnerOrganisationID",
  "IsDefaultTemplate",
  "CanBeResold",
  "IsDeductionProduct"
)
VALUES (
  TProductID,
  true,
  false,
  false,
  TProductVersion,
  BecID,
  BecID,
  false,
  true,
  false
);

--product detail template
INSERT INTO
  public."ProductDetailTemplate"
(
  "ProductTemplateID",
  "Name",
  "Description",
  "IsActive",
  "IsDeleted",
  "Price",
  "ProductCost",
  "CustomerEntersPrice",
  "HasTierPrices",
  "HasDiscountsApplied",
  "DisplayOrder",
  "ProductTypeID",
  "ProductVersionID",
  "CurrencyCode",
  "CurrencyRate",
  "InvoiceName",
  "IsDepositProduct"
)
VALUES (
  TProductID,
  'Credit Top Up',
  '',
  true,
  false,
  0,
  0,
  true,
  false,
  false,
  0,
  (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Supplier Product' and "ClassificationTypeCategoryID" = 110 limit 1),
  TProductVersion,
  'GBP',
  1,
  'Credit Top Up',
  false
);

TBusTaskID := E'b43f6a43-edc1-11e4-8341-00155d0a1426';

--product bus task template

insert into public."ProductBusTaskTemplate"(
  "ProductTemplateID",
  "ProductVersionID",
  "BusTaskID"
)
values(
  TProductID,
  TProductVersion,
  TBusTaskID
);

END $$;