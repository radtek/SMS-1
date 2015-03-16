using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.DynamicForm.Business.Models
{
    public class QuestionOptionModels
    {
        public QuestionOptionModels() { }
        public QuestionOptionModels(Bec.DynamicForm.Data.QuestionOption obj)
        {
            Util.CopyToNew(obj, this);
        }
        [System.ComponentModel.DataAnnotations.Display(Name = "OptionId")]
        public int OptionId { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "OptionText")]
        public string OptionText { get; set; }
    }
}
