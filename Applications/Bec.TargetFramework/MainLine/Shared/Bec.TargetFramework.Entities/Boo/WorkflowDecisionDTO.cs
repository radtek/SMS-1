
using System.Runtime.Serialization;
namespace Bec.TargetFramework.Entities
{

    public partial class WorkflowDecisionDTO
    {
        [DataMember]
        public bool IsSuccess { get; set; }
    }
}
