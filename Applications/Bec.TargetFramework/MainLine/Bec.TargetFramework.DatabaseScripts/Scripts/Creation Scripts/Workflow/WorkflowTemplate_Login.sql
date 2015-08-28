DO $$
Declare ResourceTypeID integer;
Declare ResourceID UUID;
Declare WorkflowTemplateID UUID := E'fe7bd8d5-2f44-4614-9512-f6d4f32ebfc5';
Declare WorkflowTemplateVersionNumber  integer := 1;
Declare RoleID UUID;
Declare RoleName varchar(50);
Declare RoleDescription varchar(50);
Declare WorkflowClaimTemplateID UUID;

BEGIN
/* Data for the 'public.WorkflowTemplate' table  (Records 1 - 1) */

INSERT INTO public."WorkflowTemplate" ("WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "WorkflowTypeID", "WorkflowSubTypeID", "WorkflowCategoryID", "WorkflowSubCategoryID")
VALUES (WorkflowTemplateID, WorkflowTemplateVersionNumber, E'Login', E'Login', (select "ClassificationTypeID" from "ClassificationType" ct
where ct."ClassificationTypeCategoryID"  = 160 and ct."Name"= 'Startup' limit 1), NULL, NULL, NULL);

--Resource  with execute operation
If Not EXISTS(select * from "Resource" where "ResourceName" = 'LoginWorkflow' limit 1) Then
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
      'LoginWorkflow',
      'Login Workflow',
      ResourceTypeID
    );

    ResourceID := (select "ResourceID" from "Resource" where "ResourceName" = 'LoginWorkflow' limit 1);

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

/* Data for the 'public.WorkflowObjectTypeTemplate' table  (Records 1 - 13) */
INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'b4142758-1189-11e4-9b21-d74056d0c6b7', E'CreateTemporaryAccountWorkflowAction', E'CreateTemporaryAccountWorkflowAction', E'CreateTemporaryAccountWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'05a8ea02-0b14-4307-a92e-3e5ba19a883c', E'ThankYouSummaryWorkflowAction', E'ThankYouSummaryWorkflowAction', E'ThankYouSummaryWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions\r\n', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1e559dec-b384-48f9-9471-093f5ee3650b', E'NextOrPreviousWorkflowDecision', E'NextOrPreviousWorkflowDecision', E'NextOrPreviousWorkflowDecision', E'Bec.TargetFramework.Workflow.Components.Decisions\r\n', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'265048de-92ab-4bdd-9341-fb3ae7fd37ac', E'UserExistsInSystemWorkflowDecision', E'UserExistsInSystemWorkflowDecision', E'UserExistsInSystemWorkflowDecision', E'Bec.TargetFramework.Workflow.Components.Decisions\r\n', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'42acb4f7-b1ba-498e-b5ff-094621218681', E'IsReassignTransactionWorkflowDecision\r\n', E'IsReassignTransactionWorkflowDecision\r\n', E'IsReassignTransactionWorkflowDecision\r\n', E'Bec.TargetFramework.Workflow.Components.Decisions\r\n', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'4ed8a7ac-2d0b-41e1-831c-285c0e514b20', E'ReassignTransactionWorkflowAction', E'ReassignTransactionWorkflowAction', E'ReassignTransactionWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions\r\n', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'512ea7c1-0abd-4f7b-beef-37bd9c584eea', E'IsUserAccountValidWorkflowDecision', E'IsUserAccountValidWorkflowDecision', E'IsUserAccountValidWorkflowDecision', E'Bec.TargetFramework.Workflow.Components.Decisions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'5b2101ce-258e-45b0-a9b1-7deb226d3860', E'IsRegistrationWorkflowDecision', E'IsRegistrationWorkflowDecision', E'IsRegistrationWorkflowDecision', E'Bec.TargetFramework.Workflow.Components.Decisions\r\n', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'7ca3aa3d-5388-466c-9004-b50ba0ed4d37', E'RejectTransactionWorkflowAction', E'RejectTransactionWorkflowAction', E'RejectTransactionWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions\r\n', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'a2879a9b-76c0-4890-9d99-68d297be5e4b', E'SearchInviteSummaryWorkflowAction', E'SearchInviteSummaryWorkflowAction', E'SearchInviteSummaryWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions\r\n', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'af245b19-bf66-4108-ace2-b535fb5c4673', E'CreatePermanentLoginWorkflowAction', E'CreatePermanentLoginWorkflowAction', E'CreatePermanentLoginWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions\r\n', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'db1c6767-728f-43e4-aeaa-1bdf4ea3a055', E'IsConfirmTransactionWorkflowDecision\r\n', E'IsConfirmTransactionWorkflowDecision\r\n', E'IsConfirmTransactionWorkflowDecision\r\n', E'Bec.TargetFramework.Workflow.Components.Decisions\r\n', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'f524bc8a-82a5-4616-a5d6-3529e484d760', E'LoginWithTempAccountWorkflowAction', E'LoginWithTempAccountWorkflowAction', E'LoginWithTempAccountWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions\r\n', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'fcfe14e1-0df0-418b-aa8c-28f4c111485e', E'IsSearchInviteWorkflowDecision', E'IsSearchInviteWorkflowDecision', E'IsSearchInviteWorkflowDecision', E'Bec.TargetFramework.Workflow.Components.Decisions\r\n', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);



--WorkflowStatusTypeTemplate

--WorkflowNotificationConstructTemplate

/* Data for the 'public.WorkflowParameterTemplate' table  (Records 1 - 4) */

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'2d0cf298-0811-11e4-9640-273234c3033c', E'Area', E'Area', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'System.String', E'Workflow');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'54af6d4e-0811-11e4-8d6f-6b63c5a4f8aa', E'Controller', E'Controller', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'System.String', E'Login');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'e8dc2ca2-3811-11e4-b759-8ba96c459a3b', E'Controller', E'Controller', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'System.String', E'CreateLogin');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'63f83d30-0811-11e4-ab44-cbb92792291f', E'Action', E'Action', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'System.String', E'Login');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'9880ee30-0811-11e4-9bb1-5bf61b045e6c', E'Action', E'Action', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'System.String', E'Index');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'30eae7cc-118e-11e4-b298-e74b1c7d6426', E'Action', E'Action', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'System.String', E'CreateTemporaryAccount');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'5ab1b41a-0e7c-11e4-88b0-83a36efa7f50', E'WorkflowInstanceStatusID', E'Workflow instance status new', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'System.String', E'New');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'caa97522-10da-11e4-b047-3bf1a02e1002', E'WorkflowInstanceStatusID', E'Workflow instance status Complete', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'System.String', E'Complete');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'3145e196-10c5-11e4-96b3-4ff009980db8', E'WorkflowInstanceStatusID', E'Workflow instance status In progress', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'System.String', E'InProgress');


/* Data for the 'public.WorkflowTransistionTemplate' table  (Records 1 - 1) */

INSERT INTO public."WorkflowTransistionTemplate" ("WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "IsWorkflowStart", "IsWorkflowEnd")
VALUES (E'2523f0de-fb36-4bde-afe2-f91db354a8a6', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'LoginWorkflow', E'LoginWorkflow', False, False);



/* Data for the 'public.WorkflowActionTemplate' table  (Records 1 - 6) */

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'5037d756-118a-11e4-9724-8712446bd344', E'CreateTemporaryAccountWorkflowAction', E'CreateTemporaryAccountWorkflowAction', False, False, NULL, False, E'b4142758-1189-11e4-9b21-d74056d0c6b7', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'20f260b5-75c1-4cf2-8aff-698d9cc1db46', E'ReassignTransactionWorkflowAction\r\n', E'ReassignTransactionWorkflowAction\r\n', False, False, NULL, False, E'4ed8a7ac-2d0b-41e1-831c-285c0e514b20', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2f8480d7-922a-4179-b653-def21aabb2a3', E'ThankYouSummaryWorkflowAction', E'ThankYouSummaryWorkflowAction', False, False, NULL, False, E'05a8ea02-0b14-4307-a92e-3e5ba19a883c', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'3bcecb07-2c95-42c9-a81d-b0f4612cae48', E'RejectTransactionWorkflowAction\r\n', E'RejectTransactionWorkflowAction\r\n', False, False, NULL, False, E'7ca3aa3d-5388-466c-9004-b50ba0ed4d37', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'4b4f12d3-0777-4bd9-b8a4-ef3b792192e1', E'CreatePermanentLoginWorkflowAction\r\n', E'CreatePermanentLoginWorkflowAction\r\n', False, False, NULL, False, E'af245b19-bf66-4108-ace2-b535fb5c4673', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'8ffb7e6f-a8ed-49ce-aa28-101a3f8c2336', E'SearchInviteSummaryWorkflowAction\r\n', E'SearchInviteSummaryWorkflowAction\r\n', False, False, NULL, False, E'a2879a9b-76c0-4890-9d99-68d297be5e4b', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'f1b344b4-6933-4bab-96b1-8bc2d90a6f71', E'LoginWithTempAccountWorkflowAction\r\n', E'LoginWithTempAccountWorkflowAction\r\n', False, False, NULL, False, E'f524bc8a-82a5-4616-a5d6-3529e484d760', WorkflowTemplateID, WorkflowTemplateVersionNumber);



/* Data for the 'public.WorkflowDecisionTemplate' table  (Records 1 - 8) */

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'0dc952b4-a567-4362-8676-938e57631543', E'IsReassignTransactionWorkflowDecision\r\n', E'IsReassignTransactionWorkflowDecision\r\n', False, False, NULL, E'42acb4f7-b1ba-498e-b5ff-094621218681', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'15c86c83-6a92-47a5-99b4-0472ee336c87', E'IsConfirmOrRejectOrReassignWorkflowDecision\r\n', E'IsConfirmOrRejectOrReassignWorkflowDecision\r\n', False, False, NULL, E'db1c6767-728f-43e4-aeaa-1bdf4ea3a055', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1978f2a5-3e75-4063-91f4-ff6ce93ed102', E'IsSearchInviteWorkflowDecision\r\n', E'IsSearchInviteWorkflowDecision\r\n', False, False, NULL, E'fcfe14e1-0df0-418b-aa8c-28f4c111485e', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'21dd39d8-00cb-4f76-898a-4cc5928bbe97', E'UserExistsInSystemWorkflowDecision', E'UserExistsInSystemWorkflowDecision', False, False, NULL, E'265048de-92ab-4bdd-9341-fb3ae7fd37ac', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'626f3463-360f-4baf-9b93-f18160e2aae5', E'IsRegistrationWorkflowDecision\r\n', E'IsRegistrationWorkflowDecision\r\n', False, False, NULL, E'5b2101ce-258e-45b0-a9b1-7deb226d3860', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'72633d10-a500-48ef-be6a-6b1fa2080ec8', E'RejectTransactionNextOrPreviousWorkflowDecision', E'RejectTransactionNextOrPreviousWorkflowDecision', False, False, NULL, E'1e559dec-b384-48f9-9471-093f5ee3650b', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'824290f7-4c97-40cb-8ec4-5a4461e53ad2', E'IsUserAccountValidWorkflowDecision\r\n', E'IsUserAccountValidWorkflowDecision\r\n', False, False, NULL, E'512ea7c1-0abd-4f7b-beef-37bd9c584eea', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'95243157-cd38-4313-93dc-ff44634fc1dc', E'ReassignTransactionNextOrPreviousWorkflowDecision', E'ReassignTransactionNextOrPreviousWorkflowDecision', False, False, NULL, E'1e559dec-b384-48f9-9471-093f5ee3650b', WorkflowTemplateID, WorkflowTemplateVersionNumber);




--WorkflowConditionTemplate

--WorkflowCommandTemplate

--WorkflowCommandParameterTemplate

/* Data for the 'public.WorkflowActionParameterTemplate' table  (Records 1 - 6) */

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'f1b344b4-6933-4bab-96b1-8bc2d90a6f71', E'2d0cf298-0811-11e4-9640-273234c3033c', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'f1b344b4-6933-4bab-96b1-8bc2d90a6f71', E'54af6d4e-0811-11e4-8d6f-6b63c5a4f8aa', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'f1b344b4-6933-4bab-96b1-8bc2d90a6f71', E'63f83d30-0811-11e4-ab44-cbb92792291f', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'4b4f12d3-0777-4bd9-b8a4-ef3b792192e1', E'2d0cf298-0811-11e4-9640-273234c3033c', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'4b4f12d3-0777-4bd9-b8a4-ef3b792192e1', E'e8dc2ca2-3811-11e4-b759-8ba96c459a3b', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'4b4f12d3-0777-4bd9-b8a4-ef3b792192e1', E'9880ee30-0811-11e4-9bb1-5bf61b045e6c', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'5037d756-118a-11e4-9724-8712446bd344', E'2d0cf298-0811-11e4-9640-273234c3033c', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'5037d756-118a-11e4-9724-8712446bd344', E'30eae7cc-118e-11e4-b298-e74b1c7d6426', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'5037d756-118a-11e4-9724-8712446bd344', E'54af6d4e-0811-11e4-8d6f-6b63c5a4f8aa', WorkflowTemplateID, WorkflowTemplateVersionNumber);

--WorkflowConditionParameterTemplate

--WorkflowDecisionParameterTemplate

--WorkflowTransistionParameterTemplate

--WorkflowActionCompleteConditionTemplate

--WorkflowActionStartConditionTemplate

--WorkflowCommandConditionTemplate

--WorkflowMainCompleteConditionTemplate

--WorkflowMainStartConditionTemplate

--WorkflowTransistionCompleteConditionTemplate

--WorkflowTransistionStartConditionTemplate

--WorkflowActionExecuteCommandTemplate

--WorkflowActionPostCommandTemplate

--WorkflowActionPreCommandTemplate

--WorkflowDecisionExecuteCommandTemplate

--WorkflowMainExecuteCommandTemplate

--WorkflowMainPostCommandTemplate

--WorkflowMainPreCommandTemplate

--WorkflowDecisionErrorTemplate




/* Data for the 'public.WorkflowDecisionFailureTemplate' table  (Records 1 - 7) */

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'824290f7-4c97-40cb-8ec4-5a4461e53ad2', E'f1b344b4-6933-4bab-96b1-8bc2d90a6f71', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'1978f2a5-3e75-4063-91f4-ff6ce93ed102', E'4b4f12d3-0777-4bd9-b8a4-ef3b792192e1', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'626f3463-360f-4baf-9b93-f18160e2aae5', NULL, WorkflowTemplateID, WorkflowTemplateVersionNumber, E'1978f2a5-3e75-4063-91f4-ff6ce93ed102');

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'15c86c83-6a92-47a5-99b4-0472ee336c87', NULL, WorkflowTemplateID, WorkflowTemplateVersionNumber, E'0dc952b4-a567-4362-8676-938e57631543');

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'0dc952b4-a567-4362-8676-938e57631543', E'3bcecb07-2c95-42c9-a81d-b0f4612cae48', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'72633d10-a500-48ef-be6a-6b1fa2080ec8', E'8ffb7e6f-a8ed-49ce-aa28-101a3f8c2336', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'95243157-cd38-4313-93dc-ff44634fc1dc', E'8ffb7e6f-a8ed-49ce-aa28-101a3f8c2336', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);




/* Data for the 'public.WorkflowDecisionSuccessTemplate' table  (Records 1 - 7) */

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'824290f7-4c97-40cb-8ec4-5a4461e53ad2', NULL, WorkflowTemplateID, WorkflowTemplateVersionNumber, E'626f3463-360f-4baf-9b93-f18160e2aae5');

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'1978f2a5-3e75-4063-91f4-ff6ce93ed102', E'8ffb7e6f-a8ed-49ce-aa28-101a3f8c2336', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'626f3463-360f-4baf-9b93-f18160e2aae5', E'4b4f12d3-0777-4bd9-b8a4-ef3b792192e1', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'15c86c83-6a92-47a5-99b4-0472ee336c87', E'4b4f12d3-0777-4bd9-b8a4-ef3b792192e1', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'72633d10-a500-48ef-be6a-6b1fa2080ec8', E'2f8480d7-922a-4179-b653-def21aabb2a3', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'0dc952b4-a567-4362-8676-938e57631543', E'20f260b5-75c1-4cf2-8aff-698d9cc1db46', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'95243157-cd38-4313-93dc-ff44634fc1dc', NULL, WorkflowTemplateID, WorkflowTemplateVersionNumber, E'21dd39d8-00cb-4f76-898a-4cc5928bbe97');



/* Data for the 'public.WorkflowTransistionWorkflowActionTemplate' table  (Records 1 - 6) */

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2523f0de-fb36-4bde-afe2-f91db354a8a6', E'20f260b5-75c1-4cf2-8aff-698d9cc1db46', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2523f0de-fb36-4bde-afe2-f91db354a8a6', E'2f8480d7-922a-4179-b653-def21aabb2a3', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2523f0de-fb36-4bde-afe2-f91db354a8a6', E'3bcecb07-2c95-42c9-a81d-b0f4612cae48', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2523f0de-fb36-4bde-afe2-f91db354a8a6', E'4b4f12d3-0777-4bd9-b8a4-ef3b792192e1', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2523f0de-fb36-4bde-afe2-f91db354a8a6', E'8ffb7e6f-a8ed-49ce-aa28-101a3f8c2336', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2523f0de-fb36-4bde-afe2-f91db354a8a6', E'f1b344b4-6933-4bab-96b1-8bc2d90a6f71', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2523f0de-fb36-4bde-afe2-f91db354a8a6', E'5037d756-118a-11e4-9724-8712446bd344', WorkflowTemplateID, WorkflowTemplateVersionNumber);



/* Data for the 'public.WorkflowTransistionWorkflowDecisionTemplate' table  (Records 1 - 8) */

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2523f0de-fb36-4bde-afe2-f91db354a8a6', E'0dc952b4-a567-4362-8676-938e57631543', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2523f0de-fb36-4bde-afe2-f91db354a8a6', E'15c86c83-6a92-47a5-99b4-0472ee336c87', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2523f0de-fb36-4bde-afe2-f91db354a8a6', E'1978f2a5-3e75-4063-91f4-ff6ce93ed102', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2523f0de-fb36-4bde-afe2-f91db354a8a6', E'21dd39d8-00cb-4f76-898a-4cc5928bbe97', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2523f0de-fb36-4bde-afe2-f91db354a8a6', E'626f3463-360f-4baf-9b93-f18160e2aae5', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2523f0de-fb36-4bde-afe2-f91db354a8a6', E'72633d10-a500-48ef-be6a-6b1fa2080ec8', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2523f0de-fb36-4bde-afe2-f91db354a8a6', E'824290f7-4c97-40cb-8ec4-5a4461e53ad2', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2523f0de-fb36-4bde-afe2-f91db354a8a6', E'95243157-cd38-4313-93dc-ff44634fc1dc', WorkflowTemplateID, WorkflowTemplateVersionNumber);



/* Data for the 'public.WorkflowTransistionHierarchyTemplate' table  (Records 1 - 1) */

INSERT INTO public."WorkflowTransistionHierarchyTemplate" ("WorkflowTransistionHierarchyTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsWorkflowStart", "IsWorkflowEnd")
VALUES (E'9f2e0d62-068b-11e4-ace4-ff31ff04bf30', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'2523f0de-fb36-4bde-afe2-f91db354a8a6', NULL, True, False);




/* Data for the 'public.WorkflowHierarchyTemplate' table  (Records 1 - 19) */

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'65b3c048-1191-11e4-bab9-0f07802efb42', E'2523f0de-fb36-4bde-afe2-f91db354a8a6', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'5037d756-118a-11e4-9724-8712446bd344', NULL, True, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'0b819f1a-f6b8-4285-979a-1832ff65e107', E'2523f0de-fb36-4bde-afe2-f91db354a8a6', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'72633d10-a500-48ef-be6a-6b1fa2080ec8', E'3bcecb07-2c95-42c9-a81d-b0f4612cae48', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'0d33baf2-a61d-4127-a85e-8067e5b77daa', E'2523f0de-fb36-4bde-afe2-f91db354a8a6', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'f1b344b4-6933-4bab-96b1-8bc2d90a6f71', E'824290f7-4c97-40cb-8ec4-5a4461e53ad2', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'2734eac0-dd63-49ed-8228-cf372cbf05f0', E'2523f0de-fb36-4bde-afe2-f91db354a8a6', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'15c86c83-6a92-47a5-99b4-0472ee336c87', E'8ffb7e6f-a8ed-49ce-aa28-101a3f8c2336', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'3a2ef3b9-a0e4-4c36-8765-ed47bca1625b', E'2523f0de-fb36-4bde-afe2-f91db354a8a6', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'20f260b5-75c1-4cf2-8aff-698d9cc1db46', E'0dc952b4-a567-4362-8676-938e57631543', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'55e5199d-b38f-40ee-a58c-edac953332d2', E'2523f0de-fb36-4bde-afe2-f91db354a8a6', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'95243157-cd38-4313-93dc-ff44634fc1dc', E'20f260b5-75c1-4cf2-8aff-698d9cc1db46', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'5a1445f3-198d-4922-bf83-46cec29b28ae', E'2523f0de-fb36-4bde-afe2-f91db354a8a6', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'3bcecb07-2c95-42c9-a81d-b0f4612cae48', E'0dc952b4-a567-4362-8676-938e57631543', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'5e04b0bd-d136-4193-9a2f-9d88202ffbf0', E'2523f0de-fb36-4bde-afe2-f91db354a8a6', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'4b4f12d3-0777-4bd9-b8a4-ef3b792192e1', E'1978f2a5-3e75-4063-91f4-ff6ce93ed102', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'6d01f410-c7fc-497f-9c82-043698a6ffa3', E'2523f0de-fb36-4bde-afe2-f91db354a8a6', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'8ffb7e6f-a8ed-49ce-aa28-101a3f8c2336', E'72633d10-a500-48ef-be6a-6b1fa2080ec8', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'72168bed-127e-41f9-888e-e995d77c8d80', E'2523f0de-fb36-4bde-afe2-f91db354a8a6', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'2f8480d7-922a-4179-b653-def21aabb2a3', E'72633d10-a500-48ef-be6a-6b1fa2080ec8', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'786fa650-0685-11e4-839f-df7a4459f8c3', E'2523f0de-fb36-4bde-afe2-f91db354a8a6', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'f1b344b4-6933-4bab-96b1-8bc2d90a6f71', '5037d756-118a-11e4-9724-8712446bd344', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'8c3f19ee-35b1-4472-b0a8-ed4171a4aa63', E'2523f0de-fb36-4bde-afe2-f91db354a8a6', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'4b4f12d3-0777-4bd9-b8a4-ef3b792192e1', E'15c86c83-6a92-47a5-99b4-0472ee336c87', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'99fcae1d-f91a-4540-a97f-eb9802ab02c2', E'2523f0de-fb36-4bde-afe2-f91db354a8a6', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'0dc952b4-a567-4362-8676-938e57631543', E'15c86c83-6a92-47a5-99b4-0472ee336c87', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'9d3222cd-fa11-44c0-8074-b096135678ce', E'2523f0de-fb36-4bde-afe2-f91db354a8a6', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'1978f2a5-3e75-4063-91f4-ff6ce93ed102', E'626f3463-360f-4baf-9b93-f18160e2aae5', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'a71c84a8-ec3d-4a44-8de3-b68dd48e1d2e', E'2523f0de-fb36-4bde-afe2-f91db354a8a6', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'4b4f12d3-0777-4bd9-b8a4-ef3b792192e1', E'626f3463-360f-4baf-9b93-f18160e2aae5', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'c83fcb5f-7d7b-498d-af58-ae75bdfcd64f', E'2523f0de-fb36-4bde-afe2-f91db354a8a6', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'8ffb7e6f-a8ed-49ce-aa28-101a3f8c2336', E'1978f2a5-3e75-4063-91f4-ff6ce93ed102', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'cd17f8a0-f769-4081-a272-4020bc792d11', E'2523f0de-fb36-4bde-afe2-f91db354a8a6', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'824290f7-4c97-40cb-8ec4-5a4461e53ad2', E'f1b344b4-6933-4bab-96b1-8bc2d90a6f71', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'd7095a87-3bd4-462a-bcb5-d25e24c39a40', E'2523f0de-fb36-4bde-afe2-f91db354a8a6', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'8ffb7e6f-a8ed-49ce-aa28-101a3f8c2336', E'95243157-cd38-4313-93dc-ff44634fc1dc', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'e87bb3ac-7798-4b53-a792-94e6f66b97a4', E'2523f0de-fb36-4bde-afe2-f91db354a8a6', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'626f3463-360f-4baf-9b93-f18160e2aae5', E'824290f7-4c97-40cb-8ec4-5a4461e53ad2', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'f55fff48-2bd5-476d-a8c3-ce642cbde553', E'2523f0de-fb36-4bde-afe2-f91db354a8a6', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'21dd39d8-00cb-4f76-898a-4cc5928bbe97', E'95243157-cd38-4313-93dc-ff44634fc1dc', False, NULL, False);

-- promote wf
perform "fn_PromoteWorkflowTemplate"(WorkflowTemplateID,WorkflowTemplateVersionNumber);
END $$;