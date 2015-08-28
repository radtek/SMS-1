
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;

namespace Bec.DynamicForms.DataAccess
{
    public class FormsDAL 
    {
        #region form 
        public static int Add(string formName, string formDescription, string contactDetails, string contactFeilds, string createdBy)
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectParameter output = new ObjectParameter("formid", typeof(Int32));
                context.Forms_Insert(output, formName, formDescription, contactDetails, contactFeilds, createdBy);
                return Convert.ToInt32(output.Value);
            }
        }
        public static void Update(Int32? formid, string formName, string formDescription, string contactDetails, string contactFeilds, string createdBy)
        {
            using (var context = new DynamicFormDBEntities())
            {
                context.Forms_Update(formid, formName, formDescription, contactDetails, contactFeilds, createdBy);
            }
        }
        public static void UpdateStatus(Int32? formid, bool? IsActive, string UpdatedBy)
        {
            using (var context = new DynamicFormDBEntities())
            {
                context.Forms_UpdateStatus(formid, IsActive, UpdatedBy);
            }
        }
        public static List<Form> Select(int? FormId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                List<Form> obj = context.Forms_Select(FormId).ToList();
                return obj;
                
            }
        }
        public static List<Forms_Sections_Select_Result> SelectSection(int? FormId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                List<Forms_Sections_Select_Result> obj = context.Forms_Sections_Select(FormId).ToList();
                return obj;
            }
        }
        #endregion
        public static Int32 AddSection(Int32? formid, Int32? sectionId, string sectionNO, string createdBy)
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectParameter output = new ObjectParameter("formsectionid", typeof(Int32));
                context.Forms_Sections_Insert(output,sectionId,sectionNO,formid,createdBy);
                return Convert.ToInt32(output.Value);
            }
        }
        public static Int32 UpdateSection(Int32? formsectionid, Int32? formid, Int32? sectionId, string sectionNO, string updatedBy)
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectParameter output = new ObjectParameter("formsectionid", typeof(Int32));
                context.Forms_Sections_Update(output, formsectionid, sectionNO, formid, updatedBy);
                return Convert.ToInt32(output.Value);
            }
        }
        public static void DeleteSection(Int32? formid, Int32? sectionId)
        {
            using (var context = new DynamicFormDBEntities())
            {                
                context.Forms_Sections_Delete(formid,sectionId);                
            }
        }




        public static List<Category> SelectCategories()
        {
            using (var context = new DynamicFormDBEntities())
            {
                List<Category> obj = context.Categories_Select().ToList();
                return obj;
            }
        }

    }
}
