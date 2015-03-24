using Autofac;
using Autofac.Integration.Wcf;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Infrastructure.Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceProcess;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Infrastructure.Serilog.Helpers;
using ServiceStack.Text;

namespace Bec.TargetFramework.Hosts.AnalysisService
{
    public partial class AnalysisService : ServiceBase
    {
        private List<ServiceHost> m_ServiceHosts { get; set; }

        public static Autofac.IContainer m_IocContainer { get; set; }

        public AnalysisService()
        {
            InitializeComponent();
        }

        private void InitialiseIOC()
        {
            ContainerBuilder builder = new ContainerBuilder();

            var registrar = new Bec.TargetFramework.Hosts.AnalysisService.IOC.DependencyRegistrar();

            registrar.Register(builder, null);

            m_IocContainer = builder.Build();
        }

        protected override void OnStart(string[] args)
        {
            StartService(args);
        }

        public void StartService(string[] args)
        {
            eventLog.WriteEntry("Starting Service");

            m_ServiceHosts = new List<ServiceHost>();

            try
            {
               
                InitialiseIOC();

                throw new Exception("test");
     
                System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                var serviceModel = ServiceModelSectionGroup.GetSectionGroup(config);

                var list = serviceModel.Services.Services.OfType<ServiceElement>().ToList();

                list.ForEach(item =>
                    {
                        Type serviceType = Type.GetType(item.Name + ", Bec.TargetFramework.Analysis.Services");
                        Type interfaceType = Type.GetType(item.Endpoints.OfType<ServiceEndpointElement>().Where(t => t.Contract.Contains("Bec.TargetFramework")).First().Contract + ", Bec.TargetFramework.Analysis.Interfaces");

                        try
                        {
                            ServiceHost host = new ServiceHost(serviceType);
                            host.AddDependencyInjectionBehavior(interfaceType, m_IocContainer);
                            host.Open();

                            m_ServiceHosts.Add(host);
                        }
                        catch (System.Exception ex)
                        {
                            eventLog.WriteEntry(ex.Dump());

                            var logger = m_IocContainer.Resolve<ILogger>();

                            logger.Error(ex, ex.Message);

                            throw;
                        }

                        
                    });
            }
            catch (Exception ex)
            {
                eventLog.WriteEntry(ex.Dump());

                if (m_IocContainer != null)
                {
                    var logger = m_IocContainer.Resolve<ILogger>();

                    logger.Error(ex, ex.Message);
                }
                else
                    SerilogHelper.LogException(AppDomain.CurrentDomain.FriendlyName, ex);

                OnStop();
            }
        }
        
        protected override void OnStop()
        {
            eventLog.WriteEntry("Stopping Service");

            if (m_ServiceHosts != null)
            {
                m_ServiceHosts.ForEach(item =>
                    item.Close());
            }

            base.OnStop();
        }

        protected override void OnShutdown()
        {
            eventLog.WriteEntry("Shutting Down Service");

            base.OnShutdown();
        }
    }
}
