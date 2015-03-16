using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    public class ForgotPasswordWithSecretDTO
    {
        public string Username { get; set; }

        [DataMember]
        public string Question { get; set; }
        [DataMember]
        [HiddenInput]
        public Guid? QuestionID { get; set; }
        [DataMember]

        [DataType(DataType.Password)]
        public string Answer { get; set; }

        public bool IsForgotUsername { get; set; }

        public bool QuestionExists()
        {
            return (Username != null && QuestionID != null);
        }
        public bool QuestionExistsWithAnswer()
        {
            return (Username != null && QuestionID != null && Answer != null);
        }

        [DataMember]
        public bool CaptchaResult { get; set; }

        [DataMember]
        public string Result { get; set; }
    }
}
