do $$
declare orgid uuid;
begin
orgid = 'daa3edb07fd111e5aaf300155da95a16';


--users
delete from "UserAccounts" where "ID" in
 (select "UserID" from "UserAccountOrganisation" where "OrganisationID" = orgid);

--address
delete from "Address" where "ParentID" in
 (select "ContactID" from "Contact" where "ParentID" = orgid);

--contact
delete from "ContactRegulator" where "ContactID" in
 (select "ContactID" from "Contact" where "ParentID" = orgid);

delete from "Contact" where "ParentID" = orgid;

--notifications
delete from "NotificationRecipientLog" where "NotificationRecipientID" in
 (select "NotificationRecipientID" from "NotificationRecipient" where "UserAccountOrganisationID" in
 (select "UserAccountOrganisationID" from "UserAccountOrganisation" where "OrganisationID" = orgid));

delete from "NotificationRecipient" where "UserAccountOrganisationID" in
 (select "UserAccountOrganisationID" from "UserAccountOrganisation" where "OrganisationID" = orgid);

--transactions, orders, invoices, shopping carts
delete from "TransactionOrderProcessLog" where "TransactionOrderID" in
 (select "TransactionOrderID" from "TransactionOrder" where "InvoiceID" in
 (select "InvoiceID" from "Invoice" where "UserAccountOrganisationID" in
 (select "UserAccountOrganisationID" from "UserAccountOrganisation" where "OrganisationID" = orgid)));

delete from "TransactionOrderItem" where "InvoiceLineItemID" in
 (select "InvoiceLineItemID" from "InvoiceLineItem" where "InvoiceID" in
 (select "InvoiceID" from "Invoice" where "UserAccountOrganisationID" in
 (select "UserAccountOrganisationID" from "UserAccountOrganisation" where "OrganisationID" = orgid)));

 delete from "InvoiceLineItem" where "InvoiceID" in
 (select "InvoiceID" from "Invoice" where "UserAccountOrganisationID" in
 (select "UserAccountOrganisationID" from "UserAccountOrganisation" where "OrganisationID" = orgid));

  delete from "InvoiceProcessLog" where "InvoiceID" in
 (select "InvoiceID" from "Invoice" where "UserAccountOrganisationID" in
 (select "UserAccountOrganisationID" from "UserAccountOrganisation" where "OrganisationID" = orgid));

delete from "OrganisationLedgerTransaction" where "OrganisationLedgerAccountID" in
 (select "OrganisationLedgerAccountID" from "OrganisationLedgerAccount" where "OrganisationID" = orgid);

delete from "TransactionOrder" where "InvoiceID" in
 (select "InvoiceID" from "Invoice" where "UserAccountOrganisationID" in
 (select "UserAccountOrganisationID" from "UserAccountOrganisation" where "OrganisationID" = orgid));

delete from "Invoice" where "UserAccountOrganisationID" in
 (select "UserAccountOrganisationID" from "UserAccountOrganisation" where "OrganisationID" = orgid);

delete from "ShoppingCartItem" where "ShoppingCartID" in
 (select "ShoppingCartID" from "ShoppingCart" where "UserAccountOrganisationID" in
 (select "UserAccountOrganisationID" from "UserAccountOrganisation" where "OrganisationID" = orgid));

delete from "ShoppingCart" where "UserAccountOrganisationID" in
 (select "UserAccountOrganisationID" from "UserAccountOrganisation" where "OrganisationID" = orgid);

--sms transaction

delete from sms."SmsUserAccountOrganisationTransaction" where "SmsTransactionID" in
 (select "SmsTransactionID" from sms."SmsTransaction" where "OrganisationID" = orgid);

delete from sms."SmsTransaction" where "OrganisationID" = orgid;

--uao
delete from "UserAccountOrganisationGroup" where "UserAccountOrganisationID" in
 (select "UserAccountOrganisationID" from "UserAccountOrganisation" where "OrganisationID" = orgid);

delete from "UserAccountOrganisationRole" where "OrganisationRoleID" in
 (select "OrganisationRoleID" from "OrganisationRole" where "OrganisationID" = orgid);

delete from "UserAccountOrganisationStatus" where "UserAccountOrganisationID" in
 (select "UserAccountOrganisationID" from "UserAccountOrganisation" where "OrganisationID" = orgid);

delete from "UserAccountOrganisation" where "OrganisationID" = orgid;

--org
delete from "OrganisationRoleClaim" where "OrganisationID" = orgid;
delete from "OrganisationRole" where "OrganisationID" = orgid;
delete from "OrganisationStatus" where "OrganisationID" = orgid;
delete from "OrganisationStatusType" where "OrganisationID" = orgid;
delete from "OrganisationDetail" where "OrganisationID" = orgid;

delete from "OrganisationBankAccountStatus" where "OrganisationBankAccountID" in
 (select "OrganisationBankAccountID" from "OrganisationBankAccount" where "OrganisationID" = orgid);

delete from "OrganisationBankAccount" where "OrganisationID" = orgid;

delete from "OrganisationLedgerAccount" where "OrganisationID" = orgid;
delete from "OrganisationGroup" where "OrganisationID" = orgid;
delete from "OrganisationFinancialDetail" where "OrganisationID" = orgid;
delete from "Organisation" where "OrganisationID" = orgid;

end $$;