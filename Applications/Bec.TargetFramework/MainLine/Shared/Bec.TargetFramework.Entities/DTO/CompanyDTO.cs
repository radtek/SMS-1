using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    public class CompanyDTO
    {
        [DataMember]
        public Guid CompanyId { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string CompanyAddress1 { get; set; }
        [DataMember]
        public string CompanyAddress2 { get; set; }
        [DataMember]
        public string AdditionalAddressInformation { get; set; }
        [DataMember]
        public string CompanyTownCity { get; set; }
        [DataMember]
        public string CompanyCounty { get; set; }
        [DataMember]
        public string CompanyPostCode { get; set; }
        [DataMember]
        public string SystemAdminTitle { get; set; }
        [DataMember]
        public string SystemAdminFirstName { get; set; }
        [DataMember]
        public string SystemAdminLastName { get; set; }
        [DataMember]
        public string SystemAdminTel { get; set; }
        [DataMember]
        public DateTime CompanyRecordCreated { get; set; }
        [DataMember]
        public string SystemAdminEmail { get; set; }
        [DataMember]
        public DateTime? CompanyPinCreated { get; set; }
        [DataMember]
        public string CompanyPinCode { get; set; }
        [DataMember]
        public string ReturnUrl { get; set; }
        [DataMember]
        public string CompanyRegulator { get; set; }
        [DataMember]
        public string CompanyOtherRegulator { get; set; }

        [DataMember]
        public bool IsCompanyVerified { get; set; }
        [DataMember]
        public bool IsCompanyPinCreated { get; set; }


        //public string SysAdmin
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(SystemAdminFirstName) && string.IsNullOrEmpty(SystemAdminLastName))
        //            return string.Empty;

        //        return SystemAdminFirstName + " " + SystemAdminLastName;
        //    }
        //}


        //public string RegulatorToDisplay
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(CompanyOtherRegulator))
        //            return CompanyOtherRegulator;

        //        return CompanyRegulator;
        //    }
        //}
    }
}