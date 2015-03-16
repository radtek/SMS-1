
DO $$
Declare ResourceTypeID integer;
Declare ResourceID UUID;
Declare WorkflowTemplateID UUID := E'060729a1-56c2-489c-9c45-78064c62997a';
Declare WorkflowTemplateVersionNumber  integer := 1;
Declare RoleID UUID;
Declare RoleName varchar(50);
Declare RoleDescription varchar(50);
Declare WorkflowClaimTemplateID UUID;

--WorkflowTemplate
BEGIN
/* Data for the 'public.WorkflowTemplate' table  (Records 1 - 1) */

INSERT INTO public."WorkflowTemplate" ("WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "WorkflowTypeID", "WorkflowSubTypeID", "WorkflowCategoryID", "WorkflowSubCategoryID")
VALUES (WorkflowTemplateID, WorkflowTemplateVersionNumber, E'ExternalInvites', E'Invites from any external firm to any user. user might be a COLP or RP or user', (select "ClassificationTypeID" from "ClassificationType" where "ClassificationTypeCategoryID" = 160 and "Name" = 'Startup' limit 1), NULL, NULL, NULL);

--WorkflowRoleTemplate

--WorkflowClaimTemplate

--Resource  with execute operation
If Not EXISTS(select * from "Resource" where "ResourceName" = 'STSExternalInviteWorkflow' limit 1) Then
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
      'STSExternalInviteWorkflow',
      'STS External Invite Workflow',
      ResourceTypeID
    );

    ResourceID := (select "ResourceID" from "Resource" where "ResourceName" = 'STSExternalInviteWorkflow' limit 1);

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


/* Data for the 'public.WorkflowObjectTypeTemplate' table  (Records 1 - 34) */

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'00ba6079-a143-4c0c-8daa-10efcf60111d', E'IsPaymentSuccessfulWorkflowDecision', E'IsPaymentSuccessfulWorkflowDecision', E'IsPaymentSuccessfulWorkflowDecision', E'Bec.TargetFramework.Workflow.Components.Decisions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'04d55308-442a-40e6-aa97-c763d4e89a90', E'FirmDetailsUserwithEditableFirmWorkflowAction', E'FirmDetailsUserwithEditableFirmWorkflowAction', E'FirmDetailsUserwithEditableFirmWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'09d02d30-c26d-49e3-991b-f570fa6c7525', E'InvitationToCOWorkflowAction', E'InvitationToCOWorkflowAction', E'InvitationToCOWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'21d86868-45e0-4e89-93ee-f9255c68592b', E'IsSRAValidWorkflowDecision', E'IsSRAValidWorkflowDecision', E'IsSRAValidWorkflowDecision', E'Bec.TargetFramework.Workflow.Components.Decisions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'2615ab0f-b939-44d1-96cb-9cef237aeac1', E'TnCExternalInviteToUserWorkflowAction', E'TnCExternalInviteToUserWorkflowAction', E'TnCExternalInviteToUserWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'29ebc6b6-a1b7-4c70-a107-10138154298e', E'PaymentWithPreAuthWorkflowAction', E'PaymentWithPreAuthWorkflowAction', E'PaymentWithPreAuthWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'3d69ec96-b0cb-4a2d-9b9c-682f871bdd3f', E'FirmDetailsUserwithNonEditableFirmWorkflowAction', E'FirmDetailsUserwithNonEditableFirmWorkflowAction', E'FirmDetailsUserwithNonEditableFirmWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'3ddb19d5-dada-4708-981f-22464ffe6ed2', E'ShoppingBasketwithCompanyCreditsWorkflowAction', E'ShoppingBasketwithCompanyCreditsWorkflowAction', E'ShoppingBasketwithCompanyCreditsWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'4556bb72-d82c-4b5f-b6cf-984a6a94c8a2', E'ApprovalRequestNotificationToBAWorkflowAction', E'ApprovalRequestNotificationToBAWorkflowAction', E'ApprovalRequestNotificationToBAWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'46803050-d298-48e4-a234-8738741f22a6', E'CompanyUsingCreditsWorkflowDecision', E'CompanyUsingCreditsWorkflowDecision', E'CompanyUsingCreditsWorkflowDecision', E'Bec.TargetFramework.Workflow.Components.Decisions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'60dba7a5-e95a-47cc-b70e-27bb261286ec', E'ApprovalRequestNotificationToCOWorkflowAction', E'ApprovalRequestNotificationToCOWorkflowAction', E'ApprovalRequestNotificationToCOWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'657e7404-3ea4-4566-bc4b-5569ced1139f', E'IDCheckWorkflowAction', E'IDCheckWorkflowAction', E'IDCheckWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions\r\n', E'Bec.TargetFramework.Workflow.Components\r\n', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'6ba78a7b-ddb5-4e40-bd4c-f8c09f7cc1ed', E'NextStepsExternalInviteWorkflowAction', E'NextStepsExternalInviteWorkflowAction', E'NextStepsExternalInviteWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'72f87318-3cda-4b46-869e-45c2e0de446b', E'DoesCompanyExistsWorkflowDecision', E'DoesCompanyExistsWorkflowDecision', E'DoesCompanyExistsWorkflowDecision', E'Bec.TargetFramework.Workflow.Components.Decisions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'78a4a9ef-d5e6-4e5c-9ad5-b61e1bc12936', E'ExperianCheckFailedWarningWorkflowAction', E'ExperianCheckFailedWarningWorkflowAction', E'ExperianCheckFailedWarningWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'7d4609c4-f3f9-4c19-b4e2-702709246855', E'HoldingPageWorkflowAction', E'HoldingPageWorkflowAction', E'HoldingPageWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'9905c91a-0aa7-4dd5-bf26-ed1000fee680', E'SearchDetailsWorkflowAction', E'SearchDetailsWorkflowAction', E'SearchDetailsWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'a5ddc1a7-7114-49c9-941e-37fa030d97a8', E'IsUserCOWorkflowDecision', E'IsUserCOWorkflowDecision', E'IsUserCOWorkflowDecision', E'Bec.TargetFramework.Workflow.Components.Decisions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'a694e275-3e05-4a15-b1d1-d3de65d9770d', E'IDCheckPassedWorkflowDecision', E'IDCheckPassedWorkflowDecision', E'IDCheckPassedWorkflowDecision', E'Bec.TargetFramework.Workflow.Components.Decisions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'a95996bd-31fd-4cac-914d-ccfffd2dd67b', E'NextOrPreviousWorkflowDecision', E'NextOrPreviousWorkflowDecision', E'NextOrPreviousWorkflowDecision', E'Bec.TargetFramework.Workflow.Components.Decisions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'b5796389-d477-4697-836a-67ceba8a9193', E'BranchesandUsersWorkflowAction', E'BranchesandUsersWorkflowAction', E'BranchesandUsersWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'b7bff93e-7f86-4d2c-8ced-a0a5645544e9', E'IsRegulatorSRAWorkflowDecision', E'IsRegulatorSRAWorkflowDecision', E'IsRegulatorSRAWorkflowDecision', E'Bec.TargetFramework.Workflow.Components.Decisions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'b9f9475e-5d65-4fb7-b956-035f9d0efbea', E'FirmDetailsCOWorkflowAction', E'FirmDetailsCOWorkflowAction', E'FirmDetailsCOWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'bc39bd52-2e73-41e9-bed2-cc00b199f957', E'TnCExternalInviteToCOWorkflowAction', E'TnCExternalInviteToCOWorkflowAction', E'TnCExternalInviteToCOWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'c43d344f-832e-42e0-8a22-46d0359d7f44', E'PaymentWithoutPreAuthWorkflowAction', E'PaymentWithoutPreAuthWorkflowAction', E'PaymentWithoutPreAuthWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'cbf9f704-fb65-4b13-9ef2-ea504d820583', E'AtleastOneApprovedBranchExistsWorkflowDecision', E'AtleastOneApprovedBranchExistsWorkflowDecision', E'AtleastOneApprovedBranchExistsWorkflowDecision', E'Bec.TargetFramework.Workflow.Components.Decisions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'd2f4369e-a2b2-49d8-adcb-26999c97c399', E'SummaryPaymentwithTotaltoPayWorkflowAction', E'SummaryPaymentwithTotaltoPayWorkflowAction', E'SummaryPaymentwithTotaltoPayWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'de9a49b1-8536-403e-8d3d-979a2c2bd001', E'CreditsAvailableWorkflowDecision', E'CreditsAvailableWorkflowDecision', E'CreditsAvailableWorkflowDecision', E'Bec.TargetFramework.Workflow.Components.Decisions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'e07e873b-b463-4510-9d50-e0f46375ef6d', E'DoesCompanyPayforIDCheckWorkflowDecision', E'DoesCompanyPayforIDCheckWorkflowDecision', E'DoesCompanyPayforIDCheckWorkflowDecision', E'Bec.TargetFramework.Workflow.Components.Decisions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'e2601b88-d850-4be2-946a-06030e958962', E'DoesBranchExistWorkflowDecision', E'DoesBranchExistWorkflowDecision', E'DoesBranchExistWorkflowDecision', E'Bec.TargetFramework.Workflow.Components.Decisions\r\n', E'Bec.TargetFramework.Workflow.Components\r\n', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'f1720edb-5971-4016-9061-6564bd861181', E'PersonalDetailsWorkflowAction', E'PersonalDetailsWorkflowAction', E'PersonalDetailsWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'f300ca7b-8615-44ad-a4a6-a7e49a966a85', E'UserIDCheckFailNotificationToCOWorkflowAction', E'UserIDCheckFailNotificationToCOWorkflowAction', E'UserIDCheckFailNotificationToCOWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions\r\n', E'Bec.TargetFramework.Workflow.Components\r\n', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'f93dfdb1-ad8b-4898-a851-2121517898b9', E'IsApprovedUserWorkflowDecision', E'IsApprovedUserWorkflowDecision', E'IsApprovedUserWorkflowDecision', E'Bec.TargetFramework.Workflow.Components.Decisions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowObjectTypeTemplate" ("WorkflowObjectTypeTemplateID", "Name", "Description", "ObjectTypeName", "ObjectTypeNameSpace", "ObjectTypeAssembly", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'fccaf999-fefa-4d71-9a99-3781909d0fb5', E'OrganisationCreditsforCOWorkflowAction', E'OrganisationCreditsforCOWorkflowAction', E'OrganisationCreditsforCOWorkflowAction', E'Bec.TargetFramework.Workflow.Components.Actions', E'Bec.TargetFramework.Workflow.Components', WorkflowTemplateID, WorkflowTemplateVersionNumber);


--WorkflowStatusTypeTemplate

--WorkflowNotificationConstructTemplate

/* Data for the 'public.WorkflowTransistionTemplate' table  (Records 1 - 1) */

INSERT INTO public."WorkflowTransistionTemplate" ("WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "IsWorkflowStart", "IsWorkflowEnd")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'ExternalInvites', E'ExternalInvites', False, False);

/* Data for the 'public.WorkflowActionTemplate' table  (Records 1 - 21) */

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'027dd4cb-0be8-45d3-8e66-62712ba180a1', E'HoldingPageWorkflowAction\r\n', E'HoldingPageWorkflowAction\r\n', False, False, NULL, False, E'7d4609c4-f3f9-4c19-b4e2-702709246855', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'046e71c9-0d94-4cb9-9804-be8ec68fdaf6', E'PaymentWithPreAuthWorkflowAction\r\n', E'PaymentWithPreAuthWorkflowAction\r\n', False, False, NULL, False, E'29ebc6b6-a1b7-4c70-a107-10138154298e', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'0c1bf58b-7ba2-4bef-8dd7-2ea0ef7ab7e0', E'TnCExternalInviteToCOWorkflowAction\r\n', E'TnCExternalInviteToCOWorkflowAction\r\n', False, False, NULL, False, E'bc39bd52-2e73-41e9-bed2-cc00b199f957', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'19e8f588-5b9a-4f81-9fb5-ddbf7aaaedef', E'TnCExternalInviteToUserWorkflowAction\r\n', E'TnCExternalInviteToUserWorkflowAction\r\n', False, False, NULL, False, E'2615ab0f-b939-44d1-96cb-9cef237aeac1', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'29578006-81dc-412b-899d-fe34064cd009', E'BranchesandUsersWorkflowAction\r\n', E'BranchesandUsersWorkflowAction\r\n', False, False, NULL, False, E'b5796389-d477-4697-836a-67ceba8a9193', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'3eb7a947-6731-4b89-a7c3-543327a97309', E'PersonalDetailsWorkflowAction\r\n', E'PersonalDetailsWorkflowAction\r\n', False, False, NULL, False, E'f1720edb-5971-4016-9061-6564bd861181', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'4c4819bd-388a-4705-9974-103efe1c74f3', E'InvitationToCOWorkflowAction\r\n', E'InvitationToCOWorkflowAction\r\n', False, False, NULL, False, E'09d02d30-c26d-49e3-991b-f570fa6c7525', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'4ebd9cb5-cfef-4afe-9481-3f8475887a34', E'NextStepsExternalInviteWorkflowAction\r\n', E'NextStepsExternalInviteWorkflowAction\r\n', False, False, NULL, False, E'6ba78a7b-ddb5-4e40-bd4c-f8c09f7cc1ed', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'5039f248-029e-11e4-8f15-c30081ddbb56', E'PersonalDetailsCOWorkflowAction', E'PersonalDetailsCOWorkflowAction', False, False, NULL, False, E'f1720edb-5971-4016-9061-6564bd861181', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'77f1081d-9c1e-4279-8563-7df997169e85', E'FirmDetailsUserwithEditableFirmWorkflowAction\r\n', E'FirmDetailsUserwithEditableFirmWorkflowAction\r\n', False, False, NULL, False, E'04d55308-442a-40e6-aa97-c763d4e89a90', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'820dcbcc-1771-46fd-8238-43e6f7fde9f6', E'SummaryPaymentwithTotaltoPayWorkflowAction\r\n', E'SummaryPaymentwithTotaltoPayWorkflowAction\r\n', False, False, NULL, False, E'd2f4369e-a2b2-49d8-adcb-26999c97c399', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'8ff25773-6751-4df3-9b66-b741d2283456', E'ExperianCheckFailedWarningWorkflowAction\r\n', E'ExperianCheckFailedWarningWorkflowAction\r\n', False, False, NULL, False, E'78a4a9ef-d5e6-4e5c-9ad5-b61e1bc12936', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'98fb9179-03ff-4a46-a1ef-f71a953a000f', E'IDCheckWorkflowAction\r\n', E'IDCheckWorkflowAction\r\n', False, False, NULL, False, E'657e7404-3ea4-4566-bc4b-5569ced1139f', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'a115ec13-b98e-4c2a-af30-daf5e9f7ba5a', E'ApprovalRequestNotificationToCOWorkflowAction\r\n', E'ApprovalRequestNotificationToCOWorkflowAction\r\n', False, False, NULL, False, E'60dba7a5-e95a-47cc-b70e-27bb261286ec', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'a82d48ad-4321-492a-950e-bb26aa0d51af', E'ShoppingBasketwithCompanyCreditsWorkflowAction\r\n', E'ShoppingBasketwithCompanyCreditsWorkflowAction\r\n', False, False, NULL, False, E'3ddb19d5-dada-4708-981f-22464ffe6ed2', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'b779a952-fa5b-4911-9a85-8c717a8e9ff6', E'ApprovalRequestNotificationToBAWorkflowAction\r\n', E'ApprovalRequestNotificationToBAWorkflowAction\r\n', False, False, NULL, False, E'4556bb72-d82c-4b5f-b6cf-984a6a94c8a2', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'be883873-03c0-401e-9b9b-945b61902a44', E'FirmDetailsUserwithNonEditableFirmWorkflowAction\r\n', E'FirmDetailsUserwithNonEditableFirmWorkflowAction\r\n', False, False, NULL, False, E'3d69ec96-b0cb-4a2d-9b9c-682f871bdd3f', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'cb560537-1659-434d-bb7c-5a58faaaf5c8', E'OrganisationCreditsforCOWorkflowAction\r\n', E'OrganisationCreditsforCOWorkflowAction\r\n', False, False, NULL, False, E'fccaf999-fefa-4d71-9a99-3781909d0fb5', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'e2a250e0-f609-4a4c-ac55-4e41650c1f86', E'PaymentWithoutPreAuthWorkflowAction\r\n', E'PaymentWithoutPreAuthWorkflowAction\r\n', False, False, NULL, False, E'c43d344f-832e-42e0-8a22-46d0359d7f44', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'e32bda0d-35cd-428a-b4b5-59c232fdc972', E'FirmDetailsCOWorkflowAction\r\n', E'FirmDetailsCOWorkflowAction\r\n', False, False, NULL, False, E'b9f9475e-5d65-4fb7-b956-035f9d0efbea', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionTemplate" ("WorkflowActionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowActionTypeTemplateID", "IsManual", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'ee28f184-4ffb-4c9a-bc4d-109ef94f740d', E'SearchDetailsWorkflowAction\r\n', E'SearchDetailsWorkflowAction\r\n', False, False, NULL, False, E'9905c91a-0aa7-4dd5-bf26-ed1000fee680', WorkflowTemplateID, WorkflowTemplateVersionNumber);

/* Data for the 'public.WorkflowDecisionTemplate' table  (Records 1 - 31) */

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'02f9998b-6124-4810-ba01-029de572a492', E'UserIDCheckPassedWorkflowDecision', E'UserIDCheckPassedWorkflowDecision', False, False, NULL, E'a694e275-3e05-4a15-b1d1-d3de65d9770d', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'05b17bf4-7110-4597-ad6d-25b1e5d05636', E'DoesCompanyExistsWorkflowDecision', E'DoesCompanyExistsWorkflowDecision', False, False, NULL, E'72f87318-3cda-4b46-869e-45c2e0de446b', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'087ff99c-6e84-4ce2-b373-a675c0259e52', E'PersonalPaymentWithoutPreAuthNextOrPreviousWorkFlowDecision\r\n', E'PersonalPaymentWithoutPreAuthNextOrPreviousWorkFlowDecision\r\n', False, False, NULL, E'a95996bd-31fd-4cac-914d-ccfffd2dd67b', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'162d06d4-eabe-40fc-8a6a-00aa86e987f0', E'Terms&ConditionsCONextOrPreviousWorkFlowDecision\r\n\r\n', E'Terms&ConditionsCONextOrPreviousWorkFlowDecision\r\n\r\n', False, False, NULL, E'a95996bd-31fd-4cac-914d-ccfffd2dd67b', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'1f9d3503-fc51-4812-9fe7-966f8094f846', E'IsApprovedUserWorkflowDecision\r\n', E'IsApprovedUserWorkflowDecision\r\n', False, False, NULL, E'f93dfdb1-ad8b-4898-a851-2121517898b9', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'324554c0-6908-41d9-b773-be54b7889189', E'FirmDetailsCONextOrPreviousWorkFlowDecision\r\n', E'FirmDetailsCONextOrPreviousWorkFlowDecision\r\n', False, False, NULL, E'a95996bd-31fd-4cac-914d-ccfffd2dd67b', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'3542b1d0-3fbe-45be-9e3a-2c148a2d1928', E'FirmDetailsUserEditableNextOrPreviousWorkFlowDecision\r\n', E'FirmDetailsUserEditableNextOrPreviousWorkFlowDecision', False, False, NULL, E'a95996bd-31fd-4cac-914d-ccfffd2dd67b', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'3fc5a6f4-6d44-4353-8147-3c557e57d848', E'CreditsAvailableWorkflowDecision\r\n', E'CreditsAvailableWorkflowDecision\r\n', False, False, NULL, E'de9a49b1-8536-403e-8d3d-979a2c2bd001', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'44aa313b-42ef-4a2c-870f-ee2b35609965', E'IsSRAValidWorkflowDecision\r\n', E'IsSRAValidWorkflowDecision\r\n', False, False, NULL, E'21d86868-45e0-4e89-93ee-f9255c68592b', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'58301250-1260-46c0-b53b-81c9f34c2f2e', E'OrganisationCreditNextOrPreviousWorkFlowDecision\r\n', E'OrganisationCreditNextOrPreviousWorkFlowDecision\r\n', False, False, NULL, E'a95996bd-31fd-4cac-914d-ccfffd2dd67b', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'6ebfc0bd-5d8d-4a02-a02d-d9c0c64170e1', E'CompanyUserPersonalPaymentWithPreAuthNextOrPreviousWorkFlowDecision', E'CompanyUserPersonalPaymentWithPreAuthNextOrPreviousWorkFlowDecision', False, False, NULL, E'a95996bd-31fd-4cac-914d-ccfffd2dd67b', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'701294ff-afff-4750-8bc4-b45027bb2d7c', E'IsUserPaymentSuccessfulwithoutPreAuthWorkflowDecision\r\n', E'IsUserPaymentSuccessfulwithoutPreAuthWorkflowDecision', False, False, NULL, E'00ba6079-a143-4c0c-8daa-10efcf60111d', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'791c77bf-44cf-4f37-b528-92d19970a674', E'DoesBranchExistWorkflowDecision\r\n', E'DoesBranchExistWorkflowDecision\r\n', False, False, NULL, E'e2601b88-d850-4be2-946a-06030e958962', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'92410955-a32f-41ee-ac93-095b46a4f117', E'IsPaymentSuccessfulwithPreAuthWorkflowDecision', E'IsPaymentSuccessfulwithPreAuthWorkflowDecision', False, False, NULL, E'00ba6079-a143-4c0c-8daa-10efcf60111d', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'b1898785-f6cd-4e52-b7d1-dedaa476ebf9', E'NonExistingCompanyUserPersonalPaymentWithoutPreAuthNextOrPreviousWorkFlowDecision', E'NonExistingCompanyUserPersonalPaymentWithoutPreAuthNextOrPreviousWorkFlowDecision', False, False, NULL, E'a95996bd-31fd-4cac-914d-ccfffd2dd67b', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'b2d9a351-ce3c-45ae-86ee-066ee15b6b25', E'AtleastOneApprovedBranchExistsWorkflowDecision\r\n', E'AtleastOneApprovedBranchExistsWorkflowDecision\r\n', False, False, NULL, E'cbf9f704-fb65-4b13-9ef2-ea504d820583', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'b8c40154-0090-47e4-8198-089e97d4623c', E'IsPaymentSuccessfulwithoutPreAuthWorkflowDecision\r\n', E'IsPaymentSuccessfulwithoutPreAuthWorkflowDecision\r\n', False, False, NULL, E'00ba6079-a143-4c0c-8daa-10efcf60111d', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'bd317461-a7b9-482e-b958-49d08a5855c6', E'CompanyUsingCreditsWorkflowDecision\r\n', E'CompanyUsingCreditsWorkflowDecision\r\n', False, False, NULL, E'46803050-d298-48e4-a234-8738741f22a6', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'bf3acc9d-d1a3-4aed-8c12-4630adf16c7d', E'IsUserCOWorkflowDecision\r\n', E'IsUserCOWorkflowDecision\r\n', False, False, NULL, E'a5ddc1a7-7114-49c9-941e-37fa030d97a8', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'bfa0d089-45ac-4e3d-b138-3317990d68aa', E'IsUserPaymentSuccessfulwithPreAuthWorkflowDecision', E'IsUserPaymentSuccessfulwithPreAuthWorkflowDecision', False, False, NULL, E'00ba6079-a143-4c0c-8daa-10efcf60111d', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'c02f475d-f81f-4e99-be8b-1e84470c359b', E'CompanyUserPersonalPaymentWithoutPreAuthNextOrPreviousWorkFlowDecision', E'CompanyUserPersonalPaymentWithoutPreAuthNextOrPreviousWorkFlowDecision', False, False, NULL, E'a95996bd-31fd-4cac-914d-ccfffd2dd67b', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'c1a3330b-0393-4834-8c50-505d662974db', E'SummaryPaymentNextrPreviousWorkfFlowDecision', E'SummaryPaymentNextrPreviousWorkfFlowDecision', False, False, NULL, E'a95996bd-31fd-4cac-914d-ccfffd2dd67b', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'cc1f9193-4e16-4651-b947-5c020417e73c', E'PersonalPaymentWithPreAuthNextOrPreviousWorkFlowDecision\r\n', E'PersonalPaymentWithPreAuthNextOrPreviousWorkFlowDecision\r\n', False, False, NULL, E'a95996bd-31fd-4cac-914d-ccfffd2dd67b', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'd082f06d-b4f8-4661-b82c-f367b76a1c6d', E'DoesCompanyPayforIDCheckWorkflowDecision\r\n', E'DoesCompanyPayforIDCheckWorkflowDecision\r\n', False, False, NULL, E'e07e873b-b463-4510-9d50-e0f46375ef6d', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'd90493bc-195a-4fd9-b7b7-b51de5d891c5', E'DoesApprovedCompanyExistsWorkflowDecision\r\n', E'DoesApprovedCompanyExistsWorkflowDecision\r\n', False, False, NULL, E'72f87318-3cda-4b46-869e-45c2e0de446b', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'd93f5ba1-1d5b-46c5-89e5-cd2cb341c592', E'Terms&ConditionsUserNextOrPreviousWorkFlowDecision\r\n', E'Terms&ConditionsUserNextOrPreviousWorkFlowDecision', False, False, NULL, E'a95996bd-31fd-4cac-914d-ccfffd2dd67b', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'daab27ac-a80b-40ec-bfc5-59c1b4c7340f', E'IsRegulatorSRAWorkflowDecision\r\n', E'IsRegulatorSRAWorkflowDecision\r\n', False, False, NULL, E'b7bff93e-7f86-4d2c-8ced-a0a5645544e9', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'e9f4a8b0-b857-4c05-8587-6840b40fa385', E'FirmDetailsUserNonEditableNextOrPreviousWorkFlowDecision', E'FirmDetailsUserNonEditableNextOrPreviousWorkFlowDecision', False, False, NULL, E'a95996bd-31fd-4cac-914d-ccfffd2dd67b', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'f045282e-5acf-43da-b75b-0ef7ab484f3a', E'CompanyCreditsPaymentSuccessfulWorkflowDecision', E'CompanyCreditsPaymentSuccessfulWorkflowDecision', False, False, NULL, E'00ba6079-a143-4c0c-8daa-10efcf60111d', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'f24e6fa9-a29c-4fdd-bc99-47bbab97643e', E'IDCheckPassedWorkflowDecision\r\n', E'IDCheckPassedWorkflowDecision\r\n', False, False, NULL, E'a694e275-3e05-4a15-b1d1-d3de65d9770d', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowDecisionTemplate" ("WorkflowDecisionTemplateID", "Name", "Description", "IsTransistionStart", "IsTransistionEnd", "WorkflowDecisionTypeTemplateID", "WorkflowObjectTypeTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'f3c39624-3a43-4734-abe8-6736d7e2622b', E'CreditsAvailableCheckBeforeUserPaymentWorkflowDecision', E'CreditsAvailableCheckBeforeUserPaymentWorkflowDecision', False, False, NULL, E'de9a49b1-8536-403e-8d3d-979a2c2bd001', WorkflowTemplateID, WorkflowTemplateVersionNumber);

--WorkflowConditionTemplate

--WorkflowCommandTemplate

--WorkflowCommandParameterTemplate

--WorkflowActionParameterTemplate

--WorkflowConditionParameterTemplate

--WorkflowDecisionParameterTemplate

--WorkflowMainParameterTemplate

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

/* Data for the 'public.WorkflowDecisionFailureTemplate' table  (Records 1 - 30) */

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'162d06d4-eabe-40fc-8a6a-00aa86e987f0', E'4ebd9cb5-cfef-4afe-9481-3f8475887a34', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'324554c0-6908-41d9-b773-be54b7889189', E'5039f248-029e-11e4-8f15-c30081ddbb56', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'58301250-1260-46c0-b53b-81c9f34c2f2e', E'e32bda0d-35cd-428a-b4b5-59c232fdc972', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'bd317461-a7b9-482e-b958-49d08a5855c6', E'e2a250e0-f609-4a4c-ac55-4e41650c1f86', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'c1a3330b-0393-4834-8c50-505d662974db', E'cb560537-1659-434d-bb7c-5a58faaaf5c8', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'087ff99c-6e84-4ce2-b373-a675c0259e52', E'cb560537-1659-434d-bb7c-5a58faaaf5c8', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'b8c40154-0090-47e4-8198-089e97d4623c', E'e2a250e0-f609-4a4c-ac55-4e41650c1f86', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'f045282e-5acf-43da-b75b-0ef7ab484f3a', E'820dcbcc-1771-46fd-8238-43e6f7fde9f6', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'92410955-a32f-41ee-ac93-095b46a4f117', E'046e71c9-0d94-4cb9-9804-be8ec68fdaf6', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'f24e6fa9-a29c-4fdd-bc99-47bbab97643e', E'027dd4cb-0be8-45d3-8e66-62712ba180a1', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'daab27ac-a80b-40ec-bfc5-59c1b4c7340f', E'027dd4cb-0be8-45d3-8e66-62712ba180a1', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'b2d9a351-ce3c-45ae-86ee-066ee15b6b25', E'29578006-81dc-412b-899d-fe34064cd009', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'44aa313b-42ef-4a2c-870f-ee2b35609965', E'027dd4cb-0be8-45d3-8e66-62712ba180a1', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'bf3acc9d-d1a3-4aed-8c12-4630adf16c7d', E'19e8f588-5b9a-4f81-9fb5-ddbf7aaaedef', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'd93f5ba1-1d5b-46c5-89e5-cd2cb341c592', E'4ebd9cb5-cfef-4afe-9481-3f8475887a34', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'3542b1d0-3fbe-45be-9e3a-2c148a2d1928', E'3eb7a947-6731-4b89-a7c3-543327a97309', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'd90493bc-195a-4fd9-b7b7-b51de5d891c5', E'77f1081d-9c1e-4279-8563-7df997169e85', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'05b17bf4-7110-4597-ad6d-25b1e5d05636', E'e2a250e0-f609-4a4c-ac55-4e41650c1f86', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'b1898785-f6cd-4e52-b7d1-dedaa476ebf9', E'77f1081d-9c1e-4279-8563-7df997169e85', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'02f9998b-6124-4810-ba01-029de572a492', E'8ff25773-6751-4df3-9b66-b741d2283456', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'701294ff-afff-4750-8bc4-b45027bb2d7c', E'e2a250e0-f609-4a4c-ac55-4e41650c1f86', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'1f9d3503-fc51-4812-9fe7-966f8094f846', E'e2a250e0-f609-4a4c-ac55-4e41650c1f86', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'791c77bf-44cf-4f37-b528-92d19970a674', E'a115ec13-b98e-4c2a-af30-daf5e9f7ba5a', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'e9f4a8b0-b857-4c05-8587-6840b40fa385', E'3eb7a947-6731-4b89-a7c3-543327a97309', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'3fc5a6f4-6d44-4353-8147-3c557e57d848', E'e2a250e0-f609-4a4c-ac55-4e41650c1f86', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'd082f06d-b4f8-4661-b82c-f367b76a1c6d', E'e2a250e0-f609-4a4c-ac55-4e41650c1f86', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'c02f475d-f81f-4e99-be8b-1e84470c359b', E'be883873-03c0-401e-9b9b-945b61902a44', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'6ebfc0bd-5d8d-4a02-a02d-d9c0c64170e1', E'be883873-03c0-401e-9b9b-945b61902a44', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'bfa0d089-45ac-4e3d-b138-3317990d68aa', E'046e71c9-0d94-4cb9-9804-be8ec68fdaf6', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionFailureTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'f3c39624-3a43-4734-abe8-6736d7e2622b', E'e2a250e0-f609-4a4c-ac55-4e41650c1f86', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

/* Data for the 'public.WorkflowDecisionSuccessTemplate' table  (Records 1 - 30) */

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'bf3acc9d-d1a3-4aed-8c12-4630adf16c7d', E'0c1bf58b-7ba2-4bef-8dd7-2ea0ef7ab7e0', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'162d06d4-eabe-40fc-8a6a-00aa86e987f0', E'5039f248-029e-11e4-8f15-c30081ddbb56', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'324554c0-6908-41d9-b773-be54b7889189', E'cb560537-1659-434d-bb7c-5a58faaaf5c8', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'087ff99c-6e84-4ce2-b373-a675c0259e52', NULL, WorkflowTemplateID, WorkflowTemplateVersionNumber, E'b8c40154-0090-47e4-8198-089e97d4623c');

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'c1a3330b-0393-4834-8c50-505d662974db', NULL, WorkflowTemplateID, WorkflowTemplateVersionNumber, E'f045282e-5acf-43da-b75b-0ef7ab484f3a');

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'58301250-1260-46c0-b53b-81c9f34c2f2e', E'a82d48ad-4321-492a-950e-bb26aa0d51af', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'bd317461-a7b9-482e-b958-49d08a5855c6', E'820dcbcc-1771-46fd-8238-43e6f7fde9f6', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'f045282e-5acf-43da-b75b-0ef7ab484f3a', E'046e71c9-0d94-4cb9-9804-be8ec68fdaf6', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'b8c40154-0090-47e4-8198-089e97d4623c', NULL, WorkflowTemplateID, WorkflowTemplateVersionNumber, E'f24e6fa9-a29c-4fdd-bc99-47bbab97643e');

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'92410955-a32f-41ee-ac93-095b46a4f117', '98fb9179-03ff-4a46-a1ef-f71a953a000f', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'f24e6fa9-a29c-4fdd-bc99-47bbab97643e', NULL, WorkflowTemplateID, WorkflowTemplateVersionNumber, E'daab27ac-a80b-40ec-bfc5-59c1b4c7340f');

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'daab27ac-a80b-40ec-bfc5-59c1b4c7340f', NULL, WorkflowTemplateID, WorkflowTemplateVersionNumber, E'44aa313b-42ef-4a2c-870f-ee2b35609965');

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'44aa313b-42ef-4a2c-870f-ee2b35609965', E'29578006-81dc-412b-899d-fe34064cd009', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'd93f5ba1-1d5b-46c5-89e5-cd2cb341c592', E'3eb7a947-6731-4b89-a7c3-543327a97309', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'b2d9a351-ce3c-45ae-86ee-066ee15b6b25', E'ee28f184-4ffb-4c9a-bc4d-109ef94f740d', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'3542b1d0-3fbe-45be-9e3a-2c148a2d1928', E'4c4819bd-388a-4705-9974-103efe1c74f3', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'd082f06d-b4f8-4661-b82c-f367b76a1c6d', NULL, WorkflowTemplateID, WorkflowTemplateVersionNumber, E'3fc5a6f4-6d44-4353-8147-3c557e57d848');

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'05b17bf4-7110-4597-ad6d-25b1e5d05636', NULL, WorkflowTemplateID, WorkflowTemplateVersionNumber, E'1f9d3503-fc51-4812-9fe7-966f8094f846');

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'701294ff-afff-4750-8bc4-b45027bb2d7c', NULL, WorkflowTemplateID, WorkflowTemplateVersionNumber, E'02f9998b-6124-4810-ba01-029de572a492');

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'02f9998b-6124-4810-ba01-029de572a492', E'ee28f184-4ffb-4c9a-bc4d-109ef94f740d', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'd90493bc-195a-4fd9-b7b7-b51de5d891c5', E'be883873-03c0-401e-9b9b-945b61902a44', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'e9f4a8b0-b857-4c05-8587-6840b40fa385', NULL, WorkflowTemplateID, WorkflowTemplateVersionNumber, E'791c77bf-44cf-4f37-b528-92d19970a674');

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'791c77bf-44cf-4f37-b528-92d19970a674', E'b779a952-fa5b-4911-9a85-8c717a8e9ff6', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'1f9d3503-fc51-4812-9fe7-966f8094f846', NULL, WorkflowTemplateID, WorkflowTemplateVersionNumber, E'd082f06d-b4f8-4661-b82c-f367b76a1c6d');

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'3fc5a6f4-6d44-4353-8147-3c557e57d848', E'046e71c9-0d94-4cb9-9804-be8ec68fdaf6', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'6ebfc0bd-5d8d-4a02-a02d-d9c0c64170e1', NULL, WorkflowTemplateID, WorkflowTemplateVersionNumber, E'f3c39624-3a43-4734-abe8-6736d7e2622b');

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'b1898785-f6cd-4e52-b7d1-dedaa476ebf9', NULL, WorkflowTemplateID, WorkflowTemplateVersionNumber, E'701294ff-afff-4750-8bc4-b45027bb2d7c');

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'bfa0d089-45ac-4e3d-b138-3317990d68aa', E'98fb9179-03ff-4a46-a1ef-f71a953a000f', WorkflowTemplateID, WorkflowTemplateVersionNumber, NULL);

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'f3c39624-3a43-4734-abe8-6736d7e2622b', NULL, WorkflowTemplateID, WorkflowTemplateVersionNumber, E'bfa0d089-45ac-4e3d-b138-3317990d68aa');

INSERT INTO public."WorkflowDecisionSuccessTemplate" ("WorkflowDecisionTemplateID", "NextWorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "NextWorkflowDecisionTemplateID")
VALUES (E'c02f475d-f81f-4e99-be8b-1e84470c359b', NULL, WorkflowTemplateID, WorkflowTemplateVersionNumber, E'701294ff-afff-4750-8bc4-b45027bb2d7c');

/* Data for the 'public.WorkflowTransistionWorkflowActionTemplate' table  (Records 1 - 21) */

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'027dd4cb-0be8-45d3-8e66-62712ba180a1', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'046e71c9-0d94-4cb9-9804-be8ec68fdaf6', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'0c1bf58b-7ba2-4bef-8dd7-2ea0ef7ab7e0', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'19e8f588-5b9a-4f81-9fb5-ddbf7aaaedef', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'29578006-81dc-412b-899d-fe34064cd009', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'3eb7a947-6731-4b89-a7c3-543327a97309', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'4c4819bd-388a-4705-9974-103efe1c74f3', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'4ebd9cb5-cfef-4afe-9481-3f8475887a34', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'5039f248-029e-11e4-8f15-c30081ddbb56', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'77f1081d-9c1e-4279-8563-7df997169e85', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'820dcbcc-1771-46fd-8238-43e6f7fde9f6', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'8ff25773-6751-4df3-9b66-b741d2283456', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'98fb9179-03ff-4a46-a1ef-f71a953a000f', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'a115ec13-b98e-4c2a-af30-daf5e9f7ba5a', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'a82d48ad-4321-492a-950e-bb26aa0d51af', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'b779a952-fa5b-4911-9a85-8c717a8e9ff6', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'be883873-03c0-401e-9b9b-945b61902a44', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'cb560537-1659-434d-bb7c-5a58faaaf5c8', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'e2a250e0-f609-4a4c-ac55-4e41650c1f86', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'e32bda0d-35cd-428a-b4b5-59c232fdc972', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowActionTemplate" ("WorkflowTransistionTemplateID", "WorkflowActionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'ee28f184-4ffb-4c9a-bc4d-109ef94f740d', WorkflowTemplateID, WorkflowTemplateVersionNumber);

/* Data for the 'public.WorkflowTransistionWorkflowDecisionTemplate' table  (Records 1 - 31) */

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'02f9998b-6124-4810-ba01-029de572a492', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'05b17bf4-7110-4597-ad6d-25b1e5d05636', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'087ff99c-6e84-4ce2-b373-a675c0259e52', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'162d06d4-eabe-40fc-8a6a-00aa86e987f0', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'1f9d3503-fc51-4812-9fe7-966f8094f846', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'324554c0-6908-41d9-b773-be54b7889189', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'3542b1d0-3fbe-45be-9e3a-2c148a2d1928', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'3fc5a6f4-6d44-4353-8147-3c557e57d848', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'44aa313b-42ef-4a2c-870f-ee2b35609965', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'58301250-1260-46c0-b53b-81c9f34c2f2e', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'6ebfc0bd-5d8d-4a02-a02d-d9c0c64170e1', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'701294ff-afff-4750-8bc4-b45027bb2d7c', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'791c77bf-44cf-4f37-b528-92d19970a674', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'92410955-a32f-41ee-ac93-095b46a4f117', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'b1898785-f6cd-4e52-b7d1-dedaa476ebf9', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'b2d9a351-ce3c-45ae-86ee-066ee15b6b25', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'b8c40154-0090-47e4-8198-089e97d4623c', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'bd317461-a7b9-482e-b958-49d08a5855c6', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'bf3acc9d-d1a3-4aed-8c12-4630adf16c7d', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'bfa0d089-45ac-4e3d-b138-3317990d68aa', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'c02f475d-f81f-4e99-be8b-1e84470c359b', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'c1a3330b-0393-4834-8c50-505d662974db', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'cc1f9193-4e16-4651-b947-5c020417e73c', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'd082f06d-b4f8-4661-b82c-f367b76a1c6d', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'd90493bc-195a-4fd9-b7b7-b51de5d891c5', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'd93f5ba1-1d5b-46c5-89e5-cd2cb341c592', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'daab27ac-a80b-40ec-bfc5-59c1b4c7340f', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'e9f4a8b0-b857-4c05-8587-6840b40fa385', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'f045282e-5acf-43da-b75b-0ef7ab484f3a', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'f24e6fa9-a29c-4fdd-bc99-47bbab97643e', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowTransistionWorkflowDecisionTemplate" ("WorkflowTransistionTemplateID", "WorkflowDecisionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', E'f3c39624-3a43-4734-abe8-6736d7e2622b', WorkflowTemplateID, WorkflowTemplateVersionNumber);

/* Data for the 'public.WorkflowTransistionHierarchyTemplate' table  (Records 1 - 1) */

INSERT INTO public."WorkflowTransistionHierarchyTemplate" ("WorkflowTransistionHierarchyTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsWorkflowStart", "IsWorkflowEnd")
VALUES (E'f4653ab7-5cab-4f67-ad8a-28b27b7891af', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', NULL, True, True);

/* Data for the 'public.WorkflowHierarchyTemplate' table  (Records 1 - 83) */

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'0112337d-f454-47e4-bbb9-83a0592786e8', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'f045282e-5acf-43da-b75b-0ef7ab484f3a', E'c1a3330b-0393-4834-8c50-505d662974db', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'065f48ca-5ff9-478a-b7c1-36938bbfe787', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'046e71c9-0d94-4cb9-9804-be8ec68fdaf6', E'3fc5a6f4-6d44-4353-8147-3c557e57d848', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'068e4084-2e22-4473-8cb9-14bfdf1df666', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'5039f248-029e-11e4-8f15-c30081ddbb56', E'324554c0-6908-41d9-b773-be54b7889189', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'0b38c83b-c675-4d10-8554-e8758f82f0d7', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'58301250-1260-46c0-b53b-81c9f34c2f2e', E'cb560537-1659-434d-bb7c-5a58faaaf5c8', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'0cba7dde-8dec-4cd7-ba26-b8de6cc80833', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'1f9d3503-fc51-4812-9fe7-966f8094f846', E'a115ec13-b98e-4c2a-af30-daf5e9f7ba5a', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'0d620163-a863-462b-8fe4-dd9c0fccb004', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'3eb7a947-6731-4b89-a7c3-543327a97309', E'3542b1d0-3fbe-45be-9e3a-2c148a2d1928', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'0e1d925d-f1a2-46d4-9ac3-ae1ac8ef0f41', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'820dcbcc-1771-46fd-8238-43e6f7fde9f6', E'f045282e-5acf-43da-b75b-0ef7ab484f3a', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'0e9060d5-1b38-42db-9765-cddb215db535', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'98fb9179-03ff-4a46-a1ef-f71a953a000f', E'701294ff-afff-4750-8bc4-b45027bb2d7c', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'0ea49969-f779-476b-a4d5-69318ab4ae2f', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'02f9998b-6124-4810-ba01-029de572a492', E'98fb9179-03ff-4a46-a1ef-f71a953a000f', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'114e5438-8c18-4ac9-ba03-17974adea65d', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'3eb7a947-6731-4b89-a7c3-543327a97309', E'd93f5ba1-1d5b-46c5-89e5-cd2cb341c592', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'13a3f2f5-62e0-467e-9ad6-e1953040d5d0', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'1f9d3503-fc51-4812-9fe7-966f8094f846', E'b779a952-fa5b-4911-9a85-8c717a8e9ff6', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'16c93205-6b3a-4f5d-875c-64380551f7b1', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'98fb9179-03ff-4a46-a1ef-f71a953a000f', E'b8c40154-0090-47e4-8198-089e97d4623c', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'17da4292-eaef-415d-b3e2-5ac93e3ce06c', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'c02f475d-f81f-4e99-be8b-1e84470c359b', E'e2a250e0-f609-4a4c-ac55-4e41650c1f86', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'1ad8f807-b98f-43c1-aa61-05861729a094', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'77f1081d-9c1e-4279-8563-7df997169e85', E'b1898785-f6cd-4e52-b7d1-dedaa476ebf9', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'1f399000-56d1-4af7-ad4f-93f72d5ab8ac', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'e2a250e0-f609-4a4c-ac55-4e41650c1f86', E'05b17bf4-7110-4597-ad6d-25b1e5d05636', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'20ea4674-200d-45a0-8170-932376c6ac0a', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'1f9d3503-fc51-4812-9fe7-966f8094f846', E'05b17bf4-7110-4597-ad6d-25b1e5d05636', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'266ea77e-2239-458e-8aea-520dc75b73c3', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'98fb9179-03ff-4a46-a1ef-f71a953a000f', E'92410955-a32f-41ee-ac93-095b46a4f117', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'272ec718-e0d8-4d4a-a795-7f90047983e6', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'cb560537-1659-434d-bb7c-5a58faaaf5c8', E'087ff99c-6e84-4ce2-b373-a675c0259e52', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'284bcd0a-bd9a-42ef-af18-ef9ae91e0268', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'162d06d4-eabe-40fc-8a6a-00aa86e987f0', E'0c1bf58b-7ba2-4bef-8dd7-2ea0ef7ab7e0', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'2c85c2f8-c443-4bff-b946-cf63d7fdd644', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'4ebd9cb5-cfef-4afe-9481-3f8475887a34', E'd93f5ba1-1d5b-46c5-89e5-cd2cb341c592', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'2d4e1cae-6a0d-40a1-9476-537fa8eabd5e', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'f3c39624-3a43-4734-abe8-6736d7e2622b', E'6ebfc0bd-5d8d-4a02-a02d-d9c0c64170e1', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'2e25c66b-40a4-4543-b939-d865a4a765fa', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'a82d48ad-4321-492a-950e-bb26aa0d51af', E'58301250-1260-46c0-b53b-81c9f34c2f2e', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'3262a145-52be-41ca-a850-7efc7ff884b6', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'791c77bf-44cf-4f37-b528-92d19970a674', E'e9f4a8b0-b857-4c05-8587-6840b40fa385', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'33fc8cf3-824d-4e2b-b7ae-c9cf632aabd5', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'3eb7a947-6731-4b89-a7c3-543327a97309', E'e9f4a8b0-b857-4c05-8587-6840b40fa385', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'3423efa3-190b-4a99-973e-e8165349a165', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'a115ec13-b98e-4c2a-af30-daf5e9f7ba5a', E'791c77bf-44cf-4f37-b528-92d19970a674', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'3a0c8520-1952-4a72-a5b5-f36e90dbaf61', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'e32bda0d-35cd-428a-b4b5-59c232fdc972', E'58301250-1260-46c0-b53b-81c9f34c2f2e', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'3b7f7436-a7ee-4391-8709-ff18329c3be5', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'b8c40154-0090-47e4-8198-089e97d4623c', E'087ff99c-6e84-4ce2-b373-a675c0259e52', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'40eee88f-8e80-445c-b92e-2662fb90fcf3', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'e2a250e0-f609-4a4c-ac55-4e41650c1f86', E'bd317461-a7b9-482e-b958-49d08a5855c6', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'40f253ab-666a-4dd7-8014-4d852c9cc074', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'29578006-81dc-412b-899d-fe34064cd009', E'b2d9a351-ce3c-45ae-86ee-066ee15b6b25', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'431e4167-2772-44b0-a1f1-faf9a37d33d4', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'77f1081d-9c1e-4279-8563-7df997169e85', E'd90493bc-195a-4fd9-b7b7-b51de5d891c5', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'4518fe67-4512-4c80-8728-de3aebef5382', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'3542b1d0-3fbe-45be-9e3a-2c148a2d1928', E'77f1081d-9c1e-4279-8563-7df997169e85', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'4d986dee-d2e4-4c64-b6ce-60d8f7191fa3', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'd082f06d-b4f8-4661-b82c-f367b76a1c6d', E'1f9d3503-fc51-4812-9fe7-966f8094f846', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'4dc99804-cbee-4e95-b022-cd3b8f4fb1fe', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'027dd4cb-0be8-45d3-8e66-62712ba180a1', E'f24e6fa9-a29c-4fdd-bc99-47bbab97643e', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'521bd274-3829-42c2-86a5-725abd9136d5', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'b779a952-fa5b-4911-9a85-8c717a8e9ff6', E'791c77bf-44cf-4f37-b528-92d19970a674', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'55480682-5015-4c83-acc6-d3a029ab7a50', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'027dd4cb-0be8-45d3-8e66-62712ba180a1', E'daab27ac-a80b-40ec-bfc5-59c1b4c7340f', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'6169e305-2331-4403-9fd4-dea636082ec6', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'324554c0-6908-41d9-b773-be54b7889189', E'e32bda0d-35cd-428a-b4b5-59c232fdc972', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'63d3516a-d337-40c5-92fd-e2f5f1b1debe', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'f24e6fa9-a29c-4fdd-bc99-47bbab97643e', E'98fb9179-03ff-4a46-a1ef-f71a953a000f', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'6506883a-c700-45d8-a830-0fc4d8535d34', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'4c4819bd-388a-4705-9974-103efe1c74f3', E'3542b1d0-3fbe-45be-9e3a-2c148a2d1928', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'67e00d48-e4a8-4fb7-bcdc-f5025ec891aa', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'e2a250e0-f609-4a4c-ac55-4e41650c1f86', E'f3c39624-3a43-4734-abe8-6736d7e2622b', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'681cd54c-c590-4257-aa8a-0386d892dae6', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'bd317461-a7b9-482e-b958-49d08a5855c6', E'a82d48ad-4321-492a-950e-bb26aa0d51af', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'6aa6a7f8-63a6-4cf1-b2f5-532d84a5cf06', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'd93f5ba1-1d5b-46c5-89e5-cd2cb341c592', E'19e8f588-5b9a-4f81-9fb5-ddbf7aaaedef', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'6ec88faf-b1bd-4e31-a863-f500247d468c', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'cb560537-1659-434d-bb7c-5a58faaaf5c8', E'c1a3330b-0393-4834-8c50-505d662974db', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'7045a74f-fafb-4bb3-ad74-f1a733723e97', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'19e8f588-5b9a-4f81-9fb5-ddbf7aaaedef', E'bf3acc9d-d1a3-4aed-8c12-4630adf16c7d', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'751fd8e2-40ae-40e7-adf7-bc0829234feb', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'b2d9a351-ce3c-45ae-86ee-066ee15b6b25', E'29578006-81dc-412b-899d-fe34064cd009', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'7748b588-83b0-4761-8d49-c03bdf50a5f9', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'cb560537-1659-434d-bb7c-5a58faaaf5c8', E'324554c0-6908-41d9-b773-be54b7889189', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'7754d2a1-298e-4aaa-86a4-d3efceec73d1', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'd90493bc-195a-4fd9-b7b7-b51de5d891c5', E'3eb7a947-6731-4b89-a7c3-543327a97309', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'77912748-dbdb-4bec-acf0-0e060b42ba65', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'29578006-81dc-412b-899d-fe34064cd009', E'44aa313b-42ef-4a2c-870f-ee2b35609965', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'7e00ebd4-a726-4769-a528-003cf3e1bfc1', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'05b17bf4-7110-4597-ad6d-25b1e5d05636', E'a115ec13-b98e-4c2a-af30-daf5e9f7ba5a', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'81c53f7a-be82-4e44-8e29-d3fb7dbe9388', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'6ebfc0bd-5d8d-4a02-a02d-d9c0c64170e1', E'046e71c9-0d94-4cb9-9804-be8ec68fdaf6', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'85bbb43c-8c80-41a9-8f30-c6779aca876e', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'e2a250e0-f609-4a4c-ac55-4e41650c1f86', E'd082f06d-b4f8-4661-b82c-f367b76a1c6d', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'8d598f01-39b6-442b-86e0-2ca03280fe3f', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'02f9998b-6124-4810-ba01-029de572a492', E'98fb9179-03ff-4a46-a1ef-f71a953a000f', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'8f1cd564-1356-4046-9683-562a78395c56', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'4ebd9cb5-cfef-4afe-9481-3f8475887a34', NULL, True, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'8f69d836-bdd7-4049-acdf-80a6ff60eab5', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'820dcbcc-1771-46fd-8238-43e6f7fde9f6', E'bd317461-a7b9-482e-b958-49d08a5855c6', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'8faf268e-b3ee-4ced-bb05-25fab92e23ae', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'c02f475d-f81f-4e99-be8b-1e84470c359b', E'701294ff-afff-4750-8bc4-b45027bb2d7c', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'95ee5141-924a-4c7b-bdac-bb5e7f17ec20', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'701294ff-afff-4750-8bc4-b45027bb2d7c', E'c02f475d-f81f-4e99-be8b-1e84470c359b', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'9926b7d0-0c10-4852-aa88-abf65a590071', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'0c1bf58b-7ba2-4bef-8dd7-2ea0ef7ab7e0', E'bf3acc9d-d1a3-4aed-8c12-4630adf16c7d', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'9ad99dc7-872c-477c-80fa-42778c67e45b', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'be883873-03c0-401e-9b9b-945b61902a44', E'd90493bc-195a-4fd9-b7b7-b51de5d891c5', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'a26f0aa3-965e-490f-8723-352b7b7fd7c3', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'b1898785-f6cd-4e52-b7d1-dedaa476ebf9', E'e2a250e0-f609-4a4c-ac55-4e41650c1f86', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'a581ed77-eada-4b3a-bb0f-9a30602eaab2', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'027dd4cb-0be8-45d3-8e66-62712ba180a1', E'44aa313b-42ef-4a2c-870f-ee2b35609965', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'a85869b8-912b-4220-a88c-2da3b050443f', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'98fb9179-03ff-4a46-a1ef-f71a953a000f', E'bfa0d089-45ac-4e3d-b138-3317990d68aa', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'abd3215a-0b8d-45cb-b2b2-96bf19cbbf3b', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'ee28f184-4ffb-4c9a-bc4d-109ef94f740d', E'b2d9a351-ce3c-45ae-86ee-066ee15b6b25', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'b2bcc7cb-9d10-4f2f-b77c-d8b27bb6ffe2', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'e2a250e0-f609-4a4c-ac55-4e41650c1f86', E'3fc5a6f4-6d44-4353-8147-3c557e57d848', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'b4e6131a-7efc-446d-8b65-3dca734ba8e5', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'5039f248-029e-11e4-8f15-c30081ddbb56', E'162d06d4-eabe-40fc-8a6a-00aa86e987f0', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'b549c7ff-1fde-4fce-91e8-17393839854b', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'3fc5a6f4-6d44-4353-8147-3c557e57d848', E'd082f06d-b4f8-4661-b82c-f367b76a1c6d', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'bb9cd8d3-0f2e-41f7-9625-77cf6c74321f', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'e2a250e0-f609-4a4c-ac55-4e41650c1f86', E'1f9d3503-fc51-4812-9fe7-966f8094f846', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'bd9a01eb-2dd4-4a67-8939-7c33ae143110', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'701294ff-afff-4750-8bc4-b45027bb2d7c', E'b1898785-f6cd-4e52-b7d1-dedaa476ebf9', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'cea787a1-cf03-4d77-bf4e-9d5f3cc20dde', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'daab27ac-a80b-40ec-bfc5-59c1b4c7340f', E'f24e6fa9-a29c-4fdd-bc99-47bbab97643e', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'ceb6d8db-9404-4937-a9aa-b37528e51493', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'ee28f184-4ffb-4c9a-bc4d-109ef94f740d', E'02f9998b-6124-4810-ba01-029de572a492', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'd2f1dfda-7a03-46b4-98c2-22765b032917', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'92410955-a32f-41ee-ac93-095b46a4f117', E'046e71c9-0d94-4cb9-9804-be8ec68fdaf6', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'd4980f47-0b5a-4b4a-aa0d-778615a2d1c5', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'be883873-03c0-401e-9b9b-945b61902a44', E'c02f475d-f81f-4e99-be8b-1e84470c359b', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'd6689413-e0f6-40c4-bfad-e0302a596a6b', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'bfa0d089-45ac-4e3d-b138-3317990d68aa', E'f3c39624-3a43-4734-abe8-6736d7e2622b', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'd84ab2c2-69de-47d5-9c14-6d30e94c6175', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'cb560537-1659-434d-bb7c-5a58faaaf5c8', E'b8c40154-0090-47e4-8198-089e97d4623c', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'd8ef65df-70de-423d-8aff-b712fd650691', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'c1a3330b-0393-4834-8c50-505d662974db', E'820dcbcc-1771-46fd-8238-43e6f7fde9f6', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'ddc8d545-beee-4c48-95fc-2e2b4897d9ce', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'087ff99c-6e84-4ce2-b373-a675c0259e52', E'e2a250e0-f609-4a4c-ac55-4e41650c1f86', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'de0ff0c1-5420-4e2f-b7bf-68b39df9a94a', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'e9f4a8b0-b857-4c05-8587-6840b40fa385', E'be883873-03c0-401e-9b9b-945b61902a44', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'e1b4fa56-86a5-47db-979b-ec1a00f23643', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'44aa313b-42ef-4a2c-870f-ee2b35609965', E'daab27ac-a80b-40ec-bfc5-59c1b4c7340f', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'e43c9132-93ae-412c-915f-cddcc253729e', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'046e71c9-0d94-4cb9-9804-be8ec68fdaf6', E'92410955-a32f-41ee-ac93-095b46a4f117', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'ec59561b-8d5e-42b9-81ed-820559408c58', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'046e71c9-0d94-4cb9-9804-be8ec68fdaf6', E'bfa0d089-45ac-4e3d-b138-3317990d68aa', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'f1c0175a-38b0-408b-8501-d5d1f78036da', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'046e71c9-0d94-4cb9-9804-be8ec68fdaf6', E'f045282e-5acf-43da-b75b-0ef7ab484f3a', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'f59db761-cd3c-45a4-8dba-9e7b4e3824b1', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'e32bda0d-35cd-428a-b4b5-59c232fdc972', E'5039f248-029e-11e4-8f15-c30081ddbb56', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'f792054d-9e74-4726-8d9e-599ea2aa84e7', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'bf3acc9d-d1a3-4aed-8c12-4630adf16c7d', E'4ebd9cb5-cfef-4afe-9481-3f8475887a34', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'f994c1a7-7abe-4d91-b868-db438b962dbc', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'be883873-03c0-401e-9b9b-945b61902a44', E'6ebfc0bd-5d8d-4a02-a02d-d9c0c64170e1', NULL, NULL, False);

INSERT INTO public."WorkflowHierarchyTemplate" ("WorkflowHierarchyTemplateID", "WorkflowTransistionTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ChildComponentID", "ParentComponentID", "IsTransistionStart", "IsTranistionEnd", "IsChildDependentOnParent")
VALUES (E'fe37aacd-5a8e-4f4d-8ad7-596f64077b35', E'06e5dd3d-524a-456f-afec-9bde6c0d3e68', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'4ebd9cb5-cfef-4afe-9481-3f8475887a34', E'162d06d4-eabe-40fc-8a6a-00aa86e987f0', NULL, NULL, False);


/* Data for the 'public.WorkflowTreeStructureTemplate' table  (Records 1 - 14) */

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'33bf299a-334e-11e4-9d7a-1f9d2ac4f73b', E'060729a1-56c2-489c-9c45-78064c62997a', 1, E'Safe Move Scheme Sign-Up', E'Safe Move Scheme Sign-Up', 1, E'0', E'1', E'0', NULL, NULL, NULL, 1);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'33bda318-334e-11e4-b285-638ab6bc42bb', E'060729a1-56c2-489c-9c45-78064c62997a', 1, E'Start', E'Start', 2, E'0', E'1', E'0', E'33bf299a-334e-11e4-9d7a-1f9d2ac4f73b', NULL, NULL, 1);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'33bf0294-334e-11e4-a06f-6399346bd702', E'060729a1-56c2-489c-9c45-78064c62997a', 1, E'Search', E'Search', 2, E'0', E'1', E'0',  E'33bf299a-334e-11e4-9d7a-1f9d2ac4f73b', NULL, NULL, 2);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'33bf0294-334e-11e4-9328-ff243657970a', E'060729a1-56c2-489c-9c45-78064c62997a', 1, E'Stage Two', E'Stage Two', 3, E'0', E'1', E'0',  E'33bda318-334e-11e4-b285-638ab6bc42bb', NULL, NULL, 2);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'33bf50a0-334e-11e4-83e9-b34d370cab4f', E'060729a1-56c2-489c-9c45-78064c62997a', 1, E'Stage One', E'Stage One', 3, E'0', E'1', E'0', E'33bda318-334e-11e4-b285-638ab6bc42bb', NULL, NULL, 1);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'33bda318-334e-11e4-a55d-d31f8dde6828', E'060729a1-56c2-489c-9c45-78064c62997a', 1, E'Branches and Users Setup', E'Branches and Users Setup', 4, E'1', E'1', E'0', E'33bf0294-334e-11e4-9328-ff243657970a', NULL, NULL, 1);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'33bdca28-334e-11e4-82ff-57727c8eb07b', E'060729a1-56c2-489c-9c45-78064c62997a', 1, E'Payment', E'Payment', 4, E'1', E'1', E'0', E'33bf50a0-334e-11e4-83e9-b34d370cab4f', NULL, NULL, 7);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'33bdca28-334e-11e4-96f9-1ff1266eed1c', E'060729a1-56c2-489c-9c45-78064c62997a', 1, E'Firm Details', E'Firm Details', 4, E'1', E'1', E'0', E'33bf50a0-334e-11e4-83e9-b34d370cab4f', NULL, NULL, 4);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'33be3f4e-334e-11e4-a912-43a6005611e0', E'060729a1-56c2-489c-9c45-78064c62997a', 1, E'Personal Details', E'Personal Details', 4, E'1', E'1', E'0',E'33bf50a0-334e-11e4-83e9-b34d370cab4f', NULL, NULL, 3);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'33be6654-334e-11e4-ba4f-73140b8ce686', E'060729a1-56c2-489c-9c45-78064c62997a', 1, E'Firm Preference', E'Firm Preference', 4, E'1', E'1', E'0',E'33bf50a0-334e-11e4-83e9-b34d370cab4f', NULL, NULL, 5);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'33be8d64-334e-11e4-b5b3-63565a03c743', E'060729a1-56c2-489c-9c45-78064c62997a', 1, E'Terms & Conditions', E'Terms & Conditions', 4, E'1', E'1', E'0', E'33bf50a0-334e-11e4-83e9-b34d370cab4f', NULL, NULL, 2);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'33beb474-334e-11e4-a181-6335197ab2ce', E'060729a1-56c2-489c-9c45-78064c62997a', 1, E'Next Steps', E'Next Steps', 4, E'1', E'1', E'0', E'33bf50a0-334e-11e4-83e9-b34d370cab4f', NULL, NULL, 1);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'33beb474-334e-11e4-a228-cfbc796bc5ce', E'060729a1-56c2-489c-9c45-78064c62997a', 1, E'Firm Payment', E'Firm Payment', 4, E'1', E'1', E'0',E'33bf50a0-334e-11e4-83e9-b34d370cab4f', NULL, NULL, 6);

INSERT INTO public."WorkflowTreeStructureTemplate" ("WorkflowTreeStructureTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "Name", "Description", "Level", "IsLeafNode", "IsActive", "IsDeleted", "ParentID", "InterfacePanelTemplateID", "InterfacePanelTemplateVersionNumber", "ItemOrder")
VALUES (E'33bedb84-334e-11e4-9610-a78413bd0ca1', E'060729a1-56c2-489c-9c45-78064c62997a', 1, E'ID Check', E'ID Check', 4, E'1', E'1', E'0',E'33bf50a0-334e-11e4-83e9-b34d370cab4f', NULL, NULL, 8);

/* Data for the 'public.WorkflowTreeStructureActionTemplate' table  (Records 1 - 19) */

INSERT INTO public."WorkflowTreeStructureActionTemplate" ("WorkflowTreeStructureActionTemplateID", "WorkflowTreeStructureTemplateID", "WorkflowActionTemplateID", "IsVisible", "IsActive", "IsDeleted", "ConditionString")
VALUES (E'785ad6fe-3cda-11e4-834c-bb6328755452', E'33be8d64-334e-11e4-b5b3-63565a03c743', E'0c1bf58b-7ba2-4bef-8dd7-2ea0ef7ab7e0', False, True, False, E'IAmCO:True');

INSERT INTO public."WorkflowTreeStructureActionTemplate" ("WorkflowTreeStructureActionTemplateID", "WorkflowTreeStructureTemplateID", "WorkflowActionTemplateID", "IsVisible", "IsActive", "IsDeleted", "ConditionString")
VALUES (E'785b251e-3cda-11e4-a035-4fb002331bc2', E'33be8d64-334e-11e4-b5b3-63565a03c743', E'19e8f588-5b9a-4f81-9fb5-ddbf7aaaedef', False, True, False, E'IAmCO:False');

INSERT INTO public."WorkflowTreeStructureActionTemplate" ("WorkflowTreeStructureActionTemplateID", "WorkflowTreeStructureTemplateID", "WorkflowActionTemplateID", "IsVisible", "IsActive", "IsDeleted", "ConditionString")
VALUES (E'785b4c2e-3cda-11e4-aa6d-63647811f535', E'33bdca28-334e-11e4-96f9-1ff1266eed1c', E'77f1081d-9c1e-4279-8563-7df997169e85', False, True, False, E'IAmCO:False,Editable:True');

INSERT INTO public."WorkflowTreeStructureActionTemplate" ("WorkflowTreeStructureActionTemplateID", "WorkflowTreeStructureTemplateID", "WorkflowActionTemplateID", "IsVisible", "IsActive", "IsDeleted", "ConditionString")
VALUES (E'785b7334-3cda-11e4-87b9-5ba70e6e3c43', E'33bdca28-334e-11e4-96f9-1ff1266eed1c', E'e32bda0d-35cd-428a-b4b5-59c232fdc972', False, True, False, E'IAmCO:True');

INSERT INTO public."WorkflowTreeStructureActionTemplate" ("WorkflowTreeStructureActionTemplateID", "WorkflowTreeStructureTemplateID", "WorkflowActionTemplateID", "IsVisible", "IsActive", "IsDeleted", "ConditionString")
VALUES (E'785be85a-3cda-11e4-a31e-4f61156933f6', E'33bdca28-334e-11e4-82ff-57727c8eb07b', E'046e71c9-0d94-4cb9-9804-be8ec68fdaf6', False, True, False, E'PaymentWithPreAuth:True');

INSERT INTO public."WorkflowTreeStructureActionTemplate" ("WorkflowTreeStructureActionTemplateID", "WorkflowTreeStructureTemplateID", "WorkflowActionTemplateID", "IsVisible", "IsActive", "IsDeleted", "ConditionString")
VALUES (E'785a61c4-3cda-11e4-adcd-3be2ba257eb0', E'33bda318-334e-11e4-a55d-d31f8dde6828', E'29578006-81dc-412b-899d-fe34064cd009', True, True, False, NULL);

INSERT INTO public."WorkflowTreeStructureActionTemplate" ("WorkflowTreeStructureActionTemplateID", "WorkflowTreeStructureTemplateID", "WorkflowActionTemplateID", "IsVisible", "IsActive", "IsDeleted", "ConditionString")
VALUES (E'785a88e8-3cda-11e4-a096-a360ac2203ab', E'33bda318-334e-11e4-b285-638ab6bc42bb', NULL, True, True, False, NULL);

INSERT INTO public."WorkflowTreeStructureActionTemplate" ("WorkflowTreeStructureActionTemplateID", "WorkflowTreeStructureTemplateID", "WorkflowActionTemplateID", "IsVisible", "IsActive", "IsDeleted", "ConditionString")
VALUES (E'785aaff8-3cda-11e4-8b39-af9e6c8ac4ea', E'33beb474-334e-11e4-a181-6335197ab2ce', E'4ebd9cb5-cfef-4afe-9481-3f8475887a34', True, True, False, NULL);

INSERT INTO public."WorkflowTreeStructureActionTemplate" ("WorkflowTreeStructureActionTemplateID", "WorkflowTreeStructureTemplateID", "WorkflowActionTemplateID", "IsVisible", "IsActive", "IsDeleted", "ConditionString")
VALUES (E'785aaff8-3cda-11e4-9c30-2379d3ec0209', E'33bf299a-334e-11e4-9d7a-1f9d2ac4f73b', NULL, True, True, False, NULL);

INSERT INTO public."WorkflowTreeStructureActionTemplate" ("WorkflowTreeStructureActionTemplateID", "WorkflowTreeStructureTemplateID", "WorkflowActionTemplateID", "IsVisible", "IsActive", "IsDeleted", "ConditionString")
VALUES (E'785ad6fe-3cda-11e4-9af7-ef4002127631', E'33bf50a0-334e-11e4-83e9-b34d370cab4f', NULL, True, True, False, NULL);

INSERT INTO public."WorkflowTreeStructureActionTemplate" ("WorkflowTreeStructureActionTemplateID", "WorkflowTreeStructureTemplateID", "WorkflowActionTemplateID", "IsVisible", "IsActive", "IsDeleted", "ConditionString")
VALUES (E'785afe0e-3cda-11e4-800c-ff9f64c82127', E'33bf0294-334e-11e4-a06f-6399346bd702', E'ee28f184-4ffb-4c9a-bc4d-109ef94f740d', True, True, False, NULL);

INSERT INTO public."WorkflowTreeStructureActionTemplate" ("WorkflowTreeStructureActionTemplateID", "WorkflowTreeStructureTemplateID", "WorkflowActionTemplateID", "IsVisible", "IsActive", "IsDeleted", "ConditionString")
VALUES (E'785afe0e-3cda-11e4-accb-e7ad93e2ee37', E'33bf0294-334e-11e4-9328-ff243657970a', E'027dd4cb-0be8-45d3-8e66-62712ba180a1', False, True, False, E'IAmCO:True');

INSERT INTO public."WorkflowTreeStructureActionTemplate" ("WorkflowTreeStructureActionTemplateID", "WorkflowTreeStructureTemplateID", "WorkflowActionTemplateID", "IsVisible", "IsActive", "IsDeleted", "ConditionString")
VALUES (E'785b251e-3cda-11e4-8580-83f97e11c53f', E'33be3f4e-334e-11e4-a912-43a6005611e0', E'3eb7a947-6731-4b89-a7c3-543327a97309', True, True, False, NULL);

INSERT INTO public."WorkflowTreeStructureActionTemplate" ("WorkflowTreeStructureActionTemplateID", "WorkflowTreeStructureTemplateID", "WorkflowActionTemplateID", "IsVisible", "IsActive", "IsDeleted", "ConditionString")
VALUES (E'785b4c2e-3cda-11e4-afe1-fb68903632ef', E'33bdca28-334e-11e4-96f9-1ff1266eed1c', E'be883873-03c0-401e-9b9b-945b61902a44', True, True, False, E'IAmCO:False,Editable:False');

INSERT INTO public."WorkflowTreeStructureActionTemplate" ("WorkflowTreeStructureActionTemplateID", "WorkflowTreeStructureTemplateID", "WorkflowActionTemplateID", "IsVisible", "IsActive", "IsDeleted", "ConditionString")
VALUES (E'785b7334-3cda-11e4-864c-d780272713ab', E'33be6654-334e-11e4-ba4f-73140b8ce686', E'cb560537-1659-434d-bb7c-5a58faaaf5c8', True, True, False, NULL);

INSERT INTO public."WorkflowTreeStructureActionTemplate" ("WorkflowTreeStructureActionTemplateID", "WorkflowTreeStructureTemplateID", "WorkflowActionTemplateID", "IsVisible", "IsActive", "IsDeleted", "ConditionString")
VALUES (E'785b9a44-3cda-11e4-967d-b75503d2ded3', E'33beb474-334e-11e4-a228-cfbc796bc5ce', E'a82d48ad-4321-492a-950e-bb26aa0d51af', False, True, False, NULL);

INSERT INTO public."WorkflowTreeStructureActionTemplate" ("WorkflowTreeStructureActionTemplateID", "WorkflowTreeStructureTemplateID", "WorkflowActionTemplateID", "IsVisible", "IsActive", "IsDeleted", "ConditionString")
VALUES (E'785bc15e-3cda-11e4-8955-4bf173e94214', E'33bdca28-334e-11e4-82ff-57727c8eb07b', E'e2a250e0-f609-4a4c-ac55-4e41650c1f86', True, True, False, E'PaymentWithPreAuth:False');

INSERT INTO public."WorkflowTreeStructureActionTemplate" ("WorkflowTreeStructureActionTemplateID", "WorkflowTreeStructureTemplateID", "WorkflowActionTemplateID", "IsVisible", "IsActive", "IsDeleted", "ConditionString")
VALUES (E'785bc15e-3cda-11e4-9b93-c7f219338c6c', E'33beb474-334e-11e4-a228-cfbc796bc5ce', E'820dcbcc-1771-46fd-8238-43e6f7fde9f6', False, True, False, NULL);

INSERT INTO public."WorkflowTreeStructureActionTemplate" ("WorkflowTreeStructureActionTemplateID", "WorkflowTreeStructureTemplateID", "WorkflowActionTemplateID", "IsVisible", "IsActive", "IsDeleted", "ConditionString")
VALUES (E'785be85a-3cda-11e4-a795-df0b42728729', E'33bedb84-334e-11e4-9610-a78413bd0ca1', E'98fb9179-03ff-4a46-a1ef-f71a953a000f', True, True, False, NULL);


/* Data for the 'public.WorkflowParameterTemplate' table  (Records 1 - 4) */

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'81a5148e-0785-11e4-accf-bf4151888ec2', E'Action', E'Action', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'System.String', E'TnCExternalInviteToCOWorkflowAction');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'6ef9fe9e-0785-11e4-9c47-fb1ed9870a3a', E'Action', E'Action', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'System.String', E'ExternalInvite');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'4fc4344a-0785-11e4-8e59-4b5b4c5ddcaa', E'Controller', E'Controller', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'System.String', E'ExternalInvite');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'07c5c140-0785-11e4-9f8e-0f46dd2158a5', E'Area', E'Area', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'System.String', E'Workflow');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'b670c448-0e7d-11e4-9211-03c6b7c83eba', E'WorkflowInstanceStatusID', E'workflow instance status new', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'System.String', E'New');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'38e354d0-10dc-11e4-8317-fff4d9e85146', E'WorkflowInstanceStatusID', E'Workflow instance status Complete', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'System.String', E'Complete');

INSERT INTO public."WorkflowParameterTemplate" ("WorkflowParameterTemplateID", "Name", "Description", "WorkflowTemplateID", "WorkflowTemplateVersionNumber", "ObjectType", "ObjectValue")
VALUES (E'435e3966-10dc-11e4-9540-5fbaa6528ce5', E'WorkflowInstanceStatusID', E'Workflow instance status In progress', WorkflowTemplateID, WorkflowTemplateVersionNumber, E'System.String', E'InProgress');


/* Data for the 'public.WorkflowActionParameterTemplate' table  (Records 1 - 6) */

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'0c1bf58b-7ba2-4bef-8dd7-2ea0ef7ab7e0', E'07c5c140-0785-11e4-9f8e-0f46dd2158a5', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'0c1bf58b-7ba2-4bef-8dd7-2ea0ef7ab7e0', E'4fc4344a-0785-11e4-8e59-4b5b4c5ddcaa', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'0c1bf58b-7ba2-4bef-8dd7-2ea0ef7ab7e0', E'81a5148e-0785-11e4-accf-bf4151888ec2', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'4ebd9cb5-cfef-4afe-9481-3f8475887a34', E'07c5c140-0785-11e4-9f8e-0f46dd2158a5', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'4ebd9cb5-cfef-4afe-9481-3f8475887a34', E'4fc4344a-0785-11e4-8e59-4b5b4c5ddcaa', WorkflowTemplateID, WorkflowTemplateVersionNumber);

INSERT INTO public."WorkflowActionParameterTemplate" ("WorkflowActionTemplateID", "WorkflowParameterTemplateID", "WorkflowTemplateID", "WorkflowTemplateVersionNumber")
VALUES (E'4ebd9cb5-cfef-4afe-9481-3f8475887a34', E'81a5148e-0785-11e4-accf-bf4151888ec2', WorkflowTemplateID, WorkflowTemplateVersionNumber);

-- promote wf
perform "fn_PromoteWorkflowTemplate"(WorkflowTemplateID,WorkflowTemplateVersionNumber);

END $$;