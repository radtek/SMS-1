using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [Serializable]
    public class ForgotPasswordDTO
    {
        //set initially
        public Guid UserID { get; set; }
        public string Url { get; set; }
        public string ExpireUrl { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid UserAccountOrganisationID { get; set; }
    }
}
