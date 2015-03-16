-- BEC Products


DO $$
Declare BecID uuid;
Begin

BecID := (select "OrganisationID" from "OrganisationDetail" where "Name" = 'BE Consultancy Ltd' limit 1 );

-- create contact
INSERT INTO
  public."Contact"
(
  "ContactID",
  "ContactName",
  "ParentID",
  "IsBackOfficeCustomer",
  "IsPrimaryContact",
  "IsActive",
  "IsDeleted",
  "FirmName"
)
VALUES (
  'b7fd2ace-4f8f-11e4-b798-1f0fe2f1a871',
  'Company Contact',
  BecID,
  false,
  true,
  true,
  false,
  'BE Consultancy Ltd'
);

-- address
INSERT INTO
  public."Address"
(
  "Name",
  "Line1",
  "City",
  "County",
  "Country",
  "PostalCode",
  "ParentID",
  "AddressTypeID",
  "IsPrimaryAddress",
  "BuildingName",
  "IsActive",
  "IsDeleted",
  "CountryCode"
)
VALUES (
  'Address',
  '114-116 Main Road',
  'Sidcup',
  'Kent',
  'United Kingdom',
  'DA14 6NG',
  'b7fd2ace-4f8f-11e4-b798-1f0fe2f1a871',
  (select "classificationtypeid" from "vClassification" where "name" = 'Work' and "categoryname" = 'AddressTypeID' limit 1),
  true,
  'Marlesfield House',
  true,
  false,
  'UK'
);

update "OrganisationDetail"

set "OrganisationLegalBlurb" = '''Safe Move Scheme'' is a trading name of BE Consultancy Ltd, Registered Company in England. 05742032 Registered Address: Marlesfield House, 114-116 Main Road, Kent, DA14 6NG. VAT no. 924 813 717'

where "OrganisationID" = BecID;

END $$;