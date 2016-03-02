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