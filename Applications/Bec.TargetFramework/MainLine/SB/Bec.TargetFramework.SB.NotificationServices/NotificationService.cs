using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Serilog;
using Bec.TargetFramework.SB.Infrastructure;
using NServiceBus.Serilog.Tracing;
using Task = System.Threading.Tasks.Task;

namespace Bec.TargetFramework.SB.NotificationServices
{
    using System.Configuration;
    using System.ServiceModel;
    using System.ServiceModel.Configuration;
    using System.Web.Http;
    using System.Web.Http.SelfHost;
    using System.Web.Mvc;

    using Autofac;
    using Autofac.Integration.Wcf;

    using Bec.TargetFramework.SB.NotificationServices.IOC;

    using NServiceBus;
    using NServiceBus.Installation.Environments;
    using Bec.TargetFramework.SB.NotificationServices.Service;
    using Bec.TargetFramework.SB.Interfaces;
    using Bec.TargetFramework.Business.Infrastructure.Interfaces;
    using Bec.TargetFramework.Infrastructure.Log;
    using Bec.TargetFramework.Infrastructure;



    partial class NotificationService : ServiceBase
    {
        private List<ServiceHost> m_ServiceHosts { get; set; }

        private HttpSelfHostServer m_SelfServer;

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
            ContainerBuilder builder = new ContainerBuilder();

            var registrar = new DependencyRegistrar();

            registrar.Register(builder, null);

            builder.Register(c => new NotificationDataService(c.Resolve<ILogger>(),c.Resolve<INotificationLogic>())).As<INotificationDataService>();

            m_IocContainer = builder.Build();

            var nLogic = m_IocContainer.Resolve<INotificationLogic>();

//            Task.Factory.StartNew(() =>
//            {
//                TracingLog.Disable();
//NServiceBusHelper.CreateDefaultStartableBusUsingaAutofacBuilder(m_IocContainer).PurgeOnStartup(true).CreateBus()
//                var startableBus = ;

//                Configure.Instance.ForInstallationOn<Windows>().Install();

//                SB.Infrastructure.HookMessageMutators.InitialiseMessageMutators();

//                m_Bus = startableBus.Start();
//            });
        }

        public void StartService(string[] args)
        {
            eventLog.WriteEntry("Starting Service");

            m_ServiceHosts = new List<ServiceHost>();
        
            try
            {
                InitialiseIOC();

                ServiceHost host = new ServiceHost(typeof(NotificationDataService));
                host.AddDependencyInjectionBehavior(typeof(INotificationDataService), m_IocContainer);
                host.Open();

                m_ServiceHosts.Add(host);
            }
            catch (Exception ex)
            {
                if (Serilog.Log.Logger == null)
                    new SerilogLogger(true, false, "NotificationService").Error(ex);
                else
                    Serilog.Log.Logger.Error(ex, ex.Message, null);
                OnStop();
            }
        }

        protected override void OnStop()
        {
            eventLog.WriteEntry("Stopping Service");

            if(m_ServiceHosts != null)
            {
                m_ServiceHosts.ForEach(item =>
                    item.Close());
            }

            if (m_SelfServer != null) m_SelfServer.CloseAsync().Wait();

            base.OnStop();
        }

        protected override void OnShutdown()
        {
            eventLog.WriteEntry("Shutting Down Service");

            if (m_ServiceHosts != null)
            {
                m_ServiceHosts.ForEach(item =>
                    item.Close());
            }

            if (m_SelfServer != null) m_SelfServer.CloseAsync().Wait();

            base.OnShutdown();
        }
    }
}
