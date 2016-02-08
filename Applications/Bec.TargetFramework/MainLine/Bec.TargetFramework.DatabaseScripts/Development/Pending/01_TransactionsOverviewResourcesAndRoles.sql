insert into public."Resource" ("ResourceID", "ResourceName" , "ResourceDescription", "IsActive")
values (uuid_generate_v1(), 'SmsTransactionsOverview', 'SmsTransactionsOverview' , TRUE);

INSERT INTO public."Role" ("RoleID" , "RoleName", "RoleDescription" , "RoleTypeID", "RoleSubTypeID", "RoleCategoryID" , "RoleSubCategoryID", "IsActive" , "IsDeleted", "IsGlobal")
VALUES (uuid_generate_v1(), E'Lender Employee', E'Lender Employee Role',
(select dot ."ClassificationTypeID" from "ClassificationType" dot where dot."ClassificationTypeCategoryID" = 130 and dot."Name" = 'Global' limit 1),
  NULL, NULL, NULL, True , False, True);
 
-- Lender Administrator Add ProUsers
    insert into public. "RoleClaim" ( "RoleID", "ResourceID" , "OperationID", "IsActive")
values (
(select "RoleID" from "Role" where "RoleName" = 'Lender Administrator' limit 1),
(select "ResourceID" from "Resource" where "ResourceName" = 'ProUsers' limit 1),
(select "OperationID" from "Operation" where "OperationName" = 'Add' limit 1), TRUE);


-- Lender Employee view homepage
insert into public. "RoleClaim" ( "RoleID", "ResourceID" , "OperationID", "IsActive")
values (
(select "RoleID" from "Role" where "RoleName" = 'Lender Employee' limit 1),
(select "ResourceID" from "Resource" where "ResourceName" = 'Home' limit 1),
(select "OperationID" from "Operation" where "OperationName" = 'View' limit 1), TRUE);

  -- Lender Employee SmsTransactionsOverview
insert into public. "RoleClaim" ( "RoleID", "ResourceID" , "OperationID", "IsActive")
values (
(select "RoleID" from "Role" where "RoleName" = 'Lender Employee' limit 1),
(select "ResourceID" from "Resource" where "ResourceName" = 'SmsTransactionsOverview' limit 1),
(select "OperationID" from "Operation" where "OperationName" = 'View' limit 1), TRUE);

-- Delete redundant stuff
delete from public."RoleClaim"
  where
       "RoleID" = ( select "RoleID" from "Role" where "RoleName" = 'Lender Administrator' limit 1) AND
       "ResourceID" = ( select "ResourceID" from "Resource" where "ResourceName" = 'Home' limit 1 ) AND
       "OperationID" = ( select "OperationID" from "Operation" where "OperationName" = 'View' limit 1);


-- ============== UPDATE Lender Template ========================
DO $$
Declare DoTemplateID uuid;
Declare DoVersionNumber integer;
Declare EmployeeRoleID uuid;
Declare DefaultOrganisationID uuid ;

BEGIN
-- declare variables
    EmployeeRoleID := ( select "RoleID" from "Role" where "RoleName" = 'Lender Employee' limit 1);
    DoTemplateID := ( select dot. "DefaultOrganisationTemplateID" from "DefaultOrganisationTemplate" dot where dot."Name" = 'Lender Organisation' limit 1);
    DoVersionNumber = 1 ;

    DefaultOrganisationID := ( select dorg. "DefaultOrganisationID" from "DefaultOrganisation" dorg
    where dorg. "DefaultOrganisationTemplateID" = DoTemplateID limit 1 );

    INSERT INTO
        public."DefaultOrganisationRoleTemplate"
    (
        "DefaultOrganisationTemplateID" ,
        "RoleID" ,
        "IsDefaultOrganisationSpecific" ,
        "DefaultOrganisationTemplateVersionNumber" ,
        "IsDefault"
    )
    VALUES (
        DoTemplateID ,
        EmployeeRoleID ,
        false ,
        DoVersionNumber ,
        true
    );
 
    INSERT INTO public. "DefaultOrganisationRoleTargetTemplate"
    (
        "DefaultOrganisationRoleTemplateID" ,
        "DefaultOrganisationUserTargetTemplateID"
    )
    select
    (select dot ."DefaultOrganisationRoleTemplateID" from "DefaultOrganisationRoleTemplate" dot where dot."DefaultOrganisationTemplateID" = DoTemplateID
            and dot. "RoleID" = EmployeeRoleID and dot."DefaultOrganisationTemplateVersionNumber" = DoVersionNumber limit 1),
            "DefaultOrganisationUserTargetTemplateID"
    from "DefaultOrganisationUserTargetTemplate"
    where "DefaultOrganisationTemplateID" = DoTemplateID and "DefaultOrganisationTemplateVersionNumber" = DoVersionNumber;

    -- ROLE
    INSERT INTO
        public."DefaultOrganisationRole"
    (
        "DefaultOrganisationID" ,
        "DefaultOrganisationVersionNumber" ,
        "RoleName" ,
        "RoleDescription" ,
        "RoleTypeID" ,
        "RoleSubTypeID" ,
        "RoleCategoryID" ,
        "RoleSubCategoryID" ,
        "ParentID" ,
        "RoleID" ,
        "IsActive" ,
        "IsDeleted" ,
        "IsDefaultOrganisationSpecific" ,
        "IsDefault"
    )
    SELECT
        DefaultOrganisationID ,
        1,
        wt ."RoleName",
        wt ."RoleDescription",
        wt ."RoleTypeID",
        wt ."RoleSubTypeID",
        wt ."RoleCategoryID",
        wt ."RoleSubCategoryID",
        wt ."DefaultOrganisationRoleTemplateID",
        wt ."RoleID",
        wt ."IsActive",
        wt ."IsDeleted",
        wt ."IsDefaultOrganisationSpecific",
        wt ."IsDefault"
    FROM
            public."DefaultOrganisationRoleTemplate"  wt
            join public ."Role" r on wt."RoleID" = r. "RoleID"
        where wt. "DefaultOrganisationTemplateID" = DoTemplateID and wt."DefaultOrganisationTemplateVersionNumber" = DoVersionNumber AND
            r ."RoleName" = 'Lender Employee';
 
END $$;