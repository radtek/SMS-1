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
    /// There are no comments for Bec.TargetFramework.Data.VProductDeduction in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VProductDeduction    {

        public VProductDeduction()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ProductDeductionID in the schema.
        /// </summary>
        public virtual global::System.Guid ProductDeductionID
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

    
        /// <summary>
        /// There are no comments for DeductionID in the schema.
        /// </summary>
        public virtual global::System.Guid DeductionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DeductionPercentage in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> DeductionPercentage
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DeductionValue in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> DeductionValue
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
        /// There are no comments for IsPercentageBased in the schema.
        /// </summary>
        public virtual bool IsPercentageBased
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DeductionVersionNumber in the schema.
        /// </summary>
        public virtual int DeductionVersionNumber
        {
            get;
            set;
        }


        #endregion
    }

}
