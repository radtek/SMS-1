﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:53
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

        public VOrganisationWithStatusAndAdminDTO(global::System.Guid organisationID, string name, global::System.DateTime createdOn, global::System.Nullable<bool> organisationVerified, global::System.Nullable<System.DateTime> organisationPinCreated, global::System.Nullable<System.DateTime> organisationPinCode, string organisationAdminSalutation, string organisationAdminFirstName, string organisationAdminLastName, string organisationAdminTelephone, string organisationAdminEmail, string regulator, string regulatorOther, string line1, string line2, string town, string county, string postalCode, string additionalAddressInformation, global::System.Guid statusTypeID, global::System.Guid statusTypeValueID, int statusTypeVersionNumber, global::System.Nullable<System.Guid> organisationAdminUserID, string statusValueName) {

          this.OrganisationID = organisationID;
          this.Name = name;
          this.CreatedOn = createdOn;
          this.OrganisationVerified = organisationVerified;
          this.OrganisationPinCreated = organisationPinCreated;
          this.OrganisationPinCode = organisationPinCode;
          this.OrganisationAdminSalutation = organisationAdminSalutation;
          this.OrganisationAdminFirstName = organisationAdminFirstName;
          this.OrganisationAdminLastName = organisationAdminLastName;
          this.OrganisationAdminTelephone = organisationAdminTelephone;
          this.OrganisationAdminEmail = organisationAdminEmail;
          this.Regulator = regulator;
          this.RegulatorOther = regulatorOther;
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
        public global::System.Nullable<bool> OrganisationVerified { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> OrganisationPinCreated { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> OrganisationPinCode { get; set; }

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

        #endregion
    }

}
