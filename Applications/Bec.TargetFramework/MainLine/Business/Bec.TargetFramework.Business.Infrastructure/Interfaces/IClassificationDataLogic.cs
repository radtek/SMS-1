using Bec.TargetFramework.Data;

namespace Bec.TargetFramework.Business.Infrastructure.Interfaces
{
    using Bec.TargetFramework.Entities;
    using System.Collections.Generic;
    using System.ServiceModel;

    //Bec.TargetFramework.Entities

    [ServiceContract(Namespace = Bec.TargetFramework.Business.Infrastructure.BecTargetFrameworkBusinessServiceNamespaces.BusinessNamespace + "/ClassificationDataLogic")]
    public interface IClassificationDataLogic : IBusinessLogicService
    {
        [OperationContract]

        /// <summary>
        /// Returns root category values
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        List<ClassificationTypeDTO> GetRootClassificationDataForTypeName(string typeName);
         [OperationContract]
        
        /// <summary>
        /// Returns sub category values
        /// </summary>
        /// <param name="classificationTypeID"></param>
        /// <returns></returns>
        List<ClassificationTypeDTO> GetSubClassificationDataForParentID(int classificationTypeID);

        [OperationContract]
         int GetClassificationDataForTypeName(string categoryName, string typeName);
        [OperationContract]
        List<CountryCodeDTO> GetCountries();
    }
}