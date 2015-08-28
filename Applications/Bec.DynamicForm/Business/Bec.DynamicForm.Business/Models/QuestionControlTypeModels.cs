using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.DynamicForm.Business.Models
{
    public class QuestionControlTypeModels
    {
        public QuestionControlTypeModels() { }
        public QuestionControlTypeModels(Bec.DynamicForm.Data.QuestionControlType obj) {
            Util.CopyToNew(obj, this);
        }
        
        [System.ComponentModel.DataAnnotations.Display(Name = "QuestionControlTypeid")]
        public int QuestionControlTypeid { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "ControlTypeName")]
        public string ControlTypeName { get; set; }


        [System.ComponentModel.DataAnnotations.Display(Name = "isSelected")]
        public bool  hasSelected { get; set; }
    }
}
