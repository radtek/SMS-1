using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.SB.Data;
using Bec.TargetFramework.SB.Entities;
using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.SB.Hosts.SBService.Helpers
{
    public class LogicHelper
    {
        public static int GetClassificationDataForTypeName(UnitOfWorkScope<TargetFrameworkCoreEntities> scope, string categoryName, string typeName)
        {
            int classificationTypeID = 0;

            List<ClassificationTypeDTO> list = new List<ClassificationTypeDTO>();

            var categoryId = scope.DbContext.ClassificationTypeCategories.Single(s => s.Name.Equals(categoryName));

            classificationTypeID = scope.DbContext.ClassificationTypes.Single(s => s.Name.Equals(typeName)).ClassificationTypeID;

            return classificationTypeID;
        }

        public static VStatusType GetStatusType(UnitOfWorkScope<TargetFrameworkCoreEntities> scope, string statusTypeEnum, string status)
        {
            Ensure.That(scope).IsNotNull();
            Ensure.That(status).IsNotNullOrEmpty();
            Ensure.That(statusTypeEnum).IsNotNullOrEmpty();

            return scope.DbContext.VStatusTypes.Single(s => s.Name.Equals(status) && s.StatusTypeName.Equals(statusTypeEnum));

        }
    }
}
