using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;

namespace Bec.TargetFramework.UI.Web.Areas.UserAccount.Models
{
    [DataContract]
    public class PasswordResetInputModel
    {
        [DataMember]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
    [DataContract]
    public class PasswordResetWithSecretInputModel
    {
        public PasswordResetWithSecretInputModel ()
	    {
	    }

        public PasswordResetWithSecretInputModel(Guid accountID)
        {
            var bytes = Encoding.UTF8.GetBytes(accountID.ToString());
            bytes = MachineKey.Protect(bytes, "PasswordResetWithSecretViewModel");
            ProtectedAccountID = Convert.ToBase64String(bytes);
        }

        [DataMember]
        public PasswordResetSecretViewModel[] Questions { get; set; }

        [DataMember]
        [Required]
        public string ProtectedAccountID { get; set; }

        [DataMember]
        public Guid? UnprotectedAccountID
        {
            get
            {
                try
                {
                    if (this.ProtectedAccountID != null)
                    {
                        var bytes = Convert.FromBase64String(this.ProtectedAccountID);
                        bytes = MachineKey.Unprotect(bytes, "PasswordResetWithSecretViewModel");
                        var val = Encoding.UTF8.GetString(bytes);
                        return Guid.Parse(val);
                    }
                }
                catch { }
                return null;
            }
        }
    }
    [DataContract]
    public class PasswordResetSecretViewModel : PasswordResetSecretInputModel
    {
        [DataMember]
        public string Question { get; set; }
    }
    [DataContract]
    public class PasswordResetSecretInputModel
    {
        [DataMember]
        [HiddenInput]
        public Guid QuestionID { get; set; }
        [DataMember]
        [Required]
        [DataType(DataType.Password)]
        public string Answer { get; set; }
    }
}