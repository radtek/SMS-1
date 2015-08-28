-- DUAL Hijack Insurance

-- Base Price £10
-- Deductions 6% IPT
-- Supplier - DUAL
-- Cannot be sold separately


DO $$
Declare LandRegistryID uuid;
Declare LoopRow Record;
Begin

-- promote all products
FOR LoopRow IN
	select * from "ProductTemplate" aw
    	--where aw."OwnerOrganisationID" = LandRegistryID
LOOP
    BEGIN
    	perform "fn_PromoteProductTemplate"(LoopRow."ProductTemplateID",LoopRow."ProductVersionID",true,true,true);
    END;
END LOOP;


END $$;