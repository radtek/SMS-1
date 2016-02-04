using System;
using System.Collections.Generic;

namespace Bec.TargetFramework.Entities.DTO.Notification
{
    [Serializable]
    public class ProductAdvisedNotificationDTO
    {
        public Guid TransactionID { get; set; }
        public string CompanyName { get; set; }
    }
}
