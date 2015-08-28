using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Entities.Helpers;

namespace Bec.TargetFramework.Entities
{
    [Serializable]
    [DataContract]
    public class TelephoneDTO
    {
        [DataMember]
        [RegularExpression(RegexExpressions.UkTelephoneExpression, ErrorMessage = "Please enter a valid UK Telephone Number")]
        [Required]
        public string TelephoneNumber { get;set;}
        [Required]
        [DataMember]
        public int? TelephoneNumberTypeID { get; set; }

         [DataMember]
        public string ID { get;set;}

    }
}
