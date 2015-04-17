﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 17/04/2015 16:46:51
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Bec.TargetFramework.Data
{

    /// <summary>
    /// There are no comments for Bec.TargetFramework.Data.InvoiceProcessLog in the schema.
    /// </summary>
    [System.Serializable]
    public partial class InvoiceProcessLog    {

        public InvoiceProcessLog()
        {
          this.IsInvoiceProcessed = false;
          this.IsPaid = false;
          this.IsClosed = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for InvoiceID in the schema.
        /// </summary>
        public virtual global::System.Guid InvoiceID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CreatedOn in the schema.
        /// </summary>
        public virtual global::System.DateTime CreatedOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotificationID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> NotificationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceStatusDetail in the schema.
        /// </summary>
        public virtual string InvoiceStatusDetail
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PaidOn in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> PaidOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsInvoiceProcessed in the schema.
        /// </summary>
        public virtual bool IsInvoiceProcessed
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsPaid in the schema.
        /// </summary>
        public virtual bool IsPaid
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusTypeID in the schema.
        /// </summary>
        public virtual global::System.Guid StatusTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusTypeVersionNumber in the schema.
        /// </summary>
        public virtual int StatusTypeVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusTypeValueID in the schema.
        /// </summary>
        public virtual global::System.Guid StatusTypeValueID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsClosed in the schema.
        /// </summary>
        public virtual bool IsClosed
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ClosedOn in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> ClosedOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceAccountingStatusID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> InvoiceAccountingStatusID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for Invoice in the schema.
        /// </summary>
        public virtual Invoice Invoice
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Notification in the schema.
        /// </summary>
        public virtual Notification Notification
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StatusType in the schema.
        /// </summary>
        public virtual StatusType StatusType
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StatusTypeValue in the schema.
        /// </summary>
        public virtual StatusTypeValue StatusTypeValue
        {
            get;
            set;
        }

        #endregion
    }

}
