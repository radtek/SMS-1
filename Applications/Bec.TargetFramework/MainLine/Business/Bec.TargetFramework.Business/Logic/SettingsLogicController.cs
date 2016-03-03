using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Logic
{
    [Trace(TraceExceptionsOnly = true)]
    public class TFSettingsLogicController : SettingsLogicBase<SettingDTO>
    {
        protected override string getCacheKey()
        {
            return "SettingLogicCache";
        }

        protected override IEnumerable<ISettingDTO> getDtos()
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().Settings.ToDtos();
            }
        }
    }
}
