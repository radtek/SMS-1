CREATE TABLE public."HelpPage" (
  "HelpPageID" UUID NOT NULL,
  "PageName" VARCHAR(200) NOT NULL,
  "PageUrl" VARCHAR(200) NOT NULL,
  "PageType" INTEGER NOT NULL,
  "CreatedOn" TIMESTAMP(0) WITH TIME ZONE DEFAULT now() NOT NULL,
  "ModifiedOn" TIMESTAMP(0) WITH TIME ZONE,
  "CreatedBy" VARCHAR(200),
  "ModifiedBy" VARCHAR(200),
  CONSTRAINT "HelpPage_pkey" PRIMARY KEY("HelpPageID")
) 
WITH (oids = false);


CREATE TABLE public."HelpItem" (
  "HelpItemID" UUID NOT NULL,
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
  CONSTRAINT "HelpItem_pkey" PRIMARY KEY("HelpItemID"),
  CONSTRAINT "fk_HelpItem_HelpPage" FOREIGN KEY ("HelpPageID")
    REFERENCES public."HelpPage"("HelpPageID")
    ON DELETE CASCADE
    ON UPDATE NO ACTION
    NOT DEFERRABLE
) 
WITH (oids = false);


CREATE TABLE public."HelpItemUserAccount" (
  "HelpItemUserAccountID" UUID NOT NULL,
  "HelpItemID" UUID NOT NULL,
  "CreatedOn" TIMESTAMP(0) WITH TIME ZONE DEFAULT now() NOT NULL,
  "UserID" UUID NOT NULL,
  "Visible" BOOLEAN DEFAULT false,
  CONSTRAINT "HelpItemUserAccount_pkey" PRIMARY KEY("HelpItemUserAccountID"),
  CONSTRAINT "fk_HelpItemUserAccount_HelpItem" FOREIGN KEY ("HelpItemID")
    REFERENCES public."HelpItem"("HelpItemID")
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