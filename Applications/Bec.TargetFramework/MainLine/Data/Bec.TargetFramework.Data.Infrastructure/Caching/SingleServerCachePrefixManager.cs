using System.Threading;

namespace Bec.TargetFramework.Data.Infrastructure.Caching
{
    public class SingleServerCachePrefixManager : ICachePrefixManager
    {
        private static int _counter = 1;

        public int Counter 
        {
            get { return _counter; }
        }

        public void IncrementCounter()
        {
            Interlocked.Increment(ref _counter);
        }
    }
}
