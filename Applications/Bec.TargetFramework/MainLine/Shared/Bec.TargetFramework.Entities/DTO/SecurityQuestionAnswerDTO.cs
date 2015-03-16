using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    public class SecurityQuestionAnswerDTO
    {
        public Guid QuestionID { get; set; }
        public string Answer { get; set; }
    }
}
