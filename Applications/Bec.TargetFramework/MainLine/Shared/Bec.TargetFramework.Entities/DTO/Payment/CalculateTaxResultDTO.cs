using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    /// <summary>
    /// Represents a result of tax calculation
    /// </summary>
    public partial class CalculateTaxResultDTO
    {
        public CalculateTaxResultDTO()
        {
            this.Errors = new List<string>();
        }

        [DataMember]
        /// <summary>
        /// Gets or sets a tax rate
        /// </summary>
        public decimal TaxRate { get; set; }
         [DataMember]
       
        /// <summary>
        /// Gets or sets an address
        /// </summary>
        public IList<string> Errors { get; set; }

        public bool Success
        {
            get 
            { 
                return this.Errors.Count == 0; 
            }
        }

        public void AddError(string error)
        {
            this.Errors.Add(error);
        }
    }
}
