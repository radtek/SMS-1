using System.ComponentModel.DataAnnotations;

namespace Bec.TargetFramework.UI.Web.Areas.UserAccount.Models
{
    public class ChangeUsernameInputModel
    {
        [Required]
        public string NewUsername { get; set; }
    }
}