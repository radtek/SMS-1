using Bec.TargetFramework.Business.Extensions;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure;
using nClam;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
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
    }
}
