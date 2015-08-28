
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Bec.DynamicForm.Data
{
    public class FormDAL 
    {
        #region Add,Update and Select Form  
        public static int addForm(string formName, string formDescription, [Optional] Int32? parentId, [Optional] Int32? formTypeId,[Optional] Int32? versionid, [Optional] Boolean? isActive)
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectParameter output = new ObjectParameter("formid", typeof(Int32));
                context.Form_Insert(output, formName, formDescription,parentId,formTypeId,versionid,isActive);
                return Convert.ToInt32(output.Value);
            }
        }
        public static void updateForm(Int32? formid, string formName, string formDescription, [Optional] Int32? parentId, [Optional] Int32? formTypeId, [Optional] Int32? versionid, [Optional] Boolean? isActive)
        {
            using (var context = new DynamicFormDBEntities())
            {
                context.Form_Update(formid, formName, formDescription, parentId, formTypeId, versionid, isActive);
            }
        }
       
        public static List<Form> selectForm(int? FormId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                List<Form> obj = context.Form_Select(FormId).ToList();
                return obj;
                
            }
        }
        public static void deleteForm(int? FormId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                context.Form_Delete(FormId);             

            }
        }

        #endregion
        //public static Int32 AddSection(Int32? formid, Int32? sectionId, string sectionNO, string createdBy)
        //{
        //    using (var context = new DynamicFormDBEntities())
        //    {
        //        ObjectParameter output = new ObjectParameter("formsectionid", typeof(Int32));
        //        context.(output,sectionId,sectionNO,formid,createdBy);
        //        return Convert.ToInt32(output.Value);
        //    }
        //}
        //public static Int32 UpdateSection(Int32? formsectionid, Int32? formid, Int32? sectionId, string sectionNO, string updatedBy)
        //{
        //    using (var context = new DynamicFormDBEntities())
        //    {
        //        ObjectParameter output = new ObjectParameter("formsectionid", typeof(Int32));
        //        context.Forms_Sections_Update(output, formsectionid, sectionNO, formid, updatedBy);
        //        return Convert.ToInt32(output.Value);
        //    }
        //}
        //public static void DeleteSection(Int32? formid, Int32? sectionId)
        //{
        //    using (var context = new DynamicFormDBEntities())
        //    {                
        //        context.Forms_Sections_Delete(formid,sectionId);                
        //    }
        //}




        //public static List<Category> SelectCategories()
        //{
        //    using (var context = new DynamicFormDBEntities())
        //    {
        //        List<Category> obj = context.Categories_Select().ToList();
        //        return obj;
        //    }
        //}

    }
}
