DO $$
Declare ResourceTypeID integer;
Declare ResourceID UUID;
Declare WorkflowTemplateID UUID := E'08796e7c-2ea9-408e-9b25-291d68e2beab';
Declare WorkflowTemplateVersionNumber  integer := 1;
Declare RoleID UUID;
Declare RoleName varchar(50);
Declare RoleDescription varchar(50);
Declare WorkflowClaimTemplateID UUID;

BEGIN
INSERT INTO public."WorkflowTemplate" ("WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "WorkflowTypeID", "WorkflowSubTypeID", "WorkflowCategoryID", "WorkflowSubCategoryID")
VALUES (WorkflowTemplateID, WorkflowTemplateVersionNumber, E'Registration', E'RegistrationthroughWebsite', (select "ClassificationTypeID" from "ClassificationType" ct
where ct."ClassificationTypeCategoryID"  = 160 and ct."Name"= 'Startup' limit 1), NULL, NULL, NULL);

--Resource  with execute operation
If Not EXISTS(select * from "Resource" where "ResourceName" = 'STSRegistrationWorkflow' limit 1) Then
    Begin
    ResourceTypeID := (select "ClassificationTypeID" from "ClassificationType" where "Name" = 'Workflow' limit 1);

    INSERT INTO
      public."Resource"
    (
      "ResourceName",
      "ResourceDescription",
      "ResourceTypeID"
    )
    VALUES (
      'STSRegistrationWorkflow',
      'STS Registration Workflow',
      ResourceTypeID
    );

    ResourceID := (select "ResourceID" from "Resource" where "ResourceName" = 'STSRegistrationWorkflow' limit 1);

    -- add operation for Execute
    INSERT INTO
      public."ResourceOperation"
    (
      "ResourceID",
      "OperationID"
    )
    VALUES (
      ResourceID,
      (select "OperationID" from "Operation" where "OperationName" = 'Execute' limit 1)
    );
    END;
END IF;
-- add Workflow role entry

--RoleID := (select "RoleID" from "Role" where "IsGlobal" = true and "RoleName" = 'Temporary User' limit 1);

select INTO RoleID, RoleName, RoleDescription  "RoleID", "RoleName", "RoleDescription" from "Role" where "IsGlobal" = true and "RoleName" = 'Temporary User' limit 1;

--WorkflowRoleTemplate
--We will be using global roles

--WorkflowClaimTemplate

WorkflowClaimTemplateID :=(SELECT * FROM public.uuid_generate_v1());
INSERT INTO
  public."WorkflowClaimTemplate"
(
  "WorkflowClaimTemplateID",
  "RoleID",
  "ResourceID",
  "OperationID",
  "WorkflowTemplateID",
  "WorkflowTemplateVersionNumber",
  "IsActive",
  "IsDeleted"
)
VALUES (
  WorkflowClaimTemplateID,
  RoleID,
  ResourceID,
  (select "OperationID" from "Operation" where "OperationName" = 'Execute' limit 1),
  WorkflowTemplateID,
  WorkflowTemplateVersionNumber,
  true,
  false
 );

INSERT INTO public."WorkflowTransistionTemplate" ("WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "IsWorkflowStart", "IsWorkflowEnd")
VALUES (E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'Registration', E'RegisterationthroughWebsite', False, False);

/* Data for the 'public.WorkflowObjectTypeTemplate' table  (Records 1 - 22) */

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'01728ec6-f0b1-11e3-bf2f-6b20bced834d', E'PaymentWithoutPreAuthWorkflowAction', E'PaymentWithoutPreAuthWorkflowAction', E'PaymentWithoutPreAuthWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'12413ef8-f0b3-11e3-8ee0-7322c97b6460', E'BranchesandUsersWorkflowAction', E'BranchesandUsersWorkflowAction', E'BranchesandUsersWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1311eec0-f0b0-11e3-b28a-3f1f84bc9ae8', E'TermsConditionCOWorkflowAction', E'TermsConditionCOWorkflowAction', E'TermsConditionCOWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'334373d9-5d98-4499-abca-6a3618a423a5', E'NextStepsCORegisterWorkflowAction', E'NextStepsCORegisterWorkflowAction', E'NextStepsCORegisterWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'4cf953b2-f0b0-11e3-b0a6-a38f80d3b77e', E'PersonalDetailsWorkflowAction', E'PersonalDetailsWorkflowAction', E'PersonalDetailsWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'4f7dad70-43cd-11e4-a3cb-3bb69610f5f1', E'FirmPreferenceWorkflowAction', E'FirmPreferenceWorkflowAction', E'FirmPreferenceWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'50708a62-f0b3-11e3-a09e-f309ff24ebfc', E'DashboardWorkflowAction', E'DashboardWorkflowAction', E'DashboardWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'8e69ebfe-f0b0-11e3-8797-033066726d5f', E'FirmDetailsCOWorkflowAction', E'FirmDetailsCOWorkflowAction', E'FirmDetailsCOWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'9a01bbe8-43cd-11e4-babd-239048b3d176', E'FirmProductWorkflowAction', E'FirmProductWorkflowAction', E'FirmProductWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'c74167a8-f0b1-11e3-9c44-d7313ee8e6b3', E'PaymentWithPreAuthWorkflowAction', E'PaymentWithPreAuthWorkflowAction', E'PaymentWithPreAuthWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'ce7262bc-f0b0-11e3-a1cd-cf26e6ec9644', E'OrganisationCreditWorkflowAction', E'OrganisationCredit SpecifyNoOfIDCheck', E'OrganisationCreditWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'e636593e-f205-11e3-8fcf-8701ab3555a1', E'HoldingPageWorkflowAction', E'HoldingPageWorkflowAction', E'HoldingPageWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'e990cc26-f0b2-11e3-9f4d-97ad89640080', E'IDCheckWorkflowAction', E'IDCheckWorkflowAction', E'IDCheckWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'cab2a9f2-4407-11e4-b957-33a69f7fd805', E'PaymentSuccessfulReceiptWorkflowAction', E'PaymentSuccessfulReceiptWorkflowAction', E'PaymentSuccessfulReceiptWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'f8ea28f6-43d3-11e4-a494-f3a27bcabb33', E'PaymentWorkflowAction', E'PaymentWorkflowAction', E'PaymentWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'25f93590-fc61-11e3-b835-3f224587bd09', E'Minimum1branchapprovedWorkflowDecision', E'Minimum1branchapprovedWorkflowDecision', E'Minimum1branchapprovedWorkflowDecision', E'Bec.TargetFramework.Workflow.Components.Decisions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2f3ca796-f21a-11e3-8579-f39f7cb26c5f', E'IDCheckPassedWorkflowDecision', E'IDCheckPassedWorkflowDecision', E'IDCheckPassedWorkflowDecision', E'Bec.TargetFramework.Workflow.Components.Decisions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'42c21720-f147-11e3-ba53-af9f1a258a85', E'NextOrPreviousWorkflowDecision', E'NextOrPreviousWorkflowDecision', E'NextOrPreviousWorkflowDecision', E'Bec.TargetFramework.Workflow.Components.Decisions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'66d6e410-f147-11e3-b086-37f6d563fcea', E'GreaterThanWorkflowDecision', E'GreaterThanWorkflowDecision', E'GreaterThanWorkflowDecision', E'Bec.TargetFramework.Workflow.Components.Decisions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'87ab4b60-f14a-11e3-a6fe-1be08f39ad93', E'IsSRAValidWorkflowDecision', E'IsSRAValidWorkflowDecision', E'IsSRAValidWorkflowDecision', E'Bec.TargetFramework.Workflow.Components.Decisions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'bf890d1c-f148-11e3-8d2c-4befd97e8fd0', E'IsRegulatorSRAWorkflowDecision', E'IsRegulatorSRAWorkflowDecision', E'IsRegulatorSRAWorkflowDecision', E'Bec.TargetFramework.Workflow.Components.Decisions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'fdecffb0-f214-11e3-bfe7-3bfd5fffb3b7', E'IsPaymentSuccessfulWorkflowDecision', E'IsPaymentSuccessfulWorkflowDecision', E'IsPaymentSuccessfulWorkflowDecision', E'Bec.TargetFramework.Workflow.Components.Decisions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);


/* Data for the 'public.WorkflowActionTemplate' table  (Records 1 - 14) */
/* Data for the 'public.WorkflowActionTemplate' table  (Records 1 - 14) */

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1c64d8ce-4408-11e4-8dce-2385af94f78f', E'PaymentSuccessfulReceiptWorkflowAction', E'PaymentSuccessfulReceiptWorkflowAction', False, False, NULL, False, E'cab2a9f2-4407-11e4-b957-33a69f7fd805', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'32935fdc-43d4-11e4-99fc-cfa5bad13698', E'IndividualPaymentWorkflowAction', E'IndividualPaymentWorkflowAction', False, False, NULL, True, E'f8ea28f6-43d3-11e4-a494-f3a27bcabb33', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'69170a08-f0b5-11e3-9f6d-57591ddd3bb1', E'NextStepsCORegisterWorkflowAction', E'NextStepsCORegisterWorkflowAction', False, False, NULL, True, E'334373d9-5d98-4499-abca-6a3618a423a5', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'b17da6b2-f0b5-11e3-b285-a367349825cb', E'Terms&ConditionWorkflowAction', E'Terms&ConditionWorkflowAction', False, False, NULL, True, E'1311eec0-f0b0-11e3-b28a-3f1f84bc9ae8', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'b747d2a2-f0b5-11e3-96d7-9fac4029974a', E'PersonalDetailsWorkflowAction', E'PersonalDetailsWorkflowAction', False, False, NULL, True, E'4cf953b2-f0b0-11e3-b0a6-a38f80d3b77e', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'be5eef3a-f0b5-11e3-8afa-af684cc62a4e', E'FirmDetailsCOWorkflowAction', E'FirmDetailsCOWorkflowAction', False, False, NULL, True, E'8e69ebfe-f0b0-11e3-8797-033066726d5f', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'c1e7af1e-f13e-11e3-9902-c7a89f2c47e1', E'FirmProductWorkflowAction', E'FirmProductWorkflowAction', False, False, NULL, True, E'9a01bbe8-43cd-11e4-babd-239048b3d176', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'c470fe18-f0b5-11e3-a4e8-eb0180025b21', E'FirmPreferenceWorkflowAction', E'FirmPreferenceWorkflowAction', False, False, NULL, True, E'4f7dad70-43cd-11e4-a3cb-3bb69610f5f1', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'c9cacbf0-f0b5-11e3-99cb-2b2e23b2f3c9', E'IDCheckWorkflowAction', E'IDCheckWorkflowAction', False, False, NULL, False, E'e990cc26-f0b2-11e3-9f4d-97ad89640080', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'c9f764d8-f13e-11e3-861f-e37421f82857', E'IndividualPaymentWithoutPreAuthWorkflowAction', E'IndividualPaymentWithoutPreAuthWorkflowAction', False, False, NULL, True, E'01728ec6-f0b1-11e3-bf2f-6b20bced834d', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'cfe42f90-f0b5-11e3-8fd9-fb4d45a1eaec', E'BranchesnUsersWorkflowAction', E'BranchesnUsersWorkflowAction', False, False, NULL, True, E'12413ef8-f0b3-11e3-8ee0-7322c97b6460', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'd1859b70-f13e-11e3-b54c-9b68a05b795b', E'IndividualPaymentWithPreAuthWorkflowAction', E'IndividualPaymentWithPreAuthWorkflowAction', False, False, NULL, True, E'c74167a8-f0b1-11e3-9c44-d7313ee8e6b3', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'db7f5c6c-f0b5-11e3-af29-f719e2b59193', E'DashboardWorkflowAction', E'DashboardWorkflowAction', False, False, NULL, False, E'50708a62-f0b3-11e3-a09e-f309ff24ebfc', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'e56db02a-f204-11e3-aadc-3f322198f772', E'HoldingPageWorkflowAction', E'HoldingPageWorkflowAction', False, False, NULL, False, E'e636593e-f205-11e3-8fcf-8701ab3555a1', WorkflowTemplateID, WorkflowTemplateVersionNumber);

/* Data for the 'public.WorkflowDecisionTemplate' table  (Records 1 - 14) */

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'e13c7b0e-52cf-11e4-89a7-77f3703d1eaa', E'IndividualPaymentNextOrPreviousWorkflowDecision', E'IndividualPaymentNextOrPreviousWorkflowDecision', False, False, NULL, E'42c21720-f147-11e3-ba53-af9f1a258a85', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'030d5144-f205-11e3-8060-f3105469b0fa', E'FirmDetailsNextOrPreviousWorkflowDecision', E'FirmDetailsNextOrPreviousWorkflowDecision', False, False, NULL, E'42c21720-f147-11e3-ba53-af9f1a258a85', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'09c25a5c-f205-11e3-969f-039efa34ff88', E'FirmPreferenceNextOrPreviousWorkflowDecision', E'FirmPreferenceNextOrPreviousWorkflowDecision', False, False, NULL, E'42c21720-f147-11e3-ba53-af9f1a258a85', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'10adb578-f205-11e3-906e-c79ebf16f092', E'PersonalPaymentWithoutPreAuthNextOrPreviousWorkflowDecision', E'PersonalPaymentWithoutPreAuthNextOrPreviousWorkflowDecision', False, False, NULL, E'42c21720-f147-11e3-ba53-af9f1a258a85', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'191695e0-f205-11e3-a6f2-67a17c03ad17', E'BranchUserSetUpMinimum1approvedbranchexistWorkflowDecision', E'BranchUserSetUpMinimum1approvedbranchexistWorkflowDecision', False, False, NULL, E'25f93590-fc61-11e3-b835-3f224587bd09', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'216ed644-f205-11e3-8495-7bf0bb419700', E'NoOfIDCheckMoreThanZeroWorkflowDecision', E'NoOfIDCheckMoreThanZeroWorkflowDecision', False, False, NULL, E'66d6e410-f147-11e3-b086-37f6d563fcea', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'28e37ca4-f205-11e3-8861-9b2f53417f78', E'IsRegulatorSRAWorkflowDecision', E'IsRegulatorSRAWorkflowDecision', False, False, NULL, E'bf890d1c-f148-11e3-8d2c-4befd97e8fd0', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2f59db9f-1534-4f9f-840d-4fea3c2671ae', E'FirmProductNextOrPreviousWorkflowDecision', E'FirmProductNextOrPreviousWorkflowDecision', False, False, NULL, E'42c21720-f147-11e3-ba53-af9f1a258a85', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2fa18d2e-f205-11e3-89db-9b60bc56f0ac', E'IsSRAValidWorkflowDecision', E'IsSRAValidWorkflowDecision', False, False, NULL, E'87ab4b60-f14a-11e3-a6fe-1be08f39ad93', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'43f75870-f21a-11e3-b93c-03732b804039', E'IDCheckWorkflowDecision', E'IDCheckWorkflowDecision', False, False, NULL, E'2f3ca796-f21a-11e3-8579-f39f7cb26c5f', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'943231ba-fc43-11e3-a4d8-576f1e4b69cd', E'IsPersonalPaymentSuccessfulWorkflowDecision', E'IsPersonalPaymentSuccessfulWorkflowDecision', False, False, NULL, E'fdecffb0-f214-11e3-bfe7-3bfd5fffb3b7', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'cb33ab86-fc60-11e3-9b64-c79d87eabc01', E'IsPersonalPaymentwithoutPreauthSuccessfulWorkflowDecision', E'IsPersonalPaymentwithoutPreauthSuccessfulWorkflowDecision', False, False, NULL, E'fdecffb0-f214-11e3-bfe7-3bfd5fffb3b7', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'da1247ac-f215-11e3-a0f8-7fc5c98477c3', E'IsOrganisationlPaymentSuccessfulWorkflowDecision', E'IsOrganisationlPaymentSuccessfulWorkflowDecision', False, False, NULL, E'fdecffb0-f214-11e3-bfe7-3bfd5fffb3b7', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'f1c2740a-f204-11e3-835c-ab3c75d69e26', E'Terms&ConditionsNextOrPreviousWorkflowDecision', E'Terms&ConditionsNextOrPreviousWorkflowDecision', False, False, NULL, E'42c21720-f147-11e3-ba53-af9f1a258a85', WorkflowTemplateID, WorkflowTemplateVersionNumber);

/* Data for the 'public.WorkflowTransistionWorkflowActionTemplate' table  (Records 1 - 14) */

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1de66199-d62a-4eb2-8846-cd389d413798', E'1c64d8ce-4408-11e4-8dce-2385af94f78f', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1de66199-d62a-4eb2-8846-cd389d413798', E'32935fdc-43d4-11e4-99fc-cfa5bad13698', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1de66199-d62a-4eb2-8846-cd389d413798', E'69170a08-f0b5-11e3-9f6d-57591ddd3bb1', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1de66199-d62a-4eb2-8846-cd389d413798', E'b17da6b2-f0b5-11e3-b285-a367349825cb', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1de66199-d62a-4eb2-8846-cd389d413798', E'b747d2a2-f0b5-11e3-96d7-9fac4029974a', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1de66199-d62a-4eb2-8846-cd389d413798', E'be5eef3a-f0b5-11e3-8afa-af684cc62a4e', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1de66199-d62a-4eb2-8846-cd389d413798', E'c1e7af1e-f13e-11e3-9902-c7a89f2c47e1', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1de66199-d62a-4eb2-8846-cd389d413798', E'c470fe18-f0b5-11e3-a4e8-eb0180025b21', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1de66199-d62a-4eb2-8846-cd389d413798', E'c9cacbf0-f0b5-11e3-99cb-2b2e23b2f3c9', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1de66199-d62a-4eb2-8846-cd389d413798', E'c9f764d8-f13e-11e3-861f-e37421f82857', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1de66199-d62a-4eb2-8846-cd389d413798', E'cfe42f90-f0b5-11e3-8fd9-fb4d45a1eaec', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1de66199-d62a-4eb2-8846-cd389d413798', E'd1859b70-f13e-11e3-b54c-9b68a05b795b', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1de66199-d62a-4eb2-8846-cd389d413798', E'db7f5c6c-f0b5-11e3-af29-f719e2b59193', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1de66199-d62a-4eb2-8846-cd389d413798', E'e56db02a-f204-11e3-aadc-3f322198f772', WorkflowTemplateID, WorkflowTemplateVersionNumber);

/* Data for the 'public.WorkflowTransistionWorkflowDecisionTemplate' table  (Records 1 - 14) */

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1de66199-d62a-4eb2-8846-cd389d413798', E'e13c7b0e-52cf-11e4-89a7-77f3703d1eaa', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1de66199-d62a-4eb2-8846-cd389d413798', E'030d5144-f205-11e3-8060-f3105469b0fa', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1de66199-d62a-4eb2-8846-cd389d413798', E'09c25a5c-f205-11e3-969f-039efa34ff88', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1de66199-d62a-4eb2-8846-cd389d413798', E'10adb578-f205-11e3-906e-c79ebf16f092', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1de66199-d62a-4eb2-8846-cd389d413798', E'191695e0-f205-11e3-a6f2-67a17c03ad17', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1de66199-d62a-4eb2-8846-cd389d413798', E'216ed644-f205-11e3-8495-7bf0bb419700', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1de66199-d62a-4eb2-8846-cd389d413798', E'28e37ca4-f205-11e3-8861-9b2f53417f78', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1de66199-d62a-4eb2-8846-cd389d413798', E'2f59db9f-1534-4f9f-840d-4fea3c2671ae', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1de66199-d62a-4eb2-8846-cd389d413798', E'2fa18d2e-f205-11e3-89db-9b60bc56f0ac', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1de66199-d62a-4eb2-8846-cd389d413798', E'43f75870-f21a-11e3-b93c-03732b804039', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1de66199-d62a-4eb2-8846-cd389d413798', E'943231ba-fc43-11e3-a4d8-576f1e4b69cd', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1de66199-d62a-4eb2-8846-cd389d413798', E'cb33ab86-fc60-11e3-9b64-c79d87eabc01', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1de66199-d62a-4eb2-8846-cd389d413798', E'da1247ac-f215-11e3-a0f8-7fc5c98477c3', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1de66199-d62a-4eb2-8846-cd389d413798', E'f1c2740a-f204-11e3-835c-ab3c75d69e26', WorkflowTemplateID, WorkflowTemplateVersionNumber);

/* Data for the 'public.WorkflowDecisionSuccessTemplate' table  (Records 1 - 13) */

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID", "WorkflowDecisionSuccessTemplateID")
VALUES (E'e13c7b0e-52cf-11e4-89a7-77f3703d1eaa', NULL, WorkflowTemplateID, WorkflowTemplateVersionNumber, E'943231ba-fc43-11e3-a4d8-576f1e4b69cd', E'71fdeeb0-52d1-11e4-8b30-27f4b1a82154');

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID", "WorkflowDecisionSuccessTemplateID")
VALUES (E'030d5144-f205-11e3-8060-f3105469b0fa', E'c470fe18-f0b5-11e3-a4e8-eb0180025b21', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL, uuid_generate_v1());

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID", "WorkflowDecisionSuccessTemplateID")
VALUES (E'09c25a5c-f205-11e3-969f-039efa34ff88', E'c1e7af1e-f13e-11e3-9902-c7a89f2c47e1', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL, uuid_generate_v1());

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID", "WorkflowDecisionSuccessTemplateID")
VALUES (E'10adb578-f205-11e3-906e-c79ebf16f092', NULL, WorkflowTemplateID, WorkflowTemplateVersionNumber, E'cb33ab86-fc60-11e3-9b64-c79d87eabc01', uuid_generate_v1());

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID", "WorkflowDecisionSuccessTemplateID")
VALUES (E'191695e0-f205-11e3-a6f2-67a17c03ad17', E'db7f5c6c-f0b5-11e3-af29-f719e2b59193', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL, uuid_generate_v1());

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID", "WorkflowDecisionSuccessTemplateID")
VALUES (E'216ed644-f205-11e3-8495-7bf0bb419700', E'c1e7af1e-f13e-11e3-9902-c7a89f2c47e1', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL, uuid_generate_v1());

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID", "WorkflowDecisionSuccessTemplateID")
VALUES (E'28e37ca4-f205-11e3-8861-9b2f53417f78', NULL, WorkflowTemplateID, WorkflowTemplateVersionNumber, E'2fa18d2e-f205-11e3-89db-9b60bc56f0ac', uuid_generate_v1());

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID", "WorkflowDecisionSuccessTemplateID")
VALUES (E'2f59db9f-1534-4f9f-840d-4fea3c2671ae', E'32935fdc-43d4-11e4-99fc-cfa5bad13698', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL, uuid_generate_v1());

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID", "WorkflowDecisionSuccessTemplateID")
VALUES (E'2fa18d2e-f205-11e3-89db-9b60bc56f0ac', E'cfe42f90-f0b5-11e3-8fd9-fb4d45a1eaec', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL, uuid_generate_v1());

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID", "WorkflowDecisionSuccessTemplateID")
VALUES (E'43f75870-f21a-11e3-b93c-03732b804039', NULL, WorkflowTemplateID, WorkflowTemplateVersionNumber, E'28e37ca4-f205-11e3-8861-9b2f53417f78', uuid_generate_v1());

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID", "WorkflowDecisionSuccessTemplateID")
VALUES (E'943231ba-fc43-11e3-a4d8-576f1e4b69cd', E'1c64d8ce-4408-11e4-8dce-2385af94f78f', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL, uuid_generate_v1());

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID", "WorkflowDecisionSuccessTemplateID")
VALUES (E'cb33ab86-fc60-11e3-9b64-c79d87eabc01', E'c9cacbf0-f0b5-11e3-99cb-2b2e23b2f3c9', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL, uuid_generate_v1());

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID", "WorkflowDecisionSuccessTemplateID")
VALUES (E'da1247ac-f215-11e3-a0f8-7fc5c98477c3', E'd1859b70-f13e-11e3-b54c-9b68a05b795b', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL, uuid_generate_v1());

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID", "WorkflowDecisionSuccessTemplateID")
VALUES (E'f1c2740a-f204-11e3-835c-ab3c75d69e26', E'b747d2a2-f0b5-11e3-96d7-9fac4029974a', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL, uuid_generate_v1());



/* Data for the 'public.WorkflowDecisionFailureTemplate' table  (Records 1 - 14) */

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID", "WorkflowDecisionFailureTemplateID")
VALUES (E'e13c7b0e-52cf-11e4-89a7-77f3703d1eaa', E'c1e7af1e-f13e-11e3-9902-c7a89f2c47e1', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL, E'ecc1a83a-52d1-11e4-a8ad-eb1df74cc2d2');

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID", "WorkflowDecisionFailureTemplateID")
VALUES (E'030d5144-f205-11e3-8060-f3105469b0fa', E'b747d2a2-f0b5-11e3-96d7-9fac4029974a', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL, uuid_generate_v1());

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID", "WorkflowDecisionFailureTemplateID")
VALUES (E'f1c2740a-f204-11e3-835c-ab3c75d69e26', E'69170a08-f0b5-11e3-9f6d-57591ddd3bb1', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL, uuid_generate_v1());

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID", "WorkflowDecisionFailureTemplateID")
VALUES (E'09c25a5c-f205-11e3-969f-039efa34ff88', E'be5eef3a-f0b5-11e3-8afa-af684cc62a4e', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL, uuid_generate_v1());

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID", "WorkflowDecisionFailureTemplateID")
VALUES (E'216ed644-f205-11e3-8495-7bf0bb419700', E'c9f764d8-f13e-11e3-861f-e37421f82857', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL, uuid_generate_v1());

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID", "WorkflowDecisionFailureTemplateID")
VALUES (E'da1247ac-f215-11e3-a0f8-7fc5c98477c3', E'c1e7af1e-f13e-11e3-9902-c7a89f2c47e1', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL, uuid_generate_v1());

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID", "WorkflowDecisionFailureTemplateID")
VALUES (E'943231ba-fc43-11e3-a4d8-576f1e4b69cd', E'32935fdc-43d4-11e4-99fc-cfa5bad13698', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL, uuid_generate_v1());

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID", "WorkflowDecisionFailureTemplateID")
VALUES (E'28e37ca4-f205-11e3-8861-9b2f53417f78', E'e56db02a-f204-11e3-aadc-3f322198f772', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL, uuid_generate_v1());

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID", "WorkflowDecisionFailureTemplateID")
VALUES (E'43f75870-f21a-11e3-b93c-03732b804039', E'e56db02a-f204-11e3-aadc-3f322198f772', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL, uuid_generate_v1());

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID", "WorkflowDecisionFailureTemplateID")
VALUES (E'191695e0-f205-11e3-a6f2-67a17c03ad17', E'cfe42f90-f0b5-11e3-8fd9-fb4d45a1eaec', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL, uuid_generate_v1());

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID", "WorkflowDecisionFailureTemplateID")
VALUES (E'10adb578-f205-11e3-906e-c79ebf16f092', E'c470fe18-f0b5-11e3-a4e8-eb0180025b21', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL, uuid_generate_v1());

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID", "WorkflowDecisionFailureTemplateID")
VALUES (E'2fa18d2e-f205-11e3-89db-9b60bc56f0ac', E'e56db02a-f204-11e3-aadc-3f322198f772', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL, uuid_generate_v1());

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID", "WorkflowDecisionFailureTemplateID")
VALUES (E'cb33ab86-fc60-11e3-9b64-c79d87eabc01', E'c9f764d8-f13e-11e3-861f-e37421f82857', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL, uuid_generate_v1());

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID", "WorkflowDecisionFailureTemplateID")
VALUES (E'2f59db9f-1534-4f9f-840d-4fea3c2671ae', E'c470fe18-f0b5-11e3-a4e8-eb0180025b21', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL, uuid_generate_v1());


/* Data for the 'public.WorkflowHierarchyTemplate' table  (Records 1 - 31) */

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'09ca2af2-52d1-11e4-88f7-37ad2f16277b', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'c1e7af1e-f13e-11e3-9902-c7a89f2c47e1', E'e13c7b0e-52cf-11e4-89a7-77f3703d1eaa', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'1853651c-f231-11e3-8ef2-bf6357059e2b', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'be5eef3a-f0b5-11e3-8afa-af684cc62a4e', E'09c25a5c-f205-11e3-969f-039efa34ff88', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'2c1b2bde-f231-11e3-ae8e-83d21835a1ae', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'2f59db9f-1534-4f9f-840d-4fea3c2671ae', E'c1e7af1e-f13e-11e3-9902-c7a89f2c47e1', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'41e166c2-f231-11e3-9fec-67265300005d', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'e13c7b0e-52cf-11e4-89a7-77f3703d1eaa', E'32935fdc-43d4-11e4-99fc-cfa5bad13698', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'4bbfd07a-f231-11e3-8fbf-dbc92bf9ef54', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'1c64d8ce-4408-11e4-8dce-2385af94f78f', E'943231ba-fc43-11e3-a4d8-576f1e4b69cd', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'79785284-4408-11e4-99e4-7ff18e571208', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'c9cacbf0-f0b5-11e3-99cb-2b2e23b2f3c9', E'1c64d8ce-4408-11e4-8dce-2385af94f78f', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'862da860-f22f-11e3-8892-6711f7ce0837', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'b17da6b2-f0b5-11e3-b285-a367349825cb', E'69170a08-f0b5-11e3-9f6d-57591ddd3bb1', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'8c634c1c-f22f-11e3-ac8f-933fcf8c2e36', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'f1c2740a-f204-11e3-835c-ab3c75d69e26', E'b17da6b2-f0b5-11e3-b285-a367349825cb', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'8c9cca5a-f239-11e3-ae4d-fb1d33fd3736', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'32935fdc-43d4-11e4-99fc-cfa5bad13698', E'943231ba-fc43-11e3-a4d8-576f1e4b69cd', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'91f9d632-f22f-11e3-b989-f363b5978eda', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'b747d2a2-f0b5-11e3-96d7-9fac4029974a', E'f1c2740a-f204-11e3-835c-ab3c75d69e26', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'946b4b6c-f239-11e3-af96-375ba4c1dafe', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'43f75870-f21a-11e3-b93c-03732b804039', E'c9cacbf0-f0b5-11e3-99cb-2b2e23b2f3c9', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'987b4cd4-f22f-11e3-a9ff-43cfaccbf7b5', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'69170a08-f0b5-11e3-9f6d-57591ddd3bb1', E'f1c2740a-f204-11e3-835c-ab3c75d69e26', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'9a602f38-f239-11e3-93c5-3fb28165ced2', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'e56db02a-f204-11e3-aadc-3f322198f772', E'43f75870-f21a-11e3-b93c-03732b804039', NULL, True, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'9e826afe-f22f-11e3-bc52-b7b29e7bc14b', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'be5eef3a-f0b5-11e3-8afa-af684cc62a4e', E'b747d2a2-f0b5-11e3-96d7-9fac4029974a', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'a0b63e54-f239-11e3-8003-3b26c1a4dab1', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'28e37ca4-f205-11e3-8861-9b2f53417f78', E'43f75870-f21a-11e3-b93c-03732b804039', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'a4b99a00-f22f-11e3-a2c0-c3ed08b3ce9f', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'030d5144-f205-11e3-8060-f3105469b0fa', E'be5eef3a-f0b5-11e3-8afa-af684cc62a4e', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'a673eda0-f239-11e3-afaf-73761ae229a7', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'2fa18d2e-f205-11e3-89db-9b60bc56f0ac', E'28e37ca4-f205-11e3-8861-9b2f53417f78', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'ab0a67ae-f22f-11e3-93e6-bff0941b5bf5', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'c470fe18-f0b5-11e3-a4e8-eb0180025b21', E'030d5144-f205-11e3-8060-f3105469b0fa', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'ac8d4538-f239-11e3-a0b6-3be514ba640e', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'e56db02a-f204-11e3-aadc-3f322198f772', E'28e37ca4-f205-11e3-8861-9b2f53417f78', NULL, True, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'b111d3b2-f22f-11e3-b96f-7f63c76e3d8e', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'b747d2a2-f0b5-11e3-96d7-9fac4029974a', E'030d5144-f205-11e3-8060-f3105469b0fa', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'b2efd7ec-f239-11e3-a993-7ba881ebf61e', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'cfe42f90-f0b5-11e3-8fd9-fb4d45a1eaec', E'2fa18d2e-f205-11e3-89db-9b60bc56f0ac', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'b67c6b78-f22f-11e3-9888-0b5d0a81bb78', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'09c25a5c-f205-11e3-969f-039efa34ff88', E'c470fe18-f0b5-11e3-a4e8-eb0180025b21', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'b9509702-f239-11e3-b7a2-7fcc3d1c14de', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'e56db02a-f204-11e3-aadc-3f322198f772', E'2fa18d2e-f205-11e3-89db-9b60bc56f0ac', NULL, True, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'bd9e2b26-f22f-11e3-89ae-1f425f994295', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'c1e7af1e-f13e-11e3-9902-c7a89f2c47e1', E'09c25a5c-f205-11e3-969f-039efa34ff88', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'c61c0160-f239-11e3-aa7e-7b0a4686626e', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'191695e0-f205-11e3-a6f2-67a17c03ad17', E'cfe42f90-f0b5-11e3-8fd9-fb4d45a1eaec', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'cdec877a-f239-11e3-ad4a-b37dfaa42672', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'db7f5c6c-f0b5-11e3-af29-f719e2b59193', E'191695e0-f205-11e3-a6f2-67a17c03ad17', NULL, True, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'cee825f6-52d0-11e4-b62f-3f646344f243', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'943231ba-fc43-11e3-a4d8-576f1e4b69cd', E'e13c7b0e-52cf-11e4-89a7-77f3703d1eaa', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'd0f8dc00-24fb-4dab-a7ca-5689cc67001a', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'69170a08-f0b5-11e3-9f6d-57591ddd3bb1', NULL, True, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'd4c7032c-f239-11e3-b8cb-c3dc40e0f6a2', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'cfe42f90-f0b5-11e3-8fd9-fb4d45a1eaec', E'191695e0-f205-11e3-a6f2-67a17c03ad17', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'e296d732-f565-11e3-8e77-738ebe696cbd', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'32935fdc-43d4-11e4-99fc-cfa5bad13698', E'2f59db9f-1534-4f9f-840d-4fea3c2671ae', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'e963a39c-f565-11e3-ad83-8b88ee003946', E'1de66199-d62a-4eb2-8846-cd389d413798', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'c470fe18-f0b5-11e3-a4e8-eb0180025b21', E'2f59db9f-1534-4f9f-840d-4fea3c2671ae', NULL, NULL, False);



INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'28e65ff8-01ca-11e4-9eb3-c3909745bd1b', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'Safe Move Scheme Sign-Up', E'Safe Move Scheme Sign-Up', 1, E'0', E'1', E'0', NULL, NULL, NULL, 1);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'14f415a6-01cc-11e4-abec-af0dfc1914ab', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'Start', E'Start', 2, E'0', E'1', E'0',  E'28e65ff8-01ca-11e4-9eb3-c3909745bd1b', NULL, NULL, 1);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'c3d0ccba-2213-11e4-b8dd-77937b005e58', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'Finish', E'Finish', 2, E'0', E'1', E'0',  E'28e65ff8-01ca-11e4-9eb3-c3909745bd1b', NULL, NULL, 2);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'2f6a2a7e-01cc-11e4-9601-67913eb01af2', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'Stage One', E'Stage One', 3, E'0', E'1', E'0',  E'14f415a6-01cc-11e4-abec-af0dfc1914ab', NULL, NULL, 1);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'40963798-01cc-11e4-89fb-4794120f5810', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'Stage Two', E'Stage Two', 3, E'0', E'1', E'0',  E'14f415a6-01cc-11e4-abec-af0dfc1914ab', NULL, NULL, 2);


INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'4c0abaa6-3357-11e4-af2e-5b3afccbe429', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'Next Steps', E'Next Steps ', 4, E'0', E'1', E'0',  E'2f6a2a7e-01cc-11e4-9601-67913eb01af2', NULL, NULL, 1);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'c3d141e0-2213-11e4-9768-43d64f92f287', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'Terms & Conditions ', E'Terms & Conditions ', 4, E'0', E'1', E'0', E'2f6a2a7e-01cc-11e4-9601-67913eb01af2', NULL, NULL, 2);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'c3d168f0-2213-11e4-869f-93f1948b2adb', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'Personal Details', E'Personal Details', 4, E'0', E'1', E'0',  E'2f6a2a7e-01cc-11e4-9601-67913eb01af2', NULL, NULL, 3);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'c3d168f0-2213-11e4-882b-0bc2f0f0e29e', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'Firm Details', E'Firm Details', 4, E'0', E'1', E'0',  E'2f6a2a7e-01cc-11e4-9601-67913eb01af2', NULL, NULL, 4);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'c3d19000-2213-11e4-8f06-07e67f2ccc57', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'Firm Preferences', E'Firm Preferences', 4, E'0', E'1', E'0',  E'2f6a2a7e-01cc-11e4-9601-67913eb01af2', NULL, NULL, 5);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'c3d1b706-2213-11e4-a4bc-c342b232db60', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'Firm Products', E'Firm Products', 4, E'0', E'1', E'0',  E'2f6a2a7e-01cc-11e4-9601-67913eb01af2', NULL, NULL, 6);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'c3d1b706-2213-11e4-bff5-1b0f01f8b6b9', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'Personal Payment', E'Personal Payment', 4, E'0', E'1', E'0',  E'2f6a2a7e-01cc-11e4-9601-67913eb01af2', NULL, NULL, 7);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'c3d1de0c-2213-11e4-9c80-83f66bd7f7c1', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'Branches & Users', E'Branches & Users', 4, E'0', E'1', E'0',  E'40963798-01cc-11e4-89fb-4794120f5810', NULL, NULL, 1);
/*----------*/

/* Data for the 'public.WorkflowTreeStructureActionTemplate' table  (Records 1 - 12) */

INSERT INTO public."WorkflowTreeStructureActionTemplate" ("WorkflowTreeStructureActionTemplateID", "WorkflowTreeStructureTemplateID", "WorkflowActionTemplateID", "IsVisible", "IsActive", "IsDeleted", "ConditionString")
VALUES (E'4e1078ac-3ceb-11e4-a10d-6b82af9c3dcd', E'40963798-01cc-11e4-89fb-4794120f5810', E'e56db02a-f204-11e3-aadc-3f322198f772', True, True, False, NULL);

INSERT INTO public."WorkflowTreeStructureActionTemplate" ("WorkflowTreeStructureActionTemplateID", "WorkflowTreeStructureTemplateID", "WorkflowActionTemplateID", "IsVisible", "IsActive", "IsDeleted", "ConditionString")
VALUES (E'ed64fbba-3ce8-11e4-93c0-3fc92befc7df', E'4c0abaa6-3357-11e4-af2e-5b3afccbe429', E'69170a08-f0b5-11e3-9f6d-57591ddd3bb1', True, True, False, NULL);

INSERT INTO public."WorkflowTreeStructureActionTemplate" ("WorkflowTreeStructureActionTemplateID", "WorkflowTreeStructureTemplateID", "WorkflowActionTemplateID", "IsVisible", "IsActive", "IsDeleted", "ConditionString")
VALUES (E'6bbd2bde-3ceb-11e4-81f6-27e80f2f2bdc', E'c3d0ccba-2213-11e4-b8dd-77937b005e58', E'db7f5c6c-f0b5-11e3-af29-f719e2b59193', True, True, False, NULL);

INSERT INTO public."WorkflowTreeStructureActionTemplate" ("WorkflowTreeStructureActionTemplateID", "WorkflowTreeStructureTemplateID", "WorkflowActionTemplateID", "IsVisible", "IsActive", "IsDeleted", "ConditionString")
VALUES (E'fd096d1c-3ce8-11e4-bbb7-bf5736b6d9c8', E'c3d141e0-2213-11e4-9768-43d64f92f287', E'b17da6b2-f0b5-11e3-b285-a367349825cb', True, True, False, NULL);

INSERT INTO public."WorkflowTreeStructureActionTemplate" ("WorkflowTreeStructureActionTemplateID", "WorkflowTreeStructureTemplateID", "WorkflowActionTemplateID", "IsVisible", "IsActive", "IsDeleted", "ConditionString")
VALUES (E'0cd2f09c-3ce9-11e4-8066-0f68acc77960', E'c3d168f0-2213-11e4-869f-93f1948b2adb', E'b747d2a2-f0b5-11e3-96d7-9fac4029974a', True, True, False, NULL);

INSERT INTO public."WorkflowTreeStructureActionTemplate" ("WorkflowTreeStructureActionTemplateID", "WorkflowTreeStructureTemplateID", "WorkflowActionTemplateID", "IsVisible", "IsActive", "IsDeleted", "ConditionString")
VALUES (E'6de50294-3ce9-11e4-a5e9-0b0c648fefff', E'c3d168f0-2213-11e4-882b-0bc2f0f0e29e', E'be5eef3a-f0b5-11e3-8afa-af684cc62a4e', True, True, False, NULL);

INSERT INTO public."WorkflowTreeStructureActionTemplate" ("WorkflowTreeStructureActionTemplateID", "WorkflowTreeStructureTemplateID", "WorkflowActionTemplateID", "IsVisible", "IsActive", "IsDeleted", "ConditionString")
VALUES (E'865195cc-3ce9-11e4-8e31-afc47955aaa5', E'c3d19000-2213-11e4-8f06-07e67f2ccc57', E'c470fe18-f0b5-11e3-a4e8-eb0180025b21', True, True, False, NULL);

INSERT INTO public."WorkflowTreeStructureActionTemplate" ("WorkflowTreeStructureActionTemplateID", "WorkflowTreeStructureTemplateID", "WorkflowActionTemplateID", "IsVisible", "IsActive", "IsDeleted", "ConditionString")
VALUES (E'ac62ac10-3ce9-11e4-a3f6-cfc07a3b9c03', E'c3d1b706-2213-11e4-a4bc-c342b232db60', E'c1e7af1e-f13e-11e3-9902-c7a89f2c47e1', True, True, False, NULL);

INSERT INTO public."WorkflowTreeStructureActionTemplate" ("WorkflowTreeStructureActionTemplateID", "WorkflowTreeStructureTemplateID", "WorkflowActionTemplateID", "IsVisible", "IsActive", "IsDeleted", "ConditionString")
VALUES (E'06cbc154-3ceb-11e4-a4c8-77c3078d96a4', E'c3d1b706-2213-11e4-bff5-1b0f01f8b6b9', E'32935fdc-43d4-11e4-99fc-cfa5bad13698', True, True, False, E'IsPaymentSuccessful:False');

INSERT INTO public."WorkflowTreeStructureActionTemplate" ("WorkflowTreeStructureActionTemplateID", "WorkflowTreeStructureTemplateID", "WorkflowActionTemplateID", "IsVisible", "IsActive", "IsDeleted", "ConditionString")
VALUES (E'273e8610-3ceb-11e4-b8c7-d3a1e939dcf9', E'c3d1b706-2213-11e4-bff5-1b0f01f8b6b9', E'1c64d8ce-4408-11e4-8dce-2385af94f78f', False, True, False, E'IsPaymentSuccessful:True');

INSERT INTO public."WorkflowTreeStructureActionTemplate" ("WorkflowTreeStructureActionTemplateID", "WorkflowTreeStructureTemplateID", "WorkflowActionTemplateID", "IsVisible", "IsActive", "IsDeleted", "ConditionString")
VALUES (E'3e5cc898-3ceb-11e4-a919-3369cff43fca', E'c3d1de0c-2213-11e4-9c80-83f66bd7f7c1', E'cfe42f90-f0b5-11e3-8fd9-fb4d45a1eaec', True, True, False, NULL);


/*-------------------*/
INSERT INTO public."WorkflowTransistionHierarchyTemplate" ("WorkflowTransistionHierarchyTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsWorkflowStart", "IsWorkflowEnd")
VALUES (E'893fd578-0774-11e4-87bd-4f8b7b7afb2d', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'1de66199-d62a-4eb2-8846-cd389d413798', NULL, True, True);

/*-----------*/
/* Data for the 'public.WorkflowParameterTemplate' table  (Records 1 - 23) */

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'5e4c0442-43c7-11e4-898e-1fca818259cc', E'Action', E'Action', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1, E'System.String', E'Index');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'8f22a44a-077c-11e4-b07b-ab3d14888cc8', E'Action', E'Action', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1, E'System.String', E'CONextSteps');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'97997892-13d9-11e4-b611-330f3c3f7997', E'Action', E'Action', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1, E'System.String', E'ConveyancerPersonalDetails');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'a0a0fc1c-13d9-11e4-a0dc-d7d7b94e88fd', E'Action', E'Action', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1, E'System.String', E'COFirmDetails');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'a4c8ae2a-13d9-11e4-b059-8728c5d30669', E'Action', E'Action', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1, E'System.String', E'PaymentSuccessful');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'afcf95a4-077c-11e4-8701-bbc9ae346f79', E'Action', E'Action', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1, E'System.String', E'TAndC');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'8881b8d2-1beb-11e4-ade2-1f87b47eec6e', E'Area', E'Area', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1, E'System.String', E'SafeTransactionSearch');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'0b6b3980-449b-11e4-b5eb-17cb6fdc7839', E'Controller', E'Controller', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1, E'System.String', E'Dashboard');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'125333f8-43c7-11e4-8045-eb1ec60bb44d', E'Controller', E'Controller', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1, E'System.String', E'TermsnConditions');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'2fe35f60-43c7-11e4-a4bf-a71c5b11dfb3', E'Controller', E'Controller', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1, E'System.String', E'Payment');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'4a2adf70-4493-11e4-991b-8f6b9ed21eb0', E'Controller', E'Controller', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1, E'System.String', E'PaymentSuccessful');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'69d547b0-077c-11e4-aa80-6b1221ead8dc', E'Controller', E'Controller', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1, E'System.String', E'SignUp');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'a6139164-448f-11e4-b8f2-afddc49bca2f', E'Controller', E'Controller', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1, E'System.String', E'FirmPreference');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'b41cb55c-43c6-11e4-8c7c-0773e0d5f3ea', E'Controller', E'Controller', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1, E'System.String', E'NextSteps');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'bf6733b6-449c-11e4-b8c2-039db80b6cfe', E'Controller', E'Controller', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1, E'System.String', E'HoldingPage');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'c91fc4a8-43c6-11e4-acd0-9b24fb8744ab', E'Controller', E'Controller', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1, E'System.String', E'PersonalDetails');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'df55bafc-43c6-11e4-8313-9b9904e3d102', E'Controller', E'Controller', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1, E'System.String', E'FirmDetail');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'e5da61d8-448f-11e4-954a-9f9517192c24', E'Controller', E'Controller', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1, E'System.String', E'FirmProduct');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'f674971c-43c6-11e4-b074-dbf5d7ef350c', E'Controller', E'Controller', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1, E'System.String', E'FirmBranchesUsers');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'f7f8785c-4497-11e4-9316-431cbe40a1b9', E'Controller', E'Controller', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1, E'System.String', E'IDCheck');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'fd6ab7a8-10dc-11e4-a47d-47a9378fcae3', E'WorkflowInstanceStatusID', E'Workflow instance status Complete', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1, E'System.String', E'Complete');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'05268256-10dd-11e4-8608-d7b775e3316f', E'WorkflowInstanceStatusID', E'Workflow instance status In progress', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1, E'System.String', E'InProgress');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'fce5a042-0e7d-11e4-bb1b-e3765d77196e', E'WorkflowInstanceStatusID', E'workflow instance status new', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1, E'System.String', E'New');

/* Data for the 'public.WorkflowActionParameterTemplate' table  (Records 1 - 36) */

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1c64d8ce-4408-11e4-8dce-2385af94f78f', E'2fe35f60-43c7-11e4-a4bf-a71c5b11dfb3', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1c64d8ce-4408-11e4-8dce-2385af94f78f', E'a4c8ae2a-13d9-11e4-b059-8728c5d30669', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1c64d8ce-4408-11e4-8dce-2385af94f78f', E'8881b8d2-1beb-11e4-ade2-1f87b47eec6e', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'32935fdc-43d4-11e4-99fc-cfa5bad13698', E'2fe35f60-43c7-11e4-a4bf-a71c5b11dfb3', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'32935fdc-43d4-11e4-99fc-cfa5bad13698', E'5e4c0442-43c7-11e4-898e-1fca818259cc', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'32935fdc-43d4-11e4-99fc-cfa5bad13698', E'8881b8d2-1beb-11e4-ade2-1f87b47eec6e', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'69170a08-f0b5-11e3-9f6d-57591ddd3bb1', E'5e4c0442-43c7-11e4-898e-1fca818259cc', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'69170a08-f0b5-11e3-9f6d-57591ddd3bb1', E'8881b8d2-1beb-11e4-ade2-1f87b47eec6e', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'69170a08-f0b5-11e3-9f6d-57591ddd3bb1', E'b41cb55c-43c6-11e4-8c7c-0773e0d5f3ea', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'b17da6b2-f0b5-11e3-b285-a367349825cb', E'125333f8-43c7-11e4-8045-eb1ec60bb44d', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'b17da6b2-f0b5-11e3-b285-a367349825cb', E'afcf95a4-077c-11e4-8701-bbc9ae346f79', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'b17da6b2-f0b5-11e3-b285-a367349825cb', E'8881b8d2-1beb-11e4-ade2-1f87b47eec6e', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'b747d2a2-f0b5-11e3-96d7-9fac4029974a', E'5e4c0442-43c7-11e4-898e-1fca818259cc', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'b747d2a2-f0b5-11e3-96d7-9fac4029974a', E'8881b8d2-1beb-11e4-ade2-1f87b47eec6e', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'b747d2a2-f0b5-11e3-96d7-9fac4029974a', E'c91fc4a8-43c6-11e4-acd0-9b24fb8744ab', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'be5eef3a-f0b5-11e3-8afa-af684cc62a4e', E'5e4c0442-43c7-11e4-898e-1fca818259cc', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'be5eef3a-f0b5-11e3-8afa-af684cc62a4e', E'8881b8d2-1beb-11e4-ade2-1f87b47eec6e', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'be5eef3a-f0b5-11e3-8afa-af684cc62a4e', E'df55bafc-43c6-11e4-8313-9b9904e3d102', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'c1e7af1e-f13e-11e3-9902-c7a89f2c47e1', E'5e4c0442-43c7-11e4-898e-1fca818259cc', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'c1e7af1e-f13e-11e3-9902-c7a89f2c47e1', E'8881b8d2-1beb-11e4-ade2-1f87b47eec6e', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'c1e7af1e-f13e-11e3-9902-c7a89f2c47e1', E'e5da61d8-448f-11e4-954a-9f9517192c24', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'c470fe18-f0b5-11e3-a4e8-eb0180025b21', E'5e4c0442-43c7-11e4-898e-1fca818259cc', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'c470fe18-f0b5-11e3-a4e8-eb0180025b21', E'8881b8d2-1beb-11e4-ade2-1f87b47eec6e', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'c470fe18-f0b5-11e3-a4e8-eb0180025b21', E'a6139164-448f-11e4-b8f2-afddc49bca2f', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'c9cacbf0-f0b5-11e3-99cb-2b2e23b2f3c9', E'5e4c0442-43c7-11e4-898e-1fca818259cc', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'c9cacbf0-f0b5-11e3-99cb-2b2e23b2f3c9', E'8881b8d2-1beb-11e4-ade2-1f87b47eec6e', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'c9cacbf0-f0b5-11e3-99cb-2b2e23b2f3c9', E'f7f8785c-4497-11e4-9316-431cbe40a1b9', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'cfe42f90-f0b5-11e3-8fd9-fb4d45a1eaec', E'5e4c0442-43c7-11e4-898e-1fca818259cc', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'cfe42f90-f0b5-11e3-8fd9-fb4d45a1eaec', E'8881b8d2-1beb-11e4-ade2-1f87b47eec6e', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'cfe42f90-f0b5-11e3-8fd9-fb4d45a1eaec', E'f674971c-43c6-11e4-b074-dbf5d7ef350c', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'db7f5c6c-f0b5-11e3-af29-f719e2b59193', E'0b6b3980-449b-11e4-b5eb-17cb6fdc7839', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'db7f5c6c-f0b5-11e3-af29-f719e2b59193', E'5e4c0442-43c7-11e4-898e-1fca818259cc', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'db7f5c6c-f0b5-11e3-af29-f719e2b59193', E'8881b8d2-1beb-11e4-ade2-1f87b47eec6e', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'e56db02a-f204-11e3-aadc-3f322198f772', E'5e4c0442-43c7-11e4-898e-1fca818259cc', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'e56db02a-f204-11e3-aadc-3f322198f772', E'8881b8d2-1beb-11e4-ade2-1f87b47eec6e', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'e56db02a-f204-11e3-aadc-3f322198f772', E'bf6733b6-449c-11e4-b8c2-039db80b6cfe', E'08796e7c-2ea9-408e-9b25-291d68e2beab', 1);


-- promote wf
perform "fn_PromoteWorkflowTemplate"(WorkflowTemplateID,WorkflowTemplateVersionNumber);
 
END $$;