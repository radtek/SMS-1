using Autofac;
using Bec.TargetFramework.Business.Services;
using Bec.TargetFramework.Entities.DTO.Event;
using Bec.TargetFramework.Infrastructure.Serilog;
using Bec.TargetFramework.SB.Infrastructure;
using Bec.TargetFramework.SB.Infrastructure.EventSource;
using Bec.TargetFramework.Services.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Autofac.Integration.Wcf;
using System.ServiceModel.Description;
using System.ServiceModel.Configuration;
using System.Configuration;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Infrastructure.Log;
using NServiceBus;
using NServiceBus.Installation.Environments;
using NServiceBus.Serilog.Tracing;

namespace Bec.TargetFramework.Hosts.BusinessService
{
    using Bec.TargetFramework.Framework.Configuration;
    using Bec.TargetFramework.Infrastructure;

    public partial class BusinessService : ServiceBase
    {
        private List<ServiceHost> m_ServiceHosts { get; set; }
        private List<IBusinessLogicService> m_ServiceInstances { get; set; }
        private Autofac.IContainer m_IocContainer { get; set; }

        private IBus m_Bus;

        public BusinessService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {



            StartService(args);
        }

        private void InitialiseIOC()
        {
            ContainerBuilder builder = new ContainerBuilder();

            var registrar = new Bec.TargetFramework.Hosts.BusinessService.IOC.DependencyRegistrar();

            registrar.Register(builder, null);

            m_IocContainer = builder.Build();

            IocContainerBase.AddIocContiner(m_IocContainer,AppDomain.CurrentDomain.FriendlyName);

            // use autofac container
            //Task.Factory.StartNew(() =>
            //{
            //    TracingLog.Disable();

            //    var startableBus = NServiceBusHelper.CreateDefaultStartableBusUsingaAutofacBuilder(m_IocContainer).PurgeOnStartup(true).CreateBus();

            //    Configure.Instance.ForInstallationOn<Windows>().Install();

            //    SB.Infrastructure.HookMessageMutators.InitialiseMessageMutators();

            //    m_Bus = startableBus.Start();
            //});

            Task.Factory.StartNew(
                () =>
                {
                    Bec.TargetFramework.Aop.AspectServiceLocator.Initialize(m_IocContainer, true,
                        m_IocContainer.Resolve<CommonSettings>().EnableTrace);
                });
        }

        public void StartService(string[] args)
        {
            eventLog.WriteEntry("Starting Service");

            m_ServiceHosts = new List<ServiceHost>();

            try
            {
                InitialiseIOC();
                System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                var serviceModel = ServiceModelSectionGroup.GetSectionGroup(config);

                var s = "";
                serviceModel.Services.Services.OfType<ServiceElement>().ToList()
                    .ForEach(item =>
                    {
                        try
                        {

                            Type serviceType = Type.GetType(item.Name + ", Bec.TargetFramework.Business.Services");
                            s = serviceType.Name;
                            //if (s == "UserLogicService")
                            //{
                                Type interfaceType = Type.GetType(item.Endpoints.OfType<ServiceEndpointElement>().Single(t => t.Contract.Contains("Bec.TargetFramework")).Contract + ", Bec.TargetFramework.Business.Infrastructure");
                                ServiceHost host = new ServiceHost(serviceType);
                                host.AddDependencyInjectionBehavior(interfaceType, m_IocContainer);
                                host.Open();


                                m_ServiceHosts.Add(host);
                            //}
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message + ":" + ex.StackTrace);
                            if (Serilog.Log.Logger == null)
                                new SerilogLogger(true, false, "BusinessService").Error(ex);
                            else
                                Serilog.Log.Logger.Error(ex, ex.Message, null);

                            Console.WriteLine(s);
                        }

                    });
            }
            catch (Exception ex)
            {
                if (Serilog.Log.Logger == null)
                    new SerilogLogger(true, false, "BusinessService").Error(ex);
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
