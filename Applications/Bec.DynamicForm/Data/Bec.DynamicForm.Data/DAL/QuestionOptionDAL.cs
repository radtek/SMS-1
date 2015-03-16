using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.DynamicForm.Data
{
    public class QuestionOptionDAL
    {
        #region Add,update,Delete and Select QuestionOption
        public static int addQuestionOption(string OptionText)
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectParameter output = new ObjectParameter("OptionId", typeof(Int32));
                context.QuestionOption_Insert(output, OptionText);
                return Convert.ToInt32(output.Value);
            }
        }
        public static void updateQuestionOption(Int32? OptionId, string OptionText)
        {
            using (var context = new DynamicFormDBEntities())
            {
                context.QuestionOption_Update(OptionId, OptionText);
            }
        }
        public static void deleteQuestionOption(Int32? OptionId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                context.QuestionOption_Delete(OptionId);
            }
        }
        public static List<QuestionOption> SelectOption(int? OptionId,long? QuestionId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                List<QuestionOption> obj = context.QuestionOption_Select(OptionId,QuestionId).ToList();
                return obj;

            }
        }
        #endregion
    }
}
