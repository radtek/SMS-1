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
using NServiceBus;

namespace Bec.TargetFramework.SB.Hosts.SBService.Base
{
    public class LogicBase : ApiController
    {
        public ILogger Logger { get; set; }
        public ICacheProvider CacheProvider { get; set; }

        public IBus Bus { get; set; }

        public LogicBase()
        {
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
    }
}
