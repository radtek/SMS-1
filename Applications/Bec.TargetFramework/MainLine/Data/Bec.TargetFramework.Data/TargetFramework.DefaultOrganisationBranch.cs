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
    /// There are no comments for Bec.TargetFramework.Data.DefaultOrganisationBranch in the schema.
    /// </summary>
    [System.Serializable]
    public partial class DefaultOrganisationBranch    {

        public DefaultOrganisationBranch()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for DefaultOrganisationBranchID in the schema.
        /// </summary>
        public virtual global::System.Guid DefaultOrganisationBranchID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DefaultOrganisationID in the schema.
        /// </summary>
        public virtual global::System.Guid DefaultOrganisationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationTypeID in the schema.
        /// </summary>
        public virtual int OrganisationTypeID
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
        /// There are no comments for BranchSubType in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> BranchSubType
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DefaultOrganisationVersionNumber in the schema.
        /// </summary>
        public virtual int DefaultOrganisationVersionNumber
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for DefaultOrganisation in the schema.
        /// </summary>
        public virtual DefaultOrganisation DefaultOrganisation
        {
            get;
            set;
        }

        #endregion
    }

}
