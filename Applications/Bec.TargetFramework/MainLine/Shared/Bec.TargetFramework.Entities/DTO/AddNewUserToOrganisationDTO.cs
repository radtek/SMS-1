using Bec.TargetFramework.Entities.Enums;
using System;
using System.Collections.Generic;

namespace Bec.TargetFramework.Entities
{
    [Serializable]
    public class AddNewUserToOrganisationDTO
    {
        public Guid OrganisationID { get; set; }
        public ContactDTO ContactDTO { get; set; }
        public UserTypeEnum UserType { get; set; }
        public bool AddDefaultRoles { get; set; }
        public IEnumerable<Guid> Functions { get; set; }
        public IEnumerable<Guid> Roles { get; set; }
    }
}
