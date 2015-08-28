using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.DynamicForm.Entities.DTO
{
     [DataContract]
    public class QuestionControlTypeDTO
    {
        public QuestionControlTypeDTO() { }
       
        
       [System.ComponentModel.DataAnnotations.Display(Name = "QuestionControlTypeid")]
       [DataMember]
        public int QuestionControlTypeid { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "ControlTypeName")]
        [DataMember]
        public string ControlTypeName { get; set; }


        [System.ComponentModel.DataAnnotations.Display(Name = "isSelected")]
        [DataMember]
        public bool  hasSelected { get; set; }
    }
}
