-- ProductAdvised
INSERT INTO
  public."BusEvent"
(
  "BusEventID",
  "BusEventName",
  "BusEventDescription",
  "BusEventTypeID"
)
VALUES (
  'E8940D74-5B74-4C19-81AC-92095D50069D',
  'ProductAdvised',
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
  '61FDE8B2-445E-45F3-92CC-65124E84662C',
  'ProductAdvised',
  'Bec.TargetFramework.SB.Messages.Events.ProductAdvisedEvent',
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
  'E8940D74-5B74-4C19-81AC-92095D50069D',
  '61FDE8B2-445E-45F3-92CC-65124E84662C',
  true,
  false,
  null
);