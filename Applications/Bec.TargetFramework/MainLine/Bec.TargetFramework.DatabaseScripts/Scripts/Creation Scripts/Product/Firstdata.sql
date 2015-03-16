-- Firstdata Processing Fee
-- Tiered Pricing based on Card Type for transaction, pre-auth separate cost


DO $$
Declare FirstdataID uuid;
Declare OrganisationTypeID integer;
Declare DoTemplateID uuid;
Declare DoVersionNumber integer;
Declare TProductID uuid;
Declare TProductVersion integer;
Declare TPlanID uuid;
Declare TPlanVersion integer;
Declare TPTID uuid;
Declare LoopRow Record;
Begin

-- declare variables
OrganisationTypeID := (select "OrganisationTypeID" from "OrganisationType" where "Name" = 'Supplier' limit 1);

DoTemplateID:= (select dot."DefaultOrganisationID" from "DefaultOrganisation" dot where dot."Name" = 'Supplier' and dot."IsActive" = true and dot."IsDeleted" = false order by dot."DefaultOrganisationVersionNumber" desc limit 1);

DoVersionNumber:= (select dot."DefaultOrganisationVersionNumber" from "DefaultOrganisation" dot where dot."Name" = 'Supplier' and dot."IsActive" = true and dot."IsDeleted" = false order by dot."DefaultOrganisationVersionNumber" desc limit 1);

FirstdataID := (select v."OrganisationID" from "vOrganisation" v  where v."OrganisationTypeID" = OrganisationTypeID and v."Name" = 'Firstdata' limit 1);

if(FirstdataID is null)
THEN
BEGIN

FirstdataID := ( SELECT * FROM public."fn_CreateOrganisationFromDefault"(OrganisationTypeID, DoTemplateID, DoVersionNumber,'Firstdata','Firstdata'));

END;
END IF;

-- create products


-- CARD Transactions
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
  FirstdataID,
  FirstdataID,
  false,
  true,
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
  'Firstdata Processing Fee',
  '',
  true,
  false,
  0,
  0,
  false,
  true,
  false,
  0,
  (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Supplier Product' and "ClassificationTypeCategoryID" = 110 limit 1),
  TProductVersion,
  'GBP',
  1,
  'Card Processing Fee',
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
  'Firstdata Invoice Plan',
  '',
  'Firstdata Invoice Plan',
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
  FirstdataID,
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
  false,
  true,
  false,
  false
);

TPTID := (select pt."PlanTransactionTemplateID" from "PlanTransactionTemplate" pt
	where pt."PlanTemplateID" = TPlanID and pt."PlanTemplateVersionNumber" = TPlanVersion
    and pt."ProductTemplateID" = TProductID and pt."ProductVersionID" = TProductVersion limit 1);


-- need to create billing for this firstdata product and link
INSERT INTO
  public."BillingTemplate"
(
  "BillingPeriod",
  "BillingPeriodUnitID",
  "ParentID",
  "BillingLagPeriod",
  "BillingLagPeriodUnitID"
)
VALUES (
  2,
   (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Month' and "ClassificationTypeCategoryID" = 8006 limit 1),
  FirstdataID,
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
  (select bt."BillingTemplateID" from "BillingTemplate" bt where bt."ParentID" = FirstdataID limit 1),
  true,
 false,
  true
);



-- create tiers for cards
-- Visa Credit
INSERT INTO
  public."ComponentTierTemplate"
(
  "IsPercentageBased",
  "TierPrice",
  "TierPercentage",
  "ApplyToTotal",
  "ApplyOnPaymentMethodTypeID",
  "ApplyPerTransaction",
  "Name",
  "Description",
  "Order",
  "TierOrder",
  "IsActive",
  "IsDeleted",
  "HasNoUpperBound",
  "ApplyOnPaymentCardTypeID",
  "ParentID",
  "ParentVersionNumber"
)
VALUES (
  true,
  0,
  0.014,
  true,
  (select ct."ClassificationTypeID" from "ClassificationType" ct where ct."ClassificationTypeCategoryID" = 8501 and ct."Name" = 'Credit Card' limit 1),
  true,
  'Visa Credit',
  '',
  0,
  0,
  true,
  false,
  false,
  (select ct."ClassificationTypeID" from "ClassificationType" ct where ct."ClassificationTypeCategoryID" = 9001 and ct."Name" = 'Visa Credit' limit 1),
  TProductID,
  TProductVersion
);
-- Visa Debit
INSERT INTO
  public."ComponentTierTemplate"
(
  "IsPercentageBased",
  "TierPrice",
  "TierPercentage",
  "ApplyToTotal",
  "ApplyOnPaymentMethodTypeID",
  "ApplyPerTransaction",
  "Name",
  "Description",
  "Order",
  "TierOrder",
  "IsActive",
  "IsDeleted",
  "HasNoUpperBound",
  "ApplyOnPaymentCardTypeID",
  "ParentID",
  "ParentVersionNumber"
)
VALUES (
  false,
  0.17,
  0,
  true,
  (select ct."ClassificationTypeID" from "ClassificationType" ct where ct."ClassificationTypeCategoryID" = 8501 and ct."Name" = 'Debit Card' limit 1),
  true,
  'Visa Debit',
  '',
  0,
  0,
  true,
  false,
  false,
  (select ct."ClassificationTypeID" from "ClassificationType" ct where ct."ClassificationTypeCategoryID" = 9001 and ct."Name" = 'Visa Debit' limit 1),
  TProductID,
  TProductVersion
);
-- Visa Business
INSERT INTO
  public."ComponentTierTemplate"
(
  "IsPercentageBased",
  "TierPrice",
  "TierPercentage",
  "ApplyToTotal",
  "ApplyOnPaymentMethodTypeID",
  "ApplyPerTransaction",
  "Name",
  "Description",
  "Order",
  "TierOrder",
  "IsActive",
  "IsDeleted",
  "HasNoUpperBound",
  "ApplyOnPaymentCardTypeID",
  "ParentID",
  "ParentVersionNumber"
)
VALUES (
  true,
  0,
  0.024,
  true,
  (select ct."ClassificationTypeID" from "ClassificationType" ct where ct."ClassificationTypeCategoryID" = 8501 and ct."Name" = 'Credit Card' limit 1),
  true,
  'Visa Business',
  '',
  0,
  0,
  true,
  false,
  false,
  (select ct."ClassificationTypeID" from "ClassificationType" ct where ct."ClassificationTypeCategoryID" = 9001 and ct."Name" = 'Visa Business' limit 1),
  TProductID,
  TProductVersion
);
-- Visa Business Debit
INSERT INTO
  public."ComponentTierTemplate"
(
  "IsPercentageBased",
  "TierPrice",
  "TierPercentage",
  "ApplyToTotal",
  "ApplyOnPaymentMethodTypeID",
  "ApplyPerTransaction",
  "Name",
  "Description",
  "Order",
  "TierOrder",
  "IsActive",
  "IsDeleted",
  "HasNoUpperBound",
  "ApplyOnPaymentCardTypeID",
  "ParentID",
  "ParentVersionNumber"
)
VALUES (
  false,
  0.27,
  0,
  true,
  (select ct."ClassificationTypeID" from "ClassificationType" ct where ct."ClassificationTypeCategoryID" = 8501 and ct."Name" = 'Debit Card' limit 1),
  true,
  'Visa Business Debit',
  '',
  0,
  0,
  true,
  false,
  false,
  (select ct."ClassificationTypeID" from "ClassificationType" ct where ct."ClassificationTypeCategoryID" = 9001 and ct."Name" = 'Visa Business Debit' limit 1),
  TProductID,
  TProductVersion
);
-- Visa Premium Cards
INSERT INTO
  public."ComponentTierTemplate"
(
  "IsPercentageBased",
  "TierPrice",
  "TierPercentage",
  "ApplyToTotal",
  "ApplyOnPaymentMethodTypeID",
  "ApplyPerTransaction",
  "Name",
  "Description",
  "Order",
  "TierOrder",
  "IsActive",
  "IsDeleted",
  "HasNoUpperBound",
  "ApplyOnPaymentCardTypeID",
  "ParentID",
  "ParentVersionNumber"
)
VALUES (
  true,
  0,
  0.024,
  true,
  (select ct."ClassificationTypeID" from "ClassificationType" ct where ct."ClassificationTypeCategoryID" = 8501 and ct."Name" = 'Credit Card' limit 1),
  true,
  'Visa Premium Cards',
  '',
  0,
  0,
  true,
  false,
  false,
  (select ct."ClassificationTypeID" from "ClassificationType" ct where ct."ClassificationTypeCategoryID" = 9001 and ct."Name" = 'Visa Premium Cards' limit 1),
  TProductID,
  TProductVersion
);
-- Visa UK Electron
INSERT INTO
  public."ComponentTierTemplate"
(
  "IsPercentageBased",
  "TierPrice",
  "TierPercentage",
  "ApplyToTotal",
  "ApplyOnPaymentMethodTypeID",
  "ApplyPerTransaction",
  "Name",
  "Description",
  "Order",
  "TierOrder",
  "IsActive",
  "IsDeleted",
  "HasNoUpperBound",
  "ApplyOnPaymentCardTypeID",
  "ParentID",
  "ParentVersionNumber"
)
VALUES (
  false,
  0.17,
  0,
  true,
  (select ct."ClassificationTypeID" from "ClassificationType" ct where ct."ClassificationTypeCategoryID" = 8501 and ct."Name" = 'Debit Card' limit 1),
  true,
  'Visa UK Electron',
  '',
  0,
  0,
  true,
  false,
  false,
  (select ct."ClassificationTypeID" from "ClassificationType" ct where ct."ClassificationTypeCategoryID" = 9001 and ct."Name" = 'Visa UK Electron' limit 1),
  TProductID,
  TProductVersion
);
-- MasterCard Credit
INSERT INTO
  public."ComponentTierTemplate"
(
  "IsPercentageBased",
  "TierPrice",
  "TierPercentage",
  "ApplyToTotal",
  "ApplyOnPaymentMethodTypeID",
  "ApplyPerTransaction",
  "Name",
  "Description",
  "Order",
  "TierOrder",
  "IsActive",
  "IsDeleted",
  "HasNoUpperBound",
  "ApplyOnPaymentCardTypeID",
  "ParentID",
  "ParentVersionNumber"
)
VALUES (
  true,
  0,
  0.014,
  true,
  (select ct."ClassificationTypeID" from "ClassificationType" ct where ct."ClassificationTypeCategoryID" = 8501 and ct."Name" = 'Credit Card' limit 1),
  true,
  'MasterCard Credit',
  '',
  0,
  0,
  true,
  false,
  false,
  (select ct."ClassificationTypeID" from "ClassificationType" ct where ct."ClassificationTypeCategoryID" = 9001 and ct."Name" = 'MasterCard Credit' limit 1),
  TProductID,
  TProductVersion
);
-- MasterCard Debit
INSERT INTO
  public."ComponentTierTemplate"
(
  "IsPercentageBased",
  "TierPrice",
  "TierPercentage",
  "ApplyToTotal",
  "ApplyOnPaymentMethodTypeID",
  "ApplyPerTransaction",
  "Name",
  "Description",
  "Order",
  "TierOrder",
  "IsActive",
  "IsDeleted",
  "HasNoUpperBound",
  "ApplyOnPaymentCardTypeID",
  "ParentID",
  "ParentVersionNumber"
)
VALUES (
  false,
  0.17,
  0,
  true,
  (select ct."ClassificationTypeID" from "ClassificationType" ct where ct."ClassificationTypeCategoryID" = 8501 and ct."Name" = 'Debit Card' limit 1),
  true,
  'MasterCard Debit',
  '',
  0,
  0,
  true,
  false,
  false,
  (select ct."ClassificationTypeID" from "ClassificationType" ct where ct."ClassificationTypeCategoryID" = 9001 and ct."Name" = 'MasterCard Debit' limit 1),
  TProductID,
  TProductVersion
);
-- Maestro
INSERT INTO
  public."ComponentTierTemplate"
(
  "IsPercentageBased",
  "TierPrice",
  "TierPercentage",
  "ApplyToTotal",
  "ApplyOnPaymentMethodTypeID",
  "ApplyPerTransaction",
  "Name",
  "Description",
  "Order",
  "TierOrder",
  "IsActive",
  "IsDeleted",
  "HasNoUpperBound",
  "ApplyOnPaymentCardTypeID",
  "ParentID",
  "ParentVersionNumber"
)
VALUES (
  false,
  0.17,
  0,
  true,
  (select ct."ClassificationTypeID" from "ClassificationType" ct where ct."ClassificationTypeCategoryID" = 8501 and ct."Name" = 'Debit Card' limit 1),
  true,
  'Maestro',
  '',
  0,
  0,
  true,
  false,
  false,
  (select ct."ClassificationTypeID" from "ClassificationType" ct where ct."ClassificationTypeCategoryID" = 9001 and ct."Name" = 'Maestro' limit 1),
  TProductID,
  TProductVersion
);
-- MasterCard Business
INSERT INTO
  public."ComponentTierTemplate"
(
  "IsPercentageBased",
  "TierPrice",
  "TierPercentage",
  "ApplyToTotal",
  "ApplyOnPaymentMethodTypeID",
  "ApplyPerTransaction",
  "Name",
  "Description",
  "Order",
  "TierOrder",
  "IsActive",
  "IsDeleted",
  "HasNoUpperBound",
  "ApplyOnPaymentCardTypeID",
  "ParentID",
  "ParentVersionNumber"
)
VALUES (
  true,
  0,
  0.024,
  true,
  (select ct."ClassificationTypeID" from "ClassificationType" ct where ct."ClassificationTypeCategoryID" = 8501 and ct."Name" = 'Credit Card' limit 1),
  true,
  'MasterCard Business',
  '',
  0,
  0,
  true,
  false,
  false,
  (select ct."ClassificationTypeID" from "ClassificationType" ct where ct."ClassificationTypeCategoryID" = 9001 and ct."Name" = 'MasterCard Business' limit 1),
  TProductID,
  TProductVersion
);
-- Diners
INSERT INTO
  public."ComponentTierTemplate"
(
  "IsPercentageBased",
  "TierPrice",
  "TierPercentage",
  "ApplyToTotal",
  "ApplyOnPaymentMethodTypeID",
  "ApplyPerTransaction",
  "Name",
  "Description",
  "Order",
  "TierOrder",
  "IsActive",
  "IsDeleted",
  "HasNoUpperBound",
  "ApplyOnPaymentCardTypeID",
  "ParentID",
  "ParentVersionNumber"
)
VALUES (
  true,
  0,
  0,
  true,
  (select ct."ClassificationTypeID" from "ClassificationType" ct where ct."ClassificationTypeCategoryID" = 8501 and ct."Name" = 'Credit Card' limit 1),
  true,
  'Diners',
  '',
  0,
  0,
  true,
  false,
  false,
  (select ct."ClassificationTypeID" from "ClassificationType" ct where ct."ClassificationTypeCategoryID" = 9001 and ct."Name" = 'Diners' limit 1),
  TProductID,
  TProductVersion
);
-- Pre auth
INSERT INTO
  public."ComponentTierTemplate"
(
  "IsPercentageBased",
  "TierPrice",
  "TierPercentage",
  "ApplyToTotal",
  "ApplyOnPaymentMethodTypeID",
  "ApplyPerTransaction",
  "Name",
  "Description",
  "Order",
  "TierOrder",
  "IsActive",
  "IsDeleted",
  "HasNoUpperBound",
  "ApplyOnPaymentCardTypeID",
  "ParentID",
  "ParentVersionNumber"
)
VALUES (
  true,
  0.20,
  0,
  true,
  (select ct."ClassificationTypeID" from "ClassificationType" ct where ct."ClassificationTypeCategoryID" = 8501 and ct."Name" = 'Pre Authentication' limit 1),
  true,
  'Pre Authentication',
  '',
  0,
  0,
  true,
  false,
  false,
  (select ct."ClassificationTypeID" from "ClassificationType" ct where ct."ClassificationTypeCategoryID" = 9001 and ct."Name" = 'Pre Authentication' limit 1),
  TProductID,
  TProductVersion
);

-- add linkage
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
    ct."ComponentTierTemplateID"

from "ComponentTierTemplate" ct

where ct."ParentID" = TProductID and ct."ParentVersionNumber" = TProductVersion

and not exists (select * from "ProductComponentTierTemplate" ctt where ctt."ProductTemplateID" = TProductID
	and ctt."ProductVersionID" = TProductVersion and ctt."ComponentTierTemplateID" = ct."ComponentTierTemplateID" limit 1)

;

END $$;