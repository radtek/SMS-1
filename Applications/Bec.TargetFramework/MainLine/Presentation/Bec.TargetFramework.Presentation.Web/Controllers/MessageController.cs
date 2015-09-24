using Bec.TargetFramework.Presentation.Web.Filters;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Controllers
{
    [AjaxFriendlyAuthorize]
    public class MessageController : Controller
    {
        public ActionResult ViewMessage(string title, string message, string button)
        {
            ViewBag.title = title;
            ViewBag.message = message;
            ViewBag.button = button;
            return PartialView("_Message");
        }
    }
}