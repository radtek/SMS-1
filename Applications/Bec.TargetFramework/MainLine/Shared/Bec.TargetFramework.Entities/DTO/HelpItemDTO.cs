﻿using System;
using System.Runtime.Serialization;
namespace Bec.TargetFramework.Entities
{    
    public partial class HelpItemDTO
    {
        [DataMember]
        public int Status { get; set; }
    }
}
