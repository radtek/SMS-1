using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Entities.Validators;
using FluentValidation;

namespace Bec.TargetFramework.Entities
{
    [FluentValidation.Attributes.ValidatorAttribute(typeof(PersonalDetailsDTOValidator))]
    [Serializable]
    [DataContract]
    [KnownType(typeof(List<OtherNameDTO>))]
    [KnownType(typeof(List<TelephoneDTO>))]
    [KnownType(typeof(List<AddressDTO>))] 
    public class PersonalDetailDTO
    {
        public PersonalDetailDTO()
        {
            HomeAddress = new AddressDTO();
            OtherAddress = new AddressDTO();
            OtherNames = new List<OtherNameDTO>();
            Addressess = new List<AddressDTO>();
            Telephones = new List<TelephoneDTO>();
        }

        [DataMember]
        public AddressDTO HomeAddress { get; set; }

        [DataMember]
        public AddressDTO OtherAddress { get; set; }
        
        [DataMember]
        public string TelephoneNumber { get; set; }
        [DataMember]
        public int TelephoneNumberTypeID { get; set; }
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public int TitleTypeID { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public int GenderTypeID { get; set; }
        [DataMember]
        public DateTime DateOfBirth { get; set; }
        [DataMember]
        public int NationalityTypeID { get; set; }
        [DataMember]
        public int IsCurrentAddressOutsideUK { get; set; }
        [DataMember]
        public string SortCode { get; set; }
        [DataMember]
        public string AccountNumber { get; set; }
        [DataMember]
        public int AccountOpenedYear { get; set; }
        [DataMember]
        public int AccountOpenedMonth { get; set; }
        [DataMember]
        public string IBANNumber { get; set; }
        [DataMember]
        public string SwiftNumber { get; set; }
        [DataMember]
        public bool HasAdditionalBuyers { get; set; }

        [DataMember]
        public int HasNameChanges { get; set; }

        [DataMember]
        public int HasOtherAddressesLast3Years { get; set; }

        [DataMember]
        public int IsRegulatedPractitioner { get; set; }

        [DataMember]
        public int RegulatorTypeID { get; set; }

        [DataMember]
        public int? YearsLivingFor { get; set; }

        [DataMember]
        public int? MonthsLivingFor { get; set; }

        [DataMember]
        public string RegulatorNumber { get; set; }

        [DataMember]
        public List<OtherNameDTO> OtherNames { get; set; }

        [DataMember]
        public List<AddressDTO> Addressess { get; set; }

        [DataMember]
        public List<TelephoneDTO> Telephones { get; set; }
    }

    [Serializable]
    [DataContract]
    public class OtherNameDTO
    {
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public int? TitleTypeID { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
        [DataMember]
        public string LastName { get; set; }
    }
}
