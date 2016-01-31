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







CREATE OR REPLACE FUNCTION public.fn_insertcalloutclaims (
)
RETURNS boolean AS
$body$
DECLARE 
	orid uuid;
    rid uuid;
    resid uuid;
    opvid uuid;
       count int;
BEGIN
	INSERT INTO "Resource" ("ResourceName", "ResourceDescription")
    VALUES ('Callout', 'Callout');

	SELECT "RoleID" FROM "Role" WHERE "RoleName" = 'Support Administrator' LIMIT 1 INTO rid;
    SELECT "ResourceID" FROM "Resource" WHERE "ResourceName" = 'Callout' LIMIT 1 INTO resid;
    SELECT "OperationID" FROM "Operation" WHERE "OperationName" = 'Add' LIMIT 1 INTO opvid;
  
    
    INSERT INTO "RoleClaim" ("RoleID", "ResourceID", "OperationID")
    VALUES (rid, resid, opvid);

       
    FOR orid IN (
    	SELECT "OrganisationRoleID" 
        FROM "OrganisationRole"
        WHERE "RoleName" = 'Support Administrator'
    )
    LOOP
    	SELECT COUNT("OrganisationRoleClaimID")
        FROM "OrganisationRoleClaim"
        WHERE "OrganisationRoleID" = orid
        	AND "ResourceID" = resid
            AND "OperationID" = opvid
        INTO count;
        IF count = 0 THEN
        	INSERT INTO "OrganisationRoleClaim" ("OrganisationRoleID", "ResourceID", "OperationID", "OrganisationID")
            VALUES (orid, resid, opvid, 
            	(SELECT "OrganisationID" FROM "OrganisationRole" WHERE "OrganisationRoleID" = orid)
            );
        END IF;
        
    END LOOP;
    RETURN TRUE;
END
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER
COST 100;

SELECT fn_insertcalloutclaims ();