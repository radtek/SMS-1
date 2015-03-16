using Bec.DynamicForms.DataAccess;
using Bec.DynamicForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bec.DynamicForms.ServiceLayer
{
    public class SectionManager
    {
        public static int Add(string name, string description, string CategoryIds, string createdBy)
        {
            return SectionsDAL.Add( name,  description,  CategoryIds,  createdBy);
        }

        public static List<SectionModels> Select(int? sectionId)
        {
            List<Sections_Select_Result> objList = SectionsDAL.Select(sectionId);
            var model = new List<SectionModels>();
            foreach (Sections_Select_Result f in objList)
            {
                SectionModels m = new SectionModels();
                Util.CopyToNew(f, m);
                model.Add(m);
            }
            return model;

        }
       
        public static void Update(Int32? sectionId, string name, string description, bool? enable, string CategoryIds, string createdBy)
        {
            SectionsDAL.Update(sectionId, name, description, enable, CategoryIds, createdBy);
        }
        public static int UpdateStatus(Int32? sectionId, bool? enable, string updatedBy)
        {
            return SectionsDAL.UpdateStatus(sectionId, enable, updatedBy);
        }
    }
}
