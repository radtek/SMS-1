using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    [Serializable]
    public class PermanentAccountDTO
    {
        [DataMember]
        public Guid UserID { get; set; }
         [Required]
        [DataMember]
        public string EmailAddress { get; set; }

         [Required]
        [DataMember]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DataMember]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DataMember]
        public string Password { get; set; }

        [Required]
        [DataMember]
        public string Question1 { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DataMember]
        public string Answer1 { get; set; }

        [Required]
        [DataMember]
        public string Question2 { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DataMember]
        public string Answer2 { get; set; }
        
    }
}
