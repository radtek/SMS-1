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
    /// There are no comments for Bec.TargetFramework.Data.InterfacePanelValidation in the schema.
    /// </summary>
    [System.Serializable]
    public partial class InterfacePanelValidation    {

        public InterfacePanelValidation()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for InterfacePanelValidationID in the schema.
        /// </summary>
        public virtual global::System.Guid InterfacePanelValidationID
        {
            get;
            set;
        }

    
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
        /// There are no comments for InterfacePanelValidationVersionNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> InterfacePanelValidationVersionNumber
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
        /// There are no comments for IsDeleted in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsDeleted
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
        /// There are no comments for InterfacePanelValidationName in the schema.
        /// </summary>
        public virtual string InterfacePanelValidationName
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for InterfacePanel in the schema.
        /// </summary>
        public virtual InterfacePanel InterfacePanel
        {
            get;
            set;
        }

        #endregion
    }

}
