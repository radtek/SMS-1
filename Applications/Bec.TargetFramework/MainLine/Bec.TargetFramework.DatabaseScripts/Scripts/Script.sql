ALTER TABLE "public"."Invoice" ADD "UserAccountOrganisationID" UUID NULL;


/******************** Update Table: ShoppingCart ************************/

ALTER TABLE "public"."ShoppingCart" ALTER COLUMN "OrganisationID" DROP NOT NULL;

ALTER TABLE "public"."ShoppingCart" ADD "UserAccountOrganisationID" UUID NULL;





/************ Add Foreign Keys ***************/

/* Add Foreign Key: fk_Invoice_UserAccountOrganisation */
ALTER TABLE "public"."Invoice" ADD CONSTRAINT "fk_Invoice_UserAccountOrganisation"
	FOREIGN KEY ("UserAccountOrganisationID") REFERENCES "public"."UserAccountOrganisation" ("UserAccountOrganisationID")
	ON UPDATE NO ACTION ON DELETE NO ACTION;

/* Add Foreign Key: fk_ShoppingCart_UserAccountOrganisation */
ALTER TABLE "public"."ShoppingCart" ADD CONSTRAINT "fk_ShoppingCart_UserAccountOrganisation"
	FOREIGN KEY ("UserAccountOrganisationID") REFERENCES "public"."UserAccountOrganisation" ("UserAccountOrganisationID")
	ON UPDATE NO ACTION ON DELETE NO ACTION;