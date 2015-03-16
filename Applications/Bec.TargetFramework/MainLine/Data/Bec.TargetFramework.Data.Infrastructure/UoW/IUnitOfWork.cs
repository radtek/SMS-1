using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Infrastructure.Log;
using System.Threading;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Data.Infrastructure
{
    public interface IUnitOfWork : IUnitOfWorkForService
    {
        bool Save();
        Task<bool> SaveAsync();

        /// <summary>
        /// Disables tracking and linq delayed execution
        /// </summary>
        void DisableProxyAndLazyLoading();

        /// <summary>
        /// Enables tracking and linq delayed execution
        /// </summary>
        void EnableProxyAndLazyLoading();
    }

    public interface IUnitOfWorkForService
    {
       // IRepository<TEntity,TKey> Repository<TEntity,TKey>() where TEntity : class, new();
    }
}