﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 02/04/2015 16:41:46
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
    /// There are no comments for Bec.TargetFramework.Data.VClaimSource in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VClaimSource    {

        public VClaimSource()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ID in the schema.
        /// </summary>
        public virtual global::System.Guid ID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ClaimType in the schema.
        /// </summary>
        public virtual string ClaimType
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ClaimID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ClaimID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ClaimName in the schema.
        /// </summary>
        public virtual string ClaimName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ClaimSubType in the schema.
        /// </summary>
        public virtual string ClaimSubType
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ClaimSubID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ClaimSubID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ClaimSubName in the schema.
        /// </summary>
        public virtual string ClaimSubName
        {
            get;
            set;
        }


        #endregion
    }

}
