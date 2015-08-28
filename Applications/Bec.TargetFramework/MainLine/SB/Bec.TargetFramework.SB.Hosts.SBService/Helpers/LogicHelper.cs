using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.SB.Data;
using Bec.TargetFramework.SB.Entities;
using EnsureThat;
using Mehdime.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.SB.Hosts.SBService.Helpers
{
    public class LogicHelper
    {
        public static int GetClassificationDataForTypeName(IDbContextReadOnlyScope scope, string categoryName, string typeName)
        {
            int classificationTypeID = 0;

            List<ClassificationTypeDTO> list = new List<ClassificationTypeDTO>();

            var categoryId = scope.DbContexts.Get<TargetFrameworkCoreEntities>().ClassificationTypeCategories.Single(s => s.Name.Equals(categoryName));

            classificationTypeID = scope.DbContexts.Get<TargetFrameworkCoreEntities>().ClassificationTypes.Single(s => s.Name.Equals(typeName)).ClassificationTypeID;

            return classificationTypeID;
        }

        public static VStatusType GetStatusType(IDbContextReadOnlyScope scope, string statusTypeEnum, string status)
        {
            Ensure.That(scope).IsNotNull();
            Ensure.That(status).IsNotNullOrEmpty();
            Ensure.That(statusTypeEnum).IsNotNullOrEmpty();

            return scope.DbContexts.Get<TargetFrameworkCoreEntities>().VStatusTypes.Single(s => s.Name.Equals(status) && s.StatusTypeName.Equals(statusTypeEnum));

        }
    }
}
