/*
 * Copyright (c) Brock Allen.  All rights reserved.
 * see license.txt
 */

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace BrockAllen.MembershipReboot
{
    [DataContract]
    [Serializable]
    public class UserLoginValidation
    {
        [DataMember]
        public virtual bool valid
        {
            get;
            set;
        }

        [DataMember]
        public virtual string validationMessage
        {
            get;
            set;
        }
         [DataMember]
        public UserAccount UserAccount { get; set; }
    }
}
