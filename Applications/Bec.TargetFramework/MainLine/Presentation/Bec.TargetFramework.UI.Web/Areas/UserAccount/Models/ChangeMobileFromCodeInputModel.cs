using System.ComponentModel.DataAnnotations;

namespace Bec.TargetFramework.UI.Web.Areas.UserAccount.Models
{
    public class ChangeMobileFromCodeInputModel
    {
        [Required]
        public string Code { get; set; }
    }
    
}