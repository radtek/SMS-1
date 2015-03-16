using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    public class LRServiceResponseStatusDTO
    {
        public LRServiceResponseStatusDTO()
        {
            IsAcknowledgement = false;
            IsRejection = false;
        }

        [DataMember]
        public bool IsAcknowledgement { get; set; }
        [DataMember]
        public bool IsRejection { get; set; }
        [DataMember]
        public string ExternalReference { get; set; }
        [DataMember]
        public int TypeCode { get; set; }
        [DataMember]
        public AcknowledgementDTO Acknowledgement { get; set; }
        [DataMember]
        public RejectionDTO Rejection { get; set; }
    }
    [DataContract]
    public class AcknowledgementDTO
    {
        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string ID { get; set; }

        [DataMember]
        public DateTime Date { get; set; }
    }
    [DataContract]
    public class RejectionDTO
    {
        public RejectionDTO()
        {
            ValidationErrors = new List<ValidationErrorDTO>();
        }

        [DataMember]
        public string Reason { get; set; }
        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public List<ValidationErrorDTO> ValidationErrors { get; set; } 
    }

    public class ValidationErrorDTO
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
