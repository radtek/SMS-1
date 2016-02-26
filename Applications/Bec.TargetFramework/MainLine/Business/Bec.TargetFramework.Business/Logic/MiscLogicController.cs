using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure;
using nClam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Logic
{
    public class MiscLogicController : LogicBase
    {
        public async Task<Guid> AddNewsArticle(NewsArticleDTO dto)
        {
            dto.NewsArticleID = Guid.NewGuid();
            using (var scope = DbContextScopeFactory.Create())
            {
                scope.DbContexts.Get<TargetFrameworkEntities>().NewsArticles.Add(dto.ToEntity());
                await scope.SaveChangesAsync();
            }
            
            return dto.NewsArticleID;
        }

        private async Task RemoveNewsArticle(Guid articleID)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                {
                    NewsArticle del = new NewsArticle { NewsArticleID = articleID };
                    scope.DbContexts.Get<TargetFrameworkEntities>().Entry(del).State = System.Data.Entity.EntityState.Deleted;
                }
                await scope.SaveChangesAsync();
            }
        }

        public async Task AddOrModifyFieldUpdate(FieldUpdateDTO dto)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var entity = scope.DbContexts.Get<TargetFrameworkEntities>().FieldUpdates.SingleOrDefault(x=>
                    x.ActivityType == dto.ActivityType &&
                    x.ActivityID == dto.ActivityID &&
                    x.ParentType == dto.ParentType &&
                    x.ParentID == dto.ParentID &&
                    x.FieldName == dto.FieldName);

                if (entity == null)
                    scope.DbContexts.Get<TargetFrameworkEntities>().FieldUpdates.Add(dto.ToEntity());
                else
                {
                    entity.ModifiedOn = dto.ModifiedOn;
                    entity.UserAccountOrganisationID = dto.UserAccountOrganisationID;
                    entity.Value = dto.Value;
                }
                
                await scope.SaveChangesAsync();
            }
        }

    }
}
