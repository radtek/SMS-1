using Bec.DynamicForm.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Omu.ValueInjecter;
using System.Data.Entity;
using Bec.DynamicForm.Entities.DTO;
namespace Bec.DynamicForm.Business
{
    public class FormSectionManager
    {
        #region Add,Update and select section to form
        public static int addSection(FormSectionDTO model)
        {
            return FormSectionDAL.addSectionForm(model.SectionNo, model.SectionName, model.SectionDescription, model.FormId, model.FormSectionParentId);
        }
        public static void updateSection(FormSectionDTO model)
        {
            FormSectionDAL.updateSectionForm(model.FormSectionId, model.SectionNo, model.SectionName, model.SectionDescription, model.FormId, model.FormSectionParentId);
        }
        public static List<FormSectionDTO> Select([Optional] int? sectionId, [Optional] int? formId)
        {
         

            List<FormSectionDTO> list = new List<FormSectionDTO>();
            FormSectionDAL.SelectSection(sectionId, formId).ToList().ForEach(it =>
            {
                var dto = new FormSectionDTO();
                dto.InjectFrom(it);

                list.Add(dto);
            });


            return list;    
        }         
        #endregion

        #region Add and select question to section
        public static void addQuestionToFormSection(Int32? formSectionid, Int64? questionId, Int32? sortingOrderNo, Boolean? isVisible, Boolean? isMandatory)
        {
            FormSectionDAL.addQuestionToSectionForm(formSectionid, questionId, sortingOrderNo, isVisible, isMandatory);
        }
        public static void deleteQuestionFromFormSection(Int32? formSectionid, Int64? questionId)
        {
            FormSectionDAL.deleteQuestionFromSectionForm(formSectionid, questionId);
        }
        #endregion
    }
}
