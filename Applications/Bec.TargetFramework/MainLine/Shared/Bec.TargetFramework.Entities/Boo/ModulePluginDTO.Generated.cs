﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:19 AM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{

    [DataContractAttribute(IsReference=true)]
    [System.Serializable]
    public partial class ModulePluginDTO
    {
        #region Constructors
  
        public ModulePluginDTO() {
        }

        public ModulePluginDTO(global::System.Guid modulePluginID, global::System.Guid moduleID, int moduleVersionNumber, global::System.Guid pluginID, int pluginVersionNumber, bool isActive, bool isDeleted, ModuleDTO module) {

          this.ModulePluginID = modulePluginID;
          this.ModuleID = moduleID;
          this.ModuleVersionNumber = moduleVersionNumber;
          this.PluginID = pluginID;
          this.PluginVersionNumber = pluginVersionNumber;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.Module = module;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ModulePluginID { get; set; }

        [DataMember]
        public global::System.Guid ModuleID { get; set; }

        [DataMember]
        public int ModuleVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid PluginID { get; set; }

        [DataMember]
        public int PluginVersionNumber { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ModuleDTO Module { get; set; }

        #endregion
    }

}
