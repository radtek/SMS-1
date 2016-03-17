using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Settings;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Controllers
{
    public class CompanyDuplicateCheckController : Controller
    {
        public IOrganisationLogicClient OrganisationClient { get; set; }
        public ITFSettingsLogicClient SettingsClient { get; set; }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Check(Guid? orgID, string regulatorNumber)
        {
            var isInSystem = await OrganisationClient.IsOrganisationInSystemAsync(orgID, regulatorNumber);
            var settings = (await SettingsClient.GetSettingsAsync()).AsSettings<CommonSettings>();
            if (isInSystem)
                return Json("The organisation with above SRA ID/MIS Number is already registered in the Safe Move Scheme." + (orgID.HasValue ? "": " Email us on " + settings.SupportEmailAddress + " if this concerns you."), JsonRequestBehavior.AllowGet);
            else
                return Json("true", JsonRequestBehavior.AllowGet);
        }
    }
}