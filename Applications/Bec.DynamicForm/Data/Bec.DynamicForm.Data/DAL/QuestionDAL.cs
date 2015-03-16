
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
namespace Bec.DynamicForm.Data
{
    public class QuestionDAL
    {

        #region Add,Update,Delete and Select Question
        public static long addQuestion(string description, int? QuestionControlTypeId, string helpText, [Optional] string maxText)
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectParameter output = new ObjectParameter("QuestionId", typeof(Int64));
                context.Question_Insert(output, description, QuestionControlTypeId, helpText, maxText);
                return Convert.ToInt64(output.Value);
            }

        }
        public static void updateQuestion(Int64? QuestionId,string description, int? QuestionControlTypeId, string helpText, [Optional] string maxText)
        {
            using (var context = new DynamicFormDBEntities())
            {
                context.Question_Update(QuestionId, description, QuestionControlTypeId, helpText, maxText);                
            }

        }
        public static void deleteQuestion(Int64? QuestionId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                context.Question_Delete(QuestionId);
            }

        }
        
        public static List<VQuestion_Select_Result> SelectQuestion(Int64? QuestionId)
        {

            using (var context = new DynamicFormDBEntities())
            {
                List<VQuestion_Select_Result> list = context.VQuestion_Select(QuestionId).ToList();

                return list;
            }

        }
        public static List<Question> SelectQuestionBySectionId(Int32? sectionId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                List<Question> list = context.Question_SelectByFormSection(sectionId).ToList();
                return list;
            }

        }
        #endregion

        #region Insert,Delete Validaton Lookup Values
        public static int InsertQuestionValidationLookup(Int32? validationTypeId, Int64? QuestionId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectParameter output = new ObjectParameter("ValidationQuestionLookId", typeof(Int64));
                context.QuestionValidationLookup_Insert(output, validationTypeId, QuestionId);
                return Convert.ToInt32(output.Value);
            }
        }
        public static void deleteQuestionValidationLookup(Int32? validationTypeId, Int64? questionId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                context.QuestionValidationLookup_Delete(validationTypeId,questionId);
            }

        }
        #endregion
     
        #region Insert,Delete Question Option Lookup Values
        public static int InsertQuestionOptionLookup(Int64? questionId, string optionText)
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectParameter output = new ObjectParameter("QuestionOptionLookupId", typeof(Int64));
                context.QuestionOptionLookup_Insert(output, questionId, optionText);
                return Convert.ToInt32(output.Value);
            }
        }
        public static void deleteQuestionOptionLookup(Int64? questionId, Int32? optionId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                context.QuestionOptionLookup_Delete(questionId, optionId);
            }

        }

        #endregion

    }
}
