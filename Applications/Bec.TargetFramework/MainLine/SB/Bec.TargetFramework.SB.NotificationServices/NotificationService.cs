using Bec.TargetFramework.Infrastructure.IOC;
using NServiceBus;
using System.ServiceProcess;

namespace Bec.TargetFramework.SB.NotificationServices
{
    partial class NotificationService : ServiceBase
    {
        public static Autofac.IContainer m_IocContainer { get; set; }

        private static IBus m_Bus;

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

            // create default configuration
            //m_Bus = NServiceBus.Bus.Create(
            //    NServiceBusHelper.CreateDefaultStartableBusUsingaAutofacBuilder(IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName), true)
            //    ).Start();
        }

        public void StartService(string[] args)
        {
            eventLog.WriteEntry("Starting Service");

            InitialiseIOC();
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
            if (m_Bus != null)
                m_Bus.Dispose();
        }
    }
}
