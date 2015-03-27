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

        public ActionResult LoadUnverifiedCompanies(/*int page, int pageSize, int take*/)
        {
            var allUnverifiedCompanies = m_OrganisationLogic.GetAllUnverifiedCompanies();
            var filteredList = allUnverifiedCompanies;//.Skip((page - 1)*pageSize).Take(pageSize).ToList();

            // set datetime for display
            filteredList.ForEach(item =>
            {
                if (item.CompanyRecordCreated.HasValue)
                    item.CompanyCreatedOnDate =  item.CompanyRecordCreated.Value.ToString("dd/MM/yyyy hh:MM:ss");
                else
                {
                    item.CompanyCreatedOnDate =  string.Empty;
                }
            });

            var jsonData = new { total = allUnverifiedCompanies.Count, filteredList };
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

        public ActionResult FindAddress(string postcode)
        {
            return Json(m_AddressLogic.FindAddressesByPostCode(postcode, null), JsonRequestBehavior.AllowGet);
        }
    }
}