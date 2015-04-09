﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:50:53
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
    public partial class LRRegisterExtractDTO
    {
        #region Constructors
  
        public LRRegisterExtractDTO() {
        }

        public LRRegisterExtractDTO(global::System.Guid lRRegisterExtractID, global::System.Guid lRTitleID, string registerExtractData, global::System.DateTime createdOn, string createdBy, global::System.Nullable<System.Guid> productPurchaseProductTaskID, LRTitleDTO lRTitle, ProductPurchaseBusTaskProcessLogDTO productPurchaseBusTaskProcessLog) {

          this.LRRegisterExtractID = lRRegisterExtractID;
          this.LRTitleID = lRTitleID;
          this.RegisterExtractData = registerExtractData;
          this.CreatedOn = createdOn;
          this.CreatedBy = createdBy;
          this.ProductPurchaseProductTaskID = productPurchaseProductTaskID;
          this.LRTitle = lRTitle;
          this.ProductPurchaseBusTaskProcessLog = productPurchaseBusTaskProcessLog;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid LRRegisterExtractID { get; set; }

        [DataMember]
        public global::System.Guid LRTitleID { get; set; }

        [DataMember]
        public string RegisterExtractData { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ProductPurchaseProductTaskID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public LRTitleDTO LRTitle { get; set; }

        [DataMember]
        public ProductPurchaseBusTaskProcessLogDTO ProductPurchaseBusTaskProcessLog { get; set; }

        #endregion
    }

}
