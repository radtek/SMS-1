using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    public class NotificationResultDTO
    {
        public Guid NotificationID { get; set; }
        public Guid NotificationConstructID { get; set; }
        public int NotificationConstructVersionNumber { get; set; }
        public List<string> Lines { get; set; }
    }
}
