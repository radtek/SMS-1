using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Infrastructure.Extensions
{
    public static class ListExtensions
    {
        public static string RemoveAndGet(this IList<string> list, int index)
        {
            lock (list)
            {
                string value = list[index];
                list.RemoveAt(index);
                return value;
            }
        }

        public static bool RemoveAndGet(this IList<bool> list, int index)
        {
            lock (list)
            {
                bool value = list[index];
                list.RemoveAt(index);
                return value;
            }
        }
    }
}
