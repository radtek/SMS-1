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

        /// <returns></returns>
        Task<Boolean> PublishEventAsync(EventPayloadDTO pDto);

        /// <returns></returns>
        Boolean PublishEvent(EventPayloadDTO pDto);


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
