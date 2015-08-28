using Bec.DynamicForm.Data;
using Bec.DynamicForm.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.DynamicForm.Business.Models
{

    public class QuestionModels
    {
        public QuestionModels()
        {         
         
        }
        public QuestionModels(Question q)
        {
            Util.CopyToNew(q, this);
        } 
        public void Initialize()
        {
            questionControlTypeList = QuestionManager.SelectQuestionControlType(null);
            if(QuestionId>0)
            Options = QuestionManager.SelectOptions(null,QuestionId);
            if(Options==null)
                Options = new List<QuestionOptionModels>();
            validations = QuestionManager.SelectValidationType(null);
        }

        [System.ComponentModel.DataAnnotations.Display(Name = "QuestionId")]
        public long QuestionId { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Description")]
        public string Description { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "QuestionControlTypeId")]
        public Nullable<int> QuestionControlTypeId { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "HelpText")]
        public string HelpText { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "MaxText")]
        public string MaxText { get; set; }
        
        public List<QuestionOptionModels> Options { get; set; }
        public List<ValidationModel> validations { get; set; }
        public List<QuestionControlTypeModels> questionControlTypeList { get; set; }
    
    }
}
