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
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.SmsTransaction.Controllers
{
    [ClaimsRequired("Add", "SmsTransaction", Order = 1000)]
    public class GiftorController : ApplicationControllerBase
    {
        public IOrganisationLogicClient orgClient { get; set; }
        public IQueryLogicClient queryClient { get; set; }
        public async Task<ActionResult> Get(Guid transactionId)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;

            var select = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new
            {
                x.UserAccountOrganisation.Contact.Salutation,
                x.UserAccountOrganisation.Contact.FirstName,
                x.UserAccountOrganisation.Contact.LastName,
                x.UserAccountOrganisation.Contact.BirthDate,
                x.UserAccountOrganisation.UserAccount.Email,
                x.UserAccountOrganisation.UserAccount.IsTemporaryAccount,
                Addresses = x.UserAccountOrganisation.Contact.Addresses.Select(a => 
                    new
                    {
                        a.Line1,
                        a.Line2,
                        a.Town,
                        a.County,
                        a.PostalCode,
                        a.AdditionalAddressInformation,
                        a.IsPrimaryAddress
                    })
            });
            var additionalBuyerTypeId = UserAccountOrganisationTransactionType.Giftor.GetIntValue();
            var where = ODataHelper.Expression<SmsUserAccountOrganisationTransactionDTO>(x => 
                x.SmsTransactionId == transactionId &&
                x.SmsTransaction.OrganisationID == orgID &&
                x.SmsUserAccountOrganisationTransactionTypeId == additionalBuyerTypeId);

            var filter = ODataHelper.Filter(where);

            JObject res = await queryClient.QueryAsync("SmsUserAccountOrganisationTransactions", Request.QueryString + select + filter);
            return Content(res.ToString(Formatting.None), "application/json");
        }

        public ActionResult ViewAddGiftor(Guid txID)
        {
            var model = new AddSmsClientDTO
            {
                TransactionId = txID
            };

            return PartialView("_AddGiftor", model);
        }

        [HttpPost]
        public async Task<ActionResult> AddGiftor(AddSmsClientDTO model)
        {
            var currentUser = WebUserHelper.GetWebUserObject(HttpContext);
            try
            {
                var giftorUaoId = await orgClient.AddSmsClientAsync(currentUser.OrganisationID, currentUser.UaoID, model.Salutation, model.FirstName, model.LastName, model.Email, model.BirthDate.Value);
                var assignSmsClientToTransactionDto = new AssignSmsClientToTransactionDTO
                {
                    UaoId = giftorUaoId,
                    TransactionId = model.TransactionId,
                    Line1 = model.Line1,
                    Line2 = model.Line2,
                    County = model.County,
                    AdditionalAddressInformation = model.AdditionalAddressInformation,
                    PostalCode = model.PostalCode,
                    Town = model.Town,
                    Manual = model.Manual,
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