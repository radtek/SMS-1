using Bec.TargetFramework.Entities.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Bec.TargetFramework.Entities
{
    [DataContract]
    [Serializable]
    public class RegistrationDTO
    {

        public RegistrationDTO()
        {
         
            COOfficeAddress = new AddressDTO();
         
        }

        //COLPS Details
        //Title
        [DataMember]
        
        public string COTitle { get; set; }
        [DataMember]
        
        public string COFirstName{ get; set; }

        [DataMember]
        
        public string COLastName { get; set; }

        [DataMember]
        
       
        public string COEmail { get; set; }
        //COO Regulator
        [DataMember]
        
        public string CORegulator { get; set; }

        [DataMember]
        public Boolean AmIComplianceOfficer { get; set; }

        [DataMember]
        
        public string CORegulatorNumber { get; set; }

        //Users Details
        //Title
        [DataMember]
        
        public string Title { get; set; }

        [DataMember]
        
        public string FirstName { get; set; }

        [DataMember]
        
        public string LastName { get; set; }

        [DataMember]
        
        public string Email { get; set; }

        //Firm Details
        [DataMember]
        
        public string FirmRegisteredName { get; set; }

        [DataMember]

        public string FirmTradingName { get; set; }

        //FirmRegulator(CLC/SRA)
        [DataMember]
        
        public string FirmRegulator { get; set; }


        //Co Office addressor branch Details
        //Title
        [DataMember]
        public Boolean IsCOOfficeHeadOffice { get; set; }
        [DataMember]
        public AddressDTO COOfficeAddress { get; set; }
        [DataMember]
        public string COOfficeAddressAdditionalInformation { get; set; }
        [DataMember]
        
        public string COOfficeBranchRegulatorNumber { get; set; }
    }
}
