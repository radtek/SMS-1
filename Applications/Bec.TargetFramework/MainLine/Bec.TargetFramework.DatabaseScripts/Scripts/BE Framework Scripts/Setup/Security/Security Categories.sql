INSERT INTO public."Operation"("OperationName", "OperationDescription")
VALUES ('Send','Send');

INSERT INTO public."Operation"("OperationName", "OperationDescription")
VALUES ('MarkAsRead','MarkAsRead');

INSERT INTO public."Operation"("OperationName", "OperationDescription")
VALUES ('MarkAsUnread','MarkAsUnread');

INSERT INTO public."Operation"("OperationName", "OperationDescription")
VALUES ('Configure','Configure');

INSERT INTO public."Operation"("OperationName", "OperationDescription")
VALUES ('View','View');

INSERT INTO public."Operation"("OperationName", "OperationDescription")
VALUES ('Edit','Edit');

INSERT INTO public."Operation"("OperationName", "OperationDescription")
VALUES ('Delete','Delete');

INSERT INTO public."Operation"("OperationName", "OperationDescription")
VALUES ('Add','Add');

insert into public."Resource"("ResourceID", "ResourceName", "ResourceDescription", "IsActive")
values (uuid_generate_v1(), 'Home', 'Home', TRUE);

insert into public."Resource"("ResourceID", "ResourceName", "ResourceDescription", "IsActive")
values (uuid_generate_v1(), 'Company', 'Company', TRUE);

insert into public."Resource"("ResourceID", "ResourceName", "ResourceDescription", "IsActive")
values (uuid_generate_v1(), 'CompanyStructure', 'CompanyStructure', TRUE);

insert into public."Resource"("ResourceID", "ResourceName", "ResourceDescription", "IsActive")
values (uuid_generate_v1(), 'ProUsers', 'ProUsers', TRUE);

insert into public."Resource"("ResourceID", "ResourceName", "ResourceDescription", "IsActive")
values (uuid_generate_v1(), 'SmsTransaction', 'SmsTransaction', TRUE);

insert into public."Resource"("ResourceID", "ResourceName", "ResourceDescription", "IsActive")
values (uuid_generate_v1(), 'BankAccount', 'BankAccount', TRUE);

insert into public."Resource"("ResourceID", "ResourceName", "ResourceDescription", "IsActive")
values (uuid_generate_v1(), 'ValidatedAccount', 'ValidatedAccount', TRUE);

insert into public."Resource"("ResourceID", "ResourceName", "ResourceDescription", "IsActive")
values (uuid_generate_v1(), 'Credit', 'Credit', TRUE);

insert into public."Resource"("ResourceID", "ResourceName", "ResourceDescription", "IsActive")
values (uuid_generate_v1(), 'Products', 'Products', TRUE);

insert into public."Resource"("ResourceID", "ResourceName", "ResourceDescription", "IsActive")
values (uuid_generate_v1(), 'InternalNotifications', 'InternalNotifications', TRUE);

insert into public."Resource"("ResourceID", "ResourceName", "ResourceDescription", "IsActive")
values (uuid_generate_v1(), 'MyTransactions', 'MyTransactions', TRUE); 

insert into public."Resource"("ResourceID", "ResourceName", "ResourceDescription", "IsActive")
values (uuid_generate_v1(), 'SupportFunctions', 'SupportFunctions: Only BEC Support user can work with management Support Functions (SMH and Callout)', TRUE);

insert into public."Resource"("ResourceID", "ResourceName", "ResourceDescription", "IsActive")
values (uuid_generate_v1(), 'RequestSupport', 'RequestSupport', TRUE);