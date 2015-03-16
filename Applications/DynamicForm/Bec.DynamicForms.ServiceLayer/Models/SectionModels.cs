using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bec.DynamicForms.Models
{
    public class SectionModels
    {

        //public SectionModels(Bec.DynamicForms.DataAccess.Forms_Sections_Select_Result section, int pFormId)
        //{
        //    this.CategoryIds = section.CategoryIds;
        //    if (section.Enable.HasValue)
        //        this.Enable = section.Enable.Value;
        //    this.CreatedBy = section.CreatedBy;
        //    if (section.CreatedOn.HasValue)
        //        this.CreatedOn = section.CreatedOn.Value;
        //    this.Description = section.Description;
        //    this.SectionId = section.SectionId;
        //    this.SectionName = section.SectionName;
        //    this.FormId = pFormId;
        //    this.SectionNo = section.SectionNo;
           
        //}
        //public SectionModels(Bec.DynamicForms.DataAccess.Sections_Select_Result section)
        //{
        //    this.CategoryIds = section.CategoryIds;
        //    this.Enable = section.Enable;
        //    this.CreatedBy = section.CreatedBy;            
        //    this.Description = section.Description;
        //    this.SectionId = section.SectionId;
        //    this.SectionName = section.SectionName;
            
            

        //}
        public SectionModels()
        {

        }

        [System.ComponentModel.DataAnnotations.Display(Name = "SectionId")]
        public int SectionId { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "FormId")]
        public int FormId { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "SectionName")]
        public string SectionName { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "SectionNo")]
        public string SectionNo { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Description")]
        public string Description { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Enable")]
        public string Enable { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Selected")]
        public bool Selected { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "CategoryIds")]
        public string CategoryIds { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "CreatedBy")]
        public string CreatedBy { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "CreatedOn")]
        public System.DateTime CreatedOn { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "UpdatedBy")]
        public string UpdatedBy { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "UpdatedOn")]
        public System.DateTime UpdatedOn { get; set; }

        public List<CategoryModel> Categories { get; set; }


        public void IsCategoryBelongToSection()
        {
            char[] separators = { '|', '|', };
            if (!string.IsNullOrEmpty(CategoryIds))
            {
                string[] strArray = CategoryIds.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                if (strArray.Length > 0)
                {
                    foreach (CategoryModel c in Categories)
                    {
                        foreach (string field in strArray)
                        {
                            if (field == c.CategoryId.ToString())
                            {
                                c.Selected = true;
                                break;
                            }
                        }
                    }
                }
            }

           
        }
    }
}