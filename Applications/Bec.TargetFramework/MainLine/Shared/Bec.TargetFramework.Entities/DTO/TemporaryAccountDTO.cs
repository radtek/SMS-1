using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Entities.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Common.Support;


namespace Bec.TargetFramework.Entities
{
    [DataContract]
    [Serializable]
    public class TemporaryAccountDTO
    {
        public TemporaryAccountDTO()
        {
            // initially set this value on object creation
            TemporaryUserId = Guid.NewGuid();
            IsColp = false;
            IsFromOrganisationInternalInvite = false;
            IsFromOrganisationInternalInvite = false;
            IsFromProfessionalInvite = false;
            IsFromPublicInvite = false;
        }
        [DataMember]
        public bool? IsForgotUsername { get; set; }

        [DataMember]
        public string EmailAddress { get; set; }
        [DataMember]
        public Guid TemporaryUserId { get; set; }

        [DataMember]
        public Guid UserID { get; set; }

        [DataMember]
        public Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        [DataMember]
        public Boolean IsRegistration { get; set; }

        [DataMember]
        public Boolean IsSearchInvite { get; set; }
        [DataMember]
       
        public string UserName { get; set; }
        [DataMember]
       
        public string Password { get; set; }
        [DataMember]
       
        public DateTime AccountExpiry { get; set; }

        [DataMember]
        public string PasswordVerificationKeyURL { get; set; }

        [DataMember]
        public bool IsColp { get; set; }
        [DataMember]
        public bool IsFromOrganisationInternalInvite { get; set; }
        [DataMember]
        public bool IsFromPublicInvite { get; set; }
        [DataMember]
        public bool IsFromProfessionalInvite { get; set; }
        [DataMember]
        public Guid UserAccountOrganisationID { get; set; }
        [DataMember]
        public OrganisationTypeEnum OrganisationTypeEnumValue { get; set; }
        [DataMember]
        public UserTypeEnum UserTypeEnumValue { get; set; }

        [DataMember]
        public bool IsPaymentSuccessful { get; set; }
    }
}
