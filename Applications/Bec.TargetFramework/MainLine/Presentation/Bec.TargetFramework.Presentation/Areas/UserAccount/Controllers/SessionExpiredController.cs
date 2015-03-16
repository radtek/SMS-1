using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Areas.UserAccount.Controllers
{
    [AllowAnonymous]
    public class SessionExpiredController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
    }
}