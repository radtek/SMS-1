
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

-- bus message

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (10000,'BusMessageTypeID');

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801300,'Atomic','',10000,true,false);

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801301,'Scheduled','',10000,true,false);

-- bus message status

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (10001,'BusMessageStatusID');

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801400,'Completed','',10001,true,false);

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801401,'Failed','',10001,true,false);

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801402,'Received','',10001,true,false);

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801403,'Sent','',10001,true,false);