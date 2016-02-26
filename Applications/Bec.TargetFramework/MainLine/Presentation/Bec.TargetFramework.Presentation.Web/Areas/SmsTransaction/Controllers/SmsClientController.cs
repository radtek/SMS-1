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
using System.Linq;
using System.Collections.Generic;

namespace Bec.TargetFramework.Presentation.Web.Areas.SmsTransaction.Controllers
{
    [ClaimsRequired("Add", "SmsTransaction", Order = 1000)]
    public class SmsClientController : ApplicationControllerBase
    {
        private static IEnumerable<UserAccountOrganisationTransactionType> AllowedParties = new[] { UserAccountOrganisationTransactionType.AdditionalBuyer, UserAccountOrganisationTransactionType.Giftor };
        public IOrganisationLogicClient orgClient { get; set; }
        public IQueryLogicClient queryClient { get; set; }
        public async Task<ActionResult> Get(Guid transactionID, UserAccountOrganisationTransactionType uaotType)
        {
            ValidateRequestedUaotType(uaotType);

            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;

            var select = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new
            {
                x.UserAccountOrganisation.UserAccountOrganisationID,
                x.UserAccountOrganisation.UserAccount.Email,
                x.UserAccountOrganisation.UserAccount.IsTemporaryAccount,
                x.UserAccountOrganisation.UserAccount.LastLogin,
                x.UserAccountOrganisation.PinCode,
                x.Contact.Salutation,
                x.Contact.FirstName,
                x.Contact.LastName,
                x.Contact.BirthDate,
                x.LatestBankAccountCheck.CheckedOn,
                x.SmsTransactionID,
                x.SmsUserAccountOrganisationTransactionID,
                SmsSrcFundsBankAccounts = x.SmsSrcFundsBankAccounts.Select(s => new { s.AccountNumber, s.SortCode })
            });
            var smsClientTypeId = uaotType.GetIntValue();
            var where = ODataHelper.Expression<SmsUserAccountOrganisationTransactionDTO>(x => 
                x.SmsTransactionID == transactionID &&
                x.SmsTransaction.OrganisationID == orgID &&
                x.SmsUserAccountOrganisationTransactionTypeID == smsClientTypeId);

            var filter = ODataHelper.Filter(where);

            JObject res = await queryClient.QueryAsync("SmsUserAccountOrganisationTransactions", Request.QueryString + select + filter);
            return Content(res.ToString(Formatting.None), "application/json");
        }

        public ActionResult ViewAddSmsClient(Guid txID, int pageNumber, UserAccountOrganisationTransactionType uaotType)
        {
            ValidateRequestedUaotType(uaotType);
            ViewBag.pageNumber = pageNumber;
            ViewBag.personaName = uaotType.GetStringValue();
            var model = new AddSmsClientDTO
            {
                TransactionID = txID,
                UserAccountOrganisationTransactionType = uaotType
            };

            return PartialView("AddSmsClient", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddSmsClient(AddSmsClientDTO model)
        {
            ValidateRequestedUaotType(model.UserAccountOrganisationTransactionType);
            var currentUser = WebUserHelper.GetWebUserObject(HttpContext);
            try
            {
                var assignSmsClientToTransactionDto = new AssignSmsClientToTransactionDTO
                {
                    Salutation = model.Salutation,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    BirthDate = model.BirthDate.Value,
                    TransactionID = model.TransactionID,
                    AssigningByOrganisationID = currentUser.OrganisationID,
                    UserAccountOrganisationTransactionType = model.UserAccountOrganisationTransactionType,
                    RegisteredHomeAddress = model.RegisteredHomeAddressDTO,
                    SmsSrcFundsBankAccounts = model.SmsSrcFundsBankAccounts
                };

                await orgClient.AssignSmsClientToTransactionAsync(assignSmsClientToTransactionDto);
                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    result = false,
                    title = "Adding Sms Client Failed",
                    message = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }

        private void ValidateRequestedUaotType(UserAccountOrganisationTransactionType uaotType)
        {
            if (!AllowedParties.Contains(uaotType))
            {
                throw new ArgumentException("The selected user type cannot be requested.");
            }
        }
    }
}