using Bec.TargetFramework.Entities;
using NServiceBus;

namespace Bec.TargetFramework.SB.Messages.Events
{
    public class NewInternalMessagesEvent : IEvent
    {
        public NewInternalMessagesNotificationDTO NewInternalMessagesNotificationDTO { get; set; }
    }
}
