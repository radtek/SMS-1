INSERT INTO public."ClassificationTypeCategory" ( "ClassificationTypeCategoryID", "Name") VALUES ('2000','HelpPageTypeId');

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "ClassificationTypeCategoryID")
VALUES('800000','Tour', '2000'), ('800001','Callout', '2000'), ('800002','Show Me How', '2000')