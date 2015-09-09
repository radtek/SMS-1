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

        //private const string CACHEKEY = "SettingLogicCache";

        //public SettingLogic()
        //{
        //}

        //public Dictionary<string, SettingDTO> GetAllSettings()
        //{
        //    return GetSettingsFromDBAndCache();
        //}

        //public SettingDTO GetSetting(SettingDTO setting)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task InsertSettingAsync(SettingDTO dto)
        //{
        //    using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, null, true))
        //    {
        //        scope.DbContexts.Get<TargetFrameworkEntities>().Settings.Add(dto.ToEntity());
        //        await scope.SaveChangesAsync();
        //        // Reset the cache
        //        ResetCache();
        //    }
        //}

        //public async Task UpdateSettingAsync(SettingDTO dto)
        //{
        //    using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, null, true))
        //    {
        //        var existing = scope.DbContexts.Get<TargetFrameworkEntities>().Settings.Single(x => x.Id == dto.Id);
        //        var updated = dto.ToEntity();

        //        scope.DbContexts.Get<TargetFrameworkEntities>().Entry(existing).CurrentValues.SetValues(updated);
        //        await scope.SaveChangesAsync();

        //        // Reset the cache
        //        ResetCache();
        //    }
        //}

        //public async Task DeleteSettingAsync(SettingDTO dto)
        //{
        //    using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, null, true))
        //    {
        //        var existing = scope.DbContexts.Get<TargetFrameworkEntities>().Settings.Single(x => x.Id == dto.Id);
        //        scope.DbContexts.Get<TargetFrameworkEntities>().Settings.Remove(existing);

        //        await scope.SaveChangesAsync();

        //        // Reset the cache
        //        ResetCache();
        //    };
        //}

        //private void ResetCache()
        //{
        //    using (var cc = CacheProvider.CreateCacheClient(Logger))
        //    {
        //        cc.Remove(CACHEKEY);
        //    }
        //}


        //public SettingDTO GetSettingById(int settingId)
        //{
        //    var cachedList = GetSettingsFromDBAndCache();

        //    return cachedList.Values.Where(s => s.Id.Equals(settingId)).FirstOrDefault();
        //}


        //public SettingDTO GetSettingByName(string name)
        //{
        //    var cachedList = GetSettingsFromDBAndCache();
        //    if (cachedList.ContainsKey(name))
        //        return cachedList[name];
        //    else
        //        return null;
        //}

        //private Dictionary<string, SettingDTO> GetSettingsFromDBAndCache()
        //{
        //    Dictionary<string, SettingDTO> settings = null;

        //    using (var cacheClient = CacheProvider.CreateCacheClient(Logger))
        //    {
        //        settings = cacheClient.Get<Dictionary<string, SettingDTO>>(CACHEKEY);

        //        if (settings == null)
        //        {
        //            settings = new Dictionary<string, SettingDTO>();

        //            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, null, true))
        //            {
        //                foreach (var dto in scope.DbContexts.Get<TargetFrameworkEntities>().Settings.ToDtos())
        //                    settings.Add(dto.Name, dto);
        //            }

        //            cacheClient.Set<Dictionary<string, SettingDTO>>(CACHEKEY, settings, DateTime.Now.AddHours(1));
        //        }
        //    }

        //    return settings;
        //}
    }
}
