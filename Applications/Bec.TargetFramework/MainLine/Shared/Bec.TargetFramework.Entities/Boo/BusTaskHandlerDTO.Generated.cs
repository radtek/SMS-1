﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:54
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
    public partial class BusTaskHandlerDTO
    {
        #region Constructors
  
        public BusTaskHandlerDTO() {
        }

        public BusTaskHandlerDTO(global::System.Guid busTaskHandlerID, string name, string objectTypeName, bool isActive, bool isDeleted, string objectTypeAssembly, string messageTypeName, string messageTypeAssembly, string handlerMessageTypeName, string handlerMessageTypeAssembly, global::System.Nullable<bool> isHandlerBasedTask, global::System.Nullable<int> numberOfRetries, bool taskDataHasExpiry, global::System.Nullable<int> taskDataExpiryPeriodUnitID, global::System.Nullable<int> taskDataExpiryPeriod, global::System.Nullable<int> defaultProcessDataTypeID, global::System.Nullable<int> defaultProcessDataCategoryID, List<BusTaskDTO> busTasks) {

          this.BusTaskHandlerID = busTaskHandlerID;
          this.Name = name;
          this.ObjectTypeName = objectTypeName;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ObjectTypeAssembly = objectTypeAssembly;
          this.MessageTypeName = messageTypeName;
          this.MessageTypeAssembly = messageTypeAssembly;
          this.HandlerMessageTypeName = handlerMessageTypeName;
          this.HandlerMessageTypeAssembly = handlerMessageTypeAssembly;
          this.IsHandlerBasedTask = isHandlerBasedTask;
          this.NumberOfRetries = numberOfRetries;
          this.TaskDataHasExpiry = taskDataHasExpiry;
          this.TaskDataExpiryPeriodUnitID = taskDataExpiryPeriodUnitID;
          this.TaskDataExpiryPeriod = taskDataExpiryPeriod;
          this.DefaultProcessDataTypeID = defaultProcessDataTypeID;
          this.DefaultProcessDataCategoryID = defaultProcessDataCategoryID;
          this.BusTasks = busTasks;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid BusTaskHandlerID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string ObjectTypeName { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public string ObjectTypeAssembly { get; set; }

        [DataMember]
        public string MessageTypeName { get; set; }

        [DataMember]
        public string MessageTypeAssembly { get; set; }

        [DataMember]
        public string HandlerMessageTypeName { get; set; }

        [DataMember]
        public string HandlerMessageTypeAssembly { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsHandlerBasedTask { get; set; }

        [DataMember]
        public global::System.Nullable<int> NumberOfRetries { get; set; }

        [DataMember]
        public bool TaskDataHasExpiry { get; set; }

        [DataMember]
        public global::System.Nullable<int> TaskDataExpiryPeriodUnitID { get; set; }

        [DataMember]
        public global::System.Nullable<int> TaskDataExpiryPeriod { get; set; }

        [DataMember]
        public global::System.Nullable<int> DefaultProcessDataTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> DefaultProcessDataCategoryID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<BusTaskDTO> BusTasks { get; set; }

        #endregion
    }

}
