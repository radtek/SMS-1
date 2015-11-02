using Bec.TargetFramework.Infrastructure.Extensions;

namespace Bec.TargetFramework.Entities.Enums
{
    public enum OperationEnum : int
    {
        [StringValue("fa59569a-8148-11e5-bd91-00155d0a147a")]
        Send = 1,
        [StringValue("fa5b7d3a-8148-11e5-bd92-00155d0a147a")]
        MarkAsRead = 2,
        [StringValue("fa5b7d3b-8148-11e5-bd93-00155d0a147a")]
        MarkAsUnread = 3,
        [StringValue("fa5b7d3c-8148-11e5-bd94-00155d0a147a")]
        Configure = 4,
        [StringValue("fa5b7d3d-8148-11e5-bd95-00155d0a147a")]
        View = 5,
        [StringValue("fa5b7d3e-8148-11e5-bd96-00155d0a147a")]
        Edit = 6,
        [StringValue("fa5b7d3f-8148-11e5-bd97-00155d0a147a")]
        Delete = 7,
        [StringValue("fa5b7d40-8148-11e5-bd98-00155d0a147a")]
        Add = 8,
    }
}
