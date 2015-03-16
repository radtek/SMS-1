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
using Bec.DynamicForm.Infrastructure.Log;
using Bec.DynamicForm.Business.Logic;
namespace Bec.DynamicForm.Business
{
    public class QuestionLogic : LogicBase
    {

        public QuestionLogic(ILogger logger)
            : base(logger)
        {

        }
        //add question to database with options if type is dropbox or checkbox or radio button
        public static long add(QuestionDTO model)
        {
            Int64 questionId = -1;
            using (var context = new DynamicFormDBEntities())
            {
                ObjectParameter output = new ObjectParameter("QuestionId", typeof(Int64));
                context.Question_Insert(output, model.Description, model.QuestionControlTypeId, model.HelpText, model.MaxText);
                questionId= Convert.ToInt64(output.Value);
            }
            addOptions(questionId,model.Options);
            addValidationType(questionId, model.validations);            
            return questionId;
        }

        private static void addValidationType(long QuestionId, List<ValidationDTO> list)
        {
            if (list != null)
            {
                foreach (ValidationDTO vId in list)
                {
                    using (var context = new DynamicFormDBEntities())
                    {
                        //add validation rule to question
                        ObjectParameter output = new ObjectParameter("ValidationQuestionLookId", typeof(Int64));
                        context.QuestionValidationLookup_Insert(output, vId.ValidationId, QuestionId);
                    }
                }
            }
        }

        private static void addOptions(Int64 questionId,List<QuestionOptionDTO> list)
        {
            if (list != null)
            {
                foreach (QuestionOptionDTO Op in list)
                {
                    //if it has new option that has not been saved to database add first to database and then get the id of that option and save it with question 
                    using (var context = new DynamicFormDBEntities())
                    {
                        ObjectParameter output = new ObjectParameter("QuestionOptionLookupId", typeof(Int64));
                        context.QuestionOptionLookup_Insert(output, questionId, Op.OptionText);
                        
                    }                    
                }
            }
        }
        public static void update(QuestionDTO model)
        {
            using (var context = new DynamicFormDBEntities())
            {
                context.Question_Update(model.QuestionId, model.Description, model.QuestionControlTypeId,model.HelpText,model.MaxText);
            }
            addOptions(model.QuestionId, model.Options);
            addValidationType(model.QuestionId, model.validations);     
            
        }
        //load all question or retreive question by question id
        public static List<QuestionDTO> get(Int64? QuestionId)
        {
            List<QuestionDTO> list = new List<QuestionDTO>();
            using (var context = new DynamicFormDBEntities())
            {             

                context.VQuestion_Select(QuestionId).ToList().ForEach(it =>
                {
                    var dto = new QuestionDTO();
                    dto.InjectFrom(it);

                    list.Add(dto);
                });
            }
            return list;
         
        }
        public static List<QuestionDTO> getBySectionId(Int32? sectionId)
        {

            List<QuestionDTO> list = new List<QuestionDTO>();
            using (var context = new DynamicFormDBEntities())
            {

                context.Question_SelectByFormSection(sectionId).ToList().ForEach(it =>
                {
                    var dto = new QuestionDTO();
                    dto.InjectFrom(it);

                    list.Add(dto);
                });
            }
            
            return list;
        }

        public static List<QuestionOptionDTO> getOptions(int? OptionId, long? QuestionId)
        {

            List<QuestionOptionDTO> list = new List<QuestionOptionDTO>();
            using (var context = new DynamicFormDBEntities())
            {

                context.QuestionOption_Select(OptionId, QuestionId).ToList().ForEach(it =>
                {
                    var dto = new QuestionOptionDTO();
                    dto.InjectFrom(it);
                    list.Add(dto);
                });
            }
           return list;
        } 
    
    }
}
