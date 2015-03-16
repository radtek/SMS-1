using Bec.TargetFramework.Entities.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Entities
{
   
    public partial class AddressDTO
    {
        //public AddressDTO()
        //{
        //    ShowIsPrimaryAddress = true;
        //    ShowPrimaryContactName = false;
        //}

        //[DataMember]
        //public System.Guid AddressID { get; set; }
        // 
        // 
        [DataMember]
        public int? InternationalAddress { get; set; }

        [DataMember]
        public bool AddressIsInUK { get; set; }
        [DataMember]
        public string ID { get; set; }

        [DataMember]
        public string AddressTotalMonths { get; set; }


        [DataMember]
        public string AddressIDString { get; set; }
        [DataMember]
        public int AddressMonths { get; set; }
        [DataMember]
        public int AddressYear { get; set; }

        [DataMember]
        public string ContainerID { get; set; }

        [DataMember]
        public bool ShowIsPrimaryAddress { get; set; }
        [DataMember]
        public bool ShowPrimaryContactName { get; set; }
    }
}
