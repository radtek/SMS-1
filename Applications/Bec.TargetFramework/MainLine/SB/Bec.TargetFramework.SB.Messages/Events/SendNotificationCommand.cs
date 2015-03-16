using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.SB.Messages.Commands
{
    using Bec.TargetFramework.Entities;

    using NServiceBus;


    public class SendNotificationCommand : IEvent
    {
        public NotificationContainerDTO NotificationContainer { get; set; }
    }
}
