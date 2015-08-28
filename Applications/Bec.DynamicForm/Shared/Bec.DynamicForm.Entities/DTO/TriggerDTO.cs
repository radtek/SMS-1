using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.DynamicForm.Entities.DTO
{
    [DataContract]
    public class TriggerDTO
    {
        public TriggerDTO() { }

        [System.ComponentModel.DataAnnotations.Display(Name = "TriggerId")]
        [DataMember]
        public int TriggerId { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "TriggerValue")]
        [DataMember]
        public string TriggerValue { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "TriggerAction")]
        [DataMember]
        public string TriggerAction { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "TriggerPointQuestionid")]
        [DataMember]
        public Nullable<long> TriggerPointQuestionid { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "TriggerPointSectionId")]
        [DataMember]
        public Nullable<int> TriggerPointSectionId { get; set; }
    }
}
