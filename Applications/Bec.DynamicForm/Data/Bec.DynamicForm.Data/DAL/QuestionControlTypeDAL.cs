using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.DynamicForm.Data
{
    public class QuestionControlTypeDAL
    {
        #region Add,update,Delete and Select QuestionControlType
        public static int addQuestionControlType(string controlTypeName)
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectParameter output = new ObjectParameter("questionControlTypeId", typeof(Int32));
                context.QuestionControlType_Insert(output, controlTypeName);
                return Convert.ToInt32(output.Value);
            }
        }
        public static void updateQuestionControlType(Int32? questionControlTypeId, string questionControlTypeName)
        {
            using (var context = new DynamicFormDBEntities())
            {
                context.QuestionControlType_Update(questionControlTypeId, questionControlTypeName);
            }
        }
        public static void deleteQuestionControlType(Int32? questionControlTypeId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                context.QuestionControlType_Delete(questionControlTypeId);
            }
        }
        public static List<QuestionControlType> Select(int? questionControlTypeId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                List<QuestionControlType> obj = context.QuestionControlType_Select(questionControlTypeId).ToList();
                return obj;

            }
        }
        #endregion
    }
}
