using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Data.Infrastructure.EfRepository;

namespace Bec.TargetFramework.Data.Repositories
{
    public class VStateRepository: EfRepository<VState>
    {
        private TargetFrameworkEntities TargetFrameworkContext 
        { 
            get
            {
                return this.Context
                     as TargetFrameworkEntities;
            }
        }

        public VStateRepository(DbContext dbContext = null) : base(dbContext)
        {
        }
    }
}
