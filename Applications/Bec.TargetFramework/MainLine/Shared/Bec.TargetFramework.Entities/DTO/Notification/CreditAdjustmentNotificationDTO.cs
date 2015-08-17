using System;

namespace Bec.TargetFramework.Entities.DTO.Notification
{
    [Serializable]
    public class CreditAdjustmentNotificationDTO
    {
        public Guid OrganisationId { get; set; }
        public string NewBalance { get; set; }
        public string Reason { get; set; }
        public string ModifiedOn { get; set; }
        public string DetailsUrl { get; set; }
    }
}
