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
    /// There are no comments for Bec.TargetFramework.Data.StsSearchActorProcessLog in the schema.
    /// </summary>
    [System.Serializable]
    public partial class StsSearchActorProcessLog    {

        public StsSearchActorProcessLog()
        {
          this.IsCancelled = false;
          this.IsClosed = false;
          this.IsRejected = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for StsSearchActorID in the schema.
        /// </summary>
        public virtual global::System.Guid StsSearchActorID
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
        /// There are no comments for IsCancelled in the schema.
        /// </summary>
        public virtual bool IsCancelled
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
        /// There are no comments for IsRejected in the schema.
        /// </summary>
        public virtual bool IsRejected
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for StsSearchActor in the schema.
        /// </summary>
        public virtual StsSearchActor StsSearchActor
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
