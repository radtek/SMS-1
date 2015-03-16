
DO $$
Declare InvoiceProcessLogID uuid;
Declare TransactionStatusID uuid;
Declare PlanSubscriptionProcessLogStatusID uuid;
Declare PlanSubscriptionBillingProcessLogStatusID uuid;
Declare UserOrganisationDefaultStatusID uuid;
Declare ServiceInterfaceProcessLogStatusID uuid;
Declare ProductPurchaseTaskStatusID uuid;
Declare ProductPurchaseStatusID uuid;
Declare ProductPurchaseBusTaskProcessLogStatusID uuid;
Declare OrganisationFinancialStatusID uuid;
Declare OrganisationStatusID uuid;
Declare BusTaskScheduleProcessLogStatusID uuid;
Declare BusMessageProcessLogStatusID uuid;
Declare BranchStatusID uuid;
Declare OrganisationDirectDebitMandateSignOffLogID uuid;
Declare OrganisationPaymentMethodID uuid;
Begin

-- base templates

INSERT INTO public."StatusTypeTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'21eefa2e-4d75-11e4-9494-e39d9f00d293', 1, E'User Organisation Status', E'User Organisation Default Status', True, False);

UserOrganisationDefaultStatusID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'User Organisation Status');

INSERT INTO public."StatusTypeTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'071c242c-6375-11e4-9b57-5feeab466abb', 1, E'Service Interface Process Log Status', E'Service Interface Process Log Status', True, False);

ServiceInterfaceProcessLogStatusID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Service Interface Process Log Status');

INSERT INTO public."StatusTypeTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'cda94f92-507f-11e4-b9c9-3fd7d6d83ce9', 1, E'ProductPurchaseTask Status', E'ProductPurchaseTask Status', True, False);

ProductPurchaseTaskStatusID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'ProductPurchaseTask Status');

INSERT INTO public."StatusTypeTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'cda99dbc-507f-11e4-8008-bbf1550da421', 1, E'ProductPurchase Status', E'ProductPurchase Status', True, False);

ProductPurchaseStatusID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'ProductPurchase Status');

INSERT INTO public."StatusTypeTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'df55fac0-6398-11e4-8c1c-e3f896c3ad0a', 1, E'Product Purchase Bus Task Process Log Status', E'Product Purchase Bus Task Process Log Status', True, False);

ProductPurchaseBusTaskProcessLogStatusID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Product Purchase Bus Task Process Log Status');

INSERT INTO public."StatusTypeTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'd341c64e-4d75-11e4-9f05-b72cf02db94e', 1, E'OrganisationPaymentMethod Status', E'OrganisationPaymentMethod Status', True, False);

OrganisationDirectDebitMandateSignOffLogID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'OrganisationPaymentMethod Status');

INSERT INTO public."StatusTypeTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'd3496818-4d75-11e4-a044-b3c58cbadd0f', 1, E'OrganisationFinancial Status', E'OrganisationFinancial Status', True, False);

OrganisationFinancialStatusID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'OrganisationFinancial Status');

INSERT INTO public."StatusTypeTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'd342146e-4d75-11e4-ba31-9b17b069c8bb', 1, E'OrganisationDirectDebitMandateSignOff Status', E'OrganisationDirectDebitMandateSignOff Default Status', True, False);

OrganisationPaymentMethodID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'OrganisationDirectDebitMandateSignOff Status');

INSERT INTO public."StatusTypeTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'21f03470-4d75-11e4-be09-8f7f7f3fdaa5', 1, E'Organisation Status', E'Organisation Default Status', True, False);

OrganisationStatusID  := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Organisation Status');

INSERT INTO public."StatusTypeTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'd32600d0-4d75-11e4-8534-a32778e392ee', 1, E'Invoice Process Log Status', E'Invoice Process Log Status', True, False);

InvoiceProcessLogID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Invoice Process Log Status');

INSERT INTO public."StatusTypeTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'df5362a6-6398-11e4-816f-3fc277a0a6f8', 1, E'Bus Task Schedule Process Log Status', E'Bus Task Schedule Process Log Status', True, False);

BusTaskScheduleProcessLogStatusID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Bus Task Schedule Process Log Status');

INSERT INTO public."StatusTypeTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'df4f43ec-6398-11e4-bf93-937a73869fae', 1, E'Bus Message Process Log Status', E'Bus Message Process Log Status', True, False);

BusMessageProcessLogStatusID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Bus Message Process Log Status');

INSERT INTO public."StatusTypeTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'21f059d2-4d75-11e4-99b6-f78cc018b0e6', 1, E'Branch Status', E'Branch Default Status', True, False);

BranchStatusID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Branch Status');

INSERT INTO public."StatusTypeTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'd327124a-4d75-11e4-bf51-eb430c13effa', 1, E'TransactionOrderProcessLog Status', E'TransactionOrderProcessLog Default Status', True, False);

TransactionStatusID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'TransactionOrderProcessLog Status');

INSERT INTO public."StatusTypeTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'd327606a-4d75-11e4-b691-43368d3c4bb6', 1, E'PlanSubscriptionProcessLog Status', E'PlanSubscriptionProcessLog Default Status', True, False);

PlanSubscriptionProcessLogStatusID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'PlanSubscriptionProcessLog Status');

INSERT INTO public."StatusTypeTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'd327ae94-4d75-11e4-9cd8-1b811711afb1', 1, E'PlanSubscriptionBillingProcessLog Status', E'PlanSubscriptionBillingProcessLog Default Status', True, False);

PlanSubscriptionBillingProcessLogStatusID := (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'PlanSubscriptionBillingProcessLog Status');


INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'21f27c9e-4d75-11e4-b2cd-7339059339fc', BranchStatusID, 1, E'Pending', E'Pending', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'21f2a3ea-4d75-11e4-861b-cb175af579e3', BranchStatusID, 1, E'Approved', E'Approved', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'21f2cb04-4d75-11e4-8cd4-2fc1a5d77f34', BranchStatusID, 1, E'Rejected', E'Rejected', True, False);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'21f4eda8-4d75-11e4-9667-bfea42259b88', BranchStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = BranchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Pending' limit 1),
 0, True, False);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'21f53bbe-4d75-11e4-ada1-dbee820db15a', BranchStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = BranchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Approved' limit 1),
 1, False, True);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'21f589de-4d75-11e4-909c-d7c5856bb4cb', BranchStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = BranchStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Rejected' limit 1),
 2, False, True);



INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'9ea7e24c-63ff-11e4-afc1-bf603bf1a286', BusMessageProcessLogStatusID, 1, E'Sent', E'Sent', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'9ea8ccac-63ff-11e4-bbde-2b49ab651765', BusMessageProcessLogStatusID, 1, E'Received', E'Received', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'df507c6c-6398-11e4-898a-035f1c8e49e4', BusMessageProcessLogStatusID, 1, E'Pending', E'Pending', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'df50ca8c-6398-11e4-9241-078d6b7e3abd', BusMessageProcessLogStatusID, 1, E'Processing', E'Processing', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'df5118ac-6398-11e4-a811-b3a5982780f3', BusMessageProcessLogStatusID, 1, E'Failed', E'Failed', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'df5166cc-6398-11e4-a9b9-23953138f2cd', BusMessageProcessLogStatusID, 1, E'Successful', E'Successful', True, False);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'9ea91acc-63ff-11e4-9ce0-3302a07d87d1', BusMessageProcessLogStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = BusMessageProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Sent' limit 1),
 0, False, False);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'df51b4ec-6398-11e4-a168-8b39bc796440', BusMessageProcessLogStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = BusMessageProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Received' limit 1),
 1, False, False);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'9ea968ec-63ff-11e4-8ac5-1b239ed37d56', BusMessageProcessLogStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = BusMessageProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Pending' limit 1),
 0, True, False);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'df522a26-6398-11e4-b2c2-671ef33b69e7', BusMessageProcessLogStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = BusMessageProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Processing' limit 1),
 1, False, False);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'df52783c-6398-11e4-a83a-93c44ab9c97d', BusMessageProcessLogStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = BusMessageProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Failed' limit 1),
 2, False, True);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'df52c65c-6398-11e4-9901-ef837c531fe4', BusMessageProcessLogStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = BusMessageProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Successful' limit 1),
 3, True, False);




INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'df5389ac-6398-11e4-9f1b-172c10d5258b', BusTaskScheduleProcessLogStatusID, 1, E'Pending', E'Pending', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'df53d7cc-6398-11e4-9ede-7392631179b7', BusTaskScheduleProcessLogStatusID, 1, E'Processing', E'Processing', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'df53fee6-6398-11e4-9fb3-6317a3a99a26', BusTaskScheduleProcessLogStatusID, 1, E'Failed', E'Failed', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'df544cfc-6398-11e4-baf3-ef93f5c987f3', BusTaskScheduleProcessLogStatusID, 1, E'Successful', E'Successful', True, False);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'df549b1c-6398-11e4-980f-abdd4f625d28', BusTaskScheduleProcessLogStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = BusTaskScheduleProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Pending' limit 1),
 0, True, False);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'df54e93c-6398-11e4-bc04-9f41494e0ff7', BusTaskScheduleProcessLogStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = BusTaskScheduleProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Processing' limit 1),
 1, False, False);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'df55375c-6398-11e4-87a3-27968d7b58c7', BusTaskScheduleProcessLogStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = BusTaskScheduleProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Failed' limit 1),
 2, False, True);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'df558586-6398-11e4-b3b0-9fd8010a35ec', BusTaskScheduleProcessLogStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = BusTaskScheduleProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Successful' limit 1),
 3, True, False);
 
 



INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'21f1b98a-4d75-11e4-bf41-8fcd114410b7', OrganisationStatusID, 1, E'Pending', E'Pending', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'21f1e09a-4d75-11e4-ba67-f7ec797962a0', OrganisationStatusID, 1, E'Approved', E'Approved', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'21f22e88-4d75-11e4-a03b-9bbbe21bb3d5', OrganisationStatusID, 1, E'Rejected', E'Rejected', True, False);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'21f45186-4d75-11e4-8cc2-336969c19a52', OrganisationStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = OrganisationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Pending' limit 1),
 0, True, False);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'21f49fd8-4d75-11e4-8322-574e8e1e955d', OrganisationStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = OrganisationStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Approved' limit 1),
 1, False, True);



INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'df5648d6-6398-11e4-9058-cbdb601fe3fb', ProductPurchaseBusTaskProcessLogStatusID, 1, E'Pending', E'Pending', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'df566fdc-6398-11e4-acec-078fff2ab2ff', ProductPurchaseBusTaskProcessLogStatusID, 1, E'Processing', E'Processing', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'df56bdfc-6398-11e4-8683-f3d6eebe7b49', ProductPurchaseBusTaskProcessLogStatusID, 1, E'Failed', E'Failed', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'df56e52a-6398-11e4-b632-83b72b167164', ProductPurchaseBusTaskProcessLogStatusID, 1, E'Successful', E'Successful', True, False);



INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'df573336-6398-11e4-a49b-fb0d3c4743d0', ProductPurchaseBusTaskProcessLogStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ProductPurchaseBusTaskProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Pending' limit 1),
 0, True, False);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'df57814c-6398-11e4-82ba-13e1eed4fa0b', ProductPurchaseBusTaskProcessLogStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ProductPurchaseBusTaskProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Processing' limit 1),
 1, False, False);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'df57cf6c-6398-11e4-a3f3-77b223b949f7', ProductPurchaseBusTaskProcessLogStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ProductPurchaseBusTaskProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Failed' limit 1),
 2, False, True);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'df57f686-6398-11e4-9ffe-ef1c13c9bbd9', ProductPurchaseBusTaskProcessLogStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ProductPurchaseBusTaskProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Successful' limit 1),
 3, True, False);





INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'cdaad646-507f-11e4-8719-2bac88d3df45', ProductPurchaseStatusID, 1, E'Pending', E'Pending', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'cdaafd56-507f-11e4-beca-d3618ae1b083', ProductPurchaseStatusID, 1, E'Processing', E'Processing', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'cdab4b76-507f-11e4-9f3b-4323e0762959', ProductPurchaseStatusID, 1, E'Successful', E'Successful', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'cdab7286-507f-11e4-b0a6-d38d85ed4671', ProductPurchaseStatusID, 1, E'Failed', E'Failed', True, False);


INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'cdacf926-507f-11e4-8285-67ceffb59cd4', ProductPurchaseStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ProductPurchaseStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Pending' limit 1),
 0, True, False);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'cdad4746-507f-11e4-8626-87cf5e42fc55', ProductPurchaseStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ProductPurchaseStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Processing' limit 1),
 1, False, False);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'cdad9570-507f-11e4-acc5-6b18881592ca', ProductPurchaseStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ProductPurchaseStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Successful' limit 1),
2, False, True);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'cdade386-507f-11e4-b255-272a947a7a6b', ProductPurchaseStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ProductPurchaseStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Failed' limit 1),
 3, False, True);




INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'cda9ebe6-507f-11e4-aa73-073c02f8f093', ProductPurchaseTaskStatusID, 1, E'Pending', E'Pending', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'cdaa39fc-507f-11e4-9ec5-1316afad49b7', ProductPurchaseTaskStatusID, 1, E'Successful', E'Successful', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'cdaa8826-507f-11e4-81ef-e7369cf749b1', ProductPurchaseTaskStatusID, 1, E'Failed', E'Failed', True, False);


INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'cdabe7b6-507f-11e4-a198-1ff158e34edf', ProductPurchaseTaskStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ProductPurchaseTaskStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Pending' limit 1),
 0, True, False);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'cdac35d6-507f-11e4-a706-4b3cfaa47a44', ProductPurchaseTaskStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ProductPurchaseTaskStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Successful' limit 1),
 1, False, True);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'cdac83f6-507f-11e4-a162-bb3cefd1e53b', ProductPurchaseTaskStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ProductPurchaseTaskStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Failed' limit 1),
 2, False, True);


INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'21f0a824-4d75-11e4-91bb-17002dc3257d', UserOrganisationDefaultStatusID, 1, E'Pending', E'Pending', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'21f1441e-4d75-11e4-8c3c-e3b840d9f181', UserOrganisationDefaultStatusID, 1, E'Approved', E'Approved', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'21f16b7e-4d75-11e4-87d3-077e51f6bf34', UserOrganisationDefaultStatusID, 1, E'Rejected', E'Rejected', True, False);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'21f34002-4d75-11e4-b9f4-a339b588798c', UserOrganisationDefaultStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = UserOrganisationDefaultStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Pending' limit 1),
 0, True, False);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'21f3b528-4d75-11e4-a8ec-2f1d7f8f060b', UserOrganisationDefaultStatusID, 1,
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = UserOrganisationDefaultStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Approved' limit 1),
 1, False, True);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'21f4037a-4d75-11e4-860e-f3f22bcacb9a', UserOrganisationDefaultStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = UserOrganisationDefaultStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Rejected' limit 1),
 2, False, True);

 
 
 INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'071d5cb6-6375-11e4-9d36-bb1529cc54ef', ServiceInterfaceProcessLogStatusID, 1, E'Initialised', E'Initialised', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'071daad6-6375-11e4-8e9c-8bf2fca208e9', ServiceInterfaceProcessLogStatusID, 1, E'In Progress', E'In Progress', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'071df8e2-6375-11e4-825b-734a42be7489', ServiceInterfaceProcessLogStatusID, 1, E'Failed', E'Failed', True, False);

INSERT INTO public."StatusTypeValueTemplate" ("StatusTypeValueTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description", "IsActive", "IsDeleted")
VALUES (E'071e4716-6375-11e4-b714-47dcb035b7f6', ServiceInterfaceProcessLogStatusID, 1, E'Completed', E'Completed', True, False);
 
 
INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'071e9536-6375-11e4-b57e-6b73082c84cd', ServiceInterfaceProcessLogStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ServiceInterfaceProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Initialised' limit 1),
 0, True, False);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'071f0a66-6375-11e4-a106-435c4d4df0f2', ServiceInterfaceProcessLogStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ServiceInterfaceProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'In Progress' limit 1),
 1, False, False);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'071f5886-6375-11e4-a7cb-4f32e9f7aa9e', ServiceInterfaceProcessLogStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ServiceInterfaceProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Failed' limit 1),
 2, False, True);

INSERT INTO public."StatusTypeStructureTemplate" ("StatusTypeStructureTemplateID", "StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "StatusTypeValueTemplateID", "StatusOrder", "IsStart", "IsEnd")
VALUES (E'071fa6b0-6375-11e4-91ed-03dca9057679', ServiceInterfaceProcessLogStatusID, 1, 
(select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = ServiceInterfaceProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Completed' limit 1),
 3, True, False);
 

-- Invoice
INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  InvoiceProcessLogID,
  1,
  'Active',
  'Active'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  InvoiceProcessLogID,
  1,
  'Paid',
  'Paid'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  InvoiceProcessLogID,
  1,
  'Unpaid',
  'Unpaid'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  InvoiceProcessLogID,
  1,
  'Payment Due',
  'Payment Due'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  InvoiceProcessLogID,
  1,
  'Processing',
  'Processing'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  InvoiceProcessLogID,
  1,
  'Cancelled',
  'Cancelled'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  InvoiceProcessLogID,
  1,
  'Payment Scheduled',
  'Payment Scheduled'
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  InvoiceProcessLogID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = InvoiceProcessLogID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Active' limit 1),
  0,
  true,
  false
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  InvoiceProcessLogID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = InvoiceProcessLogID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Payment Due' limit 1),
  1,
  false,
  false
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  InvoiceProcessLogID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = InvoiceProcessLogID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Processing' limit 1),
  2,
  false,
  false
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  InvoiceProcessLogID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = InvoiceProcessLogID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Payment Scheduled' limit 1),
  3,
  false,
  false
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  InvoiceProcessLogID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = InvoiceProcessLogID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Cancelled' limit 1),
  4,
  false,
  true
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  InvoiceProcessLogID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = InvoiceProcessLogID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Paid' limit 1),
  5,
  false,
  true
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  InvoiceProcessLogID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = InvoiceProcessLogID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Unpaid' limit 1),
  6,
  false,
  true
);

-- transaction


-- Invoice
INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  TransactionStatusID,
  1,
  'Active',
  'Active'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  TransactionStatusID,
  1,
  'Failed',
  'Failed'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  TransactionStatusID,
  1,
  'Successful',
  'Successful'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  TransactionStatusID,
  1,
  'Timeout',
  'Timeout'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  TransactionStatusID,
  1,
  'Processing',
  'Processing'
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  TransactionStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = TransactionStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Active' limit 1),
  0,
  true,
  false
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  TransactionStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = TransactionStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Processing' limit 1),
  1,
  false,
  false
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  TransactionStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = TransactionStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Timeout' limit 1),
  2,
  false,
  true
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  TransactionStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = TransactionStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Successful' limit 1),
  3,
  false,
  true
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  TransactionStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = TransactionStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Failed' limit 1),
  4,
  false,
  true
);


-- PlanSubscriptionProcessLog
INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  PlanSubscriptionProcessLogStatusID,
  1,
  'Active',
  'Active'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  PlanSubscriptionProcessLogStatusID,
  1,
  'Trialing',
  'Trialing'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  PlanSubscriptionProcessLogStatusID,
  1,
  'Cancelled',
  'Cancelled'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  PlanSubscriptionProcessLogStatusID,
  1,
  'Suspended',
  'Suspended'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  PlanSubscriptionProcessLogStatusID,
  1,
  'Expired',
  'Expired'
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  PlanSubscriptionProcessLogStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = PlanSubscriptionProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Active' limit 1),
  0,
  true,
  false
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  PlanSubscriptionProcessLogStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = PlanSubscriptionProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Trialing' limit 1),
  1,
  false,
  false
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  PlanSubscriptionProcessLogStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = PlanSubscriptionProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Cancelled' limit 1),
  2,
  false,
  true
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  PlanSubscriptionProcessLogStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = PlanSubscriptionProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Suspended' limit 1),
  3,
  false,
  true
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  PlanSubscriptionProcessLogStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = PlanSubscriptionProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Expired' limit 1),
  4,
  false,
  true
);

-- PlanSubscriptionBillingProcessLog
INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  PlanSubscriptionBillingProcessLogStatusID,
  1,
  'Active',
  'Active'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  PlanSubscriptionBillingProcessLogStatusID,
  1,
  'Processing',
  'Processing'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  PlanSubscriptionBillingProcessLogStatusID,
  1,
  'Paid',
  'Paid'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  PlanSubscriptionBillingProcessLogStatusID,
  1,
  'Unpaid',
  'Unpaid'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  PlanSubscriptionBillingProcessLogStatusID,
  1,
  'Cancelled',
  'Cancelled'
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  PlanSubscriptionBillingProcessLogStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = PlanSubscriptionBillingProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Active' limit 1),
  0,
  true,
  false
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  PlanSubscriptionBillingProcessLogStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = PlanSubscriptionBillingProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Processing' limit 1),
  1,
  false,
  false
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  PlanSubscriptionBillingProcessLogStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = PlanSubscriptionBillingProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Cancelled' limit 1),
  2,
  false,
  true
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  PlanSubscriptionBillingProcessLogStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = PlanSubscriptionBillingProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Paid' limit 1),
  3,
  false,
  true
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  PlanSubscriptionBillingProcessLogStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = PlanSubscriptionBillingProcessLogStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Unpaid' limit 1),
  4,
  false,
  true
);

-- now promote all
perform "fn_PromoteStatusTypeTemplate"(InvoiceProcessLogID,1);
perform "fn_PromoteStatusTypeTemplate"(TransactionStatusID,1);
perform "fn_PromoteStatusTypeTemplate"(PlanSubscriptionProcessLogStatusID,1);
perform "fn_PromoteStatusTypeTemplate"(PlanSubscriptionBillingProcessLogStatusID,1);


-- direct debit mandate
INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  OrganisationDirectDebitMandateSignOffLogID,
  1,
  'Pending',
  'Pending'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  OrganisationDirectDebitMandateSignOffLogID,
  1,
  'Accepted',
  'Accepted'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  OrganisationDirectDebitMandateSignOffLogID,
  1,
  'Rejected',
  'Rejected'
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  OrganisationDirectDebitMandateSignOffLogID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = OrganisationDirectDebitMandateSignOffLogID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Pending' limit 1),
  0,
  true,
  false
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  OrganisationDirectDebitMandateSignOffLogID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = OrganisationDirectDebitMandateSignOffLogID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Accepted' limit 1),
  1,
  false,
  TRUE
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  OrganisationDirectDebitMandateSignOffLogID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = OrganisationDirectDebitMandateSignOffLogID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Rejected' limit 1),
  2,
  false,
  true
);

-- Payment Method
INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  OrganisationPaymentMethodID,
  1,
  'Pending',
  'Pending'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  OrganisationPaymentMethodID,
  1,
  'Active',
  'Active'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  OrganisationPaymentMethodID,
  1,
  'In Active',
  'In Active'
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  OrganisationPaymentMethodID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = OrganisationPaymentMethodID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Pending' limit 1),
  0,
  true,
  false
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  OrganisationPaymentMethodID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = OrganisationPaymentMethodID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Active' limit 1),
  1,
  false,
  TRUE
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  OrganisationPaymentMethodID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = OrganisationPaymentMethodID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'In Active' limit 1),
  2,
  false,
  true
);

-- now promote all
perform "fn_PromoteStatusTypeTemplate"(OrganisationDirectDebitMandateSignOffLogID,1);
perform "fn_PromoteStatusTypeTemplate"(OrganisationPaymentMethodID,1);

-- direct debit mandate
INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  OrganisationFinancialStatusID,
  1,
  'Standard Terms',
  'Standard Terms'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  OrganisationFinancialStatusID,
  1,
  'Services Suspended',
  'Services Suspended'
);

INSERT INTO
  public."StatusTypeValueTemplate"
(
  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "Name",
  "Description"
)
VALUES (
  OrganisationFinancialStatusID,
  1,
  'Credit Limit Applied',
  'Credit Limit Applied'
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  OrganisationFinancialStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = OrganisationFinancialStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Standard Terms' limit 1),
  0,
  true,
  false
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  OrganisationFinancialStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = OrganisationFinancialStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Services Suspended' limit 1),
  1,
  false,
  TRUE
);

INSERT INTO
  public."StatusTypeStructureTemplate"
(

  "StatusTypeTemplateID",
  "StatusTypeTemplateVersionNumber",
  "StatusTypeValueTemplateID",
  "StatusOrder",
  "IsStart",
  "IsEnd"
)
VALUES (
  OrganisationFinancialStatusID,
  1,
  (select st."StatusTypeValueTemplateID" from "StatusTypeValueTemplate" st  where st."StatusTypeTemplateID" = OrganisationFinancialStatusID and  st."StatusTypeTemplateVersionNumber" = 1 and st."Name" = 'Credit Limit Applied' limit 1),
  2,
  false,
  true
);

perform "fn_PromoteStatusTypeTemplate"(OrganisationFinancialStatusID,1);

perform "fn_PromoteStatusTypeTemplate"(UserOrganisationDefaultStatusID,1);
perform "fn_PromoteStatusTypeTemplate"(ServiceInterfaceProcessLogStatusID,1);
perform "fn_PromoteStatusTypeTemplate"(ProductPurchaseTaskStatusID,1);
perform "fn_PromoteStatusTypeTemplate"(ProductPurchaseStatusID,1);

perform "fn_PromoteStatusTypeTemplate"(ProductPurchaseBusTaskProcessLogStatusID,1);
perform "fn_PromoteStatusTypeTemplate"(OrganisationStatusID,1);
perform "fn_PromoteStatusTypeTemplate"(BusTaskScheduleProcessLogStatusID,1);
perform "fn_PromoteStatusTypeTemplate"(BusMessageProcessLogStatusID,1);
perform "fn_PromoteStatusTypeTemplate"(BranchStatusID,1);


END $$;