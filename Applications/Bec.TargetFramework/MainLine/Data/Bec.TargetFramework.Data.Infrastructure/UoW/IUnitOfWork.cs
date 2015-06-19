using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Infrastructure.Log;
using System.Threading;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Data.Infrastructure
{
    public interface IUnitOfWork : IUnitOfWorkForService
    {
        void Save();
        Task SaveAsync();

        /// <summary>
        /// Disables tracking and linq delayed execution
        /// </summary>
        //void DisableProxyAndLazyLoading();

        ///// <summary>
        ///// Enables tracking and linq delayed execution
        ///// </summary>
        //void EnableProxyAndLazyLoading();
    }

    public interface IUnitOfWorkForService
    {
       // IRepository<TEntity,TKey> Repository<TEntity,TKey>() where TEntity : class, new();
    }
}