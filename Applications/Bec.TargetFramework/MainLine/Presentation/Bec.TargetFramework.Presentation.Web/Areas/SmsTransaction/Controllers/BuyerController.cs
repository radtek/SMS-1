using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Presentation.Web.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.SmsTransaction.Controllers
{
    public class BuyerController : ApplicationControllerBase
    {
        public IOrganisationLogicClient orgClient { get; set; }
        public IQueryLogicClient queryClient { get; set; }
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetSmsTransactions(string search)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            string extraFilter = "";
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToLower();
                extraFilter = string.Format(" and(contains(tolower(Reference), '{0}') or contains(tolower(Address/Line1), '{0}') or contains(tolower(Address/PostalCode), '{0}'))", search);
            }
            JObject res = await queryClient.GetAsync("SmsTransactions", Request.QueryString + string.Format("&$select=Reference,Price,CreatedOn&$expand=Address($select=Line1,PostalCode)&$filter=OrganisationID eq {0}" , orgID) + extraFilter);
            return Content(res.ToString(Formatting.None), "application/json");
        }

        public ActionResult ViewAddSmsTransaction()
        {
            return PartialView("_AddSmsTransaction");
        }

        [HttpPost]
        public async Task<ActionResult> AddSmsTransaction(SmsTransactionDTO dto)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            TempData["SmsTransactionID"] = await orgClient.AddSmsTransactionAsync(orgID, dto);
            return RedirectToAction("Index");
        }

        public ActionResult ViewPurchase(Guid smsTransactionID)
        {
            ViewBag.SmsTransactionID = smsTransactionID;
            return PartialView("_Purchase");
        }

        [HttpPost]
        public ActionResult Purchase(Guid smsTransactionID, string product)
        {
            //todo: attempt purchase
            var jsonData = new
            {
                result = false,
                title = "Unable to purchase product",
                message = "There is not enough credit to purchase this product. Please top-up the credit balance."
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}