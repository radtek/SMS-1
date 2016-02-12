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
    public partial class VOrganisationWithStatusAndAdminDTO
    {
        #region Constructors
  
        public VOrganisationWithStatusAndAdminDTO() {
        }

        public VOrganisationWithStatusAndAdminDTO(global::System.Guid organisationID, string name, global::System.DateTime createdOn, string createdBy, global::System.Nullable<bool> organisationVerified, global::System.Nullable<System.DateTime> pinCreated, string pinCode, string organisationAdminSalutation, string organisationAdminFirstName, string organisationAdminLastName, string organisationAdminTelephone, string organisationAdminEmail, string regulator, string regulatorOther, string regulatorNumber, string line1, string line2, string town, string county, string postalCode, string additionalAddressInformation, global::System.Guid statusTypeID, global::System.Guid statusTypeValueID, int statusTypeVersionNumber, global::System.Nullable<System.Guid> organisationAdminUserID, string statusValueName, global::System.DateTime statusChangedOn, string statusChangedBy, string reason, string notes, global::System.Nullable<System.DateTime> organisationAdminCreated, global::System.Nullable<System.DateTime> verifiedOn, string verifiedBy, string verifiedNotes, global::System.Guid userAccountOrganisationID, string registeredAsName, global::System.Nullable<int> organisationRecommendationSourceID, global::System.Nullable<int> schemeID, int filesPerMonth, global::System.Nullable<long> activeSafeAccounts, global::System.Nullable<long> pendingValidationAccounts, string organisationTypeDescription, global::System.Nullable<int> brokerType, global::System.Nullable<int> brokerBusinessType, string authorityDelegatedBySalutation, string authorityDelegatedByFirstName, string authorityDelegatedByLastName, string authorityDelegatedByEmail) {

          this.OrganisationID = organisationID;
          this.Name = name;
          this.CreatedOn = createdOn;
          this.CreatedBy = createdBy;
          this.OrganisationVerified = organisationVerified;
          this.PinCreated = pinCreated;
          this.PinCode = pinCode;
          this.OrganisationAdminSalutation = organisationAdminSalutation;
          this.OrganisationAdminFirstName = organisationAdminFirstName;
          this.OrganisationAdminLastName = organisationAdminLastName;
          this.OrganisationAdminTelephone = organisationAdminTelephone;
          this.OrganisationAdminEmail = organisationAdminEmail;
          this.Regulator = regulator;
          this.RegulatorOther = regulatorOther;
          this.RegulatorNumber = regulatorNumber;
          this.Line1 = line1;
          this.Line2 = line2;
          this.Town = town;
          this.County = county;
          this.PostalCode = postalCode;
          this.AdditionalAddressInformation = additionalAddressInformation;
          this.StatusTypeID = statusTypeID;
          this.StatusTypeValueID = statusTypeValueID;
          this.StatusTypeVersionNumber = statusTypeVersionNumber;
          this.OrganisationAdminUserID = organisationAdminUserID;
          this.StatusValueName = statusValueName;
          this.StatusChangedOn = statusChangedOn;
          this.StatusChangedBy = statusChangedBy;
          this.Reason = reason;
          this.Notes = notes;
          this.OrganisationAdminCreated = organisationAdminCreated;
          this.VerifiedOn = verifiedOn;
          this.VerifiedBy = verifiedBy;
          this.VerifiedNotes = verifiedNotes;
          this.UserAccountOrganisationID = userAccountOrganisationID;
          this.RegisteredAsName = registeredAsName;
          this.OrganisationRecommendationSourceID = organisationRecommendationSourceID;
          this.SchemeID = schemeID;
          this.FilesPerMonth = filesPerMonth;
          this.ActiveSafeAccounts = activeSafeAccounts;
          this.PendingValidationAccounts = pendingValidationAccounts;
          this.OrganisationTypeDescription = organisationTypeDescription;
          this.BrokerType = brokerType;
          this.BrokerBusinessType = brokerBusinessType;
          this.AuthorityDelegatedBySalutation = authorityDelegatedBySalutation;
          this.AuthorityDelegatedByFirstName = authorityDelegatedByFirstName;
          this.AuthorityDelegatedByLastName = authorityDelegatedByLastName;
          this.AuthorityDelegatedByEmail = authorityDelegatedByEmail;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public global::System.Nullable<bool> OrganisationVerified { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> PinCreated { get; set; }

        [DataMember]
        public string PinCode { get; set; }

        [DataMember]
        public string OrganisationAdminSalutation { get; set; }

        [DataMember]
        public string OrganisationAdminFirstName { get; set; }

        [DataMember]
        public string OrganisationAdminLastName { get; set; }

        [DataMember]
        public string OrganisationAdminTelephone { get; set; }

        [DataMember]
        public string OrganisationAdminEmail { get; set; }

        [DataMember]
        public string Regulator { get; set; }

        [DataMember]
        public string RegulatorOther { get; set; }

        [DataMember]
        public string RegulatorNumber { get; set; }

        [DataMember]
        public string Line1 { get; set; }

        [DataMember]
        public string Line2 { get; set; }

        [DataMember]
        public string Town { get; set; }

        [DataMember]
        public string County { get; set; }

        [DataMember]
        public string PostalCode { get; set; }

        [DataMember]
        public string AdditionalAddressInformation { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeID { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeValueID { get; set; }

        [DataMember]
        public int StatusTypeVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OrganisationAdminUserID { get; set; }

        [DataMember]
        public string StatusValueName { get; set; }

        [DataMember]
        public global::System.DateTime StatusChangedOn { get; set; }

        [DataMember]
        public string StatusChangedBy { get; set; }

        [DataMember]
        public string Reason { get; set; }

        [DataMember]
        public string Notes { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> OrganisationAdminCreated { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> VerifiedOn { get; set; }

        [DataMember]
        public string VerifiedBy { get; set; }

        [DataMember]
        public string VerifiedNotes { get; set; }

        [DataMember]
        public global::System.Guid UserAccountOrganisationID { get; set; }

        [DataMember]
        public string RegisteredAsName { get; set; }

        [DataMember]
        public global::System.Nullable<int> OrganisationRecommendationSourceID { get; set; }

        [DataMember]
        public global::System.Nullable<int> SchemeID { get; set; }

        [DataMember]
        public int FilesPerMonth { get; set; }

        [DataMember]
        public global::System.Nullable<long> ActiveSafeAccounts { get; set; }

        [DataMember]
        public global::System.Nullable<long> PendingValidationAccounts { get; set; }

        [DataMember]
        public string OrganisationTypeDescription { get; set; }

        [DataMember]
        public global::System.Nullable<int> BrokerType { get; set; }

        [DataMember]
        public global::System.Nullable<int> BrokerBusinessType { get; set; }

        [DataMember]
        public string AuthorityDelegatedBySalutation { get; set; }

        [DataMember]
        public string AuthorityDelegatedByFirstName { get; set; }

        [DataMember]
        public string AuthorityDelegatedByLastName { get; set; }

        [DataMember]
        public string AuthorityDelegatedByEmail { get; set; }

        #endregion
    }

}
