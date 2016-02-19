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
        public async Task<Guid> CreateHelpPage(HelpPageDTO HelpPageDTO)
        {
            Ensure.That(HelpPageDTO).IsNotNull();
            HelpPageDTO.HelpPageID = Guid.NewGuid();
            using (var scope = DbContextScopeFactory.Create())
            {
                HelpPage HelpPage = HelpPageDTO.ToEntity();
                scope.DbContexts.Get<TargetFrameworkEntities>().HelpPages.Add(HelpPage);
                await scope.SaveChangesAsync();
            }
            return HelpPageDTO.HelpPageID;
        }

        public async Task<Guid> CreateHelpItem(HelpItemDTO HelpItemDTO)
        {
            Ensure.That(HelpItemDTO).IsNotNull();
            HelpItemDTO.HelpItemID = Guid.NewGuid();
            using (var scope = DbContextScopeFactory.Create())
            {
                HelpItem HelpItem = HelpItemDTO.ToEntity();
                scope.DbContexts.Get<TargetFrameworkEntities>().HelpItems.Add(HelpItem);
                await scope.SaveChangesAsync();
            }
            return HelpItemDTO.HelpItemID;
        }

        public async Task<Guid> CreateHelpItemUserAccount(HelpItemUserAccountDTO HelpItemUserAccountDTO)
        {
            Ensure.That(HelpItemUserAccountDTO).IsNotNull();
            HelpItemUserAccountDTO.HelpItemUserAccountID = Guid.NewGuid();
            using (var scope = DbContextScopeFactory.Create())
            {
                HelpItemUserAccount HelpItemUserAccount = HelpItemUserAccountDTO.ToEntity();
                scope.DbContexts.Get<TargetFrameworkEntities>().HelpItemUserAccounts.Add(HelpItemUserAccount);
                await scope.SaveChangesAsync();
            }
            return HelpItemUserAccountDTO.HelpItemUserAccountID;
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
                    case PageType.Callout:
                        return null;
                    default :
                        return null;
                }
            }
        }
        #endregion
    }
}

