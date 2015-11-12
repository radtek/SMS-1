using Bec.TargetFramework.Entities.DTO.Notification;
using NServiceBus;

namespace Bec.TargetFramework.SB.Messages.Events
{
    public class BankAccountCheckNoMatchEvent : IEvent
    {
        public BankAccountCheckNoMatchNotificationDTO BankAccountCheckNoMatchNotificationDto { get; set; }
    }
}
