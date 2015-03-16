using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using Bec.TargetFramework.Entities.Validators;
using FluentValidation;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace Bec.TargetFramework.Entities
{
    [DataContract]
    [Serializable]
    [KnownType(typeof(List<TermsnConditionsDTO>))] 
      public class TermsnConditionsDTO
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public Guid NotificationId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string VerificationCode { get; set; }
        [DataMember]
        public string UsersVerificationData { get; set; }

    }

    
}