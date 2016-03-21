using Bec.TargetFramework.Data;
using Mehdime.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Extensions
{
    public static class EntityFrameworkHelperExtenstions
    {
        public static void SetOriginalRowVersion(this object entity, IDbContextScope scope, long rowVersion)
        {
            scope.DbContexts.Get<TargetFrameworkEntities>().Entry(entity).Property("RowVersion").OriginalValue = rowVersion;
        }
    }
}
