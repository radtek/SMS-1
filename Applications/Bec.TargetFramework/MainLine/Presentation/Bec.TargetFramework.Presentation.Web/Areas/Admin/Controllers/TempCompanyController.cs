using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.UI.Process.Base;
using JSM;
using JSM.MVC4;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    public class TempCompanyController : ApplicationControllerBase, IJavaScriptModelAware
    {
        private IOrganisationLogic m_OrganisationLogic;
        private IAddressLogic m_AddressLogic;

        public TempCompanyController(ILogger logger, IOrganisationLogic oLogic, IAddressLogic addressLogic) : base(logger)
        {
            m_OrganisationLogic = oLogic;
            m_AddressLogic = addressLogic;
        }

        // GET: Admin/TempCompany
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadCompanies(Bec.TargetFramework.Entities.Enums.ProfessionalOrganisationStatusEnum orgStatus)
        {
            var companies = m_OrganisationLogic.GetCompanies(orgStatus);

            companies.ForEach(s => s.CreatedOnAsString = s.CreatedOn.ToString("dd/MM/yyyy hh:mm:ss"));

            var jsonData = new { total = companies.Count, companies };
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
                TempData["AddTempCompanyId"] = m_OrganisationLogic.AddNewUnverifiedOrganisationAndAdministrator(Entities.Enums.OrganisationTypeEnum.Conveyancing, model);
            }

            return RedirectToAction("Index");
        }

        public ActionResult FindAddress(string postcode)
        {
            return Json(m_AddressLogic.FindAddressesByPostCode(postcode, null), JsonRequestBehavior.AllowGet);
        }
    }
}