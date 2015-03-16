using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Entities;
using NServiceBus;

namespace Bec.TargetFramework.SB.Messages.Events
{

    public class ColpRegistrationTemporaryAccountEvent : IEvent
    {
        public string DataDictionary { get; set; }
    }
}
