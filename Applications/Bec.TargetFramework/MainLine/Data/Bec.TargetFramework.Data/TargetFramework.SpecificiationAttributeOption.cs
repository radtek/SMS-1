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
    /// There are no comments for Bec.TargetFramework.Data.SpecificiationAttributeOption in the schema.
    /// </summary>
    [System.Serializable]
    public partial class SpecificiationAttributeOption    {

        public SpecificiationAttributeOption()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for SpecficiationAttributeOptionID in the schema.
        /// </summary>
        public virtual global::System.Guid SpecficiationAttributeOptionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SpecificationAttributeOptionTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid SpecificationAttributeOptionTemplateID
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
        /// There are no comments for DisplayOrder in the schema.
        /// </summary>
        public virtual int DisplayOrder
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


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for ProductSpecificationAttributeOptions in the schema.
        /// </summary>
        public virtual ICollection<ProductSpecificationAttributeOption> ProductSpecificationAttributeOptions
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for SpecificationAttribute in the schema.
        /// </summary>
        public virtual SpecificationAttribute SpecificationAttribute
        {
            get;
            set;
        }

        #endregion
    }

}
