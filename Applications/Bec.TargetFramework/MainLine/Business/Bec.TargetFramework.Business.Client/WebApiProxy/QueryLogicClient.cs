using Bec.TargetFramework.Business.Client.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Text;
using System.Collections.Specialized;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Bec.TargetFramework.Business.Client.Interfaces
{
    public partial interface IQueryLogicClient : IClientBase
    {

        /// <param name="id"></param>
        /// <returns></returns>
        Task<Newtonsoft.Json.Linq.JObject> QueryAsync(String id, string query);

        //get a partially populated dto
        Task<IEnumerable<T>> QueryAsync<T>(String id, string query);

        ///// <param name="id"></param>
        ///// <returns></returns>
        //Newtonsoft.Json.Linq.JObject Get(String id, string query);

        Task UpdateGraphAsync(String id, Newtonsoft.Json.Linq.JObject patch, string filter);
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class QueryLogicClient : ClientBase, Interfaces.IQueryLogicClient
    {

        /// <summary>
        /// 
        /// </summary>
        public QueryLogicClient(string url)
            : base(url)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public QueryLogicClient(HttpMessageHandler handler, string url, bool disposeHandler = true)
            : base(handler, url, disposeHandler)
        {
        }

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual Task<Newtonsoft.Json.Linq.JObject> QueryAsync(String id, string query)
        {
            id = id.UrlEncode();
            string _user = getHttpContextUser();
            return GetAsync<Newtonsoft.Json.Linq.JObject>("api/QueryLogic/Get/" + id + "?" + query, _user);
        }

        public virtual async Task<IEnumerable<T>> QueryAsync<T>(String id, string query)
        {
            id = id.UrlEncode();
            string _user = getHttpContextUser();
            var jobj = await GetAsync<Newtonsoft.Json.Linq.JObject>("api/QueryLogic/Get/" + id + "?" + query, _user);
            Newtonsoft.Json.Linq.JArray arr = jobj["Items"] as Newtonsoft.Json.Linq.JArray;
            return arr.Select(i => JsonConvert.DeserializeObject<T>(i.ToString())).ToList();
        }

        public virtual Task UpdateGraphAsync(String id, Newtonsoft.Json.Linq.JObject patch, string filter)
        {
            id = id.UrlEncode();
            string _user = getHttpContextUser();
            return PostAsync<Newtonsoft.Json.Linq.JObject>("api/QueryLogic/UpdateGraph/" + id + "?" + filter, patch, _user);
        }

        #endregion
    }
}
