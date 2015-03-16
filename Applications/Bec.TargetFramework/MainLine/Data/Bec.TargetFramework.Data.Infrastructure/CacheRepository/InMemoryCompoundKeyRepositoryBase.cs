using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bec.TargetFramework.Data.Infrastructure.Caching;
using Bec.TargetFramework.Data.Infrastructure.FetchStrategies;

namespace Bec.TargetFramework.Data.Infrastructure.CacheRepository
{
    public abstract class InMemoryCompoundKeyRepositoryBase<T, TKey, TKey2, TKey3> : LinqCompoundKeyRepositoryBase<T, TKey, TKey2, TKey3> where T : class, new()
    {
        private struct CompoundKey
        {
            public TKey Key1 { get; set; }

            public TKey2 Key2 { get; set; }

            public TKey3 Key3 { get; set; }

            public override int GetHashCode()
            {
                return this.Key1.GetHashCode() ^ this.Key2.GetHashCode() ^ this.Key3.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                if (obj is CompoundKey)
                {
                    var compositeKey = (CompoundKey)obj;

                    return this.Key1.Equals(compositeKey.Key1) && this.Key2.Equals(compositeKey.Key2) && this.Key3.Equals(compositeKey.Key3);
                }

                return false;
            }
        }

        private readonly ConcurrentDictionary<CompoundKey, T> _items = new ConcurrentDictionary<CompoundKey, T>();

        internal InMemoryCompoundKeyRepositoryBase(ICompoundKeyCachingStrategy<T, TKey, TKey2, TKey3> cachingStrategy = null) : base(cachingStrategy)
        {
        }

        protected override IQueryable<T> BaseQuery(IFetchStrategy<T> fetchStrategy = null)
        {
            return CloneDictionary(this._items).AsQueryable();
        }

        protected override T GetQuery(TKey key, TKey2 key2, TKey3 key3)
        {
            T result;
            var compoundKey = new CompoundKey { Key1 = key, Key2 = key2, Key3 = key3 };
            this._items.TryGetValue(compoundKey, out result);

            return result;
        }

        private static IEnumerable<T> CloneDictionary(ConcurrentDictionary<CompoundKey, T> list)
        {
            // when you Google deep copy of generic list every answer uses either the IClonable interface on the T or having the T be Serializable
            //  since we can't really put those constraints on T I'm going to do it via reflection
            var type = typeof(T);
            var properties = type.GetProperties();

            var clonedList = new List<T>(list.Count);

            foreach (var keyValuePair in list)
            {
                var newItem = new T();
                foreach (var propInfo in properties)
                {
                    propInfo.SetValue(newItem, propInfo.GetValue(keyValuePair.Value, null), null);
                }

                clonedList.Add(newItem);
            }

            return clonedList;
        }

        protected override void AddItem(T entity)
        {
            TKey key;
            TKey2 key2;
            TKey3 key3;

            this.GetPrimaryKey(entity, out key, out key2, out key3);

            var compoundKey = new CompoundKey { Key1 = key, Key2 = key2, Key3 = key3 };
            this._items[compoundKey] = entity;
        }

        protected override void DeleteItem(T entity)
        {
            TKey key;
            TKey2 key2;
            TKey3 key3;
            this.GetPrimaryKey(entity, out key, out key2, out key3);

            T tmp;
            var compoundKey = new CompoundKey { Key1 = key, Key2 = key2, Key3 = key3 };
            this._items.TryRemove(compoundKey, out tmp);
        }

        protected override void UpdateItem(T entity)
        {
            TKey key;
            TKey2 key2;
            TKey3 key3;
            this.GetPrimaryKey(entity, out key, out key2, out key3);

            var compoundKey = new CompoundKey { Key1 = key, Key2 = key2, Key3 = key3 };
            this._items[compoundKey] = entity;
        }

        protected override void SaveChanges()
        {
        }

        protected override async Task SaveChangesAsync()
        {
        }

        public override void Dispose()
        {
        }

        public override string ToString()
        {
            return "SharpRepository.InMemoryRepository";
        }
    }
}