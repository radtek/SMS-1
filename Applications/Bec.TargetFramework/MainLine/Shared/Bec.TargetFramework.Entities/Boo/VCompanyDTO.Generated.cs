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
    public partial class VCompanyDTO
    {
        #region Constructors
  
        public VCompanyDTO() {
        }

        public VCompanyDTO(global::System.Guid companyId, string companyName, global::System.Nullable<System.DateTime> companyRecordCreated, global::System.Nullable<bool> isCompanyVerified, global::System.Nullable<bool> isCompanyPinCreated, string companyPinCode, global::System.Nullable<System.DateTime> companyPinCreated, string systemAdminTitle, string systemAdminFirstName, string systemAdminLastName, string systemAdminTel, string systemAdminEmail, string companyRegulator, string companyOtherRegulator, string companyAddress1, string companyAddress2, string companyTownCity, string companyCounty, string companyPostCode, string additionalAddressInformation, string returnUrl) {

          this.CompanyId = companyId;
          this.CompanyName = companyName;
          this.CompanyRecordCreated = companyRecordCreated;
          this.IsCompanyVerified = isCompanyVerified;
          this.IsCompanyPinCreated = isCompanyPinCreated;
          this.CompanyPinCode = companyPinCode;
          this.CompanyPinCreated = companyPinCreated;
          this.SystemAdminTitle = systemAdminTitle;
          this.SystemAdminFirstName = systemAdminFirstName;
          this.SystemAdminLastName = systemAdminLastName;
          this.SystemAdminTel = systemAdminTel;
          this.SystemAdminEmail = systemAdminEmail;
          this.CompanyRegulator = companyRegulator;
          this.CompanyOtherRegulator = companyOtherRegulator;
          this.CompanyAddress1 = companyAddress1;
          this.CompanyAddress2 = companyAddress2;
          this.CompanyTownCity = companyTownCity;
          this.CompanyCounty = companyCounty;
          this.CompanyPostCode = companyPostCode;
          this.AdditionalAddressInformation = additionalAddressInformation;
          this.ReturnUrl = returnUrl;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid CompanyId { get; set; }

        [DataMember]
        public string CompanyName { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> CompanyRecordCreated { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsCompanyVerified { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsCompanyPinCreated { get; set; }

        [DataMember]
        public string CompanyPinCode { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> CompanyPinCreated { get; set; }

        [DataMember]
        public string SystemAdminTitle { get; set; }

        [DataMember]
        public string SystemAdminFirstName { get; set; }

        [DataMember]
        public string SystemAdminLastName { get; set; }

        [DataMember]
        public string SystemAdminTel { get; set; }

        [DataMember]
        public string SystemAdminEmail { get; set; }

        [DataMember]
        public string CompanyRegulator { get; set; }

        [DataMember]
        public string CompanyOtherRegulator { get; set; }

        [DataMember]
        public string CompanyAddress1 { get; set; }

        [DataMember]
        public string CompanyAddress2 { get; set; }

        [DataMember]
        public string CompanyTownCity { get; set; }

        [DataMember]
        public string CompanyCounty { get; set; }

        [DataMember]
        public string CompanyPostCode { get; set; }

        [DataMember]
        public string AdditionalAddressInformation { get; set; }

        [DataMember]
        public string ReturnUrl { get; set; }

        #endregion
    }

}
