﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:20 AM
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
    public partial class StsSearchDTO
    {
        #region Constructors
  
        public StsSearchDTO() {
        }

        public StsSearchDTO(global::System.Guid stsSearchID, global::System.Nullable<int> stsSearchTypeID, global::System.Nullable<int> stsSearchSubTypeID, global::System.Nullable<int> stsSearchCategoryID, global::System.Nullable<int> stsSearchSubCategoryID, string internalReferenceNumber, bool isActive, bool isDeleted, global::System.Guid assignedToUserAccountOrganisationID, global::System.DateTime createdOn, List<StsSearchDetailDTO> stsSearchDetails, List<StsSearchProcessLogDTO> stsSearchProcessLogs, List<StsSearchRelationDTO> stsSearchRelations_BuyerStsSearchID, List<StsSearchRelationDTO> stsSearchRelations_SellerStsSearchID, UserAccountOrganisationDTO userAccountOrganisation) {

          this.StsSearchID = stsSearchID;
          this.StsSearchTypeID = stsSearchTypeID;
          this.StsSearchSubTypeID = stsSearchSubTypeID;
          this.StsSearchCategoryID = stsSearchCategoryID;
          this.StsSearchSubCategoryID = stsSearchSubCategoryID;
          this.InternalReferenceNumber = internalReferenceNumber;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.AssignedToUserAccountOrganisationID = assignedToUserAccountOrganisationID;
          this.CreatedOn = createdOn;
          this.StsSearchDetails = stsSearchDetails;
          this.StsSearchProcessLogs = stsSearchProcessLogs;
          this.StsSearchRelations_BuyerStsSearchID = stsSearchRelations_BuyerStsSearchID;
          this.StsSearchRelations_SellerStsSearchID = stsSearchRelations_SellerStsSearchID;
          this.UserAccountOrganisation = userAccountOrganisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid StsSearchID { get; set; }

        [DataMember]
        public global::System.Nullable<int> StsSearchTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> StsSearchSubTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> StsSearchCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<int> StsSearchSubCategoryID { get; set; }

        [DataMember]
        public string InternalReferenceNumber { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid AssignedToUserAccountOrganisationID { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<StsSearchDetailDTO> StsSearchDetails { get; set; }

        [DataMember]
        public List<StsSearchProcessLogDTO> StsSearchProcessLogs { get; set; }

        [DataMember]
        public List<StsSearchRelationDTO> StsSearchRelations_BuyerStsSearchID { get; set; }

        [DataMember]
        public List<StsSearchRelationDTO> StsSearchRelations_SellerStsSearchID { get; set; }

        [DataMember]
        public UserAccountOrganisationDTO UserAccountOrganisation { get; set; }

        #endregion
    }

}
