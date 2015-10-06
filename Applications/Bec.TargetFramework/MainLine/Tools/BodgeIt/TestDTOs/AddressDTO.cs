using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodgeIt.TestDTOs
{
    public class AddressDTO
    {
        #region Constructors

        public AddressDTO()
        {
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid AddressID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string PrimaryContactName { get; set; }

        [DataMember]
        public string Line1 { get; set; }

        [DataMember]
        public string Line2 { get; set; }

        [DataMember]
        public string Line3 { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string StateOrProvince { get; set; }

        [DataMember]
        public string County { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public string PostOfficeBox { get; set; }

        [DataMember]
        public string PostalCode { get; set; }

        [DataMember]
        public string UTCOffSet { get; set; }

        [DataMember]
        public global::System.Nullable<double> Latitude { get; set; }

        [DataMember]
        public global::System.Nullable<double> Longitude { get; set; }

        [DataMember]
        public string Telephone1 { get; set; }

        [DataMember]
        public string Telephone2 { get; set; }

        [DataMember]
        public string Telephone3 { get; set; }

        [DataMember]
        public string Fax { get; set; }

        [DataMember]
        public global::System.Guid ParentID { get; set; }

        [DataMember]
        public int AddressTypeID { get; set; }

        [DataMember]
        public int AddressNumber { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsPrimaryAddress { get; set; }

        [DataMember]
        public global::System.Nullable<int> AddressCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<int> AddressSubTypeID { get; set; }

        [DataMember]
        public string BuildingName { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public string CountryCode { get; set; }

        [DataMember]
        public string AdditionalAddressInformation { get; set; }

        [DataMember]
        public string Town { get; set; }

        [DataMember]
        public global::System.Nullable<int> Order { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> ModifiedOn { get; set; }

        [DataMember]
        public string ModifiedBy { get; set; }

        [DataMember]
        public global::System.Nullable<long> RowVersion { get; set; }

        #endregion
    }
}
