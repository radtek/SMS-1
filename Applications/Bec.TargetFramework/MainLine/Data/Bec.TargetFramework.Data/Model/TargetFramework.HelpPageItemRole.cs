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
    /// There are no comments for Bec.TargetFramework.Data.HelpPageItemRole in the schema.
    /// </summary>
    [System.Serializable]
    public partial class HelpPageItemRole    {

        public HelpPageItemRole()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for HelpPageItemRoleID in the schema.
        /// </summary>
        public virtual global::System.Guid HelpPageItemRoleID
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
        /// There are no comments for HelpPageItemID in the schema.
        /// </summary>
        public virtual global::System.Guid HelpPageItemID
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

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for Role in the schema.
        /// </summary>
        public virtual Role Role
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for HelpPageItem in the schema.
        /// </summary>
        public virtual HelpPageItem HelpPageItem
        {
            get;
            set;
        }

        #endregion
    }

}
