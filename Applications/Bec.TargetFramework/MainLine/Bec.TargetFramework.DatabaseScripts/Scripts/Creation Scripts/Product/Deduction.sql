

DO $$
Declare DeductionTemplateID UUID;
Declare DeductionVersionNumber integer;
Begin

DeductionTemplateID := uuid_generate_v1();
DeductionVersionNumber = 1;


--VAT

-- Deduction Template for UK
INSERT INTO
  public."DeductionTemplate"
(
"DeductionTemplateID",
  "DeductionTypeID",
  "Name",
  "Description",
  "IsActive",
  "IsDeleted",
  "IsPercentageBased",
  "DeductionTemplateVersionNumber",
  "IsTierDeduction",
  "IsCheckoutDeduction"
)
VALUES (
  DeductionTemplateID,
  (select c."ClassificationTypeID" from "ClassificationType" c where c."ClassificationTypeCategoryID" = 70 and c."Name" = 'Sales Tax' limit 1),
  'VAT',
  'Value Added Tax',
  true,
  false,
  true,
  1,
  false,
  true
);

INSERT INTO
  public."CountryDeductionTemplate"
(
  "DeductionTemplateID",
  "CountryCode",
  "DeductionPercentage",
  "DeductionValue",
  "IsActive",
  "IsDeleted",
  "IsAppliedToAllOrders",
  "DeductionTemplateVersionNumber"
)
Values(
DeductionTemplateID,
'UK',
0.20,
0,
true,
false,
true,
DeductionVersionNumber
);

-- Deduction for UK
INSERT INTO
  public."Deduction"
(
  "DeductionTypeID",
  "Name",
  "Description",
  "IsActive",
  "IsDeleted",
  "IsPercentageBased",
  "DeductionVersionNumber",
  "IsTierDeduction",
  "IsCheckoutDeduction",
  "DeductionTemplateID",
  "DeductionTemplateVersionNumber"
)
select
dt."DeductionTypeID",
dt."Name",
dt."Description",
true,
false,
true,
1,
dt."IsTierDeduction",
dt."IsCheckoutDeduction",
dt."DeductionTemplateID",
dt."DeductionTemplateVersionNumber"

  from "DeductionTemplate" dt where dt."DeductionTemplateID" = DeductionTemplateID and dt."DeductionTemplateVersionNumber" = DeductionVersionNumber;

INSERT INTO
  public."CountryDeduction"
(
  "CountryCode",
  "DeductionPercentage",
  "DeductionValue",
  "IsActive",
  "IsDeleted",
  "IsAppliedToAllOrders",
  "DeductionID",
  "DeductionVersionNumber"
)
SELECT
  cdt."CountryCode",
  cdt."DeductionPercentage",
 cdt."DeductionValue",
  true,
  false,
  cdt."IsAppliedToAllOrders",
  d."DeductionID",
  d."DeductionVersionNumber"
FROM
  public."CountryDeductionTemplate" cdt

   left outer join "Deduction" d on d."DeductionTemplateID" = DeductionTemplateID and d."DeductionTemplateVersionNumber" = DeductionVersionNumber

   where cdt."DeductionTemplateID"= DeductionTemplateID and cdt."DeductionTemplateVersionNumber" = DeductionVersionNumber
  ;


DeductionTemplateID := uuid_generate_v1();
DeductionVersionNumber = 1;

-- FIRST DATA PRODUCT AS DEDUCTION
INSERT INTO
  public."DeductionTemplate"
(
  "DeductionTemplateID",
  "DeductionTypeID",
  "Name",
  "Description",
  "IsActive",
  "IsDeleted",
  "IsPercentageBased",
  "DeductionTemplateVersionNumber",
  "IsTierDeduction",
  "IsCheckoutDeduction"
)
VALUES (
  DeductionTemplateID,
  (select c."ClassificationTypeID" from "ClassificationType" c where c."ClassificationTypeCategoryID" = 70 and c."Name" = 'Card Processing Fee' limit 1),
  'Card Processing Fee',
  'Card Processing Fee',
  true,
  false,
  true,
  DeductionVersionNumber,
  true,
  true
);

INSERT INTO
  public."CountryDeductionTemplate"
(
  "DeductionTemplateID",
  "CountryCode",
  "DeductionPercentage",
  "DeductionValue",
  "IsActive",
  "IsDeleted",
  "IsAppliedToAllOrders",
  "DeductionTemplateVersionNumber"
)
VALUES(
DeductionTemplateID,
'UK',
0,
0,
true,
false,
true,
DeductionVersionNumber
);

INSERT INTO
  public."DeductionProductTemplate"
(
  "DeductionTemplateID",
  "DeductionTemplateVersionNumber",
  "ProductTemplateID",
  "ProductVersionID"
)
VALUES (
  DeductionTemplateID,
  DeductionVersionNumber,
  (select "ProductTemplateID" from "ProductDetailTemplate" where "Name" = 'Firstdata Processing Fee' limit 1),
  (select "ProductVersionID" from "ProductDetailTemplate" where "Name" = 'Firstdata Processing Fee' limit 1)
);

INSERT INTO
  public."Deduction"
(
  "DeductionTypeID",
  "Name",
  "Description",
  "IsActive",
  "IsDeleted",
  "IsPercentageBased",
  "DeductionVersionNumber",
  "IsTierDeduction",
  "IsCheckoutDeduction",
  "DeductionTemplateID",
  "DeductionTemplateVersionNumber"
)
select
dt."DeductionTypeID",
dt."Name",
dt."Description",
true,
false,
true,
1,
dt."IsTierDeduction",
dt."IsCheckoutDeduction",
dt."DeductionTemplateID",
dt."DeductionTemplateVersionNumber"

  from "DeductionTemplate" dt where

  dt."DeductionTemplateID" = DeductionTemplateID and dt."DeductionTemplateVersionNumber" = DeductionVersionNumber

  ;



INSERT INTO
  public."CountryDeduction"
(
  "CountryCode",
  "DeductionPercentage",
  "DeductionValue",
  "IsActive",
  "IsDeleted",
  "IsAppliedToAllOrders",
  "DeductionID",
  "DeductionVersionNumber"
)
SELECT
  cdt."CountryCode",
  cdt."DeductionPercentage",
 cdt."DeductionValue",
  true,
  cdt."IsDeleted",
  cdt."IsAppliedToAllOrders",
  d."DeductionID",
  d."DeductionVersionNumber"
FROM
  public."CountryDeductionTemplate" cdt

  left outer join "Deduction" d on d."DeductionTemplateID" = cdt."DeductionTemplateID" and d."DeductionTemplateVersionNumber" = cdt."DeductionTemplateVersionNumber"

  where cdt."CountryCode" = 'UK' and cdt."DeductionTemplateID" = DeductionTemplateID and cdt."DeductionTemplateVersionNumber" = DeductionVersionNumber

  ;

INSERT INTO
  public."DeductionProduct"
(
  "DeductionID",
  "DeductionVersionNumber",
  "ProductID",
  "ProductVersionID"
)

SELECT
  d."DeductionID",
 d."DeductionVersionNumber",
 p."ProductID",
 p."ProductVersionID"
FROM
  public."DeductionProductTemplate" dt

    left outer join "Deduction" d on d."DeductionTemplateID" = dt."DeductionTemplateID" and d."DeductionTemplateVersionNumber" = dt."DeductionTemplateVersionNumber"
  left outer join "Product" p on p."ProductTemplateID" = dt."ProductTemplateID" and p."ProductTemplateVersionID" =dt."ProductVersionID"

   where dt."DeductionTemplateID" = DeductionTemplateID and dt."DeductionTemplateVersionNumber" = DeductionVersionNumber

  ;
END $$;