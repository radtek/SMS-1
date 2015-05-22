using System;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.ServiceModel;
using System.Web.Http;
using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Entities.DTO;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;
//using Fabrik.Common;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using EnsureThat;
using Bec.TargetFramework.Entities;

namespace Bec.TargetFramework.Business.Logic
{
    public class LogicBase : ApiController
    {
        public LogicBase(ILogger logger, ICacheProvider cacheProvider)
        {
            Ensure.That(logger);
            Ensure.That(cacheProvider);

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

        private ILogger m_Logger { get; set; }

        private ICacheProvider m_CacheProvider { get; set; }

        protected void SetAuditFields<T>(T entity, bool isNew) where T : class
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
        
        protected string GetUserName()
        {
            System.Collections.Generic.IEnumerable<string> values;
            if (Request.Headers.TryGetValues("User", out values))
                return values.First();
            else
                return "";
        }
    }
}
