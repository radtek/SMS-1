create view "vOrganisationWithStatusAndAdmin" as

select

org."OrganisationID",
orgd."Name" as "Name",
org."CreatedOn",
(case when vst."Name" = 'Verified' then true else false END) as "OrganisationVerified",
org."CompanyPinCreated"	 as "OrganisationPinCreated",
org."CompanyPinCreated" as  "OrganisationPinCode",

uaoC."Salutation" as "OrganisationAdminSalutation",
uaoC."FirstName" as "OrganisationAdminFirstName",
uaoC."LastName" as  "OrganisationAdminLastName",
uaoC."Telephone1" as "OrganisationAdminTelephone",
ua."Email" as "OrganisationAdminEmail",

conReg."RegulatorName" as "Regulator",
conReg."RegulatorOtherName" as "RegulatorOther",

addr."Line1",
addr."Line2",
addr."Town",
addr."County",
addr."PostalCode",
addr."AdditionalAddressInformation",

orgs."StatusTypeID",
orgs."StatusTypeValueID",
orgs."StatusTypeVersionNumber",

ua."ID" as "OrganisationAdminUserID"

from "Organisation" org

left outer join "OrganisationDetail" orgd on orgd."OrganisationID" = org."OrganisationID"

left outer join "OrganisationType" orgt on orgt."OrganisationTypeID" = org."OrganisationTypeID"

left outer join "OrganisationStatus" orgs on orgs."OrganisationID" = org."OrganisationID"

left outer join "vStatusType" vst on vst."StatusTypeID" = orgs."StatusTypeID" and vst."StatusTypeValueID" = orgs."StatusTypeValueID" and vst."StatusTypeVersionNumber" = orgs."StatusTypeVersionNumber"

left outer join "UserAccountOrganisation" uao on uao."OrganisationID" = org."OrganisationID" and uao."UserTypeID" = (select ut."UserTypeID" from "UserType" ut where ut."Name" = 'Organisation Administrator' limit 1)

left outer join "Contact" orgC on orgC."ParentID" = org."OrganisationID"  and orgC."IsPrimaryContact" = true

left outer join "Contact" uaoC on uaoC."ParentID" = uao."UserAccountOrganisationID" and uaoC."IsPrimaryContact" = true

left outer join "UserAccounts" ua on ua."ID" = uao."UserID"

left outer join "Address" addr on addr."ParentID" = orgC."ContactID"
	and addr."IsPrimaryAddress" = true

left outer join "ContactRegulator" conReg on conReg."ContactID" = orgC."ContactID"
