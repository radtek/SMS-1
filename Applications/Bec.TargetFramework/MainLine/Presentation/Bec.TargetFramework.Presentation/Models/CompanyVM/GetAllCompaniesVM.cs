using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bec.TargetFramework.Presentation.Models
{
    public class Company
    {
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string TownCity { get; set; }
        public string County { get; set;  }
        public string PostCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tel { get; set; }
        public DateTime RecordCreated { get; set;  }
        public string Email { get; set; }
        public bool IsVerified { get; set; }
        public bool IsPinCreated { get; set; }
        public DateTime? PinCreated { get; set; }
        public string PinCode { get; set; }
        public string ReturnUrl { get; set; }
        public string Regulator { get; set; }
        public string OtherRegulator { get; set; }

        public string SysAdmin
        {
            get 
            {
                if (string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(LastName))
                    return string.Empty;

                return FirstName + " " + LastName; 
            }
        }

        public string RegulatorToDisplay
        {
            get
            {
                if (!string.IsNullOrEmpty(OtherRegulator))
                    return  OtherRegulator;

                return Regulator;
            }
        }        
    }

    public class GetAllCompaniesVM
    {
        public IList<Company> VerifiedCompanies { get; set; }

        public IList<Company> UnverifiedCompanies { get; set; }
    }
}