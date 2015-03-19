using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;
using ServiceStack.Caching;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Bec.TargetFramework.Business.Logic
{
    using Bec.TargetFramework.Aop.Aspects;
    using Bec.TargetFramework.Business.Infrastructure.Interfaces;
    using Bec.TargetFramework.Entities;

    [Trace(TraceExceptionsOnly = true)]
    public class SettingLogic : LogicBase, ISettingLogic
    {
        private const string CACHEKEY = "SettingLogicCache";

        public SettingLogic(ILogger logger, ICacheProvider cacheProvider)
            : base(logger, cacheProvider)
        {
        }

        public Dictionary<string, SettingDTO> GetAllSettings()
        {
            return GetSettingsFromDBAndCache();            
        }

        public SettingDTO GetSetting(SettingDTO setting)
        {
            throw new NotImplementedException();
        }


        public void InsertSetting(SettingDTO dto)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, null, true))
            {
                var repos = scope.GetGenericRepository<Setting, int>();

                repos.Add(SettingConverter.ToEntity(dto));

                scope.Save();

                // Reset the cache
                ResetCache();
            }
        }
        
        public void UpdateSetting(SettingDTO dto)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, null, true))
            {
                var repos = scope.GetGenericRepository<Setting, int>();

                repos.Update(SettingConverter.ToEntity(dto));

                scope.Save();

                // Reset the cache
                ResetCache();
            }
        }

        public void DeleteSetting(SettingDTO dto)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, null, true))
            {
                var repos = scope.GetGenericRepository<Setting, int>();

                repos.Delete(SettingConverter.ToEntity(dto));

                scope.Save();

                // Reset the cache
                ResetCache();
            };
        }

        private void ResetCache()
        {
            using(var cc = CacheProvider.CreateCacheClient(Logger))
            {
                cc.Remove(CACHEKEY);
            }
        }


        public SettingDTO GetSettingById(int settingId)
        {
            var cachedList = GetSettingsFromDBAndCache();

            return cachedList.Values.Where(s => s.Id.Equals(settingId)).FirstOrDefault();
        }


        public SettingDTO GetSettingByName(string name)
        {
            var cachedList = GetSettingsFromDBAndCache();
            if (cachedList.ContainsKey(name))
                return cachedList[name];
            else
                return null;
        }  
 
        private Dictionary<string, SettingDTO> GetSettingsFromDBAndCache()
        {
            Dictionary<string, SettingDTO> settings = null;

            using(var cacheClient = CacheProvider.CreateCacheClient(Logger))
            {
                settings = cacheClient.Get<Dictionary<string, SettingDTO>>(CACHEKEY);

                if (settings == null)
                { 
                    settings = new Dictionary<string, SettingDTO>();

                    using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, null, true))
                    {
                        var repos = scope.GetGenericRepositoryNoTracking<Setting, int>();

                        var vv = repos.GetAll();
                        foreach (var item in vv)
                        {
                            SettingDTO dto = SettingConverter.ToDto(item);
                            settings.Add(dto.Name, dto);
                        }
                    }

                    cacheClient.Set<Dictionary<string, SettingDTO>>(CACHEKEY, settings, DateTime.Now.AddHours(1));
                }
            }

            return settings;
        }
    }
}
