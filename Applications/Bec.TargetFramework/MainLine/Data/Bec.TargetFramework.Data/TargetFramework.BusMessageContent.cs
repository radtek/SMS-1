﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 18/03/2015 19:00:45
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
    /// There are no comments for Bec.TargetFramework.Data.BusMessageContent in the schema.
    /// </summary>
    [System.Serializable]
    public partial class BusMessageContent    {

        public BusMessageContent()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for BusMessageContentID in the schema.
        /// </summary>
        public virtual int BusMessageContentID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusMessageContent1 in the schema.
        /// </summary>
        public virtual byte[] BusMessageContent1
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusMessageID in the schema.
        /// </summary>
        public virtual global::System.Guid BusMessageID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusMessageContentType in the schema.
        /// </summary>
        public virtual string BusMessageContentType
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusMessageHeader in the schema.
        /// </summary>
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
        public virtual BusMessage BusMessage
        {
            get;
            set;
        }

        #endregion
    }

}
