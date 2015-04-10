﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 09/04/2015 12:02:52
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
    /// There are no comments for Bec.TargetFramework.Data.FieldDetailTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class FieldDetailTemplate    {

        public FieldDetailTemplate()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.ToolTipIsHTML = false;
          this.InformationIsHTML = false;
          this.HelpIsHTML = false;
          this.IsSecuredByClaim = false;
          this.IsGlobal = true;
          this.IsGridColumn = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for FieldDetailTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid FieldDetailTemplateID
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
        /// There are no comments for FieldLabelValue in the schema.
        /// </summary>
        public virtual string FieldLabelValue
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DefaultValue in the schema.
        /// </summary>
        public virtual string DefaultValue
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
        /// There are no comments for ToolTipValue in the schema.
        /// </summary>
        public virtual string ToolTipValue
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ToolTipHTML in the schema.
        /// </summary>
        public virtual string ToolTipHTML
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ToolTipIsHTML in the schema.
        /// </summary>
        public virtual bool ToolTipIsHTML
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InformationValue in the schema.
        /// </summary>
        public virtual string InformationValue
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InformationHTML in the schema.
        /// </summary>
        public virtual string InformationHTML
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InformationIsHTML in the schema.
        /// </summary>
        public virtual bool InformationIsHTML
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for HelpValue in the schema.
        /// </summary>
        public virtual string HelpValue
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for HelpHTML in the schema.
        /// </summary>
        public virtual string HelpHTML
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for HelpIsHTML in the schema.
        /// </summary>
        public virtual bool HelpIsHTML
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsSecuredByClaim in the schema.
        /// </summary>
        public virtual bool IsSecuredByClaim
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsGlobal in the schema.
        /// </summary>
        public virtual bool IsGlobal
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FieldTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> FieldTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IconAlignmentTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> IconAlignmentTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IconFileName in the schema.
        /// </summary>
        public virtual string IconFileName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsGridColumn in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsGridColumn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FieldMask in the schema.
        /// </summary>
        public virtual string FieldMask
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for InterfacePanelFieldDetailOrganaisationTypeTemplates in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelFieldDetailOrganisationTypeTemplate> InterfacePanelFieldDetailOrganaisationTypeTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InterfacePanelFieldDetailTemplates in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelFieldDetailTemplate> InterfacePanelFieldDetailTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for FieldDetails in the schema.
        /// </summary>
        public virtual ICollection<FieldDetail> FieldDetails
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InterfacePanelFDOrganaisationTypeUserTypeTemplates in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelFDOrganisationTypeUserTypeTemplate> InterfacePanelFDOrganaisationTypeUserTypeTemplates
        {
            get;
            set;
        }

        #endregion
    }

}
