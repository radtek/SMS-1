using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using Bec.TargetFramework.SB.Entities;

namespace Bec.TargetFramework.SB.Interfaces
{
    public interface ISBEvent : IEvent
    {
        EventPayloadDTO EventPayloadDto { get; set; }
    }
}
