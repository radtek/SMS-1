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
    [Serializable]
    [DataContract]
    public class PostCodeDTO
    {
        [DataMember]
        public string Postcode { get; set; }

        [DataMember]
        public string Line1 { get; set; }

        [DataMember]
        public string Line2 { get; set; }

        [DataMember]
        public string Line3 { get; set; }

        [DataMember]
        public string Line4 { get; set; }

        [DataMember]
        public string Line5 { get; set; }

        [DataMember]
        public string PostTown { get; set; }

        [DataMember]
        public string County { get; set; }

        [DataMember]
        public string BuildingName { get; set; }

        [DataMember]
        public string PrimaryStreet { get; set; }

        [DataMember]
        public string Mailsort { get; set; }

        [DataMember]
        public string Barcode { get; set; }

        [DataMember]
        public string Department { get; set; }

        [DataMember]
        public string Company { get; set; }

        [DataMember]
        public string FullAddress
        {
            get
            {
                return string.Join(", ", new List<string> { Company, BuildingName, Line1, Line2, Line3, PostTown }.Where(x => !string.IsNullOrWhiteSpace(x)));
            }
            set { }
        }
    }
}
