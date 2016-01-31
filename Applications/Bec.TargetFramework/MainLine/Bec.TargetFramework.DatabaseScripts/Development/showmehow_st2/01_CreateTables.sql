CREATE TABLE public."SMHPage" (
  "PageID" UUID DEFAULT uuid_generate_v1() NOT NULL,
  "PageName" VARCHAR(100) NOT NULL,
  "PageURL" VARCHAR(100) NOT NULL,
  "RoleId" UUID,
  CONSTRAINT "SMHPage_pkey" PRIMARY KEY("PageID")
)
WITH (oids = false);

CREATE TABLE public."SMHItem" (
  "ItemID" UUID DEFAULT uuid_generate_v1() NOT NULL,
  "PageID" UUID NOT NULL,
  "ItemName" VARCHAR(100) NOT NULL,
  "ItemSelector" VARCHAR(200),
  "ItemDescription" VARCHAR(1000),
  "ItemPosition" INTEGER DEFAULT 0 NOT NULL,
  "ItemOrder" INTEGER DEFAULT 0 NOT NULL,
  "TabContainerId" VARCHAR(50),
  CONSTRAINT "SMHItem_pkey" PRIMARY KEY("ItemID"),
  CONSTRAINT "fk_SMHItem_SMHPage" FOREIGN KEY ("PageID")
    REFERENCES public."SMHPage"("PageID")
    ON DELETE CASCADE
    ON UPDATE NO ACTION
    NOT DEFERRABLE
)
WITH (oids = false);
