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
    /// There are no comments for Bec.TargetFramework.Data.ProductRelationshipTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class ProductRelationshipTemplate    {

        public ProductRelationshipTemplate()
        {
          this.IsMandatory = false;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ProductRelationshipTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid ProductRelationshipTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ParentProductTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid ParentProductTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ChildProductTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid ChildProductTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProductRelationshipTypeID in the schema.
        /// </summary>
        public virtual int ProductRelationshipTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsMandatory in the schema.
        /// </summary>
        public virtual bool IsMandatory
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
        /// There are no comments for ParentProductVersionID in the schema.
        /// </summary>
        public virtual int ParentProductVersionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ChildProductVersionID in the schema.
        /// </summary>
        public virtual int ChildProductVersionID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for ProductRelationshipBlueprintTemplates in the schema.
        /// </summary>
        public virtual ICollection<ProductRelationshipBlueprintTemplate> ProductRelationshipBlueprintTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductTemplate_ParentProductTemplateID_ParentProductVersionID in the schema.
        /// </summary>
        public virtual ProductTemplate ProductTemplate_ParentProductTemplateID_ParentProductVersionID
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductTemplate_ChildProductTemplateID_ChildProductVersionID in the schema.
        /// </summary>
        public virtual ProductTemplate ProductTemplate_ChildProductTemplateID_ChildProductVersionID
        {
            get;
            set;
        }

        #endregion
    }

}