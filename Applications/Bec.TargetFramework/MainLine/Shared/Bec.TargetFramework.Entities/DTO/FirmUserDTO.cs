using Bec.TargetFramework.Entities.Helpers;
using Bec.TargetFramework.Entities.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Extensions;


namespace Bec.TargetFramework.Entities
{
    [FluentValidation.Attributes.ValidatorAttribute(typeof(FirmUserDTOValidator))]
    [DataContract]
    [Serializable]
    public class FirmUserDTO
    {

        public FirmUserDTO()
        {
            Roles = Enum.GetValues(typeof(FirmUserRoleEnum)).OfType<object>().Select(o => o.ToString()).ToList();
        }


        [DataMember]
        public Guid? UserID { get; set; }
      
        //Users Details

        [DataMember]
        public int? TitleID { get; set; }
        //Title
        [DataMember]        
        public string Title { get; set; }

        [DataMember]
        
        public string FirstName { get; set; }

        [DataMember]

        public string MiddleName { get; set; }

        [DataMember]
        
        public string LastName { get; set; }

        [DataMember]
        
        public string Email { get; set; }

        [DataMember]
        public int? RegulatorID { get; set; }

        [DataMember]
        public string Regulator { get; set; }
        

        [DataMember]
        public string RegulatorNumber { get; set; }

        [DataMember]
        public List<string> Roles { get; set; }

        [DataMember]
        public string SelectedRoles { get; set; }

        //Firm Details
        [DataMember]        
        public Guid? FirmID { get; set; }

        //Registered name of firm the user will be associated with
        [DataMember]
        public string FirmName { get; set; }

        [DataMember]
        public Guid? BranchID { get; set; }

        [DataMember]
        public string BranchName { get; set; }       

        [DataMember]
        public string Notification { get; set; }
        
        [DataMember]
        public Guid Status { get; set; }

        [DataMember]
        public int? RejectionReasonID { get; set; }

        [DataMember]
        public string RejectionReason { get; set; }

        [DataMember]
        public string OtherRejectionReason { get; set; }

        [DataMember]
        public Boolean IsRegulatorNumberValid { get; set; }
    }
}
