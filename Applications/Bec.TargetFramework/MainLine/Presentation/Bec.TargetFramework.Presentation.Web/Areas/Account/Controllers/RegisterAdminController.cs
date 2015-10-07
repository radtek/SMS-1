using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Account.Controllers
{
    public class RegisterAdminController : Controller
    {
        public IOrganisationLogicClient OrganisationClient { get; set; }
        private readonly CaptchaService _captchaService;
        public RegisterAdminController()
        {
            _captchaService = new CaptchaService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(AddCompanyDTO model)
        {
            var response = await _captchaService.ValidateCaptcha(Request);
            if (ModelState.IsValid && response.success)
            {
                await OrganisationClient.AddNewUnverifiedOrganisationAndAdministratorAsync(OrganisationTypeEnum.Conveyancing, model);
                return RedirectToAction("RegistrationSuccess");
            }

            return View(model);
        }

        public ActionResult RegistrationSuccess()
        {
            return View();
        }
    }
}