﻿using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.DTO.Event;
using Bec.TargetFramework.Entities.DTO.Notification;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Buyer.Controllers
{
    public class SafeBuyerController : ApplicationControllerBase
    {
        public IAddressLogicClient AddressClient { get; set; }
        public IQueryLogicClient QueryClient { get; set; }
        public IOrganisationLogicClient OrganisationClient { get; set; }
        public IBankAccountLogicClient BankAccountClient { get; set; }

        public async Task<ActionResult> Index()
        {
            var uaoID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            var select = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new
            {
                personaLine1 = x.Address.Line1,
                personaLine2 = x.Address.Line2,
                personaTown = x.Address.Town,
                personaCity = x.Address.City,
                personaCounty = x.Address.County,
                personaPostalCode = x.Address.PostalCode,
                x.Contact.BirthDate,
                x.Confirmed,
                x.SmsTransactionID,
                x.SmsTransaction.Price,
                x.SmsTransaction.LenderName,
                x.SmsTransaction.MortgageApplicationNumber,
                x.SmsTransaction.OrganisationID,
                x.SmsTransaction.Address.Line1,
                x.SmsTransaction.Address.Line2,
                x.SmsTransaction.Address.Town,
                x.SmsTransaction.Address.City,
                x.SmsTransaction.Address.County,
                x.SmsTransaction.Address.PostalCode,
                x.SmsUserAccountOrganisationTransactionTypeID,
                Names = x.SmsTransaction.Organisation.OrganisationDetails.Select(y => new { y.Name }),
                Status = x.SmsTransaction.Organisation.OrganisationStatus.Select(z => new { z.Notes, z.StatusTypeValue.Name })
            });
            var filter = ODataHelper.Filter<SmsUserAccountOrganisationTransactionDTO>(x => x.UserAccountOrganisationID == uaoID);
            var data = await QueryClient.QueryAsync<SmsUserAccountOrganisationTransactionDTO>("SmsUserAccountOrganisationTransactions", select + filter);
            return View(data);
        }

        public async Task<ActionResult> ViewConfirmDetails(Guid txID, int index)
        {
            var uaoID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            ViewBag.index = index;
            ViewBag.txID = txID;

            var select = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new
            {
                x.SmsTransactionID,
                buyerLine1 = x.Address.Line1,
                buyerLine2 = x.Address.Line2,
                buyerTown = x.Address.Town,
                buyerCity = x.Address.City,
                buyerCounty = x.Address.County,
                buyerPostalCode = x.Address.PostalCode,
                x.Confirmed,
                x.SmsTransaction.Price,
                x.SmsTransaction.LenderName,
                x.SmsTransaction.MortgageApplicationNumber,
                x.SmsTransaction.OrganisationID,
                x.SmsTransaction.Address.Line1,
                x.SmsTransaction.Address.Line2,
                x.SmsTransaction.Address.Town,
                x.SmsTransaction.Address.City,
                x.SmsTransaction.Address.County,
                x.SmsTransaction.Address.PostalCode,
                x.SmsUserAccountOrganisationTransactionID,
                x.SmsUserAccountOrganisationTransactionTypeID,
                x.Contact.Salutation,
                x.Contact.FirstName,
                x.Contact.LastName,
                x.Contact.BirthDate,
                ContactRowVersion = x.Contact.RowVersion,
                TxRowVersion = x.SmsTransaction.RowVersion
            });

            var filter = ODataHelper.Filter<SmsUserAccountOrganisationTransactionDTO>(x => x.UserAccountOrganisationID == uaoID && x.SmsTransactionID == txID);

            var res = await QueryClient.QueryAsync<SmsUserAccountOrganisationTransactionDTO>("SmsUserAccountOrganisationTransactions", select + filter);
            var model = res.First();

            ViewBag.orgID = model.SmsTransaction.OrganisationID;
            ViewBag.smsUserAccountOrganisationTransactionID = model.SmsUserAccountOrganisationTransactionID;
            
            if(model.Confirmed)
                return PartialView("_CheckBankAccount");
            else
                return PartialView("_ConfirmDetails", model);
        }

        [HttpPost]
        public async Task<ActionResult> ConfirmDetails(SmsUserAccountOrganisationTransactionDTO dto, string accountNumber, string sortCode, Guid orgID, int index)
        {
            var uaoID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            
            //update tx
            await OrganisationClient.UpdateSmsUserAccountOrganisationTransactionAsync(uaoID, accountNumber, sortCode, dto);
            //check bank account
            var isMatch = await BankAccountClient.CheckBankAccountAsync(orgID, dto.SmsUserAccountOrganisationTransactionID, accountNumber, sortCode);

            return Json(new { result = isMatch, index = index, data = dto, accountNumber = accountNumber, sortCode = sortCode }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> CheckBankAccount(Guid orgID, Guid smsUserAccountOrganisationTransactionID, string accountNumber, string sortCode, int index)
        {
            var uaoID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;

            //check bank account
            var isMatch = await BankAccountClient.CheckBankAccountAsync(orgID, smsUserAccountOrganisationTransactionID, accountNumber, sortCode);
            return Json(new { result = isMatch, index = index, accountNumber = accountNumber, sortCode = sortCode }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> NotifyOrganisationNoMatch(Guid txID, string accountNumber, string sortCode)
        {
            var uaoID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            await BankAccountClient.PublishCheckNoMatchNotificationAsync(uaoID, txID, accountNumber, sortCode);
            return null;
        }
    }
}