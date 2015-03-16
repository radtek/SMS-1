using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Data.Repositories;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Security;

using Omu.ValueInjecter;
using Bec.TargetFramework.Entities.Injections;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using System.IO;
using System.Reflection;
using Bec.TargetFramework.Business.Logic.Helper;

namespace Bec.TargetFramework.Business.Logic
{
    using Bec.TargetFramework.Aop.Aspects;
    using System.Net;
    using EnsureThat;
using Bec.TargetFramework.Framework.Configuration;
   
    [Trace(TraceExceptionsOnly = true)]
    public class DataLogic : LogicBase, IDataLogic
    {
        private const string ResourcePathPrefix = "Bec.TargetFramework.Business.Resources.Resources.";
        protected Random RandGen = new Random();
        private const string MaleFile = "dist.male.first.stripped";
        private const string FemaleFile = "dist.female.first.stripped";
        private const string LastNameFile = "dist.all.last.stripped";
        private static string[] _maleFirstNames;
        private static string[] _femaleFirstNames;
        private static string[] _lastNames;
        public string _strSearch;
        public string _strSearchUrl;
        private CommonSettings m_CommonSettings;

        public DataLogic(ILogger logger, ICacheProvider cacheProvider, CommonSettings settings)
            : base(logger, cacheProvider)
    {
        m_CommonSettings = settings;
    }

        #region TFEvent

        public TFEventDTO GetTFEventByName(string eventName)
        {
            Ensure.That(eventName);

            TFEventDTO dto = null;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var fieldQuery =
                    scope.DbContext.TFEvents.SingleOrDefault(s => s.TFEventName.Equals(eventName));

                Ensure.That(fieldQuery);

                dto = TFEventConverter.ToDto(fieldQuery);
            }

            return dto;
        }

        #endregion

        #region Tree 

        [EnsureArgumentAspect]
        public List<VWorkflowTreeDTO> GetWorkflowTree(Guid workflowID,int workflowVersionNumber)
        {
            List<VWorkflowTreeDTO> tree = new List<VWorkflowTreeDTO>();

            using (
                var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                tree =VWorkflowTreeConverter.ToDtos(scope.DbContext.VWorkflowTrees.Where(s => s.WorkflowID.Equals(workflowID) && s.WorkflowVersionNumber.Equals(workflowVersionNumber)).OrderBy(s => s.ItemOrder));
            }

            return tree;
        }

        #endregion

        #region StatusEnum

        public List<VStatusTypeDTO> GetStatusType(string statusTypeEnum)
        {
            List<VStatusTypeDTO> statustypes = null;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var statusTypeQuery = scope.DbContext.VStatusTypes.Where(s => s.StatusTypeName.Equals(statusTypeEnum)).OrderBy(s=>s.StatusOrder) ;

                statustypes = VStatusTypeConverter.ToDtos(statusTypeQuery);//StatusTypeConverter.ToDtos(statusTypeQuery);

                Ensure.That(statustypes);
            }
            return statustypes;
        }
        #endregion

        #region Field Detail

        public
             VFieldDetailForUIDTO GetFieldDetail(string interfacePanelName, string fieldDetailName,int? organisationType = null,Guid? userType = null)
        {
            Ensure.That(fieldDetailName);

            VFieldDetailForUIDTO field = null;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var fieldQuery =
                    scope.DbContext.VFieldDetailForUIs.Where(s => s.IsActive.Equals(true) && s.IsDeleted.Equals(false));

                if (organisationType == null)
                    fieldQuery = fieldQuery.Where(s => !s.OrganisationTypeID.HasValue);
                else
                    fieldQuery = fieldQuery.Where(s => s.OrganisationTypeID.HasValue && s.OrganisationTypeID.Value.Equals(organisationType.Value));

                if (userType == null)
                    fieldQuery = fieldQuery.Where(s => !s.UserTypeID.HasValue);
                else
                    fieldQuery = fieldQuery.Where(s => s.UserTypeID.HasValue && s.UserTypeID.Value.Equals(userType.Value));


                var fields = fieldQuery.Where(s => s.InterfacePanelName.Equals(interfacePanelName)
                                                               && s.Name.Equals(fieldDetailName)).ToList();

                Ensure.That(fields.Count).IsNot(0);

                field = VFieldDetailForUIConverter.ToDto(fields.First());
            }

            return field;
        }

        public List<VFieldDetailForUIDTO> GetAllFieldDetails()
        {
            List<VFieldDetailForUIDTO> fields = null;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var fieldQuery =
                    scope.DbContext.VFieldDetailForUIs.Where(s => s.IsActive.Equals(true) && s.IsDeleted.Equals(false));


                fields = VFieldDetailForUIConverter.ToDtos(fieldQuery);

                Ensure.That(fields);
            }

            return fields;
        }

        #endregion

        #region InterfacePanel Details

        public VInterfacePanelForUIDTO GetInterfacePanelDetails(string interfacePanelName, int? organisationType = null, Guid? userType = null)
        {
            Ensure.That(interfacePanelName);

            VInterfacePanelForUIDTO ipdetail = null;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var ipQuery =
                    scope.DbContext.VInterfacePanelForUIs.Where(s => s.IsActive.Equals(true) && s.IsDeleted.Equals(false));

                if (organisationType == null)
                    ipQuery = ipQuery.Where(s => !s.OrganisationTypeID.HasValue);
                else
                    ipQuery = ipQuery.Where(s => s.OrganisationTypeID.HasValue && s.OrganisationTypeID.Value.Equals(organisationType.Value));

                if (userType == null)
                    ipQuery = ipQuery.Where(s => !s.UserTypeID.HasValue);
                else
                    ipQuery = ipQuery.Where(s => s.UserTypeID.HasValue && s.UserTypeID.Value.Equals(userType.Value));


                var ipdetails = ipQuery.Where(x => x.Name.Equals(interfacePanelName)).ToList();

                Ensure.That(ipdetails.Count).IsNot(0);


                ipdetail = VInterfacePanelForUIConverter.ToDto(ipdetails.First());
            }

            return ipdetail;
        }

        public List<VInterfacePanelForUIDTO> GetAllInterfacePanels()
        {
            List<VInterfacePanelForUIDTO> interfacePanels = null;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var interfacePanelQuery =
                    scope.DbContext.VInterfacePanelForUIs.Where(s => s.IsActive.Equals(true) && s.IsDeleted.Equals(false));


                interfacePanels = VInterfacePanelForUIConverter.ToDtos(interfacePanelQuery);

                Ensure.That(interfacePanels);
            }

            return interfacePanels;
        }
        #endregion

        #region Panel Validations

        public VInterfacePanelValidationForUIDTO GetInterfacePanelValidationMessage(string interfacePanelName, string validationName, int? organisationType = null, Guid? userType = null)
        {
            Ensure.That(validationName);

            VInterfacePanelValidationForUIDTO ipValidation = null;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var ipValidationQuery =
                    scope.DbContext.VInterfacePanelValidationForUIs.Where(s => s.IsActive.HasValue && s.IsDeleted.HasValue && s.IsActive.Value.Equals(true) && s.IsDeleted.Value.Equals(false));

                if (organisationType == null)
                    ipValidationQuery = ipValidationQuery.Where(s => !s.OrganisationTypeID.HasValue);
                else
                    ipValidationQuery = ipValidationQuery.Where(s => s.OrganisationTypeID.HasValue && s.OrganisationTypeID.Value.Equals(organisationType.Value));

                if (userType == null)
                    ipValidationQuery = ipValidationQuery.Where(s => !s.UserTypeID.HasValue);
                else
                    ipValidationQuery = ipValidationQuery.Where(s => s.UserTypeID.HasValue && s.UserTypeID.Value.Equals(userType.Value));


                var validation = ipValidationQuery.Where(x => x.Name.Equals(interfacePanelName) && x.ValidationName.Equals(validationName)).ToList();

                Ensure.That(validation.Count).IsNot(0);	

                ipValidation = VInterfacePanelValidationForUIConverter.ToDto(validation.First());
            }

            return ipValidation;
        }

        public List<VInterfacePanelValidationForUIDTO> GetAllInterfacePanelValidationMessages()
        {

            List<VInterfacePanelValidationForUIDTO> ipValidations = null;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var ipValidationQuery = scope.DbContext.VInterfacePanelValidationForUIs.Where(s => s.IsActive.HasValue && s.IsDeleted.HasValue && s.IsActive.Value.Equals(true) && s.IsDeleted.Value.Equals(false)); ;

                ipValidations = VInterfacePanelValidationForUIConverter.ToDtos(ipValidationQuery);

                Ensure.That(ipValidations);
            }
            return ipValidations;
           
        }
        #endregion

        #region Field Detail Validations

        public VFieldDetailValidationForUIDTO GetFieldDetailValidationMessage(string fieldDetailName, string validationName, int? organisationType = null, Guid? userType = null)
        {
            Ensure.That(validationName);

            VFieldDetailValidationForUIDTO fdValidation = null;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var fdValidationQuery =
                    scope.DbContext.VFieldDetailValidationForUIs.Where(s => s.IsActive.HasValue && s.IsDeleted.HasValue && s.IsActive.Value.Equals(true) && s.IsDeleted.Value.Equals(false));

                if (organisationType == null)
                    fdValidationQuery = fdValidationQuery.Where(s => !s.OrganisationTypeID.HasValue);
                else
                    fdValidationQuery = fdValidationQuery.Where(s => s.OrganisationTypeID.HasValue && s.OrganisationTypeID.Value.Equals(organisationType.Value));

                if (userType == null)
                    fdValidationQuery = fdValidationQuery.Where(s => !s.UserTypeID.HasValue);
                else
                    fdValidationQuery = fdValidationQuery.Where(s => s.UserTypeID.HasValue && s.UserTypeID.Value.Equals(userType.Value));


                var validation = fdValidationQuery.Where(x => x.Name.Equals(fieldDetailName) && x.InterfacePanelFieldDetailValidationName.Equals(validationName)).ToList();

                if(validation.Count == 0)
                    throw new ArgumentException("No validation found validation name:" + validationName + " FieldDetailName:" + fieldDetailName);


                fdValidation = VFieldDetailValidationForUIConverter.ToDto(validation.First());
            }

            return fdValidation;
        }

        public List<VFieldDetailValidationForUIDTO> GetAllFieldDetailValidationMessages()
        {

            List<VFieldDetailValidationForUIDTO> fdValidations = null;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var fdValidationQuery = scope.DbContext.VFieldDetailValidationForUIs.Where(s => s.IsActive.HasValue && s.IsDeleted.HasValue && s.IsActive.Value.Equals(true) && s.IsDeleted.Value.Equals(false)); ;

                fdValidations = VFieldDetailValidationForUIConverter.ToDtos(fdValidationQuery);

                Ensure.That(fdValidations);
            }
            return fdValidations;

        }
                
        #endregion

        #region cache validations and field details data

        public FieldDetailsAndValidationsDTO LoadUIDetails()
        {

            FieldDetailsAndValidationsDTO dto = new FieldDetailsAndValidationsDTO();

            dto.InterfacePanelValidationsForUI = GetAllInterfacePanelValidationMessages();

            dto.FieldDetailValidationsForUI = GetAllFieldDetailValidationMessages();

            dto.FieldDetailsForUI = GetAllFieldDetails();

            dto.InterfacePanelForUI = GetAllInterfacePanels();

            return dto;

        }

        #endregion

        #region BaseNameGenerator
        private static Stream ReadResourceStreamForFileName(string resourceFileName)
        {
            return
                Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream(ResourcePathPrefix + resourceFileName);
        }

        protected static string[] ReadResourceByLine(string resourceFileName)
        {
            var stream = ReadResourceStreamForFileName(resourceFileName);

            var list = new List<string>();

            var streamReader = new StreamReader(stream);
            string str;

            while ((str = streamReader.ReadLine()) != null)
            {
                if (str != string.Empty)
                    list.Add(str);
            }

            return list.ToArray();
        }
        #endregion

        #region PersonNameGenerator
        private bool RandomlyPickIfNameIsMale
        {
            get { return RandGen.Next(0, 2) == 0; }
        }

        public string GenerateRandomFirstAndLastName()
        {
            return GenerateRandomFirstName() + ' ' + GenerateRandomLastName();
        }

        public string GenerateRandomName()
        {
            //Prefix with Temp so that user doesn't get confused when a random name is generated
            return "Temp" + GenerateRandomFirstName() + GenerateRandomLastName();
        }
        public string GenerateRandomLastName()
        {
            if (_lastNames == null)
                _lastNames = ReadResourceByLine(LastNameFile);
            var index = RandGen.Next(0, _lastNames.Length);

            return _lastNames[index];
        }

        public string GenerateRandomFirstName()
        {
            return !RandomlyPickIfNameIsMale
                ? GenerateRandomFemaleFirstName()
                : GenerateRandomMaleFirstName();
        }

        public string GenerateRandomFemaleFirstName()
        {
            if (_femaleFirstNames == null)
                _femaleFirstNames = ReadResourceByLine(FemaleFile);
            var index = RandGen.Next(0, _femaleFirstNames.Length);

            return _femaleFirstNames[index];
        }

        public string GenerateRandomMaleFirstName()
        {
            if (_maleFirstNames == null)
                _maleFirstNames = ReadResourceByLine(MaleFile);
            var index = RandGen.Next(0, _maleFirstNames.Length);

            return _maleFirstNames[index];
        }

        public IEnumerable<string> GenerateMultipleFirstAndLastNames(int count)
        {
            var list = new List<string>();

            for (var index = 0; index < count; ++index)
                list.Add(GenerateRandomFirstAndLastName());

            return list;
        }

        public IEnumerable<string> GenerateMultipleLastNames(int count)
        {
            var list = new List<string>();

            for (var index = 0; index < count; ++index)
                list.Add(GenerateRandomLastName());

            return list;
        }

        public IEnumerable<string> GenerateMultipleFemaleFirstAndLastNames(int count)
        {
            var list = new List<string>();

            for (var index = 0; index < count; ++index)
                list.Add(GenerateRandomFemaleFirstAndLastName());

            return list;
        }

        public IEnumerable<string> GenerateMultipleMaleFirstAndLastNames(int count)
        {
            var list = new List<string>();

            for (var index = 0; index < count; ++index)
                list.Add(GenerateRandomMaleFirstAndLastName());

            return list;
        }

        public IEnumerable<string> GenerateMultipleFemaleFirstNames(int count)
        {
            var list = new List<string>();

            for (var index = 0; index < count; ++index)
                list.Add(GenerateRandomFemaleFirstName());

            return list;
        }

        public IEnumerable<string> GenerateMultipleMaleFirstNames(int count)
        {
            var list = new List<string>();

            for (var index = 0; index < count; ++index)
                list.Add(GenerateRandomMaleFirstName());

            return list;
        }

        public string GenerateRandomFemaleFirstAndLastName()
        {
            return GenerateRandomFemaleFirstName() + GenerateRandomLastName();
        }

        public string GenerateRandomMaleFirstAndLastName()
        {
            return GenerateRandomMaleFirstName() + GenerateRandomLastName();
        }
        #endregion

        #region ServiceDefinition

        [EnsureArgumentAspect]
        public ServiceDefinitionDTO GetServiceDefinitionWithDetail(string name)
        {
            Ensure.That(m_CommonSettings.Environment).IsNotNullOrEmpty();

            ServiceDefinitionDTO dto = null;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger)
                )
            {
                var sd = ServiceDefinitionConverter.ToDto(scope.DbContext.ServiceDefinitions.Single(s => s.Name.Equals(name)));

                var sdd =
                    ServiceDefinitionDetailConverter.ToDto(
                        scope.DbContext.ServiceDefinitionDetails.Single(
                            s => s.ServiceDefinitionID.Equals(sd.ServiceDefinitionID) && s.EnvironmentName.Equals(m_CommonSettings.Environment) && s.IsActive == true && s.IsDeleted == false));

                sd.ServiceDefinitionDetails = new List<ServiceDefinitionDetailDTO>();
                sd.ServiceDefinitionDetails.Add(sdd);
            }

            return dto;
        }

        [EnsureArgumentAspect]
        public void MarkServiceInterfaceAsPending(Guid serviceDefinitionID, Guid? productPurchaseProductTaskID, Guid? parentID,string data)
        {
            using (
               var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,
                   true))
            {
                ServiceInterfaceHelper.CreateServiceInterfaceProcessLog(scope, serviceDefinitionID,
                    productPurchaseProductTaskID, parentID, data,null,ServiceInterfaceStatusEnum.Pending);

                scope.Save();
            }
        }
        [EnsureArgumentAspect]
        public void MarkServiceInterfaceAsProcessing(Guid serviceDefinitionID, Guid? productPurchaseProductTaskID, Guid? parentID, string data)
        {
            using (
               var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,
                   true))
            {
                ServiceInterfaceHelper.CreateServiceInterfaceProcessLog(scope, serviceDefinitionID,
                    productPurchaseProductTaskID, parentID, data, null, ServiceInterfaceStatusEnum.Processing);

                scope.Save();
            }
        }
        [EnsureArgumentAspect]
        public void MarkServiceInterfaceAsFailed(Guid serviceDefinitionID, Guid? productPurchaseProductTaskID, Guid? parentID, string data)
        {
            using (
               var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,
                   true))
            {
                ServiceInterfaceHelper.CreateServiceInterfaceProcessLog(scope, serviceDefinitionID,
                    productPurchaseProductTaskID, parentID, data, null, ServiceInterfaceStatusEnum.Failed);

                scope.Save();
            }
        }
        [EnsureArgumentAspect]
        public void MarkServiceInterfaceAsSuccessful(Guid serviceDefinitionID, Guid? productPurchaseProductTaskID, Guid? parentID, string data)
        {
            using (
               var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,
                   true))
            {
                ServiceInterfaceHelper.CreateServiceInterfaceProcessLog(scope, serviceDefinitionID,
                    productPurchaseProductTaskID, parentID, data, null, ServiceInterfaceStatusEnum.Successful);

                scope.Save();
            }
        }
       

        #endregion
    }

       


}
