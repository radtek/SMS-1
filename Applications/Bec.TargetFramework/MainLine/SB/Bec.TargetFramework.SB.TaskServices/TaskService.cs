﻿using System;
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
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using Bec.TargetFramework.Infrastructure.IOC;
using System.Collections.Concurrent;

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
    using NServiceBus.Logging;
    using NServiceBus.Features;
    using Bec.TargetFramework.SB.Messages.Events;
    using Bec.TargetFramework.Infrastructure.Helpers;
    using System.Collections.Concurrent;



    partial class TaskService : ServiceBase
    {
        public static Autofac.IContainer m_IocContainer { get; set; }

        private static IBus m_Bus;

        private static IScheduler m_Scheduler;

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

            // create default configuration
            m_Bus = NServiceBus.Bus.Create(
                NServiceBusHelper.CreateDefaultStartableBusUsingaAutofacBuilder(IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName), true)
                ).Start();

            m_Bus.Unsubscribe<SBEvent>();
        }


        public void StartService(string[] args)
        {
            eventLog.WriteEntry("Starting Service");

            try
            {
                InitialiseIOC();

                var factry = IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<IJobFactory>();

                m_Scheduler = StdSchedulerFactory.GetDefaultScheduler();

                m_Scheduler.Start();
            }
            catch (Exception ex)
            {
                eventLog.WriteEntry(ex.Message);

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
            if (m_Bus != null)
                m_Bus.Dispose();

            if(m_Scheduler != null && !m_Scheduler.IsShutdown)
                m_Scheduler.Shutdown();
        }
    }
}