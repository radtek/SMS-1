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
    /// There are no comments for Bec.TargetFramework.Data.DirectDebitMandateTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class DirectDebitMandateTemplate    {

        public DirectDebitMandateTemplate()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsDefaultMandate = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for DirectDebitMandateTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid DirectDebitMandateTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DirectDebitMandateTemplateVersionNumber in the schema.
        /// </summary>
        public virtual int DirectDebitMandateTemplateVersionNumber
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
        /// There are no comments for NotificationConstructTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid NotificationConstructTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotificationConstructTemplateVersionNumber in the schema.
        /// </summary>
        public virtual int NotificationConstructTemplateVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsDefaultMandate in the schema.
        /// </summary>
        public virtual bool IsDefaultMandate
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for DirectDebitMandates in the schema.
        /// </summary>
        public virtual ICollection<DirectDebitMandate> DirectDebitMandates
        {
            get;
            set;
        }

        #endregion
    }

}
