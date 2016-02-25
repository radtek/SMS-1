CREATE TABLE public."FieldUpdate" (
  "ActivityID" UUID NOT NULL,
  "ActivityType" INTEGER NOT NULL,
  "ParentID" UUID NOT NULL,
  "ParentType" INTEGER NOT NULL,
  "FieldName" VARCHAR(100) NOT NULL,
  "Value" VARCHAR,
  "UserAccountOrganisationID" UUID NOT NULL,
  "ModifiedOn" TIMESTAMP(0) WITH TIME ZONE NOT NULL,
  PRIMARY KEY("ActivityID", "ActivityType", "ParentID", "ParentType", "FieldName")
) ;

ALTER TABLE public."FieldUpdate"
  ALTER COLUMN "ActivityID" SET STATISTICS 0;

ALTER TABLE public."FieldUpdate"
  ALTER COLUMN "ActivityType" SET STATISTICS 0;

ALTER TABLE public."FieldUpdate"
  ALTER COLUMN "ParentID" SET STATISTICS 0;

ALTER TABLE public."FieldUpdate"
  ALTER COLUMN "FieldName" SET STATISTICS 0;

ALTER TABLE public."FieldUpdate"
  ALTER COLUMN "Value" SET STATISTICS 0;

ALTER TABLE public."FieldUpdate"
  ADD CONSTRAINT "FieldUpdate_UserAccountOrganisation_fk" FOREIGN KEY ("UserAccountOrganisationID")
    REFERENCES public."UserAccountOrganisation"("UserAccountOrganisationID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."FieldUpdate" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."FieldUpdate" TO bef;