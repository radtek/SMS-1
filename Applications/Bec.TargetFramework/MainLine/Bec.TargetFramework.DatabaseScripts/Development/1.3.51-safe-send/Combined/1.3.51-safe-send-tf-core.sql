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




-- BankAccountCheckNoMatch
INSERT INTO
  public."BusEvent"
(
  "BusEventID",
  "BusEventName",
  "BusEventDescription",
  "BusEventTypeID"
)
VALUES (
  'AAF415E2-325A-4BCB-8E62-A641788F42AA',
  'BankAccountMarkedAsPotentialFraud',
  '',
  '707d82de-3ddd-11e4-95c4-a77fdf4021b5'
);
INSERT INTO
  public."BusEventMessageSubscriber"
(
  "BusEventMessageSubscriberID",
  "Name",
  "ObjectName",
  "ObjectAssembly"
)
VALUES (
  '48888501-ED89-420D-A710-46290B119111',
  'BankAccountMarkedAsPotentialFraud',
  'Bec.TargetFramework.SB.Messages.Events.BankAccountMarkedAsPotentialFraudEvent',
  'Bec.TargetFramework.SB.Messages'
);
INSERT INTO
  public."BusEventBusEventMessageSubscriber"
(
  "BusEventID",
  "BusEventMessageSubscriberID",
  "IsActive",
  "IsDeleted",
  "BusEventMessageSubscriberFilter"
)
VALUES (
  'AAF415E2-325A-4BCB-8E62-A641788F42AA',
  '48888501-ED89-420D-A710-46290B119111',
  true,
  false,
  null
);