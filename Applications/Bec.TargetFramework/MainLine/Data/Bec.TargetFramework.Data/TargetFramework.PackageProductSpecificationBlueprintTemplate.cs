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
    /// There are no comments for Bec.TargetFramework.Data.PackageProductSpecificationBlueprintTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class PackageProductSpecificationBlueprintTemplate    {

        public PackageProductSpecificationBlueprintTemplate()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for PackageProductSpecificationBlueprintTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid PackageProductSpecificationBlueprintTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PackageProductTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid PackageProductTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProductSpecificationAttributeTemplate in the schema.
        /// </summary>
        public virtual global::System.Guid ProductSpecificationAttributeTemplate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DefaultProductSpecificationAttributeOptionTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid DefaultProductSpecificationAttributeOptionTemplateID
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
        /// There are no comments for PackageTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid PackageTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PackageTemplateVersionNumber in the schema.
        /// </summary>
        public virtual int PackageTemplateVersionNumber
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for ProductSpecificationAttributeTemplate1 in the schema.
        /// </summary>
        public virtual ProductSpecificationAttributeTemplate ProductSpecificationAttributeTemplate1
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductSpecificationAttributeOptionTemplate in the schema.
        /// </summary>
        public virtual ProductSpecificationAttributeOptionTemplate ProductSpecificationAttributeOptionTemplate
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PackageProductTemplate in the schema.
        /// </summary>
        public virtual PackageProductTemplate PackageProductTemplate
        {
            get;
            set;
        }

        #endregion
    }

}
