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
    public class FirmBranchDTO
    {

        public FirmBranchDTO()
        {
            this.Address = new AddressDTO();
        }
        
        [DataMember]
        public Guid ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Boolean IsBranchHeadOffice { get; set; }


        [DataMember]
        public int? BranchAdminID { get; set; }

        [DataMember]
        public string BranchAdminName { get; set; }

        [DataMember]
        public int? TotalRPCount { get; set; }

        [DataMember]
        public int? TotalStaffCount { get; set; }       

        [DataMember]
        public int? RegulatorID { get; set; }

        [DataMember]
        public string Regulator { get; set; }

        [DataMember]
        public string RegulatorNumber { get; set; }



        //Firm Details
        [DataMember]
        public Guid? FirmID { get; set; }

        //Registered name of firm the user will be associated with
        [DataMember]
        public string FirmName { get; set; }


        [DataMember]
        public string DXNumber { get; set; }

        [DataMember]
        public AddressDTO Address { get; set; }

        [DataMember]
        public string Notification { get; set; }

        [DataMember]
        public int? StatusID { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public int? RejectionReasonID { get; set; }

        [DataMember]
        public string RejectionReason { get; set; }

        [DataMember]
        public string OtherRejectionReason { get; set; }
    }
}
