
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities.DTO
{
    [DataContract]
    public class CreateShoppingCartDTO
    {
        public Guid OrganisationId { get; set; }
        public int PaymentMethodTypeID { get; set; }
        public int PaymentCartTypeID { get; set; }
    }
}
