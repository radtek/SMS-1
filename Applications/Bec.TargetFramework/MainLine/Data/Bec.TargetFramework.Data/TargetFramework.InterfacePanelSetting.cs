﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 26/03/2015 16:14:58
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
    /// There are no comments for Bec.TargetFramework.Data.InterfacePanelSetting in the schema.
    /// </summary>
    [System.Serializable]
    public partial class InterfacePanelSetting    {

        public InterfacePanelSetting()
        {
          this.IsVisible = false;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for InterfacePanelSettingID in the schema.
        /// </summary>
        public virtual global::System.Guid InterfacePanelSettingID
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
