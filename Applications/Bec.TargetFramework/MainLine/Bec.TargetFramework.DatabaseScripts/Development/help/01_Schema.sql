CREATE TABLE public."HelpPage" (
  "HelpPageID" UUID DEFAULT uuid_generate_v1() NOT NULL,
  "PageName" VARCHAR(200) NOT NULL,
  "PageUrl" VARCHAR(400) NOT NULL,
  "HelpPageTypeId" INTEGER NOT NULL,
  "CreatedOn" TIMESTAMP(0) WITH TIME ZONE DEFAULT now() NOT NULL,
  "ModifiedOn" TIMESTAMP(0) WITH TIME ZONE,
  "CreatedBy" VARCHAR(200) NOT NULL,
  "ModifiedBy" VARCHAR(200),
  "IsActive" BOOLEAN DEFAULT true NOT NULL,
  "IsDeleted" BOOLEAN DEFAULT false NOT NULL,
  CONSTRAINT "HelpPage_pkey" PRIMARY KEY("HelpPageID")  
) 
WITH (oids = false);


CREATE TABLE public."HelpPageItem" (
  "HelpPageItemID" UUID NOT NULL,
  "HelpPageID" UUID NOT NULL,
  "Title" VARCHAR(200) NOT NULL,
  "Description" VARCHAR NOT NULL,
  "DisplayOrder" INTEGER DEFAULT 0 NOT NULL,
  "Selector" VARCHAR(200),
  "TabContainerId" VARCHAR(50),
  "EffectiveOn" TIMESTAMP WITHOUT TIME ZONE,
  "Position" INTEGER,
  "CreatedOn" TIMESTAMP(0) WITH TIME ZONE DEFAULT now() NOT NULL,
  "ModifiedOn" TIMESTAMP(0) WITH TIME ZONE,
  "CreatedBy" VARCHAR(200),
  "ModifiedBy" VARCHAR(200),
  CONSTRAINT "HelpPageItem_pkey" PRIMARY KEY("HelpPageItemID"),
  CONSTRAINT "fk_HelpPageItem_HelpPage" FOREIGN KEY ("HelpPageID")
    REFERENCES public."HelpPage"("HelpPageID")
    ON DELETE CASCADE
    ON UPDATE NO ACTION
    NOT DEFERRABLE
) 
WITH (oids = false);


CREATE TABLE public."HelpPageItemUserAccount" (
  "HelpItemUserAccountID" UUID NOT NULL,
  "HelpPageItemID" UUID NOT NULL,
  "CreatedOn" TIMESTAMP(0) WITH TIME ZONE DEFAULT now() NOT NULL,
  "UserID" UUID NOT NULL,
  "Visible" BOOLEAN DEFAULT false,
  CONSTRAINT "HelpItemUserAccount_pkey" PRIMARY KEY("HelpItemUserAccountID"),
  CONSTRAINT "fk_HelpItemUserAccount_HelpPageItem" FOREIGN KEY ("HelpPageItemID")
    REFERENCES public."HelpPageItem"("HelpPageItemID")
    ON DELETE CASCADE
    ON UPDATE NO ACTION
    NOT DEFERRABLE,
  CONSTRAINT "fk_HelpItemUserAccount_UserAccount" FOREIGN KEY ("UserID")
    REFERENCES public."UserAccounts"("ID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE
) 
WITH (oids = false);

CREATE TABLE public."HelpPageItemRole" (
  "HelpPageItemRoleID" UUID DEFAULT uuid_generate_v1() NOT NULL,
  "RoleID" UUID NOT NULL,
  "HelpPageItemID" UUID NOT NULL,
  "IsActive" BOOLEAN DEFAULT true NOT NULL,
  "IsDeleted" BOOLEAN DEFAULT false NOT NULL,
  CONSTRAINT "HelpPageItemRole_pkey" PRIMARY KEY("HelpPageItemRoleID"),
  CONSTRAINT "fk_HelpPageItemRole_HelpPageItem" FOREIGN KEY ("HelpPageItemID")
    REFERENCES public."HelpPageItem"("HelpPageItemID")
    ON DELETE CASCADE
    ON UPDATE NO ACTION
    NOT DEFERRABLE,
  CONSTRAINT "fk_HelpPageItemRole_Role" FOREIGN KEY ("RoleID")
    REFERENCES public."Role"("RoleID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE
) 
WITH (oids = false);

CREATE TABLE public."RoleHierarchy" (
  "RoleHierarchyID" UUID DEFAULT uuid_generate_v1() NOT NULL,
  "RoleID" UUID NOT NULL,
  "ParentID" UUID,
  "IsActive" BOOLEAN DEFAULT true NOT NULL,
  "IsDeleted" BOOLEAN DEFAULT false NOT NULL,
  "Level" INTEGER NOT NULL,
  CONSTRAINT "RoleHierarchy_pkey" PRIMARY KEY("RoleHierarchyID"),
  CONSTRAINT "fk_RoleHierarchy_Role" FOREIGN KEY ("RoleID")
    REFERENCES public."Role"("RoleID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE
) 
WITH (oids = false);

/* Data for the 'public.RoleHierarchy' table  (Records 1 - 8) */

INSERT INTO public."RoleHierarchy" ("RoleHierarchyID", "RoleID", "ParentID", "IsActive", "IsDeleted", "Level")
VALUES (E'11d87994-e1b2-11e5-8bd7-00155d0a860e', E'a1d1f8b2-2139-11e4-b1aa-a7c8d954f17c', NULL, True, False, 1);

INSERT INTO public."RoleHierarchy" ("RoleHierarchyID", "RoleID", "ParentID", "IsActive", "IsDeleted", "Level")
VALUES (E'1b2a1b74-e1b2-11e5-8bd8-00155d0a860e', E'a1d26e64-2139-11e4-88fd-433c5be48343', NULL, True, False, 1);

INSERT INTO public."RoleHierarchy" ("RoleHierarchyID", "RoleID", "ParentID", "IsActive", "IsDeleted", "Level")
VALUES (E'4d6915a4-e1b2-11e5-8bda-00155d0a860e', E'a1d2bc0c-2139-11e4-9670-47a78b7cc43f', NULL, True, False, 1);

INSERT INTO public."RoleHierarchy" ("RoleHierarchyID", "RoleID", "ParentID", "IsActive", "IsDeleted", "Level")
VALUES (E'543b81e6-e1b2-11e5-8bdb-00155d0a860e', E'b55522a0-3cc0-11e4-acf9-bfd11fd091e6', E'a1d2bc0c-2139-11e4-9670-47a78b7cc43f', True, False, 2);

INSERT INTO public."RoleHierarchy" ("RoleHierarchyID", "RoleID", "ParentID", "IsActive", "IsDeleted", "Level")
VALUES (E'9c962734-e1b2-11e5-8bdc-00155d0a860e', E'b56622a0-3cc0-11e4-acf9-bfd11fd091e6', E'a1d2bc0c-2139-11e4-9670-47a78b7cc43f', True, False, 2);

INSERT INTO public."RoleHierarchy" ("RoleHierarchyID", "RoleID", "ParentID", "IsActive", "IsDeleted", "Level")
VALUES (E'e0475b42-e1b2-11e5-8bdd-00155d0a860e', E'b88822a0-3cc0-11e4-acf9-bfd11fd091e6', NULL, True, False, 1);

INSERT INTO public."RoleHierarchy" ("RoleHierarchyID", "RoleID", "ParentID", "IsActive", "IsDeleted", "Level")
VALUES (E'ee79a7ba-e1b2-11e5-8bde-00155d0a860e', E'b88849b0-3cc0-11e4-95f5-87c1916ab536', E'b88822a0-3cc0-11e4-acf9-bfd11fd091e6', True, False, 2);

INSERT INTO public."RoleHierarchy" ("RoleHierarchyID", "RoleID", "ParentID", "IsActive", "IsDeleted", "Level")
VALUES (E'0ac031a0-e1b3-11e5-8bdf-00155d0a860e', E'b88849b0-3cc0-11e4-8d6b-0719c31a5e20', E'b88822a0-3cc0-11e4-acf9-bfd11fd091e6', True, False, 2);


GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."HelpPage" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."HelpPage" TO bef;

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."HelpPageItem" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."HelpPageItem" TO bef;

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."HelpPageItemUserAccount" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."HelpPageItemUserAccount" TO bef;


GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."RoleHierarchy" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."RoleHierarchy" TO bef;

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."HelpPageItemRole" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."HelpPageItemRole" TO bef;