
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.DynamicForms.DataAccess
{
    public class QuestionsDAL
    {

        public static long Add(int sectionId, string questionNo, string description, string questionType, string fileUpload, bool? choiceRequired, bool? choiceAnswered, bool? uploadRequired, string answerChoices, string validationType,
            string helpText, long? parentQuestionId, int? serialNo, string triggerChildQuestions, string triggerUpload, string categoryIds, string maxText, int? versionId,
            string validationFormatString, string uploadCategoryIds, string createdBy, bool? visibleToOppositeTransactionUser, string fileClassName, string subClassName)
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectParameter output = new ObjectParameter("QuestionId", typeof(Int64));
                context.Questions_Insert(output, sectionId, questionNo, description, questionType, fileUpload, choiceRequired, choiceAnswered, uploadRequired, answerChoices, validationType,
                    helpText, parentQuestionId, serialNo, triggerChildQuestions, triggerUpload, categoryIds, maxText, versionId, validationFormatString, uploadCategoryIds, 
                    createdBy, visibleToOppositeTransactionUser, fileClassName, subClassName);

                return Convert.ToInt64(output.Value);
            }
        }
        public static int Update(long? QuestionId, int sectionId, string questionNo, string description, string questionType, string fileUpload, bool? choiceRequired, bool? choiceAnswered, bool? uploadRequired, string answerChoices, string validationType,
            string helpText, long? parentQuestionId, int? serialNo, string triggerChildQuestions, string triggerUpload, string categoryIds, string maxText, int? versionId,
            string validationFormatString, string uploadCategoryIds, string createdBy, bool? visibleToOppositeTransactionUser, string fileClassName, string subClassName)
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectParameter output = new ObjectParameter("QuestionId", typeof(Int32));
                context.Questions_Update(output, QuestionId, sectionId, questionNo, description, questionType, fileUpload, choiceRequired, choiceAnswered, uploadRequired, answerChoices, validationType,
                    helpText, parentQuestionId, serialNo, triggerChildQuestions, triggerUpload, categoryIds, maxText, versionId, validationFormatString, uploadCategoryIds,
                    createdBy, visibleToOppositeTransactionUser, fileClassName, subClassName);

                return Convert.ToInt32(output.Value);
            }
        }

        public static long GetIdByQuestionNo(string questionNo, int? versionId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                
                ObjectResult<long?> obj= context.Questions_GetIdByQuestionNo(questionNo, versionId);
                

                return Convert.ToInt64(obj);
            }
        }
        public static int GetMaxChildCount(long? parentQuestionId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectResult<int?> obj = context.Questions_GetMaxChildCount(parentQuestionId);
                return Convert.ToInt32(obj);
            }
        }
        public static int GetMaxParentCount()
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectResult<int?> obj = context.Questions_GetMaxParentCount();
                return Convert.ToInt32(obj);
            }
        }
        public static long GetMaxQuestionId()
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectResult<long?> obj = context.Questions_GetMaxQuestionId();
                return Convert.ToInt64(obj);
            }
        }
       
        public static  void Promote(long? QuestionId, int sectionId)
        {
            using (var context = new DynamicFormDBEntities())
            {

                context.Questions_Promote(QuestionId, sectionId);
                
            }
        }
        public static void Demote(long? QuestionId, int sectionId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                context.Questions_Demote(QuestionId, sectionId);
            }
        }
        public static List<Questions_Select_Result> Select(long? QuestionId, int sectionId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                List<Questions_Select_Result> obj = context.Questions_Select(sectionId, QuestionId).ToList();
                //List<QuestionModels> model = new List<QuestionModels>();
                //foreach (Questions_Select_Result q in obj)
                //{
                //    model.Add(new QuestionModels(q));
                //}
                //model.ConvertAll(f => obj);
                return obj;
            }
        }
        public static Question Get(long? QuestionId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                List<Question> obj = context.Questions_GetDetails(QuestionId).ToList();
                if(obj.Count>0)
                {
                    return obj[0];
                }               
               return null;
            }
        }
        public static List<Question> GetCurrentVersionQuestionsBySectionId(long? orderId, int? sectionId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                List<Question> obj = context.Questions_GetForm(orderId, sectionId).ToList();
                return obj;
            }
        }

        public static List<ValidationTypes_Select_Result> SelectValidations()
        {
            using (var context = new DynamicFormDBEntities())
            {
                List<ValidationTypes_Select_Result> obj = context.ValidationTypes_Select(null).ToList();
                return obj;
            }
        }

        #region Versions
          public static int AddVersion(Int32? sectionId, string title, string notes, string createdBy)
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectParameter output = new ObjectParameter("versionId", typeof(Int32));
                context.Version_Insert(output, sectionId, title, notes, createdBy);
                return Convert.ToInt32(output.Value);
            }
        }

        
        public static void UpdateVersion(Int32? versionId,Int32? sectionId, string title, string notes, string createdBy)
        {
            using (var context = new DynamicFormDBEntities())
            {
                
                context.Version_Update(versionId, sectionId, title, notes, createdBy);
                
            }
        }
        #endregion
    }
}
