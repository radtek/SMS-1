-- username
INSERT INTO
  public."BusEvent"
(
  "BusEventID",
  "BusEventName",
  "BusEventDescription",
  "BusEventTypeID"
)
VALUES (
  '4633a062-400d-11e4-92d1-3bbc97b163aa',
  'TestEvent',
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
  '6f85fd84-400d-11e4-a6c8-1fe24de621cb',
  'TestEvent',
  'Bec.TargetFramework.SB.Messages.Events.AddNewCompanyAndAdministratorEvent',
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
  '4633a062-400d-11e4-92d1-3bbc97b163aa',
  '6f85fd84-400d-11e4-a6c8-1fe24de621cb',
  true,
  false,
  null
);

-- username
INSERT INTO
  public."BusEvent"
(
  "BusEventID",
  "BusEventName",
  "BusEventDescription",
  "BusEventTypeID"
)
VALUES (
  '4fb1b2c4-489f-11e4-8ad9-175db514c526',
  'UsernameReminderEvent',
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
  '4fb1b2c4-489f-11e4-a026-2b96867a5561',
  'UsernameReminderEvent',
  'Bec.TargetFramework.SB.Messages.Events.UsernameReminderEvent',
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
  '4fb1b2c4-489f-11e4-8ad9-175db514c526',
  '4fb1b2c4-489f-11e4-a026-2b96867a5561',
  true,
  false,
  null
);

-- password
INSERT INTO
  public."BusEvent"
(
  "BusEventID",
  "BusEventName",
  "BusEventDescription",
  "BusEventTypeID"
)
VALUES (
  '5fb1b2c4-489f-11e4-8ad9-175db514c526',
  'ForgotPasswordEvent',
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
  '5fb1b2c4-489f-11e4-a026-2b96867a5561',
  'ForgotPasswordEvent',
  'Bec.TargetFramework.SB.Messages.Events.ForgotPasswordEvent',
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
  '5fb1b2c4-489f-11e4-8ad9-175db514c526',
  '5fb1b2c4-489f-11e4-a026-2b96867a5561',
  true,
  false,
  null
);