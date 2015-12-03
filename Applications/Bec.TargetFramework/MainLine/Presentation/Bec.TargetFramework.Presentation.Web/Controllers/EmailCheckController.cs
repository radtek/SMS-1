using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Settings;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Controllers
{
    public class EmailCheckController : Controller
    {
        public IUserLogicClient UserClient { get; set; }
        public ITFSettingsLogicClient SettingsClient { get; set; }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CheckForAdminRegistration(string email)
        {
            var canEmailBeUsed = await UserClient.CanEmailBeUsedAsProfessionalAsync(email, null);
            var commonSettings = (await SettingsClient.GetSettingsAsync()).AsSettings<CommonSettings>();

            if (!canEmailBeUsed)
                return Json(string.Format("The email address is already registered in Safe Move Scheme. Call us at {0} if this concerns you.", commonSettings.SupportTelephoneNumber), JsonRequestBehavior.AllowGet);
            else
                return Json("true", JsonRequestBehavior.AllowGet);
        }
    }
}