﻿truncate "Plan" cascade;
truncate "Product" cascade;
truncate "ProductTemplate" cascade;
truncate "Organisation" cascade;
truncate "DefaultOrganisation" cascade;
truncate "DefaultOrganisationTemplate" cascade;
truncate "ModuleTemplate" cascade;
truncate "StatusType" cascade;
truncate "StatusTypeTemplate" cascade;
delete from "GlobalAccountingPeriod";
delete from "GlobalDirectDebitCollectionPeriod";
delete from "GlobalPaymentMethod";