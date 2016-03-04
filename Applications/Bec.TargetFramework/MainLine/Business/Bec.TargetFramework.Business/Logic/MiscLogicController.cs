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

        public async Task ApproveUpdate(int activityType, Guid activityID, int parentType, Guid parentID, string fieldName)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var entity = scope.DbContexts.Get<TargetFrameworkEntities>().FieldUpdates.SingleOrDefault(x =>
                    x.ActivityType == activityType &&
                    x.ActivityID == activityID &&
                    x.ParentType == parentType &&
                    x.ParentID == parentID &&
                    x.FieldName == fieldName);

                if (entity == null) throw new InvalidOperationException();
                await PostImmediateUpdate(entity.ToDto());
                await scope.SaveChangesAsync();
            }
        }

        public async Task PostImmediateUpdate(FieldUpdateDTO dto)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                switch ((ActivityType)dto.ActivityType)
                {
                    case ActivityType.SmsTransaction:
                        await UpdateSmsTransaction(dto);
                        var entity = scope.DbContexts.Get<TargetFrameworkEntities>().FieldUpdates.SingleOrDefault(x =>
                            x.ActivityType == dto.ActivityType &&
                            x.ActivityID == dto.ActivityID &&
                            x.ParentType == dto.ParentType &&
                            x.ParentID == dto.ParentID &&
                            x.FieldName == dto.FieldName);
                        if (entity != null) scope.DbContexts.Get<TargetFrameworkEntities>().FieldUpdates.Remove(entity);
                        break;
                    default:
                        throw new InvalidOperationException();
                }
                await scope.SaveChangesAsync();
            }
        }

        private async Task UpdateSmsTransaction(FieldUpdateDTO entity)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var tx = scope.DbContexts.Get<TargetFrameworkEntities>().SmsTransactions.SingleOrDefault(x => x.SmsTransactionID == entity.ActivityID);
                SmsUserAccountOrganisationTransaction uaotx;

                switch ((FieldUpdateParentType)entity.ParentType)
                {
                    case FieldUpdateParentType.SmsTransaction:
                        CommonHelper.SetProperty(tx, entity.FieldName, entity.Value);
                        break;
                    case FieldUpdateParentType.SmsTransactionAddress:
                        if (tx.Address == null)
                            tx.Address = new Address();
                        else
                            CommonHelper.SetProperty(tx.Address, entity.FieldName, entity.Value);
                        break;
                    case FieldUpdateParentType.RegisteredHomeAddress:
                        uaotx = tx.SmsUserAccountOrganisationTransactions.Single(x => x.SmsUserAccountOrganisationTransactionID == entity.ParentID);
                        if (uaotx.Address == null)
                            uaotx.Address = new Address();
                        else
                            CommonHelper.SetProperty(uaotx.Address, entity.FieldName, entity.Value);
                        break;
                    case FieldUpdateParentType.Contact:
                        uaotx = tx.SmsUserAccountOrganisationTransactions.Single(x => x.SmsUserAccountOrganisationTransactionID == entity.ParentID);
                        CommonHelper.SetProperty(uaotx.Contact, entity.FieldName, entity.Value);
                        break;
                }
                await scope.SaveChangesAsync();
            }
        }

        public async Task RejectUpdate(int activityType, Guid activityID, int parentType, Guid parentID, string fieldName)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                FieldUpdate del = new FieldUpdate
                { 
                    ActivityType = activityType,
                    ActivityID = activityID,
                    ParentType = parentType,
                    ParentID = parentID,
                    FieldName = fieldName
                };
                scope.DbContexts.Get<TargetFrameworkEntities>().Entry(del).State = System.Data.Entity.EntityState.Deleted;

                await scope.SaveChangesAsync();
            }
        }

    }
}
