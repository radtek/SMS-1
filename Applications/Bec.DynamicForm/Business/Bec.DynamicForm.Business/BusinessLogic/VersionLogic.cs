using Bec.DynamicForm.Business.Logic;
using Bec.DynamicForm.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bec.DynamicForm.Data
{
    public class VersionLogic : LogicBase
    {
        public VersionLogic(ILogger logger)
            : base(logger)
        {

        }
        public static int add(VersionDTO version)
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectParameter output = new ObjectParameter("VersionId", typeof(Int32));
                context.Version_Insert(output, version.FormId, version.VersionName, version.Notes, version.DocVersionId);
                return Convert.ToInt32(output.Value);
            }
        }   
        
    
    }
}
