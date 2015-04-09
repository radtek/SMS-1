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
    using Bec.TargetFramework.Business.Infrastructure.Interfaces;
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
            IOCExtensions.BuildAndRegisterIocContainer<IOC.DependencyRegistrar>();

            // create default configuration
            m_Bus = NServiceBus.Bus.Create(
                NServiceBusHelper.CreateDefaultStartableBusUsingaAutofacBuilder(IocContainerBase.GetIocContainer(AppDomain.CurrentDomain.FriendlyName), true)
                ).Start();
        }

        public void StartService(string[] args)
        {
            eventLog.WriteEntry("Starting Service");

            try
            {
                InitialiseIOC();

                Thread.Sleep(10000);

                using (var proxy = m_IocContainer.Resolve<IEventPublishClient>())
                {
                    var tempAccountDto = new TemporaryAccountDTO
                    {
                        EmailAddress = "c.misson@beconsultancy.co.uk",
                        UserName = "test",
                        Password = "test",
                        AccountExpiry = DateTime.Now.AddDays(5),
                        UserAccountOrganisationID = Guid.Parse("3ac48762-d867-11e4-a114-00155d0a1426")
                    };

                    var orgWithAdmin = new VOrganisationWithStatusAndAdminDTO
                    {
                        Name = "Test Ltd",
                        OrganisationAdminFirstName = "Chris",
                        OrganisationAdminLastName = "Misson",
                        OrganisationAdminSalutation = "Mr"
                    };
                    var dictionary = new ConcurrentDictionary<string, object>();

                    dictionary.TryAdd("TemporaryAccountDTO", tempAccountDto);
                    dictionary.TryAdd("VOrganisationWithStatusAndAdminDTO", orgWithAdmin);

                    string payLoad = JsonHelper.SerializeData(new object[] { tempAccountDto, orgWithAdmin });

                    var dto = new EventPayloadDTO
                    {
                        EventName =  "TestEvent",
                        EventSource = AppDomain.CurrentDomain.FriendlyName,
                        EventReference = "1212",
                        PayloadAsJson = payLoad
                    };

                    proxy.PublishEvent(dto);
                }

                
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
