using Bec.TargetFramework.Entities;

namespace Bec.TargetFramework.Presentation.Web.Areas.Account.Models
{
    public class LoginModel
    {
        public LoginDTO LoginDTO { get; set; }
        public CreatePermanentLoginModel CreatePermanentLoginModel { get; set; }
        public bool IsRegistration { get; set; }
    }
}