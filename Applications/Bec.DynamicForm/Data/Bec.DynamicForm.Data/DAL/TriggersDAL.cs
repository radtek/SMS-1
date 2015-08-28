using Bec.DynamicForm.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.DynamicForm.Data
{
    public class TriggersDAL
    {
        #region Add,update,Delete and Select Triggers
        public static int addTrigger(string triggerValue, string triggerAction, Int64? triggerPointQuestionid, Int32 triggerPointSectionId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectParameter output = new ObjectParameter("TriggerId", typeof(Int32));
                context.Triggers_Insert(output,triggerValue,triggerAction,triggerPointQuestionid,triggerPointSectionId);
                return Convert.ToInt32(output.Value);
            }
        }
        public static void updateTrigger(Int32? TriggerId, string triggerValue, string triggerAction, Int64? triggerPointQuestionid, Int32 triggerPointSectionId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                context.Triggers_Update(TriggerId, triggerValue, triggerAction, triggerPointQuestionid, triggerPointSectionId);
            }
        }
        public static void deleteTrigger(Int32? TriggerId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                context.Triggers_Delete(TriggerId);
            }
        }
        public static List<Trigger> SelectSection(int? TriggerId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                List<Trigger> obj = context.Triggers_Select(TriggerId).ToList();
                return obj;
            }
        }
        #endregion
    }
}
