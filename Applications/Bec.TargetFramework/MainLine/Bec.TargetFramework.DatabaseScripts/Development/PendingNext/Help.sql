-- Classification Values
INSERT INTO
  public."ClassificationTypeCategory"
(
  "ClassificationTypeCategoryID",
  "Name",
  "IsActive",
  "IsDeleted"
)
VALUES (
  91829172,
  'HelpTypeID',
  true,
  false
);

INSERT INTO public."ClassificationType"("ClassificationTypeID", "Name",
  "ClassificationTypeCategoryID")
VALUES (918291721,'Tour', 91829172);

INSERT INTO public."ClassificationType"("ClassificationTypeID", "Name",
  "ClassificationTypeCategoryID")
VALUES (918291722,'Callout', 91829172);

INSERT INTO public."ClassificationType"("ClassificationTypeID", "Name",
  "ClassificationTypeCategoryID")
VALUES (918291723,'Show Me How', 91829172);

INSERT INTO
  public."ClassificationTypeCategory"
(
  "ClassificationTypeCategoryID",
  "Name"
)
VALUES (
  127838127,
  'HelpPosition'
);

INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "ClassificationTypeCategoryID")
VALUES (1278381271,'Top',127838127);

INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "ClassificationTypeCategoryID")
VALUES (1278381272,'Bottom',127838127);

INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "ClassificationTypeCategoryID")
VALUES (1278381273,'Left',127838127);

INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "ClassificationTypeCategoryID")
VALUES (1278381274,'Right',127838127);

-- New Resources And Claims
-- create resource and operations
INSERT INTO
  public."Resource"
(
  "ResourceName"
)
VALUES (
  'Help'
);

INSERT INTO public."ResourceOperation"("ResourceID", "OperationID")
VALUES ((
          select "ResourceID"
          from "Resource"
          where "ResourceName" = 'Help'
       ), (
            select "OperationID"
            from "Operation"
            where "OperationName" = 'Add'
       ));
       
INSERT INTO public."ResourceOperation"("ResourceID", "OperationID")
VALUES ((
          select "ResourceID"
          from "Resource"
          where "ResourceName" = 'Help'
       ), (
            select "OperationID"
            from "Operation"
            where "OperationName" = 'View'
       ));

INSERT INTO public."ResourceOperation"("ResourceID", "OperationID")
VALUES ((
          select "ResourceID"
          from "Resource"
          where "ResourceName" = 'Help'
       ), (
            select "OperationID"
            from "Operation"
            where "OperationName" = 'Edit'
       ));

INSERT INTO public."ResourceOperation"("ResourceID", "OperationID")
VALUES ((
          select "ResourceID"
          from "Resource"
          where "ResourceName" = 'Help'
       ), (
            select "OperationID"
            from "Operation"
            where "OperationName" = 'Delete'
       ));

-- Role Claims
-- create claims support all, user view
INSERT INTO public."RoleClaim"("RoleID", "ResourceID", "OperationID", "IsGlobal"
  )
VALUES ((
          select "RoleID"
          from "Role"
          where "RoleName" = 'Support Administrator'
       ), (
            select "ResourceID"
            from "Resource"
            where "ResourceName" = 'Help'
       ), (
            select "OperationID"
            from "Operation"
            where "OperationName" = 'Delete'
       ), true);

INSERT INTO public."RoleClaim"("RoleID", "ResourceID", "OperationID", "IsGlobal"
  )
VALUES ((
          select "RoleID"
          from "Role"
          where "RoleName" = 'Support Administrator'
       ), (
            select "ResourceID"
            from "Resource"
            where "ResourceName" = 'Help'
       ), (
            select "OperationID"
            from "Operation"
            where "OperationName" = 'View'
       ), true);

 INSERT INTO public."RoleClaim"("RoleID", "ResourceID", "OperationID", "IsGlobal"
  )
VALUES ((
          select "RoleID"
          from "Role"
          where "RoleName" = 'Support Administrator'
       ), (
            select "ResourceID"
            from "Resource"
            where "ResourceName" = 'Help'
       ), (
            select "OperationID"
            from "Operation"
            where "OperationName" = 'Edit'
       ), true);

INSERT INTO public."RoleClaim"("RoleID", "ResourceID", "OperationID", "IsGlobal"
  )
VALUES ((
          select "RoleID"
          from "Role"
          where "RoleName" = 'User'
       ), (
            select "ResourceID"
            from "Resource"
            where "ResourceName" = 'Help'
       ), (
            select "OperationID"
            from "Operation"
            where "OperationName" = 'View'
       ), true);

INSERT INTO public."RoleClaim"("RoleID", "ResourceID", "OperationID", "IsGlobal"
  )
VALUES ((
          select "RoleID"
          from "Role"
          where "RoleName" = 'Organisation Employee'
       ), (
            select "ResourceID"
            from "Resource"
            where "ResourceName" = 'Help'
       ), (
            select "OperationID"
            from "Operation"
            where "OperationName" = 'View'
       ), true);
       
 INSERT INTO public."RoleClaim"("RoleID", "ResourceID", "OperationID", "IsGlobal"
  )
VALUES ((
          select "RoleID"
          from "Role"
          where "RoleName" = 'Support Administrator'
       ), (
            select "ResourceID"
            from "Resource"
            where "ResourceName" = 'Help'
       ), (
            select "OperationID"
            from "Operation"
            where "OperationName" = 'Add'
       ), true);


-- Support Management 
INSERT INTO
  public."Resource"
(
  "ResourceName"
)
VALUES (
  'SupportManagement'
);

INSERT INTO public."ResourceOperation"("ResourceID", "OperationID")
VALUES ((
          select "ResourceID"
          from "Resource"
          where "ResourceName" = 'SupportManagement'
       ), (
            select "OperationID"
            from "Operation"
            where "OperationName" = 'View'
       ));

 INSERT INTO public."RoleClaim"("RoleID", "ResourceID", "OperationID", "IsGlobal"
  )
VALUES ((
          select "RoleID"
          from "Role"
          where "RoleName" = 'Support Administrator'
       ), (
            select "ResourceID"
            from "Resource"
            where "ResourceName" = 'SupportManagement'
       ), (
            select "OperationID"
            from "Operation"
            where "OperationName" = 'View'
       ), true);
       
 -- Backfill Claims
 -- backfill organisation role with new Support Claims
 insert into
    "OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted",

"OrganisationID")
  select
    org."OrganisationRoleID",
    rc."ResourceID",
    rc."OperationID",
    rc."StateID",
    rc."StateItemID",
    true,
    false,
    org."OrganisationID"
  from
    "RoleClaim" rc
    inner join "OrganisationRole" org on org."IsActive" = true and org."IsDeleted" = false and org."ParentID" = rc."RoleID"
  where
    rc."RoleID" =
    (
      select "RoleID"
          from "Role"
          where "RoleName" = 'Support Administrator'
    ) and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = org."OrganisationID" and
                   orc."OrganisationRoleID" = org."OrganisationRoleID" and
                   orc."OperationID" = rc."OperationID" and
                   orc."ResourceID" = rc."ResourceID" and
                   orc."StateID" = rc."StateID" and
                   orc."StateItemID" = rc."StateItemID"
    );

 insert into
    "OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted",

"OrganisationID")
  select
    org."OrganisationRoleID",
    rc."ResourceID",
    rc."OperationID",
    rc."StateID",
    rc."StateItemID",
    true,
    false,
    org."OrganisationID"
  from
    "RoleClaim" rc
    inner join "OrganisationRole" org on org."IsActive" = true and org."IsDeleted" = false and org."ParentID" = rc."RoleID"
  where
    rc."RoleID" =
    (
      select "RoleID"
          from "Role"
          where "RoleName" = 'User'
    ) and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = org."OrganisationID" and
                   orc."OrganisationRoleID" = org."OrganisationRoleID" and
                   orc."OperationID" = rc."OperationID" and
                   orc."ResourceID" = rc."ResourceID" and
                   orc."StateID" = rc."StateID" and
                   orc."StateItemID" = rc."StateItemID"
    );

   insert into
    "OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted",

"OrganisationID")
  select
    org."OrganisationRoleID",
    rc."ResourceID",
    rc."OperationID",
    rc."StateID",
    rc."StateItemID",
    true,
    false,
    org."OrganisationID"
  from
    "RoleClaim" rc
    inner join "OrganisationRole" org on org."IsActive" = true and org."IsDeleted" = false and org."ParentID" = rc."RoleID"
  where
    rc."RoleID" =
    (
      select "RoleID"
          from "Role"
          where "RoleName" = 'Organisation Employee'
    ) and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = org."OrganisationID" and
                   orc."OrganisationRoleID" = org."OrganisationRoleID" and
                   orc."OperationID" = rc."OperationID" and
                   orc."ResourceID" = rc."ResourceID" and
                   orc."StateID" = rc."StateID" and
                   orc."StateItemID" = rc."StateItemID"
    );
    
-- backfill organisation role with new Support Claims
 insert into
    "OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted",

"OrganisationID")
  select
    org."OrganisationRoleID",
    rc."ResourceID",
    rc."OperationID",
    rc."StateID",
    rc."StateItemID",
    true,
    false,
    org."OrganisationID"
  from
    "RoleClaim" rc
    inner join "OrganisationRole" org on org."IsActive" = true and org."IsDeleted" = false and org."ParentID" = rc."RoleID"
  where
    rc."RoleID" =
    (
      select "RoleID"
          from "Role"
          where "RoleName" = 'Support Administrator'
    ) and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = org."OrganisationID" and
                   orc."OrganisationRoleID" = org."OrganisationRoleID" and
                   orc."OperationID" = rc."OperationID" and
                   orc."ResourceID" = rc."ResourceID" and
                   orc."StateID" = rc."StateID" and
                   orc."StateItemID" = rc."StateItemID"
    );

-- backfill organisation role with new Support Claims
 insert into
    "OrganisationRoleClaim"("OrganisationRoleID", "ResourceID", "OperationID", "StateID", "StateItemID", "IsActive", "IsDeleted",

"OrganisationID")
  select
    org."OrganisationRoleID",
    rc."ResourceID",
    rc."OperationID",
    rc."StateID",
    rc."StateItemID",
    true,
    false,
    org."OrganisationID"
  from
    "RoleClaim" rc
    inner join "OrganisationRole" org on org."IsActive" = true and org."IsDeleted" = false and org."ParentID" = rc."RoleID"
  where
    rc."RoleID" =
    (
      select "RoleID"
          from "Role"
          where "RoleName" = 'Support Administrator'
    ) and
    not exists (
                 select
                   orc."OrganisationRoleClaimID"
                 from
                   "OrganisationRoleClaim" orc
                 where
                   orc."OrganisationID" = org."OrganisationID" and
                   orc."OrganisationRoleID" = org."OrganisationRoleID" and
                   orc."OperationID" = rc."OperationID" and
                   orc."ResourceID" = rc."ResourceID" and
                   orc."StateID" = rc."StateID" and
                   orc."StateItemID" = rc."StateItemID"
    );
    
 -- Tables
CREATE TABLE public."Help" (
  "HelpID" UUID DEFAULT uuid_generate_v1() NOT NULL,
  "Name" VARCHAR(400) NOT NULL,
  "Description" VARCHAR(2000),
  "HelpTypeID" INTEGER NOT NULL,
  "IsActive" BOOLEAN DEFAULT true NOT NULL,
  "IsDeleted" BOOLEAN DEFAULT false NOT NULL,
  "CreatedOn" TIMESTAMP WITH TIME ZONE DEFAULT now() NOT NULL,
  "ModifiedOn" TIMESTAMP WITH TIME ZONE,
  "UiPageUrl" VARCHAR(400),
  "CreatedBy" UUID NOT NULL,
  "ModifiedBy" UUID,
  CONSTRAINT "Help_pkey" PRIMARY KEY("HelpID"),
  CONSTRAINT "HelpTypeiD_Classificiation" FOREIGN KEY ("HelpTypeID")
    REFERENCES public."ClassificationType"("ClassificationTypeID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE,
  CONSTRAINT "Help_fk" FOREIGN KEY ("CreatedBy")
    REFERENCES public."UserAccountOrganisation"("UserAccountOrganisationID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE,
  CONSTRAINT "Help_fk1" FOREIGN KEY ("ModifiedBy")
    REFERENCES public."UserAccountOrganisation"("UserAccountOrganisationID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE
    NOT VALID
) 
WITH (oids = false);

CREATE TABLE public."HelpItem" (
  "HelpItemID" UUID DEFAULT uuid_generate_v1() NOT NULL,
  "HelpID" UUID NOT NULL,
  "Title" VARCHAR(400) NOT NULL,
  "Description" VARCHAR,
  "UiSelector" VARCHAR(400),
  "UiSelectorParent" VARCHAR(400),
  "IsActive" BOOLEAN DEFAULT true NOT NULL,
  "IsDeleted" BOOLEAN DEFAULT false NOT NULL,
  "CreatedOn" TIMESTAMP WITH TIME ZONE DEFAULT now() NOT NULL,
  "ModifiedOn" TIMESTAMP WITH TIME ZONE,
  "DisplayOrder" INTEGER DEFAULT (-1),
  "EffectiveFrom" TIMESTAMP WITH TIME ZONE,
  "UiPosition" INTEGER,
  "CreatedBy" UUID NOT NULL,
  "ModifiedBy" UUID,
  "IncludeStartTour" BOOLEAN DEFAULT false NOT NULL,
  CONSTRAINT "HelpItem_pkey" PRIMARY KEY("HelpItemID"),
  CONSTRAINT "HelpItem_fk" FOREIGN KEY ("UiPosition")
    REFERENCES public."ClassificationType"("ClassificationTypeID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE,
  CONSTRAINT "HelpItem_fk1" FOREIGN KEY ("CreatedBy")
    REFERENCES public."UserAccountOrganisation"("UserAccountOrganisationID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE,
  CONSTRAINT "HelpItem_fk2" FOREIGN KEY ("ModifiedBy")
    REFERENCES public."UserAccountOrganisation"("UserAccountOrganisationID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE,
  CONSTRAINT "Help_HelpItem" FOREIGN KEY ("HelpID")
    REFERENCES public."Help"("HelpID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE
) 
WITH (oids = false);

CREATE TABLE public."HelpItemRole" (
  "HelpItemID" UUID NOT NULL,
  "RoleID" UUID NOT NULL,
  CONSTRAINT "HelpItemRole_pkey" PRIMARY KEY("RoleID", "HelpItemID"),
  CONSTRAINT "HelpItemRole_fk" FOREIGN KEY ("RoleID")
    REFERENCES public."Role"("RoleID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE,
  CONSTRAINT "HelpItem_HelpItemRole" FOREIGN KEY ("HelpItemID")
    REFERENCES public."HelpItem"("HelpItemID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE
) 
WITH (oids = false);

CREATE TABLE public."HelpRole" (
  "HelpRoleID" UUID DEFAULT uuid_generate_v1() NOT NULL,
  "RoleID" UUID NOT NULL,
  CONSTRAINT "HelpRole_pkey" PRIMARY KEY("HelpRoleID"),
  CONSTRAINT "HelpRole_fk" FOREIGN KEY ("RoleID")
    REFERENCES public."Role"("RoleID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE
) 
WITH (oids = false);

CREATE TABLE public."UserAccountOrganisationHelpViewed" (
  "UserAccountOrganisationID" UUID NOT NULL,
  "HelpItemID" UUID NOT NULL,
  "CreatedOn" TIMESTAMP WITH TIME ZONE DEFAULT now() NOT NULL,
  CONSTRAINT "pkUserAccountOrganisationHelpViewed" PRIMARY KEY("UserAccountOrganisationID", "HelpItemID"),
  CONSTRAINT "HelpItemID_UAOID" FOREIGN KEY ("HelpItemID")
    REFERENCES public."HelpItem"("HelpItemID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE,
  CONSTRAINT "UAO_UaoHelpViewed" FOREIGN KEY ("UserAccountOrganisationID")
    REFERENCES public."UserAccountOrganisation"("UserAccountOrganisationID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE
) 
WITH (oids = false);

-- views
CREATE TABLE public."RoleHierarchy" (
  "RoleHierarchyID" UUID DEFAULT uuid_generate_v1() NOT NULL,
  "RoleID" UUID NOT NULL,
  "ParentRoleID" UUID,
  "Level" INTEGER NOT NULL,
  CONSTRAINT "pkRoleHierarchy" PRIMARY KEY("RoleID", "RoleHierarchyID", "Level"),
  CONSTRAINT "Hierarchy_ParentRoleID" FOREIGN KEY ("ParentRoleID")
    REFERENCES public."Role"("RoleID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE,
  CONSTRAINT "Hierarchy_RoleID" FOREIGN KEY ("RoleID")
    REFERENCES public."Role"("RoleID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE
) 
WITH (oids = false);


CREATE VIEW public."vOrganisationRoleHierarchy" (
    "OrganisationRoleID",
    "RoleID",
    "RoleName",
    "ParentRoleID",
    "ParentRoleName",
    "Level",
    "RoleHierarchyID")
AS
SELECT orgr."OrganisationRoleID",
    rh."RoleID",
    r."RoleName",
    rp."RoleID" AS "ParentRoleID",
    rp."RoleName" AS "ParentRoleName",
    rh."Level",
    rh."RoleHierarchyID"
FROM "OrganisationRole" orgr
     JOIN "RoleHierarchy" rh ON rh."RoleID" = orgr."ParentID"
     JOIN "Role" r ON r."RoleID" = rh."RoleID"
     LEFT JOIN "Role" rp ON rp."RoleID" = rh."ParentRoleID";

-- functions
CREATE OR REPLACE FUNCTION public."fn_GetHelpItems" (
  "UserAccountOrganisationID" uuid,
  "HelpTypeID" integer,
  "UiPageUrl" varchar = NULL::character varying
)
RETURNS SETOF public."HelpItem" AS
$body$
  	select 
    
    hipp."HelpItemID",
  hipp."HelpID",
  hipp."Title",
  hipp."Description",
  hipp."UiSelector",
  hipp."UiSelectorParent",
  hipp."IsActive",
  hipp."IsDeleted",
  hipp."CreatedOn",
  hipp."ModifiedOn",
  hipp."DisplayOrder",
  hipp."EffectiveFrom",
  hipp."UiPosition",
  hipp."CreatedBy",
  hipp."ModifiedBy",
  hipp."IncludeStartTour"
     from "HelpItem" hipp
    
    left outer join "Help" hel on hel."HelpID" = hipp."HelpID"
    
    where hipp."IsDeleted" = false and  hipp."HelpItemID" =
     (select hip."HelpItemID"
     from "HelpItem" hip
          inner join 
          (
            select hir."HelpItemID",
                   min(vrh."Level") as hiLevel
            from "HelpItemRole" hir
                 inner join "vOrganisationRoleHierarchy" vrh on vrh."RoleID" =
                   hir."RoleID"
                 inner join "UserAccountOrganisationRole" uaor on
                   uaor."OrganisationRoleID" = vrh."OrganisationRoleID"
            where uaor."UserAccountOrganisationID" =
              $1
            group by hir."HelpItemID"
          ) boo on boo."HelpItemID" = hip."HelpItemID"
     where hip."IsDeleted" = false and  ((hipp."UiSelector" = hip."UiSelector") or (hipp."UiSelector" is null and hip."UiSelector" is null)) and hel."HelpTypeID" = $2
      and case when $3 is not null then (hel."UiPageUrl" = $3) else (hel."UiPageUrl" is null) end
      and case when ($2 = (select ct."ClassificationTypeID" from "ClassificationType" ct where ct."Name" = 'Callout' and ct."ClassificationTypeCategoryID" = 91829172))
      	then ((to_date(cast(hipp."EffectiveFrom" as varchar),'yyyy-MM-dd') <= CURRENT_DATE) and (NOT EXISTS (select 1 from "UserAccountOrganisationHelpViewed" hv where
        	hv."HelpItemID" = hipp."HelpItemID" and hv."UserAccountOrganisationID" = $1)))
           else
           1=1
        end
     order by boo.hilevel asc limit 1);
$body$
LANGUAGE 'sql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER
COST 100 ROWS 1000;

-- insert HelpRole data

INSERT INTO public."HelpRole"("RoleID")
VALUES ('b56622a0-3cc0-11e4-acf9-bfd11fd091e6');

INSERT INTO public."HelpRole"("RoleID")
VALUES ('b88849b0-3cc0-11e4-95f5-87c1916ab536');

INSERT INTO public."HelpRole"("RoleID")
VALUES ('a1d2bc0c-2139-11e4-9670-47a78b7cc43f');

INSERT INTO public."HelpRole"("RoleID")
VALUES ('b88822a0-3cc0-11e4-acf9-bfd11fd091e6');

INSERT INTO public."HelpRole"("RoleID")
VALUES ('b55522a0-3cc0-11e4-acf9-bfd11fd091e6');

INSERT INTO public."HelpRole"("RoleID")
VALUES ('5a81f120-bdfe-11e5-882f-00155d0ab503');

INSERT INTO public."HelpRole"("RoleID")
VALUES ('5a8453c0-bdfe-11e5-8830-00155d0ab503');

INSERT INTO public."HelpRole"("RoleID")
VALUES ('de08bac2-cc1f-11e5-8067-00155d0ab503');

-- Role Hierarchy Data
INSERT INTO
  public."RoleHierarchy"
(
  "RoleID",
  "ParentRoleID",
  "Level"
)
VALUES (
  (select "RoleID" from "Role" where "RoleName" = 'User'),
  null,
  0
);

INSERT INTO
  public."RoleHierarchy"
(
  "RoleID",
  "ParentRoleID",
  "Level"
)
VALUES (
  (select "RoleID" from "Role" where "RoleName" = 'Temporary User'),
  null,
  0
);

INSERT INTO
  public."RoleHierarchy"
(
  "RoleID",
  "ParentRoleID",
  "Level"
)
VALUES (
  (select "RoleID" from "Role" where "RoleName" = 'Administration User'),
  null,
  0
);

INSERT INTO
  public."RoleHierarchy"
(
  "RoleID",
  "ParentRoleID",
  "Level"
)
VALUES (
  (select "RoleID" from "Role" where "RoleName" = 'Finance Administrator'),
  (select "RoleID" from "Role" where "RoleName" = 'Administration User'),
  1
);

INSERT INTO
  public."RoleHierarchy"
(
  "RoleID",
  "ParentRoleID",
  "Level"
)
VALUES (
  (select "RoleID" from "Role" where "RoleName" = 'Support Administrator'),
  (select "RoleID" from "Role" where "RoleName" = 'Administration User'),
  1
);

INSERT INTO
  public."RoleHierarchy"
(
  "RoleID",
  "ParentRoleID",
  "Level"
)
VALUES (
  (select "RoleID" from "Role" where "RoleName" = 'Organisation Administrator'),
  null,
  0
);

INSERT INTO
  public."RoleHierarchy"
(
  "RoleID",
  "ParentRoleID",
  "Level"
)
VALUES (
  (select "RoleID" from "Role" where "RoleName" = 'Organisation Employee'),
  (select "RoleID" from "Role" where "RoleName" = 'Organisation Administrator'),
  1
);

INSERT INTO
  public."RoleHierarchy"
(
  "RoleID",
  "ParentRoleID",
  "Level"
)
VALUES (
  (select "RoleID" from "Role" where "RoleName" = 'Lender Administrator'),
  null,
  0
);

INSERT INTO
  public."RoleHierarchy"
(
  "RoleID",
  "ParentRoleID",
  "Level"
)
VALUES (
  (select "RoleID" from "Role" where "RoleName" = 'Lender Employee'),
  (select "RoleID" from "Role" where "RoleName" = 'Lender Administrator'),
  1
);

-- GRANTS
GRANT DELETE, INSERT, REFERENCES, SELECT, TRIGGER, TRUNCATE, UPDATE ON Help TO bef; -- Add
GRANT DELETE, INSERT, REFERENCES, SELECT, TRIGGER, TRUNCATE, UPDATE ON HelpItem TO bef; -- Add
GRANT DELETE, INSERT, REFERENCES, SELECT, TRIGGER, TRUNCATE, UPDATE ON HelpItemRole TO bef; -- Add
GRANT DELETE, INSERT, REFERENCES, SELECT, TRIGGER, TRUNCATE, UPDATE ON HelpRole TO bef; -- Add
GRANT DELETE, INSERT, REFERENCES, SELECT, TRIGGER, TRUNCATE, UPDATE ON RoleHierarchy TO bef; -- Add
GRANT DELETE, INSERT, REFERENCES, SELECT, TRIGGER, TRUNCATE, UPDATE ON TempJsonData TO bef; -- Add
GRANT DELETE, INSERT, REFERENCES, SELECT, TRIGGER, TRUNCATE, UPDATE ON UserAccountOrganisationHelpViewed TO bef; -- Add
GRANT DELETE, INSERT, REFERENCES, SELECT, TRIGGER, TRUNCATE, UPDATE ON vOrganisationRoleHierarchy TO bef; -- Add
GRANT EXECUTE ON FUNCTION fn_GetHelpItems(in UserAccountOrganisationID uuid, in HelpTypeID int4, in UiPageUrl varchar) TO postgres;
GRANT EXECUTE ON FUNCTION fn_GetHelpItems(in UserAccountOrganisationID uuid, in HelpTypeID int4, in UiPageUrl varchar) TO bef;
GRANT EXECUTE ON FUNCTION fn_GetHelpItems(in UserAccountOrganisationID uuid, in HelpTypeID int4, in UiPageUrl varchar) TO sg_postgres_developer;
GRANT EXECUTE ON FUNCTION fn_GetHelpItems(in UserAccountOrganisationID uuid, in HelpTypeID int4, in UiPageUrl varchar) TO sg_postgres_application;
