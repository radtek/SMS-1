/* Data for the 'public.Role' table  (Records 1 - 10) */

INSERT INTO public."Role" ("RoleID", "RoleName", "RoleDescription", "RoleTypeID", "RoleSubTypeID", "RoleCategoryID", "RoleSubCategoryID", "IsActive", "IsDeleted", "IsGlobal")
VALUES (E'a1d1f8b2-2139-11e4-b1aa-a7c8d954f17c', E'User', E'User Role',
(select dot."ClassificationTypeID" from "ClassificationType" dot where dot."ClassificationTypeCategoryID" = 130 and dot."Name" = 'Default Organisation' limit 1),
 NULL, NULL, NULL, True, False, True);

INSERT INTO public."Role" ("RoleID", "RoleName", "RoleDescription", "RoleTypeID", "RoleSubTypeID", "RoleCategoryID", "RoleSubCategoryID", "IsActive", "IsDeleted", "IsGlobal")
VALUES (E'a1d26e64-2139-11e4-88fd-433c5be48343', E'Temporary User', E'Temporary User Role',
(select dot."ClassificationTypeID" from "ClassificationType" dot where dot."ClassificationTypeCategoryID" = 130 and dot."Name" = 'Default Organisation' limit 1),
 NULL, NULL, NULL, True, False, True);

INSERT INTO public."Role" ("RoleID", "RoleName", "RoleDescription", "RoleTypeID", "RoleSubTypeID", "RoleCategoryID", "RoleSubCategoryID", "IsActive", "IsDeleted", "IsGlobal")
VALUES (E'a1d2bc0c-2139-11e4-9670-47a78b7cc43f', E'Administration User', E'Administration User: This role gives the highest level of administrative permissions',
(select dot."ClassificationTypeID" from "ClassificationType" dot where dot."ClassificationTypeCategoryID" = 130 and dot."Name" = 'Default Organisation' limit 1),
 NULL, NULL, NULL, True, False, True);

INSERT INTO public."Role" ("RoleID", "RoleName", "RoleDescription", "RoleTypeID", "RoleSubTypeID", "RoleCategoryID", "RoleSubCategoryID", "IsActive", "IsDeleted", "IsGlobal")
VALUES (E'b88822a0-3cc0-11e4-acf9-bfd11fd091e6', E'Organisation Administrator', E'Organisation Administrator: This role gives permission to add users and bank accounts',
(select dot."ClassificationTypeID" from "ClassificationType" dot where dot."ClassificationTypeCategoryID" = 130 and dot."Name" = 'Global' limit 1),
 NULL, NULL, NULL, True, False, True);

 INSERT INTO public."Role" ("RoleID", "RoleName", "RoleDescription", "RoleTypeID", "RoleSubTypeID", "RoleCategoryID", "RoleSubCategoryID", "IsActive", "IsDeleted", "IsGlobal")
VALUES (E'b55522a0-3cc0-11e4-acf9-bfd11fd091e6', E'Finance Administrator', E'Finance Administrator: This role gives permission to configure bank accounts',
(select dot."ClassificationTypeID" from "ClassificationType" dot where dot."ClassificationTypeCategoryID" = 130 and dot."Name" = 'Global' limit 1),
 NULL, NULL, NULL, True, False, True);

  INSERT INTO public."Role" ("RoleID", "RoleName", "RoleDescription", "RoleTypeID", "RoleSubTypeID", "RoleCategoryID", "RoleSubCategoryID", "IsActive", "IsDeleted", "IsGlobal")
VALUES (E'b56622a0-3cc0-11e4-acf9-bfd11fd091e6', E'Support Administrator', E'Support Administrator Role',
(select dot."ClassificationTypeID" from "ClassificationType" dot where dot."ClassificationTypeCategoryID" = 130 and dot."Name" = 'Global' limit 1),
 NULL, NULL, NULL, True, False, True);

INSERT INTO public."Role" ("RoleID", "RoleName", "RoleDescription", "RoleTypeID", "RoleSubTypeID", "RoleCategoryID", "RoleSubCategoryID", "IsActive", "IsDeleted", "IsGlobal")
VALUES (E'b88849b0-3cc0-11e4-8d6b-0719c31a5e20', E'Organisation Branch Administrator', E'Organisation Branch Administrator Role',
(select dot."ClassificationTypeID" from "ClassificationType" dot where dot."ClassificationTypeCategoryID" = 130 and dot."Name" = 'Global' limit 1),
 NULL, NULL, NULL, True, False, True);

INSERT INTO public."Role" ("RoleID", "RoleName", "RoleDescription", "RoleTypeID", "RoleSubTypeID", "RoleCategoryID", "RoleSubCategoryID", "IsActive", "IsDeleted", "IsGlobal")
VALUES (E'b88849b0-3cc0-11e4-95f5-87c1916ab536', E'Organisation Employee', E'Organisation Employee Role',
(select dot."ClassificationTypeID" from "ClassificationType" dot where dot."ClassificationTypeCategoryID" = 130 and dot."Name" = 'Global' limit 1),
 NULL, NULL, NULL, True, False, True);

INSERT INTO public."Role" ("RoleID", "RoleName", "RoleDescription", "RoleTypeID", "RoleSubTypeID", "RoleCategoryID", "RoleSubCategoryID", "IsActive", "IsDeleted", "IsGlobal")
VALUES (uuid_generate_v1(), E'Broker Administrator', E'Broker Administrator Role',
(select dot."ClassificationTypeID" from "ClassificationType" dot where dot."ClassificationTypeCategoryID" = 130 and dot."Name" = 'Global' limit 1),
 NULL, NULL, NULL, True, False, True);

INSERT INTO public."Role" ("RoleID", "RoleName", "RoleDescription", "RoleTypeID", "RoleSubTypeID", "RoleCategoryID", "RoleSubCategoryID", "IsActive", "IsDeleted", "IsGlobal")
VALUES (uuid_generate_v1(), E'Lender Administrator', E'Lender Administrator Role',
(select dot."ClassificationTypeID" from "ClassificationType" dot where dot."ClassificationTypeCategoryID" = 130 and dot."Name" = 'Global' limit 1),
 NULL, NULL, NULL, True, False, True);

--user
   insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'User' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'Home' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1), TRUE);
--user view MyTransactions
   insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'User' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'MyTransactions' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1), TRUE);

  --employee view homepage
   insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Organisation Employee' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'Home' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1), TRUE);

--employee transactions
insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Organisation Employee' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'SmsTransaction' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'Add' limit 1), TRUE);

insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Organisation Employee' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'SmsTransaction' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1), TRUE);

insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Organisation Employee' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'SmsTransaction' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'Edit' limit 1), TRUE);

--employee view bank a/c
    insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Organisation Employee' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'BankAccount' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1), TRUE);

--employee view bank a/c
    insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Organisation Employee' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'Credit' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1), TRUE);

  --employee view product menu
      insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Organisation Employee' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'Products' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1), TRUE);

 --employee view InternalNotifications
   insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Organisation Employee' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'InternalNotifications' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1), TRUE);


--org admin add users
   insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Organisation Administrator' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'ProUsers' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'Add' limit 1), TRUE);

--org admin add bank account
   insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Organisation Administrator' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'BankAccount' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'Add' limit 1), TRUE);

--org admin view InternalNotifications
   insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Organisation Administrator' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'InternalNotifications' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1), TRUE);


--bec accounts
   insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Finance Administrator' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'Home' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1), TRUE);

   insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Finance Administrator' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'BankAccount' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'Configure' limit 1), TRUE);

--bec accounts view InternalNotifications
   insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Finance Administrator' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'InternalNotifications' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1), TRUE);

 --bec admin view homepage
   insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Administration User' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'Home' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1), TRUE);

/*these come from support role
--bec admin
   insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Administration User' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'Company' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'Add' limit 1), TRUE);

--add pro user claims
   insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Administration User' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'ProUsers' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'Add' limit 1), TRUE);
*/

--configure validated accounts (import)
   insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Administration User' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'ValidatedAccount' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'Add' limit 1), TRUE);

--bec admin view InternalNotifications
   insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Administration User' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'InternalNotifications' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1), TRUE);

 --support admin view homepage
   insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Support Administrator' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'Home' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1), TRUE);

  --support admin
   insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Support Administrator' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'Company' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'Add' limit 1), TRUE);

--support admin add users
   insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Support Administrator' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'ProUsers' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'Add' limit 1), TRUE);

--support admin view InternalNotifications
   insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Support Administrator' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'InternalNotifications' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1), TRUE);


 --view homepage
    insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Broker Administrator' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'Home' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1), TRUE);

 --view homepage
    insert into public."RoleClaim"( "RoleID", "ResourceID", "OperationID", "IsActive")
 values (
  (select "RoleID" from "Role" where "RoleName" = 'Lender Administrator' limit 1),
  (select "ResourceID" from "Resource" where "ResourceName" = 'Home' limit 1),
  (select "OperationID" from "Operation" where "OperationName" = 'View' limit 1), TRUE);