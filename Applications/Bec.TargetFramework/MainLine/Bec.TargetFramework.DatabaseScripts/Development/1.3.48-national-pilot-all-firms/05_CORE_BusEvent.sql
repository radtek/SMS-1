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
  'DDF415E2-325A-4BCB-8E62-A641788F42F5',
  'BankAccountCheckNoMatch',
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
  '48888501-ED89-420D-A710-46290B119060',
  'BankAccountCheckNoMatch',
  'Bec.TargetFramework.SB.Messages.Events.BankAccountCheckNoMatchEvent',
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
  'DDF415E2-325A-4BCB-8E62-A641788F42F5',
  '48888501-ED89-420D-A710-46290B119060',
  true,
  false,
  null
);