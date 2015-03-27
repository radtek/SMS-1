using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Extensions;

namespace Bec.TargetFramework.Entities.Enums
{
    public enum FirmUserRoleEnum : int
    {
        [StringValue("User")]
        User = 1,
        [StringValue("Branch Administrator")]
        BranchAdministrator = 2,
        [StringValue("FinancialOfficer")]
        FinancialOfficer = 3,
    }

    public enum UserTypeEnum : int
    {
        [StringValue("9e8ca436-2139-11e4-a37d-8771a20de3d2")]
        User = 1,
        [StringValue("9e8d195c-2139-11e4-a4cd-2b35a008ab65")]
        Administrator = 2,
        [StringValue("9e8d4076-2139-11e4-8474-3ff6242f5224")]
        ComplianceOfficer = 3,
        [StringValue("9e8d6786-2139-11e4-9216-972bcf724500")]
        Temporary = 4,
        [StringValue("ff3a49be-3ce1-11e4-be94-a761c0833a3a")]
        BranchAdministrator = 5,
        [StringValue("62885ba9-36ba-4035-836b-8e0c127098a2")]
        OrganisationAdministrator = 6
    }

}
