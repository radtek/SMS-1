using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Entities.DTO.Event;
using NServiceBus;

namespace Bec.TargetFramework.SB.Messages.Interfaces
{
    public interface ITFEvent : IEvent
    {
        EventPayloadDTO EventPayloadDto { get; set; }
    }
}
