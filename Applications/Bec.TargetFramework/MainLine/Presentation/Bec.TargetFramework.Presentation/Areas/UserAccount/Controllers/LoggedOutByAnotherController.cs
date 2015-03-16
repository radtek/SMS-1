using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Areas.UserAccount.Controllers
{
    [AllowAnonymous]
    public class LoggedOutByAnotherController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
    }
}
