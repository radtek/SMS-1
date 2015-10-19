using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
using Bec.TargetFramework.Presentation.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    [ClaimsRequired("Add", "Company", Order = 1000)]
    public class CompanyController : ApplicationControllerBase
    {
        public IOrganisationLogicClient OrganisationClient { get; set; }
        public INotificationLogicClient NotificationClient { get; set; }
        public IUserLogicClient UserLogicClient { get; set; }
        public IQueryLogicClient queryClient { get; set; }

        public CompanyController()
        {
        }

        public ActionResult Provisional()
        {
            return View();
        }

        public ActionResult Qualified()
        {
            return View();
        }

        public async Task<ActionResult> LoadCompanies(ProfessionalOrganisationStatusEnum orgStatus)
        {
            List<VOrganisationWithStatusAndAdminDTO> list = await OrganisationClient.GetCompaniesAsync(orgStatus);

            var jsonData = new { total = list.Count, list };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> ViewRejectTempCompany(Guid orgId)
        {
            var org = await OrganisationClient.GetOrganisationDTOAsync(orgId);
            if (org == null) return new HttpNotFoundResult("Organisation not found");
            ViewBag.orgId = orgId;
            ViewBag.companyName = org.Name;
            return PartialView("_RejectTempCompany");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RejectTempCompany(RejectCompanyDTO model)
        {
            await OrganisationClient.RejectOrganisationAsync(model);
            return RedirectToAction("Provisional");
        }

        public async Task<ActionResult> ViewGeneratePin(Guid orgId, Guid uaoId)
        {
            var org = await OrganisationClient.GetOrganisationDTOAsync(orgId);
            if (org == null) return new HttpNotFoundResult("Organisation not found");
            ViewBag.orgId = orgId;
            ViewBag.uaoId = uaoId;
            ViewBag.companyName = org.Name;
            return PartialView("_GeneratePin");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> GeneratePin(Guid orgId, Guid uaoId, string notes)
        {
            await UserLogicClient.GeneratePinAsync(uaoId, false, false);
            //set org status
            await OrganisationClient.AddOrganisationStatusAsync(orgId, StatusTypeEnum.ProfessionalOrganisation, ProfessionalOrganisationStatusEnum.Verified, null, notes);

            TempData["VerifiedCompanyId"] = orgId;
            TempData["tabIndex"] = 1;
            return RedirectToAction("Provisional");
        }

        public ActionResult ViewResendLogins(Guid uaoId, string label)
        {
            ViewBag.uaoId = uaoId;
            ViewBag.label = label;
            ViewBag.RedirectAction = "ResendLogins";
            ViewBag.RedirectController = "Company";
            ViewBag.RedirectArea = "Admin";
            return PartialView("_ResendLogins");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResendLogins(Guid uaoId)
        {
            var uao = await UserLogicClient.ResendLoginsAsync(uaoId);

            TempData["VerifiedCompanyId"] = uao.OrganisationID;
            TempData["tabIndex"] = 1;
            return RedirectToAction("Provisional");
        }

        public async Task<ActionResult> ViewEmailLog(Guid orgId)
        {
            return PartialView("_EmailLog", await NotificationClient.GetEventStatusAsync("TestEvent", orgId.ToString()));
        }

        public async Task<ActionResult> ViewEditCompany(Guid orgID)
        {
            ViewBag.orgID = orgID;
            var select = ODataHelper.Select<OrganisationDTO>(x => new { x.OrganisationID, x.IsActive }, true);
            var filter = ODataHelper.Filter<OrganisationDTO>(x => x.OrganisationID == orgID);
            var res = await queryClient.QueryAsync<OrganisationDTO>("Organisations", select + filter);
            return PartialView("_EditCompany", Edit.MakeModel(res.First()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditCompany(Guid orgID)
        {
            var filter = ODataHelper.Filter<OrganisationDTO>(x => x.OrganisationID == orgID);
            var data = Edit.fromD(Request.Form,
                "IsActive",
                "RowVersion");
            await queryClient.UpdateGraphAsync("Organisations", data, filter);
            return RedirectToAction("Qualified");
        }
    }
}