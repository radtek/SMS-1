INSERT INTO public."ClassificationTypeCategory" ( "ClassificationTypeCategoryID", "Name") VALUES ('2000','HelpPageTypeId');

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "ClassificationTypeCategoryID")
VALUES('800000','Tour', '2000'), ('800001','Callout', '2000'), ('800002','Show Me How', '2000')


INSERT INTO public."ClassificationTypeCategory" ( "ClassificationTypeCategoryID", "Name") VALUES ('2001','HelpPageItemStatus');

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "ClassificationTypeCategoryID")
VALUES('800003','New', '2001'), ('800004','Modified', '2001'), ('800005','Deleted', '2001')