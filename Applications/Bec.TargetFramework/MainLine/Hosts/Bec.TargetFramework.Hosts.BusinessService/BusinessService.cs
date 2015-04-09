﻿using Autofac;
using Bec.TargetFramework.Business.Services;
using Bec.TargetFramework.Entities.DTO.Event;
using Bec.TargetFramework.Infrastructure.Serilog;
using Bec.TargetFramework.SB.Infrastructure;
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
using Enyim.Caching;
using Microsoft.Owin.Hosting;
using NServiceBus;
using NServiceBus.Installation.Environments;
using NServiceBus.Serilog;

namespace Bec.TargetFramework.Hosts.BusinessService
{
    using Bec.TargetFramework.Infrastructure;
    using Bec.TargetFramework.SB.Messages.Commands;

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
            //ContainerBuilder builder = new ContainerBuilder();

            //var registrar = new Bec.TargetFramework.Hosts.BusinessService.IOC.DependencyRegistrar();

            //registrar.Register(builder, null);

            //m_IocContainer = builder.Build();

            //IocContainerBase.AddIocContiner(m_IocContainer,AppDomain.CurrentDomain.FriendlyName);
        }

        private static IEnumerable<Assembly> GetAssembliesToScan()
        {
            return new[]
             {
                 Assembly.LoadFrom("NServiceBus.Testing.dll"),
                 Assembly.LoadFrom("NServiceBus.Core.dll"),
                 Assembly.LoadFrom("NServiceBus.ObjectBuilder.Autofac.dll"),
                  Assembly.LoadFrom("NServiceBus.Transports.RabbitMQ.dll"),
                 Assembly.LoadFrom("NServiceBus.PostgreSQL.dll")
             };
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
