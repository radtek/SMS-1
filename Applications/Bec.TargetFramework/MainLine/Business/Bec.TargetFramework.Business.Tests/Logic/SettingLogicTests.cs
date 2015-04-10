using Autofac;
using Autofac.Integration.Wcf;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Business.Services;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.IOC;
using Bec.TargetFramework.Infrastructure.Serilog;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Configuration;

namespace Bec.TargetFramework.Business.Tests.Logic
{
    [TestClass]
    public class SettingLogicTests
    {
        public static IContainer m_IocContainer;
        public static ServiceHost m_SettingLogicService;

        [ClassInitialize()]
        public static void SetupTestClass(TestContext context)
        {
            try
            {
                InitialiseIOC();
                System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                var serviceModel = ServiceModelSectionGroup.GetSectionGroup(config);

                m_SettingLogicService = new ServiceHost(typeof(SettingLogicService));
                m_SettingLogicService.AddDependencyInjectionBehavior(typeof(ISettingLogic), m_IocContainer);
                m_SettingLogicService.Open();
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
            m_IocContainer = IocProvider.BuildAndReturnIocContainer<Bec.TargetFramework.Hosts.BusinessService.IOC.DependencyRegistrar>();
        }

        [TestMethod()]
        public void GetAllSettings()
        {
            var serviceInstance = m_IocContainer.Resolve<ISettingLogic>();

            var settings = serviceInstance.GetAllSettings();
            Assert.AreEqual(46, settings.Count);
        }

        [TestMethod()]
        public void GetSettingByName_Null()
        {
            var serviceInstance = m_IocContainer.Resolve<ISettingLogic>();

            var setting = serviceInstance.GetSettingByName("");
            Assert.IsNull(setting);
        }

        [TestMethod()]
        public void GetSettingByName_NotNull()
        {
            var serviceInstance = m_IocContainer.Resolve<ISettingLogic>();

            var setting = serviceInstance.GetSettingByName("CommonSettings.LogDebugDatabase");
            Assert.IsNotNull(setting);
        }

        [TestMethod()]
        public void GetSettingById_Null()
        {
            var serviceInstance = m_IocContainer.Resolve<ISettingLogic>();

            var setting = serviceInstance.GetSettingById(-1);
            Assert.IsNull(setting);
        }

        [TestMethod()]
        public void GetSettingById_NotNull()
        {
            var serviceInstance = m_IocContainer.Resolve<ISettingLogic>();

            var setting = serviceInstance.GetSettingById(1);
            Assert.IsNotNull(setting);
        }
    }
}
