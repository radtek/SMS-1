update "NotificationConstruct" set "NotificationSubject" = 'Bank Account Notification' where "Name" in ('BankAccountCheckNoMatch', 'BankAccountMarkedAsFraudSuspicious', 'BankAccountMarkedAsSafe');

INSERT INTO public."ClassificationType" ("ClassificationTypeID", "Name", "Description", "ClassificationTypeCategoryID", "ParentClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES (803002, E'BankAccount', NULL, 2081, NULL, True, False);

ALTER TABLE public."Conversation"
  ADD COLUMN IsSystemMessage BOOLEAN DEFAULT false NOT NULL;