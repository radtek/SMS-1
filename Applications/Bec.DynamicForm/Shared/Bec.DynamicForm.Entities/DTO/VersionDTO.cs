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
    using System.Runtime.Serialization;

    [DataContract]
    public class VersionDTO
    {
        public int VersionId { get; set; }
        public Nullable<int> FormId { get; set; }
        public string VersionName { get; set; }
        public string Notes { get; set; }
        public Nullable<int> DocVersionId { get; set; }
    }
}
