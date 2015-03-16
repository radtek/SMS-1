using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
//Bec.TargetFramework.Entities
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Infrastructure.Log;
//using Fabrik.Common;
using ServiceStack.Text;

namespace Bec.TargetFramework.Business.Logic
{
    using Bec.TargetFramework.Aop.Aspects;
    using Bec.TargetFramework.Business.Infrastructure.Interfaces;
    using Bec.TargetFramework.Entities;
    using EnsureThat;

    [Trace(TraceExceptionsOnly = true)]
    public class AddressLogic : LogicBase, IAddressLogic
    {
        public AddressLogic(ILogger logger, ICacheProvider cacheProvider) : base(logger, cacheProvider)
        {
        }

        public List<PostCodeDTO> FindAddressesByPostCode(string postCode, string buildingNameOrNumber)
        {
            Ensure.That(postCode).IsNotNullOrEmpty();

            var client = new PostcodeAnywhere.PostcodeAnywhere_SoapClient();
            
            var key = "EN93-RT99-CK59-GP54";
            var userName = "CLEAR11146";
            string building = "";
            if (!string.IsNullOrEmpty(buildingNameOrNumber))
            {
                building = buildingNameOrNumber;
            }

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
            Ensure.That(postCode).IsNotNullOrEmpty();

            WebRequest request =
                WebRequest.Create(string.Format("http://maps.googleapis.com/maps/api/geocode/json?address={0}&sensor=false", postCode.Trim().Replace(" ", "")));

            request.Credentials = CredentialCache.DefaultCredentials;

            var result = JsonSerializer.DeserializeResponse<GoogleGeoCodeResponse>(request.GetResponse());

            return result;
        }
    }
}
