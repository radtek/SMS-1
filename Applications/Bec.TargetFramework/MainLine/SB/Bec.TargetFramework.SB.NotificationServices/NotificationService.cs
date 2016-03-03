using Bec.TargetFramework.Infrastructure.IOC;
using NServiceBus;
using System.ServiceProcess;

namespace Bec.TargetFramework.SB.NotificationServices
{
    partial class NotificationService : ServiceBase
    {
        public static Autofac.IContainer m_IocContainer { get; set; }

        public NotificationService()
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
        }

        public void StartService(string[] args)
        {
            eventLog.WriteEntry("Starting Service");

            InitialiseIOC();
        }

        protected override void OnStop()
        {
            eventLog.WriteEntry("Stopping Service");
            base.OnStop();
        }

        protected override void OnShutdown()
        {
            eventLog.WriteEntry("Shutting Down Service");
            base.OnShutdown();
        }

    }
}
