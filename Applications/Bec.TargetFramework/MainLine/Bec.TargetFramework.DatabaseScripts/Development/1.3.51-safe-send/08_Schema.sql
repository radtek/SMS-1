CREATE TABLE public."File" (
  "FileID" UUID DEFAULT uuid_generate_v1() NOT NULL,
  "ParentID" UUID NOT NULL,
  "Name" VARCHAR NOT NULL,
  "Data" BYTEA NOT NULL,
  "Type" VARCHAR NOT NULL,
  "UserAccountOrganisationID" UUID,
  "Temporary" boolean default false not null
  PRIMARY KEY("FileID")
) ;

ALTER TABLE public."File"
  ALTER COLUMN "FileID" SET STATISTICS 0;

ALTER TABLE public."File"
  ALTER COLUMN "ParentID" SET STATISTICS 0;

ALTER TABLE public."File"
  ALTER COLUMN "Name" SET STATISTICS 0;

ALTER TABLE public."File"
  ALTER COLUMN "Data" SET STATISTICS 0; 

CREATE INDEX "File_idx_Parent" ON public."File"
  USING btree ("ParentID");

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."File" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."File" TO bef;

ALTER TABLE public."Notification"
  ALTER COLUMN "NotificationID" DROP DEFAULT;

  ALTER TABLE public."File"
  ADD CONSTRAINT "File_fk_UserAccountOrganisation" FOREIGN KEY ("UserAccountOrganisationID")
    REFERENCES public."UserAccountOrganisation"("UserAccountOrganisationID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;


CREATE FUNCTION public."fn_AttachUploads" (
  uaoid uuid,
  id uuid,
  newid uuid
)
RETURNS void AS
$body$
BEGIN
  update "File" set "ParentID" = newid, "Temporary" = false
  where "ParentID" = id and "UserAccountOrganisationID" = uaoid and "Temporary" = true;
END;
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER;

grant execute on function public."fn_AttachUploads"(uaoid uuid, id uuid, newid uuid) to postgres;
grant execute on function public."fn_AttachUploads"(uaoid uuid, id uuid, newid uuid) to bef;