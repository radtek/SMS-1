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

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetData(string source, string group)
        {
            string select;
            switch (source)
            {
                case "SmsTransaction":
                    select = ODataHelper.Select<SmsTransactionDTO>(x => new
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
                    var data = alltx.Select(d => new DataItem
                    {
                        Id = i++,
                        OrganisationName = d.Organisation.OrganisationDetails.First().Name,
                        PrimaryBuyer = d.SmsUserAccountOrganisationTransactions.FirstOrDefault(x => x.SmsUserAccountOrganisationTransactionTypeID == UserAccountOrganisationTransactionType.Buyer.GetIntValue())
                    });

                    Func<DataItem, bool> loggedinFunc = x => x.PrimaryBuyer != null && !x.PrimaryBuyer.UserAccountOrganisation.UserAccount.IsTemporaryAccount;
                    Func<IEnumerable<DataItem>, TimeDetails> timeFunc = x =>
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

                    Func<DataItem, string> getGroup = x =>
                    {
                        if (group == "[all]")
                            return "(All Firms)";
                        else if (group == "Firm")
                            return x.OrganisationName;
                        else
                            return x.Id.ToString();
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

                default:
                    throw new Exception();
            }
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

    public class DataItem
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