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
                building = buildingNameOrNumber.ToLowerInvariant();
            }

            var pcTrimmed = postCode.Replace(" ", "").Trim().ToLowerInvariant();

            using (var cacheClient = CacheProvider.CreateCacheClient(Logger))
            {
                string cacheKey = pcTrimmed + "*" + building;
                var cacheResult = cacheClient.Get<List<PostCodeDTO>>(cacheKey);

                if (cacheResult != null)
                    return cacheResult;
                else
                {
                    var response = client.PostcodeAnywhere_Interactive_RetrieveByParts_v1_00(key, "", building, "", "", pcTrimmed, userName);

                    var dtos = response.Select(item => new PostCodeDTO
                    {
                        Company = item.Company,
                        County = item.County,
                        Department = item.Department,
                        BuildingName = item.BuildingName,
                        Line1 = item.Line1,
                        Line2 = item.Line2,
                        Line3 = item.Line3,
                        Postcode = item.Postcode,
                        PostTown = item.PostTown,
                        PrimaryStreet = item.PrimaryStreet
                    }).ToList();

                    cacheClient.Set(cacheKey, dtos, TimeSpan.FromDays(1));

                    return dtos;
                }
            }
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
