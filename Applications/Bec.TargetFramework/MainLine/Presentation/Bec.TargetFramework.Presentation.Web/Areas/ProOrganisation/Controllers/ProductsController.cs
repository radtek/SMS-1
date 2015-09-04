using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
using Bec.TargetFramework.Presentation.Web.Helpers;
using Bec.TargetFramework.Presentation.Web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

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

        [ClaimsRequired("Add", "SmsTransaction", Order = 1001)]
        public ActionResult ViewAddSmsTransaction()
        {
            return PartialView("_AddSmsTransaction");
        }

        [HttpPost]
        [ClaimsRequired("Add", "SmsTransaction", Order = 1001)]
        public async Task<ActionResult> AddSmsTransaction(AddSmsTransactionDTO addSmsTransactionDto)
        {
            var orgID = HttpContext.GetWebUserObject().OrganisationID;
            var uaoID = HttpContext.GetWebUserObject().UaoID;

            var prod = await prodClient.GetBankAccountCheckProductAsync();
            var crAccount = await orgClient.GetCreditAccountAsync(orgID);
            if (crAccount.Balance < prod.CurrentDetail.Price) return Json(new
            {
                result = false,
                title = "Purchase Failed",
                message = "Insufficient credit. Please top up and retry.",
                buyerUaoID = addSmsTransactionDto.BuyerUaoId
            }, JsonRequestBehavior.AllowGet);

            try
            {
                if (addSmsTransactionDto.BuyerUaoId == null)
                {
                    addSmsTransactionDto.BuyerUaoId = await orgClient.AddSmsClientAsync(orgID, uaoID, addSmsTransactionDto.Salutation, addSmsTransactionDto.FirstName, addSmsTransactionDto.LastName, addSmsTransactionDto.Email, addSmsTransactionDto.BirthDate.Value);
                }
                var transactionId = await orgClient.PurchaseProductAsync(orgID, uaoID, addSmsTransactionDto.BuyerUaoId.Value, prod.ProductID, prod.ProductVersionID, addSmsTransactionDto.SmsTransactionDTO);

                var assignSmsClientToTransactionDto = new AssignSmsClientToTransactionDTO
                {
                    UaoId = addSmsTransactionDto.BuyerUaoId.Value,
                    TransactionId = transactionId,
                    Line1 = addSmsTransactionDto.Line1,
                    Line2 = addSmsTransactionDto.Line2,
                    County = addSmsTransactionDto.County,
                    AdditionalAddressInformation = addSmsTransactionDto.AdditionalAddressInformation,
                    PostalCode = addSmsTransactionDto.PostalCode,
                    Town = addSmsTransactionDto.Town,
                    Manual = addSmsTransactionDto.Manual,
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
                    buyerUaoID = addSmsTransactionDto.BuyerUaoId
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}