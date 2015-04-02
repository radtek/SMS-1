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
    public partial class VBranchDTO
    {
        #region Constructors
  
        public VBranchDTO() {
        }

        public VBranchDTO(global::System.Nullable<System.Guid> parentOrganisationID, global::System.Nullable<System.Guid> branchOrganisationID, bool isHeadOffice, global::System.Guid contactID, string branchName, string contactName, string emailAddress1, string telephone1, bool isPrimaryContact, bool isDeleted, string telephone2, string mobileNumber1, string mobileNumber2, string emailAddress2, string webSiteURL, global::System.Nullable<int> contactCategoryID, global::System.Nullable<int> contactTypeID) {

          this.ParentOrganisationID = parentOrganisationID;
          this.BranchOrganisationID = branchOrganisationID;
          this.IsHeadOffice = isHeadOffice;
          this.ContactID = contactID;
          this.BranchName = branchName;
          this.ContactName = contactName;
          this.EmailAddress1 = emailAddress1;
          this.Telephone1 = telephone1;
          this.IsPrimaryContact = isPrimaryContact;
          this.IsDeleted = isDeleted;
          this.Telephone2 = telephone2;
          this.MobileNumber1 = mobileNumber1;
          this.MobileNumber2 = mobileNumber2;
          this.EmailAddress2 = emailAddress2;
          this.WebSiteURL = webSiteURL;
          this.ContactCategoryID = contactCategoryID;
          this.ContactTypeID = contactTypeID;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Nullable<System.Guid> ParentOrganisationID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> BranchOrganisationID { get; set; }

        [DataMember]
        public bool IsHeadOffice { get; set; }

        [DataMember]
        public global::System.Guid ContactID { get; set; }

        [DataMember]
        public string BranchName { get; set; }

        [DataMember]
        public string ContactName { get; set; }

        [DataMember]
        public string EmailAddress1 { get; set; }

        [DataMember]
        public string Telephone1 { get; set; }

        [DataMember]
        public bool IsPrimaryContact { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public string Telephone2 { get; set; }

        [DataMember]
        public string MobileNumber1 { get; set; }

        [DataMember]
        public string MobileNumber2 { get; set; }

        [DataMember]
        public string EmailAddress2 { get; set; }

        [DataMember]
        public string WebSiteURL { get; set; }

        [DataMember]
        public global::System.Nullable<int> ContactCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<int> ContactTypeID { get; set; }

        #endregion
    }

}
