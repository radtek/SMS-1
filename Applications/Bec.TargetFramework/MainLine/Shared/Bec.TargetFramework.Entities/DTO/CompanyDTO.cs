using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [System.Serializable]
    public class CompanyDTO
    {
        
        public string Name { get; set; }
        
        public string Url { get; set; }
        
        public string SraNumber { get; set; }
        
        public string Address { get; set; }
        
        public string TradingName { get; set; }

        public string PostCode { get; set; }

        public List<CompanyDTO> Branches { get; set; }
    }
}
