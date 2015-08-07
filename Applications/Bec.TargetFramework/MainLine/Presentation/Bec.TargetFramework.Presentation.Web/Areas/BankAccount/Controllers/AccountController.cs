using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
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

namespace Bec.TargetFramework.Presentation.Web.Areas.BankAccount.Controllers
{
    [ClaimsRequired("View", "BankAccount", Order = 1000)]
    public class AccountController : ApplicationControllerBase
    {
        public IOrganisationLogicClient orgClient { get; set; }
        public IQueryLogicClient queryClient { get; set; }

        public ActionResult Index(Guid selectedBankAccountId, bool? showmessage)
        {
            ViewBag.showmessage = showmessage;
            return View();
        }

        public async Task<ActionResult> GetBankAccounts()
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            //var select = ODataHelper.Select<OrganisationBankAccountDTO>(x => new { x.OrganisationBankAccountID, x.BankAccountNumber, x.SortCode, x.Created });
            //var filter = ODataHelper.Filter<OrganisationBankAccountDTO>(x => x.OrganisationID == orgID);

            //JObject res = await queryClient.QueryAsync("OrganisationBankAccounts", Request.QueryString + select + filter);
            //return Content(res.ToString(Formatting.None), "application/json");

            var list = await orgClient.GetOrganisationBankAccountsAsync(orgID);
            
            var jsonData = new { total = list.Count, list };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewAddBankAccount()
        {
            return PartialView("_AddBankAccount");
        }

        [HttpPost]
        [ClaimsRequired("Add", "BankAccount", Order = 1000)]
        public async Task<ActionResult> AddBankAccount(OrganisationBankAccountDTO dto)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            TempData["OrganisationBankAccountID"] = await orgClient.AddBankAccountAsync(orgID, dto);
            return RedirectToAction("Index", new { showmessage = true });
        }

        public ActionResult ViewStatus(Guid baID, string title, string message, BankAccountStatusEnum status, bool? includeNotes)
        {
            ViewBag.OrganisationBankAccountID = baID;
            ViewBag.title = title;
            ViewBag.message = message;
            ViewBag.status = status;
            ViewBag.includeNotes = includeNotes;
            ViewBag.action = "AddStatus";
            ViewBag.controller = "Account";
            ViewBag.area = "BankAccount";
            return PartialView("_AddStatus");
        }

        [HttpPost]
        public async Task<ActionResult> AddStatus(Guid baID, BankAccountStatusEnum status, string notes)
        {
            var currentUser = WebUserHelper.GetWebUserObject(HttpContext);
            var orgID = currentUser.OrganisationID;

            var bankAccountStateChangeDto = new OrganisationBankAccountStateChangeDTO
            {
                OrganisationID = orgID,
                BankAccountID = baID,
                BankAccountStatus = status,
                Notes = notes,
                ChangedByUserAccountOrganisationID = currentUser.UaoID,
                DetailsUrl = Url.Action("Index", "Account", new { area = "BankAccount" }, Request.Url.Scheme)
            };

            await orgClient.AddBankAccountStatusAsync(bankAccountStateChangeDto);
            TempData["OrganisationBankAccountID"] = baID;
            return RedirectToAction("Index");
        }

        public ActionResult ViewToggleActive(Guid baID, string title, string message, bool isactive)
        {
            ViewBag.OrganisationBankAccountID = baID;
            ViewBag.title = title;
            ViewBag.message = message;
            ViewBag.isactive = isactive;
            ViewBag.action = "ToggleActive";
            ViewBag.controller = "Account";
            ViewBag.area = "BankAccount";
            return PartialView("_AddStatus");
        }
        [HttpPost]
        public async Task<ActionResult> ToggleActive(Guid baID, bool isactive)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            await orgClient.ToggleBankAccountActiveAsync(orgID, baID, isactive);
            TempData["OrganisationBankAccountID"] = baID;
            return RedirectToAction("Index");
        }
    }
}