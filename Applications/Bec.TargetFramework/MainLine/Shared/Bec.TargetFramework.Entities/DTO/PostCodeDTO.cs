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
    public class PostCodeDTOWrapper
    {
        public List<PostCodeDTO> Items { get; set; }
    }

    public class PostCodeDTO
    {
        public string Postcode { get; set; }

        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string Line3 { get; set; }

        public string Line4 { get; set; }

        public string Line5 { get; set; }

        public string PostTown { get; set; }

        public string County { get; set; }

        public string BuildingName { get; set; }

        public string PrimaryStreet { get; set; }

        public int Mailsort { get; set; }

        public string Barcode { get; set; }

        public string Department { get; set; }

        public string Company { get; set; }

        [DataMember]
        public string FullAddress
        {
            get
            {
                return string.Join(", ", new List<string> { Company, BuildingName, Line1, Line2, Line3, PostTown }.Where(x => !string.IsNullOrWhiteSpace(x)));
            }
        }
    }
}
