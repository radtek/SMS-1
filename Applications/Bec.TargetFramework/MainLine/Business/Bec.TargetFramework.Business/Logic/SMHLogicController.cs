using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Injections;
using Bec.TargetFramework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Logic
{
    [Trace(TraceExceptionsOnly = true)]
    public class SmhLogicController : LogicBase
    {
        public UserLogicController UserLogic { get; set; }

        #region Management

        public async Task<SMHPageDTO> AddSmhPage(SMHPageDTO smhPageDto)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var smhPage = smhPageDto.ToEntity();
                smhPage.PageID = Guid.NewGuid();
                scope.DbContexts.Get<TargetFrameworkEntities>().SMHPages.Add(smhPage);
                await scope.SaveChangesAsync();
                return smhPage.ToDto();
            }
        }

        public async Task EditSmhPage(SMHPageDTO smhPageDto)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var pageInDb = scope.DbContexts.Get<TargetFrameworkEntities>().SMHPages.FirstOrDefault(p => p.PageID == smhPageDto.PageID);
                if (pageInDb != null)
                {
                    pageInDb.PageName = smhPageDto.PageName;
                    pageInDb.PageURL = smhPageDto.PageURL;
                    pageInDb.RoleId = smhPageDto.RoleId;

                    var entry = scope.DbContexts.Get<TargetFrameworkEntities>().Entry(pageInDb);

                    entry.State = System.Data.Entity.EntityState.Modified;
                    await scope.SaveChangesAsync();
                }
            }
        }

        public async Task DeleteSmhPage(SMHPageDTO smhPageDto)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var pageInDb = scope.DbContexts.Get<TargetFrameworkEntities>().SMHPages.FirstOrDefault(p => p.PageID == smhPageDto.PageID);
                if (pageInDb != null)
                {
                    var entry = scope.DbContexts.Get<TargetFrameworkEntities>().Entry(pageInDb);

                    entry.State = System.Data.Entity.EntityState.Deleted;
                    await scope.SaveChangesAsync();
                }
            }
        }

        public List<SMHItemDTO> GetItemOnPage(Guid pageID)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().SMHItems
                    .Where(i => (i.PageID.Equals(pageID))).ToDtos();
            }
        }


        public async Task<SMHItemDTO> AddSmhItem(SMHItemDTO smhItemDto)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var smhItem = smhItemDto.ToEntity();
                smhItem.ItemID = Guid.NewGuid();
                scope.DbContexts.Get<TargetFrameworkEntities>().SMHItems.Add(smhItem);
                await scope.SaveChangesAsync();
                return smhItem.ToDto();
            }
        }

        public async Task EditSmhItem(SMHItemDTO smhItemDto)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var itemInDb = scope.DbContexts.Get<TargetFrameworkEntities>().SMHItems.FirstOrDefault(i => i.ItemID == smhItemDto.ItemID);
                if (itemInDb != null)
                {
                    itemInDb.PageID = smhItemDto.PageID;
                    itemInDb.ItemName = smhItemDto.ItemName;
                    itemInDb.ItemDescription = smhItemDto.ItemDescription;
                    itemInDb.ItemSelector = smhItemDto.ItemSelector;
                    itemInDb.ItemPosition = smhItemDto.ItemPosition;
                    itemInDb.TabContainerId = smhItemDto.TabContainerId;
                    itemInDb.ItemOrder = smhItemDto.ItemOrder;

                    var entry = scope.DbContexts.Get<TargetFrameworkEntities>().Entry(itemInDb);

                    entry.State = System.Data.Entity.EntityState.Modified;
                    await scope.SaveChangesAsync();
                }
            }
        }

        public async Task DeleteSmhItem(SMHItemDTO smhItemDto)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var itemInDb = scope.DbContexts.Get<TargetFrameworkEntities>().SMHItems.FirstOrDefault(i => i.ItemID == smhItemDto.ItemID);
                if (itemInDb != null)
                {
                    var entry = scope.DbContexts.Get<TargetFrameworkEntities>().Entry(itemInDb);

                    entry.State = System.Data.Entity.EntityState.Deleted;
                    await scope.SaveChangesAsync();
                }
            }
        }
        #endregion

        #region Client using
        public async Task<List<SMHItemDTO>> GetItemOnPageForCurrentUser(Guid uaoID, Guid ogrId, string pageUrl)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var userOgrRoles = await UserLogic.GetRoles(uaoID, 1);
                foreach (var userOgrRole in userOgrRoles)
                {
                    var orgRole = scope.DbContexts.Get<TargetFrameworkEntities>().OrganisationRoles
                                .FirstOrDefault(r => (r.OrganisationID == ogrId) && (r.OrganisationRoleID == userOgrRole.OrganisationRoleID));

                    if (orgRole != null && orgRole.ParentID != null)
                    {
                        var page = scope.DbContexts.Get<TargetFrameworkEntities>().SMHPages
                                 .FirstOrDefault(p => (p.PageURL.ToLower().Equals(pageUrl.ToLower()))
                                                    && (p.RoleId == orgRole.ParentID));
                        if (page != null)
                        {
                            return scope.DbContexts.Get<TargetFrameworkEntities>().SMHItems
                                    .Where(i => (i.PageID == page.PageID)).OrderBy(i => i.ItemOrder).ToDtos();
                        }
                    }
                }
                return null;
            }
        }
        #endregion
    }
}
