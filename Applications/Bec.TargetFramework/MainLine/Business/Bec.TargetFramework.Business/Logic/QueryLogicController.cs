using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Attributes;
using Bec.TargetFramework.Infrastructure;
using Microsoft.OData.Edm;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
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
            if (disposing && db != null) db.Dispose();
            base.Dispose(disposing);
        }

        public async Task UpdateGraph(string id, JObject patch)
        {
            var dbSet = dbType.GetProperty(id).GetValue(db) as IQueryable;
            var itemType = dbSet.GetType().GetGenericArguments()[0];

            var model = this.GetEdmModel(itemType);
            var entitySetContext = new ODataQueryContext(model, itemType, Request.ODataProperties().Path);
            var options = new ODataQueryOptions(entitySetContext, Request);

            var res = options.ApplyTo(dbSet);
            var list = await res.ToListAsync();
            var item = list.Single();

            patchObject(db, item, patch);

            await db.SaveChangesAsync();
        }

        private void patchObject(DbContext dbc, object obj, JObject patch)
        {
            var t = ObjectContext.GetObjectType(obj.GetType());
            foreach (var prop in patch.Properties())
            {
                var p = t.GetProperty(prop.Name);
                if (p != null)
                {
                    if (prop.Value is JObject)
                        patchObject(dbc, p.GetValue(obj), prop.Value as JObject);
                    else
                    {
                        if (prop.Value is JArray)
                        {
                            var att = p.GetCustomAttributes(typeof(CollectionUpdateBehaviourAttribute), false).SingleOrDefault() as CollectionUpdateBehaviourAttribute;
                            if (att != null && att.Behaviour == UpdateBehaviour.Replace)
                            {
                                var col = p.GetValue(obj);
                                var colType = col.GetType();
                                var itemType = colType.GetGenericArguments()[0];

                                colType.GetMethod("Clear").Invoke(col, null);
                                foreach (JObject item in prop.Value as JArray)
                                {
                                    object newItem = Activator.CreateInstance(itemType);
                                    patchObject(dbc, newItem, item);
                                    colType.GetMethod("Add").Invoke(col, new[] { newItem });
                                }
                            }
                        }
                        else
                        {
                            if (prop.Name == "RowVersion")
                                dbc.Entry(obj).Property("RowVersion").OriginalValue = (Int64)prop.Value;
                            else
                                p.SetValue(obj, Convert.ChangeType(prop.Value, p.PropertyType));
                        }
                    }
                }
            }
        }
    }

    public class QueryResult
    {
        public long? Count { get; set; }
        public Uri NextLink { get; set; }
        public IQueryable Items { get; set; }
    }
}