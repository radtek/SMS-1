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
    public partial class WorkflowInstanceExecutionDataItemDTO
    {
        #region Constructors
  
        public WorkflowInstanceExecutionDataItemDTO() {
        }

        public WorkflowInstanceExecutionDataItemDTO(int workflowInstanceExecutionDataItemID, int workflowInstanceExecutionID, string fieldName, global::System.Nullable<int> fieldTypeID, string dataContent, string dataStr, bool dataNotJsonSerialized, global::System.Nullable<int> eventOrder, int workflowInstanceExecutionStatusEventID, WorkflowInstanceExecutionStatusEventDTO workflowInstanceExecutionStatusEvent) {

          this.WorkflowInstanceExecutionDataItemID = workflowInstanceExecutionDataItemID;
          this.WorkflowInstanceExecutionID = workflowInstanceExecutionID;
          this.FieldName = fieldName;
          this.FieldTypeID = fieldTypeID;
          this.DataContent = dataContent;
          this.DataStr = dataStr;
          this.DataNotJsonSerialized = dataNotJsonSerialized;
          this.EventOrder = eventOrder;
          this.WorkflowInstanceExecutionStatusEventID = workflowInstanceExecutionStatusEventID;
          this.WorkflowInstanceExecutionStatusEvent = workflowInstanceExecutionStatusEvent;
        }

        #endregion

        #region Properties

        [DataMember]
        public int WorkflowInstanceExecutionDataItemID { get; set; }

        [DataMember]
        public int WorkflowInstanceExecutionID { get; set; }

        [DataMember]
        public string FieldName { get; set; }

        [DataMember]
        public global::System.Nullable<int> FieldTypeID { get; set; }

        [DataMember]
        public string DataContent { get; set; }

        [DataMember]
        public string DataStr { get; set; }

        [DataMember]
        public bool DataNotJsonSerialized { get; set; }

        [DataMember]
        public global::System.Nullable<int> EventOrder { get; set; }

        [DataMember]
        public int WorkflowInstanceExecutionStatusEventID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowInstanceExecutionStatusEventDTO WorkflowInstanceExecutionStatusEvent { get; set; }

        #endregion
    }

}
