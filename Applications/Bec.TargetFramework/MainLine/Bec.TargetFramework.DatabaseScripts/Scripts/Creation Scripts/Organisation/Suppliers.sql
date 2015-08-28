
-- Temp Organisation
DO $$
Declare DoTemplateID uuid;
Declare DoVersionNumber integer;
Declare OrganisationTypeID integer;
Begin

-- declare variables
OrganisationTypeID := (select "OrganisationTypeID" from "OrganisationType" where "Name" = 'Supplier' limit 1);

INSERT INTO
  public."DefaultOrganisationTemplate"
(
  "DefaultOrganisationTemplateVersionNumber",
  "Name",
  "Description",
  "IsActive",
  "IsDeleted",
  "OrganisationTypeID"
)
VALUES (
  1,
  'Supplier',
  'Template for a Supplier Organisation',
  true,
  false,
  OrganisationTypeID
);

DoTemplateID:= (select dot."DefaultOrganisationTemplateID" from "DefaultOrganisationTemplate" dot where dot."Name" = 'Supplier' limit 1);
DoVersionNumber = 1;

-- add 2 ledger accounts
INSERT INTO
  public."DefaultOrganisationLedgerTemplate"
(
  "DefaultOrganisationTemplateID",
  "DefaultOrganisationTemplateVersionNumber",
  "LedgerAccountTypeID",
  "LedgerAccountName",
  "HandlesCredit",
  "HandlesDebit",
  "IsActive",
  "IsDeleted"
)
VALUES (
  DoTemplateID,
  DoVersionNumber,
  (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Sales' and "ClassificationTypeCategoryID" = 8500 limit 1),
  'Sales',
  true,
  false,
  true,
  false
);

INSERT INTO
  public."DefaultOrganisationLedgerTemplate"
(
  "DefaultOrganisationTemplateID",
  "DefaultOrganisationTemplateVersionNumber",
  "LedgerAccountTypeID",
  "LedgerAccountName",
  "HandlesCredit",
  "HandlesDebit",
  "IsActive",
  "IsDeleted"
)
VALUES (
  DoTemplateID,
  DoVersionNumber,
  (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Purchasing' and "ClassificationTypeCategoryID" = 8500 limit 1),
  'Purchasing',
  false,
  true,
  true,
  false
);


-- promote supplier DO
perform "fn_PromoteDefaultOrganisationTemplate"(DoTemplateID, DoVersionNumber);



END $$;