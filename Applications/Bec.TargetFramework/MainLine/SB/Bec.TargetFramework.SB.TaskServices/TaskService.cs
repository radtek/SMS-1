using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bec.TargetFramework.SB.Entities;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Serilog;
using Bec.TargetFramework.SB.Infrastructure;
using NServiceBus.Serilog;
using NServiceBus.Serilog.Tracing;
using Bec.TargetFramework.Infrastructure.IOC;
using System.Collections.Concurrent;
using Bec.TargetFramework.SB.Infrastructure.Quartz.Extensions;
using Bec.TargetFramework.SB.Infrastructure.Quartz.Jobs;
using NServiceBus.Config;
using NServiceBus.Pipeline;
using Quartz;

namespace Bec.TargetFramework.SB.TaskServices
{
    using System.Configuration;
    using System.ServiceModel;
    using System.ServiceModel.Configuration;

    using Autofac;
    using Autofac.Integration.Wcf;
    using Autofac.Integration.WebApi;



    using NServiceBus;
    using NServiceBus.Installation.Environments;
    using Bec.TargetFramework.SB.Interfaces;
    using Bec.TargetFramework.Infrastructure.Log;
    using NServiceBus.Logging;
    using NServiceBus.Features;
    using Bec.TargetFramework.SB.Messages.Events;
    using Bec.TargetFramework.Infrastructure.Helpers;
    using System.Collections.Concurrent;
    using Quartz.Impl.Matchers;



    partial class TaskService : ServiceBase
    {
        private IBus m_Bus;
        private ILifetimeScope m_LifetimeScope;

        public TaskService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            StartService(args);
        }

        private void InitialiseIOC()
        {
            IocProvider.BuildAndRegisterIocContainer<IOC.DependencyRegistrar>();

            var busConfig = NServiceBusHelper.CreateDefaultStartableBusUsingaAutofacBuilder(IocProvider.GetIocContainerUsingAppDomainFriendlyName());

            busConfig.OverrideLocalAddress("Y");

            // add assemblies as needed
            busConfig.AssembliesToScan(AllAssemblies.Matching("NServiceBus")
                .And("Bec.TargetFramework.SB.Messages")
                .And("Bec.TargetFramework.SB.TaskHandlers")
                .And("Bec.TargetFramework.SB.NotificationServices"));

            NServiceBus.Bus.Create(busConfig).Start();
            m_LifetimeScope = IocProvider.GetIocContainerUsingAppDomainFriendlyName().BeginLifetimeScope();
        }

        public void StartService(string[] args)
        {
            eventLog.WriteEntry("Starting Service");

            try
            {
                InitialiseIOC();

                #if DEBUG
                    Thread.Sleep(10000);
                #endif

                // create scheduler and start 
                SchedulerHelper.InitialiseAndStartScheduler(m_LifetimeScope);
            }
            catch (Exception ex)
            {
                if (IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName) != null)
                {
                    var logger = IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<ILogger>();

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
            // shutdown scheduler
            SchedulerHelper.ShutdownScheduler(m_LifetimeScope);

            if (m_LifetimeScope != null)
                m_LifetimeScope.Dispose();
        }
    }
}