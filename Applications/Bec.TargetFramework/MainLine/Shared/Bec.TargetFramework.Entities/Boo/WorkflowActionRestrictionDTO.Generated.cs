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
    public partial class WorkflowActionRestrictionDTO
    {
        #region Constructors
  
        public WorkflowActionRestrictionDTO() {
        }

        public WorkflowActionRestrictionDTO(global::System.Guid workflowActionID, global::System.Guid workflowRestrictionID, global::System.Guid workflowID, int workflowVersionNumber, WorkflowDTO workflow, WorkflowActionDTO workflowAction, WorkflowRestrictionDTO workflowRestriction) {

          this.WorkflowActionID = workflowActionID;
          this.WorkflowRestrictionID = workflowRestrictionID;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.Workflow = workflow;
          this.WorkflowAction = workflowAction;
          this.WorkflowRestriction = workflowRestriction;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowActionID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowRestrictionID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowDTO Workflow { get; set; }

        [DataMember]
        public WorkflowActionDTO WorkflowAction { get; set; }

        [DataMember]
        public WorkflowRestrictionDTO WorkflowRestriction { get; set; }

        #endregion
    }

}
