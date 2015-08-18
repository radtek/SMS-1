delete from public."TransferInputMortgageApplicationData";
delete from public."AnalysisInputMortgageApplication";

INSERT INTO
  public."AnalysisInputMortgageApplication"
(
  "AnalysisInputMortgageApplicationID",
  "CreatedOn",
  "IsActive",
  "IsDeleted",
  "AnalysisInputSchemaID",
  "AnalysisInputSchemaVersionNumber",
  "CreatedBy",
  "ModifiedOn",
  "ModifiedBy",
  "Lender",
  "Domain",
  "MortgageApplicationNumber",
  "SearchReferenceNumber"
)

select ai."AnalysisInputMortgageApplicationID",ai."CreatedOn", ai."IsActive",ai."IsDeleted",'10364194-03ae-11e5-ab52-00155d0a1426',1,'',null,null,ad."Lender",ad."Domain",ad."MortgageApplicationNumber",ad."SearchReferenceKey" from "XAnalysisInputMortgageApplication" ai

left outer join "XAnalysisInputMortgageApplicationDetail" ad on ad."AnalysisInputMortgageApplicationID" = ai."AnalysisInputMortgageApplicationID"

where ad."Domain" is not null

INSERT INTO
  public."TransferInputMortgageApplicationData"
(
  "IsActive",
  "IsDeleted",
  "CreatedOn",
  "CreatedBy",
  "ModifiedOn",
  "ModifiedBy",
  "InputData",
  "AnalysisInputMortgageApplicationID"
)
select ai."IsActive",ai."IsDeleted",ai."CreatedOn",'',null,null,ai."InputData",ai."AnalysisInputMortgageApplicationID" from "XAnalysisInputMortgageApplication" ai

left outer join "XAnalysisInputMortgageApplicationDetail" ad on ad."AnalysisInputMortgageApplicationID" = ai."AnalysisInputMortgageApplicationID"


where ad."Domain" is not null and exists (select aii."AnalysisInputMortgageApplicationID" from "AnalysisInputMortgageApplication" aii
where aii."AnalysisInputMortgageApplicationID" = ai."AnalysisInputMortgageApplicationID")