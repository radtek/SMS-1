using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Presentation.Web.Helpers;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Controllers
{
    public class EmailCheckController : Controller
    {
        public IQueryLogicClient QueryClient { get; set; }
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

            // todo: ZM use settings to get the number
            if (contactAsync.Any() || uaoAsync.Any())
                return Json("The email address is already registered in Safe Move Scheme. Call us at 020 3598 0150 if this concerns you.", JsonRequestBehavior.AllowGet);
            else
                return Json("true", JsonRequestBehavior.AllowGet);
        }
    }
}