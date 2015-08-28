using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
   
    public partial class OrganisationGroupDTO
    {
     
        [DataMember]
        public Guid GroupTemplateID { get; set; }

   
  
        [DataMember]
        public string Name { get; set; }

       

        
    }
}
