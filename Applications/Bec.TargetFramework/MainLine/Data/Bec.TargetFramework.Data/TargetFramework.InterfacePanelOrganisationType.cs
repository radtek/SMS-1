﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 2/12/2015 3:31:04 PM
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
    /// There are no comments for Bec.TargetFramework.Data.InterfacePanelOrganisationType in the schema.
    /// </summary>
    [System.Serializable]
    public partial class InterfacePanelOrganisationType    {

        public InterfacePanelOrganisationType()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsVisible = true;
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
        /// There are no comments for OrganisationTypeID in the schema.
        /// </summary>
        public virtual int OrganisationTypeID
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
        /// There are no comments for InterfacePanelOrganisationTypeLabel in the schema.
        /// </summary>
        public virtual string InterfacePanelOrganisationTypeLabel
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
    
        /// <summary>
        /// There are no comments for OrganisationType in the schema.
        /// </summary>
        public virtual OrganisationType OrganisationType
        {
            get;
            set;
        }

        #endregion
    }

}
