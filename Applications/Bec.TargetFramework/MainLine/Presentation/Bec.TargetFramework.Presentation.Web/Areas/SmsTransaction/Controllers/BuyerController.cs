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
            var select = ODataHelper.Select<SmsTransactionDTO>(x => new
            {
                x.OrganisationID,
                x.Address.Line1,
                x.Address.Line2,
                x.Address.Town,
                x.Address.City,
                x.Address.County,
                x.Address.PostalCode,
                Names = x.Organisation.OrganisationDetails.Select(y => new { y.Name })
            });
            var filter = ODataHelper.Filter<SmsTransactionDTO>(x => x.UserAccountOrganisationID == uaoID);
            var data = await QueryClient.QueryAsync<SmsTransactionDTO>("SmsTransactions", select + filter);
            return View(data);
        }
    }
}