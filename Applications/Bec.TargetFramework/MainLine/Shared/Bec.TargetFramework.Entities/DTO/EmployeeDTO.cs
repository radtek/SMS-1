using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Bec.TargetFramework.Entities
{
     [System.Serializable]
    public class EmployeeDTO
    {
        
        public string Name { get; set; }

        public string LastName { get; set; }

        
        public string Url { get; set; }

        
        public string SraNumber { get; set; }

        
        public bool IsCOLP { get; set; }

        public string BranchSraNumber { get; set; }
        
        public bool IsSraRegistered { get; set; }

        
        public string CompanyName { get; set; }
    }
}
