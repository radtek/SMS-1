INSERT INTO 
  public."ClassificationTypeCategory"
(
  "ClassificationTypeCategoryID",
  "Name",
  "IsActive",
  "IsDeleted"
)
VALUES (
  1000,
  'ApplicationID',
  TRUE,--:IsActive,
  FALSE--:IsDeleted
);

INSERT INTO 
  public."ClassificationType"
(
  "ClassificationTypeID",
  "Name",
  "Description",
  "ClassificationTypeCategoryID",
  "ParentClassificationTypeCategoryID",
  "IsActive",
  "IsDeleted"
)
VALUES (
  1000000001,
  'BEF',
  '',--:Description,
  1000,
  NULL,--:ParentClassificationTypeCategoryID,
  TRUE,--:IsActive,
  FALSE--:IsDeleted
);


INSERT INTO 
  public."ClassificationType"
(
  "ClassificationTypeID",
  "Name",
  "Description",
  "ClassificationTypeCategoryID",
  "ParentClassificationTypeCategoryID",
  "IsActive",
  "IsDeleted"
)
VALUES (
  1000000101,
  'DEV',
  '',--:Description,
  1000,
  NULL,--:ParentClassificationTypeCategoryID,
  TRUE,--:IsActive,
  FALSE--:IsDeleted
);
