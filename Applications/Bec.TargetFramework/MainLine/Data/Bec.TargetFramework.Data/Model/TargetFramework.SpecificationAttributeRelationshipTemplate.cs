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
    /// There are no comments for Bec.TargetFramework.Data.SpecificationAttributeRelationshipTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class SpecificationAttributeRelationshipTemplate    {

        public SpecificationAttributeRelationshipTemplate()
        {
          this.IsMandatory = false;
          this.IsInverse = false;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for SpecificationAttributeRelationshipTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid SpecificationAttributeRelationshipTemplateID
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
        /// There are no comments for ParentSpecificationAttributeTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid ParentSpecificationAttributeTemplateID
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
        /// There are no comments for IsInverse in the schema.
        /// </summary>
        public virtual bool IsInverse
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
        /// There are no comments for SpecificationAttributeTemplate_ParentSpecificationAttributeTemplateID in the schema.
        /// </summary>
        public virtual SpecificationAttributeTemplate SpecificationAttributeTemplate_ParentSpecificationAttributeTemplateID
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for SpecificationAttributeTemplate_SpecificationAttributeTemplateID in the schema.
        /// </summary>
        public virtual SpecificationAttributeTemplate SpecificationAttributeTemplate_SpecificationAttributeTemplateID
        {
            get;
            set;
        }

        #endregion
    }

}
