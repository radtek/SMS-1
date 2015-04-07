﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 16:15:20
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
    public partial class ServiceInterfaceDTO
    {
        #region Constructors
  
        public ServiceInterfaceDTO() {
        }

        public ServiceInterfaceDTO(global::System.Guid serviceInterfaceID, string name, string description, int serviceInterfaceTypeID, global::System.Nullable<int> serviceInterfaceCategoryID, bool isActive, bool isDeleted, List<ServiceDefinitionDTO> serviceDefinitions) {

          this.ServiceInterfaceID = serviceInterfaceID;
          this.Name = name;
          this.Description = description;
          this.ServiceInterfaceTypeID = serviceInterfaceTypeID;
          this.ServiceInterfaceCategoryID = serviceInterfaceCategoryID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ServiceDefinitions = serviceDefinitions;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ServiceInterfaceID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int ServiceInterfaceTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> ServiceInterfaceCategoryID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<ServiceDefinitionDTO> ServiceDefinitions { get; set; }

        #endregion
    }

}
