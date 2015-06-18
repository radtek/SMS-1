using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Infrastructure.Serilog;
using Bec.TargetFramework.SB.Entities;
using Bec.TargetFramework.SB.Infrastructure;
using Task = System.Threading.Tasks.Task;
using NServiceBus.Serilog.Tracing;

namespace Bec.TargetFramework.SB.NotificationServices
{
    using System.Configuration;
    using System.ServiceModel;
    using System.ServiceModel.Configuration;
    using System.Web.Mvc;

    using Autofac;
    using Autofac.Integration.Wcf;

    using Bec.TargetFramework.SB.NotificationServices.IOC;

    using NServiceBus;
    using NServiceBus.Installation.Environments;
    using Bec.TargetFramework.SB.NotificationServices.Service;
    using Bec.TargetFramework.SB.Interfaces;

    using Bec.TargetFramework.Infrastructure.Log;
    using Bec.TargetFramework.Infrastructure;
    using NServiceBus.Serilog;
    using Bec.TargetFramework.Entities;
    using NServiceBus.Logging;
    using Bec.TargetFramework.Infrastructure.IOC;
    using Bec.TargetFramework.SB.Messages.Events;



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
