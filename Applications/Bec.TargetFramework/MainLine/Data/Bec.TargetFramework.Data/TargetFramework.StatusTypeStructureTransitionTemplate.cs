﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 07/04/2015 16:15:16
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
    /// There are no comments for Bec.TargetFramework.Data.StatusTypeStructureTransitionTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class StatusTypeStructureTransitionTemplate    {

        public StatusTypeStructureTransitionTemplate()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for StatusTypeStructureTransitionTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid StatusTypeStructureTransitionTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CurrentStatusTypeStructureTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid CurrentStatusTypeStructureTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NextStatusTypeStructureTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid NextStatusTypeStructureTemplateID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for StatusTypeStructureTemplate_NextStatusTypeStructureTemplateID in the schema.
        /// </summary>
        public virtual StatusTypeStructureTemplate StatusTypeStructureTemplate_NextStatusTypeStructureTemplateID
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StatusTypeStructureTemplate_CurrentStatusTypeStructureTemplateID in the schema.
        /// </summary>
        public virtual StatusTypeStructureTemplate StatusTypeStructureTemplate_CurrentStatusTypeStructureTemplateID
        {
            get;
            set;
        }

        #endregion
    }

}
