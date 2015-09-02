using System;
using System.Threading.Tasks;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
using System.Web.Mvc;
using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Presentation.Web.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bec.TargetFramework.Presentation.Web.Areas.SmsTransaction.Controllers
{
    [ClaimsRequired("Add", "SmsTransaction", Order = 1000)]
    public class AdditionalBuyerController : ApplicationControllerBase
    {
        public IOrganisationLogicClient orgClient { get; set; }
        public IQueryLogicClient queryClient { get; set; }
        public IAdditionalBuyerLogicClient additionalBuyerClient { get; set; }
        public async Task<ActionResult> Get(Guid transactionId)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;

            var select = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new
            {
                x.UserAccountOrganisation.Contact.Salutation,
                x.UserAccountOrganisation.Contact.FirstName,
                x.UserAccountOrganisation.Contact.LastName,
                x.UserAccountOrganisation.UserAccount.Email,
                x.UserAccountOrganisation.UserAccount.IsTemporaryAccount,
                x.UserAccountAddress.Address.Line1,
                x.UserAccountAddress.Address.Line2,
                x.UserAccountAddress.Address.Town,
                x.UserAccountAddress.Address.County,
                x.UserAccountAddress.Address.PostalCode,
                x.UserAccountAddress.Address.AdditionalAddressInformation,
            });

            var where = ODataHelper.Expression<SmsUserAccountOrganisationTransactionDTO>(x => 
                x.SmsTransactionId == transactionId &&
                x.SmsTransaction.OrganisationID == orgID);

            var filter = ODataHelper.Filter(where);

            JObject res = await queryClient.QueryAsync("SmsUserAccountOrganisationTransactions", Request.QueryString + select + filter);
            return Content(res.ToString(Formatting.None), "application/json");
        }

        [HttpPost]
        public JsonResult Create(string salutation, string firstName, string lastName, string email)
        {
            return Json(new { result = true });
        }

        [HttpPost]
        public JsonResult Update(Guid id, string salutation, string firstName, string lastName, string email)
        {
            return Json(new {result = true});
        }

        [HttpDelete]
        public JsonResult Delete(Guid id)
        {
            return Json(new { result = true });
        }

        public ActionResult ViewAddAdditionalBuyer(Guid txID)
        {
            var model = new AddAdditionalBuyerDTO
            {
                TransactionId = txID
            };

            return PartialView("_AddAdditionalBuyer", model);
        }

        [HttpPost]
        public async Task<ActionResult> AddAdditionalBuyer(AddAdditionalBuyerDTO model)
        {
            var currentUser = WebUserHelper.GetWebUserObject(HttpContext);
            try
            {
                var additionalBuyerUaoId = await orgClient.AddSmsClientAsync(currentUser.OrganisationID, currentUser.UaoID, model.Salutation, model.FirstName, model.LastName, model.Email);
                model.UaoId = additionalBuyerUaoId;

                await additionalBuyerClient.AddAdditionalBuyerAsync(model);
                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    result = false,
                    title = "Adding Additional Buyer Failed",
                    message = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}