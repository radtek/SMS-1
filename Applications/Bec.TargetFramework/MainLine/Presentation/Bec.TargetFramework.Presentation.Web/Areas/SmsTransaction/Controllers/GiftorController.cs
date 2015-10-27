using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
using Bec.TargetFramework.Presentation.Web.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.SmsTransaction.Controllers
{
    [ClaimsRequired("Add", "SmsTransaction", Order = 1000)]
    public class GiftorController : ApplicationControllerBase
    {
        public IOrganisationLogicClient orgClient { get; set; }
        public IQueryLogicClient queryClient { get; set; }
        public async Task<ActionResult> Get(Guid transactionID)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;

            var select = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new
            {
                x.UserAccountOrganisation.UserAccount.Email,
                x.UserAccountOrganisation.UserAccount.IsTemporaryAccount,
                x.Contact.Salutation,
                x.Contact.FirstName,
                x.Contact.LastName,
                x.Contact.BirthDate
            });
            var giftorTypeID = UserAccountOrganisationTransactionType.Giftor.GetIntValue();
            var where = ODataHelper.Expression<SmsUserAccountOrganisationTransactionDTO>(x => 
                x.SmsTransactionID == transactionID &&
                x.SmsTransaction.OrganisationID == orgID &&
                x.SmsUserAccountOrganisationTransactionTypeID == giftorTypeID);

            var filter = ODataHelper.Filter(where);

            JObject res = await queryClient.QueryAsync("SmsUserAccountOrganisationTransactions", Request.QueryString + select + filter);
            return Content(res.ToString(Formatting.None), "application/json");
        }

        public ActionResult ViewAddGiftor(Guid txID, int pageNumber)
        {
            ViewBag.pageNumber = pageNumber;
            var model = new AddSmsClientDTO
            {
                TransactionID = txID
            };

            return PartialView("_AddGiftor", model);
        }

        [HttpPost]
        public async Task<ActionResult> AddGiftor(AddSmsClientDTO model)
        {
            var currentUser = WebUserHelper.GetWebUserObject(HttpContext);
            try
            {
                var giftorUaoID = await orgClient.AddSmsClientAsync(currentUser.OrganisationID, currentUser.UaoID, model.Salutation, model.FirstName, model.LastName, model.Email, model.BirthDate.Value);
                var assignSmsClientToTransactionDto = new AssignSmsClientToTransactionDTO
                {
                    UaoID = giftorUaoID,
                    TransactionID = model.TransactionID,
                    AssigningByOrganisationID = currentUser.OrganisationID,
                    UserAccountOrganisationTransactionType = UserAccountOrganisationTransactionType.Giftor
                };

                await orgClient.AssignSmsClientToTransactionAsync(assignSmsClientToTransactionDto);
                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    result = false,
                    title = "Adding Giftor Failed",
                    message = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }
        
    }
}