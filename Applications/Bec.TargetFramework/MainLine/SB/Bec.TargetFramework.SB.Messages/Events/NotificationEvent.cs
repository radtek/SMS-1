using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.SB.Messages.Events
{


    using Bec.TargetFramework.Entities;
    using NServiceBus;


    public class NotificationEvent : IEvent
    {
       public NotificationContainerDTO NotificationContainer { get; set; }
    }
}
