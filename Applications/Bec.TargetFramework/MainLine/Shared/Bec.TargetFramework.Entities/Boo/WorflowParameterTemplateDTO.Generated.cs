﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 16:15:18
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
    public partial class WorflowParameterTemplateDTO
    {
        #region Constructors
  
        public WorflowParameterTemplateDTO() {
        }

        public WorflowParameterTemplateDTO(global::System.Guid worflowParameterTemplateID, bool isConfigurable1, string parameterName, string parameterValue, string parameterType, bool isActive, bool isDeleted, global::System.Guid workflowTemplateID, int workflowTemplateVersionNumber, WorkflowTemplateDTO workflowTemplate) {

          this.WorflowParameterTemplateID = worflowParameterTemplateID;
          this.IsConfigurable1 = isConfigurable1;
          this.ParameterName = parameterName;
          this.ParameterValue = parameterValue;
          this.ParameterType = parameterType;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.WorkflowTemplate = workflowTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorflowParameterTemplateID { get; set; }

        [DataMember]
        public bool IsConfigurable1 { get; set; }

        [DataMember]
        public string ParameterName { get; set; }

        [DataMember]
        public string ParameterValue { get; set; }

        [DataMember]
        public string ParameterType { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid WorkflowTemplateID { get; set; }

        [DataMember]
        public int WorkflowTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowTemplateDTO WorkflowTemplate { get; set; }

        #endregion
    }

}
