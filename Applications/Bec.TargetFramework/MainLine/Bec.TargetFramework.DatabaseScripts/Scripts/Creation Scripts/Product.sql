CREATE OR REPLACE FUNCTION public."fn_PromoteProductTemplate" (
  Producttemplateid uuid,
  Producttemplateversionnumber integer,
  ProcessPackage BOOLEAN,
  ProcessRelationship BOOLEAN,
  ProcessFamily BOOLEAN
)
RETURNS void AS
$body$
DECLARE
  ProductID UUID;
  ProductVersionNumber integer;
  LoopRow RECORD;
BEGIN


ProductID := (select dorg."ProductID" from "Product" dorg
	where dorg."ProductTemplateID" = Producttemplateid limit 1);

ProductVersionNumber := (select dorg."ProductVersionNumber" from "Product" dorg
	where dorg."ProductTemplateID" = Producttemplateid order by dorg."ProductVersionNumber" desc limit 1);

-- create DO entry
BEGIN

-- copy WF
IF(ProductID is null)
THEN
BEGIN
	ProductID := uuid_generate_v1();
END;
END IF;


ProductVersionNumber := Producttemplateversionnumber;

-- PRODUCT DEFAULTS
-- Attribute make sure unique
INSERT INTO
  public."ProductAttribute"
(
  "Name",
  "Description",
  "IsActive",
  "IsDeleted"
)
SELECT
  wt."Name",
  wt."Description",
  wt."IsActive",
  wt."IsDeleted"
FROM
  public."ProductAttributeTemplate" wt
  where not exists(select pt."Name" from "ProductAttribute" pt where pt."Name" = wt."Name" limit 1);


-- spec
INSERT INTO
  public."SpecificationAttribute"
(
  "SpecificationAttributeTemplateID",
  "Name",
  "Description",
  "DisplayOrder",
  "IsActive",
  "IsDeleted",
  "SpecificationAttributeTypeID",
  "SpecificationAttributeCategoryID",
  "SpecificationAttributeSubTypeID",
  "SpecificationAttributeSubCategoryID"
)
SELECT
  wt."SpecificationAttributeTemplateID",
  wt."Name",
  wt."Description",
  wt."DisplayOrder",
  wt."IsActive",
  wt."IsDeleted",
  wt."SpecificationAttributeTypeID",
  wt."SpecificationAttributeCategoryID",
  wt."SpecificationAttributeSubTypeID",
  wt."SpecificationAttributeSubCategoryID"
FROM
  public."SpecificationAttributeTemplate" wt
   where not exists(select pt."SpecificationAttributeTemplateID" from "SpecificationAttribute" pt where pt."SpecificationAttributeTemplateID" = wt."SpecificationAttributeTemplateID" limit 1);

-- spec option
INSERT INTO
  public."SpecificiationAttributeOption"
(
  "SpecificationAttributeOptionTemplateID",
  "SpecificationAttributeID",
  "DisplayOrder",
  "Name",
  "Description",
  "IsActive",
  "IsDeleted"
)
SELECT
  wt."SpecificationAttributeOptionTemplateID",
  (select sa1."SpecificationAttributeID" from "SpecificationAttribute" sa1 where sa1."SpecificationAttributeTemplateID" = wt."SpecificationAttributeTemplateID" limit 1),
  wt."DisplayOrder",
  wt."Name",
  wt."Description",
  wt."IsActive",
  wt."IsDeleted"

FROM
  public."SpecificationAttributeOptionTemplate"  wt
   where not exists(select pt."SpecificationAttributeOptionTemplateID" from "SpecificiationAttributeOption" pt where pt."SpecificationAttributeOptionTemplateID" = wt."SpecificationAttributeOptionTemplateID" limit 1);

-- spec relationship
INSERT INTO
  public."SpecificationAttributeRelationship"
(
  "SpecificationAttributeID",
  "ParentSpecificationAttributeID",
  "IsMandatory",
  "IsInverse",
  "IsActive",
  "IsDeleted"
)
SELECT
  sp."SpecificationAttributeID",
  spp."SpecificationAttributeID",
  wt."IsMandatory",
  wt."IsInverse",
  wt."IsActive",
  wt."IsDeleted"
FROM
  public."SpecificationAttributeRelationshipTemplate" wt

  left outer join "SpecificationAttribute" sp on sp."SpecificationAttributeTemplateID" = wt."SpecificationAttributeTemplateID"
  left outer join "SpecificationAttribute" spp on spp."SpecificationAttributeTemplateID" = wt."ParentSpecificationAttributeTemplateID"

  where sp."SpecificationAttributeID" is not null and spp."SpecificationAttributeID" is not null

  and not exists(select * from "SpecificationAttributeRelationship" ss where ss."SpecificationAttributeID" = sp."SpecificationAttributeID" and ss."ParentSpecificationAttributeID" = spp."SpecificationAttributeID" limit 1)
 ;

-- Plan
INSERT INTO
  public."Plan"
(
  "PlanVersionNumber",
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
  "PlanTemplateID",
  "PlanTemplateVersionNumber"
)
SELECT
 	1,
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
  "PlanTemplateID",
  "PlanTemplateVersionNumber"
FROM
  public."PlanTemplate"

  where not exists(select pt."PlanTemplateID" from "PlanTemplate" pt where pt."PlanTemplateID" = "PlanTemplateID" and pt."PlanTemplateVersionNumber" = "PlanTemplateVersionNumber")
  ;

-- plan transaction
INSERT INTO
  public."PlanTransaction"
(
  "PlanID",
  "PlanVersionNumber",
  "ProductID",
  "ProductVersionID"
)
SELECT
  p."PlanID",
 p."PlanVersionNumber",
  pr."ProductID",
  pr."ProductVersionID"
FROM
  public."PlanTransactionTemplate" ptt

  left outer join "Plan" p on p."PlanTemplateID" = ptt."PlanTemplateID" and p."PlanTemplateVersionNumber" = ptt."PlanTemplateVersionNumber"
  left outer join "Product" pr on pr."ProductTemplateID" = ptt."ProductTemplateID" and pr."ProductVersionID" = ptt."ProductVersionID"

   where not exists(select pt."PlanTransactionID" from "PlanTransaction" pt where pt."ProductID" = pr."ProductID" and pt."ProductVersionID" = pr."ProductVersionID"
   	and pt."PlanID" = p."PlanID" and pt."PlanVersionNumber" = p."PlanVersionNumber" limit 1)
    and p."PlanID" is not null and pr."ProductID" is not null
  ;

-- billing
INSERT INTO
  public."Billing"
(
  "BillingChargeTypeID",
  "BillingPeriod",
  "BillingPeriodUnitID",
  "NumberOfRetries",
  "BillingTakenAtTheEndOfPeriod",
  "BillingTakenAtTheBeginningOfNextPeriod",
  "ParentID"
)
SELECT
  "BillingChargeTypeID",
  "BillingPeriod",
  "BillingPeriodUnitID",
  "NumberOfRetries",
  "BillingTakenAtTheEndOfPeriod",
  "BillingTakenAtTheBeginningOfNextPeriod",
  "BillingTemplateID"
FROM
  public."BillingTemplate"
  where not exists(select * from "Billing" pt where pt."ParentID" = "BillingTemplateID")
  ;

INSERT INTO
  public."PlanBilling"
(
  "PlanID",
  "PlanVersionNumber",
  "BillingID",
  "IsActive",
  "IsDeleted"
)
SELECT
  p."PlanID",
  p."PlanVersionNumber",
  b."BillingID",
  wt."IsActive",
  wt."IsDeleted"
FROM
  public."PlanBillingTemplate" wt

  left outer join "Plan" p on p."PlanTemplateID" = wt."PlanTemplateID" and p."PlanTemplateVersionNumber" = wt."PlanTemplateVersionNumber"
  left outer join "Billing" b on b."ParentID" = wt."BillingTemplateID"


   where not exists(select * from "PlanBilling" pt where pt."PlanID" = p."PlanID" and pt."PlanVersionNumber"= p."PlanVersionNumber" and pt."BillingID" = b."BillingID")
  ;

INSERT INTO
  public."PlanProduct"
(
  "PlanID",
  "PlanVersionNumber",
  "ProductID",
  "ProductVersionID",
  "Period",
  "PeriodUnitID",
  "IsActive",
  "IsDeleted",
  "PlanProductStatusID"
)
SELECT
  p."PlanID",
  p."PlanVersionNumber",
  pr."ProductID",
  pr."ProductVersionID",
  wt."Period",
  wt."PeriodUnitID",
  wt."PlanProductTypeID",
  wt."IsActive",
  wt."IsDeleted",
  wt."PlanProductStatusID"
FROM
  public."PlanProductTemplate" wt

  left outer join "Plan" p on p."PlanTemplateID" = wt."PlanTemplateID" and p."PlanTemplateVersionNumber" = wt."PlanTemplateVersionNumber"
  left outer join "Product" pr on pr."ProductTemplateID" = wt."ProductTemplateID" and pr."ProductTemplateVersionID" = wt."ProductVersionID"

   where not exists(select * from "PlanProduct" pt where pt."PlanID" = p."PlanID" and pt."PlanVersionNumber"= p."PlanVersionNumber" and pt."ProductID" = pr."ProductID"
   	and pt."ProductVersionID" = pr."ProductVersionID")
  ;

-- subscription
INSERT INTO
  public."PlanSubscription"
(
  "PlanSubscriptionVersionNumber",
  "HasInfinitePeriods",
  "PlanQuantity",
  "StartDate",
  "TrialStart",
  "TrialEnd",
  "CurrentTermStart",
  "CurrentTermEnd",
  "RemainingBillingCycles",
  "CreatedOn",
  "CreatedBy",
  "ActivatedOn",
  "CancelledOn",
  "CancelReasonID",
  "DueInvoicesCount",
  "DueSince",
  "DueAmount",
  "IsActive",
  "IsDeleted",
  "ParentID",
  "ParentVersionNumber",
  "CountryCode",
  "IsFree",
  "PlanID",
  "PlanVersionNumber",
  "PlanSubscriptionStatusID"
)
SELECT
  1,
  wt."HasInfinitePeriods",
  wt."PlanQuantity",
  wt."StartDate",
  wt."TrialStart",
  wt."TrialEnd",
  wt."CurrentTermStart",
  wt."CurrentTermEnd",
  wt."RemainingBillingCycles",
  CURRENT_DATE,
  'System',
  wt."ActivatedOn",
  wt."CancelledOn",
  wt."CancelReasonID",
  wt. "DueInvoicesCount",
  wt."DueSince",
  wt."DueAmount",
  wt."IsActive",
  wt."IsDeleted",
  wt."PlanSubscriptionTemplateID",
  wt."PlanSubscriptionTemplateVersionNumber",
  wt."CountryCode",
  wt."IsFree",
  p."PlanID",
  p."PlanVersionNumber",
  "PlanSubscriptionStatusID"
FROM
  public."PlanSubscriptionTemplate" wt

   left outer join "Plan" p on p."PlanTemplateID" = wt."PlanTemplateID" and p."PlanTemplateVersionNumber" = wt."PlanTemplateVersionNumber"

  where not exists(select * from "PlanSubscription" pt where pt."PlanID" = p."PlanID" and pt."PlanVersionNumber" = p."PlanVersionNumber"
  	and pt."ParentID" = wt."PlanSubscriptionTemplateID" and pt."ParentVersionNumber" = wt."PlanSubscriptionTemplateVersionNumber")
  ;


-- Product
INSERT INTO
  public."Product"
(
  "ProductID",
  "ProductTemplateID",
  "IsActive",
  "IsDeleted",
  "IsPackage",
  "IsDeposit",
  "ProductVersionID",
  "ProductTemplateVersionID",
  "ParentID",
  "OwnerOrganisationID",
  "CanBeResold"
)
SELECT
   ProductID,
  wt."ProductTemplateID",
  wt."IsActive",
  wt."IsDeleted",
  wt."IsPackage",
  false,
  ProductVersionNumber,
  wt."ProductVersionID",
  wt."ParentID",
  wt."OwnerOrganisationID",
  wt."CanBeResold"
FROM
  public."ProductTemplate" wt
  where wt."ProductTemplateID" = Producttemplateid and wt."ProductVersionID" = Producttemplateversionnumber ;

-- PRoduct Attri
INSERT INTO
  public."ProductProductAttribute"
(
  "ProductID",
  "ProductAttributeID",
  "IsRequired",
  "DisplayOrder",
  "ProductVersionID",
  "IsActive",
  "IsDeleted"
)
SELECT
  ProductID,
  pa."ProductAttributeID",
  wt."IsRequired",
  wt."DisplayOrder",
  ProductVersionNumber,
  wt."IsActive",
  wt."IsDeleted"
FROM
  public."ProductProductAttributeTemplate" wt
  left outer join "ProductAttributeTemplate" pat on pat."ProductAttributeTemplateID" = wt."ProductAttributeTemplateID"
  left outer join "ProductAttribute" pa on pa."Name" = pat."Name"

  where wt."ProductTemplateID" = Producttemplateid and wt."ProductVersionID" = Producttemplateversionnumber and pa."ProductAttributeID" is not null;

-- tag
INSERT INTO
  public."ProductTag"
(
  "Name",
  "ProductID",
  "ProductVersionID"
)
SELECT
  wt."Name",
  ProductID,
  ProductVersionNumber
FROM
  public."ProductTagTemplate" wt
  where wt."ProductTemplateID" = Producttemplateid and wt."ProductVersionID" = Producttemplateversionnumber;

-- deduction
INSERT INTO
  public."ProductDeduction"
(
  "ProductID",
  "ProductVersionID",
  "DeductionID",
  "DeductionPercentage",
  "DeductionValue",
  "IsActive",
  "IsDeleted",
  "DeductionVersionNumber"
)
SELECT
  ProductID,
  ProductVersionNumber,
  de."DeductionID",
  wt."DeductionPercentage",
  wt."DeductionValue",
  wt."IsActive",
  wt."IsDeleted",
  de."DeductionVersionNumber"
FROM
  public."ProductDeductionTemplate" wt
  left outer join "DeductionTemplate" dt on dt."DeductionTemplateID" = wt."DeductionTemplateID" and dt."DeductionTemplateVersionNumber" = wt."DeductionTemplateVersionNumber"
  left outer join "Deduction" de on de."Name" = dt."Name"
  where wt."ProductTemplateID" = Producttemplateid and wt."ProductVersionID" = Producttemplateversionnumber;

-- WF ROLE
INSERT INTO
  public."ProductRole"
(
  "RoleName",
  "RoleDescription",
  "IsActive",
  "IsDeleted",
  "ProductID",
  "ProductVersionID",
  "RoleTypeID",
  "RoleSubTypeID",
  "RoleCategoryID",
  "RoleSubCategoryID"
)
SELECT
  wt."RoleName",
  wt."RoleDescription",
  wt."IsActive",
  wt."IsDeleted",
  ProductID,
  ProductVersionNumber,
  wt."RoleTypeID",
  wt."RoleSubTypeID",
  wt."RoleCategoryID",
  wt."RoleSubCategoryID"
FROM
  public."ProductRoleTemplate" wt where wt."ProductTemplateID" = Producttemplateid and wt."ProductVersionID" = Producttemplateversionnumber ;

-------------- Claim
INSERT INTO
  public."ProductClaim"
(
"ProductID",
  "ProductVersionID",
  "ResourceID",
  "OperationID",
  "StateID",
  "StateItemID",
  "IsActive",
  "IsDeleted",
  "ProductRoleID"
)
SELECT
  ProductID,
  ProductVersionNumber,
  wt."ResourceID",
  wt."OperationID",
  wt."StateID",
  wt."StateItemID",
  wt."IsActive",
  wt."IsDeleted",
  mr."RoleID"
FROM
  public."ProductClaimTemplate" wt

  inner join "ProductRoleTemplate" wrr on wrr."RoleID" = wt."ProductRoleID" and wrr."ProductTemplateID" = wt."ProductTemplateID"
  and wrr."ProductVersionID" = wt."ProductVersionID"

  left outer join "ProductRole" mr on mr."ProductID" = ProductID and mr."ProductVersionID" = ProductVersionNumber and mr."RoleName" = wrr."RoleName"

  where wt."ProductTemplateID" = Producttemplateid and wt."ProductVersionID" = Producttemplateversionnumber
  	and wrr."RoleID" is not null and wt."RoleID" is null ;

INSERT INTO
  public."ProductClaim"
(
"ProductID",
  "ProductVersionNumber",
  "ResourceID",
  "OperationID",
  "StateID",
  "StateItemID",
  "IsActive",
  "IsDeleted",
  "RoleID"
)
SELECT
ProductID,
  ProductVersionNumber,
  wt."ResourceID",
  wt."OperationID",
  wt."StateID",
  wt."StateItemID",
  wt."IsActive",
  wt."IsDeleted",
  wt."RoleID"
FROM
  public."ProductClaimTemplate" wt

  inner join "Role" wrr on wrr."RoleID" = wt."RoleID"

  where wt."ProductTemplateID" = Producttemplateid and wt."ProductVersionID" = Producttemplateversionnumber
  	and wt."ProductRoleID" is null and wt."RoleID" is not null
    and not exists(select dd."ClaimID" from "ProductClaim" dd where dd."RoleID" = wt."RoleID" and dd."ProductID" = ProductID and dd."ProductVersionID" =  ProductVersionNumber);

----
INSERT INTO
  public."ProductDetail"
(
  "Name",
  "Description",

  "IsActive",
  "IsDeleted",
  "ShortDescription",
  "LongDescription",
  "MetaKeywords",
  "MetaDescription",
  "MetaTitle",
  "RequireOtherProducts",
  "AutomaticallyAddRequiredProducts",
  "HasUserAgreement",
  "UserAgreementText",
  "IsRecurring",
  "RecurringCycleLength",
  "RecurringCyclePeriodID",
  "RecurringTotalCycle",
  "IsTaxExempt",
  "TaxCategoryID",
  "OrderMinimumQuantity",
  "OrderMaximumQuantity",
  "CallForPrice",
  "Price",
  "ProductCost",
  "CustomerEntersPrice",
  "HasTierPrices",
  "HasDiscountsApplied",
  "MinimumCustomerEnteredPrice",
  "MaximumCustomerEnteredPrice",
  "DisplayOrder",
  "AvailableStartDate",
  "AvailableEndDate",
  "ProductTypeID",
  "ProductSubTypeID",
  "ProductCategoryID",
  "ProductSubCategoryID",
  "IsProductOrganisationOwned",

  "CurrencyCode",
  "CurrencyRate",
  "CurrencyRateDate",
  "CurrencyRateToGBP",
  "CurrencyRateToUSD",
  "InvoiceName",
  "IsDepositProduct",
    "ProductID",
      "ProductVersionID"
)
SELECT
  "Name",
  "Description",
  "IsActive",
  "IsDeleted",
  "ShortDescription",
  "LongDescription",
  "MetaKeywords",
  "MetaDescription",
  "MetaTitle",
  "AutomaticallyAddRequiredProducts",
  "HasUserAgreement",
  "UserAgreementText",
  "IsRecurring",
  "RecurringCycleLength",
  "RecurringCyclePeriodID",
  "RecurringTotalCycles",
  "IsTaxExempt",
  "TaxCategoryID",
  "OrderMinimumQuantity",
  "OrderMaximumQuantity",
  "CallForPrice",
  "Price",
  "ProductCost",
  "CustomerEntersPrice",
  "HasTierPrices",
  "HasDiscountsApplied",
  "MinimumCustomerEnteredPrice",
  "MaximumCustomerEnteredPrice",
  "DisplayOrder",
  "AvailableStartDate",
  "AvailableEndDate",
  "ProductTypeID",
  "ProductSubTypeID",
  "ProductCategoryID",
  "ProductSubCategoryID",
  "RequireOtherProducts",
  "ProductVersionID",
  "CurrencyCode",
  "CurrencyRate",
  "CurrencyRateDate",
  "CurrencyRateToGBP",
  "CurrencyRateToUSD",
  "InvoiceName",
  "IsDepositProduct",
  ProductID,
  ProductVersionNumber

FROM
  public."ProductDetailTemplate"  where "ProductTemplateID" = Producttemplateid and "ProductVersionID" = Producttemplateversionnumber ;

-- spec attrs
INSERT INTO
  public."ProductSpecificationAttribute"
(
  "ProductID",
  "IsMandatory",
  "IsMultiSelect",
  "DisplayOrder",
  "IsPreSelected",
  "MinimumSelectionLimit",
  "MaximumSelectionLimit",
  "IsUserDefined",
  "IsPriceDriven",
  "SpecificationAttributeID",
  "IsActive",
  "IsDeleted",
  "ProductVersionID"
)
SELECT
  ProductID,
  wt."IsMandatory",
  wt."IsMultiSelect",
  wt."DisplayOrder",
  wt."IsPreSelected",
  wt."MinimumSelectionLimit",
  wt."MaximumSelectionLimit",
  wt."IsUserDefined",
  wt."IsPriceDriven",
  sp."SpecificationAttributeID",
  wt."IsActive",
  wt."IsDeleted",
  ProductVersionNumber
FROM
  public."ProductSpecificationAttributeTemplate" wt

  left outer join "SpecificationAttribute" sp on sp."SpecificationAttributeTemplateID" = wt."SpecificationAttributeTemplateID"

  where wt."ProductTemplateID" = Producttemplateid and wt."ProductVersionID" = Producttemplateversionnumber;

INSERT INTO
  public."ProductSpecificationAttributeOption"
(
  "ProductSpecificationAttributeID",
  "SpecficiationAttributeOptionID",
  "PriceAdjustment",
  "WeightAdjustment",
  "Cost",
  "DefaultValue",
  "DefaultQuantity",
  "DisplayOrder",
  "IsActive",
  "IsDeleted"
)
SELECT
  psa."ProductSpecificationAttributeID",
  sao."SpecficiationAttributeOptionID",
  wt."PriceAdjustement",
  wt."WeightAdjustment",
  wt."Cost",
  wt."DefaultValue",
  wt."DefaultQuantity",
  wt."DisplayOrder",
  wt. "IsActive",
  wt."IsDeleted"
FROM
  public."ProductSpecificationAttributeOptionTemplate" wt

  left outer join "SpecificiationAttributeOption" sao on sao."SpecificationAttributeOptionTemplateID" = wt."SpecificationAttributeOptionTemplateID"

  left outer join "ProductSpecificationAttributeTemplate" psat on psat."ProductSpecificationAttributeTemplateID" = wt."ProductSpecificationAttributeTemplateID"

  left outer join "ProductSpecificationAttribute" psa on psa."ProductID" = ProductID and psa."ProductVersionID" = ProductVersionNumber
  	and psa."SpecificationAttributeID" = sao."SpecificationAttributeID"

  where wt."ProductTemplateID" = Producttemplateid and wt."ProductVersionID" = Producttemplateversionnumber
  ;

INSERT INTO
  public."ProductSpecificationBlueprint"
(
  "ProductID",
  "ProductSpecificationAttributeID",
  "DefaultProductSpecificationAttributeOptionID",
  "IsActive",
  "IsDeleted",
  "ProductVersionID"
)
SELECT
  ProductID,
  psa."ProductSpecificationAttributeID",
  psao."ProductSpecificationAttributeOptionID",
  wt."IsActive",
  wt."IsDeleted",
  ProductVersionNumber
FROM
  public."ProductSpecificationBlueprintTemplate" wt
  left outer join "ProductSpecificationAttributeOptionTemplate" sao on sao."ProductSpecificationAttributeOptionTemplateID" = wt."DefaultProductSpecificationAttributeOptionTemplateID"
  left outer join "SpecificiationAttributeOption" saa on saa."SpecificationAttributeOptionTemplateID" = sao."SpecificationAttributeOptionTemplateID"

  left outer join "ProductSpecificationAttributeTemplate" psat on psat."ProductSpecificationAttributeTemplateID" = wt."ProductSpecificationAttributeTemplateID"

  left outer join "ProductSpecificationAttribute" psa on psa."ProductID" = ProductID and psa."ProductVersionID" = ProductVersionNumber
  	and psa."SpecificationAttributeID" = saa."SpecificationAttributeID"
  left outer join "ProductSpecificationAttributeOption" psao on psao."ProductID" = ProductID and psao."ProductVersionID" = ProductVersionNumber
  	and psao."ProductSpecificationAttributeID" = psa."ProductSpecificationAttributeID" and psao."SpecficiationAttributeOptionID" = saa."SpecficiationAttributeOptionID"
  where wt."ProductTemplateID" = Producttemplateid and wt."ProductVersionID" = Producttemplateversionnumber
  ;

INSERT INTO
  public."ProductVariantAttributeValue"
(
  "ProductProductAttributeID",
  "AttributeValueTypeID",
  "Name",
  "PriceAdjustment",
  "WeightAdjustement",
  "Cost",
  "Quantity",
  "IsPreSelected",
  "DisplayOrder",
  "IsActive",
  "IsDeleted"
)
SELECT
  ppa."ProductProductAttributeID",
  wt."AttributeValueTypeID",
  wt."Name",
  wt."PriceAdjustment",
  wt."WeightAdjustment",
  wt."Cost",
  wt."Quantity",
  wt."IsPreSelected",
  wt."DisplayOrder",
  wt."IsActive",
  wt."IsDeleted"
FROM
  public."ProductVariantAttributeValueTemplate" wt

  left outer join "ProductProductAttributeTemplate" ppt on ppt."ProductProductAttributeTemplateID" = wt."ProductProductAttributeTemplateID"

  left outer join "ProductAttributeTemplate" pat on pat."ProductAttributeTemplateID" = ppt."ProductAttributeTemplateID"
  left outer join "ProductAttribute" pa on pa."Name" = pat."Name"

  left outer join "ProductProductAttribute" ppa on ppa."ProductID" =ProductID and ppa."ProductVersionID" = ProductVersionNumber
  	and ppa."ProductAttributeID" = pa."ProductAttributeID"

   where wt."ProductTemplateID" = Producttemplateid and wt."ProductVersionID" = Producttemplateversionnumber
  ;

INSERT INTO
  public."ProductVariantAttributeCombination"
(
  "ProductID",
  "AllowOutOfStockOrders",
  "StockQuantity",
  "Sku",
  "ManufacturerPartNumber",
  "Gtin",
  "OverridenPrice",
  "IsActive",
  "IsDeleted",
  "ProductVersionID"
)
SELECT
  ProductID,
  wt."AllowOutOfStockOrders",
  wt."StockQuantity",
  wt."Sku",
  wt."ManufacturerPartNumber",
  wt."Gtin",
  wt."OverriddenPrice",
  wt."IsActive",
  wt."IsDeleted",
  ProductVersionNumber
FROM
  public."ProductVariantAttributeCombinationTemplate" wt

   where wt."ProductTemplateID" = Producttemplateid and wt."ProductVersionID" = Producttemplateversionnumber
  ;

IF(ProcessRelationship = true)
THEN
BEGIN

-- first promote all parent products
FOR LoopRow IN
	select aw."ParentProductTemplateID",aw."ParentProductVersionID" from "ProductRelationshipTemplate" aw
    	where not exists(select * from "Product" p where p."ProductTemplateID" = aw."ParentProductTemplateID" and p."ProductTemplateVersionID" = aw."ParentProductVersionID" limit 1)
LOOP
    BEGIN
    	perform "fn_PromoteProductTemplate"(LoopRow."ParentProductTemplateID",LoopRow."ParentProductVersionID",false,false,false);
    END;
END LOOP;
-- first promote all child products
FOR LoopRow IN
	select aw."ChildProductTemplateID",aw."ChildProductVersionID" from "ProductRelationshipTemplate" aw
    	where not exists(select * from "Product" p where p."ProductTemplateID" = aw."ChildProductTemplateID" and p."ProductTemplateVersionID" = aw."ChildProductVersionID" limit 1)
LOOP
    BEGIN
    	perform "fn_PromoteProductTemplate"(LoopRow."ChildProductTemplateID",LoopRow."ChildProductVersionID",false,false,false);
    END;
END LOOP;


INSERT INTO
  public."ProductRelationship"
(
  "ParentProductID",
  "ChildProductID",
  "ProductRelationshipTypeID",
  "IsMandatory",
  "IsActive",
  "IsDeleted",
  "ParentProductVersionID",
  "ChildProductVersionID"
)
SELECT
  pr."ProductID",
  cpr."ProductID",
  wt."ProductRelationshipTypeID",
  wt."IsMandatory",
  wt."IsActive",
  wt."IsDeleted",
  pr."ProductVersionID",
  cpr."ProductVersionID"
FROM
  public."ProductRelationshipTemplate" wt

  left outer join "Product" pr on pr."ProductTemplateID" = wt."ParentProductTemplateID" and pr."ProductTemplateVersionID" = wt."ParentProductVersionID"
  left outer join "Product" cpr on cpr."ProductTemplateID" = wt."ChildProductTemplateID" and cpr."ProductTemplateVersionID" = wt."ChildProductVersionID"

   where wt."ProductTemplateID" = Producttemplateid and wt."ProductVersionID" = Producttemplateversionnumber
   and pr."ProductID" is not null and cpr."ProductID" is not null
   and not exists(select * from "ProductRelationship" where prr."ParentProductID" = pr."ProductID" and prr."ParentProductVersionID" = pr."ProductVersionID"
   	and prr."ChildProductID" = cpr."ProductID" and prr."ChildProductVersionID" = cpr."ProductVersionID" limit 1)
  ;

INSERT INTO
  public."ProductRelationshipBlueprint"
(
  "ProductRelationshipID",
  "DefaultQuantity",
  "IsActive",
  "IsDeleted"
)
SELECT
  prr."ProductRelationshipID",
  wt."DefaultQuantity",
  wt."IsActive",
  wt."IsDeleted"
FROM
  public."ProductRelationshipBlueprintTemplate" wt

  left outer join "ProductRelationshipTemplate" rt on rt."ProductRelationshipTemplateID" = wt."ProductRelationshipTemplateID"

   left outer join "Product" pr on pr."ProductTemplateID" = rt."ParentProductTemplateID" and pr."ProductTemplateVersionID" = rt."ParentProductVersionID"
  left outer join "Product" cpr on cpr."ProductTemplateID" = rt."ChildProductTemplateID" and cpr."ProductTemplateVersionID" = rt."ChildProductVersionID"

  left outer join "ProductRelationship" prr on prr."ChildProductID" = cpr."ProductID" and prr."ChildProductVersionID" = cpr."ProductVersionID"
  	and prr."ParentProductID" = pr."ProductID" and prr."ParentProductVersionID" = pr."ProductVersionID"

   where wt."ProductTemplateID" = Producttemplateid and wt."ProductVersionID" = Producttemplateversionnumber
   and not exists(select * from "ProductRelationshipBlueprint" prr1 WHERE prr1."ProductRelationshipID" = prr."ProductRelationshipID" limit 1)
   ;

END;
END IF;

-- Package
IF(ProcessPackage = true)
THEN
BEGIN

-- first promote all package related products
FOR LoopRow IN
	select aw."ProductTemplateID",aw."ProductVersionID" from "PackageTemplate" aw
    	where not exists(select * from "Product" p where p."ProductTemplateID" = aw."ProductTemplateID" and p."ProductTemplateVersionID" = aw."ProductVersionID" limit 1)
LOOP
    BEGIN
    	perform "fn_PromoteProductTemplate"(LoopRow."ProductTemplateID",LoopRow."ProductVersionID",false,false,false);
    END;
END LOOP;
-- product all package child products
FOR LoopRow IN
	select aw."ProductTemplateID",aw."ProductVersionID" from "PackageProductTemplate" aw
    	where not exists(select * from "Product" p where p."ProductTemplateID" = aw."ProductTemplateID" and p."ProductTemplateVersionID" = aw."ProductVersionID" limit 1)
LOOP
    BEGIN
    	perform "fn_PromoteProductTemplate"(LoopRow."ProductTemplateID",LoopRow."ProductVersionID",false,false,false);
    END;
END LOOP;
-- package relationship products
FOR LoopRow IN
	select aw."ParentProductTemplateID",aw."ParentProductVersionID" from "PackageProductRelationshipTemplate" aw
    	where not exists(select * from "Product" p where p."ProductTemplateID" = aw."ParentProductTemplateID" and p."ProductTemplateVersionID" = aw."ParentProductVersionID" limit 1)
LOOP
    BEGIN
    	perform "fn_PromoteProductTemplate"(LoopRow."ParentProductTemplateID",LoopRow."ParentProductVersionID",false,false,false);
    END;
END LOOP;
-- first promote all child products
FOR LoopRow IN
	select aw."ChildProductTemplateID",aw."ChildProductVersionID" from "PackageProductRelationshipTemplate" aw
    	where not exists(select * from "Product" p where p."ProductTemplateID" = aw."ChildProductTemplateID" and p."ProductTemplateVersionID" = aw."ChildProductVersionID" limit 1)
LOOP
    BEGIN
    	perform "fn_PromoteProductTemplate"(LoopRow."ChildProductTemplateID",LoopRow."ChildProductVersionID",false,false,false);
    END;
END LOOP;

INSERT INTO
  public."Package"
(
  "ProductID",
  "ProductVersionID",
  "IsActive",
  "IsDeleted",
  "PackageVersionNumber",
  "PackageTemplateID",
  "PackageTemplateVersionNumber"
)
SELECT
  p."ProductID",
  p."ProductVersionID",
  wt."IsActive",
  wt."IsDeleted",
  1,
  wt."PackageTemplateID",
  wt."PackageTemplateVersionNumber"
FROM
  public."PackageTemplate" wt

  left outer join "Product" p on p."ProductTemplateID" = wt."ProductTemplateID" and p."ProductTemplateVersionID" = wt."ProductVersionID"

  where not exists(select * from "Package" p1 where p1."PackageTemplateID" = wt."PackageTemplateID" and p1."PackageTemplateVersionNumber" = wt."PackageTemplateVersionNumber" limit 1)
  ;

INSERT INTO
  public."PackageProduct"
(
  "PackageID",
  "UseProductDefaultBlueprint",
  "UseDefaultProductPricing",
  "IsFixedPrice",
  "ProductPriceModifierPercentage",
  "ProductPriceModifierValue",
  "DefaultQuantity",
  "UserDefinableQuantity",
  "IsActive",
  "IsDeleted",
  "ProductID",
  "ProductVersionID",
  "PackageVersionNumber"
)
SELECT
  pa."PackageID",
  wt."UseProductDefaultBlueprint",
  wt."UseDefaultProductPricing",
  wt."IsFixedPrice",
  wt."ProductPriceModifierPercentage",
  wt."ProductPriceModifierValue",
  wt."DefaultQuantity",
  wt."UserDefinableQuantity",
  wt."IsActive",
  wt."IsDeleted",
  p."ProductID",
  p."ProductVersionID",
  pa."PackageVersionNumber"
FROM
  public."PackageProductTemplate" wt

  left outer join "Product" p on p."ProductTemplateID" = wt."ProductTemplateID" and p."ProductTemplateVersionID" = wt."ProductVersionID"
  left outer join "Package" pa on pa."PackageTemplateID" =wt."PackageTemplateID" and pa."PackageTemplateVersionNumber" = wt."PackageTemplateVersionNumber"

  where not exists(select * from "PackageProduct" p1 where p1."PackageID" = pa."PackageID" and p1."PackageVersionNumber" = pa."PackageVersionNumber"
  	and p1."ProductID" = p."ProductID" and p1."ProductVersionID" = p."ProductVersionID" limit 1)
  ;

INSERT INTO
  public."PackageProductRelationship"
(
  "ParentProductID",
  "ChildProductID",
  "ProductRelationshipTypeID",
  "IsMandatory",
  "IsActive",
  "IsDeleted",
  "PackageProductID",
  "ParentProductVersionID",
  "ChildProductVersionID",
  "PackageID",
  "PackageVersionNumber"
)
SELECT
  p."ProductID",
  xp."ProductID",
  wt."ProductRelationshipTypeID",
  wt."IsMandatory",
  wt."IsActive",
  wt."IsDeleted",
  pp."PackageProductID",
  p."ProductVersionID",
  xp."ProductVersionID",
  pa."PackageID",
  pa."PackageVersionNumber"
FROM
  public."PackageProductRelationshipTemplate" wt

  left outer join "Product" p on p."ProductTemplateID" = wt."ParentProductTemplateID" and p."ProductTemplateVersionID" = wt."ParentProductVersionID"
  left outer join "Product" xp on xp."ProductTemplateID" = wt."ChildProductTemplateID" and xp."ProductTemplateVersionID" = wt."ChildProductVersionID"
  left outer join "Package" pa on pa."PackageTemplateID" =wt."PackageTemplateID" and pa."PackageTemplateVersionNumber" = wt."PackageTemplateVersionNumber"
  left outer join "PackageProductTemplate" ppt on ppt."PackageProductTemplateID" = wt."PackageProductTemplateID"
  left outer join "Product" xp1 on xp1."ProductTemplateID" = ppt."ProductTemplateID" and xp1."ProductTemplateVersionID" =ppt."ProductVersionID"
  left outer join "PackageProduct" pp on pp."PackageID" = pa."PackageID" and pp."PackageVersionNumber" = pa."PackageVersionNumber"
  	and pp."ProductID" = xp1."ProductID" and pp."ProductVersionID" = xp1."ProductVersionID"

   where not exists(select * from "PackageProductRelationship" p1 where p1."PackageID" = pa."PackageID" and p1."PackageVersionNumber" = pa."PackageVersionNumber"
  	and p1."ChildProductID" = p."ProductID" and p1."ChildProductVersionID" = p."ProductVersionID" and p1."ParentProductID" = xp."ProductID" and p1."ParentProductVersionID" = xp."ProductVersionID"
    and p1."PackageProductID" = pp."PackageProductID"  limit 1)
  ;

INSERT INTO
  public."PackageProductRelationshipBlueprint"
(
  "PackageProductRelationshipID",
  "DefaultQuantity",
  "IsActive",
  "IsDeleted"
)
SELECT
  p1."PackageProductRelationshipID",
  wt."DefaultQuantity",
  wt."IsActive",
  wt."IsDeleted"
FROM
  public."PackageProductRelationshipBlueprintTemplate" wt

   left outer join "Product" p on p."ProductTemplateID" = wt."ParentProductTemplateID" and p."ProductTemplateVersionID" = wt."ParentProductVersionID"
  left outer join "Product" xp on xp."ProductTemplateID" = wt."ChildProductTemplateID" and xp."ProductTemplateVersionID" = wt."ChildProductVersionID"
  left outer join "Package" pa on pa."PackageTemplateID" =wt."PackageTemplateID" and pa."PackageTemplateVersionNumber" = wt."PackageTemplateVersionNumber"
  left outer join "PackageProductTemplate" ppt on ppt."PackageProductTemplateID" = wt."PackageProductTemplateID"
  left outer join "Product" xp1 on xp1."ProductTemplateID" = ppt."ProductTemplateID" and xp1."ProductTemplateVersionID" =ppt."ProductVersionID"
  left outer join "PackageProduct" pp on pp."PackageID" = pa."PackageID" and pp."PackageVersionNumber" = pa."PackageVersionNumber"
  	and pp."ProductID" = xp1."ProductID" and pp."ProductVersionID" = xp1."ProductVersionID"

  left outer join "PackageProductRelationship" p1 on p1."PackageID" = pa."PackageID" and p1."PackageVersionNumber" = pa."PackageVersionNumber"
  	and p1."ChildProductID" = p."ProductID" and p1."ChildProductVersionID" = p."ProductVersionID" and p1."ParentProductID" = xp."ProductID" and p1."ParentProductVersionID" = xp."ProductVersionID"
    and p1."PackageProductID" = pp."PackageProductID"

  where not exists(select * from "PackageProductRelationshipBlueprint" pps where pps."PackageProductRelationshipID" = p1."PackageProductRelationshipID" limit 1)

  ;

END;
END IF;

END;

END;
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY DEFINER
COST 100;