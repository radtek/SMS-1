﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 08/04/2015 17:09:52
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
    /// There are no comments for Bec.TargetFramework.Data.DiscountRelatedProductTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class DiscountRelatedProductTemplate    {

        public DiscountRelatedProductTemplate()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for DiscountRelatedProductTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid DiscountRelatedProductTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DiscountTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid DiscountTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DiscountTemplateVersionNumber in the schema.
        /// </summary>
        public virtual int DiscountTemplateVersionNumber
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
        /// There are no comments for DiscountTemplate in the schema.
        /// </summary>
        public virtual DiscountTemplate DiscountTemplate
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
