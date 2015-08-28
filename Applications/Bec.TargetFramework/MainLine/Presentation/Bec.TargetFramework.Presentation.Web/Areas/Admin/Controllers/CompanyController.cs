using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Presentation.Web.Base;
using JSM;
using JSM.MVC4;
using ServiceStack.ServiceHost;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Business.Client.Interfaces;
using System.Threading.Tasks;
using Bec.TargetFramework.Presentation.Web.Filters;
using Bec.TargetFramework.Presentation.Web.Helpers;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    [ClaimsRequired("Add", "Company", Order = 1000)]
    public class CompanyController : ApplicationControllerBase, IJavaScriptModelAware
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

        public ActionResult ViewAddTempCompany()
        {
            return PartialView("_AddTempCompany");
        }

        [HttpPost]
        public async Task<ActionResult> AddTempCompany(AddCompanyDTO model)
        {
            if (ModelState.IsValid)
            {
                var id = await OrganisationClient.AddNewUnverifiedOrganisationAndAdministratorAsync(OrganisationTypeEnum.Conveyancing, model);

                TempData["AddTempCompanyId"] = id;
            }

            return RedirectToAction("Provisional");
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
        public async Task<ActionResult> GeneratePin(Guid orgId, Guid uaoId, string notes)
        {
            await UserLogicClient.GeneratePinAsync(uaoId, false);
            
            //set org status
            await OrganisationClient.AddOrganisationStatusAsync(orgId, StatusTypeEnum.ProfessionalOrganisation, ProfessionalOrganisationStatusEnum.Verified, null, notes);

            TempData["VerifiedCompanyId"] = orgId;
            TempData["tabIndex"] = 1;
            return RedirectToAction("Provisional");
        }

        public async Task<ActionResult> ViewDuplicates(string CompanyName, string PostalCode)
        {
            var list = await OrganisationClient.FindDuplicateOrganisationsAsync(CompanyName, PostalCode);
            if (list.Count > 0)
                return PartialView("_Duplicates", list);
            else
                return Json(new { result = "ok" }, JsonRequestBehavior.AllowGet);
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
            var res = await queryClient.QueryAsync<OrganisationDTO>("Organisations", Request.QueryString + select + filter);
            return PartialView("_EditCompany", Edit.MakeModel(res.First()));
        }

        [HttpPost]
        public async Task<ActionResult> EditCompany(Guid orgID)
        {
            var filter = ODataHelper.Filter<OrganisationDTO>(x => x.OrganisationID == orgID);
            var data = Edit.fromD(Request.Form);
            await queryClient.UpdateGraphAsync("Organisations", data, filter);
            return RedirectToAction("Qualified");
        }
    }
}