using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Controllers
{
    public class HomeController : Controller
    {
        public ISMHLogicClient smhClient { get; set; }
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

        public ActionResult FreeTrial()
        {
            return View();
        }

        public ActionResult SafeMoveSchemeBenefits()
        {
            return View();
        }

        public ActionResult NewAMLSolution()
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

        public ActionResult ForThePublic()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public async Task<ActionResult> GetSMHItemOnPage(string pageUrl)
        {
            var currentUser = WebUserHelper.GetWebUserObject(HttpContext);
            var list = await smhClient.GetItemOnPageForCurrentUserAsync(currentUser.UaoID, currentUser.OrganisationID, pageUrl);
            var res = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(list, Formatting.None));

            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
        }

    }
}