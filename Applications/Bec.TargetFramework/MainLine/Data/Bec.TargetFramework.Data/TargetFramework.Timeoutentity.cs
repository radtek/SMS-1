﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 13/04/2015 17:29:36
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
    /// There are no comments for Bec.TargetFramework.Data.Timeoutentity in the schema.
    /// </summary>
    [System.Serializable]
    public partial class Timeoutentity    {

        public Timeoutentity()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for Id in the schema.
        /// </summary>
        public virtual global::System.Guid Id
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Destination in the schema.
        /// </summary>
        public virtual string Destination
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Sagaid in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> Sagaid
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for State in the schema.
        /// </summary>
        public virtual byte[] State
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Time in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> Time
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Correlationid in the schema.
        /// </summary>
        public virtual string Correlationid
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Headers in the schema.
        /// </summary>
        public virtual string Headers
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Endpoint in the schema.
        /// </summary>
        public virtual string Endpoint
        {
            get;
            set;
        }


        #endregion
    }

}
