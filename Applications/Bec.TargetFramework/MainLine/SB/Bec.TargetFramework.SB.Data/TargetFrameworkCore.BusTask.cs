﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 08/04/2015 15:00:59
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
    /// There are no comments for Bec.TargetFramework.SB.Data.BusTask in the schema.
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [System.Runtime.Serialization.KnownType(typeof(BusTaskHandler))]
    [System.Runtime.Serialization.KnownType(typeof(BusTaskSchedule))]
    public partial class BusTask    {

        public BusTask()
        {
          this.IsActive = true;
          this.IsDeleted = false;
            OnCreated();
        }


        #region Properties
    
        /// <summary>
        /// There are no comments for BusTaskID in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual global::System.Guid BusTaskID
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
        /// There are no comments for CreatedOn in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual global::System.DateTime CreatedOn
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

    
        /// <summary>
        /// There are no comments for BusTaskHandlerID in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual global::System.Guid BusTaskHandlerID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusTaskVersionNumber in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual int BusTaskVersionNumber
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for BusTaskHandler in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual BusTaskHandler BusTaskHandler
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for BusTaskSchedules in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual ICollection<BusTaskSchedule> BusTaskSchedules
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
