using System;

namespace Bec.TargetFramework.Data.Infrastructure
{
    public class RepositoryConventions : IRepositoryConventions
    {
        public Func<Type, string> GetPrimaryKeyName { get; set; } 

        public RepositoryConventions()
        {
            GetPrimaryKeyName = DefaultRepositoryConventions.GetPrimaryKeyName;
        }
    }
}
