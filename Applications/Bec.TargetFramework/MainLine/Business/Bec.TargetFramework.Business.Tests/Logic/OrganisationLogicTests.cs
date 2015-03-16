using Autofac;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Business.Services;
using Bec.TargetFramework.Infrastructure.Serilog;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using Autofac.Integration.Wcf;
using Bec.TargetFramework.Entities;

namespace Bec.TargetFramework.Business.Tests.Logic
{
    [TestClass]
    public class OrganisationLogicTests
    {
        public static IContainer m_IocContainer;
        public static ServiceHost m_OrganisationLogicService;

        [ClassInitialize()]
        public static void SetupTestClass(TestContext context)
        {
            try
            {
                InitialiseIOC();
                System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                var serviceModel = ServiceModelSectionGroup.GetSectionGroup(config);

                m_OrganisationLogicService = new ServiceHost(typeof(OrganisationLogicService));
                m_OrganisationLogicService.AddDependencyInjectionBehavior(typeof(IOrganisationLogic), m_IocContainer);
                m_OrganisationLogicService.Open();
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
            ContainerBuilder builder = new ContainerBuilder();

            var registrar = new Bec.TargetFramework.Hosts.BusinessService.IOC.DependencyRegistrar();

            registrar.Register(builder, null);

            m_IocContainer = builder.Build();
        }

        [TestMethod()]
        public void Organisation_Basic()
        {
            var serviceInstance = m_IocContainer.Resolve<IOrganisationLogic>();

            //var dto = new OrganisationDTO();
            //dto.Detail = new OrganisationDetailDTO();
            //dto.Detail.Name = "testname";
            //dto.Detail.OrganisationTypeID = 1006;
            //serviceInstance.AddNewOrganisationFromWizard(dto);

            //var exists = serviceInstance.DoesOrganisationNameExist("testname");
            //Assert.IsTrue(exists);
        }
    }
}
