using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Helpers;

namespace Bec.TargetFramework.Presentation.Web.Areas.SmsTransaction.Controllers
{
    public class BuyerController : ApplicationControllerBase
    {
        public IAddressLogicClient AddressClient { get; set; }
        public IQueryLogicClient QueryClient { get; set; }

        public async Task<ActionResult> Index()
        {
            var uaoID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            var select = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new
            {
                x.SmsTransaction.OrganisationID,
                x.SmsTransaction.Address.Line1,
                x.SmsTransaction.Address.Line2,
                x.SmsTransaction.Address.Town,
                x.SmsTransaction.Address.City,
                x.SmsTransaction.Address.County,
                x.SmsTransaction.Address.PostalCode,
                Names = x.SmsTransaction.Organisation.OrganisationDetails.Select(y => new { y.Name })
            });
            var filter = ODataHelper.Filter<SmsUserAccountOrganisationTransactionDTO>(x => x.UserAccountOrganisationId == uaoID);
            var data = await QueryClient.QueryAsync<SmsUserAccountOrganisationTransactionDTO>("SmsUserAccountOrganisationTransactions", select + filter);
            return View(data);
        }
    }
}