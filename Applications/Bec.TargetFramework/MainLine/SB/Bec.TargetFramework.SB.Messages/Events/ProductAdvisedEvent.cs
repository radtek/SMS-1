using Bec.TargetFramework.Entities.DTO.Notification;
using NServiceBus;

namespace Bec.TargetFramework.SB.Messages.Events
{
    public class ProductAdvisedEvent : IEvent
    {
        public ProductAdvisedNotificationDTO ProductAdvisedNotificationDTO { get; set; }
    }
}
