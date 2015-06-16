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

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    [ClaimsRequired("Add", "Company", Order = 1000)]
    public class CompanyController : ApplicationControllerBase, IJavaScriptModelAware
    {
        private IOrganisationLogicClient m_OrganisationClient;
        IAddressLogicClient m_AddressClient;
        INotificationLogicClient m_NotificationClient;

        public CompanyController(ILogger logger, IOrganisationLogicClient oClient, IAddressLogicClient aClient, INotificationLogicClient nClient)
            : base(logger)
        {
            m_OrganisationClient = oClient;
            m_AddressClient = aClient;
            m_NotificationClient = nClient;
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
            List<VOrganisationWithStatusAndAdminDTO> list = await m_OrganisationClient.GetCompaniesAsync(orgStatus);

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
                var id = await m_OrganisationClient.AddNewUnverifiedOrganisationAndAdministratorAsync(OrganisationTypeEnum.Conveyancing, model);

                TempData["AddTempCompanyId"] = id;
            }

            return RedirectToAction("Provisional");
        }

        public async Task<ActionResult> FindAddress(string postcode)
        {
            List<PostCodeDTO> list = await m_AddressClient.FindAddressesByPostCodeAsync(postcode, null);

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> ViewRejectTempCompany(Guid orgId)
        {
            var org = await m_OrganisationClient.GetOrganisationDTOAsync(orgId);
            if (org == null) return new HttpNotFoundResult("Organisation not found");
            ViewBag.orgId = orgId;
            ViewBag.companyName = org.Name;
            return PartialView("_RejectTempCompany");
        }

        [HttpPost]
        public async Task<ActionResult> RejectTempCompany(RejectCompanyDTO model)
        {
            await m_OrganisationClient.RejectOrganisationAsync(model);
            return RedirectToAction("Provisional");
        }

        public async Task<ActionResult> ViewGeneratePin(Guid orgId)
        {
            var org = await m_OrganisationClient.GetOrganisationDTOAsync(orgId);
            if (org == null) return new HttpNotFoundResult("Organisation not found");
            ViewBag.orgId = orgId;
            ViewBag.companyName = org.Name;
            return PartialView("_GeneratePin");
        }

        [HttpPost]
        public async Task<ActionResult> GeneratePin(GeneratePinDTO model)
        {
            await m_OrganisationClient.GeneratePinAsync(model);

            TempData["VerifiedCompanyId"] = model.OrganisationId;
            TempData["tabIndex"] = 1;
            return RedirectToAction("Provisional");
        }

        public async Task<ActionResult> ViewDuplicates(bool Manual, string Line1, string Line2, string Town, string County, string PostalCode)
        {
            var list = await m_OrganisationClient.FindDuplicateOrganisationsAsync(Manual, Line1, Line2, Town, County, PostalCode);
            if (list.Count > 0)
                return PartialView("_Duplicates", list);
            else
                return Json(new { result = "ok" }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> ViewResendLogins(Guid orgId)
        {
            var org = await m_OrganisationClient.GetOrganisationDTOAsync(orgId);
            if (org == null) return new HttpNotFoundResult("Organisation not found");
            ViewBag.orgId = orgId;
            ViewBag.companyName = org.Name;
            return PartialView("_ResendLogins");
        }

        [HttpPost]
        public async Task<ActionResult> ResendLogins(Guid orgId)
        {
            await m_OrganisationClient.ResendLoginsAsync(orgId);

            TempData["VerifiedCompanyId"] = orgId;
            TempData["tabIndex"] = 1;
            return RedirectToAction("Provisional");
        }

        public async Task<ActionResult> ViewEmailLog(Guid orgId)
        {
            return PartialView("_EmailLog", await m_NotificationClient.GetEventStatusAsync("TestEvent", orgId.ToString()));
        }
    }
}