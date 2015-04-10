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

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    public class TempCompanyController : ApplicationControllerBase, IJavaScriptModelAware
    {
        private IOrganisationLogicClient m_OrganisationClient;

        public TempCompanyController(ILogger logger,IOrganisationLogicClient oClient) : base(logger)
        {
            m_OrganisationClient = oClient;
        }

        // GET: Admin/TempCompany
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadCompanies(ProfessionalOrganisationStatusEnum orgStatus)
        {
            List<VOrganisationWithStatusAndAdminDTO> list =m_OrganisationClient.GetCompanies(orgStatus);

            var jsonData = new { total = list.Count, list };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewAddTempCompany()
        {
            return PartialView("_AddTempCompany");
        }

        [HttpPost]
        public ActionResult AddTempCompany(AddCompanyDTO model)
        {
            if (ModelState.IsValid)
            {
                var id = m_OrganisationClient.AddNewUnverifiedOrganisationAndAdministrator(OrganisationTypeEnum.Conveyancing, model);

                TempData["AddTempCompanyId"] = id;
            }

            return RedirectToAction("Index");
        }

        public ActionResult FindAddress(string postcode)
        {
            List<PostCodeDTO> list = m_OrganisationClient.FindAddressesByPostCode(postcode, null);

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ValidateAddress(bool Manual, string Line1, string Line2, string Town, string County, string PostalCode)
        {
            return Json(m_OrganisationClient.FindDuplicateOrganisations(Manual, Line1, Line2, Town, County, PostalCode), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewRejectTempCompany(Guid orgId)
        {
            var org = m_OrganisationClient.GetOrganisationDTO(orgId);
            if (org == null) return new HttpNotFoundResult("Organisation not found");
            ViewBag.orgId = orgId;
            ViewBag.companyName = org.Name;
            return PartialView("_RejectTempCompany");
        }

        [HttpPost]
        public ActionResult RejectTempCompany(RejectCompanyDTO model)
        {
            m_OrganisationClient.RejectOrganisation(model);
            return RedirectToAction("Index");
        }

        public ActionResult ViewGeneratePin(Guid orgId)
        {
            var org = m_OrganisationClient.GetOrganisationDTO(orgId);
            if (org == null) return new HttpNotFoundResult("Organisation not found");
            ViewBag.orgId = orgId;
            ViewBag.companyName = org.Name;
            return PartialView("_GeneratePin");
        }

        [HttpPost]
        public ActionResult GeneratePin(GeneratePinDTO model)
        {
            m_OrganisationClient.GeneratePin(model);

            TempData["VerifiedCompanyId"] = model.OrganisationId;
            return RedirectToAction("Index");
        }
    }
}