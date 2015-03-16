
DO $$
Declare ResourceTypeID integer;
Declare ResourceID UUID;
Declare WorkflowTemplateID UUID := E'd5aa520a-05ba-4dbe-9053-b84734ea37ed';
Declare WorkflowTemplateVersionNumber  integer := 1;
Declare RoleID UUID;
Declare RoleName varchar(50);
Declare RoleDescription varchar(50);
Declare WorkflowClaimTemplateID UUID;

BEGIN
/* Data for the 'public.WorkflowTemplate' table  (Records 1 - 1) */

INSERT INTO public."WorkflowTemplate" ("WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "WorkflowTypeID", "WorkflowSubTypeID", "WorkflowCategoryID", "WorkflowSubCategoryID")
VALUES (WorkflowTemplateID, WorkflowTemplateVersionNumber, E'OrganisationAdminInvitesUser', E'OrganisationAdmin invites user in the firm', (select "ClassificationTypeID" from "ClassificationType" ct
where ct."ClassificationTypeCategoryID"  = 160 and ct."Name"= 'Startup' limit 1), NULL, NULL, NULL);

--Resource  with execute operation
If Not EXISTS(select * from "Resource" where "ResourceName" = 'STSInternalInviteWorkflow' limit 1) Then
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
      'STSInternalInviteWorkflow',
      'STS Internal Invite Workflow',
      ResourceTypeID
    );

    ResourceID := (select "ResourceID" from "Resource" where "ResourceName" = 'STSInternalInviteWorkflow' limit 1);

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




/* Data for the 'public.WorkflowObjectTypeTemplate' table  (Records 1 - 14) */

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'09f076b1-14cf-410a-804f-b0d788820cb0', E'TermsConditionsUserWorkflowAction', E'Terms and Conditions for a user', E'TermsConditionsUserWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'4e99367c-8947-4c56-ae10-d4b53034a3c3', E'IDCheckPassedWorkflowDecision', E'IDCheckPassedWorkflowDecision', E'IDCheckPassedWorkflowDecision', E'Bec.TargetFramework.Workflow.Components.Decisions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'58151c93-6bdc-4914-b370-75ac06acb568', E'PaymentWithoutPreAuthWorkflowAction', E'PaymentWithoutPreAuthWorkflowAction', E'PaymentWithoutPreAuthWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'5e25702f-7622-4382-9a74-9fd248f3c7bd', E'PersonalDetailsWorkflowAction', E'PersonalDetailsWorkflowAction', E'PersonalDetailsWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'6103d80c-15e2-4736-bc30-c6d755bfa1db', E'NextOrPreviousWorkflowDecision', E'NextOrPreviousWorkflowDecision', E'NextOrPreviousWorkflowDecision', E'Bec.TargetFramework.Workflow.Components.Decisions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'83b31410-7855-45da-8970-45cc34db76f3', E'InsufficientCreditsWorkflowAction', E'InsufficientCreditsWorkflowAction', E'InsufficientCreditsWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'851ae94c-f236-4dd8-a2a0-4cd2c01e1933', E'PaymentWithPreAuthWorkflowAction', E'PaymentWithPreAuthWorkflowAction', E'PaymentWithPreAuthWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'88e0e684-27ca-4f4d-bde1-e0ba7d4a5e91', E'IDCheckWorkflowAction', E'IDCheckWorkflowAction', E'IDCheckWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'94c5d08a-4c71-42aa-b13a-102b903f4771', E'IsPaymentSuccessfulWorkflowDecision', E'IsPaymentSuccessfulWorkflowDecision', E'IsPaymentSuccessfulWorkflowDecision', E'Bec.TargetFramework.Workflow.Components.Decisions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'a5ee6f6b-ec96-446b-a929-a39a2fd3f2d7', E'CompanyUsingCreditsWorkflowDecision', E'CompanyUsingCreditsWorkflowDecision', E'CompanyUsingCreditsWorkflowDecision', E'Bec.TargetFramework.Workflow.Components.Decision\r\ns', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'b201acb8-e838-4fd9-9bea-55d8a498ce7c', E'FirmDetailsUserWorkflowAction', E'FirmDetails User Workflow', E'FirmDetailsUserWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'c81186c1-aa0e-42e7-822e-aa017abd3ed8', E'NextStepsOAInvitesUserWorkflowAction', E'Next Steps Org Admin invites user', E'NextStepsOAInvitesUserWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'd0759fd9-dfe9-450b-98d2-25920f226602', E'DashboardWorkflowAction', E'DashboardWorkflowAction', E'DashboardWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'f588ebe7-dbfd-4622-9ad6-f35f1feba13a', E'CreditsAvailableWorkflowDecision', E'CreditsAvailableWorkflowDecision', E'CreditsAvailableWorkflowDecision', E'Bec.TargetFramework.Workflow.Components.Decisions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);



--WorkflowStatusTypeTemplate

--WorkflowNotificationConstructTemplate

/* Data for the 'public.WorkflowParameterTemplate' table  (Records 1 - 4) */

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'a2478a7e-0784-11e4-ab29-af318bae0329', E'Area', E'Area', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'System.String', E'Workflow');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'd4cb6196-0784-11e4-9b13-5b97cacb3ebf', E'Controller', E'Controller', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'System.String', E'InternalInvite');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'e65feed6-0784-11e4-8ca5-2b4618ede22d', E'Action', E'Action', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'System.String', E'InternalInvite');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'f9b9b3a4-0784-11e4-8890-979c8dc32453', E'Action', E'Action', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'System.String', E'TnCInternalInvite');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'451153a8-0e7d-11e4-b400-bf9d7290fa21', E'WorkflowInstanceStatusID', E'workflow instance status new', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'System.String', E'New');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'8b50a1b4-10dc-11e4-9dbc-0f13e639b4f5', E'WorkflowInstanceStatusID', E'Workflow instance status Complete', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'System.String', E'Complete');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'9655e33a-10dc-11e4-bfb0-d7897c575f8c', E'WorkflowInstanceStatusID', E'Workflow instance status In progress', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'System.String', E'InProgress');


/* Data for the 'public.WorkflowTransistionTemplate' table  (Records 1 - 1) */

INSERT INTO public."WorkflowTransistionTemplate" ("WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "IsWorkflowStart", "IsWorkflowEnd")
VALUES (E'2dfb4035-0962-473b-bdf3-510a5dca1b72', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'OrganisationAdminInvitesUser', E'OrganisationAdminInvitesUser', False, False);



/* Data for the 'public.WorkflowActionTemplate' table  (Records 1 - 9) */

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'0558c1e0-1aba-40ff-b34e-f1fb8dac6bcd', E'UserPaymentWithoutPreAuthWorkflowAction', E'UserPaymentWithoutPreAuthWorkflowAction', False, False, NULL, True, E'58151c93-6bdc-4914-b370-75ac06acb568', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'128eb87e-b0e9-40b2-ac88-9217d35ff19b', E'DashboardWorkflowAction\r\n', E'DashboardWorkflowAction', False, False, NULL, True, E'd0759fd9-dfe9-450b-98d2-25920f226602', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'20feb508-e9dc-4975-8242-8454e86ef8a1', E'FirmDetailsUserWorkflowAction\r\n', E'FirmDetailsUserWorkflowAction\r\n', False, False, NULL, True, E'b201acb8-e838-4fd9-9bea-55d8a498ce7c', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'3e42aa83-952e-4e84-ade3-c635a66ffff9', E'NextStepsOAInvitesUserWorkflowAction\r\n', E'NextStepsOAInvitesUserWorkflowAction\r\n', False, False, NULL, True, E'c81186c1-aa0e-42e7-822e-aa017abd3ed8', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'6b46ace0-7dd4-4891-90da-1f471f76a524', E'Terms&ConditionWorkflowAction', E'Terms&ConditionWorkflowAction', False, False, NULL, True, E'09f076b1-14cf-410a-804f-b0d788820cb0', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'9221204c-f372-4afa-af97-6805c54d7d21', E'UserPaymentWithPreAuthWorkflowAction', E'UserPaymentWithPreAuthWorkflowAction', False, False, NULL, True, E'851ae94c-f236-4dd8-a2a0-4cd2c01e1933', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'a14327dc-d329-4ec8-9dc7-10a57bd2e3f0', E'IDCheckWorkflowAction\r\n', E'IDCheckWorkflowAction\r\n', False, False, NULL, False, E'88e0e684-27ca-4f4d-bde1-e0ba7d4a5e91', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'c8961c1d-e40a-461b-b110-58e11bf9f23d', E'InsufficientCreditsWorkflowAction', E'InsufficientCreditsWorkflowAction', False, False, NULL, False, E'83b31410-7855-45da-8970-45cc34db76f3', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'f3ff74c2-86e2-4805-9a87-6c63ccd57ea3', E'PersonalDetailsWorkflowAction\r\n', E'PersonalDetailsWorkflowAction\r\n', False, False, NULL, True, E'5e25702f-7622-4382-9a74-9fd248f3c7bd', WorkflowTemplateID, WorkflowTemplateVersionNumber);



/* Data for the 'public.WorkflowDecisionTemplate' table  (Records 1 - 10) */

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'017efc02-ac78-4fff-a4de-497d05e7d531', E'CreditsAvailableForRetryWorkflowDecision', E'CreditsAvailableWorkflowDecision when the user tries multiple times for payment or at some other time', False, False, NULL, E'f588ebe7-dbfd-4622-9ad6-f35f1feba13a', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'0b149e89-3aac-4cfa-bd85-4b9611732ec3', E'IsPaymentSuccessfulPreAuthWorkflowDecision', E'IsPaymentSuccessfulPreAuthWorkflowDecision', False, False, NULL, E'94c5d08a-4c71-42aa-b13a-102b903f4771', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'35b83e5b-d09a-490b-9758-79bc34eca574', E'Terms&ConditionsNextOrPreviousWorkflowDecision', E'Terms&ConditionsNextOrPreviousWorkflowDecision', False, False, NULL, E'6103d80c-15e2-4736-bc30-c6d755bfa1db', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'85109089-91a9-4869-9d2c-ef5443023bdf', E'CreditsAvailableWorkflowDecision\r\n', E'CreditsAvailableWorkflowDecision\r\n', False, False, NULL, E'f588ebe7-dbfd-4622-9ad6-f35f1feba13a', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'8bbde0ef-05f8-4f50-b82d-cfb2f68dfb5a', E'PersonalPaymentWthoutPreAuthNextOrPreviousWorkflowDecision', E'PersonalPaymentWthoutPreAuthNextOrPreviousWorkflowDecision', False, False, NULL, E'6103d80c-15e2-4736-bc30-c6d755bfa1db', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'ac3cadd0-47b8-4a42-90f2-79f13d861c86', E'PersonalPaymentWithPreAuthNextOrPreviousWorkflowDecision', E'PersonalPaymentWithPreAuthNextOrPreviousWorkflowDecision', False, False, NULL, E'6103d80c-15e2-4736-bc30-c6d755bfa1db', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'c1e681f2-f62f-4eb2-bcc6-e7d3d9429a46', E'IsPaymentSuccessfulNoPreAuthWorkflowDecision', E'IsPaymentSuccessfulNoPreAuthWorkflowDecision', False, False, NULL, E'94c5d08a-4c71-42aa-b13a-102b903f4771', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'c4620201-8c8c-44b2-aaef-c8c48a7555c1', E'FirmDetailsNextOrPreviousWorkflowDecision', E'FirmDetailsNextOrPreviousWorkflowDecision', False, False, NULL, E'6103d80c-15e2-4736-bc30-c6d755bfa1db', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'c4a586d1-a464-4eac-8448-811fcb958439', E'CompanyUsingCreditsWorkflowDecision\r\n', E'CompanyUsingCreditsWorkflowDecision\r\n', False, False, NULL, E'a5ee6f6b-ec96-446b-a929-a39a2fd3f2d7', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'dd030157-ec6c-4de7-a199-1a6aea2ccc77', E'IDCheckPassedWorkflowDecision\r\n', E'IDCheckPassedWorkflowDecision\r\n', False, False, NULL, E'4e99367c-8947-4c56-ae10-d4b53034a3c3', WorkflowTemplateID, WorkflowTemplateVersionNumber);




--WorkflowConditionTemplate

--WorkflowCommandTemplate

--WorkflowCommandParameterTemplate



/* Data for the 'public.WorkflowActionParameterTemplate' table  (Records 1 - 6) */

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'3e42aa83-952e-4e84-ade3-c635a66ffff9', E'a2478a7e-0784-11e4-ab29-af318bae0329', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'3e42aa83-952e-4e84-ade3-c635a66ffff9', E'd4cb6196-0784-11e4-9b13-5b97cacb3ebf', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'3e42aa83-952e-4e84-ade3-c635a66ffff9', E'e65feed6-0784-11e4-8ca5-2b4618ede22d', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'6b46ace0-7dd4-4891-90da-1f471f76a524', E'a2478a7e-0784-11e4-ab29-af318bae0329', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'6b46ace0-7dd4-4891-90da-1f471f76a524', E'd4cb6196-0784-11e4-9b13-5b97cacb3ebf', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'6b46ace0-7dd4-4891-90da-1f471f76a524', E'f9b9b3a4-0784-11e4-8890-979c8dc32453', WorkflowTemplateID, WorkflowTemplateVersionNumber);



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




/* Data for the 'public.WorkflowDecisionFailureTemplate' table  (Records 1 - 10) */

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'c4620201-8c8c-44b2-aaef-c8c48a7555c1', E'f3ff74c2-86e2-4805-9a87-6c63ccd57ea3', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'35b83e5b-d09a-490b-9758-79bc34eca574', E'3e42aa83-952e-4e84-ade3-c635a66ffff9', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'c4a586d1-a464-4eac-8448-811fcb958439', E'0558c1e0-1aba-40ff-b34e-f1fb8dac6bcd', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'85109089-91a9-4869-9d2c-ef5443023bdf', E'0558c1e0-1aba-40ff-b34e-f1fb8dac6bcd', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'ac3cadd0-47b8-4a42-90f2-79f13d861c86', E'20feb508-e9dc-4975-8242-8454e86ef8a1', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'017efc02-ac78-4fff-a4de-497d05e7d531', E'0558c1e0-1aba-40ff-b34e-f1fb8dac6bcd', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'dd030157-ec6c-4de7-a199-1a6aea2ccc77', E'128eb87e-b0e9-40b2-ac88-9217d35ff19b', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'0b149e89-3aac-4cfa-bd85-4b9611732ec3', E'9221204c-f372-4afa-af97-6805c54d7d21', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'8bbde0ef-05f8-4f50-b82d-cfb2f68dfb5a', E'20feb508-e9dc-4975-8242-8454e86ef8a1', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'c1e681f2-f62f-4eb2-bcc6-e7d3d9429a46', E'0558c1e0-1aba-40ff-b34e-f1fb8dac6bcd', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);



/* Data for the 'public.WorkflowDecisionSuccessTemplate' table  (Records 1 - 10) */

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'c1e681f2-f62f-4eb2-bcc6-e7d3d9429a46', E'a14327dc-d329-4ec8-9dc7-10a57bd2e3f0', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'ac3cadd0-47b8-4a42-90f2-79f13d861c86', NULL, WorkflowTemplateID, WorkflowTemplateVersionNumber, E'017efc02-ac78-4fff-a4de-497d05e7d531');

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'017efc02-ac78-4fff-a4de-497d05e7d531', NULL, WorkflowTemplateID, WorkflowTemplateVersionNumber, E'0b149e89-3aac-4cfa-bd85-4b9611732ec3');

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'35b83e5b-d09a-490b-9758-79bc34eca574', E'f3ff74c2-86e2-4805-9a87-6c63ccd57ea3', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'c4a586d1-a464-4eac-8448-811fcb958439', NULL, WorkflowTemplateID, WorkflowTemplateVersionNumber, E'85109089-91a9-4869-9d2c-ef5443023bdf');

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'85109089-91a9-4869-9d2c-ef5443023bdf', E'9221204c-f372-4afa-af97-6805c54d7d21', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'8bbde0ef-05f8-4f50-b82d-cfb2f68dfb5a', NULL, WorkflowTemplateID, WorkflowTemplateVersionNumber, E'c1e681f2-f62f-4eb2-bcc6-e7d3d9429a46');

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'dd030157-ec6c-4de7-a199-1a6aea2ccc77', E'128eb87e-b0e9-40b2-ac88-9217d35ff19b', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'0b149e89-3aac-4cfa-bd85-4b9611732ec3', E'a14327dc-d329-4ec8-9dc7-10a57bd2e3f0', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'c4620201-8c8c-44b2-aaef-c8c48a7555c1', NULL, WorkflowTemplateID, WorkflowTemplateVersionNumber, E'c4a586d1-a464-4eac-8448-811fcb958439');




/* Data for the 'public.WorkflowTransistionWorkflowActionTemplate' table  (Records 1 - 9) */

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2dfb4035-0962-473b-bdf3-510a5dca1b72', E'0558c1e0-1aba-40ff-b34e-f1fb8dac6bcd', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2dfb4035-0962-473b-bdf3-510a5dca1b72', E'128eb87e-b0e9-40b2-ac88-9217d35ff19b', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2dfb4035-0962-473b-bdf3-510a5dca1b72', E'20feb508-e9dc-4975-8242-8454e86ef8a1', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2dfb4035-0962-473b-bdf3-510a5dca1b72', E'3e42aa83-952e-4e84-ade3-c635a66ffff9', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2dfb4035-0962-473b-bdf3-510a5dca1b72', E'6b46ace0-7dd4-4891-90da-1f471f76a524', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2dfb4035-0962-473b-bdf3-510a5dca1b72', E'9221204c-f372-4afa-af97-6805c54d7d21', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2dfb4035-0962-473b-bdf3-510a5dca1b72', E'a14327dc-d329-4ec8-9dc7-10a57bd2e3f0', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2dfb4035-0962-473b-bdf3-510a5dca1b72', E'c8961c1d-e40a-461b-b110-58e11bf9f23d', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2dfb4035-0962-473b-bdf3-510a5dca1b72', E'f3ff74c2-86e2-4805-9a87-6c63ccd57ea3', WorkflowTemplateID, WorkflowTemplateVersionNumber);




/* Data for the 'public.WorkflowTransistionWorkflowDecisionTemplate' table  (Records 1 - 10) */

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2dfb4035-0962-473b-bdf3-510a5dca1b72', E'017efc02-ac78-4fff-a4de-497d05e7d531', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2dfb4035-0962-473b-bdf3-510a5dca1b72', E'0b149e89-3aac-4cfa-bd85-4b9611732ec3', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2dfb4035-0962-473b-bdf3-510a5dca1b72', E'35b83e5b-d09a-490b-9758-79bc34eca574', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2dfb4035-0962-473b-bdf3-510a5dca1b72', E'85109089-91a9-4869-9d2c-ef5443023bdf', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2dfb4035-0962-473b-bdf3-510a5dca1b72', E'8bbde0ef-05f8-4f50-b82d-cfb2f68dfb5a', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2dfb4035-0962-473b-bdf3-510a5dca1b72', E'ac3cadd0-47b8-4a42-90f2-79f13d861c86', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2dfb4035-0962-473b-bdf3-510a5dca1b72', E'c1e681f2-f62f-4eb2-bcc6-e7d3d9429a46', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2dfb4035-0962-473b-bdf3-510a5dca1b72', E'c4620201-8c8c-44b2-aaef-c8c48a7555c1', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2dfb4035-0962-473b-bdf3-510a5dca1b72', E'c4a586d1-a464-4eac-8448-811fcb958439', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2dfb4035-0962-473b-bdf3-510a5dca1b72', E'dd030157-ec6c-4de7-a199-1a6aea2ccc77', WorkflowTemplateID, WorkflowTemplateVersionNumber);



/* Data for the 'public.WorkflowTransistionHierarchyTemplate' table  (Records 1 - 1) */

INSERT INTO public."WorkflowTransistionHierarchyTemplate" ("WorkflowTransistionHierarchyTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsWorkflowStart", "IsWorkflowEnd")
VALUES (E'08d9b72e-a2be-40a2-bd2d-97cde65d05e4', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'2dfb4035-0962-473b-bdf3-510a5dca1b72', NULL, True, True);



/* Data for the 'public.WorkflowHierarchyTemplate' table  (Records 1 - 28) */

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'01b9b023-38b0-4a5c-919a-9240a9345295', E'2dfb4035-0962-473b-bdf3-510a5dca1b72', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'f3ff74c2-86e2-4805-9a87-6c63ccd57ea3', E'35b83e5b-d09a-490b-9758-79bc34eca574', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'0545def5-7214-43c9-9de6-80a8b1c02c3f', E'2dfb4035-0962-473b-bdf3-510a5dca1b72', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'c1e681f2-f62f-4eb2-bcc6-e7d3d9429a46', E'8bbde0ef-05f8-4f50-b82d-cfb2f68dfb5a', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'06d4169e-de4c-4aa2-bd66-49e92b145f78', E'2dfb4035-0962-473b-bdf3-510a5dca1b72', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'20feb508-e9dc-4975-8242-8454e86ef8a1', E'8bbde0ef-05f8-4f50-b82d-cfb2f68dfb5a', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'0a0eeb86-d1b5-44b0-8c41-125fa9ec0fa1', E'2dfb4035-0962-473b-bdf3-510a5dca1b72', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'9221204c-f372-4afa-af97-6805c54d7d21', E'0b149e89-3aac-4cfa-bd85-4b9611732ec3', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'0d119408-e290-4781-a606-2731ab394a5e', E'2dfb4035-0962-473b-bdf3-510a5dca1b72', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'017efc02-ac78-4fff-a4de-497d05e7d531', E'ac3cadd0-47b8-4a42-90f2-79f13d861c86', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'1b95cca1-329e-4773-99f3-726f0cea01ac', E'2dfb4035-0962-473b-bdf3-510a5dca1b72', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'20feb508-e9dc-4975-8242-8454e86ef8a1', E'f3ff74c2-86e2-4805-9a87-6c63ccd57ea3', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'4e3f3159-d217-4a8c-ba48-171779abee0a', E'2dfb4035-0962-473b-bdf3-510a5dca1b72', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'0b149e89-3aac-4cfa-bd85-4b9611732ec3', E'017efc02-ac78-4fff-a4de-497d05e7d531', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'576a878f-12f3-4eb5-8322-f3109205f84c', E'2dfb4035-0962-473b-bdf3-510a5dca1b72', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'c4a586d1-a464-4eac-8448-811fcb958439', E'c4620201-8c8c-44b2-aaef-c8c48a7555c1', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'588baef4-c694-429f-a9e7-4345283d8396', E'2dfb4035-0962-473b-bdf3-510a5dca1b72', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'0558c1e0-1aba-40ff-b34e-f1fb8dac6bcd', E'c4a586d1-a464-4eac-8448-811fcb958439', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'5d8d90c2-ee74-4711-90bc-fc267635f007', E'2dfb4035-0962-473b-bdf3-510a5dca1b72', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'f3ff74c2-86e2-4805-9a87-6c63ccd57ea3', E'c4620201-8c8c-44b2-aaef-c8c48a7555c1', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'6b4be68f-6e0d-4614-b4cd-ec25097f8fc4', E'2dfb4035-0962-473b-bdf3-510a5dca1b72', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'8bbde0ef-05f8-4f50-b82d-cfb2f68dfb5a', E'0558c1e0-1aba-40ff-b34e-f1fb8dac6bcd', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'6e8886de-f0af-44ac-a58a-307bed65bb5d', E'2dfb4035-0962-473b-bdf3-510a5dca1b72', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'9221204c-f372-4afa-af97-6805c54d7d21', E'85109089-91a9-4869-9d2c-ef5443023bdf', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'73e2aef5-99df-493a-b1c7-c1cd02f06337', E'2dfb4035-0962-473b-bdf3-510a5dca1b72', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'6b46ace0-7dd4-4891-90da-1f471f76a524', E'3e42aa83-952e-4e84-ade3-c635a66ffff9', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'8f8dc52a-3aad-4762-8b5a-91b229fde6ce', E'2dfb4035-0962-473b-bdf3-510a5dca1b72', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'0558c1e0-1aba-40ff-b34e-f1fb8dac6bcd', E'017efc02-ac78-4fff-a4de-497d05e7d531', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'acc74a60-0e88-44a1-af46-4010aeea1ff7', E'2dfb4035-0962-473b-bdf3-510a5dca1b72', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'3e42aa83-952e-4e84-ade3-c635a66ffff9', NULL, True, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'b1cba4e7-8468-49de-b9ca-3b8638503b16', E'2dfb4035-0962-473b-bdf3-510a5dca1b72', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'128eb87e-b0e9-40b2-ac88-9217d35ff19b', E'dd030157-ec6c-4de7-a199-1a6aea2ccc77', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'b3c48f53-6005-40d1-b021-5299d04c129e', E'2dfb4035-0962-473b-bdf3-510a5dca1b72', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'85109089-91a9-4869-9d2c-ef5443023bdf', E'c4a586d1-a464-4eac-8448-811fcb958439', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'b6c9aa20-f280-4ce1-b86a-41e908002da7', E'2dfb4035-0962-473b-bdf3-510a5dca1b72', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'dd030157-ec6c-4de7-a199-1a6aea2ccc77', E'a14327dc-d329-4ec8-9dc7-10a57bd2e3f0', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'b9b3342e-1df1-46c6-ba64-dd27af42e2ce', E'2dfb4035-0962-473b-bdf3-510a5dca1b72', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'c4620201-8c8c-44b2-aaef-c8c48a7555c1', E'20feb508-e9dc-4975-8242-8454e86ef8a1', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'd5239d47-e8e9-432c-84c6-e210524caee1', E'2dfb4035-0962-473b-bdf3-510a5dca1b72', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'ac3cadd0-47b8-4a42-90f2-79f13d861c86', E'9221204c-f372-4afa-af97-6805c54d7d21', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'e241210b-ba41-4463-bc48-1f1741700b25', E'2dfb4035-0962-473b-bdf3-510a5dca1b72', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'35b83e5b-d09a-490b-9758-79bc34eca574', E'6b46ace0-7dd4-4891-90da-1f471f76a524', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'e656e5ea-5d86-4db7-a695-ea1c2ab1616c', E'2dfb4035-0962-473b-bdf3-510a5dca1b72', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'3e42aa83-952e-4e84-ade3-c635a66ffff9', E'35b83e5b-d09a-490b-9758-79bc34eca574', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'f2b5e163-e6d0-4491-a83c-ea151639423e', E'2dfb4035-0962-473b-bdf3-510a5dca1b72', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'a14327dc-d329-4ec8-9dc7-10a57bd2e3f0', E'c1e681f2-f62f-4eb2-bcc6-e7d3d9429a46', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'f822486a-541d-4c8f-8be6-d78b902b01f5', E'2dfb4035-0962-473b-bdf3-510a5dca1b72', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'20feb508-e9dc-4975-8242-8454e86ef8a1', E'ac3cadd0-47b8-4a42-90f2-79f13d861c86', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'f8e1b381-06cb-446e-8b49-e2cd382663f3', E'2dfb4035-0962-473b-bdf3-510a5dca1b72', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'128eb87e-b0e9-40b2-ac88-9217d35ff19b', E'dd030157-ec6c-4de7-a199-1a6aea2ccc77', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'f935fa3a-376a-4bca-9eac-4d54aa36eeb6', E'2dfb4035-0962-473b-bdf3-510a5dca1b72', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'0558c1e0-1aba-40ff-b34e-f1fb8dac6bcd', E'85109089-91a9-4869-9d2c-ef5443023bdf', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'f999d18e-2c7b-4613-bcf3-489ae797f807', E'2dfb4035-0962-473b-bdf3-510a5dca1b72', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'a14327dc-d329-4ec8-9dc7-10a57bd2e3f0', E'0b149e89-3aac-4cfa-bd85-4b9611732ec3', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'fb39e49e-a17a-4e3f-a38a-9315b4d77d28', E'2dfb4035-0962-473b-bdf3-510a5dca1b72', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'0558c1e0-1aba-40ff-b34e-f1fb8dac6bcd', E'c1e681f2-f62f-4eb2-bcc6-e7d3d9429a46', NULL, NULL, False);




/* Data for the 'public.WorkflowTreeStructureTemplate' table  (Records 1 - 11) */

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'0ca5bfe6-9f65-4a3a-a16e-3e355dc8c5f2', E'd5aa520a-05ba-4dbe-9053-b84734ea37ed', 1, E'Payment', E'Payment with Pre-Auth', 4, E'1', E'1', E'0',E'54be1920-1ff8-4a64-8b8c-3611eecec415', NULL, NULL, 5);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'29480fb7-a97d-445e-b16c-b4995b8bd1b6', E'd5aa520a-05ba-4dbe-9053-b84734ea37ed', 1, E'ID Check', E'ID Check', 4, E'1', E'1', E'0', E'54be1920-1ff8-4a64-8b8c-3611eecec415', NULL, NULL, 7);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'36ad1715-7f0a-4f56-a89d-0f4157fb0cda', E'd5aa520a-05ba-4dbe-9053-b84734ea37ed', 1, E'Start', E'Start', 2, E'0', E'1', E'0', E'871de6fd-d1f2-45fc-97af-32fe0196b2f1', NULL, NULL, 1);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'54be1920-1ff8-4a64-8b8c-3611eecec415', E'd5aa520a-05ba-4dbe-9053-b84734ea37ed', 1, E'Stage One', E'Stage One', 3, E'0', E'1', E'0', E'36ad1715-7f0a-4f56-a89d-0f4157fb0cda', NULL, NULL, 1);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'570503b3-5208-4d95-93fe-10f37150c03b', E'd5aa520a-05ba-4dbe-9053-b84734ea37ed', 1, E'Terms & Conditions', E'Terms & Conditions', 4, E'1', E'1', E'0', E'54be1920-1ff8-4a64-8b8c-3611eecec415', NULL, NULL, 2);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'82e1c056-de12-4719-b01e-c72b8c4b964e', E'd5aa520a-05ba-4dbe-9053-b84734ea37ed', 1, E'Personal Details', E'Personal Details', 4, E'1', E'1', E'0', E'54be1920-1ff8-4a64-8b8c-3611eecec415', NULL, NULL, 3);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'871de6fd-d1f2-45fc-97af-32fe0196b2f1', E'd5aa520a-05ba-4dbe-9053-b84734ea37ed', 1, E'Safe Move Scheme Sign-Up', E'Safe Move Scheme Sign-Up', 1, E'0', E'1', E'0', NULL, NULL, NULL, 1);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'922b73b9-89ee-4645-b845-c16aa80120db', E'd5aa520a-05ba-4dbe-9053-b84734ea37ed', 1, E'Next Steps', E'Next Steps', 4, E'1', E'1', E'0', E'54be1920-1ff8-4a64-8b8c-3611eecec415', NULL, NULL, 1);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'a8e80f84-3ab5-4e36-828c-43f7fc92dc2b', E'd5aa520a-05ba-4dbe-9053-b84734ea37ed', 1, E'Payment', E'Payment without Pre-Auth', 4, E'1', E'1', E'0', E'54be1920-1ff8-4a64-8b8c-3611eecec415', NULL, NULL, 6);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'c8763f50-06b9-45cf-9258-b9ee244695f4', E'd5aa520a-05ba-4dbe-9053-b84734ea37ed', 1, E'Firm Details', E'Firm Details', 4, E'1', E'1', E'0', E'54be1920-1ff8-4a64-8b8c-3611eecec415', NULL, NULL, 4);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'e547d4a5-7f44-4aa8-95a5-751d4fe2646f', E'd5aa520a-05ba-4dbe-9053-b84734ea37ed', 1, E'Finish', E'Finish', 2, E'0', E'1', E'0', E'871de6fd-d1f2-45fc-97af-32fe0196b2f1', NULL, NULL, 2);

--WorkflowMainParameterTemplate

-- promote wf
perform "fn_PromoteWorkflowTemplate"(WorkflowTemplateID,WorkflowTemplateVersionNumber);

END $$;