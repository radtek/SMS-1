using System;

namespace Bec.TargetFramework.Entities
{
    [Serializable]
    public class ParticipantDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsProfessionalOrganisation { get; set; }
        public string OrganisationName { get; set; }
    }
}
