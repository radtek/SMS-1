
CREATE TABLE public."SafeSendGroup" (
  "SafeSendGroupID" UUID NOT NULL,
  "OrganisationTypeID" INTEGER NOT NULL,
  "Name" VARCHAR(100) NOT NULL UNIQUE,
  PRIMARY KEY("SafeSendGroupID")
);

ALTER TABLE public."SafeSendGroup"
  ADD CONSTRAINT "SafeSendGroup_OrganisationType_fk" FOREIGN KEY ("OrganisationTypeID")
    REFERENCES public."OrganisationType"("OrganisationTypeID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."SafeSendGroup" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."SafeSendGroup" TO bef;

-- =============

CREATE TABLE public."UserAccountOrganisationSafeSendGroup" (
  "UserAccountOrganisationID" UUID NOT NULL,
  "SafeSendGroupID" UUID NOT NULL,
  "IsActive" BOOLEAN DEFAULT true NOT NULL,
  "IsDeleted" BOOLEAN DEFAULT false NOT NULL,
  PRIMARY KEY("UserAccountOrganisationID", "SafeSendGroupID")
) ;

ALTER TABLE public."UserAccountOrganisationSafeSendGroup"
  ADD CONSTRAINT "UserAccountOrganisationSafeSendGroup_UserAccountOrganisation_fk" FOREIGN KEY ("UserAccountOrganisationID")
    REFERENCES public."UserAccountOrganisation"("UserAccountOrganisationID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;

ALTER TABLE public."UserAccountOrganisationSafeSendGroup"
  ADD CONSTRAINT "UserAccountOrganisationSafeSendGroup_SafeSendGroup_fk" FOREIGN KEY ("SafeSendGroupID")
    REFERENCES public."SafeSendGroup"("SafeSendGroupID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."UserAccountOrganisationSafeSendGroup" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."UserAccountOrganisationSafeSendGroup" TO bef;

-- =============

CREATE TABLE public."ConversationSafeSendGroupParticipant" (
  "ConversationID" UUID NOT NULL,
  "OrganisationID" UUID NOT NULL,
  "SafeSendGroupID" UUID NOT NULL,
  "Added" TIMESTAMP(0) WITH TIME ZONE DEFAULT now() NOT NULL,
  PRIMARY KEY("ConversationID", "SafeSendGroupID")
);

ALTER TABLE public."ConversationSafeSendGroupParticipant"
  ADD CONSTRAINT "ConversationSafeSendGroupParticipant_Conversation_fk" FOREIGN KEY ("ConversationID")
    REFERENCES public."Conversation"("ConversationID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;

ALTER TABLE public."ConversationSafeSendGroupParticipant"
  ADD CONSTRAINT "ConversationSafeSendGroupParticipant_Organisation_fk" FOREIGN KEY ("OrganisationID")
    REFERENCES public."Organisation"("OrganisationID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;
    
ALTER TABLE public."ConversationSafeSendGroupParticipant"
  ADD CONSTRAINT "ConversationSafeSendGroupParticipant_SafeSendGroup_fk" FOREIGN KEY ("SafeSendGroupID")
    REFERENCES public."SafeSendGroup"("SafeSendGroupID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."ConversationSafeSendGroupParticipant" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."ConversationSafeSendGroupParticipant" TO bef;

-- =============

INSERT INTO public."SafeSendGroup"("SafeSendGroupID", "OrganisationTypeID", "Name") VALUES (uuid_generate_v1(), 38, 'Mortgage Offer');
INSERT INTO public."SafeSendGroup"("SafeSendGroupID", "OrganisationTypeID", "Name") VALUES (uuid_generate_v1(), 38, 'Valuation/Security Risk Reporting');
INSERT INTO public."SafeSendGroup"("SafeSendGroupID", "OrganisationTypeID", "Name") VALUES (uuid_generate_v1(), 38, 'Fraud Risk Reporting');
INSERT INTO public."SafeSendGroup"("SafeSendGroupID", "OrganisationTypeID", "Name") VALUES (uuid_generate_v1(), 38, 'Certificate of Title');
INSERT INTO public."SafeSendGroup"("SafeSendGroupID", "OrganisationTypeID", "Name") VALUES (uuid_generate_v1(), 38, 'Redemption Statement');
INSERT INTO public."SafeSendGroup"("SafeSendGroupID", "OrganisationTypeID", "Name") VALUES (uuid_generate_v1(), 38, 'Title Information Document');
INSERT INTO public."SafeSendGroup"("SafeSendGroupID", "OrganisationTypeID", "Name") VALUES (uuid_generate_v1(), 38, 'Requisitions at HMLR');