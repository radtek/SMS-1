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
using System.Linq;
using System.Collections.Generic;
using System.Net;
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
        public IBankAccountLogicClient BankAccountClient { get; set; }

        public async Task<ActionResult> Index()
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            ViewBag.HasOrganisationAnySafeBankAccounts = BankAccountClient.HasOrganisationAnySafeBankAccount(orgID);
            var select = ODataHelper.Select<VOrganisationWithStatusAndAdminDTO>(x => new { x.Name, x.OrganisationAdminSalutation, x.OrganisationAdminFirstName, x.OrganisationAdminLastName });
            var filter = ODataHelper.Filter<VOrganisationWithStatusAndAdminDTO>(x => x.OrganisationID == orgID);
            var orgs = await queryClient.QueryAsync<VOrganisationWithStatusAndAdminDTO>("VOrganisationWithStatusAndAdmins", select + filter);
            var org = orgs.First();
            ViewBag.OrganisationName = org.Name;
            ViewBag.OrgAdminName = string.Join(" ", org.OrganisationAdminSalutation, org.OrganisationAdminFirstName, org.OrganisationAdminLastName);
            return View();
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
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            var hasOrganisationAnySafeBankAccounts = BankAccountClient.HasOrganisationAnySafeBankAccount(orgID);
            if (!hasOrganisationAnySafeBankAccounts)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            return PartialView("_AddSmsTransaction");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
                buyerUaoID = addSmsTransactionDto.BuyerUaoID
            }, JsonRequestBehavior.AllowGet);

            try
            {
                if (addSmsTransactionDto.BuyerUaoID == null)
                {
                    addSmsTransactionDto.BuyerUaoID = await orgClient.AddSmsClientAsync(orgID, uaoID, addSmsTransactionDto.Salutation, addSmsTransactionDto.FirstName, addSmsTransactionDto.LastName, addSmsTransactionDto.Email, addSmsTransactionDto.BirthDate.Value);
                }
                var transactionID = await orgClient.PurchaseProductAsync(orgID, uaoID, addSmsTransactionDto.BuyerUaoID.Value, prod.ProductID, prod.ProductVersionID, addSmsTransactionDto.SmsTransactionDTO);

                var assignSmsClientToTransactionDto = new AssignSmsClientToTransactionDTO
                {
                    UaoID = addSmsTransactionDto.BuyerUaoID.Value,
                    TransactionID = transactionID,
                    AssigningByOrganisationID = orgID,
                    UserAccountOrganisationTransactionType = UserAccountOrganisationTransactionType.Buyer
                };

                await orgClient.AssignSmsClientToTransactionAsync(assignSmsClientToTransactionDto);

                TempData["SmsTransactionID"] = transactionID;
                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    result = false,
                    title = "Purchase Failed",
                    message = ex.Message,
                    buyerUaoID = addSmsTransactionDto.BuyerUaoID
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}