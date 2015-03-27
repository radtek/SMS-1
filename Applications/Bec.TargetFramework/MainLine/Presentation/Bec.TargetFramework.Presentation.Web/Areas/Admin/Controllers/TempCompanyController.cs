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

        public TempCompanyController(ILogger logger, IOrganisationLogic oLogic)
            : base(logger)
        {
            m_OrganisationLogic = oLogic;
        }

        // GET: Admin/TempCompany
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadCompanies(Bec.TargetFramework.Entities.Enums.ProfessionalOrganisationStatusEnum orgStatus)
        {
            var companies = m_OrganisationLogic.GetCompanies(orgStatus);
            var jsonData = new { total = companies.Count, companies };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewAddTempCompany()
        {
            return PartialView("_AddTempCompany");
        }

        [HttpPost]
        public ActionResult AddTempCompany(VCompanyDTO model)
        {
            if (ModelState.IsValid)
            {
                model = m_OrganisationLogic.AddNewOrganisation(model);

                TempData["AddTempCompanyId"] = model.CompanyId;
            }

            return RedirectToAction("Index");
        }
    }
}