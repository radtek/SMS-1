using System;

namespace Bec.TargetFramework.Entities.DTO.Notification
{
    [Serializable]
    public class BankAccountStateChangeNotificationDTO
    {
        public Guid OrganisationId{ get; set; }
        public string SortCode { get; set; }
        public string AccountNumber { get; set; }
        public string MarkedBy { get; set; }
        public string Reason { get; set; }
        public string DetailsUrl { get; set; }
        public Guid OrganisationBankAccountID { get; set; }
    }
}
