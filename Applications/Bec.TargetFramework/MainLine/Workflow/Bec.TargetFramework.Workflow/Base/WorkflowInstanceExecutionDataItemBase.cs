using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Base
{
    [Serializable]
    public class WorkflowInstanceExecutionDataItemBase
    {
        public int WorkflowInstanceExecutionDataItemID { get; set; }
        public int WorkflowInstanceExecutionID { get; set; }
        public string FieldName { get; set; }
        public Nullable<int> FieldTypeID { get; set; }
        public string DataContent { get; set; }
        public string DataStr { get; set; }
        public bool DataNotJsonSerialized { get; set; }
        public Nullable<int> EventOrder { get; set; }
        public int WorkflowInstanceExecutionStatusEventID { get; set; }
    }
}
