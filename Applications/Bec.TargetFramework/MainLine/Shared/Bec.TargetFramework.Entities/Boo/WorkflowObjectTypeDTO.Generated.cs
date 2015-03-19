﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 18/03/2015 19:00:46
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
    public partial class WorkflowObjectTypeDTO
    {
        #region Constructors
  
        public WorkflowObjectTypeDTO() {
        }

        public WorkflowObjectTypeDTO(global::System.Guid workflowObjectTypeID, string name, string description, string objectTypeName, string objectTypeNameSpace, string objectTypeAssembly, global::System.Guid workflowID, int workflowVersionNumber, List<WorkflowActionDTO> workflowActions, List<WorkflowCommandDTO> workflowCommands, List<WorkflowDecisionDTO> workflowDecisions, WorkflowDTO workflow) {

          this.WorkflowObjectTypeID = workflowObjectTypeID;
          this.Name = name;
          this.Description = description;
          this.ObjectTypeName = objectTypeName;
          this.ObjectTypeNameSpace = objectTypeNameSpace;
          this.ObjectTypeAssembly = objectTypeAssembly;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.WorkflowActions = workflowActions;
          this.WorkflowCommands = workflowCommands;
          this.WorkflowDecisions = workflowDecisions;
          this.Workflow = workflow;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowObjectTypeID { get; set; }

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
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<WorkflowActionDTO> WorkflowActions { get; set; }

        [DataMember]
        public List<WorkflowCommandDTO> WorkflowCommands { get; set; }

        [DataMember]
        public List<WorkflowDecisionDTO> WorkflowDecisions { get; set; }

        [DataMember]
        public WorkflowDTO Workflow { get; set; }

        #endregion
    }

}
