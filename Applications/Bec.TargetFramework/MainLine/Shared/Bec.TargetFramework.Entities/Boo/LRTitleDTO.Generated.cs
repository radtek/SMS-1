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
    public partial class LRTitleDTO
    {
        #region Constructors
  
        public LRTitleDTO() {
        }

        public LRTitleDTO(global::System.Guid lRTitleID, string titleNumber, global::System.Guid stsPropertyID, string description, global::System.DateTime createdOn, string createdBy, global::System.Nullable<System.Guid> parentID, global::System.Guid productPurchaseProductTaskID, global::System.Nullable<System.Guid> stsSearchPropertyID, int lRPropertyTenureTypeID, global::System.Guid addressID, bool isActive, bool isDeleted, List<LRDocumentDTO> lRDocuments, List<LRRegisterExtractDTO> lRRegisterExtracts, AddressDTO address, ProductPurchaseBusTaskProcessLogDTO productPurchaseBusTaskProcessLog) {

          this.LRTitleID = lRTitleID;
          this.TitleNumber = titleNumber;
          this.StsPropertyID = stsPropertyID;
          this.Description = description;
          this.CreatedOn = createdOn;
          this.CreatedBy = createdBy;
          this.ParentID = parentID;
          this.ProductPurchaseProductTaskID = productPurchaseProductTaskID;
          this.StsSearchPropertyID = stsSearchPropertyID;
          this.LRPropertyTenureTypeID = lRPropertyTenureTypeID;
          this.AddressID = addressID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.LRDocuments = lRDocuments;
          this.LRRegisterExtracts = lRRegisterExtracts;
          this.Address = address;
          this.ProductPurchaseBusTaskProcessLog = productPurchaseBusTaskProcessLog;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid LRTitleID { get; set; }

        [DataMember]
        public string TitleNumber { get; set; }

        [DataMember]
        public global::System.Guid StsPropertyID { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public global::System.Guid ProductPurchaseProductTaskID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> StsSearchPropertyID { get; set; }

        [DataMember]
        public int LRPropertyTenureTypeID { get; set; }

        [DataMember]
        public global::System.Guid AddressID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<LRDocumentDTO> LRDocuments { get; set; }

        [DataMember]
        public List<LRRegisterExtractDTO> LRRegisterExtracts { get; set; }

        [DataMember]
        public AddressDTO Address { get; set; }

        [DataMember]
        public ProductPurchaseBusTaskProcessLogDTO ProductPurchaseBusTaskProcessLog { get; set; }

        #endregion
    }

}
