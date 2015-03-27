DO $$
Declare TempDO UUID;
Declare TempDOVN integer;
Declare UserID UUID;
Declare UserTypeID UUID;
Declare OrganisationID UUID;

Begin

TempDO := (select "DefaultOrganisationID" from "DefaultOrganisation" d where d."Name" = 'Professional Organisation');
TempDOVN = 1;
UserTypeID := (select "UserTypeID" from "UserType" where "Name" = 'Organisation Administrator');
UserID := (select "ID" from "UserAccounts" where "Username" = 'TestAdmin' limit 1);

perform  public."fn_CreateOrganisationFromDefault"(27, TempDO, TempDOVN, 'Test Professional Organisation', '');

OrganisationID := (select "OrganisationID" from "vOrganisation" where "Name" = 'Test Professional Organisation' limit 1);

perform public."fn_AddUserToOrganisation"(UserID, OrganisationID, UserTypeID, OrganisationID);

END $$;