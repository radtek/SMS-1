using Bec.DynamicForm.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Omu.ValueInjecter;
using System.Data.Entity;
using Bec.DynamicForm.Entities.DTO;
using Bec.DynamicForm.Business.Logic;
using Bec.DynamicForm.Infrastructure.Log;
using System.Data.Entity.Core.Objects;
namespace Bec.DynamicForm.Business
{
    public class FormSectionLogic : LogicBase
    {
        public FormSectionLogic(ILogger logger)
            : base(logger)
        {

        }
       
        public static int add(FormSectionDTO model)
        {
            
            using (var context = new DynamicFormDBEntities())
            {
               ObjectParameter output = new ObjectParameter("FormSectionId", typeof(Int32));
                context.FormSection_Insert(output, model.SectionNo, model.SectionName, model.SectionDescription, model.FormId, model.FormSectionParentId);
                return Convert.ToInt32(output.Value);
            }
        }
        public static void update(FormSectionDTO model)
        {
            
            using (var context = new DynamicFormDBEntities())
            {
                context.FormSection_Update(model.FormSectionId, model.SectionNo, model.SectionName, model.SectionDescription, model.FormId, model.FormSectionParentId);
            }
        }
       
       
        public static FormSectionDTO get(int? sectionId)
        {

            var dto = new FormSectionDTO();
            using (var context = new DynamicFormDBEntities())
            {
                context.FormSection_Get(sectionId).ToList().ForEach(it =>
                {                    
                    dto.InjectFrom(it);                   
                });

            }
            return dto;
        }
        public static List<FormSectionDTO> getAllByFormId(int? formId)
        {
            List<FormSectionDTO> list = new List<FormSectionDTO>();
            using (var context = new DynamicFormDBEntities())
            {
                context.FormSection_GetAllByFormId(formId).ToList().ForEach(it =>
                {
                    var dto = new FormSectionDTO();
                    dto.InjectFrom(it);
                    list.Add(dto);
                });                

            }
          


            return list;
        }
        public static List<FormSectionDTO> getAllByParentId(int? parentSectionId)
        {
            List<FormSectionDTO> list = new List<FormSectionDTO>();
            using (var context = new DynamicFormDBEntities())
            {
                context.FormSection_GetAllByParentId(parentSectionId).ToList().ForEach(it =>
                {
                    var dto = new FormSectionDTO();
                    dto.InjectFrom(it);
                    list.Add(dto);
                });

            }



            return list;
        }
       
        public static int addQuestionToSectionForm(Int32? formSectionid, Int64? questionId, Int32? sortingOrderNo, Boolean? isVisible, Boolean? isMandatory)
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectParameter output = new ObjectParameter("FormSectionQuestionid", typeof(Int32));
                context.FormSectionQuestion_Insert(output, formSectionid, questionId, sortingOrderNo, isVisible, isMandatory);
                return Convert.ToInt32(output.Value);
            }
        }
        public static void deleteQuestionFromSectionForm(Int32? formSectionid, Int64? questionId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                context.FormSectionQuestion_Delete(formSectionid, questionId);
            }
        }
    }
}
