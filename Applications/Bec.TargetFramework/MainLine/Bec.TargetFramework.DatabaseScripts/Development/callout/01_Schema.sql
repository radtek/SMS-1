CREATE TABLE public."Callout" (
  "CalloutID" UUID NOT NULL,
  "RoleID" UUID NOT NULL,
  "Title" VARCHAR(200) NOT NULL,
  "Description" VARCHAR NOT NULL,
  "IsActive" BOOLEAN DEFAULT true NOT NULL,
  "IsDeleted" BOOLEAN DEFAULT false NOT NULL,
  "DisplayOrder" INTEGER DEFAULT 1 NOT NULL,
  "CreatedOn" TIMESTAMP(0) WITH TIME ZONE DEFAULT now() NOT NULL,
  "ModifiedOn" TIMESTAMP(0) WITH TIME ZONE,
  "CreatedBy" VARCHAR(200),
  "ModifiedBy" VARCHAR(200),
  "Selector" VARCHAR(500),
  "EffectiveOn" TIMESTAMP WITHOUT TIME ZONE NOT NULL,
  "Position" INTEGER,
  CONSTRAINT "pkCallout" PRIMARY KEY("CalloutID"),
  CONSTRAINT "Callout_Role_fk" FOREIGN KEY ("RoleID")
    REFERENCES public."Role"("RoleID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE
) 
WITH (oids = false);




CREATE TABLE public."CalloutUserAccount" (
  "CalloutUserAccountID" UUID NOT NULL,
  "CalloutID" UUID NOT NULL,
  "RoleID" UUID NOT NULL,
  "IsDeleted" BOOLEAN DEFAULT false NOT NULL,
  "CreatedOn" TIMESTAMP(0) WITH TIME ZONE DEFAULT now() NOT NULL,
  "UserID" UUID NOT NULL,
  CONSTRAINT "pkCalloutUserAccount" PRIMARY KEY("CalloutUserAccountID"),
  CONSTRAINT "CalloutUserAccount_Callout_fk" FOREIGN KEY ("CalloutID")
    REFERENCES public."Callout"("CalloutID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE,
  CONSTRAINT "CalloutUserAccount_UserType_fk" FOREIGN KEY ("RoleID")
    REFERENCES public."Role"("RoleID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE
) 
WITH (oids = false);


