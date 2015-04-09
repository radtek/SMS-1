using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.SB.Entities;
using EnsureThat;
using Bec.TargetFramework.SB.Data;

namespace Bec.TargetFramework.SB.Hosts.SBService.Base
{
    public class LogicBase : ApiController
    {
        public LogicBase(ILogger logger, ICacheProvider cacheProvider)
        {
            Ensure.That(logger).IsNotNull();
            Ensure.That(cacheProvider).IsNotNull();

            this.m_Logger = logger;
            this.m_CacheProvider = cacheProvider;
        }

        public ILogger Logger
        {
            get
            {
                return this.m_Logger;
            }
        }

        public ICacheProvider CacheProvider
        {
            get
            {
                return this.m_CacheProvider;
            }
        }

        public int GetClassificationDataForTypeName(string categoryName, string typeName)
        {
            int classificationTypeID = 0;

            List<ClassificationTypeDTO> list = new List<ClassificationTypeDTO>();

            using (
                var scope = new UnitOfWorkScope<TargetFrameworkCoreEntities>(UnitOfWorkScopePurpose.Reading,
                    this.Logger))
            {
                var categoryId = scope.DbContext.ClassificationTypeCategories.Single(s => s.Name.Equals(categoryName));

                classificationTypeID = scope.DbContext.ClassificationTypes.Single(s => s.Name.Equals(typeName)).ClassificationTypeID;
            }

            return classificationTypeID;
        }

        public static VStatusType GetStatusType(UnitOfWorkScope<TargetFrameworkCoreEntities> scope, string statusTypeEnum,
string status)
        {
            Ensure.That(scope).IsNotNull();
            Ensure.That(status).IsNotNullOrEmpty();
            Ensure.That(statusTypeEnum).IsNotNullOrEmpty();

            return scope.DbContext.VStatusTypes.Single(s => s.Name.Equals(status) && s.StatusTypeName.Equals(statusTypeEnum));

        }

        private ILogger m_Logger { get; set; }

        private ICacheProvider m_CacheProvider { get; set; }

        public void SetAuditFields<T>(T entity, bool isNew) where T : class
        {
            //var userIdentityDto = GetUserIdentificationMessageDTOFromContext();

            //var properties = TypeDescriptor.GetProperties(typeof (T));

            //if (isNew)
            //{
            //    if (properties["CreatedOn"] != null)
            //    {
            //        properties["CreatedOn"].SetValue(entity, DateTime.Now);
            //    }
                
            //    if (properties["CreatedBy"] != null)
            //    {
            //        if (userIdentityDto != null)
            //            properties["CreatedBy"].SetValue(entity, userIdentityDto.UserID);
            //        else
            //            properties["CreatedBy"].SetValue(entity, ClaimsPrincipal.Current.Identity.Name);
            //    }
            //}

            //if (properties["ModifiedOn"] != null)
            //{
            //    properties["ModifiedOn"].SetValue(entity, DateTime.Now);
            //}
            //if (properties["ModifiedBy"] != null)
            //{
            //    if (userIdentityDto != null)
            //        properties["ModifiedBy"].SetValue(entity, userIdentityDto.UserID);
            //    else
            //        properties["ModifiedBy"].SetValue(entity, ClaimsPrincipal.Current.Identity.Name);
            //}
        }
       

    }
}
