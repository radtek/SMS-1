﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:07 PM
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
    public partial class LRDocumentDTO
    {
        #region Constructors
  
        public LRDocumentDTO() {
        }

        public LRDocumentDTO(global::System.Guid lRDocumentID, global::System.Guid lRTitleID, global::System.Guid attachmentID, bool isActive, bool isDeleted, global::System.Nullable<System.Guid> productPurchaseProductTaskID, LRTitleDTO lRTitle, AttachmentDTO attachment, ProductPurchaseBusTaskProcessLogDTO productPurchaseBusTaskProcessLog) {

          this.LRDocumentID = lRDocumentID;
          this.LRTitleID = lRTitleID;
          this.AttachmentID = attachmentID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ProductPurchaseProductTaskID = productPurchaseProductTaskID;
          this.LRTitle = lRTitle;
          this.Attachment = attachment;
          this.ProductPurchaseBusTaskProcessLog = productPurchaseBusTaskProcessLog;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid LRDocumentID { get; set; }

        [DataMember]
        public global::System.Guid LRTitleID { get; set; }

        [DataMember]
        public global::System.Guid AttachmentID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ProductPurchaseProductTaskID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public LRTitleDTO LRTitle { get; set; }

        [DataMember]
        public AttachmentDTO Attachment { get; set; }

        [DataMember]
        public ProductPurchaseBusTaskProcessLogDTO ProductPurchaseBusTaskProcessLog { get; set; }

        #endregion
    }

}
