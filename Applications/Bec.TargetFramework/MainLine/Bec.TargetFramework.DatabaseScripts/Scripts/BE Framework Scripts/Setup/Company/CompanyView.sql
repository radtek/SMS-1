CREATE OR REPLACE VIEW public."vCompany"(
    "CompanyId",
    "CompanyName",
    "CompanyRecordCreated",
    "IsCompanyVerified",
    "IsCompanyPinCreated",
    "CompanyPinCode",
    "CompanyPinCreated",
    "SystemAdminTitle",
    "SystemAdminFirstName",
    "SystemAdminLastName",
    "SystemAdminTel",
    "SystemAdminEmail",
    "CompanyRegulator",
    "CompanyOtherRegulator",
    "CompanyAddress1",
    "CompanyAddress2",
    "CompanyTownCity",
    "CompanyCounty",
    "CompanyPostCode",
    "AdditionalAddressInformation")
AS
  SELECT o."OrganisationID" AS "CompanyId",
         od."Name" AS "CompanyName",
         o."CreatedOn" AS "CompanyRecordCreated",
         o."IsCompanyVerified",
         o."IsCompanyPinCreated",
         o."CompanyPinCode",
         o."CompanyPinCreated",
         c."Salutation" AS "SystemAdminTitle",
         c."FirstName" AS "SystemAdminFirstName",
         c."LastName" AS "SystemAdminLastName",
         c."Telephone1" AS "SystemAdminTel",
         c."EmailAddress1" AS "SystemAdminEmail",
         cr."RegulatorName" AS "CompanyRegulator",
         cr."RegulatorOtherName" AS "CompanyOtherRegulator",
         a."Line1" AS "CompanyAddress1",
         a."Line2" AS "CompanyAddress2",
         a."Town" AS "CompanyTownCity",
         a."County" AS "CompanyCounty",
         a."PostalCode" AS "CompanyPostCode",
         a."AdditionalAddressInformation"
  FROM "Organisation" o
       LEFT JOIN "OrganisationDetail" od ON o."OrganisationID" =
         od."OrganisationID"
       LEFT JOIN "Contact" c ON o."OrganisationID" = c."ParentID"
       LEFT JOIN "ContactRegulator" cr ON c."ContactID" = cr."ContactID"
       LEFT JOIN "Address" a ON a."ParentID" = cr."ContactID";