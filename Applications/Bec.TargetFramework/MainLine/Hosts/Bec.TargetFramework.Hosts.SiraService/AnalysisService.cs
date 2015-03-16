using Autofac;
using Autofac.Integration.Wcf;
using Bec.TargetFramework.Infrastructure.Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceProcess;
using Bec.TargetFramework.Infrastructure.Helpers;

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
            eventLog.WriteEntry("1");

            try
            {
                InitialiseIOC();
                eventLog.WriteEntry("2");
                System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                eventLog.WriteEntry("3");

                var serviceModel = ServiceModelSectionGroup.GetSectionGroup(config);

                eventLog.WriteEntry("4");

                var list = serviceModel.Services.Services.OfType<ServiceElement>().ToList();

                eventLog.WriteEntry("5");

                list.ForEach(item =>
                    {
                        Type serviceType = Type.GetType(item.Name + ", Bec.TargetFramework.Analysis.Services");
                        Type interfaceType = Type.GetType(item.Endpoints.OfType<ServiceEndpointElement>().Single(t => t.Contract.Contains("Bec.TargetFramework")).Contract + ", Bec.TargetFramework.Analysis.Interfaces");

                        ServiceHost host = new ServiceHost(serviceType);
                        host.AddDependencyInjectionBehavior(interfaceType, m_IocContainer);
                        host.Open();

                        m_ServiceHosts.Add(host);
                    });

                Console.WriteLine("Successfully added host");
                eventLog.WriteEntry("6");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding host");

                string message = ex.FlattenException();
                eventLog.WriteEntry("error: " + message);

                if (Serilog.Log.Logger == null)
                    new SerilogLogger(true, false, "AnalysisService").Error(ex);
                else
                    Serilog.Log.Logger.Error(ex, ex.Message, null);
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
