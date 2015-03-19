using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    public class VerfiedUnverifiedCompaniesDTO
    {
        public List<VCompanyDTO> VerifiedCompanies { get; set; }

        public List<VCompanyDTO> UnverifiedCompanies { get; set; }
    }
}
