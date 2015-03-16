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
    [DataContract]
    public class PostCodeDTO
    {
        [DataMember]
        public string PostCode { get; set; }

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
                StringBuilder sb = new StringBuilder();

                if (!string.IsNullOrEmpty(Company))
                    sb.Append(Company + ", ");

                sb.Append(Line1);
                if (!string.IsNullOrEmpty(Line2))
                    sb.Append(", " + Line2);
                if (!string.IsNullOrEmpty(Line3))
                    sb.Append(", " + Line3);
                if (!string.IsNullOrEmpty(PostTown))
                    sb.Append(", " + PostTown);

                return sb.ToString();

            }
            set { value = ""; }
        }
    }
}
