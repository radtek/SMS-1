﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
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
    public partial class ContactDTO
    {
        #region Constructors
  
        public ContactDTO() {
        }

        public ContactDTO(global::System.Guid contactID, string contactName, global::System.Nullable<System.Guid> masterContactID, global::System.Guid parentID, global::System.Nullable<System.Guid> ownerID, string customerTypeID, global::System.Nullable<int> preferredContactMethodID, global::System.Nullable<bool> isBackOfficeCustomer, string salutation, string jobTitle, string firstName, string department, string nickName, string middleName, string lastName, global::System.Nullable<System.DateTime> birthDate, string description, global::System.Nullable<int> genderTypeID, global::System.Nullable<bool> hasChildren, global::System.Nullable<int> educationTypeID, string webSiteURL, string emailAddress1, string emailAddress2, string emailAddress3, string assistantName, string assistantPhone, string managerName, string managerPhone, global::System.Nullable<int> countryTypeID, global::System.Nullable<bool> doNotFax, global::System.Nullable<bool> doNotEmail, global::System.Nullable<bool> doNotTelephone, global::System.Nullable<bool> isPrivate, string telephone1, string telephone2, string telephone3, string fax, string mobileNumber1, string mobileNumber2, string mobileNumber3, global::System.Nullable<int> organisationUnitID, global::System.Nullable<System.Guid> parentContactID, bool isPrimaryContact, global::System.Nullable<int> contactTypeID, global::System.Nullable<int> contactSubTypeID, global::System.Nullable<int> contactCategoryID, bool isActive, bool isDeleted, string firmName, global::System.Nullable<long> rowVersion, List<ContactNameDTO> contactNames, List<ContactPhoneDTO> contactPhones, List<ContactRegulatorDTO> contactRegulators, List<AccountDTO> accounts, List<UserAccountOrganisationDTO> userAccountOrganisations, List<OrganisationDTO> organisations) {

          this.ContactID = contactID;
          this.ContactName = contactName;
          this.MasterContactID = masterContactID;
          this.ParentID = parentID;
          this.OwnerID = ownerID;
          this.CustomerTypeID = customerTypeID;
          this.PreferredContactMethodID = preferredContactMethodID;
          this.IsBackOfficeCustomer = isBackOfficeCustomer;
          this.Salutation = salutation;
          this.JobTitle = jobTitle;
          this.FirstName = firstName;
          this.Department = department;
          this.NickName = nickName;
          this.MiddleName = middleName;
          this.LastName = lastName;
          this.BirthDate = birthDate;
          this.Description = description;
          this.GenderTypeID = genderTypeID;
          this.HasChildren = hasChildren;
          this.EducationTypeID = educationTypeID;
          this.WebSiteURL = webSiteURL;
          this.EmailAddress1 = emailAddress1;
          this.EmailAddress2 = emailAddress2;
          this.EmailAddress3 = emailAddress3;
          this.AssistantName = assistantName;
          this.AssistantPhone = assistantPhone;
          this.ManagerName = managerName;
          this.ManagerPhone = managerPhone;
          this.CountryTypeID = countryTypeID;
          this.DoNotFax = doNotFax;
          this.DoNotEmail = doNotEmail;
          this.DoNotTelephone = doNotTelephone;
          this.IsPrivate = isPrivate;
          this.Telephone1 = telephone1;
          this.Telephone2 = telephone2;
          this.Telephone3 = telephone3;
          this.Fax = fax;
          this.MobileNumber1 = mobileNumber1;
          this.MobileNumber2 = mobileNumber2;
          this.MobileNumber3 = mobileNumber3;
          this.OrganisationUnitID = organisationUnitID;
          this.ParentContactID = parentContactID;
          this.IsPrimaryContact = isPrimaryContact;
          this.ContactTypeID = contactTypeID;
          this.ContactSubTypeID = contactSubTypeID;
          this.ContactCategoryID = contactCategoryID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.FirmName = firmName;
          this.RowVersion = rowVersion;
          this.ContactNames = contactNames;
          this.ContactPhones = contactPhones;
          this.ContactRegulators = contactRegulators;
          this.Accounts = accounts;
          this.UserAccountOrganisations = userAccountOrganisations;
          this.Organisations = organisations;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ContactID { get; set; }

        [DataMember]
        public string ContactName { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> MasterContactID { get; set; }

        [DataMember]
        public global::System.Guid ParentID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OwnerID { get; set; }

        [DataMember]
        public string CustomerTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> PreferredContactMethodID { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsBackOfficeCustomer { get; set; }

        [DataMember]
        public string Salutation { get; set; }

        [DataMember]
        public string JobTitle { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string Department { get; set; }

        [DataMember]
        public string NickName { get; set; }

        [DataMember]
        public string MiddleName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> BirthDate { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public global::System.Nullable<int> GenderTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<bool> HasChildren { get; set; }

        [DataMember]
        public global::System.Nullable<int> EducationTypeID { get; set; }

        [DataMember]
        public string WebSiteURL { get; set; }

        [DataMember]
        public string EmailAddress1 { get; set; }

        [DataMember]
        public string EmailAddress2 { get; set; }

        [DataMember]
        public string EmailAddress3 { get; set; }

        [DataMember]
        public string AssistantName { get; set; }

        [DataMember]
        public string AssistantPhone { get; set; }

        [DataMember]
        public string ManagerName { get; set; }

        [DataMember]
        public string ManagerPhone { get; set; }

        [DataMember]
        public global::System.Nullable<int> CountryTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<bool> DoNotFax { get; set; }

        [DataMember]
        public global::System.Nullable<bool> DoNotEmail { get; set; }

        [DataMember]
        public global::System.Nullable<bool> DoNotTelephone { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsPrivate { get; set; }

        [DataMember]
        public string Telephone1 { get; set; }

        [DataMember]
        public string Telephone2 { get; set; }

        [DataMember]
        public string Telephone3 { get; set; }

        [DataMember]
        public string Fax { get; set; }

        [DataMember]
        public string MobileNumber1 { get; set; }

        [DataMember]
        public string MobileNumber2 { get; set; }

        [DataMember]
        public string MobileNumber3 { get; set; }

        [DataMember]
        public global::System.Nullable<int> OrganisationUnitID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentContactID { get; set; }

        [DataMember]
        public bool IsPrimaryContact { get; set; }

        [DataMember]
        public global::System.Nullable<int> ContactTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> ContactSubTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> ContactCategoryID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public string FirmName { get; set; }

        [DataMember]
        public global::System.Nullable<long> RowVersion { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<ContactNameDTO> ContactNames { get; set; }

        [DataMember]
        public List<ContactPhoneDTO> ContactPhones { get; set; }

        [DataMember]
        public List<ContactRegulatorDTO> ContactRegulators { get; set; }

        [DataMember]
        public List<AccountDTO> Accounts { get; set; }

        [DataMember]
        public List<UserAccountOrganisationDTO> UserAccountOrganisations { get; set; }

        [DataMember]
        public List<OrganisationDTO> Organisations { get; set; }

        #endregion
    }

}
