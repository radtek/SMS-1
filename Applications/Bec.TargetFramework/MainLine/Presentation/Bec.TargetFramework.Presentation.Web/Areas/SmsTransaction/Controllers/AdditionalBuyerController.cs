using System;
using System.Linq;
using System.Threading.Tasks;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
using System.Web.Mvc;
using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Extensions;
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
            var additionalBuyerTypeId = UserAccountOrganisationTransactionType.AdditionalBuyer.GetIntValue();
            var where = ODataHelper.Expression<SmsUserAccountOrganisationTransactionDTO>(x => 
                x.SmsTransactionId == transactionId &&
                x.SmsTransaction.OrganisationID == orgID &&
                x.SmsUserAccountOrganisationTransactionTypeId == additionalBuyerTypeId);

            var filter = ODataHelper.Filter(where);

            JObject res = await queryClient.QueryAsync("SmsUserAccountOrganisationTransactions", Request.QueryString + select + filter);
            return Content(res.ToString(Formatting.None), "application/json");
        }

        public ActionResult ViewAddAdditionalBuyer(Guid txID)
        {
            var model = new AddSmsClientDTO
            {
                TransactionId = txID
            };

            return PartialView("_AddAdditionalBuyer", model);
        }

        [HttpPost]
        public async Task<ActionResult> AddAdditionalBuyer(AddSmsClientDTO model)
        {
            var currentUser = WebUserHelper.GetWebUserObject(HttpContext);
            try
            {
                var additionalBuyerUaoId = await orgClient.AddSmsClientAsync(currentUser.OrganisationID, currentUser.UaoID, model.Salutation, model.FirstName, model.LastName, model.Email, model.BirthDate.Value);
                var assignSmsClientToTransactionDto = new AssignSmsClientToTransactionDTO
                {
                    UaoId = additionalBuyerUaoId,
                    TransactionId = model.TransactionId,
                    Line1 = model.Line1,
                    Line2 = model.Line2,
                    County = model.County,
                    AdditionalAddressInformation = model.AdditionalAddressInformation,
                    PostalCode = model.PostalCode,
                    Town = model.Town,
                    Manual = model.Manual,
                    UserAccountOrganisationTransactionType = UserAccountOrganisationTransactionType.AdditionalBuyer
                };

                await orgClient.AssignSmsClientToTransactionAsync(assignSmsClientToTransactionDto);
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