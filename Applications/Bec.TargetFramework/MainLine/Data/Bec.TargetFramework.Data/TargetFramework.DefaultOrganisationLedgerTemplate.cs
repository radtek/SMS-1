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
    /// There are no comments for Bec.TargetFramework.Data.DefaultOrganisationLedgerTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class DefaultOrganisationLedgerTemplate    {

        public DefaultOrganisationLedgerTemplate()
        {
          this.HandlesCredit = false;
          this.HandlesDebit = false;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for DefaultOrganisationLedgerTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid DefaultOrganisationLedgerTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DefaultOrganisationTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid DefaultOrganisationTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DefaultOrganisationTemplateVersionNumber in the schema.
        /// </summary>
        public virtual int DefaultOrganisationTemplateVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LedgerAccountTypeID in the schema.
        /// </summary>
        public virtual int LedgerAccountTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LedgerAccountName in the schema.
        /// </summary>
        public virtual string LedgerAccountName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for HandlesCredit in the schema.
        /// </summary>
        public virtual bool HandlesCredit
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for HandlesDebit in the schema.
        /// </summary>
        public virtual bool HandlesDebit
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

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for DefaultOrganisationTemplate in the schema.
        /// </summary>
        public virtual DefaultOrganisationTemplate DefaultOrganisationTemplate
        {
            get;
            set;
        }

        #endregion
    }

}
