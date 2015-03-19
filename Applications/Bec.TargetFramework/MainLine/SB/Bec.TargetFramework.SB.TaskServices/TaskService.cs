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
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.DTO.Event;
using Bec.TargetFramework.Framework;
using Bec.TargetFramework.Infrastructure.Serilog;
using Bec.TargetFramework.SB.Infrastructure;
using Bec.TargetFramework.SB.Infrastructure.EventSource;
using NServiceBus.Serilog.Tracing;

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
    using Bec.TargetFramework.Business.Infrastructure.Interfaces;
    using Bec.TargetFramework.Infrastructure.Log;



    partial class TaskService : ServiceBase
    {
        private List<ServiceHost> m_ServiceHosts { get; set; }
        public static Autofac.IContainer m_IocContainer { get; set; }

        private static IBus m_Bus;

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
            var builder = new ContainerBuilder();

            var registrar = new IOC.DependencyRegistrar();

            registrar.Register(builder, null);

            m_IocContainer = builder.Build();

            //Task.Factory.StartNew(() =>
            //{
            //    TracingLog.Disable();

            //    var startableBus = NServiceBusHelper.CreateDefaultStartableBusUsingaAutofacBuilder(m_IocContainer).PurgeOnStartup(true).CreateBus();

            //    Configure.Instance.ForInstallationOn<Windows>().Install();

            //    SB.Infrastructure.HookMessageMutators.InitialiseMessageMutators();

            //    m_Bus = startableBus.Start();

            //    //EventPublisher.PublishEvent(m_IocContainer.Resolve<IDataLogic>(), "Test", "Test", "Test",
            //    //    new TransactionOrderDTO());
            //});
        }

        public void StartService(string[] args)
        {
            eventLog.WriteEntry("Starting Service");

            m_ServiceHosts = new List<ServiceHost>();
        
            try
            {
                InitialiseIOC();
            }
            catch (Exception ex)
            {
                if (Serilog.Log.Logger == null)
                    new SerilogLogger(true, false, "TaskService").Error(ex);
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

            base.OnShutdown();
        }
    }

}
