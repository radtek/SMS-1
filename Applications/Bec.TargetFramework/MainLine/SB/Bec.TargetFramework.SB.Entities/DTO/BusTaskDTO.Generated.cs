﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 29/04/2015 12:05:04
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.SB.Entities
{

    [DataContractAttribute(IsReference=true)]
    public partial class BusTaskDTO
    {
        #region Constructors
  
        public BusTaskDTO() {
        }

        public BusTaskDTO(global::System.Guid busTaskID, string name, string description, global::System.DateTime createdOn, bool isActive, bool isDeleted, string createdBy, global::System.Nullable<System.DateTime> modifiedOn, string modifiedBy, global::System.Guid busTaskHandlerID, int busTaskHandlerVersionNumber, bool isScheduleDrivenTask, global::System.Nullable<int> busTaskTypeID, global::System.Nullable<int> busTaskCategoryID, string busTaskGroupName, global::System.Nullable<int> applicationID, global::System.Nullable<int> applicationEnvironmentID, global::System.Nullable<System.Guid> parentID, string referenceNumber, BusTaskHandlerDTO busTaskHandler, List<BusTaskScheduleDTO> busTaskSchedules) {

          this.BusTaskID = busTaskID;
          this.Name = name;
          this.Description = description;
          this.CreatedOn = createdOn;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.CreatedBy = createdBy;
          this.ModifiedOn = modifiedOn;
          this.ModifiedBy = modifiedBy;
          this.BusTaskHandlerID = busTaskHandlerID;
          this.BusTaskHandlerVersionNumber = busTaskHandlerVersionNumber;
          this.IsScheduleDrivenTask = isScheduleDrivenTask;
          this.BusTaskTypeID = busTaskTypeID;
          this.BusTaskCategoryID = busTaskCategoryID;
          this.BusTaskGroupName = busTaskGroupName;
          this.ApplicationID = applicationID;
          this.ApplicationEnvironmentID = applicationEnvironmentID;
          this.ParentID = parentID;
          this.ReferenceNumber = referenceNumber;
          this.BusTaskHandler = busTaskHandler;
          this.BusTaskSchedules = busTaskSchedules;
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
        public string CreatedBy { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> ModifiedOn { get; set; }

        [DataMember]
        public string ModifiedBy { get; set; }

        [DataMember]
        public global::System.Guid BusTaskHandlerID { get; set; }

        [DataMember]
        public int BusTaskHandlerVersionNumber { get; set; }

        [DataMember]
        public bool IsScheduleDrivenTask { get; set; }

        [DataMember]
        public global::System.Nullable<int> BusTaskTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> BusTaskCategoryID { get; set; }

        [DataMember]
        public string BusTaskGroupName { get; set; }

        [DataMember]
        public global::System.Nullable<int> ApplicationID { get; set; }

        [DataMember]
        public global::System.Nullable<int> ApplicationEnvironmentID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public string ReferenceNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public BusTaskHandlerDTO BusTaskHandler { get; set; }

        [DataMember]
        public List<BusTaskScheduleDTO> BusTaskSchedules { get; set; }

        #endregion
    }

}
