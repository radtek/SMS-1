﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 08/06/2015 16:32:47
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
    /// There are no comments for Bec.TargetFramework.SB.Data.BusEvent in the schema.
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [System.Runtime.Serialization.KnownType(typeof(BusEventType))]
    [System.Runtime.Serialization.KnownType(typeof(BusEventBusEventMessageSubscriber))]
    public partial class BusEvent    {

        public BusEvent()
        {
            OnCreated();
        }


        #region Properties
    
        /// <summary>
        /// There are no comments for BusEventID in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual global::System.Guid BusEventID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusEventName in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual string BusEventName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusEventDescription in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual string BusEventDescription
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusEventTypeID in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual global::System.Guid BusEventTypeID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for BusEventType in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual BusEventType BusEventType
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for BusEventBusEventMessageSubscribers in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual ICollection<BusEventBusEventMessageSubscriber> BusEventBusEventMessageSubscribers
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