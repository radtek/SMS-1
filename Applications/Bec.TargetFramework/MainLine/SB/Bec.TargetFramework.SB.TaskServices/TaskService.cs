using Autofac;
using Bec.TargetFramework.Infrastructure.IOC;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.SB.Infrastructure;
using Bec.TargetFramework.SB.Infrastructure.Quartz.Extensions;
using Bec.TargetFramework.WindowsService;
using NServiceBus;
using System;
using System.ServiceProcess;
using System.Threading;

namespace Bec.TargetFramework.SB.TaskServices
{
    partial class TaskService : ServiceBase, IWindowsService
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
                if (Environment.UserInteractive) Console.WriteLine(ex.Message);
                if (IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName) != null)
                {
                    var logger = IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<ILogger>();

                    logger.Error(ex, ex.Message);
                }
                else
                    Serilog.Log.Logger.Error(ex, ex.Message, null);

                Stop();
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