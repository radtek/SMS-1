using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Presentation.Web.Base;
using System.Threading.Tasks;
using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Presentation.Web.Helpers;

namespace Bec.TargetFramework.Presentation.Web.Controllers
{
    public class HomeController : ApplicationControllerBase
    {
        public IAddressLogicClient AddressClient { get; set; }
        public IQueryLogicClient queryClient { get; set; }
        public HomeController()
        {
        }

        public async Task<ActionResult> Index()
        {
            var uaoID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            var select = ODataHelper.Select<SmsTransactionDTO>(x => new { x.OrganisationID, Names = x.Organisation.OrganisationDetails.Select(y => new { y.Name }) });
            var filter = ODataHelper.Filter<SmsTransactionDTO>(x => x.UserAccountOrganisationID == uaoID);
            var data = await queryClient.QueryAsync<SmsTransactionDTO>("SmsTransactions", select + filter);
            return View(data);
        }

        public ActionResult Denied()
        {
            return View("Denied");
        }


        public ActionResult ViewCancel()
        {
            return PartialView("_Cancel");
        }

        public ActionResult ViewMessage(string title, string message, string button)
        {
            ViewBag.title = title;
            ViewBag.message = message;
            ViewBag.button = button;
            return PartialView("_Message");
        }

        public ActionResult ViewResendLogins(Guid uaoId, string label, string redirectAction, string redirectController, string redirectArea)
        {
            ViewBag.orgId = uaoId;
            ViewBag.label = label;
            ViewBag.RedirectAction = redirectAction;
            ViewBag.RedirectController = redirectController;
            ViewBag.RedirectArea = redirectArea;
            return PartialView("_ResendLogins");
        }

        public async Task<ActionResult> FindAddress(string postcode)
        {
            var list = await AddressClient.FindAddressesByPostCodeAsync(postcode, null);

            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}