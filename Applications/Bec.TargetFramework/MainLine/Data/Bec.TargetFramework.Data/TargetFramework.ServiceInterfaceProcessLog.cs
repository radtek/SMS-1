﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 2/12/2015 3:31:04 PM
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
    /// There are no comments for Bec.TargetFramework.Data.ServiceInterfaceProcessLog in the schema.
    /// </summary>
    [System.Serializable]
    public partial class ServiceInterfaceProcessLog    {

        public ServiceInterfaceProcessLog()
        {
          this.IsComplete = false;
          this.HasError = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ServiceInterfaceProcessLogID in the schema.
        /// </summary>
        public virtual global::System.Guid ServiceInterfaceProcessLogID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProductPurchaseProductTaskID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ProductPurchaseProductTaskID
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
        /// There are no comments for IsComplete in the schema.
        /// </summary>
        public virtual bool IsComplete
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NumberOfRetries in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> NumberOfRetries
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for HasError in the schema.
        /// </summary>
        public virtual bool HasError
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ServiceDefinitionID in the schema.
        /// </summary>
        public virtual global::System.Guid ServiceDefinitionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProcessDetail in the schema.
        /// </summary>
        public virtual string ProcessDetail
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProcessMessage in the schema.
        /// </summary>
        public virtual string ProcessMessage
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ParentID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ParentID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for ServiceDefinition in the schema.
        /// </summary>
        public virtual ServiceDefinition ServiceDefinition
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
    
        /// <summary>
        /// There are no comments for ProductPurchaseBusTaskProcessLog in the schema.
        /// </summary>
        public virtual ProductPurchaseBusTaskProcessLog ProductPurchaseBusTaskProcessLog
        {
            get;
            set;
        }

        #endregion
    }

}
