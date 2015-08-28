using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Infrastructure
{
    public abstract class SettingsLogicBase<tDto> : LogicBase
    {
        public Dictionary<string, string> GetSettings()
        {
            Dictionary<string, string> settings = null;

            using (var cacheClient = CacheProvider.CreateCacheClient(Logger))
            {
                settings = cacheClient.Get<Dictionary<string, string>>(getCacheKey());

                if (settings == null)
                {
                    settings = new Dictionary<string, string>();
                    foreach (var dto in getDtos()) settings.Add(dto.Name, dto.Value);

                    cacheClient.Set<Dictionary<string, string>>(getCacheKey(), settings, DateTime.Now.AddHours(1));
                }
            }

            return settings;
        }

        protected abstract string getCacheKey();

        protected abstract IEnumerable<ISettingDTO> getDtos();
    }

    public interface ISettingDTO
    {
        string Name { get; }
        string Value { get; }
    }

    public static class SettingsExtensions
    {
        public static T AsSettings<T>(this Dictionary<string, string> settings)
            where T: ISettings, new()
        {
            T ret = new T();

            foreach (var prop in typeof(T).GetProperties())
            {
                // get properties we can read and write to
                if (!prop.CanRead || !prop.CanWrite)
                    continue;

                var key = typeof(T).Name + "." + prop.Name;
                //load by store
                if (!settings.ContainsKey(key)) continue;

                var setting = settings[key];
                if (!CommonHelper.GetTargetFrameworkCustomTypeConverter(prop.PropertyType).CanConvertFrom(typeof(string)))continue;

                if (!CommonHelper.GetTargetFrameworkCustomTypeConverter(prop.PropertyType).IsValid(setting))continue;

                object value = CommonHelper.GetTargetFrameworkCustomTypeConverter(prop.PropertyType).ConvertFromInvariantString(setting);

                //set property
                prop.SetValue(ret, value, null);
            }

            return ret;
        }
    }
}
