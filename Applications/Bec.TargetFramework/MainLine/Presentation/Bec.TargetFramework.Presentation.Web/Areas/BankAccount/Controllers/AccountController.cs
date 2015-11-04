using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
using Bec.TargetFramework.Presentation.Web.Helpers;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.BankAccount.Controllers
{
    [ClaimsRequired("View", "BankAccount", Order = 1000)]
    public class AccountController : ApplicationControllerBase
    {
        public IOrganisationLogicClient orgClient { get; set; }
        public IQueryLogicClient queryClient { get; set; }
        public INotificationLogicClient nClient { get; set; }

        public ActionResult Index(Guid? selectedBankAccountId)
        {
            //don't overwrite what already might be in TempData...
            if (selectedBankAccountId.HasValue) TempData["OrganisationBankAccountID"] = selectedBankAccountId;
            return View();
        }

        public async Task<ActionResult> GetBankAccounts()
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            var list = await orgClient.GetOrganisationBankAccountsAsync(orgID);
            
            var jsonData = new { total = list.Count, list };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewAddBankAccount()
        {
            return PartialView("_AddBankAccount");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ClaimsRequired("Add", "BankAccount", Order = 1000)]
        public async Task<ActionResult> AddBankAccount(OrganisationBankAccountDTO dto)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            TempData["OrganisationBankAccountID"] = await orgClient.AddBankAccountAsync(orgID, dto);
            TempData["ShowMessage"] = true;
            return RedirectToAction("Index");
        }

        public ActionResult ViewStatus(Guid baID, string title, string message, BankAccountStatusEnum status)
        {
            ViewBag.OrganisationBankAccountID = baID;
            ViewBag.title = title;
            ViewBag.message = message;
            ViewBag.status = status;
            ViewBag.action = "AddStatus";
            ViewBag.controller = "Account";
            ViewBag.area = "BankAccount";
            return PartialView("_AddStatus");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddStatus(Guid baID, BankAccountStatusEnum status, string notes)
        {
            var currentUser = WebUserHelper.GetWebUserObject(HttpContext);
            var orgID = currentUser.OrganisationID;

            var bankAccountStateChangeDto = new OrganisationBankAccountStateChangeDTO
            {
                RequestedByOrganisationID = orgID,
                BankAccountID = baID,
                BankAccountStatus = status,
                Notes = notes,
                KillDuplicates = false,
                ChangedByUserAccountOrganisationID = currentUser.UaoID,
                DetailsUrl = Url.Action("Index", "Account", new { area = "BankAccount", selectedBankAccountId = baID }, Request.Url.Scheme)
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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ToggleActive(Guid baID, bool isactive, string notes)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            await orgClient.ToggleBankAccountActiveAsync(orgID, baID, isactive, notes);
            TempData["OrganisationBankAccountID"] = baID;
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> CheckBankAccount(string accountNumber, string sortCode)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            var select = ODataHelper.Select<OrganisationBankAccountDTO>(x => new { x.OrganisationBankAccountID });
            var filter = ODataHelper.Filter<OrganisationBankAccountDTO>(x => x.OrganisationID == orgID && x.BankAccountNumber == accountNumber && x.SortCode == sortCode);
            var accounts = await queryClient.QueryAsync<OrganisationBankAccountDTO>("OrganisationBankAccounts", select + filter);

            if (accounts.Any())
                return Json("This account number and sort code have already been entered", JsonRequestBehavior.AllowGet);
            else
                return Json("true", JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> DownloadCertificate(Guid baID)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            var name = NotificationConstructEnum.BankAccountCertificate.GetStringValue();

            if (!await BankAccountIsSafeAndActive(baID)) throw new Exception("A certificate can only produced for bank accounts which are active and marked safe");

            var select = ODataHelper.Select<OrganisationBankAccountDTO>(x => new
            {
                x.OrganisationBankAccountID,
                x.BankAccountNumber,
                x.SortCode,
                x.Name,
                x.Address,
                x.Organisation.SchemeID,
                x.Organisation.CreatedOn,
                Names = x.Organisation.OrganisationDetails.Select(y => new { y.Name })
            });
            var filter = ODataHelper.Filter<OrganisationBankAccountDTO>(x => x.OrganisationID == orgID && x.OrganisationBankAccountID == baID);
            var accounts = await queryClient.QueryAsync<OrganisationBankAccountDTO>("OrganisationBankAccounts", select + filter);
            var ba = accounts.Single();

            var ncSelect = ODataHelper.Select<NotificationConstructDTO>(x => new { x.NotificationConstructID, x.NotificationConstructVersionNumber });
            var ncFilter = ODataHelper.Filter<NotificationConstructDTO>(x => x.Name == name);
            var ncs = await queryClient.QueryAsync<NotificationConstructDTO>("NotificationConstructs", ncSelect + ncFilter);
            var nc = ncs.Single();

            var dtomap = new DTOMap();
            dtomap.Add("CertificateDetailsDTO", new CertificateDetailsDTO
            {
                OrganisationName = ba.Organisation.OrganisationDetails.First().Name,
                SchemeID = ba.Organisation.SchemeID ?? 0,
                StartDate = ba.Organisation.CreatedOn.ToLongDateString(),
                BankAccountName = string.IsNullOrEmpty(ba.Name) ? "Not supplied" : ba.Name,
                BankAddress = string.IsNullOrEmpty(ba.Address) ? "Not supplied" : threeLines(ba.Address),
                AccountNumber = ba.BankAccountNumber,
                SortCode = ba.SortCode
            });
            dtomap.Add("NotificationSettingDTO", new NotificationSettingDTO());

            var data = await nClient.RetrieveNotificationConstructDataAsync(nc.NotificationConstructID, nc.NotificationConstructVersionNumber, dtomap);

            return File(data, "application/pdf", string.Format("BankAccountCertificate.pdf"));
        }

        private string threeLines(string s)
        {
            var bits = s.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            if (bits.Length > 3)
                return string.Join(Environment.NewLine, bits[0], bits[1], string.Join(", ", bits.Skip(2)));
            else
                return string.Join(Environment.NewLine, bits);
        }

        private async Task<bool> BankAccountIsSafeAndActive(Guid baID)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;

            var select = ODataHelper.Select<OrganisationBankAccountStatusDTO>(x => new { x.StatusTypeValue.Name, x.WasActive });
            var filter = ODataHelper.Filter<OrganisationBankAccountStatusDTO>(x => x.OrganisationBankAccountID == baID && x.OrganisationBankAccount.OrganisationID == orgID);
            var order = ODataHelper.OrderBy<OrganisationBankAccountStatusDTO>(x => new { x.StatusChangedOn });
            var recs = await queryClient.QueryAsync<OrganisationBankAccountStatusDTO>("OrganisationBankAccountStatus", select + filter + order);
            var s = recs.Last();
            return s.WasActive && s.StatusTypeValue.Name == BankAccountStatusEnum.Safe.GetStringValue();
        }
    }
}