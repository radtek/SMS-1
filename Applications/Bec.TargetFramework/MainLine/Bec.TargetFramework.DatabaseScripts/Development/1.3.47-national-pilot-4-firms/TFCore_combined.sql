
-- ======================= TARGET FRAMEWORK CORE DB =======================
-- NewInternalMessages
INSERT INTO
  public."BusEvent"
(
  "BusEventID",
  "BusEventName",
  "BusEventDescription",
  "BusEventTypeID"
)
VALUES (
  '29903CF8-FC37-4221-82D1-083B987D1A54',
  'NewInternalMessages',
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
  '13E41DF5-FC57-4F31-B96E-EDF056EDDCDE',
  'NewInternalMessages',
  'Bec.TargetFramework.SB.Messages.Events.NewInternalMessagesEvent',
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
  '29903CF8-FC37-4221-82D1-083B987D1A54',
  '13E41DF5-FC57-4F31-B96E-EDF056EDDCDE',
  true,
  false,
  null
);
