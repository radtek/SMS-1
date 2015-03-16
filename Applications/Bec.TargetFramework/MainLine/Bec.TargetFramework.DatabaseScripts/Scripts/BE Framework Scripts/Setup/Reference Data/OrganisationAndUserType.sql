delete from "OrganisationType";
INSERT INTO public."OrganisationType" ("OrganisationTypeID", "Name", "Description", "IsActive", "IsDeleted")
VALUES (27, E'Temporary', E'Temporary Organisation, used for storing all temporary users', True, False);

INSERT INTO public."OrganisationType" ("OrganisationTypeID", "Name", "Description", "IsActive", "IsDeleted")
VALUES (29, E'Personal', E'Personal Organisation', True, False);

INSERT INTO public."OrganisationType" ("OrganisationTypeID", "Name", "Description", "IsActive", "IsDeleted")
VALUES (30, E'Administration', E'Administration Organisation', True, False);

delete from "UserType";
/* Data for the 'public.UserType' table  (Records 1 - 5) */

INSERT INTO public."UserType" ("UserTypeID", "Name", "Description", "IsActive", "IsDeleted", "IsGlobal", "IsPrincipal", "IsSecondary")
VALUES (E'9e8ca436-2139-11e4-a37d-8771a20de3d2', E'User', E'User', True, False, True, True, True);

INSERT INTO public."UserType" ("UserTypeID", "Name", "Description", "IsActive", "IsDeleted", "IsGlobal", "IsPrincipal", "IsSecondary")
VALUES (E'9e8d195c-2139-11e4-a4cd-2b35a008ab65', E'Administrator', E'Administrator', True, False, True, True, False);

INSERT INTO public."UserType" ("UserTypeID", "Name", "Description", "IsActive", "IsDeleted", "IsGlobal", "IsPrincipal", "IsSecondary")
VALUES (E'9e8d6786-2139-11e4-9216-972bcf724500', E'Temporary', E'Temporary User', True, False, True, True, False);