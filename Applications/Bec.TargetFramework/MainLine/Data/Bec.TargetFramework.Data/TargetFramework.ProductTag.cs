﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 02/04/2015 16:41:46
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
    /// There are no comments for Bec.TargetFramework.Data.ProductTag in the schema.
    /// </summary>
    [System.Serializable]
    public partial class ProductTag    {

        public ProductTag()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ProductTagID in the schema.
        /// </summary>
        public virtual global::System.Guid ProductTagID
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
        /// There are no comments for ProductID in the schema.
        /// </summary>
        public virtual global::System.Guid ProductID
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


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for Product in the schema.
        /// </summary>
        public virtual Product Product
        {
            get;
            set;
        }

        #endregion
    }

}
