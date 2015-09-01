﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
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
    public partial class PluginDTO
    {
        #region Constructors
  
        public PluginDTO() {
        }

        public PluginDTO(global::System.Guid pluginID, int pluginVersionNumber, string name, string description, string version, int versionNumber, string author, string systemName, int displayOrder, string pluginFileName, global::System.Guid pluginTemplateID, int pluginTemplateVersionNumber, bool isActive, bool isDeleted, PluginTemplateDTO pluginTemplate) {

          this.PluginID = pluginID;
          this.PluginVersionNumber = pluginVersionNumber;
          this.Name = name;
          this.Description = description;
          this.Version = version;
          this.VersionNumber = versionNumber;
          this.Author = author;
          this.SystemName = systemName;
          this.DisplayOrder = displayOrder;
          this.PluginFileName = pluginFileName;
          this.PluginTemplateID = pluginTemplateID;
          this.PluginTemplateVersionNumber = pluginTemplateVersionNumber;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.PluginTemplate = pluginTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid PluginID { get; set; }

        [DataMember]
        public int PluginVersionNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Version { get; set; }

        [DataMember]
        public int VersionNumber { get; set; }

        [DataMember]
        public string Author { get; set; }

        [DataMember]
        public string SystemName { get; set; }

        [DataMember]
        public int DisplayOrder { get; set; }

        [DataMember]
        public string PluginFileName { get; set; }

        [DataMember]
        public global::System.Guid PluginTemplateID { get; set; }

        [DataMember]
        public int PluginTemplateVersionNumber { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public PluginTemplateDTO PluginTemplate { get; set; }

        #endregion
    }

}