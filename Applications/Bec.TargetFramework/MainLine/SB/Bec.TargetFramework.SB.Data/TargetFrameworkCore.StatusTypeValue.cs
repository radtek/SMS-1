﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 30/04/2015 14:40:26
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Bec.TargetFramework.SB.Data
{

    /// <summary>
    /// There are no comments for Bec.TargetFramework.SB.Data.StatusTypeValue in the schema.
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [System.Runtime.Serialization.KnownType(typeof(BusMessageProcessLog))]
    [System.Runtime.Serialization.KnownType(typeof(StatusTypeStructure))]
    [System.Runtime.Serialization.KnownType(typeof(StatusType))]
    [System.Runtime.Serialization.KnownType(typeof(BusTaskScheduleProcessLog))]
    public partial class StatusTypeValue    {

        public StatusTypeValue()
        {
          this.IsActive = true;
          this.IsDeleted = false;
            OnCreated();
        }


        #region Properties
    
        /// <summary>
        /// There are no comments for StatusTypeValueID in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual global::System.Guid StatusTypeValueID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusTypeID in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual global::System.Guid StatusTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusTypeVersionNumber in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual int StatusTypeVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Name in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual string Name
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Description in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual string Description
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsActive in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual bool IsActive
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsDeleted in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual bool IsDeleted
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for BusMessageProcessLogs in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual ICollection<BusMessageProcessLog> BusMessageProcessLogs
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StatusTypeStructures in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual ICollection<StatusTypeStructure> StatusTypeStructures
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StatusType in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual StatusType StatusType
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for BusTaskScheduleProcessLogs in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual ICollection<BusTaskScheduleProcessLog> BusTaskScheduleProcessLogs
        {
            get;
            set;
        }

        #endregion
    
        #region Extensibility Method Definitions
        partial void OnCreated();
        #endregion
    }

}
