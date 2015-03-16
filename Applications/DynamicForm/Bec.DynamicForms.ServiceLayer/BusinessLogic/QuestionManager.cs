using Bec.DynamicForms.DataAccess;
using Bec.DynamicForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.DynamicForms.ServiceLayer
{
    public class QuestionManager
    {

        public static long Add(QuestionModels question)
        {

            return QuestionsDAL.Add(question.SectionId, question.QuestionNo, question.Description, question.QuestionType, question.FileUpload, question.ChoiceRequired, question.ChoiceAnswered, question.UploadRequired, question.AnswerChoices, question.ValidationType,
                question.HelpText, question.ParentQuestionId, question.SerialNo, question.TriggerChildQuestions, question.TriggerUpload, question.CategoryIds, question.MaxText, question.VersionId, question.ValidationFormatString, question.UploadCategoryIds,
                question.CreatedBy, question.VisibleToOppositeTransactionUser, question.FileClassName, question.SubClassName);


        }
        public static int Update(QuestionModels question)
        {

            return QuestionsDAL.Update(question.QuestionId, question.SectionId, question.QuestionNo, question.Description, question.QuestionType, question.FileUpload, question.ChoiceRequired, question.ChoiceAnswered, question.UploadRequired, question.AnswerChoices, question.ValidationType,
               question.HelpText, question.ParentQuestionId, question.SerialNo, question.TriggerChildQuestions, question.TriggerUpload, question.CategoryIds, question.MaxText, question.VersionId, question.ValidationFormatString, question.UploadCategoryIds,
               question.CreatedBy, question.VisibleToOppositeTransactionUser, question.FileClassName, question.SubClassName);
                 

        }

        public static long GetIdByQuestionNo(string questionNo, int? versionId)
        {
            return QuestionsDAL.GetIdByQuestionNo(questionNo, versionId);

        }
        public static int GetMaxChildCount(long? parentQuestionId)
        {
            return QuestionsDAL.GetMaxChildCount(parentQuestionId);
             
        }
        public static int GetMaxParentCount()
        {
             return QuestionsDAL.GetMaxParentCount();
                
        }
        public static long GetMaxQuestionId()
        {
            return QuestionsDAL.GetMaxQuestionId();
            
        }
       
        public static  void Promote(long? QuestionId, int sectionId)
        {
              QuestionsDAL.Promote(QuestionId, sectionId);
        }
        public static void Demote(long? QuestionId, int sectionId)
        {
              QuestionsDAL.Demote(QuestionId, sectionId);
            
        }
        public static List<QuestionModels> Select(long? QuestionId, int sectionId)
        {
            List<Questions_Select_Result> obj= QuestionsDAL.Select(QuestionId, sectionId);
            List<QuestionModels> list = new List<QuestionModels>();
            foreach (Questions_Select_Result o in obj)
            {
                QuestionModels model = new QuestionModels();
                Util.CopyToNew(o, model);
                list.Add(model);
            }
            return list;
            
        }
        public static Question Select(long? QuestionId)
        {
             return QuestionsDAL.Get(QuestionId);
            
        }
        public static List<Question> GetCurrentVersionQuestionsBySectionId(long? OrderId, int? sectionId)
        {
            return QuestionsDAL.GetCurrentVersionQuestionsBySectionId(OrderId, sectionId);
        }

        public static List<ValidationModel> SelectValidations()
        {
            List<ValidationTypes_Select_Result> obj = QuestionsDAL.SelectValidations();
            List<ValidationModel> list = new List<ValidationModel>();
            foreach (ValidationTypes_Select_Result o in obj)
            {
                list.Add(new ValidationModel(o));
            }
            return list;

        }
        #region Version 
        public static int AddVersion(Int32? sectionId, string title, string notes, string createdBy)
        {
            return QuestionsDAL.AddVersion(sectionId, title, notes, createdBy);
        }

        
        public static void UpdateVersion(Int32? versionId,Int32? sectionId, string title, string notes, string createdBy)
        {
            QuestionsDAL.UpdateVersion(versionId, sectionId, title, notes, createdBy);
        }
        #endregion
    }
}
