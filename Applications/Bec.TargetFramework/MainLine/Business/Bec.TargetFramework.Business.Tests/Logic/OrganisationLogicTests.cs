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
using Bec.TargetFramework.Entities.Enums;

namespace Bec.TargetFramework.Business.Tests.Logic
{
    [TestClass]
    public class OrganisationLogicTests
    {
        public static IContainer m_IocContainer;
        public static List<ServiceHost> m_ServiceHosts = new List<ServiceHost>();

        [ClassInitialize()]
        public static void SetupTestClass(TestContext context)
        {
            try
            {
                InitialiseIOC();
                System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                var serviceModel = ServiceModelSectionGroup.GetSectionGroup(config);

                var os = new ServiceHost(typeof(OrganisationLogicService));
                os.AddDependencyInjectionBehavior(typeof(IOrganisationLogic), m_IocContainer);
                os.Open();

                m_ServiceHosts.Add(os);

                var us = new ServiceHost(typeof(UserLogicService));
                us.AddDependencyInjectionBehavior(typeof(IUserLogic), m_IocContainer);
                us.Open();

                m_ServiceHosts.Add(us);

                var dl = new ServiceHost(typeof(DataLogicService));
                dl.AddDependencyInjectionBehavior(typeof(IDataLogic), m_IocContainer);
                dl.Open();

                m_ServiceHosts.Add(dl);
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
        public void AddOrganisationTest()
        {
            var serviceInstance = m_IocContainer.Resolve<IOrganisationLogic>();

            var boo =  serviceInstance.AddNewUnverifiedOrganisationAndAdministrator(OrganisationTypeEnum.Professional, new VOrganisationWithStatusAndAdminDTO
                {
                    OrganisationAdminTelephone = "1234",
                    PostalCode = "SE9",
                    Regulator = "Other",
                    RegulatorOther = "Test",
                    Line1 = "Add",
                    County = "Kent",
                    Line2 = "Add2",
                    CreatedOn = DateTime.Now,
                    Name = Guid.NewGuid().ToString(),
                    OrganisationAdminEmail = "c.misson@beconsultancy.co.uk",
                    OrganisationAdminLastName = "Foo",
                    OrganisationAdminFirstName = "Foo",
                    OrganisationAdminSalutation = "Mr",
                    Town = "Sidcup"
                });

            boo.Wait();

            var result = boo.Result;

            //var dto = new OrganisationDTO();
            //dto.Detail = new OrganisationDetailDTO();
            //dto.Detail.Name = "testname";
            //dto.Detail.OrganisationTypeID = 1006;
            //serviceInstance.AddNewOrganisationFromWizard(dto);

            //var exists = serviceInstance.DoesOrganisationNameExist("testname");
            //Assert.IsTrue(exists);
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
