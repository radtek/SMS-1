
namespace Bec.TargetFramework.Entities
{
    using System.Runtime.Serialization;

    public partial class GroupRoleDTO
    {
        [DataMember]
        public string RoleName { get; set; }

        [DataMember]
        public string RoleValue { get; set; }
    }
}
