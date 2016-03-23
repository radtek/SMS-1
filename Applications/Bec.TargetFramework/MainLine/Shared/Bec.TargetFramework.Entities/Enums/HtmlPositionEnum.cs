using Bec.TargetFramework.Infrastructure.Extensions;


namespace Bec.TargetFramework.Entities.Enums
{
    public enum HtmlPositionEnum : int
    {
        [StringValue("Right")]
        Right = 1,
        [StringValue("Left")]
        Left = 2,
        [StringValue("Top")]
        Top = 3,
        [StringValue("Bottom")]
        Bottom = 4
    }
}
