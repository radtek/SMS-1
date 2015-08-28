INSERT INTO
  public."Role"
(
  "RoleID",
  "RoleName",
  "RoleDescription",
  "RoleTypeID",
  "IsActive",
  "IsDeleted",
  "IsGlobal"
)
VALUES (
  'b8890cf6-3cc0-11e4-9104-d731d19b5973',
  'STS User',
  'STS User Role',
   (select dot."ClassificationTypeID" from "ClassificationType" dot where dot."ClassificationTypeCategoryID" = 130 and dot."Name" = 'Global' limit 1),
  true,
  false,
  false
);

INSERT INTO
  public."Role"
(
  "RoleID",
  "RoleName",
  "RoleDescription",
  "RoleTypeID",
  "IsActive",
  "IsDeleted",
  "IsGlobal"
)
VALUES (
  'b88933fc-3cc0-11e4-8448-07aa74ade050',
  'STS Employee',
  'STS Employee Role',
   (select dot."ClassificationTypeID" from "ClassificationType" dot where dot."ClassificationTypeCategoryID" = 130 and dot."Name" = 'Global' limit 1),
  true,
  false,
  FALSE
);

INSERT INTO
  public."Role"
(
  "RoleID",
  "RoleName",
  "RoleDescription",
  "RoleTypeID",
  "IsActive",
  "IsDeleted",
  "IsGlobal"
)
VALUES (
  'b88933fc-3cc0-11e4-9743-2faafe1fcc41',
  'STS Admin',
  'STS Admin Role',
   (select dot."ClassificationTypeID" from "ClassificationType" dot where dot."ClassificationTypeCategoryID" = 130 and dot."Name" = 'Global' limit 1),
  true,
  false,
  false
);


-- STS Status Types
DO $$
Declare InviteStatusID uuid;
Declare SearchActorStatusID uuid;
Declare StsSearchStatusID uuid;
Declare StsSearchRelationStatusID uuid;
Begin

-- base templates
INSERT INTO
  public."StatusTypeTemplate"("StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES
  (1, 'Sts Invite Status', 'Sts Invite Status', true, false);

InviteStatusID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Sts Invite Status');

INSERT INTO
  public."StatusTypeTemplate"("StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES
  (1, 'Sts Search Actor Status', 'Sts Search Actor Status', true, false);

SearchActorStatusID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Sts Search Actor Status');

INSERT INTO
  public."StatusTypeTemplate"("StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES
  (1, 'Sts Search Status', 'Sts Search Status', true, false);

StsSearchStatusID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Sts Search Status');

INSERT INTO
  public."StatusTypeTemplate"("StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES
  (1, 'Sts Search Relation Status', 'Sts Search Relation Status', true, false);

StsSearchRelationStatusID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Sts Search Relation Status');


-- Invite Status
INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  InviteStatusID,
  1,
  'Invited',
  'Invited'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  InviteStatusID,
  1,
  'Accepted',
  'Accepted'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  InviteStatusID,
  1,
  'Rejected',
  'Rejected'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  InviteStatusID,
  1,
  'Reassigned',
  'Reassigned'
);

-- SearchActorStatusID

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  SearchActorStatusID,
  1,
  'Pending',
  'Pending'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  SearchActorStatusID,
  1,
  'Active',
  'Active'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  SearchActorStatusID,
  1,
  'Cancelled',
  'Cancelled'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  SearchActorStatusID,
  1,
  'Produced',
  'Produced'
);

------------ STS Search Status

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  StsSearchStatusID,
  1,
  'Pending Acceptance',
  'Pending Acceptance'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  StsSearchStatusID,
  1,
  'Active',
  'Active'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  StsSearchStatusID,
  1,
  'Produced',
  'Produced'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  StsSearchStatusID,
  1,
  'Cancelled',
  'Cancelled'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  StsSearchStatusID,
  1,
  'Pending Produced',
  'Pending Produced'
);

----------------- STS Search Relationship

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  StsSearchRelationStatusID,
  1,
  'Active',
  'Active'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  StsSearchRelationStatusID,
  1,
  'Produced',
  'Produced'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  StsSearchRelationStatusID,
  1,
  'Pending Seller Acceptance',
  'Pending Seller Acceptance'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  StsSearchRelationStatusID,
  1,
  'Pending Buyer Acceptance',
  'Pending Buyer Acceptance'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  StsSearchRelationStatusID,
  1,
  'Cancelled',
  'Cancelled'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  StsSearchRelationStatusID,
  1,
  'Pending Seller Produced Confirmation',
  'Pending Seller Produced Confirmation'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  StsSearchRelationStatusID,
  1,
  'Pending Buyer Produced Confirmation',
  'Pending Buyer Produced Confirmation'
);

------------------- INVITE STRUCTURE

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  InviteStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = InviteStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Invited' limit 1),
  0,
  true,
  false
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  InviteStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = InviteStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Accepted' limit 1),
  1,
  false,
  true
);


INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  InviteStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = InviteStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Rejected' limit 1),
  2,
  false,
  true
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  InviteStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = InviteStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Reassigned' limit 1),
  3,
  false,
  TRUE
);

INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
   where st."StatusTypeTemplateID" = InviteStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Invited' limit 1),
  ( select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
   where st."StatusTypeTemplateID" = InviteStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Accepted' limit 1)
);

INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
   where st."StatusTypeTemplateID" = InviteStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Invited' limit 1),
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
   where st."StatusTypeTemplateID" = InviteStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Rejected' limit 1)
);

INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
   where st."StatusTypeTemplateID" = InviteStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Invited' limit 1),
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
   where st."StatusTypeTemplateID" = InviteStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Reassigned' limit 1)
);

----------------------- STS Search Actor

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  SearchActorStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = SearchActorStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Pending' limit 1),
  0,
  true,
  false
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  SearchActorStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = SearchActorStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Active' limit 1),
  1,
  false,
  true
);


INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  SearchActorStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = SearchActorStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Produced' limit 1),
  2,
  false,
  true
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  SearchActorStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = SearchActorStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Cancelled' limit 1),
  3,
  false,
  TRUE
);

INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
   where st."StatusTypeTemplateID" = SearchActorStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Pending' limit 1),
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
   where st."StatusTypeTemplateID" = SearchActorStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Active' limit 1)
);

INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
   where st."StatusTypeTemplateID" = SearchActorStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Pending' limit 1),
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
   where st."StatusTypeTemplateID" = SearchActorStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Cancelled' limit 1)
);

INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
   where st."StatusTypeTemplateID" = SearchActorStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Pending' limit 1),
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
   where st."StatusTypeTemplateID" = SearchActorStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Produced' limit 1)
);

INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
   where st."StatusTypeTemplateID" = SearchActorStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Active' limit 1),
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
   where st."StatusTypeTemplateID" = SearchActorStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Produced' limit 1)
);

INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
   where st."StatusTypeTemplateID" = SearchActorStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Active' limit 1),
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
   where st."StatusTypeTemplateID" = SearchActorStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Cancelled' limit 1)
);

INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
 (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
   where st."StatusTypeTemplateID" = SearchActorStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Active' limit 1),
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
   where st."StatusTypeTemplateID" = SearchActorStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Pending' limit 1)
);

----------------------- STS SEARCH

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  StsSearchStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = StsSearchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Pending Acceptance' limit 1),
  0,
  true,
  false
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  StsSearchStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = StsSearchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Active' limit 1),
  1,
  false,
  false
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  StsSearchStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = StsSearchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Pending Produced' limit 1),
  2,
  false,
  false
);


INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  StsSearchStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = StsSearchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Produced' limit 1),
  3,
  false,
  true
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  StsSearchStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = StsSearchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Cancelled' limit 1),
  4,
  false,
  TRUE
);

INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
   where st."StatusTypeTemplateID" = StsSearchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Pending Acceptance' limit 1),
 (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
   where st."StatusTypeTemplateID" = StsSearchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Active' limit 1)
);

INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
 (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
   where st."StatusTypeTemplateID" = StsSearchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Pending Acceptance' limit 1),
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
   where st."StatusTypeTemplateID" = StsSearchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Cancelled' limit 1)
);

INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
    where st."StatusTypeTemplateID" = StsSearchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Active' limit 1),
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
   where st."StatusTypeTemplateID" = StsSearchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Produced' limit 1)
);

INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
   where st."StatusTypeTemplateID" = StsSearchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Active' limit 1),
 (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
    where st."StatusTypeTemplateID" = StsSearchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Cancelled' limit 1)
);

INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
 (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
    where st."StatusTypeTemplateID" = StsSearchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Active' limit 1),
 (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
    where st."StatusTypeTemplateID" = StsSearchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Pending Produced' limit 1)
);

INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
   where st."StatusTypeTemplateID" = StsSearchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Pending Produced' limit 1),
 (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
    where st."StatusTypeTemplateID" = StsSearchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Active' limit 1)
);

INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
   where st."StatusTypeTemplateID" = StsSearchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Pending Produced' limit 1),
 (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
    where st."StatusTypeTemplateID" = StsSearchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Produced' limit 1)
);


INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
 (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
    where st."StatusTypeTemplateID" = StsSearchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Pending Produced' limit 1),
 (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
    where st."StatusTypeTemplateID" = StsSearchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Cancelled' limit 1)
);


INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
 (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
    where st."StatusTypeTemplateID" = StsSearchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Produced' limit 1),
 (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
    where st."StatusTypeTemplateID" = StsSearchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Active' limit 1)
);


INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
 (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
    where st."StatusTypeTemplateID" = StsSearchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Produced' limit 1),
 (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
    where st."StatusTypeTemplateID" = StsSearchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Cancelled' limit 1)
);


INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
 (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
    where st."StatusTypeTemplateID" = StsSearchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Cancelled' limit 1),
 (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
    where st."StatusTypeTemplateID" = StsSearchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Active' limit 1)
);



-------------- STS Search Relationship

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  StsSearchRelationStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Pending Seller Acceptance' limit 1),
  0,
  true,
  false
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  StsSearchRelationStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Pending Buyer Acceptance' limit 1),
  1,
  true,
  false
);


INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  StsSearchRelationStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Active' limit 1),
  2,
  false,
  false
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  StsSearchRelationStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Pending Seller Produced Confirmation' limit 1),
  3,
  false,
  false
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  StsSearchRelationStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Pending Buyer Produced Confirmation' limit 1),
  4,
  false,
  false
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  StsSearchRelationStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Cancelled' limit 1),
  5,
  false,
  TRUE
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  StsSearchRelationStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Produced' limit 1),
  6,
  false,
  TRUE
);

INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
 (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
     where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Pending Seller Acceptance' limit 1),
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
     where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Active' limit 1)
);

INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
    where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Pending Buyer Acceptance' limit 1),
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
    where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Active' limit 1)
);

INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
 (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
    where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Pending Seller Acceptance' limit 1),
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
     where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Cancelled' limit 1)
);

INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
     where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Pending Buyer Acceptance' limit 1),
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
     where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Cancelled' limit 1)
);

INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
     where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Active' limit 1),
 (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
    where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Cancelled' limit 1)
);

INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
 (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
    where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Active' limit 1),
 (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
    where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Produced' limit 1)
);

INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
    where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Active' limit 1),
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
    where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Pending Buyer Produced Confirmation' limit 1)
);


INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
     where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Active' limit 1),
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
    where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Pending Seller Produced Confirmation' limit 1)
);


INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
 (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
     where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Active' limit 1),
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
     where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Pending Seller Acceptance' limit 1)
);


INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
     where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Active' limit 1),
 (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
    where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Pending Buyer Acceptance' limit 1)
);


INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
 (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
     where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Pending Seller Produced Confirmation' limit 1),
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
    where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Active' limit 1)
);


INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
    where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Pending Seller Produced Confirmation' limit 1),
 (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
     where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Cancelled' limit 1)
);

INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
     where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Pending Seller Produced Confirmation' limit 1),
 (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
    where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Produced' limit 1)
);

INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
     where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Pending Buyer Produced Confirmation' limit 1),
(select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
    where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Active' limit 1)
);

INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
     where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Pending Buyer Produced Confirmation' limit 1),
 (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
     where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Cancelled' limit 1)
);

INSERT INTO
  public."StatusTypeStructureTransitionTemplate"
(
  "CurrentStatusTypeStructureTemplateID",
  "NextStatusTypeStructureTemplateID"
)
VALUES (
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
    where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Pending Buyer Produced Confirmation' limit 1),
  (select stst."StatusTypeStructureTemplateID" from "StatusTypeValueTemplate" st
  left outer join "StatusTypeStructureTemplate" stst on stst."StatusTypeTemplateID" = st."StatusTypeTemplateID" and stst."StatusTypeTemplateVersionNumber" = st."StatusTypeTemplateVersionNumber"
  and stst."StatusTypeValueTemplateID" = st."StatusTypeValueTemplateID"
     where st."StatusTypeTemplateID" = StsSearchRelationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" ='Produced' limit 1)
);

END $$;