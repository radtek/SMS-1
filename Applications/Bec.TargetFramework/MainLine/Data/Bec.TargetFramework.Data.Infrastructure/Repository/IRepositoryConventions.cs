using System;

namespace Bec.TargetFramework.Data.Infrastructure
{
    public interface IRepositoryConventions
    {
        Func<Type, string> GetPrimaryKeyName { get; set; } 
    }
}
