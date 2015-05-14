
DO $$
Declare OrganisationStatusID uuid;
Begin

-- base templates



INSERT INTO public."StatusTypeTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'd1cb4c86-d399-11e4-95c6-00155d0a1426', 1, E'Professional Organisation Status', E'Professional Default Status', True, False);

OrganisationStatusID  := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Professional Organisation Status');


-- User Organisation Default Status
INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'39b79aca-c287-49b6-8ee7-478ba8f80f87', OrganisationStatusID, 1, E'Unverified', E'Unverified', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'29bfddb3-da94-4955-9446-c068d6816925', OrganisationStatusID, 1, E'Verified', E'Verified', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'7a549b8c-d766-4f59-af57-dee9bd20c519', OrganisationStatusID, 1, E'Rejected', E'Rejected', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'8a549b8c-d766-4f59-af57-dee9bd20c519', OrganisationStatusID, 1, E'Expired', E'Expired', True, False);


INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'00cdb021-425d-43ed-b04b-70a3ecb55ee9', OrganisationStatusID, 1,
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = OrganisationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Unverified' limit 1),
 0, True, False);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'db010bff-b91a-4ce0-b58b-136b995911ff', OrganisationStatusID, 1,
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = OrganisationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Verified' limit 1),
 1, False, True);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'a2226a3d-22d2-46ec-bf97-dd25ea5bc93a', OrganisationStatusID, 1,
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = OrganisationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Rejected' limit 1),
 2, False, True);

 INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'b2226a3d-22d2-46ec-bf97-dd25ea5bc93a', OrganisationStatusID, 1,
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = OrganisationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Expired' limit 1),
 3, False, True);

-- Process Templates
perform "fn_PromoteStatusTypeTemplate"(OrganisationStatusID,1);

END $$;