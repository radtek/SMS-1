﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 17/04/2015 16:46:51
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
    /// There are no comments for Bec.TargetFramework.Data.StatusTypeStructureTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class StatusTypeStructureTemplate    {

        public StatusTypeStructureTemplate()
        {
          this.StatusOrder = 0;
          this.IsStart = false;
          this.IsEnd = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for StatusTypeStructureTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid StatusTypeStructureTemplateID
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
        /// There are no comments for StatusTypeValueTemplateID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> StatusTypeValueTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusOrder in the schema.
        /// </summary>
        public virtual int StatusOrder
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsStart in the schema.
        /// </summary>
        public virtual bool IsStart
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsEnd in the schema.
        /// </summary>
        public virtual bool IsEnd
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for StatusTypeStructureTransitionTemplates_NextStatusTypeStructureTemplateID in the schema.
        /// </summary>
        public virtual ICollection<StatusTypeStructureTransitionTemplate> StatusTypeStructureTransitionTemplates_NextStatusTypeStructureTemplateID
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StatusTypeStructureTransitionTemplates_CurrentStatusTypeStructureTemplateID in the schema.
        /// </summary>
        public virtual ICollection<StatusTypeStructureTransitionTemplate> StatusTypeStructureTransitionTemplates_CurrentStatusTypeStructureTemplateID
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

        #endregion
    }

}
