using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
using Bec.TargetFramework.Presentation.Web.Helpers;
using Newtonsoft.Json.Linq;
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

        public async Task<ActionResult> ViewVerify(Guid orgId)
        {
            var org = await OrganisationClient.GetOrganisationWithStatusAndAdminAsync(orgId);
            if (org == null) return new HttpNotFoundResult("Organisation not found");
            ViewBag.orgId = orgId;
            ViewBag.companyName = org.Name;
            ViewBag.regNumber = org.RegulatorNumber;
            return PartialView("_Verify");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Verify(Guid orgId, string notes, string name, int filesPerMonth, string regulatorNumber)
        {
            //set org status
            await OrganisationClient.AddOrganisationStatusAsync(orgId, StatusTypeEnum.ProfessionalOrganisation, ProfessionalOrganisationStatusEnum.Verified, null, notes);
            await OrganisationClient.VerifyOrganisationAsync(orgId, name, filesPerMonth, regulatorNumber);

            TempData["VerifiedCompanyId"] = orgId;
            TempData["tabIndex"] = 1;
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
        public async Task<ActionResult> GeneratePin(Guid orgId, Guid uaoId)
        {
            await UserLogicClient.GeneratePinAsync(uaoId, false, true, false);

            TempData["VerifiedCompanyId"] = orgId;
            TempData["tabIndex"] = 1;
            return RedirectToAction("Provisional");
        }

        // todo: ZM ucomment when enable login comes back to life
        //public async Task<ActionResult> ViewEditCompany(Guid orgID)
        //{
        //    ViewBag.orgID = orgID;
        //    var select = ODataHelper.Select<OrganisationDTO>(x => new { x.OrganisationID, x.IsActive }, true);
        //    var filter = ODataHelper.Filter<OrganisationDTO>(x => x.OrganisationID == orgID);
        //    var res = await queryClient.QueryAsync<OrganisationDTO>("Organisations", select + filter);
        //    return PartialView("_EditCompany", Edit.MakeModel(res.First()));
        //}

        // todo: ZM ucomment when enable login comes back to life
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditCompany(Guid orgID)
        //{
        //    var filter = ODataHelper.Filter<OrganisationDTO>(x => x.OrganisationID == orgID);
        //    var data = Edit.fromD(Request.Form,
        //        "IsActive",
        //        "RowVersion");
        //    await queryClient.UpdateGraphAsync("Organisations", data, filter);
        //    return RedirectToAction("Qualified");
        //}
    }
}