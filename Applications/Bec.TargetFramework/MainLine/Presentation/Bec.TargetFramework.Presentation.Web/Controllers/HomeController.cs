using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Settings;
using Bec.TargetFramework.Business.Client.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Controllers
{
    public class HomeController : Controller
    {
        public ITFSettingsLogicClient SettingsClient { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult ThreatsExplained()
        {
            return View();
        }

        public ActionResult BuyersAtRisk()
        {
            return View();
        }

        public async Task<ActionResult> ConveyancingFirmFaq()
        {
            var commonSettings = (await SettingsClient.GetSettingsAsync()).AsSettings<CommonSettings>();
            ViewBag.SupportTelephoneNumber = commonSettings.SupportTelephoneNumber;

            return View();
        }

        public ActionResult ConveyancersAtRisk()
        {
            return View();
        }

        public ActionResult HowItWorks()
        {
            return View();
        }

        public ActionResult SafeBuyerSpecification()
        {
            return View();
        }

        public ActionResult SafeBuyerProduct()
        {
            return View();
        }

        public ActionResult HowTheSmsHelpsLenders()
        {
            return View();
        }

        public ActionResult FreeTrial()
        {
            return View();
        }

        public ActionResult SafeMoveSchemeBenefits()
        {
            return View();
        }

        public ActionResult HowTheSMSHelpsConveyancingFirms()
        {
            return View();
        }

        public ActionResult ConveyancersCompliance()
        {
            return View();
        }

        public ActionResult LendersCompliance()
        {
            return View();
        }

        public ActionResult ConveyancingFirmRegistration()
        {
            return View();
        }

        public ActionResult MortgageBrokerRegistration()
        {
            return View();
        }

        public ActionResult ForThePublicIntroduction()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult TutorialsForProfessionals()
        {
            return View();
        }

        public ActionResult TutorialsForPublic()
        {
            return View();
        }

        public ActionResult HowToKeepConsumersSafe()
        {
            return View();
        }
    }
}