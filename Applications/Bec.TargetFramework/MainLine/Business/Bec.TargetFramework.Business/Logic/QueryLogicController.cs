using Bec.TargetFramework.Data;
using Bec.TargetFramework.Infrastructure;
using Microsoft.OData.Edm;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using System.Web.OData.Query;
using System.Web.OData.Routing;

namespace Bec.TargetFramework.Business.Logic
{
    public class QueryLogicController : ApiController
    {
        TargetFrameworkEntities db;
        Type dbType = typeof(TargetFrameworkEntities);
        public QueryLogicController()
        {
            db = new TargetFrameworkEntities();
        }

        public IHttpActionResult Get(string id)
        {
            var dbSet = dbType.GetProperty(id).GetValue(db) as IQueryable;
            var itemType = dbSet.GetType().GetGenericArguments()[0];

            var model = this.GetEdmModel(itemType);
            var entitySetContext = new ODataQueryContext(model, itemType, Request.ODataProperties().Path);
            var options = new ODataQueryOptions(entitySetContext, Request);

            //ODataQuerySettings settings = new ODataQuerySettings { PageSize = 10 };
            var res = options.ApplyTo(dbSet);//, settings);
            return Ok(new QueryResult { Items = res, Count = Request.ODataProperties().TotalCount, NextLink = Request.ODataProperties().NextLink });
        }

        private static ConcurrentDictionary<Type, Lazy<IEdmModel>> models = new ConcurrentDictionary<Type, Lazy<IEdmModel>>();
        private IEdmModel GetEdmModel(Type entityClrType)
        {
            return models.GetOrAdd(entityClrType, (type) => 
                new Lazy<IEdmModel>(() =>
                    {
                        ODataConventionModelBuilder builder = new ODataConventionModelBuilder(ActionContext.ActionDescriptor.Configuration, isQueryCompositionMode: true);
                        EntityTypeConfiguration entityTypeConfiguration = builder.AddEntityType(type);
                        builder.AddEntitySet(type.Name, entityTypeConfiguration);
                        return builder.GetEdmModel();
                    }
                )).Value;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }

    public class QueryResult
    {
        public long? Count { get; set; }
        public Uri NextLink { get; set; }
        public IQueryable Items { get; set; }
    }
}