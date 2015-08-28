using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.DynamicForm.Entities.DTO
{
    [DataContract]
    public class ValidationDTO
    {
       
        public ValidationDTO()
        {

        }
        [System.ComponentModel.DataAnnotations.Display(Name = "ValidationId")]
        [DataMember]
        public int ValidationId { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "ValidationTypeName")]
        [DataMember]
        public string ValidationTypeName { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Expression")]
        [DataMember]
        public string Expression { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Format")]
        [DataMember]
        public string Format { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "ErrorMessage")]
        [DataMember]
        public string ErrorMessage { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Selected")]
        [DataMember]
        public bool Selected { get; set; }
    }
}
