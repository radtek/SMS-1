
DROP TABLE public."OrganisationSetting";

CREATE TABLE public."OrganisationSetting" (
  "OrganisationSettingID" UUID NOT NULL,
  "Name" VARCHAR(200) NOT NULL,
  "Value" VARCHAR(2000) NOT NULL,
  "IsActive" BOOLEAN DEFAULT true NOT NULL,
  "IsDeleted" BOOLEAN DEFAULT false NOT NULL,
  "OrganisationID" UUID NOT NULL,
  CONSTRAINT "pkOrganisationSetting" PRIMARY KEY("OrganisationSettingID"),
  CONSTRAINT "fk_OrganisationSetting_Organisation" FOREIGN KEY ("OrganisationID")
    REFERENCES public."Organisation"("OrganisationID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE
) 
WITH (oids = false);
