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
    /// There are no comments for Bec.TargetFramework.Data.InterfacePanelFieldDetailOrganisationTypeTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class InterfacePanelFieldDetailOrganisationTypeTemplate    {

        public InterfacePanelFieldDetailOrganisationTypeTemplate()
        {
          this.IsVisible = true;
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsMandatory = false;
          this.IsFilterable = false;
          this.OverrideToolTipIsHTML = false;
          this.OverrideInformationIsHTML = false;
          this.OverrideHelpIsHTML = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for InterfacePanelTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid InterfacePanelTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InterfacePanelTemplateVersionNumber in the schema.
        /// </summary>
        public virtual int InterfacePanelTemplateVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FieldDetailTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid FieldDetailTemplateID
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
        /// There are no comments for IsVisible in the schema.
        /// </summary>
        public virtual bool IsVisible
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
        /// There are no comments for IsMandatory in the schema.
        /// </summary>
        public virtual bool IsMandatory
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsFilterable in the schema.
        /// </summary>
        public virtual bool IsFilterable
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OverrideDefaultValue in the schema.
        /// </summary>
        public virtual string OverrideDefaultValue
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OverrideToolTipValue in the schema.
        /// </summary>
        public virtual string OverrideToolTipValue
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OverrideToolTipHTML in the schema.
        /// </summary>
        public virtual string OverrideToolTipHTML
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OverrideToolTipIsHTML in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> OverrideToolTipIsHTML
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OverrideInformationValue in the schema.
        /// </summary>
        public virtual string OverrideInformationValue
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OverrideInformationHTML in the schema.
        /// </summary>
        public virtual string OverrideInformationHTML
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OverrideInformationIsHTML in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> OverrideInformationIsHTML
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OverrideHelpValue in the schema.
        /// </summary>
        public virtual string OverrideHelpValue
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OverrideHelpHTML in the schema.
        /// </summary>
        public virtual string OverrideHelpHTML
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OverrideHelpIsHTML in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> OverrideHelpIsHTML
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OverrideFieldLabelValue in the schema.
        /// </summary>
        public virtual string OverrideFieldLabelValue
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for OrganisationType in the schema.
        /// </summary>
        public virtual OrganisationType OrganisationType
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for FieldDetailTemplate in the schema.
        /// </summary>
        public virtual FieldDetailTemplate FieldDetailTemplate
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InterfacePanelTemplate in the schema.
        /// </summary>
        public virtual InterfacePanelTemplate InterfacePanelTemplate
        {
            get;
            set;
        }

        #endregion
    }

}
