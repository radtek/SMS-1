using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.SB.Data;
using Bec.TargetFramework.SB.Messages.Commands;
using EnsureThat;
using NServiceBus;
using Bec.TargetFramework.SB.Entities;
using Bec.TargetFramework.SB.Messages.Events;
using Bec.TargetFramework.SB.Interfaces;

namespace Bec.TargetFramework.SB.Hosts.SBService.Logic
{
    public class EventPublishLogicController : LogicBase
    {
        public BusLogicController BusLogic {get;set;}
        public IBus Bus { get; set; }
        public EventPublishLogicController()
        {
        }

        public bool PublishEvent(EventPayloadDTO pDto)
        {
            Ensure.That(pDto.EventName).IsNotNullOrEmpty();
            Ensure.That(pDto.EventSource).IsNotNullOrEmpty();

            // create instance of T and cat as ITFEvent
            var instanceOfT = Activator.CreateInstance<SBEvent>();

            var eventDto = BusLogic.GetBusEventByName(pDto.EventName);

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();

            // create new dic
            Dictionary<Type, object> payloadDic = new Dictionary<Type, object>();

            if (pDto.PayloadAsJson != null)
            {
                var objectArray = JsonHelper.DeserializeData<object[]>(pDto.PayloadAsJson);

                objectArray.ToList().ForEach(s =>
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
                EventID = eventDto.BusEventID,
                EventSource = pDto.EventSource,
                EventType = eventDto.BusEventTypeID,
                EventName = eventDto.BusEventName,
                EventReference = pDto.EventReference
            };

            ms.Close();

            instanceOfT.EventPayloadDto = dto;

            Bus.SetMessageHeader(instanceOfT, "Source", "EventPublisher");
            Bus.SetMessageHeader(instanceOfT, "MessageType", instanceOfT.GetType().FullName + "," + instanceOfT.GetType().Assembly.FullName);
            Bus.SetMessageHeader(instanceOfT, "ServiceType", "EventPublisher");

            if (!string.IsNullOrEmpty(dto.EventReference))
                Bus.SetMessageHeader(instanceOfT, "EventReference", dto.EventReference);

            // publish message on bus
            Bus.Publish<SBEvent>(instanceOfT);

            return true;
        }
    }
}
