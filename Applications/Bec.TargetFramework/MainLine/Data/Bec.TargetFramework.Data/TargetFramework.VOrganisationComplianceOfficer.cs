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
    /// There are no comments for Bec.TargetFramework.Data.VOrganisationComplianceOfficer in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VOrganisationComplianceOfficer    {

        public VOrganisationComplianceOfficer()
        {
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
        /// There are no comments for COEmail in the schema.
        /// </summary>
        public virtual string COEmail
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for COFirstName in the schema.
        /// </summary>
        public virtual string COFirstName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for COLastName in the schema.
        /// </summary>
        public virtual string COLastName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CompanyName in the schema.
        /// </summary>
        public virtual string CompanyName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TradingName in the schema.
        /// </summary>
        public virtual string TradingName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BranchName in the schema.
        /// </summary>
        public virtual string BranchName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BranchRegulatorID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> BranchRegulatorID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BranchRegulator in the schema.
        /// </summary>
        public virtual string BranchRegulator
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BranchRegulatorNumber in the schema.
        /// </summary>
        public virtual string BranchRegulatorNumber
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
