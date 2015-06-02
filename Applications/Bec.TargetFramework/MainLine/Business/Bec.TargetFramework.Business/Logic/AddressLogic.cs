using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;
using EnsureThat;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Logic
{
    [Trace(TraceExceptionsOnly = true)]
    public class AddressLogic : LogicBase
    {
        HttpClient httpClient;
        public AddressLogic(ILogger logger, ICacheProvider cacheProvider) : base(logger, cacheProvider)
        {
            httpClient = new HttpClient { BaseAddress = new Uri("http://services.postcodeanywhere.co.uk/PostcodeAnywhere/Interactive/RetrieveByParts/v1.00/") };
        }

        public async Task<List<PostCodeDTO>> FindAddressesByPostCode(string postCode, string buildingNameOrNumber)
        {
            Ensure.That(postCode).IsNotNullOrEmpty();
            postCode = postCode.Replace(" ", "").Trim().ToLowerInvariant();

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("Key", "EN93-RT99-CK59-GP54");
            parameters.Add("UserName", "CLEAR11146");
            parameters.Add("Postcode", postCode);
            if (!string.IsNullOrEmpty(buildingNameOrNumber)) parameters.Add("Building", buildingNameOrNumber);

            var queryString = "json3.ws?" + string.Join("&", parameters.Select(p => p.Key + "=" + p.Value.UrlEncode()));

            using (var cacheClient = CacheProvider.CreateCacheClient(Logger))
            {
                var cacheResult = cacheClient.Get<string>(queryString).FromJson<List<PostCodeDTO>>();

                if (cacheResult != null)
                    return cacheResult;
                else
                {
                    var response = await httpClient.GetAsync(queryString);
                    response.EnsureSuccessStatusCode();
                    var results = await response.Content.ReadAsAsync<PostCodeDTOWrapper>();
                    cacheClient.Set(queryString, results.Items.ToJson(), TimeSpan.FromDays(1));
                    return results.Items;
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
