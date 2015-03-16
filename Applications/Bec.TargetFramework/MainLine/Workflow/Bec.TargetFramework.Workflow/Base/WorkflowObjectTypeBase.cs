using Bec.TargetFramework.Workflow.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Base
{
    using Fabrik.Common;
    [Serializable]
    public class WorkflowObjectTypeBase : IWorkflowObjectType
    {
        public Guid WorkflowObjectTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int VersionNumber { get; set; }
        public string ObjectTypeName { get; set; }
        public string ObjectTypeNameSpace { get; set; }
        public string ObjectTypeAssembly { get; set; }
        public Guid WorkflowID { get; set; }


        public T CreateInstanceOfObject<T>()
        {
            Ensure.Argument.NotNull(ObjectTypeName);

            return (T) Activator.CreateInstance(Type.GetType(ObjectTypeName));
        }
    }
}
