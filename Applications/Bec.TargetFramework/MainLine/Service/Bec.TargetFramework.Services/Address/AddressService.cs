using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Entities.DTO;
using Fabrik.Common;
using ServiceStack.Text;

namespace Bec.TargetFramework.Services.Address
{
    public class AddressService : IAddressService
    {
        public List<PostCodeDTO> FindAddressesByPostCode(string postCode, string buildingNameOrNumber)
        {
            Ensure.NotNull(postCode);

            var client = new PostCodeSearch.PostcodeAnywhere_SoapClient();

            var key = "EN93-RT99-CK59-GP54";
            var userName = "CLEAR11146";
            string building = "";
            if (buildingNameOrNumber.IsNotNullOrEmpty())
                building = buildingNameOrNumber;

            var response = client.PostcodeAnywhere_Interactive_RetrieveByParts_v1_00(key, "", building, "", "",
                postCode.Replace(" ", "").Trim(), userName);

            List<PostCodeDTO> dtos = new List<PostCodeDTO>();

            response.ToList().ForEach(item =>
            {
                PostCodeDTO dto = new PostCodeDTO();
                dto.Company = item.Company;
                dto.County = item.County;
                dto.Department = item.Department;
                dto.BuildingName = item.BuildingName;
                dto.Line1 = item.Line1;
                dto.Line2 = item.Line2;
                dto.Line3 = item.Line3;
                dto.PostCode = item.Postcode;
                dto.PostTown = item.PostTown;
                dto.PrimaryStreet = item.PrimaryStreet;

                dtos.Add(dto);
            });

            return dtos;
        }

        public GoogleGeoCodeResponse GeoCodePostcode(string postCode)
        {
            Ensure.NotNullOrEmpty(postCode);

            WebRequest request =
                WebRequest.Create("http://maps.googleapis.com/maps/api/geocode/json?address=" + postCode.Trim().Replace(" ", "") + "&sensor=false");

            request.Credentials = CredentialCache.DefaultCredentials;

            var result = JsonSerializer.DeserializeResponse<GoogleGeoCodeResponse>(request.GetResponse());

            return result;
        }
    }

    public class GoogleGeoCodeResponse
    {

        public string status { get; set; }
        public results[] results { get; set; }

    }

    public class results
    {
        public string formatted_address { get; set; }
        public geometry geometry { get; set; }
        public string[] types { get; set; }
        public address_component[] address_components { get; set; }
    }

    public class geometry
    {
        public string location_type { get; set; }
        public location location { get; set; }
    }

    public class location
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }

    public class address_component
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public string[] types { get; set; }
    }
}
