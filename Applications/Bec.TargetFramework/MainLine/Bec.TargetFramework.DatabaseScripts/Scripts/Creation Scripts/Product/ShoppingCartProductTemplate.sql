

-- STS Buyer Shopping Cart Template
DO $$
Declare IDCheckProductID uuid;
Declare IDCheckProductVN integer;
Declare SMSProductID uuid;
Declare SMSProductVN integer;
Declare BecOrgID uuid;
Declare BlueprintTemplateID uuid;

Begin

BecOrgID := (select "OrganisationID" from "vOrganisation" where "OrganisationTypeID" = 22 limit 1);

IDCheckProductID := (select pd."ProductTemplateID" from "ProductDetailTemplate" pd where pd."Name" = 'SMS Enhanced ID Check' limit 1);
IDCheckProductVN := (select pd."ProductVersionID" from "ProductDetailTemplate" pd where pd."Name" = 'SMS Enhanced ID Check' limit 1);
SMSProductID := (select pd."ProductTemplateID" from "ProductDetailTemplate" pd where pd."Name" = 'SMS Safe Transaction Search' limit 1);
SMSProductVN := (select pd."ProductVersionID" from "ProductDetailTemplate" pd where pd."Name" = 'SMS Safe Transaction Search' limit 1);
BlueprintTemplateID := uuid_generate_v1();

INSERT INTO
  public."ShoppingCartBlueprintTemplate"
(
  "ShoppingCartBlueprintTemplateID",
  "ParentID",
  "IsActive",
  "IsDeleted",
  "Name"
)
VALUES (
  BlueprintTemplateID,
  BecOrgID,
  true,
  false,
  'SMS Buyer Shopping Cart Blueprint'
);

-- add products to blueprint template
INSERT INTO
  public."ShoppingCartBlueprintProductTemplate"
(
  "ShoppingCartBlueprintTemplateID",
  "ProductTemplateID",
  "ProductVersionID",
  "Quantity",
  "IsActive",
  "IsDeleted"
)
VALUES (
  BlueprintTemplateID,
  IDCheckProductID,
  IDCheckProductVN,
  1,
  true,
  false
);

INSERT INTO
  public."ShoppingCartBlueprintProductTemplate"
(
  "ShoppingCartBlueprintTemplateID",
  "ProductTemplateID",
  "ProductVersionID",
  "Quantity",
  "IsActive",
  "IsDeleted"
)
VALUES (
  BlueprintTemplateID,
  SMSProductID,
  SMSProductVN,
  1,
  true,
  false
);

-- promote template
perform "fn_PromoteShoppingCartBlueprintTemplate"(BlueprintTemplateID);

-- add entry to organisation

INSERT INTO
  public."OrganisationShoppingCartBlueprint"
(
  "OrganisationID",
  "ShoppingCartBlueprintID",
  "IsActive",
  "IsDeleted"
)
VALUES (
  BecOrgID,
  (select "ShoppingCartBlueprintID" from "ShoppingCartBlueprint" where "ParentID" = BlueprintTemplateID limit 1),
  true,
  false
);


END $$;