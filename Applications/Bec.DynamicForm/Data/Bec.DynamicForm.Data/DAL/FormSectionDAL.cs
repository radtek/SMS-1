
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;

namespace Bec.DynamicForm.Data
{
    public class FormSectionDAL
    {
        #region Add,update,Delete and Select Section
        public static int addSectionForm(int sectionNo, string sectionName, string sectionDescription, Int32? formId, Int32 formSectionParentId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectParameter output = new ObjectParameter("FormSectionId", typeof(Int32));
                context.FormSection_Insert(output, sectionNo, sectionName, sectionDescription, formId, formSectionParentId);
                return Convert.ToInt32(output.Value);
            }
        }
        public static void updateSectionForm(Int32? sectionid,int sectionNo, string sectionName, string sectionDescription, Int32? formId, Int32 formSectionParentId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                context.FormSection_Update(sectionid, sectionNo, sectionName, sectionDescription, formId, formSectionParentId);                
            }
        }
        public static void deleteSectionForm(Int32? sectionid)
        {
            using (var context = new DynamicFormDBEntities())
            {
                context.FormSection_Delete(sectionid);
            }
        }
        public static List<FormSection> SelectSection(int? sectionId,Int32? formId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                List<FormSection> obj = context.FormSection_Select(sectionId,formId).ToList();
                return obj;

            }
        }
        #endregion

        #region Add,Delete Question to section
        public static int addQuestionToSectionForm(Int32? formSectionid,Int64? questionId,Int32? sortingOrderNo,Boolean? isVisible,Boolean? isMandatory)
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
        #endregion
    }
}
