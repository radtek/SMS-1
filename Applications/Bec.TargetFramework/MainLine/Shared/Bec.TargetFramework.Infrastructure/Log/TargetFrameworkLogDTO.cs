using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Infrastructure.Log
{
    [Serializable]
    public class TargetFrameworkLogDTO
    {
        public string Message {get;set;}
        public Exception Exception {get;set;}
        public string ApplicationSource {get;set;}
        public string ApplicationSourceType {get;set;}
        public string UserID {get;set;}
        public string ApplicationSourceID { get; set; }
        public string OrganisationID { get; set; }
        public string WorkflowInstanceID { get; set; }
        public string ModuleID { get; set; }
        public string Detail { get; set; }
    }
}
