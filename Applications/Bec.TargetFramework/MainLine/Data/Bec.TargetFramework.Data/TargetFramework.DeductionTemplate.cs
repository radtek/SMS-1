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
    /// There are no comments for Bec.TargetFramework.Data.DeductionTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class DeductionTemplate    {

        public DeductionTemplate()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsPercentageBased = true;
          this.IsTierDeduction = false;
          this.IsCheckoutDeduction = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for DeductionTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid DeductionTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DeductionTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> DeductionTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DeductionSubTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> DeductionSubTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DeductionCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> DeductionCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DeductionSubCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> DeductionSubCategoryID
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

    
        /// <summary>
        /// There are no comments for IsPercentageBased in the schema.
        /// </summary>
        public virtual bool IsPercentageBased
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DeductionTemplateVersionNumber in the schema.
        /// </summary>
        public virtual int DeductionTemplateVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> OrganisationTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UserTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> UserTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsTierDeduction in the schema.
        /// </summary>
        public virtual bool IsTierDeduction
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsCheckoutDeduction in the schema.
        /// </summary>
        public virtual bool IsCheckoutDeduction
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ParentID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ParentID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for CountryDeductionTemplates in the schema.
        /// </summary>
        public virtual ICollection<CountryDeductionTemplate> CountryDeductionTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductDeductionTemplates in the schema.
        /// </summary>
        public virtual ICollection<ProductDeductionTemplate> ProductDeductionTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Deductions in the schema.
        /// </summary>
        public virtual ICollection<Deduction> Deductions
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationType in the schema.
        /// </summary>
        public virtual OrganisationType OrganisationType
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for UserType in the schema.
        /// </summary>
        public virtual UserType UserType
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductTemplates in the schema.
        /// </summary>
        public virtual ICollection<ProductTemplate> ProductTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ComponentTierTemplates in the schema.
        /// </summary>
        public virtual ICollection<ComponentTierTemplate> ComponentTierTemplates
        {
            get;
            set;
        }

        #endregion
    }

}
