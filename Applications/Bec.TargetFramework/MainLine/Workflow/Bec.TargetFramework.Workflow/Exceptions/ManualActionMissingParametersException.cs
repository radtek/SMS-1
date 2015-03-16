using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Exceptions
{
    public class ManualActionMissingParametersException : Exception
    {
        public ManualActionMissingParametersException(string message)
            : base(message)
        {
            
        }
    }
}
