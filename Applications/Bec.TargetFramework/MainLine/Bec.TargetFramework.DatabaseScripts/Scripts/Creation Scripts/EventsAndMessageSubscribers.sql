/* Data for the 'public.TFEventType' table  (Records 1 - 1) */

INSERT INTO public."TFEventType" ("TFEventTypeID", "Name")
VALUES (E'707d82de-3ddd-11e4-95c4-a77fdf4021b5', E'WorkflowRelated');

/* Data for the 'public.TFEvent' table  (Records 1 - 2) */

INSERT INTO public."TFEvent" ("TFEventID", "TFEventName", "TFEventDescription", "TFEventTypeID")
VALUES (E'4633a062-400d-11e4-92d1-3bbc97b163aa', E'CreateLoginCompletedEvent', E'CreateLoginCompletedEvent', E'707d82de-3ddd-11e4-95c4-a77fdf4021b5');

INSERT INTO public."TFEvent" ("TFEventID", "TFEventName", "TFEventDescription", "TFEventTypeID")
VALUES (E'5a3ef2f0-3ddd-11e4-947f-d794c7dc9b9c', E'RegistrationCompletedEvent', E'Registration Completed', E'707d82de-3ddd-11e4-95c4-a77fdf4021b5');

/* Data for the 'public.TFEventMessageSubscriber' table  (Records 1 - 2) */

INSERT INTO public."TFEventMessageSubscriber" ("TFEventMessageSubscriberID", "Name", "ObjectName", "ObjectAssembly", "DefaultMessageSubscriberFilter")
VALUES (E'6f85fd84-400d-11e4-a6c8-1fe24de621cb', E'CreateLoginCompletedEvent', E'Bec.TargetFramework.SB.Messages.Events.CreateLoginCompletedEvent', E'Bec.TargetFramework.SB.Messages', NULL);

INSERT INTO public."TFEventMessageSubscriber" ("TFEventMessageSubscriberID", "Name", "ObjectName", "ObjectAssembly", "DefaultMessageSubscriberFilter")
VALUES (E'f141991a-3ddc-11e4-a4e6-3b2e2db526bf', E'RegistrationCompletedEvent', E'Bec.TargetFramework.SB.Messages.Events.RegistrationCompletedEvent', E'Bec.TargetFramework.SB.Messages', NULL);

/* Data for the 'public.TFEventTFEventMessageSubscriber' table  (Records 1 - 2) */

INSERT INTO public."TFEventTFEventMessageSubscriber" ("TFEventID", "TFEventMessageSubscriberID", "IsActive", "IsDeleted", "TFEventMessageSubscriberFilter")
VALUES (E'4633a062-400d-11e4-92d1-3bbc97b163aa', E'6f85fd84-400d-11e4-a6c8-1fe24de621cb', True, False, NULL);

INSERT INTO public."TFEventTFEventMessageSubscriber" ("TFEventID", "TFEventMessageSubscriberID", "IsActive", "IsDeleted", "TFEventMessageSubscriberFilter")
VALUES (E'5a3ef2f0-3ddd-11e4-947f-d794c7dc9b9c', E'f141991a-3ddc-11e4-a4e6-3b2e2db526bf', True, False, NULL);