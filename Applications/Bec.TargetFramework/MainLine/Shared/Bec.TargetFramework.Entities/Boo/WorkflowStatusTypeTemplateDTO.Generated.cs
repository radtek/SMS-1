﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:55
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
    public partial class WorkflowStatusTypeTemplateDTO
    {
        #region Constructors
  
        public WorkflowStatusTypeTemplateDTO() {
        }

        public WorkflowStatusTypeTemplateDTO(global::System.Guid workflowTemplateID, int workflowTemplateVersionNumber, global::System.Guid statusTypeTemplateID, int statusTypeTemplateVersionNumber, bool isActive, bool isDeleted, StatusTypeTemplateDTO statusTypeTemplate, WorkflowTemplateDTO workflowTemplate) {

          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.StatusTypeTemplateID = statusTypeTemplateID;
          this.StatusTypeTemplateVersionNumber = statusTypeTemplateVersionNumber;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.StatusTypeTemplate = statusTypeTemplate;
          this.WorkflowTemplate = workflowTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowTemplateID { get; set; }

        [DataMember]
        public int WorkflowTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeTemplateID { get; set; }

        [DataMember]
        public int StatusTypeTemplateVersionNumber { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public StatusTypeTemplateDTO StatusTypeTemplate { get; set; }

        [DataMember]
        public WorkflowTemplateDTO WorkflowTemplate { get; set; }

        #endregion
    }

}
