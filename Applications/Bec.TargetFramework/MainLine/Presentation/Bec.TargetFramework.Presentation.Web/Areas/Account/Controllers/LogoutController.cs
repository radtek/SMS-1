using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Security;
using BrockAllen.MembershipReboot;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Account.Controllers
{
    [Authorize]
    public class LogoutController : Controller
    {
        public IUserLogicClient UserLogicClient { get; set; }
        public AuthenticationService AuthSvc { get; set; }

        // GET: Account/Logout
        public async Task<ActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var currentUser = WebUserHelper.GetWebUserObject(HttpContext);
                if (currentUser != null)
                {
                    await UserLogicClient.LogUserOutAsync(currentUser.UserID, currentUser.SessionIdentifier);
                }
                AuthSvc.SignOut();
                SessionHelper.ClearSession();

                return RedirectToAction("Index", "Login", new { area = "Account" });
            }

            return View();
        }
    }
}