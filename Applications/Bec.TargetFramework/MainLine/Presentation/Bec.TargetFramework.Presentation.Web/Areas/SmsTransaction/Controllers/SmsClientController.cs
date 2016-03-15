using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Presentation.Web.App_Helpers;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
using Bec.TargetFramework.Presentation.Web.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.SmsTransaction.Controllers
{
    [ClaimsRequired("Add", "SmsTransaction", Order = 1000)]
    public class SmsClientController : ApplicationControllerBase
    {
        private static IEnumerable<UserAccountOrganisationTransactionType> AllowedParties = new[] { UserAccountOrganisationTransactionType.AdditionalBuyer, UserAccountOrganisationTransactionType.Giftor };
        public IOrganisationLogicClient OrganisationClient { get; set; }
        public IQueryLogicClient QueryClient { get; set; }
        public IUserLogicClient UserClient { get; set; }

        public async Task<ActionResult> Get(Guid transactionID)
        {
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
                x.SmsUserAccountOrganisationTransactionTypeID,
                x.SmsUserAccountOrganisationTransactionType.Description,
                x.Address.Line1,
                x.Address.Line2,
                x.Address.Town,
                x.Address.County,
                x.Address.PostalCode
            });
            var where = ODataHelper.Expression<SmsUserAccountOrganisationTransactionDTO>(x =>
                x.SmsTransactionID == transactionID &&
                x.SmsTransaction.OrganisationID == orgID);

            var filter = ODataHelper.Filter(where);

            JObject res = await QueryClient.QueryAsync("SmsUserAccountOrganisationTransactions", Request.QueryString + select + filter);
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

                await OrganisationClient.AssignSmsClientToTransactionAsync(assignSmsClientToTransactionDto);
                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    result = false,
                    title = "Adding Buyer Party Failed",
                    message = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [ClaimsRequired("Edit", "SmsTransaction", Order = 1001)]
        public async Task<ActionResult> ViewEditSmsClient(Guid uaotID, int pageNumber)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;

            var select = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new
            {
                x.SmsTransactionID,
                x.SmsUserAccountOrganisationTransactionID,
                x.Address.Line1,
                x.Address.Line2,
                x.Address.Town,
                x.Address.County,
                x.Address.PostalCode,
                x.Address.RowVersion,
                x.Contact.Salutation,
                x.Contact.FirstName,
                x.Contact.LastName,
                x.Contact.BirthDate,
                uaRowVersion = x.UserAccountOrganisation.UserAccount.RowVersion,
                x.UserAccountOrganisation.UserAccount.IsTemporaryAccount,
                x.UserAccountOrganisation.UserAccount.Email,
                x.UserAccountOrganisationID,
                rv2 = x.Contact.RowVersion
            });

            var filter = ODataHelper.Filter<SmsUserAccountOrganisationTransactionDTO>(x => x.SmsUserAccountOrganisationTransactionID == uaotID && x.SmsTransaction.OrganisationID == orgID);

            var res = await QueryClient.QueryAsync<SmsUserAccountOrganisationTransactionDTO>("SmsUserAccountOrganisationTransactions", select + filter);
            var model = res.First();

            ViewBag.txID = model.SmsTransactionID;
            ViewBag.uaoID = model.UserAccountOrganisationID;
            ViewBag.pageNumber = pageNumber;
            ViewBag.IsTemporaryUser = model.UserAccountOrganisation.UserAccount.IsTemporaryAccount;
            ViewBag.canEditBirthDate = await PendingUpdateExtensions.CanEditBirthDate(model.UserAccountOrganisationID, model.SmsTransactionID, QueryClient);
            return PartialView("_EditSmsClient", await model.WithFieldUpdates(HttpContext, ActivityType.SmsTransaction, model.SmsTransactionID, QueryClient));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ClaimsRequired("Edit", "SmsTransaction", Order = 1001)]
        public async Task<ActionResult> EditSmsClient(Guid txID, Guid uaoID, IEnumerable<string> FieldUpdates)
        {
            try
            {
                var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;

                var model = new EditBuyerPartyDTO { Dto = new SmsUserAccountOrganisationTransactionDTO() };
                UpdateModel(model.Dto, "Dto");
                model.TxID = txID;
                model.UaoID = uaoID;

                if (FieldUpdates != null)
                {
                    model.FieldUpdates = (await PendingUpdateExtensions.GetFieldUpdates(HttpContext, ActivityType.SmsTransaction, txID, QueryClient))
                        .Where(x => FieldUpdates.Contains(x.GetHash()));
                }

                await OrganisationClient.EditBuyerPartyAsync(model);

                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new
                {
                    result = false,
                    title = "Edit Buyer Party Failed",
                    message = "Edit Buyer Party Failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        internal static async Task EnsureEmailNotInUse(string email, Guid? uaoID, IUserLogicClient userLogic)
        {
            var isEmailAvailable = await userLogic.CanEmailBeUsedAsProfessionalAsync(email, uaoID);
            if (!isEmailAvailable) throw new InvalidOperationException("The email cannot be used.");
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