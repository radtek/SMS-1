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
    /// There are no comments for Bec.TargetFramework.Data.ProductProductAttributeTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class ProductProductAttributeTemplate    {

        public ProductProductAttributeTemplate()
        {
          this.IsRequired = false;
          this.DisplayOrder = 0;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ProductProductAttributeTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid ProductProductAttributeTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProductTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid ProductTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProductAttributeTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid ProductAttributeTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsRequired in the schema.
        /// </summary>
        public virtual bool IsRequired
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
        /// There are no comments for ProductVersionID in the schema.
        /// </summary>
        public virtual int ProductVersionID
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
        /// There are no comments for ProductVariantAttributeValueTemplates in the schema.
        /// </summary>
        public virtual ICollection<ProductVariantAttributeValueTemplate> ProductVariantAttributeValueTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductAttributeTemplate in the schema.
        /// </summary>
        public virtual ProductAttributeTemplate ProductAttributeTemplate
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductTemplate in the schema.
        /// </summary>
        public virtual ProductTemplate ProductTemplate
        {
            get;
            set;
        }

        #endregion
    }

}