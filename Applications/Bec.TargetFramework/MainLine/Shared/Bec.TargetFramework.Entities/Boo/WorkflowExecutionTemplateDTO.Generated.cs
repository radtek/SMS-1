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
    public partial class WorkflowExecutionTemplateDTO
    {
        #region Constructors
  
        public WorkflowExecutionTemplateDTO() {
        }

        public WorkflowExecutionTemplateDTO(global::System.Guid workflowExecutionTemplateID, string name, string description, int versionNumber) {

          this.WorkflowExecutionTemplateID = workflowExecutionTemplateID;
          this.Name = name;
          this.Description = description;
          this.VersionNumber = versionNumber;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowExecutionTemplateID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int VersionNumber { get; set; }

        #endregion
    }

}
