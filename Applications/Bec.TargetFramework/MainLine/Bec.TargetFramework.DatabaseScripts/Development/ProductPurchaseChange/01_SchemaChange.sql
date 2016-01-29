ALTER TABLE sms."SmsTransaction"
  ADD COLUMN "IsProductPushed" BOOLEAN DEFAULT false NOT NULL;
  
ALTER TABLE sms."SmsTransaction"
  ADD COLUMN "InvoiceID" UUID;
  
ALTER TABLE sms."SmsTransaction"
  ADD CONSTRAINT "SmsTransaction_Invoice_fk" FOREIGN KEY ("InvoiceID")
    REFERENCES public."Invoice"("InvoiceID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE;




INSERT INTO public."ClassificationTypeCategory"("ClassificationTypeCategoryID", "Name")
VALUES (70,'DeductionTypeID');
  
INSERT INTO public."ClassificationType"("Name", "Description", "ClassificationTypeCategoryID", "IsActive", "IsDeleted")
VALUES ('Sales Tax','Value Added Tax',70,true,false);


-- Deduction Template for UK
INSERT INTO
  public."DeductionTemplate"
(
  "DeductionTypeID",
  "Name",
  "Description",
  "IsActive",
  "IsDeleted",
  "IsPercentageBased",
  "DeductionTemplateVersionNumber"
)
VALUES (
  (select c."ClassificationTypeID" from "ClassificationType" c where c."ClassificationTypeCategoryID" = 70 and c."Name" = 'Sales Tax' limit 1),
  'VAT',
  'Value Added Tax',
  true,
  false,
  true,
  1
);

INSERT INTO
  public."CountryDeductionTemplate"
(
  "DeductionTemplateID",
  "CountryCode",
  "DeductionPercentage",
  "DeductionValue",
  "IsActive",
  "IsDeleted",
  "IsAppliedToAllOrders",
  "DeductionTemplateVersionNumber"
)
select
dt."DeductionTemplateID",
'UK',
0.20,
0,
true,
false,
true,
dt."DeductionTemplateVersionNumber"

  from "DeductionTemplate" dt where dt."DeductionTypeID" = (select c."ClassificationTypeID" from "ClassificationType" c where c."ClassificationTypeCategoryID" = 70 and c."Name" = 'Sales Tax' limit 1) limit 1;


-- Deduction for UK
INSERT INTO
  public."Deduction"
(
  "DeductionTypeID",
  "Name",
  "Description",
  "IsActive",
  "IsDeleted",
  "IsPercentageBased",
  "DeductionVersionNumber"
)
select
dt."DeductionTypeID",
dt."Name",
dt."Description",
true,
false,
true,
1
  from "DeductionTemplate" dt where dt."DeductionTypeID" = (select c."ClassificationTypeID" from "ClassificationType" c where c."ClassificationTypeCategoryID" = 70 and c."Name" = 'Sales Tax' limit 1) limit 1;

INSERT INTO
  public."CountryDeduction"
(
  "CountryCode",
  "DeductionPercentage",
  "DeductionValue",
  "IsActive",
  "IsDeleted",
  "IsAppliedToAllOrders",
  "DeductionID",
  "DeductionVersionNumber"
)
SELECT
  cdt."CountryCode",
  cdt."DeductionPercentage",
 cdt."DeductionValue",
  true,
  false,
  cdt."IsAppliedToAllOrders",
  d."DeductionID",
  d."DeductionVersionNumber"
FROM
  public."CountryDeductionTemplate" cdt

  left outer join "DeductionTemplate" dt on dt."DeductionTemplateID" = cdt."DeductionTemplateID" and dt."DeductionTemplateVersionNumber" = cdt."DeductionTemplateVersionNumber"
  left outer join "Deduction" d on d."DeductionTypeID" = (select c."ClassificationTypeID" from "ClassificationType" c where c."ClassificationTypeCategoryID" = 70 and c."Name" = 'Sales Tax' limit 1)
  ;
