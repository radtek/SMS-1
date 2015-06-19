using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Serilog;
using Bec.TargetFramework.SB.Messages.Events;
using NServiceBus.Config;
using NServiceBus.Features;
using NServiceBus.Pipeline;
using NServiceBus.Pipeline.Contexts;
using NServiceBus.Serilog.Tracing;

namespace Bec.TargetFramework.SB.Hosts.SBService
{
    using System.Configuration;
    using Autofac;
    using Autofac.Integration.WebApi;



    using NServiceBus;
    using NServiceBus.Installation.Environments;
    using Bec.TargetFramework.Infrastructure.Log;
    using Bec.TargetFramework.Infrastructure;
    using Microsoft.Owin.Hosting;
    using Bec.TargetFramework.SB.Infrastructure;
    using NServiceBus.Serilog;
    using NServiceBus.Logging;
    using Bec.TargetFramework.Infrastructure.Settings;
    using Bec.TargetFramework.Infrastructure.IOC;



    partial class SBService : ServiceBase
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
