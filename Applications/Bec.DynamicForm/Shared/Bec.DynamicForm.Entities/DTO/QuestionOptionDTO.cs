using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.DynamicForm.Entities.DTO
{
     [DataContract]
    public class QuestionOptionDTO
    {
        public QuestionOptionDTO() { }
        
        [System.ComponentModel.DataAnnotations.Display(Name = "OptionId")]
        [DataMember]
        public int OptionId { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "OptionText")]
        [DataMember]
        public string OptionText { get; set; }
    }
}
