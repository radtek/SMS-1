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
    /// There are no comments for Bec.TargetFramework.Data.VClassification in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VClassification    {

        public VClassification()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for Classificationtypeid in the schema.
        /// </summary>
        public virtual int Classificationtypeid
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
        /// There are no comments for ClassificationTypeCategoryID in the schema.
        /// </summary>
        public virtual int ClassificationTypeCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Categoryname in the schema.
        /// </summary>
        public virtual string Categoryname
        {
            get;
            set;
        }


        #endregion
    }

}
