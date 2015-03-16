DO $$
Declare TempDO UUID;
Declare TempDOVN integer;
Begin

TempDO := (select "DefaultOrganisationID" from "DefaultOrganisation" d where d."Name" = 'Temporary');
TempDOVN = 1;



perform  public."fn_CreateOrganisationFromDefault"(27, TempDO, TempDOVN, 'Temporary Organisation', '');

END $$;