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
                scope.DbContexts.Get<TargetFrameworkEntities>().HelpPages.Add(helpPageDto.ToEntity());

                if (helpPageDto.HelpItems.Count > 0)
                {
                    helpPageDto.HelpItems.ForEach(item =>
                    {
                        item.HelpPageID = helpPageDto.HelpPageID;
                        item.HelpItemID = Guid.NewGuid();
                        scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems.Add(item.ToEntity());
                    });
                }
                await scope.SaveChangesAsync();
            }
            return helpPageDto.HelpPageID;
        }

        public async Task<Guid> EditHelpPage(HelpPageDTO helpPageDto)
        {
            Ensure.That(helpPageDto).IsNotNull();
            using (var scope = DbContextScopeFactory.Create())
            {
                var helpPage = scope.DbContexts.Get<TargetFrameworkEntities>().HelpPages.FirstOrDefault(p => p.HelpPageID == helpPageDto.HelpPageID);
                if (helpPage != null)
                {
                    helpPage.ModifiedOn = DateTime.Now;
                    helpPage.PageName = helpPageDto.PageName;
                    helpPage.PageUrl = helpPageDto.PageUrl;
                    
                    scope.DbContexts.Get<TargetFrameworkEntities>().Entry(helpPage).State = System.Data.Entity.EntityState.Modified;

                    if (helpPageDto.HelpItems.Count > 0)
                    {
                        foreach(var item in helpPageDto.HelpItems)
                        {
                            if (item.Status == 1)
                            {
                                item.HelpPageID = helpPageDto.HelpPageID;
                                item.HelpItemID = Guid.NewGuid();
                                scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems.Add(item.ToEntity());
                            }
                            else if (item.Status == 2)
                            {
                                var itemInDb = scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems.FirstOrDefault(x=> x.HelpItemID == item.HelpItemID);
                                if (itemInDb!=null)
                                {
                                    itemInDb.Description = item.Description;
                                    itemInDb.DisplayOrder = item.DisplayOrder;
                                    itemInDb.EffectiveOn = item.EffectiveOn;
                                    itemInDb.Position = item.Position;
                                    itemInDb.Selector = item.Selector;
                                    itemInDb.TabContainerId = item.TabContainerId;
                                    itemInDb.Title = item.Title;                                    
                                    itemInDb.ModifiedOn = DateTime.Now;
                                    scope.DbContexts.Get<TargetFrameworkEntities>().Entry(itemInDb).State = System.Data.Entity.EntityState.Modified;    
                                }                                
                            }
                            else if (item.Status == 3)
                            {
                                var itemInDb = scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems.FirstOrDefault(x => x.HelpItemID == item.HelpItemID);
                                if (itemInDb != null)
                                {
                                    scope.DbContexts.Get<TargetFrameworkEntities>().Entry(itemInDb).State = System.Data.Entity.EntityState.Deleted;
                                }
                            }
                        };
                    }
                    await scope.SaveChangesAsync();
                }
            }
            return helpPageDto.HelpPageID;
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
            Ensure.That(helpPageDto).IsNotNull();
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

        #region Client using
        public List<HelpItemDTO> GetHelpItems(PageType pageType, string pageUrl)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                if (pageType == PageType.Tour)
                {
                    var pageTour = scope.DbContexts.Get<TargetFrameworkEntities>().HelpPages
                                .FirstOrDefault(p => (p.PageType == PageType.Tour.GetIntValue()));
                    if (pageTour != null)
                    {
                        return scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems
                                .Where(i => (i.HelpPageID == pageTour.HelpPageID)).OrderBy(i => i.DisplayOrder).ToDtos();
                    }
                }
                else if (pageType == PageType.ShowMeHow)
                {
                    var page = scope.DbContexts.Get<TargetFrameworkEntities>().HelpPages
                                 .FirstOrDefault(p => (p.PageUrl.ToLower().Equals(pageUrl.ToLower())) && (p.PageType == PageType.ShowMeHow.GetIntValue()));
                    if (page != null)
                    {
                        return scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems
                                .Where(i => (i.HelpPageID == page.HelpPageID)).OrderBy(i => i.DisplayOrder).ToDtos();
                    }
                }
                return null;
            }
        }

        public async Task<List<HelpItemDTO>> GetHelpItemsForCallout(Guid userId, DateTime createDate)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var helpItemUas = scope.DbContexts.Get<TargetFrameworkEntities>().HelpItemUserAccounts.Where(x => x.UserID == userId && x.Visible.HasValue && !x.Visible.Value).ToList();
                var now = DateTime.Now;
                var helpItems = scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems.Where(x => x.EffectiveOn < now && x.CreatedOn > createDate && x.HelpPage.PageType == PageType.Callout.GetIntValue()).ToList();
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
                return helpItems.OrderBy(i => i.DisplayOrder).ToDtos();
            }
        }
        #endregion
    }
}

