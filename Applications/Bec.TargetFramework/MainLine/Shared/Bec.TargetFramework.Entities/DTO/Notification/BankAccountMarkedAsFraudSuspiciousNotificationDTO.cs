using System;
using System.Collections.Generic;

namespace Bec.TargetFramework.Entities.DTO.Notification
{
    [Serializable]
    public class BankAccountMarkedAsFraudSuspiciousNotificationDTO
    {
        public IEnumerable<Guid> UserAccountOrganisationIds { get; set; }
        public string SortCode { get; set; }
        public string AccountNumber { get; set; }
        public string DetailsUrl { get; set; }
    }
}
