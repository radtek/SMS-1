using Bec.DynamicForm.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Bec.DynamicForm.Entities.DTO;
using Omu.ValueInjecter;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using Bec.DynamicForm.Business.Logic;
using Bec.DynamicForm.Infrastructure.Log;
namespace Bec.DynamicForm.Business
{
    public class TriggerLogic : LogicBase
    {

        public TriggerLogic(ILogger logger)
            : base(logger)
        {

        }
        public static int add(TriggerDTO trigger)
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectParameter output = new ObjectParameter("TriggerId", typeof(Int32));
                context.Triggers_Insert(output, trigger.TriggerValue, trigger.TriggerAction, trigger.TriggerPointQuestionid, trigger.TriggerPointSectionId);
                return Convert.ToInt32(output.Value);
            }
        }
        public static void update(TriggerDTO trigger)
        {
            using (var context = new DynamicFormDBEntities())
            {
                context.Triggers_Update(trigger.TriggerId, trigger.TriggerValue, trigger.TriggerAction, trigger.TriggerPointQuestionid, trigger.TriggerPointSectionId);
            }
        }
        public static void delete(Int32? TriggerId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                context.Triggers_Delete(TriggerId);
            }
        }
        public static List<Trigger> get(int? TriggerId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                List<Trigger> obj = context.Triggers_Select(TriggerId).ToList();
                return obj;
            }
        }
        
       
      

      
    }
}
