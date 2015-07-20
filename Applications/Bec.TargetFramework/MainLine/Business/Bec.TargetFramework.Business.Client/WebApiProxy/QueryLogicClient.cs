using Bec.TargetFramework.Business.Client.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Text;

namespace Bec.TargetFramework.Business.Client.Interfaces
{
    public partial interface IQueryLogicClient : IClientBase
    {

        /// <param name="id"></param>
        /// <returns></returns>
        Task<Newtonsoft.Json.Linq.JObject> GetAsync(String id, string query);

        /// <param name="id"></param>
        /// <returns></returns>
        Newtonsoft.Json.Linq.JObject Get(String id, string query);
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
        public virtual Task<Newtonsoft.Json.Linq.JObject> GetAsync(String id, string query)
        {
            id = id.UrlEncode();
            string _user = getHttpContextUser();
            return GetAsync<Newtonsoft.Json.Linq.JObject>("api/QueryLogic/Get/" + id + "?" + query, _user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public virtual Newtonsoft.Json.Linq.JObject Get(String id, string query)
        {
            id = id.UrlEncode();
            string _user = getHttpContextUser();
            return Task.Run(() => GetAsync<Newtonsoft.Json.Linq.JObject>("api/QueryLogic/Get/" + id + "?" + query, _user)).Result;
        }

        #endregion
    }
}
