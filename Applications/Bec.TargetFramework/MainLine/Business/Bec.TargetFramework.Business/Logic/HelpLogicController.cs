using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Entities.Injections;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Infrastructure.Settings;
using Bec.TargetFramework.SB.Client.Interfaces;
using Bec.TargetFramework.Security;
using BrockAllen.MembershipReboot;
using EnsureThat;
using Mehdime.Entity;
using Omu.ValueInjecter;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Logic
{
    [Trace(TraceExceptionsOnly = true)]
    public class HelpLogicController : LogicBase
    {
        public async Task<Guid> CreateHelpPage(HelpPageDTO helpPageDto)
        {
            Ensure.That(helpPageDto).IsNotNull();
            helpPageDto.HelpPageID = Guid.NewGuid();
            using (var scope = DbContextScopeFactory.Create())
            {
                HelpPage helpPage = helpPageDto.ToEntity();
                scope.DbContexts.Get<TargetFrameworkEntities>().HelpPages.Add(helpPage);

                if (helpPageDto.HelpItems.Count>0)
                {
                    foreach (var item in helpPageDto.HelpItems)
                    {
                        Ensure.That(item).IsNotNull();
                        item.HelpPageID = helpPageDto.HelpPageID;
                        item.HelpItemID = Guid.NewGuid();

                        HelpItem helpItem = item.ToEntity();
                        scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems.Add(helpItem);                       
                    }
                }
                await scope.SaveChangesAsync();
            }
            return helpPageDto.HelpPageID;
        }

        public async Task<Guid> CreateHelpItem(HelpItemDTO helpItemDto)
        {
            Ensure.That(helpItemDto).IsNotNull();
            helpItemDto.HelpItemID = Guid.NewGuid();
            using (var scope = DbContextScopeFactory.Create())
            {
                HelpItem helpItem = helpItemDto.ToEntity();
                scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems.Add(helpItem);
                await scope.SaveChangesAsync();
            }
            return helpItemDto.HelpItemID;
        }

        public async Task<Guid> CreateHelpItemUserAccount(HelpItemUserAccountDTO helpItemUserAccountDTO)
        {
            Ensure.That(helpItemUserAccountDTO).IsNotNull();
            helpItemUserAccountDTO.HelpItemUserAccountID = Guid.NewGuid();
            using (var scope = DbContextScopeFactory.Create())
            {
                HelpItemUserAccount HelpItemUserAccount = helpItemUserAccountDTO.ToEntity();
                scope.DbContexts.Get<TargetFrameworkEntities>().HelpItemUserAccounts.Add(HelpItemUserAccount);
                await scope.SaveChangesAsync();
            }
            return helpItemUserAccountDTO.HelpItemUserAccountID;
        }

        public async Task DeleteHelpPage(HelpPageDTO helpPageDto)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var helpPage = scope.DbContexts.Get<TargetFrameworkEntities>().HelpPages.FirstOrDefault(p => p.HelpPageID == helpPageDto.HelpPageID);
                if (helpPage != null)
                {
                    scope.DbContexts.Get<TargetFrameworkEntities>().HelpPages.Remove(helpPage);
                    await scope.SaveChangesAsync();
                }
            }
        }

        public async Task DeleteHelpItem(HelpItemDTO helpItemDto)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var helpItem = scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems.FirstOrDefault(p => p.HelpItemID == helpItemDto.HelpItemID);
                if (helpItem != null)
                {
                    scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems.Remove(helpItem);
                    await scope.SaveChangesAsync();
                }
            }
        }

        #region Client using
        public List<HelpItemDTO> GetHelpItems(PageType pageType, string pageUrl)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                switch (pageType)
                {
                    case PageType.Tour: 
                        var pageTour = scope.DbContexts.Get<TargetFrameworkEntities>().HelpPages
                                  .FirstOrDefault(p => (p.PageType == (int)PageType.Tour));
                        if (pageTour != null)
                        {
                            return scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems
                                    .Where(i => (i.HelpPageID == pageTour.HelpPageID)).OrderBy(i => i.DisplayOrder).ToDtos();
                        }
                        return null;
                    case PageType.ShowMeHow:
                        var page = scope.DbContexts.Get<TargetFrameworkEntities>().HelpPages
                                 .FirstOrDefault(p => (p.PageUrl.ToLower().Equals(pageUrl.ToLower())) && (p.PageType == (int)PageType.ShowMeHow));
                        if (page != null)
                        {
                            return scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems
                                    .Where(i => (i.HelpPageID == page.HelpPageID)).OrderBy(i => i.DisplayOrder).ToDtos();
                        }
                        return null;                   
                    default :
                        return null;
                }
            }
        }

        public async Task<List<HelpItemDTO>> GetHelpItemsForCallout(Guid userId, DateTime createDate)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var helpItemUas = scope.DbContexts.Get<TargetFrameworkEntities>().HelpItemUserAccounts.Where(x => x.UserID == userId && x.Visible != true).ToList();
                var now = DateTime.Now;
                var helpItems = scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems.Where(x => x.EffectiveOn < now && x.CreatedOn > createDate && x.HelpPage.PageType == (int)PageType.Callout).ToList();
                if (helpItemUas != null && helpItemUas.Any() && helpItems != null && helpItems.Any())
                {
                    helpItems = helpItems.FindAll(x => !helpItemUas.Any(z => z.HelpItemID == x.HelpItemID));
                }
                if (helpItems != null && helpItems.Any())
                {
                    foreach (var item in helpItems)
                    {
                        var hiId = item.HelpItemID;

                        var existedHiuas = scope.DbContexts.Get<TargetFrameworkEntities>().HelpItemUserAccounts.Where(x => x.HelpItemID == hiId && x.UserID == userId).ToList();
                        if (existedHiuas != null && existedHiuas.Any())
                        {
                            foreach (var element in existedHiuas)
                            {
                                var helpItemUserAccountId = element.HelpItemUserAccountID;
                                var helpItemUc = scope.DbContexts.Get<TargetFrameworkEntities>().HelpItemUserAccounts.FirstOrDefault(p => p.HelpItemUserAccountID == helpItemUserAccountId);
                                if (helpItemUc != null)
                                {
                                    helpItemUc.Visible = false;
                                }
                            }
                        }
                        else
                        {
                            var helpItemUserAccount = new HelpItemUserAccount();
                            helpItemUserAccount.HelpItemUserAccountID = Guid.NewGuid();
                            helpItemUserAccount.HelpItemID = item.HelpItemID;
                            helpItemUserAccount.CreatedOn = DateTime.Now;
                            helpItemUserAccount.UserID = userId;
                            scope.DbContexts.Get<TargetFrameworkEntities>().HelpItemUserAccounts.Add(helpItemUserAccount);
                        }
                    }
                    await scope.SaveChangesAsync();
                }
                return helpItems.ToDtos();
            }
        }
        #endregion

        #region Request Support
        public async Task<Guid> CreateRequestSupport(RequestSupportDTO requestSupportDto)
        {
            Ensure.That(requestSupportDto).IsNotNull();
           
            requestSupportDto.RequestSupportID = Guid.NewGuid();

            using (var scope = DbContextScopeFactory.Create())
            {
                var requestSupports = scope.DbContexts.Get<TargetFrameworkEntities>().RequestSupports;
                var highestTicketNumber = requestSupports.Any() ? requestSupports.Max(x => x.TicketNumber) : 0;
                requestSupportDto.TicketNumber = highestTicketNumber + 1;
                RequestSupport requestSupport = requestSupportDto.ToEntity();
                requestSupports.Add(requestSupport);
                await scope.SaveChangesAsync();
            }
            return requestSupportDto.RequestSupportID;
        }
        #endregion
    }
}

