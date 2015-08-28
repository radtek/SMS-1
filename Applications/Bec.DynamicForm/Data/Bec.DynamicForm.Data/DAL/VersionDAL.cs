using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bec.DynamicForm.Data
{
    public class VersionDAL
    {
        #region Add new Version
        public static int addVersion(Int32? formId,string versionName,string  notes,[Optional] Int32? docVersionId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectParameter output = new ObjectParameter("VersionId", typeof(Int32));
                context.Version_Insert(output, formId, versionName, notes, docVersionId);
                return Convert.ToInt32(output.Value);
            }
        }   
        
        #endregion
    }
}
