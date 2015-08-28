

using System.Runtime.Serialization;
namespace Bec.TargetFramework.Entities
{
    [DataContract]
    /// <summary>
    /// Represents a request for tax calculation
    /// </summary>
    public partial class CalculateTaxRequestDTO
    {
        [DataMember]
        /// <summary>
        /// Gets or sets a customer
        /// </summary>
        public VUserDTO Customer { get; set; }
         [DataMember]
       
        /// <summary>
        /// Gets or sets an address
        /// </summary>
        public AddressDTO Address { get; set; }
         [DataMember]
       
        /// <summary>
        /// Gets or sets a tax category identifier
        /// </summary>
        public int TaxCategoryId { get; set; }
    }
}
