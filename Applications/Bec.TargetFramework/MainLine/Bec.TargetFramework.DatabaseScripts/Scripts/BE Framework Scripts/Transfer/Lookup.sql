
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (8006,'PeriodUnitID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800500,'Week','',8006,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800501,'Month','',8006,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800502,'Year','',8006,true,false);

-- TransferConnectionTypeID

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (5000000,'TransferConnectionTypeID');

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (5000100,'Ftp','',5000000,true,false);

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (5000101,'Sftp','',5000000,true,false);

     INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (5000102,'File','',5000000,true,false);

     INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (5000103,'Database','',5000000,true,false);

     INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (5000104,'Email','',5000000,true,false);
