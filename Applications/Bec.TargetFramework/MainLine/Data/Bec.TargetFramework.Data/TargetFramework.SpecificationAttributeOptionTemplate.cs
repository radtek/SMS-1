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
    /// There are no comments for Bec.TargetFramework.Data.SpecificationAttributeOptionTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class SpecificationAttributeOptionTemplate    {

        public SpecificationAttributeOptionTemplate()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for SpecificationAttributeOptionTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid SpecificationAttributeOptionTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SpecificationAttributeTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid SpecificationAttributeTemplateID
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

    
        /// <summary>
        /// There are no comments for Description in the schema.
        /// </summary>
        public virtual string Description
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
        /// There are no comments for DisplayOrder in the schema.
        /// </summary>
        public virtual int DisplayOrder
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Order in the schema.
        /// </summary>
        public virtual int Order
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for ProductSpecificationAttributeOptionTemplates in the schema.
        /// </summary>
        public virtual ICollection<ProductSpecificationAttributeOptionTemplate> ProductSpecificationAttributeOptionTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for SpecificationAttributeTemplate in the schema.
        /// </summary>
        public virtual SpecificationAttributeTemplate SpecificationAttributeTemplate
        {
            get;
            set;
        }

        #endregion
    }

}
