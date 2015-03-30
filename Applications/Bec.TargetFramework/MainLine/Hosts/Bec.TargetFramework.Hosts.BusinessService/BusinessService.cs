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
using Microsoft.Owin.Hosting;
using NServiceBus;
using NServiceBus.Installation.Environments;
using NServiceBus.Serilog.Tracing;

namespace Bec.TargetFramework.Hosts.BusinessService
{
    using Bec.TargetFramework.Framework.Configuration;
    using Bec.TargetFramework.Infrastructure;

    public partial class BusinessService : ServiceBase
    {
        public string m_BaseAddress { get; set; }

        private Autofac.IContainer m_IocContainer { get; set; }

        private IDisposable m_Server = null;

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

            if(m_Server != null)
                m_Server.Dispose();

            base.OnStop();
        }

        protected override void OnShutdown()
        {
            eventLog.WriteEntry("Shutting Down Service");

            base.OnShutdown();
        }

    }
}
