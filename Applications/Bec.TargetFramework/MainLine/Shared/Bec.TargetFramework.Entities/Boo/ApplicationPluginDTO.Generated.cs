//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 6/10/2014 2:36:07 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities.DTO
{

    [DataContractAttribute(IsReference=true)]
    public partial class ApplicationPluginDTO
    {
        #region Constructors
  
        public ApplicationPluginDTO() {
        }

        public ApplicationPluginDTO(global::System.Guid applicationPluginID, global::System.Guid pluginID, int pluginVersionNumber, bool isActive, bool isDeleted, PluginDTO plugin) {

          this.ApplicationPluginID = applicationPluginID;
          this.PluginID = pluginID;
          this.PluginVersionNumber = pluginVersionNumber;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.Plugin = plugin;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ApplicationPluginID { get; set; }

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
        public PluginDTO Plugin { get; set; }

        #endregion
    }

}
