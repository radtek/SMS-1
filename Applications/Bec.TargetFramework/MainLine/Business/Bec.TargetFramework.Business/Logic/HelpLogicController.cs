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
        public async Task<Guid> CreateHelpPage(HelpPageDTO helpPageDto, string createdBy)
        {
            try
            {
                Ensure.That(helpPageDto).IsNotNull();
                helpPageDto.HelpPageID = Guid.NewGuid();
                helpPageDto.CreatedBy = createdBy;
                helpPageDto.CreatedOn = DateTime.Now;
                using (var scope = DbContextScopeFactory.Create())
                {
                    scope.DbContexts.Get<TargetFrameworkEntities>().HelpPages.Add(helpPageDto.ToEntity());

                    if (helpPageDto.HelpPageItems != null && helpPageDto.HelpPageItems.Count > 0)
                    {
                        helpPageDto.HelpPageItems.ForEach(item =>
                        {
                            item.HelpPageID = helpPageDto.HelpPageID;
                            item.HelpPageItemID = Guid.NewGuid();
                            scope.DbContexts.Get<TargetFrameworkEntities>().HelpPageItems.Add(item.ToEntity());
                        });
                    }
                    await scope.SaveChangesAsync();
                }
                return helpPageDto.HelpPageID;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw ex;
            }
            
        }

        public async Task<Guid> EditHelpPage(HelpPageDTO helpPageDto, string modifiedBy)
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
                    helpPage.ModifiedBy = modifiedBy;
                    helpPage.ModifiedOn = DateTime.Now;

                    scope.DbContexts.Get<TargetFrameworkEntities>().Entry(helpPage);

                    if (helpPageDto.HelpPageItems != null && helpPageDto.HelpPageItems.Count > 0)
                    {
                        foreach (var item in helpPageDto.HelpPageItems)
                        {
                            if (item.Status == HelpPageItemStatusEnum.New.GetIntValue())
                            {
                                item.HelpPageID = helpPageDto.HelpPageID;
                                item.HelpPageItemID = Guid.NewGuid();
                                scope.DbContexts.Get<TargetFrameworkEntities>().HelpPageItems.Add(item.ToEntity());
                            }
                            else if (item.Status == HelpPageItemStatusEnum.Modified.GetIntValue())
                            {
                                var itemInDb = scope.DbContexts.Get<TargetFrameworkEntities>().HelpPageItems.FirstOrDefault(x => x.HelpPageItemID == item.HelpPageItemID);
                                if (itemInDb != null)
                                {
                                    itemInDb.Description = item.Description;
                                    itemInDb.DisplayOrder = item.DisplayOrder;
                                    itemInDb.EffectiveOn = item.EffectiveOn;
                                    itemInDb.Position = item.Position;
                                    itemInDb.Selector = item.Selector;
                                    itemInDb.TabContainerId = item.TabContainerId;
                                    itemInDb.Title = item.Title;
                                    itemInDb.ModifiedOn = DateTime.Now;
                                    scope.DbContexts.Get<TargetFrameworkEntities>().Entry(itemInDb);
                                    var helpPageItemUcs = scope.DbContexts.Get<TargetFrameworkEntities>().HelpPageItemUserAccounts.Where(x=>x.HelpPageItemID == item.HelpPageItemID);
                                    if (helpPageItemUcs != null && helpPageItemUcs.Any())
                                    {
                                        foreach (var hpiUc in helpPageItemUcs)
                                        {
                                            hpiUc.Visible = true;
                                        }
                                    }
                                }
                            }
                            else if (item.Status == HelpPageItemStatusEnum.Deleted.GetIntValue())
                            {
                                var itemInDb = scope.DbContexts.Get<TargetFrameworkEntities>().HelpPageItems.FirstOrDefault(x => x.HelpPageItemID == item.HelpPageItemID);
                                if (itemInDb != null)
                                {
                                    scope.DbContexts.Get<TargetFrameworkEntities>().HelpPageItems.Remove(itemInDb);
                                }
                            }
                        };
                    }
                    await scope.SaveChangesAsync();
                }
            }
            return helpPageDto.HelpPageID;
        }

        public async Task<Guid> CreateHelpItemUserAccount(HelpPageItemUserAccountDTO helpItemUserAccountDTO)
        {
            Ensure.That(helpItemUserAccountDTO).IsNotNull();
            helpItemUserAccountDTO.HelpItemUserAccountID = Guid.NewGuid();
            using (var scope = DbContextScopeFactory.Create())
            {
                HelpPageItemUserAccount HelpPageItemUserAccount = helpItemUserAccountDTO.ToEntity();
                scope.DbContexts.Get<TargetFrameworkEntities>().HelpPageItemUserAccounts.Add(HelpPageItemUserAccount);
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

        private static List<HelpPageItemDTO> GetHelpPageItems(IDbContextReadOnlyScope scope, HelpPage page)
        {
            return scope.DbContexts.Get<TargetFrameworkEntities>().HelpPageItems
                    .Where(i => (i.HelpPageID == page.HelpPageID)).OrderBy(i => i.DisplayOrder).ToDtos();
        }

        public List<HelpPageItemDTO> GetHelpItems(HelpPageTypeIdEnum pageType, string pageUrl)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var pageTypeValue = pageType.GetIntValue();
                if (pageType == HelpPageTypeIdEnum.Tour)
                {                    
                    var pageTour = scope.DbContexts.Get<TargetFrameworkEntities>().HelpPages
                                .FirstOrDefault(p => (p.HelpPageTypeId == pageTypeValue));
                    if (pageTour != null)
                    {
                        return GetHelpPageItems(scope, pageTour);
                    }
                }
                else if (pageType == HelpPageTypeIdEnum.ShowMeHow)
                {                    
                    var page = scope.DbContexts.Get<TargetFrameworkEntities>().HelpPages
                                 .FirstOrDefault(p => (p.PageUrl.ToLower().Equals(pageUrl.ToLower())) && (p.HelpPageTypeId == pageTypeValue));
                    if (page != null)
                    {
                        return GetHelpPageItems(scope, page);
                    }
                }
                return null;
            }
        }



        public async Task<List<HelpPageItemDTO>> GetHelpItemsForCallout(Guid userId, DateTime createDate)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var helpItemUas = scope.DbContexts.Get<TargetFrameworkEntities>().HelpPageItemUserAccounts.Where(x => x.UserID == userId && x.Visible.HasValue && !x.Visible.Value).ToList();
                var now = DateTime.Now;
                var pageTypeValue = HelpPageTypeIdEnum.Callout.GetIntValue();
                var helpItems = scope.DbContexts.Get<TargetFrameworkEntities>().HelpPageItems.Where(x => x.EffectiveOn < now && x.CreatedOn > createDate && x.HelpPage.HelpPageTypeId == pageTypeValue).ToList();
                if (helpItemUas != null && helpItemUas.Any() && helpItems != null && helpItems.Any())
                {
                    helpItems = helpItems.FindAll(x => !helpItemUas.Any(z => z.HelpPageItemID == x.HelpPageItemID));
                }
                if (helpItems != null && helpItems.Any())
                {
                    foreach (var item in helpItems)
                    {
                        var hiId = item.HelpPageItemID;

                        var existedHiuas = scope.DbContexts.Get<TargetFrameworkEntities>().HelpPageItemUserAccounts.Where(x => x.HelpPageItemID == hiId && x.UserID == userId).ToList();
                        if (existedHiuas != null && existedHiuas.Any())
                        {
                            foreach (var element in existedHiuas)
                            {
                                var helpItemUserAccountId = element.HelpItemUserAccountID;
                                var helpItemUc = scope.DbContexts.Get<TargetFrameworkEntities>().HelpPageItemUserAccounts.FirstOrDefault(p => p.HelpItemUserAccountID == helpItemUserAccountId);
                                if (helpItemUc != null)
                                {
                                    helpItemUc.Visible = false;
                                }
                            }
                        }
                        else
                        {
                            var helpItemUserAccount = new HelpPageItemUserAccount();
                            helpItemUserAccount.HelpItemUserAccountID = Guid.NewGuid();
                            helpItemUserAccount.HelpPageItemID = item.HelpPageItemID;
                            helpItemUserAccount.CreatedOn = DateTime.Now;
                            helpItemUserAccount.UserID = userId;
                            scope.DbContexts.Get<TargetFrameworkEntities>().HelpPageItemUserAccounts.Add(helpItemUserAccount);
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

