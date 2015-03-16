-- NotificationConstruct
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (8900000,'NotificationConstructTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (101,'NotificationConstructSubTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (102,'NotificationConstructCategoryID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (103,'NotificationConstructSubCategoryID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (8900003,'NotificationStatusID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (4987,'New','',8900003,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (4988,'Sent','',8900003,true,false);

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (105,'NotificationExportFormatID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (4989,'HTML','',8900002,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (4990,'HTML5','',8900002,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (4991,'PDF','',8900002,true,false);

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (8900001,'NotificationDeliveryMethodID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (4992,'Email','',8900001,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (4993,'System','',8900001,true,false);


INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (4994,'Alert','',8900000,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (4993,'Task','',8900000,true,false);



-- Product
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (110,'ProductTypeID');

INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('Supplier Product','',110,true,false);

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (111,'ProductSubTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (112,'ProductCategoryID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (113,'ProductSubCategoryID');

-- Subscription

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (8001,'SubscriptionStatusID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800100,'Future','',8001,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800101,'In Trial','',8001,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800102,'Active','',8001,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800103,'Non Renewing','',8001,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800104,'Cancelled','',8001,true,false);

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (8002,'CancelReasonID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800200,'Not Paid','',8002,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800201,'No Card','',8002,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800202,'Fraud Review Failed','',8002,true,false);

-- Payment Method

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (8003,'PaymentMethodID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (8500,'Card','',8003,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (8501,'BACS','',8003,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (8502,'Direct Debit','',8003,true,false);

-- Transaction Type

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (8004,'TransactionTypeID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800300,'Charge','',8004,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800301,'Payment','',8004,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800302,'Refund','',8004,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800303,'Payment Authorisation','',8004,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800304,'Adjustment','',8004,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800305,'Info','',8004,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800306,'Credit','',8004,true,false);

-- transaction charge type

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (8799,'TransactionChargeTypeID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800400,'One Time','',8799,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800401,'Delay Capture','',8799,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800402,'Initial','',8799,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800403,'Metered','',8799,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800404,'Quantity Based Component','',8799,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800405,'On Off Component','',8799,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800406,'Tax','',8799,true,false);


-- Period

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (8006,'PeriodUnitID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800500,'Week','',8006,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800501,'Month','',8006,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800502,'Year','',8006,true,false);

-- Plan Status

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (8007,'PlanStatusID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800600,'Active','',8007,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800601,'Archived','',8007,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800602,'Deleted','',8007,true,false);

-- discount type

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (8008,'DiscountTypeID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800800,'Fixed Amount','',8008,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800801,'Percentage','',8008,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800802,'Offer Quantity','',8008,true,false);

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (8009,'DurationTypeID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800700,'One Time','',8009,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800701,'Forever','',8009,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800702,'Limited Period','',8009,true,false);

-- discount status

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (8010,'DiscountStatusID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800900,'Active','',8010,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800901,'Expired','',8010,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (800902,'Archived','',8010,true,false);

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (8011,'DiscountAppliedOnID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801000,'Invoice Amount','',8011,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801001,'Specified Items Total','',8011,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801002,'Each Specified Item','',8011,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801003,'Each Unit of Specified Item','',8011,true,false);

-- billing

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (8012,'BillingChargeTypeID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801100,'Direct Debit','',8012,true,false);


INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801101,'BACS','',8012,true,false);

-- Ledger type

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (8500,'LedgerAccountTypeID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801200,'Deposit','',8500,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801201,'Sales','',8500,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801202,'Purchasing','',8500,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801203,'Merchant','',8500,true,false);

-- payment method type

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (8501,'PaymentMethodTypeID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID",  "Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (8000, 'Credit Card','',8501,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (8001,'Debit Card','',8501,true,false);

  INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (8002,'Direct Debit','',8501,true,false);

    INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (8003,'BACS','',8501,true,false);

  INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (8004,'Pre Authentication','',8501,true,false);

-- card type
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (9001,'PaymentCardTypeID');

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (9000,'Visa Credit','',9001,true,false);

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (9001,'Visa Debit','',9001,true,false);

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (9002,'Visa Business','',9001,true,false);

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (9003,'Visa UK Electron','',9001,true,false);

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (9004,'MasterCard Credit','',9001,true,false);

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (9005,'MasterCard Debit','',9001,true,false);

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (9006,'Maestro','',9001,true,false);

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (9007,'MasterCard Business','',9001,true,false);

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (9008,'Diners','',9001,true,false);

     INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (9009,'American Express','',9001,true,false);

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (9020,'Other','',9001,true,false);

     INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (9050,'Pre Authentication','',9001,true,false);

-- bus message

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (10000,'BusMessageTypeID');

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801300,'Atomic','',10000,true,false);

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801301,'Scheduled','',10000,true,false);

-- bus message status

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (10001,'BusMessageStatusID');

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801400,'Completed','',10001,true,false);

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801401,'Failed','',10001,true,false);

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801402,'Received','',10001,true,false);

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801403,'Sent','',10001,true,false);


-- invoice type

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (8801,'InvoiceTypeID');

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801500,'Scheduled','',8801,true,false);

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801501,'Manual','',8801,true,false);

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801502,'Online','',8801,true,false);

-- invoice line item type

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (8802,'InvoiceLineItemTypeID');

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801600,'Product','',8802,true,false);

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801601,'Plan Subscription','',8802,true,false);

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801602,'Credit Note','',8802,true,false);


   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801603,'Debit Note','',8802,true,false);


-- Invoice Category ID
-- invoice line item type

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (8803,'InvoiceAccountingStatusID');

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801700,'Paid Late','',8803,true,false);

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801701,'Arrears (BACS Only)','',8803,true,false);

   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801702,'DD Returned','',8803,true,false);


   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801703,'Credit Note','',8803,true,false);


   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801704,'Written Off','',8803,true,false);


   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801705,'Paid','',8803,true,false);


   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801706,'Pending','',8803,true,false);


   INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (801707,'Invoice Withdrawn','',8803,true,false);

-----


------- STS STUFF ---

-- Actor
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (810000,'ActorTypeID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (810001,'STS','',810000,true,false);

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (810101,'ActorSubTypeID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (810202,'ActorCategoryID');
INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (810303,'ActorSubCategoryID');

-- Search Categories

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (870000,'InviteTypeID');

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (870001,'InviteSubTypeID');

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (870002,'InviteCategoryID');

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (870003,'InviteSubCategoryID');

  INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (870004,'RejectReasonTypeID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (814000,'The address is wrong','',870004,true,false);
INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (814001,'The law firm is wrong','',870004,true,false);
INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (814002,'I am not purchasing a property','',870004,true,false);
INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (814003,'I am not selling a property','',870004,true,false);
INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (814004,'Other','',870004,true,false);

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (870005,'PropertyTenureID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (817000,'Freehold','',870005,true,false);
INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (817001,'Leasehold','',870005,true,false);

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (870006,'PropertySellerRelationshipTypeID');


INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (870007,'StsActorPrimarySecondaryRelationshipTypeID');

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (870008,'DepositFromTypeID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (818000,'Gift','',870008,true,false);
INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (818001,'Saving','',870008,true,false);
INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (818002,'Loan','',870008,true,false);
INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (818003,'Proceed from Sale','',870008,true,false);


INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (870009,'PlaceSeenMortgageBrokerTypeID');

  INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (870010,'RegisteredProprietorTypeID');


INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (870011,'SellingUnderAuthorityTypeID');

INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (871101,'Probate','',870011,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (871102,'Power of Attorney','',870011,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (871103,'Court Protection order','',870011,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (871104,'Registered Proprietor','',870011,true,false);

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (870012,'LenderID');

INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877000,'Abbey National Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877001,'Alliance & Leicester','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877002,'Amber Homeloans','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877003,'Bank of Ireland','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877004,'Bank of Scotland','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877005,'Barclays','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877006,'Barnsley Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877007,'The Bath Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877008,'The Beverley Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877009,'Birmingham Midshires','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877010,'Bradford & Bingley Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877011,'Bristol & West','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877012,'Britannia','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877013,'The Buckinghamshire Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877014,'The Cambridge Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877015,'Capital Home Loans','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877016,'The Chelsea Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877017,'The Cheltenham and Gloucester Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877018,'Chesham Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877019,'The Cheshire Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877020,'The Chorley & District Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877021,'Co-operative Insurance (CIS)','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877022,'Clydesdale Bank','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877023,'The Co-operative Bank','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877024,'Coventry Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877025,'Cumberland Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877026,'Darlington Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877027,'The Derbyshire','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877028,'Direct Line','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877029,'Dudley Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877030,'Dunfermline Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877031,'Earl Shilton Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877032,'Ecology Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877033,'Egg','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877034,'First Active','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877035,'First Direct','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877036,'First National','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877037,'First Trust Bank','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877038,'Furness Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877039,'Future Mortgages','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877040,'GMAC-RFC','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877041,'Halifax','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877042,'The Hanley Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877043,'Hinckley and Rugby Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877044,'Holmesdale Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877045,'HSBC','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877046,'iGroup','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877047,'ING Direct','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877048,'Intelligent Finance','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877049,'Ipswich Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877050,'Irish Permanent','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877051,'Kensington Mortgages','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877052,'Kent Reliance','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877053,'The Lambeth Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877054,'The Leeds Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877055,'Leek United Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877056,'Legal & General','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877057,'London Mortgage Company','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877058,'Loughborough','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877059,'The Mansfield Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877060,'The Market Harborough Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877061,'The Marsden Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877062,'Melton Mowbray Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877063,'Mercantile Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877064,'Monmouthshire Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877065,'The Mortgage Lender','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877066,'Mortgage Trust','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877067,'Mortgage Works','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877068,'Mortgages PLC','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877069,'National Counties Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877070,'Nationwide Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877071,'NatWest','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877072,'Newbury Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877073,'Newcastle Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877074,'Northern Bank','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877075,'Northern Rock','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877076,'The Norwich and Peterborough Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877077,'Nottingham Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877078,'The One Account','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877079,'Paragon Mortgages','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877080,'Penrith Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877081,'Pink Home Loans','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877082,'Principality','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877083,'Progressive Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877084,'Prudential','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877085,'The Royal Bank of Scotland','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877086,'Saffron Walden Hertfordshire and Essex Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877087,'Santander','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877088,'Scottish Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877089,'Scottish Widows Bank','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877090,'Skipton Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877091,'Southern Pacific','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877092,'Stafford Railway Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877093,'Standard Life Bank','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877094,'Stroud & Swindon','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877095,'Swansea Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877096,'Teachers Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877097,'Tesco','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877098,'Universal Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877099,'West Bromwich Building Society','',870012,true,false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (877100,'The Woolwich Bank','',870012,true,false);


  INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (870013,'IDDocumentTypeID');

INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (871300, ' Current valid UK/EU passport','',870013,true, false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (871301,' Current UK/EU photo card driving licence','',870013,true, false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (871302,' Current full UK driving licence (old paper style)','',870013,true, false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (871303,' Non EU passport & Residents visa','',870013,true, false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (871304,' Firearms certifcate','',870013,true, false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (871305,' Most recent mortgage statement','',870013,true, false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (871306,' Current year Local Authority Council Tax bill','',870013,true, false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (871307,' Local Authority rent card or tenancy agreement','',870013,true, false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (871308,' Bank/building society/credit union statement or passbook','',870013,true, false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (871309,' Utility Bill','',870013,true, false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (871310,' Current valid UK/EU passport','',870013,true, false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (871311,' Current UK/EU photo card driving licence','',870013,true, false);
INSERT INTO public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted") VALUES (871312,' Inland Revenue tax coding notications','',870013,true, false);

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (870014,'IDDocumentCategoryTypeID');

  INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (870015,'IDDocumentCertifiedByTypeID');

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (870016,'InstructedFirmTypeID');

  INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (870017,'StsSearchTypeID');

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (870018,'StsSearchSubTypeID');

  INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (870019,'StsSearchCategoryID');

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (870020,'StsSearchSubCategoryID');

  INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (870021,'StsPropertyTypeID');

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (870022,'StsPropertySubTypeID');


-- Notification Group Type

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (670001,'NotificationGroupTypeID');

  INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (670002,'NotificationGroupCategoryID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (670100,'General','',670001,true,false);

  INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (670101,'TermsConditions','',670001,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (670200,'General','',670002,true,false);

-- First Data

INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (1000000,'ErrorCodeTypeID');

  INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (1001000,'ErrorCodeCategoryID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (1000001,'FirstData Gateway','',1000000,true,false);

  INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (1000002,'FirstData Card Issuer','',1000000,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (1000003,'LREnquiryByPropertyDescription','',1000000,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (1000004,'LRRegisterExtractService','',1000000,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (1000005,'LROfficialCopyTitleKnown','',1000000,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (1000006,'LROfficialSearchWholeWithPriority','',1000000,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (1000007,'LROfficialSearchPartWithPriority','',1000000,true,false);


INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (1001001,'FirstData','',1001000,true,false);

  INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (1001002,'LandRegistry','',1001000,true,false);


-- Transaction Gateway ID

  INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (1100000,'TransactionGatewayID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (1100000,'FirstData Merchant Gateway','',1100000,true,false);



-- LRPropertyTenureTypeID

  INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (2100000,'LRPropertyTenureTypeID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (2100001,'Freehold','',2100000,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (2100002,'Other','',2100000,true,false);

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (2100003,'Leasehold','',2100000,true,false);
INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (2100004,'Commonhold','',2100000,true,false);
INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (2100005,'Feuhold','',2100000,true,false);
INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (2100006,'Mixed','',2100000,true,false);
INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (2100007,'Unknown','',2100000,true,false);
INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (2100008,'Unavailable','',2100000,true,false);
INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (2100009,'Caution Against First Registration','',2100000,true,false);
INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (2100010,'Rent Charge','',2100000,true,false);
INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (2100011,'Franchise','',2100000,true,false);
INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (2100012,'Profit A Prendre In Gross','',2100000,true,false);
INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (2100013,'Manor','',2100000,true,false);

INSERT INTO
  public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  ('LRDocument','',40,true,false);


-- Service Interface Type ID

  INSERT INTO
  public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
  (2200001,'ServiceInterfaceTypeID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (2200001,'Land Registry','',2200001,true,false);

-- Service Definition Type ID

INSERT INTO
public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES
(2200002,'ServiceDefinitionTypeID');

INSERT INTO
  public."ClassificationType"("ClassificationTypeID","Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES
  (2200002,'Land Registry Service','',2200002,true,false);
  