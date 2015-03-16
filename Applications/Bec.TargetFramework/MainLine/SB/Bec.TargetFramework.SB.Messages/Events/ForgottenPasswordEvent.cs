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
    
    public class ForgottenPasswordEvent : IEvent
    {
        public TemporaryAccountDTO TemporaryAccountDto { get; set; }
    }
}
