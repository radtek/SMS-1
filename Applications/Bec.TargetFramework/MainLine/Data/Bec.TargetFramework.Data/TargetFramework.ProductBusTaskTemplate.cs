﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 07/04/2015 09:50:51
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
    /// There are no comments for Bec.TargetFramework.Data.ProductBusTaskTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class ProductBusTaskTemplate    {

        public ProductBusTaskTemplate()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.Order = 0;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ProductBusTaskTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid ProductBusTaskTemplateID
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

    
        /// <summary>
        /// There are no comments for BusTaskID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> BusTaskID
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

    
        /// <summary>
        /// There are no comments for BusTaskVersionNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> BusTaskVersionNumber
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for ProductTemplate in the schema.
        /// </summary>
        public virtual ProductTemplate ProductTemplate
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for BusTask in the schema.
        /// </summary>
        public virtual BusTask BusTask
        {
            get;
            set;
        }

        #endregion
    }

}
