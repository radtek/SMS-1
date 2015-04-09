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
    public partial class ServiceDefinitionDTO
    {
        #region Constructors
  
        public ServiceDefinitionDTO() {
        }

        public ServiceDefinitionDTO(global::System.Guid serviceDefinitionID, int serviceDefinitionTypeID, global::System.Nullable<int> serviceDefinitionCategoryID, string name, string description, global::System.Guid serviceInterfaceID, bool isPollingService, int numberOfRetriesPerCall, string serviceEngineObjectName, string serviceDefinitionObjectName, string serviceMutatorObjectName, global::System.Nullable<int> retryPeriodPerCallInMinutes, global::System.Nullable<bool> retryFailedCalls, List<ServiceDefinitionDetailDTO> serviceDefinitionDetails, ServiceInterfaceDTO serviceInterface, List<ServiceInterfaceProcessLogDTO> serviceInterfaceProcessLogs) {

          this.ServiceDefinitionID = serviceDefinitionID;
          this.ServiceDefinitionTypeID = serviceDefinitionTypeID;
          this.ServiceDefinitionCategoryID = serviceDefinitionCategoryID;
          this.Name = name;
          this.Description = description;
          this.ServiceInterfaceID = serviceInterfaceID;
          this.IsPollingService = isPollingService;
          this.NumberOfRetriesPerCall = numberOfRetriesPerCall;
          this.ServiceEngineObjectName = serviceEngineObjectName;
          this.ServiceDefinitionObjectName = serviceDefinitionObjectName;
          this.ServiceMutatorObjectName = serviceMutatorObjectName;
          this.RetryPeriodPerCallInMinutes = retryPeriodPerCallInMinutes;
          this.RetryFailedCalls = retryFailedCalls;
          this.ServiceDefinitionDetails = serviceDefinitionDetails;
          this.ServiceInterface = serviceInterface;
          this.ServiceInterfaceProcessLogs = serviceInterfaceProcessLogs;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ServiceDefinitionID { get; set; }

        [DataMember]
        public int ServiceDefinitionTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> ServiceDefinitionCategoryID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public global::System.Guid ServiceInterfaceID { get; set; }

        [DataMember]
        public bool IsPollingService { get; set; }

        [DataMember]
        public int NumberOfRetriesPerCall { get; set; }

        [DataMember]
        public string ServiceEngineObjectName { get; set; }

        [DataMember]
        public string ServiceDefinitionObjectName { get; set; }

        [DataMember]
        public string ServiceMutatorObjectName { get; set; }

        [DataMember]
        public global::System.Nullable<int> RetryPeriodPerCallInMinutes { get; set; }

        [DataMember]
        public global::System.Nullable<bool> RetryFailedCalls { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<ServiceDefinitionDetailDTO> ServiceDefinitionDetails { get; set; }

        [DataMember]
        public ServiceInterfaceDTO ServiceInterface { get; set; }

        [DataMember]
        public List<ServiceInterfaceProcessLogDTO> ServiceInterfaceProcessLogs { get; set; }

        #endregion
    }

}
