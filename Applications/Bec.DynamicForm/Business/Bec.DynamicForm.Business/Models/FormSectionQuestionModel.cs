using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.DynamicForm.Business.Models
{
    public class FormSectionQuestionModel
    {

        public List<QuestionModels> allQuestions { get; set; }
        public List<FormSectionModels> allSections{get;set;}
    }
}
