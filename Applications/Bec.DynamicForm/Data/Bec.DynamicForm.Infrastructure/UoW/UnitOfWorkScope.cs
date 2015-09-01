﻿using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Text;

namespace Bec.TargetFramework.Data.Infrastructure
{
    /// <summary>
    /// Scoped unit of work, that merges with any existing scoped unit of work
    /// activated by a previous function in the call chain.
    /// </summary>
    /// <typeparam name="TDbContext">The type of the DbContext</typeparam>
    public class UnitOfWorkScope<TDbContext> : Disposable, IUnitOfWork
        where TDbContext : DbContext, new()
    {
        /// <summary>
        /// Handle class for holding the real DbContext and some state for it.
        /// </summary>
        private class ScopedDbContext : Disposable
        {
            /// <summary>
            /// The real DbContext.
            /// </summary>
            public TDbContext DbContext { get; private set; }

            /// <summary>
            /// Has there been a failure that should block saving?
            /// </summary>
            public bool BlockSave { get; set; }

            /// <summary>
            /// Was any unit of work scope using this DbContext opened for writing?
            /// </summary>
            public bool ForWriting { get; private set; }

            /// <summary>
            /// Switch off guard for direct calls to SaveChanges.
            /// </summary>
            public bool AllowSaving { get; set; }

            /// <summary>
            /// Ctor.
            /// </summary>
            /// <param name="forWriting">Is the root context opened for writing?</param>
            public ScopedDbContext(bool forWriting)
            {
                ForWriting = forWriting;
                DbContext = new TDbContext();
                if (DbContext != null && ((IObjectContextAdapter)DbContext).ObjectContext != null)
                    ((IObjectContextAdapter)DbContext).ObjectContext.SavingChanges
                        += GuardAgainstDirectSaves;
            }

            void GuardAgainstDirectSaves(object sender, EventArgs e)
            {
                if (!AllowSaving)
                {
                    throw new InvalidOperationException(
                        "Don't call SaveChanges directly on a context owned by a UnitOfWorkScope. " +
                        "use UnitOfWorkScope.SaveChanges instead.");
                }
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    if (DbContext != null)
                    {
                        ((IObjectContextAdapter)DbContext).ObjectContext.SavingChanges
                            -= GuardAgainstDirectSaves;

                        DbContext.Dispose();
                        DbContext = null;
                    }
                }
                base.Dispose(disposing);
            }
        }

        [ThreadStatic]
        private static ScopedDbContext scopedDbContext;

        private bool isRoot = false;

        private bool saveChangesCalled = false;

        /// <summary>
        /// Access the ambient DbContext that this unit of work uses.
        /// </summary>
        public TDbContext DbContext
        {
            get
            {
                return scopedDbContext.DbContext;
            }
        }

        private UnitOfWorkScopePurpose purpose;

        private ILogger m_Logger;
        private readonly Guid m_InstanceId;
        private IProvider m_Provider { get; set; }
        private List<EntityError> m_EntityErrors;

        public List<EntityError> EntityErrors
        {
            get { return m_EntityErrors; }
            set { m_EntityErrors = value; }
        }
        private readonly bool m_UseTransaction;
        private DbContextTransaction m_ContextTransaction;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="purpose">Will this unit of work scope be used for reading or writing?</param>
        public UnitOfWorkScope(UnitOfWorkScopePurpose purpose, ILogger logger = null, bool useTransaction = false)
        {
            this.purpose = purpose;
            m_Logger = logger;
            m_InstanceId = Guid.NewGuid();
            m_EntityErrors = new List<EntityError>();
            m_UseTransaction = useTransaction;
            if (scopedDbContext == null)
            {
                scopedDbContext = new ScopedDbContext(purpose == UnitOfWorkScopePurpose.Writing);
                isRoot = true;
            }
            if (purpose == UnitOfWorkScopePurpose.Writing && !scopedDbContext.ForWriting)
            {
                throw new InvalidOperationException(
                    "Can't open a child UnitOfWorkScope for writing when the root scope " +
                    "is opened for reading.");
            }

            if (purpose == UnitOfWorkScopePurpose.Writing)
            {
                if (isRoot && useTransaction)
                    m_ContextTransaction = scopedDbContext.DbContext.Database.BeginTransaction();
            }
            else
                m_UseTransaction = false;

            if (m_Provider == null) m_Provider = new Provider();
            m_Provider.DbContext = scopedDbContext.DbContext;
        }

        /// <summary>
        /// Dispose implementation, checking post conditions for purpose and saving.
        /// </summary>
        /// <param name="disposing">Are we disposing?</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // We're disposing and SaveChanges wasn't called. That usually
                // means we're exiting the scope with an exception. Block saves
                // of the entire unit of work.
                if (purpose == UnitOfWorkScopePurpose.Writing && !saveChangesCalled)
                {
                    scopedDbContext.BlockSave = true;
                    // Don't throw here - it would mask original exception when exiting
                    // a using block.
                }

                if (scopedDbContext != null && isRoot)
                {
                    if (m_UseTransaction && m_ContextTransaction != null)
                        m_ContextTransaction.UnderlyingTransaction.Dispose();

                    scopedDbContext.Dispose();
                    scopedDbContext = null;
                }
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// For child unit of work scopes: Mark for saving. For the root: Do actually save.
        /// </summary>
        public bool Save()
        {
            if (purpose != UnitOfWorkScopePurpose.Writing)
            {
                throw new InvalidOperationException(
                    "Can't save changes on a UnitOfWorkScope with Reading purpose.");
            }

            if (scopedDbContext.BlockSave)
            {
                throw new InvalidOperationException(
                    "Saving of changes is blocked for this unit of work scope. An enclosed " +
                    "scope was disposed without calling SaveChanges.");
            }

            saveChangesCalled = true;

            if (!isRoot)
            {
                return false;
            }

            scopedDbContext.AllowSaving = true;

            int count;
            try
            {
                count = scopedDbContext.DbContext.SaveChanges();

                if (m_UseTransaction)
                    m_ContextTransaction.Commit();

            }
            catch (DbEntityValidationException e)
            {
                if (m_UseTransaction)
                    m_ContextTransaction.Rollback();

                this.m_EntityErrors = new List<EntityError>();
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
                        m_EntityErrors.Add(entityError);
                    }
                }

                if (m_EntityErrors.Count > 0 && m_Logger != null)
                {
                    m_EntityErrors.ForEach(
                        e1 =>
                            m_Logger.Error("Entity Validation Error:" + e1.ErrorMessage + " Property:" + e1.PropertyName +
                                           " Entity:" + e1.EntityTypeName));

                }
            }
            catch (Exception ex)
            {
                m_Logger.Error(ex,"UOW Save");

                if (m_UseTransaction)
                    m_ContextTransaction.Rollback();

                throw;
            }

            scopedDbContext.AllowSaving = false;

            return (m_EntityErrors.Count == 0);
        }

        /// <summary>
        /// Saves the DbContext
        /// </summary>
        /// <returns>Bool true for success</returns>
        public async Task<bool> SaveAsync()
        {
            if (purpose != UnitOfWorkScopePurpose.Writing)
            {
                throw new InvalidOperationException(
                    "Can't save changes on a UnitOfWorkScope with Reading purpose.");
            }

            if (scopedDbContext.BlockSave)
            {
                throw new InvalidOperationException(
                    "Saving of changes is blocked for this unit of work scope. An enclosed " +
                    "scope was disposed without calling SaveChanges.");
            }

            saveChangesCalled = true;

            if (!isRoot)
            {
                return false;
            }

            scopedDbContext.AllowSaving = true;

            int count;
            try
            {
                count = await scopedDbContext.DbContext.SaveChangesAsync();
                if (m_UseTransaction)
                    m_ContextTransaction.Commit();
            }
            catch (DbEntityValidationException e)
            {
                if (m_UseTransaction)
                    m_ContextTransaction.Rollback();

                this.m_EntityErrors = new List<EntityError>();
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
                        m_EntityErrors.Add(entityError);
                    }
                }

                if (m_EntityErrors.Count > 0 && m_Logger != null)
                {
                    m_EntityErrors.ForEach(
                        e1 =>
                            m_Logger.Error("Entity Validation Error:" + e1.ErrorMessage + " Property:" + e1.PropertyName +
                                           " Entity:" + e1.EntityTypeName));

                }
            }
            catch (Exception ex)
            {
                m_Logger.Error(ex,"UOW Save");

                if (m_UseTransaction)
                    m_ContextTransaction.Rollback();

                throw;
            }
            scopedDbContext.AllowSaving = false;

            return (m_EntityErrors.Count == 0);
        }

        public IRepository<T, TKey> GetGenericRepository<T, TKey>() where T : class,new()
        {
            var repos = m_Provider.GetGenericRepository<T, TKey>();

            repos.IsInScope = true;

            return repos;
        }

        public ICompoundKeyRepository<T, TKey, TKey1> GetGenericRepository<T, TKey, TKey1>() where T : class, new()
        {
            var repos = m_Provider.GetGenericRepository<T, TKey, TKey1>();

            repos.IsInScope = true;

            return repos;
        }

        public IRepository<T, TKey> GetGenericRepositoryNoTracking<T, TKey>() where T : class,new()
        {
            var repos = m_Provider.GetGenericRepository<T, TKey>();

            repos.IsInScope = true;
            repos.TurnOffTracking = true;

            return repos;
        }

        public ICompoundKeyRepository<T, TKey, TKey1> GetGenericRepositoryNoTracking<T, TKey, TKey1>() where T : class, new()
        {
            var repos = m_Provider.GetGenericRepository<T, TKey, TKey1>();

            repos.IsInScope = true;
            repos.TurnOffTracking = true;

            return repos;
        }

        public T GetCustomRepository<T>() where T : class
        {
            return m_Provider.GetCustomRepository<T>();
        }
    }
}