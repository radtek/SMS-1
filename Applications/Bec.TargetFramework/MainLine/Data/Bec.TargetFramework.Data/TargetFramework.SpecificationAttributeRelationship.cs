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
    /// There are no comments for Bec.TargetFramework.Data.SpecificationAttributeRelationship in the schema.
    /// </summary>
    [System.Serializable]
    public partial class SpecificationAttributeRelationship    {

        public SpecificationAttributeRelationship()
        {
          this.IsMandatory = false;
          this.IsInverse = false;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for SpecificationAttributeRelationshipID in the schema.
        /// </summary>
        public virtual global::System.Guid SpecificationAttributeRelationshipID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SpecificationAttributeID in the schema.
        /// </summary>
        public virtual global::System.Guid SpecificationAttributeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ParentSpecificationAttributeID in the schema.
        /// </summary>
        public virtual global::System.Guid ParentSpecificationAttributeID
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
        /// There are no comments for SpecificationAttribute_ParentSpecificationAttributeID in the schema.
        /// </summary>
        public virtual SpecificationAttribute SpecificationAttribute_ParentSpecificationAttributeID
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for SpecificationAttribute_SpecificationAttributeID in the schema.
        /// </summary>
        public virtual SpecificationAttribute SpecificationAttribute_SpecificationAttributeID
        {
            get;
            set;
        }

        #endregion
    }

}
