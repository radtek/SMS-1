﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 13/04/2015 17:29:36
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
    /// There are no comments for Bec.TargetFramework.Data.InterfacePanelTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class InterfacePanelTemplate    {

        public InterfacePanelTemplate()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsSecuredByClaim = false;
          this.IsGridPanel = false;
          this.IsGlobal = true;
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
        /// There are no comments for InterfacePanelTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> InterfacePanelTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InterfacePanelSubTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> InterfacePanelSubTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InterfacePanelCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> InterfacePanelCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InterfacePanelSubCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> InterfacePanelSubCategoryID
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
        /// There are no comments for ParentIPTemplateID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ParentIPTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ParentIPTemplateVersionNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ParentIPTemplateVersionNumber
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
        /// There are no comments for IsGridPanel in the schema.
        /// </summary>
        public virtual bool IsGridPanel
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
        /// There are no comments for InterfacePanelTemplateLabel in the schema.
        /// </summary>
        public virtual string InterfacePanelTemplateLabel
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for InterfacePanelClaimTemplates in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelClaimTemplate> InterfacePanelClaimTemplates
        {
            get;
            set;
        }
    
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
        /// There are no comments for InterfacePanelOrganisationTypeUserTypeTemplates in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelOrganisationTypeUserTypeTemplate> InterfacePanelOrganisationTypeUserTypeTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InterfacePanels in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanel> InterfacePanels
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InterfacePanelTemplates_ParentIPTemplateID_ParentIPTemplateVersionNumber in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelTemplate> InterfacePanelTemplates_ParentIPTemplateID_ParentIPTemplateVersionNumber
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InterfacePanelTemplate_ParentIPTemplateID_ParentIPTemplateVersionNumber in the schema.
        /// </summary>
        public virtual InterfacePanelTemplate InterfacePanelTemplate_ParentIPTemplateID_ParentIPTemplateVersionNumber
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InterfacePanelSettingTemplates in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelSettingTemplate> InterfacePanelSettingTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InterfacePanelRoleTemplates in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelRoleTemplate> InterfacePanelRoleTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InterfacePanelOrganisationTypeTemplates in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelOrganisationTypeTemplate> InterfacePanelOrganisationTypeTemplates
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
    
        /// <summary>
        /// There are no comments for WorkflowTreeStructureTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowTreeStructureTemplate> WorkflowTreeStructureTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InterfacePanelValidationOrganisationTypeTemplates in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelValidationOrganisationTypeTemplate> InterfacePanelValidationOrganisationTypeTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InterfacePanelValidationOrganisationTypeUserTypeTemplates in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelValidationOrganisationTypeUserTypeTemplate> InterfacePanelValidationOrganisationTypeUserTypeTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InterfacePanelFieldDetailValidationTemplate in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelFieldDetailValidationTemplate> InterfacePanelFieldDetailValidationTemplate
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InterfacePanelFieldDetailValidationOrganisationTypeTemplates in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelFieldDetailValidationOrganisationTypeTemplate> InterfacePanelFieldDetailValidationOrganisationTypeTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InterfacePanelFDValidationOrgTypeUserTypeTemplates in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelFDValidationOrgTypeUserTypeTemplate> InterfacePanelFDValidationOrgTypeUserTypeTemplates
        {
            get;
            set;
        }

        #endregion
    }

}
