﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:50:53
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
    public partial class WorkflowExecutionStatusDTO
    {
        #region Constructors
  
        public WorkflowExecutionStatusDTO() {
        }

        public WorkflowExecutionStatusDTO(int workflowExecutionStatusID, string name, string description, List<WorkflowInstanceExecutionStatusEventDTO> workflowInstanceExecutionStatusEvents) {

          this.WorkflowExecutionStatusID = workflowExecutionStatusID;
          this.Name = name;
          this.Description = description;
          this.WorkflowInstanceExecutionStatusEvents = workflowInstanceExecutionStatusEvents;
        }

        #endregion

        #region Properties

        [DataMember]
        public int WorkflowExecutionStatusID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<WorkflowInstanceExecutionStatusEventDTO> WorkflowInstanceExecutionStatusEvents { get; set; }

        #endregion
    }

}
