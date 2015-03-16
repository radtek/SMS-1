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
namespace Bec.DynamicForm.Business
{
    public class QuestionManager
    {

        #region Add/Update and select Question
        //add question to database with options if type is dropbox or checkbox or radio button
        public static long addQuestion(QuestionDTO model)
        {
            
            Int64 questionId = QuestionDAL.addQuestion(model.Description, model.QuestionControlTypeId, model.HelpText, model.MaxText);
            if (model.Options != null)
            {
                foreach (QuestionOptionDTO Op in model.Options)
                {
                    //if it has new option that has not been saved to database add first to database and then get the id of that option and save it with question 
                    QuestionDAL.InsertQuestionOptionLookup(questionId, Op.OptionText);
                }
            }
            if (model.validations != null)
            {
                foreach (ValidationDTO vId in model.validations)
                {
                    //add validation rule to question
                    QuestionDAL.InsertQuestionValidationLookup(vId.ValidationId, questionId);
                }
            }
            return questionId;
        }
        public static long updateQuestion(Int64 questionId, string description, Int32? QuestionControlTypeId, [Optional] string helpText, [Optional] string maxText, [Optional] List<string> questionOptions, [Optional] List<int> ValidationTypeIds)
        {
            QuestionDAL.updateQuestion(questionId, description, QuestionControlTypeId, helpText, maxText);
            if (questionOptions != null)
            {
                foreach (string optionText in questionOptions)
                {
                    //system will ignore option that already added to that question
                    QuestionDAL.InsertQuestionOptionLookup(questionId, optionText);
                }
            }
            if (ValidationTypeIds != null)
            {
                foreach (int vId in ValidationTypeIds)
                {
                    QuestionDAL.InsertQuestionValidationLookup(vId, questionId);
                }
            }
            return questionId;
        }
        //load all question or retreive question by question id
        public static List<QuestionDTO> SelectQuestion(Int64? QuestionId)
        {
            List<QuestionDTO> list = new List<QuestionDTO>();
            QuestionDAL.SelectQuestion(QuestionId).ToList().ForEach(it =>
            {
                var dto = new QuestionDTO();
                dto.InjectFrom(it);

                list.Add(dto);
            });
            return list;
         
        }
        public static List<QuestionDTO> SelectQuestionBySectionId(Int32? sectionId)
        {

            List<QuestionDTO> list = new List<QuestionDTO>();
           
            QuestionDAL.SelectQuestionBySectionId(sectionId).ToList().ForEach(it =>
            {
                var dto = new QuestionDTO();
                dto.InjectFrom(it);

                list.Add(dto);
            });
            return list;
        } 
        #endregion

        #region Add/Update and Select Trigggers
        public static int addTrigger(string triggerValue, string triggerAction, Int64? triggerPointQuestionid, Int32 triggerPointSectionId)
        {
            return TriggersDAL.addTrigger(triggerValue, triggerAction, triggerPointQuestionid, triggerPointSectionId);
        }
        public static void updateTrigger(Int32? TriggerId, string triggerValue, string triggerAction, Int64? triggerPointQuestionid, Int32 triggerPointSectionId)
        {
            TriggersDAL.updateTrigger(TriggerId, triggerValue, triggerAction, triggerPointQuestionid, triggerPointSectionId);
        }
        public static void deleteTrigger(Int32? TriggerId)
        {
            TriggersDAL.deleteTrigger(TriggerId);
        }
        #endregion

        #region Add/Update and Select Validation Controls
        public static int addValidationType(string validationType, string expression, string format, string errorMessage)
        {
           return ValidationTypeDAL.addValidationType( validationType, expression, format, errorMessage);             
        }
        public static void updateValidationType(Int32? ValidationTypeId, string validationType, string expression, string format, string errorMessage)
        {
            ValidationTypeDAL.updateValidationType(ValidationTypeId, validationType, expression, format, errorMessage);            
        }
        public static void deleteValidationType(Int32? ValidationTypeId)
        {
            ValidationTypeDAL.deleteValidationType(ValidationTypeId);            
        }
        public static List<ValidationDTO> SelectValidationType(int? ValidationTypeId)
        {
            List<ValidationDTO> list = new List<ValidationDTO>();
            ValidationTypeDAL.SelectValidationType(ValidationTypeId).ToList().ForEach(it =>
            {
                var dto = new ValidationDTO();
                dto.InjectFrom(it);

                list.Add(dto);
            });
            return list;
        }
        
        #endregion

        #region Add/Update and Select  Controls
        public static int addQuestionControlType(string controlName)
        {
            return QuestionControlTypeDAL.addQuestionControlType(controlName);
        }
        public static void updateQuestionControlType(Int32? questionControlTypeId, string controlName)
        {
            QuestionControlTypeDAL.updateQuestionControlType(questionControlTypeId, controlName);
        }
        public static void deleteQuestionControlType(Int32? questionControlTypeId)
        {
            QuestionControlTypeDAL.deleteQuestionControlType(questionControlTypeId);
        }
        public static List<QuestionControlTypeDTO> SelectQuestionControlType(int? questionControlTypeId)
        {           

            List<QuestionControlTypeDTO> list = new List<QuestionControlTypeDTO>();
            QuestionControlTypeDAL.Select(questionControlTypeId).ToList().ForEach(it =>
            {
                var dto = new QuestionControlTypeDTO();
                dto.InjectFrom(it);

                list.Add(dto);
            });
            return list;
        }

        #endregion

        #region Options
        public static List<QuestionOptionDTO> SelectOptions(int? OptionId, long? QuestionId)
        {

            List<QuestionOptionDTO> list = new List<QuestionOptionDTO>();
            QuestionOptionDAL.SelectOption(OptionId, QuestionId).ToList().ForEach(it =>
            {
                var dto = new QuestionOptionDTO();
                dto.InjectFrom(it);

                list.Add(dto);
            });
            return list;
        } 
        #endregion
    }
}
