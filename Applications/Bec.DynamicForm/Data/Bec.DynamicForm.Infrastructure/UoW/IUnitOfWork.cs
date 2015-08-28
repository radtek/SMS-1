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
    }

    public interface IUnitOfWorkForService
    {
       // IRepository<TEntity,TKey> Repository<TEntity,TKey>() where TEntity : class, new();
    }
}