﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 3/27/2015 9:57:18 AM
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
    /// There are no comments for Bec.TargetFramework.Data.LegalOrganisationDetail in the schema.
    /// </summary>
    [System.Serializable]
    public partial class LegalOrganisationDetail    {

        public LegalOrganisationDetail()
        {
          this.IsVATRegistered = false;
          this.IsCompanyHouseRegistered = false;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for OrganisationID in the schema.
        /// </summary>
        public virtual global::System.Guid OrganisationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsVATRegistered in the schema.
        /// </summary>
        public virtual bool IsVATRegistered
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for VATNumber in the schema.
        /// </summary>
        public virtual string VATNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsCompanyHouseRegistered in the schema.
        /// </summary>
        public virtual bool IsCompanyHouseRegistered
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RegisteredCompanyNumber in the schema.
        /// </summary>
        public virtual string RegisteredCompanyNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PartnersCount in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> PartnersCount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RegisteredPractitionersCount in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> RegisteredPractitionersCount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StaffCount in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> StaffCount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MonthlyCompletionsCount in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> MonthlyCompletionsCount
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
    }

}
