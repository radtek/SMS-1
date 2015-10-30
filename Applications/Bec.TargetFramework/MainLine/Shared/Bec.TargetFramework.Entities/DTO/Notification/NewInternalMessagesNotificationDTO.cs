using System;
using System.Collections.Generic;

// wrong namespace but notifications do not handle additional namespaces yet
namespace Bec.TargetFramework.Entities
{
    [Serializable]
    public class NewInternalMessagesNotificationDTO
    {
        public int Count { get; set; }
        public List<NotificationRecipientDTO> NotificationRecipientDtos { get; set; }
        public string ProductName { get; set; }
    }
}
