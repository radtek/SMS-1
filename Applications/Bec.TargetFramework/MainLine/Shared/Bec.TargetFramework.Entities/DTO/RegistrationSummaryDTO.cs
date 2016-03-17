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
    public class RegistrationSummaryDTO
    {

        //COLPS Details
        //Title
        [DataMember]
        
        public string COTitle { get; set; }
        [DataMember]
        
        public string COFirstName{ get; set; }

        [DataMember]
        
        public string COLastName { get; set; }

        [DataMember]
        
       
        //Firm Details
        
        public string FirmRegisteredName { get; set; }

       
        //Co Office addressor branch Details
        //Title
        [DataMember]
        public AddressDTO HeadOfficeAddress { get; set; }



        [DataMember]
        public FirmPreferenceDTO Preference { get; set; }

        //Firm products

        [DataMember]
        public FirmProductDTO Product { get; set; }

       
        [DataMember]
        public List<FirmBranchDTO> Branch { get; set; }

        [DataMember]
        public List<FirmUserDTO> User { get; set; }

        [DataMember]
        public Boolean NeedSummaryEmail { get; set; }

    }



}
