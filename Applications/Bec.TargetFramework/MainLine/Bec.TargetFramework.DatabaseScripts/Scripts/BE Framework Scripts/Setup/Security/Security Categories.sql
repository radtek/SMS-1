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