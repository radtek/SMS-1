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
    public partial class VOrganisationDetailDTO
    {
        #region Constructors
  
        public VOrganisationDetailDTO() {
        }

        public VOrganisationDetailDTO(global::System.Guid organisationID, string organisationName, int organisationTypeID, global::System.Nullable<int> organisationSubTypeID, global::System.Nullable<int> organisationCategoryID, bool isBranch, bool isHeadOffice, bool isActive, bool isDeleted, bool isUserOrganisation, global::System.DateTime createdOn, string createdBy, global::System.Nullable<System.DateTime> modifiedOn, string modifiedBy, global::System.Nullable<int> organisationSubCategoryID, global::System.Guid defaultOrganisationID, int defaultOrganisationVersionNumber, global::System.Guid parentID, global::System.Nullable<System.Guid> parentOrganisationID, global::System.Nullable<bool> isPaymentProvider, global::System.Guid contactID, string contactName, global::System.Nullable<System.Guid> masterContactID, global::System.Nullable<System.Guid> ownerID, string customerTypeID, global::System.Nullable<int> preferredContactMethodID, global::System.Nullable<bool> isBackOfficeCustomer, string salutation, string jobTitle, string firstName, string department, string nickName, string middleName, string lastName, global::System.Nullable<System.DateTime> birthDate, string description, global::System.Nullable<int> genderTypeID, global::System.Nullable<bool> hasChildren, global::System.Nullable<int> educationTypeID, string webSiteURL, string emailAddress1, string emailAddress2, string emailAddress3, string assistantName, string assistantPhone, string managerName, string managerPhone, global::System.Nullable<int> countryTypeID, global::System.Nullable<bool> doNotFax, global::System.Nullable<bool> doNotEmail, global::System.Nullable<bool> doNotTelephone, global::System.Nullable<bool> isPrivate, string telephone1, string telephone2, string telephone3, string fax, string mobileNumber1, string mobileNumber2, string mobileNumber3, global::System.Nullable<int> organisationUnitID, global::System.Nullable<System.Guid> parentContactID, bool isPrimaryContact, global::System.Nullable<int> contactTypeID, global::System.Nullable<int> contactSubTypeID, global::System.Nullable<int> contactCategoryID, string firmName, global::System.Guid addressID, string name, string primaryContactName, string line1, string line2, string line3, string city, string stateOrProvince, string county, string country, string postOfficeBox, string postalCode, string uTCOffSet, global::System.Nullable<double> latitude, global::System.Nullable<double> longitude, int addressTypeID, int addressNumber, global::System.Nullable<bool> isPrimaryAddress, global::System.Nullable<int> addressCategoryID, global::System.Nullable<int> addressSubTypeID, string buildingName, global::System.Nullable<int> order, string countryCode, string additionalAddressInformation, string town, bool isVATRegistered, string vATNumber, bool isCompanyHouseRegistered, string registeredCompanyNumber, global::System.Nullable<int> partnersCount, global::System.Nullable<int> registeredPractitionersCount, global::System.Nullable<int> staffCount, global::System.Nullable<int> monthlyCompletionsCount) {

          this.OrganisationID = organisationID;
          this.OrganisationName = organisationName;
          this.OrganisationTypeID = organisationTypeID;
          this.OrganisationSubTypeID = organisationSubTypeID;
          this.OrganisationCategoryID = organisationCategoryID;
          this.IsBranch = isBranch;
          this.IsHeadOffice = isHeadOffice;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsUserOrganisation = isUserOrganisation;
          this.CreatedOn = createdOn;
          this.CreatedBy = createdBy;
          this.ModifiedOn = modifiedOn;
          this.ModifiedBy = modifiedBy;
          this.OrganisationSubCategoryID = organisationSubCategoryID;
          this.DefaultOrganisationID = defaultOrganisationID;
          this.DefaultOrganisationVersionNumber = defaultOrganisationVersionNumber;
          this.ParentID = parentID;
          this.ParentOrganisationID = parentOrganisationID;
          this.IsPaymentProvider = isPaymentProvider;
          this.ContactID = contactID;
          this.ContactName = contactName;
          this.MasterContactID = masterContactID;
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
          this.FirmName = firmName;
          this.AddressID = addressID;
          this.Name = name;
          this.PrimaryContactName = primaryContactName;
          this.Line1 = line1;
          this.Line2 = line2;
          this.Line3 = line3;
          this.City = city;
          this.StateOrProvince = stateOrProvince;
          this.County = county;
          this.Country = country;
          this.PostOfficeBox = postOfficeBox;
          this.PostalCode = postalCode;
          this.UTCOffSet = uTCOffSet;
          this.Latitude = latitude;
          this.Longitude = longitude;
          this.AddressTypeID = addressTypeID;
          this.AddressNumber = addressNumber;
          this.IsPrimaryAddress = isPrimaryAddress;
          this.AddressCategoryID = addressCategoryID;
          this.AddressSubTypeID = addressSubTypeID;
          this.BuildingName = buildingName;
          this.Order = order;
          this.CountryCode = countryCode;
          this.AdditionalAddressInformation = additionalAddressInformation;
          this.Town = town;
          this.IsVATRegistered = isVATRegistered;
          this.VATNumber = vATNumber;
          this.IsCompanyHouseRegistered = isCompanyHouseRegistered;
          this.RegisteredCompanyNumber = registeredCompanyNumber;
          this.PartnersCount = partnersCount;
          this.RegisteredPractitionersCount = registeredPractitionersCount;
          this.StaffCount = staffCount;
          this.MonthlyCompletionsCount = monthlyCompletionsCount;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public string OrganisationName { get; set; }

        [DataMember]
        public int OrganisationTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> OrganisationSubTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> OrganisationCategoryID { get; set; }

        [DataMember]
        public bool IsBranch { get; set; }

        [DataMember]
        public bool IsHeadOffice { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public bool IsUserOrganisation { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> ModifiedOn { get; set; }

        [DataMember]
        public string ModifiedBy { get; set; }

        [DataMember]
        public global::System.Nullable<int> OrganisationSubCategoryID { get; set; }

        [DataMember]
        public global::System.Guid DefaultOrganisationID { get; set; }

        [DataMember]
        public int DefaultOrganisationVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid ParentID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentOrganisationID { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsPaymentProvider { get; set; }

        [DataMember]
        public global::System.Guid ContactID { get; set; }

        [DataMember]
        public string ContactName { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> MasterContactID { get; set; }

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
        public string FirmName { get; set; }

        [DataMember]
        public global::System.Guid AddressID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string PrimaryContactName { get; set; }

        [DataMember]
        public string Line1 { get; set; }

        [DataMember]
        public string Line2 { get; set; }

        [DataMember]
        public string Line3 { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string StateOrProvince { get; set; }

        [DataMember]
        public string County { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public string PostOfficeBox { get; set; }

        [DataMember]
        public string PostalCode { get; set; }

        [DataMember]
        public string UTCOffSet { get; set; }

        [DataMember]
        public global::System.Nullable<double> Latitude { get; set; }

        [DataMember]
        public global::System.Nullable<double> Longitude { get; set; }

        [DataMember]
        public int AddressTypeID { get; set; }

        [DataMember]
        public int AddressNumber { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsPrimaryAddress { get; set; }

        [DataMember]
        public global::System.Nullable<int> AddressCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<int> AddressSubTypeID { get; set; }

        [DataMember]
        public string BuildingName { get; set; }

        [DataMember]
        public global::System.Nullable<int> Order { get; set; }

        [DataMember]
        public string CountryCode { get; set; }

        [DataMember]
        public string AdditionalAddressInformation { get; set; }

        [DataMember]
        public string Town { get; set; }

        [DataMember]
        public bool IsVATRegistered { get; set; }

        [DataMember]
        public string VATNumber { get; set; }

        [DataMember]
        public bool IsCompanyHouseRegistered { get; set; }

        [DataMember]
        public string RegisteredCompanyNumber { get; set; }

        [DataMember]
        public global::System.Nullable<int> PartnersCount { get; set; }

        [DataMember]
        public global::System.Nullable<int> RegisteredPractitionersCount { get; set; }

        [DataMember]
        public global::System.Nullable<int> StaffCount { get; set; }

        [DataMember]
        public global::System.Nullable<int> MonthlyCompletionsCount { get; set; }

        #endregion
    }

}
