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
    /// There are no comments for Bec.TargetFramework.SB.Data.VBusMessageProcessLog in the schema.
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    public partial class VBusMessageProcessLog    {

        public VBusMessageProcessLog()
        {
            OnCreated();
        }


        #region Properties
    
        /// <summary>
        /// There are no comments for BusMessageID in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual global::System.Guid BusMessageID
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
        /// There are no comments for SentOn in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual global::System.Nullable<System.DateTime> SentOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProcessingStarted in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual global::System.Nullable<System.DateTime> ProcessingStarted
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProcessingMachine in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual string ProcessingMachine
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MessageSentFrom in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual string MessageSentFrom
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for EventReference in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual string EventReference
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Source in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual string Source
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusMessageSubscriber in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual string BusMessageSubscriber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusMessageHandler in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual string BusMessageHandler
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
        /// There are no comments for HasError in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual bool HasError
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsComplete in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual bool IsComplete
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
