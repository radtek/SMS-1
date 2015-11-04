using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
using Bec.TargetFramework.Presentation.Web.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Bec.TargetFramework.Infrastructure.Extensions;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{

    //role for this not finalised yet
    [ClaimsRequired("Add", "Company", Order = 1000)]
    public class ReportingController : ApplicationControllerBase
    {
        public IQueryLogicClient queryClient { get; set; }

        public ReportingController()
        {
        }

        public ActionResult Transactions()
        {
            return View();
        }

        public ActionResult Firms()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }

        public async Task<ActionResult> GetData(string source, string group)
        {
            switch (source)
            {
                case "SmsTransaction":return await TransactionReport(group);
                case "Organisation": return await OrganisationReport(group);
                case "User": return await UserReport(group);
                default: throw new Exception();
            }
        }

        //pro users by organisation
        private async Task<ActionResult> UserReport(string group)
        {
            var proOrgType = OrganisationTypeEnum.Professional.GetIntValue();
            var select = ODataHelper.Select<UserAccountOrganisationDTO>(x => new
            {
                Names = x.Organisation.OrganisationDetails.Select(b => new { b.Name }),
                x.UserAccount.Created,
                x.UserAccount.AccountCreated
            });
            var filter = ODataHelper.Filter<UserAccountOrganisationDTO>(x => x.Organisation.OrganisationTypeID == proOrgType);
            var allUsers = await queryClient.QueryAsync<UserAccountOrganisationDTO>("UserAccountOrganisations", select + filter);

            Func<IEnumerable<UserAccountOrganisationDTO>, TimeDetails> timeFunc = x =>
            {
                var withVals = x.Where(y => y.UserAccount != null && y.UserAccount.AccountCreated.HasValue);
                if (withVals.Any())
                    return formatMinutes(withVals.Select(z => z.UserAccount.AccountCreated.Value - z.UserAccount.Created).Average(t => t.TotalMinutes));
                else
                    return new TimeDetails { Value = 0, Text = "-" };
            };

            int i = 0;
            var ret = allUsers.GroupBy(x => group == "Firm" ? x.Organisation.OrganisationDetails.First().Name : "(All Firms)").Select(x => new
            {
                Id = i++,
                Name = x.Key,
                Total = x.Count(),
                Time = timeFunc(x)
            });

            return Json(new { total = ret.Count(), list = ret }, JsonRequestBehavior.AllowGet);
        }

        private async Task<ActionResult> OrganisationReport(string group)
        {
            var proOrgType = OrganisationTypeEnum.Professional.GetIntValue();
            var select = ODataHelper.Select<OrganisationDTO>(x => new {
                Names = x.OrganisationDetails.Select(b => new { b.Name }),
                Statii = x.OrganisationStatus.Select(s => new { s.StatusChangedOn, s.StatusTypeValue.Name})
            });
            var filter = ODataHelper.Filter<OrganisationDTO>(x => x.OrganisationTypeID == proOrgType);
            var allOrgs = await queryClient.QueryAsync<OrganisationDTO>("Organisations", select + filter);
            var data = allOrgs.Select(x => new {
                Name = x.OrganisationDetails.First().Name,
                Status = x.OrganisationStatus.OrderBy(y=>y.StatusChangedOn).Last().StatusTypeValue.Name
            });

            int i = 0;
            var ret = data.GroupBy(x => group == "Status" ? x.Status : "(All Firms)").Select(x => new
            {
                Id = i++,
                Name = x.Key,
                Total = x.Count()
            });

            return Json(new { total = ret.Count(), list = ret }, JsonRequestBehavior.AllowGet);
        }

        //sms transactions including user time to log in
        private async Task<ActionResult> TransactionReport(string group)
        {
            var select = ODataHelper.Select<SmsTransactionDTO>(x => new
            {
                Names = x.Organisation.OrganisationDetails.Select(b => new { b.Name }),
                States = x.Organisation.OrganisationStatus.Select(c => new { c.StatusTypeValue.Name, c.StatusChangedOn }),
                Users = x.SmsUserAccountOrganisationTransactions.Select(y => new
                {
                    y.SmsUserAccountOrganisationTransactionTypeID,
                    y.UserAccountOrganisation.UserAccount.IsTemporaryAccount,
                    y.UserAccountOrganisation.UserAccount.Created,
                    y.UserAccountOrganisation.UserAccount.AccountCreated
                })
            });

            var alltx = await queryClient.QueryAsync<SmsTransactionDTO>("SmsTransactions", select);
            int i = 0;
            var data = alltx.Select(d => new TxDataItem
            {
                Id = i++,
                OrganisationName = d.Organisation.OrganisationDetails.First().Name,
                PrimaryBuyer = d.SmsUserAccountOrganisationTransactions.FirstOrDefault(x => x.SmsUserAccountOrganisationTransactionTypeID == UserAccountOrganisationTransactionType.Buyer.GetIntValue())
            });

            Func<TxDataItem, bool> loggedinFunc = x => x.PrimaryBuyer != null && !x.PrimaryBuyer.UserAccountOrganisation.UserAccount.IsTemporaryAccount;
            Func<IEnumerable<TxDataItem>, TimeDetails> timeFunc = x =>
            {
                var withVals = x.Where(y =>
                    y.PrimaryBuyer != null &&
                    y.PrimaryBuyer.UserAccountOrganisation != null &&
                    y.PrimaryBuyer.UserAccountOrganisation.UserAccount != null &&
                    y.PrimaryBuyer.UserAccountOrganisation.UserAccount.AccountCreated.HasValue);
                if (withVals.Any())
                    return formatMinutes(withVals.Select(z => z.PrimaryBuyer.UserAccountOrganisation.UserAccount.AccountCreated.Value - z.PrimaryBuyer.UserAccountOrganisation.UserAccount.Created).Average(t => t.TotalMinutes));
                else
                    return new TimeDetails { Value = 0, Text = "-" };
            };

            Func<TxDataItem, string> getGroup = x =>
            {
                if (group == "[all]")
                    return x.Id.ToString();
                else if (group == "Firm")
                    return x.OrganisationName;
                else
                    return "(All Firms)";
            };

            i = 0;
            var ret = data.GroupBy(getGroup).Select(g => new
            {
                Id = i++,
                Name = string.IsNullOrEmpty(group) ? g.First().OrganisationName : g.Key,
                Total = g.Count(),
                LoggedIn = g.Count(loggedinFunc),
                Time = timeFunc(g)
            });
            return Json(new { total = ret.Count(), list = ret }, JsonRequestBehavior.AllowGet);
        }

        private TimeDetails formatMinutes(double minutes)
        {
            TimeSpan ts = TimeSpan.FromMinutes(minutes);
            if (ts.TotalDays > 1)
                return new TimeDetails { Value = minutes, Text = string.Format("{0:0} days", ts.TotalDays) };
            else if (ts.TotalHours > 1)
                return new TimeDetails { Value = minutes, Text = string.Format("{0:0} hours", ts.TotalHours) };
            else if (ts.TotalMinutes > 1)
                return new TimeDetails { Value = minutes, Text = string.Format("{0:0} minutes", ts.TotalMinutes) };
            else
                return new TimeDetails { Value = minutes, Text = string.Format("{0:0} seconds", ts.TotalSeconds) };
        }
    }

    public class TxDataItem
    {
        public int Id { get; set; }
        public string OrganisationName { get; set; }
        public SmsUserAccountOrganisationTransactionDTO PrimaryBuyer { get; set; }
    }

    public class TimeDetails
    {
        public string Text { get; set; }
        public double Value { get; set; }
    }
}