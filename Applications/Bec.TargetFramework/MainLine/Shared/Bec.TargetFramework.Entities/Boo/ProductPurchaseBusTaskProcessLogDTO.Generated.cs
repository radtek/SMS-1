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
    public partial class ProductPurchaseBusTaskProcessLogDTO
    {
        #region Constructors
  
        public ProductPurchaseBusTaskProcessLogDTO() {
        }

        public ProductPurchaseBusTaskProcessLogDTO(global::System.Guid productPurchaseProductTaskID, global::System.Guid productPurchaseID, global::System.Guid statusTypeID, int statusTypeVersionNumber, global::System.Guid statusTypeValueID, global::System.DateTime createdOn, bool isComplete, string processMessage, string processDetail, global::System.Nullable<System.Guid> productBusTaskID, bool hasError, global::System.Nullable<System.Guid> parentID, int numberOfRetries, ProductBusTaskDTO productBusTask, ProductPurchaseDTO productPurchase, StatusTypeDTO statusType, StatusTypeValueDTO statusTypeValue, List<ServiceInterfaceProcessLogDTO> serviceInterfaceProcessLogs) {

          this.ProductPurchaseProductTaskID = productPurchaseProductTaskID;
          this.ProductPurchaseID = productPurchaseID;
          this.StatusTypeID = statusTypeID;
          this.StatusTypeVersionNumber = statusTypeVersionNumber;
          this.StatusTypeValueID = statusTypeValueID;
          this.CreatedOn = createdOn;
          this.IsComplete = isComplete;
          this.ProcessMessage = processMessage;
          this.ProcessDetail = processDetail;
          this.ProductBusTaskID = productBusTaskID;
          this.HasError = hasError;
          this.ParentID = parentID;
          this.NumberOfRetries = numberOfRetries;
          this.ProductBusTask = productBusTask;
          this.ProductPurchase = productPurchase;
          this.StatusType = statusType;
          this.StatusTypeValue = statusTypeValue;
          this.ServiceInterfaceProcessLogs = serviceInterfaceProcessLogs;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductPurchaseProductTaskID { get; set; }

        [DataMember]
        public global::System.Guid ProductPurchaseID { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeID { get; set; }

        [DataMember]
        public int StatusTypeVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeValueID { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public bool IsComplete { get; set; }

        [DataMember]
        public string ProcessMessage { get; set; }

        [DataMember]
        public string ProcessDetail { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ProductBusTaskID { get; set; }

        [DataMember]
        public bool HasError { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public int NumberOfRetries { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ProductBusTaskDTO ProductBusTask { get; set; }

        [DataMember]
        public ProductPurchaseDTO ProductPurchase { get; set; }

        [DataMember]
        public StatusTypeDTO StatusType { get; set; }

        [DataMember]
        public StatusTypeValueDTO StatusTypeValue { get; set; }

        [DataMember]
        public List<ServiceInterfaceProcessLogDTO> ServiceInterfaceProcessLogs { get; set; }

        #endregion
    }

}