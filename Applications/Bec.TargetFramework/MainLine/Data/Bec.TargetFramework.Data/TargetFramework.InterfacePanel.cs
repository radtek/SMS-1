﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 07/04/2015 09:50:51
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
    /// There are no comments for Bec.TargetFramework.Data.InterfacePanel in the schema.
    /// </summary>
    [System.Serializable]
    public partial class InterfacePanel    {

        public InterfacePanel()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsSecuredByClaim = false;
          this.IsGridPanel = false;
          this.IsGlobal = true;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for InterfacePanelID in the schema.
        /// </summary>
        public virtual global::System.Guid InterfacePanelID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InterfacePanelVersionNumber in the schema.
        /// </summary>
        public virtual int InterfacePanelVersionNumber
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
        /// There are no comments for ParentIPID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ParentIPID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ParentIPVersionNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ParentIPVersionNumber
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
        /// There are no comments for InterfacePanelLabel in the schema.
        /// </summary>
        public virtual string InterfacePanelLabel
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for InterfacePanelClaims in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelClaim> InterfacePanelClaims
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InterfacePanelFieldDetailOrganisationTypes in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelFieldDetailOrganisationType> InterfacePanelFieldDetailOrganisationTypes
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InterfacePanelOrganisationTypes in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelOrganisationType> InterfacePanelOrganisationTypes
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InterfacePanelFDOrganaisationTypeUserTypes in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelFDOrganisationTypeUserType> InterfacePanelFDOrganaisationTypeUserTypes
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InterfacePanelOrganisationTypeUserTypes in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelOrganisationTypeUserType> InterfacePanelOrganisationTypeUserTypes
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InterfacePanelFieldDetails in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelFieldDetail> InterfacePanelFieldDetails
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InterfacePanels_ParentIPID_ParentIPVersionNumber in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanel> InterfacePanels_ParentIPID_ParentIPVersionNumber
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InterfacePanel_ParentIPID_ParentIPVersionNumber in the schema.
        /// </summary>
        public virtual InterfacePanel InterfacePanel_ParentIPID_ParentIPVersionNumber
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
    
        /// <summary>
        /// There are no comments for InterfacePanelRoles in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelRole> InterfacePanelRoles
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InterfacePanelSettings in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelSetting> InterfacePanelSettings
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InterfacePanelValidations in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelValidation> InterfacePanelValidations
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InterfacePanelValidationOrganisationTypes in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelValidationOrganisationType> InterfacePanelValidationOrganisationTypes
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InterfacePanelValidationOrganisationTypeUserTypes in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelValidationOrganisationTypeUserType> InterfacePanelValidationOrganisationTypeUserTypes
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InterfacePanelFieldDetailValidations in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelFieldDetailValidation> InterfacePanelFieldDetailValidations
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InterfacePanelFieldDetailValidationOrganisationTypes in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelFieldDetailValidationOrganisationType> InterfacePanelFieldDetailValidationOrganisationTypes
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InterfacePanelFDValidationOrganisationTypeUserTypes in the schema.
        /// </summary>
        public virtual ICollection<InterfacePanelFDValidationOrganisationTypeUserType> InterfacePanelFDValidationOrganisationTypeUserTypes
        {
            get;
            set;
        }

        #endregion
    }

}
