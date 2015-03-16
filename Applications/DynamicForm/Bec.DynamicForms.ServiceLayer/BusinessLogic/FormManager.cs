using Bec.DynamicForms.DataAccess;
using Bec.DynamicForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bec.DynamicForms.ServiceLayer
{
    public class FormManager
    {
        public static int Add(Form form)
        {

            return FormsDAL.Add(form.FormName, form.Description, form.ContactDetails, form.ContactFields, form.CreatedBy);
            
        }
        public static void Update(Form form)
        {
            FormsDAL.Update(form.FormId, form.FormName, form.Description, form.ContactDetails, form.ContactFields, form.CreatedBy);
        }
        public static void Update(int FormId,bool? IsActive,string UpdatedBy)
        {
            FormsDAL.UpdateStatus(FormId, IsActive, UpdatedBy);
        }
        public static List<FormModels> Select(Int32? formid)
        {
            List<Form> objList= FormsDAL.Select(formid);
            var model = new List<FormModels>();
            foreach (Form f in objList)
            {
                FormModels m = new FormModels();
                Util.CopyToNew(f, m);
                model.Add(m);
            }
            return model;
        }
        public static Int32 AddSection(Int32? formid, Int32? sectionId, string sectionNO, string createdBy)
        {

            return FormsDAL.AddSection(formid, sectionId, sectionNO, createdBy);
               
        }
        public static List<SectionModels> SelectSection(Int32? formid)
        {
            List<Forms_Sections_Select_Result> objList = FormsDAL.SelectSection(formid);
            var model = new List<SectionModels>();
            foreach (Forms_Sections_Select_Result f in objList)
            {
                SectionModels m = new SectionModels();
                m.FormId = ((formid.HasValue) ? 0 : formid.Value);
                Util.CopyToNew(f, m);
                model.Add(m);
            }
            return model;

        }
        public static Int32 UpdateSection(Int32? formsectionid, Int32? formid, Int32? sectionId, string sectionNO, string updatedBy)
        {
            return FormsDAL.UpdateSection(formsectionid, formid, sectionId, sectionNO, updatedBy);
        }
        public static void DeleteSection(Int32? formid, Int32? sectionId)
        {
            FormsDAL.DeleteSection(formid,sectionId);
        }
        

        

        public static List<CategoryModel> SelectCategories()
        {
            List<Category> objList= FormsDAL.SelectCategories();
            var model = new List<CategoryModel>();
            foreach (Category f in objList)
            {                
                model.Add(new CategoryModel(f));
            }
            return model;

        }
    }
}
