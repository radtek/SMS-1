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
    /// There are no comments for Bec.TargetFramework.Data.PackageProductRelationshipBlueprintTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class PackageProductRelationshipBlueprintTemplate    {

        public PackageProductRelationshipBlueprintTemplate()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for PackageProductRelationshipBlueprintTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid PackageProductRelationshipBlueprintTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PackageProductRelationshipTemplateID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> PackageProductRelationshipTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DefaultQuantity in the schema.
        /// </summary>
        public virtual int DefaultQuantity
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
        /// There are no comments for PackageProductRelationshipTemplate in the schema.
        /// </summary>
        public virtual PackageProductRelationshipTemplate PackageProductRelationshipTemplate
        {
            get;
            set;
        }

        #endregion
    }

}
