﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:06 PM
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
    public partial class WorkflowExecutionDTO
    {
        #region Constructors
  
        public WorkflowExecutionDTO() {
        }

        public WorkflowExecutionDTO(global::System.Guid workflowExecutionID, string name, string description, int versionNumber) {

          this.WorkflowExecutionID = workflowExecutionID;
          this.Name = name;
          this.Description = description;
          this.VersionNumber = versionNumber;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowExecutionID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int VersionNumber { get; set; }

        #endregion
    }

}
