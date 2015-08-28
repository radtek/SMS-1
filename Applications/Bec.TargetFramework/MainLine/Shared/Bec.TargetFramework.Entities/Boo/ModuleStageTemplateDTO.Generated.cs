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
    public partial class ModuleStageTemplateDTO
    {
        #region Constructors
  
        public ModuleStageTemplateDTO() {
        }

        public ModuleStageTemplateDTO(global::System.Guid moduleStageTemplateID, global::System.Guid moduleTemplateID, int moduleTemplateVersionNumber, string name, string description, int order, bool isActive, bool isDeleted, ModuleTemplateDTO moduleTemplate, List<ModuleWorkflowTemplateDTO> moduleWorkflowTemplates) {

          this.ModuleStageTemplateID = moduleStageTemplateID;
          this.ModuleTemplateID = moduleTemplateID;
          this.ModuleTemplateVersionNumber = moduleTemplateVersionNumber;
          this.Name = name;
          this.Description = description;
          this.Order = order;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ModuleTemplate = moduleTemplate;
          this.ModuleWorkflowTemplates = moduleWorkflowTemplates;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ModuleStageTemplateID { get; set; }

        [DataMember]
        public global::System.Guid ModuleTemplateID { get; set; }

        [DataMember]
        public int ModuleTemplateVersionNumber { get; set; }

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
        public ModuleTemplateDTO ModuleTemplate { get; set; }

        [DataMember]
        public List<ModuleWorkflowTemplateDTO> ModuleWorkflowTemplates { get; set; }

        #endregion
    }

}
