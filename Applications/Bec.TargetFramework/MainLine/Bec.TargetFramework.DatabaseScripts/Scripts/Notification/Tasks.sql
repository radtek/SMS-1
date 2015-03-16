-- security tasks
INSERT INTO
  public."TFEvent"
(
  "TFEventID",
  "TFEventName",
  "TFEventDescription",
  "TFEventTypeID"
)
VALUES (
  '4fb1b2c4-489f-11e4-8ad9-175db514c526',
  'ForgottenUsernamePasswordEvent',
  '',
  '707d82de-3ddd-11e4-95c4-a77fdf4021b5'
);

INSERT INTO
  public."TFEventMessageSubscriber"
(
  "TFEventMessageSubscriberID",
  "Name",
  "ObjectName",
  "ObjectAssembly"
)
VALUES (
  '4fb1b2c4-489f-11e4-a026-2b96867a5561',
  'ForgottenUsernamePasswordEvent',
  'Bec.TargetFramework.SB.Messages.Events.ForgottenUsernamePasswordEvent',
  'Bec.TargetFramework.SB.Messages'
);

INSERT INTO
  public."TFEventTFEventMessageSubscriber"
(
  "TFEventID",
  "TFEventMessageSubscriberID",
  "IsActive",
  "IsDeleted",
  "TFEventMessageSubscriberFilter"
)
VALUES (
  '4fb1b2c4-489f-11e4-8ad9-175db514c526',
  '4fb1b2c4-489f-11e4-a026-2b96867a5561'
);