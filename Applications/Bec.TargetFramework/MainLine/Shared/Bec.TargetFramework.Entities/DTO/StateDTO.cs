using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
 
    public partial class StateDTO
    {

        [DataMember]
        public bool StateSelected { get; set; }


    }
}
