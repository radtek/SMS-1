﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 07/04/2015 09:50:51
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
    /// There are no comments for Bec.TargetFramework.Data.GroupRole in the schema.
    /// </summary>
    [System.Serializable]
    public partial class GroupRole    {

        public GroupRole()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsGlobal = true;
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
        /// There are no comments for RoleID in the schema.
        /// </summary>
        public virtual global::System.Guid RoleID
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
        public virtual global::System.Nullable<bool> IsGlobal
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for Group in the schema.
        /// </summary>
        public virtual Group Group
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Role in the schema.
        /// </summary>
        public virtual Role Role
        {
            get;
            set;
        }

        #endregion
    }

}
