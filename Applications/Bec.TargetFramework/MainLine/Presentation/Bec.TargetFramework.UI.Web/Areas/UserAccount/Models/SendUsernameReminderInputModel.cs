using System.ComponentModel.DataAnnotations;

namespace Bec.TargetFramework.UI.Web.Areas.UserAccount.Models
{
    public class SendUsernameReminderInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}