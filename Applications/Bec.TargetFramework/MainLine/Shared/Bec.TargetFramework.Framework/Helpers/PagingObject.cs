using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Web.Framework.Helpers
{
   public class PagingObject<T>
    {
        public ICollection<T> PagingList { get; set; }
        public int? TotalRecords { get; set; }

        public int TotalRecordCount
        {
            get
            {
                if (TotalRecords.HasValue)
                    return TotalRecords.Value;

                else
                    return PagingList.Count;
            }
        }
    }
}
