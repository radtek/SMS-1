using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
using Bec.TargetFramework.Presentation.Web.Models;
using Bec.TargetFramework.Presentation.Web.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Bec.TargetFramework.Entities.Enums;

namespace Bec.TargetFramework.Presentation.Web.Areas.ProOrganisation.Controllers
{
    [ClaimsRequired("View", "Products", Order = 1000)]
    public class ProductsController : ApplicationControllerBase
    {
        public IOrganisationLogicClient orgClient { get; set; }
        public IProductLogicClient prodClient { get; set; }
        public IQueryLogicClient queryClient { get; set; }
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
        public async Task<ActionResult> SearchLenders(string search)
        {
            search = search.ToLower();
            if (string.IsNullOrWhiteSpace(search)) return null;

            var select = ODataHelper.Select<LenderDTO>(x => new { x.Name });
            var filter = ODataHelper.Filter<LenderDTO>(x => x.Name.ToLower().Contains(search));
            JObject res = await queryClient.QueryAsync("Lenders", select + filter);
            return Content(res.ToString(Formatting.None), "application/json");
        }

        [ClaimsRequired("Add", "SmsTransaction", Order = 1001)]
        public async Task<ActionResult> CheckDuplicateUserSmsTransaction(SmsTransactionDTO dto, string email)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            if (await orgClient.CheckDuplicateUserSmsTransactionAsync(orgID, email, dto))
            {
                ViewBag.title = "Warning";
                ViewBag.message = "A property transaction already exists for this user at this address. Are you sure that you wish to continue?";
                ViewBag.Buttons = new List<ButtonDefinition>
                {
                    new ButtonDefinition
                    {
                        Id = "cancel",
                        Classes = "btn-default",
                        Text = "Cancel"
                    },
                    new ButtonDefinition
                    {
                        Id = "save",
                        Classes = "btn-primary",
                        Text = "Continue"
                    }
                };
                return PartialView("_Message");
            }
            return Json(new { result = "ok" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ClaimsRequired("Add", "SmsTransaction", Order = 1001)]
        public async Task<ActionResult> AddSmsTransaction(SmsTransactionDTO dto, Guid? buyerUaoID, string salutation, string firstName, string lastName, string email)
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
                if (buyerUaoID == null) buyerUaoID = await orgClient.AddSmsClientAsync(orgID, uaoID, salutation, firstName, lastName, email);
                var transactionId = await orgClient.PurchaseProductAsync(orgID, uaoID, buyerUaoID.Value, prod.ProductID, prod.ProductVersionID, dto);

                var assignSmsClientToTransactionDto = new AssignSmsClientToTransactionDTO
                {
                    UaoId = buyerUaoID.Value,
                    TransactionId = transactionId,
                    Line1 = "N/A",
                    Line2 = "N/A",
                    County = "N/A",
                    AdditionalAddressInformation = "N/A",
                    PostalCode = "N/A",
                    Town = "N/A",
                    Manual = false,
                    UserAccountOrganisationTransactionType = UserAccountOrganisationTransactionType.Buyer
                };

                await orgClient.AssignSmsClientToTransactionAsync(assignSmsClientToTransactionDto);

                TempData["SmsTransactionID"] = transactionId;
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