using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Bec.TargetFramework.Entities.Helpers;
using System.Text.RegularExpressions;
using Bec.TargetFramework.Entities.Enums;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    public partial class IDCheckRequestDTO
    {
        
        [DataMember]
        public string ForeName { get; set; }

        [DataMember]
        public string SurName { get; set; }

        [DataMember]
        public string Premise { get; set; }

        [DataMember]
        public string Postcode { get; set; }

        [DataMember]
        public string CountryCode { get; set; }

        [DataMember]
        public string Telephone { get; set; }
    }


}
