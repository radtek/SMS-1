using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bec.DynamicForm.Business.Models
{
    public class FormSectionModels: Bec.DynamicForm.Business.BusinessLogic.ITreeNode<FormSectionModels>
    {
        public FormSectionModels()
        {
            
        }        
        public FormSectionModels(Bec.DynamicForm.Data.FormSection obj)
        {
            Bec.DynamicForm.Business.Util.CopyToNew(obj, this);
           
        }
        [System.ComponentModel.DataAnnotations.Display(Name = "FormSectionId")]
        public int FormSectionId { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "FormId")]
        public int FormId { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "SectionName")]
        public string SectionName { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "SectionNo")]
        public int SectionNo { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "SectionDescription")]
        public string SectionDescription { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "FormSectionParentId")]
        public int FormSectionParentId { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "HasChild")]
        public bool HasChild {
            get
            {
                if (Children != null && Children.Count() > 0)
                    return true;
                return false;
            }
        }

        

        public int Id
        {
            get { return FormSectionId; }
        }

        public FormSectionModels Parent
        {
            get;
            set;
        }

        public IList<FormSectionModels> Children
        {
            get;
            set;
            
        }
    }
}