using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Entities.Validators;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Bec.TargetFramework.Entities
{
    [FluentValidation.Attributes.ValidatorAttribute(typeof(FirmDetailsDTOValidator))]
    [Serializable]
    [DataContract]
    [KnownType(typeof(List<ClientAccountDTO>))]
    [KnownType(typeof(List<TradingNameDTO>))] 
    public class FirmDetailsDTO
    {
        public FirmDetailsDTO()
        {
            ClientAccounts = new List<ClientAccountDTO>();
            TradingNames = new List<TradingNameDTO>();
        }
        [DataMember]
        [Required]
        public string OrganisationID { get; set; }

        [DataMember]
        public string FirmName { get; set; }

        [DataMember]
        public string TradingName { get; set; }

        [DataMember]
        public string Website { get; set; }

        [DataMember]
        public int Regulator { get; set; }

        [DataMember]
        public string PIIProvider { get; set; }

        [DataMember]
        public string PolicyNumber { get; set; }

        [DataMember]
        public DateTime RenewalDate { get; set; }

        [DataMember]
        public bool IsCompaniesHouseRegistered { get; set; }

        [DataMember]
        public string RegisteredCompanyNumber { get; set; }


        [DataMember]

        public bool IsVATRegistered { get; set; }

        [DataMember]
        public string VATNumber { get; set; }

        [DataMember]
        
        public int? DirectorsCount { get; set; }

        [DataMember]
        public int? RPCount { get; set; }

        [DataMember]
        public int? StaffCount { get; set; }

        [DataMember]
        public int? CompletionsCount { get; set; }

        [DataMember]
        public string OfficePhoneNumber { get; set; }

        [DataMember]
        public string DirectDialNumber { get; set; }

        [DataMember]
        public string AccountName { get; set; }

        [DataMember]
        public string SortCode { get; set; }

        [DataMember]
        public string AccountNumber { get; set; }

        [DataMember]
        public string ID { get; set; }

        [DataMember]
        public bool IsCOFinanceAndAdmin { get; set; }
        [DataMember]
        public List<ClientAccountDTO> ClientAccounts { get; set; }
        [DataMember]
        public List<TradingNameDTO> TradingNames { get; set; }

    }
    [Serializable]
    [DataContract]
    [KnownType(typeof(List<ClientAccountDTO>))]
    public class ClientAccountDTO
    {
        [DataMember]
        public string AccountName { get; set; }

        [DataMember]
        public string SortCode { get; set; }


        [DataMember]
        public long AccountNumber { get; set; }
         [DataMember]
        public string ID { get;set;}

    }

}
