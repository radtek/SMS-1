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
    /// There are no comments for Bec.TargetFramework.Data.InterfacePanelFDValidationOrgTypeUserTypeTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class InterfacePanelFDValidationOrgTypeUserTypeTemplate    {

        public InterfacePanelFDValidationOrgTypeUserTypeTemplate()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for InterfacePanelFDValidationOrgTypeUserTypeTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid InterfacePanelFDValidationOrgTypeUserTypeTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InterfacePanelFDValidationOrgTypeUserTypeTemplateVersion in the schema.
        /// </summary>
        public virtual int InterfacePanelFDValidationOrgTypeUserTypeTemplateVersion
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
        /// There are no comments for UserTypeID in the schema.
        /// </summary>
        public virtual global::System.Guid UserTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OverrideValidationMessage in the schema.
        /// </summary>
        public virtual string OverrideValidationMessage
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OverrideValidationMessageHTML in the schema.
        /// </summary>
        public virtual string OverrideValidationMessageHTML
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OverrideValidationIsHTML in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> OverrideValidationIsHTML
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ValidationType in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ValidationType
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ValidationSubType in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ValidationSubType
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ValidationCategory in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ValidationCategory
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ValidationSubCategory in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ValidationSubCategory
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SourceErrorCodes in the schema.
        /// </summary>
        public virtual string SourceErrorCodes
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsActive in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsActive
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InterfacePanelFDValidationOrgTypeUserTypeTemplateName in the schema.
        /// </summary>
        public virtual string InterfacePanelFDValidationOrgTypeUserTypeTemplateName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsDeleted in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsDeleted
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
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
