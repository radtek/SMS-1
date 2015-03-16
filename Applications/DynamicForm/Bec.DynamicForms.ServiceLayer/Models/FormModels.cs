using Bec.DynamicForms.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bec.DynamicForms.Models
{
    [Serializable]
    public class FormModels 
    {
        public FormModels()
        {

        }
        //public FormModels(Form f)
        //{
        //    this.FormId = f.FormId;
        //    this.Description = f.Description;
        //    this.ContactDetails = f.ContactDetails;
        //    this.ContactFields = f.ContactFields;
        //    this.CreatedBy = f.CreatedBy;
        //    if(f.CreatedOn.HasValue)
        //        this.CreatedOn = f.CreatedOn.Value;
        //    if (f.UpdatedOn.HasValue)
        //        this.UpdatedOn = f.UpdatedOn;
        //    this.UpdatedBy = f.UpdatedBy;
        //    this.FormName = f.FormName;
        //    if(f.isActive.HasValue)
        //        this.Enable = f.isActive;
        //    if (this.Enable.HasValue && this.Enable.Value)
        //        this.isActive = "InActive";
        //    else
        //        this.isActive = "Active";
        //} 
        [System.ComponentModel.DataAnnotations.Display(Name = "FormId")]
        public int FormId { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Display(Name = "Form name")]
        public string FormName { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Description")]
        public string Description { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "ContactDetails")]
        public string ContactDetails { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "ContactFields")]
        public string ContactFields { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "isActive")]
        public Boolean isActive { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "isActiveStatus")]
        public string isActiveStatus {
            get
            {
                if (isActive)
                    return "Active";
                return "InActive";
            }
        }
        [System.ComponentModel.DataAnnotations.Display(Name = "Enable")]
        public Nullable<bool> Enable { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "CreatedBy")]
        public string CreatedBy { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "CreatedOn")]
        public Nullable<System.DateTime> CreatedOn { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "UpdatedBy")]
        public string UpdatedBy { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "UpdatedOn")]
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public IEnumerable<Bec.DynamicForms.DataAccess.Category> CategoriesList { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Contacts")]
        public IEnumerable<string> Contacts { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Fields")]
        public IEnumerable<string> Fields { get; set; }
    }
}