using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Extensions;

namespace Bec.TargetFramework.Service.LR.Infrastructure.Enums
{
    public enum LRTypeCodeEnum : int
    {
        [StringValue("User")]
        User = 10,
        [StringValue("Branch Administrator")]
        BranchAdministrator = 2,
        [StringValue("FinancialOfficer")]
        FinancialOfficer = 3,
    }
}
