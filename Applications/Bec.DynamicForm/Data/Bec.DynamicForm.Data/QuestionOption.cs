//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bec.DynamicForm.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class QuestionOption
    {
        public QuestionOption()
        {
            this.QuestionOptionLookupTemplates = new HashSet<QuestionOptionLookupTemplate>();
        }
    
        public int OptionId { get; set; }
        public string OptionText { get; set; }
    
        public virtual ICollection<QuestionOptionLookupTemplate> QuestionOptionLookupTemplates { get; set; }
    }
}