﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 08/04/2015 17:09:52
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
    /// There are no comments for Bec.TargetFramework.Data.VInterfacePanelForUI in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VInterfacePanelForUI    {

        public VInterfacePanelForUI()
        {
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
        /// There are no comments for IsVisible in the schema.
        /// </summary>
        public virtual bool IsVisible
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
        /// There are no comments for OrganisationTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> OrganisationTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UserTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> UserTypeID
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
    }

}
