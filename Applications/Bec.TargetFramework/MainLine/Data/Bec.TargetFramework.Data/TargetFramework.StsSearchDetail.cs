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
    /// There are no comments for Bec.TargetFramework.Data.StsSearchDetail in the schema.
    /// </summary>
    [System.Serializable]
    public partial class StsSearchDetail    {

        public StsSearchDetail()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for StsSearchDetailID in the schema.
        /// </summary>
        public virtual global::System.Guid StsSearchDetailID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StsSearchID in the schema.
        /// </summary>
        public virtual global::System.Guid StsSearchID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for StsSearch in the schema.
        /// </summary>
        public virtual StsSearch StsSearch
        {
            get;
            set;
        }

        #endregion
    }

}
