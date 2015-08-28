
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;

namespace Bec.DynamicForms.DataAccess
{
    public class SectionsDAL
    {
        public static List<Sections_Select_Result> Select(int? sectionId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                List<Sections_Select_Result> obj = context.Sections_Select(sectionId).ToList();
                return obj;
               
            }
        }
        
        public static int Add(string name, string description, string CategoryIds, string createdBy)
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectParameter output = new ObjectParameter("sectionid", typeof(Int32));
                context.Sections_Insert(output, name, description, CategoryIds, createdBy);

                return Convert.ToInt32(output.Value);
            }
        }

        

        public static void Update(Int32? sectionId, string name, string description, bool? enable, string CategoryIds, string createdBy)
        {
            using (var context = new DynamicFormDBEntities())
            {

                context.Sections_Update(sectionId, name, description,enable, CategoryIds, createdBy);               
            }
        }
        public static int UpdateStatus(Int32? sectionId, bool? enable, string updatedBy)
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectParameter output = new ObjectParameter("Returns", typeof(Int32));
                context.Sections_UpdateStatus(sectionId, enable, updatedBy);
                return Convert.ToInt32(output.Value);
            }
        }
    }
}
