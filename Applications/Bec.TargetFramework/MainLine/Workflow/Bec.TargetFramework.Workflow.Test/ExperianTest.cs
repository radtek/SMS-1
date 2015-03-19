using Autofac;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Workflow.Components.Actions;
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

    using EnvDTE;


    using NServiceBus;

    using ServiceStack.Text;
    using Bec.TargetFramework.Entities;
    using Bec.TargetFramework.SB.Interfaces;

    public class ExperianTest
    {
        private IContainer m_IocContainer;
        private INotificationLogic m_NotificationLogic;

        private static IBus m_Bus;
        private IStartableBus m_StartableBus;

        private void NServiceBusConfiguration()
        {
           

            //Configure.ScaleOut(s => s.UseSingleBrokerQueue());

            //m_StartableBus = Configure.With(AllAssemblies.Except("ServiceStack.").And("ThinkTecture.").And("Stimulsoft.").And("Newtonsoft."))
            //         .DefaultBuilder()
            //         .UseTransport<NServiceBus.SqlServer>()
            //         .UnicastBus()
            //         .RunHandlersUnderIncomingPrincipal(false)
            //         .RijndaelEncryptionService()
            //         .CreateBus();

            //Configure.Instance.ForInstallationOn<NServiceBus.Installation.Environments.Windows>().Install();

            //m_Bus = m_StartableBus.Start();
        }

        public ExperianTest()
        {
            // wait for all services to load
            System.Threading.Thread.Sleep(30000);
            
            ContainerBuilder builder = new ContainerBuilder();

            var registrar = new DependencyRegistrar();

            registrar.Register(builder, null);

            m_IocContainer = builder.Build();

            var experianLogic = m_IocContainer.Resolve<IExperianIDCheckLogic>();

            var search = new Bec.TargetFramework.Entities.Experian.Search();

            search.CountryCode = "GBR";
            search.Addresses = new Bec.TargetFramework.Entities.Experian.SearchAddresses();
            search.Addresses.Address = new Bec.TargetFramework.Entities.Experian.SearchAddressesAddress();
            search.Addresses.Address.CountryCode = "GBR";
            search.Addresses.Address.Premise = "134";
            search.Addresses.Address.Postcode = "BN271JQ";
            search.Person = new Bec.TargetFramework.Entities.Experian.SearchPerson();
            search.Person.DateOfBirth = DateTime.Parse("15/06/1980");
            search.Person.Gender = "M";
            search.Person.Name = new Bec.TargetFramework.Entities.Experian.SearchPersonName();
            search.Person.Name.Forename = "Bharat";
            search.Person.Name.Surname = "Nave";
            search.Person.Name.Title = "Mr";
            search.Orders = new Bec.TargetFramework.Entities.Experian.SearchOrders();
            search.Orders.Order = new Bec.TargetFramework.Entities.Experian.SearchOrdersOrder();
            search.Orders.Order.Payment = new Bec.TargetFramework.Entities.Experian.SearchOrdersOrderPayment();
            search.Orders.Order.Payment.Cards = new Bec.TargetFramework.Entities.Experian.SearchOrdersOrderPaymentCards();
            search.Orders.Order.Payment.Cards.Card = new Bec.TargetFramework.Entities.Experian.SearchOrdersOrderPaymentCardsCard();
            search.Orders.Order.Payment.Cards.Card.Number = "4844400123456265";
            search.Orders.Order.Payment.Cards.Card.ExpiresEnd = 1215;

            // set datablock requirement
            search.SearchOptions = new Bec.TargetFramework.Entities.Experian.SearchSearchOptions();
            search.SearchOptions.Datablocks = new Bec.TargetFramework.Entities.Experian.SearchSearchOptionsDatablocks();
            //search.SearchOptions.Datablocks.DatablockCode = "CardHolder";
            //search.SearchOptions.Datablocks.DatablockCode = "CardHolderX";
      

            var result = experianLogic.PerformExperianProveIDQuery(search);
        }

    }

    

}
