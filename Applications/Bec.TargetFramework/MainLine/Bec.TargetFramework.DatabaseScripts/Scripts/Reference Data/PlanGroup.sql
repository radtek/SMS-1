delete from "PlanGroup";

/* Data for the 'public.PlanGroup' table  (Records 1 - 3) */

INSERT INTO public."PlanGroup" ("PlanGroupID", "Name", "Description", "ParentID", "HasSameGlobalPaymentMethodForAllPlans")
VALUES (1, E'SCP Plans', NULL, NULL, False);

INSERT INTO public."PlanGroup" ("PlanGroupID", "Name", "Description", "ParentID", "HasSameGlobalPaymentMethodForAllPlans")
VALUES (2, E'BEC Support Plans', NULL, NULL, False);

INSERT INTO public."PlanGroup" ("PlanGroupID", "Name", "Description", "ParentID", "HasSameGlobalPaymentMethodForAllPlans")
VALUES (3, E'Supplier Plans', NULL, NULL, False);