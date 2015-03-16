using System.ComponentModel.DataAnnotations;

namespace Bec.TargetFramework.UI.Web.Areas.UserAccount.Models
{
    public class TwoFactorAuthInputModel
    {
        [Required]
        public string Code { get; set; }

        public string ReturnUrl { get; set; }
    }
}