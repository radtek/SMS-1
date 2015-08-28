-- BEC Products


DO $$
Declare BecID uuid;
Declare OrganisationTypeID integer;
Declare DoTemplateID uuid;
Declare DoVersionNumber integer;
Declare TProductID uuid;
Declare TProductVersion integer;
Declare TPlanID uuid;
Declare TPlanVersion integer;
Declare TPTID uuid;
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
Declare LoopRow Record;
Declare PackageID uuid;
Declare PackageVersionID integer;
Declare PackageProductID uuid;
Begin

-- declare variables
OrganisationTypeID := (select "OrganisationTypeID" from "OrganisationType" where "Name" = 'Administration' limit 1);

DoTemplateID:= (select dot."DefaultOrganisationID" from "DefaultOrganisation" dot where dot."Name" = 'Administration' and dot."IsActive" = true and dot."IsDeleted" = false order by dot."DefaultOrganisationVersionNumber" desc limit 1);

DoVersionNumber:= (select dot."DefaultOrganisationVersionNumber" from "DefaultOrganisation" dot where dot."Name" = 'Administration' and dot."IsActive" = true and dot."IsDeleted" = false order by dot."DefaultOrganisationVersionNumber" desc limit 1);

-- promote Admin do template if it doesnt exist
if(DoTemplateID is null)
THEN
BEGIN

DoTemplateID:= (select dot."DefaultOrganisationTemplateID" from "DefaultOrganisationTemplate" dot where dot."Name" = 'Administration' and dot."IsActive" = true and dot."IsDeleted" = false order by dot."DefaultOrganisationTemplateVersionNumber" desc limit 1);

DoVersionNumber:= (select dot."DefaultOrganisationTemplateVersionNumber" from "DefaultOrganisationTemplate" dot where dot."Name" = 'Administration' and dot."IsActive" = true and dot."IsDeleted" = false order by dot."DefaultOrganisationTemplateVersionNumber" desc limit 1);

perform "fn_PromoteDefaultOrganisationTemplate"(DoTemplateID, DoVersionNumber);

-- now get the id's again, pain eh
DoTemplateID:= (select dot."DefaultOrganisationID" from "DefaultOrganisation" dot where dot."Name" = 'Administration' and dot."IsActive" = true and dot."IsDeleted" = false order by dot."DefaultOrganisationVersionNumber" desc limit 1);

DoVersionNumber:= (select dot."DefaultOrganisationVersionNumber" from "DefaultOrganisation" dot where dot."Name" = 'Administration' and dot."IsActive" = true and dot."IsDeleted" = false order by dot."DefaultOrganisationVersionNumber" desc limit 1);
END;
END IF;



BecID := (select v."OrganisationID" from "vOrganisation" v  where v."OrganisationTypeID" = OrganisationTypeID and v."Name" = 'BE Consultancy Ltd' limit 1);

if(BecID is null)
THEN
BEGIN

BecID := ( SELECT * FROM public."fn_CreateOrganisationFromDefault"(OrganisationTypeID, DoTemplateID, DoVersionNumber,'BE Consultancy Ltd','BE Consultancy Ltd'));

END;
END IF;

-- get reseller products
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

-- SMS Enhanced ID Check
-- Base Product, can be resold, not plan
-- Has one attribute - (ID+)

TProductID := (select uuid_generate_v1());
TProductVersion = 1;
TPlanID := (select uuid_generate_v1());
TPlanVersion = 1;
PackageID :=  (select uuid_generate_v1());
PackageVersionID = 1;

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
  true,
  TProductVersion,
  BecID,
  BecID,
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
  'SMS Enhanced ID Check',
  '',
  true,
  false,
  5,
  5,
  false,
  false,
  false,
  0,
  (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Supplier Product' and "ClassificationTypeCategoryID" = 110 limit 1),
  TProductVersion,
  'GBP',
  1,
  'SMS Enhanced ID Check',
  false
);

-- add attribute

-- ID+
INSERT INTO
  public."ProductAttributeTemplate"
(
  "Name",
  "Description",
  "IsActive",
  "IsDeleted"
)
VALUES (
  'ID+',
  'ID+ Bank Account Validation for Individuals',
  true,
  false
);

INSERT INTO
  public."ProductProductAttributeTemplate"
(
  "ProductTemplateID",
  "ProductAttributeTemplateID",
  "IsRequired",
  "DisplayOrder",
  "ProductVersionID",
  "IsActive",
  "IsDeleted"
)
VALUES (
  TProductID,
  (select "ProductAttributeTemplateID" from "ProductAttributeTemplate"	where "Name" = 'ID+' limit 1),
  false,
  0,
  TProductVersion,
  true,
  false
);

INSERT INTO
  public."ProductVariantAttributeValueTemplate"
(
  "ProductProductAttributeTemplateID",
  "Name",
  "PriceAdjustment",
  "WeightAdjustment",
  "Cost",
  "Quantity",
  "IsPreSelected",
  "DisplayOrder",
  "IsActive",
  "IsDeleted"
)


VALUES (
  (select 	"ProductProductAttributeTemplateID" from
  	"ProductProductAttributeTemplate" where "ProductTemplateID" = TProductID and "ProductVersionID" = TProductVersion and "IsActive" = true and "IsDeleted" = false and "ProductAttributeTemplateID" = (select at."ProductAttributeTemplateID" from "ProductAttributeTemplate" at	where at."Name" = 'ID+' limit 1) limit 1 ),
  'ID+ Variant',
  0,
  0,
  0,
  1,
  true,
  0,
  true,
  false
);

-- add package
INSERT INTO
  public."PackageTemplate"
(
  "PackageTemplateID",
  "ProductTemplateID",
  "ProductVersionID",
  "IsActive",
  "IsDeleted",
  "PackageTemplateVersionNumber"
)
VALUES (
  PackageID,
  TProductID,
  TProductVersion,
  true,
  false,
  PackageVersionID
);

-- add other products to package

-- Experian KYC
INSERT INTO
  public."PackageProductTemplate"
(
  "PackageTemplateID",
  "UseProductDefaultBlueprint",
  "UseDefaultProductPricing",
  "IsFixedPrice",
  "ProductPriceModifierPercentage",
  "ProductPriceModifierValue",
  "DefaultQuantity",
  "UserDefinableQuantity",
  "IsActive",
  "IsDeleted",
  "ProductTemplateID",
  "ProductVersionID",
  "PackageTemplateVersionNumber"
)
VALUES (
  PackageID,
  true,
  true,
  true,
  0,
  0,
  1,
  false,
  true,
  false,
  ExperianKYCProductID,
  ExperianKYCProductVersionNumber,
  PackageVersionID
);

PackageProductID := (select pp."PackageProductTemplateID" from "PackageProductTemplate" pp where pp."PackageTemplateID" = PackageID and pp."PackageTemplateVersionNumber" = PackageVersionID
	and pp."ProductTemplateID" = ExperianKYCProductID and pp."ProductVersionID" = ExperianKYCProductVersionNumber limit 1);

INSERT INTO
  public."PackageProductRelationshipTemplate"
(
  "ParentProductTemplateID",
  "ChildProductTemplateID",
  "ProductRelationshipTypeID",
  "IsMandatory",
  "IsActive",
  "IsDeleted",
  "PackageProductTemplateID",
  "ParentProductVersionID",
  "ChildProductVersionID",
  "PackageTemplateID",
  "PackageTemplateVersionNumber"
)
VALUES (
  TProductID,
  ExperianKYCProductID,
  (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Default' and "ClassificationTypeCategoryID" = 1011 limit 1),
  true,
  true,
  false,
  PackageProductID,
  TProductVersion,
  ExperianKYCProductVersionNumber,
  PackageID,
  PackageVersionID
);

-- Experian Bank
INSERT INTO
  public."PackageProductTemplate"
(
  "PackageTemplateID",
  "UseProductDefaultBlueprint",
  "UseDefaultProductPricing",
  "IsFixedPrice",
  "ProductPriceModifierPercentage",
  "ProductPriceModifierValue",
  "DefaultQuantity",
  "UserDefinableQuantity",
  "IsActive",
  "IsDeleted",
  "ProductTemplateID",
  "ProductVersionID",
  "PackageTemplateVersionNumber",
  "RelatedProductProductAttributeTemplateID"

)
VALUES (
  PackageID,
  true,
  true,
  true,
  0,
  0,
  1,
  false,
  true,
  false,
  ExperianBankProductID,
  ExperianBankProductVersionNumber,
  PackageVersionID,
    (select 	"ProductProductAttributeTemplateID" from
  	"ProductProductAttributeTemplate" where "ProductTemplateID" = TProductID and "ProductVersionID" = TProductVersion and "IsActive" = true and "IsDeleted" = false and "ProductAttributeTemplateID" = (select at."ProductAttributeTemplateID" from "ProductAttributeTemplate" at	where at."Name" = 'ID+' limit 1) limit 1 )
        );

PackageProductID := (select pp."PackageProductTemplateID" from "PackageProductTemplate" pp where pp."PackageTemplateID" = PackageID and pp."PackageTemplateVersionNumber" = PackageVersionID
	and pp."ProductTemplateID" = ExperianBankProductID and pp."ProductVersionID" = ExperianBankProductVersionNumber limit 1);

INSERT INTO
  public."PackageProductRelationshipTemplate"
(
  "ParentProductTemplateID",
  "ChildProductTemplateID",
  "ProductRelationshipTypeID",
  "IsMandatory",
  "IsActive",
  "IsDeleted",
  "PackageProductTemplateID",
  "ParentProductVersionID",
  "ChildProductVersionID",
  "PackageTemplateID",
  "PackageTemplateVersionNumber"
)
VALUES (
  TProductID,
  ExperianBankProductID,
  (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Default' and "ClassificationTypeCategoryID" = 1011 limit 1),
  true,
  true,
  false,
  PackageProductID,
  TProductVersion,
  ExperianBankProductVersionNumber,
  PackageID,
  PackageVersionID
);




----- Safe Transaction Search
-- Base, can be resold

TProductID := (select uuid_generate_v1());
TProductVersion = 1;
TPlanID := (select uuid_generate_v1());
TPlanVersion = 1;
PackageID :=  (select uuid_generate_v1());
PackageVersionID = 1;

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
  true,
  TProductVersion,
  BecID,
  BecID,
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
  'SMS Safe Transaction Search',
  '',
  true,
  false,
  30,
  30,
  false,
  true,
  false,
  0,
  (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Supplier Product' and "ClassificationTypeCategoryID" = 110 limit 1),
  TProductVersion,
  'GBP',
  1,
  'SMS Safe Transaction Search',
  false
);

-- Insurance Attribute
INSERT INTO
  public."ProductAttributeTemplate"
(
  "Name",
  "Description",
  "IsActive",
  "IsDeleted"
)
VALUES (
  'DUAL Hijack Insurance',
  'DUAL Hijack Insurance',
  true,
  false
);

INSERT INTO
  public."ProductProductAttributeTemplate"
(
  "ProductTemplateID",
  "ProductAttributeTemplateID",
  "IsRequired",
  "DisplayOrder",
  "ProductVersionID",
  "IsActive",
  "IsDeleted"
)
VALUES (
  TProductID,
  (select "ProductAttributeTemplateID" from "ProductAttributeTemplate"	where "Name" = 'DUAL Hijack Insurance' limit 1),
  false,
  0,
  TProductVersion,
  true,
  false
);

INSERT INTO
  public."ProductVariantAttributeValueTemplate"
(
  "ProductProductAttributeTemplateID",
  "Name",
  "PriceAdjustment",
  "WeightAdjustment",
  "Cost",
  "Quantity",
  "IsPreSelected",
  "DisplayOrder",
  "IsActive",
  "IsDeleted"
)


VALUES (
  (select 	"ProductProductAttributeTemplateID" from
  	"ProductProductAttributeTemplate" where "ProductTemplateID" = TProductID and "ProductVersionID" = TProductVersion and "IsActive" = true and "IsDeleted" = false and "ProductAttributeTemplateID" = (select at."ProductAttributeTemplateID" from "ProductAttributeTemplate" at	where at."Name" = 'DUAL Hijack Insurance' limit 1) limit 1 ),
  'DUAL Hijack Insurance',
  0,
  0,
  0,
  1,
  true,
  0,
  true,
  false
);


-- add package
INSERT INTO
  public."PackageTemplate"
(
  "PackageTemplateID",
  "ProductTemplateID",
  "ProductVersionID",
  "IsActive",
  "IsDeleted",
  "PackageTemplateVersionNumber"
)
VALUES (
  PackageID,
  TProductID,
  TProductVersion,
  true,
  false,
  PackageVersionID
);

-- add other products to package

-- Insurance
INSERT INTO
  public."PackageProductTemplate"
(
  "PackageTemplateID",
  "UseProductDefaultBlueprint",
  "UseDefaultProductPricing",
  "IsFixedPrice",
  "ProductPriceModifierPercentage",
  "ProductPriceModifierValue",
  "DefaultQuantity",
  "UserDefinableQuantity",
  "IsActive",
  "IsDeleted",
  "ProductTemplateID",
  "ProductVersionID",
  "PackageTemplateVersionNumber",
  "RelatedProductProductAttributeTemplateID"
)
VALUES (
  PackageID,
  true,
  true,
  true,
  0,
  0,
  1,
  false,
  true,
  false,
  InsuranceProductID,
  InsuranceProductVersionNumber,
  PackageVersionID,
(select"ProductProductAttributeTemplateID" from
  	"ProductProductAttributeTemplate" where "ProductTemplateID" = TProductID and "ProductVersionID" = TProductVersion and "IsActive" = true and "IsDeleted" = false and "ProductAttributeTemplateID" = (select at."ProductAttributeTemplateID" from "ProductAttributeTemplate" at	where  at."Name" = 'ID+' limit 1) limit 1 )
);




PackageProductID := (select pp."PackageProductTemplateID" from "PackageProductTemplate" pp where pp."PackageTemplateID" = PackageID and pp."PackageTemplateVersionNumber" = PackageVersionID
	and pp."ProductTemplateID" = InsuranceProductID and pp."ProductVersionID" = InsuranceProductVersionNumber limit 1);

INSERT INTO
  public."PackageProductRelationshipTemplate"
(
  "ParentProductTemplateID",
  "ChildProductTemplateID",
  "ProductRelationshipTypeID",
  "IsMandatory",
  "IsActive",
  "IsDeleted",
  "PackageProductTemplateID",
  "ParentProductVersionID",
  "ChildProductVersionID",
  "PackageTemplateID",
  "PackageTemplateVersionNumber"
)
VALUES (
  TProductID,
  InsuranceProductID,
  (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Default' and "ClassificationTypeCategoryID" = 1011 limit 1),
  true,
  true,
  false,
  PackageProductID,
  TProductVersion,
  InsuranceProductVersionNumber,
  PackageID,
  PackageVersionID
);

-- LAND Registry Title Official Copies

-- Base, can be resold

TProductID := (select uuid_generate_v1());
TProductVersion = 1;
TPlanID := (select uuid_generate_v1());
TPlanVersion = 1;
PackageID :=  (select uuid_generate_v1());
PackageVersionID = 1;

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
  true,
  TProductVersion,
  BecID,
  BecID,
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
  'Title Official Copies',
  '',
  true,
  false,
  3,
  3,
  false,
  true,
  false,
  0,
  (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Supplier Product' and "ClassificationTypeCategoryID" = 110 limit 1),
  TProductVersion,
  'GBP',
  1,
  'Title Official Copies',
  false
);

----- Title Plan Copied
-- Base, can be resold

TProductID := (select uuid_generate_v1());
TProductVersion = 1;
TPlanID := (select uuid_generate_v1());
TPlanVersion = 1;
PackageID :=  (select uuid_generate_v1());
PackageVersionID = 1;

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
  true,
  TProductVersion,
  BecID,
  BecID,
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
  'Title Plan Copies',
  '',
  true,
  false,
  3,
  3,
  false,
  true,
  false,
  0,
  (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Supplier Product' and "ClassificationTypeCategoryID" = 110 limit 1),
  TProductVersion,
  'GBP',
  1,
  'Title Plan Copies',
  false
);
END $$;