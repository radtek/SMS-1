using System;

namespace Bec.TargetFramework.Entities.DTO.Notification
{
    [Serializable]
    public class AdminWelcomeMessageDTO
    {
        public Guid OrganisationId { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProductName { get; set; }
    }
}
