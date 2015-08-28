using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.DynamicForm.Infrastructure.Log;
using Fabrik.Common;
using System.ComponentModel;
using System.Security.Claims;

namespace Bec.DynamicForm.Business.Logic
{
    public class LogicBase
    {
         private ILogger m_Logger {get;set;}

        public ILogger Logger
        {
            get { return m_Logger; }
        }

         public LogicBase(ILogger logger)
        {
            Ensure.Argument.NotNull(logger);

            m_Logger = logger;
        }

        public void SetAuditFields<T>(T entity,bool isNew) where T: class
        {
            var properties = TypeDescriptor.GetProperties(typeof (T));

            if (isNew)
            {
                if (properties["AutoAudit_CreatedDate"] != null)
                    properties["AutoAudit_CreatedDate"].SetValue(entity, DateTime.Now);
                
                if (properties["AutoAudit_CreatedBy"] != null)
                    properties["AutoAudit_CreatedBy"].SetValue(entity, ClaimsPrincipal.Current.Identity.Name); 
            }

            if (properties["AutoAudit_ModifiedDate"] != null)
                properties["AutoAudit_ModifiedDate"].SetValue(entity, DateTime.Now);
            if (properties["AutoAudit_ModifiedBy"] != null)
                properties["AutoAudit_ModifiedBy"].SetValue(entity, ClaimsPrincipal.Current.Identity.Name); 

        }
    }
}
