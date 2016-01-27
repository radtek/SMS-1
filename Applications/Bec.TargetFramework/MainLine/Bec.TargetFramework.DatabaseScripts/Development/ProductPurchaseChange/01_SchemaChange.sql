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