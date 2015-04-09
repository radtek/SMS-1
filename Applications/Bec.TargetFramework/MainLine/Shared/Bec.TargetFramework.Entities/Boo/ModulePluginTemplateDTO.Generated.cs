﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:50:53
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
    public partial class ModulePluginTemplateDTO
    {
        #region Constructors
  
        public ModulePluginTemplateDTO() {
        }

        public ModulePluginTemplateDTO(global::System.Guid modulePluginTemplateID, global::System.Guid moduleTemplateID, int moduleTemplateVersionNumber, global::System.Guid pluginTemplateID, int pluginVersionNumber, bool isActive, bool isDeleted, ModuleTemplateDTO moduleTemplate, PluginTemplateDTO pluginTemplate) {

          this.ModulePluginTemplateID = modulePluginTemplateID;
          this.ModuleTemplateID = moduleTemplateID;
          this.ModuleTemplateVersionNumber = moduleTemplateVersionNumber;
          this.PluginTemplateID = pluginTemplateID;
          this.PluginVersionNumber = pluginVersionNumber;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ModuleTemplate = moduleTemplate;
          this.PluginTemplate = pluginTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ModulePluginTemplateID { get; set; }

        [DataMember]
        public global::System.Guid ModuleTemplateID { get; set; }

        [DataMember]
        public int ModuleTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid PluginTemplateID { get; set; }

        [DataMember]
        public int PluginVersionNumber { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ModuleTemplateDTO ModuleTemplate { get; set; }

        [DataMember]
        public PluginTemplateDTO PluginTemplate { get; set; }

        #endregion
    }

}
