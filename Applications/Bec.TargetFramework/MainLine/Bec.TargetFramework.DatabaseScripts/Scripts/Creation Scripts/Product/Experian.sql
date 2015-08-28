-- Experian
-- KYC
-- Bank Wizard



DO $$
Declare ExperianID uuid;
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

BillingTemplateID := (select uuid_generate_v1());

-- declare variables
OrganisationTypeID := (select "OrganisationTypeID" from "OrganisationType" where "Name" = 'Supplier' limit 1);

DoTemplateID:= (select dot."DefaultOrganisationID" from "DefaultOrganisation" dot where dot."Name" = 'Supplier' and dot."IsActive" = true and dot."IsDeleted" = false order by dot."DefaultOrganisationVersionNumber" desc limit 1);

DoVersionNumber:= (select dot."DefaultOrganisationVersionNumber" from "DefaultOrganisation" dot where dot."Name" = 'Supplier' and dot."IsActive" = true and dot."IsDeleted" = false order by dot."DefaultOrganisationVersionNumber" desc limit 1);

ExperianID := (select v."OrganisationID" from "vOrganisation" v  where v."OrganisationTypeID" = OrganisationTypeID and v."Name" = 'Experian' limit 1);

if(ExperianID is null)
THEN
BEGIN

ExperianID := ( SELECT * FROM public."fn_CreateOrganisationFromDefault"(OrganisationTypeID, DoTemplateID, DoVersionNumber,'Experian','Experian'));

END;
END IF;

-- create products


------------- BANK WIZARD INDIVIDUAL - 12 MONTH 2nd Month BILLING CYCLE
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
  "CanBeResold"
)
VALUES (
  TProductID,
  true,
  false,
  false,
  TProductVersion,
  ExperianID,
  ExperianID,
  false,
  true
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
  'Experian Bank Wizard UK Individual',
  '',
  true,
  false,
  0.7,
  0.7,
  false,
  true,
  false,
  0,
  (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Supplier Product' and "ClassificationTypeCategoryID" = 110 limit 1),
  TProductVersion,
  'GBP',
  1,
  'Experian Bank Wizard UK Individual',
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
  'Experian Invoice Plan',
  '',
  'Experian Invoice Plan',
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
  ExperianID,
  (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Active' and "ClassificationTypeCategoryID" = 8007 limit 1),
  true,
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
  true,
  true,
  false,
  false
);

TPTID := (select pt."PlanTransactionTemplateID" from "PlanTransactionTemplate" pt
	where pt."PlanTemplateID" = TPlanID and pt."PlanTemplateVersionNumber" = TPlanVersion
    and pt."ProductTemplateID" = TProductID and pt."ProductVersionID" = TProductVersion limit 1);


-- add product tiers
INSERT INTO
  public."ComponentTierTemplate"
(
  "TotalValueLowerBound",
  "TotalValueUpperBound",
  "QuantityCountLowerBound",
  "QuantityCountUpperBound",
  "IsPercentageBased",
  "TierPrice",
  "TierPercentage",
  "ApplyToTotal",
  "ApplyPerTransaction",
  "Name",
  "Description",
  "Order",
  "TierOrder",
  "IsActive",
  "IsDeleted",
  "ParentID",
  "ParentVersionNumber"
)
VALUES (
  0,
  0,
  0,
  120000,
  false,
  0.70,
  0,
  false,
  true,
  'Bank Wizard Absolute Tier 1',
  '',
  0,
  0,
  true,
  false,
  TProductID,
  TProductVersion
);

-- add product tiers
INSERT INTO
  public."ComponentTierTemplate"
(
  "TotalValueLowerBound",
  "TotalValueUpperBound",
  "QuantityCountLowerBound",
  "QuantityCountUpperBound",
  "IsPercentageBased",
  "TierPrice",
  "TierPercentage",
  "ApplyToTotal",
  "ApplyPerTransaction",
  "Name",
  "Description",
  "Order",
  "TierOrder",
  "IsActive",
  "IsDeleted",
  "ParentID",
  "ParentVersionNumber"
)
VALUES (
  0,
  0,
  120001,
  240000,
  false,
  0.65,
  0,
  false,
  true,
  'Bank Wizard Absolute Tier 2',
  '',
  0,
  0,
  true,
  false,
  TProductID,
  TProductVersion
);

-- add product tiers
INSERT INTO
  public."ComponentTierTemplate"
(
  "TotalValueLowerBound",
  "TotalValueUpperBound",
  "QuantityCountLowerBound",
  "QuantityCountUpperBound",
  "IsPercentageBased",
  "TierPrice",
  "TierPercentage",
  "ApplyToTotal",
  "ApplyPerTransaction",
  "Name",
  "Description",
  "Order",
  "TierOrder",
  "IsActive",
  "IsDeleted",
  "ParentID",
  "ParentVersionNumber"
)
VALUES (
  0,
  0,
  240001,
  480000,
  false,
  0.60,
  0,
  false,
  true,
  'Bank Wizard Absolute Tier 3',
  '',
  0,
  0,
  true,
  false,
  TProductID,
  TProductVersion
);

-- add product tiers
INSERT INTO
  public."ComponentTierTemplate"
(
  "TotalValueLowerBound",
  "TotalValueUpperBound",
  "QuantityCountLowerBound",
  "QuantityCountUpperBound",
  "IsPercentageBased",
  "TierPrice",
  "TierPercentage",
  "ApplyToTotal",
  "ApplyPerTransaction",
  "Name",
  "Description",
  "Order",
  "TierOrder",
  "IsActive",
  "IsDeleted",
  "ParentID",
  "ParentVersionNumber",
  "HasNoUpperBound"
)
VALUES (
  0,
  0,
  480001,
  0,
  false,
  0.60,
  0,
  false,
  true,
  'Bank Wizard Absolute Tier 4',
  '',
  0,
  0,
  true,
  false,
  TProductID,
  TProductVersion,
  true
);

-- add product component tiers
INSERT INTO
  public."ProductComponentTierTemplate"
(
  "ProductTemplateID",
  "ProductVersionID",
  "ComponentTierTemplateID"
)
select
TProductID,
  TProductVersion,
  ctt."ComponentTierTemplateID"


from "ComponentTierTemplate" ctt

where ctt."ParentID" = TProductID and ctt."ParentVersionNumber" = TProductVersion

and not exists (select * from "ProductComponentTierTemplate" pct where pct."ComponentTierTemplateID" = ctt."ComponentTierTemplateID"
	and pct."ProductTemplateID" = TProductID and pct."ProductVersionID" = TProductVersion limit 1)

;

-- need to create billing for this experian product and link
INSERT INTO
  public."BillingTemplate"
(
  "BillingTemplateID",
  "BillingPeriod",
  "BillingPeriodUnitID",
  "BillingLagPeriod",
  "BillingLagPeriodUnitID"
)
VALUES (
	BillingTemplateID,
  2,
   (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Month' and "ClassificationTypeCategoryID" = 8006 limit 1),
  1,
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


------------- Global Gateway Prove ID KYC - 12 MONTH 2nd Month BILLING CYCLE
TProductID := (select uuid_generate_v1());
TProductVersion = 1;


BillingTemplateID :=  (select uuid_generate_v1());


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
  ExperianID,
  ExperianID,
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
  'Experian Prove ID KYC UK Individual',
  '',
  true,
  false,
  0.8,
  0.8,
  false,
  true,
  false,
  0,
   (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Supplier Product' and "ClassificationTypeCategoryID" = 110 limit 1),
  TProductVersion,
  'GBP',
  1,
  'Experian Prove ID KYC UK Individual',
  false
);

-- plan
/*INSERT INTO
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
  'Experian Prove ID KYC UK Individual Product Plan',
  '',
  'Experian Prove ID KYC UK Individual Product Plan Invoice',
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
  ExperianID,
  (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Active' and "ClassificationTypeCategoryID" = 8007 limit 1),
  true,
  (select "PlanGroupID" from "PlanGroup" where "Name" = 'Supplier Plans' limit 1),
  0
);*/

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
  "IsDeleted"
)
VALUES (
  TPlanID,
  TPlanVersion,
  TProductID,
  TProductVersion,
  false,
  true,
  true,
  false
);

TPTID := (select pt."PlanTransactionTemplateID" from "PlanTransactionTemplate" pt
	where pt."PlanTemplateID" = TPlanID and pt."PlanTemplateVersionNumber" = TPlanVersion
    and pt."ProductTemplateID" = TProductID and pt."ProductVersionID" = TProductVersion limit 1);

-- product tiers
-- add product tiers
INSERT INTO
  public."ComponentTierTemplate"
(
  "TotalValueLowerBound",
  "TotalValueUpperBound",
  "QuantityCountLowerBound",
  "QuantityCountUpperBound",
  "IsPercentageBased",
  "TierPrice",
  "TierPercentage",
  "ApplyToTotal",
  "ApplyPerTransaction",
  "Name",
  "Description",
  "Order",
  "TierOrder",
  "IsActive",
  "IsDeleted",
  "ParentID",
  "ParentVersionNumber"
)
VALUES (
  0,
  0,
  0,
  120000,
  false,
  0.80,
  0,
  false,
  true,
  'Prove ID Tier 1',
  '',
  0,
  0,
  true,
  false,
  TProductID,
  TProductVersion
);

-- add product tiers
INSERT INTO
  public."ComponentTierTemplate"
(
  "TotalValueLowerBound",
  "TotalValueUpperBound",
  "QuantityCountLowerBound",
  "QuantityCountUpperBound",
  "IsPercentageBased",
  "TierPrice",
  "TierPercentage",
  "ApplyToTotal",
  "ApplyPerTransaction",
  "Name",
  "Description",
  "Order",
  "TierOrder",
  "IsActive",
  "IsDeleted",
  "ParentID",
  "ParentVersionNumber"
)
VALUES (
  0,
  0,
  120001,
  240000,
  false,
  0.72,
  0,
  false,
  true,
  'Prove ID Tier 2',
  '',
  0,
  0,
  true,
  false,
  TProductID,
  TProductVersion
);

-- add product tiers
INSERT INTO
  public."ComponentTierTemplate"
(
  "TotalValueLowerBound",
  "TotalValueUpperBound",
  "QuantityCountLowerBound",
  "QuantityCountUpperBound",
  "IsPercentageBased",
  "TierPrice",
  "TierPercentage",
  "ApplyToTotal",
  "ApplyPerTransaction",
  "Name",
  "Description",
  "Order",
  "TierOrder",
  "IsActive",
  "IsDeleted",
  "ParentID",
  "ParentVersionNumber"
)
VALUES (
  0,
  0,
  240001,
  480000,
  false,
  0.64,
  0,
  false,
  true,
  'Prove ID Tier 3',
  '',
  0,
  0,
  true,
  false,
  TProductID,
  TProductVersion
);

-- add product tiers
INSERT INTO
  public."ComponentTierTemplate"
(
  "TotalValueLowerBound",
  "TotalValueUpperBound",
  "QuantityCountLowerBound",
  "QuantityCountUpperBound",
  "IsPercentageBased",
  "TierPrice",
  "TierPercentage",
  "ApplyToTotal",
  "ApplyPerTransaction",
  "Name",
  "Description",
  "Order",
  "TierOrder",
  "IsActive",
  "IsDeleted",
  "ParentID",
  "ParentVersionNumber",
  "HasNoUpperBound"
)
VALUES (
  0,
  0,
  480001,
  0,
  false,
  0.60,
  0,
  false,
  true,
  'Prove ID Tier 4',
  '',
  0,
  0,
  true,
  false,
  TProductID,
  TProductVersion,
  true
);

-- add product component tiers
INSERT INTO
  public."ProductComponentTierTemplate"
(
  "ProductTemplateID",
  "ProductVersionID",
  "ComponentTierTemplateID"
)
select
TProductID,
  TProductVersion,
  ctt."ComponentTierTemplateID"

from "ComponentTierTemplate" ctt

where ctt."ParentID" = TProductID and ctt."ParentVersionNumber" = TProductVersion

and not exists (select * from "ProductComponentTierTemplate" pct where pct."ComponentTierTemplateID" = ctt."ComponentTierTemplateID"
	and pct."ProductTemplateID" = TProductID and pct."ProductVersionID" = TProductVersion limit 1)

;


-- need to create billing for this experian product and link
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
  2,
   (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Month' and "ClassificationTypeCategoryID" = 8006 limit 1),
  TPlanID,
  1,
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