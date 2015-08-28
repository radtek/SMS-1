DO $$
Declare TransferInterfaceID uuid;
Begin

TransferInterfaceID := (select uuid_generate_v1());

INSERT INTO
  public."TransferInterface"
(
  "TransferInterfaceID",
  "TransferInterfaceVersionNumber",
  "Name",
  "Description",
  "TransferInterfaceTypeID"
)
VALUES (
  TransferInterfaceID,
  1,
  'STStoSiraBatchProcess',
  'Tranfer STS data to SIRA',
  40000001
);

----------- Steps
INSERT INTO
  public."TransferInterfaceStep"
(
  "TransferInterfaceStepVersionNumber",
  "Name"
)
VALUES (
  1,
  'DetermineSearchScopeForSiraBatch'
);

INSERT INTO
  public."TransferInterfaceStep"
(
  "TransferInterfaceStepVersionNumber",
  "Name"
)
VALUES (
  1,
  'ProcessSearchForSiraBatch'
);

INSERT INTO
  public."TransferInterfaceStep"
(
  "TransferInterfaceStepVersionNumber",
  "Name"
)
VALUES (
  1,
  'CollateSearchesForSiraBatch'
);

INSERT INTO
  public."TransferInterfaceStep"
(
  "TransferInterfaceStepVersionNumber",
  "Name"
)
VALUES (
  1,
  'SendSiraBatch'
);

-- create links to interface
INSERT INTO
  public."TransferInterfaceProcessOrder"
(
  "TransferInterfaceID",
  "TransferInterfaceVersionNumber",
  "TransferInterfaceStepID",
  "TransferInterfaceStepVersionNumber",
  "Order"
)
VALUES (
  TransferInterfaceID,
  1,
  ( select "TransferInterfaceStepID" from  public."TransferInterfaceStep" where "Name" = 'DetermineSearchScopeForSiraBatch'),
  1,
  0
);

INSERT INTO
  public."TransferInterfaceProcessOrder"
(
  "TransferInterfaceID",
  "TransferInterfaceVersionNumber",
  "TransferInterfaceStepID",
  "TransferInterfaceStepVersionNumber",
  "Order"
)
VALUES (
  TransferInterfaceID,
  1,
  ( select "TransferInterfaceStepID" from  public."TransferInterfaceStep" where "Name" = 'ProcessSearchForSiraBatch'),
  1,
  1
);

INSERT INTO
  public."TransferInterfaceProcessOrder"
(
  "TransferInterfaceID",
  "TransferInterfaceVersionNumber",
  "TransferInterfaceStepID",
  "TransferInterfaceStepVersionNumber",
  "Order"
)
VALUES (
  TransferInterfaceID,
  1,
  ( select "TransferInterfaceStepID" from  public."TransferInterfaceStep" where "Name" = 'CollateSearchesForSiraBatch'),
  1,
  2
);


INSERT INTO
  public."TransferInterfaceProcessOrder"
(
  "TransferInterfaceID",
  "TransferInterfaceVersionNumber",
  "TransferInterfaceStepID",
  "TransferInterfaceStepVersionNumber",
  "Order"
)
VALUES (
  TransferInterfaceID,
  1,
  ( select "TransferInterfaceStepID" from  public."TransferInterfaceStep" where "Name" = 'SendSiraBatch'),
  1,
  3
);



END $$;