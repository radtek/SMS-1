﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.SB.Entities;
using Bec.TargetFramework.SB.Entities.Enums;

namespace Bec.TargetFramework.SB.Interfaces
{

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
