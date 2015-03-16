using System.ComponentModel.DataAnnotations;

namespace Bec.TargetFramework.UI.Web.Areas.UserAccount.Models
{
    public class ChangeEmailRequestInputModel
    {
        //[Required]
        [EmailAddress]
        public string NewEmail { get; set; }
    }
}