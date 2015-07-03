using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;
using EnsureThat;
using Autofac;


namespace Bec.TargetFramework.Infrastructure
{
    public class LogicBase : ApiController
    {
        public ILogger Logger { get; set; }
        public ICacheProvider CacheProvider { get; set; }

        public UserNameService UserNameService { get; set; }
        
        public LogicBase()
        {            
        }

        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);

            // this provides services with the "User" header from the original request
            // (for when service methods are invoked indirectly, via another controller)
            // as ApiController.Request is not populated when calling methods directly.
            // UserNameService, if registered, must be scoped 'per request'.
            if (UserNameService != null) UserNameService.GetUserName(this);
        }

        //public int GetClassificationDataForTypeName(string categoryName, string typeName)
        //{
        //    int classificationTypeID = 0;

        //    List<ClassificationTypeDTO> list = new List<ClassificationTypeDTO>();

        //    using (
        //        var scope = new UnitOfWorkScope<TargetFrameworkCoreEntities>(UnitOfWorkScopePurpose.Reading,
        //            this.Logger))
        //    {
        //        var categoryId = scope.DbContext.ClassificationTypeCategories.Single(s => s.Name.Equals(categoryName));

        //        classificationTypeID = scope.DbContext.ClassificationTypes.Single(s => s.Name.Equals(typeName)).ClassificationTypeID;
        //    }

        //    return classificationTypeID;
        //}

        //public static VStatusType GetStatusType(UnitOfWorkScope<TargetFrameworkCoreEntities> scope, string statusTypeEnum, string status)
        //{
        //    Ensure.That(scope).IsNotNull();
        //    Ensure.That(status).IsNotNullOrEmpty();
        //    Ensure.That(statusTypeEnum).IsNotNullOrEmpty();

        //    return scope.DbContext.VStatusTypes.Single(s => s.Name.Equals(status) && s.StatusTypeName.Equals(statusTypeEnum));

        //}
    }
}
