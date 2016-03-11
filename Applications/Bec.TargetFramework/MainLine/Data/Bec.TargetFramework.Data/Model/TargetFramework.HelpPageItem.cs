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
    /// There are no comments for Bec.TargetFramework.Data.HelpPageItem in the schema.
    /// </summary>
    [System.Serializable]
    public partial class HelpPageItem    {

        public HelpPageItem()
        {
          this.DisplayOrder = 0;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for HelpPageItemID in the schema.
        /// </summary>
        public virtual global::System.Guid HelpPageItemID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for HelpPageID in the schema.
        /// </summary>
        public virtual global::System.Guid HelpPageID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Title in the schema.
        /// </summary>
        public virtual string Title
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Description in the schema.
        /// </summary>
        public virtual string Description
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DisplayOrder in the schema.
        /// </summary>
        public virtual int DisplayOrder
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Selector in the schema.
        /// </summary>
        public virtual string Selector
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TabContainerId in the schema.
        /// </summary>
        public virtual string TabContainerId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for EffectiveOn in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> EffectiveOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Position in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> Position
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
        /// There are no comments for ModifiedOn in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> ModifiedOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CreatedBy in the schema.
        /// </summary>
        public virtual string CreatedBy
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ModifiedBy in the schema.
        /// </summary>
        public virtual string ModifiedBy
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for HelpPageItemUserAccounts in the schema.
        /// </summary>
        public virtual ICollection<HelpPageItemUserAccount> HelpPageItemUserAccounts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for HelpPage in the schema.
        /// </summary>
        public virtual HelpPage HelpPage
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for HelpPageItemRoles in the schema.
        /// </summary>
        public virtual ICollection<HelpPageItemRole> HelpPageItemRoles
        {
            get;
            set;
        }

        #endregion
    }

}
