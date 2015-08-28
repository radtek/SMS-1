
delete from "OrganisationType";

INSERT INTO public."OrganisationType" ("OrganisationTypeID", "Name", "Description", "IsActive", "IsDeleted")
VALUES (27, E'Temporary', E'Temporary Organisation, used for storing all temporary users', True, False);

INSERT INTO public."OrganisationType" ("OrganisationTypeID", "Name", "Description", "IsActive", "IsDeleted")
VALUES (28, E'Conveyancy', E'Conveyancy Organisation', True, False);

INSERT INTO public."OrganisationType" ("OrganisationTypeID", "Name", "Description", "IsActive", "IsDeleted")
VALUES (29, E'Personal', E'Personal Organisation', True, False);

INSERT INTO public."OrganisationType" ("OrganisationTypeID", "Name", "Description", "IsActive", "IsDeleted")
VALUES (30, E'Administration', E'Administration Organisation', True, False);

INSERT INTO public."OrganisationType" ("OrganisationTypeID", "Name", "Description", "IsActive", "IsDeleted")
VALUES (31, E'Support', E'Support Organisation', True, False);

INSERT INTO public."OrganisationType" ("OrganisationTypeID", "Name", "Description", "IsActive", "IsDeleted")
VALUES (32, E'SCP', E'Support and Compliance Organisation', True, False);

INSERT INTO public."OrganisationType" ("OrganisationTypeID", "Name", "Description", "IsActive", "IsDeleted")
VALUES (33, E'Supplier', E'Supplier of Product components with no actual system access', True, False);

INSERT INTO public."OrganisationType" ("OrganisationTypeID", "Name", "Description", "IsActive", "IsDeleted")
VALUES (34, E'Branch', E'Branch of an Organisation', True, False);