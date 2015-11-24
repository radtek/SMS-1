-- new admin
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

-- new user
INSERT INTO
  public."BusEvent"
(
  "BusEventID",
  "BusEventName",
  "BusEventDescription",
  "BusEventTypeID"
)
VALUES (
  'D97F6BA0-6734-4472-9B73-932AA0A81637',
  'NewUser',
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
  '3DAA0BBD-4364-46D7-8A2C-15991526D0DD',
  'NewUser',
  'Bec.TargetFramework.SB.Messages.Events.AddNewUserEvent',
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
  'D97F6BA0-6734-4472-9B73-932AA0A81637',
  '3DAA0BBD-4364-46D7-8A2C-15991526D0DD',
  true,
  false,
  null
);

-- BankAccountMarkedAsFraudSuspicious
INSERT INTO
  public."BusEvent"
(
  "BusEventID",
  "BusEventName",
  "BusEventDescription",
  "BusEventTypeID"
)
VALUES (
  'A97F6BA0-6734-4472-9B73-932AA0A81637',
  'BankAccountMarkedAsFraudSuspicious',
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
  '1DAA0BBD-4364-46D7-8A2C-15991526D0DD',
  'BankAccountMarkedAsFraudSuspicious',
  'Bec.TargetFramework.SB.Messages.Events.BankAccountMarkedAsFraudSuspiciousEvent',
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
  'A97F6BA0-6734-4472-9B73-932AA0A81637',
  '1DAA0BBD-4364-46D7-8A2C-15991526D0DD',
  true,
  false,
  null
);

-- BankAccountMarkedAsSafe
INSERT INTO
  public."BusEvent"
(
  "BusEventID",
  "BusEventName",
  "BusEventDescription",
  "BusEventTypeID"
)
VALUES (
  '3C3415E2-325A-4BCB-8E62-A641788F42F5',
  'BankAccountMarkedAsSafe',
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
  '47777501-ED89-420D-A710-46290B119060',
  'BankAccountMarkedAsSafe',
  'Bec.TargetFramework.SB.Messages.Events.BankAccountMarkedAsSafeEvent',
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
  '3C3415E2-325A-4BCB-8E62-A641788F42F5',
  '47777501-ED89-420D-A710-46290B119060',
  true,
  false,
  null
);

-- CreditAdjustment
INSERT INTO
  public."BusEvent"
(
  "BusEventID",
  "BusEventName",
  "BusEventDescription",
  "BusEventTypeID"
)
VALUES (
  '93D38148-4126-4BEB-A7C8-112004E3C8CF',
  'CreditAdjustment',
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
  'BEBA4DB9-16F3-4DEE-BDC0-14CD0030243F',
  'CreditAdjustment',
  'Bec.TargetFramework.SB.Messages.Events.CreditAdjustmentEvent',
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
  '93D38148-4126-4BEB-A7C8-112004E3C8CF',
  'BEBA4DB9-16F3-4DEE-BDC0-14CD0030243F',
  true,
  false,
  null
);

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