using Bec.TargetFramework.Business.Client.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Controllers
{
    public class CompanyDuplicateCheckController : Controller
    {
        public IOrganisationLogicClient OrganisationClient { get; set; }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Check(string regulatorNumber)
        {
            var isInSystem = await OrganisationClient.IsOrganisationInSystemAsync(regulatorNumber);
            if (isInSystem)
                return Json("The organisation with provided SRA ID/MIS Number is already registered in Safe Move Scheme. Contact enquiries@safemovescheme.co.uk if this concerns you.", JsonRequestBehavior.AllowGet);
            else
                return Json("true", JsonRequestBehavior.AllowGet);
        }
    }
}