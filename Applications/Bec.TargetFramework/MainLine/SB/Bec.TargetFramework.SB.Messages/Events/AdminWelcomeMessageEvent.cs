using Bec.TargetFramework.Entities.DTO.Notification;
using NServiceBus;

namespace Bec.TargetFramework.SB.Messages.Events
{
    public class AdminWelcomeMessageEvent : IEvent
    {
        public AdminWelcomeMessageDTO AdminWelcomeMessageDTO { get; set; }
    }
}
