
-- Temp Organisation
DO $$
Declare DoTemplateID uuid;
Declare DoVersionNumber integer;
Declare OrganisationTypeID integer;
Begin

--check org type exists
insert into public."OrganisationType" ("Name") select 'Supplier'
where not exists (select * from public."OrganisationType" where "Name" = 'Supplier');

-- declare variables
OrganisationTypeID := (select "OrganisationTypeID" from "OrganisationType" where "Name" = 'Supplier' limit 1);

INSERT INTO
  public."DefaultOrganisationTemplate"
(
  "DefaultOrganisationTemplateVersionNumber",
  "Name",
  "Description",
  "IsActive",
  "IsDeleted",
  "OrganisationTypeID"
)
VALUES (
  1,
  'Supplier',
  'Template for a Supplier Organisation',
  true,
  false,
  OrganisationTypeID
);

DoTemplateID:= (select dot."DefaultOrganisationTemplateID" from "DefaultOrganisationTemplate" dot where dot."Name" = 'Supplier' limit 1);
DoVersionNumber = 1;

-- promote supplier DO
perform "fn_PromoteDefaultOrganisationTemplate"(DoTemplateID, DoVersionNumber);



insert into public."ClassificationTypeCategory" ("ClassificationTypeCategoryID", "Name") select 110, 'ProductTypeID'
where not exists (select * from public."ClassificationTypeCategory" where "Name" = 'ProductTypeID');

insert into public."ClassificationType" ("ClassificationTypeCategoryID", "Name") select 110, 'Supplier Product'
where not exists (select * from public."ClassificationType" where "ClassificationTypeCategoryID" = 110 and "Name" = 'Supplier Product');



insert into public."ClassificationTypeCategory" ("ClassificationTypeCategoryID", "Name") select 8006, 'PeriodUnitID'
where not exists (select * from public."ClassificationTypeCategory" where "Name" = 'PeriodUnitID');

insert into public."ClassificationType" ("ClassificationTypeCategoryID", "Name") select 8006, 'Month'
where not exists (select * from public."ClassificationType" where "ClassificationTypeCategoryID" = 8006 and "Name" = 'Month');



insert into public."ClassificationTypeCategory" ("ClassificationTypeCategoryID", "Name") select 8007, 'PlanTypeID'
where not exists (select * from public."ClassificationTypeCategory" where "Name" = 'PlanTypeID');

insert into public."ClassificationType" ("ClassificationTypeCategoryID", "Name") select 8007, 'Active'
where not exists (select * from public."ClassificationType" where "ClassificationTypeCategoryID" = 8007 and "Name" = 'Active');


INSERT INTO public."PlanGroup" ("PlanGroupID", "Name", "Description", "ParentID", "HasSameGlobalPaymentMethodForAllPlans")
select 4, E'PlanGroup1', E'Plan Group One', NULL, False
where not exists (select * from public."PlanGroup" where "Name" = 'PlanGroup1');


INSERT INTO public."GlobalPaymentMethod" ("Name", "PaymentMethodID", "IsDefaultForOnlinePayments")
select E'GlobalPaymentMethod1', 1, True
where not exists (select * from public."GlobalPaymentMethod" where "Name" = 'GlobalPaymentMethod1');


insert into public."StatusTypeTemplate" ("Name") select E'Invoice Process Log Status'
where not exists (select * from public."StatusTypeTemplate" where "Name" = 'Invoice Process Log Status');

insert into public."StatusTypeValueTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description")
select (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = E'Invoice Process Log Status' limit 1), 1, 'Active', 'Active'
where not exists (select * from public."StatusTypeValueTemplate" where
"StatusTypeValueTemplateID" = (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Invoice Process Log Status')
and "StatusTypeTemplateVersionNumber" = 1 and "Name" = 'Invoice Process Log Status');

insert into public."StatusTypeValueTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description")
select (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = E'Invoice Process Log Status' limit 1), 1, 'Processing', 'Processing'
where not exists (select * from public."StatusTypeValueTemplate" where
"StatusTypeValueTemplateID" = (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Invoice Process Log Status')
and "StatusTypeTemplateVersionNumber" = 1 and "Name" = 'Invoice Process Log Status');

insert into public."StatusTypeValueTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description")
select (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = E'Invoice Process Log Status' limit 1), 1, 'Cancelled', 'Cancelled'
where not exists (select * from public."StatusTypeValueTemplate" where
"StatusTypeValueTemplateID" = (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Invoice Process Log Status')
and "StatusTypeTemplateVersionNumber" = 1 and "Name" = 'Invoice Process Log Status');

insert into public."StatusTypeValueTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description")
select (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = E'Invoice Process Log Status' limit 1), 1, 'PaymentScheduled', 'PaymentScheduled'
where not exists (select * from public."StatusTypeValueTemplate" where
"StatusTypeValueTemplateID" = (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Invoice Process Log Status')
and "StatusTypeTemplateVersionNumber" = 1 and "Name" = 'Invoice Process Log Status');

insert into public."StatusTypeValueTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description")
select (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = E'Invoice Process Log Status' limit 1), 1, 'Paid', 'Paid'
where not exists (select * from public."StatusTypeValueTemplate" where
"StatusTypeValueTemplateID" = (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Invoice Process Log Status')
and "StatusTypeTemplateVersionNumber" = 1 and "Name" = 'Invoice Process Log Status');

insert into public."StatusTypeValueTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description")
select (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = E'Invoice Process Log Status' limit 1), 1, 'Unpaid', 'Unpaid'
where not exists (select * from public."StatusTypeValueTemplate" where
"StatusTypeValueTemplateID" = (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Invoice Process Log Status')
and "StatusTypeTemplateVersionNumber" = 1 and "Name" = 'Invoice Process Log Status');

insert into public."StatusTypeValueTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description")
select (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = E'Invoice Process Log Status' limit 1), 1, 'PaymentDue', 'PaymentDue'
where not exists (select * from public."StatusTypeValueTemplate" where
"StatusTypeValueTemplateID" = (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'Invoice Process Log Status')
and "StatusTypeTemplateVersionNumber" = 1 and "Name" = 'Invoice Process Log Status');


insert into public."StatusTypeTemplate" ("Name") select E'TransactionOrderProcessLog Status'
where not exists (select * from public."StatusTypeTemplate" where "Name" = 'TransactionOrderProcessLog Status');

insert into public."StatusTypeValueTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description")
select (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = E'TransactionOrderProcessLog Status' limit 1), 1, 'Active', 'Active'
where not exists (select * from public."StatusTypeValueTemplate" where
"StatusTypeValueTemplateID" = (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'TransactionOrderProcessLog Status')
and "StatusTypeTemplateVersionNumber" = 1 and "Name" = 'TransactionOrderProcessLog Status');

insert into public."StatusTypeValueTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description")
select (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = E'TransactionOrderProcessLog Status' limit 1), 1, 'Processing', 'Processing'
where not exists (select * from public."StatusTypeValueTemplate" where
"StatusTypeValueTemplateID" = (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'TransactionOrderProcessLog Status')
and "StatusTypeTemplateVersionNumber" = 1 and "Name" = 'TransactionOrderProcessLog Status');

insert into public."StatusTypeValueTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description")
select (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = E'TransactionOrderProcessLog Status' limit 1), 1, 'Successful', 'Successful'
where not exists (select * from public."StatusTypeValueTemplate" where
"StatusTypeValueTemplateID" = (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'TransactionOrderProcessLog Status')
and "StatusTypeTemplateVersionNumber" = 1 and "Name" = 'TransactionOrderProcessLog Status');

insert into public."StatusTypeValueTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description")
select (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = E'TransactionOrderProcessLog Status' limit 1), 1, 'Failed', 'Failed'
where not exists (select * from public."StatusTypeValueTemplate" where
"StatusTypeValueTemplateID" = (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'TransactionOrderProcessLog Status')
and "StatusTypeTemplateVersionNumber" = 1 and "Name" = 'TransactionOrderProcessLog Status');

insert into public."StatusTypeValueTemplate" ("StatusTypeTemplateID", "StatusTypeTemplateVersionNumber", "Name", "Description")
select (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = E'TransactionOrderProcessLog Status' limit 1), 1, 'Timeout', 'Timeout'
where not exists (select * from public."StatusTypeValueTemplate" where
"StatusTypeValueTemplateID" = (select "StatusTypeTemplateID" from "StatusTypeTemplate" where "Name" = 'TransactionOrderProcessLog Status')
and "StatusTypeTemplateVersionNumber" = 1 and "Name" = 'TransactionOrderProcessLog Status');

END $$;