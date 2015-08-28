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
    public class PasswordResetSecret
    {
        #region Properties
        [DataMember]
        public virtual global :: System.Guid PasswordResetSecretID 
        { get; 
          set; 
        }

        [DataMember]
        public virtual int QuestionID
        { get; 
          set; 
        }

        [DataMember]
        public virtual string Answer 
        { get; 
          set; 
        }
        #endregion
        #region Generic
        [DataMember]
        public virtual string Question
        {
            get;
            set;
        }
        #endregion
    }
}
