using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

            var select = ODataHelper.Select<SmsTransactionDTO>(x => new { x.Reference, x.Price, x.CreatedOn, x.Address.Line1, x.Address.PostalCode, x.SmsTransactionID });

            var where = ODataHelper.Expression<SmsTransactionDTO>(x => x.OrganisationID == orgID);

            if (!string.IsNullOrEmpty(search))
            {
                where = Expression.And(where, ODataHelper.Expression<SmsTransactionDTO>(x =>
                    x.Reference.ToLower().Contains(search) ||
                    x.Address.Line1.ToLower().Contains(search) ||
                    x.Address.PostalCode.ToLower().Contains(search)
                    ));
            }
            var filter = ODataHelper.Filter(where);

            JObject res = await queryClient.QueryAsync("SmsTransactions", Request.QueryString + select + filter);
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