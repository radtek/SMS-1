using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Bec.TargetFramework.Entities.Experian
{
    [DataContract]
    public partial class BWARequestDTO
    {
        [DataMember]
        public bool IsCommericalBankAccount { get; set; }


        [DataMember]
        public string ForeName { get; set; }

        [DataMember]
        public string SurName { get; set; }

        [DataMember]
        public string HouseNumber { get; set; }

        [DataMember]
        public string HouseName { get; set; }

        [DataMember]
        public string Street { get; set; }

        [DataMember]
        public string Postcode { get; set; }

        [DataMember]
        public DateTime DOB { get; set; }

        [DataMember]
        public string OwnerType { get; set; }

        [DataMember]
        public string AccountNumber { get; set; }

        [DataMember]
        public string SortCode { get; set; }

        [DataMember]
        public string RollNumber { get; set; }

        [DataMember]
        public string CheckContext { get; set; }

        [DataMember]
        public DateTime AccountSetupDate { get; set; }

        [DataMember]
        public string AccountType { get; set; }

        [DataMember]
        public string CustomerAccountType { get; set; }

        [DataMember]
        public string CompanyName { get; set; }

        [DataMember]
        public string CompanyType { get; set; }

        [DataMember]
        public string RegNumber { get; set; }

        [DataMember]
        public string VerificationType { get; set; }
    }


}
