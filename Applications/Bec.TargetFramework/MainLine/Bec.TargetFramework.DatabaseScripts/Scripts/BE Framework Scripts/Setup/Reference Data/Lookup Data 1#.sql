-- Address
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (10,'AddressTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (11,'AddressCategoryID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (12,'AddressSubTypeID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (4973,'Home','',10,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (4974,'Work','',10,true,false);

  INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (4975,'Main','',10,true,false);


-- Contact
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (60,'ContactTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (61,'ContactSubTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (62,'ContactCategoryID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (63,'ContactSubCategoryID');

INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('Personal','',60,true,false);

INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('Company','',60,true,false);


---salutationType ---
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (8502,'SalutationTypeID');


  INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('Mr','',8502,true,false);

   INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('Mrs','',8502,true,false);


   INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('Miss','',8502,true,false);


   INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('Dr','',8502,true,false);


   INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('Rev','',8502,true,false);


   INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('Prof.','',8502,true,false);

  ---Regulator  ---
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (8503,'RegulatorID');


  INSERT INTO
  public."ClassificationType"("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (5016, 'SRA','',8503,true,false);

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (5017, 'CLC','',8503,true,false);


   INSERT INTO
  public."ClassificationType"("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (5018, 'CILEx','',8503,true,false);

   ---Rejection Type  ---
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (8504,'RejectionTypeID');


  INSERT INTO
  public."ClassificationType"("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (5231, 'No match to regulator','',8504,true,false);

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (5232, 'Failed to validate callback','',8504,true,false);
