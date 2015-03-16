-- Test Specs and Attributes
INSERT INTO
  public."SpecificationAttributeTemplate"
(
  "Name",
  "Description",
  "DisplayOrder",
  "Order"
)
VALUES (
  'Test Spec',
  '',
  0,
  0
);

INSERT INTO
  public."SpecificationAttributeOptionTemplate"
(
  "SpecificationAttributeTemplateID",
  "Name",
  "Description",
  "DisplayOrder",
  "Order"
)
select
sat."SpecificationAttributeTemplateID",
'Test Spec Option',
'',
0,
0

from

"SpecificationAttributeTemplate" sat where sat."Name" = 'Test Spec';

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
  st."SpecificationAttributeTemplateID",
  st."Name",
  st."Description",
  st."DisplayOrder",
  st."IsActive",
  st."IsDeleted",
  st. "SpecificationAttributeTypeID",
  st."SpecificationAttributeCategoryID",
  st."SpecificationAttributeSubTypeID",
  st."SpecificationAttributeSubCategoryID"
FROM
  public."SpecificationAttributeTemplate" st where st."Name" = 'Test Spec';

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
  sot."SpecificationAttributeOptionTemplateID",
  sa1."SpecificationAttributeID",
  sot."DisplayOrder",
  sot."Name",
  sot."Description",
  sot."IsActive",
  sot."IsDeleted"
FROM
  public."SpecificationAttributeOptionTemplate" sot

  left outer join "SpecificationAttribute" sa1 on sa1."Name" = 'Test Spec'
  ;

INSERT INTO
  public."ProductAttributeTemplate"
(
  "Name"
)
VALUES (
  'Test Attribute'
);

INSERT INTO
  public."ProductAttribute"
(
  "Name",
  "Description",
  "IsActive",
  "IsDeleted"
)
SELECT
  st."Name",
  st."Description",
  st."IsActive",
  st."IsDeleted"
FROM
  public."ProductAttributeTemplate" st where st."Name" = 'Test Attribute';



DO $$
Declare ProductAttributeID UUID;
Declare SpecID UUID;
Declare SpecOptionID UUID;
Declare ProductID UUID;
Declare ProductVN integer;
Begin

ProductAttributeID := (SELECT
  "ProductAttributeID"
FROM
  public."ProductAttribute" where "Name" = 'Test Attribute' limit 1);


SpecID := (SELECT
  "SpecificationAttributeID"
FROM
  public."SpecificationAttribute" where "Name" = 'Test Spec' limit 1);

SpecOptionID := (SELECT
  "SpecficiationAttributeOptionID"
FROM
  public."SpecificiationAttributeOption" where "SpecificationAttributeID" = SpecID limit 1);


ProductID := (select "ProductID" from "ProductDetail" where "Name" = 'SMS Enhanced ID Check' limit 1);
ProductVN := (select "ProductVersionID" from "ProductDetail" where "Name" = 'SMS Enhanced ID Check' limit 1);

-- create links
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
VALUES (
  ProductID,
  ProductAttributeID,
  true,
  0,
  ProductVN,
  true,
  false
);

INSERT INTO
  public."ProductSpecificationAttribute"
(
  "ProductID",
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
  "ProductVersionID",
  "IsMandatory"
)
VALUES (
  ProductID,
  false,
  0,
  true,
  1,
  1,
  false,
  false,
  SpecID,
  true,
  false,
  ProductVN,
  true
);

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
VALUES (
  (select "ProductSpecificationAttributeID" from "ProductSpecificationAttribute" where "ProductID" = ProductID and "ProductVersionID" = ProductVN limit 1),
  SpecOptionID,
  0,
  0,
  1,
  2,
  1,
  0,
   true,
  false
);

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
VALUES (
  ProductID,
  (select "ProductSpecificationAttributeID" from "ProductSpecificationAttribute" where "ProductID" = ProductID and "ProductVersionID" = ProductVN limit 1),
  (select "ProductSpecificationAttributeOptionID" from "ProductSpecificationAttributeOption" where "ProductSpecificationAttributeID" =  (select "ProductSpecificationAttributeID" from "ProductSpecificationAttribute" where "ProductID" = ProductID and "ProductVersionID" = ProductVN limit 1) limit 1),
   true,
  false,
  ProductVN
);

END $$;

-- variants
DO $$
Declare ProductProductAttributeID UUID;
Declare SpecID UUID;
Declare SpecOptionID UUID;
Declare ProductID UUID;
Declare ProductVN integer;
Begin

ProductProductAttributeID := (SELECT
  "ProductProductAttributeID"
FROM
  public."ProductProductAttribute" where "ProductAttributeID" = (select "ProductAttributeID" from "ProductAttribute" where "Name" = 'Test Attribute' limit 1) limit 1);

ProductID := (select "ProductID" from "ProductDetail" where "Name" = 'SMS Enhanced ID Check' limit 1);
ProductVN := (select "ProductVersionID" from "ProductDetail" where "Name" = 'SMS Enhanced ID Check' limit 1);

INSERT INTO
  public."ProductVariantAttributeValue"
(
  "ProductProductAttributeID",
  "Name",
  "PriceAdjustment",
  "WeightAdjustement",
  "Cost",
  "Quantity",
  "IsPreSelected",
  "DisplayOrder"
)
VALUES (
  ProductProductAttributeID,
  'Test Attribute Value',
  0,
  0,
  2,
  1,
  true,
  0
);


END $$;

-- variants
DO $$
Declare ProductProductAttributeID UUID;
Declare SpecID UUID;
Declare SpecOptionID UUID;
Declare ProductID UUID;
Declare ProductVN integer;
Begin

ProductID := (select "ProductID" from "ProductDetail" where "Name" = 'SMS Enhanced ID Check' limit 1);
ProductVN := (select "ProductVersionID" from "ProductDetail" where "Name" = 'SMS Enhanced ID Check' limit 1);

INSERT INTO
  public."DiscountTemplate"
(
  "DiscountTemplateVersionNumber",
  "Name",
  "Description",
  "InvoiceName",
  "DiscountTypeID",
  "DiscountPercentage",
  "DiscountAmount",
  "DiscountQuantity",
  "ValidTill",
  "CreatedOn",
  "IsActive",
  "IsDeleted",
  "IsRecurring",
  "IsPercentage",
  "DiscountStatusID",
  "IsSingleProductDiscount"
)
VALUES (
  1,
  'Test Product Discount',
  'Test',
  'Test',
  (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Fixed Amount' and "ClassificationTypeCategoryID" = 8008 limit 1),
  0.05,
  0,
  1,
  CURRENT_DATE,
  CURRENT_DATE,
  true,
  false,
  false,
  true,
  (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Active' and "ClassificationTypeCategoryID" = 8010 limit 1),
  true
);

INSERT INTO
  public."Discount"
(
  "DiscountVersionNumber",
  "Name",
  "Description",
  "InvoiceName",
  "DiscountTypeID",
  "DiscountPercentage",
  "DiscountAmount",
  "DiscountQuantity",
  "DiscountPeriod",
  "DisocuntPeriodUnitID",
  "ValidTill",
  "MaxRedemptions",
  "DiscountApplyOnID",
  "CreatedOn",
  "IsActive",
  "IsDeleted",
  "IsRecurring",
  "IsPercentage",
  "ParentID",
  "DiscountStatusID",
  "IsSingleProductDiscount",
  "IsCheckoutDiscount",
  "IsSingleProductQuantityDiscount",
  "SingleProductQuantityDiscountDivisor",
  "IsSingleProductQuantityDiscountPercentageBased",
  "IsSingleProductQuantityDiscountAdditionalQuantityBased",
  "SingleProductQuantityDiscountAdditionalQuantity",
  "IsMultipleProductCombinationDiscount",
  "IsMultipleProductCombinationDiscountPercentageBased",
  "IsMultipleProductCombinationDiscountCheapestFreeBased"
)
SELECT
  1,
  "Name",
  "Description",
  "InvoiceName",
  "DiscountTypeID",
  "DiscountPercentage",
  "DiscountAmount",
  "DiscountQuantity",
  "DiscountDurationTypeID",
  "DiscountDurationMonth",
  "ValidTill",
  "MaxRedemptions",
  "DiscountApplyOnID",
  "CreatedOn",
  "IsActive",
  "IsDeleted",
  "IsRecurring",
  "IsPercentage",
  "ParentID",
  "DiscountStatusID",
  "IsSingleProductDiscount",
  "IsCheckoutDiscount",
  "IsSingleProductQuantityDiscount",
  "SingleProductQuantityDiscountDivisor",
  "IsSingleProductQuantityDiscountPercentageBased",
  "IsSingleProductQuantityDiscountAdditionalQuantityBased",
  "SingleProductQuantityDiscountAdditionalQuantity",
  "IsMultipleProductCombinationDiscount",
  "IsMultipleProductCombinationDiscountPercentageBased",
  "IsMultipleProductCombinationDiscountCheapestFreeBased"
FROM
  public."DiscountTemplate" where "Name" = 'Test Product Discount';

-- create product link
INSERT INTO
  public."ProductDiscount"
(
  "ProductID",
  "ProductVersionID",
  "DiscountID",
  "DiscountVersionNumber",
  "IsActive",
  "IsDeleted"
)
VALUES (
  ProductID,
  ProductVN,
  (select "DiscountID" from "Discount" where "Name" ='Test Product Discount' limit 1 ) ,
  (select "DiscountVersionNumber" from "Discount" where "Name" ='Test Product Discount' limit 1 ) ,
  true,
  false
);



END $$;
