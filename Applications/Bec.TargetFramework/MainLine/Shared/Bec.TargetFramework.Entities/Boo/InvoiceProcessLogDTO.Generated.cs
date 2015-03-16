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
    public partial class InvoiceProcessLogDTO
    {
        #region Constructors
  
        public InvoiceProcessLogDTO() {
        }

        public InvoiceProcessLogDTO(global::System.Guid invoiceID, global::System.DateTime createdOn, global::System.Nullable<System.Guid> notificationID, string invoiceStatusDetail, global::System.Nullable<System.DateTime> paidOn, bool isInvoiceProcessed, bool isPaid, global::System.Guid statusTypeID, int statusTypeVersionNumber, global::System.Guid statusTypeValueID, bool isClosed, global::System.Nullable<System.DateTime> closedOn, global::System.Nullable<int> invoiceAccountingStatusID, InvoiceDTO invoice, NotificationDTO notification, StatusTypeDTO statusType, StatusTypeValueDTO statusTypeValue) {

          this.InvoiceID = invoiceID;
          this.CreatedOn = createdOn;
          this.NotificationID = notificationID;
          this.InvoiceStatusDetail = invoiceStatusDetail;
          this.PaidOn = paidOn;
          this.IsInvoiceProcessed = isInvoiceProcessed;
          this.IsPaid = isPaid;
          this.StatusTypeID = statusTypeID;
          this.StatusTypeVersionNumber = statusTypeVersionNumber;
          this.StatusTypeValueID = statusTypeValueID;
          this.IsClosed = isClosed;
          this.ClosedOn = closedOn;
          this.InvoiceAccountingStatusID = invoiceAccountingStatusID;
          this.Invoice = invoice;
          this.Notification = notification;
          this.StatusType = statusType;
          this.StatusTypeValue = statusTypeValue;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid InvoiceID { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> NotificationID { get; set; }

        [DataMember]
        public string InvoiceStatusDetail { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> PaidOn { get; set; }

        [DataMember]
        public bool IsInvoiceProcessed { get; set; }

        [DataMember]
        public bool IsPaid { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeID { get; set; }

        [DataMember]
        public int StatusTypeVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeValueID { get; set; }

        [DataMember]
        public bool IsClosed { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> ClosedOn { get; set; }

        [DataMember]
        public global::System.Nullable<int> InvoiceAccountingStatusID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public InvoiceDTO Invoice { get; set; }

        [DataMember]
        public NotificationDTO Notification { get; set; }

        [DataMember]
        public StatusTypeDTO StatusType { get; set; }

        [DataMember]
        public StatusTypeValueDTO StatusTypeValue { get; set; }

        #endregion
    }

}
