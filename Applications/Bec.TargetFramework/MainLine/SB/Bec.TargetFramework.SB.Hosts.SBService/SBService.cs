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



    partial class SBService : ServiceBase
    {
        public string m_BaseAddress { get; set; }
        private Autofac.IContainer m_IocContainer { get; set; }

        public static IBus ServiceBus
        {
            get { return m_Bus; }
            set { m_Bus = value; }
        }

        private IDisposable m_Server = null;

        private static IBus m_Bus;

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
            //ContainerBuilder builder = new ContainerBuilder();

            //var registrar = new Bec.TargetFramework.SB.Hosts.SBService.IOC.DependencyRegistrar();

            //registrar.Register(builder, null);

            //m_IocContainer = builder.Build();

            //IocContainerBase.AddIocContiner(m_IocContainer, AppDomain.CurrentDomain.FriendlyName);

            //// create default configuration
            //var configuration = NServiceBusHelper.CreateDefaultStartableBusUsingaAutofacBuilder(m_IocContainer, true);

            //// start bus
            //m_Bus = NServiceBus.Bus.Create(configuration).Start();

            //Task.Factory.StartNew(
            //    () =>
            //    {
            //        Bec.TargetFramework.Aop.AspectServiceLocator.Initialize(m_IocContainer, true,
            //            m_IocContainer.Resolve<CommonSettings>().EnableTrace);
            //    });
        }

        public void StartService(string[] args)
        {
            eventLog.WriteEntry("Starting Service");

            try
            {
                InitialiseIOC();

                m_BaseAddress = ConfigurationManager.AppSettings["BusinessServiceBaseURL"];

                m_Server = WebApp.Start<Startup>(url: m_BaseAddress);
            }
            catch (Exception ex)
            {
                if (m_IocContainer != null)
                {
                    var logger = m_IocContainer.Resolve<ILogger>();

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

            if (m_Bus != null)
                m_Bus.Dispose();
        }

    }

}
