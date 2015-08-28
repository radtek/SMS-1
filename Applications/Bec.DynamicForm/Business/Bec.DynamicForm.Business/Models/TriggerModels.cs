using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.DynamicForm.Business.Models
{
    public class TriggerModels
    {
        public TriggerModels() { }

        [System.ComponentModel.DataAnnotations.Display(Name = "TriggerId")]
        public int TriggerId { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "TriggerValue")]
        public string TriggerValue { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "TriggerAction")]
        public string TriggerAction { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "TriggerPointQuestionid")]
        public Nullable<long> TriggerPointQuestionid { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "TriggerPointSectionId")]
        public Nullable<int> TriggerPointSectionId { get; set; }
    }
}
