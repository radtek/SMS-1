﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 29/04/2015 12:05:02
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
    /// There are no comments for Bec.TargetFramework.SB.Data.BusMessageContent in the schema.
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [System.Runtime.Serialization.KnownType(typeof(BusMessage))]
    public partial class BusMessageContent    {

        public BusMessageContent()
        {
            OnCreated();
        }


        #region Properties
    
        /// <summary>
        /// There are no comments for BusMessageContentID in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual global::System.Guid BusMessageContentID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusMessageContent1 in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual byte[] BusMessageContent1
        {
            get;
            set;
        }

    
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
        /// There are no comments for BusMessageContentType in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual string BusMessageContentType
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusMessageHeader in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual string BusMessageHeader
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for BusMessage in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual BusMessage BusMessage
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
