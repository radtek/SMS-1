using Bec.TargetFramework.Entities.DTO.Notification;
using NServiceBus;

namespace Bec.TargetFramework.SB.Messages.Events
{
    public class BankAccountMarkedAsPotentialFraudEvent : IEvent
    {
        public BankAccountMarkedAsPotentialFraudNotificationDTO BankAccountMarkedAsPotentialFraudNotificationDto { get; set; }
    }
}
