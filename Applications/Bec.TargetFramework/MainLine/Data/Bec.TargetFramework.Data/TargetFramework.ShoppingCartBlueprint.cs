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
    /// There are no comments for Bec.TargetFramework.Data.ShoppingCartBlueprint in the schema.
    /// </summary>
    [System.Serializable]
    public partial class ShoppingCartBlueprint    {

        public ShoppingCartBlueprint()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ShoppingCartBlueprintID in the schema.
        /// </summary>
        public virtual global::System.Guid ShoppingCartBlueprintID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ParentID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ParentID
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
        /// There are no comments for Name in the schema.
        /// </summary>
        public virtual string Name
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for ShoppingCartBlueprintProducts in the schema.
        /// </summary>
        public virtual ICollection<ShoppingCartBlueprintProduct> ShoppingCartBlueprintProducts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationShoppingCartBlueprints in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationShoppingCartBlueprint> DefaultOrganisationShoppingCartBlueprints
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationShoppingCartBlueprints in the schema.
        /// </summary>
        public virtual ICollection<OrganisationShoppingCartBlueprint> OrganisationShoppingCartBlueprints
        {
            get;
            set;
        }

        #endregion
    }

}
