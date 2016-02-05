insert into public."Resource"("ResourceID", "ResourceName", "ResourceDescription", "IsActive")
values (uuid_generate_v1(), 'SmsTransactionsOverview', 'SmsTransactionsOverview', TRUE);

INSERT INTO public."Role" ("RoleID", "RoleName", "RoleDescription", "RoleTypeID", "RoleSubTypeID", "RoleCategoryID", "RoleSubCategoryID", "IsActive", "IsDeleted", "IsGlobal")
VALUES (uuid_generate_v1(), E'Lender Employee', E'Lender Employee Role',
(select dot."ClassificationTypeID" from "ClassificationType" dot where dot."ClassificationTypeCategoryID" = 130 and dot."Name" = 'Global' limit 1),
 NULL, NULL, NULL, True, False, True);
 
 -- Lender Administrator SmsTransactionsOverview
    insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Lender Administrator' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'SmsTransactionsOverview' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1), TRUE);
  
     -- Lender Employee view homepage
    insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Lender Employee' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'Home' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1), TRUE);

  -- Lender Employee SmsTransactionsOverview
    insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Lender Employee' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'SmsTransactionsOverview' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1), TRUE);