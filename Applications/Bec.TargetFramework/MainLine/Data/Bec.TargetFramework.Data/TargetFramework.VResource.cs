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
    /// There are no comments for Bec.TargetFramework.Data.VResource in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VResource    {

        public VResource()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ResourceID in the schema.
        /// </summary>
        public virtual global::System.Guid ResourceID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ResourceName in the schema.
        /// </summary>
        public virtual string ResourceName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ResourceDescription in the schema.
        /// </summary>
        public virtual string ResourceDescription
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SourceID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> SourceID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ResourceTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ResourceTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ResourceCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ResourceCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ResourceSubCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ResourceSubCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsActive in the schema.
        /// </summary>
        public virtual bool IsActive
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsDeleted in the schema.
        /// </summary>
        public virtual bool IsDeleted
        {
            get;
            set;
        }


        #endregion
    }

}
