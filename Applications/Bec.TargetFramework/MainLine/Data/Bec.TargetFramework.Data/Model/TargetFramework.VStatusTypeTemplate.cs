﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
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
    /// There are no comments for Bec.TargetFramework.Data.VStatusTypeTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VStatusTypeTemplate    {

        public VStatusTypeTemplate()
        {
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
        /// There are no comments for TemplateName in the schema.
        /// </summary>
        public virtual string TemplateName
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
    }

}