﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 26/03/2015 16:14:58
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
    /// There are no comments for Bec.TargetFramework.Data.VGroup in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VGroup    {

        public VGroup()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for GroupID in the schema.
        /// </summary>
        public virtual global::System.Guid GroupID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for GroupName in the schema.
        /// </summary>
        public virtual string GroupName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for GroupDescription in the schema.
        /// </summary>
        public virtual string GroupDescription
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for GroupTypeID in the schema.
        /// </summary>
        public virtual int GroupTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for GroupSubTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> GroupSubTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for GroupCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> GroupCategoryID
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

    
        /// <summary>
        /// There are no comments for IsDisabled in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsDisabled
        {
            get;
            set;
        }


        #endregion
    }

}
