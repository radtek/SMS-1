using Bec.TargetFramework.Data.Infrastructure.EfRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Data.Repositories
{
    public class UserAccountLoginSessionRepository : EfRepository<UserAccountLoginSession, Guid, string>
    {
        private TargetFrameworkEntities TargetFrameworkContext
        {
            get
            {
                return this.Context
                     as TargetFrameworkEntities;
            }
        }

        public UserAccountLoginSessionRepository(DbContext dbContext = null)
            : base(dbContext)
        {
            this.IsInScope = true;
        }

        
    }
}
