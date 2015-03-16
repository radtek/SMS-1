using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Framework.Configuration;
using Bec.TargetFramework.Infrastructure.Log;
using Fabrik.Common;
using NServiceBus;
using ServiceStack.Text;
using Bec.TargetFramework.SB.Handlers.Base;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Bec.TargetFramework.SB.Infrastructure;

namespace Bec.TargetFramework.SB.TaskHandlers.EventHandlers
{
    public class TFEventHandler : BaseEventHandler<Bec.TargetFramework.SB.Messages.Events.TFEvent>
    {
        public TFEventHandler(ILogger logger,
            IBusLogic busLogic, IClassificationDataLogic dataLogic,
            CommonSettings settings)
            : base(logger, busLogic, dataLogic, settings)
        {
            
        }

        public static object ConvertByteArrayToObject(byte[] ba)
        {
            BinaryFormatter bf = new BinaryFormatter();
            Stream stream = new MemoryStream(ba);
            return bf.Deserialize(stream);
        }

        public override void HandleMessage(Messages.Events.TFEvent tfEvent)
        {
            if (HasMessageAlreadyBeenProcessed()) return;

            Ensure.Argument.NotNull(tfEvent);
            Ensure.Argument.NotNull(tfEvent.EventPayloadDto);
            Ensure.Argument.NotNull(tfEvent.EventPayloadDto.PayloadObjectType);

            try
            {
                var subscribers = m_BusLogic.GetTFEventSubscribers(tfEvent.EventPayloadDto.EventID);

                // iterate subscribers and process
                subscribers.ForEach(item =>
                {
                    // create message
                    Type payloadType = Type.GetType(tfEvent.EventPayloadDto.PayloadObjectType);
                    Type messageType = Type.GetType(String.Format("{0},{1}", item.ObjectName, item.ObjectAssembly));

                    Dictionary<Type, object> payloadDictionary = (Dictionary<Type, object>)ConvertByteArrayToObject(tfEvent.EventPayloadDto.Payload);

                    object message = this.Bus.CreateInstance(messageType);

                    if (
                        message.GetType()
                            .GetProperties()
                            .Any(s => payloadDictionary.ContainsKey(s.PropertyType)))
                    {
                        message.GetType()
                            .GetProperties()
                            .Where(s => payloadDictionary.ContainsKey(s.PropertyType))
                            .ForEach(s =>
                            {
                                s.GetSetMethod().Invoke(message, new object[] { payloadDictionary[s.PropertyType] });
                            });

                        Bus.SetMessageHeader(message, "Source", "TFEventHandler");
                        Bus.SetMessageHeader(message, "MessageType", String.Format("{0},{1}", item.ObjectName, item.ObjectAssembly));
                        Bus.SetMessageHeader(message, "ServiceType", "TFEventHandler");

                        if (!string.IsNullOrEmpty(tfEvent.EventPayloadDto.EventReference))
                            Bus.SetMessageHeader(message, "EventReference", tfEvent.EventPayloadDto.EventReference);

                        Bus.Publish(message);
                    }
                });

                LogMessageAsCompleted();
            }
            catch (System.Exception ex)
            {
                LogError("TFEventHandler Error", ex, NServiceBusHelper.GetBusMessageDto(Bus.CurrentMessageContext.Headers).EventReference);

                throw;
            }


        }
    }
}
