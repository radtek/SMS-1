using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Presentation.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.ProOrganisation.Controllers
{
    [ClaimsRequired("View", "Products", Order = 1000)]
    public class ProductsController : Controller
    {
        public IOrganisationLogicClient orgClient { get; set; }
        public IProductLogicClient prodClient { get; set; }
        // GET: ProOrganisation/Products
        public ActionResult Index()
        {
            return View();
        }

        [ClaimsRequired("Add", "SmsTransaction", Order = 1001)]
        public ActionResult ViewAddSmsTransaction()
        {
            return PartialView("_AddSmsTransaction");
        }
        [ClaimsRequired("Add", "SmsTransaction", Order = 1001)]
        public async Task<ActionResult> CheckDuplicateUserSmsTransaction(SmsTransactionDTO dto, string email)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            if (await orgClient.CheckDuplicateUserSmsTransactionAsync(orgID, email, dto))
            {
                ViewBag.title = "Warning";
                ViewBag.message = "A property transaction already exists for this user at this address. Are you sure that you wish to continue?";
                ViewBag.Buttons = new List<Tuple<string,string>> { Tuple.Create("save", "Continue" ), Tuple.Create("cancel", "Cancel" ) };
                return PartialView("_Message");
            }
            return Json(new { result = "ok" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ClaimsRequired("Add", "SmsTransaction", Order = 1001)]
        public async Task<ActionResult> AddSmsTransaction(SmsTransactionDTO dto, Guid? buyerUaoID, string firstName, string lastName, string email)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            var uaoID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;

            var prod = await prodClient.GetBankAccountCheckProductAsync();
            var crAccount = await orgClient.GetCreditAccountAsync(orgID);
            if (crAccount.Balance < prod.CurrentDetail.Price) return Json(new
            {
                result = false,
                title = "Purchase Failed",
                message = "Insufficient credit. Please top up and retry.",
                buyerUaoID = buyerUaoID
            }, JsonRequestBehavior.AllowGet);

            try
            {
                if (buyerUaoID == null) buyerUaoID = await orgClient.AddSmsClientAsync(orgID, uaoID, firstName, lastName, email);
                TempData["SmsTransactionID"] = await orgClient.PurchaseProductAsync(orgID, uaoID, buyerUaoID.Value, prod.ProductID, prod.ProductVersionID, dto);
                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    result = false,
                    title = "Purchase Failed",
                    message = ex.Message,
                    buyerUaoID = buyerUaoID
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}