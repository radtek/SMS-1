using Bec.TargetFramework.SB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.SB.Interfaces
{
    public partial interface IEventPublishClient : IClientBase
    {

        /// <param name="eventName"></param>
        /// <param name="eventSource"></param>
        /// <param name="eventReference"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> PublishEventAsync(EventPayloadDTO dto);

        /// <param name="eventName"></param>
        /// <param name="eventSource"></param>
        /// <param name="eventReference"></param>
        /// <returns></returns>
        Boolean PublishEvent(EventPayloadDTO dto);

        /// <param name="categoryName"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> GetClassificationDataForTypeNameAsync(String categoryName, String typeName);

        /// <param name="categoryName"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        Int32 GetClassificationDataForTypeName(String categoryName, String typeName);

        /// <param name="isNew"></param>
        /// <returns></returns>

    }
}
