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
    public partial class ProductPurchaseDTO
    {
        #region Constructors
  
        public ProductPurchaseDTO() {
        }

        public ProductPurchaseDTO(global::System.Guid productPurchaseID, global::System.Guid invoiceLineItemID, global::System.DateTime purchaseDate, global::System.Nullable<System.Guid> parentID, List<ProductPurchaseProcessLogDTO> productPurchaseProcessLogs, InvoiceLineItemDTO invoiceLineItem, List<ProductPurchaseBusTaskProcessLogDTO> productPurchaseBusTaskProcessLogs) {

          this.ProductPurchaseID = productPurchaseID;
          this.InvoiceLineItemID = invoiceLineItemID;
          this.PurchaseDate = purchaseDate;
          this.ParentID = parentID;
          this.ProductPurchaseProcessLogs = productPurchaseProcessLogs;
          this.InvoiceLineItem = invoiceLineItem;
          this.ProductPurchaseBusTaskProcessLogs = productPurchaseBusTaskProcessLogs;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductPurchaseID { get; set; }

        [DataMember]
        public global::System.Guid InvoiceLineItemID { get; set; }

        [DataMember]
        public global::System.DateTime PurchaseDate { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<ProductPurchaseProcessLogDTO> ProductPurchaseProcessLogs { get; set; }

        [DataMember]
        public InvoiceLineItemDTO InvoiceLineItem { get; set; }

        [DataMember]
        public List<ProductPurchaseBusTaskProcessLogDTO> ProductPurchaseBusTaskProcessLogs { get; set; }

        #endregion
    }

}
