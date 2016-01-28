CREATE TABLE public."OrganisationNote" (
  "OrganisationNoteID" UUID DEFAULT uuid_generate_v1() NOT NULL,
  "OrganisationID" UUID NOT NULL,
  "UserAccountOrganisationID" UUID NOT NULL,
  "DateTime" TIMESTAMP WITH TIME ZONE DEFAULT now() NOT NULL,
  "Notes" TEXT NOT NULL,
  CONSTRAINT "OrganisationNote_pkey" PRIMARY KEY("OrganisationNoteID"),
  CONSTRAINT "OrganisationNote_Organisation_fk" FOREIGN KEY ("OrganisationID")
    REFERENCES public."Organisation"("OrganisationID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE,
  CONSTRAINT "OrganisationNote_UserAccountOrganisation_fk" FOREIGN KEY ("UserAccountOrganisationID")
    REFERENCES public."UserAccountOrganisation"("UserAccountOrganisationID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE
) 
WITH (oids = false);

grant select, insert, update, delete on public."OrganisationNote" to bef;
grant select, insert, update, delete on public."OrganisationNote" to postgres;