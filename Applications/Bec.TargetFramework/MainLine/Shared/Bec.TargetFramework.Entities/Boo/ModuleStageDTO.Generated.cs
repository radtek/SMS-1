//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 6/27/2014 3:05:11 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{

    [DataContractAttribute(IsReference=true)]
    public partial class ModuleStageDTO
    {
        #region Constructors
  
        public ModuleStageDTO() {
        }

        public ModuleStageDTO(global::System.Guid moduleStageID, global::System.Nullable<System.Guid> moduleID, int moduleVersionNumber, string name, string description, int order, bool isActive, bool isDeleted, ModuleDTO module, List<ModuleWorkflowDTO> moduleWorkflows) {

          this.ModuleStageID = moduleStageID;
          this.ModuleID = moduleID;
          this.ModuleVersionNumber = moduleVersionNumber;
          this.Name = name;
          this.Description = description;
          this.Order = order;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.Module = module;
          this.ModuleWorkflows = moduleWorkflows;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ModuleStageID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ModuleID { get; set; }

        [DataMember]
        public int ModuleVersionNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int Order { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ModuleDTO Module { get; set; }

        [DataMember]
        public List<ModuleWorkflowDTO> ModuleWorkflows { get; set; }

        #endregion
    }

}
