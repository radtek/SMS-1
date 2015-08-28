using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.SB.Data;
using Bec.TargetFramework.SB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.SB.Hosts.SBService.Logic
{
    public class SettingsLogicController : SettingsLogicBase<SettingDTO>
    {
        protected override string getCacheKey()
        {
            return "SettingLogicCache";
        }

        protected override IEnumerable<ISettingDTO> getDtos()
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkCoreEntities>().Settings.ToDtos();
            }
        }
    }
}
