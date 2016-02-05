ALTER TABLE public."Lender" ADD COLUMN "OrganisationID" UUID;

ALTER TABLE public."Lender"
  ADD CONSTRAINT "Lender_Organisation_fk" FOREIGN KEY ("OrganisationID")
    REFERENCES public."Organisation"("OrganisationID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;