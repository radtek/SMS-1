﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
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
    /// There are no comments for Bec.TargetFramework.Data.Actor in the schema.
    /// </summary>
    [System.Serializable]
    public partial class Actor    {

        public Actor()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsGlobal = true;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ActorID in the schema.
        /// </summary>
        public virtual global::System.Guid ActorID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ActorName in the schema.
        /// </summary>
        public virtual string ActorName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ActorDescription in the schema.
        /// </summary>
        public virtual string ActorDescription
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ActorTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ActorTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ActorSubTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ActorSubTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ActorCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ActorCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ActorSubCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ActorSubCategoryID
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
        /// There are no comments for IsGlobal in the schema.
        /// </summary>
        public virtual bool IsGlobal
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for ActorClaimRoleMappings in the schema.
        /// </summary>
        public virtual ICollection<ActorClaimRoleMapping> ActorClaimRoleMappings
        {
            get;
            set;
        }

        #endregion
    }

}