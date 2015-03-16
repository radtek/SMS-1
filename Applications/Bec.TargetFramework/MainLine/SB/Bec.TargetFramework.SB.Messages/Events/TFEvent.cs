using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Entities.DTO.Event;
using Bec.TargetFramework.SB.Messages.Interfaces;

namespace Bec.TargetFramework.SB.Messages.Events
{
    using Bec.TargetFramework.Entities;

    using NServiceBus;

    public class TFEvent : ITFEvent
    {
        public EventPayloadDTO EventPayloadDto { get; set; }
    }
}
