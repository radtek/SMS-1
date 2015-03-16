using Bec.TargetFramework.Entities.Helpers;
using Ext.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Entities.Validators;
using FluentValidation;
using System.Runtime.InteropServices;

namespace Bec.TargetFramework.Entities
{
    //[FluentValidation.Attributes.ValidatorAttribute(typeof(FirmDetailsDTOValidator))]
    [Serializable]
    [DataContract]
    public class FirmDetailsUserDTO
    {
        public FirmDetailsUserDTO()
        {
            BranchAddress = new AddressDTO();
        }

        [DataMember]
        public AddressDTO BranchAddress { get; set; }

        [DataMember]
        public string BranchName { get; set; }

        [DataMember]
        public string BranchRegulatorNumber { get; set; }

        [DataMember]
        [Required]
        public string OrganisationID { get; set; }

        [DataMember]
        public string COTitle { get; set; }

        [DataMember]
        public string COFirstName { get; set; }

        [DataMember]
        public string COLastName { get; set; }

        [DataMember]
        public string CORegulator { get; set; }

        [DataMember]
        public string COEmail { get; set; }

        [DataMember]
        public string CORegulatorNumber { get; set; }

        [DataMember]
        public string FirmName { get; set; }

        [DataMember]
        public string TradingName { get; set; }

        [DataMember]
        public string Website { get; set; }

        [DataMember]
        public int Regulator { get; set; }

        [DataMember]
        public string OfficePhoneNumber { get; set; }

        [DataMember]
        public string DirectDialNumber { get; set; }
        
        [DataMember]
        public string DXNumber { get; set; }
                
        [DataMember]
        public string ID { get; set; }
         [DataMember]
        public Node TreeNode { get;set;}



    }
}
