using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.SB.Entities;
using Bec.TargetFramework.SB.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.SB.Client.Interfaces
{
    public interface IClientBase : IDisposable
    {
        HttpClient HttpClient { get; }
    }


    public partial interface IBusLogicClient : IClientBase
    {

        /// <param name="BusEventId"></param>
        /// <returns></returns>
        Task<List<BusEventMessageSubscriberDTO>> GetBusEventSubscribersAsync(Guid BusEventId);

        /// <param name="BusEventId"></param>
        /// <returns></returns>
        List<BusEventMessageSubscriberDTO> GetBusEventSubscribers(Guid BusEventId);


        /// <param name="eventName"></param>
        /// <returns></returns>
        Task<BusEventDTO> GetBusEventByNameAsync(String eventName);

        /// <param name="eventName"></param>
        /// <returns></returns>
        BusEventDTO GetBusEventByName(String eventName);


        /// <param name="status"></param>
        /// <param name="subscriber"></param>
        /// <param name="handler"></param>
        /// <param name="isScheduledTask"></param>
        /// <returns></returns>
        Task<Boolean> SaveBusMessageAsync(BusMessageStatusEnum status, String subscriber, String handler, Boolean isScheduledTask, BusMessageDTO messageDto);

        /// <param name="status"></param>
        /// <param name="subscriber"></param>
        /// <param name="handler"></param>
        /// <param name="isScheduledTask"></param>
        /// <returns></returns>
        Boolean SaveBusMessage(BusMessageStatusEnum status, String subscriber, String handler, Boolean isScheduledTask, BusMessageDTO messageDto);


        /// <param name="subscriber"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        Task<Boolean> HasMessageAlreadyBeenProcessedAsync(String subscriber, String handler, BusMessageDTO messageDto);

        /// <param name="subscriber"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        Boolean HasMessageAlreadyBeenProcessed(String subscriber, String handler, BusMessageDTO messageDto);


    }

    public partial interface IBusTaskLogicClient : IClientBase
    {

        /// <returns></returns>
        Task<List<VBusTaskScheduleDTO>> AllBusTaskSchedulesAsync();

        /// <returns></returns>
        List<VBusTaskScheduleDTO> AllBusTaskSchedules();


        /// <param name="appName"></param>
        /// <param name="env"></param>
        /// <returns></returns>
        Task<List<VBusTaskScheduleDTO>> AllBusTaskSchedulesByAppNameAndEnvAsync(String appName, String env);

        /// <param name="appName"></param>
        /// <param name="env"></param>
        /// <returns></returns>
        List<VBusTaskScheduleDTO> AllBusTaskSchedulesByAppNameAndEnv(String appName, String env);


        /// <returns></returns>
        Task SaveBusTaskScheduleProcessLogAsync(ProcessLogDTO logDto);

        /// <returns></returns>
        void SaveBusTaskScheduleProcessLog(ProcessLogDTO logDto);


    }

    public partial interface IEventPublishLogicClient : IClientBase
    {

        /// <returns></returns>
        Task<Boolean> PublishEventAsync(EventPayloadDTO pDto);

        /// <returns></returns>
        Boolean PublishEvent(EventPayloadDTO pDto);


    }

    public partial interface ISettingsLogicClient : IClientBase
    {

        /// <returns></returns>
        Task<Dictionary<String, ISettingDTO>> GetSettingsAsync();

        /// <returns></returns>
        Dictionary<String, ISettingDTO> GetSettings();


    }

}
