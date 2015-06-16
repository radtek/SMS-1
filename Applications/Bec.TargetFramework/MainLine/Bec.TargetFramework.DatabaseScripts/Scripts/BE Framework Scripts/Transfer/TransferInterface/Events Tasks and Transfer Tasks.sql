DO $$
Declare TransferEventTypeID uuid;
Declare TransferEventID uuid;
Declare TransferSubscriberEventID uuid;
Begin

TransferEventTypeID := (select uuid_generate_v1());
TransferEventID := (select uuid_generate_v1());
TransferSubscriberEventID := (select uuid_generate_v1());

-- Test Event Subscriber
INSERT INTO public."BusEventType" ("BusEventTypeID", "Name")
VALUES (TransferEventTypeID, E'TransferEvent');

INSERT INTO public."BusEvent" ("BusEventID", "BusEventName", "BusEventDescription", "BusEventTypeID")
VALUES (TransferEventID, E'SearchEvent', E'SearchEvent', TransferEventTypeID);

INSERT INTO public."BusEventMessageSubscriber" ("BusEventMessageSubscriberID", "Name", "ObjectName", "ObjectAssembly", "DefaultMessageSubscriberFilter")
VALUES (TransferSubscriberEventID, E'ProcessSearchEvent', E'Bec.TargetFramework.SB.Messages.Events.ProcessSearchEvent', E'Bec.TargetFramework.SB.Messages', NULL);

INSERT INTO public."BusEventBusEventMessageSubscriber" ("BusEventID", "BusEventMessageSubscriberID", "IsActive", "IsDeleted", "BusEventMessageSubscriberFilter")
VALUES (TransferEventID, TransferSubscriberEventID, True, False, NULL);


END $$;
