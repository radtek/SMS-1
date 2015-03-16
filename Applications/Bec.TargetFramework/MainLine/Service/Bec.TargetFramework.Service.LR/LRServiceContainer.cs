using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Service.LR.Entities.EarlyCompletionPoll20;
using Bec.TargetFramework.Service.LR.Entities.OfficialCopyWithSummary21;
using Bec.TargetFramework.Service.LR.Infrastructure;
using Bec.TargetFramework.Service.LR.Infrastructure.Base;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Service.LR.Interfaces.Interfaces;

namespace Bec.TargetFramework.Service.LR
{
    public class LRServiceContainer :LRServiceContainerBase
    {
        private string m_ServiceName;
        private ServiceDefinitionDTO m_ServiceDto;

        public LRServiceContainer(string serviceName, ILogger logger, LRSettings settings, IDataLogic dLogic)
            : base(logger, settings, dLogic)
        {
            m_ServiceName = serviceName;
        }

        public void InitialiseContainer(ConcurrentDictionary<string, object> objectDictionary)
        {
            m_ObjectDictionary = objectDictionary;

            // get detail
            m_ServiceDto = m_DataLogic.GetServiceDefinitionWithDetail(m_ServiceName);

            // create engine
            ServiceEngine = Activator.CreateInstance(Type.GetType(m_ServiceDto.ServiceEngineObjectName)) as ILRServiceEngine;
            ServiceEngine.ServiceInterface = new LRServiceInterfaceBase
            {
                ServiceURL =
                    (m_ServiceDto.ServiceDefinitionDetails.First().ServerURL +
                     m_ServiceDto.ServiceDefinitionDetails.First().ServicePartialURL)
            };
            ServiceEngine.ServiceDefinition =
                Activator.CreateInstance(Type.GetType(m_ServiceDto.ServiceDefinitionObjectName)) as ILRServiceDefinition;

            // create service client
            CreateServiceClient();
        }

        private void CreateServiceClient()
        {
            var binding = new BasicHttpBinding(m_LRSettings.LRBindingConfigurationName);
            var endPointAddress =
                new EndpointAddress(
                    new Uri(this.ServiceEngine.ServiceInterface.ServiceURL));

            var client = Activator.CreateInstance(this.ServiceEngine.ServiceDefinition.ServiceClientType,new object[] {binding, endPointAddress});

            // set client
            ServiceEngine.ServiceDefinition.ServiceClient = client;

            // initialise client
            ServiceEngine.InitialiseServiceClient(m_LRSettings.LRUserName,m_LRSettings.LRPassword,m_LRSettings.LRCertificatSerialNumber);
        }


        public LRServiceResponseDTO ExecuteService()
        {
            LRServiceResponseDTO responseDto = new LRServiceResponseDTO();

            // create request
            ServiceEngine.CreateServiceRequest(m_ObjectDictionary);

            try
            {
                ServiceEngine.ExecuteService();

                responseDto = ServiceEngine.ProcessServiceResponse(m_ObjectDictionary);
            }
            catch (FaultException ex)
            {
                responseDto.Exception = ex;

                MessageFault msgFault = ex.CreateMessageFault();

                // log internal errors
                if (msgFault.HasDetail)
                {
                    var content = msgFault.GetReaderAtDetailContents().ReadOuterXml();

                    responseDto.ExceptionMessage = content;

                    m_Logger.Error(new TargetFrameworkLogDTO
                    {
                        Detail = content,
                        Message = ex.Message,
                        Exception = ex,
                        ApplicationSource = this.ServiceEngine.ServiceInterface.ServiceURL
                    });
                }

                // log errors
                m_Logger.Error(ex,ex.Message,null);
                
            }
            finally { ServiceEngine.CloseServiceClient();}

            return responseDto;
        }
    }
}
