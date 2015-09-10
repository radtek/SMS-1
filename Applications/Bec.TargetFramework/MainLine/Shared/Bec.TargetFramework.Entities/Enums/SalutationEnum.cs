
using Bec.TargetFramework.Infrastructure.Extensions;

namespace Bec.TargetFramework.Entities.Enums
{
    public enum SalutationEnum
    {
        [StringValue("Mr")]
        Mr,
        [StringValue("Mrs")]
        Mrs,
        [StringValue("Miss")]
        Miss,
        [StringValue("Ms")]
        Ms,
        [StringValue("Dr")]
        Dr
    }
}
