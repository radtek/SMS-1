
-- event types

INSERT INTO public."TFEventType" ("TFEventTypeID", "Name")
VALUES (E'707d82de-3ddd-11e4-95c4-a77fdf4021b5', E'WorkflowRelated');

INSERT INTO public."TFEventType" ("TFEventTypeID", "Name")
VALUES (E'b7fae0de-4f8f-11e4-81f1-7bbebc204f52', E'Payment');

-- Events
INSERT INTO public."TFEvent" ("TFEventID", "TFEventName", "TFEventDescription", "TFEventTypeID")
VALUES (E'5a3ef2f0-3ddd-11e4-947f-d794c7dc9b9c', E'RegistrationCompletedEvent', E'Registration Completed', E'707d82de-3ddd-11e4-95c4-a77fdf4021b5');

INSERT INTO public."TFEvent" ("TFEventID", "TFEventName", "TFEventDescription", "TFEventTypeID")
VALUES (E'4633a062-400d-11e4-92d1-3bbc97b163aa', E'CreateLoginCompletedEvent', E'CreateLoginCompletedEvent', E'707d82de-3ddd-11e4-95c4-a77fdf4021b5');

INSERT INTO public."TFEvent" ("TFEventID", "TFEventName", "TFEventDescription", "TFEventTypeID")
VALUES (E'460f71d2-47bb-11e4-bc90-6ffc47e436f3', E'TemporaryAccountCreatedEvent', E'TemporaryAccountCreatedEvent', E'707d82de-3ddd-11e4-95c4-a77fdf4021b5');

INSERT INTO public."TFEvent" ("TFEventID", "TFEventName", "TFEventDescription", "TFEventTypeID")
VALUES (E'b7fba438-4f8f-11e4-b8f6-5b4d4f08b608', E'OnlinePaymentEvent', E'Online Payment Event', E'b7fae0de-4f8f-11e4-81f1-7bbebc204f52');

INSERT INTO public."TFEvent"("TFEventID", "TFEventName", "TFEventDescription", "TFEventTypeID")
VALUES (E'4fb1b2c4-489f-11e4-8ad9-175db514c526', E'ForgottenUsernamePasswordEvent',  '', '707d82de-3ddd-11e4-95c4-a77fdf4021b5');


INSERT INTO public."TFEventMessageSubscriber" ("TFEventMessageSubscriberID", "Name", "ObjectName", "ObjectAssembly", "DefaultMessageSubscriberFilter")
VALUES (E'f141991a-3ddc-11e4-a4e6-3b2e2db526bf', E'RegistrationCompletedEvent', E'Bec.TargetFramework.SB.Messages.Events.RegistrationCompletedEvent', E'Bec.TargetFramework.SB.Messages', NULL);

INSERT INTO public."TFEventMessageSubscriber" ("TFEventMessageSubscriberID", "Name", "ObjectName", "ObjectAssembly", "DefaultMessageSubscriberFilter")
VALUES (E'6f85fd84-400d-11e4-a6c8-1fe24de621cb', E'CreateLoginCompletedEvent', E'Bec.TargetFramework.SB.Messages.Events.CreateLoginCompletedEvent', E'Bec.TargetFramework.SB.Messages', NULL);

INSERT INTO public."TFEventMessageSubscriber" ("TFEventMessageSubscriberID", "Name", "ObjectName", "ObjectAssembly", "DefaultMessageSubscriberFilter")
VALUES (E'7d8401d2-47bb-11e4-b893-8bad290b3216', E'ColpRegistrationTemporaryAccountEvent', E'Bec.TargetFramework.SB.Messages.Events.ColpRegistrationTemporaryAccountEvent', E'Bec.TargetFramework.SB.Messages', NULL);

INSERT INTO public."TFEventMessageSubscriber" ("TFEventMessageSubscriberID", "Name", "ObjectName", "ObjectAssembly", "DefaultMessageSubscriberFilter")
VALUES (E'96ea8d42-47c2-11e4-8e0f-e3daeaa9f723', E'NonColpTemporaryAccountEvent', E'Bec.TargetFramework.SB.Messages.Events.NonColpTemporaryAccountEvent', E'Bec.TargetFramework.SB.Messages', NULL);

INSERT INTO public."TFEventMessageSubscriber" ("TFEventMessageSubscriberID", "Name", "ObjectName", "ObjectAssembly", "DefaultMessageSubscriberFilter")
VALUES (E'b7fbcb3e-4f8f-11e4-a726-236dc67efbde', E'OnlinePaymentEvent', E'Bec.TargetFramework.SB.Messages.Events.OnlinePaymentEvent', E'Bec.TargetFramework.SB.Messages', NULL);

INSERT INTO public."TFEventMessageSubscriber"("TFEventMessageSubscriberID",  "Name", "ObjectName", "ObjectAssembly")
VALUES (E'4fb1b2c4-489f-11e4-a026-2b96867a5561', E'ForgottenPasswordEvent', E'Bec.TargetFramework.SB.Messages.Events.ForgottenPasswordEvent', E'Bec.TargetFramework.SB.Messages');

INSERT INTO public."TFEventMessageSubscriber"("TFEventMessageSubscriberID",  "Name", "ObjectName", "ObjectAssembly")
VALUES (E'9bfc5370-48b1-11e4-9968-1392d9ed7dfd', E'ForgottenUsernameEvent', E'Bec.TargetFramework.SB.Messages.Events.ForgottenUsernameEvent', E'Bec.TargetFramework.SB.Messages');

--INSERT INTO public."TFEventMessageSubscriber"("TFEventMessageSubscriberID",  "Name", "ObjectName", "ObjectAssembly")
--VALUES (E'4fb1b2c4-489f-11e4-a026-2b96867a5561', E'ForgottenUsernamePasswordEvent', E'Bec.TargetFramework.SB.Messages.Events.ForgottenUsernamePasswordEvent', E'Bec.TargetFramework.SB.Messages');



INSERT INTO public."TFEventTFEventMessageSubscriber" ("TFEventID", "TFEventMessageSubscriberID", "IsActive", "IsDeleted", "TFEventMessageSubscriberFilter")
VALUES (E'5a3ef2f0-3ddd-11e4-947f-d794c7dc9b9c', E'f141991a-3ddc-11e4-a4e6-3b2e2db526bf', True, False, NULL);

INSERT INTO public."TFEventTFEventMessageSubscriber" ("TFEventID", "TFEventMessageSubscriberID", "IsActive", "IsDeleted", "TFEventMessageSubscriberFilter")
VALUES (E'4633a062-400d-11e4-92d1-3bbc97b163aa', E'6f85fd84-400d-11e4-a6c8-1fe24de621cb', True, False, NULL);

INSERT INTO public."TFEventTFEventMessageSubscriber" ("TFEventID", "TFEventMessageSubscriberID", "IsActive", "IsDeleted", "TFEventMessageSubscriberFilter")
VALUES (E'460f71d2-47bb-11e4-bc90-6ffc47e436f3', E'7d8401d2-47bb-11e4-b893-8bad290b3216', True, False, NULL);

INSERT INTO public."TFEventTFEventMessageSubscriber" ("TFEventID", "TFEventMessageSubscriberID", "IsActive", "IsDeleted", "TFEventMessageSubscriberFilter")
VALUES (E'460f71d2-47bb-11e4-bc90-6ffc47e436f3', E'96ea8d42-47c2-11e4-8e0f-e3daeaa9f723', True, False, NULL);

-- payment tasks
INSERT INTO public."TFEventTFEventMessageSubscriber" ("TFEventID", "TFEventMessageSubscriberID", "IsActive", "IsDeleted", "TFEventMessageSubscriberFilter")
VALUES (E'b7fba438-4f8f-11e4-b8f6-5b4d4f08b608', E'b7fbcb3e-4f8f-11e4-a726-236dc67efbde', True, False, NULL);

-- security tasks
INSERT INTO public."TFEventTFEventMessageSubscriber"("TFEventID", "TFEventMessageSubscriberID", "IsActive", "IsDeleted", "TFEventMessageSubscriberFilter")
VALUES ( E'4fb1b2c4-489f-11e4-8ad9-175db514c526', E'4fb1b2c4-489f-11e4-a026-2b96867a5561', True, False, NULL);

INSERT INTO public."TFEventTFEventMessageSubscriber"("TFEventID", "TFEventMessageSubscriberID", "IsActive", "IsDeleted", "TFEventMessageSubscriberFilter")
VALUES ( E'4fb1b2c4-489f-11e4-8ad9-175db514c526', E'9bfc5370-48b1-11e4-9968-1392d9ed7dfd', True, False, NULL);

-- Scheduled Tasks

INSERT INTO public."BusTaskHandler" ("BusTaskHandlerID", "Name", "ObjectTypeName", "IsActive", "IsDeleted", "ObjectTypeAssembly", "MessageTypeName", "MessageTypeAssembly")
VALUES (E'54e6b9b0-47f5-11e4-bdc4-1fff1c7f479e', E'UserNotLoggedInScheduledTask', E'Bec.TargetFramework.SB.TaskHandlers.ScheduledTaskHandlers.UserNotLoggedInScheduledTask, Bec.TargetFramework.SB.TaskHandlers', True, False, E'Bec.TargetFramework.SB.TaskHandlers', E'Bec.TargetFramework.SB.TaskHandlers.ScheduledTaskHandlers.TestTaskHandlerMessage', E'Bec.TargetFramework.SB.TaskHandlers');

INSERT INTO public."BusTask" ("BusTaskID", "Name", "Description", "CreatedOn", "IsActive", "IsDeleted", "BusTaskHandlerID")
VALUES (E'3b1ab5ea-47f5-11e4-8c12-d39d0d71000d', E'UserNotLoggedInScheduledTask', E'Reminds users not logged in for X periods', E'2014-09-29 00:00:00', True, False, E'54e6b9b0-47f5-11e4-bdc4-1fff1c7f479e');

INSERT INTO public."BusTaskSchedule" ("BusTaskScheduleID", "BusTaskID", "IntervalInMinutes", "IsActive", "IsDeleted")
VALUES (E'8e9cf002-47f5-11e4-9b97-03ba009b2b53', E'3b1ab5ea-47f5-11e4-8c12-d39d0d71000d', 200, True, False);




