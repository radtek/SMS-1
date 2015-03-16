using Bec.TargetFramework.Entities.Validators;
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
    [FluentValidation.Attributes.ValidatorAttribute(typeof(ChangePasswordWithSecretDTOValidator))]
    [DataContract]
    [Serializable]
    public class ChangePasswordWithSecretDTO
    {
        [DataMember]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataMember]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

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
            return (Password != null && ConfirmPassword  != null && QuestionID != null);
        }
        public bool QuestionExistsWithAnswer()
        {
            return (Password != null && ConfirmPassword != null && QuestionID != null && Answer != null);
        }

        [DataMember]
        public bool CaptchaResult { get; set; }

        [DataMember]
        public string Result { get; set; }

    }
}
