
DO $$
Declare UserOrganisationDefaultStatusID uuid;
Declare OrganisationStatusID uuid;
Declare BranchStatusID uuid;
Begin

-- base templates

INSERT INTO public."StatusTypeTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'21eefa2e-4d75-11e4-9494-e39d9f00d293', 1, E'User Organisation Status', E'User Organisation Default Status', True, False);

UserOrganisationDefaultStatusID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'User Organisation Status');


INSERT INTO public."StatusTypeTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'21f03470-4d75-11e4-be09-8f7f7f3fdaa5', 1, E'Organisation Status', E'Organisation Default Status', True, False);

OrganisationStatusID  := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Organisation Status');

INSERT INTO public."StatusTypeTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'21f059d2-4d75-11e4-99b6-f78cc018b0e6', 1, E'Branch Status', E'Branch Default Status', True, False);

BranchStatusID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Branch Status');

-- User Organisation Default Status
INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'21f0a824-4d75-11e4-91bb-17002dc3257d', UserOrganisationDefaultStatusID, 1, E'Pending', E'Pending', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'21f1441e-4d75-11e4-8c3c-e3b840d9f181', UserOrganisationDefaultStatusID, 1, E'Validated', E'Validated', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'21f16b7e-4d75-11e4-87d3-077e51f6bf34', UserOrganisationDefaultStatusID, 1, E'Rejected', E'Rejected', True, False);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'21f34002-4d75-11e4-b9f4-a339b588798c', UserOrganisationDefaultStatusID, 1,
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = UserOrganisationDefaultStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Pending' limit 1),
 0, True, False);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'21f3b528-4d75-11e4-a8ec-2f1d7f8f060b', UserOrganisationDefaultStatusID, 1,
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = UserOrganisationDefaultStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Validated' limit 1),
 1, False, True);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'21f4037a-4d75-11e4-860e-f3f22bcacb9a', UserOrganisationDefaultStatusID, 1,
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = UserOrganisationDefaultStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Rejected' limit 1),
 2, False, True);

-- Organisation Status
INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'21f1b98a-4d75-11e4-bf41-8fcd114410b7', OrganisationStatusID, 1, E'Pending', E'Pending', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'21f1e09a-4d75-11e4-ba67-f7ec797962a0', OrganisationStatusID, 1, E'Validated', E'Validated', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'21f22e88-4d75-11e4-a03b-9bbbe21bb3d5', OrganisationStatusID, 1, E'Rejected', E'Rejected', True, False);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'21f45186-4d75-11e4-8cc2-336969c19a52', OrganisationStatusID, 1,
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = OrganisationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Pending' limit 1),
 0, True, False);

 INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'21f45186-4d75-11e4-8cc2-336969c19a52', OrganisationStatusID, 1,
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = OrganisationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Validated' limit 1),
 1, False, True);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'21f49fd8-4d75-11e4-8322-574e8e1e955d', OrganisationStatusID, 1,
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = OrganisationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Rejected' limit 1),
 2, False, True);

-- Branch Status
INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'21f27c9e-4d75-11e4-b2cd-7339059339fc', BranchStatusID, 1, E'Pending', E'Pending', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'21f2a3ea-4d75-11e4-861b-cb175af579e3', BranchStatusID, 1, E'Validated', E'Validated', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'21f2cb04-4d75-11e4-8cd4-2fc1a5d77f34', BranchStatusID, 1, E'Rejected', E'Rejected', True, False);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'21f4eda8-4d75-11e4-9667-bfea42259b88', BranchStatusID, 1,
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = BranchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Pending' limit 1),
 0, True, False);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'21f53bbe-4d75-11e4-ada1-dbee820db15a', BranchStatusID, 1,
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = BranchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Validated' limit 1),
 1, False, True);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'21f589de-4d75-11e4-909c-d7c5856bb4cb', BranchStatusID, 1,
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = BranchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Rejected' limit 1),
 2, False, True);

-- Process Templates
perform "fn_PromoteStatusTypeTemplate"(UserOrganisationDefaultStatusID,1);
perform "fn_PromoteStatusTypeTemplate"(OrganisationStatusID,1);
perform "fn_PromoteStatusTypeTemplate"(BranchStatusID,1);

END $$;