using System.Linq;
using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Presentation.Web.Helpers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Account.Controllers
{
    public class SearchController : Controller
    {
        public IQueryLogicClient queryClient { get; set; }
        public SearchController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(int schemeID)
        {
            var select = ODataHelper.Select<OrganisationDTO>(x => new { x.OrganisationID });
            var filter = ODataHelper.Filter<OrganisationDTO>(x => x.SchemeID == schemeID);
            var res = await queryClient.QueryAsync<OrganisationDTO>("Organisations", select + filter);
            var org = res.FirstOrDefault();
            if (org == null) return Json(new { message = "No results" });

            var oid = org.OrganisationID;
            select = ODataHelper.Select<VOrganisationWithStatusAndAdminDTO>(x => new { x.Name, x.Line1, x.Town, x.County, x.PostalCode, x.Regulator, x.RegulatorNumber });
            filter = ODataHelper.Filter<VOrganisationWithStatusAndAdminDTO>(x => x.OrganisationID == oid);
            var res2 = await queryClient.QueryAsync<VOrganisationWithStatusAndAdminDTO>("VOrganisationWithStatusAndAdmins", select + filter);
            var vorg = res2.FirstOrDefault();
            if (vorg == null) return Json(new { message = "No results" });

            return Json(vorg);
        }
    }
}