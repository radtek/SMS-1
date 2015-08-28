using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Data.Objects
{
    public class UserClaimDTO
    {
        public System.Guid UserAccount_ID { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
