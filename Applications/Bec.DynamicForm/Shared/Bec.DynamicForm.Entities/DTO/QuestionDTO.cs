

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.DynamicForm.Entities.DTO
{
    [DataContract]
    public class QuestionDTO
    {
        public QuestionDTO()
        {         
         
        }
       
        //public void Initialize()
        //{
        //    questionControlTypeList = QuestionManager.SelectQuestionControlType(null);
        //    if(QuestionId>0)
        //    Options = QuestionManager.SelectOptions(null,QuestionId);
        //    if(Options==null)
        //        Options = new List<QuestionOptionModels>();
        //    validations = QuestionManager.SelectValidationType(null);
        //}

        [System.ComponentModel.DataAnnotations.Display(Name = "QuestionId")]
        [DataMember]
        public long QuestionId { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Description")]
        [DataMember]
        public string Description { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "QuestionControlTypeId")]
        [DataMember]
        public Nullable<int> QuestionControlTypeId { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "QuestionControlTypeName")]
        [DataMember]
        public string QuestionControlTypeName { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "HelpText")]
        [DataMember]
        public string HelpText { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "MaxText")]
        [DataMember]
        public string MaxText { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Select")]
        [DataMember]
        public Boolean Select { get; set; }


        [System.ComponentModel.DataAnnotations.Display(Name = "isVisible")]
        [DataMember]
        public Boolean isVisible { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "IsMandatory")]
        [DataMember]
        public Boolean IsMandatory { get; set; }

         [DataMember]
        public List<QuestionOptionDTO> Options { get; set; }
         [DataMember]
        public List<ValidationDTO> validations { get; set; }
         [DataMember]
        public List<QuestionControlTypeDTO> questionControlTypeList { get; set; }
    
    }
}
