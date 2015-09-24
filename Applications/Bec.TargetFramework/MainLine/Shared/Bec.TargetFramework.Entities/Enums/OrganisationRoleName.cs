using Bec.TargetFramework.Infrastructure.Extensions;

namespace Bec.TargetFramework.Entities.Enums
{
    public enum OrganisationRoleName
    {
        [StringValue("User")]
        User,
        [StringValue("Support Administrator")]
        SupportAdministrator,
        [StringValue("Finance Administrator")]
        FinanceAdministrator,
        [StringValue("Administration User")]
        AdministrationUser,
        [StringValue("Organisation Employee")]
        OrganisationEmployee,
        [StringValue("Organisation Administrator")]
        OrganisationAdministrator
    }
}
