
CREATE TABLE public."Function" (
  "FunctionID" UUID NOT NULL,
  "OrganisationTypeID" INTEGER NOT NULL,
  "Name" VARCHAR(100) NOT NULL UNIQUE,
  PRIMARY KEY("FunctionID")
);

ALTER TABLE public."Function"
  ADD CONSTRAINT "Function_OrganisationType_fk" FOREIGN KEY ("OrganisationTypeID")
    REFERENCES public."OrganisationType"("OrganisationTypeID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."Function" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."Function" TO bef;

-- =============

CREATE TABLE public."UserAccountOrganisationFunction" (
  "UserAccountOrganisationID" UUID NOT NULL,
  "FunctionID" UUID NOT NULL,
  PRIMARY KEY("UserAccountOrganisationID", "FunctionID")
) ;

ALTER TABLE public."UserAccountOrganisationFunction"
  ADD CONSTRAINT "UserAccountOrganisationFunction_UserAccountOrganisation_fk" FOREIGN KEY ("UserAccountOrganisationID")
    REFERENCES public."UserAccountOrganisation"("UserAccountOrganisationID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;

ALTER TABLE public."UserAccountOrganisationFunction"
  ADD CONSTRAINT "UserAccountOrganisationFunction_Function_fk" FOREIGN KEY ("FunctionID")
    REFERENCES public."Function"("FunctionID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."UserAccountOrganisationFunction" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."UserAccountOrganisationFunction" TO bef;

-- =============

CREATE TABLE public."ConversationFunctionParticipant" (
  "ConversationID" UUID NOT NULL,
  "OrganisationID" UUID NOT NULL,
  "FunctionID" UUID NOT NULL,
  "Added" TIMESTAMP(0) WITH TIME ZONE DEFAULT now() NOT NULL,
  PRIMARY KEY("ConversationID", "FunctionID")
);

ALTER TABLE public."ConversationFunctionParticipant"
  ADD CONSTRAINT "ConversationFunctionParticipant_Conversation_fk" FOREIGN KEY ("ConversationID")
    REFERENCES public."Conversation"("ConversationID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;

ALTER TABLE public."ConversationFunctionParticipant"
  ADD CONSTRAINT "ConversationFunctionParticipant_Organisation_fk" FOREIGN KEY ("OrganisationID")
    REFERENCES public."Organisation"("OrganisationID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;
    
ALTER TABLE public."ConversationFunctionParticipant"
  ADD CONSTRAINT "ConversationFunctionParticipant_Function_fk" FOREIGN KEY ("FunctionID")
    REFERENCES public."Function"("FunctionID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;

GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES, TRIGGER, TRUNCATE
  ON public."ConversationFunctionParticipant" TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public."ConversationFunctionParticipant" TO bef;

-- =============
