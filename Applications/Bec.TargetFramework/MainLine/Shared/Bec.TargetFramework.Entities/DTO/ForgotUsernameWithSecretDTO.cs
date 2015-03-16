using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using Bec.TargetFramework.Entities.Validators;
using FluentValidation;

namespace Bec.TargetFramework.Entities
{
    [FluentValidation.Attributes.ValidatorAttribute(typeof(ForgotUsernameWithSecretDTOValidator))]
    [DataContract]
    [Serializable]
    public class ForgotUsernameWithSecretDTO
    {
        public string Email { get; set; }

        [DataMember]
        public string Question { get; set; }
        [DataMember]
        [HiddenInput]
        public Guid? QuestionID { get; set; }
        [DataMember]

        [DataType(DataType.Password)]
        public string Answer { get; set; }

        public bool QuestionExists()
        {
            return (Email != null && QuestionID != null);
        }
        public bool QuestionExistsWithAnswer()
        {
            return (Email != null && QuestionID != null && Answer != null);
        }

        [DataMember]
        public int RetryCount { get; set; }

        [DataMember]
        public bool CaptchaResult { get; set; }

        [DataMember]
        public string Result { get; set; }

    }
}
