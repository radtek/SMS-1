truncate table "TransferTaskCoordinatorProcessLog";
delete from "TransferInterfaceProcessLogInput";
delete from "TransferInterfaceProcessLog";

-- Step 1 DetermineSearchScopeForSiraBatch
SELECT
	pl."CreatedOn",
  pl."TransferInterfaceProcessLogID",
  pl."TransferInterfaceReferenceNumber",
  tis."Name" as "StepName",
  pls."Name" as "StatusName",
  pl."HasError",
  pl."ProcessMessage"
FROM
  public."TransferInterfaceProcessLog" pl

  left outer join "vStatusType" pls on pls."StatusTypeValueID" = pl."StatusTypeValueID"
  left outer join "TransferInterfaceStep" tis on tis."TransferInterfaceStepID" = pl."TransferInterfaceStepID" and tis."TransferInterfaceStepVersionNumber" = pl."TransferInterfaceStepVersionNumber"

 order by "CreatedOn" desc ;

-- Step 2 ProcessSearchForSiraBatch

-- Input Data
 SELECT
  pl."CreateOn",
  pl."TransferInterfaceProcessLogID",
  pl."TransferInterfaceReferenceNumber",
  pl."TransferInputMortgageApplicationDataID",
  pls."Name" as "StatusName",
  pl."HasError",
  pl."ProcessDetail",
  pl."ProcessMessage",pl."ProcessLogDataID"
FROM
  public."TransferInterfaceProcessLogInput" pl

  left outer join "vStatusType" pls on pls."StatusTypeValueID" = pl."StatusTypeValueID"

 order by pl."CreateOn" desc;

 --delete from "TransferInterfaceProcessLogInput" where "StatusTypeValueID" = (select "StatusTypeValueID" from "StatusTypeValue" where "Name" = 'Successful Inclusion in Batch');

-- Step 2 Transfer Task Data
SELECT
  pl."CreateOn",
  pl."TransferInterfaceProcessLogID",
  pl."TransferInterfaceReferenceNumber",
  pl."TransferInputMortgageApplicationDataID",
  pls."Name" as "TransferInterfaceProcessLogStatusName",
  pl."HasError" as "TransferInterfaceHasError",
  pl."ProcessMessage" as "TransferInterfaceProcessMessage",
  tcs."Name" as "TransferTaskProcessLogStatusName",
  tc."HasError" as "TransferTaskProcessLogHasError",
  tc."ProcessMessage" as "TransferTaskProcessLogProcessMessage"
FROM
  public."TransferInterfaceProcessLogInput" pl

  left outer join "vStatusType" pls on pls."StatusTypeValueID" = pl."StatusTypeValueID"
  inner  join "TransferTaskCoordinatorProcessLog" tc on tc."Reference" = CAST(pl."TransferInterfaceProcessLogInputID" as varchar)
  left outer join "vStatusType" tcs on tcs."StatusTypeValueID" = tc."StatusTypeValueID"

 order by pl."CreateOn"