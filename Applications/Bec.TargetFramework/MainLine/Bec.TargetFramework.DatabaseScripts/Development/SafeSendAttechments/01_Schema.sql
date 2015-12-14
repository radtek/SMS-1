CREATE TABLE public."File" (
  "FileID" UUID DEFAULT uuid_generate_v1() NOT NULL,
  "ParentID" UUID NOT NULL,
  "Name" VARCHAR NOT NULL,
  "Data" BYTEA NOT NULL,
  "Type" VARCHAR NOT NULL,
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

ALTER TABLE public."Notification"
  ALTER COLUMN "NotificationID" DROP DEFAULT;