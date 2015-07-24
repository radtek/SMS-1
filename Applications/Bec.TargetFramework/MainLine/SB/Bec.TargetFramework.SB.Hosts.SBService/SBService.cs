using Autofac;
using Bec.TargetFramework.Infrastructure.IOC;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.SB.Infrastructure;
using Bec.TargetFramework.WindowsService;
using Microsoft.Owin.Hosting;
using NServiceBus;
using System;
using System.Configuration;
using System.ServiceProcess;

namespace Bec.TargetFramework.SB.Hosts.SBService
{
    partial class SBService : ServiceBase, IWindowsService
    {
        public string m_BaseAddress { get; set; }

        public static ILifetimeScope m_LifetimeScope;

        private IDisposable m_Server = null;

        public SBService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            StartService(args);
        }

        private void InitialiseIOC()
        {
            IocProvider.BuildAndRegisterIocContainer<Bec.TargetFramework.SB.Hosts.SBService.IOC.DependencyRegistrar>();

            var busConfig = NServiceBusHelper.CreateDefaultStartableBusUsingaAutofacBuilder(IocProvider.GetIocContainerUsingAppDomainFriendlyName());

            // add assemblies as needed
            busConfig.AssembliesToScan(AllAssemblies.Matching("NServiceBus")
                .And("Bec.TargetFramework.SB.Messages")
                .And("Bec.TargetFramework.SB.Hosts.SBService"));

            NServiceBus.Bus.Create(busConfig).Start();

            m_LifetimeScope = IocProvider.GetIocContainerUsingAppDomainFriendlyName().BeginLifetimeScope();
        }

        public void StartService(string[] args)
        {
            eventLog.WriteEntry("Starting Service");

            try
            {
                InitialiseIOC();

                m_BaseAddress = ConfigurationManager.AppSettings["SBServiceBaseURL"];

                m_Server = WebApp.Start<Startup>(url: m_BaseAddress);
            }
            catch (Exception ex)
            {
                if (m_LifetimeScope != null)
                {
                    var logger = m_LifetimeScope.Resolve<ILogger>();

                    logger.Error(ex, ex.Message);
                }
                else
                    Serilog.Log.Logger.Error(ex, ex.Message, null);

                OnStop();
            }
        }

        protected override void OnStop()
        {
            eventLog.WriteEntry("Stopping Service");

            StopServices();

            base.OnStop();
        }

        protected override void OnShutdown()
        {
            eventLog.WriteEntry("Shutting Down Service");

            StopServices();

            base.OnShutdown();
        }

        private void StopServices()
        {
            if (m_Server != null)
                m_Server.Dispose();

            if (m_LifetimeScope != null)
                m_LifetimeScope.Dispose();
        }

    }
}
