using Bec.DynamicForms.DataAccess;
using Bec.DynamicForms.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.DynamicForms.Models
{

    public class QuestionModels
    {
        public QuestionModels()
        {
            ChildList = new List<QuestionModels>();        
            

        }     
        public void Initialize()
        {
            /* Question Type Radio Button List*/
            QuestionTypeList = new List<QuestionTypeModel>();
            QuestionTypeList.Add(new QuestionTypeModel("None"));
            QuestionTypeList.Add(new QuestionTypeModel("Single Text"));
            QuestionTypeList.Add(new QuestionTypeModel("Multiple Text"));
            QuestionTypeList.Add(new QuestionTypeModel("Dropdown"));
            QuestionTypeList.Add(new QuestionTypeModel("Radio Button"));
            QuestionTypeList.Add(new QuestionTypeModel("CheckBox"));
            QuestionTypeList.Add(new QuestionTypeModel("Dropdown/Single Text"));
            QuestionTypeList.Add(new QuestionTypeModel("Dropdown/Multiple Text"));
            QuestionTypeList.Add(new QuestionTypeModel("Radio Button/Single Text"));
            QuestionTypeList.Add(new QuestionTypeModel("Radio Button/Multiple Text"));
            QuestionTypeList.Add(new QuestionTypeModel("CheckBox/Single Text"));
            QuestionTypeList.Add(new QuestionTypeModel("CheckBox/Multiple"));

            /* Upload Type List*/
            UploadTypeList = new List<UploadTypeModel>();
            UploadTypeList.Add(new UploadTypeModel("Single"));
            UploadTypeList.Add(new UploadTypeModel("Multiple"));
            UploadTypeList.Add(new UploadTypeModel("None"));

            /* Validation List*/
            ValidationList = Bec.DynamicForms.ServiceLayer.QuestionManager.SelectValidations();
            /* Role That responsible to answer List*/
            AnswerRoleList = FormManager.SelectCategories();
            /* Role that responsible to upload files*/
            UploadRoleList = FormManager.SelectCategories();

            AnswerChoiceList = new List<AnswerChoiceModel>();
            AnswerChoiceList.Add(new AnswerChoiceModel("Yes"));
          

        }
        [System.ComponentModel.DataAnnotations.Display(Name = "QuestionId")]
        public long QuestionId { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "SectionId")]
        public int SectionId { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "QuestionNo")]
        public string QuestionNo { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Description")]
        public string Description { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "QuestionType")]
        public string QuestionType { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "FileUpload")]
        public string FileUpload { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "ChoiceRequired")]
        public bool ChoiceRequired { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "AnswerRequired")]
        public bool AnswerRequired { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "UploadRequired")]
        public bool UploadRequired { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "AnswerChoices")]
        public string AnswerChoices { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "ValidationType")]
        public string ValidationType { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "HelpText")]
        public string HelpText { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "ParentQuestionId")]
        public long ParentQuestionId { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "SerialNo")]
        public int SerialNo { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "TriggerChildQuestions")]
        public string TriggerChildQuestions { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "TriggerUpload")]
        public string TriggerUpload { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "CategoryIds")]
        public string CategoryIds { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "MaxText")]
        public string MaxText { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "VersionId")]
        public int VersionId { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "CreatedBy")]
        public string CreatedBy { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "CreatedOn")]
        public Nullable<System.DateTime> CreatedOn { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "UpdatedBy")]
        public string UpdatedBy { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "UpdatedOn")]
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "ValidationFormatString")]
        public string ValidationFormatString { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "IsActive")]
        public Nullable<bool> IsActive { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "ParentQuestionNo")]
        public string ParentQuestionNo { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "UploadCategoryIds")]
        public string UploadCategoryIds { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "VisibleToOppositeTransactionUser")]
        public bool VisibleToOppositeTransactionUser { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "FileClassName")]
        public string FileClassName { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "SubClassName")]
        public string SubClassName { get; set; }

        public List<QuestionModels> ChildList { get; set; }
        public List<QuestionTypeModel> QuestionTypeList { get; set; }
        public List<UploadTypeModel> UploadTypeList { get; set; }
        public List<AnswerChoiceModel> AnswerChoiceList { get; set; }

        public List<CategoryModel> AnswerRoleList { get; set; }
        public List<CategoryModel> UploadRoleList { get; set; }

      

        [System.ComponentModel.DataAnnotations.Display(Name = "bHideChild")]
        public bool bHideChild { get; set; }

        
        [System.ComponentModel.DataAnnotations.Display(Name = "bUnHideChild")]
        public bool bUnUploadChild { get; set; }

        public List<ValidationModel> ValidationList { get; set; }
    }

    public class QuestionTypeModel
    {
        public QuestionTypeModel(string pQuestionType)
        {
            this.QuestionTypeName = pQuestionType;
        }
        [System.ComponentModel.DataAnnotations.Display(Name = "Selected")]
        public bool Selected { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "QuestionTypeName")]
        public string QuestionTypeName { get; set; }
    }
    public class UploadTypeModel
    {
        public UploadTypeModel(string pUploadTypeName)
        {
            this.UploadTypeName = pUploadTypeName;
        }
        [System.ComponentModel.DataAnnotations.Display(Name = "Selected")]
        public bool Selected { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "UploadTypeName")]
        public string UploadTypeName { get; set; }
    }
    
    /*List of choice either for dropdown or for other type of list for example radio button list or checkbox list*/
    public class AnswerChoiceModel
    {
        public AnswerChoiceModel(string pName,[System.Runtime.InteropServices.Optional] string ChoiceId)
        {
            this.ChoiceName = pName;
            if (string.IsNullOrEmpty(ChoiceId))
            {


            }
        }
        public AnswerChoiceModel()
        {
            
        }
        [System.ComponentModel.DataAnnotations.Display(Name = "Selected")]
        public bool Selected { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "bUnHideChildQuestion")]
        public bool bUnHideChildQuestion { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "bUnHideUploadControl")]
        public bool bUnHideUploadControl { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "ChoiceName")]
        public string ChoiceName { get; set; }
        public string Id { get; set; }
    }
}
