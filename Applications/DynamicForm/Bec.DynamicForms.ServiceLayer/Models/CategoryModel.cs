using Bec.DynamicForms.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bec.DynamicForms.Models
{
    public class CategoryModel
    {
       
        
        public CategoryModel(Category c)
        {
            Bec.DynamicForms.ServiceLayer.Util.CopyToNew(c, this);
        }
        public CategoryModel()
        {
            
        }
        [System.ComponentModel.DataAnnotations.Display(Name = "CategoryId")]
        public int CategoryId { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Title")]
        public string Title { get; set; }
        
        [System.ComponentModel.DataAnnotations.Display(Name = "ServiceGroupId")]
        public Nullable<int> ServiceGroupId { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Selected")]
        public bool Selected { get; set; }
    }
}