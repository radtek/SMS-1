﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:55
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
    public partial class NotificationConstructParameterDTO
    {
        #region Constructors
  
        public NotificationConstructParameterDTO() {
        }

        public NotificationConstructParameterDTO(global::System.Guid notificationConstructParameterID, global::System.Guid notificationConstructID, int notificationConstructVersionNumber, string parameterOrBusinessObjectName, string defaultValue, string objectType, string objectName, string objectNameSpace, string objectAssembly, string objectParentName, string objectParentNameSpace, string objectParentAssembly, bool isMandatory, bool isActive, bool isDeleted, global::System.Nullable<bool> isBusinessObject, string businessObjectCategoryName, string objectParentType, NotificationConstructDTO notificationConstruct) {

          this.NotificationConstructParameterID = notificationConstructParameterID;
          this.NotificationConstructID = notificationConstructID;
          this.NotificationConstructVersionNumber = notificationConstructVersionNumber;
          this.ParameterOrBusinessObjectName = parameterOrBusinessObjectName;
          this.DefaultValue = defaultValue;
          this.ObjectType = objectType;
          this.ObjectName = objectName;
          this.ObjectNameSpace = objectNameSpace;
          this.ObjectAssembly = objectAssembly;
          this.ObjectParentName = objectParentName;
          this.ObjectParentNameSpace = objectParentNameSpace;
          this.ObjectParentAssembly = objectParentAssembly;
          this.IsMandatory = isMandatory;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsBusinessObject = isBusinessObject;
          this.BusinessObjectCategoryName = businessObjectCategoryName;
          this.ObjectParentType = objectParentType;
          this.NotificationConstruct = notificationConstruct;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid NotificationConstructParameterID { get; set; }

        [DataMember]
        public global::System.Guid NotificationConstructID { get; set; }

        [DataMember]
        public int NotificationConstructVersionNumber { get; set; }

        [DataMember]
        public string ParameterOrBusinessObjectName { get; set; }

        [DataMember]
        public string DefaultValue { get; set; }

        [DataMember]
        public string ObjectType { get; set; }

        [DataMember]
        public string ObjectName { get; set; }

        [DataMember]
        public string ObjectNameSpace { get; set; }

        [DataMember]
        public string ObjectAssembly { get; set; }

        [DataMember]
        public string ObjectParentName { get; set; }

        [DataMember]
        public string ObjectParentNameSpace { get; set; }

        [DataMember]
        public string ObjectParentAssembly { get; set; }

        [DataMember]
        public bool IsMandatory { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsBusinessObject { get; set; }

        [DataMember]
        public string BusinessObjectCategoryName { get; set; }

        [DataMember]
        public string ObjectParentType { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public NotificationConstructDTO NotificationConstruct { get; set; }

        #endregion
    }

}
