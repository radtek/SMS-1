namespace Bec.TargetFramework.Business.Infrastructure.Interfaces
{
    using Bec.TargetFramework.Entities;
    using System.Collections.Generic;
    using System.ServiceModel;

    //Bec.TargetFramework.Entities

    [ServiceContract(Namespace = Bec.TargetFramework.Business.Infrastructure.BecTargetFrameworkBusinessServiceNamespaces.BusinessNamespace + "/SettingLogic")]
    public interface ISettingLogic : IBusinessLogicService
    {


        [OperationContract]

        /// <summary>
        /// Returns root category values
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        Dictionary<string, SettingDTO> GetAllSettings();

        [OperationContract]

        /// <summary>
        /// Returns root category values
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
       SettingDTO GetSetting(SettingDTO setting);
        [OperationContract]
        void InsertSetting(SettingDTO dto);
        [OperationContract]
        void UpdateSetting(SettingDTO dto);

        [OperationContract]
        void DeleteSetting(SettingDTO dto);
        [OperationContract]
        SettingDTO GetSettingById(int settingId);
        [OperationContract]
        SettingDTO GetSettingByName(string name);

    }
}