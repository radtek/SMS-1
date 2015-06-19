using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.SB.Interfaces;

namespace Bec.TargetFramework.SB.Messages.Events
{
    using NServiceBus;
    using Bec.TargetFramework.SB.Entities;

    public class SBEvent : IEvent
    {
        public EventPayloadDTO EventPayloadDto { get; set; }
    }
}
