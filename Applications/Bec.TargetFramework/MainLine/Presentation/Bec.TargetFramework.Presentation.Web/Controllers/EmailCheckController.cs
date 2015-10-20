using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Settings;
using Bec.TargetFramework.Presentation.Web.Helpers;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Controllers
{
    public class EmailCheckController : Controller
    {
        public IQueryLogicClient QueryClient { get; set; }
        public ITFSettingsLogicClient SettingsClient { get; set; }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CheckForAdminRegistration(string email)
        {
            email = email.ToLower();

            // check all org admin contacts
            var selectContact = ODataHelper.Select<ContactDTO>(x => new { x.EmailAddress1 });
            var filterContact = ODataHelper.Expression<ContactDTO>(x => x.EmailAddress1.ToLower() == email);
            var contactAsync = await QueryClient.QueryAsync<ContactDTO>("Contacts", selectContact + ODataHelper.Filter(filterContact));

            var selectUao = ODataHelper.Select<UserAccountOrganisationDTO>(x => new { x.UserAccount.Email });
            var filterUao = ODataHelper.Expression<UserAccountOrganisationDTO>(x => x.UserAccount.Email.ToLower() == email);
            var uaoAsync = await QueryClient.QueryAsync<UserAccountOrganisationDTO>("UserAccountOrganisations", selectUao + ODataHelper.Filter(filterUao));

            var commonSettings = (await SettingsClient.GetSettingsAsync()).AsSettings<CommonSettings>();

            if (contactAsync.Any() || uaoAsync.Any())
                return Json(string.Format("The email address is already registered in Safe Move Scheme. Call us at {0} if this concerns you.", commonSettings.SupportTelephoneNumber), JsonRequestBehavior.AllowGet);
            else
                return Json("true", JsonRequestBehavior.AllowGet);
        }
    }
}