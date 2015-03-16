//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bec.DynamicForms.DataAccess
{
    using System;
    
    public partial class Questions_Select_Result
    {
        public long QuestionId { get; set; }
        public Nullable<int> SectionId { get; set; }
        public string QuestionNo { get; set; }
        public string Description { get; set; }
        public string QuestionType { get; set; }
        public string FileUpload { get; set; }
        public Nullable<bool> ChoiceRequired { get; set; }
        public Nullable<bool> AnswerRequired { get; set; }
        public Nullable<bool> UploadRequired { get; set; }
        public string AnswerChoices { get; set; }
        public string ValidationType { get; set; }
        public string HelpText { get; set; }
        public Nullable<long> ParentQuestionId { get; set; }
        public Nullable<int> SerialNo { get; set; }
        public string TriggerChildQuestions { get; set; }
        public Nullable<bool> VisibleToOppositeTransactionUser { get; set; }
        public string TriggerUpload { get; set; }
        public string CategoryIds { get; set; }
        public string MaxText { get; set; }
        public Nullable<int> VersionId { get; set; }
        public string ValidationFormatString { get; set; }
        public string CreatedBy { get; set; }
        public string parentQuestionNo { get; set; }
        public string UploadCategoryIds { get; set; }
        public string FileClassName { get; set; }
        public string SubClassName { get; set; }
    }
}
