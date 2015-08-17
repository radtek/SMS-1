using Bec.TargetFramework.Entities.DTO.Notification;
using NServiceBus;

namespace Bec.TargetFramework.SB.Messages.Events
{
    public class CreditAdjustmentEvent : IEvent
    {
        public CreditAdjustmentNotificationDTO CreditAdjustmentNotificationDto { get; set; }
    }
}
