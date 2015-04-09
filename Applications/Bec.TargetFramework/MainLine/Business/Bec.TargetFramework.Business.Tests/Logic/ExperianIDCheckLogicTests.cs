using System;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using Autofac;
using Autofac.Integration.Wcf;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Business.Services;
using Bec.TargetFramework.Entities.Experian;
using Bec.TargetFramework.Infrastructure.Serilog;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bec.TargetFramework.Infrastructure.IOC;
using Bec.TargetFramework.Infrastructure;

namespace Bec.TargetFramework.Business.Tests.Logic
{
    [TestClass]
    public class ExperianIDCheckLogicTests
    {
        public static IContainer m_IocContainer;
        public static ServiceHost m_ExperianIDLogicService;

        [ClassInitialize()]
        public static void SetupTestClass(TestContext context)
        {
            try
            {
                InitialiseIOC();
                System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                var serviceModel = ServiceModelSectionGroup.GetSectionGroup(config);

                m_ExperianIDLogicService = new ServiceHost(typeof(ExperianIDCheckLogicService));
                m_ExperianIDLogicService.AddDependencyInjectionBehavior(typeof(IExperianIDCheckLogic), m_IocContainer);
                m_ExperianIDLogicService.Open();
            }
            catch (Exception ex)
            {
                if (Serilog.Log.Logger == null)
                    new SerilogLogger(true, false, "BusinessService").Error(ex);
                else
                    Serilog.Log.Logger.Error(ex, ex.Message, null);
            }
        }

        private static void InitialiseIOC()
        {
            IOCExtensions.BuildAndRegisterIocContainer<Bec.TargetFramework.Hosts.BusinessService.IOC.DependencyRegistrar>();

            m_IocContainer = IocContainerBase.GetIocContainer(AppDomain.CurrentDomain.FriendlyName);
        }

        [TestMethod()]
        public void Experian_PerformExperianProveIDQuery()
        {
            var serviceInstance = m_IocContainer.Resolve<IExperianIDCheckLogic>();

            try
            {
                serviceInstance.PerformExperianProveIDQuery(new Search());
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Experian ProveID Error"));
            }
        }
    }
}
