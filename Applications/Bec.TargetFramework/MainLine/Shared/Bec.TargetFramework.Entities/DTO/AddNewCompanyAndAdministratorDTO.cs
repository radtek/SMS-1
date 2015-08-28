using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [System.Serializable]
    public class AddNewCompanyAndAdministratorDTO
    {
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ProductName { get; set; }
        public string WebsiteURL { get; set; }
        public Guid UserAccountOrganisationID { get; set; }
        public string InviterSalutation { get; set; }
        public string InviterFirstName { get; set; }
        public string InviterLastName { get; set; }
    }
}
