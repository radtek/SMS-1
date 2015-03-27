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
    public partial class WorkflowObjectTypeTemplateDTO
    {
        #region Constructors
  
        public WorkflowObjectTypeTemplateDTO() {
        }

        public WorkflowObjectTypeTemplateDTO(global::System.Guid workflowObjectTypeTemplateID, string name, string description, string objectTypeName, string objectTypeNameSpace, string objectTypeAssembly, global::System.Guid workflowTemplateID, int workflowTemplateVersionNumber, List<WorkflowCommandTemplateDTO> workflowCommandTemplates, List<WorkflowDecisionTemplateDTO> workflowDecisionTemplates, WorkflowTemplateDTO workflowTemplate, List<WorkflowActionTemplateDTO> workflowActionTemplates, List<WorkflowCommandTemplate1DTO> workflowCommandTemplate1s) {

          this.WorkflowObjectTypeTemplateID = workflowObjectTypeTemplateID;
          this.Name = name;
          this.Description = description;
          this.ObjectTypeName = objectTypeName;
          this.ObjectTypeNameSpace = objectTypeNameSpace;
          this.ObjectTypeAssembly = objectTypeAssembly;
          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.WorkflowCommandTemplates = workflowCommandTemplates;
          this.WorkflowDecisionTemplates = workflowDecisionTemplates;
          this.WorkflowTemplate = workflowTemplate;
          this.WorkflowActionTemplates = workflowActionTemplates;
          this.WorkflowCommandTemplate1s = workflowCommandTemplate1s;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowObjectTypeTemplateID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string ObjectTypeName { get; set; }

        [DataMember]
        public string ObjectTypeNameSpace { get; set; }

        [DataMember]
        public string ObjectTypeAssembly { get; set; }

        [DataMember]
        public global::System.Guid WorkflowTemplateID { get; set; }

        [DataMember]
        public int WorkflowTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<WorkflowCommandTemplateDTO> WorkflowCommandTemplates { get; set; }

        [DataMember]
        public List<WorkflowDecisionTemplateDTO> WorkflowDecisionTemplates { get; set; }

        [DataMember]
        public WorkflowTemplateDTO WorkflowTemplate { get; set; }

        [DataMember]
        public List<WorkflowActionTemplateDTO> WorkflowActionTemplates { get; set; }

        [DataMember]
        public List<WorkflowCommandTemplate1DTO> WorkflowCommandTemplate1s { get; set; }

        #endregion
    }

}
