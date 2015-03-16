/* Data for the 'public.ServiceInterface' table  (Records 1 - 1) */

INSERT INTO public."ServiceInterface" ("ServiceInterfaceID", "Name", "Description", "ServiceInterfaceTypeID", "ServiceInterfaceCategoryID", "IsActive", "IsDeleted")
VALUES (E'6011f2c6-6359-11e4-b290-73fbd28b96a0', E'Land Registry', NULL, 2200001, NULL, True, False);

/* Data for the 'public.ServiceDefinition' table  (Records 1 - 26) */

INSERT INTO public."ServiceDefinition" ("ServiceDefinitionID", "ServiceDefinitionTypeID", "ServiceDefinitionCategoryID", "Name", "Description", "ServiceInterfaceID", "IsPollingService", "NumberOfRetriesPerCall", "ServiceEngineObjectName", "ServiceDefinitionObjectName", "ServiceMutatorObjectName", "RetryPeriodPerCallInMinutes", "RetryFailedCalls")
VALUES (E'2a2d366a-635a-11e4-93fe-d31cbd0bb48d', 2200002, NULL, E'DaylistEnquiry20', NULL, E'6011f2c6-6359-11e4-b290-73fbd28b96a0', False, 3, NULL, NULL, NULL, 180, True);

INSERT INTO public."ServiceDefinition" ("ServiceDefinitionID", "ServiceDefinitionTypeID", "ServiceDefinitionCategoryID", "Name", "Description", "ServiceInterfaceID", "IsPollingService", "NumberOfRetriesPerCall", "ServiceEngineObjectName", "ServiceDefinitionObjectName", "ServiceMutatorObjectName", "RetryPeriodPerCallInMinutes", "RetryFailedCalls")
VALUES (E'2a2e6eea-635a-11e4-a49c-7f0e96e3dd94', 2200002, NULL, E'DaylistEnquiryPoll20', NULL, E'6011f2c6-6359-11e4-b290-73fbd28b96a0', True, 3, NULL, NULL, NULL, 180, False);

INSERT INTO public."ServiceDefinition" ("ServiceDefinitionID", "ServiceDefinitionTypeID", "ServiceDefinitionCategoryID", "Name", "Description", "ServiceInterfaceID", "IsPollingService", "NumberOfRetriesPerCall", "ServiceEngineObjectName", "ServiceDefinitionObjectName", "ServiceMutatorObjectName", "RetryPeriodPerCallInMinutes", "RetryFailedCalls")
VALUES (E'2a2ebd0a-635a-11e4-bb6b-0f163eafad5e', 2200002, NULL, E'EnquiryByPropertyDescription20', NULL, E'6011f2c6-6359-11e4-b290-73fbd28b96a0', False, 3, E'Bec.TargetFramework.Service.LR.Entities.Engine.EnquiryByPropertyDescriptionEngine20, Bec.TargetFramework.Service.LR.Entities', E'Bec.TargetFramework.Service.LR.Entities.Objects.EnquiryByPropertyDescriptionServiceDefinition20, Bec.TargetFramework.Service.LR.Entities', NULL, 180, True);

INSERT INTO public."ServiceDefinition" ("ServiceDefinitionID", "ServiceDefinitionTypeID", "ServiceDefinitionCategoryID", "Name", "Description", "ServiceInterfaceID", "IsPollingService", "NumberOfRetriesPerCall", "ServiceEngineObjectName", "ServiceDefinitionObjectName", "ServiceMutatorObjectName", "RetryPeriodPerCallInMinutes", "RetryFailedCalls")
VALUES (E'2a2f323a-635a-11e4-a4fc-f7ac1461a0ae', 2200002, NULL, E'EnquiryByPropertyDescriptionPoll20', NULL, E'6011f2c6-6359-11e4-b290-73fbd28b96a0', True, 3, NULL, NULL, NULL, 180, False);

INSERT INTO public."ServiceDefinition" ("ServiceDefinitionID", "ServiceDefinitionTypeID", "ServiceDefinitionCategoryID", "Name", "Description", "ServiceInterfaceID", "IsPollingService", "NumberOfRetriesPerCall", "ServiceEngineObjectName", "ServiceDefinitionObjectName", "ServiceMutatorObjectName", "RetryPeriodPerCallInMinutes", "RetryFailedCalls")
VALUES (E'2a2fa76a-635a-11e4-8816-275e0b99f062', 2200002, NULL, E'BankruptcySearch21', NULL, E'6011f2c6-6359-11e4-b290-73fbd28b96a0', False, 3, NULL, NULL, NULL, 180, True);

INSERT INTO public."ServiceDefinition" ("ServiceDefinitionID", "ServiceDefinitionTypeID", "ServiceDefinitionCategoryID", "Name", "Description", "ServiceInterfaceID", "IsPollingService", "NumberOfRetriesPerCall", "ServiceEngineObjectName", "ServiceDefinitionObjectName", "ServiceMutatorObjectName", "RetryPeriodPerCallInMinutes", "RetryFailedCalls")
VALUES (E'2a300e08-635a-11e4-817c-f76fdab5706d', 2200002, NULL, E'BankruptcySearchPoll21', NULL, E'6011f2c6-6359-11e4-b290-73fbd28b96a0', True, 3, NULL, NULL, NULL, 180, False);

INSERT INTO public."ServiceDefinition" ("ServiceDefinitionID", "ServiceDefinitionTypeID", "ServiceDefinitionCategoryID", "Name", "Description", "ServiceInterfaceID", "IsPollingService", "NumberOfRetriesPerCall", "ServiceEngineObjectName", "ServiceDefinitionObjectName", "ServiceMutatorObjectName", "RetryPeriodPerCallInMinutes", "RetryFailedCalls")
VALUES (E'2a3060e2-635a-11e4-8a45-77c63afe6c9e', 2200002, NULL, E'ChargesFullSearch21', NULL, E'6011f2c6-6359-11e4-b290-73fbd28b96a0', False, 3, NULL, NULL, NULL, 180, True);

INSERT INTO public."ServiceDefinition" ("ServiceDefinitionID", "ServiceDefinitionTypeID", "ServiceDefinitionCategoryID", "Name", "Description", "ServiceInterfaceID", "IsPollingService", "NumberOfRetriesPerCall", "ServiceEngineObjectName", "ServiceDefinitionObjectName", "ServiceMutatorObjectName", "RetryPeriodPerCallInMinutes", "RetryFailedCalls")
VALUES (E'2a30d716-635a-11e4-8df8-8f5d61e6fe68', 2200002, NULL, E'ChargesFullSearchPoll21', NULL, E'6011f2c6-6359-11e4-b290-73fbd28b96a0', True, 3, NULL, NULL, NULL, 180, False);

INSERT INTO public."ServiceDefinition" ("ServiceDefinitionID", "ServiceDefinitionTypeID", "ServiceDefinitionCategoryID", "Name", "Description", "ServiceInterfaceID", "IsPollingService", "NumberOfRetriesPerCall", "ServiceEngineObjectName", "ServiceDefinitionObjectName", "ServiceMutatorObjectName", "RetryPeriodPerCallInMinutes", "RetryFailedCalls")
VALUES (E'2a314c0a-635a-11e4-90ae-b322daf93d9e', 2200002, NULL, E'OfficialCopyTitleKnown21', NULL, E'6011f2c6-6359-11e4-b290-73fbd28b96a0', False, 3, NULL, NULL, NULL, 180, True);

INSERT INTO public."ServiceDefinition" ("ServiceDefinitionID", "ServiceDefinitionTypeID", "ServiceDefinitionCategoryID", "Name", "Description", "ServiceInterfaceID", "IsPollingService", "NumberOfRetriesPerCall", "ServiceEngineObjectName", "ServiceDefinitionObjectName", "ServiceMutatorObjectName", "RetryPeriodPerCallInMinutes", "RetryFailedCalls")
VALUES (E'2a3199ee-635a-11e4-943e-234e8e6b9c9e', 2200002, NULL, E'OfficialCopyTitleKnownPoll21', NULL, E'6011f2c6-6359-11e4-b290-73fbd28b96a0', True, 3, NULL, NULL, NULL, 180, False);

INSERT INTO public."ServiceDefinition" ("ServiceDefinitionID", "ServiceDefinitionTypeID", "ServiceDefinitionCategoryID", "Name", "Description", "ServiceInterfaceID", "IsPollingService", "NumberOfRetriesPerCall", "ServiceEngineObjectName", "ServiceDefinitionObjectName", "ServiceMutatorObjectName", "RetryPeriodPerCallInMinutes", "RetryFailedCalls")
VALUES (E'2a320f28-635a-11e4-b1dc-4fc85b613154', 2200002, NULL, E'OfficialSearchOfPartWithPriority21', NULL, E'6011f2c6-6359-11e4-b290-73fbd28b96a0', False, 3, NULL, NULL, NULL, 180, True);

INSERT INTO public."ServiceDefinition" ("ServiceDefinitionID", "ServiceDefinitionTypeID", "ServiceDefinitionCategoryID", "Name", "Description", "ServiceInterfaceID", "IsPollingService", "NumberOfRetriesPerCall", "ServiceEngineObjectName", "ServiceDefinitionObjectName", "ServiceMutatorObjectName", "RetryPeriodPerCallInMinutes", "RetryFailedCalls")
VALUES (E'2a325d3e-635a-11e4-8176-e3c2f1ba344a', 2200002, NULL, E'OfficialSearchOfPartWithPriorityPoll21', NULL, E'6011f2c6-6359-11e4-b290-73fbd28b96a0', True, 3, NULL, NULL, NULL, 180, False);

INSERT INTO public."ServiceDefinition" ("ServiceDefinitionID", "ServiceDefinitionTypeID", "ServiceDefinitionCategoryID", "Name", "Description", "ServiceInterfaceID", "IsPollingService", "NumberOfRetriesPerCall", "ServiceEngineObjectName", "ServiceDefinitionObjectName", "ServiceMutatorObjectName", "RetryPeriodPerCallInMinutes", "RetryFailedCalls")
VALUES (E'2a32f97e-635a-11e4-836f-d309e7b0e85f', 2200002, NULL, E'OfficialSearchWholeWithPriority21', NULL, E'6011f2c6-6359-11e4-b290-73fbd28b96a0', False, 3, NULL, NULL, NULL, 180, True);

INSERT INTO public."ServiceDefinition" ("ServiceDefinitionID", "ServiceDefinitionTypeID", "ServiceDefinitionCategoryID", "Name", "Description", "ServiceInterfaceID", "IsPollingService", "NumberOfRetriesPerCall", "ServiceEngineObjectName", "ServiceDefinitionObjectName", "ServiceMutatorObjectName", "RetryPeriodPerCallInMinutes", "RetryFailedCalls")
VALUES (E'2a336ec2-635a-11e4-9afd-5f61abf60e9a', 2200002, NULL, E'OfficialSearchWholeWithPriorityPoll21', NULL, E'6011f2c6-6359-11e4-b290-73fbd28b96a0', True, 3, NULL, NULL, NULL, 180, False);

INSERT INTO public."ServiceDefinition" ("ServiceDefinitionID", "ServiceDefinitionTypeID", "ServiceDefinitionCategoryID", "Name", "Description", "ServiceInterfaceID", "IsPollingService", "NumberOfRetriesPerCall", "ServiceEngineObjectName", "ServiceDefinitionObjectName", "ServiceMutatorObjectName", "RetryPeriodPerCallInMinutes", "RetryFailedCalls")
VALUES (E'2a33bcec-635a-11e4-8410-4f3169a594bc', 2200002, NULL, E'OfficialCopyWithSummary21', NULL, E'6011f2c6-6359-11e4-b290-73fbd28b96a0', False, 3, E'Bec.TargetFramework.Service.LR.Entities.Engine.OfficialCopyWithSummaryEngine21, Bec.TargetFramework.Service.LR.Entities', E'Bec.TargetFramework.Service.LR.Entities.Objects.OfficialCopyWithSummaryServiceDefinition21, Bec.TargetFramework.Service.LR.Entities', NULL, 180, True);

INSERT INTO public."ServiceDefinition" ("ServiceDefinitionID", "ServiceDefinitionTypeID", "ServiceDefinitionCategoryID", "Name", "Description", "ServiceInterfaceID", "IsPollingService", "NumberOfRetriesPerCall", "ServiceEngineObjectName", "ServiceDefinitionObjectName", "ServiceMutatorObjectName", "RetryPeriodPerCallInMinutes", "RetryFailedCalls")
VALUES (E'2a343212-635a-11e4-9417-07ca3bfc73a9', 2200002, NULL, E'OfficialCopyWithSummaryPoll21', NULL, E'6011f2c6-6359-11e4-b290-73fbd28b96a0', True, 3, NULL, NULL, NULL, 180, False);

INSERT INTO public."ServiceDefinition" ("ServiceDefinitionID", "ServiceDefinitionTypeID", "ServiceDefinitionCategoryID", "Name", "Description", "ServiceInterfaceID", "IsPollingService", "NumberOfRetriesPerCall", "ServiceEngineObjectName", "ServiceDefinitionObjectName", "ServiceMutatorObjectName", "RetryPeriodPerCallInMinutes", "RetryFailedCalls")
VALUES (E'2a348028-635a-11e4-9462-7b00d7141479', 2200002, NULL, E'SearchOfIndexMap21', NULL, E'6011f2c6-6359-11e4-b290-73fbd28b96a0', False, 3, NULL, NULL, NULL, 180, True);

INSERT INTO public."ServiceDefinition" ("ServiceDefinitionID", "ServiceDefinitionTypeID", "ServiceDefinitionCategoryID", "Name", "Description", "ServiceInterfaceID", "IsPollingService", "NumberOfRetriesPerCall", "ServiceEngineObjectName", "ServiceDefinitionObjectName", "ServiceMutatorObjectName", "RetryPeriodPerCallInMinutes", "RetryFailedCalls")
VALUES (E'2a34ce2a-635a-11e4-bdb6-67974a2cc81b', 2200002, NULL, E'SearchOfIndexMapPoll21', NULL, E'6011f2c6-6359-11e4-b290-73fbd28b96a0', True, 3, NULL, NULL, NULL, 180, False);

INSERT INTO public."ServiceDefinition" ("ServiceDefinitionID", "ServiceDefinitionTypeID", "ServiceDefinitionCategoryID", "Name", "Description", "ServiceInterfaceID", "IsPollingService", "NumberOfRetriesPerCall", "ServiceEngineObjectName", "ServiceDefinitionObjectName", "ServiceMutatorObjectName", "RetryPeriodPerCallInMinutes", "RetryFailedCalls")
VALUES (E'2a354378-635a-11e4-af0a-3fb09ccf6eb7', 2200002, NULL, E'EDocumentRegistration20', NULL, E'6011f2c6-6359-11e4-b290-73fbd28b96a0', False, 3, NULL, NULL, NULL, 180, True);

INSERT INTO public."ServiceDefinition" ("ServiceDefinitionID", "ServiceDefinitionTypeID", "ServiceDefinitionCategoryID", "Name", "Description", "ServiceInterfaceID", "IsPollingService", "NumberOfRetriesPerCall", "ServiceEngineObjectName", "ServiceDefinitionObjectName", "ServiceMutatorObjectName", "RetryPeriodPerCallInMinutes", "RetryFailedCalls")
VALUES (E'2a3591ac-635a-11e4-ada7-7380643ecdf3', 2200002, NULL, E'EDocumentRegistrationPoll20', NULL, E'6011f2c6-6359-11e4-b290-73fbd28b96a0', True, 3, NULL, NULL, NULL, 180, False);

INSERT INTO public."ServiceDefinition" ("ServiceDefinitionID", "ServiceDefinitionTypeID", "ServiceDefinitionCategoryID", "Name", "Description", "ServiceInterfaceID", "IsPollingService", "NumberOfRetriesPerCall", "ServiceEngineObjectName", "ServiceDefinitionObjectName", "ServiceMutatorObjectName", "RetryPeriodPerCallInMinutes", "RetryFailedCalls")
VALUES (E'2a35dfd6-635a-11e4-ae88-e71760833d0e', 2200002, NULL, E'EDocumentAttachment20', NULL, E'6011f2c6-6359-11e4-b290-73fbd28b96a0', False, 3, NULL, NULL, NULL, 180, True);

INSERT INTO public."ServiceDefinition" ("ServiceDefinitionID", "ServiceDefinitionTypeID", "ServiceDefinitionCategoryID", "Name", "Description", "ServiceInterfaceID", "IsPollingService", "NumberOfRetriesPerCall", "ServiceEngineObjectName", "ServiceDefinitionObjectName", "ServiceMutatorObjectName", "RetryPeriodPerCallInMinutes", "RetryFailedCalls")
VALUES (E'2a362dd8-635a-11e4-b728-3721b09f06de', 2200002, NULL, E'EDocumentAttachmentPoll20', NULL, E'6011f2c6-6359-11e4-b290-73fbd28b96a0', True, 3, NULL, NULL, NULL, 180, False);

INSERT INTO public."ServiceDefinition" ("ServiceDefinitionID", "ServiceDefinitionTypeID", "ServiceDefinitionCategoryID", "Name", "Description", "ServiceInterfaceID", "IsPollingService", "NumberOfRetriesPerCall", "ServiceEngineObjectName", "ServiceDefinitionObjectName", "ServiceMutatorObjectName", "RetryPeriodPerCallInMinutes", "RetryFailedCalls")
VALUES (E'2a36a312-635a-11e4-b205-27180409340e', 2200002, NULL, E'EarlyCompletionPoll20', NULL, E'6011f2c6-6359-11e4-b290-73fbd28b96a0', True, 3, NULL, NULL, NULL, 180, False);

INSERT INTO public."ServiceDefinition" ("ServiceDefinitionID", "ServiceDefinitionTypeID", "ServiceDefinitionCategoryID", "Name", "Description", "ServiceInterfaceID", "IsPollingService", "NumberOfRetriesPerCall", "ServiceEngineObjectName", "ServiceDefinitionObjectName", "ServiceMutatorObjectName", "RetryPeriodPerCallInMinutes", "RetryFailedCalls")
VALUES (E'2a36f128-635a-11e4-bc0c-b7ec9430619d', 2200002, NULL, E'OnlineOwnershipVerification10', NULL, E'6011f2c6-6359-11e4-b290-73fbd28b96a0', False, 3, NULL, NULL, NULL, 180, True);

INSERT INTO public."ServiceDefinition" ("ServiceDefinitionID", "ServiceDefinitionTypeID", "ServiceDefinitionCategoryID", "Name", "Description", "ServiceInterfaceID", "IsPollingService", "NumberOfRetriesPerCall", "ServiceEngineObjectName", "ServiceDefinitionObjectName", "ServiceMutatorObjectName", "RetryPeriodPerCallInMinutes", "RetryFailedCalls")
VALUES (E'2a376658-635a-11e4-b5bc-d35aae588435', 2200002, NULL, E'OnlineOwnershipVerificationPoll10', NULL, E'6011f2c6-6359-11e4-b290-73fbd28b96a0', True, 3, NULL, NULL, NULL, 180, False);

INSERT INTO public."ServiceDefinition" ("ServiceDefinitionID", "ServiceDefinitionTypeID", "ServiceDefinitionCategoryID", "Name", "Description", "ServiceInterfaceID", "IsPollingService", "NumberOfRetriesPerCall", "ServiceEngineObjectName", "ServiceDefinitionObjectName", "ServiceMutatorObjectName", "RetryPeriodPerCallInMinutes", "RetryFailedCalls")
VALUES (E'2a37b478-635a-11e4-a3c5-03fc318693f5', 2200002, NULL, E'OutstandingRequests20', NULL, E'6011f2c6-6359-11e4-b290-73fbd28b96a0', False, 3, NULL, NULL, NULL, 180, True);



/* Data for the 'public.ServiceDefinitionDetail' table  (Records 1 - 26) */

INSERT INTO public."ServiceDefinitionDetail" ("ServiceDefinitionDetailID", "EnvironmentName", "ServicePartialURL", "IsActive", "IsDeleted", "ServiceDefinitionID", "ServerURL")
VALUES (E'b2eb7f42-635b-11e4-ab34-53b7a7376ee0', E'DEV', E'/EDocumentRegistrationV2_0WebService?wsdl', True, False, E'2a354378-635a-11e4-af0a-3fb09ccf6eb7', E'https://bgtest.landregistry.gov.uk/b2b/ECDRS_StubService');

INSERT INTO public."ServiceDefinitionDetail" ("ServiceDefinitionDetailID", "EnvironmentName", "ServicePartialURL", "IsActive", "IsDeleted", "ServiceDefinitionID", "ServerURL")
VALUES (E'b2ebf47c-635b-11e4-adb3-c3946e962e3e', E'DEV', E'/EDocumentRegistrationV2_0PollRequestWebService?wsdl', True, False, E'2a3591ac-635a-11e4-ada7-7380643ecdf3', E'https://bgtest.landregistry.gov.uk/b2b/ECDRS_StubService');

INSERT INTO public."ServiceDefinitionDetail" ("ServiceDefinitionDetailID", "EnvironmentName", "ServicePartialURL", "IsActive", "IsDeleted", "ServiceDefinitionID", "ServerURL")
VALUES (E'b2ec69a2-635b-11e4-a11c-c72b49670531', E'DEV', E'/AttachmentV2_0WebService?wsdl', True, False, E'2a35dfd6-635a-11e4-ae88-e71760833d0e', E'https://bgtest.landregistry.gov.uk/b2b/ECDRS_StubService');

INSERT INTO public."ServiceDefinitionDetail" ("ServiceDefinitionDetailID", "EnvironmentName", "ServicePartialURL", "IsActive", "IsDeleted", "ServiceDefinitionID", "ServerURL")
VALUES (E'b2ee0276-635b-11e4-a906-bb3a39b382c5', E'DEV', E'/AttachmentV2_0PollRequestWebService?wsdl', True, False, E'2a362dd8-635a-11e4-b728-3721b09f06de', E'https://bgtest.landregistry.gov.uk/b2b/ECDRS_StubService');

INSERT INTO public."ServiceDefinitionDetail" ("ServiceDefinitionDetailID", "EnvironmentName", "ServicePartialURL", "IsActive", "IsDeleted", "ServiceDefinitionID", "ServerURL")
VALUES (E'b2ee63f6-635b-11e4-bd8d-db9dc96946bb', E'DEV', E'/EarlyCompletionV2_0PollRequestWebService?wsdl', True, False, E'2a36a312-635a-11e4-b205-27180409340e', E'https://bgtest.landregistry.gov.uk/b2b/ECDRS_StubService');

INSERT INTO public."ServiceDefinitionDetail" ("ServiceDefinitionDetailID", "EnvironmentName", "ServicePartialURL", "IsActive", "IsDeleted", "ServiceDefinitionID", "ServerURL")
VALUES (E'b2e2172c-635b-11e4-a21c-23f413a2304c', E'DEV', E'/DaylistEnquiryV2_0WebService?wsdl', True, False, E'2a2d366a-635a-11e4-93fe-d31cbd0bb48d', E'https://businessgateway.landregistry.gov.uk/b2b/BGSoapEngine');

INSERT INTO public."ServiceDefinitionDetail" ("ServiceDefinitionDetailID", "EnvironmentName", "ServicePartialURL", "IsActive", "IsDeleted", "ServiceDefinitionID", "ServerURL")
VALUES (E'b2e4882c-635b-11e4-bdf5-974d5528374b', E'DEV', E'/DaylistEnquiryV2_0PollRequestWebService?wsdl', True, False, E'2a2e6eea-635a-11e4-a49c-7f0e96e3dd94', E'https://businessgateway.landregistry.gov.uk/b2b/BGSoapEngine');

INSERT INTO public."ServiceDefinitionDetail" ("ServiceDefinitionDetailID", "EnvironmentName", "ServicePartialURL", "IsActive", "IsDeleted", "ServiceDefinitionID", "ServerURL")
VALUES (E'b2e4fd5c-635b-11e4-a14c-a718504e8390', E'DEV', E'/EnquiryByPropertyDescriptionV2_0WebService?wsdl', True, False, E'2a2ebd0a-635a-11e4-bb6b-0f163eafad5e', E'https://businessgateway.landregistry.gov.uk/b2b/BGSoapEngine');

INSERT INTO public."ServiceDefinitionDetail" ("ServiceDefinitionDetailID", "EnvironmentName", "ServicePartialURL", "IsActive", "IsDeleted", "ServiceDefinitionID", "ServerURL")
VALUES (E'b2e54b86-635b-11e4-966e-4baeef5c7626', E'DEV', E'/EnquiryByPropertyDescriptionV2_0PollWebService?wsdl', True, False, E'2a2f323a-635a-11e4-a4fc-f7ac1461a0ae', E'https://businessgateway.landregistry.gov.uk/b2b/BGSoapEngine');

INSERT INTO public."ServiceDefinitionDetail" ("ServiceDefinitionDetailID", "EnvironmentName", "ServicePartialURL", "IsActive", "IsDeleted", "ServiceDefinitionID", "ServerURL")
VALUES (E'b2e5c0b6-635b-11e4-b5e6-037da8b2d116', E'DEV', E'/BankruptcySearchV2_1WebService?wsdl', True, False, E'2a2fa76a-635a-11e4-8816-275e0b99f062', E'https://businessgateway.landregistry.gov.uk/b2b/BGSoapEngine');

INSERT INTO public."ServiceDefinitionDetail" ("ServiceDefinitionDetailID", "EnvironmentName", "ServicePartialURL", "IsActive", "IsDeleted", "ServiceDefinitionID", "ServerURL")
VALUES (E'b2e635e6-635b-11e4-968e-130d49134a8c', E'DEV', E'/BankruptcySearchV2_1PollRequestWebService?wsdl', True, False, E'2a300e08-635a-11e4-817c-f76fdab5706d', E'https://businessgateway.landregistry.gov.uk/b2b/BGSoapEngine');

INSERT INTO public."ServiceDefinitionDetail" ("ServiceDefinitionDetailID", "EnvironmentName", "ServicePartialURL", "IsActive", "IsDeleted", "ServiceDefinitionID", "ServerURL")
VALUES (E'b2e6ab20-635b-11e4-a3f2-bb615bda4c74', E'DEV', E'/FullSearchV2_1WebService?wsdl', True, False, E'2a3060e2-635a-11e4-8a45-77c63afe6c9e', E'https://businessgateway.landregistry.gov.uk/b2b/BGSoapEngine');

INSERT INTO public."ServiceDefinitionDetail" ("ServiceDefinitionDetailID", "EnvironmentName", "ServicePartialURL", "IsActive", "IsDeleted", "ServiceDefinitionID", "ServerURL")
VALUES (E'b2e6f936-635b-11e4-898b-3fed51658f28', E'DEV', E'/FullSearchV2_1PollRequestWebService?wsdl', True, False, E'2a30d716-635a-11e4-8df8-8f5d61e6fe68', E'https://businessgateway.landregistry.gov.uk/b2b/BGSoapEngine');

INSERT INTO public."ServiceDefinitionDetail" ("ServiceDefinitionDetailID", "EnvironmentName", "ServicePartialURL", "IsActive", "IsDeleted", "ServiceDefinitionID", "ServerURL")
VALUES (E'b2e76e70-635b-11e4-aab4-7f62b453367a', E'DEV', E'/OfficialCopyTitleKnownV2_1WebService?wsdl', True, False, E'2a314c0a-635a-11e4-90ae-b322daf93d9e', E'https://businessgateway.landregistry.gov.uk/b2b/BGSoapEngine');

INSERT INTO public."ServiceDefinitionDetail" ("ServiceDefinitionDetailID", "EnvironmentName", "ServicePartialURL", "IsActive", "IsDeleted", "ServiceDefinitionID", "ServerURL")
VALUES (E'b2e7e3a0-635b-11e4-a175-c7f6d9e47368', E'DEV', E'/OC1TitleKnownV2_1PollRequestWebService?wsdl', True, False, E'2a3199ee-635a-11e4-943e-234e8e6b9c9e', E'https://businessgateway.landregistry.gov.uk/b2b/BGSoapEngine');

INSERT INTO public."ServiceDefinitionDetail" ("ServiceDefinitionDetailID", "EnvironmentName", "ServicePartialURL", "IsActive", "IsDeleted", "ServiceDefinitionID", "ServerURL")
VALUES (E'b2e831b6-635b-11e4-83cc-e381a515ffee', E'DEV', E'/OfficialSearchOfPartV2_1WebService?wsdl', True, False, E'2a320f28-635a-11e4-b1dc-4fc85b613154', E'https://businessgateway.landregistry.gov.uk/b2b/BGSoapEngine');

INSERT INTO public."ServiceDefinitionDetail" ("ServiceDefinitionDetailID", "EnvironmentName", "ServicePartialURL", "IsActive", "IsDeleted", "ServiceDefinitionID", "ServerURL")
VALUES (E'b2e87fea-635b-11e4-8f95-23fc1a674878', E'DEV', E'/OfficialSearchOfPartV2_1PollRequestWebService?wsdl', True, False, E'2a325d3e-635a-11e4-8176-e3c2f1ba344a', E'https://businessgateway.landregistry.gov.uk/b2b/BGSoapEngine');

INSERT INTO public."ServiceDefinitionDetail" ("ServiceDefinitionDetailID", "EnvironmentName", "ServicePartialURL", "IsActive", "IsDeleted", "ServiceDefinitionID", "ServerURL")
VALUES (E'b2e8ce46-635b-11e4-8c17-0b46cbb3d551', E'DEV', E'/OfficialSearchV2_1WebService?wsdl', True, False, E'2a32f97e-635a-11e4-836f-d309e7b0e85f', E'https://businessgateway.landregistry.gov.uk/b2b/BGSoapEngine');

INSERT INTO public."ServiceDefinitionDetail" ("ServiceDefinitionDetailID", "EnvironmentName", "ServicePartialURL", "IsActive", "IsDeleted", "ServiceDefinitionID", "ServerURL")
VALUES (E'b2e94326-635b-11e4-8cbd-c3ee896008a0', E'DEV', E'/OfficialSearchV2_1PollRequestWebService?wsdl', True, False, E'2a336ec2-635a-11e4-9afd-5f61abf60e9a', E'https://businessgateway.landregistry.gov.uk/b2b/BGSoapEngine');

INSERT INTO public."ServiceDefinitionDetail" ("ServiceDefinitionDetailID", "EnvironmentName", "ServicePartialURL", "IsActive", "IsDeleted", "ServiceDefinitionID", "ServerURL")
VALUES (E'b2e99146-635b-11e4-9c2b-0f7ac94c1a98', E'DEV', E'/OfficialCopyWithSummaryV2_1WebService?wsdl', True, False, E'2a33bcec-635a-11e4-8410-4f3169a594bc', E'https://businessgateway.landregistry.gov.uk/b2b/BGSoapEngine');

INSERT INTO public."ServiceDefinitionDetail" ("ServiceDefinitionDetailID", "EnvironmentName", "ServicePartialURL", "IsActive", "IsDeleted", "ServiceDefinitionID", "ServerURL")
VALUES (E'b2ea0676-635b-11e4-94f8-bf0c4c130476', E'DEV', E'/OfficialCopyWithSummaryV2_1PollRequestWebService?wsdl', True, False, E'2a343212-635a-11e4-9417-07ca3bfc73a9', E'https://businessgateway.landregistry.gov.uk/b2b/BGSoapEngine');

INSERT INTO public."ServiceDefinitionDetail" ("ServiceDefinitionDetailID", "EnvironmentName", "ServicePartialURL", "IsActive", "IsDeleted", "ServiceDefinitionID", "ServerURL")
VALUES (E'b2ea5496-635b-11e4-b7c5-ef8384dee63c', E'DEV', E'/SearchOfIndexMapV2_1WebService?wsdl', True, False, E'2a348028-635a-11e4-9462-7b00d7141479', E'https://businessgateway.landregistry.gov.uk/b2b/BGSoapEngine');

INSERT INTO public."ServiceDefinitionDetail" ("ServiceDefinitionDetailID", "EnvironmentName", "ServicePartialURL", "IsActive", "IsDeleted", "ServiceDefinitionID", "ServerURL")
VALUES (E'b2eb306e-635b-11e4-94fa-1b375ac99230', E'DEV', E'/SearchOfIndexMapV2_1PollRequestWebService?wsdl', True, False, E'2a34ce2a-635a-11e4-bdb6-67974a2cc81b', E'https://businessgateway.landregistry.gov.uk/b2b/BGSoapEngine');

INSERT INTO public."ServiceDefinitionDetail" ("ServiceDefinitionDetailID", "EnvironmentName", "ServicePartialURL", "IsActive", "IsDeleted", "ServiceDefinitionID", "ServerURL")
VALUES (E'b2ef9d84-635b-11e4-9a7c-e30ba00b0df2', E'DEV', E'/OutstandingRequestsV2_0WebService?wsdl', True, False, E'2a37b478-635a-11e4-a3c5-03fc318693f5', E'https://businessgateway.landregistry.gov.uk/b2b/BGSoapEngine');

INSERT INTO public."ServiceDefinitionDetail" ("ServiceDefinitionDetailID", "EnvironmentName", "ServicePartialURL", "IsActive", "IsDeleted", "ServiceDefinitionID", "ServerURL")
VALUES (E'b2eeb324-635b-11e4-95ef-8f19e21f3b43', E'DEV', E'/OnlineOwnershipVerificationV1_0WebService?wsdl', True, False, E'2a36f128-635a-11e4-bc0c-b7ec9430619d', E'https://businessgateway.landregistry.gov.uk/b2b/EOOV_SoapEngine');

INSERT INTO public."ServiceDefinitionDetail" ("ServiceDefinitionDetailID", "EnvironmentName", "ServicePartialURL", "IsActive", "IsDeleted", "ServiceDefinitionID", "ServerURL")
VALUES (E'b2ef27e6-635b-11e4-9b0d-73edfa6ddaec', E'DEV', E'/OnlineOwnershipVerificationV1_0WebService/WEB-INF/wsdl/PollRequest.xsd', True, False, E'2a376658-635a-11e4-b5bc-d35aae588435', E'https://businessgateway.landregistry.gov.uk/b2b/EOOV_SoapEngine');
