﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 07/04/2015 16:15:16
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
    /// There are no comments for Bec.TargetFramework.Data.ServiceDefinition in the schema.
    /// </summary>
    [System.Serializable]
    public partial class ServiceDefinition    {

        public ServiceDefinition()
        {
          this.IsPollingService = false;
          this.NumberOfRetriesPerCall = 1;
          this.RetryPeriodPerCallInMinutes = 180;
          this.RetryFailedCalls = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ServiceDefinitionID in the schema.
        /// </summary>
        public virtual global::System.Guid ServiceDefinitionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ServiceDefinitionTypeID in the schema.
        /// </summary>
        public virtual int ServiceDefinitionTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ServiceDefinitionCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ServiceDefinitionCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Name in the schema.
        /// </summary>
        public virtual string Name
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Description in the schema.
        /// </summary>
        public virtual string Description
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ServiceInterfaceID in the schema.
        /// </summary>
        public virtual global::System.Guid ServiceInterfaceID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsPollingService in the schema.
        /// </summary>
        public virtual bool IsPollingService
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NumberOfRetriesPerCall in the schema.
        /// </summary>
        public virtual int NumberOfRetriesPerCall
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ServiceEngineObjectName in the schema.
        /// </summary>
        public virtual string ServiceEngineObjectName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ServiceDefinitionObjectName in the schema.
        /// </summary>
        public virtual string ServiceDefinitionObjectName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ServiceMutatorObjectName in the schema.
        /// </summary>
        public virtual string ServiceMutatorObjectName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RetryPeriodPerCallInMinutes in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> RetryPeriodPerCallInMinutes
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RetryFailedCalls in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> RetryFailedCalls
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for ServiceDefinitionDetails in the schema.
        /// </summary>
        public virtual ICollection<ServiceDefinitionDetail> ServiceDefinitionDetails
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ServiceInterface in the schema.
        /// </summary>
        public virtual ServiceInterface ServiceInterface
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ServiceInterfaceProcessLogs in the schema.
        /// </summary>
        public virtual ICollection<ServiceInterfaceProcessLog> ServiceInterfaceProcessLogs
        {
            get;
            set;
        }

        #endregion
    }

}
