ALTER TABLE public."YourTableNameHere"
  ADD COLUMN "RowVersion" BIGINT DEFAULT nextval('rvsequence'::regclass) NOT NULL;

ALTER TABLE public."YourTableNameHere"
  ALTER COLUMN "RowVersion" DROP NOT NULL;