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
    /// There are no comments for Bec.TargetFramework.Data.DefaultOrganisationStatusTypeTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class DefaultOrganisationStatusTypeTemplate    {

        public DefaultOrganisationStatusTypeTemplate()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
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
        /// There are no comments for ParentID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ParentID
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
        /// There are no comments for DefaultStatusTypeValueTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid DefaultStatusTypeValueTemplateID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for DefaultOrganisationTargetTemplates in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationTargetTemplate> DefaultOrganisationTargetTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationTemplate in the schema.
        /// </summary>
        public virtual DefaultOrganisationTemplate DefaultOrganisationTemplate
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StatusTypeValueTemplate in the schema.
        /// </summary>
        public virtual StatusTypeValueTemplate StatusTypeValueTemplate
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
    
        /// <summary>
        /// There are no comments for DefaultOrganisationUserTargetTemplates in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationUserTargetTemplate> DefaultOrganisationUserTargetTemplates
        {
            get;
            set;
        }

        #endregion
    }

}
