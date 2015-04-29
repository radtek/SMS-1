using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.SB.Entities;
using Bec.TargetFramework.SB.Entities.Enums;

namespace Bec.TargetFramework.SB.Interfaces
{
    public partial interface IBusTaskLogicClient : IClientBase
    {

        /// <returns></returns>
        Task<List<VBusTaskScheduleDTO>> AllBusTaskSchedulesAsync();

        /// <returns></returns>
        List<VBusTaskScheduleDTO> AllBusTaskSchedules();


        /// <param name="applicationName"></param>
        /// <param name="applicationEnvironmentName"></param>
        /// <returns></returns>
        Task<List<VBusTaskScheduleDTO>> AllBusTaskSchedulesByAppNameAndEnvAsync(String appName, String env);

        /// <param name="applicationName"></param>
        /// <param name="applicationEnvironmentName"></param>
        /// <returns></returns>
        List<VBusTaskScheduleDTO> AllBusTaskSchedulesByAppNameAndEnv(String appName, String env);


        /// <returns></returns>
        Task SaveBusTaskScheduleProcessLogAsync(ProcessLogDTO logDto);

        /// <returns></returns>
        void SaveBusTaskScheduleProcessLog(ProcessLogDTO logDto);


        /// <param name="categoryName"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        Task<Int32> GetClassificationDataForTypeNameAsync(String categoryName, String typeName);

        /// <param name="categoryName"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        Int32 GetClassificationDataForTypeName(String categoryName, String typeName);


    }
	
}
