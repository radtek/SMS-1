using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Data.Infrastructure.Caching;
using Bec.TargetFramework.Data.Infrastructure.FetchStrategies;
using Bec.TargetFramework.Data.Infrastructure.Helpers;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using System.Collections.Generic;
using ServiceStack.Text;

namespace Bec.TargetFramework.Data.Infrastructure.EfRepository
{
    public class EfCompoundKeyRepositoryBase<T> : LinqCompoundKeyRepositoryBase<T> where T : class, new()
    {
        protected IDbSet<T> DbSet { get; private set; }
        protected DbContext Context { get; private set; }

        internal EfCompoundKeyRepositoryBase(DbContext dbContext, ICompoundKeyCachingStrategy<T> cachingStrategy = null)
            : base(cachingStrategy)
        {
            Initialize(dbContext);
        }

        private void Initialize(DbContext dbContext)
        {
            Context = dbContext;
            DbSet = Context.Set<T>();
        }

        protected override void AddItem(T entity)
        {
            // no generating primary keys
            DbSet.Add(entity);
        }

        protected override void DeleteItem(T entity)
        {
            DbSet.Remove(entity);
        }

        protected override void UpdateItem(T entity)
        {
            var entry = Context.Entry<T>(entity);

            if (entry.State == EntityState.Detached)
            {
                object[] keys;

                if (GetPrimaryKeys(entity, out keys))
                {
                    // check to see if this item is already attached
                    //  if it is then we need to copy the values to the attached value instead of changing the State to modified since it will throw a duplicate key exception
                    //  specifically: "An object with the same key already exists in the ObjectStateManager. The ObjectStateManager cannot track multiple objects with the same key."
                    var attachedEntity = Context.Set<T>().Find(keys);
                    if (attachedEntity != null)
                    {
                        Context.Entry(attachedEntity).CurrentValues.SetValues(entity);

                        return;
                    }
                }
            }

            // default
            entry.State = EntityState.Modified;
        }

        protected override void SaveChanges()
        {
            int count = 0;

            try
            {
                count = Context.SaveChanges();

            }
            catch (DbEntityValidationException e)
            {
                this.EntityErrors = new List<EntityError>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    var entity = eve.Entry.Entity;
                    var entityTypeName = entity.GetType().FullName;

                    Dictionary<string, object> entityValues = new Dictionary<string, object>();

                    //eve.Entry.OriginalValues.PropertyNames.ToList().ForEach(item =>
                    //{
                    //    entityValues.Add(item, eve.Entry.OriginalValues[item]);
                    //});

                    foreach (var ve in eve.ValidationErrors)
                    {
                        var entityError = new EfEntityError()
                        {
                            EntityTypeName = entityTypeName,
                            ErrorMessage = ve.ErrorMessage,
                            PropertyName = ve.PropertyName,
                            EntityStateName = Enum.GetName(typeof(EntityState), eve.Entry.State),
                            EntityValues = entityValues
                        };
                        EntityErrors.Add(entityError);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override async Task SaveChangesAsync()
        {
            int count = 0;

            try
            {
                count = await Context.SaveChangesAsync();

            }
            catch (DbEntityValidationException e)
            {
                this.EntityErrors = new List<EntityError>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    var entity = eve.Entry.Entity;
                    var entityTypeName = entity.GetType().FullName;

                    Dictionary<string, object> entityValues = new Dictionary<string, object>();

                    //eve.Entry.OriginalValues.PropertyNames.ToList().ForEach(item =>
                    //{
                    //    entityValues.Add(item, eve.Entry.OriginalValues[item]);
                    //});

                    foreach (var ve in eve.ValidationErrors)
                    {
                        var entityError = new EfEntityError()
                        {
                            EntityTypeName = entityTypeName,
                            ErrorMessage = ve.ErrorMessage,
                            PropertyName = ve.PropertyName,
                            EntityStateName = Enum.GetName(typeof(EntityState), eve.Entry.State),
                            EntityValues = entityValues
                        };
                        EntityErrors.Add(entityError);
                    }
                }

                if (this.HasEntityErrors)
                {
                    if(Logger != null)
                        Logger.Error("Entity Validation Error: " + EntityErrors.Dump());

                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        protected override IQueryable<T> BaseQuery(IFetchStrategy<T> fetchStrategy = null)
        {
            var query = DbSet.AsQueryable();
            return fetchStrategy == null ? query : fetchStrategy.IncludePaths.Aggregate(query, (current, path) => current.Include(path));
        }

        // we override the implementation fro LinqBaseRepository becausee this is built in and doesn't need to find the key column and do dynamic expressions, etc.
        protected override T GetQuery(params object[] keys)
        {
            return DbSet.Find(keys);
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (Context == null) return;

            Context.Dispose();
            Context = null;
        }
    }

    public class EfCompoundKeyRepositoryBase<T, TKey, TKey2> : LinqCompoundKeyRepositoryBase<T, TKey, TKey2> where T : class, new()
    {
        protected IDbSet<T> DbSet { get; private set; }
        protected DbContext Context { get; private set; }

        internal EfCompoundKeyRepositoryBase(DbContext dbContext, ICompoundKeyCachingStrategy<T, TKey, TKey2> cachingStrategy = null)
            : base(cachingStrategy)
        {
            Initialize(dbContext);
        }

        private void Initialize(DbContext dbContext)
        {
            Context = dbContext;
            DbSet = Context.Set<T>();
        }

        protected override void AddItem(T entity)
        {
            DbSet.Add(entity);
        }

        protected override void DeleteItem(T entity)
        {
            DbSet.Remove(entity);
        }

        protected override void UpdateItem(T entity)
        {
            var entry = Context.Entry<T>(entity);

            if (entry.State == EntityState.Detached)
            {
                TKey key;
                TKey2 key2;
                
                if (GetPrimaryKey(entity, out key, out key2))
                {
                    // check to see if this item is already attached
                    //  if it is then we need to copy the values to the attached value instead of changing the State to modified since it will throw a duplicate key exception
                    //  specifically: "An object with the same key already exists in the ObjectStateManager. The ObjectStateManager cannot track multiple objects with the same key."
                    var attachedEntity = Context.Set<T>().Find(key, key2);
                    if (attachedEntity != null)
                    {
                        Context.Entry(attachedEntity).CurrentValues.SetValues(entity);

                        return;
                    }
                }
            }

            // default
            entry.State = EntityState.Modified;
        }

        protected override void SaveChanges()
        {
            int count = 0;

            try
            {
                count = Context.SaveChanges();

            }
            catch (DbEntityValidationException e)
            {
                this.EntityErrors = new List<EntityError>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    var entity = eve.Entry.Entity;
                    var entityTypeName = entity.GetType().FullName;

                    Dictionary<string, object> entityValues = new Dictionary<string, object>();

                    //eve.Entry.OriginalValues.PropertyNames.ToList().ForEach(item =>
                    //{
                    //    entityValues.Add(item, eve.Entry.OriginalValues[item]);
                    //});

                    foreach (var ve in eve.ValidationErrors)
                    {
                        var entityError = new EfEntityError()
                        {
                            EntityTypeName = entityTypeName,
                            ErrorMessage = ve.ErrorMessage,
                            PropertyName = ve.PropertyName,
                            EntityStateName = Enum.GetName(typeof(EntityState), eve.Entry.State),
                            EntityValues = entityValues
                        };
                        EntityErrors.Add(entityError);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override async Task SaveChangesAsync()
        {
            int count = 0;

            try
            {
                count = await Context.SaveChangesAsync();

            }
            catch (DbEntityValidationException e)
            {
                this.EntityErrors = new List<EntityError>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    var entity = eve.Entry.Entity;
                    var entityTypeName = entity.GetType().FullName;

                    Dictionary<string, object> entityValues = new Dictionary<string, object>();

                    //eve.Entry.OriginalValues.PropertyNames.ToList().ForEach(item =>
                    //{
                    //    entityValues.Add(item, eve.Entry.OriginalValues[item]);
                    //});

                    foreach (var ve in eve.ValidationErrors)
                    {
                        var entityError = new EfEntityError()
                        {
                            EntityTypeName = entityTypeName,
                            ErrorMessage = ve.ErrorMessage,
                            PropertyName = ve.PropertyName,
                            EntityStateName = Enum.GetName(typeof(EntityState), eve.Entry.State),
                            EntityValues = entityValues
                        };
                        EntityErrors.Add(entityError);
                    }
                }

                if (this.HasEntityErrors)
                {
                     if(Logger != null)
                        Logger.Error("Entity Validation Error: " + EntityErrors.Dump());
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        protected override IQueryable<T> BaseQuery(IFetchStrategy<T> fetchStrategy = null)
        {
            var query = DbSet.AsQueryable();
            return fetchStrategy == null ? query : fetchStrategy.IncludePaths.Aggregate(query, (current, path) => current.Include(path));
        }

        // we override the implementation fro LinqBaseRepository becausee this is built in and doesn't need to find the key column and do dynamic expressions, etc.
        protected override T GetQuery(TKey key, TKey2 key2)
        {
            return DbSet.Find(key, key2);
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (Context == null) return;

            Context.Dispose();
            Context = null;
        }
    }

    public class EfCompoundKeyRepositoryBase<T, TKey, TKey2, TKey3> : LinqCompoundKeyRepositoryBase<T, TKey, TKey2, TKey3> where T : class, new()
    {
        protected IDbSet<T> DbSet { get; private set; }
        protected DbContext Context { get; private set; }

        internal EfCompoundKeyRepositoryBase(DbContext dbContext, ICompoundKeyCachingStrategy<T, TKey, TKey2, TKey3> cachingStrategy = null)
            : base(cachingStrategy)
        {
            Initialize(dbContext);
        }

        private void Initialize(DbContext dbContext)
        {
            Context = dbContext;
            DbSet = Context.Set<T>();
        }

        protected override void AddItem(T entity)
        {
            DbSet.Add(entity);
        }

        protected override void DeleteItem(T entity)
        {
            DbSet.Remove(entity);
        }

        protected override void UpdateItem(T entity)
        {
            var entry = Context.Entry<T>(entity);

            if (entry.State == EntityState.Detached)
            {
                TKey key;
                TKey2 key2;
                TKey3 key3;

                if (GetPrimaryKey(entity, out key, out key2, out key3))
                {
                    // check to see if this item is already attached
                    //  if it is then we need to copy the values to the attached value instead of changing the State to modified since it will throw a duplicate key exception
                    //  specifically: "An object with the same key already exists in the ObjectStateManager. The ObjectStateManager cannot track multiple objects with the same key."
                    var attachedEntity = Context.Set<T>().Find(key, key2, key3);
                    if (attachedEntity != null)
                    {
                        Context.Entry(attachedEntity).CurrentValues.SetValues(entity);

                        return;
                    }
                }
            }

            // default
            entry.State = EntityState.Modified;
        }

        protected override void SaveChanges()
        {
            int count = 0;

            try
            {
                count = Context.SaveChanges();

            }
            catch (DbEntityValidationException e)
            {
                this.EntityErrors = new List<EntityError>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    var entity = eve.Entry.Entity;
                    var entityTypeName = entity.GetType().FullName;

                    Dictionary<string, object> entityValues = new Dictionary<string, object>();

                    //eve.Entry.OriginalValues.PropertyNames.ToList().ForEach(item =>
                    //{
                    //    entityValues.Add(item, eve.Entry.OriginalValues[item]);
                    //});

                    foreach (var ve in eve.ValidationErrors)
                    {
                        var entityError = new EfEntityError()
                        {
                            EntityTypeName = entityTypeName,
                            ErrorMessage = ve.ErrorMessage,
                            PropertyName = ve.PropertyName,
                            EntityStateName = Enum.GetName(typeof(EntityState), eve.Entry.State),
                            EntityValues = entityValues
                        };
                        EntityErrors.Add(entityError);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override async Task SaveChangesAsync()
        {
            int count = 0;

            try
            {
                count = await Context.SaveChangesAsync();

            }
            catch (DbEntityValidationException e)
            {
                this.EntityErrors = new List<EntityError>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    var entity = eve.Entry.Entity;
                    var entityTypeName = entity.GetType().FullName;

                    Dictionary<string, object> entityValues = new Dictionary<string, object>();

                    //eve.Entry.OriginalValues.PropertyNames.ToList().ForEach(item =>
                    //{
                    //    entityValues.Add(item, eve.Entry.OriginalValues[item]);
                    //});

                    foreach (var ve in eve.ValidationErrors)
                    {
                        var entityError = new EfEntityError()
                        {
                            EntityTypeName = entityTypeName,
                            ErrorMessage = ve.ErrorMessage,
                            PropertyName = ve.PropertyName,
                            EntityStateName = Enum.GetName(typeof(EntityState), eve.Entry.State),
                            EntityValues = entityValues
                        };
                        EntityErrors.Add(entityError);
                    }
                }

                if (this.HasEntityErrors)
                {
                     if(Logger != null)
                        Logger.Error("Entity Validation Error: " + EntityErrors.Dump());  
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        protected override IQueryable<T> BaseQuery(IFetchStrategy<T> fetchStrategy = null)
        {
            var query = DbSet.AsQueryable();
            return fetchStrategy == null ? query : fetchStrategy.IncludePaths.Aggregate(query, (current, path) => current.Include(path));
        }

        // we override the implementation fro LinqBaseRepository becausee this is built in and doesn't need to find the key column and do dynamic expressions, etc.
        protected override T GetQuery(TKey key, TKey2 key2, TKey3 key3)
        {
            return DbSet.Find(key, key2, key3);
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (Context == null) return;

            Context.Dispose();
            Context = null;
        }
    }
}