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
    public partial class ProductBusTaskDTO
    {
        #region Constructors
  
        public ProductBusTaskDTO() {
        }

        public ProductBusTaskDTO(global::System.Guid productBusTaskID, global::System.Guid productID, int productVersionID, bool isActive, bool isDeleted, global::System.Nullable<System.Guid> busTaskID, long order, global::System.Nullable<int> busTaskVersionNumber, ProductDTO product, List<ProductPurchaseBusTaskProcessLogDTO> productPurchaseBusTaskProcessLogs, BusTaskDTO busTask) {

          this.ProductBusTaskID = productBusTaskID;
          this.ProductID = productID;
          this.ProductVersionID = productVersionID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.BusTaskID = busTaskID;
          this.Order = order;
          this.BusTaskVersionNumber = busTaskVersionNumber;
          this.Product = product;
          this.ProductPurchaseBusTaskProcessLogs = productPurchaseBusTaskProcessLogs;
          this.BusTask = busTask;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductBusTaskID { get; set; }

        [DataMember]
        public global::System.Guid ProductID { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> BusTaskID { get; set; }

        [DataMember]
        public long Order { get; set; }

        [DataMember]
        public global::System.Nullable<int> BusTaskVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ProductDTO Product { get; set; }

        [DataMember]
        public List<ProductPurchaseBusTaskProcessLogDTO> ProductPurchaseBusTaskProcessLogs { get; set; }

        [DataMember]
        public BusTaskDTO BusTask { get; set; }

        #endregion
    }

}
