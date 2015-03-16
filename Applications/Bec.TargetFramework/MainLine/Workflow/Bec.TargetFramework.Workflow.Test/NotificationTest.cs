using System.Collections.Concurrent;
using Autofac;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.SB.Infrastructure;
using Bec.TargetFramework.Workflow.Test.FirstDataTransactionService;
using Bec.TargetFramework.Workflow.Test.Objects;
using BEC.TargetFramework.Workflow.Test.IOC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using NServiceBus.Serilog.Tracing;
using Omu.ValueInjecter;
using Bec.TargetFramework.Entities.Injections;
using Bec.TargetFramework.Entities.Enums;
using NServiceBus.Installation.Environments;

namespace Bec.TargetFramework.Workflow.Test
{
    using System.Text.RegularExpressions;
    using System.Web.Script.Serialization;

    using Bec.TargetFramework.Framework.Configuration;
    
    using Bec.TargetFramework.SB.Messages.Commands;
    using Bec.TargetFramework.SB.NotificationServices.Report;



    using NServiceBus;

    using ServiceStack.Text;
    using Bec.TargetFramework.Entities;
    using Bec.TargetFramework.SB.Interfaces;
    using Bec.TargetFramework.Entities.DTO.Notification;

    public class NotificationTest
    {
        private IContainer m_IocContainer;
        private INotificationLogic m_NotificationLogic;

        private static IBus m_Bus;
        private IStartableBus m_StartableBus;


        public NotificationTest()
        {
            // wait for all services to load
            
            
            ContainerBuilder builder = new ContainerBuilder();

            var registrar = new DependencyRegistrar();

            registrar.Register(builder, null);

            m_IocContainer = builder.Build();

            m_NotificationLogic = m_IocContainer.Resolve<INotificationLogic>();

            INotificationDataService services = m_IocContainer.Resolve<INotificationDataService>();

            //var data1 = services.GetNotificationData(Guid.Parse("36149692-3e90-11e4-9c84-d7289f4b389c"));

            TracingLog.Disable();

            

            var startableBus = NServiceBusHelper.CreateDefaultStartableBusUsingaAutofacBuilder(m_IocContainer).PurgeOnStartup(true).CreateBus();

            SB.Infrastructure.HookMessageMutators.InitialiseMessageMutators();

            //Configure.Instance.ForInstallationOn<NServiceBus.Installation.Environments.Windows>().Install();

            m_Bus = startableBus.Start();

            System.Threading.Thread.Sleep(30000);

              ConcurrentDictionary<string, object> data = new ConcurrentDictionary<string, object>();

            data.TryAdd("UserNextSteps",new UserNextStepsNotificationDTO{IDCheckProductPrice=5.0M});

           // var commonSettings = m_IocContainer.Resolve<CommonSettings>();

           // var list = new List<NotificationRecipientDTO>();
//
           // list.Add(new NotificationRecipientDTO{UserID = Guid.Parse("0771737a-10e9-11e4-bbb6-cbe20b0b57f0")});

            //var container = new NotificationContainerDTO(
            //    commonSettings,
            //    Guid.Parse("36149692-3e90-11e4-9c84-d7289f4b389c"),
            //    1,
            //    list,
            //    new NotificationDictionaryDTO{NotificationDictionary = data});

            byte[] reportData = services.GenericNotificationtOutputFromNotificationConstruct(
                Guid.Parse("1c03a4b2-4266-11e4-a5a5-ffb43cafcbd0"), 1,
                new NotificationDictionaryDTO {NotificationDictionary = data},NotificationExportFormatIDEnum.HTML5);

          File.WriteAllBytes("c:\\temp\\file.html",reportData);

            //var message = new SendNotificationCommand {NotificationContainer = container};

            //m_Bus.SetMessageHeader(message, "Source", "NotificationTest");
            //m_Bus.SetMessageHeader(message, "MessageType", message.GetType().FullName);
            //m_Bus.SetMessageHeader(message, "ServiceType", "Notification");

            //m_Bus.Send(message);
        }

    }

}
