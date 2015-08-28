DO $$
Declare DoTemplateID uuid;
Declare DoVersionNumber integer;
Begin

DoTemplateID:= (select dot."DefaultOrganisationTemplateID" from "DefaultOrganisationTemplate" dot where dot."Name" = 'Professional Organisation' limit 1);
DoVersionNumber = 1;

perform "fn_PromoteDefaultOrganisationTemplate"(DoTemplateID, DoVersionNumber);

END $$;