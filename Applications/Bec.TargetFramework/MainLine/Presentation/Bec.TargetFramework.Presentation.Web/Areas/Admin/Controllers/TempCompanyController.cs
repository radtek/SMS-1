using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Presentation.Web.Api.Client.Clients;
using Bec.TargetFramework.Presentation.Web.Api.Client.Models;
using Bec.TargetFramework.UI.Process.Base;
using JSM;
using Bec.TargetFramework.Presentation.Web.Api.Client;
using JSM.MVC4;
using ServiceStack.ServiceHost;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    public class TempCompanyController : ApplicationControllerBase, IJavaScriptModelAware
    {

        public TempCompanyController(ILogger logger) : base(logger)
        {
        }

        // GET: Admin/TempCompany
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadCompanies(ProfessionalOrganisationStatusEnum orgStatus)
        {
            List<VOrganisationWithStatusAndAdminDTO> list = null;

            using (var client = new OrganisationLogicClient())
            {
                client.HttpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BusinessServiceBaseURL"]);
                list = client.GetCompanies(orgStatus);
            }

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
                using (var client = new OrganisationLogicClient())
                {
                    client.HttpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BusinessServiceBaseURL"]);

                    var id = client.AddNewUnverifiedOrganisationAndAdministrator(OrganisationTypeEnum.Conveyancing, model);

                    TempData["AddTempCompanyId"] = id;
                }
                
            }

            return RedirectToAction("Index");
        }

        public ActionResult FindAddress(string postcode)
        {
            List<PostCodeDTO> list = null;

            using (var client = new OrganisationLogicClient())
            {
                client.HttpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BusinessServiceBaseURL"]);

                list = client.FindAddressesByPostCode(postcode, null);

            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ValidateAddress(bool Manual, string Line1, string Line2, string Town, string County, string PostalCode)
        {
            using (var client = new OrganisationLogicClient())
            {
                client.HttpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BusinessServiceBaseURL"]);
                return Json(client.FindDuplicateOrganisations(Manual, Line1, Line2, Town, County, PostalCode), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ViewRejectTempCompany(Guid orgId)
        {
            using (var client = new OrganisationLogicClient())
            {
                client.HttpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BusinessServiceBaseURL"]);
                var org = client.GetOrganisationDTO(orgId);
                if (org == null) return new HttpNotFoundResult("Organisation not found");
                ViewBag.orgId = orgId;
                ViewBag.companyName = org.Name;
                return PartialView("_RejectTempCompany");
            }
        }

        [HttpPost]
        public ActionResult RejectTempCompany(RejectCompanyDTO model)
        {
            using (var client = new OrganisationLogicClient())
            {
                client.HttpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BusinessServiceBaseURL"]);
                client.RejectOrganisation(model);
                return RedirectToAction("Index");
            }
        }

        public ActionResult ViewGeneratePin(Guid orgId)
        {
            using (var client = new OrganisationLogicClient())
            {
                client.HttpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BusinessServiceBaseURL"]);
                var org = client.GetOrganisationDTO(orgId);
                if (org == null) return new HttpNotFoundResult("Organisation not found");
                ViewBag.orgId = orgId;
                ViewBag.companyName = org.Name;
                return PartialView("_GeneratePin");
            }
        }

        [HttpPost]
        public ActionResult GeneratePin(GeneratePinDTO model)
        {
            using (var client = new OrganisationLogicClient())
            {
                client.HttpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BusinessServiceBaseURL"]);
                client.GeneratePin(model);
                return RedirectToAction("Index", new { tab = "Verified", orgID = model.OrganisationId });
            }
        }
    }
}