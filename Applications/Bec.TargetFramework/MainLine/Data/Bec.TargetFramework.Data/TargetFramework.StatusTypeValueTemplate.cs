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
    /// There are no comments for Bec.TargetFramework.Data.StatusTypeValueTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class StatusTypeValueTemplate    {

        public StatusTypeValueTemplate()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for StatusTypeValueTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid StatusTypeValueTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusTypeTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid StatusTypeTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusTypeTemplateVersionNumber in the schema.
        /// </summary>
        public virtual int StatusTypeTemplateVersionNumber
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


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for DefaultOrganisationStatusTypeTemplates in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationStatusTypeTemplate> DefaultOrganisationStatusTypeTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StatusTypeStructureTemplates in the schema.
        /// </summary>
        public virtual ICollection<StatusTypeStructureTemplate> StatusTypeStructureTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StatusTypeTemplate in the schema.
        /// </summary>
        public virtual StatusTypeTemplate StatusTypeTemplate
        {
            get;
            set;
        }

        #endregion
    }

}
