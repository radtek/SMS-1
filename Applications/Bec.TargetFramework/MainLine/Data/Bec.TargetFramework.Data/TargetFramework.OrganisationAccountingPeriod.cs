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
    /// There are no comments for Bec.TargetFramework.Data.OrganisationAccountingPeriod in the schema.
    /// </summary>
    [System.Serializable]
    public partial class OrganisationAccountingPeriod    {

        public OrganisationAccountingPeriod()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for OrganisationAccountingPeriodID in the schema.
        /// </summary>
        public virtual int OrganisationAccountingPeriodID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for GlobalAccountingPeriodID in the schema.
        /// </summary>
        public virtual int GlobalAccountingPeriodID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationID in the schema.
        /// </summary>
        public virtual global::System.Guid OrganisationID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for Invoices in the schema.
        /// </summary>
        public virtual ICollection<Invoice> Invoices
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for GlobalAccountingPeriod in the schema.
        /// </summary>
        public virtual GlobalAccountingPeriod GlobalAccountingPeriod
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Organisation in the schema.
        /// </summary>
        public virtual Organisation Organisation
        {
            get;
            set;
        }

        #endregion
    }

}
