using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Presentation.Web.Filters;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Controllers
{
    public class PostcodeLookupController : Controller
    {
        public IAddressLogicClient AddressClient { get; set; }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> FindAddress(string postcode)
        {
            var list = await AddressClient.FindAddressesByPostCodeAsync(postcode, null);

            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}