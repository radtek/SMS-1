using Couchbase;
using Couchbase.AspNet;
using Couchbase.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Infrastructure.CouchBaseCache
{
    public sealed class MyCouchbaseFactory : ICouchbaseClientFactory
    {
        public Enyim.Caching.IMemcachedClient Create(string name, System.Collections.Specialized.NameValueCollection config, out bool disposeClient)
        {
            // This client should be disposed of as it is not shared
            disposeClient = true;

            var c = new CouchbaseClientConfiguration
            {
                Bucket = ConfigurationManager.AppSettings["couchbase:bucket"],
                Username = ConfigurationManager.AppSettings["couchbase:username"],
                BucketPassword = ConfigurationManager.AppSettings["couchbase:password"]
            };
            c.Urls.Add(new Uri(ConfigurationManager.AppSettings["couchbase:uri"]));
            c.SocketPool.ConnectionTimeout = TimeSpan.Parse(ConfigurationManager.AppSettings["couchbase:connectionTimeout"]);
            c.SocketPool.DeadTimeout = TimeSpan.Parse(ConfigurationManager.AppSettings["couchbase:deadTimeout"]);

            return new CouchbaseClient(c);
        }
    }
}
