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
    public partial class WorkflowActionRestrictionTemplateDTO
    {
        #region Constructors
  
        public WorkflowActionRestrictionTemplateDTO() {
        }

        public WorkflowActionRestrictionTemplateDTO(global::System.Guid workflowActionTemplateID, global::System.Guid workflowRestrictionTemplateID, global::System.Guid workflowTemplateID, int workflowTemplateVersionNumber, WorkflowActionTemplateDTO workflowActionTemplate, WorkflowRestrictionTemplateDTO workflowRestrictionTemplate, WorkflowTemplateDTO workflowTemplate) {

          this.WorkflowActionTemplateID = workflowActionTemplateID;
          this.WorkflowRestrictionTemplateID = workflowRestrictionTemplateID;
          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.WorkflowActionTemplate = workflowActionTemplate;
          this.WorkflowRestrictionTemplate = workflowRestrictionTemplate;
          this.WorkflowTemplate = workflowTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowActionTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowRestrictionTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowTemplateID { get; set; }

        [DataMember]
        public int WorkflowTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowActionTemplateDTO WorkflowActionTemplate { get; set; }

        [DataMember]
        public WorkflowRestrictionTemplateDTO WorkflowRestrictionTemplate { get; set; }

        [DataMember]
        public WorkflowTemplateDTO WorkflowTemplate { get; set; }

        #endregion
    }

}
