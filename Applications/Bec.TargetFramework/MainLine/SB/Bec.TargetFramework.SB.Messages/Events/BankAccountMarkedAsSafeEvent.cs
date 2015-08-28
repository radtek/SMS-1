using Bec.TargetFramework.Entities.DTO.Notification;
using NServiceBus;

namespace Bec.TargetFramework.SB.Messages.Events
{
    public class BankAccountMarkedAsSafeEvent : IEvent
    {
        public BankAccountMarkedAsSafeNotificationDTO BankAccountMarkedAsSafeNotificationDto { get; set; }
    }
}
