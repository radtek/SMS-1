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
    /// There are no comments for Bec.TargetFramework.Data.ProductTagTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class ProductTagTemplate    {

        public ProductTagTemplate()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ProductTagTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid ProductTagTemplateID
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

        #endregion
    }

}
