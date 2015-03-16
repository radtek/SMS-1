-- DUAL Hijack Insurance

-- Base Price £10
-- Deductions 6% IPT
-- Supplier - DUAL
-- Cannot be sold separately


DO $$
Declare LandRegistryID uuid;
Declare OrganisationTypeID integer;
Declare DoTemplateID uuid;
Declare DoVersionNumber integer;
Declare TProductID uuid;
Declare TProductVersion integer;
Declare TPlanID uuid;
Declare TPlanVersion integer;
Declare TPTID uuid;
Declare LoopRow Record;
Declare BillingTemplateID uuid;
Begin

-- declare variables
OrganisationTypeID := (select "OrganisationTypeID" from "OrganisationType" where "Name" = 'Supplier' limit 1);

DoTemplateID:= (select dot."DefaultOrganisationID" from "DefaultOrganisation" dot where dot."Name" = 'Supplier' and dot."IsActive" = true and dot."IsDeleted" = false order by dot."DefaultOrganisationVersionNumber" desc limit 1);

DoVersionNumber:= (select dot."DefaultOrganisationVersionNumber" from "DefaultOrganisation" dot where dot."Name" = 'Supplier' and dot."IsActive" = true and dot."IsDeleted" = false order by dot."DefaultOrganisationVersionNumber" desc limit 1);

LandRegistryID := (select v."OrganisationID" from "vOrganisation" v  where v."OrganisationTypeID" = OrganisationTypeID and v."Name" = 'DUAL Insurance' limit 1);

BillingTemplateID := (select uuid_generate_v1());

if(LandRegistryID is null)
THEN
BEGIN

LandRegistryID := ( SELECT * FROM public."fn_CreateOrganisationFromDefault"(OrganisationTypeID, DoTemplateID, DoVersionNumber,'DUAL Insurance','DUAL Insurance'));

END;
END IF;

-- create products


------------- Seller Fraud Insurance
TProductID := (select uuid_generate_v1());
TProductVersion = 1;
TPlanID := (select uuid_generate_v1());
TPlanVersion = 1;

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
  LandRegistryID,
  LandRegistryID,
  false,
  true,
  false
);

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
  'DUAL Hijack Insurance',
  '',
  true,
  false,
  10,
  10,
  false,
  true,
  false,
  0,
  (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Supplier Product' and "ClassificationTypeCategoryID" = 110 limit 1),
  TProductVersion,
  'GBP',
  1,
  'DUAL Hijack Insurance',
  false
);

-- plan
INSERT INTO
  public."PlanTemplate"
(
  "PlanTemplateID",
  "PlanTemplateVersionNumber",
  "Name",
  "Description",
  "InvoiceName",
  "Price",
  "Period",
  "TrialPeriod",
  "PeriodUnitID",
  "TrialPeriodUnitID",
  "FreeQuantity",
  "SetupCost",
  "DowngradePenalty",
  "CreatedOn",
  "CreatedBy",
  "IsActive",
  "IsDeleted",
  "CountryCode",
  "CurrencyCode",
  "CancellationPeriod",
  "CancellationPeriodUnitID",
  "IsFree",
  "HasInfinitePeriods",
  "ParentID",
  "PlanStatusID",
  "IsTransactionBased",
  "PlanGroupID",
  "PlanCategoryID"
)
VALUES (
  TPlanID,
  TPlanVersion,
  'DUAL Insurance Invoice Plan',
  '',
  'DUAL Insurance Invoice Plan',
  0,
  12,
  0,
  (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Month' and "ClassificationTypeCategoryID" = 8006 limit 1),
  (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Month' and "ClassificationTypeCategoryID" = 8006 limit 1),
  0,
  0,
  0,
  CURRENT_DATE,
  'System',
  true,
  false,
  'UK',
  'GBP',
  12,
  (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Month' and "ClassificationTypeCategoryID" = 8006 limit 1),
  false,
  false,
  LandRegistryID,
  (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Active' and "ClassificationTypeCategoryID" = 8007 limit 1),
  false,
  (select "PlanGroupID" from "PlanGroup" where "Name" = 'Supplier Plans' limit 1),
  0
);

-- plan product
INSERT INTO
  public."PlanProductTemplate"
(
  "PlanTemplateID",
  "PlanTemplateVersionNumber",
  "ProductTemplateID",
  "ProductVersionID",
  "Period",
  "PeriodUnitID",
  "IsActive",
  "IsDeleted"
)
VALUES (
  TPlanID,
  TPlanVersion,
  TProductID,
  TProductVersion,
  1,
   (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Month' and "ClassificationTypeCategoryID" = 8006 limit 1),
  true,
  false
);

-- transaction and billing info
INSERT INTO
  public."PlanTransactionTemplate"
(
  "PlanTemplateID",
  "PlanTemplateVersionNumber",
  "ProductTemplateID",
  "ProductVersionID",
  "IsTotalValuePricingBound",
  "IsTransactionCountPricingBound",
  "IsActive",
  "IsDeleted",
  "ApplyTransactionTierPricingPerTransaction"
)
VALUES (
  TPlanID,
  TPlanVersion,
  TProductID,
  TProductVersion,
  false,
  false,
  false,
  false,
  false
);

TPTID := (select pt."PlanTransactionTemplateID" from "PlanTransactionTemplate" pt
	where pt."PlanTemplateID" = TPlanID and pt."PlanTemplateVersionNumber" = TPlanVersion
    and pt."ProductTemplateID" = TProductID and pt."ProductVersionID" = TProductVersion limit 1);

-- need to create billing
INSERT INTO
  public."BillingTemplate"
(
  "BillingTemplateID",
  "BillingPeriod",
  "BillingPeriodUnitID",
  "ParentID",
  "BillingLagPeriod",
  "BillingLagPeriodUnitID"
)
VALUES (
  BillingTemplateID,
  1,
   (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Month' and "ClassificationTypeCategoryID" = 8006 limit 1),
  LandRegistryID,
  0,
   (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Month' and "ClassificationTypeCategoryID" = 8006 limit 1)
);

INSERT INTO
  public."PlanBillingTemplate"
(
  "PlanTemplateID",
  "PlanTemplateVersionNumber",
  "BillingTemplateID",
  "IsActive",
  "IsDeleted",
  "IsDefaultBilling"
)
VALUES (
  TPlanID,
  TPlanVersion,
  BillingTemplateID,
  true,
 false,
  true
);


END $$;