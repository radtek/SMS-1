﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 13/04/2015 17:29:38
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{

    [DataContractAttribute(IsReference=true)]
    [System.Serializable]
    public partial class AccountDTO
    {
        #region Constructors
  
        public AccountDTO() {
        }

        public AccountDTO(global::System.Guid accountID, string accountName, int countryTypeID, global::System.Nullable<int> accountClassificationTypeID, global::System.Nullable<int> customerTypeID, global::System.Nullable<int> businessTypeID, global::System.Nullable<int> preferredContactMethodID, global::System.Nullable<int> industryTypeID, int accountTypeID, global::System.Nullable<int> accountSubTypeID, string description, string emailAddress1, string emailAddress2, string emailAddress3, global::System.Nullable<bool> doNotPhone, global::System.Nullable<bool> doNotEmail, string fax, bool isPrivate, string telephone1, string telephone2, string telephone3, int stateTypeID, global::System.Guid ownerID, global::System.Nullable<System.Guid> contactID, global::System.Nullable<System.Guid> parentAccountID, global::System.Nullable<System.Guid> masterID, global::System.Nullable<bool> doNotTelephone, string mobileNumber1, string mobileNumber2, string mobileNumber3, global::System.Nullable<System.Guid> parentID, global::System.Nullable<int> accountCategoryID, bool isActive, global::System.Nullable<System.Guid> contactOrganisationID, global::System.Nullable<System.Guid> parentOrganisationID, bool isDeleted, global::System.Nullable<int> accountRelationshipTypeID, List<InvoiceLineItemDTO> invoiceLineItems, List<ShoppingCartItemDTO> shoppingCartItems, ContactDTO contact, OrganisationDTO organisation_ContactOrganisationID, OrganisationDTO organisation_ParentOrganisationID) {

          this.AccountID = accountID;
          this.AccountName = accountName;
          this.CountryTypeID = countryTypeID;
          this.AccountClassificationTypeID = accountClassificationTypeID;
          this.CustomerTypeID = customerTypeID;
          this.BusinessTypeID = businessTypeID;
          this.PreferredContactMethodID = preferredContactMethodID;
          this.IndustryTypeID = industryTypeID;
          this.AccountTypeID = accountTypeID;
          this.AccountSubTypeID = accountSubTypeID;
          this.Description = description;
          this.EmailAddress1 = emailAddress1;
          this.EmailAddress2 = emailAddress2;
          this.EmailAddress3 = emailAddress3;
          this.DoNotPhone = doNotPhone;
          this.DoNotEmail = doNotEmail;
          this.Fax = fax;
          this.IsPrivate = isPrivate;
          this.Telephone1 = telephone1;
          this.Telephone2 = telephone2;
          this.Telephone3 = telephone3;
          this.StateTypeID = stateTypeID;
          this.OwnerID = ownerID;
          this.ContactID = contactID;
          this.ParentAccountID = parentAccountID;
          this.MasterID = masterID;
          this.DoNotTelephone = doNotTelephone;
          this.MobileNumber1 = mobileNumber1;
          this.MobileNumber2 = mobileNumber2;
          this.MobileNumber3 = mobileNumber3;
          this.ParentID = parentID;
          this.AccountCategoryID = accountCategoryID;
          this.IsActive = isActive;
          this.ContactOrganisationID = contactOrganisationID;
          this.ParentOrganisationID = parentOrganisationID;
          this.IsDeleted = isDeleted;
          this.AccountRelationshipTypeID = accountRelationshipTypeID;
          this.InvoiceLineItems = invoiceLineItems;
          this.ShoppingCartItems = shoppingCartItems;
          this.Contact = contact;
          this.Organisation_ContactOrganisationID = organisation_ContactOrganisationID;
          this.Organisation_ParentOrganisationID = organisation_ParentOrganisationID;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid AccountID { get; set; }

        [DataMember]
        public string AccountName { get; set; }

        [DataMember]
        public int CountryTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> AccountClassificationTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> CustomerTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> BusinessTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> PreferredContactMethodID { get; set; }

        [DataMember]
        public global::System.Nullable<int> IndustryTypeID { get; set; }

        [DataMember]
        public int AccountTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> AccountSubTypeID { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string EmailAddress1 { get; set; }

        [DataMember]
        public string EmailAddress2 { get; set; }

        [DataMember]
        public string EmailAddress3 { get; set; }

        [DataMember]
        public global::System.Nullable<bool> DoNotPhone { get; set; }

        [DataMember]
        public global::System.Nullable<bool> DoNotEmail { get; set; }

        [DataMember]
        public string Fax { get; set; }

        [DataMember]
        public bool IsPrivate { get; set; }

        [DataMember]
        public string Telephone1 { get; set; }

        [DataMember]
        public string Telephone2 { get; set; }

        [DataMember]
        public string Telephone3 { get; set; }

        [DataMember]
        public int StateTypeID { get; set; }

        [DataMember]
        public global::System.Guid OwnerID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ContactID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentAccountID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> MasterID { get; set; }

        [DataMember]
        public global::System.Nullable<bool> DoNotTelephone { get; set; }

        [DataMember]
        public string MobileNumber1 { get; set; }

        [DataMember]
        public string MobileNumber2 { get; set; }

        [DataMember]
        public string MobileNumber3 { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public global::System.Nullable<int> AccountCategoryID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ContactOrganisationID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentOrganisationID { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<int> AccountRelationshipTypeID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<InvoiceLineItemDTO> InvoiceLineItems { get; set; }

        [DataMember]
        public List<ShoppingCartItemDTO> ShoppingCartItems { get; set; }

        [DataMember]
        public ContactDTO Contact { get; set; }

        [DataMember]
        public OrganisationDTO Organisation_ContactOrganisationID { get; set; }

        [DataMember]
        public OrganisationDTO Organisation_ParentOrganisationID { get; set; }

        #endregion
    }

}
