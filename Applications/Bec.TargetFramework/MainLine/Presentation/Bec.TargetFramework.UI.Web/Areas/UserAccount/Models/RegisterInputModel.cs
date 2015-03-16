using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.UI.Web.Areas.UserAccount.Models
{
    [DataContract]
    public class RegisterInputModel
    {
        [DataMember]
        [ScaffoldColumn(false)]
        public string Username { get; set; }

        [DataMember]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DataMember]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataMember]
        //[System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage="Password confirmation must match password.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [DataMember]
        public bool TemporaryAccount { get; set; }
    }
}