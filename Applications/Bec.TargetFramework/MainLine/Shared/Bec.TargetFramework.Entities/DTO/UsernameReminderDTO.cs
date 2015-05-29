using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [Serializable]
    public class UsernameReminderDTO
    {
        //set initially
        public Guid UserID { get; set; }
        public string Username { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid UserAccountOrganisationID { get; set; }
    }
}
