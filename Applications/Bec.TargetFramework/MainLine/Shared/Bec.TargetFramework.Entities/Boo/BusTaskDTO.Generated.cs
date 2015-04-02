﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:53
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
    public partial class BusTaskDTO
    {
        #region Constructors
  
        public BusTaskDTO() {
        }

        public BusTaskDTO(global::System.Guid busTaskID, string name, string description, global::System.DateTime createdOn, bool isActive, bool isDeleted, global::System.Guid busTaskHandlerID, int busTaskVersionNumber, BusTaskHandlerDTO busTaskHandler, List<BusTaskScheduleDTO> busTaskSchedules, List<ProductBusTaskDTO> productBusTasks, List<ProductBusTaskTemplateDTO> productBusTaskTemplates) {

          this.BusTaskID = busTaskID;
          this.Name = name;
          this.Description = description;
          this.CreatedOn = createdOn;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.BusTaskHandlerID = busTaskHandlerID;
          this.BusTaskVersionNumber = busTaskVersionNumber;
          this.BusTaskHandler = busTaskHandler;
          this.BusTaskSchedules = busTaskSchedules;
          this.ProductBusTasks = productBusTasks;
          this.ProductBusTaskTemplates = productBusTaskTemplates;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid BusTaskID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid BusTaskHandlerID { get; set; }

        [DataMember]
        public int BusTaskVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public BusTaskHandlerDTO BusTaskHandler { get; set; }

        [DataMember]
        public List<BusTaskScheduleDTO> BusTaskSchedules { get; set; }

        [DataMember]
        public List<ProductBusTaskDTO> ProductBusTasks { get; set; }

        [DataMember]
        public List<ProductBusTaskTemplateDTO> ProductBusTaskTemplates { get; set; }

        #endregion
    }

}
