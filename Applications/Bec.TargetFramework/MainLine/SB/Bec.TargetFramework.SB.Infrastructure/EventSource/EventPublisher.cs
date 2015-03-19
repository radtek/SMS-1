using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities.DTO.Event;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.SB.Messages.Commands;
using Bec.TargetFramework.SB.Messages.Events;
using EnsureThat;
using NServiceBus;
using ServiceStack.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Ensure = Fabrik.Common.Ensure;

namespace Bec.TargetFramework.SB.Infrastructure.EventSource
{
    public class EventPublisher
    {
        public static bool PublishEvent(IDataLogic logic, string eventName, string eventSource, string eventReference,object[] eventPayloadObjects = null)
        {
            Ensure.Argument.NotNull(eventSource);
            Ensure.Argument.NotNull(eventName);

            // create instance of T and cat as ITFEvent
            var instanceOfT = Activator.CreateInstance<TFEvent>();

            var eventDto = logic.GetTFEventByName(eventName);

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();

            // create new dic
            Dictionary<Type,object> payloadDic = new Dictionary<Type, object>();

            if (eventPayloadObjects != null)
            {
                eventPayloadObjects.ToList()
                    .ForEach(s =>
                    {
                        payloadDic.Add(s.GetType(), s);
                    });
            }

            bf.Serialize(ms, payloadDic);

            // create dto
            var dto = new EventPayloadDTO
            {
                CreatedOn = DateTime.Now,
                PayloadObjectType = payloadDic.GetType().FullName + "," + payloadDic.GetType().Assembly.FullName,
                Payload = ms.ToArray(),
                CreatedBy = Environment.UserName,
                EventID = eventDto.TFEventID,
                EventSource = eventSource,
                EventType = eventDto.TFEventTypeID,
                EventName = eventDto.TFEventName,
                EventReference = eventReference
            };

            ms.Close();

            instanceOfT.EventPayloadDto = dto;

            //var serviceBus = Configure.Instance.Builder.Build<IBus>();

            //serviceBus.SetMessageHeader(instanceOfT, "Source", "EventPublisher");
            //serviceBus.SetMessageHeader(instanceOfT, "MessageType", instanceOfT.GetType().FullName  + "," + instanceOfT.GetType().Assembly.FullName);
            //serviceBus.SetMessageHeader(instanceOfT, "ServiceType", "EventPublisher");

            //if (!string.IsNullOrEmpty(dto.EventReference))
            //    serviceBus.SetMessageHeader(instanceOfT, "EventReference", dto.EventReference);

            //// publish message on bus
            //serviceBus.Publish<TFEvent>(instanceOfT);

            return true;
        }

    }
}
