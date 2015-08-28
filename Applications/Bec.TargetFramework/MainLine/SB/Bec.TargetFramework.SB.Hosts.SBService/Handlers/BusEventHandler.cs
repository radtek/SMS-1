using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Log;
using NServiceBus;
using PostSharp.Extensibility;
using ServiceStack.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Bec.TargetFramework.SB.Infrastructure;
using Bec.TargetFramework.SB.Interfaces;
using Bec.TargetFramework.SB.Entities;
using Bec.TargetFramework.SB.Handlers.Base;
using EnsureThat;
using Bec.TargetFramework.SB.Messages.Events;

namespace Bec.TargetFramework.SB.Hosts.SBService
{
    public class BusEventHandler : BaseEventHandler<Bec.TargetFramework.SB.Messages.Events.SBEvent>
    {
        public BusEventHandler()
        {
            
        }

        public static object ConvertByteArrayToObject(byte[] ba)
        {
            BinaryFormatter bf = new BinaryFormatter();
            Stream stream = new MemoryStream(ba);
            return bf.Deserialize(stream);
        }

        public override void Dispose()
        {
        }

        public override void HandleMessage(SBEvent tfEvent)
        {
            if (HasMessageAlreadyBeenProcessed()) return;

            try
            {
                var subscribers = m_BusLogic.GetBusEventSubscribers(tfEvent.EventPayloadDto.EventID);

                // iterate subscribers and process
                subscribers.ForEach(item =>
                {
                    // create message
                    Type payloadType = Type.GetType(tfEvent.EventPayloadDto.PayloadObjectType);
                    Type messageType = Type.GetType(String.Format("{0},{1}", item.ObjectName, item.ObjectAssembly));

                    Dictionary<Type, object> payloadDictionary = (Dictionary<Type, object>)ConvertByteArrayToObject(tfEvent.EventPayloadDto.Payload);

                    object message = Activator.CreateInstance(messageType);

                    if (
                        message.GetType()
                            .GetProperties()
                            .Any(s => payloadDictionary.ContainsKey(s.PropertyType)))
                    {
                        message.GetType()
                            .GetProperties()
                            .Where(s => payloadDictionary.ContainsKey(s.PropertyType))
                            .ToList()
                            .ForEach(s =>
                            {
                                s.GetSetMethod().Invoke(message, new object[] { payloadDictionary[s.PropertyType] });
                            });

                        Bus.SetMessageHeader(message, "Source", AppDomain.CurrentDomain.FriendlyName);
                        Bus.SetMessageHeader(message, "MessageType", String.Format("{0},{1}", item.ObjectName, item.ObjectAssembly));
                        Bus.SetMessageHeader(message, "ServiceType", AppDomain.CurrentDomain.FriendlyName);

                        if (!string.IsNullOrEmpty(tfEvent.EventPayloadDto.EventReference))
                            Bus.SetMessageHeader(message, "EventReference", tfEvent.EventPayloadDto.EventReference);
                       
                        Bus.Publish(message);
                    }
                });

                LogMessageAsCompleted();
            }
            catch (System.Exception ex)
            {
                LogMessageAsFailed();

                throw;
            }


        }
    }
}
